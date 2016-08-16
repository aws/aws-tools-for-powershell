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
    [AWSCmdlet("Invokes the CreateDistributionWithTags operation against Amazon CloudFront.", Operation = new[] {"CreateDistributionWithTags"})]
    [AWSCmdletOutput("Amazon.CloudFront.Model.CreateDistributionWithTagsResponse",
        "This cmdlet returns a Amazon.CloudFront.Model.CreateDistributionWithTagsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCFDistributionWithTagCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        #region Parameter ViewerCertificate_ACMCertificateArn
        /// <summary>
        /// <para>
        /// If you want viewers to use HTTPS to
        /// request your objects and you're using an alternate domain name in your object URLs
        /// (for example, https://example.com/logo.jpg), specify the ACM certificate ARN of the
        /// custom viewer certificate for this distribution. Specify either this value, IAMCertificateId,
        /// or CloudFrontDefaultCertificate.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_ViewerCertificate_ACMCertificateArn")]
        public System.String ViewerCertificate_ACMCertificateArn { get; set; }
        #endregion
        
        #region Parameter Logging_Bucket
        /// <summary>
        /// <para>
        /// The Amazon S3 bucket to store the access logs in,
        /// for example, myawslogbucket.s3.amazonaws.com.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_Logging_Bucket")]
        public System.String Logging_Bucket { get; set; }
        #endregion
        
        #region Parameter DistributionConfig_CallerReference
        /// <summary>
        /// <para>
        /// A unique number that ensures the request
        /// can't be replayed. If the CallerReference is new (no matter the content of the DistributionConfig
        /// object), a new distribution is created. If the CallerReference is a value you already
        /// sent in a previous request to create a distribution, and the content of the DistributionConfig
        /// is identical to the original request (ignoring white space), the response includes
        /// the same information returned to the original request. If the CallerReference is a
        /// value you already sent in a previous request to create a distribution but the content
        /// of the DistributionConfig is different from the original request, CloudFront returns
        /// a DistributionAlreadyExists error.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_CallerReference")]
        public System.String DistributionConfig_CallerReference { get; set; }
        #endregion
        
        #region Parameter ViewerCertificate_Certificate
        /// <summary>
        /// <para>
        /// Note: this field is deprecated. Please use
        /// one of [ACMCertificateArn, IAMCertificateId, CloudFrontDefaultCertificate].
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_ViewerCertificate_Certificate")]
        public System.String ViewerCertificate_Certificate { get; set; }
        #endregion
        
        #region Parameter ViewerCertificate_CertificateSource
        /// <summary>
        /// <para>
        /// Note: this field is deprecated. Please
        /// use one of [ACMCertificateArn, IAMCertificateId, CloudFrontDefaultCertificate].
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
        /// If you want viewers to use
        /// HTTPS to request your objects and you're using the CloudFront domain name of your
        /// distribution in your object URLs (for example, https://d111111abcdef8.cloudfront.net/logo.jpg),
        /// set to true. Omit this value if you are setting an ACMCertificateArn or IAMCertificateId.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_ViewerCertificate_CloudFrontDefaultCertificate")]
        public System.Boolean ViewerCertificate_CloudFrontDefaultCertificate { get; set; }
        #endregion
        
        #region Parameter DistributionConfig_Comment
        /// <summary>
        /// <para>
        /// Any comments you want to include about the distribution.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_Comment")]
        public System.String DistributionConfig_Comment { get; set; }
        #endregion
        
        #region Parameter DefaultCacheBehavior_Compress
        /// <summary>
        /// <para>
        /// Whether you want CloudFront to automatically
        /// compress content for web requests that include Accept-Encoding: gzip in the request
        /// header. If so, specify true; if not, specify false. CloudFront compresses files larger
        /// than 1000 bytes and less than 1 megabyte for both Amazon S3 and custom origins. When
        /// a CloudFront edge location is unusually busy, some files might not be compressed.
        /// The value of the Content-Type header must be on the list of file types that CloudFront
        /// will compress. For the current list, see <a href="http://docs.aws.amazon.com/console/cloudfront/compressed-content">Serving
        /// Compressed Content</a> in the Amazon CloudFront Developer Guide. If you configure
        /// CloudFront to compress content, CloudFront removes the ETag response header from the
        /// objects that it compresses. The ETag header indicates that the version in a CloudFront
        /// edge cache is identical to the version on the origin server, but after compression
        /// the two versions are no longer identical. As a result, for compressed objects, CloudFront
        /// can't use the ETag header to determine whether an expired object in the CloudFront
        /// edge cache is still the latest version.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_Compress")]
        public System.Boolean DefaultCacheBehavior_Compress { get; set; }
        #endregion
        
        #region Parameter DistributionConfig_DefaultRootObject
        /// <summary>
        /// <para>
        /// The object that you want CloudFront
        /// to return (for example, index.html) when an end user requests the root URL for your
        /// distribution (http://www.example.com) instead of an object in your distribution (http://www.example.com/index.html).
        /// Specifying a default root object avoids exposing the contents of your distribution.
        /// If you don't want to specify a default root object when you create a distribution,
        /// include an empty DefaultRootObject element. To delete the default root object from
        /// an existing distribution, update the distribution configuration and include an empty
        /// DefaultRootObject element. To replace the default root object, update the distribution
        /// configuration and specify the new object.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultRootObject")]
        public System.String DistributionConfig_DefaultRootObject { get; set; }
        #endregion
        
        #region Parameter DefaultCacheBehavior_DefaultTTL
        /// <summary>
        /// <para>
        /// If you don't configure your origin to add a
        /// Cache-Control max-age directive or an Expires header, DefaultTTL is the default amount
        /// of time (in seconds) that an object is in a CloudFront cache before CloudFront forwards
        /// another request to your origin to determine whether the object has been updated. The
        /// value that you specify applies only when your origin does not add HTTP headers such
        /// as Cache-Control max-age, Cache-Control s-maxage, and Expires to objects. You can
        /// specify a value from 0 to 3,153,600,000 seconds (100 years).
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_DefaultTTL")]
        public System.Int64 DefaultCacheBehavior_DefaultTTL { get; set; }
        #endregion
        
        #region Parameter TrustedSigners_Enabled
        /// <summary>
        /// <para>
        /// Specifies whether you want to require end users
        /// to use signed URLs to access the files specified by PathPattern and TargetOriginId.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners_Enabled")]
        public System.Boolean TrustedSigners_Enabled { get; set; }
        #endregion
        
        #region Parameter DistributionConfig_Enabled
        /// <summary>
        /// <para>
        /// Whether the distribution is enabled to accept
        /// end user requests for content.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_Enabled")]
        public System.Boolean DistributionConfig_Enabled { get; set; }
        #endregion
        
        #region Parameter Logging_Enabled
        /// <summary>
        /// <para>
        /// Specifies whether you want CloudFront to save
        /// access logs to an Amazon S3 bucket. If you do not want to enable logging when you
        /// create a distribution or if you want to disable logging for an existing distribution,
        /// specify false for Enabled, and specify empty Bucket and Prefix elements. If you specify
        /// false for Enabled but you specify values for Bucket, prefix and IncludeCookies, the
        /// values are automatically deleted.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_Logging_Enabled")]
        public System.Boolean Logging_Enabled { get; set; }
        #endregion
        
        #region Parameter Cookies_Forward
        /// <summary>
        /// <para>
        /// Use this element to specify whether you want CloudFront
        /// to forward cookies to the origin that is associated with this cache behavior. You
        /// can specify all, none or whitelist. If you choose All, CloudFront forwards all cookies
        /// regardless of how many your application uses.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_Forward")]
        [AWSConstantClassSource("Amazon.CloudFront.ItemSelection")]
        public Amazon.CloudFront.ItemSelection Cookies_Forward { get; set; }
        #endregion
        
        #region Parameter ViewerCertificate_IAMCertificateId
        /// <summary>
        /// <para>
        /// If you want viewers to use HTTPS to request
        /// your objects and you're using an alternate domain name in your object URLs (for example,
        /// https://example.com/logo.jpg), specify the IAM certificate identifier of the custom
        /// viewer certificate for this distribution. Specify either this value, ACMCertificateArn,
        /// or CloudFrontDefaultCertificate.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_ViewerCertificate_IAMCertificateId")]
        public System.String ViewerCertificate_IAMCertificateId { get; set; }
        #endregion
        
        #region Parameter Logging_IncludeCookie
        /// <summary>
        /// <para>
        /// Specifies whether you want CloudFront to
        /// include cookies in access logs, specify true for IncludeCookies. If you choose to
        /// include cookies in logs, CloudFront logs all cookies regardless of how you configure
        /// the cache behaviors for this distribution. If you do not want to include cookies when
        /// you create a distribution or if you want to disable include cookies for an existing
        /// distribution, specify false for IncludeCookies.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_Logging_IncludeCookies")]
        public System.Boolean Logging_IncludeCookie { get; set; }
        #endregion
        
        #region Parameter Aliases_Item
        /// <summary>
        /// <para>
        /// Optional: A complex type that contains CNAME elements,
        /// if any, for this distribution. If Quantity is 0, you can omit Items.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_Aliases_Items")]
        public System.String[] Aliases_Item { get; set; }
        #endregion
        
        #region Parameter CacheBehaviors_Item
        /// <summary>
        /// <para>
        /// Optional: A complex type that contains cache behaviors
        /// for this distribution. If Quantity is 0, you can omit Items.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_CacheBehaviors_Items")]
        public Amazon.CloudFront.Model.CacheBehavior[] CacheBehaviors_Item { get; set; }
        #endregion
        
        #region Parameter CustomErrorResponses_Item
        /// <summary>
        /// <para>
        /// Optional: A complex type that contains custom error
        /// responses for this distribution. If Quantity is 0, you can omit Items.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_CustomErrorResponses_Items")]
        public Amazon.CloudFront.Model.CustomErrorResponse[] CustomErrorResponses_Item { get; set; }
        #endregion
        
        #region Parameter CachedMethods_Item
        /// <summary>
        /// <para>
        /// A complex type that contains the HTTP methods that
        /// you want CloudFront to cache responses to.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_Items")]
        public System.String[] CachedMethods_Item { get; set; }
        #endregion
        
        #region Parameter AllowedMethods_Item
        /// <summary>
        /// <para>
        /// A complex type that contains the HTTP methods that
        /// you want CloudFront to process and forward to your origin.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_Items")]
        public System.String[] AllowedMethods_Item { get; set; }
        #endregion
        
        #region Parameter WhitelistedNames_Item
        /// <summary>
        /// <para>
        /// Optional: A complex type that contains whitelisted
        /// cookies for this cache behavior. If Quantity is 0, you can omit Items.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_Items")]
        public System.String[] WhitelistedNames_Item { get; set; }
        #endregion
        
        #region Parameter Headers_Item
        /// <summary>
        /// <para>
        /// Optional: A complex type that contains a Name element
        /// for each header that you want CloudFront to forward to the origin and to vary on for
        /// this cache behavior. If Quantity is 0, omit Items.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_Items")]
        public System.String[] Headers_Item { get; set; }
        #endregion
        
        #region Parameter TrustedSigners_Item
        /// <summary>
        /// <para>
        /// Optional: A complex type that contains trusted signers
        /// for this cache behavior. If Quantity is 0, you can omit Items.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners_Items")]
        public System.String[] TrustedSigners_Item { get; set; }
        #endregion
        
        #region Parameter Origins_Item
        /// <summary>
        /// <para>
        /// A complex type that contains origins for this distribution.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_Origins_Items")]
        public Amazon.CloudFront.Model.Origin[] Origins_Item { get; set; }
        #endregion
        
        #region Parameter GeoRestriction_Item
        /// <summary>
        /// <para>
        /// A complex type that contains a Location element
        /// for each country in which you want CloudFront either to distribute your content (whitelist)
        /// or not distribute your content (blacklist). The Location element is a two-letter,
        /// uppercase country code for a country that you want to include in your blacklist or
        /// whitelist. Include one Location element for each country. CloudFront and MaxMind both
        /// use ISO 3166 country codes. For the current list of countries and the corresponding
        /// codes, see ISO 3166-1-alpha-2 code on the International Organization for Standardization
        /// website. You can also refer to the country list in the CloudFront console, which includes
        /// both country names and codes.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_Items")]
        public System.String[] GeoRestriction_Item { get; set; }
        #endregion
        
        #region Parameter Tags_Item
        /// <summary>
        /// <para>
        /// A complex type that contains Tag elements
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_Tags_Items")]
        public Amazon.CloudFront.Model.Tag[] Tags_Item { get; set; }
        #endregion
        
        #region Parameter DefaultCacheBehavior_MaxTTL
        /// <summary>
        /// <para>
        /// The maximum amount of time (in seconds) that an
        /// object is in a CloudFront cache before CloudFront forwards another request to your
        /// origin to determine whether the object has been updated. The value that you specify
        /// applies only when your origin adds HTTP headers such as Cache-Control max-age, Cache-Control
        /// s-maxage, and Expires to objects. You can specify a value from 0 to 3,153,600,000
        /// seconds (100 years).
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_MaxTTL")]
        public System.Int64 DefaultCacheBehavior_MaxTTL { get; set; }
        #endregion
        
        #region Parameter ViewerCertificate_MinimumProtocolVersion
        /// <summary>
        /// <para>
        /// Specify the minimum version of
        /// the SSL protocol that you want CloudFront to use, SSLv3 or TLSv1, for HTTPS connections.
        /// CloudFront will serve your objects only to browsers or devices that support at least
        /// the SSL version that you specify. The TLSv1 protocol is more secure, so we recommend
        /// that you specify SSLv3 only if your users are using browsers or devices that don't
        /// support TLSv1. If you're using a custom certificate (if you specify a value for IAMCertificateId)
        /// and if you're using dedicated IP (if you specify vip for SSLSupportMethod), you can
        /// choose SSLv3 or TLSv1 as the MinimumProtocolVersion. If you're using a custom certificate
        /// (if you specify a value for IAMCertificateId) and if you're using SNI (if you specify
        /// sni-only for SSLSupportMethod), you must specify TLSv1 for MinimumProtocolVersion.
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
        /// The minimum amount of time that you want objects
        /// to stay in CloudFront caches before CloudFront queries your origin to see whether
        /// the object has been updated.You can specify a value from 0 to 3,153,600,000 seconds
        /// (100 years).
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_MinTTL")]
        public System.Int64 DefaultCacheBehavior_MinTTL { get; set; }
        #endregion
        
        #region Parameter Logging_Prefix
        /// <summary>
        /// <para>
        /// An optional string that you want CloudFront to
        /// prefix to the access log filenames for this distribution, for example, myprefix/.
        /// If you want to enable logging, but you do not want to specify a prefix, you still
        /// must include an empty Prefix element in the Logging element.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_Logging_Prefix")]
        public System.String Logging_Prefix { get; set; }
        #endregion
        
        #region Parameter DistributionConfig_PriceClass
        /// <summary>
        /// <para>
        /// A complex type that contains information about
        /// price class for this distribution.
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
        /// The number of CNAMEs, if any, for this distribution.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_Aliases_Quantity")]
        public System.Int32 Aliases_Quantity { get; set; }
        #endregion
        
        #region Parameter CacheBehaviors_Quantity
        /// <summary>
        /// <para>
        /// The number of cache behaviors for this distribution.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_CacheBehaviors_Quantity")]
        public System.Int32 CacheBehaviors_Quantity { get; set; }
        #endregion
        
        #region Parameter CustomErrorResponses_Quantity
        /// <summary>
        /// <para>
        /// The number of custom error responses for this
        /// distribution.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_CustomErrorResponses_Quantity")]
        public System.Int32 CustomErrorResponses_Quantity { get; set; }
        #endregion
        
        #region Parameter CachedMethods_Quantity
        /// <summary>
        /// <para>
        /// The number of HTTP methods for which you want
        /// CloudFront to cache responses. Valid values are 2 (for caching responses to GET and
        /// HEAD requests) and 3 (for caching responses to GET, HEAD, and OPTIONS requests).
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_Quantity")]
        public System.Int32 CachedMethods_Quantity { get; set; }
        #endregion
        
        #region Parameter AllowedMethods_Quantity
        /// <summary>
        /// <para>
        /// The number of HTTP methods that you want CloudFront
        /// to forward to your origin. Valid values are 2 (for GET and HEAD requests), 3 (for
        /// GET, HEAD and OPTIONS requests) and 7 (for GET, HEAD, OPTIONS, PUT, PATCH, POST, and
        /// DELETE requests).
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_Quantity")]
        public System.Int32 AllowedMethods_Quantity { get; set; }
        #endregion
        
        #region Parameter WhitelistedNames_Quantity
        /// <summary>
        /// <para>
        /// The number of whitelisted cookies for this cache
        /// behavior.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_Quantity")]
        public System.Int32 WhitelistedNames_Quantity { get; set; }
        #endregion
        
        #region Parameter Headers_Quantity
        /// <summary>
        /// <para>
        /// The number of different headers that you want
        /// CloudFront to forward to the origin and to vary on for this cache behavior. The maximum
        /// number of headers that you can specify by name is 10. If you want CloudFront to forward
        /// all headers to the origin and vary on all of them, specify 1 for Quantity and * for
        /// Name. If you don't want CloudFront to forward any additional headers to the origin
        /// or to vary on any headers, specify 0 for Quantity and omit Items.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_Quantity")]
        public System.Int32 Headers_Quantity { get; set; }
        #endregion
        
        #region Parameter TrustedSigners_Quantity
        /// <summary>
        /// <para>
        /// The number of trusted signers for this cache
        /// behavior.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners_Quantity")]
        public System.Int32 TrustedSigners_Quantity { get; set; }
        #endregion
        
        #region Parameter Origins_Quantity
        /// <summary>
        /// <para>
        /// The number of origins for this distribution.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_Origins_Quantity")]
        public System.Int32 Origins_Quantity { get; set; }
        #endregion
        
        #region Parameter GeoRestriction_Quantity
        /// <summary>
        /// <para>
        /// When geo restriction is enabled, this is the
        /// number of countries in your whitelist or blacklist. Otherwise, when it is not enabled,
        /// Quantity is 0, and you can omit Items.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_Quantity")]
        public System.Int32 GeoRestriction_Quantity { get; set; }
        #endregion
        
        #region Parameter ForwardedValues_QueryString
        /// <summary>
        /// <para>
        /// Indicates whether you want CloudFront to forward
        /// query strings to the origin that is associated with this cache behavior. If so, specify
        /// true; if not, specify false.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryString")]
        public System.Boolean ForwardedValues_QueryString { get; set; }
        #endregion
        
        #region Parameter GeoRestriction_RestrictionType
        /// <summary>
        /// <para>
        /// The method that you want to use to restrict
        /// distribution of your content by country: - none: No geo restriction is enabled, meaning
        /// access to content is not restricted by client geo location. - blacklist: The Location
        /// elements specify the countries in which you do not want CloudFront to distribute your
        /// content. - whitelist: The Location elements specify the countries in which you want
        /// CloudFront to distribute your content.
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
        /// Indicates whether you want to distribute
        /// media files in Microsoft Smooth Streaming format using the origin that is associated
        /// with this cache behavior. If so, specify true; if not, specify false.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_SmoothStreaming")]
        public System.Boolean DefaultCacheBehavior_SmoothStreaming { get; set; }
        #endregion
        
        #region Parameter ViewerCertificate_SSLSupportMethod
        /// <summary>
        /// <para>
        /// If you specify a value for IAMCertificateId,
        /// you must also specify how you want CloudFront to serve HTTPS requests. Valid values
        /// are vip and sni-only. If you specify vip, CloudFront uses dedicated IP addresses for
        /// your content and can respond to HTTPS requests from any viewer. However, you must
        /// request permission to use this feature, and you incur additional monthly charges.
        /// If you specify sni-only, CloudFront can only respond to HTTPS requests from viewers
        /// that support Server Name Indication (SNI). All modern browsers support SNI, but some
        /// browsers still in use don't support SNI. Do not specify a value for SSLSupportMethod
        /// if you specified true for CloudFrontDefaultCertificate.
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
        /// The value of ID for the origin that you
        /// want CloudFront to route requests to when a request matches the path pattern either
        /// for a cache behavior or for the default cache behavior.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TargetOriginId")]
        public System.String DefaultCacheBehavior_TargetOriginId { get; set; }
        #endregion
        
        #region Parameter DefaultCacheBehavior_ViewerProtocolPolicy
        /// <summary>
        /// <para>
        /// Use this element to specify the protocol
        /// that users can use to access the files in the origin specified by TargetOriginId when
        /// a request matches the path pattern in PathPattern. If you want CloudFront to allow
        /// end users to use any available protocol, specify allow-all. If you want CloudFront
        /// to require HTTPS, specify https. If you want CloudFront to respond to an HTTP request
        /// with an HTTP status code of 301 (Moved Permanently) and the HTTPS URL, specify redirect-to-https.
        /// The viewer then resubmits the request using the HTTPS URL.
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
        /// (Optional) If you're using AWS WAF to filter
        /// CloudFront requests, the Id of the AWS WAF web ACL that is associated with the distribution.
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
        
        private static Amazon.CloudFront.Model.CreateDistributionWithTagsResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.CreateDistributionWithTagsRequest request)
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
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
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
