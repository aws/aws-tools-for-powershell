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
    /// To update a health check, send a <code>POST</code> request to the <code>/<i>Route
    /// 53 API version</i>/healthcheck/<i>health check ID</i></code> resource. The request
    /// body must include a document with an <code>UpdateHealthCheckRequest</code> element.
    /// The response returns an <code>UpdateHealthCheckResponse</code> element, which contains
    /// metadata about the health check.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "R53HealthCheck", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Route53.Model.HealthCheck")]
    [AWSCmdlet("Invokes the UpdateHealthCheck operation against Amazon Route 53.", Operation = new[] {"UpdateHealthCheck"})]
    [AWSCmdletOutput("Amazon.Route53.Model.HealthCheck",
        "This cmdlet returns a HealthCheck object.",
        "The service call response (type Amazon.Route53.Model.UpdateHealthCheckResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UpdateR53HealthCheckCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        #region Parameter ChildHealthCheck
        /// <summary>
        /// <para>
        /// <para>For a specified parent health check, a list of <code>HealthCheckId</code> values for
        /// the associated child health checks.</para><para>Specify this value only if you want to change it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ChildHealthChecks")]
        public System.String[] ChildHealthCheck { get; set; }
        #endregion
        
        #region Parameter EnableSNI
        /// <summary>
        /// <para>
        /// <para>Specify whether you want Amazon Route 53 to send the value of <code>FullyQualifiedDomainName</code>
        /// to the endpoint in the <code>client_hello</code> message during TLS negotiation. If
        /// you don't specify a value for <code>EnableSNI</code>, Amazon Route 53 defaults to
        /// <code>true</code> when <code>Type</code> is <code>HTTPS</code> or <code>HTTPS_STR_MATCH</code>
        /// and defaults to <code>false</code> when <code>Type</code> is any other value.</para><para>Specify this value only if you want to change it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean EnableSNI { get; set; }
        #endregion
        
        #region Parameter FailureThreshold
        /// <summary>
        /// <para>
        /// <para>The number of consecutive health checks that an endpoint must pass or fail for Amazon
        /// Route 53 to change the current status of the endpoint from unhealthy to healthy or
        /// vice versa.</para><para>Valid values are integers between 1 and 10. For more information, see "How Amazon
        /// Route 53 Determines Whether an Endpoint Is Healthy" in the Amazon Route 53 Developer
        /// Guide.</para><para>Specify this value only if you want to change it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 FailureThreshold { get; set; }
        #endregion
        
        #region Parameter FullyQualifiedDomainName
        /// <summary>
        /// <para>
        /// <para>Fully qualified domain name of the instance to be health checked.</para><para>Specify this value only if you want to change it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String FullyQualifiedDomainName { get; set; }
        #endregion
        
        #region Parameter HealthCheckId
        /// <summary>
        /// <para>
        /// <para>The ID of the health check to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String HealthCheckId { get; set; }
        #endregion
        
        #region Parameter HealthCheckVersion
        /// <summary>
        /// <para>
        /// <para>Optional. When you specify a health check version, Amazon Route 53 compares this value
        /// with the current value in the health check, which prevents you from updating the health
        /// check when the versions don't match. Using <code>HealthCheckVersion</code> lets you
        /// prevent overwriting another change to the health check.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 HealthCheckVersion { get; set; }
        #endregion
        
        #region Parameter HealthThreshold
        /// <summary>
        /// <para>
        /// <para>The minimum number of child health checks that must be healthy for Amazon Route 53
        /// to consider the parent health check to be healthy. Valid values are integers between
        /// 0 and 256, inclusive.</para><para>Specify this value only if you want to change it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 HealthThreshold { get; set; }
        #endregion
        
        #region Parameter InsufficientDataHealthStatus
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Route53.InsufficientDataHealthStatus")]
        public Amazon.Route53.InsufficientDataHealthStatus InsufficientDataHealthStatus { get; set; }
        #endregion
        
        #region Parameter Inverted
        /// <summary>
        /// <para>
        /// <para>A boolean value that indicates whether the status of health check should be inverted.
        /// For example, if a health check is healthy but <code>Inverted</code> is <code>True</code>,
        /// then Amazon Route 53 considers the health check to be unhealthy.</para><para>Specify this value only if you want to change it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Inverted { get; set; }
        #endregion
        
        #region Parameter IPAddress
        /// <summary>
        /// <para>
        /// <para>The IP address of the resource that you want to check.</para><para>Specify this value only if you want to change it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String IPAddress { get; set; }
        #endregion
        
        #region Parameter AlarmIdentifier_Name
        /// <summary>
        /// <para>
        /// <para>The name of the CloudWatch alarm.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AlarmIdentifier_Name { get; set; }
        #endregion
        
        #region Parameter Port
        /// <summary>
        /// <para>
        /// <para>The port on which you want Amazon Route 53 to open a connection to perform health
        /// checks.</para><para>Specify this value only if you want to change it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Port { get; set; }
        #endregion
        
        #region Parameter AlarmIdentifier_Region
        /// <summary>
        /// <para>
        /// <para>The <code>CloudWatchRegion</code> that the CloudWatch alarm was created in.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Route53.CloudWatchRegion")]
        public Amazon.Route53.CloudWatchRegion AlarmIdentifier_Region { get; set; }
        #endregion
        
        #region Parameter Region
        /// <summary>
        /// <para>
        /// <para>A list of <code>HealthCheckRegion</code> values that specify the Amazon EC2 regions
        /// that you want Amazon Route 53 to use to perform health checks. You must specify at
        /// least three regions.</para><note>When you remove a region from the list, Amazon Route 53 will briefly continue
        /// to check your endpoint from that region.</note><para>Specify this value only if you want to change it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Regions")]
        public System.String[] HealthCheckRegion { get; set; }
        #endregion
        
        #region Parameter ResourcePath
        /// <summary>
        /// <para>
        /// <para>The path that you want Amazon Route 53 to request when performing health checks. The
        /// path can be any value for which your endpoint will return an HTTP status code of 2xx
        /// or 3xx when the endpoint is healthy, for example the file /docs/route53-health-check.html.
        /// </para><para>Specify this value only if you want to change it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ResourcePath { get; set; }
        #endregion
        
        #region Parameter SearchString
        /// <summary>
        /// <para>
        /// <para>If the value of <code>Type</code> is <code>HTTP_STR_MATCH</code> or <code>HTTP_STR_MATCH</code>,
        /// the string that you want Amazon Route 53 to search for in the response body from the
        /// specified resource. If the string appears in the response body, Amazon Route 53 considers
        /// the resource healthy. Amazon Route 53 considers case when searching for <code>SearchString</code>
        /// in the response body.</para><para>Specify this value only if you want to change it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SearchString { get; set; }
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
            if (ParameterWasBound("Inverted"))
                context.Inverted = this.Inverted;
            if (ParameterWasBound("HealthThreshold"))
                context.HealthThreshold = this.HealthThreshold;
            if (this.ChildHealthCheck != null)
            {
                context.ChildHealthChecks = new List<System.String>(this.ChildHealthCheck);
            }
            if (ParameterWasBound("EnableSNI"))
                context.EnableSNI = this.EnableSNI;
            if (this.HealthCheckRegion != null)
            {
                context.Regions = new List<System.String>(this.HealthCheckRegion);
            }
            context.AlarmIdentifier_Region = this.AlarmIdentifier_Region;
            context.AlarmIdentifier_Name = this.AlarmIdentifier_Name;
            context.InsufficientDataHealthStatus = this.InsufficientDataHealthStatus;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Route53.Model.UpdateHealthCheckRequest();
            
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
            if (cmdletContext.Inverted != null)
            {
                request.Inverted = cmdletContext.Inverted.Value;
            }
            if (cmdletContext.HealthThreshold != null)
            {
                request.HealthThreshold = cmdletContext.HealthThreshold.Value;
            }
            if (cmdletContext.ChildHealthChecks != null)
            {
                request.ChildHealthChecks = cmdletContext.ChildHealthChecks;
            }
            if (cmdletContext.EnableSNI != null)
            {
                request.EnableSNI = cmdletContext.EnableSNI.Value;
            }
            if (cmdletContext.Regions != null)
            {
                request.Regions = cmdletContext.Regions;
            }
            
             // populate AlarmIdentifier
            bool requestAlarmIdentifierIsNull = true;
            request.AlarmIdentifier = new Amazon.Route53.Model.AlarmIdentifier();
            Amazon.Route53.CloudWatchRegion requestAlarmIdentifier_alarmIdentifier_Region = null;
            if (cmdletContext.AlarmIdentifier_Region != null)
            {
                requestAlarmIdentifier_alarmIdentifier_Region = cmdletContext.AlarmIdentifier_Region;
            }
            if (requestAlarmIdentifier_alarmIdentifier_Region != null)
            {
                request.AlarmIdentifier.Region = requestAlarmIdentifier_alarmIdentifier_Region;
                requestAlarmIdentifierIsNull = false;
            }
            System.String requestAlarmIdentifier_alarmIdentifier_Name = null;
            if (cmdletContext.AlarmIdentifier_Name != null)
            {
                requestAlarmIdentifier_alarmIdentifier_Name = cmdletContext.AlarmIdentifier_Name;
            }
            if (requestAlarmIdentifier_alarmIdentifier_Name != null)
            {
                request.AlarmIdentifier.Name = requestAlarmIdentifier_alarmIdentifier_Name;
                requestAlarmIdentifierIsNull = false;
            }
             // determine if request.AlarmIdentifier should be set to null
            if (requestAlarmIdentifierIsNull)
            {
                request.AlarmIdentifier = null;
            }
            if (cmdletContext.InsufficientDataHealthStatus != null)
            {
                request.InsufficientDataHealthStatus = cmdletContext.InsufficientDataHealthStatus;
            }

            var client = Client ?? CreateClient(context.Credentials, context.Region);
            CmdletOutput output;
            
            // issue call
            try
            {
                var response = CallAWSServiceOperation(client, request);
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

        #region AWS Service Operation Call

        private Amazon.Route53.Model.UpdateHealthCheckResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.UpdateHealthCheckRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Route 53", "UpdateHealthCheck");
#if DESKTOP
            return client.UpdateHealthCheck(request);
#elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.UpdateHealthCheckAsync(request);
            return task.Result;
#else
#error "Unknown build edition"
#endif
        }

        #endregion

        internal class CmdletContext : ExecutorContext
        {
            public System.String HealthCheckId { get; set; }
            public System.Int64? HealthCheckVersion { get; set; }
            public System.String IPAddress { get; set; }
            public System.Int32? Port { get; set; }
            public System.String ResourcePath { get; set; }
            public System.String FullyQualifiedDomainName { get; set; }
            public System.String SearchString { get; set; }
            public System.Int32? FailureThreshold { get; set; }
            public System.Boolean? Inverted { get; set; }
            public System.Int32? HealthThreshold { get; set; }
            public List<System.String> ChildHealthChecks { get; set; }
            public System.Boolean? EnableSNI { get; set; }
            public List<System.String> Regions { get; set; }
            public Amazon.Route53.CloudWatchRegion AlarmIdentifier_Region { get; set; }
            public System.String AlarmIdentifier_Name { get; set; }
            public Amazon.Route53.InsufficientDataHealthStatus InsufficientDataHealthStatus { get; set; }
        }
        
    }
}
