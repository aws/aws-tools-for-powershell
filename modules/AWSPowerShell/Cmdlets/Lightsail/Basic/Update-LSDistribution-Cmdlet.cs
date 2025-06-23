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
using System.Threading;
using Amazon.Lightsail;
using Amazon.Lightsail.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LS
{
    /// <summary>
    /// Updates an existing Amazon Lightsail content delivery network (CDN) distribution.
    /// 
    ///  
    /// <para>
    /// Use this action to update the configuration of your existing distribution.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "LSDistribution", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lightsail.Model.Operation")]
    [AWSCmdlet("Calls the Amazon Lightsail UpdateDistribution API operation.", Operation = new[] {"UpdateDistribution"}, SelectReturnType = typeof(Amazon.Lightsail.Model.UpdateDistributionResponse))]
    [AWSCmdletOutput("Amazon.Lightsail.Model.Operation or Amazon.Lightsail.Model.UpdateDistributionResponse",
        "This cmdlet returns an Amazon.Lightsail.Model.Operation object.",
        "The service call response (type Amazon.Lightsail.Model.UpdateDistributionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateLSDistributionCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CacheBehaviorSettings_AllowedHTTPMethod
        /// <summary>
        /// <para>
        /// <para>The HTTP methods that are processed and forwarded to the distribution's origin.</para><para>You can specify the following options:</para><ul><li><para><c>GET,HEAD</c> - The distribution forwards the <c>GET</c> and <c>HEAD</c> methods.</para></li><li><para><c>GET,HEAD,OPTIONS</c> - The distribution forwards the <c>GET</c>, <c>HEAD</c>,
        /// and <c>OPTIONS</c> methods.</para></li><li><para><c>GET,HEAD,OPTIONS,PUT,PATCH,POST,DELETE</c> - The distribution forwards the <c>GET</c>,
        /// <c>HEAD</c>, <c>OPTIONS</c>, <c>PUT</c>, <c>PATCH</c>, <c>POST</c>, and <c>DELETE</c>
        /// methods.</para></li></ul><para>If you specify the third option, you might need to restrict access to your distribution's
        /// origin so users can't perform operations that you don't want them to. For example,
        /// you might not want users to have permission to delete objects from your origin.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CacheBehaviorSettings_AllowedHTTPMethods")]
        public System.String CacheBehaviorSettings_AllowedHTTPMethod { get; set; }
        #endregion
        
        #region Parameter DefaultCacheBehavior_Behavior
        /// <summary>
        /// <para>
        /// <para>The cache behavior of the distribution.</para><para>The following cache behaviors can be specified:</para><ul><li><para><b><c>cache</c></b> - This option is best for static sites. When specified, your
        /// distribution caches and serves your entire website as static content. This behavior
        /// is ideal for websites with static content that doesn't change depending on who views
        /// it, or for websites that don't use cookies, headers, or query strings to personalize
        /// content.</para></li><li><para><b><c>dont-cache</c></b> - This option is best for sites that serve a mix of static
        /// and dynamic content. When specified, your distribution caches and serve only the content
        /// that is specified in the distribution's <c>CacheBehaviorPerPath</c> parameter. This
        /// behavior is ideal for websites or web applications that use cookies, headers, and
        /// query strings to personalize content for individual users.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Lightsail.BehaviorEnum")]
        public Amazon.Lightsail.BehaviorEnum DefaultCacheBehavior_Behavior { get; set; }
        #endregion
        
        #region Parameter CacheBehavior
        /// <summary>
        /// <para>
        /// <para>An array of objects that describe the per-path cache behavior for the distribution.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CacheBehaviors")]
        public Amazon.Lightsail.Model.CacheBehaviorPerPath[] CacheBehavior { get; set; }
        #endregion
        
        #region Parameter CacheBehaviorSettings_CachedHTTPMethod
        /// <summary>
        /// <para>
        /// <para>The HTTP method responses that are cached by your distribution.</para><para>You can specify the following options:</para><ul><li><para><c>GET,HEAD</c> - The distribution caches responses to the <c>GET</c> and <c>HEAD</c>
        /// methods.</para></li><li><para><c>GET,HEAD,OPTIONS</c> - The distribution caches responses to the <c>GET</c>, <c>HEAD</c>,
        /// and <c>OPTIONS</c> methods.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CacheBehaviorSettings_CachedHTTPMethods")]
        public System.String CacheBehaviorSettings_CachedHTTPMethod { get; set; }
        #endregion
        
        #region Parameter CertificateName
        /// <summary>
        /// <para>
        /// <para>The name of the SSL/TLS certificate that you want to attach to the distribution.</para><para>Only certificates with a status of <c>ISSUED</c> can be attached to a distribution.</para><para>Use the <a href="https://docs.aws.amazon.com/lightsail/2016-11-28/api-reference/API_GetCertificates.html">GetCertificates</a>
        /// action to get a list of certificate names that you can specify.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CertificateName { get; set; }
        #endregion
        
        #region Parameter ForwardedCookies_CookiesAllowList
        /// <summary>
        /// <para>
        /// <para>The specific cookies to forward to your distribution's origin.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CacheBehaviorSettings_ForwardedCookies_CookiesAllowList")]
        public System.String[] ForwardedCookies_CookiesAllowList { get; set; }
        #endregion
        
        #region Parameter CacheBehaviorSettings_DefaultTTL
        /// <summary>
        /// <para>
        /// <para>The default amount of time that objects stay in the distribution's cache before the
        /// distribution forwards another request to the origin to determine whether the content
        /// has been updated.</para><note><para>The value specified applies only when the origin does not add HTTP headers such as
        /// <c>Cache-Control max-age</c>, <c>Cache-Control s-maxage</c>, and <c>Expires</c> to
        /// objects.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? CacheBehaviorSettings_DefaultTTL { get; set; }
        #endregion
        
        #region Parameter DistributionName
        /// <summary>
        /// <para>
        /// <para>The name of the distribution to update.</para><para>Use the <c>GetDistributions</c> action to get a list of distribution names that you
        /// can specify.</para>
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
        public System.String DistributionName { get; set; }
        #endregion
        
        #region Parameter ForwardedHeaders_HeadersAllowList
        /// <summary>
        /// <para>
        /// <para>The specific headers to forward to your distribution's origin.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CacheBehaviorSettings_ForwardedHeaders_HeadersAllowList")]
        public System.String[] ForwardedHeaders_HeadersAllowList { get; set; }
        #endregion
        
        #region Parameter IsEnabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether to enable the distribution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IsEnabled { get; set; }
        #endregion
        
        #region Parameter CacheBehaviorSettings_MaximumTTL
        /// <summary>
        /// <para>
        /// <para>The maximum amount of time that objects stay in the distribution's cache before the
        /// distribution forwards another request to the origin to determine whether the object
        /// has been updated.</para><para>The value specified applies only when the origin adds HTTP headers such as <c>Cache-Control
        /// max-age</c>, <c>Cache-Control s-maxage</c>, and <c>Expires</c> to objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? CacheBehaviorSettings_MaximumTTL { get; set; }
        #endregion
        
        #region Parameter CacheBehaviorSettings_MinimumTTL
        /// <summary>
        /// <para>
        /// <para>The minimum amount of time that objects stay in the distribution's cache before the
        /// distribution forwards another request to the origin to determine whether the object
        /// has been updated.</para><para>A value of <c>0</c> must be specified for <c>minimumTTL</c> if the distribution is
        /// configured to forward all headers to the origin.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? CacheBehaviorSettings_MinimumTTL { get; set; }
        #endregion
        
        #region Parameter Origin_Name
        /// <summary>
        /// <para>
        /// <para>The name of the origin resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Origin_Name { get; set; }
        #endregion
        
        #region Parameter ForwardedCookies_Option
        /// <summary>
        /// <para>
        /// <para>Specifies which cookies to forward to the distribution's origin for a cache behavior:
        /// <c>all</c>, <c>none</c>, or <c>allow-list</c> to forward only the cookies specified
        /// in the <c>cookiesAllowList</c> parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CacheBehaviorSettings_ForwardedCookies_Option")]
        [AWSConstantClassSource("Amazon.Lightsail.ForwardValues")]
        public Amazon.Lightsail.ForwardValues ForwardedCookies_Option { get; set; }
        #endregion
        
        #region Parameter ForwardedHeaders_Option
        /// <summary>
        /// <para>
        /// <para>The headers that you want your distribution to forward to your origin and base caching
        /// on.</para><para>You can configure your distribution to do one of the following:</para><ul><li><para><b><c>all</c></b> - Forward all headers to your origin.</para></li><li><para><b><c>none</c></b> - Forward only the default headers.</para></li><li><para><b><c>allow-list</c></b> - Forward only the headers you specify using the <c>headersAllowList</c>
        /// parameter.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CacheBehaviorSettings_ForwardedHeaders_Option")]
        [AWSConstantClassSource("Amazon.Lightsail.ForwardValues")]
        public Amazon.Lightsail.ForwardValues ForwardedHeaders_Option { get; set; }
        #endregion
        
        #region Parameter ForwardedQueryStrings_Option
        /// <summary>
        /// <para>
        /// <para>Indicates whether the distribution forwards and caches based on query strings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CacheBehaviorSettings_ForwardedQueryStrings_Option")]
        public System.Boolean? ForwardedQueryStrings_Option { get; set; }
        #endregion
        
        #region Parameter Origin_ProtocolPolicy
        /// <summary>
        /// <para>
        /// <para>The protocol that your Amazon Lightsail distribution uses when establishing a connection
        /// with your origin to pull content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Lightsail.OriginProtocolPolicyEnum")]
        public Amazon.Lightsail.OriginProtocolPolicyEnum Origin_ProtocolPolicy { get; set; }
        #endregion
        
        #region Parameter ForwardedQueryStrings_QueryStringsAllowList
        /// <summary>
        /// <para>
        /// <para>The specific query strings that the distribution forwards to the origin.</para><para>Your distribution will cache content based on the specified query strings.</para><para>If the <c>option</c> parameter is true, then your distribution forwards all query
        /// strings, regardless of what you specify using the <c>queryStringsAllowList</c> parameter.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CacheBehaviorSettings_ForwardedQueryStrings_QueryStringsAllowList")]
        public System.String[] ForwardedQueryStrings_QueryStringsAllowList { get; set; }
        #endregion
        
        #region Parameter Origin_RegionName
        /// <summary>
        /// <para>
        /// <para>The AWS Region name of the origin resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Lightsail.RegionName")]
        public Amazon.Lightsail.RegionName Origin_RegionName { get; set; }
        #endregion
        
        #region Parameter Origin_ResponseTimeout
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, that the distribution waits for a response after forwarding
        /// a request to the origin. The minimum timeout is 1 second, the maximum is 60 seconds,
        /// and the default (if you don't specify otherwise) is 30 seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Origin_ResponseTimeout { get; set; }
        #endregion
        
        #region Parameter UseDefaultCertificate
        /// <summary>
        /// <para>
        /// <para>Indicates whether the default SSL/TLS certificate is attached to the distribution.
        /// The default value is <c>true</c>. When <c>true</c>, the distribution uses the default
        /// domain name such as <c>d111111abcdef8.cloudfront.net</c>.</para><para> Set this value to <c>false</c> to attach a new certificate to the distribution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? UseDefaultCertificate { get; set; }
        #endregion
        
        #region Parameter ViewerMinimumTlsProtocolVersion
        /// <summary>
        /// <para>
        /// <para>Use this parameter to update the minimum TLS protocol version for the SSL/TLS certificate
        /// that's attached to the distribution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Lightsail.ViewerMinimumTlsProtocolVersionEnum")]
        public Amazon.Lightsail.ViewerMinimumTlsProtocolVersionEnum ViewerMinimumTlsProtocolVersion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Operation'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lightsail.Model.UpdateDistributionResponse).
        /// Specifying the name of a property of type Amazon.Lightsail.Model.UpdateDistributionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Operation";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DistributionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LSDistribution (UpdateDistribution)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lightsail.Model.UpdateDistributionResponse, UpdateLSDistributionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.CacheBehavior != null)
            {
                context.CacheBehavior = new List<Amazon.Lightsail.Model.CacheBehaviorPerPath>(this.CacheBehavior);
            }
            context.CacheBehaviorSettings_AllowedHTTPMethod = this.CacheBehaviorSettings_AllowedHTTPMethod;
            context.CacheBehaviorSettings_CachedHTTPMethod = this.CacheBehaviorSettings_CachedHTTPMethod;
            context.CacheBehaviorSettings_DefaultTTL = this.CacheBehaviorSettings_DefaultTTL;
            if (this.ForwardedCookies_CookiesAllowList != null)
            {
                context.ForwardedCookies_CookiesAllowList = new List<System.String>(this.ForwardedCookies_CookiesAllowList);
            }
            context.ForwardedCookies_Option = this.ForwardedCookies_Option;
            if (this.ForwardedHeaders_HeadersAllowList != null)
            {
                context.ForwardedHeaders_HeadersAllowList = new List<System.String>(this.ForwardedHeaders_HeadersAllowList);
            }
            context.ForwardedHeaders_Option = this.ForwardedHeaders_Option;
            context.ForwardedQueryStrings_Option = this.ForwardedQueryStrings_Option;
            if (this.ForwardedQueryStrings_QueryStringsAllowList != null)
            {
                context.ForwardedQueryStrings_QueryStringsAllowList = new List<System.String>(this.ForwardedQueryStrings_QueryStringsAllowList);
            }
            context.CacheBehaviorSettings_MaximumTTL = this.CacheBehaviorSettings_MaximumTTL;
            context.CacheBehaviorSettings_MinimumTTL = this.CacheBehaviorSettings_MinimumTTL;
            context.CertificateName = this.CertificateName;
            context.DefaultCacheBehavior_Behavior = this.DefaultCacheBehavior_Behavior;
            context.DistributionName = this.DistributionName;
            #if MODULAR
            if (this.DistributionName == null && ParameterWasBound(nameof(this.DistributionName)))
            {
                WriteWarning("You are passing $null as a value for parameter DistributionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IsEnabled = this.IsEnabled;
            context.Origin_Name = this.Origin_Name;
            context.Origin_ProtocolPolicy = this.Origin_ProtocolPolicy;
            context.Origin_RegionName = this.Origin_RegionName;
            context.Origin_ResponseTimeout = this.Origin_ResponseTimeout;
            context.UseDefaultCertificate = this.UseDefaultCertificate;
            context.ViewerMinimumTlsProtocolVersion = this.ViewerMinimumTlsProtocolVersion;
            
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
            var request = new Amazon.Lightsail.Model.UpdateDistributionRequest();
            
            if (cmdletContext.CacheBehavior != null)
            {
                request.CacheBehaviors = cmdletContext.CacheBehavior;
            }
            
             // populate CacheBehaviorSettings
            var requestCacheBehaviorSettingsIsNull = true;
            request.CacheBehaviorSettings = new Amazon.Lightsail.Model.CacheSettings();
            System.String requestCacheBehaviorSettings_cacheBehaviorSettings_AllowedHTTPMethod = null;
            if (cmdletContext.CacheBehaviorSettings_AllowedHTTPMethod != null)
            {
                requestCacheBehaviorSettings_cacheBehaviorSettings_AllowedHTTPMethod = cmdletContext.CacheBehaviorSettings_AllowedHTTPMethod;
            }
            if (requestCacheBehaviorSettings_cacheBehaviorSettings_AllowedHTTPMethod != null)
            {
                request.CacheBehaviorSettings.AllowedHTTPMethods = requestCacheBehaviorSettings_cacheBehaviorSettings_AllowedHTTPMethod;
                requestCacheBehaviorSettingsIsNull = false;
            }
            System.String requestCacheBehaviorSettings_cacheBehaviorSettings_CachedHTTPMethod = null;
            if (cmdletContext.CacheBehaviorSettings_CachedHTTPMethod != null)
            {
                requestCacheBehaviorSettings_cacheBehaviorSettings_CachedHTTPMethod = cmdletContext.CacheBehaviorSettings_CachedHTTPMethod;
            }
            if (requestCacheBehaviorSettings_cacheBehaviorSettings_CachedHTTPMethod != null)
            {
                request.CacheBehaviorSettings.CachedHTTPMethods = requestCacheBehaviorSettings_cacheBehaviorSettings_CachedHTTPMethod;
                requestCacheBehaviorSettingsIsNull = false;
            }
            System.Int64? requestCacheBehaviorSettings_cacheBehaviorSettings_DefaultTTL = null;
            if (cmdletContext.CacheBehaviorSettings_DefaultTTL != null)
            {
                requestCacheBehaviorSettings_cacheBehaviorSettings_DefaultTTL = cmdletContext.CacheBehaviorSettings_DefaultTTL.Value;
            }
            if (requestCacheBehaviorSettings_cacheBehaviorSettings_DefaultTTL != null)
            {
                request.CacheBehaviorSettings.DefaultTTL = requestCacheBehaviorSettings_cacheBehaviorSettings_DefaultTTL.Value;
                requestCacheBehaviorSettingsIsNull = false;
            }
            System.Int64? requestCacheBehaviorSettings_cacheBehaviorSettings_MaximumTTL = null;
            if (cmdletContext.CacheBehaviorSettings_MaximumTTL != null)
            {
                requestCacheBehaviorSettings_cacheBehaviorSettings_MaximumTTL = cmdletContext.CacheBehaviorSettings_MaximumTTL.Value;
            }
            if (requestCacheBehaviorSettings_cacheBehaviorSettings_MaximumTTL != null)
            {
                request.CacheBehaviorSettings.MaximumTTL = requestCacheBehaviorSettings_cacheBehaviorSettings_MaximumTTL.Value;
                requestCacheBehaviorSettingsIsNull = false;
            }
            System.Int64? requestCacheBehaviorSettings_cacheBehaviorSettings_MinimumTTL = null;
            if (cmdletContext.CacheBehaviorSettings_MinimumTTL != null)
            {
                requestCacheBehaviorSettings_cacheBehaviorSettings_MinimumTTL = cmdletContext.CacheBehaviorSettings_MinimumTTL.Value;
            }
            if (requestCacheBehaviorSettings_cacheBehaviorSettings_MinimumTTL != null)
            {
                request.CacheBehaviorSettings.MinimumTTL = requestCacheBehaviorSettings_cacheBehaviorSettings_MinimumTTL.Value;
                requestCacheBehaviorSettingsIsNull = false;
            }
            Amazon.Lightsail.Model.CookieObject requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedCookies = null;
            
             // populate ForwardedCookies
            var requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedCookiesIsNull = true;
            requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedCookies = new Amazon.Lightsail.Model.CookieObject();
            List<System.String> requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedCookies_forwardedCookies_CookiesAllowList = null;
            if (cmdletContext.ForwardedCookies_CookiesAllowList != null)
            {
                requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedCookies_forwardedCookies_CookiesAllowList = cmdletContext.ForwardedCookies_CookiesAllowList;
            }
            if (requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedCookies_forwardedCookies_CookiesAllowList != null)
            {
                requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedCookies.CookiesAllowList = requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedCookies_forwardedCookies_CookiesAllowList;
                requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedCookiesIsNull = false;
            }
            Amazon.Lightsail.ForwardValues requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedCookies_forwardedCookies_Option = null;
            if (cmdletContext.ForwardedCookies_Option != null)
            {
                requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedCookies_forwardedCookies_Option = cmdletContext.ForwardedCookies_Option;
            }
            if (requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedCookies_forwardedCookies_Option != null)
            {
                requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedCookies.Option = requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedCookies_forwardedCookies_Option;
                requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedCookiesIsNull = false;
            }
             // determine if requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedCookies should be set to null
            if (requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedCookiesIsNull)
            {
                requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedCookies = null;
            }
            if (requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedCookies != null)
            {
                request.CacheBehaviorSettings.ForwardedCookies = requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedCookies;
                requestCacheBehaviorSettingsIsNull = false;
            }
            Amazon.Lightsail.Model.HeaderObject requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedHeaders = null;
            
             // populate ForwardedHeaders
            var requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedHeadersIsNull = true;
            requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedHeaders = new Amazon.Lightsail.Model.HeaderObject();
            List<System.String> requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedHeaders_forwardedHeaders_HeadersAllowList = null;
            if (cmdletContext.ForwardedHeaders_HeadersAllowList != null)
            {
                requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedHeaders_forwardedHeaders_HeadersAllowList = cmdletContext.ForwardedHeaders_HeadersAllowList;
            }
            if (requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedHeaders_forwardedHeaders_HeadersAllowList != null)
            {
                requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedHeaders.HeadersAllowList = requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedHeaders_forwardedHeaders_HeadersAllowList;
                requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedHeadersIsNull = false;
            }
            Amazon.Lightsail.ForwardValues requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedHeaders_forwardedHeaders_Option = null;
            if (cmdletContext.ForwardedHeaders_Option != null)
            {
                requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedHeaders_forwardedHeaders_Option = cmdletContext.ForwardedHeaders_Option;
            }
            if (requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedHeaders_forwardedHeaders_Option != null)
            {
                requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedHeaders.Option = requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedHeaders_forwardedHeaders_Option;
                requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedHeadersIsNull = false;
            }
             // determine if requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedHeaders should be set to null
            if (requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedHeadersIsNull)
            {
                requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedHeaders = null;
            }
            if (requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedHeaders != null)
            {
                request.CacheBehaviorSettings.ForwardedHeaders = requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedHeaders;
                requestCacheBehaviorSettingsIsNull = false;
            }
            Amazon.Lightsail.Model.QueryStringObject requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedQueryStrings = null;
            
             // populate ForwardedQueryStrings
            var requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedQueryStringsIsNull = true;
            requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedQueryStrings = new Amazon.Lightsail.Model.QueryStringObject();
            System.Boolean? requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedQueryStrings_forwardedQueryStrings_Option = null;
            if (cmdletContext.ForwardedQueryStrings_Option != null)
            {
                requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedQueryStrings_forwardedQueryStrings_Option = cmdletContext.ForwardedQueryStrings_Option.Value;
            }
            if (requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedQueryStrings_forwardedQueryStrings_Option != null)
            {
                requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedQueryStrings.Option = requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedQueryStrings_forwardedQueryStrings_Option.Value;
                requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedQueryStringsIsNull = false;
            }
            List<System.String> requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedQueryStrings_forwardedQueryStrings_QueryStringsAllowList = null;
            if (cmdletContext.ForwardedQueryStrings_QueryStringsAllowList != null)
            {
                requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedQueryStrings_forwardedQueryStrings_QueryStringsAllowList = cmdletContext.ForwardedQueryStrings_QueryStringsAllowList;
            }
            if (requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedQueryStrings_forwardedQueryStrings_QueryStringsAllowList != null)
            {
                requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedQueryStrings.QueryStringsAllowList = requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedQueryStrings_forwardedQueryStrings_QueryStringsAllowList;
                requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedQueryStringsIsNull = false;
            }
             // determine if requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedQueryStrings should be set to null
            if (requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedQueryStringsIsNull)
            {
                requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedQueryStrings = null;
            }
            if (requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedQueryStrings != null)
            {
                request.CacheBehaviorSettings.ForwardedQueryStrings = requestCacheBehaviorSettings_cacheBehaviorSettings_ForwardedQueryStrings;
                requestCacheBehaviorSettingsIsNull = false;
            }
             // determine if request.CacheBehaviorSettings should be set to null
            if (requestCacheBehaviorSettingsIsNull)
            {
                request.CacheBehaviorSettings = null;
            }
            if (cmdletContext.CertificateName != null)
            {
                request.CertificateName = cmdletContext.CertificateName;
            }
            
             // populate DefaultCacheBehavior
            var requestDefaultCacheBehaviorIsNull = true;
            request.DefaultCacheBehavior = new Amazon.Lightsail.Model.CacheBehavior();
            Amazon.Lightsail.BehaviorEnum requestDefaultCacheBehavior_defaultCacheBehavior_Behavior = null;
            if (cmdletContext.DefaultCacheBehavior_Behavior != null)
            {
                requestDefaultCacheBehavior_defaultCacheBehavior_Behavior = cmdletContext.DefaultCacheBehavior_Behavior;
            }
            if (requestDefaultCacheBehavior_defaultCacheBehavior_Behavior != null)
            {
                request.DefaultCacheBehavior.Behavior = requestDefaultCacheBehavior_defaultCacheBehavior_Behavior;
                requestDefaultCacheBehaviorIsNull = false;
            }
             // determine if request.DefaultCacheBehavior should be set to null
            if (requestDefaultCacheBehaviorIsNull)
            {
                request.DefaultCacheBehavior = null;
            }
            if (cmdletContext.DistributionName != null)
            {
                request.DistributionName = cmdletContext.DistributionName;
            }
            if (cmdletContext.IsEnabled != null)
            {
                request.IsEnabled = cmdletContext.IsEnabled.Value;
            }
            
             // populate Origin
            var requestOriginIsNull = true;
            request.Origin = new Amazon.Lightsail.Model.InputOrigin();
            System.String requestOrigin_origin_Name = null;
            if (cmdletContext.Origin_Name != null)
            {
                requestOrigin_origin_Name = cmdletContext.Origin_Name;
            }
            if (requestOrigin_origin_Name != null)
            {
                request.Origin.Name = requestOrigin_origin_Name;
                requestOriginIsNull = false;
            }
            Amazon.Lightsail.OriginProtocolPolicyEnum requestOrigin_origin_ProtocolPolicy = null;
            if (cmdletContext.Origin_ProtocolPolicy != null)
            {
                requestOrigin_origin_ProtocolPolicy = cmdletContext.Origin_ProtocolPolicy;
            }
            if (requestOrigin_origin_ProtocolPolicy != null)
            {
                request.Origin.ProtocolPolicy = requestOrigin_origin_ProtocolPolicy;
                requestOriginIsNull = false;
            }
            Amazon.Lightsail.RegionName requestOrigin_origin_RegionName = null;
            if (cmdletContext.Origin_RegionName != null)
            {
                requestOrigin_origin_RegionName = cmdletContext.Origin_RegionName;
            }
            if (requestOrigin_origin_RegionName != null)
            {
                request.Origin.RegionName = requestOrigin_origin_RegionName;
                requestOriginIsNull = false;
            }
            System.Int32? requestOrigin_origin_ResponseTimeout = null;
            if (cmdletContext.Origin_ResponseTimeout != null)
            {
                requestOrigin_origin_ResponseTimeout = cmdletContext.Origin_ResponseTimeout.Value;
            }
            if (requestOrigin_origin_ResponseTimeout != null)
            {
                request.Origin.ResponseTimeout = requestOrigin_origin_ResponseTimeout.Value;
                requestOriginIsNull = false;
            }
             // determine if request.Origin should be set to null
            if (requestOriginIsNull)
            {
                request.Origin = null;
            }
            if (cmdletContext.UseDefaultCertificate != null)
            {
                request.UseDefaultCertificate = cmdletContext.UseDefaultCertificate.Value;
            }
            if (cmdletContext.ViewerMinimumTlsProtocolVersion != null)
            {
                request.ViewerMinimumTlsProtocolVersion = cmdletContext.ViewerMinimumTlsProtocolVersion;
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
        
        private Amazon.Lightsail.Model.UpdateDistributionResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.UpdateDistributionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "UpdateDistribution");
            try
            {
                return client.UpdateDistributionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.Lightsail.Model.CacheBehaviorPerPath> CacheBehavior { get; set; }
            public System.String CacheBehaviorSettings_AllowedHTTPMethod { get; set; }
            public System.String CacheBehaviorSettings_CachedHTTPMethod { get; set; }
            public System.Int64? CacheBehaviorSettings_DefaultTTL { get; set; }
            public List<System.String> ForwardedCookies_CookiesAllowList { get; set; }
            public Amazon.Lightsail.ForwardValues ForwardedCookies_Option { get; set; }
            public List<System.String> ForwardedHeaders_HeadersAllowList { get; set; }
            public Amazon.Lightsail.ForwardValues ForwardedHeaders_Option { get; set; }
            public System.Boolean? ForwardedQueryStrings_Option { get; set; }
            public List<System.String> ForwardedQueryStrings_QueryStringsAllowList { get; set; }
            public System.Int64? CacheBehaviorSettings_MaximumTTL { get; set; }
            public System.Int64? CacheBehaviorSettings_MinimumTTL { get; set; }
            public System.String CertificateName { get; set; }
            public Amazon.Lightsail.BehaviorEnum DefaultCacheBehavior_Behavior { get; set; }
            public System.String DistributionName { get; set; }
            public System.Boolean? IsEnabled { get; set; }
            public System.String Origin_Name { get; set; }
            public Amazon.Lightsail.OriginProtocolPolicyEnum Origin_ProtocolPolicy { get; set; }
            public Amazon.Lightsail.RegionName Origin_RegionName { get; set; }
            public System.Int32? Origin_ResponseTimeout { get; set; }
            public System.Boolean? UseDefaultCertificate { get; set; }
            public Amazon.Lightsail.ViewerMinimumTlsProtocolVersionEnum ViewerMinimumTlsProtocolVersion { get; set; }
            public System.Func<Amazon.Lightsail.Model.UpdateDistributionResponse, UpdateLSDistributionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Operation;
        }
        
    }
}
