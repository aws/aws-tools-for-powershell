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
using Amazon.Budgets;
using Amazon.Budgets.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BGT
{
    /// <summary>
    /// Updates a budget. You can change every part of a budget except for the <c>budgetName</c>
    /// and the <c>calculatedSpend</c>. When you modify a budget, the <c>calculatedSpend</c>
    /// drops to zero until Amazon Web Services has new usage data to use for forecasting.
    /// 
    ///  <important><para>
    /// Only one of <c>BudgetLimit</c> or <c>PlannedBudgetLimits</c> can be present in the
    /// syntax at one time. Use the syntax that matches your case. The Request Syntax section
    /// shows the <c>BudgetLimit</c> syntax. For <c>PlannedBudgetLimits</c>, see the <a href="https://docs.aws.amazon.com/aws-cost-management/latest/APIReference/API_budgets_UpdateBudget.html#API_UpdateBudget_Examples">Examples</a>
    /// section.
    /// </para><para>
    /// Similarly, only one set of filter and metric selections can be present in the syntax
    /// at one time. Either <c>FilterExpression</c> and <c>Metrics</c> or <c>CostFilters</c>
    /// and <c>CostTypes</c>, not both or a different combination. We recommend using <c>FilterExpression</c>
    /// and <c>Metrics</c> as they provide more flexible and powerful filtering capabilities.
    /// The Request Syntax section shows the <c>FilterExpression</c>/<c>Metrics</c> syntax.
    /// </para></important>
    /// </summary>
    [Cmdlet("Update", "BGTBudget", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Budgets UpdateBudget API operation.", Operation = new[] {"UpdateBudget"}, SelectReturnType = typeof(Amazon.Budgets.Model.UpdateBudgetResponse))]
    [AWSCmdletOutput("None or Amazon.Budgets.Model.UpdateBudgetResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Budgets.Model.UpdateBudgetResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateBGTBudgetCmdlet : AmazonBudgetsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The <c>accountId</c> that is associated with the budget that you want to update.</para>
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
        [Alias("NewBudget_BudgetLimit_Amount")]
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
        [Alias("NewBudget_CalculatedSpend_ActualSpend_Amount")]
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
        [Alias("NewBudget_CalculatedSpend_ForecastedSpend_Amount")]
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
        [Alias("NewBudget_AutoAdjustData_AutoAdjustType")]
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
        [Alias("NewBudget_AutoAdjustData_HistoricalOptions_BudgetAdjustmentPeriod")]
        public System.Int32? HistoricalOptions_BudgetAdjustmentPeriod { get; set; }
        #endregion
        
        #region Parameter NewBudget_BudgetName
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
        public System.String NewBudget_BudgetName { get; set; }
        #endregion
        
        #region Parameter NewBudget_BudgetType
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
        public Amazon.Budgets.BudgetType NewBudget_BudgetType { get; set; }
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
        [Alias("NewBudget_TimePeriod_End")]
        public System.DateTime? TimePeriod_End { get; set; }
        #endregion
        
        #region Parameter NewBudget_FilterExpression
        /// <summary>
        /// <para>
        /// <para>The filtering dimensions for the budget and their corresponding values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Budgets.Model.Expression NewBudget_FilterExpression { get; set; }
        #endregion
        
        #region Parameter CostTypes_IncludeCredit
        /// <summary>
        /// <para>
        /// <para>Specifies whether a budget includes credits.</para><para>The default value is <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NewBudget_CostTypes_IncludeCredit")]
        public System.Boolean? CostTypes_IncludeCredit { get; set; }
        #endregion
        
        #region Parameter CostTypes_IncludeDiscount
        /// <summary>
        /// <para>
        /// <para>Specifies whether a budget includes discounts.</para><para>The default value is <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NewBudget_CostTypes_IncludeDiscount")]
        public System.Boolean? CostTypes_IncludeDiscount { get; set; }
        #endregion
        
        #region Parameter CostTypes_IncludeOtherSubscription
        /// <summary>
        /// <para>
        /// <para>Specifies whether a budget includes non-RI subscription costs.</para><para>The default value is <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NewBudget_CostTypes_IncludeOtherSubscription")]
        public System.Boolean? CostTypes_IncludeOtherSubscription { get; set; }
        #endregion
        
        #region Parameter CostTypes_IncludeRecurring
        /// <summary>
        /// <para>
        /// <para>Specifies whether a budget includes recurring fees such as monthly RI fees.</para><para>The default value is <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NewBudget_CostTypes_IncludeRecurring")]
        public System.Boolean? CostTypes_IncludeRecurring { get; set; }
        #endregion
        
        #region Parameter CostTypes_IncludeRefund
        /// <summary>
        /// <para>
        /// <para>Specifies whether a budget includes refunds.</para><para>The default value is <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NewBudget_CostTypes_IncludeRefund")]
        public System.Boolean? CostTypes_IncludeRefund { get; set; }
        #endregion
        
        #region Parameter CostTypes_IncludeSubscription
        /// <summary>
        /// <para>
        /// <para>Specifies whether a budget includes subscriptions.</para><para>The default value is <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NewBudget_CostTypes_IncludeSubscription")]
        public System.Boolean? CostTypes_IncludeSubscription { get; set; }
        #endregion
        
        #region Parameter CostTypes_IncludeSupport
        /// <summary>
        /// <para>
        /// <para>Specifies whether a budget includes support subscription fees.</para><para>The default value is <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NewBudget_CostTypes_IncludeSupport")]
        public System.Boolean? CostTypes_IncludeSupport { get; set; }
        #endregion
        
        #region Parameter CostTypes_IncludeTax
        /// <summary>
        /// <para>
        /// <para>Specifies whether a budget includes taxes.</para><para>The default value is <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NewBudget_CostTypes_IncludeTax")]
        public System.Boolean? CostTypes_IncludeTax { get; set; }
        #endregion
        
        #region Parameter CostTypes_IncludeUpfront
        /// <summary>
        /// <para>
        /// <para>Specifies whether a budget includes upfront RI costs.</para><para>The default value is <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NewBudget_CostTypes_IncludeUpfront")]
        public System.Boolean? CostTypes_IncludeUpfront { get; set; }
        #endregion
        
        #region Parameter AutoAdjustData_LastAutoAdjustTime
        /// <summary>
        /// <para>
        /// <para>The last time that your budget was auto-adjusted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NewBudget_AutoAdjustData_LastAutoAdjustTime")]
        public System.DateTime? AutoAdjustData_LastAutoAdjustTime { get; set; }
        #endregion
        
        #region Parameter NewBudget_LastUpdatedTime
        /// <summary>
        /// <para>
        /// <para>The last time that you updated this budget.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? NewBudget_LastUpdatedTime { get; set; }
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
        [Alias("NewBudget_AutoAdjustData_HistoricalOptions_LookBackAvailablePeriods")]
        public System.Int32? HistoricalOptions_LookBackAvailablePeriod { get; set; }
        #endregion
        
        #region Parameter NewBudget_Metric
        /// <summary>
        /// <para>
        /// <para>The definition for how the budget data is aggregated.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NewBudget_Metrics")]
        public System.String[] NewBudget_Metric { get; set; }
        #endregion
        
        #region Parameter NewBudget_PlannedBudgetLimit
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
        /// only contain <c>BudgetLimit</c>. They don't contain <c>PlannedBudgetLimits</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NewBudget_PlannedBudgetLimits")]
        public System.Collections.Hashtable NewBudget_PlannedBudgetLimit { get; set; }
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
        [Alias("NewBudget_TimePeriod_Start")]
        public System.DateTime? TimePeriod_Start { get; set; }
        #endregion
        
        #region Parameter NewBudget_TimeUnit
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
        public Amazon.Budgets.TimeUnit NewBudget_TimeUnit { get; set; }
        #endregion
        
        #region Parameter BudgetLimit_Unit
        /// <summary>
        /// <para>
        /// <para>The unit of measurement that's used for the budget forecast, actual spend, or budget
        /// threshold.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NewBudget_BudgetLimit_Unit")]
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
        [Alias("NewBudget_CalculatedSpend_ActualSpend_Unit")]
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
        [Alias("NewBudget_CalculatedSpend_ForecastedSpend_Unit")]
        public System.String ForecastedSpend_Unit { get; set; }
        #endregion
        
        #region Parameter CostTypes_UseAmortized
        /// <summary>
        /// <para>
        /// <para>Specifies whether a budget uses the amortized rate.</para><para>The default value is <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NewBudget_CostTypes_UseAmortized")]
        public System.Boolean? CostTypes_UseAmortized { get; set; }
        #endregion
        
        #region Parameter CostTypes_UseBlended
        /// <summary>
        /// <para>
        /// <para>Specifies whether a budget uses a blended rate.</para><para>The default value is <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NewBudget_CostTypes_UseBlended")]
        public System.Boolean? CostTypes_UseBlended { get; set; }
        #endregion
        
        #region Parameter NewBudget_CostFilter
        /// <summary>
        /// <para>
        /// <para>The cost filters, such as <c>Region</c>, <c>Service</c>, <c>LinkedAccount</c>, <c>Tag</c>,
        /// or <c>CostCategory</c>, that are applied to a budget.</para><para>Amazon Web Services Budgets supports the following services as a <c>Service</c> filter
        /// for RI budgets:</para><ul><li><para>Amazon EC2</para></li><li><para>Amazon Redshift</para></li><li><para>Amazon Relational Database Service</para></li><li><para>Amazon ElastiCache</para></li><li><para>Amazon OpenSearch Service</para></li></ul><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("CostFilters lack support for newer dimensions and filtering options. Please consider using the new \u0027FilterExpression\u0027 field.")]
        [Alias("NewBudget_CostFilters")]
        public System.Collections.Hashtable NewBudget_CostFilter { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Budgets.Model.UpdateBudgetResponse).
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AccountId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BGTBudget (UpdateBudget)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Budgets.Model.UpdateBudgetResponse, UpdateBGTBudgetCmdlet>(Select) ??
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
            context.NewBudget_BudgetName = this.NewBudget_BudgetName;
            #if MODULAR
            if (this.NewBudget_BudgetName == null && ParameterWasBound(nameof(this.NewBudget_BudgetName)))
            {
                WriteWarning("You are passing $null as a value for parameter NewBudget_BudgetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NewBudget_BudgetType = this.NewBudget_BudgetType;
            #if MODULAR
            if (this.NewBudget_BudgetType == null && ParameterWasBound(nameof(this.NewBudget_BudgetType)))
            {
                WriteWarning("You are passing $null as a value for parameter NewBudget_BudgetType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ActualSpend_Amount = this.ActualSpend_Amount;
            context.ActualSpend_Unit = this.ActualSpend_Unit;
            context.ForecastedSpend_Amount = this.ForecastedSpend_Amount;
            context.ForecastedSpend_Unit = this.ForecastedSpend_Unit;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.NewBudget_CostFilter != null)
            {
                context.NewBudget_CostFilter = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.NewBudget_CostFilter.Keys)
                {
                    object hashValue = this.NewBudget_CostFilter[hashKey];
                    if (hashValue == null)
                    {
                        context.NewBudget_CostFilter.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<System.String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((System.String)s);
                    }
                    context.NewBudget_CostFilter.Add((String)hashKey, valueSet);
                }
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
            context.NewBudget_FilterExpression = this.NewBudget_FilterExpression;
            context.NewBudget_LastUpdatedTime = this.NewBudget_LastUpdatedTime;
            if (this.NewBudget_Metric != null)
            {
                context.NewBudget_Metric = new List<System.String>(this.NewBudget_Metric);
            }
            if (this.NewBudget_PlannedBudgetLimit != null)
            {
                context.NewBudget_PlannedBudgetLimit = new Dictionary<System.String, Amazon.Budgets.Model.Spend>(StringComparer.Ordinal);
                foreach (var hashKey in this.NewBudget_PlannedBudgetLimit.Keys)
                {
                    context.NewBudget_PlannedBudgetLimit.Add((String)hashKey, (Amazon.Budgets.Model.Spend)(this.NewBudget_PlannedBudgetLimit[hashKey]));
                }
            }
            context.TimePeriod_End = this.TimePeriod_End;
            context.TimePeriod_Start = this.TimePeriod_Start;
            context.NewBudget_TimeUnit = this.NewBudget_TimeUnit;
            #if MODULAR
            if (this.NewBudget_TimeUnit == null && ParameterWasBound(nameof(this.NewBudget_TimeUnit)))
            {
                WriteWarning("You are passing $null as a value for parameter NewBudget_TimeUnit which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Budgets.Model.UpdateBudgetRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            
             // populate NewBudget
            var requestNewBudgetIsNull = true;
            request.NewBudget = new Amazon.Budgets.Model.Budget();
            System.String requestNewBudget_newBudget_BudgetName = null;
            if (cmdletContext.NewBudget_BudgetName != null)
            {
                requestNewBudget_newBudget_BudgetName = cmdletContext.NewBudget_BudgetName;
            }
            if (requestNewBudget_newBudget_BudgetName != null)
            {
                request.NewBudget.BudgetName = requestNewBudget_newBudget_BudgetName;
                requestNewBudgetIsNull = false;
            }
            Amazon.Budgets.BudgetType requestNewBudget_newBudget_BudgetType = null;
            if (cmdletContext.NewBudget_BudgetType != null)
            {
                requestNewBudget_newBudget_BudgetType = cmdletContext.NewBudget_BudgetType;
            }
            if (requestNewBudget_newBudget_BudgetType != null)
            {
                request.NewBudget.BudgetType = requestNewBudget_newBudget_BudgetType;
                requestNewBudgetIsNull = false;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            Dictionary<System.String, List<System.String>> requestNewBudget_newBudget_CostFilter = null;
            if (cmdletContext.NewBudget_CostFilter != null)
            {
                requestNewBudget_newBudget_CostFilter = cmdletContext.NewBudget_CostFilter;
            }
            if (requestNewBudget_newBudget_CostFilter != null)
            {
                request.NewBudget.CostFilters = requestNewBudget_newBudget_CostFilter;
                requestNewBudgetIsNull = false;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            Amazon.Budgets.Model.Expression requestNewBudget_newBudget_FilterExpression = null;
            if (cmdletContext.NewBudget_FilterExpression != null)
            {
                requestNewBudget_newBudget_FilterExpression = cmdletContext.NewBudget_FilterExpression;
            }
            if (requestNewBudget_newBudget_FilterExpression != null)
            {
                request.NewBudget.FilterExpression = requestNewBudget_newBudget_FilterExpression;
                requestNewBudgetIsNull = false;
            }
            System.DateTime? requestNewBudget_newBudget_LastUpdatedTime = null;
            if (cmdletContext.NewBudget_LastUpdatedTime != null)
            {
                requestNewBudget_newBudget_LastUpdatedTime = cmdletContext.NewBudget_LastUpdatedTime.Value;
            }
            if (requestNewBudget_newBudget_LastUpdatedTime != null)
            {
                request.NewBudget.LastUpdatedTime = requestNewBudget_newBudget_LastUpdatedTime.Value;
                requestNewBudgetIsNull = false;
            }
            List<System.String> requestNewBudget_newBudget_Metric = null;
            if (cmdletContext.NewBudget_Metric != null)
            {
                requestNewBudget_newBudget_Metric = cmdletContext.NewBudget_Metric;
            }
            if (requestNewBudget_newBudget_Metric != null)
            {
                request.NewBudget.Metrics = requestNewBudget_newBudget_Metric;
                requestNewBudgetIsNull = false;
            }
            Dictionary<System.String, Amazon.Budgets.Model.Spend> requestNewBudget_newBudget_PlannedBudgetLimit = null;
            if (cmdletContext.NewBudget_PlannedBudgetLimit != null)
            {
                requestNewBudget_newBudget_PlannedBudgetLimit = cmdletContext.NewBudget_PlannedBudgetLimit;
            }
            if (requestNewBudget_newBudget_PlannedBudgetLimit != null)
            {
                request.NewBudget.PlannedBudgetLimits = requestNewBudget_newBudget_PlannedBudgetLimit;
                requestNewBudgetIsNull = false;
            }
            Amazon.Budgets.TimeUnit requestNewBudget_newBudget_TimeUnit = null;
            if (cmdletContext.NewBudget_TimeUnit != null)
            {
                requestNewBudget_newBudget_TimeUnit = cmdletContext.NewBudget_TimeUnit;
            }
            if (requestNewBudget_newBudget_TimeUnit != null)
            {
                request.NewBudget.TimeUnit = requestNewBudget_newBudget_TimeUnit;
                requestNewBudgetIsNull = false;
            }
            Amazon.Budgets.Model.Spend requestNewBudget_newBudget_BudgetLimit = null;
            
             // populate BudgetLimit
            var requestNewBudget_newBudget_BudgetLimitIsNull = true;
            requestNewBudget_newBudget_BudgetLimit = new Amazon.Budgets.Model.Spend();
            System.Decimal? requestNewBudget_newBudget_BudgetLimit_budgetLimit_Amount = null;
            if (cmdletContext.BudgetLimit_Amount != null)
            {
                requestNewBudget_newBudget_BudgetLimit_budgetLimit_Amount = cmdletContext.BudgetLimit_Amount.Value;
            }
            if (requestNewBudget_newBudget_BudgetLimit_budgetLimit_Amount != null)
            {
                requestNewBudget_newBudget_BudgetLimit.Amount = requestNewBudget_newBudget_BudgetLimit_budgetLimit_Amount.Value;
                requestNewBudget_newBudget_BudgetLimitIsNull = false;
            }
            System.String requestNewBudget_newBudget_BudgetLimit_budgetLimit_Unit = null;
            if (cmdletContext.BudgetLimit_Unit != null)
            {
                requestNewBudget_newBudget_BudgetLimit_budgetLimit_Unit = cmdletContext.BudgetLimit_Unit;
            }
            if (requestNewBudget_newBudget_BudgetLimit_budgetLimit_Unit != null)
            {
                requestNewBudget_newBudget_BudgetLimit.Unit = requestNewBudget_newBudget_BudgetLimit_budgetLimit_Unit;
                requestNewBudget_newBudget_BudgetLimitIsNull = false;
            }
             // determine if requestNewBudget_newBudget_BudgetLimit should be set to null
            if (requestNewBudget_newBudget_BudgetLimitIsNull)
            {
                requestNewBudget_newBudget_BudgetLimit = null;
            }
            if (requestNewBudget_newBudget_BudgetLimit != null)
            {
                request.NewBudget.BudgetLimit = requestNewBudget_newBudget_BudgetLimit;
                requestNewBudgetIsNull = false;
            }
            Amazon.Budgets.Model.CalculatedSpend requestNewBudget_newBudget_CalculatedSpend = null;
            
             // populate CalculatedSpend
            var requestNewBudget_newBudget_CalculatedSpendIsNull = true;
            requestNewBudget_newBudget_CalculatedSpend = new Amazon.Budgets.Model.CalculatedSpend();
            Amazon.Budgets.Model.Spend requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ActualSpend = null;
            
             // populate ActualSpend
            var requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ActualSpendIsNull = true;
            requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ActualSpend = new Amazon.Budgets.Model.Spend();
            System.Decimal? requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ActualSpend_actualSpend_Amount = null;
            if (cmdletContext.ActualSpend_Amount != null)
            {
                requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ActualSpend_actualSpend_Amount = cmdletContext.ActualSpend_Amount.Value;
            }
            if (requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ActualSpend_actualSpend_Amount != null)
            {
                requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ActualSpend.Amount = requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ActualSpend_actualSpend_Amount.Value;
                requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ActualSpendIsNull = false;
            }
            System.String requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ActualSpend_actualSpend_Unit = null;
            if (cmdletContext.ActualSpend_Unit != null)
            {
                requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ActualSpend_actualSpend_Unit = cmdletContext.ActualSpend_Unit;
            }
            if (requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ActualSpend_actualSpend_Unit != null)
            {
                requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ActualSpend.Unit = requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ActualSpend_actualSpend_Unit;
                requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ActualSpendIsNull = false;
            }
             // determine if requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ActualSpend should be set to null
            if (requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ActualSpendIsNull)
            {
                requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ActualSpend = null;
            }
            if (requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ActualSpend != null)
            {
                requestNewBudget_newBudget_CalculatedSpend.ActualSpend = requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ActualSpend;
                requestNewBudget_newBudget_CalculatedSpendIsNull = false;
            }
            Amazon.Budgets.Model.Spend requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ForecastedSpend = null;
            
             // populate ForecastedSpend
            var requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ForecastedSpendIsNull = true;
            requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ForecastedSpend = new Amazon.Budgets.Model.Spend();
            System.Decimal? requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ForecastedSpend_forecastedSpend_Amount = null;
            if (cmdletContext.ForecastedSpend_Amount != null)
            {
                requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ForecastedSpend_forecastedSpend_Amount = cmdletContext.ForecastedSpend_Amount.Value;
            }
            if (requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ForecastedSpend_forecastedSpend_Amount != null)
            {
                requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ForecastedSpend.Amount = requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ForecastedSpend_forecastedSpend_Amount.Value;
                requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ForecastedSpendIsNull = false;
            }
            System.String requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ForecastedSpend_forecastedSpend_Unit = null;
            if (cmdletContext.ForecastedSpend_Unit != null)
            {
                requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ForecastedSpend_forecastedSpend_Unit = cmdletContext.ForecastedSpend_Unit;
            }
            if (requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ForecastedSpend_forecastedSpend_Unit != null)
            {
                requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ForecastedSpend.Unit = requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ForecastedSpend_forecastedSpend_Unit;
                requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ForecastedSpendIsNull = false;
            }
             // determine if requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ForecastedSpend should be set to null
            if (requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ForecastedSpendIsNull)
            {
                requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ForecastedSpend = null;
            }
            if (requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ForecastedSpend != null)
            {
                requestNewBudget_newBudget_CalculatedSpend.ForecastedSpend = requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ForecastedSpend;
                requestNewBudget_newBudget_CalculatedSpendIsNull = false;
            }
             // determine if requestNewBudget_newBudget_CalculatedSpend should be set to null
            if (requestNewBudget_newBudget_CalculatedSpendIsNull)
            {
                requestNewBudget_newBudget_CalculatedSpend = null;
            }
            if (requestNewBudget_newBudget_CalculatedSpend != null)
            {
                request.NewBudget.CalculatedSpend = requestNewBudget_newBudget_CalculatedSpend;
                requestNewBudgetIsNull = false;
            }
            Amazon.Budgets.Model.TimePeriod requestNewBudget_newBudget_TimePeriod = null;
            
             // populate TimePeriod
            var requestNewBudget_newBudget_TimePeriodIsNull = true;
            requestNewBudget_newBudget_TimePeriod = new Amazon.Budgets.Model.TimePeriod();
            System.DateTime? requestNewBudget_newBudget_TimePeriod_timePeriod_End = null;
            if (cmdletContext.TimePeriod_End != null)
            {
                requestNewBudget_newBudget_TimePeriod_timePeriod_End = cmdletContext.TimePeriod_End.Value;
            }
            if (requestNewBudget_newBudget_TimePeriod_timePeriod_End != null)
            {
                requestNewBudget_newBudget_TimePeriod.End = requestNewBudget_newBudget_TimePeriod_timePeriod_End.Value;
                requestNewBudget_newBudget_TimePeriodIsNull = false;
            }
            System.DateTime? requestNewBudget_newBudget_TimePeriod_timePeriod_Start = null;
            if (cmdletContext.TimePeriod_Start != null)
            {
                requestNewBudget_newBudget_TimePeriod_timePeriod_Start = cmdletContext.TimePeriod_Start.Value;
            }
            if (requestNewBudget_newBudget_TimePeriod_timePeriod_Start != null)
            {
                requestNewBudget_newBudget_TimePeriod.Start = requestNewBudget_newBudget_TimePeriod_timePeriod_Start.Value;
                requestNewBudget_newBudget_TimePeriodIsNull = false;
            }
             // determine if requestNewBudget_newBudget_TimePeriod should be set to null
            if (requestNewBudget_newBudget_TimePeriodIsNull)
            {
                requestNewBudget_newBudget_TimePeriod = null;
            }
            if (requestNewBudget_newBudget_TimePeriod != null)
            {
                request.NewBudget.TimePeriod = requestNewBudget_newBudget_TimePeriod;
                requestNewBudgetIsNull = false;
            }
            Amazon.Budgets.Model.AutoAdjustData requestNewBudget_newBudget_AutoAdjustData = null;
            
             // populate AutoAdjustData
            var requestNewBudget_newBudget_AutoAdjustDataIsNull = true;
            requestNewBudget_newBudget_AutoAdjustData = new Amazon.Budgets.Model.AutoAdjustData();
            Amazon.Budgets.AutoAdjustType requestNewBudget_newBudget_AutoAdjustData_autoAdjustData_AutoAdjustType = null;
            if (cmdletContext.AutoAdjustData_AutoAdjustType != null)
            {
                requestNewBudget_newBudget_AutoAdjustData_autoAdjustData_AutoAdjustType = cmdletContext.AutoAdjustData_AutoAdjustType;
            }
            if (requestNewBudget_newBudget_AutoAdjustData_autoAdjustData_AutoAdjustType != null)
            {
                requestNewBudget_newBudget_AutoAdjustData.AutoAdjustType = requestNewBudget_newBudget_AutoAdjustData_autoAdjustData_AutoAdjustType;
                requestNewBudget_newBudget_AutoAdjustDataIsNull = false;
            }
            System.DateTime? requestNewBudget_newBudget_AutoAdjustData_autoAdjustData_LastAutoAdjustTime = null;
            if (cmdletContext.AutoAdjustData_LastAutoAdjustTime != null)
            {
                requestNewBudget_newBudget_AutoAdjustData_autoAdjustData_LastAutoAdjustTime = cmdletContext.AutoAdjustData_LastAutoAdjustTime.Value;
            }
            if (requestNewBudget_newBudget_AutoAdjustData_autoAdjustData_LastAutoAdjustTime != null)
            {
                requestNewBudget_newBudget_AutoAdjustData.LastAutoAdjustTime = requestNewBudget_newBudget_AutoAdjustData_autoAdjustData_LastAutoAdjustTime.Value;
                requestNewBudget_newBudget_AutoAdjustDataIsNull = false;
            }
            Amazon.Budgets.Model.HistoricalOptions requestNewBudget_newBudget_AutoAdjustData_newBudget_AutoAdjustData_HistoricalOptions = null;
            
             // populate HistoricalOptions
            var requestNewBudget_newBudget_AutoAdjustData_newBudget_AutoAdjustData_HistoricalOptionsIsNull = true;
            requestNewBudget_newBudget_AutoAdjustData_newBudget_AutoAdjustData_HistoricalOptions = new Amazon.Budgets.Model.HistoricalOptions();
            System.Int32? requestNewBudget_newBudget_AutoAdjustData_newBudget_AutoAdjustData_HistoricalOptions_historicalOptions_BudgetAdjustmentPeriod = null;
            if (cmdletContext.HistoricalOptions_BudgetAdjustmentPeriod != null)
            {
                requestNewBudget_newBudget_AutoAdjustData_newBudget_AutoAdjustData_HistoricalOptions_historicalOptions_BudgetAdjustmentPeriod = cmdletContext.HistoricalOptions_BudgetAdjustmentPeriod.Value;
            }
            if (requestNewBudget_newBudget_AutoAdjustData_newBudget_AutoAdjustData_HistoricalOptions_historicalOptions_BudgetAdjustmentPeriod != null)
            {
                requestNewBudget_newBudget_AutoAdjustData_newBudget_AutoAdjustData_HistoricalOptions.BudgetAdjustmentPeriod = requestNewBudget_newBudget_AutoAdjustData_newBudget_AutoAdjustData_HistoricalOptions_historicalOptions_BudgetAdjustmentPeriod.Value;
                requestNewBudget_newBudget_AutoAdjustData_newBudget_AutoAdjustData_HistoricalOptionsIsNull = false;
            }
            System.Int32? requestNewBudget_newBudget_AutoAdjustData_newBudget_AutoAdjustData_HistoricalOptions_historicalOptions_LookBackAvailablePeriod = null;
            if (cmdletContext.HistoricalOptions_LookBackAvailablePeriod != null)
            {
                requestNewBudget_newBudget_AutoAdjustData_newBudget_AutoAdjustData_HistoricalOptions_historicalOptions_LookBackAvailablePeriod = cmdletContext.HistoricalOptions_LookBackAvailablePeriod.Value;
            }
            if (requestNewBudget_newBudget_AutoAdjustData_newBudget_AutoAdjustData_HistoricalOptions_historicalOptions_LookBackAvailablePeriod != null)
            {
                requestNewBudget_newBudget_AutoAdjustData_newBudget_AutoAdjustData_HistoricalOptions.LookBackAvailablePeriods = requestNewBudget_newBudget_AutoAdjustData_newBudget_AutoAdjustData_HistoricalOptions_historicalOptions_LookBackAvailablePeriod.Value;
                requestNewBudget_newBudget_AutoAdjustData_newBudget_AutoAdjustData_HistoricalOptionsIsNull = false;
            }
             // determine if requestNewBudget_newBudget_AutoAdjustData_newBudget_AutoAdjustData_HistoricalOptions should be set to null
            if (requestNewBudget_newBudget_AutoAdjustData_newBudget_AutoAdjustData_HistoricalOptionsIsNull)
            {
                requestNewBudget_newBudget_AutoAdjustData_newBudget_AutoAdjustData_HistoricalOptions = null;
            }
            if (requestNewBudget_newBudget_AutoAdjustData_newBudget_AutoAdjustData_HistoricalOptions != null)
            {
                requestNewBudget_newBudget_AutoAdjustData.HistoricalOptions = requestNewBudget_newBudget_AutoAdjustData_newBudget_AutoAdjustData_HistoricalOptions;
                requestNewBudget_newBudget_AutoAdjustDataIsNull = false;
            }
             // determine if requestNewBudget_newBudget_AutoAdjustData should be set to null
            if (requestNewBudget_newBudget_AutoAdjustDataIsNull)
            {
                requestNewBudget_newBudget_AutoAdjustData = null;
            }
            if (requestNewBudget_newBudget_AutoAdjustData != null)
            {
                request.NewBudget.AutoAdjustData = requestNewBudget_newBudget_AutoAdjustData;
                requestNewBudgetIsNull = false;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            Amazon.Budgets.Model.CostTypes requestNewBudget_newBudget_CostTypes = null;
            
             // populate CostTypes
            var requestNewBudget_newBudget_CostTypesIsNull = true;
            requestNewBudget_newBudget_CostTypes = new Amazon.Budgets.Model.CostTypes();
            System.Boolean? requestNewBudget_newBudget_CostTypes_costTypes_IncludeCredit = null;
            if (cmdletContext.CostTypes_IncludeCredit != null)
            {
                requestNewBudget_newBudget_CostTypes_costTypes_IncludeCredit = cmdletContext.CostTypes_IncludeCredit.Value;
            }
            if (requestNewBudget_newBudget_CostTypes_costTypes_IncludeCredit != null)
            {
                requestNewBudget_newBudget_CostTypes.IncludeCredit = requestNewBudget_newBudget_CostTypes_costTypes_IncludeCredit.Value;
                requestNewBudget_newBudget_CostTypesIsNull = false;
            }
            System.Boolean? requestNewBudget_newBudget_CostTypes_costTypes_IncludeDiscount = null;
            if (cmdletContext.CostTypes_IncludeDiscount != null)
            {
                requestNewBudget_newBudget_CostTypes_costTypes_IncludeDiscount = cmdletContext.CostTypes_IncludeDiscount.Value;
            }
            if (requestNewBudget_newBudget_CostTypes_costTypes_IncludeDiscount != null)
            {
                requestNewBudget_newBudget_CostTypes.IncludeDiscount = requestNewBudget_newBudget_CostTypes_costTypes_IncludeDiscount.Value;
                requestNewBudget_newBudget_CostTypesIsNull = false;
            }
            System.Boolean? requestNewBudget_newBudget_CostTypes_costTypes_IncludeOtherSubscription = null;
            if (cmdletContext.CostTypes_IncludeOtherSubscription != null)
            {
                requestNewBudget_newBudget_CostTypes_costTypes_IncludeOtherSubscription = cmdletContext.CostTypes_IncludeOtherSubscription.Value;
            }
            if (requestNewBudget_newBudget_CostTypes_costTypes_IncludeOtherSubscription != null)
            {
                requestNewBudget_newBudget_CostTypes.IncludeOtherSubscription = requestNewBudget_newBudget_CostTypes_costTypes_IncludeOtherSubscription.Value;
                requestNewBudget_newBudget_CostTypesIsNull = false;
            }
            System.Boolean? requestNewBudget_newBudget_CostTypes_costTypes_IncludeRecurring = null;
            if (cmdletContext.CostTypes_IncludeRecurring != null)
            {
                requestNewBudget_newBudget_CostTypes_costTypes_IncludeRecurring = cmdletContext.CostTypes_IncludeRecurring.Value;
            }
            if (requestNewBudget_newBudget_CostTypes_costTypes_IncludeRecurring != null)
            {
                requestNewBudget_newBudget_CostTypes.IncludeRecurring = requestNewBudget_newBudget_CostTypes_costTypes_IncludeRecurring.Value;
                requestNewBudget_newBudget_CostTypesIsNull = false;
            }
            System.Boolean? requestNewBudget_newBudget_CostTypes_costTypes_IncludeRefund = null;
            if (cmdletContext.CostTypes_IncludeRefund != null)
            {
                requestNewBudget_newBudget_CostTypes_costTypes_IncludeRefund = cmdletContext.CostTypes_IncludeRefund.Value;
            }
            if (requestNewBudget_newBudget_CostTypes_costTypes_IncludeRefund != null)
            {
                requestNewBudget_newBudget_CostTypes.IncludeRefund = requestNewBudget_newBudget_CostTypes_costTypes_IncludeRefund.Value;
                requestNewBudget_newBudget_CostTypesIsNull = false;
            }
            System.Boolean? requestNewBudget_newBudget_CostTypes_costTypes_IncludeSubscription = null;
            if (cmdletContext.CostTypes_IncludeSubscription != null)
            {
                requestNewBudget_newBudget_CostTypes_costTypes_IncludeSubscription = cmdletContext.CostTypes_IncludeSubscription.Value;
            }
            if (requestNewBudget_newBudget_CostTypes_costTypes_IncludeSubscription != null)
            {
                requestNewBudget_newBudget_CostTypes.IncludeSubscription = requestNewBudget_newBudget_CostTypes_costTypes_IncludeSubscription.Value;
                requestNewBudget_newBudget_CostTypesIsNull = false;
            }
            System.Boolean? requestNewBudget_newBudget_CostTypes_costTypes_IncludeSupport = null;
            if (cmdletContext.CostTypes_IncludeSupport != null)
            {
                requestNewBudget_newBudget_CostTypes_costTypes_IncludeSupport = cmdletContext.CostTypes_IncludeSupport.Value;
            }
            if (requestNewBudget_newBudget_CostTypes_costTypes_IncludeSupport != null)
            {
                requestNewBudget_newBudget_CostTypes.IncludeSupport = requestNewBudget_newBudget_CostTypes_costTypes_IncludeSupport.Value;
                requestNewBudget_newBudget_CostTypesIsNull = false;
            }
            System.Boolean? requestNewBudget_newBudget_CostTypes_costTypes_IncludeTax = null;
            if (cmdletContext.CostTypes_IncludeTax != null)
            {
                requestNewBudget_newBudget_CostTypes_costTypes_IncludeTax = cmdletContext.CostTypes_IncludeTax.Value;
            }
            if (requestNewBudget_newBudget_CostTypes_costTypes_IncludeTax != null)
            {
                requestNewBudget_newBudget_CostTypes.IncludeTax = requestNewBudget_newBudget_CostTypes_costTypes_IncludeTax.Value;
                requestNewBudget_newBudget_CostTypesIsNull = false;
            }
            System.Boolean? requestNewBudget_newBudget_CostTypes_costTypes_IncludeUpfront = null;
            if (cmdletContext.CostTypes_IncludeUpfront != null)
            {
                requestNewBudget_newBudget_CostTypes_costTypes_IncludeUpfront = cmdletContext.CostTypes_IncludeUpfront.Value;
            }
            if (requestNewBudget_newBudget_CostTypes_costTypes_IncludeUpfront != null)
            {
                requestNewBudget_newBudget_CostTypes.IncludeUpfront = requestNewBudget_newBudget_CostTypes_costTypes_IncludeUpfront.Value;
                requestNewBudget_newBudget_CostTypesIsNull = false;
            }
            System.Boolean? requestNewBudget_newBudget_CostTypes_costTypes_UseAmortized = null;
            if (cmdletContext.CostTypes_UseAmortized != null)
            {
                requestNewBudget_newBudget_CostTypes_costTypes_UseAmortized = cmdletContext.CostTypes_UseAmortized.Value;
            }
            if (requestNewBudget_newBudget_CostTypes_costTypes_UseAmortized != null)
            {
                requestNewBudget_newBudget_CostTypes.UseAmortized = requestNewBudget_newBudget_CostTypes_costTypes_UseAmortized.Value;
                requestNewBudget_newBudget_CostTypesIsNull = false;
            }
            System.Boolean? requestNewBudget_newBudget_CostTypes_costTypes_UseBlended = null;
            if (cmdletContext.CostTypes_UseBlended != null)
            {
                requestNewBudget_newBudget_CostTypes_costTypes_UseBlended = cmdletContext.CostTypes_UseBlended.Value;
            }
            if (requestNewBudget_newBudget_CostTypes_costTypes_UseBlended != null)
            {
                requestNewBudget_newBudget_CostTypes.UseBlended = requestNewBudget_newBudget_CostTypes_costTypes_UseBlended.Value;
                requestNewBudget_newBudget_CostTypesIsNull = false;
            }
             // determine if requestNewBudget_newBudget_CostTypes should be set to null
            if (requestNewBudget_newBudget_CostTypesIsNull)
            {
                requestNewBudget_newBudget_CostTypes = null;
            }
            if (requestNewBudget_newBudget_CostTypes != null)
            {
                request.NewBudget.CostTypes = requestNewBudget_newBudget_CostTypes;
                requestNewBudgetIsNull = false;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
             // determine if request.NewBudget should be set to null
            if (requestNewBudgetIsNull)
            {
                request.NewBudget = null;
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
        
        private Amazon.Budgets.Model.UpdateBudgetResponse CallAWSServiceOperation(IAmazonBudgets client, Amazon.Budgets.Model.UpdateBudgetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Budgets", "UpdateBudget");
            try
            {
                return client.UpdateBudgetAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String NewBudget_BudgetName { get; set; }
            public Amazon.Budgets.BudgetType NewBudget_BudgetType { get; set; }
            public System.Decimal? ActualSpend_Amount { get; set; }
            public System.String ActualSpend_Unit { get; set; }
            public System.Decimal? ForecastedSpend_Amount { get; set; }
            public System.String ForecastedSpend_Unit { get; set; }
            [System.ObsoleteAttribute]
            public Dictionary<System.String, List<System.String>> NewBudget_CostFilter { get; set; }
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
            public Amazon.Budgets.Model.Expression NewBudget_FilterExpression { get; set; }
            public System.DateTime? NewBudget_LastUpdatedTime { get; set; }
            public List<System.String> NewBudget_Metric { get; set; }
            public Dictionary<System.String, Amazon.Budgets.Model.Spend> NewBudget_PlannedBudgetLimit { get; set; }
            public System.DateTime? TimePeriod_End { get; set; }
            public System.DateTime? TimePeriod_Start { get; set; }
            public Amazon.Budgets.TimeUnit NewBudget_TimeUnit { get; set; }
            public System.Func<Amazon.Budgets.Model.UpdateBudgetResponse, UpdateBGTBudgetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
