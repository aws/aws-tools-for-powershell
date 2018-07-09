/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.ServiceDiscovery;
using Amazon.ServiceDiscovery.Model;

namespace Amazon.PowerShell.Cmdlets.SD
{
    /// <summary>
    /// Creates a service, which defines the configuration for the following entities:
    /// 
    ///  <ul><li><para>
    /// Up to three records (A, AAAA, and SRV) or one CNAME record
    /// </para></li><li><para>
    /// Optionally, a health check
    /// </para></li></ul><para>
    /// After you create the service, you can submit a <a>RegisterInstance</a> request, and
    /// Amazon Route 53 uses the values in the configuration to create the specified entities.
    /// </para><para>
    /// For the current limit on the number of instances that you can register using the same
    /// namespace and using the same service, see <a href="http://docs.aws.amazon.com/Route53/latest/DeveloperGuide/DNSLimitations.html#limits-api-entities-autonaming">Limits
    /// on Auto Naming</a> in the <i>Route 53 Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SDService", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ServiceDiscovery.Model.Service")]
    [AWSCmdlet("Calls the Amazon Route 53 Auto Naming CreateService API operation.", Operation = new[] {"CreateService"})]
    [AWSCmdletOutput("Amazon.ServiceDiscovery.Model.Service",
        "This cmdlet returns a Service object.",
        "The service call response (type Amazon.ServiceDiscovery.Model.CreateServiceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSDServiceCmdlet : AmazonServiceDiscoveryClientCmdlet, IExecutor
    {
        
        #region Parameter CreatorRequestId
        /// <summary>
        /// <para>
        /// <para>A unique string that identifies the request and that allows failed <code>CreateService</code>
        /// requests to be retried without the risk of executing the operation twice. <code>CreatorRequestId</code>
        /// can be any unique string, for example, a date/time stamp.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CreatorRequestId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DnsConfig
        /// <summary>
        /// <para>
        /// <para>A complex type that contains information about the records that you want Route 53
        /// to create when you register an instance. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.ServiceDiscovery.Model.DnsConfig DnsConfig { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_FailureThreshold
        /// <summary>
        /// <para>
        /// <para>The number of consecutive health checks that an endpoint must pass or fail for Route
        /// 53 to change the current status of the endpoint from unhealthy to healthy or vice
        /// versa. For more information, see <a href="http://docs.aws.amazon.com/Route53/latest/DeveloperGuide/dns-failover-determining-health-of-endpoints.html">How
        /// Route 53 Determines Whether an Endpoint Is Healthy</a> in the <i>Route 53 Developer
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 HealthCheckConfig_FailureThreshold { get; set; }
        #endregion
        
        #region Parameter HealthCheckCustomConfig
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.ServiceDiscovery.Model.HealthCheckCustomConfig HealthCheckCustomConfig { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name that you want to assign to the service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_ResourcePath
        /// <summary>
        /// <para>
        /// <para>The path that you want Route 53 to request when performing health checks. The path
        /// can be any value for which your endpoint will return an HTTP status code of 2xx or
        /// 3xx when the endpoint is healthy, such as the file <code>/docs/route53-health-check.html</code>.
        /// Route 53 automatically adds the DNS name for the service and a leading forward slash
        /// (<code>/</code>) character. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String HealthCheckConfig_ResourcePath { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_Type
        /// <summary>
        /// <para>
        /// <para>The type of health check that you want to create, which indicates how Route 53 determines
        /// whether an endpoint is healthy.</para><important><para>You can't change the value of <code>Type</code> after you create a health check.</para></important><para>You can create the following types of health checks:</para><ul><li><para><b>HTTP</b>: Route 53 tries to establish a TCP connection. If successful, Route 53
        /// submits an HTTP request and waits for an HTTP status code of 200 or greater and less
        /// than 400.</para></li><li><para><b>HTTPS</b>: Route 53 tries to establish a TCP connection. If successful, Route
        /// 53 submits an HTTPS request and waits for an HTTP status code of 200 or greater and
        /// less than 400.</para><important><para>If you specify HTTPS for the value of <code>Type</code>, the endpoint must support
        /// TLS v1.0 or later.</para></important></li><li><para><b>TCP</b>: Route 53 tries to establish a TCP connection.</para></li></ul><para>For more information, see <a href="http://docs.aws.amazon.com/Route53/latest/DeveloperGuide/dns-failover-determining-health-of-endpoints.html">How
        /// Route 53 Determines Whether an Endpoint Is Healthy</a> in the <i>Route 53 Developer
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ServiceDiscovery.HealthCheckType")]
        public Amazon.ServiceDiscovery.HealthCheckType HealthCheckConfig_Type { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SDService (CreateService)"))
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
            
            context.CreatorRequestId = this.CreatorRequestId;
            context.Description = this.Description;
            context.DnsConfig = this.DnsConfig;
            if (ParameterWasBound("HealthCheckConfig_FailureThreshold"))
                context.HealthCheckConfig_FailureThreshold = this.HealthCheckConfig_FailureThreshold;
            context.HealthCheckConfig_ResourcePath = this.HealthCheckConfig_ResourcePath;
            context.HealthCheckConfig_Type = this.HealthCheckConfig_Type;
            context.HealthCheckCustomConfig = this.HealthCheckCustomConfig;
            context.Name = this.Name;
            
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
            var request = new Amazon.ServiceDiscovery.Model.CreateServiceRequest();
            
            if (cmdletContext.CreatorRequestId != null)
            {
                request.CreatorRequestId = cmdletContext.CreatorRequestId;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DnsConfig != null)
            {
                request.DnsConfig = cmdletContext.DnsConfig;
            }
            
             // populate HealthCheckConfig
            bool requestHealthCheckConfigIsNull = true;
            request.HealthCheckConfig = new Amazon.ServiceDiscovery.Model.HealthCheckConfig();
            System.Int32? requestHealthCheckConfig_healthCheckConfig_FailureThreshold = null;
            if (cmdletContext.HealthCheckConfig_FailureThreshold != null)
            {
                requestHealthCheckConfig_healthCheckConfig_FailureThreshold = cmdletContext.HealthCheckConfig_FailureThreshold.Value;
            }
            if (requestHealthCheckConfig_healthCheckConfig_FailureThreshold != null)
            {
                request.HealthCheckConfig.FailureThreshold = requestHealthCheckConfig_healthCheckConfig_FailureThreshold.Value;
                requestHealthCheckConfigIsNull = false;
            }
            System.String requestHealthCheckConfig_healthCheckConfig_ResourcePath = null;
            if (cmdletContext.HealthCheckConfig_ResourcePath != null)
            {
                requestHealthCheckConfig_healthCheckConfig_ResourcePath = cmdletContext.HealthCheckConfig_ResourcePath;
            }
            if (requestHealthCheckConfig_healthCheckConfig_ResourcePath != null)
            {
                request.HealthCheckConfig.ResourcePath = requestHealthCheckConfig_healthCheckConfig_ResourcePath;
                requestHealthCheckConfigIsNull = false;
            }
            Amazon.ServiceDiscovery.HealthCheckType requestHealthCheckConfig_healthCheckConfig_Type = null;
            if (cmdletContext.HealthCheckConfig_Type != null)
            {
                requestHealthCheckConfig_healthCheckConfig_Type = cmdletContext.HealthCheckConfig_Type;
            }
            if (requestHealthCheckConfig_healthCheckConfig_Type != null)
            {
                request.HealthCheckConfig.Type = requestHealthCheckConfig_healthCheckConfig_Type;
                requestHealthCheckConfigIsNull = false;
            }
             // determine if request.HealthCheckConfig should be set to null
            if (requestHealthCheckConfigIsNull)
            {
                request.HealthCheckConfig = null;
            }
            if (cmdletContext.HealthCheckCustomConfig != null)
            {
                request.HealthCheckCustomConfig = cmdletContext.HealthCheckCustomConfig;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Service;
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
        
        private Amazon.ServiceDiscovery.Model.CreateServiceResponse CallAWSServiceOperation(IAmazonServiceDiscovery client, Amazon.ServiceDiscovery.Model.CreateServiceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53 Auto Naming", "CreateService");
            try
            {
                #if DESKTOP
                return client.CreateService(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateServiceAsync(request);
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
            public System.String CreatorRequestId { get; set; }
            public System.String Description { get; set; }
            public Amazon.ServiceDiscovery.Model.DnsConfig DnsConfig { get; set; }
            public System.Int32? HealthCheckConfig_FailureThreshold { get; set; }
            public System.String HealthCheckConfig_ResourcePath { get; set; }
            public Amazon.ServiceDiscovery.HealthCheckType HealthCheckConfig_Type { get; set; }
            public Amazon.ServiceDiscovery.Model.HealthCheckCustomConfig HealthCheckCustomConfig { get; set; }
            public System.String Name { get; set; }
        }
        
    }
}
