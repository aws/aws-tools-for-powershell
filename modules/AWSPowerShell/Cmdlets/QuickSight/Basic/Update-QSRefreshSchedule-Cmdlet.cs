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
using Amazon.QuickSight;
using Amazon.QuickSight.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.QS
{
    /// <summary>
    /// Updates a refresh schedule for a dataset.
    /// </summary>
    [Cmdlet("Update", "QSRefreshSchedule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QuickSight.Model.UpdateRefreshScheduleResponse")]
    [AWSCmdlet("Calls the Amazon QuickSight UpdateRefreshSchedule API operation.", Operation = new[] {"UpdateRefreshSchedule"}, SelectReturnType = typeof(Amazon.QuickSight.Model.UpdateRefreshScheduleResponse))]
    [AWSCmdletOutput("Amazon.QuickSight.Model.UpdateRefreshScheduleResponse",
        "This cmdlet returns an Amazon.QuickSight.Model.UpdateRefreshScheduleResponse object containing multiple properties."
    )]
    public partial class UpdateQSRefreshScheduleCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Schedule_Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for the refresh schedule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Schedule_Arn { get; set; }
        #endregion
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID.</para>
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
        public System.String AwsAccountId { get; set; }
        #endregion
        
        #region Parameter DataSetId
        /// <summary>
        /// <para>
        /// <para>The ID of the dataset.</para>
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
        public System.String DataSetId { get; set; }
        #endregion
        
        #region Parameter RefreshOnDay_DayOfMonth
        /// <summary>
        /// <para>
        /// <para>The day of the month that you want to schedule refresh on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Schedule_ScheduleFrequency_RefreshOnDay_DayOfMonth")]
        public System.String RefreshOnDay_DayOfMonth { get; set; }
        #endregion
        
        #region Parameter RefreshOnDay_DayOfWeek
        /// <summary>
        /// <para>
        /// <para>The day of the week that you want to schedule a refresh on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Schedule_ScheduleFrequency_RefreshOnDay_DayOfWeek")]
        [AWSConstantClassSource("Amazon.QuickSight.DayOfWeek")]
        public Amazon.QuickSight.DayOfWeek RefreshOnDay_DayOfWeek { get; set; }
        #endregion
        
        #region Parameter ScheduleFrequency_Interval
        /// <summary>
        /// <para>
        /// <para>The interval between scheduled refreshes. Valid values are as follows:</para><ul><li><para><c>MINUTE15</c>: The dataset refreshes every 15 minutes. This value is only supported
        /// for incremental refreshes. This interval can only be used for one schedule per dataset.</para></li><li><para><c>MINUTE30</c>:The dataset refreshes every 30 minutes. This value is only supported
        /// for incremental refreshes. This interval can only be used for one schedule per dataset.</para></li><li><para><c>HOURLY</c>: The dataset refreshes every hour. This interval can only be used for
        /// one schedule per dataset.</para></li><li><para><c>DAILY</c>: The dataset refreshes every day.</para></li><li><para><c>WEEKLY</c>: The dataset refreshes every week.</para></li><li><para><c>MONTHLY</c>: The dataset refreshes every month.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Schedule_ScheduleFrequency_Interval")]
        [AWSConstantClassSource("Amazon.QuickSight.RefreshInterval")]
        public Amazon.QuickSight.RefreshInterval ScheduleFrequency_Interval { get; set; }
        #endregion
        
        #region Parameter Schedule_RefreshType
        /// <summary>
        /// <para>
        /// <para>The type of refresh that a datset undergoes. Valid values are as follows:</para><ul><li><para><c>FULL_REFRESH</c>: A complete refresh of a dataset.</para></li><li><para><c>INCREMENTAL_REFRESH</c>: A partial refresh of some rows of a dataset, based on
        /// the time window specified.</para></li></ul><para>For more information on full and incremental refreshes, see <a href="https://docs.aws.amazon.com/quicksight/latest/user/refreshing-imported-data.html">Refreshing
        /// SPICE data</a> in the <i>Amazon QuickSight User Guide</i>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.QuickSight.IngestionType")]
        public Amazon.QuickSight.IngestionType Schedule_RefreshType { get; set; }
        #endregion
        
        #region Parameter Schedule_ScheduleId
        /// <summary>
        /// <para>
        /// <para>An identifier for the refresh schedule.</para>
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
        public System.String Schedule_ScheduleId { get; set; }
        #endregion
        
        #region Parameter Schedule_StartAfterDateTime
        /// <summary>
        /// <para>
        /// <para>Time after which the refresh schedule can be started, expressed in <c>YYYY-MM-DDTHH:MM:SS</c>
        /// format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Schedule_StartAfterDateTime { get; set; }
        #endregion
        
        #region Parameter ScheduleFrequency_TimeOfTheDay
        /// <summary>
        /// <para>
        /// <para>The time of day that you want the datset to refresh. This value is expressed in HH:MM
        /// format. This field is not required for schedules that refresh hourly.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Schedule_ScheduleFrequency_TimeOfTheDay")]
        public System.String ScheduleFrequency_TimeOfTheDay { get; set; }
        #endregion
        
        #region Parameter ScheduleFrequency_Timezone
        /// <summary>
        /// <para>
        /// <para>The timezone that you want the refresh schedule to use. The timezone ID must match
        /// a corresponding ID found on <c>java.util.time.getAvailableIDs()</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Schedule_ScheduleFrequency_Timezone")]
        public System.String ScheduleFrequency_Timezone { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.UpdateRefreshScheduleResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.UpdateRefreshScheduleResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Schedule_ScheduleId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-QSRefreshSchedule (UpdateRefreshSchedule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.UpdateRefreshScheduleResponse, UpdateQSRefreshScheduleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DataSetId = this.DataSetId;
            #if MODULAR
            if (this.DataSetId == null && ParameterWasBound(nameof(this.DataSetId)))
            {
                WriteWarning("You are passing $null as a value for parameter DataSetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Schedule_Arn = this.Schedule_Arn;
            context.Schedule_RefreshType = this.Schedule_RefreshType;
            #if MODULAR
            if (this.Schedule_RefreshType == null && ParameterWasBound(nameof(this.Schedule_RefreshType)))
            {
                WriteWarning("You are passing $null as a value for parameter Schedule_RefreshType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScheduleFrequency_Interval = this.ScheduleFrequency_Interval;
            #if MODULAR
            if (this.ScheduleFrequency_Interval == null && ParameterWasBound(nameof(this.ScheduleFrequency_Interval)))
            {
                WriteWarning("You are passing $null as a value for parameter ScheduleFrequency_Interval which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RefreshOnDay_DayOfMonth = this.RefreshOnDay_DayOfMonth;
            context.RefreshOnDay_DayOfWeek = this.RefreshOnDay_DayOfWeek;
            context.ScheduleFrequency_TimeOfTheDay = this.ScheduleFrequency_TimeOfTheDay;
            context.ScheduleFrequency_Timezone = this.ScheduleFrequency_Timezone;
            context.Schedule_ScheduleId = this.Schedule_ScheduleId;
            #if MODULAR
            if (this.Schedule_ScheduleId == null && ParameterWasBound(nameof(this.Schedule_ScheduleId)))
            {
                WriteWarning("You are passing $null as a value for parameter Schedule_ScheduleId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Schedule_StartAfterDateTime = this.Schedule_StartAfterDateTime;
            
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
            var request = new Amazon.QuickSight.Model.UpdateRefreshScheduleRequest();
            
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            if (cmdletContext.DataSetId != null)
            {
                request.DataSetId = cmdletContext.DataSetId;
            }
            
             // populate Schedule
            var requestScheduleIsNull = true;
            request.Schedule = new Amazon.QuickSight.Model.RefreshSchedule();
            System.String requestSchedule_schedule_Arn = null;
            if (cmdletContext.Schedule_Arn != null)
            {
                requestSchedule_schedule_Arn = cmdletContext.Schedule_Arn;
            }
            if (requestSchedule_schedule_Arn != null)
            {
                request.Schedule.Arn = requestSchedule_schedule_Arn;
                requestScheduleIsNull = false;
            }
            Amazon.QuickSight.IngestionType requestSchedule_schedule_RefreshType = null;
            if (cmdletContext.Schedule_RefreshType != null)
            {
                requestSchedule_schedule_RefreshType = cmdletContext.Schedule_RefreshType;
            }
            if (requestSchedule_schedule_RefreshType != null)
            {
                request.Schedule.RefreshType = requestSchedule_schedule_RefreshType;
                requestScheduleIsNull = false;
            }
            System.String requestSchedule_schedule_ScheduleId = null;
            if (cmdletContext.Schedule_ScheduleId != null)
            {
                requestSchedule_schedule_ScheduleId = cmdletContext.Schedule_ScheduleId;
            }
            if (requestSchedule_schedule_ScheduleId != null)
            {
                request.Schedule.ScheduleId = requestSchedule_schedule_ScheduleId;
                requestScheduleIsNull = false;
            }
            System.DateTime? requestSchedule_schedule_StartAfterDateTime = null;
            if (cmdletContext.Schedule_StartAfterDateTime != null)
            {
                requestSchedule_schedule_StartAfterDateTime = cmdletContext.Schedule_StartAfterDateTime.Value;
            }
            if (requestSchedule_schedule_StartAfterDateTime != null)
            {
                request.Schedule.StartAfterDateTime = requestSchedule_schedule_StartAfterDateTime.Value;
                requestScheduleIsNull = false;
            }
            Amazon.QuickSight.Model.RefreshFrequency requestSchedule_schedule_ScheduleFrequency = null;
            
             // populate ScheduleFrequency
            var requestSchedule_schedule_ScheduleFrequencyIsNull = true;
            requestSchedule_schedule_ScheduleFrequency = new Amazon.QuickSight.Model.RefreshFrequency();
            Amazon.QuickSight.RefreshInterval requestSchedule_schedule_ScheduleFrequency_scheduleFrequency_Interval = null;
            if (cmdletContext.ScheduleFrequency_Interval != null)
            {
                requestSchedule_schedule_ScheduleFrequency_scheduleFrequency_Interval = cmdletContext.ScheduleFrequency_Interval;
            }
            if (requestSchedule_schedule_ScheduleFrequency_scheduleFrequency_Interval != null)
            {
                requestSchedule_schedule_ScheduleFrequency.Interval = requestSchedule_schedule_ScheduleFrequency_scheduleFrequency_Interval;
                requestSchedule_schedule_ScheduleFrequencyIsNull = false;
            }
            System.String requestSchedule_schedule_ScheduleFrequency_scheduleFrequency_TimeOfTheDay = null;
            if (cmdletContext.ScheduleFrequency_TimeOfTheDay != null)
            {
                requestSchedule_schedule_ScheduleFrequency_scheduleFrequency_TimeOfTheDay = cmdletContext.ScheduleFrequency_TimeOfTheDay;
            }
            if (requestSchedule_schedule_ScheduleFrequency_scheduleFrequency_TimeOfTheDay != null)
            {
                requestSchedule_schedule_ScheduleFrequency.TimeOfTheDay = requestSchedule_schedule_ScheduleFrequency_scheduleFrequency_TimeOfTheDay;
                requestSchedule_schedule_ScheduleFrequencyIsNull = false;
            }
            System.String requestSchedule_schedule_ScheduleFrequency_scheduleFrequency_Timezone = null;
            if (cmdletContext.ScheduleFrequency_Timezone != null)
            {
                requestSchedule_schedule_ScheduleFrequency_scheduleFrequency_Timezone = cmdletContext.ScheduleFrequency_Timezone;
            }
            if (requestSchedule_schedule_ScheduleFrequency_scheduleFrequency_Timezone != null)
            {
                requestSchedule_schedule_ScheduleFrequency.Timezone = requestSchedule_schedule_ScheduleFrequency_scheduleFrequency_Timezone;
                requestSchedule_schedule_ScheduleFrequencyIsNull = false;
            }
            Amazon.QuickSight.Model.ScheduleRefreshOnEntity requestSchedule_schedule_ScheduleFrequency_schedule_ScheduleFrequency_RefreshOnDay = null;
            
             // populate RefreshOnDay
            var requestSchedule_schedule_ScheduleFrequency_schedule_ScheduleFrequency_RefreshOnDayIsNull = true;
            requestSchedule_schedule_ScheduleFrequency_schedule_ScheduleFrequency_RefreshOnDay = new Amazon.QuickSight.Model.ScheduleRefreshOnEntity();
            System.String requestSchedule_schedule_ScheduleFrequency_schedule_ScheduleFrequency_RefreshOnDay_refreshOnDay_DayOfMonth = null;
            if (cmdletContext.RefreshOnDay_DayOfMonth != null)
            {
                requestSchedule_schedule_ScheduleFrequency_schedule_ScheduleFrequency_RefreshOnDay_refreshOnDay_DayOfMonth = cmdletContext.RefreshOnDay_DayOfMonth;
            }
            if (requestSchedule_schedule_ScheduleFrequency_schedule_ScheduleFrequency_RefreshOnDay_refreshOnDay_DayOfMonth != null)
            {
                requestSchedule_schedule_ScheduleFrequency_schedule_ScheduleFrequency_RefreshOnDay.DayOfMonth = requestSchedule_schedule_ScheduleFrequency_schedule_ScheduleFrequency_RefreshOnDay_refreshOnDay_DayOfMonth;
                requestSchedule_schedule_ScheduleFrequency_schedule_ScheduleFrequency_RefreshOnDayIsNull = false;
            }
            Amazon.QuickSight.DayOfWeek requestSchedule_schedule_ScheduleFrequency_schedule_ScheduleFrequency_RefreshOnDay_refreshOnDay_DayOfWeek = null;
            if (cmdletContext.RefreshOnDay_DayOfWeek != null)
            {
                requestSchedule_schedule_ScheduleFrequency_schedule_ScheduleFrequency_RefreshOnDay_refreshOnDay_DayOfWeek = cmdletContext.RefreshOnDay_DayOfWeek;
            }
            if (requestSchedule_schedule_ScheduleFrequency_schedule_ScheduleFrequency_RefreshOnDay_refreshOnDay_DayOfWeek != null)
            {
                requestSchedule_schedule_ScheduleFrequency_schedule_ScheduleFrequency_RefreshOnDay.DayOfWeek = requestSchedule_schedule_ScheduleFrequency_schedule_ScheduleFrequency_RefreshOnDay_refreshOnDay_DayOfWeek;
                requestSchedule_schedule_ScheduleFrequency_schedule_ScheduleFrequency_RefreshOnDayIsNull = false;
            }
             // determine if requestSchedule_schedule_ScheduleFrequency_schedule_ScheduleFrequency_RefreshOnDay should be set to null
            if (requestSchedule_schedule_ScheduleFrequency_schedule_ScheduleFrequency_RefreshOnDayIsNull)
            {
                requestSchedule_schedule_ScheduleFrequency_schedule_ScheduleFrequency_RefreshOnDay = null;
            }
            if (requestSchedule_schedule_ScheduleFrequency_schedule_ScheduleFrequency_RefreshOnDay != null)
            {
                requestSchedule_schedule_ScheduleFrequency.RefreshOnDay = requestSchedule_schedule_ScheduleFrequency_schedule_ScheduleFrequency_RefreshOnDay;
                requestSchedule_schedule_ScheduleFrequencyIsNull = false;
            }
             // determine if requestSchedule_schedule_ScheduleFrequency should be set to null
            if (requestSchedule_schedule_ScheduleFrequencyIsNull)
            {
                requestSchedule_schedule_ScheduleFrequency = null;
            }
            if (requestSchedule_schedule_ScheduleFrequency != null)
            {
                request.Schedule.ScheduleFrequency = requestSchedule_schedule_ScheduleFrequency;
                requestScheduleIsNull = false;
            }
             // determine if request.Schedule should be set to null
            if (requestScheduleIsNull)
            {
                request.Schedule = null;
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
        
        private Amazon.QuickSight.Model.UpdateRefreshScheduleResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.UpdateRefreshScheduleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "UpdateRefreshSchedule");
            try
            {
                return client.UpdateRefreshScheduleAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AwsAccountId { get; set; }
            public System.String DataSetId { get; set; }
            public System.String Schedule_Arn { get; set; }
            public Amazon.QuickSight.IngestionType Schedule_RefreshType { get; set; }
            public Amazon.QuickSight.RefreshInterval ScheduleFrequency_Interval { get; set; }
            public System.String RefreshOnDay_DayOfMonth { get; set; }
            public Amazon.QuickSight.DayOfWeek RefreshOnDay_DayOfWeek { get; set; }
            public System.String ScheduleFrequency_TimeOfTheDay { get; set; }
            public System.String ScheduleFrequency_Timezone { get; set; }
            public System.String Schedule_ScheduleId { get; set; }
            public System.DateTime? Schedule_StartAfterDateTime { get; set; }
            public System.Func<Amazon.QuickSight.Model.UpdateRefreshScheduleResponse, UpdateQSRefreshScheduleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
