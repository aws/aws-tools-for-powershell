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
using Amazon.Route53;
using Amazon.Route53.Model;

namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    /// This action updates an existing health check.
    /// 
    ///  
    /// <para>
    ///  To update a health check, send a <code>POST</code> request to the <code>2013-04-01/healthcheck/<i>health
    /// check ID</i></code> resource. The request body must include an XML document with an
    /// <code>UpdateHealthCheckRequest</code> element. The response returns an <code>UpdateHealthCheckResponse</code>
    /// element, which contains metadata about the health check.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "R53HealthCheck", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Route53.Model.HealthCheck")]
    [AWSCmdlet("Invokes the UpdateHealthCheck operation against AWS Route 53.", Operation = new[] {"UpdateHealthCheck"})]
    [AWSCmdletOutput("Amazon.Route53.Model.HealthCheck",
        "This cmdlet returns a HealthCheck object.",
        "The service call response (type UpdateHealthCheckResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UpdateR53HealthCheckCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The number of consecutive health checks that an endpoint must pass or fail for Route
        /// 53 to change the current status of the endpoint from unhealthy to healthy or vice
        /// versa.</para><para>Valid values are integers between 1 and 10. For more information, see "How Amazon
        /// Route 53 Determines Whether an Endpoint Is Healthy" in the Amazon Route 53 Developer
        /// Guide.</para><para>Specify this value only if you want to change it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Int32 FailureThreshold { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Fully qualified domain name of the instance to be health checked.</para><para>Specify this value only if you want to change it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String FullyQualifiedDomainName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ID of the health check to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String HealthCheckId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Optional. When you specify a health check version, Route 53 compares this value with
        /// the current value in the health check, which prevents you from updating the health
        /// check when the versions don't match. Using <code>HealthCheckVersion</code> lets you
        /// prevent overwriting another change to the health check.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Int64 HealthCheckVersion { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The IP address of the resource that you want to check.</para><para>Specify this value only if you want to change it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String IPAddress { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The port on which you want Route 53 to open a connection to perform health checks.</para><para>Specify this value only if you want to change it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Int32 Port { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The path that you want Amazon Route 53 to request when performing health checks. The
        /// path can be any value for which your endpoint will return an HTTP status code of 2xx
        /// or 3xx when the endpoint is healthy, for example the file /docs/route53-health-check.html.
        /// </para><para>Specify this value only if you want to change it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String ResourcePath { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>If the value of <code>Type</code> is <code>HTTP_STR_MATCH</code> or <code>HTTP_STR_MATCH</code>,
        /// the string that you want Route 53 to search for in the response body from the specified
        /// resource. If the string appears in the response body, Route 53 considers the resource
        /// healthy. </para><para>Specify this value only if you want to change it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String SearchString { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("HealthCheckId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-R53HealthCheck (UpdateHealthCheck)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.HealthCheckId = this.HealthCheckId;
            if (ParameterWasBound("HealthCheckVersion"))
                context.HealthCheckVersion = this.HealthCheckVersion;
            context.IPAddress = this.IPAddress;
            if (ParameterWasBound("Port"))
                context.Port = this.Port;
            context.ResourcePath = this.ResourcePath;
            context.FullyQualifiedDomainName = this.FullyQualifiedDomainName;
            context.SearchString = this.SearchString;
            if (ParameterWasBound("FailureThreshold"))
                context.FailureThreshold = this.FailureThreshold;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new UpdateHealthCheckRequest();
            
            if (cmdletContext.HealthCheckId != null)
            {
                request.HealthCheckId = cmdletContext.HealthCheckId;
            }
            if (cmdletContext.HealthCheckVersion != null)
            {
                request.HealthCheckVersion = cmdletContext.HealthCheckVersion.Value;
            }
            if (cmdletContext.IPAddress != null)
            {
                request.IPAddress = cmdletContext.IPAddress;
            }
            if (cmdletContext.Port != null)
            {
                request.Port = cmdletContext.Port.Value;
            }
            if (cmdletContext.ResourcePath != null)
            {
                request.ResourcePath = cmdletContext.ResourcePath;
            }
            if (cmdletContext.FullyQualifiedDomainName != null)
            {
                request.FullyQualifiedDomainName = cmdletContext.FullyQualifiedDomainName;
            }
            if (cmdletContext.SearchString != null)
            {
                request.SearchString = cmdletContext.SearchString;
            }
            if (cmdletContext.FailureThreshold != null)
            {
                request.FailureThreshold = cmdletContext.FailureThreshold.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.UpdateHealthCheck(request);
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
            public String HealthCheckId { get; set; }
            public Int64? HealthCheckVersion { get; set; }
            public String IPAddress { get; set; }
            public Int32? Port { get; set; }
            public String ResourcePath { get; set; }
            public String FullyQualifiedDomainName { get; set; }
            public String SearchString { get; set; }
            public Int32? FailureThreshold { get; set; }
        }
        
    }
}
