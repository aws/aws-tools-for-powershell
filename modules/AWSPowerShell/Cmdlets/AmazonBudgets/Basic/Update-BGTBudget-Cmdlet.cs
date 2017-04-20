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
    /// Update the information of a budget already created
    /// </summary>
    [Cmdlet("Update", "BGTBudget", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the UpdateBudget operation against AWS Budgets.", Operation = new[] {"UpdateBudget"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the AccountId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.Budgets.Model.UpdateBudgetResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateBGTBudgetCmdlet : AmazonBudgetsClientCmdlet, IExecutor
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
        [Alias("NewBudget_BudgetLimit_Amount")]
        public System.Decimal BudgetLimit_Amount { get; set; }
        #endregion
        
        #region Parameter ActualSpend_Amount
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NewBudget_CalculatedSpend_ActualSpend_Amount")]
        public System.Decimal ActualSpend_Amount { get; set; }
        #endregion
        
        #region Parameter ForecastedSpend_Amount
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NewBudget_CalculatedSpend_ForecastedSpend_Amount")]
        public System.Decimal ForecastedSpend_Amount { get; set; }
        #endregion
        
        #region Parameter NewBudget_BudgetName
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NewBudget_BudgetName { get; set; }
        #endregion
        
        #region Parameter NewBudget_BudgetType
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Budgets.BudgetType")]
        public Amazon.Budgets.BudgetType NewBudget_BudgetType { get; set; }
        #endregion
        
        #region Parameter NewBudget_CostFilter
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NewBudget_CostFilters")]
        public System.Collections.Hashtable NewBudget_CostFilter { get; set; }
        #endregion
        
        #region Parameter TimePeriod_End
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NewBudget_TimePeriod_End")]
        public System.DateTime TimePeriod_End { get; set; }
        #endregion
        
        #region Parameter CostTypes_IncludeSubscription
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NewBudget_CostTypes_IncludeSubscription")]
        public System.Boolean CostTypes_IncludeSubscription { get; set; }
        #endregion
        
        #region Parameter CostTypes_IncludeTax
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NewBudget_CostTypes_IncludeTax")]
        public System.Boolean CostTypes_IncludeTax { get; set; }
        #endregion
        
        #region Parameter TimePeriod_Start
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NewBudget_TimePeriod_Start")]
        public System.DateTime TimePeriod_Start { get; set; }
        #endregion
        
        #region Parameter NewBudget_TimeUnit
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Budgets.TimeUnit")]
        public Amazon.Budgets.TimeUnit NewBudget_TimeUnit { get; set; }
        #endregion
        
        #region Parameter BudgetLimit_Unit
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NewBudget_BudgetLimit_Unit")]
        public System.String BudgetLimit_Unit { get; set; }
        #endregion
        
        #region Parameter ActualSpend_Unit
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NewBudget_CalculatedSpend_ActualSpend_Unit")]
        public System.String ActualSpend_Unit { get; set; }
        #endregion
        
        #region Parameter ForecastedSpend_Unit
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NewBudget_CalculatedSpend_ForecastedSpend_Unit")]
        public System.String ForecastedSpend_Unit { get; set; }
        #endregion
        
        #region Parameter CostTypes_UseBlended
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NewBudget_CostTypes_UseBlended")]
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BGTBudget (UpdateBudget)"))
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
                context.NewBudget_BudgetLimit_Amount = this.BudgetLimit_Amount;
            context.NewBudget_BudgetLimit_Unit = this.BudgetLimit_Unit;
            context.NewBudget_BudgetName = this.NewBudget_BudgetName;
            context.NewBudget_BudgetType = this.NewBudget_BudgetType;
            if (ParameterWasBound("ActualSpend_Amount"))
                context.NewBudget_CalculatedSpend_ActualSpend_Amount = this.ActualSpend_Amount;
            context.NewBudget_CalculatedSpend_ActualSpend_Unit = this.ActualSpend_Unit;
            if (ParameterWasBound("ForecastedSpend_Amount"))
                context.NewBudget_CalculatedSpend_ForecastedSpend_Amount = this.ForecastedSpend_Amount;
            context.NewBudget_CalculatedSpend_ForecastedSpend_Unit = this.ForecastedSpend_Unit;
            if (this.NewBudget_CostFilter != null)
            {
                context.NewBudget_CostFilters = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.NewBudget_CostFilter.Keys)
                {
                    object hashValue = this.NewBudget_CostFilter[hashKey];
                    if (hashValue == null)
                    {
                        context.NewBudget_CostFilters.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((String)s);
                    }
                    context.NewBudget_CostFilters.Add((String)hashKey, valueSet);
                }
            }
            if (ParameterWasBound("CostTypes_IncludeSubscription"))
                context.NewBudget_CostTypes_IncludeSubscription = this.CostTypes_IncludeSubscription;
            if (ParameterWasBound("CostTypes_IncludeTax"))
                context.NewBudget_CostTypes_IncludeTax = this.CostTypes_IncludeTax;
            if (ParameterWasBound("CostTypes_UseBlended"))
                context.NewBudget_CostTypes_UseBlended = this.CostTypes_UseBlended;
            if (ParameterWasBound("TimePeriod_End"))
                context.NewBudget_TimePeriod_End = this.TimePeriod_End;
            if (ParameterWasBound("TimePeriod_Start"))
                context.NewBudget_TimePeriod_Start = this.TimePeriod_Start;
            context.NewBudget_TimeUnit = this.NewBudget_TimeUnit;
            
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
            bool requestNewBudgetIsNull = true;
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
            Dictionary<System.String, List<System.String>> requestNewBudget_newBudget_CostFilter = null;
            if (cmdletContext.NewBudget_CostFilters != null)
            {
                requestNewBudget_newBudget_CostFilter = cmdletContext.NewBudget_CostFilters;
            }
            if (requestNewBudget_newBudget_CostFilter != null)
            {
                request.NewBudget.CostFilters = requestNewBudget_newBudget_CostFilter;
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
            bool requestNewBudget_newBudget_BudgetLimitIsNull = true;
            requestNewBudget_newBudget_BudgetLimit = new Amazon.Budgets.Model.Spend();
            System.Decimal? requestNewBudget_newBudget_BudgetLimit_budgetLimit_Amount = null;
            if (cmdletContext.NewBudget_BudgetLimit_Amount != null)
            {
                requestNewBudget_newBudget_BudgetLimit_budgetLimit_Amount = cmdletContext.NewBudget_BudgetLimit_Amount.Value;
            }
            if (requestNewBudget_newBudget_BudgetLimit_budgetLimit_Amount != null)
            {
                requestNewBudget_newBudget_BudgetLimit.Amount = requestNewBudget_newBudget_BudgetLimit_budgetLimit_Amount.Value;
                requestNewBudget_newBudget_BudgetLimitIsNull = false;
            }
            System.String requestNewBudget_newBudget_BudgetLimit_budgetLimit_Unit = null;
            if (cmdletContext.NewBudget_BudgetLimit_Unit != null)
            {
                requestNewBudget_newBudget_BudgetLimit_budgetLimit_Unit = cmdletContext.NewBudget_BudgetLimit_Unit;
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
            bool requestNewBudget_newBudget_CalculatedSpendIsNull = true;
            requestNewBudget_newBudget_CalculatedSpend = new Amazon.Budgets.Model.CalculatedSpend();
            Amazon.Budgets.Model.Spend requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ActualSpend = null;
            
             // populate ActualSpend
            bool requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ActualSpendIsNull = true;
            requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ActualSpend = new Amazon.Budgets.Model.Spend();
            System.Decimal? requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ActualSpend_actualSpend_Amount = null;
            if (cmdletContext.NewBudget_CalculatedSpend_ActualSpend_Amount != null)
            {
                requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ActualSpend_actualSpend_Amount = cmdletContext.NewBudget_CalculatedSpend_ActualSpend_Amount.Value;
            }
            if (requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ActualSpend_actualSpend_Amount != null)
            {
                requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ActualSpend.Amount = requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ActualSpend_actualSpend_Amount.Value;
                requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ActualSpendIsNull = false;
            }
            System.String requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ActualSpend_actualSpend_Unit = null;
            if (cmdletContext.NewBudget_CalculatedSpend_ActualSpend_Unit != null)
            {
                requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ActualSpend_actualSpend_Unit = cmdletContext.NewBudget_CalculatedSpend_ActualSpend_Unit;
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
            bool requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ForecastedSpendIsNull = true;
            requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ForecastedSpend = new Amazon.Budgets.Model.Spend();
            System.Decimal? requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ForecastedSpend_forecastedSpend_Amount = null;
            if (cmdletContext.NewBudget_CalculatedSpend_ForecastedSpend_Amount != null)
            {
                requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ForecastedSpend_forecastedSpend_Amount = cmdletContext.NewBudget_CalculatedSpend_ForecastedSpend_Amount.Value;
            }
            if (requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ForecastedSpend_forecastedSpend_Amount != null)
            {
                requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ForecastedSpend.Amount = requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ForecastedSpend_forecastedSpend_Amount.Value;
                requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ForecastedSpendIsNull = false;
            }
            System.String requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ForecastedSpend_forecastedSpend_Unit = null;
            if (cmdletContext.NewBudget_CalculatedSpend_ForecastedSpend_Unit != null)
            {
                requestNewBudget_newBudget_CalculatedSpend_newBudget_CalculatedSpend_ForecastedSpend_forecastedSpend_Unit = cmdletContext.NewBudget_CalculatedSpend_ForecastedSpend_Unit;
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
            bool requestNewBudget_newBudget_TimePeriodIsNull = true;
            requestNewBudget_newBudget_TimePeriod = new Amazon.Budgets.Model.TimePeriod();
            System.DateTime? requestNewBudget_newBudget_TimePeriod_timePeriod_End = null;
            if (cmdletContext.NewBudget_TimePeriod_End != null)
            {
                requestNewBudget_newBudget_TimePeriod_timePeriod_End = cmdletContext.NewBudget_TimePeriod_End.Value;
            }
            if (requestNewBudget_newBudget_TimePeriod_timePeriod_End != null)
            {
                requestNewBudget_newBudget_TimePeriod.End = requestNewBudget_newBudget_TimePeriod_timePeriod_End.Value;
                requestNewBudget_newBudget_TimePeriodIsNull = false;
            }
            System.DateTime? requestNewBudget_newBudget_TimePeriod_timePeriod_Start = null;
            if (cmdletContext.NewBudget_TimePeriod_Start != null)
            {
                requestNewBudget_newBudget_TimePeriod_timePeriod_Start = cmdletContext.NewBudget_TimePeriod_Start.Value;
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
            Amazon.Budgets.Model.CostTypes requestNewBudget_newBudget_CostTypes = null;
            
             // populate CostTypes
            bool requestNewBudget_newBudget_CostTypesIsNull = true;
            requestNewBudget_newBudget_CostTypes = new Amazon.Budgets.Model.CostTypes();
            System.Boolean? requestNewBudget_newBudget_CostTypes_costTypes_IncludeSubscription = null;
            if (cmdletContext.NewBudget_CostTypes_IncludeSubscription != null)
            {
                requestNewBudget_newBudget_CostTypes_costTypes_IncludeSubscription = cmdletContext.NewBudget_CostTypes_IncludeSubscription.Value;
            }
            if (requestNewBudget_newBudget_CostTypes_costTypes_IncludeSubscription != null)
            {
                requestNewBudget_newBudget_CostTypes.IncludeSubscription = requestNewBudget_newBudget_CostTypes_costTypes_IncludeSubscription.Value;
                requestNewBudget_newBudget_CostTypesIsNull = false;
            }
            System.Boolean? requestNewBudget_newBudget_CostTypes_costTypes_IncludeTax = null;
            if (cmdletContext.NewBudget_CostTypes_IncludeTax != null)
            {
                requestNewBudget_newBudget_CostTypes_costTypes_IncludeTax = cmdletContext.NewBudget_CostTypes_IncludeTax.Value;
            }
            if (requestNewBudget_newBudget_CostTypes_costTypes_IncludeTax != null)
            {
                requestNewBudget_newBudget_CostTypes.IncludeTax = requestNewBudget_newBudget_CostTypes_costTypes_IncludeTax.Value;
                requestNewBudget_newBudget_CostTypesIsNull = false;
            }
            System.Boolean? requestNewBudget_newBudget_CostTypes_costTypes_UseBlended = null;
            if (cmdletContext.NewBudget_CostTypes_UseBlended != null)
            {
                requestNewBudget_newBudget_CostTypes_costTypes_UseBlended = cmdletContext.NewBudget_CostTypes_UseBlended.Value;
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
             // determine if request.NewBudget should be set to null
            if (requestNewBudgetIsNull)
            {
                request.NewBudget = null;
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
        
        private Amazon.Budgets.Model.UpdateBudgetResponse CallAWSServiceOperation(IAmazonBudgets client, Amazon.Budgets.Model.UpdateBudgetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Budgets", "UpdateBudget");
            #if DESKTOP
            return client.UpdateBudget(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.UpdateBudgetAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String AccountId { get; set; }
            public System.Decimal? NewBudget_BudgetLimit_Amount { get; set; }
            public System.String NewBudget_BudgetLimit_Unit { get; set; }
            public System.String NewBudget_BudgetName { get; set; }
            public Amazon.Budgets.BudgetType NewBudget_BudgetType { get; set; }
            public System.Decimal? NewBudget_CalculatedSpend_ActualSpend_Amount { get; set; }
            public System.String NewBudget_CalculatedSpend_ActualSpend_Unit { get; set; }
            public System.Decimal? NewBudget_CalculatedSpend_ForecastedSpend_Amount { get; set; }
            public System.String NewBudget_CalculatedSpend_ForecastedSpend_Unit { get; set; }
            public Dictionary<System.String, List<System.String>> NewBudget_CostFilters { get; set; }
            public System.Boolean? NewBudget_CostTypes_IncludeSubscription { get; set; }
            public System.Boolean? NewBudget_CostTypes_IncludeTax { get; set; }
            public System.Boolean? NewBudget_CostTypes_UseBlended { get; set; }
            public System.DateTime? NewBudget_TimePeriod_End { get; set; }
            public System.DateTime? NewBudget_TimePeriod_Start { get; set; }
            public Amazon.Budgets.TimeUnit NewBudget_TimeUnit { get; set; }
        }
        
    }
}
