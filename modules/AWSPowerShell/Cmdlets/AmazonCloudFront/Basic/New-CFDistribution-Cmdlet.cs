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
using Amazon.CloudFront;
using Amazon.CloudFront.Model;

namespace Amazon.PowerShell.Cmdlets.CF
{
    /// <summary>
    /// Creates a new web distribution. Send a <code>POST</code> request to the <code>/<i>CloudFront
    /// API version</i>/distribution</code>/<code>distribution ID</code> resource.
    /// </summary>
    [Cmdlet("New", "CFDistribution", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudFront.Model.CreateDistributionResponse")]
    [AWSCmdlet("Invokes the CreateDistribution operation against Amazon CloudFront.", Operation = new[] {"CreateDistribution"})]
    [AWSCmdletOutput("Amazon.CloudFront.Model.CreateDistributionResponse",
        "This cmdlet returns a Amazon.CloudFront.Model.CreateDistributionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCFDistributionCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        #region Parameter ViewerCertificate_ACMCertificateArn
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_ViewerCertificate_ACMCertificateArn")]
        public System.String ViewerCertificate_ACMCertificateArn { get; set; }
        #endregion
        
        #region Parameter Logging_Bucket
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket to store the access logs in, for example, <code>myawslogbucket.s3.amazonaws.com</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_Logging_Bucket")]
        public System.String Logging_Bucket { get; set; }
        #endregion
        
        #region Parameter DistributionConfig_CallerReference
        /// <summary>
        /// <para>
        /// <para>A unique value (for example, a date-time stamp) that ensures that the request can't
        /// be replayed.</para><para>If the value of <code>CallerReference</code> is new (regardless of the content of
        /// the <code>DistributionConfig</code> object), CloudFront creates a new distribution.</para><para>If <code>CallerReference</code> is a value you already sent in a previous request
        /// to create a distribution, and if the content of the <code>DistributionConfig</code>
        /// is identical to the original request (ignoring white space), CloudFront returns the
        /// same the response that it returned to the original request.</para><para>If <code>CallerReference</code> is a value you already sent in a previous request
        /// to create a distribution but the content of the <code>DistributionConfig</code> is
        /// different from the original request, CloudFront returns a <code>DistributionAlreadyExists</code>
        /// error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DistributionConfig_CallerReference { get; set; }
        #endregion
        
        #region Parameter ViewerCertificate_Certificate
        /// <summary>
        /// <para>
        /// <para>Include one of these values to specify the following:</para><ul><li><para>Whether you want viewers to use HTTP or HTTPS to request your objects.</para></li><li><para>If you want viewers to use HTTPS, whether you're using an alternate domain name such
        /// as example.com or the CloudFront domain name for your distribution, such as <code>d111111abcdef8.cloudfront.net</code>.</para></li><li><para>If you're using an alternate domain name, whether AWS Certificate Manager (ACM) provided
        /// the certificate, or you purchased a certificate from a third-party certificate authority
        /// and imported it into ACM or uploaded it to the IAM certificate store.</para></li></ul><para>You must specify one (and only one) of the three values. Do not specify <code>false</code>
        /// for <code>CloudFrontDefaultCertificate</code>.</para><para><b>If you want viewers to use HTTP to request your objects</b>: Specify the following
        /// value:</para><para><code>&lt;CloudFrontDefaultCertificate&gt;true&lt;CloudFrontDefaultCertificate&gt;</code></para><para>In addition, specify <code>allow-all</code> for <code>ViewerProtocolPolicy</code>
        /// for all of your cache behaviors.</para><para><b>If you want viewers to use HTTPS to request your objects</b>: Choose the type
        /// of certificate that you want to use based on whether you're using an alternate domain
        /// name for your objects or the CloudFront domain name:</para><ul><li><para><b>If you're using an alternate domain name, such as example.com</b>: Specify one
        /// of the following values, depending on whether ACM provided your certificate or you
        /// purchased your certificate from third-party certificate authority:</para><ul><li><para><code>&lt;ACMCertificateArn&gt;ARN for ACM SSL/TLS certificate&lt;ACMCertificateArn&gt;</code>
        /// where ARN for ACM SSL/TLS certificate is the ARN for the ACM SSL/TLS certificate that
        /// you want to use for this distribution.</para></li><li><para><code>&lt;IAMCertificateId&gt;IAM certificate ID&lt;IAMCertificateId&gt;</code> where
        /// IAM certificate ID is the ID that IAM returned when you added the certificate to the
        /// IAM certificate store.</para></li></ul><para>If you specify <code>ACMCertificateArn</code> or <code>IAMCertificateId</code>, you
        /// must also specify a value for <code>SSLSupportMethod</code>.</para><para>If you choose to use an ACM certificate or a certificate in the IAM certificate store,
        /// we recommend that you use only an alternate domain name in your object URLs (<code>https://example.com/logo.jpg</code>).
        /// If you use the domain name that is associated with your CloudFront distribution (<code>https://d111111abcdef8.cloudfront.net/logo.jpg</code>)
        /// and the viewer supports <code>SNI</code>, then CloudFront behaves normally. However,
        /// if the browser does not support SNI, the user's experience depends on the value that
        /// you choose for <code>SSLSupportMethod</code>:</para><ul><li><para><code>vip</code>: The viewer displays a warning because there is a mismatch between
        /// the CloudFront domain name and the domain name in your SSL/TLS certificate.</para></li><li><para><code>sni-only</code>: CloudFront drops the connection with the browser without returning
        /// the object.</para></li></ul></li><li><para><b>If you're using the CloudFront domain name for your distribution, such as <code>d111111abcdef8.cloudfront.net</code></b>: Specify the following value:</para><para><code> &lt;CloudFrontDefaultCertificate&gt;true&lt;CloudFrontDefaultCertificate&gt;
        /// </code></para><para>If you want viewers to use HTTPS, you must also specify one of the following values
        /// in your cache behaviors:</para><ul><li><para><code> &lt;ViewerProtocolPolicy&gt;https-only&lt;ViewerProtocolPolicy&gt; </code></para></li><li><para><code> &lt;ViewerProtocolPolicy&gt;redirect-to-https&lt;ViewerProtocolPolicy&gt;
        /// </code></para></li></ul><para>You can also optionally require that CloudFront use HTTPS to communicate with your
        /// origin by specifying one of the following values for the applicable origins:</para><ul><li><para><code> &lt;OriginProtocolPolicy&gt;https-only&lt;OriginProtocolPolicy&gt; </code></para></li><li><para><code> &lt;OriginProtocolPolicy&gt;match-viewer&lt;OriginProtocolPolicy&gt; </code></para></li></ul><para>For more information, see <a href="http://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/SecureConnections.html#CNAMEsAndHTTPS">Using
        /// Alternate Domain Names and HTTPS</a> in the <i>Amazon CloudFront Developer Guide</i>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_ViewerCertificate_Certificate")]
        public System.String ViewerCertificate_Certificate { get; set; }
        #endregion
        
        #region Parameter ViewerCertificate_CertificateSource
        /// <summary>
        /// <para>
        /// <note><para>This field is deprecated. You can use one of the following: <code>[ACMCertificateArn</code>,
        /// <code>IAMCertificateId</code>, or <code>CloudFrontDefaultCertificate]</code>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_ViewerCertificate_CertificateSource")]
        [AWSConstantClassSource("Amazon.CloudFront.CertificateSource")]
        public Amazon.CloudFront.CertificateSource ViewerCertificate_CertificateSource { get; set; }
        #endregion
        
        #region Parameter ViewerCertificate_CloudFrontDefaultCertificate
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_ViewerCertificate_CloudFrontDefaultCertificate")]
        public System.Boolean ViewerCertificate_CloudFrontDefaultCertificate { get; set; }
        #endregion
        
        #region Parameter DistributionConfig_Comment
        /// <summary>
        /// <para>
        /// <para>Any comments you want to include about the distribution.</para><para>If you don't want to specify a comment, include an empty <code>Comment</code> element.</para><para>To delete an existing comment, update the distribution configuration and include an
        /// empty <code>Comment</code> element.</para><para>To add or change a comment, update the distribution configuration and specify the
        /// new comment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DistributionConfig_Comment { get; set; }
        #endregion
        
        #region Parameter DefaultCacheBehavior_Compress
        /// <summary>
        /// <para>
        /// <para>Whether you want CloudFront to automatically compress certain files for this cache
        /// behavior. If so, specify <code>true</code>; if not, specify <code>false</code>. For
        /// more information, see <a href="http://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/ServingCompressedFiles.html">Serving
        /// Compressed Files</a> in the <i>Amazon CloudFront Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_DefaultCacheBehavior_Compress")]
        public System.Boolean DefaultCacheBehavior_Compress { get; set; }
        #endregion
        
        #region Parameter DistributionConfig_DefaultRootObject
        /// <summary>
        /// <para>
        /// <para>The object that you want CloudFront to request from your origin (for example, <code>index.html</code>)
        /// when a viewer requests the root URL for your distribution (<code>http://www.example.com</code>)
        /// instead of an object in your distribution (<code>http://www.example.com/product-description.html</code>).
        /// Specifying a default root object avoids exposing the contents of your distribution.</para><para>Specify only the object name, for example, <code>index.html</code>. Do not add a <code>/</code>
        /// before the object name.</para><para>If you don't want to specify a default root object when you create a distribution,
        /// include an empty <code>DefaultRootObject</code> element.</para><para>To delete the default root object from an existing distribution, update the distribution
        /// configuration and include an empty <code>DefaultRootObject</code> element.</para><para>To replace the default root object, update the distribution configuration and specify
        /// the new object.</para><para>For more information about the default root object, see <a href="http://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/DefaultRootObject.html">Creating
        /// a Default Root Object</a> in the <i>Amazon CloudFront Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DistributionConfig_DefaultRootObject { get; set; }
        #endregion
        
        #region Parameter DefaultCacheBehavior_DefaultTTL
        /// <summary>
        /// <para>
        /// <para>The default amount of time that you want objects to stay in CloudFront caches before
        /// CloudFront forwards another request to your origin to determine whether the object
        /// has been updated. The value that you specify applies only when your origin does not
        /// add HTTP headers such as <code>Cache-Control max-age</code>, <code>Cache-Control s-maxage</code>,
        /// and <code>Expires</code> to objects. For more information, see <a href="http://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/Expiration.html">Specifying
        /// How Long Objects and Errors Stay in a CloudFront Edge Cache (Expiration)</a> in the
        /// <i>Amazon CloudFront Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_DefaultCacheBehavior_DefaultTTL")]
        public System.Int64 DefaultCacheBehavior_DefaultTTL { get; set; }
        #endregion
        
        #region Parameter TrustedSigners_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether you want to require viewers to use signed URLs to access the files
        /// specified by <code>PathPattern</code> and <code>TargetOriginId</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_DefaultCacheBehavior_TrustedSigners_Enabled")]
        public System.Boolean TrustedSigners_Enabled { get; set; }
        #endregion
        
        #region Parameter DistributionConfig_Enabled
        /// <summary>
        /// <para>
        /// <para>From this field, you can enable or disable the selected distribution.</para><para>If you specify <code>false</code> for <code>Enabled</code> but you specify values
        /// for <code>Bucket</code> and <code>Prefix</code>, the values are automatically deleted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean DistributionConfig_Enabled { get; set; }
        #endregion
        
        #region Parameter Logging_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether you want CloudFront to save access logs to an Amazon S3 bucket.
        /// If you do not want to enable logging when you create a distribution or if you want
        /// to disable logging for an existing distribution, specify <code>false</code> for <code>Enabled</code>,
        /// and specify empty <code>Bucket</code> and <code>Prefix</code> elements. If you specify
        /// <code>false</code> for <code>Enabled</code> but you specify values for <code>Bucket</code>,
        /// <code>prefix</code>, and <code>IncludeCookies</code>, the values are automatically
        /// deleted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_Logging_Enabled")]
        public System.Boolean Logging_Enabled { get; set; }
        #endregion
        
        #region Parameter Cookies_Forward
        /// <summary>
        /// <para>
        /// <para>Specifies which cookies to forward to the origin for this cache behavior: all, none,
        /// or the list of cookies specified in the <code>WhitelistedNames</code> complex type.</para><para>Amazon S3 doesn't process cookies. When the cache behavior is forwarding requests
        /// to an Amazon S3 origin, specify none for the <code>Forward</code> element. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_Forward")]
        [AWSConstantClassSource("Amazon.CloudFront.ItemSelection")]
        public Amazon.CloudFront.ItemSelection Cookies_Forward { get; set; }
        #endregion
        
        #region Parameter DistributionConfig_HttpVersion
        /// <summary>
        /// <para>
        /// <para>(Optional) Specify the maximum HTTP version that you want viewers to use to communicate
        /// with CloudFront. The default value for new web distributions is http2. Viewers that
        /// don't support HTTP/2 automatically use an earlier HTTP version.</para><para>For viewers and CloudFront to use HTTP/2, viewers must support TLS 1.2 or later, and
        /// must support Server Name Identification (SNI).</para><para>In general, configuring CloudFront to communicate with viewers using HTTP/2 reduces
        /// latency. You can improve performance by optimizing for HTTP/2. For more information,
        /// do an Internet search for "http/2 optimization." </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CloudFront.HttpVersion")]
        public Amazon.CloudFront.HttpVersion DistributionConfig_HttpVersion { get; set; }
        #endregion
        
        #region Parameter ViewerCertificate_IAMCertificateId
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_ViewerCertificate_IAMCertificateId")]
        public System.String ViewerCertificate_IAMCertificateId { get; set; }
        #endregion
        
        #region Parameter Logging_IncludeCookie
        /// <summary>
        /// <para>
        /// <para>Specifies whether you want CloudFront to include cookies in access logs, specify <code>true</code>
        /// for <code>IncludeCookies</code>. If you choose to include cookies in logs, CloudFront
        /// logs all cookies regardless of how you configure the cache behaviors for this distribution.
        /// If you do not want to include cookies when you create a distribution or if you want
        /// to disable include cookies for an existing distribution, specify <code>false</code>
        /// for <code>IncludeCookies</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_Logging_IncludeCookies")]
        public System.Boolean Logging_IncludeCookie { get; set; }
        #endregion
        
        #region Parameter DistributionConfig_IsIPV6Enabled
        /// <summary>
        /// <para>
        /// <para>If you want CloudFront to respond to IPv6 DNS requests with an IPv6 address for your
        /// distribution, specify <code>true</code>. If you specify <code>false</code>, CloudFront
        /// responds to IPv6 DNS requests with the DNS response code <code>NOERROR</code> and
        /// with no IP addresses. This allows viewers to submit a second request, for an IPv4
        /// address for your distribution. </para><para>In general, you should enable IPv6 if you have users on IPv6 networks who want to
        /// access your content. However, if you're using signed URLs or signed cookies to restrict
        /// access to your content, and if you're using a custom policy that includes the <code>IpAddress</code>
        /// parameter to restrict the IP addresses that can access your content, do not enable
        /// IPv6. If you want to restrict access to some content by IP address and not restrict
        /// access to other content (or restrict access but not by IP address), you can create
        /// two distributions. For more information, see <a href="http://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/private-content-creating-signed-url-custom-policy.html">Creating
        /// a Signed URL Using a Custom Policy</a> in the <i>Amazon CloudFront Developer Guide</i>.</para><para>If you're using an Amazon Route 53 alias resource record set to route traffic to your
        /// CloudFront distribution, you need to create a second alias resource record set when
        /// both of the following are true:</para><ul><li><para>You enable IPv6 for the distribution</para></li><li><para>You're using alternate domain names in the URLs for your objects</para></li></ul><para>For more information, see <a href="http://docs.aws.amazon.com/Route53/latest/DeveloperGuide/routing-to-cloudfront-distribution.html">Routing
        /// Traffic to an Amazon CloudFront Web Distribution by Using Your Domain Name</a> in
        /// the <i>Amazon Route 53 Developer Guide</i>.</para><para>If you created a CNAME resource record set, either with Amazon Route 53 or with another
        /// DNS service, you don't need to make any changes. A CNAME record will route traffic
        /// to your distribution regardless of the IP address format of the viewer request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean DistributionConfig_IsIPV6Enabled { get; set; }
        #endregion
        
        #region Parameter Aliases_Item
        /// <summary>
        /// <para>
        /// <para>A complex type that contains the CNAME aliases, if any, that you want to associate
        /// with this distribution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_Aliases_Items")]
        public System.String[] Aliases_Item { get; set; }
        #endregion
        
        #region Parameter CacheBehaviors_Item
        /// <summary>
        /// <para>
        /// <para>Optional: A complex type that contains cache behaviors for this distribution. If <code>Quantity</code>
        /// is <code>0</code>, you can omit <code>Items</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_CacheBehaviors_Items")]
        public Amazon.CloudFront.Model.CacheBehavior[] CacheBehaviors_Item { get; set; }
        #endregion
        
        #region Parameter CustomErrorResponses_Item
        /// <summary>
        /// <para>
        /// <para>A complex type that contains a <code>CustomErrorResponse</code> element for each HTTP
        /// status code for which you want to specify a custom error page and/or a caching duration.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_CustomErrorResponses_Items")]
        public Amazon.CloudFront.Model.CustomErrorResponse[] CustomErrorResponses_Item { get; set; }
        #endregion
        
        #region Parameter CachedMethods_Item
        /// <summary>
        /// <para>
        /// <para>A complex type that contains the HTTP methods that you want CloudFront to cache responses
        /// to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_Items")]
        public System.String[] CachedMethods_Item { get; set; }
        #endregion
        
        #region Parameter AllowedMethods_Item
        /// <summary>
        /// <para>
        /// <para>A complex type that contains the HTTP methods that you want CloudFront to process
        /// and forward to your origin.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_DefaultCacheBehavior_AllowedMethods_Items")]
        public System.String[] AllowedMethods_Item { get; set; }
        #endregion
        
        #region Parameter WhitelistedNames_Item
        /// <summary>
        /// <para>
        /// <para>A complex type that contains one <code>Name</code> element for each cookie that you
        /// want CloudFront to forward to the origin for this cache behavior.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_Items")]
        public System.String[] WhitelistedNames_Item { get; set; }
        #endregion
        
        #region Parameter Headers_Item
        /// <summary>
        /// <para>
        /// <para>A complex type that contains one <code>Name</code> element for each header that you
        /// want CloudFront to forward to the origin and to vary on for this cache behavior. If
        /// <code>Quantity</code> is <code>0</code>, omit <code>Items</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_Items")]
        public System.String[] Headers_Item { get; set; }
        #endregion
        
        #region Parameter QueryStringCacheKeys_Item
        /// <summary>
        /// <para>
        /// <para>(Optional) A list that contains the query string parameters that you want CloudFront
        /// to use as a basis for caching for this cache behavior. If <code>Quantity</code> is
        /// 0, you can omit <code>Items</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_Items")]
        public System.String[] QueryStringCacheKeys_Item { get; set; }
        #endregion
        
        #region Parameter LambdaFunctionAssociations_Item
        /// <summary>
        /// <para>
        /// <para><b>Optional</b>: A complex type that contains <code>LambdaFunctionAssociation</code>
        /// items for this cache behavior. If <code>Quantity</code> is <code>0</code>, you can
        /// omit <code>Items</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_Items")]
        public Amazon.CloudFront.Model.LambdaFunctionAssociation[] LambdaFunctionAssociations_Item { get; set; }
        #endregion
        
        #region Parameter TrustedSigners_Item
        /// <summary>
        /// <para>
        /// <para><b>Optional</b>: A complex type that contains trusted signers for this cache behavior.
        /// If <code>Quantity</code> is <code>0</code>, you can omit <code>Items</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_DefaultCacheBehavior_TrustedSigners_Items")]
        public System.String[] TrustedSigners_Item { get; set; }
        #endregion
        
        #region Parameter Origins_Item
        /// <summary>
        /// <para>
        /// <para>A complex type that contains origins for this distribution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_Origins_Items")]
        public Amazon.CloudFront.Model.Origin[] Origins_Item { get; set; }
        #endregion
        
        #region Parameter GeoRestriction_Item
        /// <summary>
        /// <para>
        /// <para> A complex type that contains a <code>Location</code> element for each country in
        /// which you want CloudFront either to distribute your content (<code>whitelist</code>)
        /// or not distribute your content (<code>blacklist</code>).</para><para>The <code>Location</code> element is a two-letter, uppercase country code for a country
        /// that you want to include in your <code>blacklist</code> or <code>whitelist</code>.
        /// Include one <code>Location</code> element for each country.</para><para>CloudFront and <code>MaxMind</code> both use <code>ISO 3166</code> country codes.
        /// For the current list of countries and the corresponding codes, see <code>ISO 3166-1-alpha-2</code>
        /// code on the <i>International Organization for Standardization</i> website. You can
        /// also refer to the country list in the CloudFront console, which includes both country
        /// names and codes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_Restrictions_GeoRestriction_Items")]
        public System.String[] GeoRestriction_Item { get; set; }
        #endregion
        
        #region Parameter DefaultCacheBehavior_MaxTTL
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_DefaultCacheBehavior_MaxTTL")]
        public System.Int64 DefaultCacheBehavior_MaxTTL { get; set; }
        #endregion
        
        #region Parameter ViewerCertificate_MinimumProtocolVersion
        /// <summary>
        /// <para>
        /// <para>Specify the minimum version of the SSL/TLS protocol that you want CloudFront to use
        /// for HTTPS connections between viewers and CloudFront: <code>SSLv3</code> or <code>TLSv1</code>.
        /// CloudFront serves your objects only to viewers that support SSL/TLS version that you
        /// specify and later versions. The <code>TLSv1</code> protocol is more secure, so we
        /// recommend that you specify <code>SSLv3</code> only if your users are using browsers
        /// or devices that don't support <code>TLSv1</code>. Note the following:</para><ul><li><para>If you specify &lt;CloudFrontDefaultCertificate&gt;true&lt;CloudFrontDefaultCertificate&gt;,
        /// the minimum SSL protocol version is <code>TLSv1</code> and can't be changed.</para></li><li><para>If you're using a custom certificate (if you specify a value for <code>ACMCertificateArn</code>
        /// or for <code>IAMCertificateId</code>) and if you're using SNI (if you specify <code>sni-only</code>
        /// for <code>SSLSupportMethod</code>), you must specify <code>TLSv1</code> for <code>MinimumProtocolVersion</code>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_ViewerCertificate_MinimumProtocolVersion")]
        [AWSConstantClassSource("Amazon.CloudFront.MinimumProtocolVersion")]
        public Amazon.CloudFront.MinimumProtocolVersion ViewerCertificate_MinimumProtocolVersion { get; set; }
        #endregion
        
        #region Parameter DefaultCacheBehavior_MinTTL
        /// <summary>
        /// <para>
        /// <para>The minimum amount of time that you want objects to stay in CloudFront caches before
        /// CloudFront forwards another request to your origin to determine whether the object
        /// has been updated. For more information, see <a href="http://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/Expiration.html">Specifying
        /// How Long Objects and Errors Stay in a CloudFront Edge Cache (Expiration)</a> in the
        /// <i>Amazon Amazon CloudFront Developer Guide</i>.</para><para>You must specify <code>0</code> for <code>MinTTL</code> if you configure CloudFront
        /// to forward all headers to your origin (under <code>Headers</code>, if you specify
        /// <code>1</code> for <code>Quantity</code> and <code>*</code> for <code>Name</code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_DefaultCacheBehavior_MinTTL")]
        public System.Int64 DefaultCacheBehavior_MinTTL { get; set; }
        #endregion
        
        #region Parameter Logging_Prefix
        /// <summary>
        /// <para>
        /// <para>An optional string that you want CloudFront to prefix to the access log <code>filenames</code>
        /// for this distribution, for example, <code>myprefix/</code>. If you want to enable
        /// logging, but you do not want to specify a prefix, you still must include an empty
        /// <code>Prefix</code> element in the <code>Logging</code> element.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_Logging_Prefix")]
        public System.String Logging_Prefix { get; set; }
        #endregion
        
        #region Parameter DistributionConfig_PriceClass
        /// <summary>
        /// <para>
        /// <para>The price class that corresponds with the maximum price that you want to pay for CloudFront
        /// service. If you specify <code>PriceClass_All</code>, CloudFront responds to requests
        /// for your objects from all CloudFront edge locations.</para><para>If you specify a price class other than <code>PriceClass_All</code>, CloudFront serves
        /// your objects from the CloudFront edge location that has the lowest latency among the
        /// edge locations in your price class. Viewers who are in or near regions that are excluded
        /// from your specified price class may encounter slower performance.</para><para>For more information about price classes, see <a href="http://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/PriceClass.html">Choosing
        /// the Price Class for a CloudFront Distribution</a> in the <i>Amazon CloudFront Developer
        /// Guide</i>. For information about CloudFront pricing, including how price classes map
        /// to CloudFront regions, see <a href="https://aws.amazon.com/cloudfront/pricing/">Amazon
        /// CloudFront Pricing</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CloudFront.PriceClass")]
        public Amazon.CloudFront.PriceClass DistributionConfig_PriceClass { get; set; }
        #endregion
        
        #region Parameter Aliases_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of CNAME aliases, if any, that you want to associate with this distribution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_Aliases_Quantity")]
        public System.Int32 Aliases_Quantity { get; set; }
        #endregion
        
        #region Parameter CacheBehaviors_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of cache behaviors for this distribution. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_CacheBehaviors_Quantity")]
        public System.Int32 CacheBehaviors_Quantity { get; set; }
        #endregion
        
        #region Parameter CustomErrorResponses_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of HTTP status codes for which you want to specify a custom error page
        /// and/or a caching duration. If <code>Quantity</code> is <code>0</code>, you can omit
        /// <code>Items</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_CustomErrorResponses_Quantity")]
        public System.Int32 CustomErrorResponses_Quantity { get; set; }
        #endregion
        
        #region Parameter CachedMethods_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of HTTP methods for which you want CloudFront to cache responses. Valid
        /// values are <code>2</code> (for caching responses to <code>GET</code> and <code>HEAD</code>
        /// requests) and <code>3</code> (for caching responses to <code>GET</code>, <code>HEAD</code>,
        /// and <code>OPTIONS</code> requests).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_Quantity")]
        public System.Int32 CachedMethods_Quantity { get; set; }
        #endregion
        
        #region Parameter AllowedMethods_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of HTTP methods that you want CloudFront to forward to your origin. Valid
        /// values are 2 (for <code>GET</code> and <code>HEAD</code> requests), 3 (for <code>GET</code>,
        /// <code>HEAD</code>, and <code>OPTIONS</code> requests) and 7 (for <code>GET, HEAD,
        /// OPTIONS, PUT, PATCH, POST</code>, and <code>DELETE</code> requests).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_DefaultCacheBehavior_AllowedMethods_Quantity")]
        public System.Int32 AllowedMethods_Quantity { get; set; }
        #endregion
        
        #region Parameter WhitelistedNames_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of different cookies that you want CloudFront to forward to the origin
        /// for this cache behavior.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_Quantity")]
        public System.Int32 WhitelistedNames_Quantity { get; set; }
        #endregion
        
        #region Parameter Headers_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of different headers that you want CloudFront to forward to the origin
        /// for this cache behavior. You can configure each cache behavior in a web distribution
        /// to do one of the following:</para><ul><li><para><b>Forward all headers to your origin</b>: Specify <code>1</code> for <code>Quantity</code>
        /// and <code>*</code> for <code>Name</code>.</para><important><para>If you configure CloudFront to forward all headers to your origin, CloudFront doesn't
        /// cache the objects associated with this cache behavior. Instead, it sends every request
        /// to the origin.</para></important></li><li><para><i>Forward a whitelist of headers you specify</i>: Specify the number of headers
        /// that you want to forward, and specify the header names in <code>Name</code> elements.
        /// CloudFront caches your objects based on the values in all of the specified headers.
        /// CloudFront also forwards the headers that it forwards by default, but it caches your
        /// objects based only on the headers that you specify. </para></li><li><para><b>Forward only the default headers</b>: Specify <code>0</code> for <code>Quantity</code>
        /// and omit <code>Items</code>. In this configuration, CloudFront doesn't cache based
        /// on the values in the request headers.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_Quantity")]
        public System.Int32 Headers_Quantity { get; set; }
        #endregion
        
        #region Parameter QueryStringCacheKeys_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of <code>whitelisted</code> query string parameters for this cache behavior.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_Quantity")]
        public System.Int32 QueryStringCacheKeys_Quantity { get; set; }
        #endregion
        
        #region Parameter LambdaFunctionAssociations_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of Lambda function associations for this cache behavior.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_Quantity")]
        public System.Int32 LambdaFunctionAssociations_Quantity { get; set; }
        #endregion
        
        #region Parameter TrustedSigners_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of trusted signers for this cache behavior.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_DefaultCacheBehavior_TrustedSigners_Quantity")]
        public System.Int32 TrustedSigners_Quantity { get; set; }
        #endregion
        
        #region Parameter Origins_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of origins for this distribution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_Origins_Quantity")]
        public System.Int32 Origins_Quantity { get; set; }
        #endregion
        
        #region Parameter GeoRestriction_Quantity
        /// <summary>
        /// <para>
        /// <para>When geo restriction is <code>enabled</code>, this is the number of countries in your
        /// <code>whitelist</code> or <code>blacklist</code>. Otherwise, when it is not enabled,
        /// <code>Quantity</code> is <code>0</code>, and you can omit <code>Items</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_Restrictions_GeoRestriction_Quantity")]
        public System.Int32 GeoRestriction_Quantity { get; set; }
        #endregion
        
        #region Parameter ForwardedValues_QueryString
        /// <summary>
        /// <para>
        /// <para>Indicates whether you want CloudFront to forward query strings to the origin that
        /// is associated with this cache behavior and cache based on the query string parameters.
        /// CloudFront behavior depends on the value of <code>QueryString</code> and on the values
        /// that you specify for <code>QueryStringCacheKeys</code>, if any:</para><para>If you specify true for <code>QueryString</code> and you don't specify any values
        /// for <code>QueryStringCacheKeys</code>, CloudFront forwards all query string parameters
        /// to the origin and caches based on all query string parameters. Depending on how many
        /// query string parameters and values you have, this can adversely affect performance
        /// because CloudFront must forward more requests to the origin.</para><para>If you specify true for <code>QueryString</code> and you specify one or more values
        /// for <code>QueryStringCacheKeys</code>, CloudFront forwards all query string parameters
        /// to the origin, but it only caches based on the query string parameters that you specify.</para><para>If you specify false for <code>QueryString</code>, CloudFront doesn't forward any
        /// query string parameters to the origin, and doesn't cache based on query string parameters.</para><para>For more information, see <a href="http://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/QueryStringParameters.html">Configuring
        /// CloudFront to Cache Based on Query String Parameters</a> in the <i>Amazon CloudFront
        /// Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryString")]
        public System.Boolean ForwardedValues_QueryString { get; set; }
        #endregion
        
        #region Parameter GeoRestriction_RestrictionType
        /// <summary>
        /// <para>
        /// <para>The method that you want to use to restrict distribution of your content by country:</para><ul><li><para><code>none</code>: No geo restriction is enabled, meaning access to content is not
        /// restricted by client geo location.</para></li><li><para><code>blacklist</code>: The <code>Location</code> elements specify the countries
        /// in which you do not want CloudFront to distribute your content.</para></li><li><para><code>whitelist</code>: The <code>Location</code> elements specify the countries
        /// in which you want CloudFront to distribute your content.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_Restrictions_GeoRestriction_RestrictionType")]
        [AWSConstantClassSource("Amazon.CloudFront.GeoRestrictionType")]
        public Amazon.CloudFront.GeoRestrictionType GeoRestriction_RestrictionType { get; set; }
        #endregion
        
        #region Parameter DefaultCacheBehavior_SmoothStreaming
        /// <summary>
        /// <para>
        /// <para>Indicates whether you want to distribute media files in the Microsoft Smooth Streaming
        /// format using the origin that is associated with this cache behavior. If so, specify
        /// <code>true</code>; if not, specify <code>false</code>. If you specify <code>true</code>
        /// for <code>SmoothStreaming</code>, you can still distribute other content using this
        /// cache behavior if the content matches the value of <code>PathPattern</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_DefaultCacheBehavior_SmoothStreaming")]
        public System.Boolean DefaultCacheBehavior_SmoothStreaming { get; set; }
        #endregion
        
        #region Parameter ViewerCertificate_SSLSupportMethod
        /// <summary>
        /// <para>
        /// <para>If you specify a value for <code>ACMCertificateArn</code> or for <code>IAMCertificateId</code>,
        /// you must also specify how you want CloudFront to serve HTTPS requests: using a method
        /// that works for all clients or one that works for most clients:</para><ul><li><para><code>vip</code>: CloudFront uses dedicated IP addresses for your content and can
        /// respond to HTTPS requests from any viewer. However, you will incur additional monthly
        /// charges.</para></li><li><para><code>sni-only</code>: CloudFront can respond to HTTPS requests from viewers that
        /// support Server Name Indication (SNI). All modern browsers support SNI, but some browsers
        /// still in use don't support SNI. If some of your users' browsers don't support SNI,
        /// we recommend that you do one of the following:</para><ul><li><para>Use the <code>vip</code> option (dedicated IP addresses) instead of <code>sni-only</code>.</para></li><li><para>Use the CloudFront SSL/TLS certificate instead of a custom certificate. This requires
        /// that you use the CloudFront domain name of your distribution in the URLs for your
        /// objects, for example, <code>https://d111111abcdef8.cloudfront.net/logo.png</code>.</para></li><li><para>If you can control which browser your users use, upgrade the browser to one that supports
        /// SNI.</para></li><li><para>Use HTTP instead of HTTPS.</para></li></ul></li></ul><para>Do not specify a value for <code>SSLSupportMethod</code> if you specified <code>&lt;CloudFrontDefaultCertificate&gt;true&lt;CloudFrontDefaultCertificate&gt;</code>.</para><para>For more information, see <a href="http://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/SecureConnections.html#CNAMEsAndHTTPS.html">Using
        /// Alternate Domain Names and HTTPS</a> in the <i>Amazon CloudFront Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_ViewerCertificate_SSLSupportMethod")]
        [AWSConstantClassSource("Amazon.CloudFront.SSLSupportMethod")]
        public Amazon.CloudFront.SSLSupportMethod ViewerCertificate_SSLSupportMethod { get; set; }
        #endregion
        
        #region Parameter DefaultCacheBehavior_TargetOriginId
        /// <summary>
        /// <para>
        /// <para>The value of <code>ID</code> for the origin that you want CloudFront to route requests
        /// to when a request matches the path pattern either for a cache behavior or for the
        /// default cache behavior.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_DefaultCacheBehavior_TargetOriginId")]
        public System.String DefaultCacheBehavior_TargetOriginId { get; set; }
        #endregion
        
        #region Parameter DefaultCacheBehavior_ViewerProtocolPolicy
        /// <summary>
        /// <para>
        /// <para>The protocol that viewers can use to access the files in the origin specified by <code>TargetOriginId</code>
        /// when a request matches the path pattern in <code>PathPattern</code>. You can specify
        /// the following options:</para><ul><li><para><code>allow-all</code>: Viewers can use HTTP or HTTPS.</para></li><li><para><code>redirect-to-https</code>: If a viewer submits an HTTP request, CloudFront returns
        /// an HTTP status code of 301 (Moved Permanently) to the viewer along with the HTTPS
        /// URL. The viewer then resubmits the request using the new URL.</para></li><li><para><code>https-only</code>: If a viewer sends an HTTP request, CloudFront returns an
        /// HTTP status code of 403 (Forbidden).</para></li></ul><para>For more information about requiring the HTTPS protocol, see <a href="http://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/SecureConnections.html">Using
        /// an HTTPS Connection to Access Your Objects</a> in the <i>Amazon CloudFront Developer
        /// Guide</i>.</para><note><para>The only way to guarantee that viewers retrieve an object that was fetched from the
        /// origin using HTTPS is never to use any other protocol to fetch the object. If you
        /// have recently changed from HTTP to HTTPS, we recommend that you clear your objects'
        /// cache because cached objects are protocol agnostic. That means that an edge location
        /// will return an object from the cache regardless of whether the current request protocol
        /// matches the protocol used previously. For more information, see <a href="http://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/Expiration.html">Specifying
        /// How Long Objects and Errors Stay in a CloudFront Edge Cache (Expiration)</a> in the
        /// <i>Amazon CloudFront Developer Guide</i>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_DefaultCacheBehavior_ViewerProtocolPolicy")]
        [AWSConstantClassSource("Amazon.CloudFront.ViewerProtocolPolicy")]
        public Amazon.CloudFront.ViewerProtocolPolicy DefaultCacheBehavior_ViewerProtocolPolicy { get; set; }
        #endregion
        
        #region Parameter DistributionConfig_WebACLId
        /// <summary>
        /// <para>
        /// <para>A unique identifier that specifies the AWS WAF web ACL, if any, to associate with
        /// this distribution.</para><para>AWS WAF is a web application firewall that lets you monitor the HTTP and HTTPS requests
        /// that are forwarded to CloudFront, and lets you control access to your content. Based
        /// on conditions that you specify, such as the IP addresses that requests originate from
        /// or the values of query strings, CloudFront responds to requests either with the requested
        /// content or with an HTTP 403 status code (Forbidden). You can also configure CloudFront
        /// to return a custom error page when a request is blocked. For more information about
        /// AWS WAF, see the <a href="http://docs.aws.amazon.com/waf/latest/developerguide/what-is-aws-waf.html">AWS
        /// WAF Developer Guide</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DistributionConfig_WebACLId { get; set; }
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CFDistribution (CreateDistribution)"))
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
            
            if (this.Aliases_Item != null)
            {
                context.DistributionConfig_Aliases_Items = new List<System.String>(this.Aliases_Item);
            }
            if (ParameterWasBound("Aliases_Quantity"))
                context.DistributionConfig_Aliases_Quantity = this.Aliases_Quantity;
            if (this.CacheBehaviors_Item != null)
            {
                context.DistributionConfig_CacheBehaviors_Items = new List<Amazon.CloudFront.Model.CacheBehavior>(this.CacheBehaviors_Item);
            }
            if (ParameterWasBound("CacheBehaviors_Quantity"))
                context.DistributionConfig_CacheBehaviors_Quantity = this.CacheBehaviors_Quantity;
            context.DistributionConfig_CallerReference = this.DistributionConfig_CallerReference;
            context.DistributionConfig_Comment = this.DistributionConfig_Comment;
            if (this.CustomErrorResponses_Item != null)
            {
                context.DistributionConfig_CustomErrorResponses_Items = new List<Amazon.CloudFront.Model.CustomErrorResponse>(this.CustomErrorResponses_Item);
            }
            if (ParameterWasBound("CustomErrorResponses_Quantity"))
                context.DistributionConfig_CustomErrorResponses_Quantity = this.CustomErrorResponses_Quantity;
            if (this.CachedMethods_Item != null)
            {
                context.DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_Items = new List<System.String>(this.CachedMethods_Item);
            }
            if (ParameterWasBound("CachedMethods_Quantity"))
                context.DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_Quantity = this.CachedMethods_Quantity;
            if (this.AllowedMethods_Item != null)
            {
                context.DistributionConfig_DefaultCacheBehavior_AllowedMethods_Items = new List<System.String>(this.AllowedMethods_Item);
            }
            if (ParameterWasBound("AllowedMethods_Quantity"))
                context.DistributionConfig_DefaultCacheBehavior_AllowedMethods_Quantity = this.AllowedMethods_Quantity;
            if (ParameterWasBound("DefaultCacheBehavior_Compress"))
                context.DistributionConfig_DefaultCacheBehavior_Compress = this.DefaultCacheBehavior_Compress;
            if (ParameterWasBound("DefaultCacheBehavior_DefaultTTL"))
                context.DistributionConfig_DefaultCacheBehavior_DefaultTTL = this.DefaultCacheBehavior_DefaultTTL;
            context.DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_Forward = this.Cookies_Forward;
            if (this.WhitelistedNames_Item != null)
            {
                context.DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_Items = new List<System.String>(this.WhitelistedNames_Item);
            }
            if (ParameterWasBound("WhitelistedNames_Quantity"))
                context.DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_Quantity = this.WhitelistedNames_Quantity;
            if (this.Headers_Item != null)
            {
                context.DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_Items = new List<System.String>(this.Headers_Item);
            }
            if (ParameterWasBound("Headers_Quantity"))
                context.DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_Quantity = this.Headers_Quantity;
            if (ParameterWasBound("ForwardedValues_QueryString"))
                context.DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryString = this.ForwardedValues_QueryString;
            if (this.QueryStringCacheKeys_Item != null)
            {
                context.DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_Items = new List<System.String>(this.QueryStringCacheKeys_Item);
            }
            if (ParameterWasBound("QueryStringCacheKeys_Quantity"))
                context.DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_Quantity = this.QueryStringCacheKeys_Quantity;
            if (this.LambdaFunctionAssociations_Item != null)
            {
                context.DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_Items = new List<Amazon.CloudFront.Model.LambdaFunctionAssociation>(this.LambdaFunctionAssociations_Item);
            }
            if (ParameterWasBound("LambdaFunctionAssociations_Quantity"))
                context.DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_Quantity = this.LambdaFunctionAssociations_Quantity;
            if (ParameterWasBound("DefaultCacheBehavior_MaxTTL"))
                context.DistributionConfig_DefaultCacheBehavior_MaxTTL = this.DefaultCacheBehavior_MaxTTL;
            if (ParameterWasBound("DefaultCacheBehavior_MinTTL"))
                context.DistributionConfig_DefaultCacheBehavior_MinTTL = this.DefaultCacheBehavior_MinTTL;
            if (ParameterWasBound("DefaultCacheBehavior_SmoothStreaming"))
                context.DistributionConfig_DefaultCacheBehavior_SmoothStreaming = this.DefaultCacheBehavior_SmoothStreaming;
            context.DistributionConfig_DefaultCacheBehavior_TargetOriginId = this.DefaultCacheBehavior_TargetOriginId;
            if (ParameterWasBound("TrustedSigners_Enabled"))
                context.DistributionConfig_DefaultCacheBehavior_TrustedSigners_Enabled = this.TrustedSigners_Enabled;
            if (this.TrustedSigners_Item != null)
            {
                context.DistributionConfig_DefaultCacheBehavior_TrustedSigners_Items = new List<System.String>(this.TrustedSigners_Item);
            }
            if (ParameterWasBound("TrustedSigners_Quantity"))
                context.DistributionConfig_DefaultCacheBehavior_TrustedSigners_Quantity = this.TrustedSigners_Quantity;
            context.DistributionConfig_DefaultCacheBehavior_ViewerProtocolPolicy = this.DefaultCacheBehavior_ViewerProtocolPolicy;
            context.DistributionConfig_DefaultRootObject = this.DistributionConfig_DefaultRootObject;
            if (ParameterWasBound("DistributionConfig_Enabled"))
                context.DistributionConfig_Enabled = this.DistributionConfig_Enabled;
            context.DistributionConfig_HttpVersion = this.DistributionConfig_HttpVersion;
            if (ParameterWasBound("DistributionConfig_IsIPV6Enabled"))
                context.DistributionConfig_IsIPV6Enabled = this.DistributionConfig_IsIPV6Enabled;
            context.DistributionConfig_Logging_Bucket = this.Logging_Bucket;
            if (ParameterWasBound("Logging_Enabled"))
                context.DistributionConfig_Logging_Enabled = this.Logging_Enabled;
            if (ParameterWasBound("Logging_IncludeCookie"))
                context.DistributionConfig_Logging_IncludeCookies = this.Logging_IncludeCookie;
            context.DistributionConfig_Logging_Prefix = this.Logging_Prefix;
            if (this.Origins_Item != null)
            {
                context.DistributionConfig_Origins_Items = new List<Amazon.CloudFront.Model.Origin>(this.Origins_Item);
            }
            if (ParameterWasBound("Origins_Quantity"))
                context.DistributionConfig_Origins_Quantity = this.Origins_Quantity;
            context.DistributionConfig_PriceClass = this.DistributionConfig_PriceClass;
            if (this.GeoRestriction_Item != null)
            {
                context.DistributionConfig_Restrictions_GeoRestriction_Items = new List<System.String>(this.GeoRestriction_Item);
            }
            if (ParameterWasBound("GeoRestriction_Quantity"))
                context.DistributionConfig_Restrictions_GeoRestriction_Quantity = this.GeoRestriction_Quantity;
            context.DistributionConfig_Restrictions_GeoRestriction_RestrictionType = this.GeoRestriction_RestrictionType;
            context.DistributionConfig_ViewerCertificate_ACMCertificateArn = this.ViewerCertificate_ACMCertificateArn;
            context.DistributionConfig_ViewerCertificate_Certificate = this.ViewerCertificate_Certificate;
            context.DistributionConfig_ViewerCertificate_CertificateSource = this.ViewerCertificate_CertificateSource;
            if (ParameterWasBound("ViewerCertificate_CloudFrontDefaultCertificate"))
                context.DistributionConfig_ViewerCertificate_CloudFrontDefaultCertificate = this.ViewerCertificate_CloudFrontDefaultCertificate;
            context.DistributionConfig_ViewerCertificate_IAMCertificateId = this.ViewerCertificate_IAMCertificateId;
            context.DistributionConfig_ViewerCertificate_MinimumProtocolVersion = this.ViewerCertificate_MinimumProtocolVersion;
            context.DistributionConfig_ViewerCertificate_SSLSupportMethod = this.ViewerCertificate_SSLSupportMethod;
            context.DistributionConfig_WebACLId = this.DistributionConfig_WebACLId;
            
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
            var request = new Amazon.CloudFront.Model.CreateDistributionRequest();
            
            
             // populate DistributionConfig
            bool requestDistributionConfigIsNull = true;
            request.DistributionConfig = new Amazon.CloudFront.Model.DistributionConfig();
            System.String requestDistributionConfig_distributionConfig_CallerReference = null;
            if (cmdletContext.DistributionConfig_CallerReference != null)
            {
                requestDistributionConfig_distributionConfig_CallerReference = cmdletContext.DistributionConfig_CallerReference;
            }
            if (requestDistributionConfig_distributionConfig_CallerReference != null)
            {
                request.DistributionConfig.CallerReference = requestDistributionConfig_distributionConfig_CallerReference;
                requestDistributionConfigIsNull = false;
            }
            System.String requestDistributionConfig_distributionConfig_Comment = null;
            if (cmdletContext.DistributionConfig_Comment != null)
            {
                requestDistributionConfig_distributionConfig_Comment = cmdletContext.DistributionConfig_Comment;
            }
            if (requestDistributionConfig_distributionConfig_Comment != null)
            {
                request.DistributionConfig.Comment = requestDistributionConfig_distributionConfig_Comment;
                requestDistributionConfigIsNull = false;
            }
            System.String requestDistributionConfig_distributionConfig_DefaultRootObject = null;
            if (cmdletContext.DistributionConfig_DefaultRootObject != null)
            {
                requestDistributionConfig_distributionConfig_DefaultRootObject = cmdletContext.DistributionConfig_DefaultRootObject;
            }
            if (requestDistributionConfig_distributionConfig_DefaultRootObject != null)
            {
                request.DistributionConfig.DefaultRootObject = requestDistributionConfig_distributionConfig_DefaultRootObject;
                requestDistributionConfigIsNull = false;
            }
            System.Boolean? requestDistributionConfig_distributionConfig_Enabled = null;
            if (cmdletContext.DistributionConfig_Enabled != null)
            {
                requestDistributionConfig_distributionConfig_Enabled = cmdletContext.DistributionConfig_Enabled.Value;
            }
            if (requestDistributionConfig_distributionConfig_Enabled != null)
            {
                request.DistributionConfig.Enabled = requestDistributionConfig_distributionConfig_Enabled.Value;
                requestDistributionConfigIsNull = false;
            }
            Amazon.CloudFront.HttpVersion requestDistributionConfig_distributionConfig_HttpVersion = null;
            if (cmdletContext.DistributionConfig_HttpVersion != null)
            {
                requestDistributionConfig_distributionConfig_HttpVersion = cmdletContext.DistributionConfig_HttpVersion;
            }
            if (requestDistributionConfig_distributionConfig_HttpVersion != null)
            {
                request.DistributionConfig.HttpVersion = requestDistributionConfig_distributionConfig_HttpVersion;
                requestDistributionConfigIsNull = false;
            }
            System.Boolean? requestDistributionConfig_distributionConfig_IsIPV6Enabled = null;
            if (cmdletContext.DistributionConfig_IsIPV6Enabled != null)
            {
                requestDistributionConfig_distributionConfig_IsIPV6Enabled = cmdletContext.DistributionConfig_IsIPV6Enabled.Value;
            }
            if (requestDistributionConfig_distributionConfig_IsIPV6Enabled != null)
            {
                request.DistributionConfig.IsIPV6Enabled = requestDistributionConfig_distributionConfig_IsIPV6Enabled.Value;
                requestDistributionConfigIsNull = false;
            }
            Amazon.CloudFront.PriceClass requestDistributionConfig_distributionConfig_PriceClass = null;
            if (cmdletContext.DistributionConfig_PriceClass != null)
            {
                requestDistributionConfig_distributionConfig_PriceClass = cmdletContext.DistributionConfig_PriceClass;
            }
            if (requestDistributionConfig_distributionConfig_PriceClass != null)
            {
                request.DistributionConfig.PriceClass = requestDistributionConfig_distributionConfig_PriceClass;
                requestDistributionConfigIsNull = false;
            }
            System.String requestDistributionConfig_distributionConfig_WebACLId = null;
            if (cmdletContext.DistributionConfig_WebACLId != null)
            {
                requestDistributionConfig_distributionConfig_WebACLId = cmdletContext.DistributionConfig_WebACLId;
            }
            if (requestDistributionConfig_distributionConfig_WebACLId != null)
            {
                request.DistributionConfig.WebACLId = requestDistributionConfig_distributionConfig_WebACLId;
                requestDistributionConfigIsNull = false;
            }
            Amazon.CloudFront.Model.Restrictions requestDistributionConfig_distributionConfig_Restrictions = null;
            
             // populate Restrictions
            bool requestDistributionConfig_distributionConfig_RestrictionsIsNull = true;
            requestDistributionConfig_distributionConfig_Restrictions = new Amazon.CloudFront.Model.Restrictions();
            Amazon.CloudFront.Model.GeoRestriction requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction = null;
            
             // populate GeoRestriction
            bool requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestrictionIsNull = true;
            requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction = new Amazon.CloudFront.Model.GeoRestriction();
            List<System.String> requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction_geoRestriction_Item = null;
            if (cmdletContext.DistributionConfig_Restrictions_GeoRestriction_Items != null)
            {
                requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction_geoRestriction_Item = cmdletContext.DistributionConfig_Restrictions_GeoRestriction_Items;
            }
            if (requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction_geoRestriction_Item != null)
            {
                requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction.Items = requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction_geoRestriction_Item;
                requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestrictionIsNull = false;
            }
            System.Int32? requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction_geoRestriction_Quantity = null;
            if (cmdletContext.DistributionConfig_Restrictions_GeoRestriction_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction_geoRestriction_Quantity = cmdletContext.DistributionConfig_Restrictions_GeoRestriction_Quantity.Value;
            }
            if (requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction_geoRestriction_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction.Quantity = requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction_geoRestriction_Quantity.Value;
                requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestrictionIsNull = false;
            }
            Amazon.CloudFront.GeoRestrictionType requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction_geoRestriction_RestrictionType = null;
            if (cmdletContext.DistributionConfig_Restrictions_GeoRestriction_RestrictionType != null)
            {
                requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction_geoRestriction_RestrictionType = cmdletContext.DistributionConfig_Restrictions_GeoRestriction_RestrictionType;
            }
            if (requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction_geoRestriction_RestrictionType != null)
            {
                requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction.RestrictionType = requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction_geoRestriction_RestrictionType;
                requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestrictionIsNull = false;
            }
             // determine if requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction should be set to null
            if (requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestrictionIsNull)
            {
                requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction = null;
            }
            if (requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction != null)
            {
                requestDistributionConfig_distributionConfig_Restrictions.GeoRestriction = requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction;
                requestDistributionConfig_distributionConfig_RestrictionsIsNull = false;
            }
             // determine if requestDistributionConfig_distributionConfig_Restrictions should be set to null
            if (requestDistributionConfig_distributionConfig_RestrictionsIsNull)
            {
                requestDistributionConfig_distributionConfig_Restrictions = null;
            }
            if (requestDistributionConfig_distributionConfig_Restrictions != null)
            {
                request.DistributionConfig.Restrictions = requestDistributionConfig_distributionConfig_Restrictions;
                requestDistributionConfigIsNull = false;
            }
            Amazon.CloudFront.Model.Aliases requestDistributionConfig_distributionConfig_Aliases = null;
            
             // populate Aliases
            bool requestDistributionConfig_distributionConfig_AliasesIsNull = true;
            requestDistributionConfig_distributionConfig_Aliases = new Amazon.CloudFront.Model.Aliases();
            List<System.String> requestDistributionConfig_distributionConfig_Aliases_aliases_Item = null;
            if (cmdletContext.DistributionConfig_Aliases_Items != null)
            {
                requestDistributionConfig_distributionConfig_Aliases_aliases_Item = cmdletContext.DistributionConfig_Aliases_Items;
            }
            if (requestDistributionConfig_distributionConfig_Aliases_aliases_Item != null)
            {
                requestDistributionConfig_distributionConfig_Aliases.Items = requestDistributionConfig_distributionConfig_Aliases_aliases_Item;
                requestDistributionConfig_distributionConfig_AliasesIsNull = false;
            }
            System.Int32? requestDistributionConfig_distributionConfig_Aliases_aliases_Quantity = null;
            if (cmdletContext.DistributionConfig_Aliases_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_Aliases_aliases_Quantity = cmdletContext.DistributionConfig_Aliases_Quantity.Value;
            }
            if (requestDistributionConfig_distributionConfig_Aliases_aliases_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_Aliases.Quantity = requestDistributionConfig_distributionConfig_Aliases_aliases_Quantity.Value;
                requestDistributionConfig_distributionConfig_AliasesIsNull = false;
            }
             // determine if requestDistributionConfig_distributionConfig_Aliases should be set to null
            if (requestDistributionConfig_distributionConfig_AliasesIsNull)
            {
                requestDistributionConfig_distributionConfig_Aliases = null;
            }
            if (requestDistributionConfig_distributionConfig_Aliases != null)
            {
                request.DistributionConfig.Aliases = requestDistributionConfig_distributionConfig_Aliases;
                requestDistributionConfigIsNull = false;
            }
            Amazon.CloudFront.Model.CacheBehaviors requestDistributionConfig_distributionConfig_CacheBehaviors = null;
            
             // populate CacheBehaviors
            bool requestDistributionConfig_distributionConfig_CacheBehaviorsIsNull = true;
            requestDistributionConfig_distributionConfig_CacheBehaviors = new Amazon.CloudFront.Model.CacheBehaviors();
            List<Amazon.CloudFront.Model.CacheBehavior> requestDistributionConfig_distributionConfig_CacheBehaviors_cacheBehaviors_Item = null;
            if (cmdletContext.DistributionConfig_CacheBehaviors_Items != null)
            {
                requestDistributionConfig_distributionConfig_CacheBehaviors_cacheBehaviors_Item = cmdletContext.DistributionConfig_CacheBehaviors_Items;
            }
            if (requestDistributionConfig_distributionConfig_CacheBehaviors_cacheBehaviors_Item != null)
            {
                requestDistributionConfig_distributionConfig_CacheBehaviors.Items = requestDistributionConfig_distributionConfig_CacheBehaviors_cacheBehaviors_Item;
                requestDistributionConfig_distributionConfig_CacheBehaviorsIsNull = false;
            }
            System.Int32? requestDistributionConfig_distributionConfig_CacheBehaviors_cacheBehaviors_Quantity = null;
            if (cmdletContext.DistributionConfig_CacheBehaviors_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_CacheBehaviors_cacheBehaviors_Quantity = cmdletContext.DistributionConfig_CacheBehaviors_Quantity.Value;
            }
            if (requestDistributionConfig_distributionConfig_CacheBehaviors_cacheBehaviors_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_CacheBehaviors.Quantity = requestDistributionConfig_distributionConfig_CacheBehaviors_cacheBehaviors_Quantity.Value;
                requestDistributionConfig_distributionConfig_CacheBehaviorsIsNull = false;
            }
             // determine if requestDistributionConfig_distributionConfig_CacheBehaviors should be set to null
            if (requestDistributionConfig_distributionConfig_CacheBehaviorsIsNull)
            {
                requestDistributionConfig_distributionConfig_CacheBehaviors = null;
            }
            if (requestDistributionConfig_distributionConfig_CacheBehaviors != null)
            {
                request.DistributionConfig.CacheBehaviors = requestDistributionConfig_distributionConfig_CacheBehaviors;
                requestDistributionConfigIsNull = false;
            }
            Amazon.CloudFront.Model.CustomErrorResponses requestDistributionConfig_distributionConfig_CustomErrorResponses = null;
            
             // populate CustomErrorResponses
            bool requestDistributionConfig_distributionConfig_CustomErrorResponsesIsNull = true;
            requestDistributionConfig_distributionConfig_CustomErrorResponses = new Amazon.CloudFront.Model.CustomErrorResponses();
            List<Amazon.CloudFront.Model.CustomErrorResponse> requestDistributionConfig_distributionConfig_CustomErrorResponses_customErrorResponses_Item = null;
            if (cmdletContext.DistributionConfig_CustomErrorResponses_Items != null)
            {
                requestDistributionConfig_distributionConfig_CustomErrorResponses_customErrorResponses_Item = cmdletContext.DistributionConfig_CustomErrorResponses_Items;
            }
            if (requestDistributionConfig_distributionConfig_CustomErrorResponses_customErrorResponses_Item != null)
            {
                requestDistributionConfig_distributionConfig_CustomErrorResponses.Items = requestDistributionConfig_distributionConfig_CustomErrorResponses_customErrorResponses_Item;
                requestDistributionConfig_distributionConfig_CustomErrorResponsesIsNull = false;
            }
            System.Int32? requestDistributionConfig_distributionConfig_CustomErrorResponses_customErrorResponses_Quantity = null;
            if (cmdletContext.DistributionConfig_CustomErrorResponses_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_CustomErrorResponses_customErrorResponses_Quantity = cmdletContext.DistributionConfig_CustomErrorResponses_Quantity.Value;
            }
            if (requestDistributionConfig_distributionConfig_CustomErrorResponses_customErrorResponses_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_CustomErrorResponses.Quantity = requestDistributionConfig_distributionConfig_CustomErrorResponses_customErrorResponses_Quantity.Value;
                requestDistributionConfig_distributionConfig_CustomErrorResponsesIsNull = false;
            }
             // determine if requestDistributionConfig_distributionConfig_CustomErrorResponses should be set to null
            if (requestDistributionConfig_distributionConfig_CustomErrorResponsesIsNull)
            {
                requestDistributionConfig_distributionConfig_CustomErrorResponses = null;
            }
            if (requestDistributionConfig_distributionConfig_CustomErrorResponses != null)
            {
                request.DistributionConfig.CustomErrorResponses = requestDistributionConfig_distributionConfig_CustomErrorResponses;
                requestDistributionConfigIsNull = false;
            }
            Amazon.CloudFront.Model.Origins requestDistributionConfig_distributionConfig_Origins = null;
            
             // populate Origins
            bool requestDistributionConfig_distributionConfig_OriginsIsNull = true;
            requestDistributionConfig_distributionConfig_Origins = new Amazon.CloudFront.Model.Origins();
            List<Amazon.CloudFront.Model.Origin> requestDistributionConfig_distributionConfig_Origins_origins_Item = null;
            if (cmdletContext.DistributionConfig_Origins_Items != null)
            {
                requestDistributionConfig_distributionConfig_Origins_origins_Item = cmdletContext.DistributionConfig_Origins_Items;
            }
            if (requestDistributionConfig_distributionConfig_Origins_origins_Item != null)
            {
                requestDistributionConfig_distributionConfig_Origins.Items = requestDistributionConfig_distributionConfig_Origins_origins_Item;
                requestDistributionConfig_distributionConfig_OriginsIsNull = false;
            }
            System.Int32? requestDistributionConfig_distributionConfig_Origins_origins_Quantity = null;
            if (cmdletContext.DistributionConfig_Origins_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_Origins_origins_Quantity = cmdletContext.DistributionConfig_Origins_Quantity.Value;
            }
            if (requestDistributionConfig_distributionConfig_Origins_origins_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_Origins.Quantity = requestDistributionConfig_distributionConfig_Origins_origins_Quantity.Value;
                requestDistributionConfig_distributionConfig_OriginsIsNull = false;
            }
             // determine if requestDistributionConfig_distributionConfig_Origins should be set to null
            if (requestDistributionConfig_distributionConfig_OriginsIsNull)
            {
                requestDistributionConfig_distributionConfig_Origins = null;
            }
            if (requestDistributionConfig_distributionConfig_Origins != null)
            {
                request.DistributionConfig.Origins = requestDistributionConfig_distributionConfig_Origins;
                requestDistributionConfigIsNull = false;
            }
            Amazon.CloudFront.Model.LoggingConfig requestDistributionConfig_distributionConfig_Logging = null;
            
             // populate Logging
            bool requestDistributionConfig_distributionConfig_LoggingIsNull = true;
            requestDistributionConfig_distributionConfig_Logging = new Amazon.CloudFront.Model.LoggingConfig();
            System.String requestDistributionConfig_distributionConfig_Logging_logging_Bucket = null;
            if (cmdletContext.DistributionConfig_Logging_Bucket != null)
            {
                requestDistributionConfig_distributionConfig_Logging_logging_Bucket = cmdletContext.DistributionConfig_Logging_Bucket;
            }
            if (requestDistributionConfig_distributionConfig_Logging_logging_Bucket != null)
            {
                requestDistributionConfig_distributionConfig_Logging.Bucket = requestDistributionConfig_distributionConfig_Logging_logging_Bucket;
                requestDistributionConfig_distributionConfig_LoggingIsNull = false;
            }
            System.Boolean? requestDistributionConfig_distributionConfig_Logging_logging_Enabled = null;
            if (cmdletContext.DistributionConfig_Logging_Enabled != null)
            {
                requestDistributionConfig_distributionConfig_Logging_logging_Enabled = cmdletContext.DistributionConfig_Logging_Enabled.Value;
            }
            if (requestDistributionConfig_distributionConfig_Logging_logging_Enabled != null)
            {
                requestDistributionConfig_distributionConfig_Logging.Enabled = requestDistributionConfig_distributionConfig_Logging_logging_Enabled.Value;
                requestDistributionConfig_distributionConfig_LoggingIsNull = false;
            }
            System.Boolean? requestDistributionConfig_distributionConfig_Logging_logging_IncludeCookie = null;
            if (cmdletContext.DistributionConfig_Logging_IncludeCookies != null)
            {
                requestDistributionConfig_distributionConfig_Logging_logging_IncludeCookie = cmdletContext.DistributionConfig_Logging_IncludeCookies.Value;
            }
            if (requestDistributionConfig_distributionConfig_Logging_logging_IncludeCookie != null)
            {
                requestDistributionConfig_distributionConfig_Logging.IncludeCookies = requestDistributionConfig_distributionConfig_Logging_logging_IncludeCookie.Value;
                requestDistributionConfig_distributionConfig_LoggingIsNull = false;
            }
            System.String requestDistributionConfig_distributionConfig_Logging_logging_Prefix = null;
            if (cmdletContext.DistributionConfig_Logging_Prefix != null)
            {
                requestDistributionConfig_distributionConfig_Logging_logging_Prefix = cmdletContext.DistributionConfig_Logging_Prefix;
            }
            if (requestDistributionConfig_distributionConfig_Logging_logging_Prefix != null)
            {
                requestDistributionConfig_distributionConfig_Logging.Prefix = requestDistributionConfig_distributionConfig_Logging_logging_Prefix;
                requestDistributionConfig_distributionConfig_LoggingIsNull = false;
            }
             // determine if requestDistributionConfig_distributionConfig_Logging should be set to null
            if (requestDistributionConfig_distributionConfig_LoggingIsNull)
            {
                requestDistributionConfig_distributionConfig_Logging = null;
            }
            if (requestDistributionConfig_distributionConfig_Logging != null)
            {
                request.DistributionConfig.Logging = requestDistributionConfig_distributionConfig_Logging;
                requestDistributionConfigIsNull = false;
            }
            Amazon.CloudFront.Model.ViewerCertificate requestDistributionConfig_distributionConfig_ViewerCertificate = null;
            
             // populate ViewerCertificate
            bool requestDistributionConfig_distributionConfig_ViewerCertificateIsNull = true;
            requestDistributionConfig_distributionConfig_ViewerCertificate = new Amazon.CloudFront.Model.ViewerCertificate();
            System.String requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_ACMCertificateArn = null;
            if (cmdletContext.DistributionConfig_ViewerCertificate_ACMCertificateArn != null)
            {
                requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_ACMCertificateArn = cmdletContext.DistributionConfig_ViewerCertificate_ACMCertificateArn;
            }
            if (requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_ACMCertificateArn != null)
            {
                requestDistributionConfig_distributionConfig_ViewerCertificate.ACMCertificateArn = requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_ACMCertificateArn;
                requestDistributionConfig_distributionConfig_ViewerCertificateIsNull = false;
            }
            System.String requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_Certificate = null;
            if (cmdletContext.DistributionConfig_ViewerCertificate_Certificate != null)
            {
                requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_Certificate = cmdletContext.DistributionConfig_ViewerCertificate_Certificate;
            }
            if (requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_Certificate != null)
            {
                requestDistributionConfig_distributionConfig_ViewerCertificate.Certificate = requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_Certificate;
                requestDistributionConfig_distributionConfig_ViewerCertificateIsNull = false;
            }
            Amazon.CloudFront.CertificateSource requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_CertificateSource = null;
            if (cmdletContext.DistributionConfig_ViewerCertificate_CertificateSource != null)
            {
                requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_CertificateSource = cmdletContext.DistributionConfig_ViewerCertificate_CertificateSource;
            }
            if (requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_CertificateSource != null)
            {
                requestDistributionConfig_distributionConfig_ViewerCertificate.CertificateSource = requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_CertificateSource;
                requestDistributionConfig_distributionConfig_ViewerCertificateIsNull = false;
            }
            System.Boolean? requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_CloudFrontDefaultCertificate = null;
            if (cmdletContext.DistributionConfig_ViewerCertificate_CloudFrontDefaultCertificate != null)
            {
                requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_CloudFrontDefaultCertificate = cmdletContext.DistributionConfig_ViewerCertificate_CloudFrontDefaultCertificate.Value;
            }
            if (requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_CloudFrontDefaultCertificate != null)
            {
                requestDistributionConfig_distributionConfig_ViewerCertificate.CloudFrontDefaultCertificate = requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_CloudFrontDefaultCertificate.Value;
                requestDistributionConfig_distributionConfig_ViewerCertificateIsNull = false;
            }
            System.String requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_IAMCertificateId = null;
            if (cmdletContext.DistributionConfig_ViewerCertificate_IAMCertificateId != null)
            {
                requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_IAMCertificateId = cmdletContext.DistributionConfig_ViewerCertificate_IAMCertificateId;
            }
            if (requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_IAMCertificateId != null)
            {
                requestDistributionConfig_distributionConfig_ViewerCertificate.IAMCertificateId = requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_IAMCertificateId;
                requestDistributionConfig_distributionConfig_ViewerCertificateIsNull = false;
            }
            Amazon.CloudFront.MinimumProtocolVersion requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_MinimumProtocolVersion = null;
            if (cmdletContext.DistributionConfig_ViewerCertificate_MinimumProtocolVersion != null)
            {
                requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_MinimumProtocolVersion = cmdletContext.DistributionConfig_ViewerCertificate_MinimumProtocolVersion;
            }
            if (requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_MinimumProtocolVersion != null)
            {
                requestDistributionConfig_distributionConfig_ViewerCertificate.MinimumProtocolVersion = requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_MinimumProtocolVersion;
                requestDistributionConfig_distributionConfig_ViewerCertificateIsNull = false;
            }
            Amazon.CloudFront.SSLSupportMethod requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_SSLSupportMethod = null;
            if (cmdletContext.DistributionConfig_ViewerCertificate_SSLSupportMethod != null)
            {
                requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_SSLSupportMethod = cmdletContext.DistributionConfig_ViewerCertificate_SSLSupportMethod;
            }
            if (requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_SSLSupportMethod != null)
            {
                requestDistributionConfig_distributionConfig_ViewerCertificate.SSLSupportMethod = requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_SSLSupportMethod;
                requestDistributionConfig_distributionConfig_ViewerCertificateIsNull = false;
            }
             // determine if requestDistributionConfig_distributionConfig_ViewerCertificate should be set to null
            if (requestDistributionConfig_distributionConfig_ViewerCertificateIsNull)
            {
                requestDistributionConfig_distributionConfig_ViewerCertificate = null;
            }
            if (requestDistributionConfig_distributionConfig_ViewerCertificate != null)
            {
                request.DistributionConfig.ViewerCertificate = requestDistributionConfig_distributionConfig_ViewerCertificate;
                requestDistributionConfigIsNull = false;
            }
            Amazon.CloudFront.Model.DefaultCacheBehavior requestDistributionConfig_distributionConfig_DefaultCacheBehavior = null;
            
             // populate DefaultCacheBehavior
            bool requestDistributionConfig_distributionConfig_DefaultCacheBehaviorIsNull = true;
            requestDistributionConfig_distributionConfig_DefaultCacheBehavior = new Amazon.CloudFront.Model.DefaultCacheBehavior();
            System.Boolean? requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_Compress = null;
            if (cmdletContext.DistributionConfig_DefaultCacheBehavior_Compress != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_Compress = cmdletContext.DistributionConfig_DefaultCacheBehavior_Compress.Value;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_Compress != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior.Compress = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_Compress.Value;
                requestDistributionConfig_distributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            System.Int64? requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_DefaultTTL = null;
            if (cmdletContext.DistributionConfig_DefaultCacheBehavior_DefaultTTL != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_DefaultTTL = cmdletContext.DistributionConfig_DefaultCacheBehavior_DefaultTTL.Value;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_DefaultTTL != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior.DefaultTTL = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_DefaultTTL.Value;
                requestDistributionConfig_distributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            System.Int64? requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_MaxTTL = null;
            if (cmdletContext.DistributionConfig_DefaultCacheBehavior_MaxTTL != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_MaxTTL = cmdletContext.DistributionConfig_DefaultCacheBehavior_MaxTTL.Value;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_MaxTTL != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior.MaxTTL = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_MaxTTL.Value;
                requestDistributionConfig_distributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            System.Int64? requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_MinTTL = null;
            if (cmdletContext.DistributionConfig_DefaultCacheBehavior_MinTTL != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_MinTTL = cmdletContext.DistributionConfig_DefaultCacheBehavior_MinTTL.Value;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_MinTTL != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior.MinTTL = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_MinTTL.Value;
                requestDistributionConfig_distributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            System.Boolean? requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_SmoothStreaming = null;
            if (cmdletContext.DistributionConfig_DefaultCacheBehavior_SmoothStreaming != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_SmoothStreaming = cmdletContext.DistributionConfig_DefaultCacheBehavior_SmoothStreaming.Value;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_SmoothStreaming != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior.SmoothStreaming = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_SmoothStreaming.Value;
                requestDistributionConfig_distributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            System.String requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_TargetOriginId = null;
            if (cmdletContext.DistributionConfig_DefaultCacheBehavior_TargetOriginId != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_TargetOriginId = cmdletContext.DistributionConfig_DefaultCacheBehavior_TargetOriginId;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_TargetOriginId != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior.TargetOriginId = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_TargetOriginId;
                requestDistributionConfig_distributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            Amazon.CloudFront.ViewerProtocolPolicy requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_ViewerProtocolPolicy = null;
            if (cmdletContext.DistributionConfig_DefaultCacheBehavior_ViewerProtocolPolicy != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_ViewerProtocolPolicy = cmdletContext.DistributionConfig_DefaultCacheBehavior_ViewerProtocolPolicy;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_ViewerProtocolPolicy != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior.ViewerProtocolPolicy = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_ViewerProtocolPolicy;
                requestDistributionConfig_distributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            Amazon.CloudFront.Model.LambdaFunctionAssociations requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations = null;
            
             // populate LambdaFunctionAssociations
            bool requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_LambdaFunctionAssociationsIsNull = true;
            requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations = new Amazon.CloudFront.Model.LambdaFunctionAssociations();
            List<Amazon.CloudFront.Model.LambdaFunctionAssociation> requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_lambdaFunctionAssociations_Item = null;
            if (cmdletContext.DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_Items != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_lambdaFunctionAssociations_Item = cmdletContext.DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_Items;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_lambdaFunctionAssociations_Item != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations.Items = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_lambdaFunctionAssociations_Item;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_LambdaFunctionAssociationsIsNull = false;
            }
            System.Int32? requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_lambdaFunctionAssociations_Quantity = null;
            if (cmdletContext.DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_lambdaFunctionAssociations_Quantity = cmdletContext.DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_Quantity.Value;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_lambdaFunctionAssociations_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations.Quantity = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_lambdaFunctionAssociations_Quantity.Value;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_LambdaFunctionAssociationsIsNull = false;
            }
             // determine if requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations should be set to null
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_LambdaFunctionAssociationsIsNull)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations = null;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior.LambdaFunctionAssociations = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations;
                requestDistributionConfig_distributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            Amazon.CloudFront.Model.AllowedMethods requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods = null;
            
             // populate AllowedMethods
            bool requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethodsIsNull = true;
            requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods = new Amazon.CloudFront.Model.AllowedMethods();
            List<System.String> requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_allowedMethods_Item = null;
            if (cmdletContext.DistributionConfig_DefaultCacheBehavior_AllowedMethods_Items != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_allowedMethods_Item = cmdletContext.DistributionConfig_DefaultCacheBehavior_AllowedMethods_Items;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_allowedMethods_Item != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods.Items = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_allowedMethods_Item;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethodsIsNull = false;
            }
            System.Int32? requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_allowedMethods_Quantity = null;
            if (cmdletContext.DistributionConfig_DefaultCacheBehavior_AllowedMethods_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_allowedMethods_Quantity = cmdletContext.DistributionConfig_DefaultCacheBehavior_AllowedMethods_Quantity.Value;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_allowedMethods_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods.Quantity = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_allowedMethods_Quantity.Value;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethodsIsNull = false;
            }
            Amazon.CloudFront.Model.CachedMethods requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods = null;
            
             // populate CachedMethods
            bool requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethodsIsNull = true;
            requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods = new Amazon.CloudFront.Model.CachedMethods();
            List<System.String> requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_cachedMethods_Item = null;
            if (cmdletContext.DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_Items != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_cachedMethods_Item = cmdletContext.DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_Items;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_cachedMethods_Item != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods.Items = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_cachedMethods_Item;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethodsIsNull = false;
            }
            System.Int32? requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_cachedMethods_Quantity = null;
            if (cmdletContext.DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_cachedMethods_Quantity = cmdletContext.DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_Quantity.Value;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_cachedMethods_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods.Quantity = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_cachedMethods_Quantity.Value;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethodsIsNull = false;
            }
             // determine if requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods should be set to null
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethodsIsNull)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods = null;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods.CachedMethods = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethodsIsNull = false;
            }
             // determine if requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods should be set to null
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethodsIsNull)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods = null;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior.AllowedMethods = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods;
                requestDistributionConfig_distributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            Amazon.CloudFront.Model.TrustedSigners requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners = null;
            
             // populate TrustedSigners
            bool requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSignersIsNull = true;
            requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners = new Amazon.CloudFront.Model.TrustedSigners();
            System.Boolean? requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Enabled = null;
            if (cmdletContext.DistributionConfig_DefaultCacheBehavior_TrustedSigners_Enabled != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Enabled = cmdletContext.DistributionConfig_DefaultCacheBehavior_TrustedSigners_Enabled.Value;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Enabled != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners.Enabled = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Enabled.Value;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSignersIsNull = false;
            }
            List<System.String> requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Item = null;
            if (cmdletContext.DistributionConfig_DefaultCacheBehavior_TrustedSigners_Items != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Item = cmdletContext.DistributionConfig_DefaultCacheBehavior_TrustedSigners_Items;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Item != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners.Items = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Item;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSignersIsNull = false;
            }
            System.Int32? requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Quantity = null;
            if (cmdletContext.DistributionConfig_DefaultCacheBehavior_TrustedSigners_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Quantity = cmdletContext.DistributionConfig_DefaultCacheBehavior_TrustedSigners_Quantity.Value;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners.Quantity = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Quantity.Value;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSignersIsNull = false;
            }
             // determine if requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners should be set to null
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSignersIsNull)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners = null;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior.TrustedSigners = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners;
                requestDistributionConfig_distributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            Amazon.CloudFront.Model.ForwardedValues requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues = null;
            
             // populate ForwardedValues
            bool requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValuesIsNull = true;
            requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues = new Amazon.CloudFront.Model.ForwardedValues();
            System.Boolean? requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_forwardedValues_QueryString = null;
            if (cmdletContext.DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryString != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_forwardedValues_QueryString = cmdletContext.DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryString.Value;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_forwardedValues_QueryString != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues.QueryString = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_forwardedValues_QueryString.Value;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValuesIsNull = false;
            }
            Amazon.CloudFront.Model.CookiePreference requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies = null;
            
             // populate Cookies
            bool requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_CookiesIsNull = true;
            requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies = new Amazon.CloudFront.Model.CookiePreference();
            Amazon.CloudFront.ItemSelection requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_cookies_Forward = null;
            if (cmdletContext.DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_Forward != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_cookies_Forward = cmdletContext.DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_Forward;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_cookies_Forward != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies.Forward = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_cookies_Forward;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_CookiesIsNull = false;
            }
            Amazon.CloudFront.Model.CookieNames requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames = null;
            
             // populate WhitelistedNames
            bool requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNamesIsNull = true;
            requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames = new Amazon.CloudFront.Model.CookieNames();
            List<System.String> requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_whitelistedNames_Item = null;
            if (cmdletContext.DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_Items != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_whitelistedNames_Item = cmdletContext.DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_Items;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_whitelistedNames_Item != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames.Items = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_whitelistedNames_Item;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNamesIsNull = false;
            }
            System.Int32? requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_whitelistedNames_Quantity = null;
            if (cmdletContext.DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_whitelistedNames_Quantity = cmdletContext.DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_Quantity.Value;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_whitelistedNames_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames.Quantity = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_whitelistedNames_Quantity.Value;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNamesIsNull = false;
            }
             // determine if requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames should be set to null
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNamesIsNull)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames = null;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies.WhitelistedNames = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_CookiesIsNull = false;
            }
             // determine if requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies should be set to null
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_CookiesIsNull)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies = null;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues.Cookies = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValuesIsNull = false;
            }
            Amazon.CloudFront.Model.Headers requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Headers = null;
            
             // populate Headers
            bool requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_HeadersIsNull = true;
            requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Headers = new Amazon.CloudFront.Model.Headers();
            List<System.String> requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_headers_Item = null;
            if (cmdletContext.DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_Items != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_headers_Item = cmdletContext.DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_Items;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_headers_Item != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Headers.Items = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_headers_Item;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_HeadersIsNull = false;
            }
            System.Int32? requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_headers_Quantity = null;
            if (cmdletContext.DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_headers_Quantity = cmdletContext.DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_Quantity.Value;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_headers_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Headers.Quantity = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_headers_Quantity.Value;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_HeadersIsNull = false;
            }
             // determine if requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Headers should be set to null
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_HeadersIsNull)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Headers = null;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Headers != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues.Headers = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Headers;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValuesIsNull = false;
            }
            Amazon.CloudFront.Model.QueryStringCacheKeys requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys = null;
            
             // populate QueryStringCacheKeys
            bool requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeysIsNull = true;
            requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys = new Amazon.CloudFront.Model.QueryStringCacheKeys();
            List<System.String> requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_queryStringCacheKeys_Item = null;
            if (cmdletContext.DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_Items != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_queryStringCacheKeys_Item = cmdletContext.DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_Items;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_queryStringCacheKeys_Item != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys.Items = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_queryStringCacheKeys_Item;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeysIsNull = false;
            }
            System.Int32? requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_queryStringCacheKeys_Quantity = null;
            if (cmdletContext.DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_queryStringCacheKeys_Quantity = cmdletContext.DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_Quantity.Value;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_queryStringCacheKeys_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys.Quantity = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_queryStringCacheKeys_Quantity.Value;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeysIsNull = false;
            }
             // determine if requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys should be set to null
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeysIsNull)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys = null;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues.QueryStringCacheKeys = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValuesIsNull = false;
            }
             // determine if requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues should be set to null
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValuesIsNull)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues = null;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior.ForwardedValues = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues;
                requestDistributionConfig_distributionConfig_DefaultCacheBehaviorIsNull = false;
            }
             // determine if requestDistributionConfig_distributionConfig_DefaultCacheBehavior should be set to null
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehaviorIsNull)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior = null;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior != null)
            {
                request.DistributionConfig.DefaultCacheBehavior = requestDistributionConfig_distributionConfig_DefaultCacheBehavior;
                requestDistributionConfigIsNull = false;
            }
             // determine if request.DistributionConfig should be set to null
            if (requestDistributionConfigIsNull)
            {
                request.DistributionConfig = null;
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
        
        private Amazon.CloudFront.Model.CreateDistributionResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.CreateDistributionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "CreateDistribution");
            try
            {
                #if DESKTOP
                return client.CreateDistribution(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateDistributionAsync(request);
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
            public List<System.String> DistributionConfig_Aliases_Items { get; set; }
            public System.Int32? DistributionConfig_Aliases_Quantity { get; set; }
            public List<Amazon.CloudFront.Model.CacheBehavior> DistributionConfig_CacheBehaviors_Items { get; set; }
            public System.Int32? DistributionConfig_CacheBehaviors_Quantity { get; set; }
            public System.String DistributionConfig_CallerReference { get; set; }
            public System.String DistributionConfig_Comment { get; set; }
            public List<Amazon.CloudFront.Model.CustomErrorResponse> DistributionConfig_CustomErrorResponses_Items { get; set; }
            public System.Int32? DistributionConfig_CustomErrorResponses_Quantity { get; set; }
            public List<System.String> DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_Items { get; set; }
            public System.Int32? DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_Quantity { get; set; }
            public List<System.String> DistributionConfig_DefaultCacheBehavior_AllowedMethods_Items { get; set; }
            public System.Int32? DistributionConfig_DefaultCacheBehavior_AllowedMethods_Quantity { get; set; }
            public System.Boolean? DistributionConfig_DefaultCacheBehavior_Compress { get; set; }
            public System.Int64? DistributionConfig_DefaultCacheBehavior_DefaultTTL { get; set; }
            public Amazon.CloudFront.ItemSelection DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_Forward { get; set; }
            public List<System.String> DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_Items { get; set; }
            public System.Int32? DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_Quantity { get; set; }
            public List<System.String> DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_Items { get; set; }
            public System.Int32? DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_Quantity { get; set; }
            public System.Boolean? DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryString { get; set; }
            public List<System.String> DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_Items { get; set; }
            public System.Int32? DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_Quantity { get; set; }
            public List<Amazon.CloudFront.Model.LambdaFunctionAssociation> DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_Items { get; set; }
            public System.Int32? DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_Quantity { get; set; }
            public System.Int64? DistributionConfig_DefaultCacheBehavior_MaxTTL { get; set; }
            public System.Int64? DistributionConfig_DefaultCacheBehavior_MinTTL { get; set; }
            public System.Boolean? DistributionConfig_DefaultCacheBehavior_SmoothStreaming { get; set; }
            public System.String DistributionConfig_DefaultCacheBehavior_TargetOriginId { get; set; }
            public System.Boolean? DistributionConfig_DefaultCacheBehavior_TrustedSigners_Enabled { get; set; }
            public List<System.String> DistributionConfig_DefaultCacheBehavior_TrustedSigners_Items { get; set; }
            public System.Int32? DistributionConfig_DefaultCacheBehavior_TrustedSigners_Quantity { get; set; }
            public Amazon.CloudFront.ViewerProtocolPolicy DistributionConfig_DefaultCacheBehavior_ViewerProtocolPolicy { get; set; }
            public System.String DistributionConfig_DefaultRootObject { get; set; }
            public System.Boolean? DistributionConfig_Enabled { get; set; }
            public Amazon.CloudFront.HttpVersion DistributionConfig_HttpVersion { get; set; }
            public System.Boolean? DistributionConfig_IsIPV6Enabled { get; set; }
            public System.String DistributionConfig_Logging_Bucket { get; set; }
            public System.Boolean? DistributionConfig_Logging_Enabled { get; set; }
            public System.Boolean? DistributionConfig_Logging_IncludeCookies { get; set; }
            public System.String DistributionConfig_Logging_Prefix { get; set; }
            public List<Amazon.CloudFront.Model.Origin> DistributionConfig_Origins_Items { get; set; }
            public System.Int32? DistributionConfig_Origins_Quantity { get; set; }
            public Amazon.CloudFront.PriceClass DistributionConfig_PriceClass { get; set; }
            public List<System.String> DistributionConfig_Restrictions_GeoRestriction_Items { get; set; }
            public System.Int32? DistributionConfig_Restrictions_GeoRestriction_Quantity { get; set; }
            public Amazon.CloudFront.GeoRestrictionType DistributionConfig_Restrictions_GeoRestriction_RestrictionType { get; set; }
            public System.String DistributionConfig_ViewerCertificate_ACMCertificateArn { get; set; }
            public System.String DistributionConfig_ViewerCertificate_Certificate { get; set; }
            public Amazon.CloudFront.CertificateSource DistributionConfig_ViewerCertificate_CertificateSource { get; set; }
            public System.Boolean? DistributionConfig_ViewerCertificate_CloudFrontDefaultCertificate { get; set; }
            public System.String DistributionConfig_ViewerCertificate_IAMCertificateId { get; set; }
            public Amazon.CloudFront.MinimumProtocolVersion DistributionConfig_ViewerCertificate_MinimumProtocolVersion { get; set; }
            public Amazon.CloudFront.SSLSupportMethod DistributionConfig_ViewerCertificate_SSLSupportMethod { get; set; }
            public System.String DistributionConfig_WebACLId { get; set; }
        }
        
    }
}
