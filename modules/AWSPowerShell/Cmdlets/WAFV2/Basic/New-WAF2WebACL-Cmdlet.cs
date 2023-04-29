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
using Amazon.WAFV2;
using Amazon.WAFV2.Model;

namespace Amazon.PowerShell.Cmdlets.WAF2
{
    /// <summary>
    /// Creates a <a>WebACL</a> per the specifications provided.
    /// 
    ///  
    /// <para>
    ///  A web ACL defines a collection of rules to use to inspect and control web requests.
    /// Each rule has an action defined (allow, block, or count) for requests that match the
    /// statement of the rule. In the web ACL, you assign a default action to take (allow,
    /// block) for any request that does not match any of the rules. The rules in a web ACL
    /// can be a combination of the types <a>Rule</a>, <a>RuleGroup</a>, and managed rule
    /// group. You can associate a web ACL with one or more Amazon Web Services resources
    /// to protect. The resources can be an Amazon CloudFront distribution, an Amazon API
    /// Gateway REST API, an Application Load Balancer, an AppSync GraphQL API, an Amazon
    /// Cognito user pool, an App Runner service, or an Amazon Web Services Verified Access
    /// instance. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "WAF2WebACL", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.WAFV2.Model.WebACLSummary")]
    [AWSCmdlet("Calls the AWS WAF V2 CreateWebACL API operation.", Operation = new[] {"CreateWebACL"}, SelectReturnType = typeof(Amazon.WAFV2.Model.CreateWebACLResponse))]
    [AWSCmdletOutput("Amazon.WAFV2.Model.WebACLSummary or Amazon.WAFV2.Model.CreateWebACLResponse",
        "This cmdlet returns an Amazon.WAFV2.Model.WebACLSummary object.",
        "The service call response (type Amazon.WAFV2.Model.CreateWebACLResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewWAF2WebACLCmdlet : AmazonWAFV2ClientCmdlet, IExecutor
    {
        
        #region Parameter DefaultAction_Allow
        /// <summary>
        /// <para>
        /// <para>Specifies that WAF should allow requests by default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.WAFV2.Model.AllowAction DefaultAction_Allow { get; set; }
        #endregion
        
        #region Parameter DefaultAction_Block
        /// <summary>
        /// <para>
        /// <para>Specifies that WAF should block requests by default. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.WAFV2.Model.BlockAction DefaultAction_Block { get; set; }
        #endregion
        
        #region Parameter VisibilityConfig_CloudWatchMetricsEnabled
        /// <summary>
        /// <para>
        /// <para>A boolean indicating whether the associated resource sends metrics to Amazon CloudWatch.
        /// For the list of available metrics, see <a href="https://docs.aws.amazon.com/waf/latest/developerguide/monitoring-cloudwatch.html#waf-metrics">WAF
        /// Metrics</a> in the <i>WAF Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? VisibilityConfig_CloudWatchMetricsEnabled { get; set; }
        #endregion
        
        #region Parameter CustomResponseBody
        /// <summary>
        /// <para>
        /// <para>A map of custom response keys and content bodies. When you create a rule with a block
        /// action, you can send a custom response to the web request. You define these for the
        /// web ACL, and then use them in the rules and default actions that you define in the
        /// web ACL. </para><para>For information about customizing web requests and responses, see <a href="https://docs.aws.amazon.com/waf/latest/developerguide/waf-custom-request-response.html">Customizing
        /// web requests and responses in WAF</a> in the <i>WAF Developer Guide</i>. </para><para>For information about the limits on count and size for custom request and response
        /// settings, see <a href="https://docs.aws.amazon.com/waf/latest/developerguide/limits.html">WAF
        /// quotas</a> in the <i>WAF Developer Guide</i>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CustomResponseBodies")]
        public System.Collections.Hashtable CustomResponseBody { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the web ACL that helps with identification. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter CaptchaConfig_ImmunityTimeProperty_ImmunityTime
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, that a <code>CAPTCHA</code> or challenge timestamp
        /// is considered valid by WAF. The default setting is 300. </para><para>For the Challenge action, the minimum setting is 300. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ImmunityTimeProperty_ImmunityTime")]
        public System.Int64? CaptchaConfig_ImmunityTimeProperty_ImmunityTime { get; set; }
        #endregion
        
        #region Parameter ChallengeConfig_ImmunityTimeProperty_ImmunityTime
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, that a <code>CAPTCHA</code> or challenge timestamp
        /// is considered valid by WAF. The default setting is 300. </para><para>For the Challenge action, the minimum setting is 300. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? ChallengeConfig_ImmunityTimeProperty_ImmunityTime { get; set; }
        #endregion
        
        #region Parameter VisibilityConfig_MetricName
        /// <summary>
        /// <para>
        /// <para>A name of the Amazon CloudWatch metric dimension. The name can contain only the characters:
        /// A-Z, a-z, 0-9, - (hyphen), and _ (underscore). The name can be from one to 128 characters
        /// long. It can't contain whitespace or metric names that are reserved for WAF, for example
        /// <code>All</code> and <code>Default_Action</code>. </para>
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
        public System.String VisibilityConfig_MetricName { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the web ACL. You cannot change the name of a web ACL after you create
        /// it.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter AssociationConfig_RequestBody
        /// <summary>
        /// <para>
        /// <para>Customizes the maximum size of the request body that your protected CloudFront distributions
        /// forward to WAF for inspection. The default size is 16 KB (16,384 kilobytes). </para><note><para>You are charged additional fees when your protected resources forward body sizes that
        /// are larger than the default. For more information, see <a href="http://aws.amazon.com/waf/pricing/">WAF
        /// Pricing</a>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable AssociationConfig_RequestBody { get; set; }
        #endregion
        
        #region Parameter Rule
        /// <summary>
        /// <para>
        /// <para>The <a>Rule</a> statements used to identify the web requests that you want to allow,
        /// block, or count. Each rule includes one top-level statement that WAF uses to identify
        /// matching web requests, and parameters that govern how WAF handles them. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rules")]
        public Amazon.WAFV2.Model.Rule[] Rule { get; set; }
        #endregion
        
        #region Parameter VisibilityConfig_SampledRequestsEnabled
        /// <summary>
        /// <para>
        /// <para>A boolean indicating whether WAF should store a sampling of the web requests that
        /// match the rules. You can view the sampled requests through the WAF console. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? VisibilityConfig_SampledRequestsEnabled { get; set; }
        #endregion
        
        #region Parameter Scope
        /// <summary>
        /// <para>
        /// <para>Specifies whether this is for an Amazon CloudFront distribution or for a regional
        /// application. A regional application can be an Application Load Balancer (ALB), an
        /// Amazon API Gateway REST API, an AppSync GraphQL API, an Amazon Cognito user pool,
        /// an App Runner service, or an Amazon Web Services Verified Access instance. </para><para>To work with CloudFront, you must also specify the Region US East (N. Virginia) as
        /// follows: </para><ul><li><para>CLI - Specify the Region when you use the CloudFront scope: <code>--scope=CLOUDFRONT
        /// --region=us-east-1</code>. </para></li><li><para>API and SDKs - For all calls, use the Region endpoint us-east-1. </para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.WAFV2.Scope")]
        public Amazon.WAFV2.Scope Scope { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of key:value pairs to associate with the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.WAFV2.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TokenDomain
        /// <summary>
        /// <para>
        /// <para>Specifies the domains that WAF should accept in a web request token. This enables
        /// the use of tokens across multiple protected websites. When WAF provides a token, it
        /// uses the domain of the Amazon Web Services resource that the web ACL is protecting.
        /// If you don't specify a list of token domains, WAF accepts tokens only for the domain
        /// of the protected resource. With a token domain list, WAF accepts the resource's host
        /// domain plus all domains in the token domain list, including their prefixed subdomains.</para><para>Example JSON: <code>"TokenDomains": { "mywebsite.com", "myotherwebsite.com" }</code></para><para>Public suffixes aren't allowed. For example, you can't use <code>usa.gov</code> or
        /// <code>co.uk</code> as token domains.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TokenDomains")]
        public System.String[] TokenDomain { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Summary'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WAFV2.Model.CreateWebACLResponse).
        /// Specifying the name of a property of type Amazon.WAFV2.Model.CreateWebACLResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Summary";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-WAF2WebACL (CreateWebACL)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WAFV2.Model.CreateWebACLResponse, NewWAF2WebACLCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AssociationConfig_RequestBody != null)
            {
                context.AssociationConfig_RequestBody = new Dictionary<System.String, Amazon.WAFV2.Model.RequestBodyAssociatedResourceTypeConfig>(StringComparer.Ordinal);
                foreach (var hashKey in this.AssociationConfig_RequestBody.Keys)
                {
                    context.AssociationConfig_RequestBody.Add((String)hashKey, (RequestBodyAssociatedResourceTypeConfig)(this.AssociationConfig_RequestBody[hashKey]));
                }
            }
            context.CaptchaConfig_ImmunityTimeProperty_ImmunityTime = this.CaptchaConfig_ImmunityTimeProperty_ImmunityTime;
            context.ChallengeConfig_ImmunityTimeProperty_ImmunityTime = this.ChallengeConfig_ImmunityTimeProperty_ImmunityTime;
            if (this.CustomResponseBody != null)
            {
                context.CustomResponseBody = new Dictionary<System.String, Amazon.WAFV2.Model.CustomResponseBody>(StringComparer.Ordinal);
                foreach (var hashKey in this.CustomResponseBody.Keys)
                {
                    context.CustomResponseBody.Add((String)hashKey, (CustomResponseBody)(this.CustomResponseBody[hashKey]));
                }
            }
            context.DefaultAction_Allow = this.DefaultAction_Allow;
            context.DefaultAction_Block = this.DefaultAction_Block;
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Rule != null)
            {
                context.Rule = new List<Amazon.WAFV2.Model.Rule>(this.Rule);
            }
            context.Scope = this.Scope;
            #if MODULAR
            if (this.Scope == null && ParameterWasBound(nameof(this.Scope)))
            {
                WriteWarning("You are passing $null as a value for parameter Scope which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.WAFV2.Model.Tag>(this.Tag);
            }
            if (this.TokenDomain != null)
            {
                context.TokenDomain = new List<System.String>(this.TokenDomain);
            }
            context.VisibilityConfig_CloudWatchMetricsEnabled = this.VisibilityConfig_CloudWatchMetricsEnabled;
            #if MODULAR
            if (this.VisibilityConfig_CloudWatchMetricsEnabled == null && ParameterWasBound(nameof(this.VisibilityConfig_CloudWatchMetricsEnabled)))
            {
                WriteWarning("You are passing $null as a value for parameter VisibilityConfig_CloudWatchMetricsEnabled which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VisibilityConfig_MetricName = this.VisibilityConfig_MetricName;
            #if MODULAR
            if (this.VisibilityConfig_MetricName == null && ParameterWasBound(nameof(this.VisibilityConfig_MetricName)))
            {
                WriteWarning("You are passing $null as a value for parameter VisibilityConfig_MetricName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VisibilityConfig_SampledRequestsEnabled = this.VisibilityConfig_SampledRequestsEnabled;
            #if MODULAR
            if (this.VisibilityConfig_SampledRequestsEnabled == null && ParameterWasBound(nameof(this.VisibilityConfig_SampledRequestsEnabled)))
            {
                WriteWarning("You are passing $null as a value for parameter VisibilityConfig_SampledRequestsEnabled which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.WAFV2.Model.CreateWebACLRequest();
            
            
             // populate AssociationConfig
            var requestAssociationConfigIsNull = true;
            request.AssociationConfig = new Amazon.WAFV2.Model.AssociationConfig();
            Dictionary<System.String, Amazon.WAFV2.Model.RequestBodyAssociatedResourceTypeConfig> requestAssociationConfig_associationConfig_RequestBody = null;
            if (cmdletContext.AssociationConfig_RequestBody != null)
            {
                requestAssociationConfig_associationConfig_RequestBody = cmdletContext.AssociationConfig_RequestBody;
            }
            if (requestAssociationConfig_associationConfig_RequestBody != null)
            {
                request.AssociationConfig.RequestBody = requestAssociationConfig_associationConfig_RequestBody;
                requestAssociationConfigIsNull = false;
            }
             // determine if request.AssociationConfig should be set to null
            if (requestAssociationConfigIsNull)
            {
                request.AssociationConfig = null;
            }
            
             // populate CaptchaConfig
            var requestCaptchaConfigIsNull = true;
            request.CaptchaConfig = new Amazon.WAFV2.Model.CaptchaConfig();
            Amazon.WAFV2.Model.ImmunityTimeProperty requestCaptchaConfig_captchaConfig_ImmunityTimeProperty = null;
            
             // populate ImmunityTimeProperty
            var requestCaptchaConfig_captchaConfig_ImmunityTimePropertyIsNull = true;
            requestCaptchaConfig_captchaConfig_ImmunityTimeProperty = new Amazon.WAFV2.Model.ImmunityTimeProperty();
            System.Int64? requestCaptchaConfig_captchaConfig_ImmunityTimeProperty_captchaConfig_ImmunityTimeProperty_ImmunityTime = null;
            if (cmdletContext.CaptchaConfig_ImmunityTimeProperty_ImmunityTime != null)
            {
                requestCaptchaConfig_captchaConfig_ImmunityTimeProperty_captchaConfig_ImmunityTimeProperty_ImmunityTime = cmdletContext.CaptchaConfig_ImmunityTimeProperty_ImmunityTime.Value;
            }
            if (requestCaptchaConfig_captchaConfig_ImmunityTimeProperty_captchaConfig_ImmunityTimeProperty_ImmunityTime != null)
            {
                requestCaptchaConfig_captchaConfig_ImmunityTimeProperty.ImmunityTime = requestCaptchaConfig_captchaConfig_ImmunityTimeProperty_captchaConfig_ImmunityTimeProperty_ImmunityTime.Value;
                requestCaptchaConfig_captchaConfig_ImmunityTimePropertyIsNull = false;
            }
             // determine if requestCaptchaConfig_captchaConfig_ImmunityTimeProperty should be set to null
            if (requestCaptchaConfig_captchaConfig_ImmunityTimePropertyIsNull)
            {
                requestCaptchaConfig_captchaConfig_ImmunityTimeProperty = null;
            }
            if (requestCaptchaConfig_captchaConfig_ImmunityTimeProperty != null)
            {
                request.CaptchaConfig.ImmunityTimeProperty = requestCaptchaConfig_captchaConfig_ImmunityTimeProperty;
                requestCaptchaConfigIsNull = false;
            }
             // determine if request.CaptchaConfig should be set to null
            if (requestCaptchaConfigIsNull)
            {
                request.CaptchaConfig = null;
            }
            
             // populate ChallengeConfig
            var requestChallengeConfigIsNull = true;
            request.ChallengeConfig = new Amazon.WAFV2.Model.ChallengeConfig();
            Amazon.WAFV2.Model.ImmunityTimeProperty requestChallengeConfig_challengeConfig_ImmunityTimeProperty = null;
            
             // populate ImmunityTimeProperty
            var requestChallengeConfig_challengeConfig_ImmunityTimePropertyIsNull = true;
            requestChallengeConfig_challengeConfig_ImmunityTimeProperty = new Amazon.WAFV2.Model.ImmunityTimeProperty();
            System.Int64? requestChallengeConfig_challengeConfig_ImmunityTimeProperty_challengeConfig_ImmunityTimeProperty_ImmunityTime = null;
            if (cmdletContext.ChallengeConfig_ImmunityTimeProperty_ImmunityTime != null)
            {
                requestChallengeConfig_challengeConfig_ImmunityTimeProperty_challengeConfig_ImmunityTimeProperty_ImmunityTime = cmdletContext.ChallengeConfig_ImmunityTimeProperty_ImmunityTime.Value;
            }
            if (requestChallengeConfig_challengeConfig_ImmunityTimeProperty_challengeConfig_ImmunityTimeProperty_ImmunityTime != null)
            {
                requestChallengeConfig_challengeConfig_ImmunityTimeProperty.ImmunityTime = requestChallengeConfig_challengeConfig_ImmunityTimeProperty_challengeConfig_ImmunityTimeProperty_ImmunityTime.Value;
                requestChallengeConfig_challengeConfig_ImmunityTimePropertyIsNull = false;
            }
             // determine if requestChallengeConfig_challengeConfig_ImmunityTimeProperty should be set to null
            if (requestChallengeConfig_challengeConfig_ImmunityTimePropertyIsNull)
            {
                requestChallengeConfig_challengeConfig_ImmunityTimeProperty = null;
            }
            if (requestChallengeConfig_challengeConfig_ImmunityTimeProperty != null)
            {
                request.ChallengeConfig.ImmunityTimeProperty = requestChallengeConfig_challengeConfig_ImmunityTimeProperty;
                requestChallengeConfigIsNull = false;
            }
             // determine if request.ChallengeConfig should be set to null
            if (requestChallengeConfigIsNull)
            {
                request.ChallengeConfig = null;
            }
            if (cmdletContext.CustomResponseBody != null)
            {
                request.CustomResponseBodies = cmdletContext.CustomResponseBody;
            }
            
             // populate DefaultAction
            var requestDefaultActionIsNull = true;
            request.DefaultAction = new Amazon.WAFV2.Model.DefaultAction();
            Amazon.WAFV2.Model.AllowAction requestDefaultAction_defaultAction_Allow = null;
            if (cmdletContext.DefaultAction_Allow != null)
            {
                requestDefaultAction_defaultAction_Allow = cmdletContext.DefaultAction_Allow;
            }
            if (requestDefaultAction_defaultAction_Allow != null)
            {
                request.DefaultAction.Allow = requestDefaultAction_defaultAction_Allow;
                requestDefaultActionIsNull = false;
            }
            Amazon.WAFV2.Model.BlockAction requestDefaultAction_defaultAction_Block = null;
            if (cmdletContext.DefaultAction_Block != null)
            {
                requestDefaultAction_defaultAction_Block = cmdletContext.DefaultAction_Block;
            }
            if (requestDefaultAction_defaultAction_Block != null)
            {
                request.DefaultAction.Block = requestDefaultAction_defaultAction_Block;
                requestDefaultActionIsNull = false;
            }
             // determine if request.DefaultAction should be set to null
            if (requestDefaultActionIsNull)
            {
                request.DefaultAction = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Rule != null)
            {
                request.Rules = cmdletContext.Rule;
            }
            if (cmdletContext.Scope != null)
            {
                request.Scope = cmdletContext.Scope;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TokenDomain != null)
            {
                request.TokenDomains = cmdletContext.TokenDomain;
            }
            
             // populate VisibilityConfig
            var requestVisibilityConfigIsNull = true;
            request.VisibilityConfig = new Amazon.WAFV2.Model.VisibilityConfig();
            System.Boolean? requestVisibilityConfig_visibilityConfig_CloudWatchMetricsEnabled = null;
            if (cmdletContext.VisibilityConfig_CloudWatchMetricsEnabled != null)
            {
                requestVisibilityConfig_visibilityConfig_CloudWatchMetricsEnabled = cmdletContext.VisibilityConfig_CloudWatchMetricsEnabled.Value;
            }
            if (requestVisibilityConfig_visibilityConfig_CloudWatchMetricsEnabled != null)
            {
                request.VisibilityConfig.CloudWatchMetricsEnabled = requestVisibilityConfig_visibilityConfig_CloudWatchMetricsEnabled.Value;
                requestVisibilityConfigIsNull = false;
            }
            System.String requestVisibilityConfig_visibilityConfig_MetricName = null;
            if (cmdletContext.VisibilityConfig_MetricName != null)
            {
                requestVisibilityConfig_visibilityConfig_MetricName = cmdletContext.VisibilityConfig_MetricName;
            }
            if (requestVisibilityConfig_visibilityConfig_MetricName != null)
            {
                request.VisibilityConfig.MetricName = requestVisibilityConfig_visibilityConfig_MetricName;
                requestVisibilityConfigIsNull = false;
            }
            System.Boolean? requestVisibilityConfig_visibilityConfig_SampledRequestsEnabled = null;
            if (cmdletContext.VisibilityConfig_SampledRequestsEnabled != null)
            {
                requestVisibilityConfig_visibilityConfig_SampledRequestsEnabled = cmdletContext.VisibilityConfig_SampledRequestsEnabled.Value;
            }
            if (requestVisibilityConfig_visibilityConfig_SampledRequestsEnabled != null)
            {
                request.VisibilityConfig.SampledRequestsEnabled = requestVisibilityConfig_visibilityConfig_SampledRequestsEnabled.Value;
                requestVisibilityConfigIsNull = false;
            }
             // determine if request.VisibilityConfig should be set to null
            if (requestVisibilityConfigIsNull)
            {
                request.VisibilityConfig = null;
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
        
        private Amazon.WAFV2.Model.CreateWebACLResponse CallAWSServiceOperation(IAmazonWAFV2 client, Amazon.WAFV2.Model.CreateWebACLRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF V2", "CreateWebACL");
            try
            {
                #if DESKTOP
                return client.CreateWebACL(request);
                #elif CORECLR
                return client.CreateWebACLAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, Amazon.WAFV2.Model.RequestBodyAssociatedResourceTypeConfig> AssociationConfig_RequestBody { get; set; }
            public System.Int64? CaptchaConfig_ImmunityTimeProperty_ImmunityTime { get; set; }
            public System.Int64? ChallengeConfig_ImmunityTimeProperty_ImmunityTime { get; set; }
            public Dictionary<System.String, Amazon.WAFV2.Model.CustomResponseBody> CustomResponseBody { get; set; }
            public Amazon.WAFV2.Model.AllowAction DefaultAction_Allow { get; set; }
            public Amazon.WAFV2.Model.BlockAction DefaultAction_Block { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.WAFV2.Model.Rule> Rule { get; set; }
            public Amazon.WAFV2.Scope Scope { get; set; }
            public List<Amazon.WAFV2.Model.Tag> Tag { get; set; }
            public List<System.String> TokenDomain { get; set; }
            public System.Boolean? VisibilityConfig_CloudWatchMetricsEnabled { get; set; }
            public System.String VisibilityConfig_MetricName { get; set; }
            public System.Boolean? VisibilityConfig_SampledRequestsEnabled { get; set; }
            public System.Func<Amazon.WAFV2.Model.CreateWebACLResponse, NewWAF2WebACLCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Summary;
        }
        
    }
}
