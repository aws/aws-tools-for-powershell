/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Create a new distribution with tags. This API operation requires the following IAM
    /// permissions:
    /// 
    ///  <ul><li><para><a href="https://docs.aws.amazon.com/cloudfront/latest/APIReference/API_CreateDistribution.html">CreateDistribution</a></para></li><li><para><a href="https://docs.aws.amazon.com/cloudfront/latest/APIReference/API_TagResource.html">TagResource</a></para></li></ul>
    /// </summary>
    [Cmdlet("New", "CFDistributionWithTag", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudFront.Model.CreateDistributionWithTagsResponse")]
    [AWSCmdlet("Calls the Amazon CloudFront CreateDistributionWithTags API operation.", Operation = new[] {"CreateDistributionWithTags"}, SelectReturnType = typeof(Amazon.CloudFront.Model.CreateDistributionWithTagsResponse))]
    [AWSCmdletOutput("Amazon.CloudFront.Model.CreateDistributionWithTagsResponse",
        "This cmdlet returns an Amazon.CloudFront.Model.CreateDistributionWithTagsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCFDistributionWithTagCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ViewerCertificate_ACMCertificateArn
        /// <summary>
        /// <para>
        /// <para>If the distribution uses <code>Aliases</code> (alternate domain names or CNAMEs) and
        /// the SSL/TLS certificate is stored in <a href="https://docs.aws.amazon.com/acm/latest/userguide/acm-overview.html">Certificate
        /// Manager (ACM)</a>, provide the Amazon Resource Name (ARN) of the ACM certificate.
        /// CloudFront only supports ACM certificates in the US East (N. Virginia) Region (<code>us-east-1</code>).</para><para>If you specify an ACM certificate ARN, you must also specify values for <code>MinimumProtocolVersion</code>
        /// and <code>SSLSupportMethod</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_ViewerCertificate_ACMCertificateArn")]
        public System.String ViewerCertificate_ACMCertificateArn { get; set; }
        #endregion
        
        #region Parameter Logging_Bucket
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket to store the access logs in, for example, <code>myawslogbucket.s3.amazonaws.com</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_Logging_Bucket")]
        public System.String Logging_Bucket { get; set; }
        #endregion
        
        #region Parameter DefaultCacheBehavior_CachePolicyId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the cache policy that is attached to the default cache behavior.
        /// For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/controlling-the-cache-key.html#cache-key-create-cache-policy">Creating
        /// cache policies</a> or <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/using-managed-cache-policies.html">Using
        /// the managed cache policies</a> in the <i>Amazon CloudFront Developer Guide</i>.</para><para>A <code>DefaultCacheBehavior</code> must include either a <code>CachePolicyId</code>
        /// or <code>ForwardedValues</code>. We recommend that you use a <code>CachePolicyId</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_CachePolicyId")]
        public System.String DefaultCacheBehavior_CachePolicyId { get; set; }
        #endregion
        
        #region Parameter DistributionConfig_CallerReference
        /// <summary>
        /// <para>
        /// <para>A unique value (for example, a date-time stamp) that ensures that the request can't
        /// be replayed.</para><para>If the value of <code>CallerReference</code> is new (regardless of the content of
        /// the <code>DistributionConfig</code> object), CloudFront creates a new distribution.</para><para>If <code>CallerReference</code> is a value that you already sent in a previous request
        /// to create a distribution, CloudFront returns a <code>DistributionAlreadyExists</code>
        /// error.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_CallerReference")]
        public System.String DistributionConfig_CallerReference { get; set; }
        #endregion
        
        #region Parameter ViewerCertificate_CloudFrontDefaultCertificate
        /// <summary>
        /// <para>
        /// <para>If the distribution uses the CloudFront domain name such as <code>d111111abcdef8.cloudfront.net</code>,
        /// set this field to <code>true</code>.</para><para>If the distribution uses <code>Aliases</code> (alternate domain names or CNAMEs),
        /// set this field to <code>false</code> and specify values for the following fields:</para><ul><li><para><code>ACMCertificateArn</code> or <code>IAMCertificateId</code> (specify a value
        /// for one, not both)</para></li><li><para><code>MinimumProtocolVersion</code></para></li><li><para><code>SSLSupportMethod</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_ViewerCertificate_CloudFrontDefaultCertificate")]
        public System.Boolean? ViewerCertificate_CloudFrontDefaultCertificate { get; set; }
        #endregion
        
        #region Parameter DistributionConfig_Comment
        /// <summary>
        /// <para>
        /// <para>A comment to describe the distribution. The comment cannot be longer than 128 characters.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_Comment")]
        public System.String DistributionConfig_Comment { get; set; }
        #endregion
        
        #region Parameter DefaultCacheBehavior_Compress
        /// <summary>
        /// <para>
        /// <para>Whether you want CloudFront to automatically compress certain files for this cache
        /// behavior. If so, specify <code>true</code>; if not, specify <code>false</code>. For
        /// more information, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/ServingCompressedFiles.html">Serving
        /// Compressed Files</a> in the <i>Amazon CloudFront Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_Compress")]
        public System.Boolean? DefaultCacheBehavior_Compress { get; set; }
        #endregion
        
        #region Parameter DistributionConfig_ContinuousDeploymentPolicyId
        /// <summary>
        /// <para>
        /// <para>The identifier of a continuous deployment policy. For more information, see <code>CreateContinuousDeploymentPolicy</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_ContinuousDeploymentPolicyId")]
        public System.String DistributionConfig_ContinuousDeploymentPolicyId { get; set; }
        #endregion
        
        #region Parameter DistributionConfig_DefaultRootObject
        /// <summary>
        /// <para>
        /// <para>The object that you want CloudFront to request from your origin (for example, <code>index.html</code>)
        /// when a viewer requests the root URL for your distribution (<code>https://www.example.com</code>)
        /// instead of an object in your distribution (<code>https://www.example.com/product-description.html</code>).
        /// Specifying a default root object avoids exposing the contents of your distribution.</para><para>Specify only the object name, for example, <code>index.html</code>. Don't add a <code>/</code>
        /// before the object name.</para><para>If you don't want to specify a default root object when you create a distribution,
        /// include an empty <code>DefaultRootObject</code> element.</para><para>To delete the default root object from an existing distribution, update the distribution
        /// configuration and include an empty <code>DefaultRootObject</code> element.</para><para>To replace the default root object, update the distribution configuration and specify
        /// the new object.</para><para>For more information about the default root object, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/DefaultRootObject.html">Creating
        /// a Default Root Object</a> in the <i>Amazon CloudFront Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultRootObject")]
        public System.String DistributionConfig_DefaultRootObject { get; set; }
        #endregion
        
        #region Parameter TrustedKeyGroups_Enabled
        /// <summary>
        /// <para>
        /// <para>This field is <code>true</code> if any of the key groups in the list have public keys
        /// that CloudFront can use to verify the signatures of signed URLs and signed cookies.
        /// If not, this field is <code>false</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedKeyGroups_Enabled")]
        public System.Boolean? TrustedKeyGroups_Enabled { get; set; }
        #endregion
        
        #region Parameter TrustedSigners_Enabled
        /// <summary>
        /// <para>
        /// <para>This field is <code>true</code> if any of the Amazon Web Services accounts in the
        /// list are configured as trusted signers. If not, this field is <code>false</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners_Enabled")]
        public System.Boolean? TrustedSigners_Enabled { get; set; }
        #endregion
        
        #region Parameter DistributionConfig_Enabled
        /// <summary>
        /// <para>
        /// <para>From this field, you can enable or disable the selected distribution.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_Enabled")]
        public System.Boolean? DistributionConfig_Enabled { get; set; }
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_Logging_Enabled")]
        public System.Boolean? Logging_Enabled { get; set; }
        #endregion
        
        #region Parameter DefaultCacheBehavior_FieldLevelEncryptionId
        /// <summary>
        /// <para>
        /// <para>The value of <code>ID</code> for the field-level encryption configuration that you
        /// want CloudFront to use for encrypting specific fields of data for the default cache
        /// behavior.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_FieldLevelEncryptionId")]
        public System.String DefaultCacheBehavior_FieldLevelEncryptionId { get; set; }
        #endregion
        
        #region Parameter Cookies_Forward
        /// <summary>
        /// <para>
        /// <para>This field is deprecated. We recommend that you use a cache policy or an origin request
        /// policy instead of this field.</para><para>If you want to include cookies in the cache key, use a cache policy. For more information,
        /// see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/controlling-the-cache-key.html#cache-key-create-cache-policy">Creating
        /// cache policies</a> in the <i>Amazon CloudFront Developer Guide</i>.</para><para>If you want to send cookies to the origin but not include them in the cache key, use
        /// origin request policy. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/controlling-origin-requests.html#origin-request-create-origin-request-policy">Creating
        /// origin request policies</a> in the <i>Amazon CloudFront Developer Guide</i>.</para><para>Specifies which cookies to forward to the origin for this cache behavior: all, none,
        /// or the list of cookies specified in the <code>WhitelistedNames</code> complex type.</para><para>Amazon S3 doesn't process cookies. When the cache behavior is forwarding requests
        /// to an Amazon S3 origin, specify none for the <code>Forward</code> element.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_Forward")]
        [AWSConstantClassSource("Amazon.CloudFront.ItemSelection")]
        public Amazon.CloudFront.ItemSelection Cookies_Forward { get; set; }
        #endregion
        
        #region Parameter DistributionConfig_HttpVersion
        /// <summary>
        /// <para>
        /// <para>(Optional) Specify the maximum HTTP version(s) that you want viewers to use to communicate
        /// with CloudFront. The default value for new web distributions is <code>http2</code>.
        /// Viewers that don't support HTTP/2 automatically use an earlier HTTP version.</para><para>For viewers and CloudFront to use HTTP/2, viewers must support TLSv1.2 or later, and
        /// must support Server Name Indication (SNI).</para><para>For viewers and CloudFront to use HTTP/3, viewers must support TLSv1.3 and Server
        /// Name Indication (SNI). CloudFront supports HTTP/3 connection migration to allow the
        /// viewer to switch networks without losing connection. For more information about connection
        /// migration, see <a href="https://www.rfc-editor.org/rfc/rfc9000.html#name-connection-migration">Connection
        /// Migration</a> at RFC 9000. For more information about supported TLSv1.3 ciphers, see
        /// <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/secure-connections-supported-viewer-protocols-ciphers.html">Supported
        /// protocols and ciphers between viewers and CloudFront</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_HttpVersion")]
        [AWSConstantClassSource("Amazon.CloudFront.HttpVersion")]
        public Amazon.CloudFront.HttpVersion DistributionConfig_HttpVersion { get; set; }
        #endregion
        
        #region Parameter ViewerCertificate_IAMCertificateId
        /// <summary>
        /// <para>
        /// <para>If the distribution uses <code>Aliases</code> (alternate domain names or CNAMEs) and
        /// the SSL/TLS certificate is stored in <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id_credentials_server-certs.html">Identity
        /// and Access Management (IAM)</a>, provide the ID of the IAM certificate.</para><para>If you specify an IAM certificate ID, you must also specify values for <code>MinimumProtocolVersion</code>
        /// and <code>SSLSupportMethod</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_Logging_IncludeCookies")]
        public System.Boolean? Logging_IncludeCookie { get; set; }
        #endregion
        
        #region Parameter DistributionConfig_IsIPV6Enabled
        /// <summary>
        /// <para>
        /// <para>If you want CloudFront to respond to IPv6 DNS requests with an IPv6 address for your
        /// distribution, specify <code>true</code>. If you specify <code>false</code>, CloudFront
        /// responds to IPv6 DNS requests with the DNS response code <code>NOERROR</code> and
        /// with no IP addresses. This allows viewers to submit a second request, for an IPv4
        /// address for your distribution.</para><para>In general, you should enable IPv6 if you have users on IPv6 networks who want to
        /// access your content. However, if you're using signed URLs or signed cookies to restrict
        /// access to your content, and if you're using a custom policy that includes the <code>IpAddress</code>
        /// parameter to restrict the IP addresses that can access your content, don't enable
        /// IPv6. If you want to restrict access to some content by IP address and not restrict
        /// access to other content (or restrict access but not by IP address), you can create
        /// two distributions. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/private-content-creating-signed-url-custom-policy.html">Creating
        /// a Signed URL Using a Custom Policy</a> in the <i>Amazon CloudFront Developer Guide</i>.</para><para>If you're using an Route 53 Amazon Web Services Integration alias resource record
        /// set to route traffic to your CloudFront distribution, you need to create a second
        /// alias resource record set when both of the following are true:</para><ul><li><para>You enable IPv6 for the distribution</para></li><li><para>You're using alternate domain names in the URLs for your objects</para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/Route53/latest/DeveloperGuide/routing-to-cloudfront-distribution.html">Routing
        /// Traffic to an Amazon CloudFront Web Distribution by Using Your Domain Name</a> in
        /// the <i>Route 53 Amazon Web Services Integration Developer Guide</i>.</para><para>If you created a CNAME resource record set, either with Route 53 Amazon Web Services
        /// Integration or with another DNS service, you don't need to make any changes. A CNAME
        /// record will route traffic to your distribution regardless of the IP address format
        /// of the viewer request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_IsIPV6Enabled")]
        public System.Boolean? DistributionConfig_IsIPV6Enabled { get; set; }
        #endregion
        
        #region Parameter Aliases_Item
        /// <summary>
        /// <para>
        /// <para>A complex type that contains the CNAME aliases, if any, that you want to associate
        /// with this distribution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_Items")]
        public System.String[] AllowedMethods_Item { get; set; }
        #endregion
        
        #region Parameter WhitelistedNames_Item
        /// <summary>
        /// <para>
        /// <para>A list of cookie names.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_Items")]
        public System.String[] WhitelistedNames_Item { get; set; }
        #endregion
        
        #region Parameter Headers_Item
        /// <summary>
        /// <para>
        /// <para>A list of HTTP header names.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_Items")]
        public System.String[] Headers_Item { get; set; }
        #endregion
        
        #region Parameter QueryStringCacheKeys_Item
        /// <summary>
        /// <para>
        /// <para>A list that contains the query string parameters that you want CloudFront to use as
        /// a basis for caching for a cache behavior. If <code>Quantity</code> is 0, you can omit
        /// <code>Items</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_Items")]
        public System.String[] QueryStringCacheKeys_Item { get; set; }
        #endregion
        
        #region Parameter FunctionAssociations_Item
        /// <summary>
        /// <para>
        /// <para>The CloudFront functions that are associated with a cache behavior in a CloudFront
        /// distribution. CloudFront functions must be published to the <code>LIVE</code> stage
        /// to associate them with a cache behavior.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_FunctionAssociations_Items")]
        public Amazon.CloudFront.Model.FunctionAssociation[] FunctionAssociations_Item { get; set; }
        #endregion
        
        #region Parameter LambdaFunctionAssociations_Item
        /// <summary>
        /// <para>
        /// <para><b>Optional</b>: A complex type that contains <code>LambdaFunctionAssociation</code>
        /// items for this cache behavior. If <code>Quantity</code> is <code>0</code>, you can
        /// omit <code>Items</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_Items")]
        public Amazon.CloudFront.Model.LambdaFunctionAssociation[] LambdaFunctionAssociations_Item { get; set; }
        #endregion
        
        #region Parameter TrustedKeyGroups_Item
        /// <summary>
        /// <para>
        /// <para>A list of key groups identifiers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedKeyGroups_Items")]
        public System.String[] TrustedKeyGroups_Item { get; set; }
        #endregion
        
        #region Parameter TrustedSigners_Item
        /// <summary>
        /// <para>
        /// <para>A list of Amazon Web Services account identifiers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners_Items")]
        public System.String[] TrustedSigners_Item { get; set; }
        #endregion
        
        #region Parameter OriginGroups_Item
        /// <summary>
        /// <para>
        /// <para>The items (origin groups) in a distribution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_OriginGroups_Items")]
        public Amazon.CloudFront.Model.OriginGroup[] OriginGroups_Item { get; set; }
        #endregion
        
        #region Parameter Origins_Item
        /// <summary>
        /// <para>
        /// <para>A list of origins.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_Origins_Items")]
        public Amazon.CloudFront.Model.Origin[] Origins_Item { get; set; }
        #endregion
        
        #region Parameter GeoRestriction_Item
        /// <summary>
        /// <para>
        /// <para>A complex type that contains a <code>Location</code> element for each country in which
        /// you want CloudFront either to distribute your content (<code>whitelist</code>) or
        /// not distribute your content (<code>blacklist</code>).</para><para>The <code>Location</code> element is a two-letter, uppercase country code for a country
        /// that you want to include in your <code>blacklist</code> or <code>whitelist</code>.
        /// Include one <code>Location</code> element for each country.</para><para>CloudFront and <code>MaxMind</code> both use <code>ISO 3166</code> country codes.
        /// For the current list of countries and the corresponding codes, see <code>ISO 3166-1-alpha-2</code>
        /// code on the <i>International Organization for Standardization</i> website. You can
        /// also refer to the country list on the CloudFront console, which includes both country
        /// names and codes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_Items")]
        public System.String[] GeoRestriction_Item { get; set; }
        #endregion
        
        #region Parameter Tags_Item
        /// <summary>
        /// <para>
        /// <para>A complex type that contains <code>Tag</code> elements.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_Tags_Items")]
        public Amazon.CloudFront.Model.Tag[] Tags_Item { get; set; }
        #endregion
        
        #region Parameter ViewerCertificate_MinimumProtocolVersion
        /// <summary>
        /// <para>
        /// <para>If the distribution uses <code>Aliases</code> (alternate domain names or CNAMEs),
        /// specify the security policy that you want CloudFront to use for HTTPS connections
        /// with viewers. The security policy determines two settings:</para><ul><li><para>The minimum SSL/TLS protocol that CloudFront can use to communicate with viewers.</para></li><li><para>The ciphers that CloudFront can use to encrypt the content that it returns to viewers.</para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/distribution-web-values-specify.html#DownloadDistValues-security-policy">Security
        /// Policy</a> and <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/secure-connections-supported-viewer-protocols-ciphers.html#secure-connections-supported-ciphers">Supported
        /// Protocols and Ciphers Between Viewers and CloudFront</a> in the <i>Amazon CloudFront
        /// Developer Guide</i>.</para><note><para>On the CloudFront console, this setting is called <b>Security Policy</b>.</para></note><para>When you're using SNI only (you set <code>SSLSupportMethod</code> to <code>sni-only</code>),
        /// you must specify <code>TLSv1</code> or higher.</para><para>If the distribution uses the CloudFront domain name such as <code>d111111abcdef8.cloudfront.net</code>
        /// (you set <code>CloudFrontDefaultCertificate</code> to <code>true</code>), CloudFront
        /// automatically sets the security policy to <code>TLSv1</code> regardless of the value
        /// that you set here.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_ViewerCertificate_MinimumProtocolVersion")]
        [AWSConstantClassSource("Amazon.CloudFront.MinimumProtocolVersion")]
        public Amazon.CloudFront.MinimumProtocolVersion ViewerCertificate_MinimumProtocolVersion { get; set; }
        #endregion
        
        #region Parameter DefaultCacheBehavior_OriginRequestPolicyId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the origin request policy that is attached to the default
        /// cache behavior. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/controlling-origin-requests.html#origin-request-create-origin-request-policy">Creating
        /// origin request policies</a> or <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/using-managed-origin-request-policies.html">Using
        /// the managed origin request policies</a> in the <i>Amazon CloudFront Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_OriginRequestPolicyId")]
        public System.String DefaultCacheBehavior_OriginRequestPolicyId { get; set; }
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        /// from your specified price class may encounter slower performance.</para><para>For more information about price classes, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/PriceClass.html">Choosing
        /// the Price Class for a CloudFront Distribution</a> in the <i>Amazon CloudFront Developer
        /// Guide</i>. For information about CloudFront pricing, including how price classes (such
        /// as Price Class 100) map to CloudFront regions, see <a href="http://aws.amazon.com/cloudfront/pricing/">Amazon
        /// CloudFront Pricing</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_Aliases_Quantity")]
        public System.Int32? Aliases_Quantity { get; set; }
        #endregion
        
        #region Parameter CacheBehaviors_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of cache behaviors for this distribution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_CacheBehaviors_Quantity")]
        public System.Int32? CacheBehaviors_Quantity { get; set; }
        #endregion
        
        #region Parameter CustomErrorResponses_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of HTTP status codes for which you want to specify a custom error page
        /// and/or a caching duration. If <code>Quantity</code> is <code>0</code>, you can omit
        /// <code>Items</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_CustomErrorResponses_Quantity")]
        public System.Int32? CustomErrorResponses_Quantity { get; set; }
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_Quantity")]
        public System.Int32? CachedMethods_Quantity { get; set; }
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_Quantity")]
        public System.Int32? AllowedMethods_Quantity { get; set; }
        #endregion
        
        #region Parameter WhitelistedNames_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of cookie names in the <code>Items</code> list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_Quantity")]
        public System.Int32? WhitelistedNames_Quantity { get; set; }
        #endregion
        
        #region Parameter Headers_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of header names in the <code>Items</code> list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_Quantity")]
        public System.Int32? Headers_Quantity { get; set; }
        #endregion
        
        #region Parameter QueryStringCacheKeys_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of <code>whitelisted</code> query string parameters for a cache behavior.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_Quantity")]
        public System.Int32? QueryStringCacheKeys_Quantity { get; set; }
        #endregion
        
        #region Parameter FunctionAssociations_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of CloudFront functions in the list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_FunctionAssociations_Quantity")]
        public System.Int32? FunctionAssociations_Quantity { get; set; }
        #endregion
        
        #region Parameter LambdaFunctionAssociations_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of Lambda@Edge function associations for this cache behavior.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_Quantity")]
        public System.Int32? LambdaFunctionAssociations_Quantity { get; set; }
        #endregion
        
        #region Parameter TrustedKeyGroups_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of key groups in the list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedKeyGroups_Quantity")]
        public System.Int32? TrustedKeyGroups_Quantity { get; set; }
        #endregion
        
        #region Parameter TrustedSigners_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of Amazon Web Services accounts in the list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners_Quantity")]
        public System.Int32? TrustedSigners_Quantity { get; set; }
        #endregion
        
        #region Parameter OriginGroups_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of origin groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_OriginGroups_Quantity")]
        public System.Int32? OriginGroups_Quantity { get; set; }
        #endregion
        
        #region Parameter Origins_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of origins for this distribution.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_Origins_Quantity")]
        public System.Int32? Origins_Quantity { get; set; }
        #endregion
        
        #region Parameter GeoRestriction_Quantity
        /// <summary>
        /// <para>
        /// <para>When geo restriction is <code>enabled</code>, this is the number of countries in your
        /// <code>whitelist</code> or <code>blacklist</code>. Otherwise, when it is not enabled,
        /// <code>Quantity</code> is <code>0</code>, and you can omit <code>Items</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_Quantity")]
        public System.Int32? GeoRestriction_Quantity { get; set; }
        #endregion
        
        #region Parameter ForwardedValues_QueryString
        /// <summary>
        /// <para>
        /// <para>This field is deprecated. We recommend that you use a cache policy or an origin request
        /// policy instead of this field.</para><para>If you want to include query strings in the cache key, use a cache policy. For more
        /// information, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/controlling-the-cache-key.html#cache-key-create-cache-policy">Creating
        /// cache policies</a> in the <i>Amazon CloudFront Developer Guide</i>.</para><para>If you want to send query strings to the origin but not include them in the cache
        /// key, use an origin request policy. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/controlling-origin-requests.html#origin-request-create-origin-request-policy">Creating
        /// origin request policies</a> in the <i>Amazon CloudFront Developer Guide</i>.</para><para>Indicates whether you want CloudFront to forward query strings to the origin that
        /// is associated with this cache behavior and cache based on the query string parameters.
        /// CloudFront behavior depends on the value of <code>QueryString</code> and on the values
        /// that you specify for <code>QueryStringCacheKeys</code>, if any:</para><para>If you specify true for <code>QueryString</code> and you don't specify any values
        /// for <code>QueryStringCacheKeys</code>, CloudFront forwards all query string parameters
        /// to the origin and caches based on all query string parameters. Depending on how many
        /// query string parameters and values you have, this can adversely affect performance
        /// because CloudFront must forward more requests to the origin.</para><para>If you specify true for <code>QueryString</code> and you specify one or more values
        /// for <code>QueryStringCacheKeys</code>, CloudFront forwards all query string parameters
        /// to the origin, but it only caches based on the query string parameters that you specify.</para><para>If you specify false for <code>QueryString</code>, CloudFront doesn't forward any
        /// query string parameters to the origin, and doesn't cache based on query string parameters.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/QueryStringParameters.html">Configuring
        /// CloudFront to Cache Based on Query String Parameters</a> in the <i>Amazon CloudFront
        /// Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryString")]
        public System.Boolean? ForwardedValues_QueryString { get; set; }
        #endregion
        
        #region Parameter DefaultCacheBehavior_RealtimeLogConfigArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the real-time log configuration that is attached
        /// to this cache behavior. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/real-time-logs.html">Real-time
        /// logs</a> in the <i>Amazon CloudFront Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_RealtimeLogConfigArn")]
        public System.String DefaultCacheBehavior_RealtimeLogConfigArn { get; set; }
        #endregion
        
        #region Parameter DefaultCacheBehavior_ResponseHeadersPolicyId
        /// <summary>
        /// <para>
        /// <para>The identifier for a response headers policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ResponseHeadersPolicyId")]
        public System.String DefaultCacheBehavior_ResponseHeadersPolicyId { get; set; }
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        /// cache behavior if the content matches the value of <code>PathPattern</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_SmoothStreaming")]
        public System.Boolean? DefaultCacheBehavior_SmoothStreaming { get; set; }
        #endregion
        
        #region Parameter ViewerCertificate_SSLSupportMethod
        /// <summary>
        /// <para>
        /// <para>If the distribution uses <code>Aliases</code> (alternate domain names or CNAMEs),
        /// specify which viewers the distribution accepts HTTPS connections from.</para><ul><li><para><code>sni-only</code> – The distribution accepts HTTPS connections from only viewers
        /// that support <a href="https://en.wikipedia.org/wiki/Server_Name_Indication">server
        /// name indication (SNI)</a>. This is recommended. Most browsers and clients support
        /// SNI.</para></li><li><para><code>vip</code> – The distribution accepts HTTPS connections from all viewers including
        /// those that don't support SNI. This is not recommended, and results in additional monthly
        /// charges from CloudFront.</para></li><li><para><code>static-ip</code> - Do not specify this value unless your distribution has been
        /// enabled for this feature by the CloudFront team. If you have a use case that requires
        /// static IP addresses for a distribution, contact CloudFront through the <a href="https://console.aws.amazon.com/support/home">Amazon
        /// Web Services Support Center</a>.</para></li></ul><para>If the distribution uses the CloudFront domain name such as <code>d111111abcdef8.cloudfront.net</code>,
        /// don't set a value for this field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_ViewerCertificate_SSLSupportMethod")]
        [AWSConstantClassSource("Amazon.CloudFront.SSLSupportMethod")]
        public Amazon.CloudFront.SSLSupportMethod ViewerCertificate_SSLSupportMethod { get; set; }
        #endregion
        
        #region Parameter DistributionConfig_Staging
        /// <summary>
        /// <para>
        /// <para>A Boolean that indicates whether this is a staging distribution. When this value is
        /// <code>true</code>, this is a staging distribution. When this value is <code>false</code>,
        /// this is not a staging distribution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_Staging")]
        public System.Boolean? DistributionConfig_Staging { get; set; }
        #endregion
        
        #region Parameter DefaultCacheBehavior_TargetOriginId
        /// <summary>
        /// <para>
        /// <para>The value of <code>ID</code> for the origin that you want CloudFront to route requests
        /// to when they use the default cache behavior.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
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
        /// HTTP status code of 403 (Forbidden).</para></li></ul><para>For more information about requiring the HTTPS protocol, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/using-https-viewers-to-cloudfront.html">Requiring
        /// HTTPS Between Viewers and CloudFront</a> in the <i>Amazon CloudFront Developer Guide</i>.</para><note><para>The only way to guarantee that viewers retrieve an object that was fetched from the
        /// origin using HTTPS is never to use any other protocol to fetch the object. If you
        /// have recently changed from HTTP to HTTPS, we recommend that you clear your objects'
        /// cache because cached objects are protocol agnostic. That means that an edge location
        /// will return an object from the cache regardless of whether the current request protocol
        /// matches the protocol used previously. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/Expiration.html">Managing
        /// Cache Expiration</a> in the <i>Amazon CloudFront Developer Guide</i>.</para></note>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ViewerProtocolPolicy")]
        [AWSConstantClassSource("Amazon.CloudFront.ViewerProtocolPolicy")]
        public Amazon.CloudFront.ViewerProtocolPolicy DefaultCacheBehavior_ViewerProtocolPolicy { get; set; }
        #endregion
        
        #region Parameter DistributionConfig_WebACLId
        /// <summary>
        /// <para>
        /// <para>A unique identifier that specifies the WAF web ACL, if any, to associate with this
        /// distribution. To specify a web ACL created using the latest version of WAF, use the
        /// ACL ARN, for example <code>arn:aws:wafv2:us-east-1:123456789012:global/webacl/ExampleWebACL/473e64fd-f30b-4765-81a0-62ad96dd167a</code>.
        /// To specify a web ACL created using WAF Classic, use the ACL ID, for example <code>473e64fd-f30b-4765-81a0-62ad96dd167a</code>.</para><para>WAF is a web application firewall that lets you monitor the HTTP and HTTPS requests
        /// that are forwarded to CloudFront, and lets you control access to your content. Based
        /// on conditions that you specify, such as the IP addresses that requests originate from
        /// or the values of query strings, CloudFront responds to requests either with the requested
        /// content or with an HTTP 403 status code (Forbidden). You can also configure CloudFront
        /// to return a custom error page when a request is blocked. For more information about
        /// WAF, see the <a href="https://docs.aws.amazon.com/waf/latest/developerguide/what-is-aws-waf.html">WAF
        /// Developer Guide</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfigWithTags_DistributionConfig_WebACLId")]
        public System.String DistributionConfig_WebACLId { get; set; }
        #endregion
        
        #region Parameter ViewerCertificate_Certificate
        /// <summary>
        /// <para>
        /// <para>This field is deprecated. Use one of the following fields instead:</para><ul><li><para><code>ACMCertificateArn</code></para></li><li><para><code>IAMCertificateId</code></para></li><li><para><code>CloudFrontDefaultCertificate</code></para></li></ul>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This field has been deprecated. Use one of the following fields instead: ACMCertificateArn, IAMCertificateId or CloudFrontDefaultCertificate.")]
        [Alias("DistributionConfigWithTags_DistributionConfig_ViewerCertificate_Certificate")]
        public System.String ViewerCertificate_Certificate { get; set; }
        #endregion
        
        #region Parameter ViewerCertificate_CertificateSource
        /// <summary>
        /// <para>
        /// <para>This field is deprecated. Use one of the following fields instead:</para><ul><li><para><code>ACMCertificateArn</code></para></li><li><para><code>IAMCertificateId</code></para></li><li><para><code>CloudFrontDefaultCertificate</code></para></li></ul>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This field has been deprecated. Use one of the following fields instead: ACMCertificateArn, IAMCertificateId or CloudFrontDefaultCertificate.")]
        [Alias("DistributionConfigWithTags_DistributionConfig_ViewerCertificate_CertificateSource")]
        [AWSConstantClassSource("Amazon.CloudFront.CertificateSource")]
        public Amazon.CloudFront.CertificateSource ViewerCertificate_CertificateSource { get; set; }
        #endregion
        
        #region Parameter DefaultCacheBehavior_DefaultTTL
        /// <summary>
        /// <para>
        /// <para>This field is deprecated. We recommend that you use the <code>DefaultTTL</code> field
        /// in a cache policy instead of this field. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/controlling-the-cache-key.html#cache-key-create-cache-policy">Creating
        /// cache policies</a> or <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/using-managed-cache-policies.html">Using
        /// the managed cache policies</a> in the <i>Amazon CloudFront Developer Guide</i>.</para><para>The default amount of time that you want objects to stay in CloudFront caches before
        /// CloudFront forwards another request to your origin to determine whether the object
        /// has been updated. The value that you specify applies only when your origin does not
        /// add HTTP headers such as <code>Cache-Control max-age</code>, <code>Cache-Control s-maxage</code>,
        /// and <code>Expires</code> to objects. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/Expiration.html">Managing
        /// How Long Content Stays in an Edge Cache (Expiration)</a> in the <i>Amazon CloudFront
        /// Developer Guide</i>.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This field is deprecated. Use CachePolicy instead.")]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_DefaultTTL")]
        public System.Int64? DefaultCacheBehavior_DefaultTTL { get; set; }
        #endregion
        
        #region Parameter DefaultCacheBehavior_MaxTTL
        /// <summary>
        /// <para>
        /// <para>This field is deprecated. We recommend that you use the <code>MaxTTL</code> field
        /// in a cache policy instead of this field. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/controlling-the-cache-key.html#cache-key-create-cache-policy">Creating
        /// cache policies</a> or <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/using-managed-cache-policies.html">Using
        /// the managed cache policies</a> in the <i>Amazon CloudFront Developer Guide</i>.</para><para>The maximum amount of time that you want objects to stay in CloudFront caches before
        /// CloudFront forwards another request to your origin to determine whether the object
        /// has been updated. The value that you specify applies only when your origin adds HTTP
        /// headers such as <code>Cache-Control max-age</code>, <code>Cache-Control s-maxage</code>,
        /// and <code>Expires</code> to objects. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/Expiration.html">Managing
        /// How Long Content Stays in an Edge Cache (Expiration)</a> in the <i>Amazon CloudFront
        /// Developer Guide</i>.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This field is deprecated. Use CachePolicy instead.")]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_MaxTTL")]
        public System.Int64? DefaultCacheBehavior_MaxTTL { get; set; }
        #endregion
        
        #region Parameter DefaultCacheBehavior_MinTTL
        /// <summary>
        /// <para>
        /// <para>This field is deprecated. We recommend that you use the <code>MinTTL</code> field
        /// in a cache policy instead of this field. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/controlling-the-cache-key.html#cache-key-create-cache-policy">Creating
        /// cache policies</a> or <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/using-managed-cache-policies.html">Using
        /// the managed cache policies</a> in the <i>Amazon CloudFront Developer Guide</i>.</para><para>The minimum amount of time that you want objects to stay in CloudFront caches before
        /// CloudFront forwards another request to your origin to determine whether the object
        /// has been updated. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/Expiration.html">Managing
        /// How Long Content Stays in an Edge Cache (Expiration)</a> in the <i>Amazon CloudFront
        /// Developer Guide</i>.</para><para>You must specify <code>0</code> for <code>MinTTL</code> if you configure CloudFront
        /// to forward all headers to your origin (under <code>Headers</code>, if you specify
        /// <code>1</code> for <code>Quantity</code> and <code>*</code> for <code>Name</code>).</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This field is deprecated. Use CachePolicy instead.")]
        [Alias("DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_MinTTL")]
        public System.Int64? DefaultCacheBehavior_MinTTL { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFront.Model.CreateDistributionWithTagsResponse).
        /// Specifying the name of a property of type Amazon.CloudFront.Model.CreateDistributionWithTagsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CFDistributionWithTag (CreateDistributionWithTags)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFront.Model.CreateDistributionWithTagsResponse, NewCFDistributionWithTagCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Aliases_Item != null)
            {
                context.Aliases_Item = new List<System.String>(this.Aliases_Item);
            }
            context.Aliases_Quantity = this.Aliases_Quantity;
            if (this.CacheBehaviors_Item != null)
            {
                context.CacheBehaviors_Item = new List<Amazon.CloudFront.Model.CacheBehavior>(this.CacheBehaviors_Item);
            }
            context.CacheBehaviors_Quantity = this.CacheBehaviors_Quantity;
            context.DistributionConfig_CallerReference = this.DistributionConfig_CallerReference;
            #if MODULAR
            if (this.DistributionConfig_CallerReference == null && ParameterWasBound(nameof(this.DistributionConfig_CallerReference)))
            {
                WriteWarning("You are passing $null as a value for parameter DistributionConfig_CallerReference which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DistributionConfig_Comment = this.DistributionConfig_Comment;
            #if MODULAR
            if (this.DistributionConfig_Comment == null && ParameterWasBound(nameof(this.DistributionConfig_Comment)))
            {
                WriteWarning("You are passing $null as a value for parameter DistributionConfig_Comment which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DistributionConfig_ContinuousDeploymentPolicyId = this.DistributionConfig_ContinuousDeploymentPolicyId;
            if (this.CustomErrorResponses_Item != null)
            {
                context.CustomErrorResponses_Item = new List<Amazon.CloudFront.Model.CustomErrorResponse>(this.CustomErrorResponses_Item);
            }
            context.CustomErrorResponses_Quantity = this.CustomErrorResponses_Quantity;
            if (this.CachedMethods_Item != null)
            {
                context.CachedMethods_Item = new List<System.String>(this.CachedMethods_Item);
            }
            context.CachedMethods_Quantity = this.CachedMethods_Quantity;
            if (this.AllowedMethods_Item != null)
            {
                context.AllowedMethods_Item = new List<System.String>(this.AllowedMethods_Item);
            }
            context.AllowedMethods_Quantity = this.AllowedMethods_Quantity;
            context.DefaultCacheBehavior_CachePolicyId = this.DefaultCacheBehavior_CachePolicyId;
            context.DefaultCacheBehavior_Compress = this.DefaultCacheBehavior_Compress;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DefaultCacheBehavior_DefaultTTL = this.DefaultCacheBehavior_DefaultTTL;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DefaultCacheBehavior_FieldLevelEncryptionId = this.DefaultCacheBehavior_FieldLevelEncryptionId;
            context.Cookies_Forward = this.Cookies_Forward;
            if (this.WhitelistedNames_Item != null)
            {
                context.WhitelistedNames_Item = new List<System.String>(this.WhitelistedNames_Item);
            }
            context.WhitelistedNames_Quantity = this.WhitelistedNames_Quantity;
            if (this.Headers_Item != null)
            {
                context.Headers_Item = new List<System.String>(this.Headers_Item);
            }
            context.Headers_Quantity = this.Headers_Quantity;
            context.ForwardedValues_QueryString = this.ForwardedValues_QueryString;
            if (this.QueryStringCacheKeys_Item != null)
            {
                context.QueryStringCacheKeys_Item = new List<System.String>(this.QueryStringCacheKeys_Item);
            }
            context.QueryStringCacheKeys_Quantity = this.QueryStringCacheKeys_Quantity;
            if (this.FunctionAssociations_Item != null)
            {
                context.FunctionAssociations_Item = new List<Amazon.CloudFront.Model.FunctionAssociation>(this.FunctionAssociations_Item);
            }
            context.FunctionAssociations_Quantity = this.FunctionAssociations_Quantity;
            if (this.LambdaFunctionAssociations_Item != null)
            {
                context.LambdaFunctionAssociations_Item = new List<Amazon.CloudFront.Model.LambdaFunctionAssociation>(this.LambdaFunctionAssociations_Item);
            }
            context.LambdaFunctionAssociations_Quantity = this.LambdaFunctionAssociations_Quantity;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DefaultCacheBehavior_MaxTTL = this.DefaultCacheBehavior_MaxTTL;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DefaultCacheBehavior_MinTTL = this.DefaultCacheBehavior_MinTTL;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DefaultCacheBehavior_OriginRequestPolicyId = this.DefaultCacheBehavior_OriginRequestPolicyId;
            context.DefaultCacheBehavior_RealtimeLogConfigArn = this.DefaultCacheBehavior_RealtimeLogConfigArn;
            context.DefaultCacheBehavior_ResponseHeadersPolicyId = this.DefaultCacheBehavior_ResponseHeadersPolicyId;
            context.DefaultCacheBehavior_SmoothStreaming = this.DefaultCacheBehavior_SmoothStreaming;
            context.DefaultCacheBehavior_TargetOriginId = this.DefaultCacheBehavior_TargetOriginId;
            #if MODULAR
            if (this.DefaultCacheBehavior_TargetOriginId == null && ParameterWasBound(nameof(this.DefaultCacheBehavior_TargetOriginId)))
            {
                WriteWarning("You are passing $null as a value for parameter DefaultCacheBehavior_TargetOriginId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TrustedKeyGroups_Enabled = this.TrustedKeyGroups_Enabled;
            if (this.TrustedKeyGroups_Item != null)
            {
                context.TrustedKeyGroups_Item = new List<System.String>(this.TrustedKeyGroups_Item);
            }
            context.TrustedKeyGroups_Quantity = this.TrustedKeyGroups_Quantity;
            context.TrustedSigners_Enabled = this.TrustedSigners_Enabled;
            if (this.TrustedSigners_Item != null)
            {
                context.TrustedSigners_Item = new List<System.String>(this.TrustedSigners_Item);
            }
            context.TrustedSigners_Quantity = this.TrustedSigners_Quantity;
            context.DefaultCacheBehavior_ViewerProtocolPolicy = this.DefaultCacheBehavior_ViewerProtocolPolicy;
            #if MODULAR
            if (this.DefaultCacheBehavior_ViewerProtocolPolicy == null && ParameterWasBound(nameof(this.DefaultCacheBehavior_ViewerProtocolPolicy)))
            {
                WriteWarning("You are passing $null as a value for parameter DefaultCacheBehavior_ViewerProtocolPolicy which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DistributionConfig_DefaultRootObject = this.DistributionConfig_DefaultRootObject;
            context.DistributionConfig_Enabled = this.DistributionConfig_Enabled;
            #if MODULAR
            if (this.DistributionConfig_Enabled == null && ParameterWasBound(nameof(this.DistributionConfig_Enabled)))
            {
                WriteWarning("You are passing $null as a value for parameter DistributionConfig_Enabled which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DistributionConfig_HttpVersion = this.DistributionConfig_HttpVersion;
            context.DistributionConfig_IsIPV6Enabled = this.DistributionConfig_IsIPV6Enabled;
            context.Logging_Bucket = this.Logging_Bucket;
            context.Logging_Enabled = this.Logging_Enabled;
            context.Logging_IncludeCookie = this.Logging_IncludeCookie;
            context.Logging_Prefix = this.Logging_Prefix;
            if (this.OriginGroups_Item != null)
            {
                context.OriginGroups_Item = new List<Amazon.CloudFront.Model.OriginGroup>(this.OriginGroups_Item);
            }
            context.OriginGroups_Quantity = this.OriginGroups_Quantity;
            if (this.Origins_Item != null)
            {
                context.Origins_Item = new List<Amazon.CloudFront.Model.Origin>(this.Origins_Item);
            }
            #if MODULAR
            if (this.Origins_Item == null && ParameterWasBound(nameof(this.Origins_Item)))
            {
                WriteWarning("You are passing $null as a value for parameter Origins_Item which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Origins_Quantity = this.Origins_Quantity;
            #if MODULAR
            if (this.Origins_Quantity == null && ParameterWasBound(nameof(this.Origins_Quantity)))
            {
                WriteWarning("You are passing $null as a value for parameter Origins_Quantity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DistributionConfig_PriceClass = this.DistributionConfig_PriceClass;
            if (this.GeoRestriction_Item != null)
            {
                context.GeoRestriction_Item = new List<System.String>(this.GeoRestriction_Item);
            }
            context.GeoRestriction_Quantity = this.GeoRestriction_Quantity;
            context.GeoRestriction_RestrictionType = this.GeoRestriction_RestrictionType;
            context.DistributionConfig_Staging = this.DistributionConfig_Staging;
            context.ViewerCertificate_ACMCertificateArn = this.ViewerCertificate_ACMCertificateArn;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ViewerCertificate_Certificate = this.ViewerCertificate_Certificate;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ViewerCertificate_CertificateSource = this.ViewerCertificate_CertificateSource;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ViewerCertificate_CloudFrontDefaultCertificate = this.ViewerCertificate_CloudFrontDefaultCertificate;
            context.ViewerCertificate_IAMCertificateId = this.ViewerCertificate_IAMCertificateId;
            context.ViewerCertificate_MinimumProtocolVersion = this.ViewerCertificate_MinimumProtocolVersion;
            context.ViewerCertificate_SSLSupportMethod = this.ViewerCertificate_SSLSupportMethod;
            context.DistributionConfig_WebACLId = this.DistributionConfig_WebACLId;
            if (this.Tags_Item != null)
            {
                context.Tags_Item = new List<Amazon.CloudFront.Model.Tag>(this.Tags_Item);
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
            var requestDistributionConfigWithTagsIsNull = true;
            request.DistributionConfigWithTags = new Amazon.CloudFront.Model.DistributionConfigWithTags();
            Amazon.CloudFront.Model.Tags requestDistributionConfigWithTags_distributionConfigWithTags_Tags = null;
            
             // populate Tags
            var requestDistributionConfigWithTags_distributionConfigWithTags_TagsIsNull = true;
            requestDistributionConfigWithTags_distributionConfigWithTags_Tags = new Amazon.CloudFront.Model.Tags();
            List<Amazon.CloudFront.Model.Tag> requestDistributionConfigWithTags_distributionConfigWithTags_Tags_tags_Item = null;
            if (cmdletContext.Tags_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_Tags_tags_Item = cmdletContext.Tags_Item;
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
            var requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfigIsNull = true;
            requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig = new Amazon.CloudFront.Model.DistributionConfig();
            System.String requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_CallerReference = null;
            if (cmdletContext.DistributionConfig_CallerReference != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_CallerReference = cmdletContext.DistributionConfig_CallerReference;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_CallerReference != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig.CallerReference = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_CallerReference;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfigIsNull = false;
            }
            System.String requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_Comment = null;
            if (cmdletContext.DistributionConfig_Comment != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_Comment = cmdletContext.DistributionConfig_Comment;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_Comment != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig.Comment = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_Comment;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfigIsNull = false;
            }
            System.String requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_ContinuousDeploymentPolicyId = null;
            if (cmdletContext.DistributionConfig_ContinuousDeploymentPolicyId != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_ContinuousDeploymentPolicyId = cmdletContext.DistributionConfig_ContinuousDeploymentPolicyId;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_ContinuousDeploymentPolicyId != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig.ContinuousDeploymentPolicyId = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_ContinuousDeploymentPolicyId;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfigIsNull = false;
            }
            System.String requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_DefaultRootObject = null;
            if (cmdletContext.DistributionConfig_DefaultRootObject != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_DefaultRootObject = cmdletContext.DistributionConfig_DefaultRootObject;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_DefaultRootObject != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig.DefaultRootObject = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_DefaultRootObject;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfigIsNull = false;
            }
            System.Boolean? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_Enabled = null;
            if (cmdletContext.DistributionConfig_Enabled != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_Enabled = cmdletContext.DistributionConfig_Enabled.Value;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_Enabled != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig.Enabled = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_Enabled.Value;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfigIsNull = false;
            }
            Amazon.CloudFront.HttpVersion requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_HttpVersion = null;
            if (cmdletContext.DistributionConfig_HttpVersion != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_HttpVersion = cmdletContext.DistributionConfig_HttpVersion;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_HttpVersion != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig.HttpVersion = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_HttpVersion;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfigIsNull = false;
            }
            System.Boolean? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_IsIPV6Enabled = null;
            if (cmdletContext.DistributionConfig_IsIPV6Enabled != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_IsIPV6Enabled = cmdletContext.DistributionConfig_IsIPV6Enabled.Value;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_IsIPV6Enabled != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig.IsIPV6Enabled = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_IsIPV6Enabled.Value;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfigIsNull = false;
            }
            Amazon.CloudFront.PriceClass requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_PriceClass = null;
            if (cmdletContext.DistributionConfig_PriceClass != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_PriceClass = cmdletContext.DistributionConfig_PriceClass;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_PriceClass != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig.PriceClass = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_PriceClass;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfigIsNull = false;
            }
            System.Boolean? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_Staging = null;
            if (cmdletContext.DistributionConfig_Staging != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_Staging = cmdletContext.DistributionConfig_Staging.Value;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_Staging != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig.Staging = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_Staging.Value;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfigIsNull = false;
            }
            System.String requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_WebACLId = null;
            if (cmdletContext.DistributionConfig_WebACLId != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_WebACLId = cmdletContext.DistributionConfig_WebACLId;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_WebACLId != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig.WebACLId = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfig_WebACLId;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfigIsNull = false;
            }
            Amazon.CloudFront.Model.Restrictions requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions = null;
            
             // populate Restrictions
            var requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_RestrictionsIsNull = true;
            requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions = new Amazon.CloudFront.Model.Restrictions();
            Amazon.CloudFront.Model.GeoRestriction requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions_distributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction = null;
            
             // populate GeoRestriction
            var requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions_distributionConfigWithTags_DistributionConfig_Restrictions_GeoRestrictionIsNull = true;
            requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions_distributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction = new Amazon.CloudFront.Model.GeoRestriction();
            List<System.String> requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions_distributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_geoRestriction_Item = null;
            if (cmdletContext.GeoRestriction_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions_distributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_geoRestriction_Item = cmdletContext.GeoRestriction_Item;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions_distributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_geoRestriction_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions_distributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction.Items = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions_distributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_geoRestriction_Item;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions_distributionConfigWithTags_DistributionConfig_Restrictions_GeoRestrictionIsNull = false;
            }
            System.Int32? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions_distributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_geoRestriction_Quantity = null;
            if (cmdletContext.GeoRestriction_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions_distributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_geoRestriction_Quantity = cmdletContext.GeoRestriction_Quantity.Value;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions_distributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_geoRestriction_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions_distributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction.Quantity = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions_distributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_geoRestriction_Quantity.Value;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions_distributionConfigWithTags_DistributionConfig_Restrictions_GeoRestrictionIsNull = false;
            }
            Amazon.CloudFront.GeoRestrictionType requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions_distributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_geoRestriction_RestrictionType = null;
            if (cmdletContext.GeoRestriction_RestrictionType != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Restrictions_distributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_geoRestriction_RestrictionType = cmdletContext.GeoRestriction_RestrictionType;
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
            var requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_AliasesIsNull = true;
            requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Aliases = new Amazon.CloudFront.Model.Aliases();
            List<System.String> requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Aliases_aliases_Item = null;
            if (cmdletContext.Aliases_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Aliases_aliases_Item = cmdletContext.Aliases_Item;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Aliases_aliases_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Aliases.Items = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Aliases_aliases_Item;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_AliasesIsNull = false;
            }
            System.Int32? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Aliases_aliases_Quantity = null;
            if (cmdletContext.Aliases_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Aliases_aliases_Quantity = cmdletContext.Aliases_Quantity.Value;
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
            var requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CacheBehaviorsIsNull = true;
            requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CacheBehaviors = new Amazon.CloudFront.Model.CacheBehaviors();
            List<Amazon.CloudFront.Model.CacheBehavior> requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CacheBehaviors_cacheBehaviors_Item = null;
            if (cmdletContext.CacheBehaviors_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CacheBehaviors_cacheBehaviors_Item = cmdletContext.CacheBehaviors_Item;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CacheBehaviors_cacheBehaviors_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CacheBehaviors.Items = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CacheBehaviors_cacheBehaviors_Item;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CacheBehaviorsIsNull = false;
            }
            System.Int32? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CacheBehaviors_cacheBehaviors_Quantity = null;
            if (cmdletContext.CacheBehaviors_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CacheBehaviors_cacheBehaviors_Quantity = cmdletContext.CacheBehaviors_Quantity.Value;
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
            var requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CustomErrorResponsesIsNull = true;
            requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CustomErrorResponses = new Amazon.CloudFront.Model.CustomErrorResponses();
            List<Amazon.CloudFront.Model.CustomErrorResponse> requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CustomErrorResponses_customErrorResponses_Item = null;
            if (cmdletContext.CustomErrorResponses_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CustomErrorResponses_customErrorResponses_Item = cmdletContext.CustomErrorResponses_Item;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CustomErrorResponses_customErrorResponses_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CustomErrorResponses.Items = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CustomErrorResponses_customErrorResponses_Item;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CustomErrorResponsesIsNull = false;
            }
            System.Int32? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CustomErrorResponses_customErrorResponses_Quantity = null;
            if (cmdletContext.CustomErrorResponses_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_CustomErrorResponses_customErrorResponses_Quantity = cmdletContext.CustomErrorResponses_Quantity.Value;
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
            Amazon.CloudFront.Model.OriginGroups requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_OriginGroups = null;
            
             // populate OriginGroups
            var requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_OriginGroupsIsNull = true;
            requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_OriginGroups = new Amazon.CloudFront.Model.OriginGroups();
            List<Amazon.CloudFront.Model.OriginGroup> requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_OriginGroups_originGroups_Item = null;
            if (cmdletContext.OriginGroups_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_OriginGroups_originGroups_Item = cmdletContext.OriginGroups_Item;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_OriginGroups_originGroups_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_OriginGroups.Items = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_OriginGroups_originGroups_Item;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_OriginGroupsIsNull = false;
            }
            System.Int32? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_OriginGroups_originGroups_Quantity = null;
            if (cmdletContext.OriginGroups_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_OriginGroups_originGroups_Quantity = cmdletContext.OriginGroups_Quantity.Value;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_OriginGroups_originGroups_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_OriginGroups.Quantity = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_OriginGroups_originGroups_Quantity.Value;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_OriginGroupsIsNull = false;
            }
             // determine if requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_OriginGroups should be set to null
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_OriginGroupsIsNull)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_OriginGroups = null;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_OriginGroups != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig.OriginGroups = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_OriginGroups;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfigIsNull = false;
            }
            Amazon.CloudFront.Model.Origins requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Origins = null;
            
             // populate Origins
            var requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_OriginsIsNull = true;
            requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Origins = new Amazon.CloudFront.Model.Origins();
            List<Amazon.CloudFront.Model.Origin> requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Origins_origins_Item = null;
            if (cmdletContext.Origins_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Origins_origins_Item = cmdletContext.Origins_Item;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Origins_origins_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Origins.Items = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Origins_origins_Item;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_OriginsIsNull = false;
            }
            System.Int32? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Origins_origins_Quantity = null;
            if (cmdletContext.Origins_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Origins_origins_Quantity = cmdletContext.Origins_Quantity.Value;
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
            var requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_LoggingIsNull = true;
            requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging = new Amazon.CloudFront.Model.LoggingConfig();
            System.String requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging_logging_Bucket = null;
            if (cmdletContext.Logging_Bucket != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging_logging_Bucket = cmdletContext.Logging_Bucket;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging_logging_Bucket != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging.Bucket = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging_logging_Bucket;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_LoggingIsNull = false;
            }
            System.Boolean? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging_logging_Enabled = null;
            if (cmdletContext.Logging_Enabled != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging_logging_Enabled = cmdletContext.Logging_Enabled.Value;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging_logging_Enabled != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging.Enabled = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging_logging_Enabled.Value;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_LoggingIsNull = false;
            }
            System.Boolean? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging_logging_IncludeCookie = null;
            if (cmdletContext.Logging_IncludeCookie != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging_logging_IncludeCookie = cmdletContext.Logging_IncludeCookie.Value;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging_logging_IncludeCookie != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging.IncludeCookies = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging_logging_IncludeCookie.Value;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_LoggingIsNull = false;
            }
            System.String requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging_logging_Prefix = null;
            if (cmdletContext.Logging_Prefix != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_Logging_logging_Prefix = cmdletContext.Logging_Prefix;
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
            var requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificateIsNull = true;
            requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate = new Amazon.CloudFront.Model.ViewerCertificate();
            System.String requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_ACMCertificateArn = null;
            if (cmdletContext.ViewerCertificate_ACMCertificateArn != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_ACMCertificateArn = cmdletContext.ViewerCertificate_ACMCertificateArn;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_ACMCertificateArn != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate.ACMCertificateArn = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_ACMCertificateArn;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificateIsNull = false;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            System.String requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_Certificate = null;
            if (cmdletContext.ViewerCertificate_Certificate != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_Certificate = cmdletContext.ViewerCertificate_Certificate;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_Certificate != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate.Certificate = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_Certificate;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificateIsNull = false;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            Amazon.CloudFront.CertificateSource requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_CertificateSource = null;
            if (cmdletContext.ViewerCertificate_CertificateSource != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_CertificateSource = cmdletContext.ViewerCertificate_CertificateSource;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_CertificateSource != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate.CertificateSource = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_CertificateSource;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificateIsNull = false;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            System.Boolean? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_CloudFrontDefaultCertificate = null;
            if (cmdletContext.ViewerCertificate_CloudFrontDefaultCertificate != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_CloudFrontDefaultCertificate = cmdletContext.ViewerCertificate_CloudFrontDefaultCertificate.Value;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_CloudFrontDefaultCertificate != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate.CloudFrontDefaultCertificate = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_CloudFrontDefaultCertificate.Value;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificateIsNull = false;
            }
            System.String requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_IAMCertificateId = null;
            if (cmdletContext.ViewerCertificate_IAMCertificateId != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_IAMCertificateId = cmdletContext.ViewerCertificate_IAMCertificateId;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_IAMCertificateId != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate.IAMCertificateId = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_IAMCertificateId;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificateIsNull = false;
            }
            Amazon.CloudFront.MinimumProtocolVersion requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_MinimumProtocolVersion = null;
            if (cmdletContext.ViewerCertificate_MinimumProtocolVersion != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_MinimumProtocolVersion = cmdletContext.ViewerCertificate_MinimumProtocolVersion;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_MinimumProtocolVersion != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate.MinimumProtocolVersion = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_MinimumProtocolVersion;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificateIsNull = false;
            }
            Amazon.CloudFront.SSLSupportMethod requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_SSLSupportMethod = null;
            if (cmdletContext.ViewerCertificate_SSLSupportMethod != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_ViewerCertificate_viewerCertificate_SSLSupportMethod = cmdletContext.ViewerCertificate_SSLSupportMethod;
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
            var requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehaviorIsNull = true;
            requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior = new Amazon.CloudFront.Model.DefaultCacheBehavior();
            System.String requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_CachePolicyId = null;
            if (cmdletContext.DefaultCacheBehavior_CachePolicyId != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_CachePolicyId = cmdletContext.DefaultCacheBehavior_CachePolicyId;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_CachePolicyId != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior.CachePolicyId = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_CachePolicyId;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            System.Boolean? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_Compress = null;
            if (cmdletContext.DefaultCacheBehavior_Compress != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_Compress = cmdletContext.DefaultCacheBehavior_Compress.Value;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_Compress != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior.Compress = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_Compress.Value;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            System.Int64? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_DefaultTTL = null;
            if (cmdletContext.DefaultCacheBehavior_DefaultTTL != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_DefaultTTL = cmdletContext.DefaultCacheBehavior_DefaultTTL.Value;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_DefaultTTL != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior.DefaultTTL = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_DefaultTTL.Value;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            System.String requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_FieldLevelEncryptionId = null;
            if (cmdletContext.DefaultCacheBehavior_FieldLevelEncryptionId != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_FieldLevelEncryptionId = cmdletContext.DefaultCacheBehavior_FieldLevelEncryptionId;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_FieldLevelEncryptionId != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior.FieldLevelEncryptionId = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_FieldLevelEncryptionId;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            System.Int64? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_MaxTTL = null;
            if (cmdletContext.DefaultCacheBehavior_MaxTTL != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_MaxTTL = cmdletContext.DefaultCacheBehavior_MaxTTL.Value;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_MaxTTL != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior.MaxTTL = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_MaxTTL.Value;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            System.Int64? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_MinTTL = null;
            if (cmdletContext.DefaultCacheBehavior_MinTTL != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_MinTTL = cmdletContext.DefaultCacheBehavior_MinTTL.Value;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_MinTTL != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior.MinTTL = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_MinTTL.Value;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            System.String requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_OriginRequestPolicyId = null;
            if (cmdletContext.DefaultCacheBehavior_OriginRequestPolicyId != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_OriginRequestPolicyId = cmdletContext.DefaultCacheBehavior_OriginRequestPolicyId;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_OriginRequestPolicyId != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior.OriginRequestPolicyId = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_OriginRequestPolicyId;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            System.String requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_RealtimeLogConfigArn = null;
            if (cmdletContext.DefaultCacheBehavior_RealtimeLogConfigArn != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_RealtimeLogConfigArn = cmdletContext.DefaultCacheBehavior_RealtimeLogConfigArn;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_RealtimeLogConfigArn != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior.RealtimeLogConfigArn = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_RealtimeLogConfigArn;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            System.String requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_ResponseHeadersPolicyId = null;
            if (cmdletContext.DefaultCacheBehavior_ResponseHeadersPolicyId != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_ResponseHeadersPolicyId = cmdletContext.DefaultCacheBehavior_ResponseHeadersPolicyId;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_ResponseHeadersPolicyId != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior.ResponseHeadersPolicyId = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_ResponseHeadersPolicyId;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            System.Boolean? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_SmoothStreaming = null;
            if (cmdletContext.DefaultCacheBehavior_SmoothStreaming != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_SmoothStreaming = cmdletContext.DefaultCacheBehavior_SmoothStreaming.Value;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_SmoothStreaming != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior.SmoothStreaming = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_SmoothStreaming.Value;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            System.String requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_TargetOriginId = null;
            if (cmdletContext.DefaultCacheBehavior_TargetOriginId != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_TargetOriginId = cmdletContext.DefaultCacheBehavior_TargetOriginId;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_TargetOriginId != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior.TargetOriginId = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_TargetOriginId;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            Amazon.CloudFront.ViewerProtocolPolicy requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_ViewerProtocolPolicy = null;
            if (cmdletContext.DefaultCacheBehavior_ViewerProtocolPolicy != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_ViewerProtocolPolicy = cmdletContext.DefaultCacheBehavior_ViewerProtocolPolicy;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_ViewerProtocolPolicy != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior.ViewerProtocolPolicy = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_defaultCacheBehavior_ViewerProtocolPolicy;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            Amazon.CloudFront.Model.FunctionAssociations requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_FunctionAssociations = null;
            
             // populate FunctionAssociations
            var requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_FunctionAssociationsIsNull = true;
            requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_FunctionAssociations = new Amazon.CloudFront.Model.FunctionAssociations();
            List<Amazon.CloudFront.Model.FunctionAssociation> requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_FunctionAssociations_functionAssociations_Item = null;
            if (cmdletContext.FunctionAssociations_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_FunctionAssociations_functionAssociations_Item = cmdletContext.FunctionAssociations_Item;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_FunctionAssociations_functionAssociations_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_FunctionAssociations.Items = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_FunctionAssociations_functionAssociations_Item;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_FunctionAssociationsIsNull = false;
            }
            System.Int32? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_FunctionAssociations_functionAssociations_Quantity = null;
            if (cmdletContext.FunctionAssociations_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_FunctionAssociations_functionAssociations_Quantity = cmdletContext.FunctionAssociations_Quantity.Value;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_FunctionAssociations_functionAssociations_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_FunctionAssociations.Quantity = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_FunctionAssociations_functionAssociations_Quantity.Value;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_FunctionAssociationsIsNull = false;
            }
             // determine if requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_FunctionAssociations should be set to null
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_FunctionAssociationsIsNull)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_FunctionAssociations = null;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_FunctionAssociations != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior.FunctionAssociations = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_FunctionAssociations;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            Amazon.CloudFront.Model.LambdaFunctionAssociations requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations = null;
            
             // populate LambdaFunctionAssociations
            var requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociationsIsNull = true;
            requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations = new Amazon.CloudFront.Model.LambdaFunctionAssociations();
            List<Amazon.CloudFront.Model.LambdaFunctionAssociation> requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_lambdaFunctionAssociations_Item = null;
            if (cmdletContext.LambdaFunctionAssociations_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_lambdaFunctionAssociations_Item = cmdletContext.LambdaFunctionAssociations_Item;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_lambdaFunctionAssociations_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations.Items = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_lambdaFunctionAssociations_Item;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociationsIsNull = false;
            }
            System.Int32? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_lambdaFunctionAssociations_Quantity = null;
            if (cmdletContext.LambdaFunctionAssociations_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_lambdaFunctionAssociations_Quantity = cmdletContext.LambdaFunctionAssociations_Quantity.Value;
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
            var requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethodsIsNull = true;
            requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods = new Amazon.CloudFront.Model.AllowedMethods();
            List<System.String> requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_allowedMethods_Item = null;
            if (cmdletContext.AllowedMethods_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_allowedMethods_Item = cmdletContext.AllowedMethods_Item;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_allowedMethods_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods.Items = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_allowedMethods_Item;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethodsIsNull = false;
            }
            System.Int32? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_allowedMethods_Quantity = null;
            if (cmdletContext.AllowedMethods_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_allowedMethods_Quantity = cmdletContext.AllowedMethods_Quantity.Value;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_allowedMethods_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods.Quantity = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_allowedMethods_Quantity.Value;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethodsIsNull = false;
            }
            Amazon.CloudFront.Model.CachedMethods requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods = null;
            
             // populate CachedMethods
            var requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethodsIsNull = true;
            requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods = new Amazon.CloudFront.Model.CachedMethods();
            List<System.String> requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_cachedMethods_Item = null;
            if (cmdletContext.CachedMethods_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_cachedMethods_Item = cmdletContext.CachedMethods_Item;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_cachedMethods_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods.Items = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_cachedMethods_Item;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethodsIsNull = false;
            }
            System.Int32? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_cachedMethods_Quantity = null;
            if (cmdletContext.CachedMethods_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_cachedMethods_Quantity = cmdletContext.CachedMethods_Quantity.Value;
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
            Amazon.CloudFront.Model.TrustedKeyGroups requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedKeyGroups = null;
            
             // populate TrustedKeyGroups
            var requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedKeyGroupsIsNull = true;
            requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedKeyGroups = new Amazon.CloudFront.Model.TrustedKeyGroups();
            System.Boolean? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedKeyGroups_trustedKeyGroups_Enabled = null;
            if (cmdletContext.TrustedKeyGroups_Enabled != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedKeyGroups_trustedKeyGroups_Enabled = cmdletContext.TrustedKeyGroups_Enabled.Value;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedKeyGroups_trustedKeyGroups_Enabled != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedKeyGroups.Enabled = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedKeyGroups_trustedKeyGroups_Enabled.Value;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedKeyGroupsIsNull = false;
            }
            List<System.String> requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedKeyGroups_trustedKeyGroups_Item = null;
            if (cmdletContext.TrustedKeyGroups_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedKeyGroups_trustedKeyGroups_Item = cmdletContext.TrustedKeyGroups_Item;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedKeyGroups_trustedKeyGroups_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedKeyGroups.Items = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedKeyGroups_trustedKeyGroups_Item;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedKeyGroupsIsNull = false;
            }
            System.Int32? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedKeyGroups_trustedKeyGroups_Quantity = null;
            if (cmdletContext.TrustedKeyGroups_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedKeyGroups_trustedKeyGroups_Quantity = cmdletContext.TrustedKeyGroups_Quantity.Value;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedKeyGroups_trustedKeyGroups_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedKeyGroups.Quantity = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedKeyGroups_trustedKeyGroups_Quantity.Value;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedKeyGroupsIsNull = false;
            }
             // determine if requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedKeyGroups should be set to null
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedKeyGroupsIsNull)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedKeyGroups = null;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedKeyGroups != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior.TrustedKeyGroups = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedKeyGroups;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            Amazon.CloudFront.Model.TrustedSigners requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners = null;
            
             // populate TrustedSigners
            var requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSignersIsNull = true;
            requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners = new Amazon.CloudFront.Model.TrustedSigners();
            System.Boolean? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Enabled = null;
            if (cmdletContext.TrustedSigners_Enabled != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Enabled = cmdletContext.TrustedSigners_Enabled.Value;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Enabled != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners.Enabled = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Enabled.Value;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSignersIsNull = false;
            }
            List<System.String> requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Item = null;
            if (cmdletContext.TrustedSigners_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Item = cmdletContext.TrustedSigners_Item;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners.Items = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Item;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSignersIsNull = false;
            }
            System.Int32? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Quantity = null;
            if (cmdletContext.TrustedSigners_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Quantity = cmdletContext.TrustedSigners_Quantity.Value;
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
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            Amazon.CloudFront.Model.ForwardedValues requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues = null;
            
             // populate ForwardedValues
            var requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValuesIsNull = true;
            requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues = new Amazon.CloudFront.Model.ForwardedValues();
            System.Boolean? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_forwardedValues_QueryString = null;
            if (cmdletContext.ForwardedValues_QueryString != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_forwardedValues_QueryString = cmdletContext.ForwardedValues_QueryString.Value;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_forwardedValues_QueryString != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues.QueryString = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_forwardedValues_QueryString.Value;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValuesIsNull = false;
            }
            Amazon.CloudFront.Model.CookiePreference requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies = null;
            
             // populate Cookies
            var requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_CookiesIsNull = true;
            requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies = new Amazon.CloudFront.Model.CookiePreference();
            Amazon.CloudFront.ItemSelection requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_cookies_Forward = null;
            if (cmdletContext.Cookies_Forward != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_cookies_Forward = cmdletContext.Cookies_Forward;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_cookies_Forward != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies.Forward = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_cookies_Forward;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_CookiesIsNull = false;
            }
            Amazon.CloudFront.Model.CookieNames requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames = null;
            
             // populate WhitelistedNames
            var requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNamesIsNull = true;
            requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames = new Amazon.CloudFront.Model.CookieNames();
            List<System.String> requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_whitelistedNames_Item = null;
            if (cmdletContext.WhitelistedNames_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_whitelistedNames_Item = cmdletContext.WhitelistedNames_Item;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_whitelistedNames_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames.Items = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_whitelistedNames_Item;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNamesIsNull = false;
            }
            System.Int32? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_whitelistedNames_Quantity = null;
            if (cmdletContext.WhitelistedNames_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_whitelistedNames_Quantity = cmdletContext.WhitelistedNames_Quantity.Value;
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
            var requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_HeadersIsNull = true;
            requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers = new Amazon.CloudFront.Model.Headers();
            List<System.String> requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_headers_Item = null;
            if (cmdletContext.Headers_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_headers_Item = cmdletContext.Headers_Item;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_headers_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers.Items = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_headers_Item;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_HeadersIsNull = false;
            }
            System.Int32? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_headers_Quantity = null;
            if (cmdletContext.Headers_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_headers_Quantity = cmdletContext.Headers_Quantity.Value;
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
            var requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeysIsNull = true;
            requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys = new Amazon.CloudFront.Model.QueryStringCacheKeys();
            List<System.String> requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_queryStringCacheKeys_Item = null;
            if (cmdletContext.QueryStringCacheKeys_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_queryStringCacheKeys_Item = cmdletContext.QueryStringCacheKeys_Item;
            }
            if (requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_queryStringCacheKeys_Item != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys.Items = requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_queryStringCacheKeys_Item;
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeysIsNull = false;
            }
            System.Int32? requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_queryStringCacheKeys_Quantity = null;
            if (cmdletContext.QueryStringCacheKeys_Quantity != null)
            {
                requestDistributionConfigWithTags_distributionConfigWithTags_DistributionConfig_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_queryStringCacheKeys_Quantity = cmdletContext.QueryStringCacheKeys_Quantity.Value;
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
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
        
        private Amazon.CloudFront.Model.CreateDistributionWithTagsResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.CreateDistributionWithTagsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "CreateDistributionWithTags");
            try
            {
                #if DESKTOP
                return client.CreateDistributionWithTags(request);
                #elif CORECLR
                return client.CreateDistributionWithTagsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Aliases_Item { get; set; }
            public System.Int32? Aliases_Quantity { get; set; }
            public List<Amazon.CloudFront.Model.CacheBehavior> CacheBehaviors_Item { get; set; }
            public System.Int32? CacheBehaviors_Quantity { get; set; }
            public System.String DistributionConfig_CallerReference { get; set; }
            public System.String DistributionConfig_Comment { get; set; }
            public System.String DistributionConfig_ContinuousDeploymentPolicyId { get; set; }
            public List<Amazon.CloudFront.Model.CustomErrorResponse> CustomErrorResponses_Item { get; set; }
            public System.Int32? CustomErrorResponses_Quantity { get; set; }
            public List<System.String> CachedMethods_Item { get; set; }
            public System.Int32? CachedMethods_Quantity { get; set; }
            public List<System.String> AllowedMethods_Item { get; set; }
            public System.Int32? AllowedMethods_Quantity { get; set; }
            public System.String DefaultCacheBehavior_CachePolicyId { get; set; }
            public System.Boolean? DefaultCacheBehavior_Compress { get; set; }
            [System.ObsoleteAttribute]
            public System.Int64? DefaultCacheBehavior_DefaultTTL { get; set; }
            public System.String DefaultCacheBehavior_FieldLevelEncryptionId { get; set; }
            public Amazon.CloudFront.ItemSelection Cookies_Forward { get; set; }
            public List<System.String> WhitelistedNames_Item { get; set; }
            public System.Int32? WhitelistedNames_Quantity { get; set; }
            public List<System.String> Headers_Item { get; set; }
            public System.Int32? Headers_Quantity { get; set; }
            public System.Boolean? ForwardedValues_QueryString { get; set; }
            public List<System.String> QueryStringCacheKeys_Item { get; set; }
            public System.Int32? QueryStringCacheKeys_Quantity { get; set; }
            public List<Amazon.CloudFront.Model.FunctionAssociation> FunctionAssociations_Item { get; set; }
            public System.Int32? FunctionAssociations_Quantity { get; set; }
            public List<Amazon.CloudFront.Model.LambdaFunctionAssociation> LambdaFunctionAssociations_Item { get; set; }
            public System.Int32? LambdaFunctionAssociations_Quantity { get; set; }
            [System.ObsoleteAttribute]
            public System.Int64? DefaultCacheBehavior_MaxTTL { get; set; }
            [System.ObsoleteAttribute]
            public System.Int64? DefaultCacheBehavior_MinTTL { get; set; }
            public System.String DefaultCacheBehavior_OriginRequestPolicyId { get; set; }
            public System.String DefaultCacheBehavior_RealtimeLogConfigArn { get; set; }
            public System.String DefaultCacheBehavior_ResponseHeadersPolicyId { get; set; }
            public System.Boolean? DefaultCacheBehavior_SmoothStreaming { get; set; }
            public System.String DefaultCacheBehavior_TargetOriginId { get; set; }
            public System.Boolean? TrustedKeyGroups_Enabled { get; set; }
            public List<System.String> TrustedKeyGroups_Item { get; set; }
            public System.Int32? TrustedKeyGroups_Quantity { get; set; }
            public System.Boolean? TrustedSigners_Enabled { get; set; }
            public List<System.String> TrustedSigners_Item { get; set; }
            public System.Int32? TrustedSigners_Quantity { get; set; }
            public Amazon.CloudFront.ViewerProtocolPolicy DefaultCacheBehavior_ViewerProtocolPolicy { get; set; }
            public System.String DistributionConfig_DefaultRootObject { get; set; }
            public System.Boolean? DistributionConfig_Enabled { get; set; }
            public Amazon.CloudFront.HttpVersion DistributionConfig_HttpVersion { get; set; }
            public System.Boolean? DistributionConfig_IsIPV6Enabled { get; set; }
            public System.String Logging_Bucket { get; set; }
            public System.Boolean? Logging_Enabled { get; set; }
            public System.Boolean? Logging_IncludeCookie { get; set; }
            public System.String Logging_Prefix { get; set; }
            public List<Amazon.CloudFront.Model.OriginGroup> OriginGroups_Item { get; set; }
            public System.Int32? OriginGroups_Quantity { get; set; }
            public List<Amazon.CloudFront.Model.Origin> Origins_Item { get; set; }
            public System.Int32? Origins_Quantity { get; set; }
            public Amazon.CloudFront.PriceClass DistributionConfig_PriceClass { get; set; }
            public List<System.String> GeoRestriction_Item { get; set; }
            public System.Int32? GeoRestriction_Quantity { get; set; }
            public Amazon.CloudFront.GeoRestrictionType GeoRestriction_RestrictionType { get; set; }
            public System.Boolean? DistributionConfig_Staging { get; set; }
            public System.String ViewerCertificate_ACMCertificateArn { get; set; }
            [System.ObsoleteAttribute]
            public System.String ViewerCertificate_Certificate { get; set; }
            [System.ObsoleteAttribute]
            public Amazon.CloudFront.CertificateSource ViewerCertificate_CertificateSource { get; set; }
            public System.Boolean? ViewerCertificate_CloudFrontDefaultCertificate { get; set; }
            public System.String ViewerCertificate_IAMCertificateId { get; set; }
            public Amazon.CloudFront.MinimumProtocolVersion ViewerCertificate_MinimumProtocolVersion { get; set; }
            public Amazon.CloudFront.SSLSupportMethod ViewerCertificate_SSLSupportMethod { get; set; }
            public System.String DistributionConfig_WebACLId { get; set; }
            public List<Amazon.CloudFront.Model.Tag> Tags_Item { get; set; }
            public System.Func<Amazon.CloudFront.Model.CreateDistributionWithTagsResponse, NewCFDistributionWithTagCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
