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
using Amazon.SecurityHub;
using Amazon.SecurityHub.Model;

namespace Amazon.PowerShell.Cmdlets.SHUB
{
    /// <summary>
    /// Creates an automation rule based on input parameters.
    /// </summary>
    [Cmdlet("New", "SHUBAutomationRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Security Hub CreateAutomationRule API operation.", Operation = new[] {"CreateAutomationRule"}, SelectReturnType = typeof(Amazon.SecurityHub.Model.CreateAutomationRuleResponse))]
    [AWSCmdletOutput("System.String or Amazon.SecurityHub.Model.CreateAutomationRuleResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SecurityHub.Model.CreateAutomationRuleResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSHUBAutomationRuleCmdlet : AmazonSecurityHubClientCmdlet, IExecutor
    {
        
        #region Parameter Action
        /// <summary>
        /// <para>
        /// <para> One or more actions to update finding fields if a finding matches the conditions
        /// specified in <code>Criteria</code>. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Actions")]
        public Amazon.SecurityHub.Model.AutomationRulesAction[] Action { get; set; }
        #endregion
        
        #region Parameter Criteria_AwsAccountId
        /// <summary>
        /// <para>
        /// <para> The Amazon Web Services account ID in which a finding was generated. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityHub.Model.StringFilter[] Criteria_AwsAccountId { get; set; }
        #endregion
        
        #region Parameter Criteria_CompanyName
        /// <summary>
        /// <para>
        /// <para> The name of the company for the product that generated the finding. For control-based
        /// findings, the company is Amazon Web Services. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityHub.Model.StringFilter[] Criteria_CompanyName { get; set; }
        #endregion
        
        #region Parameter Criteria_ComplianceAssociatedStandardsId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of a standard in which a control is enabled. This field consists
        /// of the resource portion of the Amazon Resource Name (ARN) returned for a standard
        /// in the <a href="https://docs.aws.amazon.com/securityhub/1.0/APIReference/API_DescribeStandards.html">DescribeStandards</a>
        /// API response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityHub.Model.StringFilter[] Criteria_ComplianceAssociatedStandardsId { get; set; }
        #endregion
        
        #region Parameter Criteria_ComplianceSecurityControlId
        /// <summary>
        /// <para>
        /// <para> The security control ID for which a finding was generated. Security control IDs are
        /// the same across standards.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityHub.Model.StringFilter[] Criteria_ComplianceSecurityControlId { get; set; }
        #endregion
        
        #region Parameter Criteria_ComplianceStatus
        /// <summary>
        /// <para>
        /// <para> The result of a security check. This field is only used for findings generated from
        /// controls. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityHub.Model.StringFilter[] Criteria_ComplianceStatus { get; set; }
        #endregion
        
        #region Parameter Criteria_Confidence
        /// <summary>
        /// <para>
        /// <para>The likelihood that a finding accurately identifies the behavior or issue that it
        /// was intended to identify. <code>Confidence</code> is scored on a 0–100 basis using
        /// a ratio scale. A value of <code>0</code> means 0 percent confidence, and a value of
        /// <code>100</code> means 100 percent confidence. For example, a data exfiltration detection
        /// based on a statistical deviation of network traffic has low confidence because an
        /// actual exfiltration hasn't been verified. For more information, see <a href="https://docs.aws.amazon.com/securityhub/latest/userguide/asff-top-level-attributes.html#asff-confidence">Confidence</a>
        /// in the <i>Security Hub User Guide</i>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityHub.Model.NumberFilter[] Criteria_Confidence { get; set; }
        #endregion
        
        #region Parameter Criteria_CreatedAt
        /// <summary>
        /// <para>
        /// <para> A timestamp that indicates when this finding record was created. </para><para>Uses the <code>date-time</code> format specified in <a href="https://tools.ietf.org/html/rfc3339#section-5.6">RFC
        /// 3339 section 5.6, Internet Date/Time Format</a>. The value cannot contain spaces.
        /// For example, <code>2020-03-22T13:22:13.933Z</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityHub.Model.DateFilter[] Criteria_CreatedAt { get; set; }
        #endregion
        
        #region Parameter Criteria_Criticality
        /// <summary>
        /// <para>
        /// <para> The level of importance that is assigned to the resources that are associated with
        /// a finding. <code>Criticality</code> is scored on a 0–100 basis, using a ratio scale
        /// that supports only full integers. A score of <code>0</code> means that the underlying
        /// resources have no criticality, and a score of <code>100</code> is reserved for the
        /// most critical resources. For more information, see <a href="https://docs.aws.amazon.com/securityhub/latest/userguide/asff-top-level-attributes.html#asff-criticality">Criticality</a>
        /// in the <i>Security Hub User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityHub.Model.NumberFilter[] Criteria_Criticality { get; set; }
        #endregion
        
        #region Parameter Criteria_Description
        /// <summary>
        /// <para>
        /// <para> A finding's description. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityHub.Model.StringFilter[] Criteria_Description { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para> A description of the rule. </para>
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
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Criteria_FirstObservedAt
        /// <summary>
        /// <para>
        /// <para> A timestamp that indicates when the potential security issue captured by a finding
        /// was first observed by the security findings product. </para><para>Uses the <code>date-time</code> format specified in <a href="https://tools.ietf.org/html/rfc3339#section-5.6">RFC
        /// 3339 section 5.6, Internet Date/Time Format</a>. The value cannot contain spaces.
        /// For example, <code>2020-03-22T13:22:13.933Z</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityHub.Model.DateFilter[] Criteria_FirstObservedAt { get; set; }
        #endregion
        
        #region Parameter Criteria_GeneratorId
        /// <summary>
        /// <para>
        /// <para> The identifier for the solution-specific component that generated a finding. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityHub.Model.StringFilter[] Criteria_GeneratorId { get; set; }
        #endregion
        
        #region Parameter Criteria_Id
        /// <summary>
        /// <para>
        /// <para> The product-specific identifier for a finding. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityHub.Model.StringFilter[] Criteria_Id { get; set; }
        #endregion
        
        #region Parameter IsTerminal
        /// <summary>
        /// <para>
        /// <para>Specifies whether a rule is the last to be applied with respect to a finding that
        /// matches the rule criteria. This is useful when a finding matches the criteria for
        /// multiple rules, and each rule has different actions. If a rule is terminal, Security
        /// Hub applies the rule action to a finding that matches the rule criteria and doesn't
        /// evaluate other rules for the finding. By default, a rule isn't terminal. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IsTerminal { get; set; }
        #endregion
        
        #region Parameter Criteria_LastObservedAt
        /// <summary>
        /// <para>
        /// <para> A timestamp that indicates when the potential security issue captured by a finding
        /// was most recently observed by the security findings product. </para><para>Uses the <code>date-time</code> format specified in <a href="https://tools.ietf.org/html/rfc3339#section-5.6">RFC
        /// 3339 section 5.6, Internet Date/Time Format</a>. The value cannot contain spaces.
        /// For example, <code>2020-03-22T13:22:13.933Z</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityHub.Model.DateFilter[] Criteria_LastObservedAt { get; set; }
        #endregion
        
        #region Parameter Criteria_NoteText
        /// <summary>
        /// <para>
        /// <para> The text of a user-defined note that's added to a finding. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityHub.Model.StringFilter[] Criteria_NoteText { get; set; }
        #endregion
        
        #region Parameter Criteria_NoteUpdatedAt
        /// <summary>
        /// <para>
        /// <para> The timestamp of when the note was updated. Uses the date-time format specified in
        /// <a href="https://www.rfc-editor.org/rfc/rfc3339#section-5.6">RFC 3339 section 5.6,
        /// Internet Date/Time Format</a>. The value cannot contain spaces. For example, <code>2020-03-22T13:22:13.933Z</code>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityHub.Model.DateFilter[] Criteria_NoteUpdatedAt { get; set; }
        #endregion
        
        #region Parameter Criteria_NoteUpdatedBy
        /// <summary>
        /// <para>
        /// <para> The principal that created a note. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityHub.Model.StringFilter[] Criteria_NoteUpdatedBy { get; set; }
        #endregion
        
        #region Parameter Criteria_ProductArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) for a third-party product that generated a finding
        /// in Security Hub. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityHub.Model.StringFilter[] Criteria_ProductArn { get; set; }
        #endregion
        
        #region Parameter Criteria_ProductName
        /// <summary>
        /// <para>
        /// <para> Provides the name of the product that generated the finding. For control-based findings,
        /// the product name is Security Hub. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityHub.Model.StringFilter[] Criteria_ProductName { get; set; }
        #endregion
        
        #region Parameter Criteria_RecordState
        /// <summary>
        /// <para>
        /// <para> Provides the current state of a finding. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityHub.Model.StringFilter[] Criteria_RecordState { get; set; }
        #endregion
        
        #region Parameter Criteria_RelatedFindingsId
        /// <summary>
        /// <para>
        /// <para> The product-generated identifier for a related finding. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityHub.Model.StringFilter[] Criteria_RelatedFindingsId { get; set; }
        #endregion
        
        #region Parameter Criteria_RelatedFindingsProductArn
        /// <summary>
        /// <para>
        /// <para> The ARN for the product that generated a related finding. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityHub.Model.StringFilter[] Criteria_RelatedFindingsProductArn { get; set; }
        #endregion
        
        #region Parameter Criteria_ResourceDetailsOther
        /// <summary>
        /// <para>
        /// <para> Custom fields and values about the resource that a finding pertains to. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityHub.Model.MapFilter[] Criteria_ResourceDetailsOther { get; set; }
        #endregion
        
        #region Parameter Criteria_ResourceId
        /// <summary>
        /// <para>
        /// <para> The identifier for the given resource type. For Amazon Web Services resources that
        /// are identified by Amazon Resource Names (ARNs), this is the ARN. For Amazon Web Services
        /// resources that lack ARNs, this is the identifier as defined by the Amazon Web Service
        /// that created the resource. For non-Amazon Web Services resources, this is a unique
        /// identifier that is associated with the resource. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityHub.Model.StringFilter[] Criteria_ResourceId { get; set; }
        #endregion
        
        #region Parameter Criteria_ResourcePartition
        /// <summary>
        /// <para>
        /// <para> The partition in which the resource that the finding pertains to is located. A partition
        /// is a group of Amazon Web Services Regions. Each Amazon Web Services account is scoped
        /// to one partition. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityHub.Model.StringFilter[] Criteria_ResourcePartition { get; set; }
        #endregion
        
        #region Parameter Criteria_ResourceRegion
        /// <summary>
        /// <para>
        /// <para> The Amazon Web Services Region where the resource that a finding pertains to is located.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityHub.Model.StringFilter[] Criteria_ResourceRegion { get; set; }
        #endregion
        
        #region Parameter Criteria_ResourceTag
        /// <summary>
        /// <para>
        /// <para> A list of Amazon Web Services tags associated with a resource at the time the finding
        /// was processed. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Criteria_ResourceTags")]
        public Amazon.SecurityHub.Model.MapFilter[] Criteria_ResourceTag { get; set; }
        #endregion
        
        #region Parameter Criteria_ResourceType
        /// <summary>
        /// <para>
        /// <para> The type of resource that the finding pertains to. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityHub.Model.StringFilter[] Criteria_ResourceType { get; set; }
        #endregion
        
        #region Parameter RuleName
        /// <summary>
        /// <para>
        /// <para> The name of the rule. </para>
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
        public System.String RuleName { get; set; }
        #endregion
        
        #region Parameter RuleOrder
        /// <summary>
        /// <para>
        /// <para>An integer ranging from 1 to 1000 that represents the order in which the rule action
        /// is applied to findings. Security Hub applies rules with lower values for this parameter
        /// first. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? RuleOrder { get; set; }
        #endregion
        
        #region Parameter RuleStatus
        /// <summary>
        /// <para>
        /// <para> Whether the rule is active after it is created. If this parameter is equal to <code>ENABLED</code>,
        /// Security Hub starts applying the rule to findings and finding updates after the rule
        /// is created. To change the value of this parameter after creating a rule, use <a href="https://docs.aws.amazon.com/securityhub/1.0/APIReference/API_BatchUpdateAutomationRules.html"><code>BatchUpdateAutomationRules</code></a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SecurityHub.RuleStatus")]
        public Amazon.SecurityHub.RuleStatus RuleStatus { get; set; }
        #endregion
        
        #region Parameter Criteria_SeverityLabel
        /// <summary>
        /// <para>
        /// <para> The severity value of the finding. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityHub.Model.StringFilter[] Criteria_SeverityLabel { get; set; }
        #endregion
        
        #region Parameter Criteria_SourceUrl
        /// <summary>
        /// <para>
        /// <para> Provides a URL that links to a page about the current finding in the finding product.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityHub.Model.StringFilter[] Criteria_SourceUrl { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para> User-defined tags that help you label the purpose of a rule. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Criteria_Title
        /// <summary>
        /// <para>
        /// <para> A finding's title. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityHub.Model.StringFilter[] Criteria_Title { get; set; }
        #endregion
        
        #region Parameter Criteria_Type
        /// <summary>
        /// <para>
        /// <para> One or more finding types in the format of namespace/category/classifier that classify
        /// a finding. For a list of namespaces, classifiers, and categories, see <a href="https://docs.aws.amazon.com/securityhub/latest/userguide/securityhub-findings-format-type-taxonomy.html">Types
        /// taxonomy for ASFF</a> in the <i>Security Hub User Guide</i>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityHub.Model.StringFilter[] Criteria_Type { get; set; }
        #endregion
        
        #region Parameter Criteria_UpdatedAt
        /// <summary>
        /// <para>
        /// <para> A timestamp that indicates when the finding record was most recently updated. </para><para>Uses the <code>date-time</code> format specified in <a href="https://tools.ietf.org/html/rfc3339#section-5.6">RFC
        /// 3339 section 5.6, Internet Date/Time Format</a>. The value cannot contain spaces.
        /// For example, <code>2020-03-22T13:22:13.933Z</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityHub.Model.DateFilter[] Criteria_UpdatedAt { get; set; }
        #endregion
        
        #region Parameter Criteria_UserDefinedField
        /// <summary>
        /// <para>
        /// <para> A list of user-defined name and value string pairs added to a finding. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Criteria_UserDefinedFields")]
        public Amazon.SecurityHub.Model.MapFilter[] Criteria_UserDefinedField { get; set; }
        #endregion
        
        #region Parameter Criteria_VerificationState
        /// <summary>
        /// <para>
        /// <para> Provides the veracity of a finding. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityHub.Model.StringFilter[] Criteria_VerificationState { get; set; }
        #endregion
        
        #region Parameter Criteria_WorkflowStatus
        /// <summary>
        /// <para>
        /// <para> Provides information about the status of the investigation into a finding. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityHub.Model.StringFilter[] Criteria_WorkflowStatus { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RuleArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityHub.Model.CreateAutomationRuleResponse).
        /// Specifying the name of a property of type Amazon.SecurityHub.Model.CreateAutomationRuleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RuleArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RuleName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SHUBAutomationRule (CreateAutomationRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityHub.Model.CreateAutomationRuleResponse, NewSHUBAutomationRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Action != null)
            {
                context.Action = new List<Amazon.SecurityHub.Model.AutomationRulesAction>(this.Action);
            }
            #if MODULAR
            if (this.Action == null && ParameterWasBound(nameof(this.Action)))
            {
                WriteWarning("You are passing $null as a value for parameter Action which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Criteria_AwsAccountId != null)
            {
                context.Criteria_AwsAccountId = new List<Amazon.SecurityHub.Model.StringFilter>(this.Criteria_AwsAccountId);
            }
            if (this.Criteria_CompanyName != null)
            {
                context.Criteria_CompanyName = new List<Amazon.SecurityHub.Model.StringFilter>(this.Criteria_CompanyName);
            }
            if (this.Criteria_ComplianceAssociatedStandardsId != null)
            {
                context.Criteria_ComplianceAssociatedStandardsId = new List<Amazon.SecurityHub.Model.StringFilter>(this.Criteria_ComplianceAssociatedStandardsId);
            }
            if (this.Criteria_ComplianceSecurityControlId != null)
            {
                context.Criteria_ComplianceSecurityControlId = new List<Amazon.SecurityHub.Model.StringFilter>(this.Criteria_ComplianceSecurityControlId);
            }
            if (this.Criteria_ComplianceStatus != null)
            {
                context.Criteria_ComplianceStatus = new List<Amazon.SecurityHub.Model.StringFilter>(this.Criteria_ComplianceStatus);
            }
            if (this.Criteria_Confidence != null)
            {
                context.Criteria_Confidence = new List<Amazon.SecurityHub.Model.NumberFilter>(this.Criteria_Confidence);
            }
            if (this.Criteria_CreatedAt != null)
            {
                context.Criteria_CreatedAt = new List<Amazon.SecurityHub.Model.DateFilter>(this.Criteria_CreatedAt);
            }
            if (this.Criteria_Criticality != null)
            {
                context.Criteria_Criticality = new List<Amazon.SecurityHub.Model.NumberFilter>(this.Criteria_Criticality);
            }
            if (this.Criteria_Description != null)
            {
                context.Criteria_Description = new List<Amazon.SecurityHub.Model.StringFilter>(this.Criteria_Description);
            }
            if (this.Criteria_FirstObservedAt != null)
            {
                context.Criteria_FirstObservedAt = new List<Amazon.SecurityHub.Model.DateFilter>(this.Criteria_FirstObservedAt);
            }
            if (this.Criteria_GeneratorId != null)
            {
                context.Criteria_GeneratorId = new List<Amazon.SecurityHub.Model.StringFilter>(this.Criteria_GeneratorId);
            }
            if (this.Criteria_Id != null)
            {
                context.Criteria_Id = new List<Amazon.SecurityHub.Model.StringFilter>(this.Criteria_Id);
            }
            if (this.Criteria_LastObservedAt != null)
            {
                context.Criteria_LastObservedAt = new List<Amazon.SecurityHub.Model.DateFilter>(this.Criteria_LastObservedAt);
            }
            if (this.Criteria_NoteText != null)
            {
                context.Criteria_NoteText = new List<Amazon.SecurityHub.Model.StringFilter>(this.Criteria_NoteText);
            }
            if (this.Criteria_NoteUpdatedAt != null)
            {
                context.Criteria_NoteUpdatedAt = new List<Amazon.SecurityHub.Model.DateFilter>(this.Criteria_NoteUpdatedAt);
            }
            if (this.Criteria_NoteUpdatedBy != null)
            {
                context.Criteria_NoteUpdatedBy = new List<Amazon.SecurityHub.Model.StringFilter>(this.Criteria_NoteUpdatedBy);
            }
            if (this.Criteria_ProductArn != null)
            {
                context.Criteria_ProductArn = new List<Amazon.SecurityHub.Model.StringFilter>(this.Criteria_ProductArn);
            }
            if (this.Criteria_ProductName != null)
            {
                context.Criteria_ProductName = new List<Amazon.SecurityHub.Model.StringFilter>(this.Criteria_ProductName);
            }
            if (this.Criteria_RecordState != null)
            {
                context.Criteria_RecordState = new List<Amazon.SecurityHub.Model.StringFilter>(this.Criteria_RecordState);
            }
            if (this.Criteria_RelatedFindingsId != null)
            {
                context.Criteria_RelatedFindingsId = new List<Amazon.SecurityHub.Model.StringFilter>(this.Criteria_RelatedFindingsId);
            }
            if (this.Criteria_RelatedFindingsProductArn != null)
            {
                context.Criteria_RelatedFindingsProductArn = new List<Amazon.SecurityHub.Model.StringFilter>(this.Criteria_RelatedFindingsProductArn);
            }
            if (this.Criteria_ResourceDetailsOther != null)
            {
                context.Criteria_ResourceDetailsOther = new List<Amazon.SecurityHub.Model.MapFilter>(this.Criteria_ResourceDetailsOther);
            }
            if (this.Criteria_ResourceId != null)
            {
                context.Criteria_ResourceId = new List<Amazon.SecurityHub.Model.StringFilter>(this.Criteria_ResourceId);
            }
            if (this.Criteria_ResourcePartition != null)
            {
                context.Criteria_ResourcePartition = new List<Amazon.SecurityHub.Model.StringFilter>(this.Criteria_ResourcePartition);
            }
            if (this.Criteria_ResourceRegion != null)
            {
                context.Criteria_ResourceRegion = new List<Amazon.SecurityHub.Model.StringFilter>(this.Criteria_ResourceRegion);
            }
            if (this.Criteria_ResourceTag != null)
            {
                context.Criteria_ResourceTag = new List<Amazon.SecurityHub.Model.MapFilter>(this.Criteria_ResourceTag);
            }
            if (this.Criteria_ResourceType != null)
            {
                context.Criteria_ResourceType = new List<Amazon.SecurityHub.Model.StringFilter>(this.Criteria_ResourceType);
            }
            if (this.Criteria_SeverityLabel != null)
            {
                context.Criteria_SeverityLabel = new List<Amazon.SecurityHub.Model.StringFilter>(this.Criteria_SeverityLabel);
            }
            if (this.Criteria_SourceUrl != null)
            {
                context.Criteria_SourceUrl = new List<Amazon.SecurityHub.Model.StringFilter>(this.Criteria_SourceUrl);
            }
            if (this.Criteria_Title != null)
            {
                context.Criteria_Title = new List<Amazon.SecurityHub.Model.StringFilter>(this.Criteria_Title);
            }
            if (this.Criteria_Type != null)
            {
                context.Criteria_Type = new List<Amazon.SecurityHub.Model.StringFilter>(this.Criteria_Type);
            }
            if (this.Criteria_UpdatedAt != null)
            {
                context.Criteria_UpdatedAt = new List<Amazon.SecurityHub.Model.DateFilter>(this.Criteria_UpdatedAt);
            }
            if (this.Criteria_UserDefinedField != null)
            {
                context.Criteria_UserDefinedField = new List<Amazon.SecurityHub.Model.MapFilter>(this.Criteria_UserDefinedField);
            }
            if (this.Criteria_VerificationState != null)
            {
                context.Criteria_VerificationState = new List<Amazon.SecurityHub.Model.StringFilter>(this.Criteria_VerificationState);
            }
            if (this.Criteria_WorkflowStatus != null)
            {
                context.Criteria_WorkflowStatus = new List<Amazon.SecurityHub.Model.StringFilter>(this.Criteria_WorkflowStatus);
            }
            context.Description = this.Description;
            #if MODULAR
            if (this.Description == null && ParameterWasBound(nameof(this.Description)))
            {
                WriteWarning("You are passing $null as a value for parameter Description which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IsTerminal = this.IsTerminal;
            context.RuleName = this.RuleName;
            #if MODULAR
            if (this.RuleName == null && ParameterWasBound(nameof(this.RuleName)))
            {
                WriteWarning("You are passing $null as a value for parameter RuleName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RuleOrder = this.RuleOrder;
            #if MODULAR
            if (this.RuleOrder == null && ParameterWasBound(nameof(this.RuleOrder)))
            {
                WriteWarning("You are passing $null as a value for parameter RuleOrder which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RuleStatus = this.RuleStatus;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
            }
            
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
            var request = new Amazon.SecurityHub.Model.CreateAutomationRuleRequest();
            
            if (cmdletContext.Action != null)
            {
                request.Actions = cmdletContext.Action;
            }
            
             // populate Criteria
            var requestCriteriaIsNull = true;
            request.Criteria = new Amazon.SecurityHub.Model.AutomationRulesFindingFilters();
            List<Amazon.SecurityHub.Model.StringFilter> requestCriteria_criteria_AwsAccountId = null;
            if (cmdletContext.Criteria_AwsAccountId != null)
            {
                requestCriteria_criteria_AwsAccountId = cmdletContext.Criteria_AwsAccountId;
            }
            if (requestCriteria_criteria_AwsAccountId != null)
            {
                request.Criteria.AwsAccountId = requestCriteria_criteria_AwsAccountId;
                requestCriteriaIsNull = false;
            }
            List<Amazon.SecurityHub.Model.StringFilter> requestCriteria_criteria_CompanyName = null;
            if (cmdletContext.Criteria_CompanyName != null)
            {
                requestCriteria_criteria_CompanyName = cmdletContext.Criteria_CompanyName;
            }
            if (requestCriteria_criteria_CompanyName != null)
            {
                request.Criteria.CompanyName = requestCriteria_criteria_CompanyName;
                requestCriteriaIsNull = false;
            }
            List<Amazon.SecurityHub.Model.StringFilter> requestCriteria_criteria_ComplianceAssociatedStandardsId = null;
            if (cmdletContext.Criteria_ComplianceAssociatedStandardsId != null)
            {
                requestCriteria_criteria_ComplianceAssociatedStandardsId = cmdletContext.Criteria_ComplianceAssociatedStandardsId;
            }
            if (requestCriteria_criteria_ComplianceAssociatedStandardsId != null)
            {
                request.Criteria.ComplianceAssociatedStandardsId = requestCriteria_criteria_ComplianceAssociatedStandardsId;
                requestCriteriaIsNull = false;
            }
            List<Amazon.SecurityHub.Model.StringFilter> requestCriteria_criteria_ComplianceSecurityControlId = null;
            if (cmdletContext.Criteria_ComplianceSecurityControlId != null)
            {
                requestCriteria_criteria_ComplianceSecurityControlId = cmdletContext.Criteria_ComplianceSecurityControlId;
            }
            if (requestCriteria_criteria_ComplianceSecurityControlId != null)
            {
                request.Criteria.ComplianceSecurityControlId = requestCriteria_criteria_ComplianceSecurityControlId;
                requestCriteriaIsNull = false;
            }
            List<Amazon.SecurityHub.Model.StringFilter> requestCriteria_criteria_ComplianceStatus = null;
            if (cmdletContext.Criteria_ComplianceStatus != null)
            {
                requestCriteria_criteria_ComplianceStatus = cmdletContext.Criteria_ComplianceStatus;
            }
            if (requestCriteria_criteria_ComplianceStatus != null)
            {
                request.Criteria.ComplianceStatus = requestCriteria_criteria_ComplianceStatus;
                requestCriteriaIsNull = false;
            }
            List<Amazon.SecurityHub.Model.NumberFilter> requestCriteria_criteria_Confidence = null;
            if (cmdletContext.Criteria_Confidence != null)
            {
                requestCriteria_criteria_Confidence = cmdletContext.Criteria_Confidence;
            }
            if (requestCriteria_criteria_Confidence != null)
            {
                request.Criteria.Confidence = requestCriteria_criteria_Confidence;
                requestCriteriaIsNull = false;
            }
            List<Amazon.SecurityHub.Model.DateFilter> requestCriteria_criteria_CreatedAt = null;
            if (cmdletContext.Criteria_CreatedAt != null)
            {
                requestCriteria_criteria_CreatedAt = cmdletContext.Criteria_CreatedAt;
            }
            if (requestCriteria_criteria_CreatedAt != null)
            {
                request.Criteria.CreatedAt = requestCriteria_criteria_CreatedAt;
                requestCriteriaIsNull = false;
            }
            List<Amazon.SecurityHub.Model.NumberFilter> requestCriteria_criteria_Criticality = null;
            if (cmdletContext.Criteria_Criticality != null)
            {
                requestCriteria_criteria_Criticality = cmdletContext.Criteria_Criticality;
            }
            if (requestCriteria_criteria_Criticality != null)
            {
                request.Criteria.Criticality = requestCriteria_criteria_Criticality;
                requestCriteriaIsNull = false;
            }
            List<Amazon.SecurityHub.Model.StringFilter> requestCriteria_criteria_Description = null;
            if (cmdletContext.Criteria_Description != null)
            {
                requestCriteria_criteria_Description = cmdletContext.Criteria_Description;
            }
            if (requestCriteria_criteria_Description != null)
            {
                request.Criteria.Description = requestCriteria_criteria_Description;
                requestCriteriaIsNull = false;
            }
            List<Amazon.SecurityHub.Model.DateFilter> requestCriteria_criteria_FirstObservedAt = null;
            if (cmdletContext.Criteria_FirstObservedAt != null)
            {
                requestCriteria_criteria_FirstObservedAt = cmdletContext.Criteria_FirstObservedAt;
            }
            if (requestCriteria_criteria_FirstObservedAt != null)
            {
                request.Criteria.FirstObservedAt = requestCriteria_criteria_FirstObservedAt;
                requestCriteriaIsNull = false;
            }
            List<Amazon.SecurityHub.Model.StringFilter> requestCriteria_criteria_GeneratorId = null;
            if (cmdletContext.Criteria_GeneratorId != null)
            {
                requestCriteria_criteria_GeneratorId = cmdletContext.Criteria_GeneratorId;
            }
            if (requestCriteria_criteria_GeneratorId != null)
            {
                request.Criteria.GeneratorId = requestCriteria_criteria_GeneratorId;
                requestCriteriaIsNull = false;
            }
            List<Amazon.SecurityHub.Model.StringFilter> requestCriteria_criteria_Id = null;
            if (cmdletContext.Criteria_Id != null)
            {
                requestCriteria_criteria_Id = cmdletContext.Criteria_Id;
            }
            if (requestCriteria_criteria_Id != null)
            {
                request.Criteria.Id = requestCriteria_criteria_Id;
                requestCriteriaIsNull = false;
            }
            List<Amazon.SecurityHub.Model.DateFilter> requestCriteria_criteria_LastObservedAt = null;
            if (cmdletContext.Criteria_LastObservedAt != null)
            {
                requestCriteria_criteria_LastObservedAt = cmdletContext.Criteria_LastObservedAt;
            }
            if (requestCriteria_criteria_LastObservedAt != null)
            {
                request.Criteria.LastObservedAt = requestCriteria_criteria_LastObservedAt;
                requestCriteriaIsNull = false;
            }
            List<Amazon.SecurityHub.Model.StringFilter> requestCriteria_criteria_NoteText = null;
            if (cmdletContext.Criteria_NoteText != null)
            {
                requestCriteria_criteria_NoteText = cmdletContext.Criteria_NoteText;
            }
            if (requestCriteria_criteria_NoteText != null)
            {
                request.Criteria.NoteText = requestCriteria_criteria_NoteText;
                requestCriteriaIsNull = false;
            }
            List<Amazon.SecurityHub.Model.DateFilter> requestCriteria_criteria_NoteUpdatedAt = null;
            if (cmdletContext.Criteria_NoteUpdatedAt != null)
            {
                requestCriteria_criteria_NoteUpdatedAt = cmdletContext.Criteria_NoteUpdatedAt;
            }
            if (requestCriteria_criteria_NoteUpdatedAt != null)
            {
                request.Criteria.NoteUpdatedAt = requestCriteria_criteria_NoteUpdatedAt;
                requestCriteriaIsNull = false;
            }
            List<Amazon.SecurityHub.Model.StringFilter> requestCriteria_criteria_NoteUpdatedBy = null;
            if (cmdletContext.Criteria_NoteUpdatedBy != null)
            {
                requestCriteria_criteria_NoteUpdatedBy = cmdletContext.Criteria_NoteUpdatedBy;
            }
            if (requestCriteria_criteria_NoteUpdatedBy != null)
            {
                request.Criteria.NoteUpdatedBy = requestCriteria_criteria_NoteUpdatedBy;
                requestCriteriaIsNull = false;
            }
            List<Amazon.SecurityHub.Model.StringFilter> requestCriteria_criteria_ProductArn = null;
            if (cmdletContext.Criteria_ProductArn != null)
            {
                requestCriteria_criteria_ProductArn = cmdletContext.Criteria_ProductArn;
            }
            if (requestCriteria_criteria_ProductArn != null)
            {
                request.Criteria.ProductArn = requestCriteria_criteria_ProductArn;
                requestCriteriaIsNull = false;
            }
            List<Amazon.SecurityHub.Model.StringFilter> requestCriteria_criteria_ProductName = null;
            if (cmdletContext.Criteria_ProductName != null)
            {
                requestCriteria_criteria_ProductName = cmdletContext.Criteria_ProductName;
            }
            if (requestCriteria_criteria_ProductName != null)
            {
                request.Criteria.ProductName = requestCriteria_criteria_ProductName;
                requestCriteriaIsNull = false;
            }
            List<Amazon.SecurityHub.Model.StringFilter> requestCriteria_criteria_RecordState = null;
            if (cmdletContext.Criteria_RecordState != null)
            {
                requestCriteria_criteria_RecordState = cmdletContext.Criteria_RecordState;
            }
            if (requestCriteria_criteria_RecordState != null)
            {
                request.Criteria.RecordState = requestCriteria_criteria_RecordState;
                requestCriteriaIsNull = false;
            }
            List<Amazon.SecurityHub.Model.StringFilter> requestCriteria_criteria_RelatedFindingsId = null;
            if (cmdletContext.Criteria_RelatedFindingsId != null)
            {
                requestCriteria_criteria_RelatedFindingsId = cmdletContext.Criteria_RelatedFindingsId;
            }
            if (requestCriteria_criteria_RelatedFindingsId != null)
            {
                request.Criteria.RelatedFindingsId = requestCriteria_criteria_RelatedFindingsId;
                requestCriteriaIsNull = false;
            }
            List<Amazon.SecurityHub.Model.StringFilter> requestCriteria_criteria_RelatedFindingsProductArn = null;
            if (cmdletContext.Criteria_RelatedFindingsProductArn != null)
            {
                requestCriteria_criteria_RelatedFindingsProductArn = cmdletContext.Criteria_RelatedFindingsProductArn;
            }
            if (requestCriteria_criteria_RelatedFindingsProductArn != null)
            {
                request.Criteria.RelatedFindingsProductArn = requestCriteria_criteria_RelatedFindingsProductArn;
                requestCriteriaIsNull = false;
            }
            List<Amazon.SecurityHub.Model.MapFilter> requestCriteria_criteria_ResourceDetailsOther = null;
            if (cmdletContext.Criteria_ResourceDetailsOther != null)
            {
                requestCriteria_criteria_ResourceDetailsOther = cmdletContext.Criteria_ResourceDetailsOther;
            }
            if (requestCriteria_criteria_ResourceDetailsOther != null)
            {
                request.Criteria.ResourceDetailsOther = requestCriteria_criteria_ResourceDetailsOther;
                requestCriteriaIsNull = false;
            }
            List<Amazon.SecurityHub.Model.StringFilter> requestCriteria_criteria_ResourceId = null;
            if (cmdletContext.Criteria_ResourceId != null)
            {
                requestCriteria_criteria_ResourceId = cmdletContext.Criteria_ResourceId;
            }
            if (requestCriteria_criteria_ResourceId != null)
            {
                request.Criteria.ResourceId = requestCriteria_criteria_ResourceId;
                requestCriteriaIsNull = false;
            }
            List<Amazon.SecurityHub.Model.StringFilter> requestCriteria_criteria_ResourcePartition = null;
            if (cmdletContext.Criteria_ResourcePartition != null)
            {
                requestCriteria_criteria_ResourcePartition = cmdletContext.Criteria_ResourcePartition;
            }
            if (requestCriteria_criteria_ResourcePartition != null)
            {
                request.Criteria.ResourcePartition = requestCriteria_criteria_ResourcePartition;
                requestCriteriaIsNull = false;
            }
            List<Amazon.SecurityHub.Model.StringFilter> requestCriteria_criteria_ResourceRegion = null;
            if (cmdletContext.Criteria_ResourceRegion != null)
            {
                requestCriteria_criteria_ResourceRegion = cmdletContext.Criteria_ResourceRegion;
            }
            if (requestCriteria_criteria_ResourceRegion != null)
            {
                request.Criteria.ResourceRegion = requestCriteria_criteria_ResourceRegion;
                requestCriteriaIsNull = false;
            }
            List<Amazon.SecurityHub.Model.MapFilter> requestCriteria_criteria_ResourceTag = null;
            if (cmdletContext.Criteria_ResourceTag != null)
            {
                requestCriteria_criteria_ResourceTag = cmdletContext.Criteria_ResourceTag;
            }
            if (requestCriteria_criteria_ResourceTag != null)
            {
                request.Criteria.ResourceTags = requestCriteria_criteria_ResourceTag;
                requestCriteriaIsNull = false;
            }
            List<Amazon.SecurityHub.Model.StringFilter> requestCriteria_criteria_ResourceType = null;
            if (cmdletContext.Criteria_ResourceType != null)
            {
                requestCriteria_criteria_ResourceType = cmdletContext.Criteria_ResourceType;
            }
            if (requestCriteria_criteria_ResourceType != null)
            {
                request.Criteria.ResourceType = requestCriteria_criteria_ResourceType;
                requestCriteriaIsNull = false;
            }
            List<Amazon.SecurityHub.Model.StringFilter> requestCriteria_criteria_SeverityLabel = null;
            if (cmdletContext.Criteria_SeverityLabel != null)
            {
                requestCriteria_criteria_SeverityLabel = cmdletContext.Criteria_SeverityLabel;
            }
            if (requestCriteria_criteria_SeverityLabel != null)
            {
                request.Criteria.SeverityLabel = requestCriteria_criteria_SeverityLabel;
                requestCriteriaIsNull = false;
            }
            List<Amazon.SecurityHub.Model.StringFilter> requestCriteria_criteria_SourceUrl = null;
            if (cmdletContext.Criteria_SourceUrl != null)
            {
                requestCriteria_criteria_SourceUrl = cmdletContext.Criteria_SourceUrl;
            }
            if (requestCriteria_criteria_SourceUrl != null)
            {
                request.Criteria.SourceUrl = requestCriteria_criteria_SourceUrl;
                requestCriteriaIsNull = false;
            }
            List<Amazon.SecurityHub.Model.StringFilter> requestCriteria_criteria_Title = null;
            if (cmdletContext.Criteria_Title != null)
            {
                requestCriteria_criteria_Title = cmdletContext.Criteria_Title;
            }
            if (requestCriteria_criteria_Title != null)
            {
                request.Criteria.Title = requestCriteria_criteria_Title;
                requestCriteriaIsNull = false;
            }
            List<Amazon.SecurityHub.Model.StringFilter> requestCriteria_criteria_Type = null;
            if (cmdletContext.Criteria_Type != null)
            {
                requestCriteria_criteria_Type = cmdletContext.Criteria_Type;
            }
            if (requestCriteria_criteria_Type != null)
            {
                request.Criteria.Type = requestCriteria_criteria_Type;
                requestCriteriaIsNull = false;
            }
            List<Amazon.SecurityHub.Model.DateFilter> requestCriteria_criteria_UpdatedAt = null;
            if (cmdletContext.Criteria_UpdatedAt != null)
            {
                requestCriteria_criteria_UpdatedAt = cmdletContext.Criteria_UpdatedAt;
            }
            if (requestCriteria_criteria_UpdatedAt != null)
            {
                request.Criteria.UpdatedAt = requestCriteria_criteria_UpdatedAt;
                requestCriteriaIsNull = false;
            }
            List<Amazon.SecurityHub.Model.MapFilter> requestCriteria_criteria_UserDefinedField = null;
            if (cmdletContext.Criteria_UserDefinedField != null)
            {
                requestCriteria_criteria_UserDefinedField = cmdletContext.Criteria_UserDefinedField;
            }
            if (requestCriteria_criteria_UserDefinedField != null)
            {
                request.Criteria.UserDefinedFields = requestCriteria_criteria_UserDefinedField;
                requestCriteriaIsNull = false;
            }
            List<Amazon.SecurityHub.Model.StringFilter> requestCriteria_criteria_VerificationState = null;
            if (cmdletContext.Criteria_VerificationState != null)
            {
                requestCriteria_criteria_VerificationState = cmdletContext.Criteria_VerificationState;
            }
            if (requestCriteria_criteria_VerificationState != null)
            {
                request.Criteria.VerificationState = requestCriteria_criteria_VerificationState;
                requestCriteriaIsNull = false;
            }
            List<Amazon.SecurityHub.Model.StringFilter> requestCriteria_criteria_WorkflowStatus = null;
            if (cmdletContext.Criteria_WorkflowStatus != null)
            {
                requestCriteria_criteria_WorkflowStatus = cmdletContext.Criteria_WorkflowStatus;
            }
            if (requestCriteria_criteria_WorkflowStatus != null)
            {
                request.Criteria.WorkflowStatus = requestCriteria_criteria_WorkflowStatus;
                requestCriteriaIsNull = false;
            }
             // determine if request.Criteria should be set to null
            if (requestCriteriaIsNull)
            {
                request.Criteria = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.IsTerminal != null)
            {
                request.IsTerminal = cmdletContext.IsTerminal.Value;
            }
            if (cmdletContext.RuleName != null)
            {
                request.RuleName = cmdletContext.RuleName;
            }
            if (cmdletContext.RuleOrder != null)
            {
                request.RuleOrder = cmdletContext.RuleOrder.Value;
            }
            if (cmdletContext.RuleStatus != null)
            {
                request.RuleStatus = cmdletContext.RuleStatus;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.SecurityHub.Model.CreateAutomationRuleResponse CallAWSServiceOperation(IAmazonSecurityHub client, Amazon.SecurityHub.Model.CreateAutomationRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Hub", "CreateAutomationRule");
            try
            {
                #if DESKTOP
                return client.CreateAutomationRule(request);
                #elif CORECLR
                return client.CreateAutomationRuleAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.SecurityHub.Model.AutomationRulesAction> Action { get; set; }
            public List<Amazon.SecurityHub.Model.StringFilter> Criteria_AwsAccountId { get; set; }
            public List<Amazon.SecurityHub.Model.StringFilter> Criteria_CompanyName { get; set; }
            public List<Amazon.SecurityHub.Model.StringFilter> Criteria_ComplianceAssociatedStandardsId { get; set; }
            public List<Amazon.SecurityHub.Model.StringFilter> Criteria_ComplianceSecurityControlId { get; set; }
            public List<Amazon.SecurityHub.Model.StringFilter> Criteria_ComplianceStatus { get; set; }
            public List<Amazon.SecurityHub.Model.NumberFilter> Criteria_Confidence { get; set; }
            public List<Amazon.SecurityHub.Model.DateFilter> Criteria_CreatedAt { get; set; }
            public List<Amazon.SecurityHub.Model.NumberFilter> Criteria_Criticality { get; set; }
            public List<Amazon.SecurityHub.Model.StringFilter> Criteria_Description { get; set; }
            public List<Amazon.SecurityHub.Model.DateFilter> Criteria_FirstObservedAt { get; set; }
            public List<Amazon.SecurityHub.Model.StringFilter> Criteria_GeneratorId { get; set; }
            public List<Amazon.SecurityHub.Model.StringFilter> Criteria_Id { get; set; }
            public List<Amazon.SecurityHub.Model.DateFilter> Criteria_LastObservedAt { get; set; }
            public List<Amazon.SecurityHub.Model.StringFilter> Criteria_NoteText { get; set; }
            public List<Amazon.SecurityHub.Model.DateFilter> Criteria_NoteUpdatedAt { get; set; }
            public List<Amazon.SecurityHub.Model.StringFilter> Criteria_NoteUpdatedBy { get; set; }
            public List<Amazon.SecurityHub.Model.StringFilter> Criteria_ProductArn { get; set; }
            public List<Amazon.SecurityHub.Model.StringFilter> Criteria_ProductName { get; set; }
            public List<Amazon.SecurityHub.Model.StringFilter> Criteria_RecordState { get; set; }
            public List<Amazon.SecurityHub.Model.StringFilter> Criteria_RelatedFindingsId { get; set; }
            public List<Amazon.SecurityHub.Model.StringFilter> Criteria_RelatedFindingsProductArn { get; set; }
            public List<Amazon.SecurityHub.Model.MapFilter> Criteria_ResourceDetailsOther { get; set; }
            public List<Amazon.SecurityHub.Model.StringFilter> Criteria_ResourceId { get; set; }
            public List<Amazon.SecurityHub.Model.StringFilter> Criteria_ResourcePartition { get; set; }
            public List<Amazon.SecurityHub.Model.StringFilter> Criteria_ResourceRegion { get; set; }
            public List<Amazon.SecurityHub.Model.MapFilter> Criteria_ResourceTag { get; set; }
            public List<Amazon.SecurityHub.Model.StringFilter> Criteria_ResourceType { get; set; }
            public List<Amazon.SecurityHub.Model.StringFilter> Criteria_SeverityLabel { get; set; }
            public List<Amazon.SecurityHub.Model.StringFilter> Criteria_SourceUrl { get; set; }
            public List<Amazon.SecurityHub.Model.StringFilter> Criteria_Title { get; set; }
            public List<Amazon.SecurityHub.Model.StringFilter> Criteria_Type { get; set; }
            public List<Amazon.SecurityHub.Model.DateFilter> Criteria_UpdatedAt { get; set; }
            public List<Amazon.SecurityHub.Model.MapFilter> Criteria_UserDefinedField { get; set; }
            public List<Amazon.SecurityHub.Model.StringFilter> Criteria_VerificationState { get; set; }
            public List<Amazon.SecurityHub.Model.StringFilter> Criteria_WorkflowStatus { get; set; }
            public System.String Description { get; set; }
            public System.Boolean? IsTerminal { get; set; }
            public System.String RuleName { get; set; }
            public System.Int32? RuleOrder { get; set; }
            public Amazon.SecurityHub.RuleStatus RuleStatus { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.SecurityHub.Model.CreateAutomationRuleResponse, NewSHUBAutomationRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RuleArn;
        }
        
    }
}
