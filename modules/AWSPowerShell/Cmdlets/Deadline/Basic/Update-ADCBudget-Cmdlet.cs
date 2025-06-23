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
using Amazon.Deadline;
using Amazon.Deadline.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ADC
{
    /// <summary>
    /// Updates a budget that sets spending thresholds for rendering activity.
    /// </summary>
    [Cmdlet("Update", "ADCBudget", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWSDeadlineCloud UpdateBudget API operation.", Operation = new[] {"UpdateBudget"}, SelectReturnType = typeof(Amazon.Deadline.Model.UpdateBudgetResponse))]
    [AWSCmdletOutput("None or Amazon.Deadline.Model.UpdateBudgetResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Deadline.Model.UpdateBudgetResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateADCBudgetCmdlet : AmazonDeadlineClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ActionsToAdd
        /// <summary>
        /// <para>
        /// <para>The budget actions to add. Budget actions specify what happens when the budget runs
        /// out.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Deadline.Model.BudgetActionToAdd[] ActionsToAdd { get; set; }
        #endregion
        
        #region Parameter ActionsToRemove
        /// <summary>
        /// <para>
        /// <para>The budget actions to remove from the budget.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Deadline.Model.BudgetActionToRemove[] ActionsToRemove { get; set; }
        #endregion
        
        #region Parameter ApproximateDollarLimit
        /// <summary>
        /// <para>
        /// <para>The dollar limit to update on the budget. Based on consumed usage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? ApproximateDollarLimit { get; set; }
        #endregion
        
        #region Parameter BudgetId
        /// <summary>
        /// <para>
        /// <para>The budget ID to update.</para>
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
        public System.String BudgetId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the budget to update.</para><important><para>This field can store any content. Escape or encode this content before displaying
        /// it on a webpage or any other system that might interpret the content of this field.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>The display name of the budget to update.</para><important><para>This field can store any content. Escape or encode this content before displaying
        /// it on a webpage or any other system that might interpret the content of this field.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter Fixed_EndTime
        /// <summary>
        /// <para>
        /// <para>When the budget ends.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Schedule_Fixed_EndTime")]
        public System.DateTime? Fixed_EndTime { get; set; }
        #endregion
        
        #region Parameter FarmId
        /// <summary>
        /// <para>
        /// <para>The farm ID of the budget to update.</para>
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
        public System.String FarmId { get; set; }
        #endregion
        
        #region Parameter Fixed_StartTime
        /// <summary>
        /// <para>
        /// <para>When the budget starts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Schedule_Fixed_StartTime")]
        public System.DateTime? Fixed_StartTime { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>Updates the status of the budget.</para><ul><li><para><c>ACTIVE</c>–The budget is being evaluated.</para></li><li><para><c>INACTIVE</c>–The budget is inactive. This can include Expired, Canceled, or deleted
        /// Deleted statuses.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Deadline.BudgetStatus")]
        public Amazon.Deadline.BudgetStatus Status { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The unique token which the server uses to recognize retries of the same request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Deadline.Model.UpdateBudgetResponse).
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ADCBudget (UpdateBudget)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Deadline.Model.UpdateBudgetResponse, UpdateADCBudgetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ActionsToAdd != null)
            {
                context.ActionsToAdd = new List<Amazon.Deadline.Model.BudgetActionToAdd>(this.ActionsToAdd);
            }
            if (this.ActionsToRemove != null)
            {
                context.ActionsToRemove = new List<Amazon.Deadline.Model.BudgetActionToRemove>(this.ActionsToRemove);
            }
            context.ApproximateDollarLimit = this.ApproximateDollarLimit;
            context.BudgetId = this.BudgetId;
            #if MODULAR
            if (this.BudgetId == null && ParameterWasBound(nameof(this.BudgetId)))
            {
                WriteWarning("You are passing $null as a value for parameter BudgetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.DisplayName = this.DisplayName;
            context.FarmId = this.FarmId;
            #if MODULAR
            if (this.FarmId == null && ParameterWasBound(nameof(this.FarmId)))
            {
                WriteWarning("You are passing $null as a value for parameter FarmId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Fixed_EndTime = this.Fixed_EndTime;
            context.Fixed_StartTime = this.Fixed_StartTime;
            context.Status = this.Status;
            
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
            var request = new Amazon.Deadline.Model.UpdateBudgetRequest();
            
            if (cmdletContext.ActionsToAdd != null)
            {
                request.ActionsToAdd = cmdletContext.ActionsToAdd;
            }
            if (cmdletContext.ActionsToRemove != null)
            {
                request.ActionsToRemove = cmdletContext.ActionsToRemove;
            }
            if (cmdletContext.ApproximateDollarLimit != null)
            {
                request.ApproximateDollarLimit = cmdletContext.ApproximateDollarLimit.Value;
            }
            if (cmdletContext.BudgetId != null)
            {
                request.BudgetId = cmdletContext.BudgetId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            if (cmdletContext.FarmId != null)
            {
                request.FarmId = cmdletContext.FarmId;
            }
            
             // populate Schedule
            var requestScheduleIsNull = true;
            request.Schedule = new Amazon.Deadline.Model.BudgetSchedule();
            Amazon.Deadline.Model.FixedBudgetSchedule requestSchedule_schedule_Fixed = null;
            
             // populate Fixed
            var requestSchedule_schedule_FixedIsNull = true;
            requestSchedule_schedule_Fixed = new Amazon.Deadline.Model.FixedBudgetSchedule();
            System.DateTime? requestSchedule_schedule_Fixed_fixed_EndTime = null;
            if (cmdletContext.Fixed_EndTime != null)
            {
                requestSchedule_schedule_Fixed_fixed_EndTime = cmdletContext.Fixed_EndTime.Value;
            }
            if (requestSchedule_schedule_Fixed_fixed_EndTime != null)
            {
                requestSchedule_schedule_Fixed.EndTime = requestSchedule_schedule_Fixed_fixed_EndTime.Value;
                requestSchedule_schedule_FixedIsNull = false;
            }
            System.DateTime? requestSchedule_schedule_Fixed_fixed_StartTime = null;
            if (cmdletContext.Fixed_StartTime != null)
            {
                requestSchedule_schedule_Fixed_fixed_StartTime = cmdletContext.Fixed_StartTime.Value;
            }
            if (requestSchedule_schedule_Fixed_fixed_StartTime != null)
            {
                requestSchedule_schedule_Fixed.StartTime = requestSchedule_schedule_Fixed_fixed_StartTime.Value;
                requestSchedule_schedule_FixedIsNull = false;
            }
             // determine if requestSchedule_schedule_Fixed should be set to null
            if (requestSchedule_schedule_FixedIsNull)
            {
                requestSchedule_schedule_Fixed = null;
            }
            if (requestSchedule_schedule_Fixed != null)
            {
                request.Schedule.Fixed = requestSchedule_schedule_Fixed;
                requestScheduleIsNull = false;
            }
             // determine if request.Schedule should be set to null
            if (requestScheduleIsNull)
            {
                request.Schedule = null;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
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
        
        private Amazon.Deadline.Model.UpdateBudgetResponse CallAWSServiceOperation(IAmazonDeadline client, Amazon.Deadline.Model.UpdateBudgetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWSDeadlineCloud", "UpdateBudget");
            try
            {
                return client.UpdateBudgetAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.Deadline.Model.BudgetActionToAdd> ActionsToAdd { get; set; }
            public List<Amazon.Deadline.Model.BudgetActionToRemove> ActionsToRemove { get; set; }
            public System.Single? ApproximateDollarLimit { get; set; }
            public System.String BudgetId { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String DisplayName { get; set; }
            public System.String FarmId { get; set; }
            public System.DateTime? Fixed_EndTime { get; set; }
            public System.DateTime? Fixed_StartTime { get; set; }
            public Amazon.Deadline.BudgetStatus Status { get; set; }
            public System.Func<Amazon.Deadline.Model.UpdateBudgetResponse, UpdateADCBudgetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
