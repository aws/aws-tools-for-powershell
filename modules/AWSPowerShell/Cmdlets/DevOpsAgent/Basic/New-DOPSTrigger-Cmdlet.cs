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
using Amazon.DevOpsAgent;
using Amazon.DevOpsAgent.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DOPS
{
    /// <summary>
    /// Creates a new Trigger in the specified agent space
    /// </summary>
    [Cmdlet("New", "DOPSTrigger", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DevOpsAgent.Model.Trigger")]
    [AWSCmdlet("Calls the AWS DevOps Agent Service CreateTrigger API operation.", Operation = new[] {"CreateTrigger"}, SelectReturnType = typeof(Amazon.DevOpsAgent.Model.CreateTriggerResponse))]
    [AWSCmdletOutput("Amazon.DevOpsAgent.Model.Trigger or Amazon.DevOpsAgent.Model.CreateTriggerResponse",
        "This cmdlet returns an Amazon.DevOpsAgent.Model.Trigger object.",
        "The service call response (type Amazon.DevOpsAgent.Model.CreateTriggerResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewDOPSTriggerCmdlet : AmazonDevOpsAgentClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Action
        /// <summary>
        /// <para>
        /// <para>The action the new Trigger performs when it fires</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Management.Automation.PSObject Action { get; set; }
        #endregion
        
        #region Parameter AgentSpaceId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the agent space where the Trigger will be created</para>
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
        public System.String AgentSpaceId { get; set; }
        #endregion
        
        #region Parameter Condition_Schedule_Spec_TimeRange_Recurrence_Daily
        /// <summary>
        /// <para>
        /// <para>The window recurs every day</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.DevOpsAgent.Model.DailyRecurrence Condition_Schedule_Spec_TimeRange_Recurrence_Daily { get; set; }
        #endregion
        
        #region Parameter Condition_Schedule_Spec_TimeRange_Recurrence_Monthly_DayOfMonth
        /// <summary>
        /// <para>
        /// <para>Day of month the window recurs on</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Condition_Schedule_Spec_TimeRange_Recurrence_Monthly_DayOfMonth { get; set; }
        #endregion
        
        #region Parameter Condition_Schedule_Spec_TimeRange_Recurrence_Weekly_DayOfWeek
        /// <summary>
        /// <para>
        /// <para>Day of week the window recurs on</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DevOpsAgent.DayOfWeek")]
        public Amazon.DevOpsAgent.DayOfWeek Condition_Schedule_Spec_TimeRange_Recurrence_Weekly_DayOfWeek { get; set; }
        #endregion
        
        #region Parameter Condition_Schedule_Expression
        /// <summary>
        /// <para>
        /// <para>EventBridge cron or rate expression. Required for existing request and response compatibility.
        /// For a structured schedule response, this is the expression derived by Backlog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Condition_Schedule_Expression { get; set; }
        #endregion
        
        #region Parameter Condition_Schedule_Spec_Cron_Expression
        /// <summary>
        /// <para>
        /// <para>EventBridge cron or rate expression that anchors the flexible window</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Condition_Schedule_Spec_Cron_Expression { get; set; }
        #endregion
        
        #region Parameter Condition_Schedule_Spec_TimeRange_StartAfter
        /// <summary>
        /// <para>
        /// <para>Earliest time of day the trigger may fire</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Condition_Schedule_Spec_TimeRange_StartAfter { get; set; }
        #endregion
        
        #region Parameter Condition_Schedule_Spec_TimeRange_StartBefore
        /// <summary>
        /// <para>
        /// <para>Latest time of day the trigger may fire</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Condition_Schedule_Spec_TimeRange_StartBefore { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The initial status of the Trigger</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Status { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>How the new Trigger fires</para>
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
        public System.String Type { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier used for idempotent Trigger creation</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Trigger'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DevOpsAgent.Model.CreateTriggerResponse).
        /// Specifying the name of a property of type Amazon.DevOpsAgent.Model.CreateTriggerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Trigger";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AgentSpaceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DOPSTrigger (CreateTrigger)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DevOpsAgent.Model.CreateTriggerResponse, NewDOPSTriggerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Action = this.Action;
            #if MODULAR
            if (this.Action == null && ParameterWasBound(nameof(this.Action)))
            {
                WriteWarning("You are passing $null as a value for parameter Action which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AgentSpaceId = this.AgentSpaceId;
            #if MODULAR
            if (this.AgentSpaceId == null && ParameterWasBound(nameof(this.AgentSpaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter AgentSpaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.Condition_Schedule_Expression = this.Condition_Schedule_Expression;
            context.Condition_Schedule_Spec_Cron_Expression = this.Condition_Schedule_Spec_Cron_Expression;
            context.Condition_Schedule_Spec_TimeRange_Recurrence_Daily = this.Condition_Schedule_Spec_TimeRange_Recurrence_Daily;
            context.Condition_Schedule_Spec_TimeRange_Recurrence_Monthly_DayOfMonth = this.Condition_Schedule_Spec_TimeRange_Recurrence_Monthly_DayOfMonth;
            context.Condition_Schedule_Spec_TimeRange_Recurrence_Weekly_DayOfWeek = this.Condition_Schedule_Spec_TimeRange_Recurrence_Weekly_DayOfWeek;
            context.Condition_Schedule_Spec_TimeRange_StartAfter = this.Condition_Schedule_Spec_TimeRange_StartAfter;
            context.Condition_Schedule_Spec_TimeRange_StartBefore = this.Condition_Schedule_Spec_TimeRange_StartBefore;
            context.Status = this.Status;
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DevOpsAgent.Model.CreateTriggerRequest();
            
            if (cmdletContext.Action != null)
            {
                request.Action = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.Action);
            }
            if (cmdletContext.AgentSpaceId != null)
            {
                request.AgentSpaceId = cmdletContext.AgentSpaceId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate Condition
            var requestConditionIsNull = true;
            request.Condition = new Amazon.DevOpsAgent.Model.TriggerCondition();
            Amazon.DevOpsAgent.Model.ScheduleCondition requestCondition_condition_Schedule = null;
            
             // populate Schedule
            var requestCondition_condition_ScheduleIsNull = true;
            requestCondition_condition_Schedule = new Amazon.DevOpsAgent.Model.ScheduleCondition();
            System.String requestCondition_condition_Schedule_condition_Schedule_Expression = null;
            if (cmdletContext.Condition_Schedule_Expression != null)
            {
                requestCondition_condition_Schedule_condition_Schedule_Expression = cmdletContext.Condition_Schedule_Expression;
            }
            if (requestCondition_condition_Schedule_condition_Schedule_Expression != null)
            {
                requestCondition_condition_Schedule.Expression = requestCondition_condition_Schedule_condition_Schedule_Expression;
                requestCondition_condition_ScheduleIsNull = false;
            }
            Amazon.DevOpsAgent.Model.ScheduleSpec requestCondition_condition_Schedule_condition_Schedule_Spec = null;
            
             // populate Spec
            var requestCondition_condition_Schedule_condition_Schedule_SpecIsNull = true;
            requestCondition_condition_Schedule_condition_Schedule_Spec = new Amazon.DevOpsAgent.Model.ScheduleSpec();
            Amazon.DevOpsAgent.Model.CronSchedule requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_Cron = null;
            
             // populate Cron
            var requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_CronIsNull = true;
            requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_Cron = new Amazon.DevOpsAgent.Model.CronSchedule();
            System.String requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_Cron_condition_Schedule_Spec_Cron_Expression = null;
            if (cmdletContext.Condition_Schedule_Spec_Cron_Expression != null)
            {
                requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_Cron_condition_Schedule_Spec_Cron_Expression = cmdletContext.Condition_Schedule_Spec_Cron_Expression;
            }
            if (requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_Cron_condition_Schedule_Spec_Cron_Expression != null)
            {
                requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_Cron.Expression = requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_Cron_condition_Schedule_Spec_Cron_Expression;
                requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_CronIsNull = false;
            }
             // determine if requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_Cron should be set to null
            if (requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_CronIsNull)
            {
                requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_Cron = null;
            }
            if (requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_Cron != null)
            {
                requestCondition_condition_Schedule_condition_Schedule_Spec.Cron = requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_Cron;
                requestCondition_condition_Schedule_condition_Schedule_SpecIsNull = false;
            }
            Amazon.DevOpsAgent.Model.TimeRangeSchedule requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange = null;
            
             // populate TimeRange
            var requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRangeIsNull = true;
            requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange = new Amazon.DevOpsAgent.Model.TimeRangeSchedule();
            System.String requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_StartAfter = null;
            if (cmdletContext.Condition_Schedule_Spec_TimeRange_StartAfter != null)
            {
                requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_StartAfter = cmdletContext.Condition_Schedule_Spec_TimeRange_StartAfter;
            }
            if (requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_StartAfter != null)
            {
                requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange.StartAfter = requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_StartAfter;
                requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRangeIsNull = false;
            }
            System.String requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_StartBefore = null;
            if (cmdletContext.Condition_Schedule_Spec_TimeRange_StartBefore != null)
            {
                requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_StartBefore = cmdletContext.Condition_Schedule_Spec_TimeRange_StartBefore;
            }
            if (requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_StartBefore != null)
            {
                requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange.StartBefore = requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_StartBefore;
                requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRangeIsNull = false;
            }
            Amazon.DevOpsAgent.Model.Recurrence requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_Recurrence = null;
            
             // populate Recurrence
            var requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_RecurrenceIsNull = true;
            requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_Recurrence = new Amazon.DevOpsAgent.Model.Recurrence();
            Amazon.DevOpsAgent.Model.DailyRecurrence requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_Recurrence_condition_Schedule_Spec_TimeRange_Recurrence_Daily = null;
            if (cmdletContext.Condition_Schedule_Spec_TimeRange_Recurrence_Daily != null)
            {
                requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_Recurrence_condition_Schedule_Spec_TimeRange_Recurrence_Daily = cmdletContext.Condition_Schedule_Spec_TimeRange_Recurrence_Daily;
            }
            if (requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_Recurrence_condition_Schedule_Spec_TimeRange_Recurrence_Daily != null)
            {
                requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_Recurrence.Daily = requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_Recurrence_condition_Schedule_Spec_TimeRange_Recurrence_Daily;
                requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_RecurrenceIsNull = false;
            }
            Amazon.DevOpsAgent.Model.MonthlyRecurrence requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_Recurrence_condition_Schedule_Spec_TimeRange_Recurrence_Monthly = null;
            
             // populate Monthly
            var requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_Recurrence_condition_Schedule_Spec_TimeRange_Recurrence_MonthlyIsNull = true;
            requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_Recurrence_condition_Schedule_Spec_TimeRange_Recurrence_Monthly = new Amazon.DevOpsAgent.Model.MonthlyRecurrence();
            System.Int32? requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_Recurrence_condition_Schedule_Spec_TimeRange_Recurrence_Monthly_condition_Schedule_Spec_TimeRange_Recurrence_Monthly_DayOfMonth = null;
            if (cmdletContext.Condition_Schedule_Spec_TimeRange_Recurrence_Monthly_DayOfMonth != null)
            {
                requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_Recurrence_condition_Schedule_Spec_TimeRange_Recurrence_Monthly_condition_Schedule_Spec_TimeRange_Recurrence_Monthly_DayOfMonth = cmdletContext.Condition_Schedule_Spec_TimeRange_Recurrence_Monthly_DayOfMonth.Value;
            }
            if (requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_Recurrence_condition_Schedule_Spec_TimeRange_Recurrence_Monthly_condition_Schedule_Spec_TimeRange_Recurrence_Monthly_DayOfMonth != null)
            {
                requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_Recurrence_condition_Schedule_Spec_TimeRange_Recurrence_Monthly.DayOfMonth = requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_Recurrence_condition_Schedule_Spec_TimeRange_Recurrence_Monthly_condition_Schedule_Spec_TimeRange_Recurrence_Monthly_DayOfMonth.Value;
                requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_Recurrence_condition_Schedule_Spec_TimeRange_Recurrence_MonthlyIsNull = false;
            }
             // determine if requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_Recurrence_condition_Schedule_Spec_TimeRange_Recurrence_Monthly should be set to null
            if (requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_Recurrence_condition_Schedule_Spec_TimeRange_Recurrence_MonthlyIsNull)
            {
                requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_Recurrence_condition_Schedule_Spec_TimeRange_Recurrence_Monthly = null;
            }
            if (requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_Recurrence_condition_Schedule_Spec_TimeRange_Recurrence_Monthly != null)
            {
                requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_Recurrence.Monthly = requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_Recurrence_condition_Schedule_Spec_TimeRange_Recurrence_Monthly;
                requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_RecurrenceIsNull = false;
            }
            Amazon.DevOpsAgent.Model.WeeklyRecurrence requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_Recurrence_condition_Schedule_Spec_TimeRange_Recurrence_Weekly = null;
            
             // populate Weekly
            var requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_Recurrence_condition_Schedule_Spec_TimeRange_Recurrence_WeeklyIsNull = true;
            requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_Recurrence_condition_Schedule_Spec_TimeRange_Recurrence_Weekly = new Amazon.DevOpsAgent.Model.WeeklyRecurrence();
            Amazon.DevOpsAgent.DayOfWeek requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_Recurrence_condition_Schedule_Spec_TimeRange_Recurrence_Weekly_condition_Schedule_Spec_TimeRange_Recurrence_Weekly_DayOfWeek = null;
            if (cmdletContext.Condition_Schedule_Spec_TimeRange_Recurrence_Weekly_DayOfWeek != null)
            {
                requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_Recurrence_condition_Schedule_Spec_TimeRange_Recurrence_Weekly_condition_Schedule_Spec_TimeRange_Recurrence_Weekly_DayOfWeek = cmdletContext.Condition_Schedule_Spec_TimeRange_Recurrence_Weekly_DayOfWeek;
            }
            if (requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_Recurrence_condition_Schedule_Spec_TimeRange_Recurrence_Weekly_condition_Schedule_Spec_TimeRange_Recurrence_Weekly_DayOfWeek != null)
            {
                requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_Recurrence_condition_Schedule_Spec_TimeRange_Recurrence_Weekly.DayOfWeek = requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_Recurrence_condition_Schedule_Spec_TimeRange_Recurrence_Weekly_condition_Schedule_Spec_TimeRange_Recurrence_Weekly_DayOfWeek;
                requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_Recurrence_condition_Schedule_Spec_TimeRange_Recurrence_WeeklyIsNull = false;
            }
             // determine if requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_Recurrence_condition_Schedule_Spec_TimeRange_Recurrence_Weekly should be set to null
            if (requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_Recurrence_condition_Schedule_Spec_TimeRange_Recurrence_WeeklyIsNull)
            {
                requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_Recurrence_condition_Schedule_Spec_TimeRange_Recurrence_Weekly = null;
            }
            if (requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_Recurrence_condition_Schedule_Spec_TimeRange_Recurrence_Weekly != null)
            {
                requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_Recurrence.Weekly = requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_Recurrence_condition_Schedule_Spec_TimeRange_Recurrence_Weekly;
                requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_RecurrenceIsNull = false;
            }
             // determine if requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_Recurrence should be set to null
            if (requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_RecurrenceIsNull)
            {
                requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_Recurrence = null;
            }
            if (requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_Recurrence != null)
            {
                requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange.Recurrence = requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange_condition_Schedule_Spec_TimeRange_Recurrence;
                requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRangeIsNull = false;
            }
             // determine if requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange should be set to null
            if (requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRangeIsNull)
            {
                requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange = null;
            }
            if (requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange != null)
            {
                requestCondition_condition_Schedule_condition_Schedule_Spec.TimeRange = requestCondition_condition_Schedule_condition_Schedule_Spec_condition_Schedule_Spec_TimeRange;
                requestCondition_condition_Schedule_condition_Schedule_SpecIsNull = false;
            }
             // determine if requestCondition_condition_Schedule_condition_Schedule_Spec should be set to null
            if (requestCondition_condition_Schedule_condition_Schedule_SpecIsNull)
            {
                requestCondition_condition_Schedule_condition_Schedule_Spec = null;
            }
            if (requestCondition_condition_Schedule_condition_Schedule_Spec != null)
            {
                requestCondition_condition_Schedule.Spec = requestCondition_condition_Schedule_condition_Schedule_Spec;
                requestCondition_condition_ScheduleIsNull = false;
            }
             // determine if requestCondition_condition_Schedule should be set to null
            if (requestCondition_condition_ScheduleIsNull)
            {
                requestCondition_condition_Schedule = null;
            }
            if (requestCondition_condition_Schedule != null)
            {
                request.Condition.Schedule = requestCondition_condition_Schedule;
                requestConditionIsNull = false;
            }
             // determine if request.Condition should be set to null
            if (requestConditionIsNull)
            {
                request.Condition = null;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.DevOpsAgent.Model.CreateTriggerResponse CallAWSServiceOperation(IAmazonDevOpsAgent client, Amazon.DevOpsAgent.Model.CreateTriggerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS DevOps Agent Service", "CreateTrigger");
            try
            {
                return client.CreateTriggerAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Management.Automation.PSObject Action { get; set; }
            public System.String AgentSpaceId { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Condition_Schedule_Expression { get; set; }
            public System.String Condition_Schedule_Spec_Cron_Expression { get; set; }
            public Amazon.DevOpsAgent.Model.DailyRecurrence Condition_Schedule_Spec_TimeRange_Recurrence_Daily { get; set; }
            public System.Int32? Condition_Schedule_Spec_TimeRange_Recurrence_Monthly_DayOfMonth { get; set; }
            public Amazon.DevOpsAgent.DayOfWeek Condition_Schedule_Spec_TimeRange_Recurrence_Weekly_DayOfWeek { get; set; }
            public System.String Condition_Schedule_Spec_TimeRange_StartAfter { get; set; }
            public System.String Condition_Schedule_Spec_TimeRange_StartBefore { get; set; }
            public System.String Status { get; set; }
            public System.String Type { get; set; }
            public System.Func<Amazon.DevOpsAgent.Model.CreateTriggerResponse, NewDOPSTriggerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Trigger;
        }
        
    }
}
