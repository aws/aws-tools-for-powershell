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
using Amazon.Budgets;
using Amazon.Budgets.Model;

namespace Amazon.PowerShell.Cmdlets.BGT
{
    /// <summary>
    /// Creates a budget and, if included, notifications and subscribers. 
    /// 
    ///  <important><para>
    /// Only one of <c>BudgetLimit</c> or <c>PlannedBudgetLimits</c> can be present in the
    /// syntax at one time. Use the syntax that matches your case. The Request Syntax section
    /// shows the <c>BudgetLimit</c> syntax. For <c>PlannedBudgetLimits</c>, see the <a href="https://docs.aws.amazon.com/aws-cost-management/latest/APIReference/API_budgets_CreateBudget.html#API_CreateBudget_Examples">Examples</a>
    /// section. 
    /// </para></important>
    /// </summary>
    [Cmdlet("New", "BGTBudget", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Budgets CreateBudget API operation.", Operation = new[] {"CreateBudget"}, SelectReturnType = typeof(Amazon.Budgets.Model.CreateBudgetResponse))]
    [AWSCmdletOutput("None or Amazon.Budgets.Model.CreateBudgetResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Budgets.Model.CreateBudgetResponse) be returned by specifying '-Select *'."
    )]
    public partial class NewBGTBudgetCmdlet : AmazonBudgetsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The <c>accountId</c> that is associated with the budget.</para>
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
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter BudgetLimit_Amount
        /// <summary>
        /// <para>
        /// <para>The cost or usage amount that's associated with a budget forecast, actual spend, or
        /// budget threshold.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Budget_BudgetLimit_Amount")]
        public System.Decimal? BudgetLimit_Amount { get; set; }
        #endregion
        
        #region Parameter ActualSpend_Amount
        /// <summary>
        /// <para>
        /// <para>The cost or usage amount that's associated with a budget forecast, actual spend, or
        /// budget threshold.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Budget_CalculatedSpend_ActualSpend_Amount")]
        public System.Decimal? ActualSpend_Amount { get; set; }
        #endregion
        
        #region Parameter ForecastedSpend_Amount
        /// <summary>
        /// <para>
        /// <para>The cost or usage amount that's associated with a budget forecast, actual spend, or
        /// budget threshold.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Budget_CalculatedSpend_ForecastedSpend_Amount")]
        public System.Decimal? ForecastedSpend_Amount { get; set; }
        #endregion
        
        #region Parameter AutoAdjustData_AutoAdjustType
        /// <summary>
        /// <para>
        /// <para>The string that defines whether your budget auto-adjusts based on historical or forecasted
        /// data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Budget_AutoAdjustData_AutoAdjustType")]
        [AWSConstantClassSource("Amazon.Budgets.AutoAdjustType")]
        public Amazon.Budgets.AutoAdjustType AutoAdjustData_AutoAdjustType { get; set; }
        #endregion
        
        #region Parameter HistoricalOptions_BudgetAdjustmentPeriod
        /// <summary>
        /// <para>
        /// <para>The number of budget periods included in the moving-average calculation that determines
        /// your auto-adjusted budget amount. The maximum value depends on the <c>TimeUnit</c>
        /// granularity of the budget:</para><ul><li><para>For the <c>DAILY</c> granularity, the maximum value is <c>60</c>.</para></li><li><para>For the <c>MONTHLY</c> granularity, the maximum value is <c>12</c>.</para></li><li><para>For the <c>QUARTERLY</c> granularity, the maximum value is <c>4</c>.</para></li><li><para>For the <c>ANNUALLY</c> granularity, the maximum value is <c>1</c>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Budget_AutoAdjustData_HistoricalOptions_BudgetAdjustmentPeriod")]
        public System.Int32? HistoricalOptions_BudgetAdjustmentPeriod { get; set; }
        #endregion
        
        #region Parameter Budget_BudgetName
        /// <summary>
        /// <para>
        /// <para>The name of a budget. The name must be unique within an account. The <c>:</c> and
        /// <c>\</c> characters, and the "/action/" substring, aren't allowed in <c>BudgetName</c>.</para>
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
        public System.String Budget_BudgetName { get; set; }
        #endregion
        
        #region Parameter Budget_BudgetType
        /// <summary>
        /// <para>
        /// <para>Specifies whether this budget tracks costs, usage, RI utilization, RI coverage, Savings
        /// Plans utilization, or Savings Plans coverage.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Budgets.BudgetType")]
        public Amazon.Budgets.BudgetType Budget_BudgetType { get; set; }
        #endregion
        
        #region Parameter Budget_CostFilter
        /// <summary>
        /// <para>
        /// <para>The cost filters, such as <c>Region</c>, <c>Service</c>, <c>LinkedAccount</c>, <c>Tag</c>,
        /// or <c>CostCategory</c>, that are applied to a budget.</para><para>Amazon Web Services Budgets supports the following services as a <c>Service</c> filter
        /// for RI budgets:</para><ul><li><para>Amazon EC2</para></li><li><para>Amazon Redshift</para></li><li><para>Amazon Relational Database Service</para></li><li><para>Amazon ElastiCache</para></li><li><para>Amazon OpenSearch Service</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Budget_CostFilters")]
        public System.Collections.Hashtable Budget_CostFilter { get; set; }
        #endregion
        
        #region Parameter TimePeriod_End
        /// <summary>
        /// <para>
        /// <para>The end date for a budget. If you didn't specify an end date, Amazon Web Services
        /// set your end date to <c>06/15/87 00:00 UTC</c>. The defaults are the same for the
        /// Billing and Cost Management console and the API.</para><para>After the end date, Amazon Web Services deletes the budget and all the associated
        /// notifications and subscribers. You can change your end date with the <c>UpdateBudget</c>
        /// operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Budget_TimePeriod_End")]
        public System.DateTime? TimePeriod_End { get; set; }
        #endregion
        
        #region Parameter CostTypes_IncludeCredit
        /// <summary>
        /// <para>
        /// <para>Specifies whether a budget includes credits.</para><para>The default value is <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Budget_CostTypes_IncludeCredit")]
        public System.Boolean? CostTypes_IncludeCredit { get; set; }
        #endregion
        
        #region Parameter CostTypes_IncludeDiscount
        /// <summary>
        /// <para>
        /// <para>Specifies whether a budget includes discounts.</para><para>The default value is <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Budget_CostTypes_IncludeDiscount")]
        public System.Boolean? CostTypes_IncludeDiscount { get; set; }
        #endregion
        
        #region Parameter CostTypes_IncludeOtherSubscription
        /// <summary>
        /// <para>
        /// <para>Specifies whether a budget includes non-RI subscription costs.</para><para>The default value is <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Budget_CostTypes_IncludeOtherSubscription")]
        public System.Boolean? CostTypes_IncludeOtherSubscription { get; set; }
        #endregion
        
        #region Parameter CostTypes_IncludeRecurring
        /// <summary>
        /// <para>
        /// <para>Specifies whether a budget includes recurring fees such as monthly RI fees.</para><para>The default value is <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Budget_CostTypes_IncludeRecurring")]
        public System.Boolean? CostTypes_IncludeRecurring { get; set; }
        #endregion
        
        #region Parameter CostTypes_IncludeRefund
        /// <summary>
        /// <para>
        /// <para>Specifies whether a budget includes refunds.</para><para>The default value is <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Budget_CostTypes_IncludeRefund")]
        public System.Boolean? CostTypes_IncludeRefund { get; set; }
        #endregion
        
        #region Parameter CostTypes_IncludeSubscription
        /// <summary>
        /// <para>
        /// <para>Specifies whether a budget includes subscriptions.</para><para>The default value is <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Budget_CostTypes_IncludeSubscription")]
        public System.Boolean? CostTypes_IncludeSubscription { get; set; }
        #endregion
        
        #region Parameter CostTypes_IncludeSupport
        /// <summary>
        /// <para>
        /// <para>Specifies whether a budget includes support subscription fees.</para><para>The default value is <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Budget_CostTypes_IncludeSupport")]
        public System.Boolean? CostTypes_IncludeSupport { get; set; }
        #endregion
        
        #region Parameter CostTypes_IncludeTax
        /// <summary>
        /// <para>
        /// <para>Specifies whether a budget includes taxes.</para><para>The default value is <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Budget_CostTypes_IncludeTax")]
        public System.Boolean? CostTypes_IncludeTax { get; set; }
        #endregion
        
        #region Parameter CostTypes_IncludeUpfront
        /// <summary>
        /// <para>
        /// <para>Specifies whether a budget includes upfront RI costs.</para><para>The default value is <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Budget_CostTypes_IncludeUpfront")]
        public System.Boolean? CostTypes_IncludeUpfront { get; set; }
        #endregion
        
        #region Parameter AutoAdjustData_LastAutoAdjustTime
        /// <summary>
        /// <para>
        /// <para>The last time that your budget was auto-adjusted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Budget_AutoAdjustData_LastAutoAdjustTime")]
        public System.DateTime? AutoAdjustData_LastAutoAdjustTime { get; set; }
        #endregion
        
        #region Parameter Budget_LastUpdatedTime
        /// <summary>
        /// <para>
        /// <para>The last time that you updated this budget.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Budget_LastUpdatedTime { get; set; }
        #endregion
        
        #region Parameter HistoricalOptions_LookBackAvailablePeriod
        /// <summary>
        /// <para>
        /// <para>The integer that describes how many budget periods in your <c>BudgetAdjustmentPeriod</c>
        /// are included in the calculation of your current <c>BudgetLimit</c>. If the first budget
        /// period in your <c>BudgetAdjustmentPeriod</c> has no cost data, then that budget period
        /// isn’t included in the average that determines your budget limit. </para><para>For example, if you set <c>BudgetAdjustmentPeriod</c> as <c>4</c> quarters, but your
        /// account had no cost data in the first quarter, then only the last three quarters are
        /// included in the calculation. In this scenario, <c>LookBackAvailablePeriods</c> returns
        /// <c>3</c>. </para><para>You can’t set your own <c>LookBackAvailablePeriods</c>. The value is automatically
        /// calculated from the <c>BudgetAdjustmentPeriod</c> and your historical cost data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Budget_AutoAdjustData_HistoricalOptions_LookBackAvailablePeriods")]
        public System.Int32? HistoricalOptions_LookBackAvailablePeriod { get; set; }
        #endregion
        
        #region Parameter NotificationsWithSubscriber
        /// <summary>
        /// <para>
        /// <para>A notification that you want to associate with a budget. A budget can have up to five
        /// notifications, and each notification can have one SNS subscriber and up to 10 email
        /// subscribers. If you include notifications and subscribers in your <c>CreateBudget</c>
        /// call, Amazon Web Services creates the notifications and subscribers for you.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NotificationsWithSubscribers")]
        public Amazon.Budgets.Model.NotificationWithSubscribers[] NotificationsWithSubscriber { get; set; }
        #endregion
        
        #region Parameter Budget_PlannedBudgetLimit
        /// <summary>
        /// <para>
        /// <para>A map containing multiple <c>BudgetLimit</c>, including current or future limits.</para><para><c>PlannedBudgetLimits</c> is available for cost or usage budget and supports both
        /// monthly and quarterly <c>TimeUnit</c>. </para><para>For monthly budgets, provide 12 months of <c>PlannedBudgetLimits</c> values. This
        /// must start from the current month and include the next 11 months. The <c>key</c> is
        /// the start of the month, <c>UTC</c> in epoch seconds. </para><para>For quarterly budgets, provide four quarters of <c>PlannedBudgetLimits</c> value entries
        /// in standard calendar quarter increments. This must start from the current quarter
        /// and include the next three quarters. The <c>key</c> is the start of the quarter, <c>UTC</c>
        /// in epoch seconds. </para><para>If the planned budget expires before 12 months for monthly or four quarters for quarterly,
        /// provide the <c>PlannedBudgetLimits</c> values only for the remaining periods.</para><para>If the budget begins at a date in the future, provide <c>PlannedBudgetLimits</c> values
        /// from the start date of the budget. </para><para>After all of the <c>BudgetLimit</c> values in <c>PlannedBudgetLimits</c> are used,
        /// the budget continues to use the last limit as the <c>BudgetLimit</c>. At that point,
        /// the planned budget provides the same experience as a fixed budget. </para><para><c>DescribeBudget</c> and <c>DescribeBudgets</c> response along with <c>PlannedBudgetLimits</c>
        /// also contain <c>BudgetLimit</c> representing the current month or quarter limit present
        /// in <c>PlannedBudgetLimits</c>. This only applies to budgets that are created with
        /// <c>PlannedBudgetLimits</c>. Budgets that are created without <c>PlannedBudgetLimits</c>
        /// only contain <c>BudgetLimit</c>. They don't contain <c>PlannedBudgetLimits</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Budget_PlannedBudgetLimits")]
        public System.Collections.Hashtable Budget_PlannedBudgetLimit { get; set; }
        #endregion
        
        #region Parameter ResourceTag
        /// <summary>
        /// <para>
        /// <para>An optional list of tags to associate with the specified budget. Each tag consists
        /// of a key and a value, and each key must be unique for the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceTags")]
        public Amazon.Budgets.Model.ResourceTag[] ResourceTag { get; set; }
        #endregion
        
        #region Parameter TimePeriod_Start
        /// <summary>
        /// <para>
        /// <para>The start date for a budget. If you created your budget and didn't specify a start
        /// date, Amazon Web Services defaults to the start of your chosen time period (DAILY,
        /// MONTHLY, QUARTERLY, or ANNUALLY). For example, if you created your budget on January
        /// 24, 2018, chose <c>DAILY</c>, and didn't set a start date, Amazon Web Services set
        /// your start date to <c>01/24/18 00:00 UTC</c>. If you chose <c>MONTHLY</c>, Amazon
        /// Web Services set your start date to <c>01/01/18 00:00 UTC</c>. The defaults are the
        /// same for the Billing and Cost Management console and the API.</para><para>You can change your start date with the <c>UpdateBudget</c> operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Budget_TimePeriod_Start")]
        public System.DateTime? TimePeriod_Start { get; set; }
        #endregion
        
        #region Parameter Budget_TimeUnit
        /// <summary>
        /// <para>
        /// <para>The length of time until a budget resets the actual and forecasted spend.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Budgets.TimeUnit")]
        public Amazon.Budgets.TimeUnit Budget_TimeUnit { get; set; }
        #endregion
        
        #region Parameter BudgetLimit_Unit
        /// <summary>
        /// <para>
        /// <para>The unit of measurement that's used for the budget forecast, actual spend, or budget
        /// threshold.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Budget_BudgetLimit_Unit")]
        public System.String BudgetLimit_Unit { get; set; }
        #endregion
        
        #region Parameter ActualSpend_Unit
        /// <summary>
        /// <para>
        /// <para>The unit of measurement that's used for the budget forecast, actual spend, or budget
        /// threshold.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Budget_CalculatedSpend_ActualSpend_Unit")]
        public System.String ActualSpend_Unit { get; set; }
        #endregion
        
        #region Parameter ForecastedSpend_Unit
        /// <summary>
        /// <para>
        /// <para>The unit of measurement that's used for the budget forecast, actual spend, or budget
        /// threshold.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Budget_CalculatedSpend_ForecastedSpend_Unit")]
        public System.String ForecastedSpend_Unit { get; set; }
        #endregion
        
        #region Parameter CostTypes_UseAmortized
        /// <summary>
        /// <para>
        /// <para>Specifies whether a budget uses the amortized rate.</para><para>The default value is <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Budget_CostTypes_UseAmortized")]
        public System.Boolean? CostTypes_UseAmortized { get; set; }
        #endregion
        
        #region Parameter CostTypes_UseBlended
        /// <summary>
        /// <para>
        /// <para>Specifies whether a budget uses a blended rate.</para><para>The default value is <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Budget_CostTypes_UseBlended")]
        public System.Boolean? CostTypes_UseBlended { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Budgets.Model.CreateBudgetResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AccountId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BGTBudget (CreateBudget)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Budgets.Model.CreateBudgetResponse, NewBGTBudgetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccountId = this.AccountId;
            #if MODULAR
            if (this.AccountId == null && ParameterWasBound(nameof(this.AccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AutoAdjustData_AutoAdjustType = this.AutoAdjustData_AutoAdjustType;
            context.HistoricalOptions_BudgetAdjustmentPeriod = this.HistoricalOptions_BudgetAdjustmentPeriod;
            context.HistoricalOptions_LookBackAvailablePeriod = this.HistoricalOptions_LookBackAvailablePeriod;
            context.AutoAdjustData_LastAutoAdjustTime = this.AutoAdjustData_LastAutoAdjustTime;
            context.BudgetLimit_Amount = this.BudgetLimit_Amount;
            context.BudgetLimit_Unit = this.BudgetLimit_Unit;
            context.Budget_BudgetName = this.Budget_BudgetName;
            #if MODULAR
            if (this.Budget_BudgetName == null && ParameterWasBound(nameof(this.Budget_BudgetName)))
            {
                WriteWarning("You are passing $null as a value for parameter Budget_BudgetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Budget_BudgetType = this.Budget_BudgetType;
            #if MODULAR
            if (this.Budget_BudgetType == null && ParameterWasBound(nameof(this.Budget_BudgetType)))
            {
                WriteWarning("You are passing $null as a value for parameter Budget_BudgetType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ActualSpend_Amount = this.ActualSpend_Amount;
            context.ActualSpend_Unit = this.ActualSpend_Unit;
            context.ForecastedSpend_Amount = this.ForecastedSpend_Amount;
            context.ForecastedSpend_Unit = this.ForecastedSpend_Unit;
            if (this.Budget_CostFilter != null)
            {
                context.Budget_CostFilter = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.Budget_CostFilter.Keys)
                {
                    object hashValue = this.Budget_CostFilter[hashKey];
                    if (hashValue == null)
                    {
                        context.Budget_CostFilter.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<System.String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((System.String)s);
                    }
                    context.Budget_CostFilter.Add((String)hashKey, valueSet);
                }
            }
            context.CostTypes_IncludeCredit = this.CostTypes_IncludeCredit;
            context.CostTypes_IncludeDiscount = this.CostTypes_IncludeDiscount;
            context.CostTypes_IncludeOtherSubscription = this.CostTypes_IncludeOtherSubscription;
            context.CostTypes_IncludeRecurring = this.CostTypes_IncludeRecurring;
            context.CostTypes_IncludeRefund = this.CostTypes_IncludeRefund;
            context.CostTypes_IncludeSubscription = this.CostTypes_IncludeSubscription;
            context.CostTypes_IncludeSupport = this.CostTypes_IncludeSupport;
            context.CostTypes_IncludeTax = this.CostTypes_IncludeTax;
            context.CostTypes_IncludeUpfront = this.CostTypes_IncludeUpfront;
            context.CostTypes_UseAmortized = this.CostTypes_UseAmortized;
            context.CostTypes_UseBlended = this.CostTypes_UseBlended;
            context.Budget_LastUpdatedTime = this.Budget_LastUpdatedTime;
            if (this.Budget_PlannedBudgetLimit != null)
            {
                context.Budget_PlannedBudgetLimit = new Dictionary<System.String, Amazon.Budgets.Model.Spend>(StringComparer.Ordinal);
                foreach (var hashKey in this.Budget_PlannedBudgetLimit.Keys)
                {
                    context.Budget_PlannedBudgetLimit.Add((String)hashKey, (Amazon.Budgets.Model.Spend)(this.Budget_PlannedBudgetLimit[hashKey]));
                }
            }
            context.TimePeriod_End = this.TimePeriod_End;
            context.TimePeriod_Start = this.TimePeriod_Start;
            context.Budget_TimeUnit = this.Budget_TimeUnit;
            #if MODULAR
            if (this.Budget_TimeUnit == null && ParameterWasBound(nameof(this.Budget_TimeUnit)))
            {
                WriteWarning("You are passing $null as a value for parameter Budget_TimeUnit which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.NotificationsWithSubscriber != null)
            {
                context.NotificationsWithSubscriber = new List<Amazon.Budgets.Model.NotificationWithSubscribers>(this.NotificationsWithSubscriber);
            }
            if (this.ResourceTag != null)
            {
                context.ResourceTag = new List<Amazon.Budgets.Model.ResourceTag>(this.ResourceTag);
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
            var request = new Amazon.Budgets.Model.CreateBudgetRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            
             // populate Budget
            var requestBudgetIsNull = true;
            request.Budget = new Amazon.Budgets.Model.Budget();
            System.String requestBudget_budget_BudgetName = null;
            if (cmdletContext.Budget_BudgetName != null)
            {
                requestBudget_budget_BudgetName = cmdletContext.Budget_BudgetName;
            }
            if (requestBudget_budget_BudgetName != null)
            {
                request.Budget.BudgetName = requestBudget_budget_BudgetName;
                requestBudgetIsNull = false;
            }
            Amazon.Budgets.BudgetType requestBudget_budget_BudgetType = null;
            if (cmdletContext.Budget_BudgetType != null)
            {
                requestBudget_budget_BudgetType = cmdletContext.Budget_BudgetType;
            }
            if (requestBudget_budget_BudgetType != null)
            {
                request.Budget.BudgetType = requestBudget_budget_BudgetType;
                requestBudgetIsNull = false;
            }
            Dictionary<System.String, List<System.String>> requestBudget_budget_CostFilter = null;
            if (cmdletContext.Budget_CostFilter != null)
            {
                requestBudget_budget_CostFilter = cmdletContext.Budget_CostFilter;
            }
            if (requestBudget_budget_CostFilter != null)
            {
                request.Budget.CostFilters = requestBudget_budget_CostFilter;
                requestBudgetIsNull = false;
            }
            System.DateTime? requestBudget_budget_LastUpdatedTime = null;
            if (cmdletContext.Budget_LastUpdatedTime != null)
            {
                requestBudget_budget_LastUpdatedTime = cmdletContext.Budget_LastUpdatedTime.Value;
            }
            if (requestBudget_budget_LastUpdatedTime != null)
            {
                request.Budget.LastUpdatedTime = requestBudget_budget_LastUpdatedTime.Value;
                requestBudgetIsNull = false;
            }
            Dictionary<System.String, Amazon.Budgets.Model.Spend> requestBudget_budget_PlannedBudgetLimit = null;
            if (cmdletContext.Budget_PlannedBudgetLimit != null)
            {
                requestBudget_budget_PlannedBudgetLimit = cmdletContext.Budget_PlannedBudgetLimit;
            }
            if (requestBudget_budget_PlannedBudgetLimit != null)
            {
                request.Budget.PlannedBudgetLimits = requestBudget_budget_PlannedBudgetLimit;
                requestBudgetIsNull = false;
            }
            Amazon.Budgets.TimeUnit requestBudget_budget_TimeUnit = null;
            if (cmdletContext.Budget_TimeUnit != null)
            {
                requestBudget_budget_TimeUnit = cmdletContext.Budget_TimeUnit;
            }
            if (requestBudget_budget_TimeUnit != null)
            {
                request.Budget.TimeUnit = requestBudget_budget_TimeUnit;
                requestBudgetIsNull = false;
            }
            Amazon.Budgets.Model.Spend requestBudget_budget_BudgetLimit = null;
            
             // populate BudgetLimit
            var requestBudget_budget_BudgetLimitIsNull = true;
            requestBudget_budget_BudgetLimit = new Amazon.Budgets.Model.Spend();
            System.Decimal? requestBudget_budget_BudgetLimit_budgetLimit_Amount = null;
            if (cmdletContext.BudgetLimit_Amount != null)
            {
                requestBudget_budget_BudgetLimit_budgetLimit_Amount = cmdletContext.BudgetLimit_Amount.Value;
            }
            if (requestBudget_budget_BudgetLimit_budgetLimit_Amount != null)
            {
                requestBudget_budget_BudgetLimit.Amount = requestBudget_budget_BudgetLimit_budgetLimit_Amount.Value;
                requestBudget_budget_BudgetLimitIsNull = false;
            }
            System.String requestBudget_budget_BudgetLimit_budgetLimit_Unit = null;
            if (cmdletContext.BudgetLimit_Unit != null)
            {
                requestBudget_budget_BudgetLimit_budgetLimit_Unit = cmdletContext.BudgetLimit_Unit;
            }
            if (requestBudget_budget_BudgetLimit_budgetLimit_Unit != null)
            {
                requestBudget_budget_BudgetLimit.Unit = requestBudget_budget_BudgetLimit_budgetLimit_Unit;
                requestBudget_budget_BudgetLimitIsNull = false;
            }
             // determine if requestBudget_budget_BudgetLimit should be set to null
            if (requestBudget_budget_BudgetLimitIsNull)
            {
                requestBudget_budget_BudgetLimit = null;
            }
            if (requestBudget_budget_BudgetLimit != null)
            {
                request.Budget.BudgetLimit = requestBudget_budget_BudgetLimit;
                requestBudgetIsNull = false;
            }
            Amazon.Budgets.Model.CalculatedSpend requestBudget_budget_CalculatedSpend = null;
            
             // populate CalculatedSpend
            var requestBudget_budget_CalculatedSpendIsNull = true;
            requestBudget_budget_CalculatedSpend = new Amazon.Budgets.Model.CalculatedSpend();
            Amazon.Budgets.Model.Spend requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ActualSpend = null;
            
             // populate ActualSpend
            var requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ActualSpendIsNull = true;
            requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ActualSpend = new Amazon.Budgets.Model.Spend();
            System.Decimal? requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ActualSpend_actualSpend_Amount = null;
            if (cmdletContext.ActualSpend_Amount != null)
            {
                requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ActualSpend_actualSpend_Amount = cmdletContext.ActualSpend_Amount.Value;
            }
            if (requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ActualSpend_actualSpend_Amount != null)
            {
                requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ActualSpend.Amount = requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ActualSpend_actualSpend_Amount.Value;
                requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ActualSpendIsNull = false;
            }
            System.String requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ActualSpend_actualSpend_Unit = null;
            if (cmdletContext.ActualSpend_Unit != null)
            {
                requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ActualSpend_actualSpend_Unit = cmdletContext.ActualSpend_Unit;
            }
            if (requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ActualSpend_actualSpend_Unit != null)
            {
                requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ActualSpend.Unit = requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ActualSpend_actualSpend_Unit;
                requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ActualSpendIsNull = false;
            }
             // determine if requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ActualSpend should be set to null
            if (requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ActualSpendIsNull)
            {
                requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ActualSpend = null;
            }
            if (requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ActualSpend != null)
            {
                requestBudget_budget_CalculatedSpend.ActualSpend = requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ActualSpend;
                requestBudget_budget_CalculatedSpendIsNull = false;
            }
            Amazon.Budgets.Model.Spend requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ForecastedSpend = null;
            
             // populate ForecastedSpend
            var requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ForecastedSpendIsNull = true;
            requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ForecastedSpend = new Amazon.Budgets.Model.Spend();
            System.Decimal? requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ForecastedSpend_forecastedSpend_Amount = null;
            if (cmdletContext.ForecastedSpend_Amount != null)
            {
                requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ForecastedSpend_forecastedSpend_Amount = cmdletContext.ForecastedSpend_Amount.Value;
            }
            if (requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ForecastedSpend_forecastedSpend_Amount != null)
            {
                requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ForecastedSpend.Amount = requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ForecastedSpend_forecastedSpend_Amount.Value;
                requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ForecastedSpendIsNull = false;
            }
            System.String requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ForecastedSpend_forecastedSpend_Unit = null;
            if (cmdletContext.ForecastedSpend_Unit != null)
            {
                requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ForecastedSpend_forecastedSpend_Unit = cmdletContext.ForecastedSpend_Unit;
            }
            if (requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ForecastedSpend_forecastedSpend_Unit != null)
            {
                requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ForecastedSpend.Unit = requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ForecastedSpend_forecastedSpend_Unit;
                requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ForecastedSpendIsNull = false;
            }
             // determine if requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ForecastedSpend should be set to null
            if (requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ForecastedSpendIsNull)
            {
                requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ForecastedSpend = null;
            }
            if (requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ForecastedSpend != null)
            {
                requestBudget_budget_CalculatedSpend.ForecastedSpend = requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ForecastedSpend;
                requestBudget_budget_CalculatedSpendIsNull = false;
            }
             // determine if requestBudget_budget_CalculatedSpend should be set to null
            if (requestBudget_budget_CalculatedSpendIsNull)
            {
                requestBudget_budget_CalculatedSpend = null;
            }
            if (requestBudget_budget_CalculatedSpend != null)
            {
                request.Budget.CalculatedSpend = requestBudget_budget_CalculatedSpend;
                requestBudgetIsNull = false;
            }
            Amazon.Budgets.Model.TimePeriod requestBudget_budget_TimePeriod = null;
            
             // populate TimePeriod
            var requestBudget_budget_TimePeriodIsNull = true;
            requestBudget_budget_TimePeriod = new Amazon.Budgets.Model.TimePeriod();
            System.DateTime? requestBudget_budget_TimePeriod_timePeriod_End = null;
            if (cmdletContext.TimePeriod_End != null)
            {
                requestBudget_budget_TimePeriod_timePeriod_End = cmdletContext.TimePeriod_End.Value;
            }
            if (requestBudget_budget_TimePeriod_timePeriod_End != null)
            {
                requestBudget_budget_TimePeriod.End = requestBudget_budget_TimePeriod_timePeriod_End.Value;
                requestBudget_budget_TimePeriodIsNull = false;
            }
            System.DateTime? requestBudget_budget_TimePeriod_timePeriod_Start = null;
            if (cmdletContext.TimePeriod_Start != null)
            {
                requestBudget_budget_TimePeriod_timePeriod_Start = cmdletContext.TimePeriod_Start.Value;
            }
            if (requestBudget_budget_TimePeriod_timePeriod_Start != null)
            {
                requestBudget_budget_TimePeriod.Start = requestBudget_budget_TimePeriod_timePeriod_Start.Value;
                requestBudget_budget_TimePeriodIsNull = false;
            }
             // determine if requestBudget_budget_TimePeriod should be set to null
            if (requestBudget_budget_TimePeriodIsNull)
            {
                requestBudget_budget_TimePeriod = null;
            }
            if (requestBudget_budget_TimePeriod != null)
            {
                request.Budget.TimePeriod = requestBudget_budget_TimePeriod;
                requestBudgetIsNull = false;
            }
            Amazon.Budgets.Model.AutoAdjustData requestBudget_budget_AutoAdjustData = null;
            
             // populate AutoAdjustData
            var requestBudget_budget_AutoAdjustDataIsNull = true;
            requestBudget_budget_AutoAdjustData = new Amazon.Budgets.Model.AutoAdjustData();
            Amazon.Budgets.AutoAdjustType requestBudget_budget_AutoAdjustData_autoAdjustData_AutoAdjustType = null;
            if (cmdletContext.AutoAdjustData_AutoAdjustType != null)
            {
                requestBudget_budget_AutoAdjustData_autoAdjustData_AutoAdjustType = cmdletContext.AutoAdjustData_AutoAdjustType;
            }
            if (requestBudget_budget_AutoAdjustData_autoAdjustData_AutoAdjustType != null)
            {
                requestBudget_budget_AutoAdjustData.AutoAdjustType = requestBudget_budget_AutoAdjustData_autoAdjustData_AutoAdjustType;
                requestBudget_budget_AutoAdjustDataIsNull = false;
            }
            System.DateTime? requestBudget_budget_AutoAdjustData_autoAdjustData_LastAutoAdjustTime = null;
            if (cmdletContext.AutoAdjustData_LastAutoAdjustTime != null)
            {
                requestBudget_budget_AutoAdjustData_autoAdjustData_LastAutoAdjustTime = cmdletContext.AutoAdjustData_LastAutoAdjustTime.Value;
            }
            if (requestBudget_budget_AutoAdjustData_autoAdjustData_LastAutoAdjustTime != null)
            {
                requestBudget_budget_AutoAdjustData.LastAutoAdjustTime = requestBudget_budget_AutoAdjustData_autoAdjustData_LastAutoAdjustTime.Value;
                requestBudget_budget_AutoAdjustDataIsNull = false;
            }
            Amazon.Budgets.Model.HistoricalOptions requestBudget_budget_AutoAdjustData_budget_AutoAdjustData_HistoricalOptions = null;
            
             // populate HistoricalOptions
            var requestBudget_budget_AutoAdjustData_budget_AutoAdjustData_HistoricalOptionsIsNull = true;
            requestBudget_budget_AutoAdjustData_budget_AutoAdjustData_HistoricalOptions = new Amazon.Budgets.Model.HistoricalOptions();
            System.Int32? requestBudget_budget_AutoAdjustData_budget_AutoAdjustData_HistoricalOptions_historicalOptions_BudgetAdjustmentPeriod = null;
            if (cmdletContext.HistoricalOptions_BudgetAdjustmentPeriod != null)
            {
                requestBudget_budget_AutoAdjustData_budget_AutoAdjustData_HistoricalOptions_historicalOptions_BudgetAdjustmentPeriod = cmdletContext.HistoricalOptions_BudgetAdjustmentPeriod.Value;
            }
            if (requestBudget_budget_AutoAdjustData_budget_AutoAdjustData_HistoricalOptions_historicalOptions_BudgetAdjustmentPeriod != null)
            {
                requestBudget_budget_AutoAdjustData_budget_AutoAdjustData_HistoricalOptions.BudgetAdjustmentPeriod = requestBudget_budget_AutoAdjustData_budget_AutoAdjustData_HistoricalOptions_historicalOptions_BudgetAdjustmentPeriod.Value;
                requestBudget_budget_AutoAdjustData_budget_AutoAdjustData_HistoricalOptionsIsNull = false;
            }
            System.Int32? requestBudget_budget_AutoAdjustData_budget_AutoAdjustData_HistoricalOptions_historicalOptions_LookBackAvailablePeriod = null;
            if (cmdletContext.HistoricalOptions_LookBackAvailablePeriod != null)
            {
                requestBudget_budget_AutoAdjustData_budget_AutoAdjustData_HistoricalOptions_historicalOptions_LookBackAvailablePeriod = cmdletContext.HistoricalOptions_LookBackAvailablePeriod.Value;
            }
            if (requestBudget_budget_AutoAdjustData_budget_AutoAdjustData_HistoricalOptions_historicalOptions_LookBackAvailablePeriod != null)
            {
                requestBudget_budget_AutoAdjustData_budget_AutoAdjustData_HistoricalOptions.LookBackAvailablePeriods = requestBudget_budget_AutoAdjustData_budget_AutoAdjustData_HistoricalOptions_historicalOptions_LookBackAvailablePeriod.Value;
                requestBudget_budget_AutoAdjustData_budget_AutoAdjustData_HistoricalOptionsIsNull = false;
            }
             // determine if requestBudget_budget_AutoAdjustData_budget_AutoAdjustData_HistoricalOptions should be set to null
            if (requestBudget_budget_AutoAdjustData_budget_AutoAdjustData_HistoricalOptionsIsNull)
            {
                requestBudget_budget_AutoAdjustData_budget_AutoAdjustData_HistoricalOptions = null;
            }
            if (requestBudget_budget_AutoAdjustData_budget_AutoAdjustData_HistoricalOptions != null)
            {
                requestBudget_budget_AutoAdjustData.HistoricalOptions = requestBudget_budget_AutoAdjustData_budget_AutoAdjustData_HistoricalOptions;
                requestBudget_budget_AutoAdjustDataIsNull = false;
            }
             // determine if requestBudget_budget_AutoAdjustData should be set to null
            if (requestBudget_budget_AutoAdjustDataIsNull)
            {
                requestBudget_budget_AutoAdjustData = null;
            }
            if (requestBudget_budget_AutoAdjustData != null)
            {
                request.Budget.AutoAdjustData = requestBudget_budget_AutoAdjustData;
                requestBudgetIsNull = false;
            }
            Amazon.Budgets.Model.CostTypes requestBudget_budget_CostTypes = null;
            
             // populate CostTypes
            var requestBudget_budget_CostTypesIsNull = true;
            requestBudget_budget_CostTypes = new Amazon.Budgets.Model.CostTypes();
            System.Boolean? requestBudget_budget_CostTypes_costTypes_IncludeCredit = null;
            if (cmdletContext.CostTypes_IncludeCredit != null)
            {
                requestBudget_budget_CostTypes_costTypes_IncludeCredit = cmdletContext.CostTypes_IncludeCredit.Value;
            }
            if (requestBudget_budget_CostTypes_costTypes_IncludeCredit != null)
            {
                requestBudget_budget_CostTypes.IncludeCredit = requestBudget_budget_CostTypes_costTypes_IncludeCredit.Value;
                requestBudget_budget_CostTypesIsNull = false;
            }
            System.Boolean? requestBudget_budget_CostTypes_costTypes_IncludeDiscount = null;
            if (cmdletContext.CostTypes_IncludeDiscount != null)
            {
                requestBudget_budget_CostTypes_costTypes_IncludeDiscount = cmdletContext.CostTypes_IncludeDiscount.Value;
            }
            if (requestBudget_budget_CostTypes_costTypes_IncludeDiscount != null)
            {
                requestBudget_budget_CostTypes.IncludeDiscount = requestBudget_budget_CostTypes_costTypes_IncludeDiscount.Value;
                requestBudget_budget_CostTypesIsNull = false;
            }
            System.Boolean? requestBudget_budget_CostTypes_costTypes_IncludeOtherSubscription = null;
            if (cmdletContext.CostTypes_IncludeOtherSubscription != null)
            {
                requestBudget_budget_CostTypes_costTypes_IncludeOtherSubscription = cmdletContext.CostTypes_IncludeOtherSubscription.Value;
            }
            if (requestBudget_budget_CostTypes_costTypes_IncludeOtherSubscription != null)
            {
                requestBudget_budget_CostTypes.IncludeOtherSubscription = requestBudget_budget_CostTypes_costTypes_IncludeOtherSubscription.Value;
                requestBudget_budget_CostTypesIsNull = false;
            }
            System.Boolean? requestBudget_budget_CostTypes_costTypes_IncludeRecurring = null;
            if (cmdletContext.CostTypes_IncludeRecurring != null)
            {
                requestBudget_budget_CostTypes_costTypes_IncludeRecurring = cmdletContext.CostTypes_IncludeRecurring.Value;
            }
            if (requestBudget_budget_CostTypes_costTypes_IncludeRecurring != null)
            {
                requestBudget_budget_CostTypes.IncludeRecurring = requestBudget_budget_CostTypes_costTypes_IncludeRecurring.Value;
                requestBudget_budget_CostTypesIsNull = false;
            }
            System.Boolean? requestBudget_budget_CostTypes_costTypes_IncludeRefund = null;
            if (cmdletContext.CostTypes_IncludeRefund != null)
            {
                requestBudget_budget_CostTypes_costTypes_IncludeRefund = cmdletContext.CostTypes_IncludeRefund.Value;
            }
            if (requestBudget_budget_CostTypes_costTypes_IncludeRefund != null)
            {
                requestBudget_budget_CostTypes.IncludeRefund = requestBudget_budget_CostTypes_costTypes_IncludeRefund.Value;
                requestBudget_budget_CostTypesIsNull = false;
            }
            System.Boolean? requestBudget_budget_CostTypes_costTypes_IncludeSubscription = null;
            if (cmdletContext.CostTypes_IncludeSubscription != null)
            {
                requestBudget_budget_CostTypes_costTypes_IncludeSubscription = cmdletContext.CostTypes_IncludeSubscription.Value;
            }
            if (requestBudget_budget_CostTypes_costTypes_IncludeSubscription != null)
            {
                requestBudget_budget_CostTypes.IncludeSubscription = requestBudget_budget_CostTypes_costTypes_IncludeSubscription.Value;
                requestBudget_budget_CostTypesIsNull = false;
            }
            System.Boolean? requestBudget_budget_CostTypes_costTypes_IncludeSupport = null;
            if (cmdletContext.CostTypes_IncludeSupport != null)
            {
                requestBudget_budget_CostTypes_costTypes_IncludeSupport = cmdletContext.CostTypes_IncludeSupport.Value;
            }
            if (requestBudget_budget_CostTypes_costTypes_IncludeSupport != null)
            {
                requestBudget_budget_CostTypes.IncludeSupport = requestBudget_budget_CostTypes_costTypes_IncludeSupport.Value;
                requestBudget_budget_CostTypesIsNull = false;
            }
            System.Boolean? requestBudget_budget_CostTypes_costTypes_IncludeTax = null;
            if (cmdletContext.CostTypes_IncludeTax != null)
            {
                requestBudget_budget_CostTypes_costTypes_IncludeTax = cmdletContext.CostTypes_IncludeTax.Value;
            }
            if (requestBudget_budget_CostTypes_costTypes_IncludeTax != null)
            {
                requestBudget_budget_CostTypes.IncludeTax = requestBudget_budget_CostTypes_costTypes_IncludeTax.Value;
                requestBudget_budget_CostTypesIsNull = false;
            }
            System.Boolean? requestBudget_budget_CostTypes_costTypes_IncludeUpfront = null;
            if (cmdletContext.CostTypes_IncludeUpfront != null)
            {
                requestBudget_budget_CostTypes_costTypes_IncludeUpfront = cmdletContext.CostTypes_IncludeUpfront.Value;
            }
            if (requestBudget_budget_CostTypes_costTypes_IncludeUpfront != null)
            {
                requestBudget_budget_CostTypes.IncludeUpfront = requestBudget_budget_CostTypes_costTypes_IncludeUpfront.Value;
                requestBudget_budget_CostTypesIsNull = false;
            }
            System.Boolean? requestBudget_budget_CostTypes_costTypes_UseAmortized = null;
            if (cmdletContext.CostTypes_UseAmortized != null)
            {
                requestBudget_budget_CostTypes_costTypes_UseAmortized = cmdletContext.CostTypes_UseAmortized.Value;
            }
            if (requestBudget_budget_CostTypes_costTypes_UseAmortized != null)
            {
                requestBudget_budget_CostTypes.UseAmortized = requestBudget_budget_CostTypes_costTypes_UseAmortized.Value;
                requestBudget_budget_CostTypesIsNull = false;
            }
            System.Boolean? requestBudget_budget_CostTypes_costTypes_UseBlended = null;
            if (cmdletContext.CostTypes_UseBlended != null)
            {
                requestBudget_budget_CostTypes_costTypes_UseBlended = cmdletContext.CostTypes_UseBlended.Value;
            }
            if (requestBudget_budget_CostTypes_costTypes_UseBlended != null)
            {
                requestBudget_budget_CostTypes.UseBlended = requestBudget_budget_CostTypes_costTypes_UseBlended.Value;
                requestBudget_budget_CostTypesIsNull = false;
            }
             // determine if requestBudget_budget_CostTypes should be set to null
            if (requestBudget_budget_CostTypesIsNull)
            {
                requestBudget_budget_CostTypes = null;
            }
            if (requestBudget_budget_CostTypes != null)
            {
                request.Budget.CostTypes = requestBudget_budget_CostTypes;
                requestBudgetIsNull = false;
            }
             // determine if request.Budget should be set to null
            if (requestBudgetIsNull)
            {
                request.Budget = null;
            }
            if (cmdletContext.NotificationsWithSubscriber != null)
            {
                request.NotificationsWithSubscribers = cmdletContext.NotificationsWithSubscriber;
            }
            if (cmdletContext.ResourceTag != null)
            {
                request.ResourceTags = cmdletContext.ResourceTag;
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
        
        private Amazon.Budgets.Model.CreateBudgetResponse CallAWSServiceOperation(IAmazonBudgets client, Amazon.Budgets.Model.CreateBudgetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Budgets", "CreateBudget");
            try
            {
                #if DESKTOP
                return client.CreateBudget(request);
                #elif CORECLR
                return client.CreateBudgetAsync(request).GetAwaiter().GetResult();
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
            public System.String AccountId { get; set; }
            public Amazon.Budgets.AutoAdjustType AutoAdjustData_AutoAdjustType { get; set; }
            public System.Int32? HistoricalOptions_BudgetAdjustmentPeriod { get; set; }
            public System.Int32? HistoricalOptions_LookBackAvailablePeriod { get; set; }
            public System.DateTime? AutoAdjustData_LastAutoAdjustTime { get; set; }
            public System.Decimal? BudgetLimit_Amount { get; set; }
            public System.String BudgetLimit_Unit { get; set; }
            public System.String Budget_BudgetName { get; set; }
            public Amazon.Budgets.BudgetType Budget_BudgetType { get; set; }
            public System.Decimal? ActualSpend_Amount { get; set; }
            public System.String ActualSpend_Unit { get; set; }
            public System.Decimal? ForecastedSpend_Amount { get; set; }
            public System.String ForecastedSpend_Unit { get; set; }
            public Dictionary<System.String, List<System.String>> Budget_CostFilter { get; set; }
            public System.Boolean? CostTypes_IncludeCredit { get; set; }
            public System.Boolean? CostTypes_IncludeDiscount { get; set; }
            public System.Boolean? CostTypes_IncludeOtherSubscription { get; set; }
            public System.Boolean? CostTypes_IncludeRecurring { get; set; }
            public System.Boolean? CostTypes_IncludeRefund { get; set; }
            public System.Boolean? CostTypes_IncludeSubscription { get; set; }
            public System.Boolean? CostTypes_IncludeSupport { get; set; }
            public System.Boolean? CostTypes_IncludeTax { get; set; }
            public System.Boolean? CostTypes_IncludeUpfront { get; set; }
            public System.Boolean? CostTypes_UseAmortized { get; set; }
            public System.Boolean? CostTypes_UseBlended { get; set; }
            public System.DateTime? Budget_LastUpdatedTime { get; set; }
            public Dictionary<System.String, Amazon.Budgets.Model.Spend> Budget_PlannedBudgetLimit { get; set; }
            public System.DateTime? TimePeriod_End { get; set; }
            public System.DateTime? TimePeriod_Start { get; set; }
            public Amazon.Budgets.TimeUnit Budget_TimeUnit { get; set; }
            public List<Amazon.Budgets.Model.NotificationWithSubscribers> NotificationsWithSubscriber { get; set; }
            public List<Amazon.Budgets.Model.ResourceTag> ResourceTag { get; set; }
            public System.Func<Amazon.Budgets.Model.CreateBudgetResponse, NewBGTBudgetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
