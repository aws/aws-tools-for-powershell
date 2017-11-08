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
    /// Creates a new health check.
    /// 
    ///  
    /// <para>
    /// For information about adding health checks to resource record sets, see <a>ResourceRecordSet$HealthCheckId</a>
    /// in <a>ChangeResourceRecordSets</a>. 
    /// </para><para><b>ELB Load Balancers</b></para><para>
    /// If you're registering EC2 instances with an Elastic Load Balancing (ELB) load balancer,
    /// do not create Amazon Route 53 health checks for the EC2 instances. When you register
    /// an EC2 instance with a load balancer, you configure settings for an ELB health check,
    /// which performs a similar function to an Amazon Route 53 health check.
    /// </para><para><b>Private Hosted Zones</b></para><para>
    /// You can associate health checks with failover resource record sets in a private hosted
    /// zone. Note the following:
    /// </para><ul><li><para>
    /// Amazon Route 53 health checkers are outside the VPC. To check the health of an endpoint
    /// within a VPC by IP address, you must assign a public IP address to the instance in
    /// the VPC.
    /// </para></li><li><para>
    /// You can configure a health checker to check the health of an external resource that
    /// the instance relies on, such as a database server.
    /// </para></li><li><para>
    /// You can create a CloudWatch metric, associate an alarm with the metric, and then create
    /// a health check that is based on the state of the alarm. For example, you might create
    /// a CloudWatch metric that checks the status of the Amazon EC2 <code>StatusCheckFailed</code>
    /// metric, add an alarm to the metric, and then create a health check that is based on
    /// the state of the alarm. For information about creating CloudWatch metrics and alarms
    /// by using the CloudWatch console, see the <a href="http://docs.aws.amazon.com/AmazonCloudWatch/latest/DeveloperGuide/WhatIsCloudWatch.html">Amazon
    /// CloudWatch User Guide</a>.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("New", "R53HealthCheck")]
    [OutputType("Amazon.Route53.Model.CreateHealthCheckResponse")]
    [AWSCmdlet("Calls the Amazon Route 53 CreateHealthCheck API operation.", Operation = new[] {"CreateHealthCheck"})]
    [AWSCmdletOutput("Amazon.Route53.Model.CreateHealthCheckResponse",
        "This cmdlet returns a Amazon.Route53.Model.CreateHealthCheckResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewR53HealthCheckCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        #region Parameter CallerReference
        /// <summary>
        /// <para>
        /// <para>A unique string that identifies the request and that allows you to retry a failed
        /// <code>CreateHealthCheck</code> request without the risk of creating two identical
        /// health checks:</para><ul><li><para>If you send a <code>CreateHealthCheck</code> request with the same <code>CallerReference</code>
        /// and settings as a previous request, and if the health check doesn't exist, Amazon
        /// Route 53 creates the health check. If the health check does exist, Amazon Route 53
        /// returns the settings for the existing health check.</para></li><li><para>If you send a <code>CreateHealthCheck</code> request with the same <code>CallerReference</code>
        /// as a deleted health check, regardless of the settings, Amazon Route 53 returns a <code>HealthCheckAlreadyExists</code>
        /// error.</para></li><li><para>If you send a <code>CreateHealthCheck</code> request with the same <code>CallerReference</code>
        /// as an existing health check but with different settings, Amazon Route 53 returns a
        /// <code>HealthCheckAlreadyExists</code> error.</para></li><li><para>If you send a <code>CreateHealthCheck</code> request with a unique <code>CallerReference</code>
        /// but settings identical to an existing health check, Amazon Route 53 creates the health
        /// check.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String CallerReference { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_ChildHealthCheck
        /// <summary>
        /// <para>
        /// <para>(CALCULATED Health Checks Only) A complex type that contains one <code>ChildHealthCheck</code>
        /// element for each health check that you want to associate with a <code>CALCULATED</code>
        /// health check.</para>
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
        /// to the endpoint in the <code>client_hello</code> message during TLS negotiation. This
        /// allows the endpoint to respond to <code>HTTPS</code> health check requests with the
        /// applicable SSL/TLS certificate.</para><para>Some endpoints require that <code>HTTPS</code> requests include the host name in the
        /// <code>client_hello</code> message. If you don't enable SNI, the status of the health
        /// check will be <code>SSL alert handshake_failure</code>. A health check can also have
        /// that status for other reasons. If SNI is enabled and you're still getting the error,
        /// check the SSL/TLS configuration on your endpoint and confirm that your certificate
        /// is valid.</para><para>The SSL/TLS certificate on your endpoint includes a domain name in the <code>Common
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
        public System.Boolean HealthCheckConfig_EnableSNI { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_FailureThreshold
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
        public System.Int32 HealthCheckConfig_FailureThreshold { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_FullyQualifiedDomainName
        /// <summary>
        /// <para>
        /// <para>Amazon Route 53 behavior depends on whether you specify a value for <code>IPAddress</code>.</para><para><b>If you specify a value for</b><code>IPAddress</code>:</para><para>Amazon Route 53 sends health check requests to the specified IPv4 or IPv6 address
        /// and passes the value of <code>FullyQualifiedDomainName</code> in the <code>Host</code>
        /// header for all health checks except TCP health checks. This is typically the fully
        /// qualified DNS name of the endpoint on which you want Amazon Route 53 to perform health
        /// checks.</para><para>When Amazon Route 53 checks the health of an endpoint, here is how it constructs the
        /// <code>Host</code> header:</para><ul><li><para>If you specify a value of <code>80</code> for <code>Port</code> and <code>HTTP</code>
        /// or <code>HTTP_STR_MATCH</code> for <code>Type</code>, Amazon Route 53 passes the value
        /// of <code>FullyQualifiedDomainName</code> to the endpoint in the Host header. </para></li><li><para>If you specify a value of <code>443</code> for <code>Port</code> and <code>HTTPS</code>
        /// or <code>HTTPS_STR_MATCH</code> for <code>Type</code>, Amazon Route 53 passes the
        /// value of <code>FullyQualifiedDomainName</code> to the endpoint in the <code>Host</code>
        /// header.</para></li><li><para>If you specify another value for <code>Port</code> and any value except <code>TCP</code>
        /// for <code>Type</code>, Amazon Route 53 passes <code>FullyQualifiedDomainName:Port</code>
        /// to the endpoint in the <code>Host</code> header.</para></li></ul><para>If you don't specify a value for <code>FullyQualifiedDomainName</code>, Amazon Route
        /// 53 substitutes the value of <code>IPAddress</code> in the <code>Host</code> header
        /// in each of the preceding cases.</para><para><b>If you don't specify a value for <code>IPAddress</code></b>:</para><para>Amazon Route 53 sends a DNS request to the domain that you specify for <code>FullyQualifiedDomainName</code>
        /// at the interval that you specify for <code>RequestInterval</code>. Using an IPv4 address
        /// that DNS returns, Amazon Route 53 then checks the health of the endpoint.</para><note><para>If you don't specify a value for <code>IPAddress</code>, Amazon Route 53 uses only
        /// IPv4 to send health checks to the endpoint. If there's no resource record set with
        /// a type of A for the name that you specify for <code>FullyQualifiedDomainName</code>,
        /// the health check fails with a "DNS resolution failed" error.</para></note><para>If you want to check the health of weighted, latency, or failover resource record
        /// sets and you choose to specify the endpoint only by <code>FullyQualifiedDomainName</code>,
        /// we recommend that you create a separate health check for each endpoint. For example,
        /// create a health check for each HTTP server that is serving content for www.example.com.
        /// For the value of <code>FullyQualifiedDomainName</code>, specify the domain name of
        /// the server (such as us-east-2-www.example.com), not the name of the resource record
        /// sets (www.example.com).</para><important><para>In this configuration, if you create a health check for which the value of <code>FullyQualifiedDomainName</code>
        /// matches the name of the resource record sets and you then associate the health check
        /// with those resource record sets, health check results will be unpredictable.</para></important><para>In addition, if the value that you specify for <code>Type</code> is <code>HTTP</code>,
        /// <code>HTTPS</code>, <code>HTTP_STR_MATCH</code>, or <code>HTTPS_STR_MATCH</code>,
        /// Amazon Route 53 passes the value of <code>FullyQualifiedDomainName</code> in the <code>Host</code>
        /// header, as it does when you specify a value for <code>IPAddress</code>. If the value
        /// of <code>Type</code> is <code>TCP</code>, Amazon Route 53 doesn't pass a <code>Host</code>
        /// header.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String HealthCheckConfig_FullyQualifiedDomainName { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_HealthThreshold
        /// <summary>
        /// <para>
        /// <para>The number of child health checks that are associated with a <code>CALCULATED</code>
        /// health that Amazon Route 53 must consider healthy for the <code>CALCULATED</code>
        /// health check to be considered healthy. To specify the child health checks that you
        /// want to associate with a <code>CALCULATED</code> health check, use the <a>HealthCheckConfig$ChildHealthChecks</a>
        /// and <a>HealthCheckConfig$ChildHealthChecks</a> elements.</para><para>Note the following:</para><ul><li><para>If you specify a number greater than the number of child health checks, Amazon Route
        /// 53 always considers this health check to be unhealthy.</para></li><li><para>If you specify <code>0</code>, Amazon Route 53 always considers this health check
        /// to be healthy.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 HealthCheckConfig_HealthThreshold { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_InsufficientDataHealthStatus
        /// <summary>
        /// <para>
        /// <para>When CloudWatch has insufficient data about the metric to determine the alarm state,
        /// the status that you want Amazon Route 53 to assign to the health check:</para><ul><li><para><code>Healthy</code>: Amazon Route 53 considers the health check to be healthy.</para></li><li><para><code>Unhealthy</code>: Amazon Route 53 considers the health check to be unhealthy.</para></li><li><para><code>LastKnownStatus</code>: Amazon Route 53 uses the status of the health check
        /// from the last time that CloudWatch had sufficient data to determine the alarm state.
        /// For new health checks that have no last known status, the default status for the health
        /// check is healthy.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Route53.InsufficientDataHealthStatus")]
        public Amazon.Route53.InsufficientDataHealthStatus HealthCheckConfig_InsufficientDataHealthStatus { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_Inverted
        /// <summary>
        /// <para>
        /// <para>Specify whether you want Amazon Route 53 to invert the status of a health check, for
        /// example, to consider a health check unhealthy when it otherwise would be considered
        /// healthy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean HealthCheckConfig_Inverted { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_IPAddress
        /// <summary>
        /// <para>
        /// <para>The IPv4 or IPv6 IP address of the endpoint that you want Amazon Route 53 to perform
        /// health checks on. If you don't specify a value for <code>IPAddress</code>, Amazon
        /// Route 53 sends a DNS request to resolve the domain name that you specify in <code>FullyQualifiedDomainName</code>
        /// at the interval that you specify in <code>RequestInterval</code>. Using an IP address
        /// returned by DNS, Amazon Route 53 then checks the health of the endpoint.</para><para>Use one of the following formats for the value of <code>IPAddress</code>: </para><ul><li><para><b>IPv4 address</b>: four values between 0 and 255, separated by periods (.), for
        /// example, <code>192.0.2.44</code>.</para></li><li><para><b>IPv6 address</b>: eight groups of four hexadecimal values, separated by colons
        /// (:), for example, <code>2001:0db8:85a3:0000:0000:abcd:0001:2345</code>. You can also
        /// shorten IPv6 addresses as described in RFC 5952, for example, <code>2001:db8:85a3::abcd:1:2345</code>.</para></li></ul><para>If the endpoint is an EC2 instance, we recommend that you create an Elastic IP address,
        /// associate it with your EC2 instance, and specify the Elastic IP address for <code>IPAddress</code>.
        /// This ensures that the IP address of your instance will never change.</para><para>For more information, see <a>HealthCheckConfig$FullyQualifiedDomainName</a>.</para><para>Constraints: Amazon Route 53 can't check the health of endpoints for which the IP
        /// address is in local, private, non-routable, or multicast ranges. For more information
        /// about IP addresses for which you can't create health checks, see the following documents:</para><ul><li><para><a href="https://tools.ietf.org/html/rfc5735">RFC 5735, Special Use IPv4 Addresses</a></para></li><li><para><a href="https://tools.ietf.org/html/rfc6598">RFC 6598, IANA-Reserved IPv4 Prefix
        /// for Shared Address Space</a></para></li><li><para><a href="https://tools.ietf.org/html/rfc5156">RFC 5156, Special-Use IPv6 Addresses</a></para></li></ul><para>When the value of <code>Type</code> is <code>CALCULATED</code> or <code>CLOUDWATCH_METRIC</code>,
        /// omit <code>IPAddress</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String HealthCheckConfig_IPAddress { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_MeasureLatency
        /// <summary>
        /// <para>
        /// <para>Specify whether you want Amazon Route 53 to measure the latency between health checkers
        /// in multiple AWS regions and your endpoint, and to display CloudWatch latency graphs
        /// on the <b>Health Checks</b> page in the Amazon Route 53 console.</para><important><para>You can't change the value of <code>MeasureLatency</code> after you create a health
        /// check.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean HealthCheckConfig_MeasureLatency { get; set; }
        #endregion
        
        #region Parameter AlarmIdentifier_Name
        /// <summary>
        /// <para>
        /// <para>The name of the CloudWatch alarm that you want Amazon Route 53 health checkers to
        /// use to determine whether this health check is healthy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("HealthCheckConfig_AlarmIdentifier_Name")]
        public System.String AlarmIdentifier_Name { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_Port
        /// <summary>
        /// <para>
        /// <para>The port on the endpoint on which you want Amazon Route 53 to perform health checks.
        /// Specify a value for <code>Port</code> only when you specify a value for <code>IPAddress</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 HealthCheckConfig_Port { get; set; }
        #endregion
        
        #region Parameter AlarmIdentifier_Region
        /// <summary>
        /// <para>
        /// <para>A complex type that identifies the CloudWatch alarm that you want Amazon Route 53
        /// health checkers to use to determine whether this health check is healthy.</para><para>For the current list of CloudWatch regions, see <a href="http://docs.aws.amazon.com/general/latest/gr/rande.html#cw_region">Amazon
        /// CloudWatch</a> in the <i>AWS Regions and Endpoints</i> chapter of the <i>Amazon Web
        /// Services General Reference</i>.</para>
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
        /// <para>A complex type that contains one <code>Region</code> element for each region from
        /// which you want Amazon Route 53 health checkers to check the specified endpoint.</para><para>If you don't specify any regions, Amazon Route 53 health checkers automatically performs
        /// checks from all of the regions that are listed under <b>Valid Values</b>.</para><para>If you update a health check to remove a region that has been performing health checks,
        /// Amazon Route 53 will briefly continue to perform checks from that region to ensure
        /// that some health checkers are always checking the endpoint (for example, if you replace
        /// three regions with four different regions). </para>
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
        /// endpoint and the time that it sends the next health check request. Each Amazon Route
        /// 53 health checker makes requests at this interval.</para><important><para>You can't change the value of <code>RequestInterval</code> after you create a health
        /// check.</para></important><para>If you don't specify a value for <code>RequestInterval</code>, the default value is
        /// <code>30</code> seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 HealthCheckConfig_RequestInterval { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_ResourcePath
        /// <summary>
        /// <para>
        /// <para>The path, if any, that you want Amazon Route 53 to request when performing health
        /// checks. The path can be any value for which your endpoint will return an HTTP status
        /// code of 2xx or 3xx when the endpoint is healthy, for example, the file /docs/route53-health-check.html.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String HealthCheckConfig_ResourcePath { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_SearchString
        /// <summary>
        /// <para>
        /// <para>If the value of Type is <code>HTTP_STR_MATCH</code> or <code>HTTP_STR_MATCH</code>,
        /// the string that you want Amazon Route 53 to search for in the response body from the
        /// specified resource. If the string appears in the response body, Amazon Route 53 considers
        /// the resource healthy.</para><para>Amazon Route 53 considers case when searching for <code>SearchString</code> in the
        /// response body. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String HealthCheckConfig_SearchString { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_Type
        /// <summary>
        /// <para>
        /// <para>The type of health check that you want to create, which indicates how Amazon Route
        /// 53 determines whether an endpoint is healthy.</para><important><para>You can't change the value of <code>Type</code> after you create a health check.</para></important><para>You can create the following types of health checks:</para><ul><li><para><b>HTTP</b>: Amazon Route 53 tries to establish a TCP connection. If successful,
        /// Amazon Route 53 submits an HTTP request and waits for an HTTP status code of 200 or
        /// greater and less than 400.</para></li><li><para><b>HTTPS</b>: Amazon Route 53 tries to establish a TCP connection. If successful,
        /// Amazon Route 53 submits an HTTPS request and waits for an HTTP status code of 200
        /// or greater and less than 400.</para><important><para>If you specify <code>HTTPS</code> for the value of <code>Type</code>, the endpoint
        /// must support TLS v1.0 or later.</para></important></li><li><para><b>HTTP_STR_MATCH</b>: Amazon Route 53 tries to establish a TCP connection. If successful,
        /// Amazon Route 53 submits an HTTP request and searches the first 5,120 bytes of the
        /// response body for the string that you specify in <code>SearchString</code>.</para></li><li><para><b>HTTPS_STR_MATCH</b>: Amazon Route 53 tries to establish a TCP connection. If successful,
        /// Amazon Route 53 submits an <code>HTTPS</code> request and searches the first 5,120
        /// bytes of the response body for the string that you specify in <code>SearchString</code>.</para></li><li><para><b>TCP</b>: Amazon Route 53 tries to establish a TCP connection.</para></li><li><para><b>CLOUDWATCH_METRIC</b>: The health check is associated with a CloudWatch alarm.
        /// If the state of the alarm is <code>OK</code>, the health check is considered healthy.
        /// If the state is <code>ALARM</code>, the health check is considered unhealthy. If CloudWatch
        /// doesn't have sufficient data to determine whether the state is <code>OK</code> or
        /// <code>ALARM</code>, the health check status depends on the setting for <code>InsufficientDataHealthStatus</code>:
        /// <code>Healthy</code>, <code>Unhealthy</code>, or <code>LastKnownStatus</code>. </para></li><li><para><b>CALCULATED</b>: For health checks that monitor the status of other health checks,
        /// Amazon Route 53 adds up the number of health checks that Amazon Route 53 health checkers
        /// consider to be healthy and compares that number with the value of <code>HealthThreshold</code>.
        /// </para></li></ul><para>For more information, see <a href="http://docs.aws.amazon.com/Route53/latest/DeveloperGuide/dns-failover-determining-health-of-endpoints.html">How
        /// Amazon Route 53 Determines Whether an Endpoint Is Healthy</a> in the <i>Amazon Route
        /// 53 Developer Guide</i>.</para>
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
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
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
        
        private Amazon.Route53.Model.CreateHealthCheckResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.CreateHealthCheckRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53", "CreateHealthCheck");
            try
            {
                #if DESKTOP
                return client.CreateHealthCheck(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateHealthCheckAsync(request);
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
