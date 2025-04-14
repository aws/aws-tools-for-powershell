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
using Amazon.WAFV2;
using Amazon.WAFV2.Model;

namespace Amazon.PowerShell.Cmdlets.WAF2
{
    /// <summary>
    /// Updates the specified <a>WebACL</a>. While updating a web ACL, WAF provides continuous
    /// coverage to the resources that you have associated with the web ACL. 
    /// 
    ///  <note><para>
    /// This operation completely replaces the mutable specifications that you already have
    /// for the web ACL with the ones that you provide to this call. 
    /// </para><para>
    /// To modify a web ACL, do the following: 
    /// </para><ol><li><para>
    /// Retrieve it by calling <a>GetWebACL</a></para></li><li><para>
    /// Update its settings as needed
    /// </para></li><li><para>
    /// Provide the complete web ACL specification to this call
    /// </para></li></ol></note><para>
    ///  A web ACL defines a collection of rules to use to inspect and control web requests.
    /// Each rule has a statement that defines what to look for in web requests and an action
    /// that WAF applies to requests that match the statement. In the web ACL, you assign
    /// a default action to take (allow, block) for any request that does not match any of
    /// the rules. The rules in a web ACL can be a combination of the types <a>Rule</a>, <a>RuleGroup</a>,
    /// and managed rule group. You can associate a web ACL with one or more Amazon Web Services
    /// resources to protect. The resource types include Amazon CloudFront distribution, Amazon
    /// API Gateway REST API, Application Load Balancer, AppSync GraphQL API, Amazon Cognito
    /// user pool, App Runner service, Amplify application, and Amazon Web Services Verified
    /// Access instance. 
    /// </para><para><b>Temporary inconsistencies during updates</b></para><para>
    /// When you create or change a web ACL or other WAF resources, the changes take a small
    /// amount of time to propagate to all areas where the resources are stored. The propagation
    /// time can be from a few seconds to a number of minutes. 
    /// </para><para>
    /// The following are examples of the temporary inconsistencies that you might notice
    /// during change propagation: 
    /// </para><ul><li><para>
    /// After you create a web ACL, if you try to associate it with a resource, you might
    /// get an exception indicating that the web ACL is unavailable. 
    /// </para></li><li><para>
    /// After you add a rule group to a web ACL, the new rule group rules might be in effect
    /// in one area where the web ACL is used and not in another.
    /// </para></li><li><para>
    /// After you change a rule action setting, you might see the old action in some places
    /// and the new action in others. 
    /// </para></li><li><para>
    /// After you add an IP address to an IP set that is in use in a blocking rule, the new
    /// address might be blocked in one area while still allowed in another.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Update", "WAF2WebACL", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS WAF V2 UpdateWebACL API operation.", Operation = new[] {"UpdateWebACL"}, SelectReturnType = typeof(Amazon.WAFV2.Model.UpdateWebACLResponse))]
    [AWSCmdletOutput("System.String or Amazon.WAFV2.Model.UpdateWebACLResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.WAFV2.Model.UpdateWebACLResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateWAF2WebACLCmdlet : AmazonWAFV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        /// <para>Indicates whether the associated resource sends metrics to Amazon CloudWatch. For
        /// the list of available metrics, see <a href="https://docs.aws.amazon.com/waf/latest/developerguide/monitoring-cloudwatch.html#waf-metrics">WAF
        /// Metrics</a> in the <i>WAF Developer Guide</i>.</para><para>For web ACLs, the metrics are for web requests that have the web ACL default action
        /// applied. WAF applies the default action to web requests that pass the inspection of
        /// all rules in the web ACL without being either allowed or blocked. For more information,
        /// see <a href="https://docs.aws.amazon.com/waf/latest/developerguide/web-acl-default-action.html">The
        /// web ACL default action</a> in the <i>WAF Developer Guide</i>.</para>
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
        
        #region Parameter DataProtectionConfig_DataProtection
        /// <summary>
        /// <para>
        /// <para>An array of data protection configurations for specific web request field types. This
        /// is defined for each web ACL. WAF applies the specified protection to all web requests
        /// that the web ACL inspects. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataProtectionConfig_DataProtections")]
        public Amazon.WAFV2.Model.DataProtection[] DataProtectionConfig_DataProtection { get; set; }
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
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the web ACL. This ID is returned in the responses to create
        /// and list commands. You provide it to operations like update and delete.</para>
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
        
        #region Parameter CaptchaConfig_ImmunityTimeProperty_ImmunityTime
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, that a <c>CAPTCHA</c> or challenge timestamp is considered
        /// valid by WAF. The default setting is 300. </para><para>For the Challenge action, the minimum setting is 300. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ImmunityTimeProperty_ImmunityTime")]
        public System.Int64? CaptchaConfig_ImmunityTimeProperty_ImmunityTime { get; set; }
        #endregion
        
        #region Parameter ChallengeConfig_ImmunityTimeProperty_ImmunityTime
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, that a <c>CAPTCHA</c> or challenge timestamp is considered
        /// valid by WAF. The default setting is 300. </para><para>For the Challenge action, the minimum setting is 300. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? ChallengeConfig_ImmunityTimeProperty_ImmunityTime { get; set; }
        #endregion
        
        #region Parameter LockToken
        /// <summary>
        /// <para>
        /// <para>A token used for optimistic locking. WAF returns a token to your <c>get</c> and <c>list</c>
        /// requests, to mark the state of the entity at the time of the request. To make changes
        /// to the entity associated with the token, you provide the token to operations like
        /// <c>update</c> and <c>delete</c>. WAF uses the token to ensure that no changes have
        /// been made to the entity since you last retrieved it. If a change has been made, the
        /// update fails with a <c>WAFOptimisticLockException</c>. If this happens, perform another
        /// <c>get</c>, and use the new token returned by that operation. </para>
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
        public System.String LockToken { get; set; }
        #endregion
        
        #region Parameter VisibilityConfig_MetricName
        /// <summary>
        /// <para>
        /// <para>A name of the Amazon CloudWatch metric dimension. The name can contain only the characters:
        /// A-Z, a-z, 0-9, - (hyphen), and _ (underscore). The name can be from one to 128 characters
        /// long. It can't contain whitespace or metric names that are reserved for WAF, for example
        /// <c>All</c> and <c>Default_Action</c>. </para>
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter AssociationConfig_RequestBody
        /// <summary>
        /// <para>
        /// <para>Customizes the maximum size of the request body that your protected CloudFront, API
        /// Gateway, Amazon Cognito, App Runner, and Verified Access resources forward to WAF
        /// for inspection. The default size is 16 KB (16,384 bytes). You can change the setting
        /// for any of the available resource types. </para><note><para>You are charged additional fees when your protected resources forward body sizes that
        /// are larger than the default. For more information, see <a href="http://aws.amazon.com/waf/pricing/">WAF
        /// Pricing</a>.</para></note><para>Example JSON: <c> { "API_GATEWAY": "KB_48", "APP_RUNNER_SERVICE": "KB_32" }</c></para><para>For Application Load Balancer and AppSync, the limit is fixed at 8 KB (8,192 bytes).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable AssociationConfig_RequestBody { get; set; }
        #endregion
        
        #region Parameter Rule
        /// <summary>
        /// <para>
        /// <para>The <a>Rule</a> statements used to identify the web requests that you want to manage.
        /// Each rule includes one top-level statement that WAF uses to identify matching web
        /// requests, and parameters that govern how WAF handles them. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rules")]
        public Amazon.WAFV2.Model.Rule[] Rule { get; set; }
        #endregion
        
        #region Parameter VisibilityConfig_SampledRequestsEnabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether WAF should store a sampling of the web requests that match the rules.
        /// You can view the sampled requests through the WAF console. </para><para>If you configure data protection for the web ACL, the protection applies to the web
        /// ACL's sampled web request data. </para><note><para>Request sampling doesn't provide a field redaction option, and any field redaction
        /// that you specify in your logging configuration doesn't affect sampling. You can only
        /// exclude fields from request sampling by disabling sampling in the web ACL visibility
        /// configuration or by configuring data protection for the web ACL.</para></note>
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
        /// <para>Specifies whether this is for a global resource type, such as a Amazon CloudFront
        /// distribution. For an Amplify application, use <c>CLOUDFRONT</c>.</para><para>To work with CloudFront, you must also specify the Region US East (N. Virginia) as
        /// follows: </para><ul><li><para>CLI - Specify the Region when you use the CloudFront scope: <c>--scope=CLOUDFRONT
        /// --region=us-east-1</c>. </para></li><li><para>API and SDKs - For all calls, use the Region endpoint us-east-1. </para></li></ul>
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
        
        #region Parameter TokenDomain
        /// <summary>
        /// <para>
        /// <para>Specifies the domains that WAF should accept in a web request token. This enables
        /// the use of tokens across multiple protected websites. When WAF provides a token, it
        /// uses the domain of the Amazon Web Services resource that the web ACL is protecting.
        /// If you don't specify a list of token domains, WAF accepts tokens only for the domain
        /// of the protected resource. With a token domain list, WAF accepts the resource's host
        /// domain plus all domains in the token domain list, including their prefixed subdomains.</para><para>Example JSON: <c>"TokenDomains": { "mywebsite.com", "myotherwebsite.com" }</c></para><para>Public suffixes aren't allowed. For example, you can't use <c>gov.au</c> or <c>co.uk</c>
        /// as token domains.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TokenDomains")]
        public System.String[] TokenDomain { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'NextLockToken'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WAFV2.Model.UpdateWebACLResponse).
        /// Specifying the name of a property of type Amazon.WAFV2.Model.UpdateWebACLResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "NextLockToken";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-WAF2WebACL (UpdateWebACL)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WAFV2.Model.UpdateWebACLResponse, UpdateWAF2WebACLCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AssociationConfig_RequestBody != null)
            {
                context.AssociationConfig_RequestBody = new Dictionary<System.String, Amazon.WAFV2.Model.RequestBodyAssociatedResourceTypeConfig>(StringComparer.Ordinal);
                foreach (var hashKey in this.AssociationConfig_RequestBody.Keys)
                {
                    context.AssociationConfig_RequestBody.Add((String)hashKey, (Amazon.WAFV2.Model.RequestBodyAssociatedResourceTypeConfig)(this.AssociationConfig_RequestBody[hashKey]));
                }
            }
            context.CaptchaConfig_ImmunityTimeProperty_ImmunityTime = this.CaptchaConfig_ImmunityTimeProperty_ImmunityTime;
            context.ChallengeConfig_ImmunityTimeProperty_ImmunityTime = this.ChallengeConfig_ImmunityTimeProperty_ImmunityTime;
            if (this.CustomResponseBody != null)
            {
                context.CustomResponseBody = new Dictionary<System.String, Amazon.WAFV2.Model.CustomResponseBody>(StringComparer.Ordinal);
                foreach (var hashKey in this.CustomResponseBody.Keys)
                {
                    context.CustomResponseBody.Add((String)hashKey, (Amazon.WAFV2.Model.CustomResponseBody)(this.CustomResponseBody[hashKey]));
                }
            }
            if (this.DataProtectionConfig_DataProtection != null)
            {
                context.DataProtectionConfig_DataProtection = new List<Amazon.WAFV2.Model.DataProtection>(this.DataProtectionConfig_DataProtection);
            }
            context.DefaultAction_Allow = this.DefaultAction_Allow;
            context.DefaultAction_Block = this.DefaultAction_Block;
            context.Description = this.Description;
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LockToken = this.LockToken;
            #if MODULAR
            if (this.LockToken == null && ParameterWasBound(nameof(this.LockToken)))
            {
                WriteWarning("You are passing $null as a value for parameter LockToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.WAFV2.Model.UpdateWebACLRequest();
            
            
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
            
             // populate DataProtectionConfig
            var requestDataProtectionConfigIsNull = true;
            request.DataProtectionConfig = new Amazon.WAFV2.Model.DataProtectionConfig();
            List<Amazon.WAFV2.Model.DataProtection> requestDataProtectionConfig_dataProtectionConfig_DataProtection = null;
            if (cmdletContext.DataProtectionConfig_DataProtection != null)
            {
                requestDataProtectionConfig_dataProtectionConfig_DataProtection = cmdletContext.DataProtectionConfig_DataProtection;
            }
            if (requestDataProtectionConfig_dataProtectionConfig_DataProtection != null)
            {
                request.DataProtectionConfig.DataProtections = requestDataProtectionConfig_dataProtectionConfig_DataProtection;
                requestDataProtectionConfigIsNull = false;
            }
             // determine if request.DataProtectionConfig should be set to null
            if (requestDataProtectionConfigIsNull)
            {
                request.DataProtectionConfig = null;
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
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.LockToken != null)
            {
                request.LockToken = cmdletContext.LockToken;
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
        
        private Amazon.WAFV2.Model.UpdateWebACLResponse CallAWSServiceOperation(IAmazonWAFV2 client, Amazon.WAFV2.Model.UpdateWebACLRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF V2", "UpdateWebACL");
            try
            {
                return client.UpdateWebACLAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.WAFV2.Model.DataProtection> DataProtectionConfig_DataProtection { get; set; }
            public Amazon.WAFV2.Model.AllowAction DefaultAction_Allow { get; set; }
            public Amazon.WAFV2.Model.BlockAction DefaultAction_Block { get; set; }
            public System.String Description { get; set; }
            public System.String Id { get; set; }
            public System.String LockToken { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.WAFV2.Model.Rule> Rule { get; set; }
            public Amazon.WAFV2.Scope Scope { get; set; }
            public List<System.String> TokenDomain { get; set; }
            public System.Boolean? VisibilityConfig_CloudWatchMetricsEnabled { get; set; }
            public System.String VisibilityConfig_MetricName { get; set; }
            public System.Boolean? VisibilityConfig_SampledRequestsEnabled { get; set; }
            public System.Func<Amazon.WAFV2.Model.UpdateWebACLResponse, UpdateWAF2WebACLCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.NextLockToken;
        }
        
    }
}
