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
    /// Specifies the health check settings to use when evaluating the health state of your
    /// EC2 instances.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/elasticloadbalancing/latest/classic/elb-healthchecks.html">Configure
    /// Health Checks for Your Load Balancer</a> in the <i>Classic Load Balancers Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Set", "ELBHealthCheck", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticLoadBalancing.Model.HealthCheck")]
    [AWSCmdlet("Calls the Elastic Load Balancing ConfigureHealthCheck API operation.", Operation = new[] {"ConfigureHealthCheck"}, SelectReturnType = typeof(Amazon.ElasticLoadBalancing.Model.ConfigureHealthCheckResponse))]
    [AWSCmdletOutput("Amazon.ElasticLoadBalancing.Model.HealthCheck or Amazon.ElasticLoadBalancing.Model.ConfigureHealthCheckResponse",
        "This cmdlet returns an Amazon.ElasticLoadBalancing.Model.HealthCheck object.",
        "The service call response (type Amazon.ElasticLoadBalancing.Model.ConfigureHealthCheckResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetELBHealthCheckCmdlet : AmazonElasticLoadBalancingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter HealthCheck_HealthyThreshold
        /// <summary>
        /// <para>
        /// <para>The number of consecutive health checks successes required before moving the instance
        /// to the <c>Healthy</c> state.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? HealthCheck_HealthyThreshold { get; set; }
        #endregion
        
        #region Parameter HealthCheck_Interval
        /// <summary>
        /// <para>
        /// <para>The approximate interval, in seconds, between health checks of an individual instance.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? HealthCheck_Interval { get; set; }
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
        
        #region Parameter HealthCheck_Target
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
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String HealthCheck_Target { get; set; }
        #endregion
        
        #region Parameter HealthCheck_Timeout
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, during which no response means a failed health check.</para><para>This value must be less than the <c>Interval</c> value.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? HealthCheck_Timeout { get; set; }
        #endregion
        
        #region Parameter HealthCheck_UnhealthyThreshold
        /// <summary>
        /// <para>
        /// <para>The number of consecutive health check failures required before moving the instance
        /// to the <c>Unhealthy</c> state.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? HealthCheck_UnhealthyThreshold { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'HealthCheck'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticLoadBalancing.Model.ConfigureHealthCheckResponse).
        /// Specifying the name of a property of type Amazon.ElasticLoadBalancing.Model.ConfigureHealthCheckResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "HealthCheck";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-ELBHealthCheck (ConfigureHealthCheck)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticLoadBalancing.Model.ConfigureHealthCheckResponse, SetELBHealthCheckCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.HealthCheck_HealthyThreshold = this.HealthCheck_HealthyThreshold;
            #if MODULAR
            if (this.HealthCheck_HealthyThreshold == null && ParameterWasBound(nameof(this.HealthCheck_HealthyThreshold)))
            {
                WriteWarning("You are passing $null as a value for parameter HealthCheck_HealthyThreshold which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HealthCheck_Interval = this.HealthCheck_Interval;
            #if MODULAR
            if (this.HealthCheck_Interval == null && ParameterWasBound(nameof(this.HealthCheck_Interval)))
            {
                WriteWarning("You are passing $null as a value for parameter HealthCheck_Interval which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HealthCheck_Target = this.HealthCheck_Target;
            #if MODULAR
            if (this.HealthCheck_Target == null && ParameterWasBound(nameof(this.HealthCheck_Target)))
            {
                WriteWarning("You are passing $null as a value for parameter HealthCheck_Target which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HealthCheck_Timeout = this.HealthCheck_Timeout;
            #if MODULAR
            if (this.HealthCheck_Timeout == null && ParameterWasBound(nameof(this.HealthCheck_Timeout)))
            {
                WriteWarning("You are passing $null as a value for parameter HealthCheck_Timeout which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HealthCheck_UnhealthyThreshold = this.HealthCheck_UnhealthyThreshold;
            #if MODULAR
            if (this.HealthCheck_UnhealthyThreshold == null && ParameterWasBound(nameof(this.HealthCheck_UnhealthyThreshold)))
            {
                WriteWarning("You are passing $null as a value for parameter HealthCheck_UnhealthyThreshold which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LoadBalancerName = this.LoadBalancerName;
            #if MODULAR
            if (this.LoadBalancerName == null && ParameterWasBound(nameof(this.LoadBalancerName)))
            {
                WriteWarning("You are passing $null as a value for parameter LoadBalancerName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ElasticLoadBalancing.Model.ConfigureHealthCheckRequest();
            
            
             // populate HealthCheck
            var requestHealthCheckIsNull = true;
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
        
        private Amazon.ElasticLoadBalancing.Model.ConfigureHealthCheckResponse CallAWSServiceOperation(IAmazonElasticLoadBalancing client, Amazon.ElasticLoadBalancing.Model.ConfigureHealthCheckRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Load Balancing", "ConfigureHealthCheck");
            try
            {
                #if DESKTOP
                return client.ConfigureHealthCheck(request);
                #elif CORECLR
                return client.ConfigureHealthCheckAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? HealthCheck_HealthyThreshold { get; set; }
            public System.Int32? HealthCheck_Interval { get; set; }
            public System.String HealthCheck_Target { get; set; }
            public System.Int32? HealthCheck_Timeout { get; set; }
            public System.Int32? HealthCheck_UnhealthyThreshold { get; set; }
            public System.String LoadBalancerName { get; set; }
            public System.Func<Amazon.ElasticLoadBalancing.Model.ConfigureHealthCheckResponse, SetELBHealthCheckCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.HealthCheck;
        }
        
    }
}
