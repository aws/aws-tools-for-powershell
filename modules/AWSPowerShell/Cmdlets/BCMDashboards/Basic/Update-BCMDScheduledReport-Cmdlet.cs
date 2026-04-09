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
    /// Updates an existing scheduled report's properties, including its name, description,
    /// schedule configuration, and widget settings. Only the parameters included in the request
    /// are updated; all other properties remain unchanged.
    /// </summary>
    [Cmdlet("Update", "BCMDScheduledReport", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Billing and Cost Management Dashboards UpdateScheduledReport API operation.", Operation = new[] {"UpdateScheduledReport"}, SelectReturnType = typeof(Amazon.BCMDashboards.Model.UpdateScheduledReportResponse))]
    [AWSCmdletOutput("System.String or Amazon.BCMDashboards.Model.UpdateScheduledReportResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.BCMDashboards.Model.UpdateScheduledReportResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateBCMDScheduledReportCmdlet : AmazonBCMDashboardsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para>The ARN of the scheduled report to update.</para>
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
        public System.String Arn { get; set; }
        #endregion
        
        #region Parameter ClearWidgetDateRangeOverride
        /// <summary>
        /// <para>
        /// <para>Set to true to clear existing widgetDateRangeOverride.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ClearWidgetDateRangeOverride { get; set; }
        #endregion
        
        #region Parameter ClearWidgetId
        /// <summary>
        /// <para>
        /// <para>Set to true to clear existing widgetIds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ClearWidgetIds")]
        public System.Boolean? ClearWidgetId { get; set; }
        #endregion
        
        #region Parameter DashboardArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the dashboard to associate with the scheduled report.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DashboardArn { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The new description for the scheduled report.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ScheduleConfig_SchedulePeriod_EndTime
        /// <summary>
        /// <para>
        /// <para>The end time of the schedule period. If not specified, defaults to 3 years from the
        /// time of the create or update request. The maximum allowed value is 3 years from the
        /// current time. Setting an end time beyond this limit returns a <c>ValidationException</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ScheduleConfig_SchedulePeriod_EndTime { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The new name for the scheduled report.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ScheduledReportExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that the scheduled report uses to execute. Amazon Web Services
        /// Billing and Cost Management Dashboards will assume this IAM role while executing the
        /// scheduled report.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ScheduledReportExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter ScheduleConfig_ScheduleExpression
        /// <summary>
        /// <para>
        /// <para>The schedule expression that specifies when to trigger the scheduled report run. This
        /// value must be a cron expression consisting of six fields separated by white spaces:
        /// <c>cron(minutes hours day_of_month month day_of_week year)</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ScheduleConfig_ScheduleExpression { get; set; }
        #endregion
        
        #region Parameter ScheduleConfig_ScheduleExpressionTimeZone
        /// <summary>
        /// <para>
        /// <para>The time zone for the schedule expression, for example, <c>UTC</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ScheduleConfig_ScheduleExpressionTimeZone { get; set; }
        #endregion
        
        #region Parameter ScheduleConfig_SchedulePeriod_StartTime
        /// <summary>
        /// <para>
        /// <para>The start time of the schedule period. If not specified, defaults to the time of the
        /// create or update request. The start time cannot be more than 5 minutes before the
        /// time of the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ScheduleConfig_SchedulePeriod_StartTime { get; set; }
        #endregion
        
        #region Parameter ScheduleConfig_State
        /// <summary>
        /// <para>
        /// <para>The state of the schedule. <c>ENABLED</c> means the scheduled report runs according
        /// to its schedule expression. <c>DISABLED</c> means the scheduled report is paused and
        /// will not run until re-enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BCMDashboards.ScheduleState")]
        public Amazon.BCMDashboards.ScheduleState ScheduleConfig_State { get; set; }
        #endregion
        
        #region Parameter WidgetDateRangeOverride_EndTime_Type
        /// <summary>
        /// <para>
        /// <para>The type of date/time value: <c>ABSOLUTE</c> for specific dates or <c>RELATIVE</c>
        /// for dynamic time periods.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BCMDashboards.DateTimeType")]
        public Amazon.BCMDashboards.DateTimeType WidgetDateRangeOverride_EndTime_Type { get; set; }
        #endregion
        
        #region Parameter WidgetDateRangeOverride_StartTime_Type
        /// <summary>
        /// <para>
        /// <para>The type of date/time value: <c>ABSOLUTE</c> for specific dates or <c>RELATIVE</c>
        /// for dynamic time periods.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BCMDashboards.DateTimeType")]
        public Amazon.BCMDashboards.DateTimeType WidgetDateRangeOverride_StartTime_Type { get; set; }
        #endregion
        
        #region Parameter WidgetDateRangeOverride_EndTime_Value
        /// <summary>
        /// <para>
        /// <para>The actual date/time value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WidgetDateRangeOverride_EndTime_Value { get; set; }
        #endregion
        
        #region Parameter WidgetDateRangeOverride_StartTime_Value
        /// <summary>
        /// <para>
        /// <para>The actual date/time value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WidgetDateRangeOverride_StartTime_Value { get; set; }
        #endregion
        
        #region Parameter WidgetId
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
        [Alias("WidgetIds")]
        public System.String[] WidgetId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Arn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BCMDashboards.Model.UpdateScheduledReportResponse).
        /// Specifying the name of a property of type Amazon.BCMDashboards.Model.UpdateScheduledReportResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Arn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BCMDScheduledReport (UpdateScheduledReport)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BCMDashboards.Model.UpdateScheduledReportResponse, UpdateBCMDScheduledReportCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Arn = this.Arn;
            #if MODULAR
            if (this.Arn == null && ParameterWasBound(nameof(this.Arn)))
            {
                WriteWarning("You are passing $null as a value for parameter Arn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClearWidgetDateRangeOverride = this.ClearWidgetDateRangeOverride;
            context.ClearWidgetId = this.ClearWidgetId;
            context.DashboardArn = this.DashboardArn;
            context.Description = this.Description;
            context.Name = this.Name;
            context.ScheduleConfig_ScheduleExpression = this.ScheduleConfig_ScheduleExpression;
            context.ScheduleConfig_ScheduleExpressionTimeZone = this.ScheduleConfig_ScheduleExpressionTimeZone;
            context.ScheduleConfig_SchedulePeriod_EndTime = this.ScheduleConfig_SchedulePeriod_EndTime;
            context.ScheduleConfig_SchedulePeriod_StartTime = this.ScheduleConfig_SchedulePeriod_StartTime;
            context.ScheduleConfig_State = this.ScheduleConfig_State;
            context.ScheduledReportExecutionRoleArn = this.ScheduledReportExecutionRoleArn;
            context.WidgetDateRangeOverride_EndTime_Type = this.WidgetDateRangeOverride_EndTime_Type;
            context.WidgetDateRangeOverride_EndTime_Value = this.WidgetDateRangeOverride_EndTime_Value;
            context.WidgetDateRangeOverride_StartTime_Type = this.WidgetDateRangeOverride_StartTime_Type;
            context.WidgetDateRangeOverride_StartTime_Value = this.WidgetDateRangeOverride_StartTime_Value;
            if (this.WidgetId != null)
            {
                context.WidgetId = new List<System.String>(this.WidgetId);
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
            var request = new Amazon.BCMDashboards.Model.UpdateScheduledReportRequest();
            
            if (cmdletContext.Arn != null)
            {
                request.Arn = cmdletContext.Arn;
            }
            if (cmdletContext.ClearWidgetDateRangeOverride != null)
            {
                request.ClearWidgetDateRangeOverride = cmdletContext.ClearWidgetDateRangeOverride.Value;
            }
            if (cmdletContext.ClearWidgetId != null)
            {
                request.ClearWidgetIds = cmdletContext.ClearWidgetId.Value;
            }
            if (cmdletContext.DashboardArn != null)
            {
                request.DashboardArn = cmdletContext.DashboardArn;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate ScheduleConfig
            var requestScheduleConfigIsNull = true;
            request.ScheduleConfig = new Amazon.BCMDashboards.Model.ScheduleConfig();
            System.String requestScheduleConfig_scheduleConfig_ScheduleExpression = null;
            if (cmdletContext.ScheduleConfig_ScheduleExpression != null)
            {
                requestScheduleConfig_scheduleConfig_ScheduleExpression = cmdletContext.ScheduleConfig_ScheduleExpression;
            }
            if (requestScheduleConfig_scheduleConfig_ScheduleExpression != null)
            {
                request.ScheduleConfig.ScheduleExpression = requestScheduleConfig_scheduleConfig_ScheduleExpression;
                requestScheduleConfigIsNull = false;
            }
            System.String requestScheduleConfig_scheduleConfig_ScheduleExpressionTimeZone = null;
            if (cmdletContext.ScheduleConfig_ScheduleExpressionTimeZone != null)
            {
                requestScheduleConfig_scheduleConfig_ScheduleExpressionTimeZone = cmdletContext.ScheduleConfig_ScheduleExpressionTimeZone;
            }
            if (requestScheduleConfig_scheduleConfig_ScheduleExpressionTimeZone != null)
            {
                request.ScheduleConfig.ScheduleExpressionTimeZone = requestScheduleConfig_scheduleConfig_ScheduleExpressionTimeZone;
                requestScheduleConfigIsNull = false;
            }
            Amazon.BCMDashboards.ScheduleState requestScheduleConfig_scheduleConfig_State = null;
            if (cmdletContext.ScheduleConfig_State != null)
            {
                requestScheduleConfig_scheduleConfig_State = cmdletContext.ScheduleConfig_State;
            }
            if (requestScheduleConfig_scheduleConfig_State != null)
            {
                request.ScheduleConfig.State = requestScheduleConfig_scheduleConfig_State;
                requestScheduleConfigIsNull = false;
            }
            Amazon.BCMDashboards.Model.SchedulePeriod requestScheduleConfig_scheduleConfig_SchedulePeriod = null;
            
             // populate SchedulePeriod
            var requestScheduleConfig_scheduleConfig_SchedulePeriodIsNull = true;
            requestScheduleConfig_scheduleConfig_SchedulePeriod = new Amazon.BCMDashboards.Model.SchedulePeriod();
            System.DateTime? requestScheduleConfig_scheduleConfig_SchedulePeriod_scheduleConfig_SchedulePeriod_EndTime = null;
            if (cmdletContext.ScheduleConfig_SchedulePeriod_EndTime != null)
            {
                requestScheduleConfig_scheduleConfig_SchedulePeriod_scheduleConfig_SchedulePeriod_EndTime = cmdletContext.ScheduleConfig_SchedulePeriod_EndTime.Value;
            }
            if (requestScheduleConfig_scheduleConfig_SchedulePeriod_scheduleConfig_SchedulePeriod_EndTime != null)
            {
                requestScheduleConfig_scheduleConfig_SchedulePeriod.EndTime = requestScheduleConfig_scheduleConfig_SchedulePeriod_scheduleConfig_SchedulePeriod_EndTime.Value;
                requestScheduleConfig_scheduleConfig_SchedulePeriodIsNull = false;
            }
            System.DateTime? requestScheduleConfig_scheduleConfig_SchedulePeriod_scheduleConfig_SchedulePeriod_StartTime = null;
            if (cmdletContext.ScheduleConfig_SchedulePeriod_StartTime != null)
            {
                requestScheduleConfig_scheduleConfig_SchedulePeriod_scheduleConfig_SchedulePeriod_StartTime = cmdletContext.ScheduleConfig_SchedulePeriod_StartTime.Value;
            }
            if (requestScheduleConfig_scheduleConfig_SchedulePeriod_scheduleConfig_SchedulePeriod_StartTime != null)
            {
                requestScheduleConfig_scheduleConfig_SchedulePeriod.StartTime = requestScheduleConfig_scheduleConfig_SchedulePeriod_scheduleConfig_SchedulePeriod_StartTime.Value;
                requestScheduleConfig_scheduleConfig_SchedulePeriodIsNull = false;
            }
             // determine if requestScheduleConfig_scheduleConfig_SchedulePeriod should be set to null
            if (requestScheduleConfig_scheduleConfig_SchedulePeriodIsNull)
            {
                requestScheduleConfig_scheduleConfig_SchedulePeriod = null;
            }
            if (requestScheduleConfig_scheduleConfig_SchedulePeriod != null)
            {
                request.ScheduleConfig.SchedulePeriod = requestScheduleConfig_scheduleConfig_SchedulePeriod;
                requestScheduleConfigIsNull = false;
            }
             // determine if request.ScheduleConfig should be set to null
            if (requestScheduleConfigIsNull)
            {
                request.ScheduleConfig = null;
            }
            if (cmdletContext.ScheduledReportExecutionRoleArn != null)
            {
                request.ScheduledReportExecutionRoleArn = cmdletContext.ScheduledReportExecutionRoleArn;
            }
            
             // populate WidgetDateRangeOverride
            var requestWidgetDateRangeOverrideIsNull = true;
            request.WidgetDateRangeOverride = new Amazon.BCMDashboards.Model.DateTimeRange();
            Amazon.BCMDashboards.Model.DateTimeValue requestWidgetDateRangeOverride_widgetDateRangeOverride_EndTime = null;
            
             // populate EndTime
            var requestWidgetDateRangeOverride_widgetDateRangeOverride_EndTimeIsNull = true;
            requestWidgetDateRangeOverride_widgetDateRangeOverride_EndTime = new Amazon.BCMDashboards.Model.DateTimeValue();
            Amazon.BCMDashboards.DateTimeType requestWidgetDateRangeOverride_widgetDateRangeOverride_EndTime_widgetDateRangeOverride_EndTime_Type = null;
            if (cmdletContext.WidgetDateRangeOverride_EndTime_Type != null)
            {
                requestWidgetDateRangeOverride_widgetDateRangeOverride_EndTime_widgetDateRangeOverride_EndTime_Type = cmdletContext.WidgetDateRangeOverride_EndTime_Type;
            }
            if (requestWidgetDateRangeOverride_widgetDateRangeOverride_EndTime_widgetDateRangeOverride_EndTime_Type != null)
            {
                requestWidgetDateRangeOverride_widgetDateRangeOverride_EndTime.Type = requestWidgetDateRangeOverride_widgetDateRangeOverride_EndTime_widgetDateRangeOverride_EndTime_Type;
                requestWidgetDateRangeOverride_widgetDateRangeOverride_EndTimeIsNull = false;
            }
            System.String requestWidgetDateRangeOverride_widgetDateRangeOverride_EndTime_widgetDateRangeOverride_EndTime_Value = null;
            if (cmdletContext.WidgetDateRangeOverride_EndTime_Value != null)
            {
                requestWidgetDateRangeOverride_widgetDateRangeOverride_EndTime_widgetDateRangeOverride_EndTime_Value = cmdletContext.WidgetDateRangeOverride_EndTime_Value;
            }
            if (requestWidgetDateRangeOverride_widgetDateRangeOverride_EndTime_widgetDateRangeOverride_EndTime_Value != null)
            {
                requestWidgetDateRangeOverride_widgetDateRangeOverride_EndTime.Value = requestWidgetDateRangeOverride_widgetDateRangeOverride_EndTime_widgetDateRangeOverride_EndTime_Value;
                requestWidgetDateRangeOverride_widgetDateRangeOverride_EndTimeIsNull = false;
            }
             // determine if requestWidgetDateRangeOverride_widgetDateRangeOverride_EndTime should be set to null
            if (requestWidgetDateRangeOverride_widgetDateRangeOverride_EndTimeIsNull)
            {
                requestWidgetDateRangeOverride_widgetDateRangeOverride_EndTime = null;
            }
            if (requestWidgetDateRangeOverride_widgetDateRangeOverride_EndTime != null)
            {
                request.WidgetDateRangeOverride.EndTime = requestWidgetDateRangeOverride_widgetDateRangeOverride_EndTime;
                requestWidgetDateRangeOverrideIsNull = false;
            }
            Amazon.BCMDashboards.Model.DateTimeValue requestWidgetDateRangeOverride_widgetDateRangeOverride_StartTime = null;
            
             // populate StartTime
            var requestWidgetDateRangeOverride_widgetDateRangeOverride_StartTimeIsNull = true;
            requestWidgetDateRangeOverride_widgetDateRangeOverride_StartTime = new Amazon.BCMDashboards.Model.DateTimeValue();
            Amazon.BCMDashboards.DateTimeType requestWidgetDateRangeOverride_widgetDateRangeOverride_StartTime_widgetDateRangeOverride_StartTime_Type = null;
            if (cmdletContext.WidgetDateRangeOverride_StartTime_Type != null)
            {
                requestWidgetDateRangeOverride_widgetDateRangeOverride_StartTime_widgetDateRangeOverride_StartTime_Type = cmdletContext.WidgetDateRangeOverride_StartTime_Type;
            }
            if (requestWidgetDateRangeOverride_widgetDateRangeOverride_StartTime_widgetDateRangeOverride_StartTime_Type != null)
            {
                requestWidgetDateRangeOverride_widgetDateRangeOverride_StartTime.Type = requestWidgetDateRangeOverride_widgetDateRangeOverride_StartTime_widgetDateRangeOverride_StartTime_Type;
                requestWidgetDateRangeOverride_widgetDateRangeOverride_StartTimeIsNull = false;
            }
            System.String requestWidgetDateRangeOverride_widgetDateRangeOverride_StartTime_widgetDateRangeOverride_StartTime_Value = null;
            if (cmdletContext.WidgetDateRangeOverride_StartTime_Value != null)
            {
                requestWidgetDateRangeOverride_widgetDateRangeOverride_StartTime_widgetDateRangeOverride_StartTime_Value = cmdletContext.WidgetDateRangeOverride_StartTime_Value;
            }
            if (requestWidgetDateRangeOverride_widgetDateRangeOverride_StartTime_widgetDateRangeOverride_StartTime_Value != null)
            {
                requestWidgetDateRangeOverride_widgetDateRangeOverride_StartTime.Value = requestWidgetDateRangeOverride_widgetDateRangeOverride_StartTime_widgetDateRangeOverride_StartTime_Value;
                requestWidgetDateRangeOverride_widgetDateRangeOverride_StartTimeIsNull = false;
            }
             // determine if requestWidgetDateRangeOverride_widgetDateRangeOverride_StartTime should be set to null
            if (requestWidgetDateRangeOverride_widgetDateRangeOverride_StartTimeIsNull)
            {
                requestWidgetDateRangeOverride_widgetDateRangeOverride_StartTime = null;
            }
            if (requestWidgetDateRangeOverride_widgetDateRangeOverride_StartTime != null)
            {
                request.WidgetDateRangeOverride.StartTime = requestWidgetDateRangeOverride_widgetDateRangeOverride_StartTime;
                requestWidgetDateRangeOverrideIsNull = false;
            }
             // determine if request.WidgetDateRangeOverride should be set to null
            if (requestWidgetDateRangeOverrideIsNull)
            {
                request.WidgetDateRangeOverride = null;
            }
            if (cmdletContext.WidgetId != null)
            {
                request.WidgetIds = cmdletContext.WidgetId;
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
        
        private Amazon.BCMDashboards.Model.UpdateScheduledReportResponse CallAWSServiceOperation(IAmazonBCMDashboards client, Amazon.BCMDashboards.Model.UpdateScheduledReportRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Billing and Cost Management Dashboards", "UpdateScheduledReport");
            try
            {
                return client.UpdateScheduledReportAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Arn { get; set; }
            public System.Boolean? ClearWidgetDateRangeOverride { get; set; }
            public System.Boolean? ClearWidgetId { get; set; }
            public System.String DashboardArn { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public System.String ScheduleConfig_ScheduleExpression { get; set; }
            public System.String ScheduleConfig_ScheduleExpressionTimeZone { get; set; }
            public System.DateTime? ScheduleConfig_SchedulePeriod_EndTime { get; set; }
            public System.DateTime? ScheduleConfig_SchedulePeriod_StartTime { get; set; }
            public Amazon.BCMDashboards.ScheduleState ScheduleConfig_State { get; set; }
            public System.String ScheduledReportExecutionRoleArn { get; set; }
            public Amazon.BCMDashboards.DateTimeType WidgetDateRangeOverride_EndTime_Type { get; set; }
            public System.String WidgetDateRangeOverride_EndTime_Value { get; set; }
            public Amazon.BCMDashboards.DateTimeType WidgetDateRangeOverride_StartTime_Type { get; set; }
            public System.String WidgetDateRangeOverride_StartTime_Value { get; set; }
            public List<System.String> WidgetId { get; set; }
            public System.Func<Amazon.BCMDashboards.Model.UpdateScheduledReportResponse, UpdateBCMDScheduledReportCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Arn;
        }
        
    }
}
