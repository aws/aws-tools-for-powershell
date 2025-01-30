/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// to track the instance for each request. When the load balancer receives a request,
    /// it first checks to see if this cookie is present in the request. If so, the load balancer
    /// sends the request to the application server specified in the cookie. If not, the load
    /// balancer sends the request to a server that is chosen based on the existing load-balancing
    /// algorithm.
    /// </para><para>
    /// A cookie is inserted into the response for binding subsequent requests from the same
    /// user to that server. The validity of the cookie is based on the cookie expiration
    /// time, which is specified in the policy configuration.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/elasticloadbalancing/latest/classic/elb-sticky-sessions.html#enable-sticky-sessions-duration">Duration-Based
    /// Session Stickiness</a> in the <i>Classic Load Balancers Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "ELBLBCookieStickinessPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Elastic Load Balancing CreateLBCookieStickinessPolicy API operation.", Operation = new[] {"CreateLBCookieStickinessPolicy"}, SelectReturnType = typeof(Amazon.ElasticLoadBalancing.Model.CreateLBCookieStickinessPolicyResponse))]
    [AWSCmdletOutput("None or Amazon.ElasticLoadBalancing.Model.CreateLBCookieStickinessPolicyResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ElasticLoadBalancing.Model.CreateLBCookieStickinessPolicyResponse) be returned by specifying '-Select *'."
    )]
    public partial class NewELBLBCookieStickinessPolicyCmdlet : AmazonElasticLoadBalancingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CookieExpirationPeriod
        /// <summary>
        /// <para>
        /// <para>The time period, in seconds, after which the cookie should be considered stale. If
        /// you do not specify this parameter, the default value is 0, which indicates that the
        /// sticky session should last for the duration of the browser session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.Int64? CookieExpirationPeriod { get; set; }
        #endregion
        
        #region Parameter LoadBalancerName
        /// <summary>
        /// <para>
        /// <para>The name of the load balancer.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String LoadBalancerName { get; set; }
        #endregion
        
        #region Parameter PolicyName
        /// <summary>
        /// <para>
        /// <para>The name of the policy being created. Policy names must consist of alphanumeric characters
        /// and dashes (-). This name must be unique within the set of policies for this load
        /// balancer.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String PolicyName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticLoadBalancing.Model.CreateLBCookieStickinessPolicyResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the LoadBalancerName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^LoadBalancerName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^LoadBalancerName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LoadBalancerName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ELBLBCookieStickinessPolicy (CreateLBCookieStickinessPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticLoadBalancing.Model.CreateLBCookieStickinessPolicyResponse, NewELBLBCookieStickinessPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.LoadBalancerName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CookieExpirationPeriod = this.CookieExpirationPeriod;
            context.LoadBalancerName = this.LoadBalancerName;
            #if MODULAR
            if (this.LoadBalancerName == null && ParameterWasBound(nameof(this.LoadBalancerName)))
            {
                WriteWarning("You are passing $null as a value for parameter LoadBalancerName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PolicyName = this.PolicyName;
            #if MODULAR
            if (this.PolicyName == null && ParameterWasBound(nameof(this.PolicyName)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.ElasticLoadBalancing.Model.CreateLBCookieStickinessPolicyRequest();
            
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
        
        private Amazon.ElasticLoadBalancing.Model.CreateLBCookieStickinessPolicyResponse CallAWSServiceOperation(IAmazonElasticLoadBalancing client, Amazon.ElasticLoadBalancing.Model.CreateLBCookieStickinessPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Load Balancing", "CreateLBCookieStickinessPolicy");
            try
            {
                #if DESKTOP
                return client.CreateLBCookieStickinessPolicy(request);
                #elif CORECLR
                return client.CreateLBCookieStickinessPolicyAsync(request).GetAwaiter().GetResult();
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
            public System.Int64? CookieExpirationPeriod { get; set; }
            public System.String LoadBalancerName { get; set; }
            public System.String PolicyName { get; set; }
            public System.Func<Amazon.ElasticLoadBalancing.Model.CreateLBCookieStickinessPolicyResponse, NewELBLBCookieStickinessPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
