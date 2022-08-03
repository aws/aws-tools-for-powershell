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
    /// Updates the specified <a>RuleGroup</a>.
    /// 
    ///  <note><para>
    /// This operation completely replaces the mutable specifications that you already have
    /// for the rule group with the ones that you provide to this call. To modify the rule
    /// group, retrieve it by calling <a>GetRuleGroup</a>, update the settings as needed,
    /// and then provide the complete rule group specification to this call.
    /// </para></note><para>
    /// When you make changes to web ACLs or web ACL components, like rules and rule groups,
    /// WAF propagates the changes everywhere that the web ACL and its components are stored
    /// and used. Your changes are applied within seconds, but there might be a brief period
    /// of inconsistency when the changes have arrived in some places and not in others. So,
    /// for example, if you change a rule action setting, the action might be the old action
    /// in one area and the new action in another area. Or if you add an IP address to an
    /// IP set used in a blocking rule, the new address might briefly be blocked in one area
    /// while still allowed in another. This temporary inconsistency can occur when you first
    /// associate a web ACL with an Amazon Web Services resource and when you change a web
    /// ACL that is already associated with a resource. Generally, any inconsistencies of
    /// this type last only a few seconds.
    /// </para><para>
    ///  A rule group defines a collection of rules to inspect and control web requests that
    /// you can use in a <a>WebACL</a>. When you create a rule group, you define an immutable
    /// capacity limit. If you update a rule group, you must stay within the capacity. This
    /// allows others to reuse the rule group with confidence in its capacity requirements.
    /// 
    /// </para>
    /// </summary>
    [Cmdlet("Update", "WAF2RuleGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS WAF V2 UpdateRuleGroup API operation.", Operation = new[] {"UpdateRuleGroup"}, SelectReturnType = typeof(Amazon.WAFV2.Model.UpdateRuleGroupResponse))]
    [AWSCmdletOutput("System.String or Amazon.WAFV2.Model.UpdateRuleGroupResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.WAFV2.Model.UpdateRuleGroupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateWAF2RuleGroupCmdlet : AmazonWAFV2ClientCmdlet, IExecutor
    {
        
        #region Parameter VisibilityConfig_CloudWatchMetricsEnabled
        /// <summary>
        /// <para>
        /// <para>A boolean indicating whether the associated resource sends metrics to Amazon CloudWatch.
        /// For the list of available metrics, see <a href="https://docs.aws.amazon.com/waf/latest/developerguide/monitoring-cloudwatch.html#waf-metrics">WAF
        /// Metrics</a>.</para>
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
        /// web requests and responses in WAF</a> in the <a href="https://docs.aws.amazon.com/waf/latest/developerguide/waf-chapter.html">WAF
        /// Developer Guide</a>. </para><para>For information about the limits on count and size for custom request and response
        /// settings, see <a href="https://docs.aws.amazon.com/waf/latest/developerguide/limits.html">WAF
        /// quotas</a> in the <a href="https://docs.aws.amazon.com/waf/latest/developerguide/waf-chapter.html">WAF
        /// Developer Guide</a>. </para>
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
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the rule group. This ID is returned in the responses to create
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
        
        #region Parameter LockToken
        /// <summary>
        /// <para>
        /// <para>A token used for optimistic locking. WAF returns a token to your <code>get</code>
        /// and <code>list</code> requests, to mark the state of the entity at the time of the
        /// request. To make changes to the entity associated with the token, you provide the
        /// token to operations like <code>update</code> and <code>delete</code>. WAF uses the
        /// token to ensure that no changes have been made to the entity since you last retrieved
        /// it. If a change has been made, the update fails with a <code>WAFOptimisticLockException</code>.
        /// If this happens, perform another <code>get</code>, and use the new token returned
        /// by that operation. </para>
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
        /// <para>A name of the Amazon CloudWatch metric. The name can contain only the characters:
        /// A-Z, a-z, 0-9, - (hyphen), and _ (underscore). The name can be from one to 128 characters
        /// long. It can't contain whitespace or metric names reserved for WAF, for example <code>All</code>
        /// and <code>Default_Action</code>. </para>
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Name { get; set; }
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
        /// Amazon API Gateway REST API, an AppSync GraphQL API, or an Amazon Cognito user pool.
        /// </para><para>To work with CloudFront, you must also specify the Region US East (N. Virginia) as
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'NextLockToken'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WAFV2.Model.UpdateRuleGroupResponse).
        /// Specifying the name of a property of type Amazon.WAFV2.Model.UpdateRuleGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "NextLockToken";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-WAF2RuleGroup (UpdateRuleGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WAFV2.Model.UpdateRuleGroupResponse, UpdateWAF2RuleGroupCmdlet>(Select) ??
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
            if (this.CustomResponseBody != null)
            {
                context.CustomResponseBody = new Dictionary<System.String, Amazon.WAFV2.Model.CustomResponseBody>(StringComparer.Ordinal);
                foreach (var hashKey in this.CustomResponseBody.Keys)
                {
                    context.CustomResponseBody.Add((String)hashKey, (CustomResponseBody)(this.CustomResponseBody[hashKey]));
                }
            }
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
            var request = new Amazon.WAFV2.Model.UpdateRuleGroupRequest();
            
            if (cmdletContext.CustomResponseBody != null)
            {
                request.CustomResponseBodies = cmdletContext.CustomResponseBody;
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
        
        private Amazon.WAFV2.Model.UpdateRuleGroupResponse CallAWSServiceOperation(IAmazonWAFV2 client, Amazon.WAFV2.Model.UpdateRuleGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF V2", "UpdateRuleGroup");
            try
            {
                #if DESKTOP
                return client.UpdateRuleGroup(request);
                #elif CORECLR
                return client.UpdateRuleGroupAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, Amazon.WAFV2.Model.CustomResponseBody> CustomResponseBody { get; set; }
            public System.String Description { get; set; }
            public System.String Id { get; set; }
            public System.String LockToken { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.WAFV2.Model.Rule> Rule { get; set; }
            public Amazon.WAFV2.Scope Scope { get; set; }
            public System.Boolean? VisibilityConfig_CloudWatchMetricsEnabled { get; set; }
            public System.String VisibilityConfig_MetricName { get; set; }
            public System.Boolean? VisibilityConfig_SampledRequestsEnabled { get; set; }
            public System.Func<Amazon.WAFV2.Model.UpdateRuleGroupResponse, UpdateWAF2RuleGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.NextLockToken;
        }
        
    }
}
