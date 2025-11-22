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
using Amazon.ComputeOptimizerAutomation;
using Amazon.ComputeOptimizerAutomation.Model;

namespace Amazon.PowerShell.Cmdlets.COA
{
    /// <summary>
    /// Creates a new automation rule to apply recommended actions to resources based on
    /// specified criteria.
    /// </summary>
    [Cmdlet("New", "COAAutomationRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ComputeOptimizerAutomation.Model.CreateAutomationRuleResponse")]
    [AWSCmdlet("Calls the Compute Optimizer Automation Service CreateAutomationRule API operation.", Operation = new[] {"CreateAutomationRule"}, SelectReturnType = typeof(Amazon.ComputeOptimizerAutomation.Model.CreateAutomationRuleResponse))]
    [AWSCmdletOutput("Amazon.ComputeOptimizerAutomation.Model.CreateAutomationRuleResponse",
        "This cmdlet returns an Amazon.ComputeOptimizerAutomation.Model.CreateAutomationRuleResponse object containing multiple properties."
    )]
    public partial class NewCOAAutomationRuleCmdlet : AmazonComputeOptimizerAutomationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter OrganizationConfiguration_AccountId
        /// <summary>
        /// <para>
        /// <para>List of specific Amazon Web Services account IDs where the organization rule should
        /// be applied.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OrganizationConfiguration_AccountIds")]
        public System.String[] OrganizationConfiguration_AccountId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para> A description of the automation rule. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Criteria_EbsVolumeSizeInGib
        /// <summary>
        /// <para>
        /// <para>Filter criteria for EBS volume sizes in gibibytes (GiB).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ComputeOptimizerAutomation.Model.IntegerCriteriaCondition[] Criteria_EbsVolumeSizeInGib { get; set; }
        #endregion
        
        #region Parameter Criteria_EbsVolumeType
        /// <summary>
        /// <para>
        /// <para>Filter criteria for EBS volume types, such as gp2, gp3, io1, io2, st1, or sc1.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ComputeOptimizerAutomation.Model.StringCriteriaCondition[] Criteria_EbsVolumeType { get; set; }
        #endregion
        
        #region Parameter Criteria_EstimatedMonthlySaving
        /// <summary>
        /// <para>
        /// <para>Filter criteria for estimated monthly cost savings from the recommended action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Criteria_EstimatedMonthlySavings")]
        public Amazon.ComputeOptimizerAutomation.Model.DoubleCriteriaCondition[] Criteria_EstimatedMonthlySaving { get; set; }
        #endregion
        
        #region Parameter Schedule_ExecutionWindowInMinute
        /// <summary>
        /// <para>
        /// <para>The time window in minutes during which the automation rule can start implementing
        /// recommended actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Schedule_ExecutionWindowInMinutes")]
        public System.Int32? Schedule_ExecutionWindowInMinute { get; set; }
        #endregion
        
        #region Parameter Criteria_LookBackPeriodInDay
        /// <summary>
        /// <para>
        /// <para>Filter criteria for the lookback period in days used to analyze resource utilization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Criteria_LookBackPeriodInDays")]
        public Amazon.ComputeOptimizerAutomation.Model.IntegerCriteriaCondition[] Criteria_LookBackPeriodInDay { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para> The name of the automation rule. </para>
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
        
        #region Parameter Priority
        /// <summary>
        /// <para>
        /// <para>A string representation of a decimal number between 0 and 1 (having up to 30 digits
        /// after the decimal point) that determines the priority of the rule. When multiple rules
        /// match the same recommended action, Compute Optimizer assigns the action to the rule
        /// with the lowest priority value (highest priority), even if that rule is scheduled
        /// to run later than other matching rules. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Priority { get; set; }
        #endregion
        
        #region Parameter RecommendedActionType
        /// <summary>
        /// <para>
        /// <para> The types of recommended actions this rule will automate. </para>
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
        [Alias("RecommendedActionTypes")]
        public System.String[] RecommendedActionType { get; set; }
        #endregion
        
        #region Parameter Criteria_Region
        /// <summary>
        /// <para>
        /// <para>Filter criteria for Amazon Web Services regions where resources must be located.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ComputeOptimizerAutomation.Model.StringCriteriaCondition[] Criteria_Region { get; set; }
        #endregion
        
        #region Parameter Criteria_ResourceArn
        /// <summary>
        /// <para>
        /// <para>Filter criteria for specific resource ARNs to include or exclude.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ComputeOptimizerAutomation.Model.StringCriteriaCondition[] Criteria_ResourceArn { get; set; }
        #endregion
        
        #region Parameter Criteria_ResourceTag
        /// <summary>
        /// <para>
        /// <para>Filter criteria for resource tags, allowing filtering by tag key and value combinations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ComputeOptimizerAutomation.Model.ResourceTagsCriteriaCondition[] Criteria_ResourceTag { get; set; }
        #endregion
        
        #region Parameter Criteria_RestartNeeded
        /// <summary>
        /// <para>
        /// <para>Filter criteria indicating whether the recommended action requires a resource restart.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ComputeOptimizerAutomation.Model.StringCriteriaCondition[] Criteria_RestartNeeded { get; set; }
        #endregion
        
        #region Parameter OrganizationConfiguration_RuleApplyOrder
        /// <summary>
        /// <para>
        /// <para>Specifies when organization rules should be applied relative to account rules.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ComputeOptimizerAutomation.RuleApplyOrder")]
        public Amazon.ComputeOptimizerAutomation.RuleApplyOrder OrganizationConfiguration_RuleApplyOrder { get; set; }
        #endregion
        
        #region Parameter RuleType
        /// <summary>
        /// <para>
        /// <para> The type of rule. </para><note><para>Only the management account or a delegated administrator can set the ruleType to be
        /// OrganizationRule.</para></note>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ComputeOptimizerAutomation.RuleType")]
        public Amazon.ComputeOptimizerAutomation.RuleType RuleType { get; set; }
        #endregion
        
        #region Parameter Schedule_ScheduleExpression
        /// <summary>
        /// <para>
        /// <para>The expression that defines when the schedule runs. <c>cron</c> expression is supported.
        /// A <c>cron</c> expression consists of six fields separated by white spaces: (<c>minutes</c><c>hours</c><c>day_of_month</c><c>month</c><c>day_of_week</c><c>year</c>)</para><note><para>You can schedule rules to run at most once per day. Your cron expression must use
        /// specific values (not wildcards) for the minutes and hours fields. For example: (<c>30
        /// 12 * * *</c>) runs daily at 12:30 PM UTC.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Schedule_ScheduleExpression { get; set; }
        #endregion
        
        #region Parameter Schedule_ScheduleExpressionTimezone
        /// <summary>
        /// <para>
        /// <para>The timezone to use when interpreting the schedule expression.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Schedule_ScheduleExpressionTimezone { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The status of the rule </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ComputeOptimizerAutomation.RuleStatus")]
        public Amazon.ComputeOptimizerAutomation.RuleStatus Status { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para> The tags to associate with the rule. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ComputeOptimizerAutomation.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para> A unique identifier to ensure idempotency of the request. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ComputeOptimizerAutomation.Model.CreateAutomationRuleResponse).
        /// Specifying the name of a property of type Amazon.ComputeOptimizerAutomation.Model.CreateAutomationRuleResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-COAAutomationRule (CreateAutomationRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ComputeOptimizerAutomation.Model.CreateAutomationRuleResponse, NewCOAAutomationRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            if (this.Criteria_EbsVolumeSizeInGib != null)
            {
                context.Criteria_EbsVolumeSizeInGib = new List<Amazon.ComputeOptimizerAutomation.Model.IntegerCriteriaCondition>(this.Criteria_EbsVolumeSizeInGib);
            }
            if (this.Criteria_EbsVolumeType != null)
            {
                context.Criteria_EbsVolumeType = new List<Amazon.ComputeOptimizerAutomation.Model.StringCriteriaCondition>(this.Criteria_EbsVolumeType);
            }
            if (this.Criteria_EstimatedMonthlySaving != null)
            {
                context.Criteria_EstimatedMonthlySaving = new List<Amazon.ComputeOptimizerAutomation.Model.DoubleCriteriaCondition>(this.Criteria_EstimatedMonthlySaving);
            }
            if (this.Criteria_LookBackPeriodInDay != null)
            {
                context.Criteria_LookBackPeriodInDay = new List<Amazon.ComputeOptimizerAutomation.Model.IntegerCriteriaCondition>(this.Criteria_LookBackPeriodInDay);
            }
            if (this.Criteria_Region != null)
            {
                context.Criteria_Region = new List<Amazon.ComputeOptimizerAutomation.Model.StringCriteriaCondition>(this.Criteria_Region);
            }
            if (this.Criteria_ResourceArn != null)
            {
                context.Criteria_ResourceArn = new List<Amazon.ComputeOptimizerAutomation.Model.StringCriteriaCondition>(this.Criteria_ResourceArn);
            }
            if (this.Criteria_ResourceTag != null)
            {
                context.Criteria_ResourceTag = new List<Amazon.ComputeOptimizerAutomation.Model.ResourceTagsCriteriaCondition>(this.Criteria_ResourceTag);
            }
            if (this.Criteria_RestartNeeded != null)
            {
                context.Criteria_RestartNeeded = new List<Amazon.ComputeOptimizerAutomation.Model.StringCriteriaCondition>(this.Criteria_RestartNeeded);
            }
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.OrganizationConfiguration_AccountId != null)
            {
                context.OrganizationConfiguration_AccountId = new List<System.String>(this.OrganizationConfiguration_AccountId);
            }
            context.OrganizationConfiguration_RuleApplyOrder = this.OrganizationConfiguration_RuleApplyOrder;
            context.Priority = this.Priority;
            if (this.RecommendedActionType != null)
            {
                context.RecommendedActionType = new List<System.String>(this.RecommendedActionType);
            }
            #if MODULAR
            if (this.RecommendedActionType == null && ParameterWasBound(nameof(this.RecommendedActionType)))
            {
                WriteWarning("You are passing $null as a value for parameter RecommendedActionType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RuleType = this.RuleType;
            #if MODULAR
            if (this.RuleType == null && ParameterWasBound(nameof(this.RuleType)))
            {
                WriteWarning("You are passing $null as a value for parameter RuleType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Schedule_ExecutionWindowInMinute = this.Schedule_ExecutionWindowInMinute;
            context.Schedule_ScheduleExpression = this.Schedule_ScheduleExpression;
            context.Schedule_ScheduleExpressionTimezone = this.Schedule_ScheduleExpressionTimezone;
            context.Status = this.Status;
            #if MODULAR
            if (this.Status == null && ParameterWasBound(nameof(this.Status)))
            {
                WriteWarning("You are passing $null as a value for parameter Status which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ComputeOptimizerAutomation.Model.Tag>(this.Tag);
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
            var request = new Amazon.ComputeOptimizerAutomation.Model.CreateAutomationRuleRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate Criteria
            var requestCriteriaIsNull = true;
            request.Criteria = new Amazon.ComputeOptimizerAutomation.Model.Criteria();
            List<Amazon.ComputeOptimizerAutomation.Model.IntegerCriteriaCondition> requestCriteria_criteria_EbsVolumeSizeInGib = null;
            if (cmdletContext.Criteria_EbsVolumeSizeInGib != null)
            {
                requestCriteria_criteria_EbsVolumeSizeInGib = cmdletContext.Criteria_EbsVolumeSizeInGib;
            }
            if (requestCriteria_criteria_EbsVolumeSizeInGib != null)
            {
                request.Criteria.EbsVolumeSizeInGib = requestCriteria_criteria_EbsVolumeSizeInGib;
                requestCriteriaIsNull = false;
            }
            List<Amazon.ComputeOptimizerAutomation.Model.StringCriteriaCondition> requestCriteria_criteria_EbsVolumeType = null;
            if (cmdletContext.Criteria_EbsVolumeType != null)
            {
                requestCriteria_criteria_EbsVolumeType = cmdletContext.Criteria_EbsVolumeType;
            }
            if (requestCriteria_criteria_EbsVolumeType != null)
            {
                request.Criteria.EbsVolumeType = requestCriteria_criteria_EbsVolumeType;
                requestCriteriaIsNull = false;
            }
            List<Amazon.ComputeOptimizerAutomation.Model.DoubleCriteriaCondition> requestCriteria_criteria_EstimatedMonthlySaving = null;
            if (cmdletContext.Criteria_EstimatedMonthlySaving != null)
            {
                requestCriteria_criteria_EstimatedMonthlySaving = cmdletContext.Criteria_EstimatedMonthlySaving;
            }
            if (requestCriteria_criteria_EstimatedMonthlySaving != null)
            {
                request.Criteria.EstimatedMonthlySavings = requestCriteria_criteria_EstimatedMonthlySaving;
                requestCriteriaIsNull = false;
            }
            List<Amazon.ComputeOptimizerAutomation.Model.IntegerCriteriaCondition> requestCriteria_criteria_LookBackPeriodInDay = null;
            if (cmdletContext.Criteria_LookBackPeriodInDay != null)
            {
                requestCriteria_criteria_LookBackPeriodInDay = cmdletContext.Criteria_LookBackPeriodInDay;
            }
            if (requestCriteria_criteria_LookBackPeriodInDay != null)
            {
                request.Criteria.LookBackPeriodInDays = requestCriteria_criteria_LookBackPeriodInDay;
                requestCriteriaIsNull = false;
            }
            List<Amazon.ComputeOptimizerAutomation.Model.StringCriteriaCondition> requestCriteria_criteria_Region = null;
            if (cmdletContext.Criteria_Region != null)
            {
                requestCriteria_criteria_Region = cmdletContext.Criteria_Region;
            }
            if (requestCriteria_criteria_Region != null)
            {
                request.Criteria.Region = requestCriteria_criteria_Region;
                requestCriteriaIsNull = false;
            }
            List<Amazon.ComputeOptimizerAutomation.Model.StringCriteriaCondition> requestCriteria_criteria_ResourceArn = null;
            if (cmdletContext.Criteria_ResourceArn != null)
            {
                requestCriteria_criteria_ResourceArn = cmdletContext.Criteria_ResourceArn;
            }
            if (requestCriteria_criteria_ResourceArn != null)
            {
                request.Criteria.ResourceArn = requestCriteria_criteria_ResourceArn;
                requestCriteriaIsNull = false;
            }
            List<Amazon.ComputeOptimizerAutomation.Model.ResourceTagsCriteriaCondition> requestCriteria_criteria_ResourceTag = null;
            if (cmdletContext.Criteria_ResourceTag != null)
            {
                requestCriteria_criteria_ResourceTag = cmdletContext.Criteria_ResourceTag;
            }
            if (requestCriteria_criteria_ResourceTag != null)
            {
                request.Criteria.ResourceTag = requestCriteria_criteria_ResourceTag;
                requestCriteriaIsNull = false;
            }
            List<Amazon.ComputeOptimizerAutomation.Model.StringCriteriaCondition> requestCriteria_criteria_RestartNeeded = null;
            if (cmdletContext.Criteria_RestartNeeded != null)
            {
                requestCriteria_criteria_RestartNeeded = cmdletContext.Criteria_RestartNeeded;
            }
            if (requestCriteria_criteria_RestartNeeded != null)
            {
                request.Criteria.RestartNeeded = requestCriteria_criteria_RestartNeeded;
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
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate OrganizationConfiguration
            var requestOrganizationConfigurationIsNull = true;
            request.OrganizationConfiguration = new Amazon.ComputeOptimizerAutomation.Model.OrganizationConfiguration();
            List<System.String> requestOrganizationConfiguration_organizationConfiguration_AccountId = null;
            if (cmdletContext.OrganizationConfiguration_AccountId != null)
            {
                requestOrganizationConfiguration_organizationConfiguration_AccountId = cmdletContext.OrganizationConfiguration_AccountId;
            }
            if (requestOrganizationConfiguration_organizationConfiguration_AccountId != null)
            {
                request.OrganizationConfiguration.AccountIds = requestOrganizationConfiguration_organizationConfiguration_AccountId;
                requestOrganizationConfigurationIsNull = false;
            }
            Amazon.ComputeOptimizerAutomation.RuleApplyOrder requestOrganizationConfiguration_organizationConfiguration_RuleApplyOrder = null;
            if (cmdletContext.OrganizationConfiguration_RuleApplyOrder != null)
            {
                requestOrganizationConfiguration_organizationConfiguration_RuleApplyOrder = cmdletContext.OrganizationConfiguration_RuleApplyOrder;
            }
            if (requestOrganizationConfiguration_organizationConfiguration_RuleApplyOrder != null)
            {
                request.OrganizationConfiguration.RuleApplyOrder = requestOrganizationConfiguration_organizationConfiguration_RuleApplyOrder;
                requestOrganizationConfigurationIsNull = false;
            }
             // determine if request.OrganizationConfiguration should be set to null
            if (requestOrganizationConfigurationIsNull)
            {
                request.OrganizationConfiguration = null;
            }
            if (cmdletContext.Priority != null)
            {
                request.Priority = cmdletContext.Priority;
            }
            if (cmdletContext.RecommendedActionType != null)
            {
                request.RecommendedActionTypes = cmdletContext.RecommendedActionType;
            }
            if (cmdletContext.RuleType != null)
            {
                request.RuleType = cmdletContext.RuleType;
            }
            
             // populate Schedule
            var requestScheduleIsNull = true;
            request.Schedule = new Amazon.ComputeOptimizerAutomation.Model.Schedule();
            System.Int32? requestSchedule_schedule_ExecutionWindowInMinute = null;
            if (cmdletContext.Schedule_ExecutionWindowInMinute != null)
            {
                requestSchedule_schedule_ExecutionWindowInMinute = cmdletContext.Schedule_ExecutionWindowInMinute.Value;
            }
            if (requestSchedule_schedule_ExecutionWindowInMinute != null)
            {
                request.Schedule.ExecutionWindowInMinutes = requestSchedule_schedule_ExecutionWindowInMinute.Value;
                requestScheduleIsNull = false;
            }
            System.String requestSchedule_schedule_ScheduleExpression = null;
            if (cmdletContext.Schedule_ScheduleExpression != null)
            {
                requestSchedule_schedule_ScheduleExpression = cmdletContext.Schedule_ScheduleExpression;
            }
            if (requestSchedule_schedule_ScheduleExpression != null)
            {
                request.Schedule.ScheduleExpression = requestSchedule_schedule_ScheduleExpression;
                requestScheduleIsNull = false;
            }
            System.String requestSchedule_schedule_ScheduleExpressionTimezone = null;
            if (cmdletContext.Schedule_ScheduleExpressionTimezone != null)
            {
                requestSchedule_schedule_ScheduleExpressionTimezone = cmdletContext.Schedule_ScheduleExpressionTimezone;
            }
            if (requestSchedule_schedule_ScheduleExpressionTimezone != null)
            {
                request.Schedule.ScheduleExpressionTimezone = requestSchedule_schedule_ScheduleExpressionTimezone;
                requestScheduleIsNull = false;
            }
             // determine if request.Schedule should be set to null
            if (requestScheduleIsNull)
            {
                request.Schedule = null;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
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
        
        private Amazon.ComputeOptimizerAutomation.Model.CreateAutomationRuleResponse CallAWSServiceOperation(IAmazonComputeOptimizerAutomation client, Amazon.ComputeOptimizerAutomation.Model.CreateAutomationRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Compute Optimizer Automation Service", "CreateAutomationRule");
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
            public System.String ClientToken { get; set; }
            public List<Amazon.ComputeOptimizerAutomation.Model.IntegerCriteriaCondition> Criteria_EbsVolumeSizeInGib { get; set; }
            public List<Amazon.ComputeOptimizerAutomation.Model.StringCriteriaCondition> Criteria_EbsVolumeType { get; set; }
            public List<Amazon.ComputeOptimizerAutomation.Model.DoubleCriteriaCondition> Criteria_EstimatedMonthlySaving { get; set; }
            public List<Amazon.ComputeOptimizerAutomation.Model.IntegerCriteriaCondition> Criteria_LookBackPeriodInDay { get; set; }
            public List<Amazon.ComputeOptimizerAutomation.Model.StringCriteriaCondition> Criteria_Region { get; set; }
            public List<Amazon.ComputeOptimizerAutomation.Model.StringCriteriaCondition> Criteria_ResourceArn { get; set; }
            public List<Amazon.ComputeOptimizerAutomation.Model.ResourceTagsCriteriaCondition> Criteria_ResourceTag { get; set; }
            public List<Amazon.ComputeOptimizerAutomation.Model.StringCriteriaCondition> Criteria_RestartNeeded { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public List<System.String> OrganizationConfiguration_AccountId { get; set; }
            public Amazon.ComputeOptimizerAutomation.RuleApplyOrder OrganizationConfiguration_RuleApplyOrder { get; set; }
            public System.String Priority { get; set; }
            public List<System.String> RecommendedActionType { get; set; }
            public Amazon.ComputeOptimizerAutomation.RuleType RuleType { get; set; }
            public System.Int32? Schedule_ExecutionWindowInMinute { get; set; }
            public System.String Schedule_ScheduleExpression { get; set; }
            public System.String Schedule_ScheduleExpressionTimezone { get; set; }
            public Amazon.ComputeOptimizerAutomation.RuleStatus Status { get; set; }
            public List<Amazon.ComputeOptimizerAutomation.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.ComputeOptimizerAutomation.Model.CreateAutomationRuleResponse, NewCOAAutomationRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
