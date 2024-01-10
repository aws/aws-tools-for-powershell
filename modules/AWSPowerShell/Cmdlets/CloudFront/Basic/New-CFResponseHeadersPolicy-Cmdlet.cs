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
    /// Creates a response headers policy.
    /// 
    ///  
    /// <para>
    /// A response headers policy contains information about a set of HTTP headers. To create
    /// a response headers policy, you provide some metadata about the policy and a set of
    /// configurations that specify the headers.
    /// </para><para>
    /// After you create a response headers policy, you can use its ID to attach it to one
    /// or more cache behaviors in a CloudFront distribution. When it's attached to a cache
    /// behavior, the response headers policy affects the HTTP headers that CloudFront includes
    /// in HTTP responses to requests that match the cache behavior. CloudFront adds or removes
    /// response headers according to the configuration of the response headers policy.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/modifying-response-headers.html">Adding
    /// or removing HTTP headers in CloudFront responses</a> in the <i>Amazon CloudFront Developer
    /// Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "CFResponseHeadersPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudFront.Model.CreateResponseHeadersPolicyResponse")]
    [AWSCmdlet("Calls the Amazon CloudFront CreateResponseHeadersPolicy API operation.", Operation = new[] {"CreateResponseHeadersPolicy"}, SelectReturnType = typeof(Amazon.CloudFront.Model.CreateResponseHeadersPolicyResponse))]
    [AWSCmdletOutput("Amazon.CloudFront.Model.CreateResponseHeadersPolicyResponse",
        "This cmdlet returns an Amazon.CloudFront.Model.CreateResponseHeadersPolicyResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCFResponseHeadersPolicyCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CorsConfig_AccessControlAllowCredential
        /// <summary>
        /// <para>
        /// <para>A Boolean that CloudFront uses as the value for the <c>Access-Control-Allow-Credentials</c>
        /// HTTP response header.</para><para>For more information about the <c>Access-Control-Allow-Credentials</c> HTTP response
        /// header, see <a href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Access-Control-Allow-Credentials">Access-Control-Allow-Credentials</a>
        /// in the MDN Web Docs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResponseHeadersPolicyConfig_CorsConfig_AccessControlAllowCredentials")]
        public System.Boolean? CorsConfig_AccessControlAllowCredential { get; set; }
        #endregion
        
        #region Parameter CorsConfig_AccessControlMaxAgeSec
        /// <summary>
        /// <para>
        /// <para>A number that CloudFront uses as the value for the <c>Access-Control-Max-Age</c> HTTP
        /// response header.</para><para>For more information about the <c>Access-Control-Max-Age</c> HTTP response header,
        /// see <a href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Access-Control-Max-Age">Access-Control-Max-Age</a>
        /// in the MDN Web Docs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResponseHeadersPolicyConfig_CorsConfig_AccessControlMaxAgeSec")]
        public System.Int32? CorsConfig_AccessControlMaxAgeSec { get; set; }
        #endregion
        
        #region Parameter StrictTransportSecurity_AccessControlMaxAgeSec
        /// <summary>
        /// <para>
        /// <para>A number that CloudFront uses as the value for the <c>max-age</c> directive in the
        /// <c>Strict-Transport-Security</c> HTTP response header.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResponseHeadersPolicyConfig_SecurityHeadersConfig_StrictTransportSecurity_AccessControlMaxAgeSec")]
        public System.Int32? StrictTransportSecurity_AccessControlMaxAgeSec { get; set; }
        #endregion
        
        #region Parameter ResponseHeadersPolicyConfig_Comment
        /// <summary>
        /// <para>
        /// <para>A comment to describe the response headers policy.</para><para>The comment cannot be longer than 128 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResponseHeadersPolicyConfig_Comment { get; set; }
        #endregion
        
        #region Parameter ContentSecurityPolicy_ContentSecurityPolicy
        /// <summary>
        /// <para>
        /// <para>The policy directives and their values that CloudFront includes as values for the
        /// <c>Content-Security-Policy</c> HTTP response header.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResponseHeadersPolicyConfig_SecurityHeadersConfig_ContentSecurityPolicy_ContentSecurityPolicy")]
        public System.String ContentSecurityPolicy_ContentSecurityPolicy { get; set; }
        #endregion
        
        #region Parameter ServerTimingHeadersConfig_Enabled
        /// <summary>
        /// <para>
        /// <para>A Boolean that determines whether CloudFront adds the <c>Server-Timing</c> header
        /// to HTTP responses that it sends in response to requests that match a cache behavior
        /// that's associated with this response headers policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResponseHeadersPolicyConfig_ServerTimingHeadersConfig_Enabled")]
        public System.Boolean? ServerTimingHeadersConfig_Enabled { get; set; }
        #endregion
        
        #region Parameter FrameOptions_FrameOption
        /// <summary>
        /// <para>
        /// <para>The value of the <c>X-Frame-Options</c> HTTP response header. Valid values are <c>DENY</c>
        /// and <c>SAMEORIGIN</c>.</para><para>For more information about these values, see <a href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-Frame-Options">X-Frame-Options</a>
        /// in the MDN Web Docs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResponseHeadersPolicyConfig_SecurityHeadersConfig_FrameOptions_FrameOption")]
        [AWSConstantClassSource("Amazon.CloudFront.FrameOptionsList")]
        public Amazon.CloudFront.FrameOptionsList FrameOptions_FrameOption { get; set; }
        #endregion
        
        #region Parameter StrictTransportSecurity_IncludeSubdomain
        /// <summary>
        /// <para>
        /// <para>A Boolean that determines whether CloudFront includes the <c>includeSubDomains</c>
        /// directive in the <c>Strict-Transport-Security</c> HTTP response header.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResponseHeadersPolicyConfig_SecurityHeadersConfig_StrictTransportSecurity_IncludeSubdomains")]
        public System.Boolean? StrictTransportSecurity_IncludeSubdomain { get; set; }
        #endregion
        
        #region Parameter AccessControlAllowHeaders_Item
        /// <summary>
        /// <para>
        /// <para>The list of HTTP header names. You can specify <c>*</c> to allow all headers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResponseHeadersPolicyConfig_CorsConfig_AccessControlAllowHeaders_Items")]
        public System.String[] AccessControlAllowHeaders_Item { get; set; }
        #endregion
        
        #region Parameter AccessControlAllowMethods_Item
        /// <summary>
        /// <para>
        /// <para>The list of HTTP methods. Valid values are:</para><ul><li><para><c>GET</c></para></li><li><para><c>DELETE</c></para></li><li><para><c>HEAD</c></para></li><li><para><c>OPTIONS</c></para></li><li><para><c>PATCH</c></para></li><li><para><c>POST</c></para></li><li><para><c>PUT</c></para></li><li><para><c>ALL</c></para></li></ul><para><c>ALL</c> is a special value that includes all of the listed HTTP methods.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResponseHeadersPolicyConfig_CorsConfig_AccessControlAllowMethods_Items")]
        public System.String[] AccessControlAllowMethods_Item { get; set; }
        #endregion
        
        #region Parameter AccessControlAllowOrigins_Item
        /// <summary>
        /// <para>
        /// <para>The list of origins (domain names). You can specify <c>*</c> to allow all origins.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResponseHeadersPolicyConfig_CorsConfig_AccessControlAllowOrigins_Items")]
        public System.String[] AccessControlAllowOrigins_Item { get; set; }
        #endregion
        
        #region Parameter AccessControlExposeHeaders_Item
        /// <summary>
        /// <para>
        /// <para>The list of HTTP headers. You can specify <c>*</c> to expose all headers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResponseHeadersPolicyConfig_CorsConfig_AccessControlExposeHeaders_Items")]
        public System.String[] AccessControlExposeHeaders_Item { get; set; }
        #endregion
        
        #region Parameter CustomHeadersConfig_Item
        /// <summary>
        /// <para>
        /// <para>The list of HTTP response headers and their values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResponseHeadersPolicyConfig_CustomHeadersConfig_Items")]
        public Amazon.CloudFront.Model.ResponseHeadersPolicyCustomHeader[] CustomHeadersConfig_Item { get; set; }
        #endregion
        
        #region Parameter RemoveHeadersConfig_Item
        /// <summary>
        /// <para>
        /// <para>The list of HTTP header names.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResponseHeadersPolicyConfig_RemoveHeadersConfig_Items")]
        public Amazon.CloudFront.Model.ResponseHeadersPolicyRemoveHeader[] RemoveHeadersConfig_Item { get; set; }
        #endregion
        
        #region Parameter XSSProtection_ModeBlock
        /// <summary>
        /// <para>
        /// <para>A Boolean that determines whether CloudFront includes the <c>mode=block</c> directive
        /// in the <c>X-XSS-Protection</c> header.</para><para>For more information about this directive, see <a href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-XSS-Protection">X-XSS-Protection</a>
        /// in the MDN Web Docs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResponseHeadersPolicyConfig_SecurityHeadersConfig_XSSProtection_ModeBlock")]
        public System.Boolean? XSSProtection_ModeBlock { get; set; }
        #endregion
        
        #region Parameter ResponseHeadersPolicyConfig_Name
        /// <summary>
        /// <para>
        /// <para>A name to identify the response headers policy.</para><para>The name must be unique for response headers policies in this Amazon Web Services
        /// account.</para>
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
        public System.String ResponseHeadersPolicyConfig_Name { get; set; }
        #endregion
        
        #region Parameter CorsConfig_OriginOverride
        /// <summary>
        /// <para>
        /// <para>A Boolean that determines whether CloudFront overrides HTTP response headers received
        /// from the origin with the ones specified in this response headers policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResponseHeadersPolicyConfig_CorsConfig_OriginOverride")]
        public System.Boolean? CorsConfig_OriginOverride { get; set; }
        #endregion
        
        #region Parameter ContentSecurityPolicy_Override
        /// <summary>
        /// <para>
        /// <para>A Boolean that determines whether CloudFront overrides the <c>Content-Security-Policy</c>
        /// HTTP response header received from the origin with the one specified in this response
        /// headers policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResponseHeadersPolicyConfig_SecurityHeadersConfig_ContentSecurityPolicy_Override")]
        public System.Boolean? ContentSecurityPolicy_Override { get; set; }
        #endregion
        
        #region Parameter ContentTypeOptions_Override
        /// <summary>
        /// <para>
        /// <para>A Boolean that determines whether CloudFront overrides the <c>X-Content-Type-Options</c>
        /// HTTP response header received from the origin with the one specified in this response
        /// headers policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResponseHeadersPolicyConfig_SecurityHeadersConfig_ContentTypeOptions_Override")]
        public System.Boolean? ContentTypeOptions_Override { get; set; }
        #endregion
        
        #region Parameter FrameOptions_Override
        /// <summary>
        /// <para>
        /// <para>A Boolean that determines whether CloudFront overrides the <c>X-Frame-Options</c>
        /// HTTP response header received from the origin with the one specified in this response
        /// headers policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResponseHeadersPolicyConfig_SecurityHeadersConfig_FrameOptions_Override")]
        public System.Boolean? FrameOptions_Override { get; set; }
        #endregion
        
        #region Parameter ReferrerPolicy_Override
        /// <summary>
        /// <para>
        /// <para>A Boolean that determines whether CloudFront overrides the <c>Referrer-Policy</c>
        /// HTTP response header received from the origin with the one specified in this response
        /// headers policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResponseHeadersPolicyConfig_SecurityHeadersConfig_ReferrerPolicy_Override")]
        public System.Boolean? ReferrerPolicy_Override { get; set; }
        #endregion
        
        #region Parameter StrictTransportSecurity_Override
        /// <summary>
        /// <para>
        /// <para>A Boolean that determines whether CloudFront overrides the <c>Strict-Transport-Security</c>
        /// HTTP response header received from the origin with the one specified in this response
        /// headers policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResponseHeadersPolicyConfig_SecurityHeadersConfig_StrictTransportSecurity_Override")]
        public System.Boolean? StrictTransportSecurity_Override { get; set; }
        #endregion
        
        #region Parameter XSSProtection_Override
        /// <summary>
        /// <para>
        /// <para>A Boolean that determines whether CloudFront overrides the <c>X-XSS-Protection</c>
        /// HTTP response header received from the origin with the one specified in this response
        /// headers policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResponseHeadersPolicyConfig_SecurityHeadersConfig_XSSProtection_Override")]
        public System.Boolean? XSSProtection_Override { get; set; }
        #endregion
        
        #region Parameter StrictTransportSecurity_Preload
        /// <summary>
        /// <para>
        /// <para>A Boolean that determines whether CloudFront includes the <c>preload</c> directive
        /// in the <c>Strict-Transport-Security</c> HTTP response header.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResponseHeadersPolicyConfig_SecurityHeadersConfig_StrictTransportSecurity_Preload")]
        public System.Boolean? StrictTransportSecurity_Preload { get; set; }
        #endregion
        
        #region Parameter XSSProtection_Protection
        /// <summary>
        /// <para>
        /// <para>A Boolean that determines the value of the <c>X-XSS-Protection</c> HTTP response header.
        /// When this setting is <c>true</c>, the value of the <c>X-XSS-Protection</c> header
        /// is <c>1</c>. When this setting is <c>false</c>, the value of the <c>X-XSS-Protection</c>
        /// header is <c>0</c>.</para><para>For more information about these settings, see <a href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-XSS-Protection">X-XSS-Protection</a>
        /// in the MDN Web Docs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResponseHeadersPolicyConfig_SecurityHeadersConfig_XSSProtection_Protection")]
        public System.Boolean? XSSProtection_Protection { get; set; }
        #endregion
        
        #region Parameter AccessControlAllowHeaders_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of HTTP header names in the list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResponseHeadersPolicyConfig_CorsConfig_AccessControlAllowHeaders_Quantity")]
        public System.Int32? AccessControlAllowHeaders_Quantity { get; set; }
        #endregion
        
        #region Parameter AccessControlAllowMethods_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of HTTP methods in the list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResponseHeadersPolicyConfig_CorsConfig_AccessControlAllowMethods_Quantity")]
        public System.Int32? AccessControlAllowMethods_Quantity { get; set; }
        #endregion
        
        #region Parameter AccessControlAllowOrigins_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of origins in the list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResponseHeadersPolicyConfig_CorsConfig_AccessControlAllowOrigins_Quantity")]
        public System.Int32? AccessControlAllowOrigins_Quantity { get; set; }
        #endregion
        
        #region Parameter AccessControlExposeHeaders_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of HTTP headers in the list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResponseHeadersPolicyConfig_CorsConfig_AccessControlExposeHeaders_Quantity")]
        public System.Int32? AccessControlExposeHeaders_Quantity { get; set; }
        #endregion
        
        #region Parameter CustomHeadersConfig_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of HTTP response headers in the list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResponseHeadersPolicyConfig_CustomHeadersConfig_Quantity")]
        public System.Int32? CustomHeadersConfig_Quantity { get; set; }
        #endregion
        
        #region Parameter RemoveHeadersConfig_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of HTTP header names in the list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResponseHeadersPolicyConfig_RemoveHeadersConfig_Quantity")]
        public System.Int32? RemoveHeadersConfig_Quantity { get; set; }
        #endregion
        
        #region Parameter ReferrerPolicy_ReferrerPolicy
        /// <summary>
        /// <para>
        /// <para>The value of the <c>Referrer-Policy</c> HTTP response header. Valid values are:</para><ul><li><para><c>no-referrer</c></para></li><li><para><c>no-referrer-when-downgrade</c></para></li><li><para><c>origin</c></para></li><li><para><c>origin-when-cross-origin</c></para></li><li><para><c>same-origin</c></para></li><li><para><c>strict-origin</c></para></li><li><para><c>strict-origin-when-cross-origin</c></para></li><li><para><c>unsafe-url</c></para></li></ul><para>For more information about these values, see <a href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Referrer-Policy">Referrer-Policy</a>
        /// in the MDN Web Docs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResponseHeadersPolicyConfig_SecurityHeadersConfig_ReferrerPolicy_ReferrerPolicy")]
        [AWSConstantClassSource("Amazon.CloudFront.ReferrerPolicyList")]
        public Amazon.CloudFront.ReferrerPolicyList ReferrerPolicy_ReferrerPolicy { get; set; }
        #endregion
        
        #region Parameter XSSProtection_ReportUri
        /// <summary>
        /// <para>
        /// <para>A reporting URI, which CloudFront uses as the value of the <c>report</c> directive
        /// in the <c>X-XSS-Protection</c> header.</para><para>You cannot specify a <c>ReportUri</c> when <c>ModeBlock</c> is <c>true</c>.</para><para>For more information about using a reporting URL, see <a href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-XSS-Protection">X-XSS-Protection</a>
        /// in the MDN Web Docs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResponseHeadersPolicyConfig_SecurityHeadersConfig_XSSProtection_ReportUri")]
        public System.String XSSProtection_ReportUri { get; set; }
        #endregion
        
        #region Parameter ServerTimingHeadersConfig_SamplingRate
        /// <summary>
        /// <para>
        /// <para>A number 0–100 (inclusive) that specifies the percentage of responses that you want
        /// CloudFront to add the <c>Server-Timing</c> header to. When you set the sampling rate
        /// to 100, CloudFront adds the <c>Server-Timing</c> header to the HTTP response for every
        /// request that matches the cache behavior that this response headers policy is attached
        /// to. When you set it to 50, CloudFront adds the header to 50% of the responses for
        /// requests that match the cache behavior. You can set the sampling rate to any number
        /// 0–100 with up to four decimal places.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResponseHeadersPolicyConfig_ServerTimingHeadersConfig_SamplingRate")]
        public System.Double? ServerTimingHeadersConfig_SamplingRate { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFront.Model.CreateResponseHeadersPolicyResponse).
        /// Specifying the name of a property of type Amazon.CloudFront.Model.CreateResponseHeadersPolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ResponseHeadersPolicyConfig_Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ResponseHeadersPolicyConfig_Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ResponseHeadersPolicyConfig_Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResponseHeadersPolicyConfig_Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CFResponseHeadersPolicy (CreateResponseHeadersPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFront.Model.CreateResponseHeadersPolicyResponse, NewCFResponseHeadersPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ResponseHeadersPolicyConfig_Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ResponseHeadersPolicyConfig_Comment = this.ResponseHeadersPolicyConfig_Comment;
            context.CorsConfig_AccessControlAllowCredential = this.CorsConfig_AccessControlAllowCredential;
            if (this.AccessControlAllowHeaders_Item != null)
            {
                context.AccessControlAllowHeaders_Item = new List<System.String>(this.AccessControlAllowHeaders_Item);
            }
            context.AccessControlAllowHeaders_Quantity = this.AccessControlAllowHeaders_Quantity;
            if (this.AccessControlAllowMethods_Item != null)
            {
                context.AccessControlAllowMethods_Item = new List<System.String>(this.AccessControlAllowMethods_Item);
            }
            context.AccessControlAllowMethods_Quantity = this.AccessControlAllowMethods_Quantity;
            if (this.AccessControlAllowOrigins_Item != null)
            {
                context.AccessControlAllowOrigins_Item = new List<System.String>(this.AccessControlAllowOrigins_Item);
            }
            context.AccessControlAllowOrigins_Quantity = this.AccessControlAllowOrigins_Quantity;
            if (this.AccessControlExposeHeaders_Item != null)
            {
                context.AccessControlExposeHeaders_Item = new List<System.String>(this.AccessControlExposeHeaders_Item);
            }
            context.AccessControlExposeHeaders_Quantity = this.AccessControlExposeHeaders_Quantity;
            context.CorsConfig_AccessControlMaxAgeSec = this.CorsConfig_AccessControlMaxAgeSec;
            context.CorsConfig_OriginOverride = this.CorsConfig_OriginOverride;
            if (this.CustomHeadersConfig_Item != null)
            {
                context.CustomHeadersConfig_Item = new List<Amazon.CloudFront.Model.ResponseHeadersPolicyCustomHeader>(this.CustomHeadersConfig_Item);
            }
            context.CustomHeadersConfig_Quantity = this.CustomHeadersConfig_Quantity;
            context.ResponseHeadersPolicyConfig_Name = this.ResponseHeadersPolicyConfig_Name;
            #if MODULAR
            if (this.ResponseHeadersPolicyConfig_Name == null && ParameterWasBound(nameof(this.ResponseHeadersPolicyConfig_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter ResponseHeadersPolicyConfig_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.RemoveHeadersConfig_Item != null)
            {
                context.RemoveHeadersConfig_Item = new List<Amazon.CloudFront.Model.ResponseHeadersPolicyRemoveHeader>(this.RemoveHeadersConfig_Item);
            }
            context.RemoveHeadersConfig_Quantity = this.RemoveHeadersConfig_Quantity;
            context.ContentSecurityPolicy_ContentSecurityPolicy = this.ContentSecurityPolicy_ContentSecurityPolicy;
            context.ContentSecurityPolicy_Override = this.ContentSecurityPolicy_Override;
            context.ContentTypeOptions_Override = this.ContentTypeOptions_Override;
            context.FrameOptions_FrameOption = this.FrameOptions_FrameOption;
            context.FrameOptions_Override = this.FrameOptions_Override;
            context.ReferrerPolicy_Override = this.ReferrerPolicy_Override;
            context.ReferrerPolicy_ReferrerPolicy = this.ReferrerPolicy_ReferrerPolicy;
            context.StrictTransportSecurity_AccessControlMaxAgeSec = this.StrictTransportSecurity_AccessControlMaxAgeSec;
            context.StrictTransportSecurity_IncludeSubdomain = this.StrictTransportSecurity_IncludeSubdomain;
            context.StrictTransportSecurity_Override = this.StrictTransportSecurity_Override;
            context.StrictTransportSecurity_Preload = this.StrictTransportSecurity_Preload;
            context.XSSProtection_ModeBlock = this.XSSProtection_ModeBlock;
            context.XSSProtection_Override = this.XSSProtection_Override;
            context.XSSProtection_Protection = this.XSSProtection_Protection;
            context.XSSProtection_ReportUri = this.XSSProtection_ReportUri;
            context.ServerTimingHeadersConfig_Enabled = this.ServerTimingHeadersConfig_Enabled;
            context.ServerTimingHeadersConfig_SamplingRate = this.ServerTimingHeadersConfig_SamplingRate;
            
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
            var request = new Amazon.CloudFront.Model.CreateResponseHeadersPolicyRequest();
            
            
             // populate ResponseHeadersPolicyConfig
            var requestResponseHeadersPolicyConfigIsNull = true;
            request.ResponseHeadersPolicyConfig = new Amazon.CloudFront.Model.ResponseHeadersPolicyConfig();
            System.String requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_Comment = null;
            if (cmdletContext.ResponseHeadersPolicyConfig_Comment != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_Comment = cmdletContext.ResponseHeadersPolicyConfig_Comment;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_Comment != null)
            {
                request.ResponseHeadersPolicyConfig.Comment = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_Comment;
                requestResponseHeadersPolicyConfigIsNull = false;
            }
            System.String requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_Name = null;
            if (cmdletContext.ResponseHeadersPolicyConfig_Name != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_Name = cmdletContext.ResponseHeadersPolicyConfig_Name;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_Name != null)
            {
                request.ResponseHeadersPolicyConfig.Name = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_Name;
                requestResponseHeadersPolicyConfigIsNull = false;
            }
            Amazon.CloudFront.Model.ResponseHeadersPolicyCustomHeadersConfig requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CustomHeadersConfig = null;
            
             // populate CustomHeadersConfig
            var requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CustomHeadersConfigIsNull = true;
            requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CustomHeadersConfig = new Amazon.CloudFront.Model.ResponseHeadersPolicyCustomHeadersConfig();
            List<Amazon.CloudFront.Model.ResponseHeadersPolicyCustomHeader> requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CustomHeadersConfig_customHeadersConfig_Item = null;
            if (cmdletContext.CustomHeadersConfig_Item != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CustomHeadersConfig_customHeadersConfig_Item = cmdletContext.CustomHeadersConfig_Item;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CustomHeadersConfig_customHeadersConfig_Item != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CustomHeadersConfig.Items = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CustomHeadersConfig_customHeadersConfig_Item;
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CustomHeadersConfigIsNull = false;
            }
            System.Int32? requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CustomHeadersConfig_customHeadersConfig_Quantity = null;
            if (cmdletContext.CustomHeadersConfig_Quantity != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CustomHeadersConfig_customHeadersConfig_Quantity = cmdletContext.CustomHeadersConfig_Quantity.Value;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CustomHeadersConfig_customHeadersConfig_Quantity != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CustomHeadersConfig.Quantity = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CustomHeadersConfig_customHeadersConfig_Quantity.Value;
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CustomHeadersConfigIsNull = false;
            }
             // determine if requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CustomHeadersConfig should be set to null
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CustomHeadersConfigIsNull)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CustomHeadersConfig = null;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CustomHeadersConfig != null)
            {
                request.ResponseHeadersPolicyConfig.CustomHeadersConfig = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CustomHeadersConfig;
                requestResponseHeadersPolicyConfigIsNull = false;
            }
            Amazon.CloudFront.Model.ResponseHeadersPolicyRemoveHeadersConfig requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_RemoveHeadersConfig = null;
            
             // populate RemoveHeadersConfig
            var requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_RemoveHeadersConfigIsNull = true;
            requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_RemoveHeadersConfig = new Amazon.CloudFront.Model.ResponseHeadersPolicyRemoveHeadersConfig();
            List<Amazon.CloudFront.Model.ResponseHeadersPolicyRemoveHeader> requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_RemoveHeadersConfig_removeHeadersConfig_Item = null;
            if (cmdletContext.RemoveHeadersConfig_Item != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_RemoveHeadersConfig_removeHeadersConfig_Item = cmdletContext.RemoveHeadersConfig_Item;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_RemoveHeadersConfig_removeHeadersConfig_Item != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_RemoveHeadersConfig.Items = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_RemoveHeadersConfig_removeHeadersConfig_Item;
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_RemoveHeadersConfigIsNull = false;
            }
            System.Int32? requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_RemoveHeadersConfig_removeHeadersConfig_Quantity = null;
            if (cmdletContext.RemoveHeadersConfig_Quantity != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_RemoveHeadersConfig_removeHeadersConfig_Quantity = cmdletContext.RemoveHeadersConfig_Quantity.Value;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_RemoveHeadersConfig_removeHeadersConfig_Quantity != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_RemoveHeadersConfig.Quantity = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_RemoveHeadersConfig_removeHeadersConfig_Quantity.Value;
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_RemoveHeadersConfigIsNull = false;
            }
             // determine if requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_RemoveHeadersConfig should be set to null
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_RemoveHeadersConfigIsNull)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_RemoveHeadersConfig = null;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_RemoveHeadersConfig != null)
            {
                request.ResponseHeadersPolicyConfig.RemoveHeadersConfig = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_RemoveHeadersConfig;
                requestResponseHeadersPolicyConfigIsNull = false;
            }
            Amazon.CloudFront.Model.ResponseHeadersPolicyServerTimingHeadersConfig requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_ServerTimingHeadersConfig = null;
            
             // populate ServerTimingHeadersConfig
            var requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_ServerTimingHeadersConfigIsNull = true;
            requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_ServerTimingHeadersConfig = new Amazon.CloudFront.Model.ResponseHeadersPolicyServerTimingHeadersConfig();
            System.Boolean? requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_ServerTimingHeadersConfig_serverTimingHeadersConfig_Enabled = null;
            if (cmdletContext.ServerTimingHeadersConfig_Enabled != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_ServerTimingHeadersConfig_serverTimingHeadersConfig_Enabled = cmdletContext.ServerTimingHeadersConfig_Enabled.Value;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_ServerTimingHeadersConfig_serverTimingHeadersConfig_Enabled != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_ServerTimingHeadersConfig.Enabled = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_ServerTimingHeadersConfig_serverTimingHeadersConfig_Enabled.Value;
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_ServerTimingHeadersConfigIsNull = false;
            }
            System.Double? requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_ServerTimingHeadersConfig_serverTimingHeadersConfig_SamplingRate = null;
            if (cmdletContext.ServerTimingHeadersConfig_SamplingRate != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_ServerTimingHeadersConfig_serverTimingHeadersConfig_SamplingRate = cmdletContext.ServerTimingHeadersConfig_SamplingRate.Value;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_ServerTimingHeadersConfig_serverTimingHeadersConfig_SamplingRate != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_ServerTimingHeadersConfig.SamplingRate = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_ServerTimingHeadersConfig_serverTimingHeadersConfig_SamplingRate.Value;
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_ServerTimingHeadersConfigIsNull = false;
            }
             // determine if requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_ServerTimingHeadersConfig should be set to null
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_ServerTimingHeadersConfigIsNull)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_ServerTimingHeadersConfig = null;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_ServerTimingHeadersConfig != null)
            {
                request.ResponseHeadersPolicyConfig.ServerTimingHeadersConfig = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_ServerTimingHeadersConfig;
                requestResponseHeadersPolicyConfigIsNull = false;
            }
            Amazon.CloudFront.Model.ResponseHeadersPolicySecurityHeadersConfig requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig = null;
            
             // populate SecurityHeadersConfig
            var requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfigIsNull = true;
            requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig = new Amazon.CloudFront.Model.ResponseHeadersPolicySecurityHeadersConfig();
            Amazon.CloudFront.Model.ResponseHeadersPolicyContentTypeOptions requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ContentTypeOptions = null;
            
             // populate ContentTypeOptions
            var requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ContentTypeOptionsIsNull = true;
            requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ContentTypeOptions = new Amazon.CloudFront.Model.ResponseHeadersPolicyContentTypeOptions();
            System.Boolean? requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ContentTypeOptions_contentTypeOptions_Override = null;
            if (cmdletContext.ContentTypeOptions_Override != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ContentTypeOptions_contentTypeOptions_Override = cmdletContext.ContentTypeOptions_Override.Value;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ContentTypeOptions_contentTypeOptions_Override != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ContentTypeOptions.Override = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ContentTypeOptions_contentTypeOptions_Override.Value;
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ContentTypeOptionsIsNull = false;
            }
             // determine if requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ContentTypeOptions should be set to null
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ContentTypeOptionsIsNull)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ContentTypeOptions = null;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ContentTypeOptions != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig.ContentTypeOptions = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ContentTypeOptions;
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfigIsNull = false;
            }
            Amazon.CloudFront.Model.ResponseHeadersPolicyContentSecurityPolicy requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ContentSecurityPolicy = null;
            
             // populate ContentSecurityPolicy
            var requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ContentSecurityPolicyIsNull = true;
            requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ContentSecurityPolicy = new Amazon.CloudFront.Model.ResponseHeadersPolicyContentSecurityPolicy();
            System.String requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ContentSecurityPolicy_contentSecurityPolicy_ContentSecurityPolicy = null;
            if (cmdletContext.ContentSecurityPolicy_ContentSecurityPolicy != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ContentSecurityPolicy_contentSecurityPolicy_ContentSecurityPolicy = cmdletContext.ContentSecurityPolicy_ContentSecurityPolicy;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ContentSecurityPolicy_contentSecurityPolicy_ContentSecurityPolicy != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ContentSecurityPolicy.ContentSecurityPolicy = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ContentSecurityPolicy_contentSecurityPolicy_ContentSecurityPolicy;
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ContentSecurityPolicyIsNull = false;
            }
            System.Boolean? requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ContentSecurityPolicy_contentSecurityPolicy_Override = null;
            if (cmdletContext.ContentSecurityPolicy_Override != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ContentSecurityPolicy_contentSecurityPolicy_Override = cmdletContext.ContentSecurityPolicy_Override.Value;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ContentSecurityPolicy_contentSecurityPolicy_Override != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ContentSecurityPolicy.Override = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ContentSecurityPolicy_contentSecurityPolicy_Override.Value;
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ContentSecurityPolicyIsNull = false;
            }
             // determine if requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ContentSecurityPolicy should be set to null
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ContentSecurityPolicyIsNull)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ContentSecurityPolicy = null;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ContentSecurityPolicy != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig.ContentSecurityPolicy = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ContentSecurityPolicy;
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfigIsNull = false;
            }
            Amazon.CloudFront.Model.ResponseHeadersPolicyFrameOptions requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_FrameOptions = null;
            
             // populate FrameOptions
            var requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_FrameOptionsIsNull = true;
            requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_FrameOptions = new Amazon.CloudFront.Model.ResponseHeadersPolicyFrameOptions();
            Amazon.CloudFront.FrameOptionsList requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_FrameOptions_frameOptions_FrameOption = null;
            if (cmdletContext.FrameOptions_FrameOption != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_FrameOptions_frameOptions_FrameOption = cmdletContext.FrameOptions_FrameOption;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_FrameOptions_frameOptions_FrameOption != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_FrameOptions.FrameOption = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_FrameOptions_frameOptions_FrameOption;
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_FrameOptionsIsNull = false;
            }
            System.Boolean? requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_FrameOptions_frameOptions_Override = null;
            if (cmdletContext.FrameOptions_Override != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_FrameOptions_frameOptions_Override = cmdletContext.FrameOptions_Override.Value;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_FrameOptions_frameOptions_Override != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_FrameOptions.Override = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_FrameOptions_frameOptions_Override.Value;
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_FrameOptionsIsNull = false;
            }
             // determine if requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_FrameOptions should be set to null
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_FrameOptionsIsNull)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_FrameOptions = null;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_FrameOptions != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig.FrameOptions = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_FrameOptions;
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfigIsNull = false;
            }
            Amazon.CloudFront.Model.ResponseHeadersPolicyReferrerPolicy requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ReferrerPolicy = null;
            
             // populate ReferrerPolicy
            var requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ReferrerPolicyIsNull = true;
            requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ReferrerPolicy = new Amazon.CloudFront.Model.ResponseHeadersPolicyReferrerPolicy();
            System.Boolean? requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ReferrerPolicy_referrerPolicy_Override = null;
            if (cmdletContext.ReferrerPolicy_Override != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ReferrerPolicy_referrerPolicy_Override = cmdletContext.ReferrerPolicy_Override.Value;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ReferrerPolicy_referrerPolicy_Override != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ReferrerPolicy.Override = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ReferrerPolicy_referrerPolicy_Override.Value;
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ReferrerPolicyIsNull = false;
            }
            Amazon.CloudFront.ReferrerPolicyList requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ReferrerPolicy_referrerPolicy_ReferrerPolicy = null;
            if (cmdletContext.ReferrerPolicy_ReferrerPolicy != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ReferrerPolicy_referrerPolicy_ReferrerPolicy = cmdletContext.ReferrerPolicy_ReferrerPolicy;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ReferrerPolicy_referrerPolicy_ReferrerPolicy != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ReferrerPolicy.ReferrerPolicy = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ReferrerPolicy_referrerPolicy_ReferrerPolicy;
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ReferrerPolicyIsNull = false;
            }
             // determine if requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ReferrerPolicy should be set to null
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ReferrerPolicyIsNull)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ReferrerPolicy = null;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ReferrerPolicy != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig.ReferrerPolicy = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_ReferrerPolicy;
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfigIsNull = false;
            }
            Amazon.CloudFront.Model.ResponseHeadersPolicyStrictTransportSecurity requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_StrictTransportSecurity = null;
            
             // populate StrictTransportSecurity
            var requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_StrictTransportSecurityIsNull = true;
            requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_StrictTransportSecurity = new Amazon.CloudFront.Model.ResponseHeadersPolicyStrictTransportSecurity();
            System.Int32? requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_StrictTransportSecurity_strictTransportSecurity_AccessControlMaxAgeSec = null;
            if (cmdletContext.StrictTransportSecurity_AccessControlMaxAgeSec != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_StrictTransportSecurity_strictTransportSecurity_AccessControlMaxAgeSec = cmdletContext.StrictTransportSecurity_AccessControlMaxAgeSec.Value;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_StrictTransportSecurity_strictTransportSecurity_AccessControlMaxAgeSec != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_StrictTransportSecurity.AccessControlMaxAgeSec = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_StrictTransportSecurity_strictTransportSecurity_AccessControlMaxAgeSec.Value;
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_StrictTransportSecurityIsNull = false;
            }
            System.Boolean? requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_StrictTransportSecurity_strictTransportSecurity_IncludeSubdomain = null;
            if (cmdletContext.StrictTransportSecurity_IncludeSubdomain != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_StrictTransportSecurity_strictTransportSecurity_IncludeSubdomain = cmdletContext.StrictTransportSecurity_IncludeSubdomain.Value;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_StrictTransportSecurity_strictTransportSecurity_IncludeSubdomain != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_StrictTransportSecurity.IncludeSubdomains = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_StrictTransportSecurity_strictTransportSecurity_IncludeSubdomain.Value;
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_StrictTransportSecurityIsNull = false;
            }
            System.Boolean? requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_StrictTransportSecurity_strictTransportSecurity_Override = null;
            if (cmdletContext.StrictTransportSecurity_Override != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_StrictTransportSecurity_strictTransportSecurity_Override = cmdletContext.StrictTransportSecurity_Override.Value;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_StrictTransportSecurity_strictTransportSecurity_Override != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_StrictTransportSecurity.Override = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_StrictTransportSecurity_strictTransportSecurity_Override.Value;
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_StrictTransportSecurityIsNull = false;
            }
            System.Boolean? requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_StrictTransportSecurity_strictTransportSecurity_Preload = null;
            if (cmdletContext.StrictTransportSecurity_Preload != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_StrictTransportSecurity_strictTransportSecurity_Preload = cmdletContext.StrictTransportSecurity_Preload.Value;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_StrictTransportSecurity_strictTransportSecurity_Preload != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_StrictTransportSecurity.Preload = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_StrictTransportSecurity_strictTransportSecurity_Preload.Value;
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_StrictTransportSecurityIsNull = false;
            }
             // determine if requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_StrictTransportSecurity should be set to null
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_StrictTransportSecurityIsNull)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_StrictTransportSecurity = null;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_StrictTransportSecurity != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig.StrictTransportSecurity = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_StrictTransportSecurity;
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfigIsNull = false;
            }
            Amazon.CloudFront.Model.ResponseHeadersPolicyXSSProtection requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_XSSProtection = null;
            
             // populate XSSProtection
            var requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_XSSProtectionIsNull = true;
            requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_XSSProtection = new Amazon.CloudFront.Model.ResponseHeadersPolicyXSSProtection();
            System.Boolean? requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_XSSProtection_xSSProtection_ModeBlock = null;
            if (cmdletContext.XSSProtection_ModeBlock != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_XSSProtection_xSSProtection_ModeBlock = cmdletContext.XSSProtection_ModeBlock.Value;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_XSSProtection_xSSProtection_ModeBlock != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_XSSProtection.ModeBlock = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_XSSProtection_xSSProtection_ModeBlock.Value;
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_XSSProtectionIsNull = false;
            }
            System.Boolean? requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_XSSProtection_xSSProtection_Override = null;
            if (cmdletContext.XSSProtection_Override != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_XSSProtection_xSSProtection_Override = cmdletContext.XSSProtection_Override.Value;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_XSSProtection_xSSProtection_Override != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_XSSProtection.Override = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_XSSProtection_xSSProtection_Override.Value;
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_XSSProtectionIsNull = false;
            }
            System.Boolean? requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_XSSProtection_xSSProtection_Protection = null;
            if (cmdletContext.XSSProtection_Protection != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_XSSProtection_xSSProtection_Protection = cmdletContext.XSSProtection_Protection.Value;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_XSSProtection_xSSProtection_Protection != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_XSSProtection.Protection = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_XSSProtection_xSSProtection_Protection.Value;
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_XSSProtectionIsNull = false;
            }
            System.String requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_XSSProtection_xSSProtection_ReportUri = null;
            if (cmdletContext.XSSProtection_ReportUri != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_XSSProtection_xSSProtection_ReportUri = cmdletContext.XSSProtection_ReportUri;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_XSSProtection_xSSProtection_ReportUri != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_XSSProtection.ReportUri = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_XSSProtection_xSSProtection_ReportUri;
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_XSSProtectionIsNull = false;
            }
             // determine if requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_XSSProtection should be set to null
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_XSSProtectionIsNull)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_XSSProtection = null;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_XSSProtection != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig.XSSProtection = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_responseHeadersPolicyConfig_SecurityHeadersConfig_XSSProtection;
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfigIsNull = false;
            }
             // determine if requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig should be set to null
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfigIsNull)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig = null;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig != null)
            {
                request.ResponseHeadersPolicyConfig.SecurityHeadersConfig = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_SecurityHeadersConfig;
                requestResponseHeadersPolicyConfigIsNull = false;
            }
            Amazon.CloudFront.Model.ResponseHeadersPolicyCorsConfig requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig = null;
            
             // populate CorsConfig
            var requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfigIsNull = true;
            requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig = new Amazon.CloudFront.Model.ResponseHeadersPolicyCorsConfig();
            System.Boolean? requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_corsConfig_AccessControlAllowCredential = null;
            if (cmdletContext.CorsConfig_AccessControlAllowCredential != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_corsConfig_AccessControlAllowCredential = cmdletContext.CorsConfig_AccessControlAllowCredential.Value;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_corsConfig_AccessControlAllowCredential != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig.AccessControlAllowCredentials = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_corsConfig_AccessControlAllowCredential.Value;
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfigIsNull = false;
            }
            System.Int32? requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_corsConfig_AccessControlMaxAgeSec = null;
            if (cmdletContext.CorsConfig_AccessControlMaxAgeSec != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_corsConfig_AccessControlMaxAgeSec = cmdletContext.CorsConfig_AccessControlMaxAgeSec.Value;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_corsConfig_AccessControlMaxAgeSec != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig.AccessControlMaxAgeSec = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_corsConfig_AccessControlMaxAgeSec.Value;
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfigIsNull = false;
            }
            System.Boolean? requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_corsConfig_OriginOverride = null;
            if (cmdletContext.CorsConfig_OriginOverride != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_corsConfig_OriginOverride = cmdletContext.CorsConfig_OriginOverride.Value;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_corsConfig_OriginOverride != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig.OriginOverride = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_corsConfig_OriginOverride.Value;
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfigIsNull = false;
            }
            Amazon.CloudFront.Model.ResponseHeadersPolicyAccessControlAllowHeaders requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowHeaders = null;
            
             // populate AccessControlAllowHeaders
            var requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowHeadersIsNull = true;
            requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowHeaders = new Amazon.CloudFront.Model.ResponseHeadersPolicyAccessControlAllowHeaders();
            List<System.String> requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowHeaders_accessControlAllowHeaders_Item = null;
            if (cmdletContext.AccessControlAllowHeaders_Item != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowHeaders_accessControlAllowHeaders_Item = cmdletContext.AccessControlAllowHeaders_Item;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowHeaders_accessControlAllowHeaders_Item != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowHeaders.Items = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowHeaders_accessControlAllowHeaders_Item;
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowHeadersIsNull = false;
            }
            System.Int32? requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowHeaders_accessControlAllowHeaders_Quantity = null;
            if (cmdletContext.AccessControlAllowHeaders_Quantity != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowHeaders_accessControlAllowHeaders_Quantity = cmdletContext.AccessControlAllowHeaders_Quantity.Value;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowHeaders_accessControlAllowHeaders_Quantity != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowHeaders.Quantity = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowHeaders_accessControlAllowHeaders_Quantity.Value;
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowHeadersIsNull = false;
            }
             // determine if requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowHeaders should be set to null
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowHeadersIsNull)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowHeaders = null;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowHeaders != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig.AccessControlAllowHeaders = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowHeaders;
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfigIsNull = false;
            }
            Amazon.CloudFront.Model.ResponseHeadersPolicyAccessControlAllowMethods requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowMethods = null;
            
             // populate AccessControlAllowMethods
            var requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowMethodsIsNull = true;
            requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowMethods = new Amazon.CloudFront.Model.ResponseHeadersPolicyAccessControlAllowMethods();
            List<System.String> requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowMethods_accessControlAllowMethods_Item = null;
            if (cmdletContext.AccessControlAllowMethods_Item != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowMethods_accessControlAllowMethods_Item = cmdletContext.AccessControlAllowMethods_Item;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowMethods_accessControlAllowMethods_Item != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowMethods.Items = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowMethods_accessControlAllowMethods_Item;
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowMethodsIsNull = false;
            }
            System.Int32? requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowMethods_accessControlAllowMethods_Quantity = null;
            if (cmdletContext.AccessControlAllowMethods_Quantity != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowMethods_accessControlAllowMethods_Quantity = cmdletContext.AccessControlAllowMethods_Quantity.Value;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowMethods_accessControlAllowMethods_Quantity != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowMethods.Quantity = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowMethods_accessControlAllowMethods_Quantity.Value;
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowMethodsIsNull = false;
            }
             // determine if requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowMethods should be set to null
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowMethodsIsNull)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowMethods = null;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowMethods != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig.AccessControlAllowMethods = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowMethods;
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfigIsNull = false;
            }
            Amazon.CloudFront.Model.ResponseHeadersPolicyAccessControlAllowOrigins requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowOrigins = null;
            
             // populate AccessControlAllowOrigins
            var requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowOriginsIsNull = true;
            requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowOrigins = new Amazon.CloudFront.Model.ResponseHeadersPolicyAccessControlAllowOrigins();
            List<System.String> requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowOrigins_accessControlAllowOrigins_Item = null;
            if (cmdletContext.AccessControlAllowOrigins_Item != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowOrigins_accessControlAllowOrigins_Item = cmdletContext.AccessControlAllowOrigins_Item;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowOrigins_accessControlAllowOrigins_Item != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowOrigins.Items = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowOrigins_accessControlAllowOrigins_Item;
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowOriginsIsNull = false;
            }
            System.Int32? requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowOrigins_accessControlAllowOrigins_Quantity = null;
            if (cmdletContext.AccessControlAllowOrigins_Quantity != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowOrigins_accessControlAllowOrigins_Quantity = cmdletContext.AccessControlAllowOrigins_Quantity.Value;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowOrigins_accessControlAllowOrigins_Quantity != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowOrigins.Quantity = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowOrigins_accessControlAllowOrigins_Quantity.Value;
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowOriginsIsNull = false;
            }
             // determine if requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowOrigins should be set to null
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowOriginsIsNull)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowOrigins = null;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowOrigins != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig.AccessControlAllowOrigins = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlAllowOrigins;
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfigIsNull = false;
            }
            Amazon.CloudFront.Model.ResponseHeadersPolicyAccessControlExposeHeaders requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlExposeHeaders = null;
            
             // populate AccessControlExposeHeaders
            var requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlExposeHeadersIsNull = true;
            requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlExposeHeaders = new Amazon.CloudFront.Model.ResponseHeadersPolicyAccessControlExposeHeaders();
            List<System.String> requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlExposeHeaders_accessControlExposeHeaders_Item = null;
            if (cmdletContext.AccessControlExposeHeaders_Item != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlExposeHeaders_accessControlExposeHeaders_Item = cmdletContext.AccessControlExposeHeaders_Item;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlExposeHeaders_accessControlExposeHeaders_Item != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlExposeHeaders.Items = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlExposeHeaders_accessControlExposeHeaders_Item;
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlExposeHeadersIsNull = false;
            }
            System.Int32? requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlExposeHeaders_accessControlExposeHeaders_Quantity = null;
            if (cmdletContext.AccessControlExposeHeaders_Quantity != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlExposeHeaders_accessControlExposeHeaders_Quantity = cmdletContext.AccessControlExposeHeaders_Quantity.Value;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlExposeHeaders_accessControlExposeHeaders_Quantity != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlExposeHeaders.Quantity = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlExposeHeaders_accessControlExposeHeaders_Quantity.Value;
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlExposeHeadersIsNull = false;
            }
             // determine if requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlExposeHeaders should be set to null
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlExposeHeadersIsNull)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlExposeHeaders = null;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlExposeHeaders != null)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig.AccessControlExposeHeaders = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig_responseHeadersPolicyConfig_CorsConfig_AccessControlExposeHeaders;
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfigIsNull = false;
            }
             // determine if requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig should be set to null
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfigIsNull)
            {
                requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig = null;
            }
            if (requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig != null)
            {
                request.ResponseHeadersPolicyConfig.CorsConfig = requestResponseHeadersPolicyConfig_responseHeadersPolicyConfig_CorsConfig;
                requestResponseHeadersPolicyConfigIsNull = false;
            }
             // determine if request.ResponseHeadersPolicyConfig should be set to null
            if (requestResponseHeadersPolicyConfigIsNull)
            {
                request.ResponseHeadersPolicyConfig = null;
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
        
        private Amazon.CloudFront.Model.CreateResponseHeadersPolicyResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.CreateResponseHeadersPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "CreateResponseHeadersPolicy");
            try
            {
                #if DESKTOP
                return client.CreateResponseHeadersPolicy(request);
                #elif CORECLR
                return client.CreateResponseHeadersPolicyAsync(request).GetAwaiter().GetResult();
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
            public System.String ResponseHeadersPolicyConfig_Comment { get; set; }
            public System.Boolean? CorsConfig_AccessControlAllowCredential { get; set; }
            public List<System.String> AccessControlAllowHeaders_Item { get; set; }
            public System.Int32? AccessControlAllowHeaders_Quantity { get; set; }
            public List<System.String> AccessControlAllowMethods_Item { get; set; }
            public System.Int32? AccessControlAllowMethods_Quantity { get; set; }
            public List<System.String> AccessControlAllowOrigins_Item { get; set; }
            public System.Int32? AccessControlAllowOrigins_Quantity { get; set; }
            public List<System.String> AccessControlExposeHeaders_Item { get; set; }
            public System.Int32? AccessControlExposeHeaders_Quantity { get; set; }
            public System.Int32? CorsConfig_AccessControlMaxAgeSec { get; set; }
            public System.Boolean? CorsConfig_OriginOverride { get; set; }
            public List<Amazon.CloudFront.Model.ResponseHeadersPolicyCustomHeader> CustomHeadersConfig_Item { get; set; }
            public System.Int32? CustomHeadersConfig_Quantity { get; set; }
            public System.String ResponseHeadersPolicyConfig_Name { get; set; }
            public List<Amazon.CloudFront.Model.ResponseHeadersPolicyRemoveHeader> RemoveHeadersConfig_Item { get; set; }
            public System.Int32? RemoveHeadersConfig_Quantity { get; set; }
            public System.String ContentSecurityPolicy_ContentSecurityPolicy { get; set; }
            public System.Boolean? ContentSecurityPolicy_Override { get; set; }
            public System.Boolean? ContentTypeOptions_Override { get; set; }
            public Amazon.CloudFront.FrameOptionsList FrameOptions_FrameOption { get; set; }
            public System.Boolean? FrameOptions_Override { get; set; }
            public System.Boolean? ReferrerPolicy_Override { get; set; }
            public Amazon.CloudFront.ReferrerPolicyList ReferrerPolicy_ReferrerPolicy { get; set; }
            public System.Int32? StrictTransportSecurity_AccessControlMaxAgeSec { get; set; }
            public System.Boolean? StrictTransportSecurity_IncludeSubdomain { get; set; }
            public System.Boolean? StrictTransportSecurity_Override { get; set; }
            public System.Boolean? StrictTransportSecurity_Preload { get; set; }
            public System.Boolean? XSSProtection_ModeBlock { get; set; }
            public System.Boolean? XSSProtection_Override { get; set; }
            public System.Boolean? XSSProtection_Protection { get; set; }
            public System.String XSSProtection_ReportUri { get; set; }
            public System.Boolean? ServerTimingHeadersConfig_Enabled { get; set; }
            public System.Double? ServerTimingHeadersConfig_SamplingRate { get; set; }
            public System.Func<Amazon.CloudFront.Model.CreateResponseHeadersPolicyResponse, NewCFResponseHeadersPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
