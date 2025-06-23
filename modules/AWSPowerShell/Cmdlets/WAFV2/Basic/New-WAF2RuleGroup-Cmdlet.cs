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

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.WAF2
{
    /// <summary>
    /// Creates a <a>RuleGroup</a> per the specifications provided. 
    /// 
    ///  
    /// <para>
    ///  A rule group defines a collection of rules to inspect and control web requests that
    /// you can use in a <a>WebACL</a>. When you create a rule group, you define an immutable
    /// capacity limit. If you update a rule group, you must stay within the capacity. This
    /// allows others to reuse the rule group with confidence in its capacity requirements.
    /// 
    /// </para>
    /// </summary>
    [Cmdlet("New", "WAF2RuleGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.WAFV2.Model.RuleGroupSummary")]
    [AWSCmdlet("Calls the AWS WAF V2 CreateRuleGroup API operation.", Operation = new[] {"CreateRuleGroup"}, SelectReturnType = typeof(Amazon.WAFV2.Model.CreateRuleGroupResponse))]
    [AWSCmdletOutput("Amazon.WAFV2.Model.RuleGroupSummary or Amazon.WAFV2.Model.CreateRuleGroupResponse",
        "This cmdlet returns an Amazon.WAFV2.Model.RuleGroupSummary object.",
        "The service call response (type Amazon.WAFV2.Model.CreateRuleGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewWAF2RuleGroupCmdlet : AmazonWAFV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Capacity
        /// <summary>
        /// <para>
        /// <para>The web ACL capacity units (WCUs) required for this rule group.</para><para>When you create your own rule group, you define this, and you cannot change it after
        /// creation. When you add or modify the rules in a rule group, WAF enforces this limit.
        /// You can check the capacity for a set of rules using <a>CheckCapacity</a>.</para><para>WAF uses WCUs to calculate and control the operating resources that are used to run
        /// your rules, rule groups, and web ACLs. WAF calculates capacity differently for each
        /// rule type, to reflect the relative cost of each rule. Simple rules that cost little
        /// to run use fewer WCUs than more complex rules that use more processing power. Rule
        /// group capacity is fixed at creation, which helps users plan their web ACL WCU usage
        /// when they use a rule group. For more information, see <a href="https://docs.aws.amazon.com/waf/latest/developerguide/aws-waf-capacity-units.html">WAF
        /// web ACL capacity units (WCU)</a> in the <i>WAF Developer Guide</i>. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int64? Capacity { get; set; }
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
        /// rule group, and then use them in the rules that you define in the rule group. </para><para>For information about customizing web requests and responses, see <a href="https://docs.aws.amazon.com/waf/latest/developerguide/waf-custom-request-response.html">Customizing
        /// web requests and responses in WAF</a> in the <i>WAF Developer Guide</i>. </para><para>For information about the limits on count and size for custom request and response
        /// settings, see <a href="https://docs.aws.amazon.com/waf/latest/developerguide/limits.html">WAF
        /// quotas</a> in the <i>WAF Developer Guide</i>. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CustomResponseBodies")]
        public System.Collections.Hashtable CustomResponseBody { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the rule group that helps with identification. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
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
        /// <para>The name of the rule group. You cannot change the name of a rule group after you create
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
        
        #region Parameter Rule
        /// <summary>
        /// <para>
        /// <para>The <a>Rule</a> statements used to identify the web requests that you want to manage.
        /// Each rule includes one top-level statement that WAF uses to identify matching web
        /// requests, and parameters that govern how WAF handles them. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of key:value pairs to associate with the resource.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.WAFV2.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Summary'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WAFV2.Model.CreateRuleGroupResponse).
        /// Specifying the name of a property of type Amazon.WAFV2.Model.CreateRuleGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Summary";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-WAF2RuleGroup (CreateRuleGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WAFV2.Model.CreateRuleGroupResponse, NewWAF2RuleGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Capacity = this.Capacity;
            #if MODULAR
            if (this.Capacity == null && ParameterWasBound(nameof(this.Capacity)))
            {
                WriteWarning("You are passing $null as a value for parameter Capacity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.CustomResponseBody != null)
            {
                context.CustomResponseBody = new Dictionary<System.String, Amazon.WAFV2.Model.CustomResponseBody>(StringComparer.Ordinal);
                foreach (var hashKey in this.CustomResponseBody.Keys)
                {
                    context.CustomResponseBody.Add((String)hashKey, (Amazon.WAFV2.Model.CustomResponseBody)(this.CustomResponseBody[hashKey]));
                }
            }
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
            var request = new Amazon.WAFV2.Model.CreateRuleGroupRequest();
            
            if (cmdletContext.Capacity != null)
            {
                request.Capacity = cmdletContext.Capacity.Value;
            }
            if (cmdletContext.CustomResponseBody != null)
            {
                request.CustomResponseBodies = cmdletContext.CustomResponseBody;
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
        
        private Amazon.WAFV2.Model.CreateRuleGroupResponse CallAWSServiceOperation(IAmazonWAFV2 client, Amazon.WAFV2.Model.CreateRuleGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF V2", "CreateRuleGroup");
            try
            {
                return client.CreateRuleGroupAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int64? Capacity { get; set; }
            public Dictionary<System.String, Amazon.WAFV2.Model.CustomResponseBody> CustomResponseBody { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.WAFV2.Model.Rule> Rule { get; set; }
            public Amazon.WAFV2.Scope Scope { get; set; }
            public List<Amazon.WAFV2.Model.Tag> Tag { get; set; }
            public System.Boolean? VisibilityConfig_CloudWatchMetricsEnabled { get; set; }
            public System.String VisibilityConfig_MetricName { get; set; }
            public System.Boolean? VisibilityConfig_SampledRequestsEnabled { get; set; }
            public System.Func<Amazon.WAFV2.Model.CreateRuleGroupResponse, NewWAF2RuleGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Summary;
        }
        
    }
}
