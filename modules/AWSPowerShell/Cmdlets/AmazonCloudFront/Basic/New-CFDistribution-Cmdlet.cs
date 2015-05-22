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
    /// Create a new distribution.
    /// </summary>
    [Cmdlet("New", "CFDistribution", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudFront.Model.CreateDistributionResponse")]
    [AWSCmdlet("Invokes the CreateDistribution operation against Amazon CloudFront.", Operation = new[] {"CreateDistribution"})]
    [AWSCmdletOutput("Amazon.CloudFront.Model.CreateDistributionResponse",
        "This cmdlet returns a CreateDistributionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewCFDistributionCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// The Amazon S3 bucket to store the access logs in,
        /// for example, myawslogbucket.s3.amazonaws.com.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_Logging_Bucket")]
        public String Logging_Bucket { get; set; }
        
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
        public String DistributionConfig_CallerReference { get; set; }
        
        /// <summary>
        /// <para>
        /// If you want viewers to use
        /// HTTPS to request your objects and you're using the CloudFront domain name of your
        /// distribution in your object URLs (for example, https://d111111abcdef8.cloudfront.net/logo.jpg),
        /// set to true. Omit this value if you are setting an IAMCertificateId.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_ViewerCertificate_CloudFrontDefaultCertificate")]
        public Boolean ViewerCertificate_CloudFrontDefaultCertificate { get; set; }
        
        /// <summary>
        /// <para>
        /// Any comments you want to include about the distribution.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String DistributionConfig_Comment { get; set; }
        
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
        public String DistributionConfig_DefaultRootObject { get; set; }
        
        /// <summary>
        /// <para>
        /// Specifies whether you want to require end users
        /// to use signed URLs to access the files specified by PathPattern and TargetOriginId.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_DefaultCacheBehavior_TrustedSigners_Enabled")]
        public Boolean TrustedSigners_Enabled { get; set; }
        
        /// <summary>
        /// <para>
        /// Whether the distribution is enabled to accept
        /// end user requests for content.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean DistributionConfig_Enabled { get; set; }
        
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
        [Alias("DistributionConfig_Logging_Enabled")]
        public Boolean Logging_Enabled { get; set; }
        
        /// <summary>
        /// <para>
        /// Use this element to specify whether you want CloudFront
        /// to forward cookies to the origin that is associated with this cache behavior. You
        /// can specify all, none or whitelist. If you choose All, CloudFront forwards all cookies
        /// regardless of how many your application uses.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_Forward")]
        public ItemSelection Cookies_Forward { get; set; }
        
        /// <summary>
        /// <para>
        /// If you want viewers to use HTTPS to request
        /// your objects and you're using an alternate domain name in your object URLs (for example,
        /// https://example.com/logo.jpg), specify the IAM certificate identifier of the custom
        /// viewer certificate for this distribution. Specify either this value or CloudFrontDefaultCertificate.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_ViewerCertificate_IAMCertificateId")]
        public String ViewerCertificate_IAMCertificateId { get; set; }
        
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
        [Alias("DistributionConfig_Logging_IncludeCookies")]
        public Boolean Logging_IncludeCookies { get; set; }
        
        /// <summary>
        /// <para>
        /// Optional: A complex type that contains CNAME elements,
        /// if any, for this distribution. If Quantity is 0, you can omit Items.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_Aliases_Items")]
        public System.String[] Aliases_Item { get; set; }
        
        /// <summary>
        /// <para>
        /// Optional: A complex type that contains cache behaviors
        /// for this distribution. If Quantity is 0, you can omit Items.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_CacheBehaviors_Items")]
        public Amazon.CloudFront.Model.CacheBehavior[] CacheBehaviors_Item { get; set; }
        
        /// <summary>
        /// <para>
        /// Optional: A complex type that contains custom error
        /// responses for this distribution. If Quantity is 0, you can omit Items.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_CustomErrorResponses_Items")]
        public Amazon.CloudFront.Model.CustomErrorResponse[] CustomErrorResponses_Item { get; set; }
        
        /// <summary>
        /// <para>
        /// A complex type that contains the HTTP methods that
        /// you want CloudFront to cache responses to.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_Items")]
        public System.String[] CachedMethods_Item { get; set; }
        
        /// <summary>
        /// <para>
        /// A complex type that contains the HTTP methods that
        /// you want CloudFront to process and forward to your origin.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_DefaultCacheBehavior_AllowedMethods_Items")]
        public System.String[] AllowedMethods_Item { get; set; }
        
        /// <summary>
        /// <para>
        /// Optional: A complex type that contains whitelisted
        /// cookies for this cache behavior. If Quantity is 0, you can omit Items.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_Items")]
        public System.String[] WhitelistedNames_Item { get; set; }
        
        /// <summary>
        /// <para>
        /// Optional: A complex type that contains a Name element
        /// for each header that you want CloudFront to forward to the origin and to vary on for
        /// this cache behavior. If Quantity is 0, omit Items.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_Items")]
        public System.String[] Headers_Item { get; set; }
        
        /// <summary>
        /// <para>
        /// Optional: A complex type that contains trusted signers
        /// for this cache behavior. If Quantity is 0, you can omit Items.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_DefaultCacheBehavior_TrustedSigners_Items")]
        public System.String[] TrustedSigners_Item { get; set; }
        
        /// <summary>
        /// <para>
        /// A complex type that contains origins for this distribution.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_Origins_Items")]
        public Amazon.CloudFront.Model.Origin[] Origins_Item { get; set; }
        
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
        [Alias("DistributionConfig_Restrictions_GeoRestriction_Items")]
        public System.String[] GeoRestriction_Item { get; set; }
        
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
        [Alias("DistributionConfig_ViewerCertificate_MinimumProtocolVersion")]
        public MinimumProtocolVersion ViewerCertificate_MinimumProtocolVersion { get; set; }
        
        /// <summary>
        /// <para>
        /// The minimum amount of time that you want objects
        /// to stay in CloudFront caches before CloudFront queries your origin to see whether
        /// the object has been updated.You can specify a value from 0 to 3,153,600,000 seconds
        /// (100 years).
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_DefaultCacheBehavior_MinTTL")]
        public Int64 DefaultCacheBehavior_MinTTL { get; set; }
        
        /// <summary>
        /// <para>
        /// An optional string that you want CloudFront to
        /// prefix to the access log filenames for this distribution, for example, myprefix/.
        /// If you want to enable logging, but you do not want to specify a prefix, you still
        /// must include an empty Prefix element in the Logging element.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_Logging_Prefix")]
        public String Logging_Prefix { get; set; }
        
        /// <summary>
        /// <para>
        /// A complex type that contains information about
        /// price class for this distribution.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public PriceClass DistributionConfig_PriceClass { get; set; }
        
        /// <summary>
        /// <para>
        /// The number of CNAMEs, if any, for this distribution.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_Aliases_Quantity")]
        public Int32 Aliases_Quantity { get; set; }
        
        /// <summary>
        /// <para>
        /// The number of cache behaviors for this distribution.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_CacheBehaviors_Quantity")]
        public Int32 CacheBehaviors_Quantity { get; set; }
        
        /// <summary>
        /// <para>
        /// The number of custom error responses for this
        /// distribution.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_CustomErrorResponses_Quantity")]
        public Int32 CustomErrorResponses_Quantity { get; set; }
        
        /// <summary>
        /// <para>
        /// The number of HTTP methods for which you want
        /// CloudFront to cache responses. Valid values are 2 (for caching responses to GET and
        /// HEAD requests) and 3 (for caching responses to GET, HEAD, and OPTIONS requests).
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_Quantity")]
        public Int32 CachedMethods_Quantity { get; set; }
        
        /// <summary>
        /// <para>
        /// The number of HTTP methods that you want CloudFront
        /// to forward to your origin. Valid values are 2 (for GET and HEAD requests), 3 (for
        /// GET, HEAD and OPTIONS requests) and 7 (for GET, HEAD, OPTIONS, PUT, PATCH, POST, and
        /// DELETE requests).
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_DefaultCacheBehavior_AllowedMethods_Quantity")]
        public Int32 AllowedMethods_Quantity { get; set; }
        
        /// <summary>
        /// <para>
        /// The number of whitelisted cookies for this cache
        /// behavior.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_Quantity")]
        public Int32 WhitelistedNames_Quantity { get; set; }
        
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
        [Alias("DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_Quantity")]
        public Int32 Headers_Quantity { get; set; }
        
        /// <summary>
        /// <para>
        /// The number of trusted signers for this cache
        /// behavior.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_DefaultCacheBehavior_TrustedSigners_Quantity")]
        public Int32 TrustedSigners_Quantity { get; set; }
        
        /// <summary>
        /// <para>
        /// The number of origins for this distribution.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_Origins_Quantity")]
        public Int32 Origins_Quantity { get; set; }
        
        /// <summary>
        /// <para>
        /// When geo restriction is enabled, this is the
        /// number of countries in your whitelist or blacklist. Otherwise, when it is not enabled,
        /// Quantity is 0, and you can omit Items.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_Restrictions_GeoRestriction_Quantity")]
        public Int32 GeoRestriction_Quantity { get; set; }
        
        /// <summary>
        /// <para>
        /// Indicates whether you want CloudFront to forward
        /// query strings to the origin that is associated with this cache behavior. If so, specify
        /// true; if not, specify false.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryString")]
        public Boolean ForwardedValues_QueryString { get; set; }
        
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
        [Alias("DistributionConfig_Restrictions_GeoRestriction_RestrictionType")]
        public GeoRestrictionType GeoRestriction_RestrictionType { get; set; }
        
        /// <summary>
        /// <para>
        /// Indicates whether you want to distribute
        /// media files in Microsoft Smooth Streaming format using the origin that is associated
        /// with this cache behavior. If so, specify true; if not, specify false.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_DefaultCacheBehavior_SmoothStreaming")]
        public Boolean DefaultCacheBehavior_SmoothStreaming { get; set; }
        
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
        [Alias("DistributionConfig_ViewerCertificate_SSLSupportMethod")]
        public SSLSupportMethod ViewerCertificate_SSLSupportMethod { get; set; }
        
        /// <summary>
        /// <para>
        /// The value of ID for the origin that you
        /// want CloudFront to route requests to when a request matches the path pattern either
        /// for a cache behavior or for the default cache behavior.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DistributionConfig_DefaultCacheBehavior_TargetOriginId")]
        public String DefaultCacheBehavior_TargetOriginId { get; set; }
        
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
        [Alias("DistributionConfig_DefaultCacheBehavior_ViewerProtocolPolicy")]
        public ViewerProtocolPolicy DefaultCacheBehavior_ViewerProtocolPolicy { get; set; }
        
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
            
            if (this.Aliases_Item != null)
            {
                context.DistributionConfig_Aliases_Items = new List<String>(this.Aliases_Item);
            }
            if (ParameterWasBound("Aliases_Quantity"))
                context.DistributionConfig_Aliases_Quantity = this.Aliases_Quantity;
            if (this.CacheBehaviors_Item != null)
            {
                context.DistributionConfig_CacheBehaviors_Items = new List<CacheBehavior>(this.CacheBehaviors_Item);
            }
            if (ParameterWasBound("CacheBehaviors_Quantity"))
                context.DistributionConfig_CacheBehaviors_Quantity = this.CacheBehaviors_Quantity;
            context.DistributionConfig_CallerReference = this.DistributionConfig_CallerReference;
            context.DistributionConfig_Comment = this.DistributionConfig_Comment;
            if (this.CustomErrorResponses_Item != null)
            {
                context.DistributionConfig_CustomErrorResponses_Items = new List<CustomErrorResponse>(this.CustomErrorResponses_Item);
            }
            if (ParameterWasBound("CustomErrorResponses_Quantity"))
                context.DistributionConfig_CustomErrorResponses_Quantity = this.CustomErrorResponses_Quantity;
            if (this.CachedMethods_Item != null)
            {
                context.DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_Items = new List<String>(this.CachedMethods_Item);
            }
            if (ParameterWasBound("CachedMethods_Quantity"))
                context.DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_Quantity = this.CachedMethods_Quantity;
            if (this.AllowedMethods_Item != null)
            {
                context.DistributionConfig_DefaultCacheBehavior_AllowedMethods_Items = new List<String>(this.AllowedMethods_Item);
            }
            if (ParameterWasBound("AllowedMethods_Quantity"))
                context.DistributionConfig_DefaultCacheBehavior_AllowedMethods_Quantity = this.AllowedMethods_Quantity;
            context.DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_Forward = this.Cookies_Forward;
            if (this.WhitelistedNames_Item != null)
            {
                context.DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_Items = new List<String>(this.WhitelistedNames_Item);
            }
            if (ParameterWasBound("WhitelistedNames_Quantity"))
                context.DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_Quantity = this.WhitelistedNames_Quantity;
            if (this.Headers_Item != null)
            {
                context.DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_Items = new List<String>(this.Headers_Item);
            }
            if (ParameterWasBound("Headers_Quantity"))
                context.DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_Quantity = this.Headers_Quantity;
            if (ParameterWasBound("ForwardedValues_QueryString"))
                context.DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryString = this.ForwardedValues_QueryString;
            if (ParameterWasBound("DefaultCacheBehavior_MinTTL"))
                context.DistributionConfig_DefaultCacheBehavior_MinTTL = this.DefaultCacheBehavior_MinTTL;
            if (ParameterWasBound("DefaultCacheBehavior_SmoothStreaming"))
                context.DistributionConfig_DefaultCacheBehavior_SmoothStreaming = this.DefaultCacheBehavior_SmoothStreaming;
            context.DistributionConfig_DefaultCacheBehavior_TargetOriginId = this.DefaultCacheBehavior_TargetOriginId;
            if (ParameterWasBound("TrustedSigners_Enabled"))
                context.DistributionConfig_DefaultCacheBehavior_TrustedSigners_Enabled = this.TrustedSigners_Enabled;
            if (this.TrustedSigners_Item != null)
            {
                context.DistributionConfig_DefaultCacheBehavior_TrustedSigners_Items = new List<String>(this.TrustedSigners_Item);
            }
            if (ParameterWasBound("TrustedSigners_Quantity"))
                context.DistributionConfig_DefaultCacheBehavior_TrustedSigners_Quantity = this.TrustedSigners_Quantity;
            context.DistributionConfig_DefaultCacheBehavior_ViewerProtocolPolicy = this.DefaultCacheBehavior_ViewerProtocolPolicy;
            context.DistributionConfig_DefaultRootObject = this.DistributionConfig_DefaultRootObject;
            if (ParameterWasBound("DistributionConfig_Enabled"))
                context.DistributionConfig_Enabled = this.DistributionConfig_Enabled;
            context.DistributionConfig_Logging_Bucket = this.Logging_Bucket;
            if (ParameterWasBound("Logging_Enabled"))
                context.DistributionConfig_Logging_Enabled = this.Logging_Enabled;
            if (ParameterWasBound("Logging_IncludeCookies"))
                context.DistributionConfig_Logging_IncludeCookies = this.Logging_IncludeCookies;
            context.DistributionConfig_Logging_Prefix = this.Logging_Prefix;
            if (this.Origins_Item != null)
            {
                context.DistributionConfig_Origins_Items = new List<Origin>(this.Origins_Item);
            }
            if (ParameterWasBound("Origins_Quantity"))
                context.DistributionConfig_Origins_Quantity = this.Origins_Quantity;
            context.DistributionConfig_PriceClass = this.DistributionConfig_PriceClass;
            if (this.GeoRestriction_Item != null)
            {
                context.DistributionConfig_Restrictions_GeoRestriction_Items = new List<String>(this.GeoRestriction_Item);
            }
            if (ParameterWasBound("GeoRestriction_Quantity"))
                context.DistributionConfig_Restrictions_GeoRestriction_Quantity = this.GeoRestriction_Quantity;
            context.DistributionConfig_Restrictions_GeoRestriction_RestrictionType = this.GeoRestriction_RestrictionType;
            if (ParameterWasBound("ViewerCertificate_CloudFrontDefaultCertificate"))
                context.DistributionConfig_ViewerCertificate_CloudFrontDefaultCertificate = this.ViewerCertificate_CloudFrontDefaultCertificate;
            context.DistributionConfig_ViewerCertificate_IAMCertificateId = this.ViewerCertificate_IAMCertificateId;
            context.DistributionConfig_ViewerCertificate_MinimumProtocolVersion = this.ViewerCertificate_MinimumProtocolVersion;
            context.DistributionConfig_ViewerCertificate_SSLSupportMethod = this.ViewerCertificate_SSLSupportMethod;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new CreateDistributionRequest();
            
            
             // populate DistributionConfig
            bool requestDistributionConfigIsNull = true;
            request.DistributionConfig = new DistributionConfig();
            String requestDistributionConfig_distributionConfig_CallerReference = null;
            if (cmdletContext.DistributionConfig_CallerReference != null)
            {
                requestDistributionConfig_distributionConfig_CallerReference = cmdletContext.DistributionConfig_CallerReference;
            }
            if (requestDistributionConfig_distributionConfig_CallerReference != null)
            {
                request.DistributionConfig.CallerReference = requestDistributionConfig_distributionConfig_CallerReference;
                requestDistributionConfigIsNull = false;
            }
            String requestDistributionConfig_distributionConfig_Comment = null;
            if (cmdletContext.DistributionConfig_Comment != null)
            {
                requestDistributionConfig_distributionConfig_Comment = cmdletContext.DistributionConfig_Comment;
            }
            if (requestDistributionConfig_distributionConfig_Comment != null)
            {
                request.DistributionConfig.Comment = requestDistributionConfig_distributionConfig_Comment;
                requestDistributionConfigIsNull = false;
            }
            String requestDistributionConfig_distributionConfig_DefaultRootObject = null;
            if (cmdletContext.DistributionConfig_DefaultRootObject != null)
            {
                requestDistributionConfig_distributionConfig_DefaultRootObject = cmdletContext.DistributionConfig_DefaultRootObject;
            }
            if (requestDistributionConfig_distributionConfig_DefaultRootObject != null)
            {
                request.DistributionConfig.DefaultRootObject = requestDistributionConfig_distributionConfig_DefaultRootObject;
                requestDistributionConfigIsNull = false;
            }
            Boolean? requestDistributionConfig_distributionConfig_Enabled = null;
            if (cmdletContext.DistributionConfig_Enabled != null)
            {
                requestDistributionConfig_distributionConfig_Enabled = cmdletContext.DistributionConfig_Enabled.Value;
            }
            if (requestDistributionConfig_distributionConfig_Enabled != null)
            {
                request.DistributionConfig.Enabled = requestDistributionConfig_distributionConfig_Enabled.Value;
                requestDistributionConfigIsNull = false;
            }
            PriceClass requestDistributionConfig_distributionConfig_PriceClass = null;
            if (cmdletContext.DistributionConfig_PriceClass != null)
            {
                requestDistributionConfig_distributionConfig_PriceClass = cmdletContext.DistributionConfig_PriceClass;
            }
            if (requestDistributionConfig_distributionConfig_PriceClass != null)
            {
                request.DistributionConfig.PriceClass = requestDistributionConfig_distributionConfig_PriceClass;
                requestDistributionConfigIsNull = false;
            }
            Restrictions requestDistributionConfig_distributionConfig_Restrictions = null;
            
             // populate Restrictions
            bool requestDistributionConfig_distributionConfig_RestrictionsIsNull = true;
            requestDistributionConfig_distributionConfig_Restrictions = new Restrictions();
            GeoRestriction requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction = null;
            
             // populate GeoRestriction
            bool requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestrictionIsNull = true;
            requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction = new GeoRestriction();
            List<String> requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction_geoRestriction_Item = null;
            if (cmdletContext.DistributionConfig_Restrictions_GeoRestriction_Items != null)
            {
                requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction_geoRestriction_Item = cmdletContext.DistributionConfig_Restrictions_GeoRestriction_Items;
            }
            if (requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction_geoRestriction_Item != null)
            {
                requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction.Items = requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction_geoRestriction_Item;
                requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestrictionIsNull = false;
            }
            Int32? requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction_geoRestriction_Quantity = null;
            if (cmdletContext.DistributionConfig_Restrictions_GeoRestriction_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction_geoRestriction_Quantity = cmdletContext.DistributionConfig_Restrictions_GeoRestriction_Quantity.Value;
            }
            if (requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction_geoRestriction_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction.Quantity = requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction_geoRestriction_Quantity.Value;
                requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestrictionIsNull = false;
            }
            GeoRestrictionType requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction_geoRestriction_RestrictionType = null;
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
            Aliases requestDistributionConfig_distributionConfig_Aliases = null;
            
             // populate Aliases
            bool requestDistributionConfig_distributionConfig_AliasesIsNull = true;
            requestDistributionConfig_distributionConfig_Aliases = new Aliases();
            List<String> requestDistributionConfig_distributionConfig_Aliases_aliases_Item = null;
            if (cmdletContext.DistributionConfig_Aliases_Items != null)
            {
                requestDistributionConfig_distributionConfig_Aliases_aliases_Item = cmdletContext.DistributionConfig_Aliases_Items;
            }
            if (requestDistributionConfig_distributionConfig_Aliases_aliases_Item != null)
            {
                requestDistributionConfig_distributionConfig_Aliases.Items = requestDistributionConfig_distributionConfig_Aliases_aliases_Item;
                requestDistributionConfig_distributionConfig_AliasesIsNull = false;
            }
            Int32? requestDistributionConfig_distributionConfig_Aliases_aliases_Quantity = null;
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
            CacheBehaviors requestDistributionConfig_distributionConfig_CacheBehaviors = null;
            
             // populate CacheBehaviors
            bool requestDistributionConfig_distributionConfig_CacheBehaviorsIsNull = true;
            requestDistributionConfig_distributionConfig_CacheBehaviors = new CacheBehaviors();
            List<CacheBehavior> requestDistributionConfig_distributionConfig_CacheBehaviors_cacheBehaviors_Item = null;
            if (cmdletContext.DistributionConfig_CacheBehaviors_Items != null)
            {
                requestDistributionConfig_distributionConfig_CacheBehaviors_cacheBehaviors_Item = cmdletContext.DistributionConfig_CacheBehaviors_Items;
            }
            if (requestDistributionConfig_distributionConfig_CacheBehaviors_cacheBehaviors_Item != null)
            {
                requestDistributionConfig_distributionConfig_CacheBehaviors.Items = requestDistributionConfig_distributionConfig_CacheBehaviors_cacheBehaviors_Item;
                requestDistributionConfig_distributionConfig_CacheBehaviorsIsNull = false;
            }
            Int32? requestDistributionConfig_distributionConfig_CacheBehaviors_cacheBehaviors_Quantity = null;
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
            CustomErrorResponses requestDistributionConfig_distributionConfig_CustomErrorResponses = null;
            
             // populate CustomErrorResponses
            bool requestDistributionConfig_distributionConfig_CustomErrorResponsesIsNull = true;
            requestDistributionConfig_distributionConfig_CustomErrorResponses = new CustomErrorResponses();
            List<CustomErrorResponse> requestDistributionConfig_distributionConfig_CustomErrorResponses_customErrorResponses_Item = null;
            if (cmdletContext.DistributionConfig_CustomErrorResponses_Items != null)
            {
                requestDistributionConfig_distributionConfig_CustomErrorResponses_customErrorResponses_Item = cmdletContext.DistributionConfig_CustomErrorResponses_Items;
            }
            if (requestDistributionConfig_distributionConfig_CustomErrorResponses_customErrorResponses_Item != null)
            {
                requestDistributionConfig_distributionConfig_CustomErrorResponses.Items = requestDistributionConfig_distributionConfig_CustomErrorResponses_customErrorResponses_Item;
                requestDistributionConfig_distributionConfig_CustomErrorResponsesIsNull = false;
            }
            Int32? requestDistributionConfig_distributionConfig_CustomErrorResponses_customErrorResponses_Quantity = null;
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
            Origins requestDistributionConfig_distributionConfig_Origins = null;
            
             // populate Origins
            bool requestDistributionConfig_distributionConfig_OriginsIsNull = true;
            requestDistributionConfig_distributionConfig_Origins = new Origins();
            List<Origin> requestDistributionConfig_distributionConfig_Origins_origins_Item = null;
            if (cmdletContext.DistributionConfig_Origins_Items != null)
            {
                requestDistributionConfig_distributionConfig_Origins_origins_Item = cmdletContext.DistributionConfig_Origins_Items;
            }
            if (requestDistributionConfig_distributionConfig_Origins_origins_Item != null)
            {
                requestDistributionConfig_distributionConfig_Origins.Items = requestDistributionConfig_distributionConfig_Origins_origins_Item;
                requestDistributionConfig_distributionConfig_OriginsIsNull = false;
            }
            Int32? requestDistributionConfig_distributionConfig_Origins_origins_Quantity = null;
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
            LoggingConfig requestDistributionConfig_distributionConfig_Logging = null;
            
             // populate Logging
            bool requestDistributionConfig_distributionConfig_LoggingIsNull = true;
            requestDistributionConfig_distributionConfig_Logging = new LoggingConfig();
            String requestDistributionConfig_distributionConfig_Logging_logging_Bucket = null;
            if (cmdletContext.DistributionConfig_Logging_Bucket != null)
            {
                requestDistributionConfig_distributionConfig_Logging_logging_Bucket = cmdletContext.DistributionConfig_Logging_Bucket;
            }
            if (requestDistributionConfig_distributionConfig_Logging_logging_Bucket != null)
            {
                requestDistributionConfig_distributionConfig_Logging.Bucket = requestDistributionConfig_distributionConfig_Logging_logging_Bucket;
                requestDistributionConfig_distributionConfig_LoggingIsNull = false;
            }
            Boolean? requestDistributionConfig_distributionConfig_Logging_logging_Enabled = null;
            if (cmdletContext.DistributionConfig_Logging_Enabled != null)
            {
                requestDistributionConfig_distributionConfig_Logging_logging_Enabled = cmdletContext.DistributionConfig_Logging_Enabled.Value;
            }
            if (requestDistributionConfig_distributionConfig_Logging_logging_Enabled != null)
            {
                requestDistributionConfig_distributionConfig_Logging.Enabled = requestDistributionConfig_distributionConfig_Logging_logging_Enabled.Value;
                requestDistributionConfig_distributionConfig_LoggingIsNull = false;
            }
            Boolean? requestDistributionConfig_distributionConfig_Logging_logging_IncludeCookies = null;
            if (cmdletContext.DistributionConfig_Logging_IncludeCookies != null)
            {
                requestDistributionConfig_distributionConfig_Logging_logging_IncludeCookies = cmdletContext.DistributionConfig_Logging_IncludeCookies.Value;
            }
            if (requestDistributionConfig_distributionConfig_Logging_logging_IncludeCookies != null)
            {
                requestDistributionConfig_distributionConfig_Logging.IncludeCookies = requestDistributionConfig_distributionConfig_Logging_logging_IncludeCookies.Value;
                requestDistributionConfig_distributionConfig_LoggingIsNull = false;
            }
            String requestDistributionConfig_distributionConfig_Logging_logging_Prefix = null;
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
            ViewerCertificate requestDistributionConfig_distributionConfig_ViewerCertificate = null;
            
             // populate ViewerCertificate
            bool requestDistributionConfig_distributionConfig_ViewerCertificateIsNull = true;
            requestDistributionConfig_distributionConfig_ViewerCertificate = new ViewerCertificate();
            Boolean? requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_CloudFrontDefaultCertificate = null;
            if (cmdletContext.DistributionConfig_ViewerCertificate_CloudFrontDefaultCertificate != null)
            {
                requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_CloudFrontDefaultCertificate = cmdletContext.DistributionConfig_ViewerCertificate_CloudFrontDefaultCertificate.Value;
            }
            if (requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_CloudFrontDefaultCertificate != null)
            {
                requestDistributionConfig_distributionConfig_ViewerCertificate.CloudFrontDefaultCertificate = requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_CloudFrontDefaultCertificate.Value;
                requestDistributionConfig_distributionConfig_ViewerCertificateIsNull = false;
            }
            String requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_IAMCertificateId = null;
            if (cmdletContext.DistributionConfig_ViewerCertificate_IAMCertificateId != null)
            {
                requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_IAMCertificateId = cmdletContext.DistributionConfig_ViewerCertificate_IAMCertificateId;
            }
            if (requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_IAMCertificateId != null)
            {
                requestDistributionConfig_distributionConfig_ViewerCertificate.IAMCertificateId = requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_IAMCertificateId;
                requestDistributionConfig_distributionConfig_ViewerCertificateIsNull = false;
            }
            MinimumProtocolVersion requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_MinimumProtocolVersion = null;
            if (cmdletContext.DistributionConfig_ViewerCertificate_MinimumProtocolVersion != null)
            {
                requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_MinimumProtocolVersion = cmdletContext.DistributionConfig_ViewerCertificate_MinimumProtocolVersion;
            }
            if (requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_MinimumProtocolVersion != null)
            {
                requestDistributionConfig_distributionConfig_ViewerCertificate.MinimumProtocolVersion = requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_MinimumProtocolVersion;
                requestDistributionConfig_distributionConfig_ViewerCertificateIsNull = false;
            }
            SSLSupportMethod requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_SSLSupportMethod = null;
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
            DefaultCacheBehavior requestDistributionConfig_distributionConfig_DefaultCacheBehavior = null;
            
             // populate DefaultCacheBehavior
            bool requestDistributionConfig_distributionConfig_DefaultCacheBehaviorIsNull = true;
            requestDistributionConfig_distributionConfig_DefaultCacheBehavior = new DefaultCacheBehavior();
            Int64? requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_MinTTL = null;
            if (cmdletContext.DistributionConfig_DefaultCacheBehavior_MinTTL != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_MinTTL = cmdletContext.DistributionConfig_DefaultCacheBehavior_MinTTL.Value;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_MinTTL != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior.MinTTL = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_MinTTL.Value;
                requestDistributionConfig_distributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            Boolean? requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_SmoothStreaming = null;
            if (cmdletContext.DistributionConfig_DefaultCacheBehavior_SmoothStreaming != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_SmoothStreaming = cmdletContext.DistributionConfig_DefaultCacheBehavior_SmoothStreaming.Value;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_SmoothStreaming != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior.SmoothStreaming = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_SmoothStreaming.Value;
                requestDistributionConfig_distributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            String requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_TargetOriginId = null;
            if (cmdletContext.DistributionConfig_DefaultCacheBehavior_TargetOriginId != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_TargetOriginId = cmdletContext.DistributionConfig_DefaultCacheBehavior_TargetOriginId;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_TargetOriginId != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior.TargetOriginId = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_TargetOriginId;
                requestDistributionConfig_distributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            ViewerProtocolPolicy requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_ViewerProtocolPolicy = null;
            if (cmdletContext.DistributionConfig_DefaultCacheBehavior_ViewerProtocolPolicy != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_ViewerProtocolPolicy = cmdletContext.DistributionConfig_DefaultCacheBehavior_ViewerProtocolPolicy;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_ViewerProtocolPolicy != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior.ViewerProtocolPolicy = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_ViewerProtocolPolicy;
                requestDistributionConfig_distributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            AllowedMethods requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods = null;
            
             // populate AllowedMethods
            bool requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethodsIsNull = true;
            requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods = new AllowedMethods();
            List<String> requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_allowedMethods_Item = null;
            if (cmdletContext.DistributionConfig_DefaultCacheBehavior_AllowedMethods_Items != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_allowedMethods_Item = cmdletContext.DistributionConfig_DefaultCacheBehavior_AllowedMethods_Items;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_allowedMethods_Item != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods.Items = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_allowedMethods_Item;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethodsIsNull = false;
            }
            Int32? requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_allowedMethods_Quantity = null;
            if (cmdletContext.DistributionConfig_DefaultCacheBehavior_AllowedMethods_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_allowedMethods_Quantity = cmdletContext.DistributionConfig_DefaultCacheBehavior_AllowedMethods_Quantity.Value;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_allowedMethods_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods.Quantity = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_allowedMethods_Quantity.Value;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethodsIsNull = false;
            }
            CachedMethods requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods = null;
            
             // populate CachedMethods
            bool requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethodsIsNull = true;
            requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods = new CachedMethods();
            List<String> requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_cachedMethods_Item = null;
            if (cmdletContext.DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_Items != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_cachedMethods_Item = cmdletContext.DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_Items;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_cachedMethods_Item != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods.Items = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_cachedMethods_Item;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethodsIsNull = false;
            }
            Int32? requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_cachedMethods_Quantity = null;
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
            ForwardedValues requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues = null;
            
             // populate ForwardedValues
            bool requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValuesIsNull = true;
            requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues = new ForwardedValues();
            Boolean? requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_forwardedValues_QueryString = null;
            if (cmdletContext.DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryString != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_forwardedValues_QueryString = cmdletContext.DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryString.Value;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_forwardedValues_QueryString != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues.QueryString = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_forwardedValues_QueryString.Value;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValuesIsNull = false;
            }
            CookiePreference requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies = null;
            
             // populate Cookies
            bool requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_CookiesIsNull = true;
            requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies = new CookiePreference();
            ItemSelection requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_cookies_Forward = null;
            if (cmdletContext.DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_Forward != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_cookies_Forward = cmdletContext.DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_Forward;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_cookies_Forward != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies.Forward = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_cookies_Forward;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_CookiesIsNull = false;
            }
            CookieNames requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames = null;
            
             // populate WhitelistedNames
            bool requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNamesIsNull = true;
            requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames = new CookieNames();
            List<String> requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_whitelistedNames_Item = null;
            if (cmdletContext.DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_Items != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_whitelistedNames_Item = cmdletContext.DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_Items;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_whitelistedNames_Item != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames.Items = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_whitelistedNames_Item;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNamesIsNull = false;
            }
            Int32? requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_whitelistedNames_Quantity = null;
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
            Headers requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Headers = null;
            
             // populate Headers
            bool requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_HeadersIsNull = true;
            requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Headers = new Headers();
            List<String> requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_headers_Item = null;
            if (cmdletContext.DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_Items != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_headers_Item = cmdletContext.DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_Items;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_headers_Item != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Headers.Items = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_headers_Item;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_HeadersIsNull = false;
            }
            Int32? requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_headers_Quantity = null;
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
            TrustedSigners requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners = null;
            
             // populate TrustedSigners
            bool requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSignersIsNull = true;
            requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners = new TrustedSigners();
            Boolean? requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Enabled = null;
            if (cmdletContext.DistributionConfig_DefaultCacheBehavior_TrustedSigners_Enabled != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Enabled = cmdletContext.DistributionConfig_DefaultCacheBehavior_TrustedSigners_Enabled.Value;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Enabled != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners.Enabled = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Enabled.Value;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSignersIsNull = false;
            }
            List<String> requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Item = null;
            if (cmdletContext.DistributionConfig_DefaultCacheBehavior_TrustedSigners_Items != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Item = cmdletContext.DistributionConfig_DefaultCacheBehavior_TrustedSigners_Items;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Item != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners.Items = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Item;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSignersIsNull = false;
            }
            Int32? requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Quantity = null;
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
                var response = client.CreateDistribution(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public List<String> DistributionConfig_Aliases_Items { get; set; }
            public Int32? DistributionConfig_Aliases_Quantity { get; set; }
            public List<CacheBehavior> DistributionConfig_CacheBehaviors_Items { get; set; }
            public Int32? DistributionConfig_CacheBehaviors_Quantity { get; set; }
            public String DistributionConfig_CallerReference { get; set; }
            public String DistributionConfig_Comment { get; set; }
            public List<CustomErrorResponse> DistributionConfig_CustomErrorResponses_Items { get; set; }
            public Int32? DistributionConfig_CustomErrorResponses_Quantity { get; set; }
            public List<String> DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_Items { get; set; }
            public Int32? DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_Quantity { get; set; }
            public List<String> DistributionConfig_DefaultCacheBehavior_AllowedMethods_Items { get; set; }
            public Int32? DistributionConfig_DefaultCacheBehavior_AllowedMethods_Quantity { get; set; }
            public ItemSelection DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_Forward { get; set; }
            public List<String> DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_Items { get; set; }
            public Int32? DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_Quantity { get; set; }
            public List<String> DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_Items { get; set; }
            public Int32? DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_Quantity { get; set; }
            public Boolean? DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryString { get; set; }
            public Int64? DistributionConfig_DefaultCacheBehavior_MinTTL { get; set; }
            public Boolean? DistributionConfig_DefaultCacheBehavior_SmoothStreaming { get; set; }
            public String DistributionConfig_DefaultCacheBehavior_TargetOriginId { get; set; }
            public Boolean? DistributionConfig_DefaultCacheBehavior_TrustedSigners_Enabled { get; set; }
            public List<String> DistributionConfig_DefaultCacheBehavior_TrustedSigners_Items { get; set; }
            public Int32? DistributionConfig_DefaultCacheBehavior_TrustedSigners_Quantity { get; set; }
            public ViewerProtocolPolicy DistributionConfig_DefaultCacheBehavior_ViewerProtocolPolicy { get; set; }
            public String DistributionConfig_DefaultRootObject { get; set; }
            public Boolean? DistributionConfig_Enabled { get; set; }
            public String DistributionConfig_Logging_Bucket { get; set; }
            public Boolean? DistributionConfig_Logging_Enabled { get; set; }
            public Boolean? DistributionConfig_Logging_IncludeCookies { get; set; }
            public String DistributionConfig_Logging_Prefix { get; set; }
            public List<Origin> DistributionConfig_Origins_Items { get; set; }
            public Int32? DistributionConfig_Origins_Quantity { get; set; }
            public PriceClass DistributionConfig_PriceClass { get; set; }
            public List<String> DistributionConfig_Restrictions_GeoRestriction_Items { get; set; }
            public Int32? DistributionConfig_Restrictions_GeoRestriction_Quantity { get; set; }
            public GeoRestrictionType DistributionConfig_Restrictions_GeoRestriction_RestrictionType { get; set; }
            public Boolean? DistributionConfig_ViewerCertificate_CloudFrontDefaultCertificate { get; set; }
            public String DistributionConfig_ViewerCertificate_IAMCertificateId { get; set; }
            public MinimumProtocolVersion DistributionConfig_ViewerCertificate_MinimumProtocolVersion { get; set; }
            public SSLSupportMethod DistributionConfig_ViewerCertificate_SSLSupportMethod { get; set; }
        }
        
    }
}
