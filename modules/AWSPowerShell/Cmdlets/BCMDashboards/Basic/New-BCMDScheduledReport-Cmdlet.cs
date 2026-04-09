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
using Amazon.BCMDashboards;
using Amazon.BCMDashboards.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BCMD
{
    /// <summary>
    /// Creates a new scheduled report for a dashboard. A scheduled report automatically generates
    /// and delivers dashboard snapshots on a recurring schedule. Reports are delivered within
    /// 15 minutes of the scheduled delivery time.
    /// </summary>
    [Cmdlet("New", "BCMDScheduledReport", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Billing and Cost Management Dashboards CreateScheduledReport API operation.", Operation = new[] {"CreateScheduledReport"}, SelectReturnType = typeof(Amazon.BCMDashboards.Model.CreateScheduledReportResponse))]
    [AWSCmdletOutput("System.String or Amazon.BCMDashboards.Model.CreateScheduledReportResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.BCMDashboards.Model.CreateScheduledReportResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewBCMDScheduledReportCmdlet : AmazonBCMDashboardsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ScheduledReport_DashboardArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the dashboard to generate the scheduled report from.</para>
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
        public System.String ScheduledReport_DashboardArn { get; set; }
        #endregion
        
        #region Parameter ScheduledReport_Description
        /// <summary>
        /// <para>
        /// <para>A description of the scheduled report's purpose or contents.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ScheduledReport_Description { get; set; }
        #endregion
        
        #region Parameter ScheduledReport_ScheduleConfig_SchedulePeriod_EndTime
        /// <summary>
        /// <para>
        /// <para>The end time of the schedule period. If not specified, defaults to 3 years from the
        /// time of the create or update request. The maximum allowed value is 3 years from the
        /// current time. Setting an end time beyond this limit returns a <c>ValidationException</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ScheduledReport_ScheduleConfig_SchedulePeriod_EndTime { get; set; }
        #endregion
        
        #region Parameter ScheduledReport_Name
        /// <summary>
        /// <para>
        /// <para>The name of the scheduled report.</para>
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
        public System.String ScheduledReport_Name { get; set; }
        #endregion
        
        #region Parameter ResourceTag
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the scheduled report resource for organization and management.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceTags")]
        public Amazon.BCMDashboards.Model.ResourceTag[] ResourceTag { get; set; }
        #endregion
        
        #region Parameter ScheduledReport_ScheduledReportExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that the scheduled report uses to execute. Amazon Web Services
        /// Billing and Cost Management Dashboards will assume this IAM role while executing the
        /// scheduled report.</para>
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
        public System.String ScheduledReport_ScheduledReportExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter ScheduledReport_ScheduleConfig_ScheduleExpression
        /// <summary>
        /// <para>
        /// <para>The schedule expression that specifies when to trigger the scheduled report run. This
        /// value must be a cron expression consisting of six fields separated by white spaces:
        /// <c>cron(minutes hours day_of_month month day_of_week year)</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ScheduledReport_ScheduleConfig_ScheduleExpression { get; set; }
        #endregion
        
        #region Parameter ScheduledReport_ScheduleConfig_ScheduleExpressionTimeZone
        /// <summary>
        /// <para>
        /// <para>The time zone for the schedule expression, for example, <c>UTC</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ScheduledReport_ScheduleConfig_ScheduleExpressionTimeZone { get; set; }
        #endregion
        
        #region Parameter ScheduledReport_ScheduleConfig_SchedulePeriod_StartTime
        /// <summary>
        /// <para>
        /// <para>The start time of the schedule period. If not specified, defaults to the time of the
        /// create or update request. The start time cannot be more than 5 minutes before the
        /// time of the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ScheduledReport_ScheduleConfig_SchedulePeriod_StartTime { get; set; }
        #endregion
        
        #region Parameter ScheduledReport_ScheduleConfig_State
        /// <summary>
        /// <para>
        /// <para>The state of the schedule. <c>ENABLED</c> means the scheduled report runs according
        /// to its schedule expression. <c>DISABLED</c> means the scheduled report is paused and
        /// will not run until re-enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BCMDashboards.ScheduleState")]
        public Amazon.BCMDashboards.ScheduleState ScheduledReport_ScheduleConfig_State { get; set; }
        #endregion
        
        #region Parameter ScheduledReport_WidgetDateRangeOverride_EndTime_Type
        /// <summary>
        /// <para>
        /// <para>The type of date/time value: <c>ABSOLUTE</c> for specific dates or <c>RELATIVE</c>
        /// for dynamic time periods.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BCMDashboards.DateTimeType")]
        public Amazon.BCMDashboards.DateTimeType ScheduledReport_WidgetDateRangeOverride_EndTime_Type { get; set; }
        #endregion
        
        #region Parameter ScheduledReport_WidgetDateRangeOverride_StartTime_Type
        /// <summary>
        /// <para>
        /// <para>The type of date/time value: <c>ABSOLUTE</c> for specific dates or <c>RELATIVE</c>
        /// for dynamic time periods.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BCMDashboards.DateTimeType")]
        public Amazon.BCMDashboards.DateTimeType ScheduledReport_WidgetDateRangeOverride_StartTime_Type { get; set; }
        #endregion
        
        #region Parameter ScheduledReport_WidgetDateRangeOverride_EndTime_Value
        /// <summary>
        /// <para>
        /// <para>The actual date/time value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ScheduledReport_WidgetDateRangeOverride_EndTime_Value { get; set; }
        #endregion
        
        #region Parameter ScheduledReport_WidgetDateRangeOverride_StartTime_Value
        /// <summary>
        /// <para>
        /// <para>The actual date/time value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ScheduledReport_WidgetDateRangeOverride_StartTime_Value { get; set; }
        #endregion
        
        #region Parameter ScheduledReport_WidgetId
        /// <summary>
        /// <para>
        /// <para>The list of widget identifiers to include in the scheduled report. If not specified,
        /// all widgets in the dashboard are included.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ScheduledReport_WidgetIds")]
        public System.String[] ScheduledReport_WidgetId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Arn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BCMDashboards.Model.CreateScheduledReportResponse).
        /// Specifying the name of a property of type Amazon.BCMDashboards.Model.CreateScheduledReportResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Arn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ScheduledReport_Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BCMDScheduledReport (CreateScheduledReport)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BCMDashboards.Model.CreateScheduledReportResponse, NewBCMDScheduledReportCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            if (this.ResourceTag != null)
            {
                context.ResourceTag = new List<Amazon.BCMDashboards.Model.ResourceTag>(this.ResourceTag);
            }
            context.ScheduledReport_DashboardArn = this.ScheduledReport_DashboardArn;
            #if MODULAR
            if (this.ScheduledReport_DashboardArn == null && ParameterWasBound(nameof(this.ScheduledReport_DashboardArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ScheduledReport_DashboardArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScheduledReport_Description = this.ScheduledReport_Description;
            context.ScheduledReport_Name = this.ScheduledReport_Name;
            #if MODULAR
            if (this.ScheduledReport_Name == null && ParameterWasBound(nameof(this.ScheduledReport_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter ScheduledReport_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScheduledReport_ScheduleConfig_ScheduleExpression = this.ScheduledReport_ScheduleConfig_ScheduleExpression;
            context.ScheduledReport_ScheduleConfig_ScheduleExpressionTimeZone = this.ScheduledReport_ScheduleConfig_ScheduleExpressionTimeZone;
            context.ScheduledReport_ScheduleConfig_SchedulePeriod_EndTime = this.ScheduledReport_ScheduleConfig_SchedulePeriod_EndTime;
            context.ScheduledReport_ScheduleConfig_SchedulePeriod_StartTime = this.ScheduledReport_ScheduleConfig_SchedulePeriod_StartTime;
            context.ScheduledReport_ScheduleConfig_State = this.ScheduledReport_ScheduleConfig_State;
            context.ScheduledReport_ScheduledReportExecutionRoleArn = this.ScheduledReport_ScheduledReportExecutionRoleArn;
            #if MODULAR
            if (this.ScheduledReport_ScheduledReportExecutionRoleArn == null && ParameterWasBound(nameof(this.ScheduledReport_ScheduledReportExecutionRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ScheduledReport_ScheduledReportExecutionRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScheduledReport_WidgetDateRangeOverride_EndTime_Type = this.ScheduledReport_WidgetDateRangeOverride_EndTime_Type;
            context.ScheduledReport_WidgetDateRangeOverride_EndTime_Value = this.ScheduledReport_WidgetDateRangeOverride_EndTime_Value;
            context.ScheduledReport_WidgetDateRangeOverride_StartTime_Type = this.ScheduledReport_WidgetDateRangeOverride_StartTime_Type;
            context.ScheduledReport_WidgetDateRangeOverride_StartTime_Value = this.ScheduledReport_WidgetDateRangeOverride_StartTime_Value;
            if (this.ScheduledReport_WidgetId != null)
            {
                context.ScheduledReport_WidgetId = new List<System.String>(this.ScheduledReport_WidgetId);
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
            var request = new Amazon.BCMDashboards.Model.CreateScheduledReportRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ResourceTag != null)
            {
                request.ResourceTags = cmdletContext.ResourceTag;
            }
            
             // populate ScheduledReport
            var requestScheduledReportIsNull = true;
            request.ScheduledReport = new Amazon.BCMDashboards.Model.ScheduledReportInput();
            System.String requestScheduledReport_scheduledReport_DashboardArn = null;
            if (cmdletContext.ScheduledReport_DashboardArn != null)
            {
                requestScheduledReport_scheduledReport_DashboardArn = cmdletContext.ScheduledReport_DashboardArn;
            }
            if (requestScheduledReport_scheduledReport_DashboardArn != null)
            {
                request.ScheduledReport.DashboardArn = requestScheduledReport_scheduledReport_DashboardArn;
                requestScheduledReportIsNull = false;
            }
            System.String requestScheduledReport_scheduledReport_Description = null;
            if (cmdletContext.ScheduledReport_Description != null)
            {
                requestScheduledReport_scheduledReport_Description = cmdletContext.ScheduledReport_Description;
            }
            if (requestScheduledReport_scheduledReport_Description != null)
            {
                request.ScheduledReport.Description = requestScheduledReport_scheduledReport_Description;
                requestScheduledReportIsNull = false;
            }
            System.String requestScheduledReport_scheduledReport_Name = null;
            if (cmdletContext.ScheduledReport_Name != null)
            {
                requestScheduledReport_scheduledReport_Name = cmdletContext.ScheduledReport_Name;
            }
            if (requestScheduledReport_scheduledReport_Name != null)
            {
                request.ScheduledReport.Name = requestScheduledReport_scheduledReport_Name;
                requestScheduledReportIsNull = false;
            }
            System.String requestScheduledReport_scheduledReport_ScheduledReportExecutionRoleArn = null;
            if (cmdletContext.ScheduledReport_ScheduledReportExecutionRoleArn != null)
            {
                requestScheduledReport_scheduledReport_ScheduledReportExecutionRoleArn = cmdletContext.ScheduledReport_ScheduledReportExecutionRoleArn;
            }
            if (requestScheduledReport_scheduledReport_ScheduledReportExecutionRoleArn != null)
            {
                request.ScheduledReport.ScheduledReportExecutionRoleArn = requestScheduledReport_scheduledReport_ScheduledReportExecutionRoleArn;
                requestScheduledReportIsNull = false;
            }
            List<System.String> requestScheduledReport_scheduledReport_WidgetId = null;
            if (cmdletContext.ScheduledReport_WidgetId != null)
            {
                requestScheduledReport_scheduledReport_WidgetId = cmdletContext.ScheduledReport_WidgetId;
            }
            if (requestScheduledReport_scheduledReport_WidgetId != null)
            {
                request.ScheduledReport.WidgetIds = requestScheduledReport_scheduledReport_WidgetId;
                requestScheduledReportIsNull = false;
            }
            Amazon.BCMDashboards.Model.DateTimeRange requestScheduledReport_scheduledReport_WidgetDateRangeOverride = null;
            
             // populate WidgetDateRangeOverride
            var requestScheduledReport_scheduledReport_WidgetDateRangeOverrideIsNull = true;
            requestScheduledReport_scheduledReport_WidgetDateRangeOverride = new Amazon.BCMDashboards.Model.DateTimeRange();
            Amazon.BCMDashboards.Model.DateTimeValue requestScheduledReport_scheduledReport_WidgetDateRangeOverride_scheduledReport_WidgetDateRangeOverride_EndTime = null;
            
             // populate EndTime
            var requestScheduledReport_scheduledReport_WidgetDateRangeOverride_scheduledReport_WidgetDateRangeOverride_EndTimeIsNull = true;
            requestScheduledReport_scheduledReport_WidgetDateRangeOverride_scheduledReport_WidgetDateRangeOverride_EndTime = new Amazon.BCMDashboards.Model.DateTimeValue();
            Amazon.BCMDashboards.DateTimeType requestScheduledReport_scheduledReport_WidgetDateRangeOverride_scheduledReport_WidgetDateRangeOverride_EndTime_scheduledReport_WidgetDateRangeOverride_EndTime_Type = null;
            if (cmdletContext.ScheduledReport_WidgetDateRangeOverride_EndTime_Type != null)
            {
                requestScheduledReport_scheduledReport_WidgetDateRangeOverride_scheduledReport_WidgetDateRangeOverride_EndTime_scheduledReport_WidgetDateRangeOverride_EndTime_Type = cmdletContext.ScheduledReport_WidgetDateRangeOverride_EndTime_Type;
            }
            if (requestScheduledReport_scheduledReport_WidgetDateRangeOverride_scheduledReport_WidgetDateRangeOverride_EndTime_scheduledReport_WidgetDateRangeOverride_EndTime_Type != null)
            {
                requestScheduledReport_scheduledReport_WidgetDateRangeOverride_scheduledReport_WidgetDateRangeOverride_EndTime.Type = requestScheduledReport_scheduledReport_WidgetDateRangeOverride_scheduledReport_WidgetDateRangeOverride_EndTime_scheduledReport_WidgetDateRangeOverride_EndTime_Type;
                requestScheduledReport_scheduledReport_WidgetDateRangeOverride_scheduledReport_WidgetDateRangeOverride_EndTimeIsNull = false;
            }
            System.String requestScheduledReport_scheduledReport_WidgetDateRangeOverride_scheduledReport_WidgetDateRangeOverride_EndTime_scheduledReport_WidgetDateRangeOverride_EndTime_Value = null;
            if (cmdletContext.ScheduledReport_WidgetDateRangeOverride_EndTime_Value != null)
            {
                requestScheduledReport_scheduledReport_WidgetDateRangeOverride_scheduledReport_WidgetDateRangeOverride_EndTime_scheduledReport_WidgetDateRangeOverride_EndTime_Value = cmdletContext.ScheduledReport_WidgetDateRangeOverride_EndTime_Value;
            }
            if (requestScheduledReport_scheduledReport_WidgetDateRangeOverride_scheduledReport_WidgetDateRangeOverride_EndTime_scheduledReport_WidgetDateRangeOverride_EndTime_Value != null)
            {
                requestScheduledReport_scheduledReport_WidgetDateRangeOverride_scheduledReport_WidgetDateRangeOverride_EndTime.Value = requestScheduledReport_scheduledReport_WidgetDateRangeOverride_scheduledReport_WidgetDateRangeOverride_EndTime_scheduledReport_WidgetDateRangeOverride_EndTime_Value;
                requestScheduledReport_scheduledReport_WidgetDateRangeOverride_scheduledReport_WidgetDateRangeOverride_EndTimeIsNull = false;
            }
             // determine if requestScheduledReport_scheduledReport_WidgetDateRangeOverride_scheduledReport_WidgetDateRangeOverride_EndTime should be set to null
            if (requestScheduledReport_scheduledReport_WidgetDateRangeOverride_scheduledReport_WidgetDateRangeOverride_EndTimeIsNull)
            {
                requestScheduledReport_scheduledReport_WidgetDateRangeOverride_scheduledReport_WidgetDateRangeOverride_EndTime = null;
            }
            if (requestScheduledReport_scheduledReport_WidgetDateRangeOverride_scheduledReport_WidgetDateRangeOverride_EndTime != null)
            {
                requestScheduledReport_scheduledReport_WidgetDateRangeOverride.EndTime = requestScheduledReport_scheduledReport_WidgetDateRangeOverride_scheduledReport_WidgetDateRangeOverride_EndTime;
                requestScheduledReport_scheduledReport_WidgetDateRangeOverrideIsNull = false;
            }
            Amazon.BCMDashboards.Model.DateTimeValue requestScheduledReport_scheduledReport_WidgetDateRangeOverride_scheduledReport_WidgetDateRangeOverride_StartTime = null;
            
             // populate StartTime
            var requestScheduledReport_scheduledReport_WidgetDateRangeOverride_scheduledReport_WidgetDateRangeOverride_StartTimeIsNull = true;
            requestScheduledReport_scheduledReport_WidgetDateRangeOverride_scheduledReport_WidgetDateRangeOverride_StartTime = new Amazon.BCMDashboards.Model.DateTimeValue();
            Amazon.BCMDashboards.DateTimeType requestScheduledReport_scheduledReport_WidgetDateRangeOverride_scheduledReport_WidgetDateRangeOverride_StartTime_scheduledReport_WidgetDateRangeOverride_StartTime_Type = null;
            if (cmdletContext.ScheduledReport_WidgetDateRangeOverride_StartTime_Type != null)
            {
                requestScheduledReport_scheduledReport_WidgetDateRangeOverride_scheduledReport_WidgetDateRangeOverride_StartTime_scheduledReport_WidgetDateRangeOverride_StartTime_Type = cmdletContext.ScheduledReport_WidgetDateRangeOverride_StartTime_Type;
            }
            if (requestScheduledReport_scheduledReport_WidgetDateRangeOverride_scheduledReport_WidgetDateRangeOverride_StartTime_scheduledReport_WidgetDateRangeOverride_StartTime_Type != null)
            {
                requestScheduledReport_scheduledReport_WidgetDateRangeOverride_scheduledReport_WidgetDateRangeOverride_StartTime.Type = requestScheduledReport_scheduledReport_WidgetDateRangeOverride_scheduledReport_WidgetDateRangeOverride_StartTime_scheduledReport_WidgetDateRangeOverride_StartTime_Type;
                requestScheduledReport_scheduledReport_WidgetDateRangeOverride_scheduledReport_WidgetDateRangeOverride_StartTimeIsNull = false;
            }
            System.String requestScheduledReport_scheduledReport_WidgetDateRangeOverride_scheduledReport_WidgetDateRangeOverride_StartTime_scheduledReport_WidgetDateRangeOverride_StartTime_Value = null;
            if (cmdletContext.ScheduledReport_WidgetDateRangeOverride_StartTime_Value != null)
            {
                requestScheduledReport_scheduledReport_WidgetDateRangeOverride_scheduledReport_WidgetDateRangeOverride_StartTime_scheduledReport_WidgetDateRangeOverride_StartTime_Value = cmdletContext.ScheduledReport_WidgetDateRangeOverride_StartTime_Value;
            }
            if (requestScheduledReport_scheduledReport_WidgetDateRangeOverride_scheduledReport_WidgetDateRangeOverride_StartTime_scheduledReport_WidgetDateRangeOverride_StartTime_Value != null)
            {
                requestScheduledReport_scheduledReport_WidgetDateRangeOverride_scheduledReport_WidgetDateRangeOverride_StartTime.Value = requestScheduledReport_scheduledReport_WidgetDateRangeOverride_scheduledReport_WidgetDateRangeOverride_StartTime_scheduledReport_WidgetDateRangeOverride_StartTime_Value;
                requestScheduledReport_scheduledReport_WidgetDateRangeOverride_scheduledReport_WidgetDateRangeOverride_StartTimeIsNull = false;
            }
             // determine if requestScheduledReport_scheduledReport_WidgetDateRangeOverride_scheduledReport_WidgetDateRangeOverride_StartTime should be set to null
            if (requestScheduledReport_scheduledReport_WidgetDateRangeOverride_scheduledReport_WidgetDateRangeOverride_StartTimeIsNull)
            {
                requestScheduledReport_scheduledReport_WidgetDateRangeOverride_scheduledReport_WidgetDateRangeOverride_StartTime = null;
            }
            if (requestScheduledReport_scheduledReport_WidgetDateRangeOverride_scheduledReport_WidgetDateRangeOverride_StartTime != null)
            {
                requestScheduledReport_scheduledReport_WidgetDateRangeOverride.StartTime = requestScheduledReport_scheduledReport_WidgetDateRangeOverride_scheduledReport_WidgetDateRangeOverride_StartTime;
                requestScheduledReport_scheduledReport_WidgetDateRangeOverrideIsNull = false;
            }
             // determine if requestScheduledReport_scheduledReport_WidgetDateRangeOverride should be set to null
            if (requestScheduledReport_scheduledReport_WidgetDateRangeOverrideIsNull)
            {
                requestScheduledReport_scheduledReport_WidgetDateRangeOverride = null;
            }
            if (requestScheduledReport_scheduledReport_WidgetDateRangeOverride != null)
            {
                request.ScheduledReport.WidgetDateRangeOverride = requestScheduledReport_scheduledReport_WidgetDateRangeOverride;
                requestScheduledReportIsNull = false;
            }
            Amazon.BCMDashboards.Model.ScheduleConfig requestScheduledReport_scheduledReport_ScheduleConfig = null;
            
             // populate ScheduleConfig
            var requestScheduledReport_scheduledReport_ScheduleConfigIsNull = true;
            requestScheduledReport_scheduledReport_ScheduleConfig = new Amazon.BCMDashboards.Model.ScheduleConfig();
            System.String requestScheduledReport_scheduledReport_ScheduleConfig_scheduledReport_ScheduleConfig_ScheduleExpression = null;
            if (cmdletContext.ScheduledReport_ScheduleConfig_ScheduleExpression != null)
            {
                requestScheduledReport_scheduledReport_ScheduleConfig_scheduledReport_ScheduleConfig_ScheduleExpression = cmdletContext.ScheduledReport_ScheduleConfig_ScheduleExpression;
            }
            if (requestScheduledReport_scheduledReport_ScheduleConfig_scheduledReport_ScheduleConfig_ScheduleExpression != null)
            {
                requestScheduledReport_scheduledReport_ScheduleConfig.ScheduleExpression = requestScheduledReport_scheduledReport_ScheduleConfig_scheduledReport_ScheduleConfig_ScheduleExpression;
                requestScheduledReport_scheduledReport_ScheduleConfigIsNull = false;
            }
            System.String requestScheduledReport_scheduledReport_ScheduleConfig_scheduledReport_ScheduleConfig_ScheduleExpressionTimeZone = null;
            if (cmdletContext.ScheduledReport_ScheduleConfig_ScheduleExpressionTimeZone != null)
            {
                requestScheduledReport_scheduledReport_ScheduleConfig_scheduledReport_ScheduleConfig_ScheduleExpressionTimeZone = cmdletContext.ScheduledReport_ScheduleConfig_ScheduleExpressionTimeZone;
            }
            if (requestScheduledReport_scheduledReport_ScheduleConfig_scheduledReport_ScheduleConfig_ScheduleExpressionTimeZone != null)
            {
                requestScheduledReport_scheduledReport_ScheduleConfig.ScheduleExpressionTimeZone = requestScheduledReport_scheduledReport_ScheduleConfig_scheduledReport_ScheduleConfig_ScheduleExpressionTimeZone;
                requestScheduledReport_scheduledReport_ScheduleConfigIsNull = false;
            }
            Amazon.BCMDashboards.ScheduleState requestScheduledReport_scheduledReport_ScheduleConfig_scheduledReport_ScheduleConfig_State = null;
            if (cmdletContext.ScheduledReport_ScheduleConfig_State != null)
            {
                requestScheduledReport_scheduledReport_ScheduleConfig_scheduledReport_ScheduleConfig_State = cmdletContext.ScheduledReport_ScheduleConfig_State;
            }
            if (requestScheduledReport_scheduledReport_ScheduleConfig_scheduledReport_ScheduleConfig_State != null)
            {
                requestScheduledReport_scheduledReport_ScheduleConfig.State = requestScheduledReport_scheduledReport_ScheduleConfig_scheduledReport_ScheduleConfig_State;
                requestScheduledReport_scheduledReport_ScheduleConfigIsNull = false;
            }
            Amazon.BCMDashboards.Model.SchedulePeriod requestScheduledReport_scheduledReport_ScheduleConfig_scheduledReport_ScheduleConfig_SchedulePeriod = null;
            
             // populate SchedulePeriod
            var requestScheduledReport_scheduledReport_ScheduleConfig_scheduledReport_ScheduleConfig_SchedulePeriodIsNull = true;
            requestScheduledReport_scheduledReport_ScheduleConfig_scheduledReport_ScheduleConfig_SchedulePeriod = new Amazon.BCMDashboards.Model.SchedulePeriod();
            System.DateTime? requestScheduledReport_scheduledReport_ScheduleConfig_scheduledReport_ScheduleConfig_SchedulePeriod_scheduledReport_ScheduleConfig_SchedulePeriod_EndTime = null;
            if (cmdletContext.ScheduledReport_ScheduleConfig_SchedulePeriod_EndTime != null)
            {
                requestScheduledReport_scheduledReport_ScheduleConfig_scheduledReport_ScheduleConfig_SchedulePeriod_scheduledReport_ScheduleConfig_SchedulePeriod_EndTime = cmdletContext.ScheduledReport_ScheduleConfig_SchedulePeriod_EndTime.Value;
            }
            if (requestScheduledReport_scheduledReport_ScheduleConfig_scheduledReport_ScheduleConfig_SchedulePeriod_scheduledReport_ScheduleConfig_SchedulePeriod_EndTime != null)
            {
                requestScheduledReport_scheduledReport_ScheduleConfig_scheduledReport_ScheduleConfig_SchedulePeriod.EndTime = requestScheduledReport_scheduledReport_ScheduleConfig_scheduledReport_ScheduleConfig_SchedulePeriod_scheduledReport_ScheduleConfig_SchedulePeriod_EndTime.Value;
                requestScheduledReport_scheduledReport_ScheduleConfig_scheduledReport_ScheduleConfig_SchedulePeriodIsNull = false;
            }
            System.DateTime? requestScheduledReport_scheduledReport_ScheduleConfig_scheduledReport_ScheduleConfig_SchedulePeriod_scheduledReport_ScheduleConfig_SchedulePeriod_StartTime = null;
            if (cmdletContext.ScheduledReport_ScheduleConfig_SchedulePeriod_StartTime != null)
            {
                requestScheduledReport_scheduledReport_ScheduleConfig_scheduledReport_ScheduleConfig_SchedulePeriod_scheduledReport_ScheduleConfig_SchedulePeriod_StartTime = cmdletContext.ScheduledReport_ScheduleConfig_SchedulePeriod_StartTime.Value;
            }
            if (requestScheduledReport_scheduledReport_ScheduleConfig_scheduledReport_ScheduleConfig_SchedulePeriod_scheduledReport_ScheduleConfig_SchedulePeriod_StartTime != null)
            {
                requestScheduledReport_scheduledReport_ScheduleConfig_scheduledReport_ScheduleConfig_SchedulePeriod.StartTime = requestScheduledReport_scheduledReport_ScheduleConfig_scheduledReport_ScheduleConfig_SchedulePeriod_scheduledReport_ScheduleConfig_SchedulePeriod_StartTime.Value;
                requestScheduledReport_scheduledReport_ScheduleConfig_scheduledReport_ScheduleConfig_SchedulePeriodIsNull = false;
            }
             // determine if requestScheduledReport_scheduledReport_ScheduleConfig_scheduledReport_ScheduleConfig_SchedulePeriod should be set to null
            if (requestScheduledReport_scheduledReport_ScheduleConfig_scheduledReport_ScheduleConfig_SchedulePeriodIsNull)
            {
                requestScheduledReport_scheduledReport_ScheduleConfig_scheduledReport_ScheduleConfig_SchedulePeriod = null;
            }
            if (requestScheduledReport_scheduledReport_ScheduleConfig_scheduledReport_ScheduleConfig_SchedulePeriod != null)
            {
                requestScheduledReport_scheduledReport_ScheduleConfig.SchedulePeriod = requestScheduledReport_scheduledReport_ScheduleConfig_scheduledReport_ScheduleConfig_SchedulePeriod;
                requestScheduledReport_scheduledReport_ScheduleConfigIsNull = false;
            }
             // determine if requestScheduledReport_scheduledReport_ScheduleConfig should be set to null
            if (requestScheduledReport_scheduledReport_ScheduleConfigIsNull)
            {
                requestScheduledReport_scheduledReport_ScheduleConfig = null;
            }
            if (requestScheduledReport_scheduledReport_ScheduleConfig != null)
            {
                request.ScheduledReport.ScheduleConfig = requestScheduledReport_scheduledReport_ScheduleConfig;
                requestScheduledReportIsNull = false;
            }
             // determine if request.ScheduledReport should be set to null
            if (requestScheduledReportIsNull)
            {
                request.ScheduledReport = null;
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
        
        private Amazon.BCMDashboards.Model.CreateScheduledReportResponse CallAWSServiceOperation(IAmazonBCMDashboards client, Amazon.BCMDashboards.Model.CreateScheduledReportRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Billing and Cost Management Dashboards", "CreateScheduledReport");
            try
            {
                return client.CreateScheduledReportAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.BCMDashboards.Model.ResourceTag> ResourceTag { get; set; }
            public System.String ScheduledReport_DashboardArn { get; set; }
            public System.String ScheduledReport_Description { get; set; }
            public System.String ScheduledReport_Name { get; set; }
            public System.String ScheduledReport_ScheduleConfig_ScheduleExpression { get; set; }
            public System.String ScheduledReport_ScheduleConfig_ScheduleExpressionTimeZone { get; set; }
            public System.DateTime? ScheduledReport_ScheduleConfig_SchedulePeriod_EndTime { get; set; }
            public System.DateTime? ScheduledReport_ScheduleConfig_SchedulePeriod_StartTime { get; set; }
            public Amazon.BCMDashboards.ScheduleState ScheduledReport_ScheduleConfig_State { get; set; }
            public System.String ScheduledReport_ScheduledReportExecutionRoleArn { get; set; }
            public Amazon.BCMDashboards.DateTimeType ScheduledReport_WidgetDateRangeOverride_EndTime_Type { get; set; }
            public System.String ScheduledReport_WidgetDateRangeOverride_EndTime_Value { get; set; }
            public Amazon.BCMDashboards.DateTimeType ScheduledReport_WidgetDateRangeOverride_StartTime_Type { get; set; }
            public System.String ScheduledReport_WidgetDateRangeOverride_StartTime_Value { get; set; }
            public List<System.String> ScheduledReport_WidgetId { get; set; }
            public System.Func<Amazon.BCMDashboards.Model.CreateScheduledReportResponse, NewBCMDScheduledReportCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Arn;
        }
        
    }
}
