/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// </summary>
    [Cmdlet("New", "BGTBudget", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the AWS Budgets CreateBudget API operation.", Operation = new[] {"CreateBudget"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the AccountId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.Budgets.Model.CreateBudgetResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewBGTBudgetCmdlet : AmazonBudgetsClientCmdlet, IExecutor
    {
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The <code>accountId</code> that is associated with the budget.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter BudgetLimit_Amount
        /// <summary>
        /// <para>
        /// <para>The cost or usage amount that is associated with a budget forecast, actual spend,
        /// or budget threshold.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Budget_BudgetLimit_Amount")]
        public System.Decimal BudgetLimit_Amount { get; set; }
        #endregion
        
        #region Parameter ActualSpend_Amount
        /// <summary>
        /// <para>
        /// <para>The cost or usage amount that is associated with a budget forecast, actual spend,
        /// or budget threshold.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Budget_CalculatedSpend_ActualSpend_Amount")]
        public System.Decimal ActualSpend_Amount { get; set; }
        #endregion
        
        #region Parameter ForecastedSpend_Amount
        /// <summary>
        /// <para>
        /// <para>The cost or usage amount that is associated with a budget forecast, actual spend,
        /// or budget threshold.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Budget_CalculatedSpend_ForecastedSpend_Amount")]
        public System.Decimal ForecastedSpend_Amount { get; set; }
        #endregion
        
        #region Parameter Budget_BudgetName
        /// <summary>
        /// <para>
        /// <para>The name of a budget. The name must be unique within accounts. The <code>:</code>
        /// and <code>\</code> characters aren't allowed in <code>BudgetName</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Budget_BudgetName { get; set; }
        #endregion
        
        #region Parameter Budget_BudgetType
        /// <summary>
        /// <para>
        /// <para>Whether this budget tracks monetary costs, usage, RI utilization, or RI coverage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Budgets.BudgetType")]
        public Amazon.Budgets.BudgetType Budget_BudgetType { get; set; }
        #endregion
        
        #region Parameter Budget_CostFilter
        /// <summary>
        /// <para>
        /// <para>The cost filters, such as service or region, that are applied to a budget.</para><para>AWS Budgets supports the following services as a filter for RI budgets:</para><ul><li><para>Amazon Elastic Compute Cloud - Compute</para></li><li><para>Amazon Redshift</para></li><li><para>Amazon Relational Database Service</para></li><li><para>Amazon ElastiCache</para></li><li><para>Amazon Elasticsearch Service</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Budget_CostFilters")]
        public System.Collections.Hashtable Budget_CostFilter { get; set; }
        #endregion
        
        #region Parameter TimePeriod_End
        /// <summary>
        /// <para>
        /// <para>The end date for a budget. If you didn't specify an end date, AWS set your end date
        /// to <code>06/15/87 00:00 UTC</code>. The defaults are the same for the AWS Billing
        /// and Cost Management console and the API.</para><para>After the end date, AWS deletes the budget and all associated notifications and subscribers.
        /// You can change your end date with the <code>UpdateBudget</code> operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Budget_TimePeriod_End")]
        public System.DateTime TimePeriod_End { get; set; }
        #endregion
        
        #region Parameter CostTypes_IncludeCredit
        /// <summary>
        /// <para>
        /// <para>Specifies whether a budget includes credits.</para><para>The default value is <code>true</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Budget_CostTypes_IncludeCredit")]
        public System.Boolean CostTypes_IncludeCredit { get; set; }
        #endregion
        
        #region Parameter CostTypes_IncludeDiscount
        /// <summary>
        /// <para>
        /// <para>Specifies whether a budget includes discounts.</para><para>The default value is <code>true</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Budget_CostTypes_IncludeDiscount")]
        public System.Boolean CostTypes_IncludeDiscount { get; set; }
        #endregion
        
        #region Parameter CostTypes_IncludeOtherSubscription
        /// <summary>
        /// <para>
        /// <para>Specifies whether a budget includes non-RI subscription costs.</para><para>The default value is <code>true</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Budget_CostTypes_IncludeOtherSubscription")]
        public System.Boolean CostTypes_IncludeOtherSubscription { get; set; }
        #endregion
        
        #region Parameter CostTypes_IncludeRecurring
        /// <summary>
        /// <para>
        /// <para>Specifies whether a budget includes recurring fees such as monthly RI fees.</para><para>The default value is <code>true</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Budget_CostTypes_IncludeRecurring")]
        public System.Boolean CostTypes_IncludeRecurring { get; set; }
        #endregion
        
        #region Parameter CostTypes_IncludeRefund
        /// <summary>
        /// <para>
        /// <para>Specifies whether a budget includes refunds.</para><para>The default value is <code>true</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Budget_CostTypes_IncludeRefund")]
        public System.Boolean CostTypes_IncludeRefund { get; set; }
        #endregion
        
        #region Parameter CostTypes_IncludeSubscription
        /// <summary>
        /// <para>
        /// <para>Specifies whether a budget includes subscriptions.</para><para>The default value is <code>true</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Budget_CostTypes_IncludeSubscription")]
        public System.Boolean CostTypes_IncludeSubscription { get; set; }
        #endregion
        
        #region Parameter CostTypes_IncludeSupport
        /// <summary>
        /// <para>
        /// <para>Specifies whether a budget includes support subscription fees.</para><para>The default value is <code>true</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Budget_CostTypes_IncludeSupport")]
        public System.Boolean CostTypes_IncludeSupport { get; set; }
        #endregion
        
        #region Parameter CostTypes_IncludeTax
        /// <summary>
        /// <para>
        /// <para>Specifies whether a budget includes taxes.</para><para>The default value is <code>true</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Budget_CostTypes_IncludeTax")]
        public System.Boolean CostTypes_IncludeTax { get; set; }
        #endregion
        
        #region Parameter CostTypes_IncludeUpfront
        /// <summary>
        /// <para>
        /// <para>Specifies whether a budget includes upfront RI costs.</para><para>The default value is <code>true</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Budget_CostTypes_IncludeUpfront")]
        public System.Boolean CostTypes_IncludeUpfront { get; set; }
        #endregion
        
        #region Parameter Budget_LastUpdatedTime
        /// <summary>
        /// <para>
        /// <para>The last time that you updated this budget.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime Budget_LastUpdatedTime { get; set; }
        #endregion
        
        #region Parameter NotificationsWithSubscriber
        /// <summary>
        /// <para>
        /// <para>A notification that you want to associate with a budget. A budget can have up to five
        /// notifications, and each notification can have one SNS subscriber and up to 10 email
        /// subscribers. If you include notifications and subscribers in your <code>CreateBudget</code>
        /// call, AWS creates the notifications and subscribers for you.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NotificationsWithSubscribers")]
        public Amazon.Budgets.Model.NotificationWithSubscribers[] NotificationsWithSubscriber { get; set; }
        #endregion
        
        #region Parameter TimePeriod_Start
        /// <summary>
        /// <para>
        /// <para>The start date for a budget. If you created your budget and didn't specify a start
        /// date, AWS defaults to the start of your chosen time period (DAILY, MONTHLY, QUARTERLY,
        /// or ANNUALLY). For example, if you created your budget on January 24, 2018, chose <code>DAILY</code>,
        /// and didn't set a start date, AWS set your start date to <code>01/24/18 00:00 UTC</code>.
        /// If you chose <code>MONTHLY</code>, AWS set your start date to <code>01/01/18 00:00
        /// UTC</code>. The defaults are the same for the AWS Billing and Cost Management console
        /// and the API.</para><para>You can change your start date with the <code>UpdateBudget</code> operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Budget_TimePeriod_Start")]
        public System.DateTime TimePeriod_Start { get; set; }
        #endregion
        
        #region Parameter Budget_TimeUnit
        /// <summary>
        /// <para>
        /// <para>The length of time until a budget resets the actual and forecasted spend. <code>DAILY</code>
        /// is available only for <code>RI_UTILIZATION</code> and <code>RI_COVERAGE</code> budgets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Budgets.TimeUnit")]
        public Amazon.Budgets.TimeUnit Budget_TimeUnit { get; set; }
        #endregion
        
        #region Parameter BudgetLimit_Unit
        /// <summary>
        /// <para>
        /// <para>The unit of measurement that is used for the budget forecast, actual spend, or budget
        /// threshold, such as dollars or GB.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Budget_BudgetLimit_Unit")]
        public System.String BudgetLimit_Unit { get; set; }
        #endregion
        
        #region Parameter ActualSpend_Unit
        /// <summary>
        /// <para>
        /// <para>The unit of measurement that is used for the budget forecast, actual spend, or budget
        /// threshold, such as dollars or GB.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Budget_CalculatedSpend_ActualSpend_Unit")]
        public System.String ActualSpend_Unit { get; set; }
        #endregion
        
        #region Parameter ForecastedSpend_Unit
        /// <summary>
        /// <para>
        /// <para>The unit of measurement that is used for the budget forecast, actual spend, or budget
        /// threshold, such as dollars or GB.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Budget_CalculatedSpend_ForecastedSpend_Unit")]
        public System.String ForecastedSpend_Unit { get; set; }
        #endregion
        
        #region Parameter CostTypes_UseAmortized
        /// <summary>
        /// <para>
        /// <para>Specifies whether a budget uses the amortized rate.</para><para>The default value is <code>false</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Budget_CostTypes_UseAmortized")]
        public System.Boolean CostTypes_UseAmortized { get; set; }
        #endregion
        
        #region Parameter CostTypes_UseBlended
        /// <summary>
        /// <para>
        /// <para>Specifies whether a budget uses a blended rate.</para><para>The default value is <code>false</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Budget_CostTypes_UseBlended")]
        public System.Boolean CostTypes_UseBlended { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the AccountId parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("AccountId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BGTBudget (CreateBudget)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.AccountId = this.AccountId;
            if (ParameterWasBound("BudgetLimit_Amount"))
                context.Budget_BudgetLimit_Amount = this.BudgetLimit_Amount;
            context.Budget_BudgetLimit_Unit = this.BudgetLimit_Unit;
            context.Budget_BudgetName = this.Budget_BudgetName;
            context.Budget_BudgetType = this.Budget_BudgetType;
            if (ParameterWasBound("ActualSpend_Amount"))
                context.Budget_CalculatedSpend_ActualSpend_Amount = this.ActualSpend_Amount;
            context.Budget_CalculatedSpend_ActualSpend_Unit = this.ActualSpend_Unit;
            if (ParameterWasBound("ForecastedSpend_Amount"))
                context.Budget_CalculatedSpend_ForecastedSpend_Amount = this.ForecastedSpend_Amount;
            context.Budget_CalculatedSpend_ForecastedSpend_Unit = this.ForecastedSpend_Unit;
            if (this.Budget_CostFilter != null)
            {
                context.Budget_CostFilters = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.Budget_CostFilter.Keys)
                {
                    object hashValue = this.Budget_CostFilter[hashKey];
                    if (hashValue == null)
                    {
                        context.Budget_CostFilters.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((String)s);
                    }
                    context.Budget_CostFilters.Add((String)hashKey, valueSet);
                }
            }
            if (ParameterWasBound("CostTypes_IncludeCredit"))
                context.Budget_CostTypes_IncludeCredit = this.CostTypes_IncludeCredit;
            if (ParameterWasBound("CostTypes_IncludeDiscount"))
                context.Budget_CostTypes_IncludeDiscount = this.CostTypes_IncludeDiscount;
            if (ParameterWasBound("CostTypes_IncludeOtherSubscription"))
                context.Budget_CostTypes_IncludeOtherSubscription = this.CostTypes_IncludeOtherSubscription;
            if (ParameterWasBound("CostTypes_IncludeRecurring"))
                context.Budget_CostTypes_IncludeRecurring = this.CostTypes_IncludeRecurring;
            if (ParameterWasBound("CostTypes_IncludeRefund"))
                context.Budget_CostTypes_IncludeRefund = this.CostTypes_IncludeRefund;
            if (ParameterWasBound("CostTypes_IncludeSubscription"))
                context.Budget_CostTypes_IncludeSubscription = this.CostTypes_IncludeSubscription;
            if (ParameterWasBound("CostTypes_IncludeSupport"))
                context.Budget_CostTypes_IncludeSupport = this.CostTypes_IncludeSupport;
            if (ParameterWasBound("CostTypes_IncludeTax"))
                context.Budget_CostTypes_IncludeTax = this.CostTypes_IncludeTax;
            if (ParameterWasBound("CostTypes_IncludeUpfront"))
                context.Budget_CostTypes_IncludeUpfront = this.CostTypes_IncludeUpfront;
            if (ParameterWasBound("CostTypes_UseAmortized"))
                context.Budget_CostTypes_UseAmortized = this.CostTypes_UseAmortized;
            if (ParameterWasBound("CostTypes_UseBlended"))
                context.Budget_CostTypes_UseBlended = this.CostTypes_UseBlended;
            if (ParameterWasBound("Budget_LastUpdatedTime"))
                context.Budget_LastUpdatedTime = this.Budget_LastUpdatedTime;
            if (ParameterWasBound("TimePeriod_End"))
                context.Budget_TimePeriod_End = this.TimePeriod_End;
            if (ParameterWasBound("TimePeriod_Start"))
                context.Budget_TimePeriod_Start = this.TimePeriod_Start;
            context.Budget_TimeUnit = this.Budget_TimeUnit;
            if (this.NotificationsWithSubscriber != null)
            {
                context.NotificationsWithSubscribers = new List<Amazon.Budgets.Model.NotificationWithSubscribers>(this.NotificationsWithSubscriber);
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
            bool requestBudgetIsNull = true;
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
            if (cmdletContext.Budget_CostFilters != null)
            {
                requestBudget_budget_CostFilter = cmdletContext.Budget_CostFilters;
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
            bool requestBudget_budget_BudgetLimitIsNull = true;
            requestBudget_budget_BudgetLimit = new Amazon.Budgets.Model.Spend();
            System.Decimal? requestBudget_budget_BudgetLimit_budgetLimit_Amount = null;
            if (cmdletContext.Budget_BudgetLimit_Amount != null)
            {
                requestBudget_budget_BudgetLimit_budgetLimit_Amount = cmdletContext.Budget_BudgetLimit_Amount.Value;
            }
            if (requestBudget_budget_BudgetLimit_budgetLimit_Amount != null)
            {
                requestBudget_budget_BudgetLimit.Amount = requestBudget_budget_BudgetLimit_budgetLimit_Amount.Value;
                requestBudget_budget_BudgetLimitIsNull = false;
            }
            System.String requestBudget_budget_BudgetLimit_budgetLimit_Unit = null;
            if (cmdletContext.Budget_BudgetLimit_Unit != null)
            {
                requestBudget_budget_BudgetLimit_budgetLimit_Unit = cmdletContext.Budget_BudgetLimit_Unit;
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
            bool requestBudget_budget_CalculatedSpendIsNull = true;
            requestBudget_budget_CalculatedSpend = new Amazon.Budgets.Model.CalculatedSpend();
            Amazon.Budgets.Model.Spend requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ActualSpend = null;
            
             // populate ActualSpend
            bool requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ActualSpendIsNull = true;
            requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ActualSpend = new Amazon.Budgets.Model.Spend();
            System.Decimal? requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ActualSpend_actualSpend_Amount = null;
            if (cmdletContext.Budget_CalculatedSpend_ActualSpend_Amount != null)
            {
                requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ActualSpend_actualSpend_Amount = cmdletContext.Budget_CalculatedSpend_ActualSpend_Amount.Value;
            }
            if (requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ActualSpend_actualSpend_Amount != null)
            {
                requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ActualSpend.Amount = requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ActualSpend_actualSpend_Amount.Value;
                requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ActualSpendIsNull = false;
            }
            System.String requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ActualSpend_actualSpend_Unit = null;
            if (cmdletContext.Budget_CalculatedSpend_ActualSpend_Unit != null)
            {
                requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ActualSpend_actualSpend_Unit = cmdletContext.Budget_CalculatedSpend_ActualSpend_Unit;
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
            bool requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ForecastedSpendIsNull = true;
            requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ForecastedSpend = new Amazon.Budgets.Model.Spend();
            System.Decimal? requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ForecastedSpend_forecastedSpend_Amount = null;
            if (cmdletContext.Budget_CalculatedSpend_ForecastedSpend_Amount != null)
            {
                requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ForecastedSpend_forecastedSpend_Amount = cmdletContext.Budget_CalculatedSpend_ForecastedSpend_Amount.Value;
            }
            if (requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ForecastedSpend_forecastedSpend_Amount != null)
            {
                requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ForecastedSpend.Amount = requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ForecastedSpend_forecastedSpend_Amount.Value;
                requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ForecastedSpendIsNull = false;
            }
            System.String requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ForecastedSpend_forecastedSpend_Unit = null;
            if (cmdletContext.Budget_CalculatedSpend_ForecastedSpend_Unit != null)
            {
                requestBudget_budget_CalculatedSpend_budget_CalculatedSpend_ForecastedSpend_forecastedSpend_Unit = cmdletContext.Budget_CalculatedSpend_ForecastedSpend_Unit;
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
            bool requestBudget_budget_TimePeriodIsNull = true;
            requestBudget_budget_TimePeriod = new Amazon.Budgets.Model.TimePeriod();
            System.DateTime? requestBudget_budget_TimePeriod_timePeriod_End = null;
            if (cmdletContext.Budget_TimePeriod_End != null)
            {
                requestBudget_budget_TimePeriod_timePeriod_End = cmdletContext.Budget_TimePeriod_End.Value;
            }
            if (requestBudget_budget_TimePeriod_timePeriod_End != null)
            {
                requestBudget_budget_TimePeriod.End = requestBudget_budget_TimePeriod_timePeriod_End.Value;
                requestBudget_budget_TimePeriodIsNull = false;
            }
            System.DateTime? requestBudget_budget_TimePeriod_timePeriod_Start = null;
            if (cmdletContext.Budget_TimePeriod_Start != null)
            {
                requestBudget_budget_TimePeriod_timePeriod_Start = cmdletContext.Budget_TimePeriod_Start.Value;
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
            Amazon.Budgets.Model.CostTypes requestBudget_budget_CostTypes = null;
            
             // populate CostTypes
            bool requestBudget_budget_CostTypesIsNull = true;
            requestBudget_budget_CostTypes = new Amazon.Budgets.Model.CostTypes();
            System.Boolean? requestBudget_budget_CostTypes_costTypes_IncludeCredit = null;
            if (cmdletContext.Budget_CostTypes_IncludeCredit != null)
            {
                requestBudget_budget_CostTypes_costTypes_IncludeCredit = cmdletContext.Budget_CostTypes_IncludeCredit.Value;
            }
            if (requestBudget_budget_CostTypes_costTypes_IncludeCredit != null)
            {
                requestBudget_budget_CostTypes.IncludeCredit = requestBudget_budget_CostTypes_costTypes_IncludeCredit.Value;
                requestBudget_budget_CostTypesIsNull = false;
            }
            System.Boolean? requestBudget_budget_CostTypes_costTypes_IncludeDiscount = null;
            if (cmdletContext.Budget_CostTypes_IncludeDiscount != null)
            {
                requestBudget_budget_CostTypes_costTypes_IncludeDiscount = cmdletContext.Budget_CostTypes_IncludeDiscount.Value;
            }
            if (requestBudget_budget_CostTypes_costTypes_IncludeDiscount != null)
            {
                requestBudget_budget_CostTypes.IncludeDiscount = requestBudget_budget_CostTypes_costTypes_IncludeDiscount.Value;
                requestBudget_budget_CostTypesIsNull = false;
            }
            System.Boolean? requestBudget_budget_CostTypes_costTypes_IncludeOtherSubscription = null;
            if (cmdletContext.Budget_CostTypes_IncludeOtherSubscription != null)
            {
                requestBudget_budget_CostTypes_costTypes_IncludeOtherSubscription = cmdletContext.Budget_CostTypes_IncludeOtherSubscription.Value;
            }
            if (requestBudget_budget_CostTypes_costTypes_IncludeOtherSubscription != null)
            {
                requestBudget_budget_CostTypes.IncludeOtherSubscription = requestBudget_budget_CostTypes_costTypes_IncludeOtherSubscription.Value;
                requestBudget_budget_CostTypesIsNull = false;
            }
            System.Boolean? requestBudget_budget_CostTypes_costTypes_IncludeRecurring = null;
            if (cmdletContext.Budget_CostTypes_IncludeRecurring != null)
            {
                requestBudget_budget_CostTypes_costTypes_IncludeRecurring = cmdletContext.Budget_CostTypes_IncludeRecurring.Value;
            }
            if (requestBudget_budget_CostTypes_costTypes_IncludeRecurring != null)
            {
                requestBudget_budget_CostTypes.IncludeRecurring = requestBudget_budget_CostTypes_costTypes_IncludeRecurring.Value;
                requestBudget_budget_CostTypesIsNull = false;
            }
            System.Boolean? requestBudget_budget_CostTypes_costTypes_IncludeRefund = null;
            if (cmdletContext.Budget_CostTypes_IncludeRefund != null)
            {
                requestBudget_budget_CostTypes_costTypes_IncludeRefund = cmdletContext.Budget_CostTypes_IncludeRefund.Value;
            }
            if (requestBudget_budget_CostTypes_costTypes_IncludeRefund != null)
            {
                requestBudget_budget_CostTypes.IncludeRefund = requestBudget_budget_CostTypes_costTypes_IncludeRefund.Value;
                requestBudget_budget_CostTypesIsNull = false;
            }
            System.Boolean? requestBudget_budget_CostTypes_costTypes_IncludeSubscription = null;
            if (cmdletContext.Budget_CostTypes_IncludeSubscription != null)
            {
                requestBudget_budget_CostTypes_costTypes_IncludeSubscription = cmdletContext.Budget_CostTypes_IncludeSubscription.Value;
            }
            if (requestBudget_budget_CostTypes_costTypes_IncludeSubscription != null)
            {
                requestBudget_budget_CostTypes.IncludeSubscription = requestBudget_budget_CostTypes_costTypes_IncludeSubscription.Value;
                requestBudget_budget_CostTypesIsNull = false;
            }
            System.Boolean? requestBudget_budget_CostTypes_costTypes_IncludeSupport = null;
            if (cmdletContext.Budget_CostTypes_IncludeSupport != null)
            {
                requestBudget_budget_CostTypes_costTypes_IncludeSupport = cmdletContext.Budget_CostTypes_IncludeSupport.Value;
            }
            if (requestBudget_budget_CostTypes_costTypes_IncludeSupport != null)
            {
                requestBudget_budget_CostTypes.IncludeSupport = requestBudget_budget_CostTypes_costTypes_IncludeSupport.Value;
                requestBudget_budget_CostTypesIsNull = false;
            }
            System.Boolean? requestBudget_budget_CostTypes_costTypes_IncludeTax = null;
            if (cmdletContext.Budget_CostTypes_IncludeTax != null)
            {
                requestBudget_budget_CostTypes_costTypes_IncludeTax = cmdletContext.Budget_CostTypes_IncludeTax.Value;
            }
            if (requestBudget_budget_CostTypes_costTypes_IncludeTax != null)
            {
                requestBudget_budget_CostTypes.IncludeTax = requestBudget_budget_CostTypes_costTypes_IncludeTax.Value;
                requestBudget_budget_CostTypesIsNull = false;
            }
            System.Boolean? requestBudget_budget_CostTypes_costTypes_IncludeUpfront = null;
            if (cmdletContext.Budget_CostTypes_IncludeUpfront != null)
            {
                requestBudget_budget_CostTypes_costTypes_IncludeUpfront = cmdletContext.Budget_CostTypes_IncludeUpfront.Value;
            }
            if (requestBudget_budget_CostTypes_costTypes_IncludeUpfront != null)
            {
                requestBudget_budget_CostTypes.IncludeUpfront = requestBudget_budget_CostTypes_costTypes_IncludeUpfront.Value;
                requestBudget_budget_CostTypesIsNull = false;
            }
            System.Boolean? requestBudget_budget_CostTypes_costTypes_UseAmortized = null;
            if (cmdletContext.Budget_CostTypes_UseAmortized != null)
            {
                requestBudget_budget_CostTypes_costTypes_UseAmortized = cmdletContext.Budget_CostTypes_UseAmortized.Value;
            }
            if (requestBudget_budget_CostTypes_costTypes_UseAmortized != null)
            {
                requestBudget_budget_CostTypes.UseAmortized = requestBudget_budget_CostTypes_costTypes_UseAmortized.Value;
                requestBudget_budget_CostTypesIsNull = false;
            }
            System.Boolean? requestBudget_budget_CostTypes_costTypes_UseBlended = null;
            if (cmdletContext.Budget_CostTypes_UseBlended != null)
            {
                requestBudget_budget_CostTypes_costTypes_UseBlended = cmdletContext.Budget_CostTypes_UseBlended.Value;
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
            if (cmdletContext.NotificationsWithSubscribers != null)
            {
                request.NotificationsWithSubscribers = cmdletContext.NotificationsWithSubscribers;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.AccountId;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateBudgetAsync(request);
                return task.Result;
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
            public System.Decimal? Budget_BudgetLimit_Amount { get; set; }
            public System.String Budget_BudgetLimit_Unit { get; set; }
            public System.String Budget_BudgetName { get; set; }
            public Amazon.Budgets.BudgetType Budget_BudgetType { get; set; }
            public System.Decimal? Budget_CalculatedSpend_ActualSpend_Amount { get; set; }
            public System.String Budget_CalculatedSpend_ActualSpend_Unit { get; set; }
            public System.Decimal? Budget_CalculatedSpend_ForecastedSpend_Amount { get; set; }
            public System.String Budget_CalculatedSpend_ForecastedSpend_Unit { get; set; }
            public Dictionary<System.String, List<System.String>> Budget_CostFilters { get; set; }
            public System.Boolean? Budget_CostTypes_IncludeCredit { get; set; }
            public System.Boolean? Budget_CostTypes_IncludeDiscount { get; set; }
            public System.Boolean? Budget_CostTypes_IncludeOtherSubscription { get; set; }
            public System.Boolean? Budget_CostTypes_IncludeRecurring { get; set; }
            public System.Boolean? Budget_CostTypes_IncludeRefund { get; set; }
            public System.Boolean? Budget_CostTypes_IncludeSubscription { get; set; }
            public System.Boolean? Budget_CostTypes_IncludeSupport { get; set; }
            public System.Boolean? Budget_CostTypes_IncludeTax { get; set; }
            public System.Boolean? Budget_CostTypes_IncludeUpfront { get; set; }
            public System.Boolean? Budget_CostTypes_UseAmortized { get; set; }
            public System.Boolean? Budget_CostTypes_UseBlended { get; set; }
            public System.DateTime? Budget_LastUpdatedTime { get; set; }
            public System.DateTime? Budget_TimePeriod_End { get; set; }
            public System.DateTime? Budget_TimePeriod_Start { get; set; }
            public Amazon.Budgets.TimeUnit Budget_TimeUnit { get; set; }
            public List<Amazon.Budgets.Model.NotificationWithSubscribers> NotificationsWithSubscribers { get; set; }
        }
        
    }
}
