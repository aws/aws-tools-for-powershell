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
using Amazon.Route53;
using Amazon.Route53.Model;

namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    /// Updates an existing health check. Note that some values can't be updated. 
    /// 
    ///  
    /// <para>
    /// For more information about updating health checks, see <a href="http://docs.aws.amazon.com/Route53/latest/DeveloperGuide/health-checks-creating-deleting.html">Creating,
    /// Updating, and Deleting Health Checks</a> in the <i>Amazon Route 53 Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "R53HealthCheck", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Route53.Model.HealthCheck")]
    [AWSCmdlet("Calls the Amazon Route 53 UpdateHealthCheck API operation.", Operation = new[] {"UpdateHealthCheck"})]
    [AWSCmdletOutput("Amazon.Route53.Model.HealthCheck",
        "This cmdlet returns a HealthCheck object.",
        "The service call response (type Amazon.Route53.Model.UpdateHealthCheckResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateR53HealthCheckCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        #region Parameter ChildHealthCheck
        /// <summary>
        /// <para>
        /// <para>A complex type that contains one <code>ChildHealthCheck</code> element for each health
        /// check that you want to associate with a <code>CALCULATED</code> health check.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ChildHealthChecks")]
        public System.String[] ChildHealthCheck { get; set; }
        #endregion
        
        #region Parameter Disabled
        /// <summary>
        /// <para>
        /// <para>Stops Route 53 from performing health checks. When you disable a health check, here's
        /// what happens:</para><ul><li><para><b>Health checks that check the health of endpoints:</b> Route 53 stops submitting
        /// requests to your application, server, or other resource.</para></li><li><para><b>Calculated health checks:</b> Route 53 stops aggregating the status of the referenced
        /// health checks.</para></li><li><para><b>Health checks that monitor CloudWatch alarms:</b> Route 53 stops monitoring the
        /// corresponding CloudWatch metrics.</para></li></ul><para>After you disable a health check, Route 53 considers the status of the health check
        /// to always be healthy. If you configured DNS failover, Route 53 continues to route
        /// traffic to the corresponding resources. If you want to stop routing traffic to a resource,
        /// change the value of <a>UpdateHealthCheckRequest$Inverted</a>.</para><para>Charges for a health check still apply when the health check is disabled. For more
        /// information, see <a href="http://aws.amazon.com/route53/pricing/">Amazon Route 53
        /// Pricing</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Disabled { get; set; }
        #endregion
        
        #region Parameter EnableSNI
        /// <summary>
        /// <para>
        /// <para>Specify whether you want Amazon Route 53 to send the value of <code>FullyQualifiedDomainName</code>
        /// to the endpoint in the <code>client_hello</code> message during <code>TLS</code> negotiation.
        /// This allows the endpoint to respond to <code>HTTPS</code> health check requests with
        /// the applicable SSL/TLS certificate.</para><para>Some endpoints require that HTTPS requests include the host name in the <code>client_hello</code>
        /// message. If you don't enable SNI, the status of the health check will be SSL alert
        /// <code>handshake_failure</code>. A health check can also have that status for other
        /// reasons. If SNI is enabled and you're still getting the error, check the SSL/TLS configuration
        /// on your endpoint and confirm that your certificate is valid.</para><para>The SSL/TLS certificate on your endpoint includes a domain name in the <code>Common
        /// Name</code> field and possibly several more in the <code>Subject Alternative Names</code>
        /// field. One of the domain names in the certificate should match the value that you
        /// specify for <code>FullyQualifiedDomainName</code>. If the endpoint responds to the
        /// <code>client_hello</code> message with a certificate that does not include the domain
        /// name that you specified in <code>FullyQualifiedDomainName</code>, a health checker
        /// will retry the handshake. In the second attempt, the health checker will omit <code>FullyQualifiedDomainName</code>
        /// from the <code>client_hello</code> message.</para>
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
        /// vice versa. For more information, see <a href="http://docs.aws.amazon.com/Route53/latest/DeveloperGuide/dns-failover-determining-health-of-endpoints.html">How
        /// Amazon Route 53 Determines Whether an Endpoint Is Healthy</a> in the <i>Amazon Route
        /// 53 Developer Guide</i>.</para><para>If you don't specify a value for <code>FailureThreshold</code>, the default value
        /// is three health checks.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 FailureThreshold { get; set; }
        #endregion
        
        #region Parameter FullyQualifiedDomainName
        /// <summary>
        /// <para>
        /// <para>Amazon Route 53 behavior depends on whether you specify a value for <code>IPAddress</code>.</para><note><para>If a health check already has a value for <code>IPAddress</code>, you can change the
        /// value. However, you can't update an existing health check to add or remove the value
        /// of <code>IPAddress</code>. </para></note><para><b>If you specify a value for</b><code>IPAddress</code>:</para><para>Route 53 sends health check requests to the specified IPv4 or IPv6 address and passes
        /// the value of <code>FullyQualifiedDomainName</code> in the <code>Host</code> header
        /// for all health checks except TCP health checks. This is typically the fully qualified
        /// DNS name of the endpoint on which you want Route 53 to perform health checks.</para><para>When Route 53 checks the health of an endpoint, here is how it constructs the <code>Host</code>
        /// header:</para><ul><li><para>If you specify a value of <code>80</code> for <code>Port</code> and <code>HTTP</code>
        /// or <code>HTTP_STR_MATCH</code> for <code>Type</code>, Route 53 passes the value of
        /// <code>FullyQualifiedDomainName</code> to the endpoint in the <code>Host</code> header.</para></li><li><para>If you specify a value of <code>443</code> for <code>Port</code> and <code>HTTPS</code>
        /// or <code>HTTPS_STR_MATCH</code> for <code>Type</code>, Route 53 passes the value of
        /// <code>FullyQualifiedDomainName</code> to the endpoint in the <code>Host</code> header.</para></li><li><para>If you specify another value for <code>Port</code> and any value except <code>TCP</code>
        /// for <code>Type</code>, Route 53 passes <i><code>FullyQualifiedDomainName</code>:<code>Port</code></i> to the endpoint in the <code>Host</code> header.</para></li></ul><para>If you don't specify a value for <code>FullyQualifiedDomainName</code>, Route 53 substitutes
        /// the value of <code>IPAddress</code> in the <code>Host</code> header in each of the
        /// above cases.</para><para><b>If you don't specify a value for</b><code>IPAddress</code>:</para><para>If you don't specify a value for <code>IPAddress</code>, Route 53 sends a DNS request
        /// to the domain that you specify in <code>FullyQualifiedDomainName</code> at the interval
        /// you specify in <code>RequestInterval</code>. Using an IPv4 address that is returned
        /// by DNS, Route 53 then checks the health of the endpoint.</para><note><para>If you don't specify a value for <code>IPAddress</code>, Route 53 uses only IPv4 to
        /// send health checks to the endpoint. If there's no resource record set with a type
        /// of A for the name that you specify for <code>FullyQualifiedDomainName</code>, the
        /// health check fails with a "DNS resolution failed" error.</para></note><para>If you want to check the health of weighted, latency, or failover resource record
        /// sets and you choose to specify the endpoint only by <code>FullyQualifiedDomainName</code>,
        /// we recommend that you create a separate health check for each endpoint. For example,
        /// create a health check for each HTTP server that is serving content for www.example.com.
        /// For the value of <code>FullyQualifiedDomainName</code>, specify the domain name of
        /// the server (such as <code>us-east-2-www.example.com</code>), not the name of the resource
        /// record sets (www.example.com).</para><important><para>In this configuration, if the value of <code>FullyQualifiedDomainName</code> matches
        /// the name of the resource record sets and you then associate the health check with
        /// those resource record sets, health check results will be unpredictable.</para></important><para>In addition, if the value of <code>Type</code> is <code>HTTP</code>, <code>HTTPS</code>,
        /// <code>HTTP_STR_MATCH</code>, or <code>HTTPS_STR_MATCH</code>, Route 53 passes the
        /// value of <code>FullyQualifiedDomainName</code> in the <code>Host</code> header, as
        /// it does when you specify a value for <code>IPAddress</code>. If the value of <code>Type</code>
        /// is <code>TCP</code>, Route 53 doesn't pass a <code>Host</code> header.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String FullyQualifiedDomainName { get; set; }
        #endregion
        
        #region Parameter HealthCheckId
        /// <summary>
        /// <para>
        /// <para>The ID for the health check for which you want detailed information. When you created
        /// the health check, <code>CreateHealthCheck</code> returned the ID in the response,
        /// in the <code>HealthCheckId</code> element.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String HealthCheckId { get; set; }
        #endregion
        
        #region Parameter HealthCheckVersion
        /// <summary>
        /// <para>
        /// <para>A sequential counter that Amazon Route 53 sets to <code>1</code> when you create a
        /// health check and increments by 1 each time you update settings for the health check.</para><para>We recommend that you use <code>GetHealthCheck</code> or <code>ListHealthChecks</code>
        /// to get the current value of <code>HealthCheckVersion</code> for the health check that
        /// you want to update, and that you include that value in your <code>UpdateHealthCheck</code>
        /// request. This prevents Route 53 from overwriting an intervening update:</para><ul><li><para>If the value in the <code>UpdateHealthCheck</code> request matches the value of <code>HealthCheckVersion</code>
        /// in the health check, Route 53 updates the health check with the new settings.</para></li><li><para>If the value of <code>HealthCheckVersion</code> in the health check is greater, the
        /// health check was changed after you got the version number. Route 53 does not update
        /// the health check, and it returns a <code>HealthCheckVersionMismatch</code> error.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 HealthCheckVersion { get; set; }
        #endregion
        
        #region Parameter HealthThreshold
        /// <summary>
        /// <para>
        /// <para>The number of child health checks that are associated with a <code>CALCULATED</code>
        /// health that Amazon Route 53 must consider healthy for the <code>CALCULATED</code>
        /// health check to be considered healthy. To specify the child health checks that you
        /// want to associate with a <code>CALCULATED</code> health check, use the <code>ChildHealthChecks</code>
        /// and <code>ChildHealthCheck</code> elements.</para><para>Note the following:</para><ul><li><para>If you specify a number greater than the number of child health checks, Route 53 always
        /// considers this health check to be unhealthy.</para></li><li><para>If you specify <code>0</code>, Route 53 always considers this health check to be healthy.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 HealthThreshold { get; set; }
        #endregion
        
        #region Parameter InsufficientDataHealthStatus
        /// <summary>
        /// <para>
        /// <para>When CloudWatch has insufficient data about the metric to determine the alarm state,
        /// the status that you want Amazon Route 53 to assign to the health check:</para><ul><li><para><code>Healthy</code>: Route 53 considers the health check to be healthy.</para></li><li><para><code>Unhealthy</code>: Route 53 considers the health check to be unhealthy.</para></li><li><para><code>LastKnownStatus</code>: Route 53 uses the status of the health check from the
        /// last time CloudWatch had sufficient data to determine the alarm state. For new health
        /// checks that have no last known status, the default status for the health check is
        /// healthy.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Route53.InsufficientDataHealthStatus")]
        public Amazon.Route53.InsufficientDataHealthStatus InsufficientDataHealthStatus { get; set; }
        #endregion
        
        #region Parameter Inverted
        /// <summary>
        /// <para>
        /// <para>Specify whether you want Amazon Route 53 to invert the status of a health check, for
        /// example, to consider a health check unhealthy when it otherwise would be considered
        /// healthy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Inverted { get; set; }
        #endregion
        
        #region Parameter IPAddress
        /// <summary>
        /// <para>
        /// <para>The IPv4 or IPv6 IP address for the endpoint that you want Amazon Route 53 to perform
        /// health checks on. If you don't specify a value for <code>IPAddress</code>, Route 53
        /// sends a DNS request to resolve the domain name that you specify in <code>FullyQualifiedDomainName</code>
        /// at the interval that you specify in <code>RequestInterval</code>. Using an IP address
        /// that is returned by DNS, Route 53 then checks the health of the endpoint.</para><para>Use one of the following formats for the value of <code>IPAddress</code>: </para><ul><li><para><b>IPv4 address</b>: four values between 0 and 255, separated by periods (.), for
        /// example, <code>192.0.2.44</code>.</para></li><li><para><b>IPv6 address</b>: eight groups of four hexadecimal values, separated by colons
        /// (:), for example, <code>2001:0db8:85a3:0000:0000:abcd:0001:2345</code>. You can also
        /// shorten IPv6 addresses as described in RFC 5952, for example, <code>2001:db8:85a3::abcd:1:2345</code>.</para></li></ul><para>If the endpoint is an EC2 instance, we recommend that you create an Elastic IP address,
        /// associate it with your EC2 instance, and specify the Elastic IP address for <code>IPAddress</code>.
        /// This ensures that the IP address of your instance never changes. For more information,
        /// see the applicable documentation:</para><ul><li><para>Linux: <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/elastic-ip-addresses-eip.html">Elastic
        /// IP Addresses (EIP)</a> in the <i>Amazon EC2 User Guide for Linux Instances</i></para></li><li><para>Windows: <a href="http://docs.aws.amazon.com/AWSEC2/latest/WindowsGuide/elastic-ip-addresses-eip.html">Elastic
        /// IP Addresses (EIP)</a> in the <i>Amazon EC2 User Guide for Windows Instances</i></para></li></ul><note><para>If a health check already has a value for <code>IPAddress</code>, you can change the
        /// value. However, you can't update an existing health check to add or remove the value
        /// of <code>IPAddress</code>. </para></note><para>For more information, see <a>UpdateHealthCheckRequest$FullyQualifiedDomainName</a>.</para><para>Constraints: Route 53 can't check the health of endpoints for which the IP address
        /// is in local, private, non-routable, or multicast ranges. For more information about
        /// IP addresses for which you can't create health checks, see the following documents:</para><ul><li><para><a href="https://tools.ietf.org/html/rfc5735">RFC 5735, Special Use IPv4 Addresses</a></para></li><li><para><a href="https://tools.ietf.org/html/rfc6598">RFC 6598, IANA-Reserved IPv4 Prefix
        /// for Shared Address Space</a></para></li><li><para><a href="https://tools.ietf.org/html/rfc5156">RFC 5156, Special-Use IPv6 Addresses</a></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String IPAddress { get; set; }
        #endregion
        
        #region Parameter AlarmIdentifier_Name
        /// <summary>
        /// <para>
        /// <para>The name of the CloudWatch alarm that you want Amazon Route 53 health checkers to
        /// use to determine whether this health check is healthy.</para><note><para>Route 53 supports CloudWatch alarms with the following features:</para><ul><li><para>Standard-resolution metrics. High-resolution metrics aren't supported. For more information,
        /// see <a href="http://docs.aws.amazon.com/AmazonCloudWatch/latest/DeveloperGuide/publishingMetrics.html#high-resolution-metrics">High-Resolution
        /// Metrics</a> in the <i>Amazon CloudWatch User Guide</i>.</para></li><li><para>Statistics: Average, Minimum, Maximum, Sum, and SampleCount. Extended statistics aren't
        /// supported.</para></li></ul></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AlarmIdentifier_Name { get; set; }
        #endregion
        
        #region Parameter Port
        /// <summary>
        /// <para>
        /// <para>The port on the endpoint on which you want Amazon Route 53 to perform health checks.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Port { get; set; }
        #endregion
        
        #region Parameter AlarmIdentifier_Region
        /// <summary>
        /// <para>
        /// <para>For the CloudWatch alarm that you want Route 53 health checkers to use to determine
        /// whether this health check is healthy, the region that the alarm was created in.</para><para>For the current list of CloudWatch regions, see <a href="http://docs.aws.amazon.com/general/latest/gr/rande.html#cw_region">Amazon
        /// CloudWatch</a> in the <i>AWS Regions and Endpoints</i> chapter of the <i>Amazon Web
        /// Services General Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Route53.CloudWatchRegion")]
        public Amazon.Route53.CloudWatchRegion AlarmIdentifier_Region { get; set; }
        #endregion
        
        #region Parameter HealthCheckRegion
        /// <summary>
        /// <para>
        /// <para>A complex type that contains one <code>Region</code> element for each region that
        /// you want Amazon Route 53 health checkers to check the specified endpoint from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Regions")]
        public System.String[] HealthCheckRegion { get; set; }
        #endregion
        
        #region Parameter ResetElement
        /// <summary>
        /// <para>
        /// <para>A complex type that contains one <code>ResettableElementName</code> element for each
        /// element that you want to reset to the default value. Valid values for <code>ResettableElementName</code>
        /// include the following:</para><ul><li><para><code>ChildHealthChecks</code>: Amazon Route 53 resets <a>HealthCheckConfig$ChildHealthChecks</a>
        /// to null.</para></li><li><para><code>FullyQualifiedDomainName</code>: Route 53 resets <a>HealthCheckConfig$FullyQualifiedDomainName</a>
        /// to null.</para></li><li><para><code>Regions</code>: Route 53 resets the <a>HealthCheckConfig$Regions</a> list to
        /// the default set of regions. </para></li><li><para><code>ResourcePath</code>: Route 53 resets <a>HealthCheckConfig$ResourcePath</a>
        /// to null.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ResetElements")]
        public System.String[] ResetElement { get; set; }
        #endregion
        
        #region Parameter ResourcePath
        /// <summary>
        /// <para>
        /// <para>The path that you want Amazon Route 53 to request when performing health checks. The
        /// path can be any value for which your endpoint will return an HTTP status code of 2xx
        /// or 3xx when the endpoint is healthy, for example the file /docs/route53-health-check.html.
        /// You can also include query string parameters, for example, <code>/welcome.html?language=jp&amp;login=y</code>.
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
        /// specified resource. If the string appears in the response body, Route 53 considers
        /// the resource healthy. (You can't change the value of <code>Type</code> when you update
        /// a health check.)</para>
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
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
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
            if (ParameterWasBound("Disabled"))
                context.Disabled = this.Disabled;
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
                context.HealthCheckRegion = new List<System.String>(this.HealthCheckRegion);
            }
            context.AlarmIdentifier_Region = this.AlarmIdentifier_Region;
            context.AlarmIdentifier_Name = this.AlarmIdentifier_Name;
            context.InsufficientDataHealthStatus = this.InsufficientDataHealthStatus;
            if (this.ResetElement != null)
            {
                context.ResetElements = new List<System.String>(this.ResetElement);
            }
            
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
            if (cmdletContext.Disabled != null)
            {
                request.Disabled = cmdletContext.Disabled.Value;
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
            if (cmdletContext.HealthCheckRegion != null)
            {
                request.Regions = cmdletContext.HealthCheckRegion;
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
            if (cmdletContext.ResetElements != null)
            {
                request.ResetElements = cmdletContext.ResetElements;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
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
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53", "UpdateHealthCheck");
            try
            {
                #if DESKTOP
                return client.UpdateHealthCheck(request);
                #elif CORECLR
                return client.UpdateHealthCheckAsync(request).GetAwaiter().GetResult();
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
            public System.String HealthCheckId { get; set; }
            public System.Int64? HealthCheckVersion { get; set; }
            public System.String IPAddress { get; set; }
            public System.Int32? Port { get; set; }
            public System.String ResourcePath { get; set; }
            public System.String FullyQualifiedDomainName { get; set; }
            public System.String SearchString { get; set; }
            public System.Int32? FailureThreshold { get; set; }
            public System.Boolean? Inverted { get; set; }
            public System.Boolean? Disabled { get; set; }
            public System.Int32? HealthThreshold { get; set; }
            public List<System.String> ChildHealthChecks { get; set; }
            public System.Boolean? EnableSNI { get; set; }
            public List<System.String> HealthCheckRegion { get; set; }
            public Amazon.Route53.CloudWatchRegion AlarmIdentifier_Region { get; set; }
            public System.String AlarmIdentifier_Name { get; set; }
            public Amazon.Route53.InsufficientDataHealthStatus InsufficientDataHealthStatus { get; set; }
            public List<System.String> ResetElements { get; set; }
        }
        
    }
}
