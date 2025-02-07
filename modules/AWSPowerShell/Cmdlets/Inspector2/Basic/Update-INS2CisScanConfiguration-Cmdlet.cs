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
using Amazon.Inspector2;
using Amazon.Inspector2.Model;

namespace Amazon.PowerShell.Cmdlets.INS2
{
    /// <summary>
    /// Updates a CIS scan configuration.
    /// </summary>
    [Cmdlet("Update", "INS2CisScanConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Inspector2 UpdateCisScanConfiguration API operation.", Operation = new[] {"UpdateCisScanConfiguration"}, SelectReturnType = typeof(Amazon.Inspector2.Model.UpdateCisScanConfigurationResponse))]
    [AWSCmdletOutput("System.String or Amazon.Inspector2.Model.UpdateCisScanConfigurationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Inspector2.Model.UpdateCisScanConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateINS2CisScanConfigurationCmdlet : AmazonInspector2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Targets_AccountId
        /// <summary>
        /// <para>
        /// <para>The target account ids.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Targets_AccountIds")]
        public System.String[] Targets_AccountId { get; set; }
        #endregion
        
        #region Parameter Monthly_Day
        /// <summary>
        /// <para>
        /// <para>The monthly schedule's day.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Schedule_Monthly_Day")]
        [AWSConstantClassSource("Amazon.Inspector2.Day")]
        public Amazon.Inspector2.Day Monthly_Day { get; set; }
        #endregion
        
        #region Parameter Weekly_Day
        /// <summary>
        /// <para>
        /// <para>The weekly schedule's days.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Schedule_Weekly_Days")]
        public System.String[] Weekly_Day { get; set; }
        #endregion
        
        #region Parameter Schedule_OneTime
        /// <summary>
        /// <para>
        /// <para>The schedule's one time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.OneTimeSchedule Schedule_OneTime { get; set; }
        #endregion
        
        #region Parameter ScanConfigurationArn
        /// <summary>
        /// <para>
        /// <para>The CIS scan configuration ARN.</para>
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
        public System.String ScanConfigurationArn { get; set; }
        #endregion
        
        #region Parameter ScanName
        /// <summary>
        /// <para>
        /// <para>The scan name for the CIS scan configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ScanName { get; set; }
        #endregion
        
        #region Parameter SecurityLevel
        /// <summary>
        /// <para>
        /// <para> The security level for the CIS scan configuration. Security level refers to the Benchmark
        /// levels that CIS assigns to a profile. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Inspector2.CisSecurityLevel")]
        public Amazon.Inspector2.CisSecurityLevel SecurityLevel { get; set; }
        #endregion
        
        #region Parameter Targets_TargetResourceTag
        /// <summary>
        /// <para>
        /// <para>The target resource tags.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Targets_TargetResourceTags")]
        public System.Collections.Hashtable Targets_TargetResourceTag { get; set; }
        #endregion
        
        #region Parameter Schedule_Daily_StartTime_TimeOfDay
        /// <summary>
        /// <para>
        /// <para>The time of day in 24-hour format (00:00).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Schedule_Daily_StartTime_TimeOfDay { get; set; }
        #endregion
        
        #region Parameter Schedule_Monthly_StartTime_TimeOfDay
        /// <summary>
        /// <para>
        /// <para>The time of day in 24-hour format (00:00).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Schedule_Monthly_StartTime_TimeOfDay { get; set; }
        #endregion
        
        #region Parameter Schedule_Weekly_StartTime_TimeOfDay
        /// <summary>
        /// <para>
        /// <para>The time of day in 24-hour format (00:00).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Schedule_Weekly_StartTime_TimeOfDay { get; set; }
        #endregion
        
        #region Parameter Schedule_Daily_StartTime_Timezone
        /// <summary>
        /// <para>
        /// <para>The timezone.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Schedule_Daily_StartTime_Timezone { get; set; }
        #endregion
        
        #region Parameter Schedule_Monthly_StartTime_Timezone
        /// <summary>
        /// <para>
        /// <para>The timezone.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Schedule_Monthly_StartTime_Timezone { get; set; }
        #endregion
        
        #region Parameter Schedule_Weekly_StartTime_Timezone
        /// <summary>
        /// <para>
        /// <para>The timezone.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Schedule_Weekly_StartTime_Timezone { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ScanConfigurationArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Inspector2.Model.UpdateCisScanConfigurationResponse).
        /// Specifying the name of a property of type Amazon.Inspector2.Model.UpdateCisScanConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ScanConfigurationArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ScanConfigurationArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-INS2CisScanConfiguration (UpdateCisScanConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Inspector2.Model.UpdateCisScanConfigurationResponse, UpdateINS2CisScanConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ScanConfigurationArn = this.ScanConfigurationArn;
            #if MODULAR
            if (this.ScanConfigurationArn == null && ParameterWasBound(nameof(this.ScanConfigurationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ScanConfigurationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScanName = this.ScanName;
            context.Schedule_Daily_StartTime_TimeOfDay = this.Schedule_Daily_StartTime_TimeOfDay;
            context.Schedule_Daily_StartTime_Timezone = this.Schedule_Daily_StartTime_Timezone;
            context.Monthly_Day = this.Monthly_Day;
            context.Schedule_Monthly_StartTime_TimeOfDay = this.Schedule_Monthly_StartTime_TimeOfDay;
            context.Schedule_Monthly_StartTime_Timezone = this.Schedule_Monthly_StartTime_Timezone;
            context.Schedule_OneTime = this.Schedule_OneTime;
            if (this.Weekly_Day != null)
            {
                context.Weekly_Day = new List<System.String>(this.Weekly_Day);
            }
            context.Schedule_Weekly_StartTime_TimeOfDay = this.Schedule_Weekly_StartTime_TimeOfDay;
            context.Schedule_Weekly_StartTime_Timezone = this.Schedule_Weekly_StartTime_Timezone;
            context.SecurityLevel = this.SecurityLevel;
            if (this.Targets_AccountId != null)
            {
                context.Targets_AccountId = new List<System.String>(this.Targets_AccountId);
            }
            if (this.Targets_TargetResourceTag != null)
            {
                context.Targets_TargetResourceTag = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.Targets_TargetResourceTag.Keys)
                {
                    object hashValue = this.Targets_TargetResourceTag[hashKey];
                    if (hashValue == null)
                    {
                        context.Targets_TargetResourceTag.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<System.String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((System.String)s);
                    }
                    context.Targets_TargetResourceTag.Add((String)hashKey, valueSet);
                }
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
            var request = new Amazon.Inspector2.Model.UpdateCisScanConfigurationRequest();
            
            if (cmdletContext.ScanConfigurationArn != null)
            {
                request.ScanConfigurationArn = cmdletContext.ScanConfigurationArn;
            }
            if (cmdletContext.ScanName != null)
            {
                request.ScanName = cmdletContext.ScanName;
            }
            
             // populate Schedule
            var requestScheduleIsNull = true;
            request.Schedule = new Amazon.Inspector2.Model.Schedule();
            Amazon.Inspector2.Model.OneTimeSchedule requestSchedule_schedule_OneTime = null;
            if (cmdletContext.Schedule_OneTime != null)
            {
                requestSchedule_schedule_OneTime = cmdletContext.Schedule_OneTime;
            }
            if (requestSchedule_schedule_OneTime != null)
            {
                request.Schedule.OneTime = requestSchedule_schedule_OneTime;
                requestScheduleIsNull = false;
            }
            Amazon.Inspector2.Model.DailySchedule requestSchedule_schedule_Daily = null;
            
             // populate Daily
            var requestSchedule_schedule_DailyIsNull = true;
            requestSchedule_schedule_Daily = new Amazon.Inspector2.Model.DailySchedule();
            Amazon.Inspector2.Model.Time requestSchedule_schedule_Daily_schedule_Daily_StartTime = null;
            
             // populate StartTime
            var requestSchedule_schedule_Daily_schedule_Daily_StartTimeIsNull = true;
            requestSchedule_schedule_Daily_schedule_Daily_StartTime = new Amazon.Inspector2.Model.Time();
            System.String requestSchedule_schedule_Daily_schedule_Daily_StartTime_schedule_Daily_StartTime_TimeOfDay = null;
            if (cmdletContext.Schedule_Daily_StartTime_TimeOfDay != null)
            {
                requestSchedule_schedule_Daily_schedule_Daily_StartTime_schedule_Daily_StartTime_TimeOfDay = cmdletContext.Schedule_Daily_StartTime_TimeOfDay;
            }
            if (requestSchedule_schedule_Daily_schedule_Daily_StartTime_schedule_Daily_StartTime_TimeOfDay != null)
            {
                requestSchedule_schedule_Daily_schedule_Daily_StartTime.TimeOfDay = requestSchedule_schedule_Daily_schedule_Daily_StartTime_schedule_Daily_StartTime_TimeOfDay;
                requestSchedule_schedule_Daily_schedule_Daily_StartTimeIsNull = false;
            }
            System.String requestSchedule_schedule_Daily_schedule_Daily_StartTime_schedule_Daily_StartTime_Timezone = null;
            if (cmdletContext.Schedule_Daily_StartTime_Timezone != null)
            {
                requestSchedule_schedule_Daily_schedule_Daily_StartTime_schedule_Daily_StartTime_Timezone = cmdletContext.Schedule_Daily_StartTime_Timezone;
            }
            if (requestSchedule_schedule_Daily_schedule_Daily_StartTime_schedule_Daily_StartTime_Timezone != null)
            {
                requestSchedule_schedule_Daily_schedule_Daily_StartTime.Timezone = requestSchedule_schedule_Daily_schedule_Daily_StartTime_schedule_Daily_StartTime_Timezone;
                requestSchedule_schedule_Daily_schedule_Daily_StartTimeIsNull = false;
            }
             // determine if requestSchedule_schedule_Daily_schedule_Daily_StartTime should be set to null
            if (requestSchedule_schedule_Daily_schedule_Daily_StartTimeIsNull)
            {
                requestSchedule_schedule_Daily_schedule_Daily_StartTime = null;
            }
            if (requestSchedule_schedule_Daily_schedule_Daily_StartTime != null)
            {
                requestSchedule_schedule_Daily.StartTime = requestSchedule_schedule_Daily_schedule_Daily_StartTime;
                requestSchedule_schedule_DailyIsNull = false;
            }
             // determine if requestSchedule_schedule_Daily should be set to null
            if (requestSchedule_schedule_DailyIsNull)
            {
                requestSchedule_schedule_Daily = null;
            }
            if (requestSchedule_schedule_Daily != null)
            {
                request.Schedule.Daily = requestSchedule_schedule_Daily;
                requestScheduleIsNull = false;
            }
            Amazon.Inspector2.Model.MonthlySchedule requestSchedule_schedule_Monthly = null;
            
             // populate Monthly
            var requestSchedule_schedule_MonthlyIsNull = true;
            requestSchedule_schedule_Monthly = new Amazon.Inspector2.Model.MonthlySchedule();
            Amazon.Inspector2.Day requestSchedule_schedule_Monthly_monthly_Day = null;
            if (cmdletContext.Monthly_Day != null)
            {
                requestSchedule_schedule_Monthly_monthly_Day = cmdletContext.Monthly_Day;
            }
            if (requestSchedule_schedule_Monthly_monthly_Day != null)
            {
                requestSchedule_schedule_Monthly.Day = requestSchedule_schedule_Monthly_monthly_Day;
                requestSchedule_schedule_MonthlyIsNull = false;
            }
            Amazon.Inspector2.Model.Time requestSchedule_schedule_Monthly_schedule_Monthly_StartTime = null;
            
             // populate StartTime
            var requestSchedule_schedule_Monthly_schedule_Monthly_StartTimeIsNull = true;
            requestSchedule_schedule_Monthly_schedule_Monthly_StartTime = new Amazon.Inspector2.Model.Time();
            System.String requestSchedule_schedule_Monthly_schedule_Monthly_StartTime_schedule_Monthly_StartTime_TimeOfDay = null;
            if (cmdletContext.Schedule_Monthly_StartTime_TimeOfDay != null)
            {
                requestSchedule_schedule_Monthly_schedule_Monthly_StartTime_schedule_Monthly_StartTime_TimeOfDay = cmdletContext.Schedule_Monthly_StartTime_TimeOfDay;
            }
            if (requestSchedule_schedule_Monthly_schedule_Monthly_StartTime_schedule_Monthly_StartTime_TimeOfDay != null)
            {
                requestSchedule_schedule_Monthly_schedule_Monthly_StartTime.TimeOfDay = requestSchedule_schedule_Monthly_schedule_Monthly_StartTime_schedule_Monthly_StartTime_TimeOfDay;
                requestSchedule_schedule_Monthly_schedule_Monthly_StartTimeIsNull = false;
            }
            System.String requestSchedule_schedule_Monthly_schedule_Monthly_StartTime_schedule_Monthly_StartTime_Timezone = null;
            if (cmdletContext.Schedule_Monthly_StartTime_Timezone != null)
            {
                requestSchedule_schedule_Monthly_schedule_Monthly_StartTime_schedule_Monthly_StartTime_Timezone = cmdletContext.Schedule_Monthly_StartTime_Timezone;
            }
            if (requestSchedule_schedule_Monthly_schedule_Monthly_StartTime_schedule_Monthly_StartTime_Timezone != null)
            {
                requestSchedule_schedule_Monthly_schedule_Monthly_StartTime.Timezone = requestSchedule_schedule_Monthly_schedule_Monthly_StartTime_schedule_Monthly_StartTime_Timezone;
                requestSchedule_schedule_Monthly_schedule_Monthly_StartTimeIsNull = false;
            }
             // determine if requestSchedule_schedule_Monthly_schedule_Monthly_StartTime should be set to null
            if (requestSchedule_schedule_Monthly_schedule_Monthly_StartTimeIsNull)
            {
                requestSchedule_schedule_Monthly_schedule_Monthly_StartTime = null;
            }
            if (requestSchedule_schedule_Monthly_schedule_Monthly_StartTime != null)
            {
                requestSchedule_schedule_Monthly.StartTime = requestSchedule_schedule_Monthly_schedule_Monthly_StartTime;
                requestSchedule_schedule_MonthlyIsNull = false;
            }
             // determine if requestSchedule_schedule_Monthly should be set to null
            if (requestSchedule_schedule_MonthlyIsNull)
            {
                requestSchedule_schedule_Monthly = null;
            }
            if (requestSchedule_schedule_Monthly != null)
            {
                request.Schedule.Monthly = requestSchedule_schedule_Monthly;
                requestScheduleIsNull = false;
            }
            Amazon.Inspector2.Model.WeeklySchedule requestSchedule_schedule_Weekly = null;
            
             // populate Weekly
            var requestSchedule_schedule_WeeklyIsNull = true;
            requestSchedule_schedule_Weekly = new Amazon.Inspector2.Model.WeeklySchedule();
            List<System.String> requestSchedule_schedule_Weekly_weekly_Day = null;
            if (cmdletContext.Weekly_Day != null)
            {
                requestSchedule_schedule_Weekly_weekly_Day = cmdletContext.Weekly_Day;
            }
            if (requestSchedule_schedule_Weekly_weekly_Day != null)
            {
                requestSchedule_schedule_Weekly.Days = requestSchedule_schedule_Weekly_weekly_Day;
                requestSchedule_schedule_WeeklyIsNull = false;
            }
            Amazon.Inspector2.Model.Time requestSchedule_schedule_Weekly_schedule_Weekly_StartTime = null;
            
             // populate StartTime
            var requestSchedule_schedule_Weekly_schedule_Weekly_StartTimeIsNull = true;
            requestSchedule_schedule_Weekly_schedule_Weekly_StartTime = new Amazon.Inspector2.Model.Time();
            System.String requestSchedule_schedule_Weekly_schedule_Weekly_StartTime_schedule_Weekly_StartTime_TimeOfDay = null;
            if (cmdletContext.Schedule_Weekly_StartTime_TimeOfDay != null)
            {
                requestSchedule_schedule_Weekly_schedule_Weekly_StartTime_schedule_Weekly_StartTime_TimeOfDay = cmdletContext.Schedule_Weekly_StartTime_TimeOfDay;
            }
            if (requestSchedule_schedule_Weekly_schedule_Weekly_StartTime_schedule_Weekly_StartTime_TimeOfDay != null)
            {
                requestSchedule_schedule_Weekly_schedule_Weekly_StartTime.TimeOfDay = requestSchedule_schedule_Weekly_schedule_Weekly_StartTime_schedule_Weekly_StartTime_TimeOfDay;
                requestSchedule_schedule_Weekly_schedule_Weekly_StartTimeIsNull = false;
            }
            System.String requestSchedule_schedule_Weekly_schedule_Weekly_StartTime_schedule_Weekly_StartTime_Timezone = null;
            if (cmdletContext.Schedule_Weekly_StartTime_Timezone != null)
            {
                requestSchedule_schedule_Weekly_schedule_Weekly_StartTime_schedule_Weekly_StartTime_Timezone = cmdletContext.Schedule_Weekly_StartTime_Timezone;
            }
            if (requestSchedule_schedule_Weekly_schedule_Weekly_StartTime_schedule_Weekly_StartTime_Timezone != null)
            {
                requestSchedule_schedule_Weekly_schedule_Weekly_StartTime.Timezone = requestSchedule_schedule_Weekly_schedule_Weekly_StartTime_schedule_Weekly_StartTime_Timezone;
                requestSchedule_schedule_Weekly_schedule_Weekly_StartTimeIsNull = false;
            }
             // determine if requestSchedule_schedule_Weekly_schedule_Weekly_StartTime should be set to null
            if (requestSchedule_schedule_Weekly_schedule_Weekly_StartTimeIsNull)
            {
                requestSchedule_schedule_Weekly_schedule_Weekly_StartTime = null;
            }
            if (requestSchedule_schedule_Weekly_schedule_Weekly_StartTime != null)
            {
                requestSchedule_schedule_Weekly.StartTime = requestSchedule_schedule_Weekly_schedule_Weekly_StartTime;
                requestSchedule_schedule_WeeklyIsNull = false;
            }
             // determine if requestSchedule_schedule_Weekly should be set to null
            if (requestSchedule_schedule_WeeklyIsNull)
            {
                requestSchedule_schedule_Weekly = null;
            }
            if (requestSchedule_schedule_Weekly != null)
            {
                request.Schedule.Weekly = requestSchedule_schedule_Weekly;
                requestScheduleIsNull = false;
            }
             // determine if request.Schedule should be set to null
            if (requestScheduleIsNull)
            {
                request.Schedule = null;
            }
            if (cmdletContext.SecurityLevel != null)
            {
                request.SecurityLevel = cmdletContext.SecurityLevel;
            }
            
             // populate Targets
            var requestTargetsIsNull = true;
            request.Targets = new Amazon.Inspector2.Model.UpdateCisTargets();
            List<System.String> requestTargets_targets_AccountId = null;
            if (cmdletContext.Targets_AccountId != null)
            {
                requestTargets_targets_AccountId = cmdletContext.Targets_AccountId;
            }
            if (requestTargets_targets_AccountId != null)
            {
                request.Targets.AccountIds = requestTargets_targets_AccountId;
                requestTargetsIsNull = false;
            }
            Dictionary<System.String, List<System.String>> requestTargets_targets_TargetResourceTag = null;
            if (cmdletContext.Targets_TargetResourceTag != null)
            {
                requestTargets_targets_TargetResourceTag = cmdletContext.Targets_TargetResourceTag;
            }
            if (requestTargets_targets_TargetResourceTag != null)
            {
                request.Targets.TargetResourceTags = requestTargets_targets_TargetResourceTag;
                requestTargetsIsNull = false;
            }
             // determine if request.Targets should be set to null
            if (requestTargetsIsNull)
            {
                request.Targets = null;
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
        
        private Amazon.Inspector2.Model.UpdateCisScanConfigurationResponse CallAWSServiceOperation(IAmazonInspector2 client, Amazon.Inspector2.Model.UpdateCisScanConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Inspector2", "UpdateCisScanConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateCisScanConfiguration(request);
                #elif CORECLR
                return client.UpdateCisScanConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String ScanConfigurationArn { get; set; }
            public System.String ScanName { get; set; }
            public System.String Schedule_Daily_StartTime_TimeOfDay { get; set; }
            public System.String Schedule_Daily_StartTime_Timezone { get; set; }
            public Amazon.Inspector2.Day Monthly_Day { get; set; }
            public System.String Schedule_Monthly_StartTime_TimeOfDay { get; set; }
            public System.String Schedule_Monthly_StartTime_Timezone { get; set; }
            public Amazon.Inspector2.Model.OneTimeSchedule Schedule_OneTime { get; set; }
            public List<System.String> Weekly_Day { get; set; }
            public System.String Schedule_Weekly_StartTime_TimeOfDay { get; set; }
            public System.String Schedule_Weekly_StartTime_Timezone { get; set; }
            public Amazon.Inspector2.CisSecurityLevel SecurityLevel { get; set; }
            public List<System.String> Targets_AccountId { get; set; }
            public Dictionary<System.String, List<System.String>> Targets_TargetResourceTag { get; set; }
            public System.Func<Amazon.Inspector2.Model.UpdateCisScanConfigurationResponse, UpdateINS2CisScanConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ScanConfigurationArn;
        }
        
    }
}
