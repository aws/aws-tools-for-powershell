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
    /// Creates or updates one or more records and optionally a health check based on the
    /// settings in a specified service. When you submit a <code>RegisterInstance</code> request,
    /// Amazon Route 53 does the following:
    /// 
    ///  <ul><li><para>
    /// For each DNS record that you define in the service specified by <code>ServiceId</code>,
    /// creates or updates a record in the hosted zone that is associated with the corresponding
    /// namespace
    /// </para></li><li><para>
    /// If the service includes <code>HealthCheckConfig</code>, creates or updates a health
    /// check based on the settings in the health check configuration
    /// </para></li><li><para>
    /// Associates the health check, if any, with each of the records
    /// </para></li></ul><important><para>
    /// One <code>RegisterInstance</code> request must complete before you can submit another
    /// request and specify the same service ID and instance ID.
    /// </para></important><para>
    /// For more information, see <a>CreateService</a>.
    /// </para><para>
    /// When Route 53 receives a DNS query for the specified DNS name, it returns the applicable
    /// value:
    /// </para><ul><li><para><b>If the health check is healthy</b>: returns all the records
    /// </para></li><li><para><b>If the health check is unhealthy</b>: returns the applicable value for the last
    /// healthy instance
    /// </para></li><li><para><b>If you didn't specify a health check configuration</b>: returns all the records
    /// </para></li></ul><para>
    /// For the current limit on the number of instances that you can register using the same
    /// namespace and using the same service, see <a href="http://docs.aws.amazon.com/Route53/latest/DeveloperGuide/DNSLimitations.html#limits-api-entities-autonaming">Limits
    /// on Auto Naming</a> in the <i>Route 53 Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SDInstanceRegistration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Route 53 Auto Naming RegisterInstance API operation.", Operation = new[] {"RegisterInstance"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.ServiceDiscovery.Model.RegisterInstanceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSDInstanceRegistrationCmdlet : AmazonServiceDiscoveryClientCmdlet, IExecutor
    {
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>A string map that contains the following information for the service that you specify
        /// in <code>ServiceId</code>:</para><ul><li><para>The attributes that apply to the records that are defined in the service. </para></li><li><para>For each attribute, the applicable value.</para></li></ul><para>Supported attribute keys include the following:</para><para><b>AWS_ALIAS_DNS_NAME</b></para><para><b /></para><para>If you want Route 53 to create an alias record that routes traffic to an Elastic Load
        /// Balancing load balancer, specify the DNS name that is associated with the load balancer.
        /// For information about how to get the DNS name, see "DNSName" in the topic <a href="http://docs.aws.amazon.com/http:/docs.aws.amazon.com/Route53/latest/APIReference/API_AliasTarget.html">AliasTarget</a>.</para><para>Note the following:</para><ul><li><para>The configuration for the service that is specified by <code>ServiceId</code> must
        /// include settings for an A record, an AAAA record, or both.</para></li><li><para>In the service that is specified by <code>ServiceId</code>, the value of <code>RoutingPolicy</code>
        /// must be <code>WEIGHTED</code>.</para></li><li><para>If the service that is specified by <code>ServiceId</code> includes <code>HealthCheckConfig</code>
        /// settings, Route 53 will create the health check, but it won't associate the health
        /// check with the alias record.</para></li><li><para>Auto naming currently doesn't support creating alias records that route traffic to
        /// AWS resources other than ELB load balancers.</para></li><li><para>If you specify a value for <code>AWS_ALIAS_DNS_NAME</code>, don't specify values for
        /// any of the <code>AWS_INSTANCE</code> attributes.</para></li></ul><para><b>AWS_INSTANCE_CNAME</b></para><para>If the service configuration includes a CNAME record, the domain name that you want
        /// Route 53 to return in response to DNS queries, for example, <code>example.com</code>.</para><para>This value is required if the service specified by <code>ServiceId</code> includes
        /// settings for an CNAME record.</para><para><b>AWS_INSTANCE_IPV4</b></para><para>If the service configuration includes an A record, the IPv4 address that you want
        /// Route 53 to return in response to DNS queries, for example, <code>192.0.2.44</code>.</para><para>This value is required if the service specified by <code>ServiceId</code> includes
        /// settings for an A record. If the service includes settings for an SRV record, you
        /// must specify a value for <code>AWS_INSTANCE_IPV4</code>, <code>AWS_INSTANCE_IPV6</code>,
        /// or both.</para><para><b>AWS_INSTANCE_IPV6</b></para><para>If the service configuration includes an AAAA record, the IPv6 address that you want
        /// Route 53 to return in response to DNS queries, for example, <code>2001:0db8:85a3:0000:0000:abcd:0001:2345</code>.</para><para>This value is required if the service specified by <code>ServiceId</code> includes
        /// settings for an AAAA record. If the service includes settings for an SRV record, you
        /// must specify a value for <code>AWS_INSTANCE_IPV4</code>, <code>AWS_INSTANCE_IPV6</code>,
        /// or both.</para><para><b>AWS_INSTANCE_PORT</b></para><para>If the service includes an SRV record, the value that you want Route 53 to return
        /// for the port.</para><para>If the service includes <code>HealthCheckConfig</code>, the port on the endpoint that
        /// you want Route 53 to send requests to. </para><para>This value is required if you specified settings for an SRV record when you created
        /// the service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Attributes")]
        public System.Collections.Hashtable Attribute { get; set; }
        #endregion
        
        #region Parameter CreatorRequestId
        /// <summary>
        /// <para>
        /// <para>A unique string that identifies the request and that allows failed <code>RegisterInstance</code>
        /// requests to be retried without the risk of executing the operation twice. You must
        /// use a unique <code>CreatorRequestId</code> string every time you submit a <code>RegisterInstance</code>
        /// request if you're registering additional instances for the same namespace and service.
        /// <code>CreatorRequestId</code> can be any unique string, for example, a date/time stamp.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CreatorRequestId { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>An identifier that you want to associate with the instance. Note the following:</para><ul><li><para>If the service that is specified by <code>ServiceId</code> includes settings for an
        /// SRV record, the value of <code>InstanceId</code> is automatically included as part
        /// of the value for the SRV record. For more information, see <a>DnsRecord$Type</a>.</para></li><li><para>You can use this value to update an existing instance.</para></li><li><para>To register a new instance, you must specify a value that is unique among instances
        /// that you register by using the same service. </para></li><li><para>If you specify an existing <code>InstanceId</code> and <code>ServiceId</code>, Route
        /// 53 updates the existing records. If there's also an existing health check, Route 53
        /// deletes the old health check and creates a new one. </para><note><para>The health check isn't deleted immediately, so it will still appear for a while if
        /// you submit a <code>ListHealthChecks</code> request, for example.</para></note></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter ServiceId
        /// <summary>
        /// <para>
        /// <para>The ID of the service that you want to use for settings for the records and health
        /// check that Route 53 will create.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ServiceId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("InstanceId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SDInstanceRegistration (RegisterInstance)"))
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
            
            if (this.Attribute != null)
            {
                context.Attributes = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Attribute.Keys)
                {
                    context.Attributes.Add((String)hashKey, (String)(this.Attribute[hashKey]));
                }
            }
            context.CreatorRequestId = this.CreatorRequestId;
            context.InstanceId = this.InstanceId;
            context.ServiceId = this.ServiceId;
            
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
            var request = new Amazon.ServiceDiscovery.Model.RegisterInstanceRequest();
            
            if (cmdletContext.Attributes != null)
            {
                request.Attributes = cmdletContext.Attributes;
            }
            if (cmdletContext.CreatorRequestId != null)
            {
                request.CreatorRequestId = cmdletContext.CreatorRequestId;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.ServiceId != null)
            {
                request.ServiceId = cmdletContext.ServiceId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.OperationId;
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
        
        private Amazon.ServiceDiscovery.Model.RegisterInstanceResponse CallAWSServiceOperation(IAmazonServiceDiscovery client, Amazon.ServiceDiscovery.Model.RegisterInstanceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53 Auto Naming", "RegisterInstance");
            try
            {
                #if DESKTOP
                return client.RegisterInstance(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.RegisterInstanceAsync(request);
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
            public Dictionary<System.String, System.String> Attributes { get; set; }
            public System.String CreatorRequestId { get; set; }
            public System.String InstanceId { get; set; }
            public System.String ServiceId { get; set; }
        }
        
    }
}
