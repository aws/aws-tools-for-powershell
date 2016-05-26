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
    /// This action creates a new health check.
    /// 
    ///  
    /// <para>
    /// To create a new health check, send a <code>POST</code> request to the <code>/<i>Route
    /// 53 API version</i>/healthcheck</code> resource. The request body must include a document
    /// with a <code>CreateHealthCheckRequest</code> element. The response returns the <code>CreateHealthCheckResponse</code>
    /// element that contains metadata about the health check.
    /// </para>
    /// </summary>
    [Cmdlet("New", "R53HealthCheck")]
    [OutputType("Amazon.Route53.Model.CreateHealthCheckResponse")]
    [AWSCmdlet("Invokes the CreateHealthCheck operation against Amazon Route 53.", Operation = new[] {"CreateHealthCheck"})]
    [AWSCmdletOutput("Amazon.Route53.Model.CreateHealthCheckResponse",
        "This cmdlet returns a Amazon.Route53.Model.CreateHealthCheckResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewR53HealthCheckCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        #region Parameter CallerReference
        /// <summary>
        /// <para>
        /// <para>A unique string that identifies the request and that allows failed <code>CreateHealthCheck</code>
        /// requests to be retried without the risk of executing the operation twice. You must
        /// use a unique <code>CallerReference</code> string every time you create a health check.
        /// <code>CallerReference</code> can be any unique string; you might choose to use a string
        /// that identifies your project.</para><para>Valid characters are any Unicode code points that are legal in an XML 1.0 document.
        /// The UTF-8 encoding of the value must be less than 128 bytes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String CallerReference { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_ChildHealthCheck
        /// <summary>
        /// <para>
        /// <para>For a specified parent health check, a list of <code>HealthCheckId</code> values for
        /// the associated child health checks.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("HealthCheckConfig_ChildHealthChecks")]
        public System.String[] HealthCheckConfig_ChildHealthCheck { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_EnableSNI
        /// <summary>
        /// <para>
        /// <para>Specify whether you want Amazon Route 53 to send the value of <code>FullyQualifiedDomainName</code>
        /// to the endpoint in the <code>client_hello</code> message during TLS negotiation. If
        /// you don't specify a value for <code>EnableSNI</code>, Amazon Route 53 defaults to
        /// <code>true</code> when <code>Type</code> is <code>HTTPS</code> or <code>HTTPS_STR_MATCH</code>
        /// and defaults to <code>false</code> when <code>Type</code> is any other value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean HealthCheckConfig_EnableSNI { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_FailureThreshold
        /// <summary>
        /// <para>
        /// <para>The number of consecutive health checks that an endpoint must pass or fail for Amazon
        /// Route 53 to change the current status of the endpoint from unhealthy to healthy or
        /// vice versa.</para><para>Valid values are integers between 1 and 10. For more information, see "How Amazon
        /// Route 53 Determines Whether an Endpoint Is Healthy" in the Amazon Route 53 Developer
        /// Guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 HealthCheckConfig_FailureThreshold { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_FullyQualifiedDomainName
        /// <summary>
        /// <para>
        /// <para>Fully qualified domain name of the instance to be health checked.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String HealthCheckConfig_FullyQualifiedDomainName { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_HealthThreshold
        /// <summary>
        /// <para>
        /// <para>The minimum number of child health checks that must be healthy for Amazon Route 53
        /// to consider the parent health check to be healthy. Valid values are integers between
        /// 0 and 256, inclusive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 HealthCheckConfig_HealthThreshold { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_InsufficientDataHealthStatus
        /// <summary>
        /// <para>
        /// <para>The status of the health check when CloudWatch has insufficient data about the state
        /// of associated alarm. Valid values are <code>Healthy</code>, <code>Unhealthy</code>
        /// and <code>LastKnownStatus</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Route53.InsufficientDataHealthStatus")]
        public Amazon.Route53.InsufficientDataHealthStatus HealthCheckConfig_InsufficientDataHealthStatus { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_Inverted
        /// <summary>
        /// <para>
        /// <para>A boolean value that indicates whether the status of health check should be inverted.
        /// For example, if a health check is healthy but <code>Inverted</code> is <code>True</code>,
        /// then Amazon Route 53 considers the health check to be unhealthy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean HealthCheckConfig_Inverted { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_IPAddress
        /// <summary>
        /// <para>
        /// <para>IP Address of the instance being checked. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String HealthCheckConfig_IPAddress { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_MeasureLatency
        /// <summary>
        /// <para>
        /// <para>A Boolean value that indicates whether you want Amazon Route 53 to measure the latency
        /// between health checkers in multiple AWS regions and your endpoint and to display CloudWatch
        /// latency graphs in the Amazon Route 53 console.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean HealthCheckConfig_MeasureLatency { get; set; }
        #endregion
        
        #region Parameter AlarmIdentifier_Name
        /// <summary>
        /// <para>
        /// <para>The name of the CloudWatch alarm.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("HealthCheckConfig_AlarmIdentifier_Name")]
        public System.String AlarmIdentifier_Name { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_Port
        /// <summary>
        /// <para>
        /// <para>Port on which connection will be opened to the instance to health check. For HTTP
        /// and HTTP_STR_MATCH this defaults to 80 if the port is not specified. For HTTPS and
        /// HTTPS_STR_MATCH this defaults to 443 if the port is not specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 HealthCheckConfig_Port { get; set; }
        #endregion
        
        #region Parameter AlarmIdentifier_Region
        /// <summary>
        /// <para>
        /// <para>The <code>CloudWatchRegion</code> that the CloudWatch alarm was created in.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("HealthCheckConfig_AlarmIdentifier_Region")]
        [AWSConstantClassSource("Amazon.Route53.CloudWatchRegion")]
        public Amazon.Route53.CloudWatchRegion AlarmIdentifier_Region { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_Region
        /// <summary>
        /// <para>
        /// <para>A list of <code>HealthCheckRegion</code> values that you want Amazon Route 53 to use
        /// to perform health checks for the specified endpoint. You must specify at least three
        /// regions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("HealthCheckConfig_Regions")]
        public System.String[] HealthCheckConfig_Region { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_RequestInterval
        /// <summary>
        /// <para>
        /// <para>The number of seconds between the time that Amazon Route 53 gets a response from your
        /// endpoint and the time that it sends the next health-check request.</para><para>Each Amazon Route 53 health checker makes requests at this interval. Valid values
        /// are 10 and 30. The default value is 30.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 HealthCheckConfig_RequestInterval { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_ResourcePath
        /// <summary>
        /// <para>
        /// <para>Path to ping on the instance to check the health. Required for HTTP, HTTPS, HTTP_STR_MATCH,
        /// and HTTPS_STR_MATCH health checks. The HTTP request is issued to the instance on the
        /// given port and path.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String HealthCheckConfig_ResourcePath { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_SearchString
        /// <summary>
        /// <para>
        /// <para>A string to search for in the body of a health check response. Required for HTTP_STR_MATCH
        /// and HTTPS_STR_MATCH health checks. Amazon Route 53 considers case when searching for
        /// <code>SearchString</code> in the response body. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String HealthCheckConfig_SearchString { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_Type
        /// <summary>
        /// <para>
        /// <para>The type of health check to be performed. Currently supported types are TCP, HTTP,
        /// HTTPS, HTTP_STR_MATCH, HTTPS_STR_MATCH, CALCULATED and CLOUDWATCH_METRIC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Route53.HealthCheckType")]
        public Amazon.Route53.HealthCheckType HealthCheckConfig_Type { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.CallerReference = this.CallerReference;
            context.HealthCheckConfig_IPAddress = this.HealthCheckConfig_IPAddress;
            if (ParameterWasBound("HealthCheckConfig_Port"))
                context.HealthCheckConfig_Port = this.HealthCheckConfig_Port;
            context.HealthCheckConfig_Type = this.HealthCheckConfig_Type;
            context.HealthCheckConfig_ResourcePath = this.HealthCheckConfig_ResourcePath;
            context.HealthCheckConfig_FullyQualifiedDomainName = this.HealthCheckConfig_FullyQualifiedDomainName;
            context.HealthCheckConfig_SearchString = this.HealthCheckConfig_SearchString;
            if (ParameterWasBound("HealthCheckConfig_RequestInterval"))
                context.HealthCheckConfig_RequestInterval = this.HealthCheckConfig_RequestInterval;
            if (ParameterWasBound("HealthCheckConfig_FailureThreshold"))
                context.HealthCheckConfig_FailureThreshold = this.HealthCheckConfig_FailureThreshold;
            if (ParameterWasBound("HealthCheckConfig_MeasureLatency"))
                context.HealthCheckConfig_MeasureLatency = this.HealthCheckConfig_MeasureLatency;
            if (ParameterWasBound("HealthCheckConfig_Inverted"))
                context.HealthCheckConfig_Inverted = this.HealthCheckConfig_Inverted;
            if (ParameterWasBound("HealthCheckConfig_HealthThreshold"))
                context.HealthCheckConfig_HealthThreshold = this.HealthCheckConfig_HealthThreshold;
            if (this.HealthCheckConfig_ChildHealthCheck != null)
            {
                context.HealthCheckConfig_ChildHealthChecks = new List<System.String>(this.HealthCheckConfig_ChildHealthCheck);
            }
            if (ParameterWasBound("HealthCheckConfig_EnableSNI"))
                context.HealthCheckConfig_EnableSNI = this.HealthCheckConfig_EnableSNI;
            if (this.HealthCheckConfig_Region != null)
            {
                context.HealthCheckConfig_Regions = new List<System.String>(this.HealthCheckConfig_Region);
            }
            context.HealthCheckConfig_AlarmIdentifier_Region = this.AlarmIdentifier_Region;
            context.HealthCheckConfig_AlarmIdentifier_Name = this.AlarmIdentifier_Name;
            context.HealthCheckConfig_InsufficientDataHealthStatus = this.HealthCheckConfig_InsufficientDataHealthStatus;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Route53.Model.CreateHealthCheckRequest();
            
            if (cmdletContext.CallerReference != null)
            {
                request.CallerReference = cmdletContext.CallerReference;
            }
            
             // populate HealthCheckConfig
            bool requestHealthCheckConfigIsNull = true;
            request.HealthCheckConfig = new Amazon.Route53.Model.HealthCheckConfig();
            System.String requestHealthCheckConfig_healthCheckConfig_IPAddress = null;
            if (cmdletContext.HealthCheckConfig_IPAddress != null)
            {
                requestHealthCheckConfig_healthCheckConfig_IPAddress = cmdletContext.HealthCheckConfig_IPAddress;
            }
            if (requestHealthCheckConfig_healthCheckConfig_IPAddress != null)
            {
                request.HealthCheckConfig.IPAddress = requestHealthCheckConfig_healthCheckConfig_IPAddress;
                requestHealthCheckConfigIsNull = false;
            }
            System.Int32? requestHealthCheckConfig_healthCheckConfig_Port = null;
            if (cmdletContext.HealthCheckConfig_Port != null)
            {
                requestHealthCheckConfig_healthCheckConfig_Port = cmdletContext.HealthCheckConfig_Port.Value;
            }
            if (requestHealthCheckConfig_healthCheckConfig_Port != null)
            {
                request.HealthCheckConfig.Port = requestHealthCheckConfig_healthCheckConfig_Port.Value;
                requestHealthCheckConfigIsNull = false;
            }
            Amazon.Route53.HealthCheckType requestHealthCheckConfig_healthCheckConfig_Type = null;
            if (cmdletContext.HealthCheckConfig_Type != null)
            {
                requestHealthCheckConfig_healthCheckConfig_Type = cmdletContext.HealthCheckConfig_Type;
            }
            if (requestHealthCheckConfig_healthCheckConfig_Type != null)
            {
                request.HealthCheckConfig.Type = requestHealthCheckConfig_healthCheckConfig_Type;
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
            System.String requestHealthCheckConfig_healthCheckConfig_FullyQualifiedDomainName = null;
            if (cmdletContext.HealthCheckConfig_FullyQualifiedDomainName != null)
            {
                requestHealthCheckConfig_healthCheckConfig_FullyQualifiedDomainName = cmdletContext.HealthCheckConfig_FullyQualifiedDomainName;
            }
            if (requestHealthCheckConfig_healthCheckConfig_FullyQualifiedDomainName != null)
            {
                request.HealthCheckConfig.FullyQualifiedDomainName = requestHealthCheckConfig_healthCheckConfig_FullyQualifiedDomainName;
                requestHealthCheckConfigIsNull = false;
            }
            System.String requestHealthCheckConfig_healthCheckConfig_SearchString = null;
            if (cmdletContext.HealthCheckConfig_SearchString != null)
            {
                requestHealthCheckConfig_healthCheckConfig_SearchString = cmdletContext.HealthCheckConfig_SearchString;
            }
            if (requestHealthCheckConfig_healthCheckConfig_SearchString != null)
            {
                request.HealthCheckConfig.SearchString = requestHealthCheckConfig_healthCheckConfig_SearchString;
                requestHealthCheckConfigIsNull = false;
            }
            System.Int32? requestHealthCheckConfig_healthCheckConfig_RequestInterval = null;
            if (cmdletContext.HealthCheckConfig_RequestInterval != null)
            {
                requestHealthCheckConfig_healthCheckConfig_RequestInterval = cmdletContext.HealthCheckConfig_RequestInterval.Value;
            }
            if (requestHealthCheckConfig_healthCheckConfig_RequestInterval != null)
            {
                request.HealthCheckConfig.RequestInterval = requestHealthCheckConfig_healthCheckConfig_RequestInterval.Value;
                requestHealthCheckConfigIsNull = false;
            }
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
            System.Boolean? requestHealthCheckConfig_healthCheckConfig_MeasureLatency = null;
            if (cmdletContext.HealthCheckConfig_MeasureLatency != null)
            {
                requestHealthCheckConfig_healthCheckConfig_MeasureLatency = cmdletContext.HealthCheckConfig_MeasureLatency.Value;
            }
            if (requestHealthCheckConfig_healthCheckConfig_MeasureLatency != null)
            {
                request.HealthCheckConfig.MeasureLatency = requestHealthCheckConfig_healthCheckConfig_MeasureLatency.Value;
                requestHealthCheckConfigIsNull = false;
            }
            System.Boolean? requestHealthCheckConfig_healthCheckConfig_Inverted = null;
            if (cmdletContext.HealthCheckConfig_Inverted != null)
            {
                requestHealthCheckConfig_healthCheckConfig_Inverted = cmdletContext.HealthCheckConfig_Inverted.Value;
            }
            if (requestHealthCheckConfig_healthCheckConfig_Inverted != null)
            {
                request.HealthCheckConfig.Inverted = requestHealthCheckConfig_healthCheckConfig_Inverted.Value;
                requestHealthCheckConfigIsNull = false;
            }
            System.Int32? requestHealthCheckConfig_healthCheckConfig_HealthThreshold = null;
            if (cmdletContext.HealthCheckConfig_HealthThreshold != null)
            {
                requestHealthCheckConfig_healthCheckConfig_HealthThreshold = cmdletContext.HealthCheckConfig_HealthThreshold.Value;
            }
            if (requestHealthCheckConfig_healthCheckConfig_HealthThreshold != null)
            {
                request.HealthCheckConfig.HealthThreshold = requestHealthCheckConfig_healthCheckConfig_HealthThreshold.Value;
                requestHealthCheckConfigIsNull = false;
            }
            List<System.String> requestHealthCheckConfig_healthCheckConfig_ChildHealthCheck = null;
            if (cmdletContext.HealthCheckConfig_ChildHealthChecks != null)
            {
                requestHealthCheckConfig_healthCheckConfig_ChildHealthCheck = cmdletContext.HealthCheckConfig_ChildHealthChecks;
            }
            if (requestHealthCheckConfig_healthCheckConfig_ChildHealthCheck != null)
            {
                request.HealthCheckConfig.ChildHealthChecks = requestHealthCheckConfig_healthCheckConfig_ChildHealthCheck;
                requestHealthCheckConfigIsNull = false;
            }
            System.Boolean? requestHealthCheckConfig_healthCheckConfig_EnableSNI = null;
            if (cmdletContext.HealthCheckConfig_EnableSNI != null)
            {
                requestHealthCheckConfig_healthCheckConfig_EnableSNI = cmdletContext.HealthCheckConfig_EnableSNI.Value;
            }
            if (requestHealthCheckConfig_healthCheckConfig_EnableSNI != null)
            {
                request.HealthCheckConfig.EnableSNI = requestHealthCheckConfig_healthCheckConfig_EnableSNI.Value;
                requestHealthCheckConfigIsNull = false;
            }
            List<System.String> requestHealthCheckConfig_healthCheckConfig_Region = null;
            if (cmdletContext.HealthCheckConfig_Regions != null)
            {
                requestHealthCheckConfig_healthCheckConfig_Region = cmdletContext.HealthCheckConfig_Regions;
            }
            if (requestHealthCheckConfig_healthCheckConfig_Region != null)
            {
                request.HealthCheckConfig.Regions = requestHealthCheckConfig_healthCheckConfig_Region;
                requestHealthCheckConfigIsNull = false;
            }
            Amazon.Route53.InsufficientDataHealthStatus requestHealthCheckConfig_healthCheckConfig_InsufficientDataHealthStatus = null;
            if (cmdletContext.HealthCheckConfig_InsufficientDataHealthStatus != null)
            {
                requestHealthCheckConfig_healthCheckConfig_InsufficientDataHealthStatus = cmdletContext.HealthCheckConfig_InsufficientDataHealthStatus;
            }
            if (requestHealthCheckConfig_healthCheckConfig_InsufficientDataHealthStatus != null)
            {
                request.HealthCheckConfig.InsufficientDataHealthStatus = requestHealthCheckConfig_healthCheckConfig_InsufficientDataHealthStatus;
                requestHealthCheckConfigIsNull = false;
            }
            Amazon.Route53.Model.AlarmIdentifier requestHealthCheckConfig_healthCheckConfig_AlarmIdentifier = null;
            
             // populate AlarmIdentifier
            bool requestHealthCheckConfig_healthCheckConfig_AlarmIdentifierIsNull = true;
            requestHealthCheckConfig_healthCheckConfig_AlarmIdentifier = new Amazon.Route53.Model.AlarmIdentifier();
            Amazon.Route53.CloudWatchRegion requestHealthCheckConfig_healthCheckConfig_AlarmIdentifier_alarmIdentifier_Region = null;
            if (cmdletContext.HealthCheckConfig_AlarmIdentifier_Region != null)
            {
                requestHealthCheckConfig_healthCheckConfig_AlarmIdentifier_alarmIdentifier_Region = cmdletContext.HealthCheckConfig_AlarmIdentifier_Region;
            }
            if (requestHealthCheckConfig_healthCheckConfig_AlarmIdentifier_alarmIdentifier_Region != null)
            {
                requestHealthCheckConfig_healthCheckConfig_AlarmIdentifier.Region = requestHealthCheckConfig_healthCheckConfig_AlarmIdentifier_alarmIdentifier_Region;
                requestHealthCheckConfig_healthCheckConfig_AlarmIdentifierIsNull = false;
            }
            System.String requestHealthCheckConfig_healthCheckConfig_AlarmIdentifier_alarmIdentifier_Name = null;
            if (cmdletContext.HealthCheckConfig_AlarmIdentifier_Name != null)
            {
                requestHealthCheckConfig_healthCheckConfig_AlarmIdentifier_alarmIdentifier_Name = cmdletContext.HealthCheckConfig_AlarmIdentifier_Name;
            }
            if (requestHealthCheckConfig_healthCheckConfig_AlarmIdentifier_alarmIdentifier_Name != null)
            {
                requestHealthCheckConfig_healthCheckConfig_AlarmIdentifier.Name = requestHealthCheckConfig_healthCheckConfig_AlarmIdentifier_alarmIdentifier_Name;
                requestHealthCheckConfig_healthCheckConfig_AlarmIdentifierIsNull = false;
            }
             // determine if requestHealthCheckConfig_healthCheckConfig_AlarmIdentifier should be set to null
            if (requestHealthCheckConfig_healthCheckConfig_AlarmIdentifierIsNull)
            {
                requestHealthCheckConfig_healthCheckConfig_AlarmIdentifier = null;
            }
            if (requestHealthCheckConfig_healthCheckConfig_AlarmIdentifier != null)
            {
                request.HealthCheckConfig.AlarmIdentifier = requestHealthCheckConfig_healthCheckConfig_AlarmIdentifier;
                requestHealthCheckConfigIsNull = false;
            }
             // determine if request.HealthCheckConfig should be set to null
            if (requestHealthCheckConfigIsNull)
            {
                request.HealthCheckConfig = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private static Amazon.Route53.Model.CreateHealthCheckResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.CreateHealthCheckRequest request)
        {
            return client.CreateHealthCheck(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String CallerReference { get; set; }
            public System.String HealthCheckConfig_IPAddress { get; set; }
            public System.Int32? HealthCheckConfig_Port { get; set; }
            public Amazon.Route53.HealthCheckType HealthCheckConfig_Type { get; set; }
            public System.String HealthCheckConfig_ResourcePath { get; set; }
            public System.String HealthCheckConfig_FullyQualifiedDomainName { get; set; }
            public System.String HealthCheckConfig_SearchString { get; set; }
            public System.Int32? HealthCheckConfig_RequestInterval { get; set; }
            public System.Int32? HealthCheckConfig_FailureThreshold { get; set; }
            public System.Boolean? HealthCheckConfig_MeasureLatency { get; set; }
            public System.Boolean? HealthCheckConfig_Inverted { get; set; }
            public System.Int32? HealthCheckConfig_HealthThreshold { get; set; }
            public List<System.String> HealthCheckConfig_ChildHealthChecks { get; set; }
            public System.Boolean? HealthCheckConfig_EnableSNI { get; set; }
            public List<System.String> HealthCheckConfig_Regions { get; set; }
            public Amazon.Route53.CloudWatchRegion HealthCheckConfig_AlarmIdentifier_Region { get; set; }
            public System.String HealthCheckConfig_AlarmIdentifier_Name { get; set; }
            public Amazon.Route53.InsufficientDataHealthStatus HealthCheckConfig_InsufficientDataHealthStatus { get; set; }
        }
        
    }
}
