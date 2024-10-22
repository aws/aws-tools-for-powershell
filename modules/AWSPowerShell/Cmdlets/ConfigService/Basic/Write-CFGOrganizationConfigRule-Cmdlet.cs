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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Adds or updates an Config rule for your entire organization to evaluate if your Amazon
    /// Web Services resources comply with your desired configurations. For information on
    /// how many organization Config rules you can have per account, see <a href="https://docs.aws.amazon.com/config/latest/developerguide/configlimits.html"><b>Service Limits</b></a> in the <i>Config Developer Guide</i>.
    /// 
    ///  
    /// <para>
    ///  Only a management account and a delegated administrator can create or update an organization
    /// Config rule. When calling this API with a delegated administrator, you must ensure
    /// Organizations <c>ListDelegatedAdministrator</c> permissions are added. An organization
    /// can have up to 3 delegated administrators.
    /// </para><para>
    /// This API enables organization service access through the <c>EnableAWSServiceAccess</c>
    /// action and creates a service-linked role <c>AWSServiceRoleForConfigMultiAccountSetup</c>
    /// in the management or delegated administrator account of your organization. The service-linked
    /// role is created only when the role does not exist in the caller account. Config verifies
    /// the existence of role with <c>GetRole</c> action.
    /// </para><para>
    /// To use this API with delegated administrator, register a delegated administrator by
    /// calling Amazon Web Services Organization <c>register-delegated-administrator</c> for
    /// <c>config-multiaccountsetup.amazonaws.com</c>. 
    /// </para><para>
    /// There are two types of rules: <i>Config Managed Rules</i> and <i>Config Custom Rules</i>.
    /// You can use <c>PutOrganizationConfigRule</c> to create both Config Managed Rules and
    /// Config Custom Rules.
    /// </para><para>
    /// Config Managed Rules are predefined, customizable rules created by Config. For a list
    /// of managed rules, see <a href="https://docs.aws.amazon.com/config/latest/developerguide/managed-rules-by-aws-config.html">List
    /// of Config Managed Rules</a>. If you are adding an Config managed rule, you must specify
    /// the rule's identifier for the <c>RuleIdentifier</c> key.
    /// </para><para>
    /// Config Custom Rules are rules that you create from scratch. There are two ways to
    /// create Config custom rules: with Lambda functions (<a href="https://docs.aws.amazon.com/config/latest/developerguide/gettingstarted-concepts.html#gettingstarted-concepts-function">
    /// Lambda Developer Guide</a>) and with Guard (<a href="https://github.com/aws-cloudformation/cloudformation-guard">Guard
    /// GitHub Repository</a>), a policy-as-code language. Config custom rules created with
    /// Lambda are called <i>Config Custom Lambda Rules</i> and Config custom rules created
    /// with Guard are called <i>Config Custom Policy Rules</i>.
    /// </para><para>
    /// If you are adding a new Config Custom Lambda rule, you first need to create an Lambda
    /// function in the management account or a delegated administrator that the rule invokes
    /// to evaluate your resources. You also need to create an IAM role in the managed account
    /// that can be assumed by the Lambda function. When you use <c>PutOrganizationConfigRule</c>
    /// to add a Custom Lambda rule to Config, you must specify the Amazon Resource Name (ARN)
    /// that Lambda assigns to the function.
    /// </para><note><para>
    /// Prerequisite: Ensure you call <c>EnableAllFeatures</c> API to enable all features
    /// in an organization.
    /// </para><para>
    /// Make sure to specify one of either <c>OrganizationCustomPolicyRuleMetadata</c> for
    /// Custom Policy rules, <c>OrganizationCustomRuleMetadata</c> for Custom Lambda rules,
    /// or <c>OrganizationManagedRuleMetadata</c> for managed rules.
    /// </para></note>
    /// </summary>
    [Cmdlet("Write", "CFGOrganizationConfigRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Config PutOrganizationConfigRule API operation.", Operation = new[] {"PutOrganizationConfigRule"}, SelectReturnType = typeof(Amazon.ConfigService.Model.PutOrganizationConfigRuleResponse))]
    [AWSCmdletOutput("System.String or Amazon.ConfigService.Model.PutOrganizationConfigRuleResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ConfigService.Model.PutOrganizationConfigRuleResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCFGOrganizationConfigRuleCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter OrganizationCustomPolicyRuleMetadata_DebugLogDeliveryAccount
        /// <summary>
        /// <para>
        /// <para>A list of accounts that you can enable debug logging for your organization Config
        /// Custom Policy rule. List is null when debug logging is enabled for all accounts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OrganizationCustomPolicyRuleMetadata_DebugLogDeliveryAccounts")]
        public System.String[] OrganizationCustomPolicyRuleMetadata_DebugLogDeliveryAccount { get; set; }
        #endregion
        
        #region Parameter OrganizationCustomPolicyRuleMetadata_Description
        /// <summary>
        /// <para>
        /// <para>The description that you provide for your organization Config Custom Policy rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OrganizationCustomPolicyRuleMetadata_Description { get; set; }
        #endregion
        
        #region Parameter OrganizationCustomRuleMetadata_Description
        /// <summary>
        /// <para>
        /// <para>The description that you provide for your organization Config rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OrganizationCustomRuleMetadata_Description { get; set; }
        #endregion
        
        #region Parameter OrganizationManagedRuleMetadata_Description
        /// <summary>
        /// <para>
        /// <para>The description that you provide for your organization Config rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OrganizationManagedRuleMetadata_Description { get; set; }
        #endregion
        
        #region Parameter ExcludedAccount
        /// <summary>
        /// <para>
        /// <para>A comma-separated list of accounts that you want to exclude from an organization Config
        /// rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExcludedAccounts")]
        public System.String[] ExcludedAccount { get; set; }
        #endregion
        
        #region Parameter OrganizationCustomPolicyRuleMetadata_InputParameter
        /// <summary>
        /// <para>
        /// <para>A string, in JSON format, that is passed to your organization Config Custom Policy
        /// rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OrganizationCustomPolicyRuleMetadata_InputParameters")]
        public System.String OrganizationCustomPolicyRuleMetadata_InputParameter { get; set; }
        #endregion
        
        #region Parameter OrganizationCustomRuleMetadata_InputParameter
        /// <summary>
        /// <para>
        /// <para>A string, in JSON format, that is passed to your organization Config rule Lambda function.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OrganizationCustomRuleMetadata_InputParameters")]
        public System.String OrganizationCustomRuleMetadata_InputParameter { get; set; }
        #endregion
        
        #region Parameter OrganizationManagedRuleMetadata_InputParameter
        /// <summary>
        /// <para>
        /// <para>A string, in JSON format, that is passed to your organization Config rule Lambda function.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OrganizationManagedRuleMetadata_InputParameters")]
        public System.String OrganizationManagedRuleMetadata_InputParameter { get; set; }
        #endregion
        
        #region Parameter OrganizationCustomRuleMetadata_LambdaFunctionArn
        /// <summary>
        /// <para>
        /// <para>The lambda function ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OrganizationCustomRuleMetadata_LambdaFunctionArn { get; set; }
        #endregion
        
        #region Parameter OrganizationCustomPolicyRuleMetadata_MaximumExecutionFrequency
        /// <summary>
        /// <para>
        /// <para>The maximum frequency with which Config runs evaluations for a rule. Your Config Custom
        /// Policy rule is triggered when Config delivers the configuration snapshot. For more
        /// information, see <a>ConfigSnapshotDeliveryProperties</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ConfigService.MaximumExecutionFrequency")]
        public Amazon.ConfigService.MaximumExecutionFrequency OrganizationCustomPolicyRuleMetadata_MaximumExecutionFrequency { get; set; }
        #endregion
        
        #region Parameter OrganizationCustomRuleMetadata_MaximumExecutionFrequency
        /// <summary>
        /// <para>
        /// <para>The maximum frequency with which Config runs evaluations for a rule. Your custom rule
        /// is triggered when Config delivers the configuration snapshot. For more information,
        /// see <a>ConfigSnapshotDeliveryProperties</a>.</para><note><para>By default, rules with a periodic trigger are evaluated every 24 hours. To change
        /// the frequency, specify a valid value for the <c>MaximumExecutionFrequency</c> parameter.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ConfigService.MaximumExecutionFrequency")]
        public Amazon.ConfigService.MaximumExecutionFrequency OrganizationCustomRuleMetadata_MaximumExecutionFrequency { get; set; }
        #endregion
        
        #region Parameter OrganizationManagedRuleMetadata_MaximumExecutionFrequency
        /// <summary>
        /// <para>
        /// <para>The maximum frequency with which Config runs evaluations for a rule. This is for an
        /// Config managed rule that is triggered at a periodic frequency.</para><note><para>By default, rules with a periodic trigger are evaluated every 24 hours. To change
        /// the frequency, specify a valid value for the <c>MaximumExecutionFrequency</c> parameter.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ConfigService.MaximumExecutionFrequency")]
        public Amazon.ConfigService.MaximumExecutionFrequency OrganizationManagedRuleMetadata_MaximumExecutionFrequency { get; set; }
        #endregion
        
        #region Parameter OrganizationConfigRuleName
        /// <summary>
        /// <para>
        /// <para>The name that you assign to an organization Config rule.</para>
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
        public System.String OrganizationConfigRuleName { get; set; }
        #endregion
        
        #region Parameter OrganizationCustomPolicyRuleMetadata_OrganizationConfigRuleTriggerType
        /// <summary>
        /// <para>
        /// <para>The type of notification that initiates Config to run an evaluation for a rule. For
        /// Config Custom Policy rules, Config supports change-initiated notification types:</para><ul><li><para><c>ConfigurationItemChangeNotification</c> - Initiates an evaluation when Config
        /// delivers a configuration item as a result of a resource change.</para></li><li><para><c>OversizedConfigurationItemChangeNotification</c> - Initiates an evaluation when
        /// Config delivers an oversized configuration item. Config may generate this notification
        /// type when a resource changes and the notification exceeds the maximum size allowed
        /// by Amazon SNS.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OrganizationCustomPolicyRuleMetadata_OrganizationConfigRuleTriggerTypes")]
        public System.String[] OrganizationCustomPolicyRuleMetadata_OrganizationConfigRuleTriggerType { get; set; }
        #endregion
        
        #region Parameter OrganizationCustomRuleMetadata_OrganizationConfigRuleTriggerType
        /// <summary>
        /// <para>
        /// <para>The type of notification that triggers Config to run an evaluation for a rule. You
        /// can specify the following notification types:</para><ul><li><para><c>ConfigurationItemChangeNotification</c> - Triggers an evaluation when Config delivers
        /// a configuration item as a result of a resource change.</para></li><li><para><c>OversizedConfigurationItemChangeNotification</c> - Triggers an evaluation when
        /// Config delivers an oversized configuration item. Config may generate this notification
        /// type when a resource changes and the notification exceeds the maximum size allowed
        /// by Amazon SNS.</para></li><li><para><c>ScheduledNotification</c> - Triggers a periodic evaluation at the frequency specified
        /// for <c>MaximumExecutionFrequency</c>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OrganizationCustomRuleMetadata_OrganizationConfigRuleTriggerTypes")]
        public System.String[] OrganizationCustomRuleMetadata_OrganizationConfigRuleTriggerType { get; set; }
        #endregion
        
        #region Parameter OrganizationCustomPolicyRuleMetadata_PolicyRuntime
        /// <summary>
        /// <para>
        /// <para>The runtime system for your organization Config Custom Policy rules. Guard is a policy-as-code
        /// language that allows you to write policies that are enforced by Config Custom Policy
        /// rules. For more information about Guard, see the <a href="https://github.com/aws-cloudformation/cloudformation-guard">Guard
        /// GitHub Repository</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OrganizationCustomPolicyRuleMetadata_PolicyRuntime { get; set; }
        #endregion
        
        #region Parameter OrganizationCustomPolicyRuleMetadata_PolicyText
        /// <summary>
        /// <para>
        /// <para>The policy definition containing the logic for your organization Config Custom Policy
        /// rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OrganizationCustomPolicyRuleMetadata_PolicyText { get; set; }
        #endregion
        
        #region Parameter OrganizationCustomPolicyRuleMetadata_ResourceIdScope
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services resource that was evaluated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OrganizationCustomPolicyRuleMetadata_ResourceIdScope { get; set; }
        #endregion
        
        #region Parameter OrganizationCustomRuleMetadata_ResourceIdScope
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services resource that was evaluated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OrganizationCustomRuleMetadata_ResourceIdScope { get; set; }
        #endregion
        
        #region Parameter OrganizationManagedRuleMetadata_ResourceIdScope
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services resource that was evaluated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OrganizationManagedRuleMetadata_ResourceIdScope { get; set; }
        #endregion
        
        #region Parameter OrganizationCustomPolicyRuleMetadata_ResourceTypesScope
        /// <summary>
        /// <para>
        /// <para>The type of the Amazon Web Services resource that was evaluated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] OrganizationCustomPolicyRuleMetadata_ResourceTypesScope { get; set; }
        #endregion
        
        #region Parameter OrganizationCustomRuleMetadata_ResourceTypesScope
        /// <summary>
        /// <para>
        /// <para>The type of the Amazon Web Services resource that was evaluated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] OrganizationCustomRuleMetadata_ResourceTypesScope { get; set; }
        #endregion
        
        #region Parameter OrganizationManagedRuleMetadata_ResourceTypesScope
        /// <summary>
        /// <para>
        /// <para>The type of the Amazon Web Services resource that was evaluated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] OrganizationManagedRuleMetadata_ResourceTypesScope { get; set; }
        #endregion
        
        #region Parameter OrganizationManagedRuleMetadata_RuleIdentifier
        /// <summary>
        /// <para>
        /// <para>For organization config managed rules, a predefined identifier from a list. For example,
        /// <c>IAM_PASSWORD_POLICY</c> is a managed rule. To reference a managed rule, see <a href="https://docs.aws.amazon.com/config/latest/developerguide/evaluate-config_use-managed-rules.html">Using
        /// Config managed rules</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OrganizationManagedRuleMetadata_RuleIdentifier { get; set; }
        #endregion
        
        #region Parameter OrganizationCustomPolicyRuleMetadata_TagKeyScope
        /// <summary>
        /// <para>
        /// <para>One part of a key-value pair that make up a tag. A key is a general label that acts
        /// like a category for more specific tag values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OrganizationCustomPolicyRuleMetadata_TagKeyScope { get; set; }
        #endregion
        
        #region Parameter OrganizationCustomRuleMetadata_TagKeyScope
        /// <summary>
        /// <para>
        /// <para>One part of a key-value pair that make up a tag. A key is a general label that acts
        /// like a category for more specific tag values. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OrganizationCustomRuleMetadata_TagKeyScope { get; set; }
        #endregion
        
        #region Parameter OrganizationManagedRuleMetadata_TagKeyScope
        /// <summary>
        /// <para>
        /// <para>One part of a key-value pair that make up a tag. A key is a general label that acts
        /// like a category for more specific tag values. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OrganizationManagedRuleMetadata_TagKeyScope { get; set; }
        #endregion
        
        #region Parameter OrganizationCustomPolicyRuleMetadata_TagValueScope
        /// <summary>
        /// <para>
        /// <para>The optional part of a key-value pair that make up a tag. A value acts as a descriptor
        /// within a tag category (key).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OrganizationCustomPolicyRuleMetadata_TagValueScope { get; set; }
        #endregion
        
        #region Parameter OrganizationCustomRuleMetadata_TagValueScope
        /// <summary>
        /// <para>
        /// <para>The optional part of a key-value pair that make up a tag. A value acts as a descriptor
        /// within a tag category (key). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OrganizationCustomRuleMetadata_TagValueScope { get; set; }
        #endregion
        
        #region Parameter OrganizationManagedRuleMetadata_TagValueScope
        /// <summary>
        /// <para>
        /// <para>The optional part of a key-value pair that make up a tag. A value acts as a descriptor
        /// within a tag category (key).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OrganizationManagedRuleMetadata_TagValueScope { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'OrganizationConfigRuleArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConfigService.Model.PutOrganizationConfigRuleResponse).
        /// Specifying the name of a property of type Amazon.ConfigService.Model.PutOrganizationConfigRuleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "OrganizationConfigRuleArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.OrganizationConfigRuleName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CFGOrganizationConfigRule (PutOrganizationConfigRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConfigService.Model.PutOrganizationConfigRuleResponse, WriteCFGOrganizationConfigRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ExcludedAccount != null)
            {
                context.ExcludedAccount = new List<System.String>(this.ExcludedAccount);
            }
            context.OrganizationConfigRuleName = this.OrganizationConfigRuleName;
            #if MODULAR
            if (this.OrganizationConfigRuleName == null && ParameterWasBound(nameof(this.OrganizationConfigRuleName)))
            {
                WriteWarning("You are passing $null as a value for parameter OrganizationConfigRuleName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.OrganizationCustomPolicyRuleMetadata_DebugLogDeliveryAccount != null)
            {
                context.OrganizationCustomPolicyRuleMetadata_DebugLogDeliveryAccount = new List<System.String>(this.OrganizationCustomPolicyRuleMetadata_DebugLogDeliveryAccount);
            }
            context.OrganizationCustomPolicyRuleMetadata_Description = this.OrganizationCustomPolicyRuleMetadata_Description;
            context.OrganizationCustomPolicyRuleMetadata_InputParameter = this.OrganizationCustomPolicyRuleMetadata_InputParameter;
            context.OrganizationCustomPolicyRuleMetadata_MaximumExecutionFrequency = this.OrganizationCustomPolicyRuleMetadata_MaximumExecutionFrequency;
            if (this.OrganizationCustomPolicyRuleMetadata_OrganizationConfigRuleTriggerType != null)
            {
                context.OrganizationCustomPolicyRuleMetadata_OrganizationConfigRuleTriggerType = new List<System.String>(this.OrganizationCustomPolicyRuleMetadata_OrganizationConfigRuleTriggerType);
            }
            context.OrganizationCustomPolicyRuleMetadata_PolicyRuntime = this.OrganizationCustomPolicyRuleMetadata_PolicyRuntime;
            context.OrganizationCustomPolicyRuleMetadata_PolicyText = this.OrganizationCustomPolicyRuleMetadata_PolicyText;
            context.OrganizationCustomPolicyRuleMetadata_ResourceIdScope = this.OrganizationCustomPolicyRuleMetadata_ResourceIdScope;
            if (this.OrganizationCustomPolicyRuleMetadata_ResourceTypesScope != null)
            {
                context.OrganizationCustomPolicyRuleMetadata_ResourceTypesScope = new List<System.String>(this.OrganizationCustomPolicyRuleMetadata_ResourceTypesScope);
            }
            context.OrganizationCustomPolicyRuleMetadata_TagKeyScope = this.OrganizationCustomPolicyRuleMetadata_TagKeyScope;
            context.OrganizationCustomPolicyRuleMetadata_TagValueScope = this.OrganizationCustomPolicyRuleMetadata_TagValueScope;
            context.OrganizationCustomRuleMetadata_Description = this.OrganizationCustomRuleMetadata_Description;
            context.OrganizationCustomRuleMetadata_InputParameter = this.OrganizationCustomRuleMetadata_InputParameter;
            context.OrganizationCustomRuleMetadata_LambdaFunctionArn = this.OrganizationCustomRuleMetadata_LambdaFunctionArn;
            context.OrganizationCustomRuleMetadata_MaximumExecutionFrequency = this.OrganizationCustomRuleMetadata_MaximumExecutionFrequency;
            if (this.OrganizationCustomRuleMetadata_OrganizationConfigRuleTriggerType != null)
            {
                context.OrganizationCustomRuleMetadata_OrganizationConfigRuleTriggerType = new List<System.String>(this.OrganizationCustomRuleMetadata_OrganizationConfigRuleTriggerType);
            }
            context.OrganizationCustomRuleMetadata_ResourceIdScope = this.OrganizationCustomRuleMetadata_ResourceIdScope;
            if (this.OrganizationCustomRuleMetadata_ResourceTypesScope != null)
            {
                context.OrganizationCustomRuleMetadata_ResourceTypesScope = new List<System.String>(this.OrganizationCustomRuleMetadata_ResourceTypesScope);
            }
            context.OrganizationCustomRuleMetadata_TagKeyScope = this.OrganizationCustomRuleMetadata_TagKeyScope;
            context.OrganizationCustomRuleMetadata_TagValueScope = this.OrganizationCustomRuleMetadata_TagValueScope;
            context.OrganizationManagedRuleMetadata_Description = this.OrganizationManagedRuleMetadata_Description;
            context.OrganizationManagedRuleMetadata_InputParameter = this.OrganizationManagedRuleMetadata_InputParameter;
            context.OrganizationManagedRuleMetadata_MaximumExecutionFrequency = this.OrganizationManagedRuleMetadata_MaximumExecutionFrequency;
            context.OrganizationManagedRuleMetadata_ResourceIdScope = this.OrganizationManagedRuleMetadata_ResourceIdScope;
            if (this.OrganizationManagedRuleMetadata_ResourceTypesScope != null)
            {
                context.OrganizationManagedRuleMetadata_ResourceTypesScope = new List<System.String>(this.OrganizationManagedRuleMetadata_ResourceTypesScope);
            }
            context.OrganizationManagedRuleMetadata_RuleIdentifier = this.OrganizationManagedRuleMetadata_RuleIdentifier;
            context.OrganizationManagedRuleMetadata_TagKeyScope = this.OrganizationManagedRuleMetadata_TagKeyScope;
            context.OrganizationManagedRuleMetadata_TagValueScope = this.OrganizationManagedRuleMetadata_TagValueScope;
            
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
            var request = new Amazon.ConfigService.Model.PutOrganizationConfigRuleRequest();
            
            if (cmdletContext.ExcludedAccount != null)
            {
                request.ExcludedAccounts = cmdletContext.ExcludedAccount;
            }
            if (cmdletContext.OrganizationConfigRuleName != null)
            {
                request.OrganizationConfigRuleName = cmdletContext.OrganizationConfigRuleName;
            }
            
             // populate OrganizationCustomPolicyRuleMetadata
            var requestOrganizationCustomPolicyRuleMetadataIsNull = true;
            request.OrganizationCustomPolicyRuleMetadata = new Amazon.ConfigService.Model.OrganizationCustomPolicyRuleMetadata();
            List<System.String> requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_DebugLogDeliveryAccount = null;
            if (cmdletContext.OrganizationCustomPolicyRuleMetadata_DebugLogDeliveryAccount != null)
            {
                requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_DebugLogDeliveryAccount = cmdletContext.OrganizationCustomPolicyRuleMetadata_DebugLogDeliveryAccount;
            }
            if (requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_DebugLogDeliveryAccount != null)
            {
                request.OrganizationCustomPolicyRuleMetadata.DebugLogDeliveryAccounts = requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_DebugLogDeliveryAccount;
                requestOrganizationCustomPolicyRuleMetadataIsNull = false;
            }
            System.String requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_Description = null;
            if (cmdletContext.OrganizationCustomPolicyRuleMetadata_Description != null)
            {
                requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_Description = cmdletContext.OrganizationCustomPolicyRuleMetadata_Description;
            }
            if (requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_Description != null)
            {
                request.OrganizationCustomPolicyRuleMetadata.Description = requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_Description;
                requestOrganizationCustomPolicyRuleMetadataIsNull = false;
            }
            System.String requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_InputParameter = null;
            if (cmdletContext.OrganizationCustomPolicyRuleMetadata_InputParameter != null)
            {
                requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_InputParameter = cmdletContext.OrganizationCustomPolicyRuleMetadata_InputParameter;
            }
            if (requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_InputParameter != null)
            {
                request.OrganizationCustomPolicyRuleMetadata.InputParameters = requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_InputParameter;
                requestOrganizationCustomPolicyRuleMetadataIsNull = false;
            }
            Amazon.ConfigService.MaximumExecutionFrequency requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_MaximumExecutionFrequency = null;
            if (cmdletContext.OrganizationCustomPolicyRuleMetadata_MaximumExecutionFrequency != null)
            {
                requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_MaximumExecutionFrequency = cmdletContext.OrganizationCustomPolicyRuleMetadata_MaximumExecutionFrequency;
            }
            if (requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_MaximumExecutionFrequency != null)
            {
                request.OrganizationCustomPolicyRuleMetadata.MaximumExecutionFrequency = requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_MaximumExecutionFrequency;
                requestOrganizationCustomPolicyRuleMetadataIsNull = false;
            }
            List<System.String> requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_OrganizationConfigRuleTriggerType = null;
            if (cmdletContext.OrganizationCustomPolicyRuleMetadata_OrganizationConfigRuleTriggerType != null)
            {
                requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_OrganizationConfigRuleTriggerType = cmdletContext.OrganizationCustomPolicyRuleMetadata_OrganizationConfigRuleTriggerType;
            }
            if (requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_OrganizationConfigRuleTriggerType != null)
            {
                request.OrganizationCustomPolicyRuleMetadata.OrganizationConfigRuleTriggerTypes = requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_OrganizationConfigRuleTriggerType;
                requestOrganizationCustomPolicyRuleMetadataIsNull = false;
            }
            System.String requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_PolicyRuntime = null;
            if (cmdletContext.OrganizationCustomPolicyRuleMetadata_PolicyRuntime != null)
            {
                requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_PolicyRuntime = cmdletContext.OrganizationCustomPolicyRuleMetadata_PolicyRuntime;
            }
            if (requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_PolicyRuntime != null)
            {
                request.OrganizationCustomPolicyRuleMetadata.PolicyRuntime = requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_PolicyRuntime;
                requestOrganizationCustomPolicyRuleMetadataIsNull = false;
            }
            System.String requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_PolicyText = null;
            if (cmdletContext.OrganizationCustomPolicyRuleMetadata_PolicyText != null)
            {
                requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_PolicyText = cmdletContext.OrganizationCustomPolicyRuleMetadata_PolicyText;
            }
            if (requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_PolicyText != null)
            {
                request.OrganizationCustomPolicyRuleMetadata.PolicyText = requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_PolicyText;
                requestOrganizationCustomPolicyRuleMetadataIsNull = false;
            }
            System.String requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_ResourceIdScope = null;
            if (cmdletContext.OrganizationCustomPolicyRuleMetadata_ResourceIdScope != null)
            {
                requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_ResourceIdScope = cmdletContext.OrganizationCustomPolicyRuleMetadata_ResourceIdScope;
            }
            if (requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_ResourceIdScope != null)
            {
                request.OrganizationCustomPolicyRuleMetadata.ResourceIdScope = requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_ResourceIdScope;
                requestOrganizationCustomPolicyRuleMetadataIsNull = false;
            }
            List<System.String> requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_ResourceTypesScope = null;
            if (cmdletContext.OrganizationCustomPolicyRuleMetadata_ResourceTypesScope != null)
            {
                requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_ResourceTypesScope = cmdletContext.OrganizationCustomPolicyRuleMetadata_ResourceTypesScope;
            }
            if (requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_ResourceTypesScope != null)
            {
                request.OrganizationCustomPolicyRuleMetadata.ResourceTypesScope = requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_ResourceTypesScope;
                requestOrganizationCustomPolicyRuleMetadataIsNull = false;
            }
            System.String requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_TagKeyScope = null;
            if (cmdletContext.OrganizationCustomPolicyRuleMetadata_TagKeyScope != null)
            {
                requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_TagKeyScope = cmdletContext.OrganizationCustomPolicyRuleMetadata_TagKeyScope;
            }
            if (requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_TagKeyScope != null)
            {
                request.OrganizationCustomPolicyRuleMetadata.TagKeyScope = requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_TagKeyScope;
                requestOrganizationCustomPolicyRuleMetadataIsNull = false;
            }
            System.String requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_TagValueScope = null;
            if (cmdletContext.OrganizationCustomPolicyRuleMetadata_TagValueScope != null)
            {
                requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_TagValueScope = cmdletContext.OrganizationCustomPolicyRuleMetadata_TagValueScope;
            }
            if (requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_TagValueScope != null)
            {
                request.OrganizationCustomPolicyRuleMetadata.TagValueScope = requestOrganizationCustomPolicyRuleMetadata_organizationCustomPolicyRuleMetadata_TagValueScope;
                requestOrganizationCustomPolicyRuleMetadataIsNull = false;
            }
             // determine if request.OrganizationCustomPolicyRuleMetadata should be set to null
            if (requestOrganizationCustomPolicyRuleMetadataIsNull)
            {
                request.OrganizationCustomPolicyRuleMetadata = null;
            }
            
             // populate OrganizationCustomRuleMetadata
            var requestOrganizationCustomRuleMetadataIsNull = true;
            request.OrganizationCustomRuleMetadata = new Amazon.ConfigService.Model.OrganizationCustomRuleMetadata();
            System.String requestOrganizationCustomRuleMetadata_organizationCustomRuleMetadata_Description = null;
            if (cmdletContext.OrganizationCustomRuleMetadata_Description != null)
            {
                requestOrganizationCustomRuleMetadata_organizationCustomRuleMetadata_Description = cmdletContext.OrganizationCustomRuleMetadata_Description;
            }
            if (requestOrganizationCustomRuleMetadata_organizationCustomRuleMetadata_Description != null)
            {
                request.OrganizationCustomRuleMetadata.Description = requestOrganizationCustomRuleMetadata_organizationCustomRuleMetadata_Description;
                requestOrganizationCustomRuleMetadataIsNull = false;
            }
            System.String requestOrganizationCustomRuleMetadata_organizationCustomRuleMetadata_InputParameter = null;
            if (cmdletContext.OrganizationCustomRuleMetadata_InputParameter != null)
            {
                requestOrganizationCustomRuleMetadata_organizationCustomRuleMetadata_InputParameter = cmdletContext.OrganizationCustomRuleMetadata_InputParameter;
            }
            if (requestOrganizationCustomRuleMetadata_organizationCustomRuleMetadata_InputParameter != null)
            {
                request.OrganizationCustomRuleMetadata.InputParameters = requestOrganizationCustomRuleMetadata_organizationCustomRuleMetadata_InputParameter;
                requestOrganizationCustomRuleMetadataIsNull = false;
            }
            System.String requestOrganizationCustomRuleMetadata_organizationCustomRuleMetadata_LambdaFunctionArn = null;
            if (cmdletContext.OrganizationCustomRuleMetadata_LambdaFunctionArn != null)
            {
                requestOrganizationCustomRuleMetadata_organizationCustomRuleMetadata_LambdaFunctionArn = cmdletContext.OrganizationCustomRuleMetadata_LambdaFunctionArn;
            }
            if (requestOrganizationCustomRuleMetadata_organizationCustomRuleMetadata_LambdaFunctionArn != null)
            {
                request.OrganizationCustomRuleMetadata.LambdaFunctionArn = requestOrganizationCustomRuleMetadata_organizationCustomRuleMetadata_LambdaFunctionArn;
                requestOrganizationCustomRuleMetadataIsNull = false;
            }
            Amazon.ConfigService.MaximumExecutionFrequency requestOrganizationCustomRuleMetadata_organizationCustomRuleMetadata_MaximumExecutionFrequency = null;
            if (cmdletContext.OrganizationCustomRuleMetadata_MaximumExecutionFrequency != null)
            {
                requestOrganizationCustomRuleMetadata_organizationCustomRuleMetadata_MaximumExecutionFrequency = cmdletContext.OrganizationCustomRuleMetadata_MaximumExecutionFrequency;
            }
            if (requestOrganizationCustomRuleMetadata_organizationCustomRuleMetadata_MaximumExecutionFrequency != null)
            {
                request.OrganizationCustomRuleMetadata.MaximumExecutionFrequency = requestOrganizationCustomRuleMetadata_organizationCustomRuleMetadata_MaximumExecutionFrequency;
                requestOrganizationCustomRuleMetadataIsNull = false;
            }
            List<System.String> requestOrganizationCustomRuleMetadata_organizationCustomRuleMetadata_OrganizationConfigRuleTriggerType = null;
            if (cmdletContext.OrganizationCustomRuleMetadata_OrganizationConfigRuleTriggerType != null)
            {
                requestOrganizationCustomRuleMetadata_organizationCustomRuleMetadata_OrganizationConfigRuleTriggerType = cmdletContext.OrganizationCustomRuleMetadata_OrganizationConfigRuleTriggerType;
            }
            if (requestOrganizationCustomRuleMetadata_organizationCustomRuleMetadata_OrganizationConfigRuleTriggerType != null)
            {
                request.OrganizationCustomRuleMetadata.OrganizationConfigRuleTriggerTypes = requestOrganizationCustomRuleMetadata_organizationCustomRuleMetadata_OrganizationConfigRuleTriggerType;
                requestOrganizationCustomRuleMetadataIsNull = false;
            }
            System.String requestOrganizationCustomRuleMetadata_organizationCustomRuleMetadata_ResourceIdScope = null;
            if (cmdletContext.OrganizationCustomRuleMetadata_ResourceIdScope != null)
            {
                requestOrganizationCustomRuleMetadata_organizationCustomRuleMetadata_ResourceIdScope = cmdletContext.OrganizationCustomRuleMetadata_ResourceIdScope;
            }
            if (requestOrganizationCustomRuleMetadata_organizationCustomRuleMetadata_ResourceIdScope != null)
            {
                request.OrganizationCustomRuleMetadata.ResourceIdScope = requestOrganizationCustomRuleMetadata_organizationCustomRuleMetadata_ResourceIdScope;
                requestOrganizationCustomRuleMetadataIsNull = false;
            }
            List<System.String> requestOrganizationCustomRuleMetadata_organizationCustomRuleMetadata_ResourceTypesScope = null;
            if (cmdletContext.OrganizationCustomRuleMetadata_ResourceTypesScope != null)
            {
                requestOrganizationCustomRuleMetadata_organizationCustomRuleMetadata_ResourceTypesScope = cmdletContext.OrganizationCustomRuleMetadata_ResourceTypesScope;
            }
            if (requestOrganizationCustomRuleMetadata_organizationCustomRuleMetadata_ResourceTypesScope != null)
            {
                request.OrganizationCustomRuleMetadata.ResourceTypesScope = requestOrganizationCustomRuleMetadata_organizationCustomRuleMetadata_ResourceTypesScope;
                requestOrganizationCustomRuleMetadataIsNull = false;
            }
            System.String requestOrganizationCustomRuleMetadata_organizationCustomRuleMetadata_TagKeyScope = null;
            if (cmdletContext.OrganizationCustomRuleMetadata_TagKeyScope != null)
            {
                requestOrganizationCustomRuleMetadata_organizationCustomRuleMetadata_TagKeyScope = cmdletContext.OrganizationCustomRuleMetadata_TagKeyScope;
            }
            if (requestOrganizationCustomRuleMetadata_organizationCustomRuleMetadata_TagKeyScope != null)
            {
                request.OrganizationCustomRuleMetadata.TagKeyScope = requestOrganizationCustomRuleMetadata_organizationCustomRuleMetadata_TagKeyScope;
                requestOrganizationCustomRuleMetadataIsNull = false;
            }
            System.String requestOrganizationCustomRuleMetadata_organizationCustomRuleMetadata_TagValueScope = null;
            if (cmdletContext.OrganizationCustomRuleMetadata_TagValueScope != null)
            {
                requestOrganizationCustomRuleMetadata_organizationCustomRuleMetadata_TagValueScope = cmdletContext.OrganizationCustomRuleMetadata_TagValueScope;
            }
            if (requestOrganizationCustomRuleMetadata_organizationCustomRuleMetadata_TagValueScope != null)
            {
                request.OrganizationCustomRuleMetadata.TagValueScope = requestOrganizationCustomRuleMetadata_organizationCustomRuleMetadata_TagValueScope;
                requestOrganizationCustomRuleMetadataIsNull = false;
            }
             // determine if request.OrganizationCustomRuleMetadata should be set to null
            if (requestOrganizationCustomRuleMetadataIsNull)
            {
                request.OrganizationCustomRuleMetadata = null;
            }
            
             // populate OrganizationManagedRuleMetadata
            var requestOrganizationManagedRuleMetadataIsNull = true;
            request.OrganizationManagedRuleMetadata = new Amazon.ConfigService.Model.OrganizationManagedRuleMetadata();
            System.String requestOrganizationManagedRuleMetadata_organizationManagedRuleMetadata_Description = null;
            if (cmdletContext.OrganizationManagedRuleMetadata_Description != null)
            {
                requestOrganizationManagedRuleMetadata_organizationManagedRuleMetadata_Description = cmdletContext.OrganizationManagedRuleMetadata_Description;
            }
            if (requestOrganizationManagedRuleMetadata_organizationManagedRuleMetadata_Description != null)
            {
                request.OrganizationManagedRuleMetadata.Description = requestOrganizationManagedRuleMetadata_organizationManagedRuleMetadata_Description;
                requestOrganizationManagedRuleMetadataIsNull = false;
            }
            System.String requestOrganizationManagedRuleMetadata_organizationManagedRuleMetadata_InputParameter = null;
            if (cmdletContext.OrganizationManagedRuleMetadata_InputParameter != null)
            {
                requestOrganizationManagedRuleMetadata_organizationManagedRuleMetadata_InputParameter = cmdletContext.OrganizationManagedRuleMetadata_InputParameter;
            }
            if (requestOrganizationManagedRuleMetadata_organizationManagedRuleMetadata_InputParameter != null)
            {
                request.OrganizationManagedRuleMetadata.InputParameters = requestOrganizationManagedRuleMetadata_organizationManagedRuleMetadata_InputParameter;
                requestOrganizationManagedRuleMetadataIsNull = false;
            }
            Amazon.ConfigService.MaximumExecutionFrequency requestOrganizationManagedRuleMetadata_organizationManagedRuleMetadata_MaximumExecutionFrequency = null;
            if (cmdletContext.OrganizationManagedRuleMetadata_MaximumExecutionFrequency != null)
            {
                requestOrganizationManagedRuleMetadata_organizationManagedRuleMetadata_MaximumExecutionFrequency = cmdletContext.OrganizationManagedRuleMetadata_MaximumExecutionFrequency;
            }
            if (requestOrganizationManagedRuleMetadata_organizationManagedRuleMetadata_MaximumExecutionFrequency != null)
            {
                request.OrganizationManagedRuleMetadata.MaximumExecutionFrequency = requestOrganizationManagedRuleMetadata_organizationManagedRuleMetadata_MaximumExecutionFrequency;
                requestOrganizationManagedRuleMetadataIsNull = false;
            }
            System.String requestOrganizationManagedRuleMetadata_organizationManagedRuleMetadata_ResourceIdScope = null;
            if (cmdletContext.OrganizationManagedRuleMetadata_ResourceIdScope != null)
            {
                requestOrganizationManagedRuleMetadata_organizationManagedRuleMetadata_ResourceIdScope = cmdletContext.OrganizationManagedRuleMetadata_ResourceIdScope;
            }
            if (requestOrganizationManagedRuleMetadata_organizationManagedRuleMetadata_ResourceIdScope != null)
            {
                request.OrganizationManagedRuleMetadata.ResourceIdScope = requestOrganizationManagedRuleMetadata_organizationManagedRuleMetadata_ResourceIdScope;
                requestOrganizationManagedRuleMetadataIsNull = false;
            }
            List<System.String> requestOrganizationManagedRuleMetadata_organizationManagedRuleMetadata_ResourceTypesScope = null;
            if (cmdletContext.OrganizationManagedRuleMetadata_ResourceTypesScope != null)
            {
                requestOrganizationManagedRuleMetadata_organizationManagedRuleMetadata_ResourceTypesScope = cmdletContext.OrganizationManagedRuleMetadata_ResourceTypesScope;
            }
            if (requestOrganizationManagedRuleMetadata_organizationManagedRuleMetadata_ResourceTypesScope != null)
            {
                request.OrganizationManagedRuleMetadata.ResourceTypesScope = requestOrganizationManagedRuleMetadata_organizationManagedRuleMetadata_ResourceTypesScope;
                requestOrganizationManagedRuleMetadataIsNull = false;
            }
            System.String requestOrganizationManagedRuleMetadata_organizationManagedRuleMetadata_RuleIdentifier = null;
            if (cmdletContext.OrganizationManagedRuleMetadata_RuleIdentifier != null)
            {
                requestOrganizationManagedRuleMetadata_organizationManagedRuleMetadata_RuleIdentifier = cmdletContext.OrganizationManagedRuleMetadata_RuleIdentifier;
            }
            if (requestOrganizationManagedRuleMetadata_organizationManagedRuleMetadata_RuleIdentifier != null)
            {
                request.OrganizationManagedRuleMetadata.RuleIdentifier = requestOrganizationManagedRuleMetadata_organizationManagedRuleMetadata_RuleIdentifier;
                requestOrganizationManagedRuleMetadataIsNull = false;
            }
            System.String requestOrganizationManagedRuleMetadata_organizationManagedRuleMetadata_TagKeyScope = null;
            if (cmdletContext.OrganizationManagedRuleMetadata_TagKeyScope != null)
            {
                requestOrganizationManagedRuleMetadata_organizationManagedRuleMetadata_TagKeyScope = cmdletContext.OrganizationManagedRuleMetadata_TagKeyScope;
            }
            if (requestOrganizationManagedRuleMetadata_organizationManagedRuleMetadata_TagKeyScope != null)
            {
                request.OrganizationManagedRuleMetadata.TagKeyScope = requestOrganizationManagedRuleMetadata_organizationManagedRuleMetadata_TagKeyScope;
                requestOrganizationManagedRuleMetadataIsNull = false;
            }
            System.String requestOrganizationManagedRuleMetadata_organizationManagedRuleMetadata_TagValueScope = null;
            if (cmdletContext.OrganizationManagedRuleMetadata_TagValueScope != null)
            {
                requestOrganizationManagedRuleMetadata_organizationManagedRuleMetadata_TagValueScope = cmdletContext.OrganizationManagedRuleMetadata_TagValueScope;
            }
            if (requestOrganizationManagedRuleMetadata_organizationManagedRuleMetadata_TagValueScope != null)
            {
                request.OrganizationManagedRuleMetadata.TagValueScope = requestOrganizationManagedRuleMetadata_organizationManagedRuleMetadata_TagValueScope;
                requestOrganizationManagedRuleMetadataIsNull = false;
            }
             // determine if request.OrganizationManagedRuleMetadata should be set to null
            if (requestOrganizationManagedRuleMetadataIsNull)
            {
                request.OrganizationManagedRuleMetadata = null;
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
        
        private Amazon.ConfigService.Model.PutOrganizationConfigRuleResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.PutOrganizationConfigRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "PutOrganizationConfigRule");
            try
            {
                #if DESKTOP
                return client.PutOrganizationConfigRule(request);
                #elif CORECLR
                return client.PutOrganizationConfigRuleAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ExcludedAccount { get; set; }
            public System.String OrganizationConfigRuleName { get; set; }
            public List<System.String> OrganizationCustomPolicyRuleMetadata_DebugLogDeliveryAccount { get; set; }
            public System.String OrganizationCustomPolicyRuleMetadata_Description { get; set; }
            public System.String OrganizationCustomPolicyRuleMetadata_InputParameter { get; set; }
            public Amazon.ConfigService.MaximumExecutionFrequency OrganizationCustomPolicyRuleMetadata_MaximumExecutionFrequency { get; set; }
            public List<System.String> OrganizationCustomPolicyRuleMetadata_OrganizationConfigRuleTriggerType { get; set; }
            public System.String OrganizationCustomPolicyRuleMetadata_PolicyRuntime { get; set; }
            public System.String OrganizationCustomPolicyRuleMetadata_PolicyText { get; set; }
            public System.String OrganizationCustomPolicyRuleMetadata_ResourceIdScope { get; set; }
            public List<System.String> OrganizationCustomPolicyRuleMetadata_ResourceTypesScope { get; set; }
            public System.String OrganizationCustomPolicyRuleMetadata_TagKeyScope { get; set; }
            public System.String OrganizationCustomPolicyRuleMetadata_TagValueScope { get; set; }
            public System.String OrganizationCustomRuleMetadata_Description { get; set; }
            public System.String OrganizationCustomRuleMetadata_InputParameter { get; set; }
            public System.String OrganizationCustomRuleMetadata_LambdaFunctionArn { get; set; }
            public Amazon.ConfigService.MaximumExecutionFrequency OrganizationCustomRuleMetadata_MaximumExecutionFrequency { get; set; }
            public List<System.String> OrganizationCustomRuleMetadata_OrganizationConfigRuleTriggerType { get; set; }
            public System.String OrganizationCustomRuleMetadata_ResourceIdScope { get; set; }
            public List<System.String> OrganizationCustomRuleMetadata_ResourceTypesScope { get; set; }
            public System.String OrganizationCustomRuleMetadata_TagKeyScope { get; set; }
            public System.String OrganizationCustomRuleMetadata_TagValueScope { get; set; }
            public System.String OrganizationManagedRuleMetadata_Description { get; set; }
            public System.String OrganizationManagedRuleMetadata_InputParameter { get; set; }
            public Amazon.ConfigService.MaximumExecutionFrequency OrganizationManagedRuleMetadata_MaximumExecutionFrequency { get; set; }
            public System.String OrganizationManagedRuleMetadata_ResourceIdScope { get; set; }
            public List<System.String> OrganizationManagedRuleMetadata_ResourceTypesScope { get; set; }
            public System.String OrganizationManagedRuleMetadata_RuleIdentifier { get; set; }
            public System.String OrganizationManagedRuleMetadata_TagKeyScope { get; set; }
            public System.String OrganizationManagedRuleMetadata_TagValueScope { get; set; }
            public System.Func<Amazon.ConfigService.Model.PutOrganizationConfigRuleResponse, WriteCFGOrganizationConfigRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.OrganizationConfigRuleArn;
        }
        
    }
}
