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
using Amazon.Connect;
using Amazon.Connect.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Update the hours of operation override.
    /// </summary>
    [Cmdlet("Update", "CONNHoursOfOperationOverride", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Connect Service UpdateHoursOfOperationOverride API operation.", Operation = new[] {"UpdateHoursOfOperationOverride"}, SelectReturnType = typeof(Amazon.Connect.Model.UpdateHoursOfOperationOverrideResponse))]
    [AWSCmdletOutput("None or Amazon.Connect.Model.UpdateHoursOfOperationOverrideResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Connect.Model.UpdateHoursOfOperationOverrideResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateCONNHoursOfOperationOverrideCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter RecurrenceConfig_RecurrencePattern_ByMonth
        /// <summary>
        /// <para>
        /// <para>Specifies which month the event should occur in (1-12, where 1=January, 12=December).
        /// Used with YEARLY frequency to schedule events in specific month. </para><para>Note: It does not accept multiple values in the same list</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32[] RecurrenceConfig_RecurrencePattern_ByMonth { get; set; }
        #endregion
        
        #region Parameter RecurrenceConfig_RecurrencePattern_ByMonthDay
        /// <summary>
        /// <para>
        /// <para>Specifies which day of the month the event should occur on (1-31). Used with MONTHLY
        /// or YEARLY frequency to schedule events on specific date within a month.</para><para> Examples: [15] for events on the 15th of each month, [-1] for events on the last
        /// day of month. </para><para>Note: It does not accept multiple values in the same list. If a specified day doesn't
        /// exist in a particular month (e.g., day 31 in February), the event will be skipped
        /// for that month. This field cannot be used simultaneously with ByWeekdayOccurrence
        /// as they represent different scheduling approaches (specific dates vs. relative weekday
        /// positions).</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32[] RecurrenceConfig_RecurrencePattern_ByMonthDay { get; set; }
        #endregion
        
        #region Parameter RecurrenceConfig_RecurrencePattern_ByWeekdayOccurrence
        /// <summary>
        /// <para>
        /// <para>Specifies which occurrence of a weekday within the month the event should occur on.
        /// Must be used with MONTHLY or YEARLY frequency. </para><para>Example: 2 corresponds to second occurrence of the weekday in the month. -1 corresponds
        /// to last occurrence of the weekday in the month </para><para>The weekday itself is specified separately in the HoursOfOperationConfig. Example:
        /// To schedule the recurring event for the 2nd Thursday of April every year, set ByWeekdayOccurrence=[2],
        /// Day=THURSDAY, ByMonth=[4], Frequency: YEARLY and INTERVAL=1.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32[] RecurrenceConfig_RecurrencePattern_ByWeekdayOccurrence { get; set; }
        #endregion
        
        #region Parameter Config
        /// <summary>
        /// <para>
        /// <para>Configuration information for the hours of operation override: day, start time, and
        /// end time.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Connect.Model.HoursOfOperationOverrideConfig[] Config { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the hours of operation override.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EffectiveFrom
        /// <summary>
        /// <para>
        /// <para>The date from when the hours of operation override would be effective.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EffectiveFrom { get; set; }
        #endregion
        
        #region Parameter EffectiveTill
        /// <summary>
        /// <para>
        /// <para>The date until the hours of operation override is effective.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EffectiveTill { get; set; }
        #endregion
        
        #region Parameter RecurrenceConfig_RecurrencePattern_Frequency
        /// <summary>
        /// <para>
        /// <para>Defines how often the pattern repeats. This is the base unit for the recurrence schedule
        /// and works in conjunction with the Interval field to determine the exact repetition
        /// sequence.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Connect.RecurrenceFrequency")]
        public Amazon.Connect.RecurrenceFrequency RecurrenceConfig_RecurrencePattern_Frequency { get; set; }
        #endregion
        
        #region Parameter HoursOfOperationId
        /// <summary>
        /// <para>
        /// <para>The identifier for the hours of operation.</para>
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
        public System.String HoursOfOperationId { get; set; }
        #endregion
        
        #region Parameter HoursOfOperationOverrideId
        /// <summary>
        /// <para>
        /// <para>The identifier for the hours of operation override.</para>
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
        public System.String HoursOfOperationOverrideId { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter RecurrenceConfig_RecurrencePattern_Interval
        /// <summary>
        /// <para>
        /// <para>Specifies the number of frequency units between each occurrence. Must be a positive
        /// integer. </para><para> Examples: To repeat every week, set Interval=1 with WEEKLY frequency. To repeat every
        /// two months, set Interval=2 with MONTHLY frequency.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? RecurrenceConfig_RecurrencePattern_Interval { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the hours of operation override.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter OverrideType
        /// <summary>
        /// <para>
        /// <para>Whether the override will be defined as a <i>standard</i> or as a <i>recurring event</i>.</para><para>For more information about how override types are applied, see <a href="https://docs.aws.amazon.com/https:/docs.aws.amazon.com/connect/latest/adminguide/hours-of-operation-overrides.html">Build
        /// your list of overrides</a> in the <i> Administrator Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Connect.OverrideType")]
        public Amazon.Connect.OverrideType OverrideType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.UpdateHoursOfOperationOverrideResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.HoursOfOperationOverrideId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CONNHoursOfOperationOverride (UpdateHoursOfOperationOverride)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.UpdateHoursOfOperationOverrideResponse, UpdateCONNHoursOfOperationOverrideCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Config != null)
            {
                context.Config = new List<Amazon.Connect.Model.HoursOfOperationOverrideConfig>(this.Config);
            }
            context.Description = this.Description;
            context.EffectiveFrom = this.EffectiveFrom;
            context.EffectiveTill = this.EffectiveTill;
            context.HoursOfOperationId = this.HoursOfOperationId;
            #if MODULAR
            if (this.HoursOfOperationId == null && ParameterWasBound(nameof(this.HoursOfOperationId)))
            {
                WriteWarning("You are passing $null as a value for parameter HoursOfOperationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HoursOfOperationOverrideId = this.HoursOfOperationOverrideId;
            #if MODULAR
            if (this.HoursOfOperationOverrideId == null && ParameterWasBound(nameof(this.HoursOfOperationOverrideId)))
            {
                WriteWarning("You are passing $null as a value for parameter HoursOfOperationOverrideId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            context.OverrideType = this.OverrideType;
            if (this.RecurrenceConfig_RecurrencePattern_ByMonth != null)
            {
                context.RecurrenceConfig_RecurrencePattern_ByMonth = new List<System.Int32>(this.RecurrenceConfig_RecurrencePattern_ByMonth);
            }
            if (this.RecurrenceConfig_RecurrencePattern_ByMonthDay != null)
            {
                context.RecurrenceConfig_RecurrencePattern_ByMonthDay = new List<System.Int32>(this.RecurrenceConfig_RecurrencePattern_ByMonthDay);
            }
            if (this.RecurrenceConfig_RecurrencePattern_ByWeekdayOccurrence != null)
            {
                context.RecurrenceConfig_RecurrencePattern_ByWeekdayOccurrence = new List<System.Int32>(this.RecurrenceConfig_RecurrencePattern_ByWeekdayOccurrence);
            }
            context.RecurrenceConfig_RecurrencePattern_Frequency = this.RecurrenceConfig_RecurrencePattern_Frequency;
            context.RecurrenceConfig_RecurrencePattern_Interval = this.RecurrenceConfig_RecurrencePattern_Interval;
            
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
            var request = new Amazon.Connect.Model.UpdateHoursOfOperationOverrideRequest();
            
            if (cmdletContext.Config != null)
            {
                request.Config = cmdletContext.Config;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EffectiveFrom != null)
            {
                request.EffectiveFrom = cmdletContext.EffectiveFrom;
            }
            if (cmdletContext.EffectiveTill != null)
            {
                request.EffectiveTill = cmdletContext.EffectiveTill;
            }
            if (cmdletContext.HoursOfOperationId != null)
            {
                request.HoursOfOperationId = cmdletContext.HoursOfOperationId;
            }
            if (cmdletContext.HoursOfOperationOverrideId != null)
            {
                request.HoursOfOperationOverrideId = cmdletContext.HoursOfOperationOverrideId;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.OverrideType != null)
            {
                request.OverrideType = cmdletContext.OverrideType;
            }
            
             // populate RecurrenceConfig
            var requestRecurrenceConfigIsNull = true;
            request.RecurrenceConfig = new Amazon.Connect.Model.RecurrenceConfig();
            Amazon.Connect.Model.RecurrencePattern requestRecurrenceConfig_recurrenceConfig_RecurrencePattern = null;
            
             // populate RecurrencePattern
            var requestRecurrenceConfig_recurrenceConfig_RecurrencePatternIsNull = true;
            requestRecurrenceConfig_recurrenceConfig_RecurrencePattern = new Amazon.Connect.Model.RecurrencePattern();
            List<System.Int32> requestRecurrenceConfig_recurrenceConfig_RecurrencePattern_recurrenceConfig_RecurrencePattern_ByMonth = null;
            if (cmdletContext.RecurrenceConfig_RecurrencePattern_ByMonth != null)
            {
                requestRecurrenceConfig_recurrenceConfig_RecurrencePattern_recurrenceConfig_RecurrencePattern_ByMonth = cmdletContext.RecurrenceConfig_RecurrencePattern_ByMonth;
            }
            if (requestRecurrenceConfig_recurrenceConfig_RecurrencePattern_recurrenceConfig_RecurrencePattern_ByMonth != null)
            {
                requestRecurrenceConfig_recurrenceConfig_RecurrencePattern.ByMonth = requestRecurrenceConfig_recurrenceConfig_RecurrencePattern_recurrenceConfig_RecurrencePattern_ByMonth;
                requestRecurrenceConfig_recurrenceConfig_RecurrencePatternIsNull = false;
            }
            List<System.Int32> requestRecurrenceConfig_recurrenceConfig_RecurrencePattern_recurrenceConfig_RecurrencePattern_ByMonthDay = null;
            if (cmdletContext.RecurrenceConfig_RecurrencePattern_ByMonthDay != null)
            {
                requestRecurrenceConfig_recurrenceConfig_RecurrencePattern_recurrenceConfig_RecurrencePattern_ByMonthDay = cmdletContext.RecurrenceConfig_RecurrencePattern_ByMonthDay;
            }
            if (requestRecurrenceConfig_recurrenceConfig_RecurrencePattern_recurrenceConfig_RecurrencePattern_ByMonthDay != null)
            {
                requestRecurrenceConfig_recurrenceConfig_RecurrencePattern.ByMonthDay = requestRecurrenceConfig_recurrenceConfig_RecurrencePattern_recurrenceConfig_RecurrencePattern_ByMonthDay;
                requestRecurrenceConfig_recurrenceConfig_RecurrencePatternIsNull = false;
            }
            List<System.Int32> requestRecurrenceConfig_recurrenceConfig_RecurrencePattern_recurrenceConfig_RecurrencePattern_ByWeekdayOccurrence = null;
            if (cmdletContext.RecurrenceConfig_RecurrencePattern_ByWeekdayOccurrence != null)
            {
                requestRecurrenceConfig_recurrenceConfig_RecurrencePattern_recurrenceConfig_RecurrencePattern_ByWeekdayOccurrence = cmdletContext.RecurrenceConfig_RecurrencePattern_ByWeekdayOccurrence;
            }
            if (requestRecurrenceConfig_recurrenceConfig_RecurrencePattern_recurrenceConfig_RecurrencePattern_ByWeekdayOccurrence != null)
            {
                requestRecurrenceConfig_recurrenceConfig_RecurrencePattern.ByWeekdayOccurrence = requestRecurrenceConfig_recurrenceConfig_RecurrencePattern_recurrenceConfig_RecurrencePattern_ByWeekdayOccurrence;
                requestRecurrenceConfig_recurrenceConfig_RecurrencePatternIsNull = false;
            }
            Amazon.Connect.RecurrenceFrequency requestRecurrenceConfig_recurrenceConfig_RecurrencePattern_recurrenceConfig_RecurrencePattern_Frequency = null;
            if (cmdletContext.RecurrenceConfig_RecurrencePattern_Frequency != null)
            {
                requestRecurrenceConfig_recurrenceConfig_RecurrencePattern_recurrenceConfig_RecurrencePattern_Frequency = cmdletContext.RecurrenceConfig_RecurrencePattern_Frequency;
            }
            if (requestRecurrenceConfig_recurrenceConfig_RecurrencePattern_recurrenceConfig_RecurrencePattern_Frequency != null)
            {
                requestRecurrenceConfig_recurrenceConfig_RecurrencePattern.Frequency = requestRecurrenceConfig_recurrenceConfig_RecurrencePattern_recurrenceConfig_RecurrencePattern_Frequency;
                requestRecurrenceConfig_recurrenceConfig_RecurrencePatternIsNull = false;
            }
            System.Int32? requestRecurrenceConfig_recurrenceConfig_RecurrencePattern_recurrenceConfig_RecurrencePattern_Interval = null;
            if (cmdletContext.RecurrenceConfig_RecurrencePattern_Interval != null)
            {
                requestRecurrenceConfig_recurrenceConfig_RecurrencePattern_recurrenceConfig_RecurrencePattern_Interval = cmdletContext.RecurrenceConfig_RecurrencePattern_Interval.Value;
            }
            if (requestRecurrenceConfig_recurrenceConfig_RecurrencePattern_recurrenceConfig_RecurrencePattern_Interval != null)
            {
                requestRecurrenceConfig_recurrenceConfig_RecurrencePattern.Interval = requestRecurrenceConfig_recurrenceConfig_RecurrencePattern_recurrenceConfig_RecurrencePattern_Interval.Value;
                requestRecurrenceConfig_recurrenceConfig_RecurrencePatternIsNull = false;
            }
             // determine if requestRecurrenceConfig_recurrenceConfig_RecurrencePattern should be set to null
            if (requestRecurrenceConfig_recurrenceConfig_RecurrencePatternIsNull)
            {
                requestRecurrenceConfig_recurrenceConfig_RecurrencePattern = null;
            }
            if (requestRecurrenceConfig_recurrenceConfig_RecurrencePattern != null)
            {
                request.RecurrenceConfig.RecurrencePattern = requestRecurrenceConfig_recurrenceConfig_RecurrencePattern;
                requestRecurrenceConfigIsNull = false;
            }
             // determine if request.RecurrenceConfig should be set to null
            if (requestRecurrenceConfigIsNull)
            {
                request.RecurrenceConfig = null;
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
        
        private Amazon.Connect.Model.UpdateHoursOfOperationOverrideResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.UpdateHoursOfOperationOverrideRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "UpdateHoursOfOperationOverride");
            try
            {
                return client.UpdateHoursOfOperationOverrideAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.Connect.Model.HoursOfOperationOverrideConfig> Config { get; set; }
            public System.String Description { get; set; }
            public System.String EffectiveFrom { get; set; }
            public System.String EffectiveTill { get; set; }
            public System.String HoursOfOperationId { get; set; }
            public System.String HoursOfOperationOverrideId { get; set; }
            public System.String InstanceId { get; set; }
            public System.String Name { get; set; }
            public Amazon.Connect.OverrideType OverrideType { get; set; }
            public List<System.Int32> RecurrenceConfig_RecurrencePattern_ByMonth { get; set; }
            public List<System.Int32> RecurrenceConfig_RecurrencePattern_ByMonthDay { get; set; }
            public List<System.Int32> RecurrenceConfig_RecurrencePattern_ByWeekdayOccurrence { get; set; }
            public Amazon.Connect.RecurrenceFrequency RecurrenceConfig_RecurrencePattern_Frequency { get; set; }
            public System.Int32? RecurrenceConfig_RecurrencePattern_Interval { get; set; }
            public System.Func<Amazon.Connect.Model.UpdateHoursOfOperationOverrideResponse, UpdateCONNHoursOfOperationOverrideCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
