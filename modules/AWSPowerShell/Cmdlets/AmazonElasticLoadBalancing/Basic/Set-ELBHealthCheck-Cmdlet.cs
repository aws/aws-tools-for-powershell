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
    /// Specifies the health check settings to use when evaluating the health state of your
    /// back-end instances.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="http://docs.aws.amazon.com/ElasticLoadBalancing/latest/DeveloperGuide/elb-healthchecks.html">Configure
    /// Health Checks</a> in the <i>Elastic Load Balancing Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Set", "ELBHealthCheck", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticLoadBalancing.Model.HealthCheck")]
    [AWSCmdlet("Invokes the ConfigureHealthCheck operation against Elastic Load Balancing.", Operation = new[] {"ConfigureHealthCheck"})]
    [AWSCmdletOutput("Amazon.ElasticLoadBalancing.Model.HealthCheck",
        "This cmdlet returns a HealthCheck object.",
        "The service call response (type Amazon.ElasticLoadBalancing.Model.ConfigureHealthCheckResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class SetELBHealthCheckCmdlet : AmazonElasticLoadBalancingClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The number of consecutive health checks successes required before moving the instance
        /// to the <code>Healthy</code> state.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 HealthCheck_HealthyThreshold { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The approximate interval, in seconds, between health checks of an individual instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 HealthCheck_Interval { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the load balancer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String LoadBalancerName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The instance being checked. The protocol is either TCP, HTTP, HTTPS, or SSL. The range
        /// of valid ports is one (1) through 65535.</para><para>TCP is the default, specified as a TCP: port pair, for example "TCP:5000". In this
        /// case, a health check simply attempts to open a TCP connection to the instance on the
        /// specified port. Failure to connect within the configured timeout is considered unhealthy.</para><para>SSL is also specified as SSL: port pair, for example, SSL:5000.</para><para>For HTTP/HTTPS, you must include a ping path in the string. HTTP is specified as a
        /// HTTP:port;/;PathToPing; grouping, for example "HTTP:80/weather/us/wa/seattle". In
        /// this case, a HTTP GET request is issued to the instance on the given port and path.
        /// Any answer other than "200 OK" within the timeout period is considered unhealthy.</para><para>The total length of the HTTP ping target must be 1024 16-bit Unicode characters or
        /// less.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String HealthCheck_Target { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, during which no response means a failed health check.</para><para>This value must be less than the <code>Interval</code> value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 HealthCheck_Timeout { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The number of consecutive health check failures required before moving the instance
        /// to the <code>Unhealthy</code> state.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 HealthCheck_UnhealthyThreshold { get; set; }
        
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-ELBHealthCheck (ConfigureHealthCheck)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (ParameterWasBound("HealthCheck_HealthyThreshold"))
                context.HealthCheck_HealthyThreshold = this.HealthCheck_HealthyThreshold;
            if (ParameterWasBound("HealthCheck_Interval"))
                context.HealthCheck_Interval = this.HealthCheck_Interval;
            context.HealthCheck_Target = this.HealthCheck_Target;
            if (ParameterWasBound("HealthCheck_Timeout"))
                context.HealthCheck_Timeout = this.HealthCheck_Timeout;
            if (ParameterWasBound("HealthCheck_UnhealthyThreshold"))
                context.HealthCheck_UnhealthyThreshold = this.HealthCheck_UnhealthyThreshold;
            context.LoadBalancerName = this.LoadBalancerName;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.ElasticLoadBalancing.Model.ConfigureHealthCheckRequest();
            
            
             // populate HealthCheck
            bool requestHealthCheckIsNull = true;
            request.HealthCheck = new Amazon.ElasticLoadBalancing.Model.HealthCheck();
            System.Int32? requestHealthCheck_healthCheck_HealthyThreshold = null;
            if (cmdletContext.HealthCheck_HealthyThreshold != null)
            {
                requestHealthCheck_healthCheck_HealthyThreshold = cmdletContext.HealthCheck_HealthyThreshold.Value;
            }
            if (requestHealthCheck_healthCheck_HealthyThreshold != null)
            {
                request.HealthCheck.HealthyThreshold = requestHealthCheck_healthCheck_HealthyThreshold.Value;
                requestHealthCheckIsNull = false;
            }
            System.Int32? requestHealthCheck_healthCheck_Interval = null;
            if (cmdletContext.HealthCheck_Interval != null)
            {
                requestHealthCheck_healthCheck_Interval = cmdletContext.HealthCheck_Interval.Value;
            }
            if (requestHealthCheck_healthCheck_Interval != null)
            {
                request.HealthCheck.Interval = requestHealthCheck_healthCheck_Interval.Value;
                requestHealthCheckIsNull = false;
            }
            System.String requestHealthCheck_healthCheck_Target = null;
            if (cmdletContext.HealthCheck_Target != null)
            {
                requestHealthCheck_healthCheck_Target = cmdletContext.HealthCheck_Target;
            }
            if (requestHealthCheck_healthCheck_Target != null)
            {
                request.HealthCheck.Target = requestHealthCheck_healthCheck_Target;
                requestHealthCheckIsNull = false;
            }
            System.Int32? requestHealthCheck_healthCheck_Timeout = null;
            if (cmdletContext.HealthCheck_Timeout != null)
            {
                requestHealthCheck_healthCheck_Timeout = cmdletContext.HealthCheck_Timeout.Value;
            }
            if (requestHealthCheck_healthCheck_Timeout != null)
            {
                request.HealthCheck.Timeout = requestHealthCheck_healthCheck_Timeout.Value;
                requestHealthCheckIsNull = false;
            }
            System.Int32? requestHealthCheck_healthCheck_UnhealthyThreshold = null;
            if (cmdletContext.HealthCheck_UnhealthyThreshold != null)
            {
                requestHealthCheck_healthCheck_UnhealthyThreshold = cmdletContext.HealthCheck_UnhealthyThreshold.Value;
            }
            if (requestHealthCheck_healthCheck_UnhealthyThreshold != null)
            {
                request.HealthCheck.UnhealthyThreshold = requestHealthCheck_healthCheck_UnhealthyThreshold.Value;
                requestHealthCheckIsNull = false;
            }
             // determine if request.HealthCheck should be set to null
            if (requestHealthCheckIsNull)
            {
                request.HealthCheck = null;
            }
            if (cmdletContext.LoadBalancerName != null)
            {
                request.LoadBalancerName = cmdletContext.LoadBalancerName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.ConfigureHealthCheck(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.HealthCheck;
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
            public System.Int32? HealthCheck_HealthyThreshold { get; set; }
            public System.Int32? HealthCheck_Interval { get; set; }
            public System.String HealthCheck_Target { get; set; }
            public System.Int32? HealthCheck_Timeout { get; set; }
            public System.Int32? HealthCheck_UnhealthyThreshold { get; set; }
            public System.String LoadBalancerName { get; set; }
        }
        
    }
}
