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
using Amazon.CloudFront;
using Amazon.CloudFront.Model;

namespace Amazon.PowerShell.Cmdlets.CF
{
    /// <summary>
    /// Updates a cache policy configuration.
    /// 
    ///  
    /// <para>
    /// When you update a cache policy configuration, all the fields are updated with the
    /// values provided in the request. You cannot update some fields independent of others.
    /// To update a cache policy configuration:
    /// </para><ol><li><para>
    /// Use <c>GetCachePolicyConfig</c> to get the current configuration.
    /// </para></li><li><para>
    /// Locally modify the fields in the cache policy configuration that you want to update.
    /// </para></li><li><para>
    /// Call <c>UpdateCachePolicy</c> by providing the entire cache policy configuration,
    /// including the fields that you modified and those that you didn't.
    /// </para></li></ol><important><para>
    /// If your minimum TTL is greater than 0, CloudFront will cache content for at least
    /// the duration specified in the cache policy's minimum TTL, even if the <c>Cache-Control:
    /// no-cache</c>, <c>no-store</c>, or <c>private</c> directives are present in the origin
    /// headers.
    /// </para></important>
    /// </summary>
    [Cmdlet("Update", "CFCachePolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudFront.Model.CachePolicy")]
    [AWSCmdlet("Calls the Amazon CloudFront UpdateCachePolicy API operation.", Operation = new[] {"UpdateCachePolicy"}, SelectReturnType = typeof(Amazon.CloudFront.Model.UpdateCachePolicyResponse))]
    [AWSCmdletOutput("Amazon.CloudFront.Model.CachePolicy or Amazon.CloudFront.Model.UpdateCachePolicyResponse",
        "This cmdlet returns an Amazon.CloudFront.Model.CachePolicy object.",
        "The service call response (type Amazon.CloudFront.Model.UpdateCachePolicyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCFCachePolicyCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        /// in requests that CloudFront sends to the origin. Valid values are:</para><ul><li><para><c>none</c> – No cookies in viewer requests are included in the cache key or in requests
        /// that CloudFront sends to the origin. Even when this field is set to <c>none</c>, any
        /// cookies that are listed in an <c>OriginRequestPolicy</c><i>are</i> included in origin
        /// requests.</para></li><li><para><c>whitelist</c> – Only the cookies in viewer requests that are listed in the <c>CookieNames</c>
        /// type are included in the cache key and in requests that CloudFront sends to the origin.</para></li><li><para><c>allExcept</c> – All cookies in viewer requests are included in the cache key and
        /// in requests that CloudFront sends to the origin, <i><b>except</b></i> for those
        /// that are listed in the <c>CookieNames</c> type, which are not included.</para></li><li><para><c>all</c> – All cookies in viewer requests are included in the cache key and in
        /// requests that CloudFront sends to the origin.</para></li></ul>
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
        /// the origin does <i>not</i> send <c>Cache-Control</c> or <c>Expires</c> headers with
        /// the object. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/Expiration.html">Managing
        /// How Long Content Stays in an Edge Cache (Expiration)</a> in the <i>Amazon CloudFront
        /// Developer Guide</i>.</para><para>The default value for this field is 86400 seconds (one day). If the value of <c>MinTTL</c>
        /// is more than 86400 seconds, then the default value for this field is the same as the
        /// value of <c>MinTTL</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? CachePolicyConfig_DefaultTTL { get; set; }
        #endregion
        
        #region Parameter ParametersInCacheKeyAndForwardedToOrigin_EnableAcceptEncodingBrotli
        /// <summary>
        /// <para>
        /// <para>A flag that can affect whether the <c>Accept-Encoding</c> HTTP header is included
        /// in the cache key and included in requests that CloudFront sends to the origin.</para><para>This field is related to the <c>EnableAcceptEncodingGzip</c> field. If one or both
        /// of these fields is <c>true</c><i>and</i> the viewer request includes the <c>Accept-Encoding</c>
        /// header, then CloudFront does the following:</para><ul><li><para>Normalizes the value of the viewer's <c>Accept-Encoding</c> header</para></li><li><para>Includes the normalized header in the cache key</para></li><li><para>Includes the normalized header in the request to the origin, if a request is necessary</para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/controlling-the-cache-key.html#cache-policy-compressed-objects">Compression
        /// support</a> in the <i>Amazon CloudFront Developer Guide</i>.</para><para>If you set this value to <c>true</c>, and this cache behavior also has an origin request
        /// policy attached, do not include the <c>Accept-Encoding</c> header in the origin request
        /// policy. CloudFront always includes the <c>Accept-Encoding</c> header in origin requests
        /// when the value of this field is <c>true</c>, so including this header in an origin
        /// request policy has no effect.</para><para>If both of these fields are <c>false</c>, then CloudFront treats the <c>Accept-Encoding</c>
        /// header the same as any other HTTP header in the viewer request. By default, it's not
        /// included in the cache key and it's not included in origin requests. In this case,
        /// you can manually add <c>Accept-Encoding</c> to the headers whitelist like any other
        /// HTTP header.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_EnableAcceptEncodingBrotli")]
        public System.Boolean? ParametersInCacheKeyAndForwardedToOrigin_EnableAcceptEncodingBrotli { get; set; }
        #endregion
        
        #region Parameter ParametersInCacheKeyAndForwardedToOrigin_EnableAcceptEncodingGzip
        /// <summary>
        /// <para>
        /// <para>A flag that can affect whether the <c>Accept-Encoding</c> HTTP header is included
        /// in the cache key and included in requests that CloudFront sends to the origin.</para><para>This field is related to the <c>EnableAcceptEncodingBrotli</c> field. If one or both
        /// of these fields is <c>true</c><i>and</i> the viewer request includes the <c>Accept-Encoding</c>
        /// header, then CloudFront does the following:</para><ul><li><para>Normalizes the value of the viewer's <c>Accept-Encoding</c> header</para></li><li><para>Includes the normalized header in the cache key</para></li><li><para>Includes the normalized header in the request to the origin, if a request is necessary</para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/controlling-the-cache-key.html#cache-policy-compressed-objects">Compression
        /// support</a> in the <i>Amazon CloudFront Developer Guide</i>.</para><para>If you set this value to <c>true</c>, and this cache behavior also has an origin request
        /// policy attached, do not include the <c>Accept-Encoding</c> header in the origin request
        /// policy. CloudFront always includes the <c>Accept-Encoding</c> header in origin requests
        /// when the value of this field is <c>true</c>, so including this header in an origin
        /// request policy has no effect.</para><para>If both of these fields are <c>false</c>, then CloudFront treats the <c>Accept-Encoding</c>
        /// header the same as any other HTTP header in the viewer request. By default, it's not
        /// included in the cache key and it's not included in origin requests. In this case,
        /// you can manually add <c>Accept-Encoding</c> to the headers whitelist like any other
        /// HTTP header.</para>
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
        /// that CloudFront sends to the origin. Valid values are:</para><ul><li><para><c>none</c> – No HTTP headers are included in the cache key or in requests that CloudFront
        /// sends to the origin. Even when this field is set to <c>none</c>, any headers that
        /// are listed in an <c>OriginRequestPolicy</c><i>are</i> included in origin requests.</para></li><li><para><c>whitelist</c> – Only the HTTP headers that are listed in the <c>Headers</c> type
        /// are included in the cache key and in requests that CloudFront sends to the origin.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_HeaderBehavior")]
        [AWSConstantClassSource("Amazon.CloudFront.CachePolicyHeaderBehavior")]
        public Amazon.CloudFront.CachePolicyHeaderBehavior HeadersConfig_HeaderBehavior { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the cache policy that you are updating. The identifier is
        /// returned in a cache behavior's <c>CachePolicyId</c> field in the response to <c>GetDistributionConfig</c>.</para>
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
        /// <para>The version of the cache policy that you are updating. The version is returned in
        /// the cache policy's <c>ETag</c> field in the response to <c>GetCachePolicyConfig</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IfMatch { get; set; }
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
        /// updated. CloudFront uses this value only when the origin sends <c>Cache-Control</c>
        /// or <c>Expires</c> headers with the object. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/Expiration.html">Managing
        /// How Long Content Stays in an Edge Cache (Expiration)</a> in the <i>Amazon CloudFront
        /// Developer Guide</i>.</para><para>The default value for this field is 31536000 seconds (one year). If the value of <c>MinTTL</c>
        /// or <c>DefaultTTL</c> is more than 31536000 seconds, then the default value for this
        /// field is the same as the value of <c>DefaultTTL</c>.</para>
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
        /// <para>The number of cookie names in the <c>Items</c> list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_Cookies_Quantity")]
        public System.Int32? Cookies_Quantity { get; set; }
        #endregion
        
        #region Parameter Headers_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of header names in the <c>Items</c> list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_Headers_Quantity")]
        public System.Int32? Headers_Quantity { get; set; }
        #endregion
        
        #region Parameter QueryStrings_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of query string names in the <c>Items</c> list.</para>
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
        /// key and in requests that CloudFront sends to the origin. Valid values are:</para><ul><li><para><c>none</c> – No query strings in viewer requests are included in the cache key or
        /// in requests that CloudFront sends to the origin. Even when this field is set to <c>none</c>,
        /// any query strings that are listed in an <c>OriginRequestPolicy</c><i>are</i> included
        /// in origin requests.</para></li><li><para><c>whitelist</c> – Only the query strings in viewer requests that are listed in the
        /// <c>QueryStringNames</c> type are included in the cache key and in requests that CloudFront
        /// sends to the origin.</para></li><li><para><c>allExcept</c> – All query strings in viewer requests are included in the cache
        /// key and in requests that CloudFront sends to the origin, <i><b>except</b></i> those
        /// that are listed in the <c>QueryStringNames</c> type, which are not included.</para></li><li><para><c>all</c> – All query strings in viewer requests are included in the cache key and
        /// in requests that CloudFront sends to the origin.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_QueryStringBehavior")]
        [AWSConstantClassSource("Amazon.CloudFront.CachePolicyQueryStringBehavior")]
        public Amazon.CloudFront.CachePolicyQueryStringBehavior QueryStringsConfig_QueryStringBehavior { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CachePolicy'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFront.Model.UpdateCachePolicyResponse).
        /// Specifying the name of a property of type Amazon.CloudFront.Model.UpdateCachePolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CachePolicy";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CFCachePolicy (UpdateCachePolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFront.Model.UpdateCachePolicyResponse, UpdateCFCachePolicyCmdlet>(Select) ??
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
            var request = new Amazon.CloudFront.Model.UpdateCachePolicyRequest();
            
            
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
        
        private Amazon.CloudFront.Model.UpdateCachePolicyResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.UpdateCachePolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "UpdateCachePolicy");
            try
            {
                #if DESKTOP
                return client.UpdateCachePolicy(request);
                #elif CORECLR
                return client.UpdateCachePolicyAsync(request).GetAwaiter().GetResult();
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
            public System.String Id { get; set; }
            public System.String IfMatch { get; set; }
            public System.Func<Amazon.CloudFront.Model.UpdateCachePolicyResponse, UpdateCFCachePolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CachePolicy;
        }
        
    }
}
