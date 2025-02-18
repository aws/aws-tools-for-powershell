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
using System.Threading;
using Amazon.ServiceDiscovery;
using Amazon.ServiceDiscovery.Model;

namespace Amazon.PowerShell.Cmdlets.SD
{
    /// <summary>
    /// Creates a service. This action defines the configuration for the following entities:
    /// 
    ///  <ul><li><para>
    /// For public and private DNS namespaces, one of the following combinations of DNS records
    /// in Amazon Route 53:
    /// </para><ul><li><para><c>A</c></para></li><li><para><c>AAAA</c></para></li><li><para><c>A</c> and <c>AAAA</c></para></li><li><para><c>SRV</c></para></li><li><para><c>CNAME</c></para></li></ul></li><li><para>
    /// Optionally, a health check
    /// </para></li></ul><para>
    /// After you create the service, you can submit a <a href="https://docs.aws.amazon.com/cloud-map/latest/api/API_RegisterInstance.html">RegisterInstance</a>
    /// request, and Cloud Map uses the values in the configuration to create the specified
    /// entities.
    /// </para><para>
    /// For the current quota on the number of instances that you can register using the same
    /// namespace and using the same service, see <a href="https://docs.aws.amazon.com/cloud-map/latest/dg/cloud-map-limits.html">Cloud
    /// Map quotas</a> in the <i>Cloud Map Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SDService", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ServiceDiscovery.Model.Service")]
    [AWSCmdlet("Calls the AWS Cloud Map CreateService API operation.", Operation = new[] {"CreateService"}, SelectReturnType = typeof(Amazon.ServiceDiscovery.Model.CreateServiceResponse))]
    [AWSCmdletOutput("Amazon.ServiceDiscovery.Model.Service or Amazon.ServiceDiscovery.Model.CreateServiceResponse",
        "This cmdlet returns an Amazon.ServiceDiscovery.Model.Service object.",
        "The service call response (type Amazon.ServiceDiscovery.Model.CreateServiceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSDServiceCmdlet : AmazonServiceDiscoveryClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CreatorRequestId
        /// <summary>
        /// <para>
        /// <para>A unique string that identifies the request and that allows failed <c>CreateService</c>
        /// requests to be retried without the risk of running the operation twice. <c>CreatorRequestId</c>
        /// can be any unique string (for example, a date/timestamp).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CreatorRequestId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DnsConfig
        /// <summary>
        /// <para>
        /// <para>A complex type that contains information about the Amazon Route 53 records that you
        /// want Cloud Map to create when you register an instance. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ServiceDiscovery.Model.DnsConfig DnsConfig { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_FailureThreshold
        /// <summary>
        /// <para>
        /// <para>The number of consecutive health checks that an endpoint must pass or fail for Route 53
        /// to change the current status of the endpoint from unhealthy to healthy or the other
        /// way around. For more information, see <a href="https://docs.aws.amazon.com/Route53/latest/DeveloperGuide/dns-failover-determining-health-of-endpoints.html">How
        /// Route 53 Determines Whether an Endpoint Is Healthy</a> in the <i>Route 53 Developer
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? HealthCheckConfig_FailureThreshold { get; set; }
        #endregion
        
        #region Parameter HealthCheckCustomConfig
        /// <summary>
        /// <para>
        /// <para>A complex type that contains information about an optional custom health check.</para><important><para>If you specify a health check configuration, you can specify either <c>HealthCheckCustomConfig</c>
        /// or <c>HealthCheckConfig</c> but not both.</para></important><para>You can't add, update, or delete a <c>HealthCheckCustomConfig</c> configuration from
        /// an existing service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ServiceDiscovery.Model.HealthCheckCustomConfig HealthCheckCustomConfig { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name that you want to assign to the service.</para><note><para>Do not include sensitive information in the name if the namespace is discoverable
        /// by public DNS queries.</para></note><para>If you want Cloud Map to create an <c>SRV</c> record when you register an instance
        /// and you're using a system that requires a specific <c>SRV</c> format, such as <a href="http://www.haproxy.org/">HAProxy</a>,
        /// specify the following for <c>Name</c>:</para><ul><li><para>Start the name with an underscore (_), such as <c>_exampleservice</c>.</para></li><li><para>End the name with <i>._protocol</i>, such as <c>._tcp</c>.</para></li></ul><para>When you register an instance, Cloud Map creates an <c>SRV</c> record and assigns
        /// a name to the record by concatenating the service name and the namespace name (for
        /// example,</para><para><c>_exampleservice._tcp.example.com</c>).</para><note><para>For services that are accessible by DNS queries, you can't create multiple services
        /// with names that differ only by case (such as EXAMPLE and example). Otherwise, these
        /// services have the same DNS name and can't be distinguished. However, if you use a
        /// namespace that's only accessible by API calls, then you can create services that with
        /// names that differ only by case.</para></note>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter NamespaceId
        /// <summary>
        /// <para>
        /// <para>The ID of the namespace that you want to use to create the service. The namespace
        /// ID must be specified, but it can be specified either here or in the <c>DnsConfig</c>
        /// object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NamespaceId { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_ResourcePath
        /// <summary>
        /// <para>
        /// <para>The path that you want Route 53 to request when performing health checks. The path
        /// can be any value that your endpoint returns an HTTP status code of a 2xx or 3xx format
        /// for when the endpoint is healthy. An example file is <c>/docs/route53-health-check.html</c>.
        /// Route 53 automatically adds the DNS name for the service. If you don't specify a value
        /// for <c>ResourcePath</c>, the default value is <c>/</c>.</para><para>If you specify <c>TCP</c> for <c>Type</c>, you must <i>not</i> specify a value for
        /// <c>ResourcePath</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HealthCheckConfig_ResourcePath { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to add to the service. Each tag consists of a key and an optional value that
        /// you define. Tags keys can be up to 128 characters in length, and tag values can be
        /// up to 256 characters in length.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ServiceDiscovery.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_Type
        /// <summary>
        /// <para>
        /// <para>The type of health check that you want to create, which indicates how Route 53 determines
        /// whether an endpoint is healthy.</para><important><para>You can't change the value of <c>Type</c> after you create a health check.</para></important><para>You can create the following types of health checks:</para><ul><li><para><b>HTTP</b>: Route 53 tries to establish a TCP connection. If successful, Route 53
        /// submits an HTTP request and waits for an HTTP status code of 200 or greater and less
        /// than 400.</para></li><li><para><b>HTTPS</b>: Route 53 tries to establish a TCP connection. If successful, Route 53
        /// submits an HTTPS request and waits for an HTTP status code of 200 or greater and less
        /// than 400.</para><important><para>If you specify HTTPS for the value of <c>Type</c>, the endpoint must support TLS v1.0
        /// or later.</para></important></li><li><para><b>TCP</b>: Route 53 tries to establish a TCP connection.</para><para>If you specify <c>TCP</c> for <c>Type</c>, don't specify a value for <c>ResourcePath</c>.</para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/Route53/latest/DeveloperGuide/dns-failover-determining-health-of-endpoints.html">How
        /// Route 53 Determines Whether an Endpoint Is Healthy</a> in the <i>Route 53 Developer
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ServiceDiscovery.HealthCheckType")]
        public Amazon.ServiceDiscovery.HealthCheckType HealthCheckConfig_Type { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>If present, specifies that the service instances are only discoverable using the <c>DiscoverInstances</c>
        /// API operation. No DNS records is registered for the service instances. The only valid
        /// value is <c>HTTP</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ServiceDiscovery.ServiceTypeOption")]
        public Amazon.ServiceDiscovery.ServiceTypeOption Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Service'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ServiceDiscovery.Model.CreateServiceResponse).
        /// Specifying the name of a property of type Amazon.ServiceDiscovery.Model.CreateServiceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Service";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SDService (CreateService)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ServiceDiscovery.Model.CreateServiceResponse, NewSDServiceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CreatorRequestId = this.CreatorRequestId;
            context.Description = this.Description;
            context.DnsConfig = this.DnsConfig;
            context.HealthCheckConfig_FailureThreshold = this.HealthCheckConfig_FailureThreshold;
            context.HealthCheckConfig_ResourcePath = this.HealthCheckConfig_ResourcePath;
            context.HealthCheckConfig_Type = this.HealthCheckConfig_Type;
            context.HealthCheckCustomConfig = this.HealthCheckCustomConfig;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NamespaceId = this.NamespaceId;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ServiceDiscovery.Model.Tag>(this.Tag);
            }
            context.Type = this.Type;
            
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
            var requestHealthCheckConfigIsNull = true;
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
            if (cmdletContext.NamespaceId != null)
            {
                request.NamespaceId = cmdletContext.NamespaceId;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.ServiceDiscovery.Model.CreateServiceResponse CallAWSServiceOperation(IAmazonServiceDiscovery client, Amazon.ServiceDiscovery.Model.CreateServiceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cloud Map", "CreateService");
            try
            {
                return client.CreateServiceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String NamespaceId { get; set; }
            public List<Amazon.ServiceDiscovery.Model.Tag> Tag { get; set; }
            public Amazon.ServiceDiscovery.ServiceTypeOption Type { get; set; }
            public System.Func<Amazon.ServiceDiscovery.Model.CreateServiceResponse, NewSDServiceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Service;
        }
        
    }
}
