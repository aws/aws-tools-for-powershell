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
    /// Updates an origin request policy configuration.
    /// 
    ///  
    /// <para>
    /// When you update an origin request policy configuration, all the fields are updated
    /// with the values provided in the request. You cannot update some fields independent
    /// of others. To update an origin request policy configuration:
    /// </para><ol><li><para>
    /// Use <c>GetOriginRequestPolicyConfig</c> to get the current configuration.
    /// </para></li><li><para>
    /// Locally modify the fields in the origin request policy configuration that you want
    /// to update.
    /// </para></li><li><para>
    /// Call <c>UpdateOriginRequestPolicy</c> by providing the entire origin request policy
    /// configuration, including the fields that you modified and those that you didn't.
    /// </para></li></ol>
    /// </summary>
    [Cmdlet("Update", "CFOriginRequestPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudFront.Model.OriginRequestPolicy")]
    [AWSCmdlet("Calls the Amazon CloudFront UpdateOriginRequestPolicy API operation.", Operation = new[] {"UpdateOriginRequestPolicy"}, SelectReturnType = typeof(Amazon.CloudFront.Model.UpdateOriginRequestPolicyResponse))]
    [AWSCmdletOutput("Amazon.CloudFront.Model.OriginRequestPolicy or Amazon.CloudFront.Model.UpdateOriginRequestPolicyResponse",
        "This cmdlet returns an Amazon.CloudFront.Model.OriginRequestPolicy object.",
        "The service call response (type Amazon.CloudFront.Model.UpdateOriginRequestPolicyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCFOriginRequestPolicyCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
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
        /// sends to the origin. Valid values are:</para><ul><li><para><c>none</c> – No cookies in viewer requests are included in requests that CloudFront
        /// sends to the origin. Even when this field is set to <c>none</c>, any cookies that
        /// are listed in a <c>CachePolicy</c><i>are</i> included in origin requests.</para></li><li><para><c>whitelist</c> – Only the cookies in viewer requests that are listed in the <c>CookieNames</c>
        /// type are included in requests that CloudFront sends to the origin.</para></li><li><para><c>all</c> – All cookies in viewer requests are included in requests that CloudFront
        /// sends to the origin.</para></li><li><para><c>allExcept</c> – All cookies in viewer requests are included in requests that CloudFront
        /// sends to the origin, <i><b>except</b></i> for those listed in the <c>CookieNames</c>
        /// type, which are not included.</para></li></ul>
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
        /// to the origin. Valid values are:</para><ul><li><para><c>none</c> – No HTTP headers in viewer requests are included in requests that CloudFront
        /// sends to the origin. Even when this field is set to <c>none</c>, any headers that
        /// are listed in a <c>CachePolicy</c><i>are</i> included in origin requests.</para></li><li><para><c>whitelist</c> – Only the HTTP headers that are listed in the <c>Headers</c> type
        /// are included in requests that CloudFront sends to the origin.</para></li><li><para><c>allViewer</c> – All HTTP headers in viewer requests are included in requests that
        /// CloudFront sends to the origin.</para></li><li><para><c>allViewerAndWhitelistCloudFront</c> – All HTTP headers in viewer requests and
        /// the additional CloudFront headers that are listed in the <c>Headers</c> type are included
        /// in requests that CloudFront sends to the origin. The additional headers are added
        /// by CloudFront.</para></li><li><para><c>allExcept</c> – All HTTP headers in viewer requests are included in requests that
        /// CloudFront sends to the origin, <i><b>except</b></i> for those listed in the <c>Headers</c>
        /// type, which are not included.</para></li></ul>
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
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the origin request policy that you are updating. The identifier
        /// is returned in a cache behavior's <c>OriginRequestPolicyId</c> field in the response
        /// to <c>GetDistributionConfig</c>.</para>
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
        /// <para>The version of the origin request policy that you are updating. The version is returned
        /// in the origin request policy's <c>ETag</c> field in the response to <c>GetOriginRequestPolicyConfig</c>.</para>
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
        /// <para>The number of cookie names in the <c>Items</c> list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OriginRequestPolicyConfig_CookiesConfig_Cookies_Quantity")]
        public System.Int32? Cookies_Quantity { get; set; }
        #endregion
        
        #region Parameter Headers_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of header names in the <c>Items</c> list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OriginRequestPolicyConfig_HeadersConfig_Headers_Quantity")]
        public System.Int32? Headers_Quantity { get; set; }
        #endregion
        
        #region Parameter QueryStrings_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of query string names in the <c>Items</c> list.</para>
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
        /// that CloudFront sends to the origin. Valid values are:</para><ul><li><para><c>none</c> – No query strings in viewer requests are included in requests that CloudFront
        /// sends to the origin. Even when this field is set to <c>none</c>, any query strings
        /// that are listed in a <c>CachePolicy</c><i>are</i> included in origin requests.</para></li><li><para><c>whitelist</c> – Only the query strings in viewer requests that are listed in the
        /// <c>QueryStringNames</c> type are included in requests that CloudFront sends to the
        /// origin.</para></li><li><para><c>all</c> – All query strings in viewer requests are included in requests that CloudFront
        /// sends to the origin.</para></li><li><para><c>allExcept</c> – All query strings in viewer requests are included in requests
        /// that CloudFront sends to the origin, <i><b>except</b></i> for those listed in the
        /// <c>QueryStringNames</c> type, which are not included.</para></li></ul>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'OriginRequestPolicy'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFront.Model.UpdateOriginRequestPolicyResponse).
        /// Specifying the name of a property of type Amazon.CloudFront.Model.UpdateOriginRequestPolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "OriginRequestPolicy";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CFOriginRequestPolicy (UpdateOriginRequestPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFront.Model.UpdateOriginRequestPolicyResponse, UpdateCFOriginRequestPolicyCmdlet>(Select) ??
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
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IfMatch = this.IfMatch;
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
            var request = new Amazon.CloudFront.Model.UpdateOriginRequestPolicyRequest();
            
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.IfMatch != null)
            {
                request.IfMatch = cmdletContext.IfMatch;
            }
            
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
        
        private Amazon.CloudFront.Model.UpdateOriginRequestPolicyResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.UpdateOriginRequestPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "UpdateOriginRequestPolicy");
            try
            {
                #if DESKTOP
                return client.UpdateOriginRequestPolicy(request);
                #elif CORECLR
                return client.UpdateOriginRequestPolicyAsync(request).GetAwaiter().GetResult();
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
            public System.String Id { get; set; }
            public System.String IfMatch { get; set; }
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
            public System.Func<Amazon.CloudFront.Model.UpdateOriginRequestPolicyResponse, UpdateCFOriginRequestPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.OriginRequestPolicy;
        }
        
    }
}
