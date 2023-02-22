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
    /// Creates a cache policy.
    /// 
    ///  
    /// <para>
    /// After you create a cache policy, you can attach it to one or more cache behaviors.
    /// When it's attached to a cache behavior, the cache policy determines the following:
    /// </para><ul><li><para>
    /// The values that CloudFront includes in the <i>cache key</i>. These values can include
    /// HTTP headers, cookies, and URL query strings. CloudFront uses the cache key to find
    /// an object in its cache that it can return to the viewer.
    /// </para></li><li><para>
    /// The default, minimum, and maximum time to live (TTL) values that you want objects
    /// to stay in the CloudFront cache.
    /// </para></li></ul><para>
    /// The headers, cookies, and query strings that are included in the cache key are also
    /// included in requests that CloudFront sends to the origin. CloudFront sends a request
    /// when it can't find an object in its cache that matches the request's cache key. If
    /// you want to send values to the origin but <i>not</i> include them in the cache key,
    /// use <code>OriginRequestPolicy</code>.
    /// </para><para>
    /// For more information about cache policies, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/controlling-the-cache-key.html">Controlling
    /// the cache key</a> in the <i>Amazon CloudFront Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "CFCachePolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudFront.Model.CreateCachePolicyResponse")]
    [AWSCmdlet("Calls the Amazon CloudFront CreateCachePolicy API operation.", Operation = new[] {"CreateCachePolicy"}, SelectReturnType = typeof(Amazon.CloudFront.Model.CreateCachePolicyResponse))]
    [AWSCmdletOutput("Amazon.CloudFront.Model.CreateCachePolicyResponse",
        "This cmdlet returns an Amazon.CloudFront.Model.CreateCachePolicyResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCFCachePolicyCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        #region Parameter CachePolicyConfig_Comment
        /// <summary>
        /// <para>
        /// <para>A comment to describe the cache policy. The comment cannot be longer than 128 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CachePolicyConfig_Comment { get; set; }
        #endregion
        
        #region Parameter CookiesConfig_CookieBehavior
        /// <summary>
        /// <para>
        /// <para>Determines whether any cookies in viewer requests are included in the cache key and
        /// in requests that CloudFront sends to the origin. Valid values are:</para><ul><li><para><code>none</code> – No cookies in viewer requests are included in the cache key or
        /// in requests that CloudFront sends to the origin. Even when this field is set to <code>none</code>,
        /// any cookies that are listed in an <code>OriginRequestPolicy</code><i>are</i> included
        /// in origin requests.</para></li><li><para><code>whitelist</code> – Only the cookies in viewer requests that are listed in the
        /// <code>CookieNames</code> type are included in the cache key and in requests that CloudFront
        /// sends to the origin.</para></li><li><para><code>allExcept</code> – All cookies in viewer requests are included in the cache
        /// key and in requests that CloudFront sends to the origin, <i><b>except</b></i> for
        /// those that are listed in the <code>CookieNames</code> type, which are not included.</para></li><li><para><code>all</code> – All cookies in viewer requests are included in the cache key and
        /// in requests that CloudFront sends to the origin.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_CookieBehavior")]
        [AWSConstantClassSource("Amazon.CloudFront.CachePolicyCookieBehavior")]
        public Amazon.CloudFront.CachePolicyCookieBehavior CookiesConfig_CookieBehavior { get; set; }
        #endregion
        
        #region Parameter CachePolicyConfig_DefaultTTL
        /// <summary>
        /// <para>
        /// <para>The default amount of time, in seconds, that you want objects to stay in the CloudFront
        /// cache before CloudFront sends another request to the origin to see if the object has
        /// been updated. CloudFront uses this value as the object's time to live (TTL) only when
        /// the origin does <i>not</i> send <code>Cache-Control</code> or <code>Expires</code>
        /// headers with the object. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/Expiration.html">Managing
        /// How Long Content Stays in an Edge Cache (Expiration)</a> in the <i>Amazon CloudFront
        /// Developer Guide</i>.</para><para>The default value for this field is 86400 seconds (one day). If the value of <code>MinTTL</code>
        /// is more than 86400 seconds, then the default value for this field is the same as the
        /// value of <code>MinTTL</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? CachePolicyConfig_DefaultTTL { get; set; }
        #endregion
        
        #region Parameter ParametersInCacheKeyAndForwardedToOrigin_EnableAcceptEncodingBrotli
        /// <summary>
        /// <para>
        /// <para>A flag that can affect whether the <code>Accept-Encoding</code> HTTP header is included
        /// in the cache key and included in requests that CloudFront sends to the origin.</para><para>This field is related to the <code>EnableAcceptEncodingGzip</code> field. If one or
        /// both of these fields is <code>true</code><i>and</i> the viewer request includes the
        /// <code>Accept-Encoding</code> header, then CloudFront does the following:</para><ul><li><para>Normalizes the value of the viewer's <code>Accept-Encoding</code> header</para></li><li><para>Includes the normalized header in the cache key</para></li><li><para>Includes the normalized header in the request to the origin, if a request is necessary</para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/controlling-the-cache-key.html#cache-policy-compressed-objects">Compression
        /// support</a> in the <i>Amazon CloudFront Developer Guide</i>.</para><para>If you set this value to <code>true</code>, and this cache behavior also has an origin
        /// request policy attached, do not include the <code>Accept-Encoding</code> header in
        /// the origin request policy. CloudFront always includes the <code>Accept-Encoding</code>
        /// header in origin requests when the value of this field is <code>true</code>, so including
        /// this header in an origin request policy has no effect.</para><para>If both of these fields are <code>false</code>, then CloudFront treats the <code>Accept-Encoding</code>
        /// header the same as any other HTTP header in the viewer request. By default, it's not
        /// included in the cache key and it's not included in origin requests. In this case,
        /// you can manually add <code>Accept-Encoding</code> to the headers whitelist like any
        /// other HTTP header.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_EnableAcceptEncodingBrotli")]
        public System.Boolean? ParametersInCacheKeyAndForwardedToOrigin_EnableAcceptEncodingBrotli { get; set; }
        #endregion
        
        #region Parameter ParametersInCacheKeyAndForwardedToOrigin_EnableAcceptEncodingGzip
        /// <summary>
        /// <para>
        /// <para>A flag that can affect whether the <code>Accept-Encoding</code> HTTP header is included
        /// in the cache key and included in requests that CloudFront sends to the origin.</para><para>This field is related to the <code>EnableAcceptEncodingBrotli</code> field. If one
        /// or both of these fields is <code>true</code><i>and</i> the viewer request includes
        /// the <code>Accept-Encoding</code> header, then CloudFront does the following:</para><ul><li><para>Normalizes the value of the viewer's <code>Accept-Encoding</code> header</para></li><li><para>Includes the normalized header in the cache key</para></li><li><para>Includes the normalized header in the request to the origin, if a request is necessary</para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/controlling-the-cache-key.html#cache-policy-compressed-objects">Compression
        /// support</a> in the <i>Amazon CloudFront Developer Guide</i>.</para><para>If you set this value to <code>true</code>, and this cache behavior also has an origin
        /// request policy attached, do not include the <code>Accept-Encoding</code> header in
        /// the origin request policy. CloudFront always includes the <code>Accept-Encoding</code>
        /// header in origin requests when the value of this field is <code>true</code>, so including
        /// this header in an origin request policy has no effect.</para><para>If both of these fields are <code>false</code>, then CloudFront treats the <code>Accept-Encoding</code>
        /// header the same as any other HTTP header in the viewer request. By default, it's not
        /// included in the cache key and it's not included in origin requests. In this case,
        /// you can manually add <code>Accept-Encoding</code> to the headers whitelist like any
        /// other HTTP header.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_EnableAcceptEncodingGzip")]
        public System.Boolean? ParametersInCacheKeyAndForwardedToOrigin_EnableAcceptEncodingGzip { get; set; }
        #endregion
        
        #region Parameter HeadersConfig_HeaderBehavior
        /// <summary>
        /// <para>
        /// <para>Determines whether any HTTP headers are included in the cache key and in requests
        /// that CloudFront sends to the origin. Valid values are:</para><ul><li><para><code>none</code> – No HTTP headers are included in the cache key or in requests
        /// that CloudFront sends to the origin. Even when this field is set to <code>none</code>,
        /// any headers that are listed in an <code>OriginRequestPolicy</code><i>are</i> included
        /// in origin requests.</para></li><li><para><code>whitelist</code> – Only the HTTP headers that are listed in the <code>Headers</code>
        /// type are included in the cache key and in requests that CloudFront sends to the origin.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_HeaderBehavior")]
        [AWSConstantClassSource("Amazon.CloudFront.CachePolicyHeaderBehavior")]
        public Amazon.CloudFront.CachePolicyHeaderBehavior HeadersConfig_HeaderBehavior { get; set; }
        #endregion
        
        #region Parameter Cookies_Item
        /// <summary>
        /// <para>
        /// <para>A list of cookie names.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_Cookies_Items")]
        public System.String[] Cookies_Item { get; set; }
        #endregion
        
        #region Parameter Headers_Item
        /// <summary>
        /// <para>
        /// <para>A list of HTTP header names.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_Headers_Items")]
        public System.String[] Headers_Item { get; set; }
        #endregion
        
        #region Parameter QueryStrings_Item
        /// <summary>
        /// <para>
        /// <para>A list of query string names.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_QueryStrings_Items")]
        public System.String[] QueryStrings_Item { get; set; }
        #endregion
        
        #region Parameter CachePolicyConfig_MaxTTL
        /// <summary>
        /// <para>
        /// <para>The maximum amount of time, in seconds, that objects stay in the CloudFront cache
        /// before CloudFront sends another request to the origin to see if the object has been
        /// updated. CloudFront uses this value only when the origin sends <code>Cache-Control</code>
        /// or <code>Expires</code> headers with the object. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/Expiration.html">Managing
        /// How Long Content Stays in an Edge Cache (Expiration)</a> in the <i>Amazon CloudFront
        /// Developer Guide</i>.</para><para>The default value for this field is 31536000 seconds (one year). If the value of <code>MinTTL</code>
        /// or <code>DefaultTTL</code> is more than 31536000 seconds, then the default value for
        /// this field is the same as the value of <code>DefaultTTL</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? CachePolicyConfig_MaxTTL { get; set; }
        #endregion
        
        #region Parameter CachePolicyConfig_MinTTL
        /// <summary>
        /// <para>
        /// <para>The minimum amount of time, in seconds, that you want objects to stay in the CloudFront
        /// cache before CloudFront sends another request to the origin to see if the object has
        /// been updated. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/Expiration.html">Managing
        /// How Long Content Stays in an Edge Cache (Expiration)</a> in the <i>Amazon CloudFront
        /// Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int64? CachePolicyConfig_MinTTL { get; set; }
        #endregion
        
        #region Parameter CachePolicyConfig_Name
        /// <summary>
        /// <para>
        /// <para>A unique name to identify the cache policy.</para>
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
        public System.String CachePolicyConfig_Name { get; set; }
        #endregion
        
        #region Parameter Cookies_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of cookie names in the <code>Items</code> list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_Cookies_Quantity")]
        public System.Int32? Cookies_Quantity { get; set; }
        #endregion
        
        #region Parameter Headers_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of header names in the <code>Items</code> list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_Headers_Quantity")]
        public System.Int32? Headers_Quantity { get; set; }
        #endregion
        
        #region Parameter QueryStrings_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of query string names in the <code>Items</code> list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_QueryStrings_Quantity")]
        public System.Int32? QueryStrings_Quantity { get; set; }
        #endregion
        
        #region Parameter QueryStringsConfig_QueryStringBehavior
        /// <summary>
        /// <para>
        /// <para>Determines whether any URL query strings in viewer requests are included in the cache
        /// key and in requests that CloudFront sends to the origin. Valid values are:</para><ul><li><para><code>none</code> – No query strings in viewer requests are included in the cache
        /// key or in requests that CloudFront sends to the origin. Even when this field is set
        /// to <code>none</code>, any query strings that are listed in an <code>OriginRequestPolicy</code><i>are</i> included in origin requests.</para></li><li><para><code>whitelist</code> – Only the query strings in viewer requests that are listed
        /// in the <code>QueryStringNames</code> type are included in the cache key and in requests
        /// that CloudFront sends to the origin.</para></li><li><para><code>allExcept</code> – All query strings in viewer requests are included in the
        /// cache key and in requests that CloudFront sends to the origin, <i><b>except</b></i>
        /// those that are listed in the <code>QueryStringNames</code> type, which are not included.</para></li><li><para><code>all</code> – All query strings in viewer requests are included in the cache
        /// key and in requests that CloudFront sends to the origin.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_QueryStringBehavior")]
        [AWSConstantClassSource("Amazon.CloudFront.CachePolicyQueryStringBehavior")]
        public Amazon.CloudFront.CachePolicyQueryStringBehavior QueryStringsConfig_QueryStringBehavior { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFront.Model.CreateCachePolicyResponse).
        /// Specifying the name of a property of type Amazon.CloudFront.Model.CreateCachePolicyResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CachePolicyConfig_Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CFCachePolicy (CreateCachePolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFront.Model.CreateCachePolicyResponse, NewCFCachePolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CachePolicyConfig_Comment = this.CachePolicyConfig_Comment;
            context.CachePolicyConfig_DefaultTTL = this.CachePolicyConfig_DefaultTTL;
            context.CachePolicyConfig_MaxTTL = this.CachePolicyConfig_MaxTTL;
            context.CachePolicyConfig_MinTTL = this.CachePolicyConfig_MinTTL;
            #if MODULAR
            if (this.CachePolicyConfig_MinTTL == null && ParameterWasBound(nameof(this.CachePolicyConfig_MinTTL)))
            {
                WriteWarning("You are passing $null as a value for parameter CachePolicyConfig_MinTTL which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CachePolicyConfig_Name = this.CachePolicyConfig_Name;
            #if MODULAR
            if (this.CachePolicyConfig_Name == null && ParameterWasBound(nameof(this.CachePolicyConfig_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter CachePolicyConfig_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CookiesConfig_CookieBehavior = this.CookiesConfig_CookieBehavior;
            if (this.Cookies_Item != null)
            {
                context.Cookies_Item = new List<System.String>(this.Cookies_Item);
            }
            context.Cookies_Quantity = this.Cookies_Quantity;
            context.ParametersInCacheKeyAndForwardedToOrigin_EnableAcceptEncodingBrotli = this.ParametersInCacheKeyAndForwardedToOrigin_EnableAcceptEncodingBrotli;
            context.ParametersInCacheKeyAndForwardedToOrigin_EnableAcceptEncodingGzip = this.ParametersInCacheKeyAndForwardedToOrigin_EnableAcceptEncodingGzip;
            context.HeadersConfig_HeaderBehavior = this.HeadersConfig_HeaderBehavior;
            if (this.Headers_Item != null)
            {
                context.Headers_Item = new List<System.String>(this.Headers_Item);
            }
            context.Headers_Quantity = this.Headers_Quantity;
            context.QueryStringsConfig_QueryStringBehavior = this.QueryStringsConfig_QueryStringBehavior;
            if (this.QueryStrings_Item != null)
            {
                context.QueryStrings_Item = new List<System.String>(this.QueryStrings_Item);
            }
            context.QueryStrings_Quantity = this.QueryStrings_Quantity;
            
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
            var request = new Amazon.CloudFront.Model.CreateCachePolicyRequest();
            
            
             // populate CachePolicyConfig
            var requestCachePolicyConfigIsNull = true;
            request.CachePolicyConfig = new Amazon.CloudFront.Model.CachePolicyConfig();
            System.String requestCachePolicyConfig_cachePolicyConfig_Comment = null;
            if (cmdletContext.CachePolicyConfig_Comment != null)
            {
                requestCachePolicyConfig_cachePolicyConfig_Comment = cmdletContext.CachePolicyConfig_Comment;
            }
            if (requestCachePolicyConfig_cachePolicyConfig_Comment != null)
            {
                request.CachePolicyConfig.Comment = requestCachePolicyConfig_cachePolicyConfig_Comment;
                requestCachePolicyConfigIsNull = false;
            }
            System.Int64? requestCachePolicyConfig_cachePolicyConfig_DefaultTTL = null;
            if (cmdletContext.CachePolicyConfig_DefaultTTL != null)
            {
                requestCachePolicyConfig_cachePolicyConfig_DefaultTTL = cmdletContext.CachePolicyConfig_DefaultTTL.Value;
            }
            if (requestCachePolicyConfig_cachePolicyConfig_DefaultTTL != null)
            {
                request.CachePolicyConfig.DefaultTTL = requestCachePolicyConfig_cachePolicyConfig_DefaultTTL.Value;
                requestCachePolicyConfigIsNull = false;
            }
            System.Int64? requestCachePolicyConfig_cachePolicyConfig_MaxTTL = null;
            if (cmdletContext.CachePolicyConfig_MaxTTL != null)
            {
                requestCachePolicyConfig_cachePolicyConfig_MaxTTL = cmdletContext.CachePolicyConfig_MaxTTL.Value;
            }
            if (requestCachePolicyConfig_cachePolicyConfig_MaxTTL != null)
            {
                request.CachePolicyConfig.MaxTTL = requestCachePolicyConfig_cachePolicyConfig_MaxTTL.Value;
                requestCachePolicyConfigIsNull = false;
            }
            System.Int64? requestCachePolicyConfig_cachePolicyConfig_MinTTL = null;
            if (cmdletContext.CachePolicyConfig_MinTTL != null)
            {
                requestCachePolicyConfig_cachePolicyConfig_MinTTL = cmdletContext.CachePolicyConfig_MinTTL.Value;
            }
            if (requestCachePolicyConfig_cachePolicyConfig_MinTTL != null)
            {
                request.CachePolicyConfig.MinTTL = requestCachePolicyConfig_cachePolicyConfig_MinTTL.Value;
                requestCachePolicyConfigIsNull = false;
            }
            System.String requestCachePolicyConfig_cachePolicyConfig_Name = null;
            if (cmdletContext.CachePolicyConfig_Name != null)
            {
                requestCachePolicyConfig_cachePolicyConfig_Name = cmdletContext.CachePolicyConfig_Name;
            }
            if (requestCachePolicyConfig_cachePolicyConfig_Name != null)
            {
                request.CachePolicyConfig.Name = requestCachePolicyConfig_cachePolicyConfig_Name;
                requestCachePolicyConfigIsNull = false;
            }
            Amazon.CloudFront.Model.ParametersInCacheKeyAndForwardedToOrigin requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin = null;
            
             // populate ParametersInCacheKeyAndForwardedToOrigin
            var requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOriginIsNull = true;
            requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin = new Amazon.CloudFront.Model.ParametersInCacheKeyAndForwardedToOrigin();
            System.Boolean? requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_parametersInCacheKeyAndForwardedToOrigin_EnableAcceptEncodingBrotli = null;
            if (cmdletContext.ParametersInCacheKeyAndForwardedToOrigin_EnableAcceptEncodingBrotli != null)
            {
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_parametersInCacheKeyAndForwardedToOrigin_EnableAcceptEncodingBrotli = cmdletContext.ParametersInCacheKeyAndForwardedToOrigin_EnableAcceptEncodingBrotli.Value;
            }
            if (requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_parametersInCacheKeyAndForwardedToOrigin_EnableAcceptEncodingBrotli != null)
            {
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin.EnableAcceptEncodingBrotli = requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_parametersInCacheKeyAndForwardedToOrigin_EnableAcceptEncodingBrotli.Value;
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOriginIsNull = false;
            }
            System.Boolean? requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_parametersInCacheKeyAndForwardedToOrigin_EnableAcceptEncodingGzip = null;
            if (cmdletContext.ParametersInCacheKeyAndForwardedToOrigin_EnableAcceptEncodingGzip != null)
            {
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_parametersInCacheKeyAndForwardedToOrigin_EnableAcceptEncodingGzip = cmdletContext.ParametersInCacheKeyAndForwardedToOrigin_EnableAcceptEncodingGzip.Value;
            }
            if (requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_parametersInCacheKeyAndForwardedToOrigin_EnableAcceptEncodingGzip != null)
            {
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin.EnableAcceptEncodingGzip = requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_parametersInCacheKeyAndForwardedToOrigin_EnableAcceptEncodingGzip.Value;
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOriginIsNull = false;
            }
            Amazon.CloudFront.Model.CachePolicyCookiesConfig requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig = null;
            
             // populate CookiesConfig
            var requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfigIsNull = true;
            requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig = new Amazon.CloudFront.Model.CachePolicyCookiesConfig();
            Amazon.CloudFront.CachePolicyCookieBehavior requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_cookiesConfig_CookieBehavior = null;
            if (cmdletContext.CookiesConfig_CookieBehavior != null)
            {
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_cookiesConfig_CookieBehavior = cmdletContext.CookiesConfig_CookieBehavior;
            }
            if (requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_cookiesConfig_CookieBehavior != null)
            {
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig.CookieBehavior = requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_cookiesConfig_CookieBehavior;
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfigIsNull = false;
            }
            Amazon.CloudFront.Model.CookieNames requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_Cookies = null;
            
             // populate Cookies
            var requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_CookiesIsNull = true;
            requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_Cookies = new Amazon.CloudFront.Model.CookieNames();
            List<System.String> requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_Cookies_cookies_Item = null;
            if (cmdletContext.Cookies_Item != null)
            {
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_Cookies_cookies_Item = cmdletContext.Cookies_Item;
            }
            if (requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_Cookies_cookies_Item != null)
            {
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_Cookies.Items = requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_Cookies_cookies_Item;
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_CookiesIsNull = false;
            }
            System.Int32? requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_Cookies_cookies_Quantity = null;
            if (cmdletContext.Cookies_Quantity != null)
            {
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_Cookies_cookies_Quantity = cmdletContext.Cookies_Quantity.Value;
            }
            if (requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_Cookies_cookies_Quantity != null)
            {
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_Cookies.Quantity = requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_Cookies_cookies_Quantity.Value;
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_CookiesIsNull = false;
            }
             // determine if requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_Cookies should be set to null
            if (requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_CookiesIsNull)
            {
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_Cookies = null;
            }
            if (requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_Cookies != null)
            {
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig.Cookies = requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_Cookies;
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfigIsNull = false;
            }
             // determine if requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig should be set to null
            if (requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfigIsNull)
            {
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig = null;
            }
            if (requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig != null)
            {
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin.CookiesConfig = requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig;
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOriginIsNull = false;
            }
            Amazon.CloudFront.Model.CachePolicyHeadersConfig requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig = null;
            
             // populate HeadersConfig
            var requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfigIsNull = true;
            requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig = new Amazon.CloudFront.Model.CachePolicyHeadersConfig();
            Amazon.CloudFront.CachePolicyHeaderBehavior requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_headersConfig_HeaderBehavior = null;
            if (cmdletContext.HeadersConfig_HeaderBehavior != null)
            {
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_headersConfig_HeaderBehavior = cmdletContext.HeadersConfig_HeaderBehavior;
            }
            if (requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_headersConfig_HeaderBehavior != null)
            {
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig.HeaderBehavior = requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_headersConfig_HeaderBehavior;
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfigIsNull = false;
            }
            Amazon.CloudFront.Model.Headers requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_Headers = null;
            
             // populate Headers
            var requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_HeadersIsNull = true;
            requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_Headers = new Amazon.CloudFront.Model.Headers();
            List<System.String> requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_Headers_headers_Item = null;
            if (cmdletContext.Headers_Item != null)
            {
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_Headers_headers_Item = cmdletContext.Headers_Item;
            }
            if (requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_Headers_headers_Item != null)
            {
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_Headers.Items = requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_Headers_headers_Item;
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_HeadersIsNull = false;
            }
            System.Int32? requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_Headers_headers_Quantity = null;
            if (cmdletContext.Headers_Quantity != null)
            {
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_Headers_headers_Quantity = cmdletContext.Headers_Quantity.Value;
            }
            if (requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_Headers_headers_Quantity != null)
            {
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_Headers.Quantity = requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_Headers_headers_Quantity.Value;
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_HeadersIsNull = false;
            }
             // determine if requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_Headers should be set to null
            if (requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_HeadersIsNull)
            {
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_Headers = null;
            }
            if (requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_Headers != null)
            {
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig.Headers = requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_Headers;
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfigIsNull = false;
            }
             // determine if requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig should be set to null
            if (requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfigIsNull)
            {
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig = null;
            }
            if (requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig != null)
            {
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin.HeadersConfig = requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig;
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOriginIsNull = false;
            }
            Amazon.CloudFront.Model.CachePolicyQueryStringsConfig requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig = null;
            
             // populate QueryStringsConfig
            var requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfigIsNull = true;
            requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig = new Amazon.CloudFront.Model.CachePolicyQueryStringsConfig();
            Amazon.CloudFront.CachePolicyQueryStringBehavior requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_queryStringsConfig_QueryStringBehavior = null;
            if (cmdletContext.QueryStringsConfig_QueryStringBehavior != null)
            {
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_queryStringsConfig_QueryStringBehavior = cmdletContext.QueryStringsConfig_QueryStringBehavior;
            }
            if (requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_queryStringsConfig_QueryStringBehavior != null)
            {
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig.QueryStringBehavior = requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_queryStringsConfig_QueryStringBehavior;
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfigIsNull = false;
            }
            Amazon.CloudFront.Model.QueryStringNames requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_QueryStrings = null;
            
             // populate QueryStrings
            var requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_QueryStringsIsNull = true;
            requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_QueryStrings = new Amazon.CloudFront.Model.QueryStringNames();
            List<System.String> requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_QueryStrings_queryStrings_Item = null;
            if (cmdletContext.QueryStrings_Item != null)
            {
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_QueryStrings_queryStrings_Item = cmdletContext.QueryStrings_Item;
            }
            if (requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_QueryStrings_queryStrings_Item != null)
            {
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_QueryStrings.Items = requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_QueryStrings_queryStrings_Item;
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_QueryStringsIsNull = false;
            }
            System.Int32? requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_QueryStrings_queryStrings_Quantity = null;
            if (cmdletContext.QueryStrings_Quantity != null)
            {
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_QueryStrings_queryStrings_Quantity = cmdletContext.QueryStrings_Quantity.Value;
            }
            if (requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_QueryStrings_queryStrings_Quantity != null)
            {
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_QueryStrings.Quantity = requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_QueryStrings_queryStrings_Quantity.Value;
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_QueryStringsIsNull = false;
            }
             // determine if requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_QueryStrings should be set to null
            if (requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_QueryStringsIsNull)
            {
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_QueryStrings = null;
            }
            if (requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_QueryStrings != null)
            {
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig.QueryStrings = requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_QueryStrings;
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfigIsNull = false;
            }
             // determine if requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig should be set to null
            if (requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfigIsNull)
            {
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig = null;
            }
            if (requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig != null)
            {
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin.QueryStringsConfig = requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig;
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOriginIsNull = false;
            }
             // determine if requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin should be set to null
            if (requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOriginIsNull)
            {
                requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin = null;
            }
            if (requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin != null)
            {
                request.CachePolicyConfig.ParametersInCacheKeyAndForwardedToOrigin = requestCachePolicyConfig_cachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin;
                requestCachePolicyConfigIsNull = false;
            }
             // determine if request.CachePolicyConfig should be set to null
            if (requestCachePolicyConfigIsNull)
            {
                request.CachePolicyConfig = null;
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
        
        private Amazon.CloudFront.Model.CreateCachePolicyResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.CreateCachePolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "CreateCachePolicy");
            try
            {
                #if DESKTOP
                return client.CreateCachePolicy(request);
                #elif CORECLR
                return client.CreateCachePolicyAsync(request).GetAwaiter().GetResult();
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
            public System.String CachePolicyConfig_Comment { get; set; }
            public System.Int64? CachePolicyConfig_DefaultTTL { get; set; }
            public System.Int64? CachePolicyConfig_MaxTTL { get; set; }
            public System.Int64? CachePolicyConfig_MinTTL { get; set; }
            public System.String CachePolicyConfig_Name { get; set; }
            public Amazon.CloudFront.CachePolicyCookieBehavior CookiesConfig_CookieBehavior { get; set; }
            public List<System.String> Cookies_Item { get; set; }
            public System.Int32? Cookies_Quantity { get; set; }
            public System.Boolean? ParametersInCacheKeyAndForwardedToOrigin_EnableAcceptEncodingBrotli { get; set; }
            public System.Boolean? ParametersInCacheKeyAndForwardedToOrigin_EnableAcceptEncodingGzip { get; set; }
            public Amazon.CloudFront.CachePolicyHeaderBehavior HeadersConfig_HeaderBehavior { get; set; }
            public List<System.String> Headers_Item { get; set; }
            public System.Int32? Headers_Quantity { get; set; }
            public Amazon.CloudFront.CachePolicyQueryStringBehavior QueryStringsConfig_QueryStringBehavior { get; set; }
            public List<System.String> QueryStrings_Item { get; set; }
            public System.Int32? QueryStrings_Quantity { get; set; }
            public System.Func<Amazon.CloudFront.Model.CreateCachePolicyResponse, NewCFCachePolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
