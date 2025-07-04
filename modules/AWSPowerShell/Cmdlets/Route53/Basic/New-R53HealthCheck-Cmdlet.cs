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
using Amazon.Route53;
using Amazon.Route53.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    /// Creates a new health check.
    /// 
    ///  
    /// <para>
    /// For information about adding health checks to resource record sets, see <a href="https://docs.aws.amazon.com/Route53/latest/APIReference/API_ResourceRecordSet.html#Route53-Type-ResourceRecordSet-HealthCheckId">HealthCheckId</a>
    /// in <a href="https://docs.aws.amazon.com/Route53/latest/APIReference/API_ChangeResourceRecordSets.html">ChangeResourceRecordSets</a>.
    /// 
    /// </para><para><b>ELB Load Balancers</b></para><para>
    /// If you're registering EC2 instances with an Elastic Load Balancing (ELB) load balancer,
    /// do not create Amazon Route 53 health checks for the EC2 instances. When you register
    /// an EC2 instance with a load balancer, you configure settings for an ELB health check,
    /// which performs a similar function to a Route 53 health check.
    /// </para><para><b>Private Hosted Zones</b></para><para>
    /// You can associate health checks with failover resource record sets in a private hosted
    /// zone. Note the following:
    /// </para><ul><li><para>
    /// Route 53 health checkers are outside the VPC. To check the health of an endpoint within
    /// a VPC by IP address, you must assign a public IP address to the instance in the VPC.
    /// </para></li><li><para>
    /// You can configure a health checker to check the health of an external resource that
    /// the instance relies on, such as a database server.
    /// </para></li><li><para>
    /// You can create a CloudWatch metric, associate an alarm with the metric, and then create
    /// a health check that is based on the state of the alarm. For example, you might create
    /// a CloudWatch metric that checks the status of the Amazon EC2 <c>StatusCheckFailed</c>
    /// metric, add an alarm to the metric, and then create a health check that is based on
    /// the state of the alarm. For information about creating CloudWatch metrics and alarms
    /// by using the CloudWatch console, see the <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/DeveloperGuide/WhatIsCloudWatch.html">Amazon
    /// CloudWatch User Guide</a>.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("New", "R53HealthCheck")]
    [OutputType("Amazon.Route53.Model.CreateHealthCheckResponse")]
    [AWSCmdlet("Calls the Amazon Route 53 CreateHealthCheck API operation.", Operation = new[] {"CreateHealthCheck"}, SelectReturnType = typeof(Amazon.Route53.Model.CreateHealthCheckResponse))]
    [AWSCmdletOutput("Amazon.Route53.Model.CreateHealthCheckResponse",
        "This cmdlet returns an Amazon.Route53.Model.CreateHealthCheckResponse object containing multiple properties."
    )]
    public partial class NewR53HealthCheckCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CallerReference
        /// <summary>
        /// <para>
        /// <para>A unique string that identifies the request and that allows you to retry a failed
        /// <c>CreateHealthCheck</c> request without the risk of creating two identical health
        /// checks:</para><ul><li><para>If you send a <c>CreateHealthCheck</c> request with the same <c>CallerReference</c>
        /// and settings as a previous request, and if the health check doesn't exist, Amazon
        /// Route 53 creates the health check. If the health check does exist, Route 53 returns
        /// the settings for the existing health check.</para></li><li><para>If you send a <c>CreateHealthCheck</c> request with the same <c>CallerReference</c>
        /// as a deleted health check, regardless of the settings, Route 53 returns a <c>HealthCheckAlreadyExists</c>
        /// error.</para></li><li><para>If you send a <c>CreateHealthCheck</c> request with the same <c>CallerReference</c>
        /// as an existing health check but with different settings, Route 53 returns a <c>HealthCheckAlreadyExists</c>
        /// error.</para></li><li><para>If you send a <c>CreateHealthCheck</c> request with a unique <c>CallerReference</c>
        /// but settings identical to an existing health check, Route 53 creates the health check.</para></li></ul><para> Route 53 does not store the <c>CallerReference</c> for a deleted health check indefinitely.
        /// The <c>CallerReference</c> for a deleted health check will be deleted after a number
        /// of days.</para>
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
        public System.String CallerReference { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_ChildHealthCheck
        /// <summary>
        /// <para>
        /// <para>(CALCULATED Health Checks Only) A complex type that contains one <c>ChildHealthCheck</c>
        /// element for each health check that you want to associate with a <c>CALCULATED</c>
        /// health check.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HealthCheckConfig_ChildHealthChecks")]
        public System.String[] HealthCheckConfig_ChildHealthCheck { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_Disabled
        /// <summary>
        /// <para>
        /// <para>Stops Route 53 from performing health checks. When you disable a health check, here's
        /// what happens:</para><ul><li><para><b>Health checks that check the health of endpoints:</b> Route 53 stops submitting
        /// requests to your application, server, or other resource.</para></li><li><para><b>Calculated health checks:</b> Route 53 stops aggregating the status of the referenced
        /// health checks.</para></li><li><para><b>Health checks that monitor CloudWatch alarms:</b> Route 53 stops monitoring the
        /// corresponding CloudWatch metrics.</para></li></ul><para>After you disable a health check, Route 53 considers the status of the health check
        /// to always be healthy. If you configured DNS failover, Route 53 continues to route
        /// traffic to the corresponding resources. If you want to stop routing traffic to a resource,
        /// change the value of <a href="https://docs.aws.amazon.com/Route53/latest/APIReference/API_UpdateHealthCheck.html#Route53-UpdateHealthCheck-request-Inverted">Inverted</a>.
        /// </para><para>Charges for a health check still apply when the health check is disabled. For more
        /// information, see <a href="http://aws.amazon.com/route53/pricing/">Amazon Route 53
        /// Pricing</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? HealthCheckConfig_Disabled { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_EnableSNI
        /// <summary>
        /// <para>
        /// <para>Specify whether you want Amazon Route 53 to send the value of <c>FullyQualifiedDomainName</c>
        /// to the endpoint in the <c>client_hello</c> message during TLS negotiation. This allows
        /// the endpoint to respond to <c>HTTPS</c> health check requests with the applicable
        /// SSL/TLS certificate.</para><para>Some endpoints require that <c>HTTPS</c> requests include the host name in the <c>client_hello</c>
        /// message. If you don't enable SNI, the status of the health check will be <c>SSL alert
        /// handshake_failure</c>. A health check can also have that status for other reasons.
        /// If SNI is enabled and you're still getting the error, check the SSL/TLS configuration
        /// on your endpoint and confirm that your certificate is valid.</para><para>The SSL/TLS certificate on your endpoint includes a domain name in the <c>Common Name</c>
        /// field and possibly several more in the <c>Subject Alternative Names</c> field. One
        /// of the domain names in the certificate should match the value that you specify for
        /// <c>FullyQualifiedDomainName</c>. If the endpoint responds to the <c>client_hello</c>
        /// message with a certificate that does not include the domain name that you specified
        /// in <c>FullyQualifiedDomainName</c>, a health checker will retry the handshake. In
        /// the second attempt, the health checker will omit <c>FullyQualifiedDomainName</c> from
        /// the <c>client_hello</c> message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? HealthCheckConfig_EnableSNI { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_FailureThreshold
        /// <summary>
        /// <para>
        /// <para>The number of consecutive health checks that an endpoint must pass or fail for Amazon
        /// Route 53 to change the current status of the endpoint from unhealthy to healthy or
        /// vice versa. For more information, see <a href="https://docs.aws.amazon.com/Route53/latest/DeveloperGuide/dns-failover-determining-health-of-endpoints.html">How
        /// Amazon Route 53 Determines Whether an Endpoint Is Healthy</a> in the <i>Amazon Route
        /// 53 Developer Guide</i>.</para><para>If you don't specify a value for <c>FailureThreshold</c>, the default value is three
        /// health checks.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? HealthCheckConfig_FailureThreshold { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_FullyQualifiedDomainName
        /// <summary>
        /// <para>
        /// <para>Amazon Route 53 behavior depends on whether you specify a value for <c>IPAddress</c>.</para><para><b>If you specify a value for</b><c>IPAddress</c>:</para><para>Amazon Route 53 sends health check requests to the specified IPv4 or IPv6 address
        /// and passes the value of <c>FullyQualifiedDomainName</c> in the <c>Host</c> header
        /// for all health checks except TCP health checks. This is typically the fully qualified
        /// DNS name of the endpoint on which you want Route 53 to perform health checks.</para><para>When Route 53 checks the health of an endpoint, here is how it constructs the <c>Host</c>
        /// header:</para><ul><li><para>If you specify a value of <c>80</c> for <c>Port</c> and <c>HTTP</c> or <c>HTTP_STR_MATCH</c>
        /// for <c>Type</c>, Route 53 passes the value of <c>FullyQualifiedDomainName</c> to the
        /// endpoint in the Host header. </para></li><li><para>If you specify a value of <c>443</c> for <c>Port</c> and <c>HTTPS</c> or <c>HTTPS_STR_MATCH</c>
        /// for <c>Type</c>, Route 53 passes the value of <c>FullyQualifiedDomainName</c> to the
        /// endpoint in the <c>Host</c> header.</para></li><li><para>If you specify another value for <c>Port</c> and any value except <c>TCP</c> for <c>Type</c>,
        /// Route 53 passes <c>FullyQualifiedDomainName:Port</c> to the endpoint in the <c>Host</c>
        /// header.</para></li></ul><para>If you don't specify a value for <c>FullyQualifiedDomainName</c>, Route 53 substitutes
        /// the value of <c>IPAddress</c> in the <c>Host</c> header in each of the preceding cases.</para><para><b>If you don't specify a value for</b><c>IPAddress</c>:</para><para>Route 53 sends a DNS request to the domain that you specify for <c>FullyQualifiedDomainName</c>
        /// at the interval that you specify for <c>RequestInterval</c>. Using an IPv4 address
        /// that DNS returns, Route 53 then checks the health of the endpoint.</para><note><para>If you don't specify a value for <c>IPAddress</c>, Route 53 uses only IPv4 to send
        /// health checks to the endpoint. If there's no resource record set with a type of A
        /// for the name that you specify for <c>FullyQualifiedDomainName</c>, the health check
        /// fails with a "DNS resolution failed" error.</para></note><para>If you want to check the health of weighted, latency, or failover resource record
        /// sets and you choose to specify the endpoint only by <c>FullyQualifiedDomainName</c>,
        /// we recommend that you create a separate health check for each endpoint. For example,
        /// create a health check for each HTTP server that is serving content for www.example.com.
        /// For the value of <c>FullyQualifiedDomainName</c>, specify the domain name of the server
        /// (such as us-east-2-www.example.com), not the name of the resource record sets (www.example.com).</para><important><para>In this configuration, if you create a health check for which the value of <c>FullyQualifiedDomainName</c>
        /// matches the name of the resource record sets and you then associate the health check
        /// with those resource record sets, health check results will be unpredictable.</para></important><para>In addition, if the value that you specify for <c>Type</c> is <c>HTTP</c>, <c>HTTPS</c>,
        /// <c>HTTP_STR_MATCH</c>, or <c>HTTPS_STR_MATCH</c>, Route 53 passes the value of <c>FullyQualifiedDomainName</c>
        /// in the <c>Host</c> header, as it does when you specify a value for <c>IPAddress</c>.
        /// If the value of <c>Type</c> is <c>TCP</c>, Route 53 doesn't pass a <c>Host</c> header.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HealthCheckConfig_FullyQualifiedDomainName { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_HealthThreshold
        /// <summary>
        /// <para>
        /// <para>The number of child health checks that are associated with a <c>CALCULATED</c> health
        /// check that Amazon Route 53 must consider healthy for the <c>CALCULATED</c> health
        /// check to be considered healthy. To specify the child health checks that you want to
        /// associate with a <c>CALCULATED</c> health check, use the <a href="https://docs.aws.amazon.com/Route53/latest/APIReference/API_UpdateHealthCheck.html#Route53-UpdateHealthCheck-request-ChildHealthChecks">ChildHealthChecks</a>
        /// element.</para><para>Note the following:</para><ul><li><para>If you specify a number greater than the number of child health checks, Route 53 always
        /// considers this health check to be unhealthy.</para></li><li><para>If you specify <c>0</c>, Route 53 always considers this health check to be healthy.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? HealthCheckConfig_HealthThreshold { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_InsufficientDataHealthStatus
        /// <summary>
        /// <para>
        /// <para>When CloudWatch has insufficient data about the metric to determine the alarm state,
        /// the status that you want Amazon Route 53 to assign to the health check:</para><ul><li><para><c>Healthy</c>: Route 53 considers the health check to be healthy.</para></li><li><para><c>Unhealthy</c>: Route 53 considers the health check to be unhealthy.</para></li><li><para><c>LastKnownStatus</c>: Route 53 uses the status of the health check from the last
        /// time that CloudWatch had sufficient data to determine the alarm state. For new health
        /// checks that have no last known status, the default status for the health check is
        /// healthy.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? HealthCheckConfig_Inverted { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_IPAddress
        /// <summary>
        /// <para>
        /// <para>The IPv4 or IPv6 IP address of the endpoint that you want Amazon Route 53 to perform
        /// health checks on. If you don't specify a value for <c>IPAddress</c>, Route 53 sends
        /// a DNS request to resolve the domain name that you specify in <c>FullyQualifiedDomainName</c>
        /// at the interval that you specify in <c>RequestInterval</c>. Using an IP address returned
        /// by DNS, Route 53 then checks the health of the endpoint.</para><para>Use one of the following formats for the value of <c>IPAddress</c>: </para><ul><li><para><b>IPv4 address</b>: four values between 0 and 255, separated by periods (.), for
        /// example, <c>192.0.2.44</c>.</para></li><li><para><b>IPv6 address</b>: eight groups of four hexadecimal values, separated by colons
        /// (:), for example, <c>2001:0db8:85a3:0000:0000:abcd:0001:2345</c>. You can also shorten
        /// IPv6 addresses as described in RFC 5952, for example, <c>2001:db8:85a3::abcd:1:2345</c>.</para></li></ul><para>If the endpoint is an EC2 instance, we recommend that you create an Elastic IP address,
        /// associate it with your EC2 instance, and specify the Elastic IP address for <c>IPAddress</c>.
        /// This ensures that the IP address of your instance will never change.</para><para>For more information, see <a href="https://docs.aws.amazon.com/Route53/latest/APIReference/API_UpdateHealthCheck.html#Route53-UpdateHealthCheck-request-FullyQualifiedDomainName">FullyQualifiedDomainName</a>.
        /// </para><para>Constraints: Route 53 can't check the health of endpoints for which the IP address
        /// is in local, private, non-routable, or multicast ranges. For more information about
        /// IP addresses for which you can't create health checks, see the following documents:</para><ul><li><para><a href="https://tools.ietf.org/html/rfc5735">RFC 5735, Special Use IPv4 Addresses</a></para></li><li><para><a href="https://tools.ietf.org/html/rfc6598">RFC 6598, IANA-Reserved IPv4 Prefix
        /// for Shared Address Space</a></para></li><li><para><a href="https://tools.ietf.org/html/rfc5156">RFC 5156, Special-Use IPv6 Addresses</a></para></li></ul><para>When the value of <c>Type</c> is <c>CALCULATED</c> or <c>CLOUDWATCH_METRIC</c>, omit
        /// <c>IPAddress</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HealthCheckConfig_IPAddress { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_MeasureLatency
        /// <summary>
        /// <para>
        /// <para>Specify whether you want Amazon Route 53 to measure the latency between health checkers
        /// in multiple Amazon Web Services regions and your endpoint, and to display CloudWatch
        /// latency graphs on the <b>Health Checks</b> page in the Route 53 console.</para><important><para>You can't change the value of <c>MeasureLatency</c> after you create a health check.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? HealthCheckConfig_MeasureLatency { get; set; }
        #endregion
        
        #region Parameter AlarmIdentifier_Name
        /// <summary>
        /// <para>
        /// <para>The name of the CloudWatch alarm that you want Amazon Route 53 health checkers to
        /// use to determine whether this health check is healthy.</para><note><para>Route 53 supports CloudWatch alarms with the following features:</para><ul><li><para>Standard-resolution metrics. High-resolution metrics aren't supported. For more information,
        /// see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/DeveloperGuide/publishingMetrics.html#high-resolution-metrics">High-Resolution
        /// Metrics</a> in the <i>Amazon CloudWatch User Guide</i>.</para></li><li><para>Statistics: Average, Minimum, Maximum, Sum, and SampleCount. Extended statistics aren't
        /// supported.</para></li></ul></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HealthCheckConfig_AlarmIdentifier_Name")]
        public System.String AlarmIdentifier_Name { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_Port
        /// <summary>
        /// <para>
        /// <para>The port on the endpoint that you want Amazon Route 53 to perform health checks on.</para><note><para>Don't specify a value for <c>Port</c> when you specify a value for <c>Type</c> of
        /// <c>CLOUDWATCH_METRIC</c> or <c>CALCULATED</c>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? HealthCheckConfig_Port { get; set; }
        #endregion
        
        #region Parameter AlarmIdentifier_Region
        /// <summary>
        /// <para>
        /// <para>For the CloudWatch alarm that you want Route 53 health checkers to use to determine
        /// whether this health check is healthy, the region that the alarm was created in.</para><para>For the current list of CloudWatch regions, see <a href="https://docs.aws.amazon.com/general/latest/gr/cw_region.html">Amazon
        /// CloudWatch endpoints and quotas</a> in the <i>Amazon Web Services General Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HealthCheckConfig_AlarmIdentifier_Region")]
        [AWSConstantClassSource("Amazon.Route53.CloudWatchRegion")]
        public Amazon.Route53.CloudWatchRegion AlarmIdentifier_Region { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_Region
        /// <summary>
        /// <para>
        /// <para>A complex type that contains one <c>Region</c> element for each region from which
        /// you want Amazon Route 53 health checkers to check the specified endpoint.</para><para>If you don't specify any regions, Route 53 health checkers automatically performs
        /// checks from all of the regions that are listed under <b>Valid Values</b>.</para><para>If you update a health check to remove a region that has been performing health checks,
        /// Route 53 will briefly continue to perform checks from that region to ensure that some
        /// health checkers are always checking the endpoint (for example, if you replace three
        /// regions with four different regions). </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HealthCheckConfig_Regions")]
        public System.String[] HealthCheckConfig_Region { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_RequestInterval
        /// <summary>
        /// <para>
        /// <para>The number of seconds between the time that Amazon Route 53 gets a response from your
        /// endpoint and the time that it sends the next health check request. Each Route 53 health
        /// checker makes requests at this interval.</para><important><para>You can't change the value of <c>RequestInterval</c> after you create a health check.</para></important><para>If you don't specify a value for <c>RequestInterval</c>, the default value is <c>30</c>
        /// seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? HealthCheckConfig_RequestInterval { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_ResourcePath
        /// <summary>
        /// <para>
        /// <para>The path, if any, that you want Amazon Route 53 to request when performing health
        /// checks. The path can be any value for which your endpoint will return an HTTP status
        /// code of 2xx or 3xx when the endpoint is healthy, for example, the file /docs/route53-health-check.html.
        /// You can also include query string parameters, for example, <c>/welcome.html?language=jp&amp;login=y</c>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HealthCheckConfig_ResourcePath { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_RoutingControlArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for the Route 53 Application Recovery Controller routing
        /// control.</para><para>For more information about Route 53 Application Recovery Controller, see <a href="https://docs.aws.amazon.com/r53recovery/latest/dg/what-is-route-53-recovery.html">Route
        /// 53 Application Recovery Controller Developer Guide.</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HealthCheckConfig_RoutingControlArn { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_SearchString
        /// <summary>
        /// <para>
        /// <para>If the value of Type is <c>HTTP_STR_MATCH</c> or <c>HTTPS_STR_MATCH</c>, the string
        /// that you want Amazon Route 53 to search for in the response body from the specified
        /// resource. If the string appears in the response body, Route 53 considers the resource
        /// healthy.</para><para>Route 53 considers case when searching for <c>SearchString</c> in the response body.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HealthCheckConfig_SearchString { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfig_Type
        /// <summary>
        /// <para>
        /// <para>The type of health check that you want to create, which indicates how Amazon Route
        /// 53 determines whether an endpoint is healthy.</para><important><para>You can't change the value of <c>Type</c> after you create a health check.</para></important><para>You can create the following types of health checks:</para><ul><li><para><b>HTTP</b>: Route 53 tries to establish a TCP connection. If successful, Route 53
        /// submits an HTTP request and waits for an HTTP status code of 200 or greater and less
        /// than 400.</para></li><li><para><b>HTTPS</b>: Route 53 tries to establish a TCP connection. If successful, Route
        /// 53 submits an HTTPS request and waits for an HTTP status code of 200 or greater and
        /// less than 400.</para><important><para>If you specify <c>HTTPS</c> for the value of <c>Type</c>, the endpoint must support
        /// TLS v1.0, v1.1, or v1.2.</para></important></li><li><para><b>HTTP_STR_MATCH</b>: Route 53 tries to establish a TCP connection. If successful,
        /// Route 53 submits an HTTP request and searches the first 5,120 bytes of the response
        /// body for the string that you specify in <c>SearchString</c>.</para></li><li><para><b>HTTPS_STR_MATCH</b>: Route 53 tries to establish a TCP connection. If successful,
        /// Route 53 submits an <c>HTTPS</c> request and searches the first 5,120 bytes of the
        /// response body for the string that you specify in <c>SearchString</c>.</para></li><li><para><b>TCP</b>: Route 53 tries to establish a TCP connection.</para></li><li><para><b>CLOUDWATCH_METRIC</b>: The health check is associated with a CloudWatch alarm.
        /// If the state of the alarm is <c>OK</c>, the health check is considered healthy. If
        /// the state is <c>ALARM</c>, the health check is considered unhealthy. If CloudWatch
        /// doesn't have sufficient data to determine whether the state is <c>OK</c> or <c>ALARM</c>,
        /// the health check status depends on the setting for <c>InsufficientDataHealthStatus</c>:
        /// <c>Healthy</c>, <c>Unhealthy</c>, or <c>LastKnownStatus</c>. </para></li><li><para><b>CALCULATED</b>: For health checks that monitor the status of other health checks,
        /// Route 53 adds up the number of health checks that Route 53 health checkers consider
        /// to be healthy and compares that number with the value of <c>HealthThreshold</c>. </para></li><li><para><b>RECOVERY_CONTROL</b>: The health check is associated with a Route53 Application
        /// Recovery Controller routing control. If the routing control state is <c>ON</c>, the
        /// health check is considered healthy. If the state is <c>OFF</c>, the health check is
        /// considered unhealthy. </para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/Route53/latest/DeveloperGuide/dns-failover-determining-health-of-endpoints.html">How
        /// Route 53 Determines Whether an Endpoint Is Healthy</a> in the <i>Amazon Route 53 Developer
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Route53.HealthCheckType")]
        public Amazon.Route53.HealthCheckType HealthCheckConfig_Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53.Model.CreateHealthCheckResponse).
        /// Specifying the name of a property of type Amazon.Route53.Model.CreateHealthCheckResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53.Model.CreateHealthCheckResponse, NewR53HealthCheckCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CallerReference = this.CallerReference;
            #if MODULAR
            if (this.CallerReference == null && ParameterWasBound(nameof(this.CallerReference)))
            {
                WriteWarning("You are passing $null as a value for parameter CallerReference which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HealthCheckConfig_IPAddress = this.HealthCheckConfig_IPAddress;
            context.HealthCheckConfig_Port = this.HealthCheckConfig_Port;
            context.HealthCheckConfig_Type = this.HealthCheckConfig_Type;
            #if MODULAR
            if (this.HealthCheckConfig_Type == null && ParameterWasBound(nameof(this.HealthCheckConfig_Type)))
            {
                WriteWarning("You are passing $null as a value for parameter HealthCheckConfig_Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HealthCheckConfig_ResourcePath = this.HealthCheckConfig_ResourcePath;
            context.HealthCheckConfig_FullyQualifiedDomainName = this.HealthCheckConfig_FullyQualifiedDomainName;
            context.HealthCheckConfig_SearchString = this.HealthCheckConfig_SearchString;
            context.HealthCheckConfig_RequestInterval = this.HealthCheckConfig_RequestInterval;
            context.HealthCheckConfig_FailureThreshold = this.HealthCheckConfig_FailureThreshold;
            context.HealthCheckConfig_MeasureLatency = this.HealthCheckConfig_MeasureLatency;
            context.HealthCheckConfig_Inverted = this.HealthCheckConfig_Inverted;
            context.HealthCheckConfig_Disabled = this.HealthCheckConfig_Disabled;
            context.HealthCheckConfig_HealthThreshold = this.HealthCheckConfig_HealthThreshold;
            if (this.HealthCheckConfig_ChildHealthCheck != null)
            {
                context.HealthCheckConfig_ChildHealthCheck = new List<System.String>(this.HealthCheckConfig_ChildHealthCheck);
            }
            context.HealthCheckConfig_EnableSNI = this.HealthCheckConfig_EnableSNI;
            if (this.HealthCheckConfig_Region != null)
            {
                context.HealthCheckConfig_Region = new List<System.String>(this.HealthCheckConfig_Region);
            }
            context.AlarmIdentifier_Region = this.AlarmIdentifier_Region;
            context.AlarmIdentifier_Name = this.AlarmIdentifier_Name;
            context.HealthCheckConfig_InsufficientDataHealthStatus = this.HealthCheckConfig_InsufficientDataHealthStatus;
            context.HealthCheckConfig_RoutingControlArn = this.HealthCheckConfig_RoutingControlArn;
            
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
            var requestHealthCheckConfigIsNull = true;
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
            System.Boolean? requestHealthCheckConfig_healthCheckConfig_Disabled = null;
            if (cmdletContext.HealthCheckConfig_Disabled != null)
            {
                requestHealthCheckConfig_healthCheckConfig_Disabled = cmdletContext.HealthCheckConfig_Disabled.Value;
            }
            if (requestHealthCheckConfig_healthCheckConfig_Disabled != null)
            {
                request.HealthCheckConfig.Disabled = requestHealthCheckConfig_healthCheckConfig_Disabled.Value;
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
            if (cmdletContext.HealthCheckConfig_ChildHealthCheck != null)
            {
                requestHealthCheckConfig_healthCheckConfig_ChildHealthCheck = cmdletContext.HealthCheckConfig_ChildHealthCheck;
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
            if (cmdletContext.HealthCheckConfig_Region != null)
            {
                requestHealthCheckConfig_healthCheckConfig_Region = cmdletContext.HealthCheckConfig_Region;
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
            System.String requestHealthCheckConfig_healthCheckConfig_RoutingControlArn = null;
            if (cmdletContext.HealthCheckConfig_RoutingControlArn != null)
            {
                requestHealthCheckConfig_healthCheckConfig_RoutingControlArn = cmdletContext.HealthCheckConfig_RoutingControlArn;
            }
            if (requestHealthCheckConfig_healthCheckConfig_RoutingControlArn != null)
            {
                request.HealthCheckConfig.RoutingControlArn = requestHealthCheckConfig_healthCheckConfig_RoutingControlArn;
                requestHealthCheckConfigIsNull = false;
            }
            Amazon.Route53.Model.AlarmIdentifier requestHealthCheckConfig_healthCheckConfig_AlarmIdentifier = null;
            
             // populate AlarmIdentifier
            var requestHealthCheckConfig_healthCheckConfig_AlarmIdentifierIsNull = true;
            requestHealthCheckConfig_healthCheckConfig_AlarmIdentifier = new Amazon.Route53.Model.AlarmIdentifier();
            Amazon.Route53.CloudWatchRegion requestHealthCheckConfig_healthCheckConfig_AlarmIdentifier_alarmIdentifier_Region = null;
            if (cmdletContext.AlarmIdentifier_Region != null)
            {
                requestHealthCheckConfig_healthCheckConfig_AlarmIdentifier_alarmIdentifier_Region = cmdletContext.AlarmIdentifier_Region;
            }
            if (requestHealthCheckConfig_healthCheckConfig_AlarmIdentifier_alarmIdentifier_Region != null)
            {
                requestHealthCheckConfig_healthCheckConfig_AlarmIdentifier.Region = requestHealthCheckConfig_healthCheckConfig_AlarmIdentifier_alarmIdentifier_Region;
                requestHealthCheckConfig_healthCheckConfig_AlarmIdentifierIsNull = false;
            }
            System.String requestHealthCheckConfig_healthCheckConfig_AlarmIdentifier_alarmIdentifier_Name = null;
            if (cmdletContext.AlarmIdentifier_Name != null)
            {
                requestHealthCheckConfig_healthCheckConfig_AlarmIdentifier_alarmIdentifier_Name = cmdletContext.AlarmIdentifier_Name;
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
        
        private Amazon.Route53.Model.CreateHealthCheckResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.CreateHealthCheckRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53", "CreateHealthCheck");
            try
            {
                return client.CreateHealthCheckAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? HealthCheckConfig_Disabled { get; set; }
            public System.Int32? HealthCheckConfig_HealthThreshold { get; set; }
            public List<System.String> HealthCheckConfig_ChildHealthCheck { get; set; }
            public System.Boolean? HealthCheckConfig_EnableSNI { get; set; }
            public List<System.String> HealthCheckConfig_Region { get; set; }
            public Amazon.Route53.CloudWatchRegion AlarmIdentifier_Region { get; set; }
            public System.String AlarmIdentifier_Name { get; set; }
            public Amazon.Route53.InsufficientDataHealthStatus HealthCheckConfig_InsufficientDataHealthStatus { get; set; }
            public System.String HealthCheckConfig_RoutingControlArn { get; set; }
            public System.Func<Amazon.Route53.Model.CreateHealthCheckResponse, NewR53HealthCheckCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
