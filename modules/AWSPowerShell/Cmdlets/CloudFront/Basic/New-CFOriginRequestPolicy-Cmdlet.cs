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
    /// Creates an origin request policy.
    /// 
    ///  
    /// <para>
    /// After you create an origin request policy, you can attach it to one or more cache
    /// behaviors. When it's attached to a cache behavior, the origin request policy determines
    /// the values that CloudFront includes in requests that it sends to the origin. Each
    /// request that CloudFront sends to the origin includes the following:
    /// </para><ul><li><para>
    /// The request body and the URL path (without the domain name) from the viewer request.
    /// </para></li><li><para>
    /// The headers that CloudFront automatically includes in every origin request, including
    /// <code>Host</code>, <code>User-Agent</code>, and <code>X-Amz-Cf-Id</code>.
    /// </para></li><li><para>
    /// All HTTP headers, cookies, and URL query strings that are specified in the cache policy
    /// or the origin request policy. These can include items from the viewer request and,
    /// in the case of headers, additional ones that are added by CloudFront.
    /// </para></li></ul><para>
    /// CloudFront sends a request when it can't find a valid object in its cache that matches
    /// the request. If you want to send values to the origin and also include them in the
    /// cache key, use <code>CachePolicy</code>.
    /// </para><para>
    /// For more information about origin request policies, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/controlling-origin-requests.html">Controlling
    /// origin requests</a> in the <i>Amazon CloudFront Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "CFOriginRequestPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudFront.Model.CreateOriginRequestPolicyResponse")]
    [AWSCmdlet("Calls the Amazon CloudFront CreateOriginRequestPolicy API operation.", Operation = new[] {"CreateOriginRequestPolicy"}, SelectReturnType = typeof(Amazon.CloudFront.Model.CreateOriginRequestPolicyResponse))]
    [AWSCmdletOutput("Amazon.CloudFront.Model.CreateOriginRequestPolicyResponse",
        "This cmdlet returns an Amazon.CloudFront.Model.CreateOriginRequestPolicyResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCFOriginRequestPolicyCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter OriginRequestPolicyConfig_Comment
        /// <summary>
        /// <para>
        /// <para>A comment to describe the origin request policy. The comment cannot be longer than
        /// 128 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OriginRequestPolicyConfig_Comment { get; set; }
        #endregion
        
        #region Parameter CookiesConfig_CookieBehavior
        /// <summary>
        /// <para>
        /// <para>Determines whether cookies in viewer requests are included in requests that CloudFront
        /// sends to the origin. Valid values are:</para><ul><li><para><code>none</code> – No cookies in viewer requests are included in requests that CloudFront
        /// sends to the origin. Even when this field is set to <code>none</code>, any cookies
        /// that are listed in a <code>CachePolicy</code><i>are</i> included in origin requests.</para></li><li><para><code>whitelist</code> – Only the cookies in viewer requests that are listed in the
        /// <code>CookieNames</code> type are included in requests that CloudFront sends to the
        /// origin.</para></li><li><para><code>all</code> – All cookies in viewer requests are included in requests that CloudFront
        /// sends to the origin.</para></li><li><para><code>allExcept</code> – All cookies in viewer requests are included in requests
        /// that CloudFront sends to the origin, <i><b>except</b></i> for those listed in the
        /// <code>CookieNames</code> type, which are not included.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("OriginRequestPolicyConfig_CookiesConfig_CookieBehavior")]
        [AWSConstantClassSource("Amazon.CloudFront.OriginRequestPolicyCookieBehavior")]
        public Amazon.CloudFront.OriginRequestPolicyCookieBehavior CookiesConfig_CookieBehavior { get; set; }
        #endregion
        
        #region Parameter HeadersConfig_HeaderBehavior
        /// <summary>
        /// <para>
        /// <para>Determines whether any HTTP headers are included in requests that CloudFront sends
        /// to the origin. Valid values are:</para><ul><li><para><code>none</code> – No HTTP headers in viewer requests are included in requests that
        /// CloudFront sends to the origin. Even when this field is set to <code>none</code>,
        /// any headers that are listed in a <code>CachePolicy</code><i>are</i> included in origin
        /// requests.</para></li><li><para><code>whitelist</code> – Only the HTTP headers that are listed in the <code>Headers</code>
        /// type are included in requests that CloudFront sends to the origin.</para></li><li><para><code>allViewer</code> – All HTTP headers in viewer requests are included in requests
        /// that CloudFront sends to the origin.</para></li><li><para><code>allViewerAndWhitelistCloudFront</code> – All HTTP headers in viewer requests
        /// and the additional CloudFront headers that are listed in the <code>Headers</code>
        /// type are included in requests that CloudFront sends to the origin. The additional
        /// headers are added by CloudFront.</para></li><li><para><code>allExcept</code> – All HTTP headers in viewer requests are included in requests
        /// that CloudFront sends to the origin, <i><b>except</b></i> for those listed in the
        /// <code>Headers</code> type, which are not included.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("OriginRequestPolicyConfig_HeadersConfig_HeaderBehavior")]
        [AWSConstantClassSource("Amazon.CloudFront.OriginRequestPolicyHeaderBehavior")]
        public Amazon.CloudFront.OriginRequestPolicyHeaderBehavior HeadersConfig_HeaderBehavior { get; set; }
        #endregion
        
        #region Parameter Cookies_Item
        /// <summary>
        /// <para>
        /// <para>A list of cookie names.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OriginRequestPolicyConfig_CookiesConfig_Cookies_Items")]
        public System.String[] Cookies_Item { get; set; }
        #endregion
        
        #region Parameter Headers_Item
        /// <summary>
        /// <para>
        /// <para>A list of HTTP header names.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OriginRequestPolicyConfig_HeadersConfig_Headers_Items")]
        public System.String[] Headers_Item { get; set; }
        #endregion
        
        #region Parameter QueryStrings_Item
        /// <summary>
        /// <para>
        /// <para>A list of query string names.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OriginRequestPolicyConfig_QueryStringsConfig_QueryStrings_Items")]
        public System.String[] QueryStrings_Item { get; set; }
        #endregion
        
        #region Parameter OriginRequestPolicyConfig_Name
        /// <summary>
        /// <para>
        /// <para>A unique name to identify the origin request policy.</para>
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
        public System.String OriginRequestPolicyConfig_Name { get; set; }
        #endregion
        
        #region Parameter Cookies_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of cookie names in the <code>Items</code> list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OriginRequestPolicyConfig_CookiesConfig_Cookies_Quantity")]
        public System.Int32? Cookies_Quantity { get; set; }
        #endregion
        
        #region Parameter Headers_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of header names in the <code>Items</code> list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OriginRequestPolicyConfig_HeadersConfig_Headers_Quantity")]
        public System.Int32? Headers_Quantity { get; set; }
        #endregion
        
        #region Parameter QueryStrings_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of query string names in the <code>Items</code> list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OriginRequestPolicyConfig_QueryStringsConfig_QueryStrings_Quantity")]
        public System.Int32? QueryStrings_Quantity { get; set; }
        #endregion
        
        #region Parameter QueryStringsConfig_QueryStringBehavior
        /// <summary>
        /// <para>
        /// <para>Determines whether any URL query strings in viewer requests are included in requests
        /// that CloudFront sends to the origin. Valid values are:</para><ul><li><para><code>none</code> – No query strings in viewer requests are included in requests
        /// that CloudFront sends to the origin. Even when this field is set to <code>none</code>,
        /// any query strings that are listed in a <code>CachePolicy</code><i>are</i> included
        /// in origin requests.</para></li><li><para><code>whitelist</code> – Only the query strings in viewer requests that are listed
        /// in the <code>QueryStringNames</code> type are included in requests that CloudFront
        /// sends to the origin.</para></li><li><para><code>all</code> – All query strings in viewer requests are included in requests
        /// that CloudFront sends to the origin.</para></li><li><para><code>allExcept</code> – All query strings in viewer requests are included in requests
        /// that CloudFront sends to the origin, <i><b>except</b></i> for those listed in the
        /// <code>QueryStringNames</code> type, which are not included.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("OriginRequestPolicyConfig_QueryStringsConfig_QueryStringBehavior")]
        [AWSConstantClassSource("Amazon.CloudFront.OriginRequestPolicyQueryStringBehavior")]
        public Amazon.CloudFront.OriginRequestPolicyQueryStringBehavior QueryStringsConfig_QueryStringBehavior { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFront.Model.CreateOriginRequestPolicyResponse).
        /// Specifying the name of a property of type Amazon.CloudFront.Model.CreateOriginRequestPolicyResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.OriginRequestPolicyConfig_Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CFOriginRequestPolicy (CreateOriginRequestPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFront.Model.CreateOriginRequestPolicyResponse, NewCFOriginRequestPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.OriginRequestPolicyConfig_Comment = this.OriginRequestPolicyConfig_Comment;
            context.CookiesConfig_CookieBehavior = this.CookiesConfig_CookieBehavior;
            #if MODULAR
            if (this.CookiesConfig_CookieBehavior == null && ParameterWasBound(nameof(this.CookiesConfig_CookieBehavior)))
            {
                WriteWarning("You are passing $null as a value for parameter CookiesConfig_CookieBehavior which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Cookies_Item != null)
            {
                context.Cookies_Item = new List<System.String>(this.Cookies_Item);
            }
            context.Cookies_Quantity = this.Cookies_Quantity;
            context.HeadersConfig_HeaderBehavior = this.HeadersConfig_HeaderBehavior;
            #if MODULAR
            if (this.HeadersConfig_HeaderBehavior == null && ParameterWasBound(nameof(this.HeadersConfig_HeaderBehavior)))
            {
                WriteWarning("You are passing $null as a value for parameter HeadersConfig_HeaderBehavior which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Headers_Item != null)
            {
                context.Headers_Item = new List<System.String>(this.Headers_Item);
            }
            context.Headers_Quantity = this.Headers_Quantity;
            context.OriginRequestPolicyConfig_Name = this.OriginRequestPolicyConfig_Name;
            #if MODULAR
            if (this.OriginRequestPolicyConfig_Name == null && ParameterWasBound(nameof(this.OriginRequestPolicyConfig_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter OriginRequestPolicyConfig_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.QueryStringsConfig_QueryStringBehavior = this.QueryStringsConfig_QueryStringBehavior;
            #if MODULAR
            if (this.QueryStringsConfig_QueryStringBehavior == null && ParameterWasBound(nameof(this.QueryStringsConfig_QueryStringBehavior)))
            {
                WriteWarning("You are passing $null as a value for parameter QueryStringsConfig_QueryStringBehavior which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.CloudFront.Model.CreateOriginRequestPolicyRequest();
            
            
             // populate OriginRequestPolicyConfig
            var requestOriginRequestPolicyConfigIsNull = true;
            request.OriginRequestPolicyConfig = new Amazon.CloudFront.Model.OriginRequestPolicyConfig();
            System.String requestOriginRequestPolicyConfig_originRequestPolicyConfig_Comment = null;
            if (cmdletContext.OriginRequestPolicyConfig_Comment != null)
            {
                requestOriginRequestPolicyConfig_originRequestPolicyConfig_Comment = cmdletContext.OriginRequestPolicyConfig_Comment;
            }
            if (requestOriginRequestPolicyConfig_originRequestPolicyConfig_Comment != null)
            {
                request.OriginRequestPolicyConfig.Comment = requestOriginRequestPolicyConfig_originRequestPolicyConfig_Comment;
                requestOriginRequestPolicyConfigIsNull = false;
            }
            System.String requestOriginRequestPolicyConfig_originRequestPolicyConfig_Name = null;
            if (cmdletContext.OriginRequestPolicyConfig_Name != null)
            {
                requestOriginRequestPolicyConfig_originRequestPolicyConfig_Name = cmdletContext.OriginRequestPolicyConfig_Name;
            }
            if (requestOriginRequestPolicyConfig_originRequestPolicyConfig_Name != null)
            {
                request.OriginRequestPolicyConfig.Name = requestOriginRequestPolicyConfig_originRequestPolicyConfig_Name;
                requestOriginRequestPolicyConfigIsNull = false;
            }
            Amazon.CloudFront.Model.OriginRequestPolicyCookiesConfig requestOriginRequestPolicyConfig_originRequestPolicyConfig_CookiesConfig = null;
            
             // populate CookiesConfig
            var requestOriginRequestPolicyConfig_originRequestPolicyConfig_CookiesConfigIsNull = true;
            requestOriginRequestPolicyConfig_originRequestPolicyConfig_CookiesConfig = new Amazon.CloudFront.Model.OriginRequestPolicyCookiesConfig();
            Amazon.CloudFront.OriginRequestPolicyCookieBehavior requestOriginRequestPolicyConfig_originRequestPolicyConfig_CookiesConfig_cookiesConfig_CookieBehavior = null;
            if (cmdletContext.CookiesConfig_CookieBehavior != null)
            {
                requestOriginRequestPolicyConfig_originRequestPolicyConfig_CookiesConfig_cookiesConfig_CookieBehavior = cmdletContext.CookiesConfig_CookieBehavior;
            }
            if (requestOriginRequestPolicyConfig_originRequestPolicyConfig_CookiesConfig_cookiesConfig_CookieBehavior != null)
            {
                requestOriginRequestPolicyConfig_originRequestPolicyConfig_CookiesConfig.CookieBehavior = requestOriginRequestPolicyConfig_originRequestPolicyConfig_CookiesConfig_cookiesConfig_CookieBehavior;
                requestOriginRequestPolicyConfig_originRequestPolicyConfig_CookiesConfigIsNull = false;
            }
            Amazon.CloudFront.Model.CookieNames requestOriginRequestPolicyConfig_originRequestPolicyConfig_CookiesConfig_originRequestPolicyConfig_CookiesConfig_Cookies = null;
            
             // populate Cookies
            var requestOriginRequestPolicyConfig_originRequestPolicyConfig_CookiesConfig_originRequestPolicyConfig_CookiesConfig_CookiesIsNull = true;
            requestOriginRequestPolicyConfig_originRequestPolicyConfig_CookiesConfig_originRequestPolicyConfig_CookiesConfig_Cookies = new Amazon.CloudFront.Model.CookieNames();
            List<System.String> requestOriginRequestPolicyConfig_originRequestPolicyConfig_CookiesConfig_originRequestPolicyConfig_CookiesConfig_Cookies_cookies_Item = null;
            if (cmdletContext.Cookies_Item != null)
            {
                requestOriginRequestPolicyConfig_originRequestPolicyConfig_CookiesConfig_originRequestPolicyConfig_CookiesConfig_Cookies_cookies_Item = cmdletContext.Cookies_Item;
            }
            if (requestOriginRequestPolicyConfig_originRequestPolicyConfig_CookiesConfig_originRequestPolicyConfig_CookiesConfig_Cookies_cookies_Item != null)
            {
                requestOriginRequestPolicyConfig_originRequestPolicyConfig_CookiesConfig_originRequestPolicyConfig_CookiesConfig_Cookies.Items = requestOriginRequestPolicyConfig_originRequestPolicyConfig_CookiesConfig_originRequestPolicyConfig_CookiesConfig_Cookies_cookies_Item;
                requestOriginRequestPolicyConfig_originRequestPolicyConfig_CookiesConfig_originRequestPolicyConfig_CookiesConfig_CookiesIsNull = false;
            }
            System.Int32? requestOriginRequestPolicyConfig_originRequestPolicyConfig_CookiesConfig_originRequestPolicyConfig_CookiesConfig_Cookies_cookies_Quantity = null;
            if (cmdletContext.Cookies_Quantity != null)
            {
                requestOriginRequestPolicyConfig_originRequestPolicyConfig_CookiesConfig_originRequestPolicyConfig_CookiesConfig_Cookies_cookies_Quantity = cmdletContext.Cookies_Quantity.Value;
            }
            if (requestOriginRequestPolicyConfig_originRequestPolicyConfig_CookiesConfig_originRequestPolicyConfig_CookiesConfig_Cookies_cookies_Quantity != null)
            {
                requestOriginRequestPolicyConfig_originRequestPolicyConfig_CookiesConfig_originRequestPolicyConfig_CookiesConfig_Cookies.Quantity = requestOriginRequestPolicyConfig_originRequestPolicyConfig_CookiesConfig_originRequestPolicyConfig_CookiesConfig_Cookies_cookies_Quantity.Value;
                requestOriginRequestPolicyConfig_originRequestPolicyConfig_CookiesConfig_originRequestPolicyConfig_CookiesConfig_CookiesIsNull = false;
            }
             // determine if requestOriginRequestPolicyConfig_originRequestPolicyConfig_CookiesConfig_originRequestPolicyConfig_CookiesConfig_Cookies should be set to null
            if (requestOriginRequestPolicyConfig_originRequestPolicyConfig_CookiesConfig_originRequestPolicyConfig_CookiesConfig_CookiesIsNull)
            {
                requestOriginRequestPolicyConfig_originRequestPolicyConfig_CookiesConfig_originRequestPolicyConfig_CookiesConfig_Cookies = null;
            }
            if (requestOriginRequestPolicyConfig_originRequestPolicyConfig_CookiesConfig_originRequestPolicyConfig_CookiesConfig_Cookies != null)
            {
                requestOriginRequestPolicyConfig_originRequestPolicyConfig_CookiesConfig.Cookies = requestOriginRequestPolicyConfig_originRequestPolicyConfig_CookiesConfig_originRequestPolicyConfig_CookiesConfig_Cookies;
                requestOriginRequestPolicyConfig_originRequestPolicyConfig_CookiesConfigIsNull = false;
            }
             // determine if requestOriginRequestPolicyConfig_originRequestPolicyConfig_CookiesConfig should be set to null
            if (requestOriginRequestPolicyConfig_originRequestPolicyConfig_CookiesConfigIsNull)
            {
                requestOriginRequestPolicyConfig_originRequestPolicyConfig_CookiesConfig = null;
            }
            if (requestOriginRequestPolicyConfig_originRequestPolicyConfig_CookiesConfig != null)
            {
                request.OriginRequestPolicyConfig.CookiesConfig = requestOriginRequestPolicyConfig_originRequestPolicyConfig_CookiesConfig;
                requestOriginRequestPolicyConfigIsNull = false;
            }
            Amazon.CloudFront.Model.OriginRequestPolicyHeadersConfig requestOriginRequestPolicyConfig_originRequestPolicyConfig_HeadersConfig = null;
            
             // populate HeadersConfig
            var requestOriginRequestPolicyConfig_originRequestPolicyConfig_HeadersConfigIsNull = true;
            requestOriginRequestPolicyConfig_originRequestPolicyConfig_HeadersConfig = new Amazon.CloudFront.Model.OriginRequestPolicyHeadersConfig();
            Amazon.CloudFront.OriginRequestPolicyHeaderBehavior requestOriginRequestPolicyConfig_originRequestPolicyConfig_HeadersConfig_headersConfig_HeaderBehavior = null;
            if (cmdletContext.HeadersConfig_HeaderBehavior != null)
            {
                requestOriginRequestPolicyConfig_originRequestPolicyConfig_HeadersConfig_headersConfig_HeaderBehavior = cmdletContext.HeadersConfig_HeaderBehavior;
            }
            if (requestOriginRequestPolicyConfig_originRequestPolicyConfig_HeadersConfig_headersConfig_HeaderBehavior != null)
            {
                requestOriginRequestPolicyConfig_originRequestPolicyConfig_HeadersConfig.HeaderBehavior = requestOriginRequestPolicyConfig_originRequestPolicyConfig_HeadersConfig_headersConfig_HeaderBehavior;
                requestOriginRequestPolicyConfig_originRequestPolicyConfig_HeadersConfigIsNull = false;
            }
            Amazon.CloudFront.Model.Headers requestOriginRequestPolicyConfig_originRequestPolicyConfig_HeadersConfig_originRequestPolicyConfig_HeadersConfig_Headers = null;
            
             // populate Headers
            var requestOriginRequestPolicyConfig_originRequestPolicyConfig_HeadersConfig_originRequestPolicyConfig_HeadersConfig_HeadersIsNull = true;
            requestOriginRequestPolicyConfig_originRequestPolicyConfig_HeadersConfig_originRequestPolicyConfig_HeadersConfig_Headers = new Amazon.CloudFront.Model.Headers();
            List<System.String> requestOriginRequestPolicyConfig_originRequestPolicyConfig_HeadersConfig_originRequestPolicyConfig_HeadersConfig_Headers_headers_Item = null;
            if (cmdletContext.Headers_Item != null)
            {
                requestOriginRequestPolicyConfig_originRequestPolicyConfig_HeadersConfig_originRequestPolicyConfig_HeadersConfig_Headers_headers_Item = cmdletContext.Headers_Item;
            }
            if (requestOriginRequestPolicyConfig_originRequestPolicyConfig_HeadersConfig_originRequestPolicyConfig_HeadersConfig_Headers_headers_Item != null)
            {
                requestOriginRequestPolicyConfig_originRequestPolicyConfig_HeadersConfig_originRequestPolicyConfig_HeadersConfig_Headers.Items = requestOriginRequestPolicyConfig_originRequestPolicyConfig_HeadersConfig_originRequestPolicyConfig_HeadersConfig_Headers_headers_Item;
                requestOriginRequestPolicyConfig_originRequestPolicyConfig_HeadersConfig_originRequestPolicyConfig_HeadersConfig_HeadersIsNull = false;
            }
            System.Int32? requestOriginRequestPolicyConfig_originRequestPolicyConfig_HeadersConfig_originRequestPolicyConfig_HeadersConfig_Headers_headers_Quantity = null;
            if (cmdletContext.Headers_Quantity != null)
            {
                requestOriginRequestPolicyConfig_originRequestPolicyConfig_HeadersConfig_originRequestPolicyConfig_HeadersConfig_Headers_headers_Quantity = cmdletContext.Headers_Quantity.Value;
            }
            if (requestOriginRequestPolicyConfig_originRequestPolicyConfig_HeadersConfig_originRequestPolicyConfig_HeadersConfig_Headers_headers_Quantity != null)
            {
                requestOriginRequestPolicyConfig_originRequestPolicyConfig_HeadersConfig_originRequestPolicyConfig_HeadersConfig_Headers.Quantity = requestOriginRequestPolicyConfig_originRequestPolicyConfig_HeadersConfig_originRequestPolicyConfig_HeadersConfig_Headers_headers_Quantity.Value;
                requestOriginRequestPolicyConfig_originRequestPolicyConfig_HeadersConfig_originRequestPolicyConfig_HeadersConfig_HeadersIsNull = false;
            }
             // determine if requestOriginRequestPolicyConfig_originRequestPolicyConfig_HeadersConfig_originRequestPolicyConfig_HeadersConfig_Headers should be set to null
            if (requestOriginRequestPolicyConfig_originRequestPolicyConfig_HeadersConfig_originRequestPolicyConfig_HeadersConfig_HeadersIsNull)
            {
                requestOriginRequestPolicyConfig_originRequestPolicyConfig_HeadersConfig_originRequestPolicyConfig_HeadersConfig_Headers = null;
            }
            if (requestOriginRequestPolicyConfig_originRequestPolicyConfig_HeadersConfig_originRequestPolicyConfig_HeadersConfig_Headers != null)
            {
                requestOriginRequestPolicyConfig_originRequestPolicyConfig_HeadersConfig.Headers = requestOriginRequestPolicyConfig_originRequestPolicyConfig_HeadersConfig_originRequestPolicyConfig_HeadersConfig_Headers;
                requestOriginRequestPolicyConfig_originRequestPolicyConfig_HeadersConfigIsNull = false;
            }
             // determine if requestOriginRequestPolicyConfig_originRequestPolicyConfig_HeadersConfig should be set to null
            if (requestOriginRequestPolicyConfig_originRequestPolicyConfig_HeadersConfigIsNull)
            {
                requestOriginRequestPolicyConfig_originRequestPolicyConfig_HeadersConfig = null;
            }
            if (requestOriginRequestPolicyConfig_originRequestPolicyConfig_HeadersConfig != null)
            {
                request.OriginRequestPolicyConfig.HeadersConfig = requestOriginRequestPolicyConfig_originRequestPolicyConfig_HeadersConfig;
                requestOriginRequestPolicyConfigIsNull = false;
            }
            Amazon.CloudFront.Model.OriginRequestPolicyQueryStringsConfig requestOriginRequestPolicyConfig_originRequestPolicyConfig_QueryStringsConfig = null;
            
             // populate QueryStringsConfig
            var requestOriginRequestPolicyConfig_originRequestPolicyConfig_QueryStringsConfigIsNull = true;
            requestOriginRequestPolicyConfig_originRequestPolicyConfig_QueryStringsConfig = new Amazon.CloudFront.Model.OriginRequestPolicyQueryStringsConfig();
            Amazon.CloudFront.OriginRequestPolicyQueryStringBehavior requestOriginRequestPolicyConfig_originRequestPolicyConfig_QueryStringsConfig_queryStringsConfig_QueryStringBehavior = null;
            if (cmdletContext.QueryStringsConfig_QueryStringBehavior != null)
            {
                requestOriginRequestPolicyConfig_originRequestPolicyConfig_QueryStringsConfig_queryStringsConfig_QueryStringBehavior = cmdletContext.QueryStringsConfig_QueryStringBehavior;
            }
            if (requestOriginRequestPolicyConfig_originRequestPolicyConfig_QueryStringsConfig_queryStringsConfig_QueryStringBehavior != null)
            {
                requestOriginRequestPolicyConfig_originRequestPolicyConfig_QueryStringsConfig.QueryStringBehavior = requestOriginRequestPolicyConfig_originRequestPolicyConfig_QueryStringsConfig_queryStringsConfig_QueryStringBehavior;
                requestOriginRequestPolicyConfig_originRequestPolicyConfig_QueryStringsConfigIsNull = false;
            }
            Amazon.CloudFront.Model.QueryStringNames requestOriginRequestPolicyConfig_originRequestPolicyConfig_QueryStringsConfig_originRequestPolicyConfig_QueryStringsConfig_QueryStrings = null;
            
             // populate QueryStrings
            var requestOriginRequestPolicyConfig_originRequestPolicyConfig_QueryStringsConfig_originRequestPolicyConfig_QueryStringsConfig_QueryStringsIsNull = true;
            requestOriginRequestPolicyConfig_originRequestPolicyConfig_QueryStringsConfig_originRequestPolicyConfig_QueryStringsConfig_QueryStrings = new Amazon.CloudFront.Model.QueryStringNames();
            List<System.String> requestOriginRequestPolicyConfig_originRequestPolicyConfig_QueryStringsConfig_originRequestPolicyConfig_QueryStringsConfig_QueryStrings_queryStrings_Item = null;
            if (cmdletContext.QueryStrings_Item != null)
            {
                requestOriginRequestPolicyConfig_originRequestPolicyConfig_QueryStringsConfig_originRequestPolicyConfig_QueryStringsConfig_QueryStrings_queryStrings_Item = cmdletContext.QueryStrings_Item;
            }
            if (requestOriginRequestPolicyConfig_originRequestPolicyConfig_QueryStringsConfig_originRequestPolicyConfig_QueryStringsConfig_QueryStrings_queryStrings_Item != null)
            {
                requestOriginRequestPolicyConfig_originRequestPolicyConfig_QueryStringsConfig_originRequestPolicyConfig_QueryStringsConfig_QueryStrings.Items = requestOriginRequestPolicyConfig_originRequestPolicyConfig_QueryStringsConfig_originRequestPolicyConfig_QueryStringsConfig_QueryStrings_queryStrings_Item;
                requestOriginRequestPolicyConfig_originRequestPolicyConfig_QueryStringsConfig_originRequestPolicyConfig_QueryStringsConfig_QueryStringsIsNull = false;
            }
            System.Int32? requestOriginRequestPolicyConfig_originRequestPolicyConfig_QueryStringsConfig_originRequestPolicyConfig_QueryStringsConfig_QueryStrings_queryStrings_Quantity = null;
            if (cmdletContext.QueryStrings_Quantity != null)
            {
                requestOriginRequestPolicyConfig_originRequestPolicyConfig_QueryStringsConfig_originRequestPolicyConfig_QueryStringsConfig_QueryStrings_queryStrings_Quantity = cmdletContext.QueryStrings_Quantity.Value;
            }
            if (requestOriginRequestPolicyConfig_originRequestPolicyConfig_QueryStringsConfig_originRequestPolicyConfig_QueryStringsConfig_QueryStrings_queryStrings_Quantity != null)
            {
                requestOriginRequestPolicyConfig_originRequestPolicyConfig_QueryStringsConfig_originRequestPolicyConfig_QueryStringsConfig_QueryStrings.Quantity = requestOriginRequestPolicyConfig_originRequestPolicyConfig_QueryStringsConfig_originRequestPolicyConfig_QueryStringsConfig_QueryStrings_queryStrings_Quantity.Value;
                requestOriginRequestPolicyConfig_originRequestPolicyConfig_QueryStringsConfig_originRequestPolicyConfig_QueryStringsConfig_QueryStringsIsNull = false;
            }
             // determine if requestOriginRequestPolicyConfig_originRequestPolicyConfig_QueryStringsConfig_originRequestPolicyConfig_QueryStringsConfig_QueryStrings should be set to null
            if (requestOriginRequestPolicyConfig_originRequestPolicyConfig_QueryStringsConfig_originRequestPolicyConfig_QueryStringsConfig_QueryStringsIsNull)
            {
                requestOriginRequestPolicyConfig_originRequestPolicyConfig_QueryStringsConfig_originRequestPolicyConfig_QueryStringsConfig_QueryStrings = null;
            }
            if (requestOriginRequestPolicyConfig_originRequestPolicyConfig_QueryStringsConfig_originRequestPolicyConfig_QueryStringsConfig_QueryStrings != null)
            {
                requestOriginRequestPolicyConfig_originRequestPolicyConfig_QueryStringsConfig.QueryStrings = requestOriginRequestPolicyConfig_originRequestPolicyConfig_QueryStringsConfig_originRequestPolicyConfig_QueryStringsConfig_QueryStrings;
                requestOriginRequestPolicyConfig_originRequestPolicyConfig_QueryStringsConfigIsNull = false;
            }
             // determine if requestOriginRequestPolicyConfig_originRequestPolicyConfig_QueryStringsConfig should be set to null
            if (requestOriginRequestPolicyConfig_originRequestPolicyConfig_QueryStringsConfigIsNull)
            {
                requestOriginRequestPolicyConfig_originRequestPolicyConfig_QueryStringsConfig = null;
            }
            if (requestOriginRequestPolicyConfig_originRequestPolicyConfig_QueryStringsConfig != null)
            {
                request.OriginRequestPolicyConfig.QueryStringsConfig = requestOriginRequestPolicyConfig_originRequestPolicyConfig_QueryStringsConfig;
                requestOriginRequestPolicyConfigIsNull = false;
            }
             // determine if request.OriginRequestPolicyConfig should be set to null
            if (requestOriginRequestPolicyConfigIsNull)
            {
                request.OriginRequestPolicyConfig = null;
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
        
        private Amazon.CloudFront.Model.CreateOriginRequestPolicyResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.CreateOriginRequestPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "CreateOriginRequestPolicy");
            try
            {
                #if DESKTOP
                return client.CreateOriginRequestPolicy(request);
                #elif CORECLR
                return client.CreateOriginRequestPolicyAsync(request).GetAwaiter().GetResult();
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
            public System.String OriginRequestPolicyConfig_Comment { get; set; }
            public Amazon.CloudFront.OriginRequestPolicyCookieBehavior CookiesConfig_CookieBehavior { get; set; }
            public List<System.String> Cookies_Item { get; set; }
            public System.Int32? Cookies_Quantity { get; set; }
            public Amazon.CloudFront.OriginRequestPolicyHeaderBehavior HeadersConfig_HeaderBehavior { get; set; }
            public List<System.String> Headers_Item { get; set; }
            public System.Int32? Headers_Quantity { get; set; }
            public System.String OriginRequestPolicyConfig_Name { get; set; }
            public Amazon.CloudFront.OriginRequestPolicyQueryStringBehavior QueryStringsConfig_QueryStringBehavior { get; set; }
            public List<System.String> QueryStrings_Item { get; set; }
            public System.Int32? QueryStrings_Quantity { get; set; }
            public System.Func<Amazon.CloudFront.Model.CreateOriginRequestPolicyResponse, NewCFOriginRequestPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
