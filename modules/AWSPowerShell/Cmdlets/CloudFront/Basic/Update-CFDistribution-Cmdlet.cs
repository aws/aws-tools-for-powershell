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
    /// Updates the configuration for a web distribution. 
    /// 
    ///  <important><para>
    /// When you update a distribution, there are more required fields than when you create
    /// a distribution. When you update your distribution by using this API action, follow
    /// the steps here to get the current configuration and then make your updates, to make
    /// sure that you include all of the required fields. To view a summary, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/distribution-overview-required-fields.html">Required
    /// Fields for Create Distribution and Update Distribution</a> in the <i>Amazon CloudFront
    /// Developer Guide</i>.
    /// </para></important><para>
    /// The update process includes getting the current distribution configuration, updating
    /// the XML document that is returned to make your changes, and then submitting an <code>UpdateDistribution</code>
    /// request to make the updates.
    /// </para><para>
    /// For information about updating a distribution using the CloudFront console instead,
    /// see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/distribution-web-creating-console.html">Creating
    /// a Distribution</a> in the <i>Amazon CloudFront Developer Guide</i>.
    /// </para><para><b>To update a web distribution using the CloudFront API</b></para><ol><li><para>
    /// Submit a <a href="https://docs.aws.amazon.com/cloudfront/latest/APIReference/API_GetDistributionConfig.html">GetDistributionConfig</a>
    /// request to get the current configuration and an <code>Etag</code> header for the distribution.
    /// </para><note><para>
    /// If you update the distribution again, you must get a new <code>Etag</code> header.
    /// </para></note></li><li><para>
    /// Update the XML document that was returned in the response to your <code>GetDistributionConfig</code>
    /// request to include your changes. 
    /// </para><important><para>
    /// When you edit the XML file, be aware of the following:
    /// </para><ul><li><para>
    /// You must strip out the ETag parameter that is returned.
    /// </para></li><li><para>
    /// Additional fields are required when you update a distribution. There may be fields
    /// included in the XML file for features that you haven't configured for your distribution.
    /// This is expected and required to successfully update the distribution.
    /// </para></li><li><para>
    /// You can't change the value of <code>CallerReference</code>. If you try to change this
    /// value, CloudFront returns an <code>IllegalUpdate</code> error. 
    /// </para></li><li><para>
    /// The new configuration replaces the existing configuration; the values that you specify
    /// in an <code>UpdateDistribution</code> request are not merged into your existing configuration.
    /// When you add, delete, or replace values in an element that allows multiple values
    /// (for example, <code>CNAME</code>), you must specify all of the values that you want
    /// to appear in the updated distribution. In addition, you must update the corresponding
    /// <code>Quantity</code> element.
    /// </para></li></ul></important></li><li><para>
    /// Submit an <code>UpdateDistribution</code> request to update the configuration for
    /// your distribution:
    /// </para><ul><li><para>
    /// In the request body, include the XML document that you updated in Step 2. The request
    /// body must include an XML document with a <code>DistributionConfig</code> element.
    /// </para></li><li><para>
    /// Set the value of the HTTP <code>If-Match</code> header to the value of the <code>ETag</code>
    /// header that CloudFront returned when you submitted the <code>GetDistributionConfig</code>
    /// request in Step 1.
    /// </para></li></ul></li><li><para>
    /// Review the response to the <code>UpdateDistribution</code> request to confirm that
    /// the configuration was successfully updated.
    /// </para></li><li><para>
    /// Optional: Submit a <a href="https://docs.aws.amazon.com/cloudfront/latest/APIReference/API_GetDistribution.html">GetDistribution</a>
    /// request to confirm that your changes have propagated. When propagation is complete,
    /// the value of <code>Status</code> is <code>Deployed</code>.
    /// </para></li></ol>
    /// </summary>
    [Cmdlet("Update", "CFDistribution", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudFront.Model.Distribution")]
    [AWSCmdlet("Calls the Amazon CloudFront UpdateDistribution API operation.", Operation = new[] {"UpdateDistribution"}, SelectReturnType = typeof(Amazon.CloudFront.Model.UpdateDistributionResponse))]
    [AWSCmdletOutput("Amazon.CloudFront.Model.Distribution or Amazon.CloudFront.Model.UpdateDistributionResponse",
        "This cmdlet returns an Amazon.CloudFront.Model.Distribution object.",
        "The service call response (type Amazon.CloudFront.Model.UpdateDistributionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateCFDistributionCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
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
        [Alias("DistributionConfig_ViewerCertificate_ACMCertificateArn")]
        public System.String ViewerCertificate_ACMCertificateArn { get; set; }
        #endregion
        
        #region Parameter Logging_Bucket
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket to store the access logs in, for example, <code>myawslogbucket.s3.amazonaws.com</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfig_Logging_Bucket")]
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
        [Alias("DistributionConfig_DefaultCacheBehavior_CachePolicyId")]
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
        [Alias("DistributionConfig_ViewerCertificate_CloudFrontDefaultCertificate")]
        public System.Boolean? ViewerCertificate_CloudFrontDefaultCertificate { get; set; }
        #endregion
        
        #region Parameter DistributionConfig_Comment
        /// <summary>
        /// <para>
        /// <para>An optional comment to describe the distribution. The comment cannot be longer than
        /// 128 characters.</para>
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
        [Alias("DistributionConfig_DefaultCacheBehavior_Compress")]
        public System.Boolean? DefaultCacheBehavior_Compress { get; set; }
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
        /// the new object.</para><para>For more information about the default root object, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/DefaultRootObject.html">Creating
        /// a Default Root Object</a> in the <i>Amazon CloudFront Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [Alias("DistributionConfig_DefaultCacheBehavior_TrustedKeyGroups_Enabled")]
        public System.Boolean? TrustedKeyGroups_Enabled { get; set; }
        #endregion
        
        #region Parameter TrustedSigners_Enabled
        /// <summary>
        /// <para>
        /// <para>This field is <code>true</code> if any of the Amazon Web Services accounts have public
        /// keys that CloudFront can use to verify the signatures of signed URLs and signed cookies.
        /// If not, this field is <code>false</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfig_DefaultCacheBehavior_TrustedSigners_Enabled")]
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
        [Alias("DistributionConfig_Logging_Enabled")]
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
        [Alias("DistributionConfig_DefaultCacheBehavior_FieldLevelEncryptionId")]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [Alias("DistributionConfig_ViewerCertificate_IAMCertificateId")]
        public System.String ViewerCertificate_IAMCertificateId { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The distribution's id.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter IfMatch
        /// <summary>
        /// <para>
        /// <para>The value of the <code>ETag</code> header that you received when retrieving the distribution's
        /// configuration. For example: <code>E2QWRUHAPOMQZL</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String IfMatch { get; set; }
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
        [Alias("DistributionConfig_Logging_IncludeCookies")]
        public System.Boolean? Logging_IncludeCookie { get; set; }
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfig_DefaultCacheBehavior_AllowedMethods_Items")]
        public System.String[] AllowedMethods_Item { get; set; }
        #endregion
        
        #region Parameter WhitelistedNames_Item
        /// <summary>
        /// <para>
        /// <para>A list of cookie names.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_Items")]
        public System.String[] WhitelistedNames_Item { get; set; }
        #endregion
        
        #region Parameter Headers_Item
        /// <summary>
        /// <para>
        /// <para>A list of HTTP header names.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_Items")]
        public System.String[] Headers_Item { get; set; }
        #endregion
        
        #region Parameter QueryStringCacheKeys_Item
        /// <summary>
        /// <para>
        /// <para>A list that contains the query string parameters that you want CloudFront to use as
        /// a basis for caching for a cache behavior. If <code>Quantity</code> is 0, you can omit
        /// <code>Items</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_Items")]
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
        [Alias("DistributionConfig_DefaultCacheBehavior_FunctionAssociations_Items")]
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
        [Alias("DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_Items")]
        public Amazon.CloudFront.Model.LambdaFunctionAssociation[] LambdaFunctionAssociations_Item { get; set; }
        #endregion
        
        #region Parameter TrustedKeyGroups_Item
        /// <summary>
        /// <para>
        /// <para>A list of key groups identifiers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfig_DefaultCacheBehavior_TrustedKeyGroups_Items")]
        public System.String[] TrustedKeyGroups_Item { get; set; }
        #endregion
        
        #region Parameter TrustedSigners_Item
        /// <summary>
        /// <para>
        /// <para>A list of Amazon Web Services account identifiers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfig_DefaultCacheBehavior_TrustedSigners_Items")]
        public System.String[] TrustedSigners_Item { get; set; }
        #endregion
        
        #region Parameter OriginGroups_Item
        /// <summary>
        /// <para>
        /// <para>The items (origin groups) in a distribution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfig_OriginGroups_Items")]
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
        /// also refer to the country list on the CloudFront console, which includes both country
        /// names and codes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfig_Restrictions_GeoRestriction_Items")]
        public System.String[] GeoRestriction_Item { get; set; }
        #endregion
        
        #region Parameter ViewerCertificate_MinimumProtocolVersion
        /// <summary>
        /// <para>
        /// <para>If the distribution uses <code>Aliases</code> (alternate domain names or CNAMEs),
        /// specify the security policy that you want CloudFront to use for HTTPS connections
        /// with viewers. The security policy determines two settings:</para><ul><li><para>The minimum SSL/TLS protocol that CloudFront can use to communicate with viewers.</para></li><li><para>The ciphers that CloudFront can use to encrypt the content that it returns to viewers.</para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/distribution-web-values-specify.html#DownloadDistValues-security-policy">Security
        /// Policy</a> and <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/secure-connections-supported-viewer-protocols-ciphers.html#secure-connections-supported-ciphers">Supported
        /// Protocols and Ciphers Between Viewers and CloudFront</a> in the <i>Amazon CloudFront
        /// Developer Guide</i>.</para><note><para>On the CloudFront console, this setting is called <b>Security Policy</b>.</para></note><para>When you’re using SNI only (you set <code>SSLSupportMethod</code> to <code>sni-only</code>),
        /// you must specify <code>TLSv1</code> or higher.</para><para>If the distribution uses the CloudFront domain name such as <code>d111111abcdef8.cloudfront.net</code>
        /// (you set <code>CloudFrontDefaultCertificate</code> to <code>true</code>), CloudFront
        /// automatically sets the security policy to <code>TLSv1</code> regardless of the value
        /// that you set here.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfig_ViewerCertificate_MinimumProtocolVersion")]
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
        [Alias("DistributionConfig_DefaultCacheBehavior_OriginRequestPolicyId")]
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
        /// from your specified price class may encounter slower performance.</para><para>For more information about price classes, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/PriceClass.html">Choosing
        /// the Price Class for a CloudFront Distribution</a> in the <i>Amazon CloudFront Developer
        /// Guide</i>. For information about CloudFront pricing, including how price classes (such
        /// as Price Class 100) map to CloudFront regions, see <a href="http://aws.amazon.com/cloudfront/pricing/">Amazon
        /// CloudFront Pricing</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [Alias("DistributionConfig_Aliases_Quantity")]
        public System.Int32? Aliases_Quantity { get; set; }
        #endregion
        
        #region Parameter CacheBehaviors_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of cache behaviors for this distribution. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfig_CacheBehaviors_Quantity")]
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
        [Alias("DistributionConfig_CustomErrorResponses_Quantity")]
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
        [Alias("DistributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_Quantity")]
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
        [Alias("DistributionConfig_DefaultCacheBehavior_AllowedMethods_Quantity")]
        public System.Int32? AllowedMethods_Quantity { get; set; }
        #endregion
        
        #region Parameter WhitelistedNames_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of cookie names in the <code>Items</code> list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_Quantity")]
        public System.Int32? WhitelistedNames_Quantity { get; set; }
        #endregion
        
        #region Parameter Headers_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of header names in the <code>Items</code> list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_Quantity")]
        public System.Int32? Headers_Quantity { get; set; }
        #endregion
        
        #region Parameter QueryStringCacheKeys_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of <code>whitelisted</code> query string parameters for a cache behavior.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_Quantity")]
        public System.Int32? QueryStringCacheKeys_Quantity { get; set; }
        #endregion
        
        #region Parameter FunctionAssociations_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of CloudFront functions in the list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfig_DefaultCacheBehavior_FunctionAssociations_Quantity")]
        public System.Int32? FunctionAssociations_Quantity { get; set; }
        #endregion
        
        #region Parameter LambdaFunctionAssociations_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of Lambda@Edge function associations for this cache behavior.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_Quantity")]
        public System.Int32? LambdaFunctionAssociations_Quantity { get; set; }
        #endregion
        
        #region Parameter TrustedKeyGroups_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of key groups in the list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfig_DefaultCacheBehavior_TrustedKeyGroups_Quantity")]
        public System.Int32? TrustedKeyGroups_Quantity { get; set; }
        #endregion
        
        #region Parameter TrustedSigners_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of Amazon Web Services accounts in the list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfig_DefaultCacheBehavior_TrustedSigners_Quantity")]
        public System.Int32? TrustedSigners_Quantity { get; set; }
        #endregion
        
        #region Parameter OriginGroups_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of origin groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfig_OriginGroups_Quantity")]
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
        [Alias("DistributionConfig_Origins_Quantity")]
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
        [Alias("DistributionConfig_Restrictions_GeoRestriction_Quantity")]
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
        [Alias("DistributionConfig_DefaultCacheBehavior_ForwardedValues_QueryString")]
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
        [Alias("DistributionConfig_DefaultCacheBehavior_RealtimeLogConfigArn")]
        public System.String DefaultCacheBehavior_RealtimeLogConfigArn { get; set; }
        #endregion
        
        #region Parameter DefaultCacheBehavior_ResponseHeadersPolicyId
        /// <summary>
        /// <para>
        /// <para>The identifier for a response headers policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfig_DefaultCacheBehavior_ResponseHeadersPolicyId")]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfig_DefaultCacheBehavior_SmoothStreaming")]
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
        /// those that don’t support SNI. This is not recommended, and results in additional monthly
        /// charges from CloudFront.</para></li><li><para><code>static-ip</code> - Do not specify this value unless your distribution has been
        /// enabled for this feature by the CloudFront team. If you have a use case that requires
        /// static IP addresses for a distribution, contact CloudFront through the <a href="https://console.aws.amazon.com/support/home">Amazon
        /// Web Services Support Center</a>.</para></li></ul><para>If the distribution uses the CloudFront domain name such as <code>d111111abcdef8.cloudfront.net</code>,
        /// don’t set a value for this field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DistributionConfig_ViewerCertificate_SSLSupportMethod")]
        [AWSConstantClassSource("Amazon.CloudFront.SSLSupportMethod")]
        public Amazon.CloudFront.SSLSupportMethod ViewerCertificate_SSLSupportMethod { get; set; }
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
        /// HTTP status code of 403 (Forbidden).</para></li></ul><para>For more information about requiring the HTTPS protocol, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/using-https-viewers-to-cloudfront.html">Requiring
        /// HTTPS Between Viewers and CloudFront</a> in the <i>Amazon CloudFront Developer Guide</i>.</para><note><para>The only way to guarantee that viewers retrieve an object that was fetched from the
        /// origin using HTTPS is never to use any other protocol to fetch the object. If you
        /// have recently changed from HTTP to HTTPS, we recommend that you clear your objects’
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
        [Alias("DistributionConfig_DefaultCacheBehavior_ViewerProtocolPolicy")]
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
        /// Developer Guide</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [Alias("DistributionConfig_ViewerCertificate_Certificate")]
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
        [Alias("DistributionConfig_ViewerCertificate_CertificateSource")]
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
        [Alias("DistributionConfig_DefaultCacheBehavior_DefaultTTL")]
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
        [Alias("DistributionConfig_DefaultCacheBehavior_MaxTTL")]
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
        [Alias("DistributionConfig_DefaultCacheBehavior_MinTTL")]
        public System.Int64? DefaultCacheBehavior_MinTTL { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Distribution'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFront.Model.UpdateDistributionResponse).
        /// Specifying the name of a property of type Amazon.CloudFront.Model.UpdateDistributionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Distribution";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Id parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CFDistribution (UpdateDistribution)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFront.Model.UpdateDistributionResponse, UpdateCFDistributionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Id;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IfMatch = this.IfMatch;
            
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
            var request = new Amazon.CloudFront.Model.UpdateDistributionRequest();
            
            
             // populate DistributionConfig
            var requestDistributionConfigIsNull = true;
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
            var requestDistributionConfig_distributionConfig_RestrictionsIsNull = true;
            requestDistributionConfig_distributionConfig_Restrictions = new Amazon.CloudFront.Model.Restrictions();
            Amazon.CloudFront.Model.GeoRestriction requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction = null;
            
             // populate GeoRestriction
            var requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestrictionIsNull = true;
            requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction = new Amazon.CloudFront.Model.GeoRestriction();
            List<System.String> requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction_geoRestriction_Item = null;
            if (cmdletContext.GeoRestriction_Item != null)
            {
                requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction_geoRestriction_Item = cmdletContext.GeoRestriction_Item;
            }
            if (requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction_geoRestriction_Item != null)
            {
                requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction.Items = requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction_geoRestriction_Item;
                requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestrictionIsNull = false;
            }
            System.Int32? requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction_geoRestriction_Quantity = null;
            if (cmdletContext.GeoRestriction_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction_geoRestriction_Quantity = cmdletContext.GeoRestriction_Quantity.Value;
            }
            if (requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction_geoRestriction_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction.Quantity = requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction_geoRestriction_Quantity.Value;
                requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestrictionIsNull = false;
            }
            Amazon.CloudFront.GeoRestrictionType requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction_geoRestriction_RestrictionType = null;
            if (cmdletContext.GeoRestriction_RestrictionType != null)
            {
                requestDistributionConfig_distributionConfig_Restrictions_distributionConfig_Restrictions_GeoRestriction_geoRestriction_RestrictionType = cmdletContext.GeoRestriction_RestrictionType;
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
            var requestDistributionConfig_distributionConfig_AliasesIsNull = true;
            requestDistributionConfig_distributionConfig_Aliases = new Amazon.CloudFront.Model.Aliases();
            List<System.String> requestDistributionConfig_distributionConfig_Aliases_aliases_Item = null;
            if (cmdletContext.Aliases_Item != null)
            {
                requestDistributionConfig_distributionConfig_Aliases_aliases_Item = cmdletContext.Aliases_Item;
            }
            if (requestDistributionConfig_distributionConfig_Aliases_aliases_Item != null)
            {
                requestDistributionConfig_distributionConfig_Aliases.Items = requestDistributionConfig_distributionConfig_Aliases_aliases_Item;
                requestDistributionConfig_distributionConfig_AliasesIsNull = false;
            }
            System.Int32? requestDistributionConfig_distributionConfig_Aliases_aliases_Quantity = null;
            if (cmdletContext.Aliases_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_Aliases_aliases_Quantity = cmdletContext.Aliases_Quantity.Value;
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
            var requestDistributionConfig_distributionConfig_CacheBehaviorsIsNull = true;
            requestDistributionConfig_distributionConfig_CacheBehaviors = new Amazon.CloudFront.Model.CacheBehaviors();
            List<Amazon.CloudFront.Model.CacheBehavior> requestDistributionConfig_distributionConfig_CacheBehaviors_cacheBehaviors_Item = null;
            if (cmdletContext.CacheBehaviors_Item != null)
            {
                requestDistributionConfig_distributionConfig_CacheBehaviors_cacheBehaviors_Item = cmdletContext.CacheBehaviors_Item;
            }
            if (requestDistributionConfig_distributionConfig_CacheBehaviors_cacheBehaviors_Item != null)
            {
                requestDistributionConfig_distributionConfig_CacheBehaviors.Items = requestDistributionConfig_distributionConfig_CacheBehaviors_cacheBehaviors_Item;
                requestDistributionConfig_distributionConfig_CacheBehaviorsIsNull = false;
            }
            System.Int32? requestDistributionConfig_distributionConfig_CacheBehaviors_cacheBehaviors_Quantity = null;
            if (cmdletContext.CacheBehaviors_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_CacheBehaviors_cacheBehaviors_Quantity = cmdletContext.CacheBehaviors_Quantity.Value;
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
            var requestDistributionConfig_distributionConfig_CustomErrorResponsesIsNull = true;
            requestDistributionConfig_distributionConfig_CustomErrorResponses = new Amazon.CloudFront.Model.CustomErrorResponses();
            List<Amazon.CloudFront.Model.CustomErrorResponse> requestDistributionConfig_distributionConfig_CustomErrorResponses_customErrorResponses_Item = null;
            if (cmdletContext.CustomErrorResponses_Item != null)
            {
                requestDistributionConfig_distributionConfig_CustomErrorResponses_customErrorResponses_Item = cmdletContext.CustomErrorResponses_Item;
            }
            if (requestDistributionConfig_distributionConfig_CustomErrorResponses_customErrorResponses_Item != null)
            {
                requestDistributionConfig_distributionConfig_CustomErrorResponses.Items = requestDistributionConfig_distributionConfig_CustomErrorResponses_customErrorResponses_Item;
                requestDistributionConfig_distributionConfig_CustomErrorResponsesIsNull = false;
            }
            System.Int32? requestDistributionConfig_distributionConfig_CustomErrorResponses_customErrorResponses_Quantity = null;
            if (cmdletContext.CustomErrorResponses_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_CustomErrorResponses_customErrorResponses_Quantity = cmdletContext.CustomErrorResponses_Quantity.Value;
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
            Amazon.CloudFront.Model.OriginGroups requestDistributionConfig_distributionConfig_OriginGroups = null;
            
             // populate OriginGroups
            var requestDistributionConfig_distributionConfig_OriginGroupsIsNull = true;
            requestDistributionConfig_distributionConfig_OriginGroups = new Amazon.CloudFront.Model.OriginGroups();
            List<Amazon.CloudFront.Model.OriginGroup> requestDistributionConfig_distributionConfig_OriginGroups_originGroups_Item = null;
            if (cmdletContext.OriginGroups_Item != null)
            {
                requestDistributionConfig_distributionConfig_OriginGroups_originGroups_Item = cmdletContext.OriginGroups_Item;
            }
            if (requestDistributionConfig_distributionConfig_OriginGroups_originGroups_Item != null)
            {
                requestDistributionConfig_distributionConfig_OriginGroups.Items = requestDistributionConfig_distributionConfig_OriginGroups_originGroups_Item;
                requestDistributionConfig_distributionConfig_OriginGroupsIsNull = false;
            }
            System.Int32? requestDistributionConfig_distributionConfig_OriginGroups_originGroups_Quantity = null;
            if (cmdletContext.OriginGroups_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_OriginGroups_originGroups_Quantity = cmdletContext.OriginGroups_Quantity.Value;
            }
            if (requestDistributionConfig_distributionConfig_OriginGroups_originGroups_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_OriginGroups.Quantity = requestDistributionConfig_distributionConfig_OriginGroups_originGroups_Quantity.Value;
                requestDistributionConfig_distributionConfig_OriginGroupsIsNull = false;
            }
             // determine if requestDistributionConfig_distributionConfig_OriginGroups should be set to null
            if (requestDistributionConfig_distributionConfig_OriginGroupsIsNull)
            {
                requestDistributionConfig_distributionConfig_OriginGroups = null;
            }
            if (requestDistributionConfig_distributionConfig_OriginGroups != null)
            {
                request.DistributionConfig.OriginGroups = requestDistributionConfig_distributionConfig_OriginGroups;
                requestDistributionConfigIsNull = false;
            }
            Amazon.CloudFront.Model.Origins requestDistributionConfig_distributionConfig_Origins = null;
            
             // populate Origins
            var requestDistributionConfig_distributionConfig_OriginsIsNull = true;
            requestDistributionConfig_distributionConfig_Origins = new Amazon.CloudFront.Model.Origins();
            List<Amazon.CloudFront.Model.Origin> requestDistributionConfig_distributionConfig_Origins_origins_Item = null;
            if (cmdletContext.Origins_Item != null)
            {
                requestDistributionConfig_distributionConfig_Origins_origins_Item = cmdletContext.Origins_Item;
            }
            if (requestDistributionConfig_distributionConfig_Origins_origins_Item != null)
            {
                requestDistributionConfig_distributionConfig_Origins.Items = requestDistributionConfig_distributionConfig_Origins_origins_Item;
                requestDistributionConfig_distributionConfig_OriginsIsNull = false;
            }
            System.Int32? requestDistributionConfig_distributionConfig_Origins_origins_Quantity = null;
            if (cmdletContext.Origins_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_Origins_origins_Quantity = cmdletContext.Origins_Quantity.Value;
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
            var requestDistributionConfig_distributionConfig_LoggingIsNull = true;
            requestDistributionConfig_distributionConfig_Logging = new Amazon.CloudFront.Model.LoggingConfig();
            System.String requestDistributionConfig_distributionConfig_Logging_logging_Bucket = null;
            if (cmdletContext.Logging_Bucket != null)
            {
                requestDistributionConfig_distributionConfig_Logging_logging_Bucket = cmdletContext.Logging_Bucket;
            }
            if (requestDistributionConfig_distributionConfig_Logging_logging_Bucket != null)
            {
                requestDistributionConfig_distributionConfig_Logging.Bucket = requestDistributionConfig_distributionConfig_Logging_logging_Bucket;
                requestDistributionConfig_distributionConfig_LoggingIsNull = false;
            }
            System.Boolean? requestDistributionConfig_distributionConfig_Logging_logging_Enabled = null;
            if (cmdletContext.Logging_Enabled != null)
            {
                requestDistributionConfig_distributionConfig_Logging_logging_Enabled = cmdletContext.Logging_Enabled.Value;
            }
            if (requestDistributionConfig_distributionConfig_Logging_logging_Enabled != null)
            {
                requestDistributionConfig_distributionConfig_Logging.Enabled = requestDistributionConfig_distributionConfig_Logging_logging_Enabled.Value;
                requestDistributionConfig_distributionConfig_LoggingIsNull = false;
            }
            System.Boolean? requestDistributionConfig_distributionConfig_Logging_logging_IncludeCookie = null;
            if (cmdletContext.Logging_IncludeCookie != null)
            {
                requestDistributionConfig_distributionConfig_Logging_logging_IncludeCookie = cmdletContext.Logging_IncludeCookie.Value;
            }
            if (requestDistributionConfig_distributionConfig_Logging_logging_IncludeCookie != null)
            {
                requestDistributionConfig_distributionConfig_Logging.IncludeCookies = requestDistributionConfig_distributionConfig_Logging_logging_IncludeCookie.Value;
                requestDistributionConfig_distributionConfig_LoggingIsNull = false;
            }
            System.String requestDistributionConfig_distributionConfig_Logging_logging_Prefix = null;
            if (cmdletContext.Logging_Prefix != null)
            {
                requestDistributionConfig_distributionConfig_Logging_logging_Prefix = cmdletContext.Logging_Prefix;
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
            var requestDistributionConfig_distributionConfig_ViewerCertificateIsNull = true;
            requestDistributionConfig_distributionConfig_ViewerCertificate = new Amazon.CloudFront.Model.ViewerCertificate();
            System.String requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_ACMCertificateArn = null;
            if (cmdletContext.ViewerCertificate_ACMCertificateArn != null)
            {
                requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_ACMCertificateArn = cmdletContext.ViewerCertificate_ACMCertificateArn;
            }
            if (requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_ACMCertificateArn != null)
            {
                requestDistributionConfig_distributionConfig_ViewerCertificate.ACMCertificateArn = requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_ACMCertificateArn;
                requestDistributionConfig_distributionConfig_ViewerCertificateIsNull = false;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            System.String requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_Certificate = null;
            if (cmdletContext.ViewerCertificate_Certificate != null)
            {
                requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_Certificate = cmdletContext.ViewerCertificate_Certificate;
            }
            if (requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_Certificate != null)
            {
                requestDistributionConfig_distributionConfig_ViewerCertificate.Certificate = requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_Certificate;
                requestDistributionConfig_distributionConfig_ViewerCertificateIsNull = false;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            Amazon.CloudFront.CertificateSource requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_CertificateSource = null;
            if (cmdletContext.ViewerCertificate_CertificateSource != null)
            {
                requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_CertificateSource = cmdletContext.ViewerCertificate_CertificateSource;
            }
            if (requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_CertificateSource != null)
            {
                requestDistributionConfig_distributionConfig_ViewerCertificate.CertificateSource = requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_CertificateSource;
                requestDistributionConfig_distributionConfig_ViewerCertificateIsNull = false;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            System.Boolean? requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_CloudFrontDefaultCertificate = null;
            if (cmdletContext.ViewerCertificate_CloudFrontDefaultCertificate != null)
            {
                requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_CloudFrontDefaultCertificate = cmdletContext.ViewerCertificate_CloudFrontDefaultCertificate.Value;
            }
            if (requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_CloudFrontDefaultCertificate != null)
            {
                requestDistributionConfig_distributionConfig_ViewerCertificate.CloudFrontDefaultCertificate = requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_CloudFrontDefaultCertificate.Value;
                requestDistributionConfig_distributionConfig_ViewerCertificateIsNull = false;
            }
            System.String requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_IAMCertificateId = null;
            if (cmdletContext.ViewerCertificate_IAMCertificateId != null)
            {
                requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_IAMCertificateId = cmdletContext.ViewerCertificate_IAMCertificateId;
            }
            if (requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_IAMCertificateId != null)
            {
                requestDistributionConfig_distributionConfig_ViewerCertificate.IAMCertificateId = requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_IAMCertificateId;
                requestDistributionConfig_distributionConfig_ViewerCertificateIsNull = false;
            }
            Amazon.CloudFront.MinimumProtocolVersion requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_MinimumProtocolVersion = null;
            if (cmdletContext.ViewerCertificate_MinimumProtocolVersion != null)
            {
                requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_MinimumProtocolVersion = cmdletContext.ViewerCertificate_MinimumProtocolVersion;
            }
            if (requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_MinimumProtocolVersion != null)
            {
                requestDistributionConfig_distributionConfig_ViewerCertificate.MinimumProtocolVersion = requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_MinimumProtocolVersion;
                requestDistributionConfig_distributionConfig_ViewerCertificateIsNull = false;
            }
            Amazon.CloudFront.SSLSupportMethod requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_SSLSupportMethod = null;
            if (cmdletContext.ViewerCertificate_SSLSupportMethod != null)
            {
                requestDistributionConfig_distributionConfig_ViewerCertificate_viewerCertificate_SSLSupportMethod = cmdletContext.ViewerCertificate_SSLSupportMethod;
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
            var requestDistributionConfig_distributionConfig_DefaultCacheBehaviorIsNull = true;
            requestDistributionConfig_distributionConfig_DefaultCacheBehavior = new Amazon.CloudFront.Model.DefaultCacheBehavior();
            System.String requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_CachePolicyId = null;
            if (cmdletContext.DefaultCacheBehavior_CachePolicyId != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_CachePolicyId = cmdletContext.DefaultCacheBehavior_CachePolicyId;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_CachePolicyId != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior.CachePolicyId = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_CachePolicyId;
                requestDistributionConfig_distributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            System.Boolean? requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_Compress = null;
            if (cmdletContext.DefaultCacheBehavior_Compress != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_Compress = cmdletContext.DefaultCacheBehavior_Compress.Value;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_Compress != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior.Compress = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_Compress.Value;
                requestDistributionConfig_distributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            System.Int64? requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_DefaultTTL = null;
            if (cmdletContext.DefaultCacheBehavior_DefaultTTL != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_DefaultTTL = cmdletContext.DefaultCacheBehavior_DefaultTTL.Value;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_DefaultTTL != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior.DefaultTTL = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_DefaultTTL.Value;
                requestDistributionConfig_distributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            System.String requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_FieldLevelEncryptionId = null;
            if (cmdletContext.DefaultCacheBehavior_FieldLevelEncryptionId != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_FieldLevelEncryptionId = cmdletContext.DefaultCacheBehavior_FieldLevelEncryptionId;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_FieldLevelEncryptionId != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior.FieldLevelEncryptionId = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_FieldLevelEncryptionId;
                requestDistributionConfig_distributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            System.Int64? requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_MaxTTL = null;
            if (cmdletContext.DefaultCacheBehavior_MaxTTL != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_MaxTTL = cmdletContext.DefaultCacheBehavior_MaxTTL.Value;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_MaxTTL != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior.MaxTTL = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_MaxTTL.Value;
                requestDistributionConfig_distributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            System.Int64? requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_MinTTL = null;
            if (cmdletContext.DefaultCacheBehavior_MinTTL != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_MinTTL = cmdletContext.DefaultCacheBehavior_MinTTL.Value;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_MinTTL != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior.MinTTL = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_MinTTL.Value;
                requestDistributionConfig_distributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            System.String requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_OriginRequestPolicyId = null;
            if (cmdletContext.DefaultCacheBehavior_OriginRequestPolicyId != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_OriginRequestPolicyId = cmdletContext.DefaultCacheBehavior_OriginRequestPolicyId;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_OriginRequestPolicyId != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior.OriginRequestPolicyId = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_OriginRequestPolicyId;
                requestDistributionConfig_distributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            System.String requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_RealtimeLogConfigArn = null;
            if (cmdletContext.DefaultCacheBehavior_RealtimeLogConfigArn != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_RealtimeLogConfigArn = cmdletContext.DefaultCacheBehavior_RealtimeLogConfigArn;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_RealtimeLogConfigArn != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior.RealtimeLogConfigArn = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_RealtimeLogConfigArn;
                requestDistributionConfig_distributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            System.String requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_ResponseHeadersPolicyId = null;
            if (cmdletContext.DefaultCacheBehavior_ResponseHeadersPolicyId != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_ResponseHeadersPolicyId = cmdletContext.DefaultCacheBehavior_ResponseHeadersPolicyId;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_ResponseHeadersPolicyId != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior.ResponseHeadersPolicyId = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_ResponseHeadersPolicyId;
                requestDistributionConfig_distributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            System.Boolean? requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_SmoothStreaming = null;
            if (cmdletContext.DefaultCacheBehavior_SmoothStreaming != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_SmoothStreaming = cmdletContext.DefaultCacheBehavior_SmoothStreaming.Value;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_SmoothStreaming != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior.SmoothStreaming = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_SmoothStreaming.Value;
                requestDistributionConfig_distributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            System.String requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_TargetOriginId = null;
            if (cmdletContext.DefaultCacheBehavior_TargetOriginId != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_TargetOriginId = cmdletContext.DefaultCacheBehavior_TargetOriginId;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_TargetOriginId != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior.TargetOriginId = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_TargetOriginId;
                requestDistributionConfig_distributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            Amazon.CloudFront.ViewerProtocolPolicy requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_ViewerProtocolPolicy = null;
            if (cmdletContext.DefaultCacheBehavior_ViewerProtocolPolicy != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_ViewerProtocolPolicy = cmdletContext.DefaultCacheBehavior_ViewerProtocolPolicy;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_ViewerProtocolPolicy != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior.ViewerProtocolPolicy = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_defaultCacheBehavior_ViewerProtocolPolicy;
                requestDistributionConfig_distributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            Amazon.CloudFront.Model.FunctionAssociations requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_FunctionAssociations = null;
            
             // populate FunctionAssociations
            var requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_FunctionAssociationsIsNull = true;
            requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_FunctionAssociations = new Amazon.CloudFront.Model.FunctionAssociations();
            List<Amazon.CloudFront.Model.FunctionAssociation> requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_FunctionAssociations_functionAssociations_Item = null;
            if (cmdletContext.FunctionAssociations_Item != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_FunctionAssociations_functionAssociations_Item = cmdletContext.FunctionAssociations_Item;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_FunctionAssociations_functionAssociations_Item != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_FunctionAssociations.Items = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_FunctionAssociations_functionAssociations_Item;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_FunctionAssociationsIsNull = false;
            }
            System.Int32? requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_FunctionAssociations_functionAssociations_Quantity = null;
            if (cmdletContext.FunctionAssociations_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_FunctionAssociations_functionAssociations_Quantity = cmdletContext.FunctionAssociations_Quantity.Value;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_FunctionAssociations_functionAssociations_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_FunctionAssociations.Quantity = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_FunctionAssociations_functionAssociations_Quantity.Value;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_FunctionAssociationsIsNull = false;
            }
             // determine if requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_FunctionAssociations should be set to null
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_FunctionAssociationsIsNull)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_FunctionAssociations = null;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_FunctionAssociations != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior.FunctionAssociations = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_FunctionAssociations;
                requestDistributionConfig_distributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            Amazon.CloudFront.Model.LambdaFunctionAssociations requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations = null;
            
             // populate LambdaFunctionAssociations
            var requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_LambdaFunctionAssociationsIsNull = true;
            requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations = new Amazon.CloudFront.Model.LambdaFunctionAssociations();
            List<Amazon.CloudFront.Model.LambdaFunctionAssociation> requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_lambdaFunctionAssociations_Item = null;
            if (cmdletContext.LambdaFunctionAssociations_Item != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_lambdaFunctionAssociations_Item = cmdletContext.LambdaFunctionAssociations_Item;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_lambdaFunctionAssociations_Item != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations.Items = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_lambdaFunctionAssociations_Item;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_LambdaFunctionAssociationsIsNull = false;
            }
            System.Int32? requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_lambdaFunctionAssociations_Quantity = null;
            if (cmdletContext.LambdaFunctionAssociations_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_LambdaFunctionAssociations_lambdaFunctionAssociations_Quantity = cmdletContext.LambdaFunctionAssociations_Quantity.Value;
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
            var requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethodsIsNull = true;
            requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods = new Amazon.CloudFront.Model.AllowedMethods();
            List<System.String> requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_allowedMethods_Item = null;
            if (cmdletContext.AllowedMethods_Item != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_allowedMethods_Item = cmdletContext.AllowedMethods_Item;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_allowedMethods_Item != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods.Items = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_allowedMethods_Item;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethodsIsNull = false;
            }
            System.Int32? requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_allowedMethods_Quantity = null;
            if (cmdletContext.AllowedMethods_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_allowedMethods_Quantity = cmdletContext.AllowedMethods_Quantity.Value;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_allowedMethods_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods.Quantity = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_allowedMethods_Quantity.Value;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethodsIsNull = false;
            }
            Amazon.CloudFront.Model.CachedMethods requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods = null;
            
             // populate CachedMethods
            var requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethodsIsNull = true;
            requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods = new Amazon.CloudFront.Model.CachedMethods();
            List<System.String> requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_cachedMethods_Item = null;
            if (cmdletContext.CachedMethods_Item != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_cachedMethods_Item = cmdletContext.CachedMethods_Item;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_cachedMethods_Item != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods.Items = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_cachedMethods_Item;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethodsIsNull = false;
            }
            System.Int32? requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_cachedMethods_Quantity = null;
            if (cmdletContext.CachedMethods_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_AllowedMethods_distributionConfig_DefaultCacheBehavior_AllowedMethods_CachedMethods_cachedMethods_Quantity = cmdletContext.CachedMethods_Quantity.Value;
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
            Amazon.CloudFront.Model.TrustedKeyGroups requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedKeyGroups = null;
            
             // populate TrustedKeyGroups
            var requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedKeyGroupsIsNull = true;
            requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedKeyGroups = new Amazon.CloudFront.Model.TrustedKeyGroups();
            System.Boolean? requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedKeyGroups_trustedKeyGroups_Enabled = null;
            if (cmdletContext.TrustedKeyGroups_Enabled != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedKeyGroups_trustedKeyGroups_Enabled = cmdletContext.TrustedKeyGroups_Enabled.Value;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedKeyGroups_trustedKeyGroups_Enabled != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedKeyGroups.Enabled = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedKeyGroups_trustedKeyGroups_Enabled.Value;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedKeyGroupsIsNull = false;
            }
            List<System.String> requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedKeyGroups_trustedKeyGroups_Item = null;
            if (cmdletContext.TrustedKeyGroups_Item != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedKeyGroups_trustedKeyGroups_Item = cmdletContext.TrustedKeyGroups_Item;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedKeyGroups_trustedKeyGroups_Item != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedKeyGroups.Items = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedKeyGroups_trustedKeyGroups_Item;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedKeyGroupsIsNull = false;
            }
            System.Int32? requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedKeyGroups_trustedKeyGroups_Quantity = null;
            if (cmdletContext.TrustedKeyGroups_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedKeyGroups_trustedKeyGroups_Quantity = cmdletContext.TrustedKeyGroups_Quantity.Value;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedKeyGroups_trustedKeyGroups_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedKeyGroups.Quantity = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedKeyGroups_trustedKeyGroups_Quantity.Value;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedKeyGroupsIsNull = false;
            }
             // determine if requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedKeyGroups should be set to null
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedKeyGroupsIsNull)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedKeyGroups = null;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedKeyGroups != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior.TrustedKeyGroups = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedKeyGroups;
                requestDistributionConfig_distributionConfig_DefaultCacheBehaviorIsNull = false;
            }
            Amazon.CloudFront.Model.TrustedSigners requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners = null;
            
             // populate TrustedSigners
            var requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSignersIsNull = true;
            requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners = new Amazon.CloudFront.Model.TrustedSigners();
            System.Boolean? requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Enabled = null;
            if (cmdletContext.TrustedSigners_Enabled != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Enabled = cmdletContext.TrustedSigners_Enabled.Value;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Enabled != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners.Enabled = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Enabled.Value;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSignersIsNull = false;
            }
            List<System.String> requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Item = null;
            if (cmdletContext.TrustedSigners_Item != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Item = cmdletContext.TrustedSigners_Item;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Item != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners.Items = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Item;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSignersIsNull = false;
            }
            System.Int32? requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Quantity = null;
            if (cmdletContext.TrustedSigners_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_TrustedSigners_trustedSigners_Quantity = cmdletContext.TrustedSigners_Quantity.Value;
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
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            Amazon.CloudFront.Model.ForwardedValues requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues = null;
            
             // populate ForwardedValues
            var requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValuesIsNull = true;
            requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues = new Amazon.CloudFront.Model.ForwardedValues();
            System.Boolean? requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_forwardedValues_QueryString = null;
            if (cmdletContext.ForwardedValues_QueryString != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_forwardedValues_QueryString = cmdletContext.ForwardedValues_QueryString.Value;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_forwardedValues_QueryString != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues.QueryString = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_forwardedValues_QueryString.Value;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValuesIsNull = false;
            }
            Amazon.CloudFront.Model.CookiePreference requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies = null;
            
             // populate Cookies
            var requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_CookiesIsNull = true;
            requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies = new Amazon.CloudFront.Model.CookiePreference();
            Amazon.CloudFront.ItemSelection requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_cookies_Forward = null;
            if (cmdletContext.Cookies_Forward != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_cookies_Forward = cmdletContext.Cookies_Forward;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_cookies_Forward != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies.Forward = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_cookies_Forward;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_CookiesIsNull = false;
            }
            Amazon.CloudFront.Model.CookieNames requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames = null;
            
             // populate WhitelistedNames
            var requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNamesIsNull = true;
            requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames = new Amazon.CloudFront.Model.CookieNames();
            List<System.String> requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_whitelistedNames_Item = null;
            if (cmdletContext.WhitelistedNames_Item != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_whitelistedNames_Item = cmdletContext.WhitelistedNames_Item;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_whitelistedNames_Item != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames.Items = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_whitelistedNames_Item;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNamesIsNull = false;
            }
            System.Int32? requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_whitelistedNames_Quantity = null;
            if (cmdletContext.WhitelistedNames_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_distributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_WhitelistedNames_whitelistedNames_Quantity = cmdletContext.WhitelistedNames_Quantity.Value;
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
            var requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_HeadersIsNull = true;
            requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Headers = new Amazon.CloudFront.Model.Headers();
            List<System.String> requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_headers_Item = null;
            if (cmdletContext.Headers_Item != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_headers_Item = cmdletContext.Headers_Item;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_headers_Item != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Headers.Items = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_headers_Item;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_HeadersIsNull = false;
            }
            System.Int32? requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_headers_Quantity = null;
            if (cmdletContext.Headers_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_Headers_headers_Quantity = cmdletContext.Headers_Quantity.Value;
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
            var requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeysIsNull = true;
            requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys = new Amazon.CloudFront.Model.QueryStringCacheKeys();
            List<System.String> requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_queryStringCacheKeys_Item = null;
            if (cmdletContext.QueryStringCacheKeys_Item != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_queryStringCacheKeys_Item = cmdletContext.QueryStringCacheKeys_Item;
            }
            if (requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_queryStringCacheKeys_Item != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys.Items = requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_queryStringCacheKeys_Item;
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeysIsNull = false;
            }
            System.Int32? requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_queryStringCacheKeys_Quantity = null;
            if (cmdletContext.QueryStringCacheKeys_Quantity != null)
            {
                requestDistributionConfig_distributionConfig_DefaultCacheBehavior_distributionConfig_DefaultCacheBehavior_ForwardedValues_distributionConfig_DefaultCacheBehavior_ForwardedValues_QueryStringCacheKeys_queryStringCacheKeys_Quantity = cmdletContext.QueryStringCacheKeys_Quantity.Value;
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
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.IfMatch != null)
            {
                request.IfMatch = cmdletContext.IfMatch;
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
        
        private Amazon.CloudFront.Model.UpdateDistributionResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.UpdateDistributionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "UpdateDistribution");
            try
            {
                #if DESKTOP
                return client.UpdateDistribution(request);
                #elif CORECLR
                return client.UpdateDistributionAsync(request).GetAwaiter().GetResult();
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
            public System.String Id { get; set; }
            public System.String IfMatch { get; set; }
            public System.Func<Amazon.CloudFront.Model.UpdateDistributionResponse, UpdateCFDistributionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Distribution;
        }
        
    }
}
