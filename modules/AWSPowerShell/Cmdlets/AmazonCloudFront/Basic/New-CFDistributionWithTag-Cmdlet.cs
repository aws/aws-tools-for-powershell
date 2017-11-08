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
    /// Create a new distribution with tags.
    /// </summary>
    [Cmdlet("New", "CFDistributionWithTag", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudFront.Model.CreateDistributionWithTagsResponse")]
    [AWSCmdlet("Calls the Amazon CloudFront CreateDistributionWithTags API operation.", Operation = new[] {"CreateDistributionWithTags"})]
    [AWSCmdletOutput("Amazon.CloudFront.Model.CreateDistributionWithTagsResponse",
        "This cmdlet returns a Amazon.CloudFront.Model.CreateDistributionWithTagsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCFDistributionWithTagCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        #region Parameter ViewerCertificate_ACMCertificateArn
        /// <summary>
        /// <para>
        /// <para>For information about how and when to use <code>ACMCertificateArn</code>, see <a>ViewerCertificate</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_ViewerCertificate_ACMCertificateArn")]
        public System.String ViewerCertificate_ACMCertificateArn { get; set; }
        #endregion
        
        #region Parameter Logging_Bucket
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket to store the access logs in, for example, <code>myawslogbucket.s3.amazonaws.com</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_Logging_Bucket")]
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
        [Alias("DistributionConfigWithTags_DistributionConfig_CallerReference")]
        public System.String DistributionConfig_CallerReference { get; set; }
        #endregion
        
        #region Parameter ViewerCertificate_Certificate
        /// <summary>
        /// <para>
        /// <para>This field has been deprecated. Use one of the following fields instead:</para><ul><li><para><a>ViewerCertificate$ACMCertificateArn</a></para></li><li><para><a>ViewerCertificate$IAMCertificateId</a></para></li><li><para><a>ViewerCertificate$CloudFrontDefaultCertificate</a></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_ViewerCertificate_Certificate")]
        public System.String ViewerCertificate_Certificate { get; set; }
        #endregion
        
        #region Parameter ViewerCertificate_CertificateSource
        /// <summary>
        /// <para>
        /// <para>This field has been deprecated. Use one of the following fields instead:</para><ul><li><para><a>ViewerCertificate$ACMCertificateArn</a></para></li><li><para><a>ViewerCertificate$IAMCertificateId</a></para></li><li><para><a>ViewerCertificate$CloudFrontDefaultCertificate</a></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_ViewerCertificate_CertificateSource")]
        [AWSConstantClassSource("Amazon.CloudFront.CertificateSource")]
        public Amazon.CloudFront.CertificateSource ViewerCertificate_CertificateSource { get; set; }
        #endregion
        
        #region Parameter ViewerCertificate_CloudFrontDefaultCertificate
        /// <summary>
        /// <para>
        /// <para>For information about how and when to use <code>CloudFrontDefaultCertificate</code>,
        /// see <a>ViewerCertificate</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_ViewerCertificate_CloudFrontDefaultCertificate")]
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
        [Alias("DistributionConfigWithTags_DistributionConfig_Comment")]
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
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_Compress")]
        public System.Boolean DefaultCacheBehavior_Compress { get; set; }
        #endregion
        
        #region Parameter DistributionConfig_DefaultRootObject
        /// <summary>
        /// <para>
        /// <para>The object that you want CloudFront to request from your origin (for example, <code>index.html</code>)
        /// when a viewer requests the root URL for your distribution (<code>http://www.example.com</code>)
        /// instead of an object in your distribution (<code>http://www.example.com/product-description.html</code>).
        /// Specifying a default root object avoids exposing the contents of your distribution.</para><para>Specify only the object name, for example, <code>index.html</code>. Don't add a <code>/</code>
        /// before the object name.</para><para>If you don't want to specify a default root object when you create a distribution,
        /// include an empty <code>DefaultRootObject</code> element.</para><para>To delete the default root object from an existing distribution, update the distribution
        /// configuration and include an empty <code>DefaultRootObject</code> element.</para><para>To replace the default root object, update the distribution configuration and specify
        /// the new object.</para><para>For more information about the default root object, see <a href="http://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/DefaultRootObject.html">Creating
        /// a Default Root Object</a> in the <i>Amazon CloudFront Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultRootObject")]
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
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_DefaultTTL")]
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
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners_Enabled")]
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
        [Alias("DistributionConfigWithTags_DistributionConfig_Enabled")]
        public System.Boolean DistributionConfig_Enabled { get; set; }
        #endregion
        
        #region Parameter Logging_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether you want CloudFront to save access logs to an Amazon S3 bucket.
        /// If you don't want to enable logging when you create a distribution or if you want
        /// to disable logging for an existing distribution, specify <code>false</code> for <code>Enabled</code>,
        /// and specify empty <code>Bucket</code> and <code>Prefix</code> elements. If you specify
        /// <code>false</code> for <code>Enabled</code> but you specify values for <code>Bucket</code>,
        /// <code>prefix</code>, and <code>IncludeCookies</code>, the values are automatically
        /// deleted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_Logging_Enabled")]
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
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_Forward")]
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
        [Alias("DistributionConfigWithTags_DistributionConfig_HttpVersion")]
        [AWSConstantClassSource("Amazon.CloudFront.HttpVersion")]
        public Amazon.CloudFront.HttpVersion DistributionConfig_HttpVersion { get; set; }
        #endregion
        
        #region Parameter ViewerCertificate_IAMCertificateId
        /// <summary>
        /// <para>
        /// <para>For information about how and when to use <code>IAMCertificateId</code>, see <a>ViewerCertificate</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_ViewerCertificate_IAMCertificateId")]
        public System.String ViewerCertificate_IAMCertificateId { get; set; }
        #endregion
        
        #region Parameter Logging_IncludeCookie
        /// <summary>
        /// <para>
        /// <para>Specifies whether you want CloudFront to include cookies in access logs, specify <code>true</code>
        /// for <code>IncludeCookies</code>. If you choose to include cookies in logs, CloudFront
        /// logs all cookies regardless of how you configure the cache behaviors for this distribution.
        /// If you don't want to include cookies when you create a distribution or if you want
        /// to disable include cookies for an existing distribution, specify <code>false</code>
        /// for <code>IncludeCookies</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_Logging_IncludeCookies")]
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
        /// parameter to restrict the IP addresses that can access your content, don't enable
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
        [Alias("DistributionConfigWithTags_DistributionConfig_IsIPV6Enabled")]
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
        [Alias("DistributionConfigWithTags_DistributionConfig_Aliases_Items")]
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
        [Alias("DistributionConfigWithTags_DistributionConfig_CacheBehaviors_Items")]
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
        [Alias("DistributionConfigWithTags_DistributionConfig_CustomErrorResponses_Items")]
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
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_Items")]
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
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_Items")]
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
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_Items")]
        public System.String[] WhitelistedNames_Item { get; set; }
        #endregion
        
        #region Parameter Headers_Item
        /// <summary>
        /// <para>
        /// <para>A list that contains one <code>Name</code> element for each header that you want CloudFront
        /// to use for caching in this cache behavior. If <code>Quantity</code> is <code>0</code>,
        /// omit <code>Items</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_Items")]
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
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_Items")]
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
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_Items")]
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
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners_Items")]
        public System.String[] TrustedSigners_Item { get; set; }
        #endregion
        
        #region Parameter Origins_Item
        /// <summary>
        /// <para>
        /// <para>A complex type that contains origins for this distribution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_Origins_Items")]
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
        /// also refer to the country list on the CloudFront console, which includes both country
        /// names and codes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_Items")]
        public System.String[] GeoRestriction_Item { get; set; }
        #endregion
        
        #region Parameter Tags_Item
        /// <summary>
        /// <para>
        /// <para> A complex type that contains <code>Tag</code> elements.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_Tags_Items")]
        public Amazon.CloudFront.Model.Tag[] Tags_Item { get; set; }
        #endregion
        
        #region Parameter DefaultCacheBehavior_MaxTTL
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_MaxTTL")]
        public System.Int64 DefaultCacheBehavior_MaxTTL { get; set; }
        #endregion
        
        #region Parameter ViewerCertificate_MinimumProtocolVersion
        /// <summary>
        /// <para>
        /// <para>Specify the security policy that you want CloudFront to use for HTTPS connections.
        /// A security policy determines two settings:</para><ul><li><para>The minimum SSL/TLS protocol that CloudFront uses to communicate with viewers</para></li><li><para>The cipher that CloudFront uses to encrypt the content that it returns to viewers</para></li></ul><note><para>On the CloudFront console, this setting is called <b>Security policy</b>.</para></note><para>We recommend that you specify <code>TLSv1.1_2016</code> unless your users are using
        /// browsers or devices that do not support TLSv1.1 or later.</para><para>When both of the following are true, you must specify <code>TLSv1</code> or later
        /// for the security policy: </para><ul><li><para>You're using a custom certificate: you specified a value for <code>ACMCertificateArn</code>
        /// or for <code>IAMCertificateId</code></para></li><li><para>You're using SNI: you specified <code>sni-only</code> for <code>SSLSupportMethod</code></para></li></ul><para>If you specify <code>true</code> for <code>CloudFrontDefaultCertificate</code>, CloudFront
        /// automatically sets the security policy to <code>TLSv1</code> regardless of the value
        /// that you specify for <code>MinimumProtocolVersion</code>.</para><para>For information about the relationship between the security policy that you choose
        /// and the protocols and ciphers that CloudFront uses to communicate with viewers, see
        /// <a href="http://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/secure-connections-supported-viewer-protocols-ciphers.html#secure-connections-supported-ciphers">
        /// Supported SSL/TLS Protocols and Ciphers for Communication Between Viewers and CloudFront</a>
        /// in the <i>Amazon CloudFront Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_ViewerCertificate_MinimumProtocolVersion")]
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
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_MinTTL")]
        public System.Int64 DefaultCacheBehavior_MinTTL { get; set; }
        #endregion
        
        #region Parameter Logging_Prefix
        /// <summary>
        /// <para>
        /// <para>An optional string that you want CloudFront to prefix to the access log <code>filenames</code>
        /// for this distribution, for example, <code>myprefix/</code>. If you want to enable
        /// logging, but you don't want to specify a prefix, you still must include an empty <code>Prefix</code>
        /// element in the <code>Logging</code> element.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_Logging_Prefix")]
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
        [Alias("DistributionConfigWithTags_DistributionConfig_PriceClass")]
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
        [Alias("DistributionConfigWithTags_DistributionConfig_Aliases_Quantity")]
        public System.Int32 Aliases_Quantity { get; set; }
        #endregion
        
        #region Parameter CacheBehaviors_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of cache behaviors for this distribution. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_CacheBehaviors_Quantity")]
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
        [Alias("DistributionConfigWithTags_DistributionConfig_CustomErrorResponses_Quantity")]
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
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_Quantity")]
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
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_Quantity")]
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
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_Quantity")]
        public System.Int32 WhitelistedNames_Quantity { get; set; }
        #endregion
        
        #region Parameter Headers_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of different headers that you want CloudFront to base caching on for this
        /// cache behavior. You can configure each cache behavior in a web distribution to do
        /// one of the following:</para><ul><li><para><b>Forward all headers to your origin</b>: Specify <code>1</code> for <code>Quantity</code>
        /// and <code>*</code> for <code>Name</code>.</para><important><para>CloudFront doesn't cache the objects that are associated with this cache behavior.
        /// Instead, CloudFront sends every request to the origin. </para></important></li><li><para><b>Forward a whitelist of headers you specify</b>: Specify the number of headers
        /// that you want CloudFront to base caching on. Then specify the header names in <code>Name</code>
        /// elements. CloudFront caches your objects based on the values in the specified headers.</para></li><li><para><b>Forward only the default headers</b>: Specify <code>0</code> for <code>Quantity</code>
        /// and omit <code>Items</code>. In this configuration, CloudFront doesn't cache based
        /// on the values in the request headers.</para></li></ul><para>Regardless of which option you choose, CloudFront forwards headers to your origin
        /// based on whether the origin is an S3 bucket or a custom origin. See the following
        /// documentation:</para><ul><li><para><b>S3 bucket</b>: See <a href="http://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/RequestAndResponseBehaviorS3Origin.html#request-s3-removed-headers">HTTP
        /// Request Headers That CloudFront Removes or Updates</a></para></li><li><para><b>Custom origin</b>: See <a href="http://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/RequestAndResponseBehaviorCustomOrigin.html#request-custom-headers-behavior">HTTP
        /// Request Headers and CloudFront Behavior</a></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_Quantity")]
        public System.Int32 Headers_Quantity { get; set; }
        #endregion
        
        #region Parameter QueryStringCacheKeys_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of <code>whitelisted</code> query string parameters for this cache behavior.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_Quantity")]
        public System.Int32 QueryStringCacheKeys_Quantity { get; set; }
        #endregion
        
        #region Parameter LambdaFunctionAssociations_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of Lambda function associations for this cache behavior.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_Quantity")]
        public System.Int32 LambdaFunctionAssociations_Quantity { get; set; }
        #endregion
        
        #region Parameter TrustedSigners_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of trusted signers for this cache behavior.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners_Quantity")]
        public System.Int32 TrustedSigners_Quantity { get; set; }
        #endregion
        
        #region Parameter Origins_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of origins for this distribution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_Origins_Quantity")]
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
        [Alias("DistributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_Quantity")]
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
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryString")]
        public System.Boolean ForwardedValues_QueryString { get; set; }
        #endregion
        
        #region Parameter GeoRestriction_RestrictionType
        /// <summary>
        /// <para>
        /// <para>The method that you want to use to restrict distribution of your content by country:</para><ul><li><para><code>none</code>: No geo restriction is enabled, meaning access to content is not
        /// restricted by client geo location.</para></li><li><para><code>blacklist</code>: The <code>Location</code> elements specify the countries
        /// in which you don't want CloudFront to distribute your content.</para></li><li><para><code>whitelist</code>: The <code>Location</code> elements specify the countries
        /// in which you want CloudFront to distribute your content.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_RestrictionType")]
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
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_SmoothStreaming")]
        public System.Boolean DefaultCacheBehavior_SmoothStreaming { get; set; }
        #endregion
        
        #region Parameter ViewerCertificate_SSLSupportMethod
        /// <summary>
        /// <para>
        /// <para>If you specify a value for <a>ViewerCertificate$ACMCertificateArn</a> or for <a>ViewerCertificate$IAMCertificateId</a>,
        /// you must also specify how you want CloudFront to serve HTTPS requests: using a method
        /// that works for all clients or one that works for most clients:</para><ul><li><para><code>vip</code>: CloudFront uses dedicated IP addresses for your content and can
        /// respond to HTTPS requests from any viewer. However, you will incur additional monthly
        /// charges.</para></li><li><para><code>sni-only</code>: CloudFront can respond to HTTPS requests from viewers that
        /// support Server Name Indication (SNI). All modern browsers support SNI, but some browsers
        /// still in use don't support SNI. If some of your users' browsers don't support SNI,
        /// we recommend that you do one of the following:</para><ul><li><para>Use the <code>vip</code> option (dedicated IP addresses) instead of <code>sni-only</code>.</para></li><li><para>Use the CloudFront SSL/TLS certificate instead of a custom certificate. This requires
        /// that you use the CloudFront domain name of your distribution in the URLs for your
        /// objects, for example, <code>https://d111111abcdef8.cloudfront.net/logo.png</code>.</para></li><li><para>If you can control which browser your users use, upgrade the browser to one that supports
        /// SNI.</para></li><li><para>Use HTTP instead of HTTPS.</para></li></ul></li></ul><para>Don't specify a value for <code>SSLSupportMethod</code> if you specified <code>&lt;CloudFrontDefaultCertificate&gt;true&lt;CloudFrontDefaultCertificate&gt;</code>.</para><para>For more information, see <a href="http://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/SecureConnections.html#CNAMEsAndHTTPS.html">Using
        /// Alternate Domain Names and HTTPS</a> in the <i>Amazon CloudFront Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_ViewerCertificate_SSLSupportMethod")]
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
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TargetOriginId")]
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
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ViewerProtocolPolicy")]
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
        [Alias("DistributionConfigWithTags_DistributionConfig_WebACLId")]
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CFDistributionWithTag (CreateDistributionWithTags)"))
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
                context.DistributionConfigWithTags_DistributionConfig_Aliases_Items = new List<System.String>(this.Aliases_Item);
            }
            if (ParameterWasBound("Aliases_Quantity"))
                context.DistributionConfigWithTags_DistributionConfig_Aliases_Quantity = this.Aliases_Quantity;
            if (this.CacheBehaviors_Item != null)
            {
                context.DistributionConfigWithTags_DistributionConfig_CacheBehaviors_Items = new List<Amazon.CloudFront.Model.CacheBehavior>(this.CacheBehaviors_Item);
            }
            if (ParameterWasBound("CacheBehaviors_Quantity"))
                context.DistributionConfigWithTags_DistributionConfig_CacheBehaviors_Quantity = this.CacheBehaviors_Quantity;
            context.DistributionConfigWithTags_DistributionConfig_CallerReference = this.DistributionConfig_CallerReference;
            context.DistributionConfigWithTags_DistributionConfig_Comment = this.DistributionConfig_Comment;
            if (this.CustomErrorResponses_Item != null)
            {
                context.DistributionConfigWithTags_DistributionConfig_CustomErrorResponses_Items = new List<Amazon.CloudFront.Model.CustomErrorResponse>(this.CustomErrorResponses_Item);
            }
            if (ParameterWasBound("CustomErrorResponses_Quantity"))
                context.DistributionConfigWithTags_DistributionConfig_CustomErrorResponses_Quantity = this.CustomErrorResponses_Quantity;
            if (this.CachedMethods_Item != null)
            {
                context.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_Items = new List<System.String>(this.CachedMethods_Item);
            }
            if (ParameterWasBound("CachedMethods_Quantity"))
                context.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_Quantity = this.CachedMethods_Quantity;
            if (this.AllowedMethods_Item != null)
            {
                context.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_Items = new List<System.String>(this.AllowedMethods_Item);
            }
            if (ParameterWasBound("AllowedMethods_Quantity"))
                context.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_Quantity = this.AllowedMethods_Quantity;
            if (ParameterWasBound("DefaultCacheBehavior_Compress"))
                context.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_Compress = this.DefaultCacheBehavior_Compress;
            if (ParameterWasBound("DefaultCacheBehavior_DefaultTTL"))
                context.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_DefaultTTL = this.DefaultCacheBehavior_DefaultTTL;
            context.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_Forward = this.Cookies_Forward;
            if (this.WhitelistedNames_Item != null)
            {
                context.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_Items = new List<System.String>(this.WhitelistedNames_Item);
            }
            if (ParameterWasBound("WhitelistedNames_Quantity"))
                context.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_Quantity = this.WhitelistedNames_Quantity;
            if (this.Headers_Item != null)
            {
                context.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_Items = new List<System.String>(this.Headers_Item);
            }
            if (ParameterWasBound("Headers_Quantity"))
                context.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_Quantity = this.Headers_Quantity;
            if (ParameterWasBound("ForwardedValues_QueryString"))
                context.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryString = this.ForwardedValues_QueryString;
            if (this.QueryStringCacheKeys_Item != null)
            {
                context.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_Items = new List<System.String>(this.QueryStringCacheKeys_Item);
            }
            if (ParameterWasBound("QueryStringCacheKeys_Quantity"))
                context.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_Quantity = this.QueryStringCacheKeys_Quantity;
            if (this.LambdaFunctionAssociations_Item != null)
            {
                context.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_Items = new List<Amazon.CloudFront.Model.LambdaFunctionAssociation>(this.LambdaFunctionAssociations_Item);
            }
            if (ParameterWasBound("LambdaFunctionAssociations_Quantity"))
                context.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_Quantity = this.LambdaFunctionAssociations_Quantity;
            if (ParameterWasBound("DefaultCacheBehavior_MaxTTL"))
                context.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_MaxTTL = this.DefaultCacheBehavior_MaxTTL;
            if (ParameterWasBound("DefaultCacheBehavior_MinTTL"))
                context.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_MinTTL = this.DefaultCacheBehavior_MinTTL;
            if (ParameterWasBound("DefaultCacheBehavior_SmoothStreaming"))
                context.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_SmoothStreaming = this.DefaultCacheBehavior_SmoothStreaming;
            context.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TargetOriginId = this.DefaultCacheBehavior_TargetOriginId;
            if (ParameterWasBound("TrustedSigners_Enabled"))
                context.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners_Enabled = this.TrustedSigners_Enabled;
            if (this.TrustedSigners_Item != null)
            {
                context.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners_Items = new List<System.String>(this.TrustedSigners_Item);
            }
            if (ParameterWasBound("TrustedSigners_Quantity"))
                context.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners_Quantity = this.TrustedSigners_Quantity;
            context.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ViewerProtocolPolicy = this.DefaultCacheBehavior_ViewerProtocolPolicy;
            context.DistributionConfigWithTags_DistributionConfig_DefaultRootObject = this.DistributionConfig_DefaultRootObject;
            if (ParameterWasBound("DistributionConfig_Enabled"))
                context.DistributionConfigWithTags_DistributionConfig_Enabled = this.DistributionConfig_Enabled;
            context.DistributionConfigWithTags_DistributionConfig_HttpVersion = this.DistributionConfig_HttpVersion;
            if (ParameterWasBound("DistributionConfig_IsIPV6Enabled"))
                context.DistributionConfigWithTags_DistributionConfig_IsIPV6Enabled = this.DistributionConfig_IsIPV6Enabled;
            context.DistributionConfigWithTags_DistributionConfig_Logging_Bucket = this.Logging_Bucket;
            if (ParameterWasBound("Logging_Enabled"))
                context.DistributionConfigWithTags_DistributionConfig_Logging_Enabled = this.Logging_Enabled;
            if (ParameterWasBound("Logging_IncludeCookie"))
                context.DistributionConfigWithTags_DistributionConfig_Logging_IncludeCookies = this.Logging_IncludeCookie;
            context.DistributionConfigWithTags_DistributionConfig_Logging_Prefix = this.Logging_Prefix;
            if (this.Origins_Item != null)
            {
                context.DistributionConfigWithTags_DistributionConfig_Origins_Items = new List<Amazon.CloudFront.Model.Origin>(this.Origins_Item);
            }
            if (ParameterWasBound("Origins_Quantity"))
                context.DistributionConfigWithTags_DistributionConfig_Origins_Quantity = this.Origins_Quantity;
            context.DistributionConfigWithTags_DistributionConfig_PriceClass = this.DistributionConfig_PriceClass;
            if (this.GeoRestriction_Item != null)
            {
                context.DistributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_Items = new List<System.String>(this.GeoRestriction_Item);
            }
            if (ParameterWasBound("GeoRestriction_Quantity"))
                context.DistributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_Quantity = this.GeoRestriction_Quantity;
            context.DistributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_RestrictionType = this.GeoRestriction_RestrictionType;
            context.DistributionConfigWithTags_DistributionConfig_ViewerCertificate_ACMCertificateArn = this.ViewerCertificate_ACMCertificateArn;
            context.DistributionConfigWithTags_DistributionConfig_ViewerCertificate_Certificate = this.ViewerCertificate_Certificate;
            context.DistributionConfigWithTags_DistributionConfig_ViewerCertificate_CertificateSource = this.ViewerCertificate_CertificateSource;
            if (ParameterWasBound("ViewerCertificate_CloudFrontDefaultCertificate"))
                context.DistributionConfigWithTags_DistributionConfig_ViewerCertificate_CloudFrontDefaultCertificate = this.ViewerCertificate_CloudFrontDefaultCertificate;
            context.DistributionConfigWithTags_DistributionConfig_ViewerCertificate_IAMCertificateId = this.ViewerCertificate_IAMCertificateId;
            context.DistributionConfigWithTags_DistributionConfig_ViewerCertificate_MinimumProtocolVersion = this.ViewerCertificate_MinimumProtocolVersion;
            context.DistributionConfigWithTags_DistributionConfig_ViewerCertificate_SSLSupportMethod = this.ViewerCertificate_SSLSupportMethod;
            context.DistributionConfigWithTags_DistributionConfig_WebACLId = this.DistributionConfig_WebACLId;
            if (this.Tags_Item != null)
            {
                context.DistributionConfigWithTags_Tags_Items = new List<Amazon.CloudFront.Model.Tag>(this.Tags_Item);
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
            var request = new Amazon.CloudFront.Model.CreateDistributionWithTagsRequest();
            
            
             // populate DistributionConfigWithTags
            bool requestDistributionConfigWithTagsIsNull = true;
            request.DistributionConfigWithTags = new Amazon.CloudFront.Model.DistributionConfigWithTags();
            Amazon.CloudFront.Model.Tags requestDistributionConfigWithTags_distributionConfigWithTags_Tags = null;
            
             // populate Tags
            bool requestDistributionConfigWithTags_distributionConfigWithTags_TagsIsNull = true;
            requestDistributionConfigWithTags_distributionConfigWithTags_Tags = new Amazon.CloudFront.Model.Tags();
            List<Amazon.CloudFront.Model.Tag> requestDistributionConfigWithTags_distributionConfigWithTags_Tags_tags_Item = null;
            if (cmdletContext.DistributionConfigWithTags_Tags_Items != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_Tags_tags_Item = cmdletContext.DistributionConfigWithTags_Tags_Items;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_Tags_tags_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_Tags.Items = requestDistributionConfigWithTags_distributionConfigWithTags_Tags_tags_Item;
                requestDistributionConfigWithTags_distributionConfigWithTags_TagsIsNull = false;
            }
             // determine if requestDistributionConfigWithTags_distributionConfigWithTags_Tags should be set to null
            if (requestDistributionConfigWithTags_distributionConfigWithTags_TagsIsNull)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_Tags = null;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_Tags != null)
            {
                request.DistributionConfigWithTags.Tags = requestDistributionConfigWithTags_distributionConfigWithTags_Tags;
                requestDistributionConfigWithTagsIsNull = false;
            }
            Amazon.CloudFront.Model.DistributionConfig requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig = null;
            
             // populate DistributionConfig
            bool requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfigIsNull = true;
            requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig = new Amazon.CloudFront.Model.DistributionConfig();
            System.String requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_CallerReference = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_CallerReference != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_CallerReference = cmdletContext.DistributionConfigWithTags_DistributionConfig_CallerReference;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_CallerReference != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig.CallerReference = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_CallerReference;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfigIsNull = false;
            }
            System.String requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_Comment = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_Comment != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_Comment = cmdletContext.DistributionConfigWithTags_DistributionConfig_Comment;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_Comment != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig.Comment = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_Comment;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfigIsNull = false;
            }
            System.String requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_DefaultRootObject = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultRootObject != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_DefaultRootObject = cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultRootObject;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_DefaultRootObject != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig.DefaultRootObject = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_DefaultRootObject;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfigIsNull = false;
            }
            System.Boolean? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_Enabled = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_Enabled != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_Enabled = cmdletContext.DistributionConfigWithTags_DistributionConfig_Enabled.Value;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_Enabled != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig.Enabled = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_Enabled.Value;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfigIsNull = false;
            }
            Amazon.CloudFront.HttpVersion requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_HttpVersion = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_HttpVersion != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_HttpVersion = cmdletContext.DistributionConfigWithTags_DistributionConfig_HttpVersion;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_HttpVersion != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig.HttpVersion = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_HttpVersion;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfigIsNull = false;
            }
            System.Boolean? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_IsIPV6Enabled = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_IsIPV6Enabled != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_IsIPV6Enabled = cmdletContext.DistributionConfigWithTags_DistributionConfig_IsIPV6Enabled.Value;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_IsIPV6Enabled != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig.IsIPV6Enabled = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_IsIPV6Enabled.Value;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfigIsNull = false;
            }
            Amazon.CloudFront.PriceClass requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_PriceClass = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_PriceClass != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_PriceClass = cmdletContext.DistributionConfigWithTags_DistributionConfig_PriceClass;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_PriceClass != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig.PriceClass = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_PriceClass;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfigIsNull = false;
            }
            System.String requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_WebACLId = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_WebACLId != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_WebACLId = cmdletContext.DistributionConfigWithTags_DistributionConfig_WebACLId;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_WebACLId != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig.WebACLId = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_WebACLId;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfigIsNull = false;
            }
            Amazon.CloudFront.Model.Restrictions requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions = null;
            
             // populate Restrictions
            bool requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_RestrictionsIsNull = true;
            requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions = new Amazon.CloudFront.Model.Restrictions();
            Amazon.CloudFront.Model.GeoRestriction requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions_distributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction = null;
            
             // populate GeoRestriction
            bool requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions_distributionConfigWithTags_DistributionConfig_Restrictions_GeoRestrictionIsNull = true;
            requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions_distributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction = new Amazon.CloudFront.Model.GeoRestriction();
            List<System.String> requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions_distributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_geoRestriction_Item = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_Items != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions_distributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_geoRestriction_Item = cmdletContext.DistributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_Items;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions_distributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_geoRestriction_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions_distributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction.Items = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions_distributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_geoRestriction_Item;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions_distributionConfigWithTags_DistributionConfig_Restrictions_GeoRestrictionIsNull = false;
            }
            System.Int32? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions_distributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_geoRestriction_Quantity = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions_distributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_geoRestriction_Quantity = cmdletContext.DistributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_Quantity.Value;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions_distributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_geoRestriction_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions_distributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction.Quantity = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions_distributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_geoRestriction_Quantity.Value;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions_distributionConfigWithTags_DistributionConfig_Restrictions_GeoRestrictionIsNull = false;
            }
            Amazon.CloudFront.GeoRestrictionType requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions_distributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_geoRestriction_RestrictionType = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_RestrictionType != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions_distributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_geoRestriction_RestrictionType = cmdletContext.DistributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_RestrictionType;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions_distributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_geoRestriction_RestrictionType != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions_distributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction.RestrictionType = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions_distributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_geoRestriction_RestrictionType;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions_distributionConfigWithTags_DistributionConfig_Restrictions_GeoRestrictionIsNull = false;
            }
             // determine if requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions_distributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction should be set to null
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions_distributionConfigWithTags_DistributionConfig_Restrictions_GeoRestrictionIsNull)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions_distributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction = null;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions_distributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions.GeoRestriction = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions_distributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_RestrictionsIsNull = false;
            }
             // determine if requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions should be set to null
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_RestrictionsIsNull)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions = null;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig.Restrictions = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfigIsNull = false;
            }
            Amazon.CloudFront.Model.Aliases requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Aliases = null;
            
             // populate Aliases
            bool requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_AliasesIsNull = true;
            requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Aliases = new Amazon.CloudFront.Model.Aliases();
            List<System.String> requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Aliases_aliases_Item = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_Aliases_Items != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Aliases_aliases_Item = cmdletContext.DistributionConfigWithTags_DistributionConfig_Aliases_Items;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Aliases_aliases_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Aliases.Items = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Aliases_aliases_Item;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_AliasesIsNull = false;
            }
            System.Int32? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Aliases_aliases_Quantity = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_Aliases_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Aliases_aliases_Quantity = cmdletContext.DistributionConfigWithTags_DistributionConfig_Aliases_Quantity.Value;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Aliases_aliases_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Aliases.Quantity = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Aliases_aliases_Quantity.Value;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_AliasesIsNull = false;
            }
             // determine if requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Aliases should be set to null
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_AliasesIsNull)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Aliases = null;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Aliases != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig.Aliases = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Aliases;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfigIsNull = false;
            }
            Amazon.CloudFront.Model.CacheBehaviors requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CacheBehaviors = null;
            
             // populate CacheBehaviors
            bool requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CacheBehaviorsIsNull = true;
            requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CacheBehaviors = new Amazon.CloudFront.Model.CacheBehaviors();
            List<Amazon.CloudFront.Model.CacheBehavior> requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CacheBehaviors_cacheBehaviors_Item = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_CacheBehaviors_Items != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CacheBehaviors_cacheBehaviors_Item = cmdletContext.DistributionConfigWithTags_DistributionConfig_CacheBehaviors_Items;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CacheBehaviors_cacheBehaviors_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CacheBehaviors.Items = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CacheBehaviors_cacheBehaviors_Item;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CacheBehaviorsIsNull = false;
            }
            System.Int32? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CacheBehaviors_cacheBehaviors_Quantity = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_CacheBehaviors_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CacheBehaviors_cacheBehaviors_Quantity = cmdletContext.DistributionConfigWithTags_DistributionConfig_CacheBehaviors_Quantity.Value;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CacheBehaviors_cacheBehaviors_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CacheBehaviors.Quantity = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CacheBehaviors_cacheBehaviors_Quantity.Value;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CacheBehaviorsIsNull = false;
            }
             // determine if requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CacheBehaviors should be set to null
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CacheBehaviorsIsNull)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CacheBehaviors = null;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CacheBehaviors != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig.CacheBehaviors = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CacheBehaviors;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfigIsNull = false;
            }
            Amazon.CloudFront.Model.CustomErrorResponses requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CustomErrorResponses = null;
            
             // populate CustomErrorResponses
            bool requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CustomErrorResponsesIsNull = true;
            requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CustomErrorResponses = new Amazon.CloudFront.Model.CustomErrorResponses();
            List<Amazon.CloudFront.Model.CustomErrorResponse> requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CustomErrorResponses_customErrorResponses_Item = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_CustomErrorResponses_Items != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CustomErrorResponses_customErrorResponses_Item = cmdletContext.DistributionConfigWithTags_DistributionConfig_CustomErrorResponses_Items;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CustomErrorResponses_customErrorResponses_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CustomErrorResponses.Items = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CustomErrorResponses_customErrorResponses_Item;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CustomErrorResponsesIsNull = false;
            }
            System.Int32? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CustomErrorResponses_customErrorResponses_Quantity = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_CustomErrorResponses_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CustomErrorResponses_customErrorResponses_Quantity = cmdletContext.DistributionConfigWithTags_DistributionConfig_CustomErrorResponses_Quantity.Value;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CustomErrorResponses_customErrorResponses_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CustomErrorResponses.Quantity = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CustomErrorResponses_customErrorResponses_Quantity.Value;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CustomErrorResponsesIsNull = false;
            }
             // determine if requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CustomErrorResponses should be set to null
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CustomErrorResponsesIsNull)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CustomErrorResponses = null;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CustomErrorResponses != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig.CustomErrorResponses = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CustomErrorResponses;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfigIsNull = false;
            }
            Amazon.CloudFront.Model.Origins requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Origins = null;
            
             // populate Origins
            bool requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_OriginsIsNull = true;
            requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Origins = new Amazon.CloudFront.Model.Origins();
            List<Amazon.CloudFront.Model.Origin> requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Origins_origins_Item = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_Origins_Items != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Origins_origins_Item = cmdletContext.DistributionConfigWithTags_DistributionConfig_Origins_Items;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Origins_origins_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Origins.Items = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Origins_origins_Item;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_OriginsIsNull = false;
            }
            System.Int32? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Origins_origins_Quantity = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_Origins_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Origins_origins_Quantity = cmdletContext.DistributionConfigWithTags_DistributionConfig_Origins_Quantity.Value;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Origins_origins_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Origins.Quantity = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Origins_origins_Quantity.Value;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_OriginsIsNull = false;
            }
             // determine if requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Origins should be set to null
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_OriginsIsNull)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Origins = null;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Origins != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig.Origins = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Origins;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfigIsNull = false;
            }
            Amazon.CloudFront.Model.LoggingConfig requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging = null;
            
             // populate Logging
            bool requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_LoggingIsNull = true;
            requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging = new Amazon.CloudFront.Model.LoggingConfig();
            System.String requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging_logging_Bucket = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_Logging_Bucket != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging_logging_Bucket = cmdletContext.DistributionConfigWithTags_DistributionConfig_Logging_Bucket;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging_logging_Bucket != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging.Bucket = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging_logging_Bucket;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_LoggingIsNull = false;
            }
            System.Boolean? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging_logging_Enabled = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_Logging_Enabled != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging_logging_Enabled = cmdletContext.DistributionConfigWithTags_DistributionConfig_Logging_Enabled.Value;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging_logging_Enabled != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging.Enabled = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging_logging_Enabled.Value;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_LoggingIsNull = false;
            }
            System.Boolean? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging_logging_IncludeCookie = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_Logging_IncludeCookies != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging_logging_IncludeCookie = cmdletContext.DistributionConfigWithTags_DistributionConfig_Logging_IncludeCookies.Value;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging_logging_IncludeCookie != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging.IncludeCookies = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging_logging_IncludeCookie.Value;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_LoggingIsNull = false;
            }
            System.String requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging_logging_Prefix = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_Logging_Prefix != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging_logging_Prefix = cmdletContext.DistributionConfigWithTags_DistributionConfig_Logging_Prefix;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging_logging_Prefix != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging.Prefix = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging_logging_Prefix;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_LoggingIsNull = false;
            }
             // determine if requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging should be set to null
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_LoggingIsNull)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging = null;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig.Logging = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfigIsNull = false;
            }
            Amazon.CloudFront.Model.ViewerCertificate requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate = null;
            
             // populate ViewerCertificate
            bool requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificateIsNull = true;
            requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate = new Amazon.CloudFront.Model.ViewerCertificate();
            System.String requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_ACMCertificateArn = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_ViewerCertificate_ACMCertificateArn != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_ACMCertificateArn = cmdletContext.DistributionConfigWithTags_DistributionConfig_ViewerCertificate_ACMCertificateArn;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_ACMCertificateArn != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate.ACMCertificateArn = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_ACMCertificateArn;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificateIsNull = false;
            }
            System.String requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_Certificate = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_ViewerCertificate_Certificate != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_Certificate = cmdletContext.DistributionConfigWithTags_DistributionConfig_ViewerCertificate_Certificate;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_Certificate != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate.Certificate = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_Certificate;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificateIsNull = false;
            }
            Amazon.CloudFront.CertificateSource requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_CertificateSource = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_ViewerCertificate_CertificateSource != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_CertificateSource = cmdletContext.DistributionConfigWithTags_DistributionConfig_ViewerCertificate_CertificateSource;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_CertificateSource != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate.CertificateSource = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_CertificateSource;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificateIsNull = false;
            }
            System.Boolean? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_CloudFrontDefaultCertificate = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_ViewerCertificate_CloudFrontDefaultCertificate != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_CloudFrontDefaultCertificate = cmdletContext.DistributionConfigWithTags_DistributionConfig_ViewerCertificate_CloudFrontDefaultCertificate.Value;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_CloudFrontDefaultCertificate != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate.CloudFrontDefaultCertificate = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_CloudFrontDefaultCertificate.Value;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificateIsNull = false;
            }
            System.String requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_IAMCertificateId = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_ViewerCertificate_IAMCertificateId != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_IAMCertificateId = cmdletContext.DistributionConfigWithTags_DistributionConfig_ViewerCertificate_IAMCertificateId;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_IAMCertificateId != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate.IAMCertificateId = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_IAMCertificateId;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificateIsNull = false;
            }
            Amazon.CloudFront.MinimumProtocolVersion requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_MinimumProtocolVersion = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_ViewerCertificate_MinimumProtocolVersion != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_MinimumProtocolVersion = cmdletContext.DistributionConfigWithTags_DistributionConfig_ViewerCertificate_MinimumProtocolVersion;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_MinimumProtocolVersion != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate.MinimumProtocolVersion = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_MinimumProtocolVersion;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificateIsNull = false;
            }
            Amazon.CloudFront.SSLSupportMethod requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_SSLSupportMethod = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_ViewerCertificate_SSLSupportMethod != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_SSLSupportMethod = cmdletContext.DistributionConfigWithTags_DistributionConfig_ViewerCertificate_SSLSupportMethod;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_SSLSupportMethod != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate.SSLSupportMethod = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_SSLSupportMethod;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificateIsNull = false;
            }
             // determine if requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate should be set to null
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificateIsNull)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate = null;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig.ViewerCertificate = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfigIsNull = false;
            }
            Amazon.CloudFront.Model.DefaultCacheBehavior requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior = null;
            
             // populate DefaultCacheBehavior
            bool requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehaviorIsNull = true;
            requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior = new Amazon.CloudFront.Model.DefaultCacheBehavior();
            System.Boolean? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_Compress = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_Compress != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_Compress = cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_Compress.Value;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_Compress != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior.Compress = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_Compress.Value;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            System.Int64? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_DefaultTTL = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_DefaultTTL != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_DefaultTTL = cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_DefaultTTL.Value;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_DefaultTTL != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior.DefaultTTL = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_DefaultTTL.Value;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            System.Int64? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_MaxTTL = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_MaxTTL != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_MaxTTL = cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_MaxTTL.Value;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_MaxTTL != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior.MaxTTL = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_MaxTTL.Value;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            System.Int64? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_MinTTL = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_MinTTL != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_MinTTL = cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_MinTTL.Value;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_MinTTL != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior.MinTTL = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_MinTTL.Value;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            System.Boolean? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_SmoothStreaming = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_SmoothStreaming != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_SmoothStreaming = cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_SmoothStreaming.Value;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_SmoothStreaming != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior.SmoothStreaming = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_SmoothStreaming.Value;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            System.String requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_TargetOriginId = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TargetOriginId != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_TargetOriginId = cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TargetOriginId;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_TargetOriginId != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior.TargetOriginId = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_TargetOriginId;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            Amazon.CloudFront.ViewerProtocolPolicy requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_ViewerProtocolPolicy = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ViewerProtocolPolicy != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_ViewerProtocolPolicy = cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ViewerProtocolPolicy;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_ViewerProtocolPolicy != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior.ViewerProtocolPolicy = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_ViewerProtocolPolicy;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            Amazon.CloudFront.Model.LambdaFunctionAssociations requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations = null;
            
             // populate LambdaFunctionAssociations
            bool requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociationsIsNull = true;
            requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations = new Amazon.CloudFront.Model.LambdaFunctionAssociations();
            List<Amazon.CloudFront.Model.LambdaFunctionAssociation> requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_lambdaFunctionAssociations_Item = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_Items != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_lambdaFunctionAssociations_Item = cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_Items;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_lambdaFunctionAssociations_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations.Items = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_lambdaFunctionAssociations_Item;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociationsIsNull = false;
            }
            System.Int32? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_lambdaFunctionAssociations_Quantity = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_lambdaFunctionAssociations_Quantity = cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_Quantity.Value;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_lambdaFunctionAssociations_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations.Quantity = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_lambdaFunctionAssociations_Quantity.Value;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociationsIsNull = false;
            }
             // determine if requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations should be set to null
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociationsIsNull)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations = null;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior.LambdaFunctionAssociations = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            Amazon.CloudFront.Model.AllowedMethods requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods = null;
            
             // populate AllowedMethods
            bool requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethodsIsNull = true;
            requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods = new Amazon.CloudFront.Model.AllowedMethods();
            List<System.String> requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_allowedMethods_Item = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_Items != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_allowedMethods_Item = cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_Items;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_allowedMethods_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods.Items = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_allowedMethods_Item;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethodsIsNull = false;
            }
            System.Int32? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_allowedMethods_Quantity = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_allowedMethods_Quantity = cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_Quantity.Value;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_allowedMethods_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods.Quantity = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_allowedMethods_Quantity.Value;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethodsIsNull = false;
            }
            Amazon.CloudFront.Model.CachedMethods requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods = null;
            
             // populate CachedMethods
            bool requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethodsIsNull = true;
            requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods = new Amazon.CloudFront.Model.CachedMethods();
            List<System.String> requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_cachedMethods_Item = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_Items != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_cachedMethods_Item = cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_Items;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_cachedMethods_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods.Items = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_cachedMethods_Item;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethodsIsNull = false;
            }
            System.Int32? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_cachedMethods_Quantity = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_cachedMethods_Quantity = cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_Quantity.Value;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_cachedMethods_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods.Quantity = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_cachedMethods_Quantity.Value;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethodsIsNull = false;
            }
             // determine if requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods should be set to null
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethodsIsNull)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods = null;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods.CachedMethods = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethodsIsNull = false;
            }
             // determine if requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods should be set to null
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethodsIsNull)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods = null;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior.AllowedMethods = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            Amazon.CloudFront.Model.TrustedSigners requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners = null;
            
             // populate TrustedSigners
            bool requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSignersIsNull = true;
            requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners = new Amazon.CloudFront.Model.TrustedSigners();
            System.Boolean? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Enabled = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners_Enabled != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Enabled = cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners_Enabled.Value;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Enabled != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners.Enabled = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Enabled.Value;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSignersIsNull = false;
            }
            List<System.String> requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Item = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners_Items != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Item = cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners_Items;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners.Items = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Item;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSignersIsNull = false;
            }
            System.Int32? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Quantity = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Quantity = cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners_Quantity.Value;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners.Quantity = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Quantity.Value;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSignersIsNull = false;
            }
             // determine if requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners should be set to null
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSignersIsNull)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners = null;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior.TrustedSigners = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            Amazon.CloudFront.Model.ForwardedValues requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues = null;
            
             // populate ForwardedValues
            bool requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValuesIsNull = true;
            requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues = new Amazon.CloudFront.Model.ForwardedValues();
            System.Boolean? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_forwardedValues_QueryString = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryString != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_forwardedValues_QueryString = cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryString.Value;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_forwardedValues_QueryString != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues.QueryString = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_forwardedValues_QueryString.Value;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValuesIsNull = false;
            }
            Amazon.CloudFront.Model.CookiePreference requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies = null;
            
             // populate Cookies
            bool requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_CookiesIsNull = true;
            requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies = new Amazon.CloudFront.Model.CookiePreference();
            Amazon.CloudFront.ItemSelection requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_cookies_Forward = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_Forward != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_cookies_Forward = cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_Forward;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_cookies_Forward != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies.Forward = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_cookies_Forward;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_CookiesIsNull = false;
            }
            Amazon.CloudFront.Model.CookieNames requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames = null;
            
             // populate WhitelistedNames
            bool requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNamesIsNull = true;
            requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames = new Amazon.CloudFront.Model.CookieNames();
            List<System.String> requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_whitelistedNames_Item = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_Items != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_whitelistedNames_Item = cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_Items;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_whitelistedNames_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames.Items = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_whitelistedNames_Item;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNamesIsNull = false;
            }
            System.Int32? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_whitelistedNames_Quantity = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_whitelistedNames_Quantity = cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_Quantity.Value;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_whitelistedNames_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames.Quantity = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_whitelistedNames_Quantity.Value;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNamesIsNull = false;
            }
             // determine if requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames should be set to null
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNamesIsNull)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames = null;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies.WhitelistedNames = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_CookiesIsNull = false;
            }
             // determine if requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies should be set to null
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_CookiesIsNull)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies = null;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues.Cookies = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValuesIsNull = false;
            }
            Amazon.CloudFront.Model.Headers requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers = null;
            
             // populate Headers
            bool requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_HeadersIsNull = true;
            requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers = new Amazon.CloudFront.Model.Headers();
            List<System.String> requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_headers_Item = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_Items != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_headers_Item = cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_Items;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_headers_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers.Items = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_headers_Item;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_HeadersIsNull = false;
            }
            System.Int32? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_headers_Quantity = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_headers_Quantity = cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_Quantity.Value;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_headers_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers.Quantity = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_headers_Quantity.Value;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_HeadersIsNull = false;
            }
             // determine if requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers should be set to null
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_HeadersIsNull)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers = null;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues.Headers = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValuesIsNull = false;
            }
            Amazon.CloudFront.Model.QueryStringCacheKeys requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys = null;
            
             // populate QueryStringCacheKeys
            bool requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeysIsNull = true;
            requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys = new Amazon.CloudFront.Model.QueryStringCacheKeys();
            List<System.String> requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_queryStringCacheKeys_Item = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_Items != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_queryStringCacheKeys_Item = cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_Items;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_queryStringCacheKeys_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys.Items = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_queryStringCacheKeys_Item;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeysIsNull = false;
            }
            System.Int32? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_queryStringCacheKeys_Quantity = null;
            if (cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_queryStringCacheKeys_Quantity = cmdletContext.DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_Quantity.Value;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_queryStringCacheKeys_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys.Quantity = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_queryStringCacheKeys_Quantity.Value;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeysIsNull = false;
            }
             // determine if requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys should be set to null
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeysIsNull)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys = null;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues.QueryStringCacheKeys = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValuesIsNull = false;
            }
             // determine if requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues should be set to null
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValuesIsNull)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues = null;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior.ForwardedValues = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehaviorIsNull = false;
            }
             // determine if requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior should be set to null
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehaviorIsNull)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior = null;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig.DefaultCacheBehavior = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfigIsNull = false;
            }
             // determine if requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig should be set to null
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfigIsNull)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig = null;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig != null)
            {
                request.DistributionConfigWithTags.DistributionConfig = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig;
                requestDistributionConfigWithTagsIsNull = false;
            }
             // determine if request.DistributionConfigWithTags should be set to null
            if (requestDistributionConfigWithTagsIsNull)
            {
                request.DistributionConfigWithTags = null;
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
        
        private Amazon.CloudFront.Model.CreateDistributionWithTagsResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.CreateDistributionWithTagsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "CreateDistributionWithTags");
            try
            {
                #if DESKTOP
                return client.CreateDistributionWithTags(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateDistributionWithTagsAsync(request);
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
            public List<System.String> DistributionConfigWithTags_DistributionConfig_Aliases_Items { get; set; }
            public System.Int32? DistributionConfigWithTags_DistributionConfig_Aliases_Quantity { get; set; }
            public List<Amazon.CloudFront.Model.CacheBehavior> DistributionConfigWithTags_DistributionConfig_CacheBehaviors_Items { get; set; }
            public System.Int32? DistributionConfigWithTags_DistributionConfig_CacheBehaviors_Quantity { get; set; }
            public System.String DistributionConfigWithTags_DistributionConfig_CallerReference { get; set; }
            public System.String DistributionConfigWithTags_DistributionConfig_Comment { get; set; }
            public List<Amazon.CloudFront.Model.CustomErrorResponse> DistributionConfigWithTags_DistributionConfig_CustomErrorResponses_Items { get; set; }
            public System.Int32? DistributionConfigWithTags_DistributionConfig_CustomErrorResponses_Quantity { get; set; }
            public List<System.String> DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_Items { get; set; }
            public System.Int32? DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_Quantity { get; set; }
            public List<System.String> DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_Items { get; set; }
            public System.Int32? DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_Quantity { get; set; }
            public System.Boolean? DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_Compress { get; set; }
            public System.Int64? DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_DefaultTTL { get; set; }
            public Amazon.CloudFront.ItemSelection DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_Forward { get; set; }
            public List<System.String> DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_Items { get; set; }
            public System.Int32? DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_Quantity { get; set; }
            public List<System.String> DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_Items { get; set; }
            public System.Int32? DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_Quantity { get; set; }
            public System.Boolean? DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryString { get; set; }
            public List<System.String> DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_Items { get; set; }
            public System.Int32? DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_Quantity { get; set; }
            public List<Amazon.CloudFront.Model.LambdaFunctionAssociation> DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_Items { get; set; }
            public System.Int32? DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_Quantity { get; set; }
            public System.Int64? DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_MaxTTL { get; set; }
            public System.Int64? DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_MinTTL { get; set; }
            public System.Boolean? DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_SmoothStreaming { get; set; }
            public System.String DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TargetOriginId { get; set; }
            public System.Boolean? DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners_Enabled { get; set; }
            public List<System.String> DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners_Items { get; set; }
            public System.Int32? DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners_Quantity { get; set; }
            public Amazon.CloudFront.ViewerProtocolPolicy DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ViewerProtocolPolicy { get; set; }
            public System.String DistributionConfigWithTags_DistributionConfig_DefaultRootObject { get; set; }
            public System.Boolean? DistributionConfigWithTags_DistributionConfig_Enabled { get; set; }
            public Amazon.CloudFront.HttpVersion DistributionConfigWithTags_DistributionConfig_HttpVersion { get; set; }
            public System.Boolean? DistributionConfigWithTags_DistributionConfig_IsIPV6Enabled { get; set; }
            public System.String DistributionConfigWithTags_DistributionConfig_Logging_Bucket { get; set; }
            public System.Boolean? DistributionConfigWithTags_DistributionConfig_Logging_Enabled { get; set; }
            public System.Boolean? DistributionConfigWithTags_DistributionConfig_Logging_IncludeCookies { get; set; }
            public System.String DistributionConfigWithTags_DistributionConfig_Logging_Prefix { get; set; }
            public List<Amazon.CloudFront.Model.Origin> DistributionConfigWithTags_DistributionConfig_Origins_Items { get; set; }
            public System.Int32? DistributionConfigWithTags_DistributionConfig_Origins_Quantity { get; set; }
            public Amazon.CloudFront.PriceClass DistributionConfigWithTags_DistributionConfig_PriceClass { get; set; }
            public List<System.String> DistributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_Items { get; set; }
            public System.Int32? DistributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_Quantity { get; set; }
            public Amazon.CloudFront.GeoRestrictionType DistributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_RestrictionType { get; set; }
            public System.String DistributionConfigWithTags_DistributionConfig_ViewerCertificate_ACMCertificateArn { get; set; }
            public System.String DistributionConfigWithTags_DistributionConfig_ViewerCertificate_Certificate { get; set; }
            public Amazon.CloudFront.CertificateSource DistributionConfigWithTags_DistributionConfig_ViewerCertificate_CertificateSource { get; set; }
            public System.Boolean? DistributionConfigWithTags_DistributionConfig_ViewerCertificate_CloudFrontDefaultCertificate { get; set; }
            public System.String DistributionConfigWithTags_DistributionConfig_ViewerCertificate_IAMCertificateId { get; set; }
            public Amazon.CloudFront.MinimumProtocolVersion DistributionConfigWithTags_DistributionConfig_ViewerCertificate_MinimumProtocolVersion { get; set; }
            public Amazon.CloudFront.SSLSupportMethod DistributionConfigWithTags_DistributionConfig_ViewerCertificate_SSLSupportMethod { get; set; }
            public System.String DistributionConfigWithTags_DistributionConfig_WebACLId { get; set; }
            public List<Amazon.CloudFront.Model.Tag> DistributionConfigWithTags_Tags_Items { get; set; }
        }
        
    }
}
