/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Create a new budget
    /// </summary>
    [Cmdlet("New", "BGTBudget", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the CreateBudget operation against AWS Budgets.", Operation = new[] {"CreateBudget"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the AccountId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.Budgets.Model.CreateBudgetResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewBGTBudgetCmdlet : AmazonBudgetsClientCmdlet, IExecutor
    {
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter BudgetLimit_Amount
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Budget_BudgetLimit_Amount")]
        public System.Decimal BudgetLimit_Amount { get; set; }
        #endregion
        
        #region Parameter ActualSpend_Amount
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Budget_CalculatedSpend_ActualSpend_Amount")]
        public System.Decimal ActualSpend_Amount { get; set; }
        #endregion
        
        #region Parameter ForecastedSpend_Amount
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Budget_CalculatedSpend_ForecastedSpend_Amount")]
        public System.Decimal ForecastedSpend_Amount { get; set; }
        #endregion
        
        #region Parameter Budget_BudgetName
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Budget_BudgetName { get; set; }
        #endregion
        
        #region Parameter Budget_BudgetType
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Budgets.BudgetType")]
        public Amazon.Budgets.BudgetType Budget_BudgetType { get; set; }
        #endregion
        
        #region Parameter Budget_CostFilter
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Budget_CostFilters")]
        public System.Collections.Hashtable Budget_CostFilter { get; set; }
        #endregion
        
        #region Parameter TimePeriod_End
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Budget_TimePeriod_End")]
        public System.DateTime TimePeriod_End { get; set; }
        #endregion
        
        #region Parameter CostTypes_IncludeSubscription
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Budget_CostTypes_IncludeSubscription")]
        public System.Boolean CostTypes_IncludeSubscription { get; set; }
        #endregion
        
        #region Parameter CostTypes_IncludeTax
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Budget_CostTypes_IncludeTax")]
        public System.Boolean CostTypes_IncludeTax { get; set; }
        #endregion
        
        #region Parameter NotificationsWithSubscriber
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NotificationsWithSubscribers")]
        public Amazon.Budgets.Model.NotificationWithSubscribers[] NotificationsWithSubscriber { get; set; }
        #endregion
        
        #region Parameter TimePeriod_Start
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Budget_TimePeriod_Start")]
        public System.DateTime TimePeriod_Start { get; set; }
        #endregion
        
        #region Parameter Budget_TimeUnit
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Budgets.TimeUnit")]
        public Amazon.Budgets.TimeUnit Budget_TimeUnit { get; set; }
        #endregion
        
        #region Parameter BudgetLimit_Unit
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Budget_BudgetLimit_Unit")]
        public System.String BudgetLimit_Unit { get; set; }
        #endregion
        
        #region Parameter ActualSpend_Unit
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Budget_CalculatedSpend_ActualSpend_Unit")]
        public System.String ActualSpend_Unit { get; set; }
        #endregion
        
        #region Parameter ForecastedSpend_Unit
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Budget_CalculatedSpend_ForecastedSpend_Unit")]
        public System.String ForecastedSpend_Unit { get; set; }
        #endregion
        
        #region Parameter CostTypes_UseBlended
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
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
            if (ParameterWasBound("CostTypes_IncludeSubscription"))
                context.Budget_CostTypes_IncludeSubscription = this.CostTypes_IncludeSubscription;
            if (ParameterWasBound("CostTypes_IncludeTax"))
                context.Budget_CostTypes_IncludeTax = this.CostTypes_IncludeTax;
            if (ParameterWasBound("CostTypes_UseBlended"))
                context.Budget_CostTypes_UseBlended = this.CostTypes_UseBlended;
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
            public System.Boolean? Budget_CostTypes_IncludeSubscription { get; set; }
            public System.Boolean? Budget_CostTypes_IncludeTax { get; set; }
            public System.Boolean? Budget_CostTypes_UseBlended { get; set; }
            public System.DateTime? Budget_TimePeriod_End { get; set; }
            public System.DateTime? Budget_TimePeriod_Start { get; set; }
            public Amazon.Budgets.TimeUnit Budget_TimeUnit { get; set; }
            public List<Amazon.Budgets.Model.NotificationWithSubscribers> NotificationsWithSubscribers { get; set; }
        }
        
    }
}
