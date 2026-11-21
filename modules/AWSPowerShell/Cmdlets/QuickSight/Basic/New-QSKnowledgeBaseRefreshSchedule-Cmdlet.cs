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
    /// Creates a schedule that periodically refreshes an Amazon Quick Sight knowledge base
    /// at the frequency that you specify.
    /// 
    ///  
    /// <para>
    /// A knowledge base can have only one refresh schedule. If the knowledge base already
    /// has a refresh schedule, the request fails with a <c>LimitExceededException</c>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "QSKnowledgeBaseRefreshSchedule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QuickSight.Model.CreateKnowledgeBaseRefreshScheduleResponse")]
    [AWSCmdlet("Calls the Amazon QuickSight CreateKnowledgeBaseRefreshSchedule API operation.", Operation = new[] {"CreateKnowledgeBaseRefreshSchedule"}, SelectReturnType = typeof(Amazon.QuickSight.Model.CreateKnowledgeBaseRefreshScheduleResponse))]
    [AWSCmdletOutput("Amazon.QuickSight.Model.CreateKnowledgeBaseRefreshScheduleResponse",
        "This cmdlet returns an Amazon.QuickSight.Model.CreateKnowledgeBaseRefreshScheduleResponse object containing multiple properties."
    )]
    public partial class NewQSKnowledgeBaseRefreshScheduleCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services account that contains the knowledge base.</para>
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
        
        #region Parameter ScheduleFrequency_RefreshOnDay_DayOfMonth
        /// <summary>
        /// <para>
        /// <para>The day of the month on which a monthly refresh runs. Valid values include:</para><ul><li><para><c>1</c> through <c>28</c> – The refresh runs on that day of each month.</para></li><li><para><c>LAST_DAY_OF_MONTH</c> – The refresh runs on the last day of each month.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ScheduleFrequency_RefreshOnDay_DayOfMonth { get; set; }
        #endregion
        
        #region Parameter ScheduleFrequency_RefreshOnDay_DayOfWeek
        /// <summary>
        /// <para>
        /// <para>The day of the week on which a weekly refresh runs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.KbDayOfWeek")]
        public Amazon.QuickSight.KbDayOfWeek ScheduleFrequency_RefreshOnDay_DayOfWeek { get; set; }
        #endregion
        
        #region Parameter ScheduleFrequency_Interval
        /// <summary>
        /// <para>
        /// <para>The interval at which the schedule refreshes the knowledge base. Valid values include:</para><ul><li><para><c>DAILY</c> – The schedule refreshes the knowledge base once each day.</para></li><li><para><c>WEEKLY</c> – The schedule refreshes the knowledge base once each week, on the
        /// day that you specify in <c>RefreshOnDay.DayOfWeek</c>.</para></li><li><para><c>MONTHLY</c> – The schedule refreshes the knowledge base once each month, on the
        /// day that you specify in <c>RefreshOnDay.DayOfMonth</c>.</para></li><li><para><c>HOURLY</c> – The schedule refreshes the knowledge base once each hour. Available
        /// only if your account is enabled for hourly refresh. Otherwise, the request fails with
        /// an <c>InvalidParameterValueException</c>.</para></li></ul><para>For <c>DAILY</c>, <c>WEEKLY</c>, and <c>MONTHLY</c> intervals, the service chooses
        /// the time of day at which the refresh runs. You can't specify the time of day.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.QuickSight.KbRefreshInterval")]
        public Amazon.QuickSight.KbRefreshInterval ScheduleFrequency_Interval { get; set; }
        #endregion
        
        #region Parameter KnowledgeBaseId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the knowledge base.</para>
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
        public System.String KnowledgeBaseId { get; set; }
        #endregion
        
        #region Parameter ScheduleId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the knowledge base refresh schedule.</para>
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
        public System.String ScheduleId { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The date and time, in ISO 8601 format, after which the schedule can start refreshing
        /// the knowledge base. The first refresh runs at the next scheduled time after this date
        /// and time. If you don't specify a value, the schedule becomes active immediately, and
        /// the first refresh runs at the next scheduled time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartTime { get; set; }
        #endregion
        
        #region Parameter State
        /// <summary>
        /// <para>
        /// <para>The state that you want the refresh schedule to have when you create it. If you don't
        /// specify a state, the schedule is created in the <c>ENABLED</c> state. A schedule that
        /// isn't <c>ENABLED</c> doesn't run refreshes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.ScheduleState")]
        public Amazon.QuickSight.ScheduleState State { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.CreateKnowledgeBaseRefreshScheduleResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.CreateKnowledgeBaseRefreshScheduleResponse will result in that property being returned.
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.AwsAccountId),
                nameof(this.KnowledgeBaseId),
                nameof(this.ScheduleId)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-QSKnowledgeBaseRefreshSchedule (CreateKnowledgeBaseRefreshSchedule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.CreateKnowledgeBaseRefreshScheduleResponse, NewQSKnowledgeBaseRefreshScheduleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KnowledgeBaseId = this.KnowledgeBaseId;
            #if MODULAR
            if (this.KnowledgeBaseId == null && ParameterWasBound(nameof(this.KnowledgeBaseId)))
            {
                WriteWarning("You are passing $null as a value for parameter KnowledgeBaseId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScheduleFrequency_Interval = this.ScheduleFrequency_Interval;
            #if MODULAR
            if (this.ScheduleFrequency_Interval == null && ParameterWasBound(nameof(this.ScheduleFrequency_Interval)))
            {
                WriteWarning("You are passing $null as a value for parameter ScheduleFrequency_Interval which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScheduleFrequency_RefreshOnDay_DayOfMonth = this.ScheduleFrequency_RefreshOnDay_DayOfMonth;
            context.ScheduleFrequency_RefreshOnDay_DayOfWeek = this.ScheduleFrequency_RefreshOnDay_DayOfWeek;
            context.ScheduleId = this.ScheduleId;
            #if MODULAR
            if (this.ScheduleId == null && ParameterWasBound(nameof(this.ScheduleId)))
            {
                WriteWarning("You are passing $null as a value for parameter ScheduleId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StartTime = this.StartTime;
            context.State = this.State;
            
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
            var request = new Amazon.QuickSight.Model.CreateKnowledgeBaseRefreshScheduleRequest();
            
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            if (cmdletContext.KnowledgeBaseId != null)
            {
                request.KnowledgeBaseId = cmdletContext.KnowledgeBaseId;
            }
            
             // populate ScheduleFrequency
            var requestScheduleFrequencyIsNull = true;
            request.ScheduleFrequency = new Amazon.QuickSight.Model.KnowledgeBaseRefreshFrequency();
            Amazon.QuickSight.KbRefreshInterval requestScheduleFrequency_scheduleFrequency_Interval = null;
            if (cmdletContext.ScheduleFrequency_Interval != null)
            {
                requestScheduleFrequency_scheduleFrequency_Interval = cmdletContext.ScheduleFrequency_Interval;
            }
            if (requestScheduleFrequency_scheduleFrequency_Interval != null)
            {
                request.ScheduleFrequency.Interval = requestScheduleFrequency_scheduleFrequency_Interval;
                requestScheduleFrequencyIsNull = false;
            }
            Amazon.QuickSight.Model.KnowledgeBaseScheduleRefreshOnEntity requestScheduleFrequency_scheduleFrequency_RefreshOnDay = null;
            
             // populate RefreshOnDay
            var requestScheduleFrequency_scheduleFrequency_RefreshOnDayIsNull = true;
            requestScheduleFrequency_scheduleFrequency_RefreshOnDay = new Amazon.QuickSight.Model.KnowledgeBaseScheduleRefreshOnEntity();
            System.String requestScheduleFrequency_scheduleFrequency_RefreshOnDay_scheduleFrequency_RefreshOnDay_DayOfMonth = null;
            if (cmdletContext.ScheduleFrequency_RefreshOnDay_DayOfMonth != null)
            {
                requestScheduleFrequency_scheduleFrequency_RefreshOnDay_scheduleFrequency_RefreshOnDay_DayOfMonth = cmdletContext.ScheduleFrequency_RefreshOnDay_DayOfMonth;
            }
            if (requestScheduleFrequency_scheduleFrequency_RefreshOnDay_scheduleFrequency_RefreshOnDay_DayOfMonth != null)
            {
                requestScheduleFrequency_scheduleFrequency_RefreshOnDay.DayOfMonth = requestScheduleFrequency_scheduleFrequency_RefreshOnDay_scheduleFrequency_RefreshOnDay_DayOfMonth;
                requestScheduleFrequency_scheduleFrequency_RefreshOnDayIsNull = false;
            }
            Amazon.QuickSight.KbDayOfWeek requestScheduleFrequency_scheduleFrequency_RefreshOnDay_scheduleFrequency_RefreshOnDay_DayOfWeek = null;
            if (cmdletContext.ScheduleFrequency_RefreshOnDay_DayOfWeek != null)
            {
                requestScheduleFrequency_scheduleFrequency_RefreshOnDay_scheduleFrequency_RefreshOnDay_DayOfWeek = cmdletContext.ScheduleFrequency_RefreshOnDay_DayOfWeek;
            }
            if (requestScheduleFrequency_scheduleFrequency_RefreshOnDay_scheduleFrequency_RefreshOnDay_DayOfWeek != null)
            {
                requestScheduleFrequency_scheduleFrequency_RefreshOnDay.DayOfWeek = requestScheduleFrequency_scheduleFrequency_RefreshOnDay_scheduleFrequency_RefreshOnDay_DayOfWeek;
                requestScheduleFrequency_scheduleFrequency_RefreshOnDayIsNull = false;
            }
             // determine if requestScheduleFrequency_scheduleFrequency_RefreshOnDay should be set to null
            if (requestScheduleFrequency_scheduleFrequency_RefreshOnDayIsNull)
            {
                requestScheduleFrequency_scheduleFrequency_RefreshOnDay = null;
            }
            if (requestScheduleFrequency_scheduleFrequency_RefreshOnDay != null)
            {
                request.ScheduleFrequency.RefreshOnDay = requestScheduleFrequency_scheduleFrequency_RefreshOnDay;
                requestScheduleFrequencyIsNull = false;
            }
             // determine if request.ScheduleFrequency should be set to null
            if (requestScheduleFrequencyIsNull)
            {
                request.ScheduleFrequency = null;
            }
            if (cmdletContext.ScheduleId != null)
            {
                request.ScheduleId = cmdletContext.ScheduleId;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
            }
            if (cmdletContext.State != null)
            {
                request.State = cmdletContext.State;
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
        
        private Amazon.QuickSight.Model.CreateKnowledgeBaseRefreshScheduleResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.CreateKnowledgeBaseRefreshScheduleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "CreateKnowledgeBaseRefreshSchedule");
            try
            {
                return client.CreateKnowledgeBaseRefreshScheduleAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String KnowledgeBaseId { get; set; }
            public Amazon.QuickSight.KbRefreshInterval ScheduleFrequency_Interval { get; set; }
            public System.String ScheduleFrequency_RefreshOnDay_DayOfMonth { get; set; }
            public Amazon.QuickSight.KbDayOfWeek ScheduleFrequency_RefreshOnDay_DayOfWeek { get; set; }
            public System.String ScheduleId { get; set; }
            public System.DateTime? StartTime { get; set; }
            public Amazon.QuickSight.ScheduleState State { get; set; }
            public System.Func<Amazon.QuickSight.Model.CreateKnowledgeBaseRefreshScheduleResponse, NewQSKnowledgeBaseRefreshScheduleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
