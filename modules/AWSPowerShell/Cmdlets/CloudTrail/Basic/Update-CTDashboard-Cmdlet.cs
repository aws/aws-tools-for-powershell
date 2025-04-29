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
using Amazon.CloudTrail;
using Amazon.CloudTrail.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CT
{
    /// <summary>
    /// Updates the specified dashboard. 
    /// 
    ///  
    /// <para>
    ///  To set a refresh schedule, CloudTrail must be granted permissions to run the <c>StartDashboardRefresh</c>
    /// operation to refresh the dashboard on your behalf. To provide permissions, run the
    /// <c>PutResourcePolicy</c> operation to attach a resource-based policy to the dashboard.
    /// For more information, see <a href="https://docs.aws.amazon.com/awscloudtrail/latest/userguide/security_iam_resource-based-policy-examples.html#security_iam_resource-based-policy-examples-dashboards">
    /// Resource-based policy example for a dashboard</a> in the <i>CloudTrail User Guide</i>.
    /// 
    /// </para><para>
    ///  CloudTrail runs queries to populate the dashboard's widgets during a manual or scheduled
    /// refresh. CloudTrail must be granted permissions to run the <c>StartQuery</c> operation
    /// on your behalf. To provide permissions, run the <c>PutResourcePolicy</c> operation
    /// to attach a resource-based policy to each event data store. For more information,
    /// see <a href="https://docs.aws.amazon.com/awscloudtrail/latest/userguide/security_iam_resource-based-policy-examples.html#security_iam_resource-based-policy-examples-eds-dashboard">Example:
    /// Allow CloudTrail to run queries to populate a dashboard</a> in the <i>CloudTrail User
    /// Guide</i>. 
    /// </para>
    /// </summary>
    [Cmdlet("Update", "CTDashboard", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudTrail.Model.UpdateDashboardResponse")]
    [AWSCmdlet("Calls the AWS CloudTrail UpdateDashboard API operation.", Operation = new[] {"UpdateDashboard"}, SelectReturnType = typeof(Amazon.CloudTrail.Model.UpdateDashboardResponse))]
    [AWSCmdletOutput("Amazon.CloudTrail.Model.UpdateDashboardResponse",
        "This cmdlet returns an Amazon.CloudTrail.Model.UpdateDashboardResponse object containing multiple properties."
    )]
    public partial class UpdateCTDashboardCmdlet : AmazonCloudTrailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DashboardId
        /// <summary>
        /// <para>
        /// <para> The name or ARN of the dashboard. </para>
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
        public System.String DashboardId { get; set; }
        #endregion
        
        #region Parameter RefreshSchedule_Status
        /// <summary>
        /// <para>
        /// <para> Specifies whether the refresh schedule is enabled. Set the value to <c>ENABLED</c>
        /// to enable the refresh schedule, or to <c>DISABLED</c> to turn off the refresh schedule.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudTrail.RefreshScheduleStatus")]
        public Amazon.CloudTrail.RefreshScheduleStatus RefreshSchedule_Status { get; set; }
        #endregion
        
        #region Parameter TerminationProtectionEnabled
        /// <summary>
        /// <para>
        /// <para> Specifies whether termination protection is enabled for the dashboard. If termination
        /// protection is enabled, you cannot delete the dashboard until termination protection
        /// is disabled. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? TerminationProtectionEnabled { get; set; }
        #endregion
        
        #region Parameter RefreshSchedule_TimeOfDay
        /// <summary>
        /// <para>
        /// <para> The time of day in UTC to run the schedule; for hourly only refer to minutes; default
        /// is 00:00. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RefreshSchedule_TimeOfDay { get; set; }
        #endregion
        
        #region Parameter Frequency_Unit
        /// <summary>
        /// <para>
        /// <para> The unit to use for the refresh. </para><para>For custom dashboards, the unit can be <c>HOURS</c> or <c>DAYS</c>.</para><para>For the Highlights dashboard, the <c>Unit</c> must be <c>HOURS</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RefreshSchedule_Frequency_Unit")]
        [AWSConstantClassSource("Amazon.CloudTrail.RefreshScheduleFrequencyUnit")]
        public Amazon.CloudTrail.RefreshScheduleFrequencyUnit Frequency_Unit { get; set; }
        #endregion
        
        #region Parameter Frequency_Value
        /// <summary>
        /// <para>
        /// <para> The value for the refresh schedule. </para><para> For custom dashboards, the following values are valid when the unit is <c>HOURS</c>:
        /// <c>1</c>, <c>6</c>, <c>12</c>, <c>24</c></para><para>For custom dashboards, the only valid value when the unit is <c>DAYS</c> is <c>1</c>.</para><para>For the Highlights dashboard, the <c>Value</c> must be <c>6</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RefreshSchedule_Frequency_Value")]
        public System.Int32? Frequency_Value { get; set; }
        #endregion
        
        #region Parameter Widget
        /// <summary>
        /// <para>
        /// <para> An array of widgets for the dashboard. A custom dashboard can have a maximum of 10
        /// widgets. </para><para>To add new widgets, pass in an array that includes the existing widgets along with
        /// any new widgets. Run the <c>GetDashboard</c> operation to get the list of widgets
        /// for the dashboard.</para><para>To remove widgets, pass in an array that includes the existing widgets minus the widgets
        /// you want removed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Widgets")]
        public Amazon.CloudTrail.Model.RequestWidget[] Widget { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudTrail.Model.UpdateDashboardResponse).
        /// Specifying the name of a property of type Amazon.CloudTrail.Model.UpdateDashboardResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DashboardId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CTDashboard (UpdateDashboard)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudTrail.Model.UpdateDashboardResponse, UpdateCTDashboardCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DashboardId = this.DashboardId;
            #if MODULAR
            if (this.DashboardId == null && ParameterWasBound(nameof(this.DashboardId)))
            {
                WriteWarning("You are passing $null as a value for parameter DashboardId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Frequency_Unit = this.Frequency_Unit;
            context.Frequency_Value = this.Frequency_Value;
            context.RefreshSchedule_Status = this.RefreshSchedule_Status;
            context.RefreshSchedule_TimeOfDay = this.RefreshSchedule_TimeOfDay;
            context.TerminationProtectionEnabled = this.TerminationProtectionEnabled;
            if (this.Widget != null)
            {
                context.Widget = new List<Amazon.CloudTrail.Model.RequestWidget>(this.Widget);
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
            var request = new Amazon.CloudTrail.Model.UpdateDashboardRequest();
            
            if (cmdletContext.DashboardId != null)
            {
                request.DashboardId = cmdletContext.DashboardId;
            }
            
             // populate RefreshSchedule
            var requestRefreshScheduleIsNull = true;
            request.RefreshSchedule = new Amazon.CloudTrail.Model.RefreshSchedule();
            Amazon.CloudTrail.RefreshScheduleStatus requestRefreshSchedule_refreshSchedule_Status = null;
            if (cmdletContext.RefreshSchedule_Status != null)
            {
                requestRefreshSchedule_refreshSchedule_Status = cmdletContext.RefreshSchedule_Status;
            }
            if (requestRefreshSchedule_refreshSchedule_Status != null)
            {
                request.RefreshSchedule.Status = requestRefreshSchedule_refreshSchedule_Status;
                requestRefreshScheduleIsNull = false;
            }
            System.String requestRefreshSchedule_refreshSchedule_TimeOfDay = null;
            if (cmdletContext.RefreshSchedule_TimeOfDay != null)
            {
                requestRefreshSchedule_refreshSchedule_TimeOfDay = cmdletContext.RefreshSchedule_TimeOfDay;
            }
            if (requestRefreshSchedule_refreshSchedule_TimeOfDay != null)
            {
                request.RefreshSchedule.TimeOfDay = requestRefreshSchedule_refreshSchedule_TimeOfDay;
                requestRefreshScheduleIsNull = false;
            }
            Amazon.CloudTrail.Model.RefreshScheduleFrequency requestRefreshSchedule_refreshSchedule_Frequency = null;
            
             // populate Frequency
            var requestRefreshSchedule_refreshSchedule_FrequencyIsNull = true;
            requestRefreshSchedule_refreshSchedule_Frequency = new Amazon.CloudTrail.Model.RefreshScheduleFrequency();
            Amazon.CloudTrail.RefreshScheduleFrequencyUnit requestRefreshSchedule_refreshSchedule_Frequency_frequency_Unit = null;
            if (cmdletContext.Frequency_Unit != null)
            {
                requestRefreshSchedule_refreshSchedule_Frequency_frequency_Unit = cmdletContext.Frequency_Unit;
            }
            if (requestRefreshSchedule_refreshSchedule_Frequency_frequency_Unit != null)
            {
                requestRefreshSchedule_refreshSchedule_Frequency.Unit = requestRefreshSchedule_refreshSchedule_Frequency_frequency_Unit;
                requestRefreshSchedule_refreshSchedule_FrequencyIsNull = false;
            }
            System.Int32? requestRefreshSchedule_refreshSchedule_Frequency_frequency_Value = null;
            if (cmdletContext.Frequency_Value != null)
            {
                requestRefreshSchedule_refreshSchedule_Frequency_frequency_Value = cmdletContext.Frequency_Value.Value;
            }
            if (requestRefreshSchedule_refreshSchedule_Frequency_frequency_Value != null)
            {
                requestRefreshSchedule_refreshSchedule_Frequency.Value = requestRefreshSchedule_refreshSchedule_Frequency_frequency_Value.Value;
                requestRefreshSchedule_refreshSchedule_FrequencyIsNull = false;
            }
             // determine if requestRefreshSchedule_refreshSchedule_Frequency should be set to null
            if (requestRefreshSchedule_refreshSchedule_FrequencyIsNull)
            {
                requestRefreshSchedule_refreshSchedule_Frequency = null;
            }
            if (requestRefreshSchedule_refreshSchedule_Frequency != null)
            {
                request.RefreshSchedule.Frequency = requestRefreshSchedule_refreshSchedule_Frequency;
                requestRefreshScheduleIsNull = false;
            }
             // determine if request.RefreshSchedule should be set to null
            if (requestRefreshScheduleIsNull)
            {
                request.RefreshSchedule = null;
            }
            if (cmdletContext.TerminationProtectionEnabled != null)
            {
                request.TerminationProtectionEnabled = cmdletContext.TerminationProtectionEnabled.Value;
            }
            if (cmdletContext.Widget != null)
            {
                request.Widgets = cmdletContext.Widget;
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
        
        private Amazon.CloudTrail.Model.UpdateDashboardResponse CallAWSServiceOperation(IAmazonCloudTrail client, Amazon.CloudTrail.Model.UpdateDashboardRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudTrail", "UpdateDashboard");
            try
            {
                return client.UpdateDashboardAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DashboardId { get; set; }
            public Amazon.CloudTrail.RefreshScheduleFrequencyUnit Frequency_Unit { get; set; }
            public System.Int32? Frequency_Value { get; set; }
            public Amazon.CloudTrail.RefreshScheduleStatus RefreshSchedule_Status { get; set; }
            public System.String RefreshSchedule_TimeOfDay { get; set; }
            public System.Boolean? TerminationProtectionEnabled { get; set; }
            public List<Amazon.CloudTrail.Model.RequestWidget> Widget { get; set; }
            public System.Func<Amazon.CloudTrail.Model.UpdateDashboardResponse, UpdateCTDashboardCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
