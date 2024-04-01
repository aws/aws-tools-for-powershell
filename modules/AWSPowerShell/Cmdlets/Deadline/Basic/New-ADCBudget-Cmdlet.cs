/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Deadline;
using Amazon.Deadline.Model;

namespace Amazon.PowerShell.Cmdlets.ADC
{
    /// <summary>
    /// Creates a budget to set spending thresholds for your rendering activity.
    /// </summary>
    [Cmdlet("New", "ADCBudget", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWSDeadlineCloud CreateBudget API operation.", Operation = new[] {"CreateBudget"}, SelectReturnType = typeof(Amazon.Deadline.Model.CreateBudgetResponse))]
    [AWSCmdletOutput("System.String or Amazon.Deadline.Model.CreateBudgetResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Deadline.Model.CreateBudgetResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewADCBudgetCmdlet : AmazonDeadlineClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Action
        /// <summary>
        /// <para>
        /// <para>The budget actions to specify what happens when the budget runs out.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Actions")]
        public Amazon.Deadline.Model.BudgetActionToAdd[] Action { get; set; }
        #endregion
        
        #region Parameter ApproximateDollarLimit
        /// <summary>
        /// <para>
        /// <para>The dollar limit based on consumed usage.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Single? ApproximateDollarLimit { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the budget.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>The display name of the budget.</para>
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
        /// <para>The farm ID to include in this budget.</para>
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
        
        #region Parameter UsageTrackingResource_QueueId
        /// <summary>
        /// <para>
        /// <para>The queue ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UsageTrackingResource_QueueId { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'BudgetId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Deadline.Model.CreateBudgetResponse).
        /// Specifying the name of a property of type Amazon.Deadline.Model.CreateBudgetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "BudgetId";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ADCBudget (CreateBudget)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Deadline.Model.CreateBudgetResponse, NewADCBudgetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Action != null)
            {
                context.Action = new List<Amazon.Deadline.Model.BudgetActionToAdd>(this.Action);
            }
            #if MODULAR
            if (this.Action == null && ParameterWasBound(nameof(this.Action)))
            {
                WriteWarning("You are passing $null as a value for parameter Action which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ApproximateDollarLimit = this.ApproximateDollarLimit;
            #if MODULAR
            if (this.ApproximateDollarLimit == null && ParameterWasBound(nameof(this.ApproximateDollarLimit)))
            {
                WriteWarning("You are passing $null as a value for parameter ApproximateDollarLimit which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.DisplayName = this.DisplayName;
            #if MODULAR
            if (this.DisplayName == null && ParameterWasBound(nameof(this.DisplayName)))
            {
                WriteWarning("You are passing $null as a value for parameter DisplayName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FarmId = this.FarmId;
            #if MODULAR
            if (this.FarmId == null && ParameterWasBound(nameof(this.FarmId)))
            {
                WriteWarning("You are passing $null as a value for parameter FarmId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Fixed_EndTime = this.Fixed_EndTime;
            context.Fixed_StartTime = this.Fixed_StartTime;
            context.UsageTrackingResource_QueueId = this.UsageTrackingResource_QueueId;
            
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
            var request = new Amazon.Deadline.Model.CreateBudgetRequest();
            
            if (cmdletContext.Action != null)
            {
                request.Actions = cmdletContext.Action;
            }
            if (cmdletContext.ApproximateDollarLimit != null)
            {
                request.ApproximateDollarLimit = cmdletContext.ApproximateDollarLimit.Value;
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
            
             // populate UsageTrackingResource
            var requestUsageTrackingResourceIsNull = true;
            request.UsageTrackingResource = new Amazon.Deadline.Model.UsageTrackingResource();
            System.String requestUsageTrackingResource_usageTrackingResource_QueueId = null;
            if (cmdletContext.UsageTrackingResource_QueueId != null)
            {
                requestUsageTrackingResource_usageTrackingResource_QueueId = cmdletContext.UsageTrackingResource_QueueId;
            }
            if (requestUsageTrackingResource_usageTrackingResource_QueueId != null)
            {
                request.UsageTrackingResource.QueueId = requestUsageTrackingResource_usageTrackingResource_QueueId;
                requestUsageTrackingResourceIsNull = false;
            }
             // determine if request.UsageTrackingResource should be set to null
            if (requestUsageTrackingResourceIsNull)
            {
                request.UsageTrackingResource = null;
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
        
        private Amazon.Deadline.Model.CreateBudgetResponse CallAWSServiceOperation(IAmazonDeadline client, Amazon.Deadline.Model.CreateBudgetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWSDeadlineCloud", "CreateBudget");
            try
            {
                #if DESKTOP
                return client.CreateBudget(request);
                #elif CORECLR
                return client.CreateBudgetAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Deadline.Model.BudgetActionToAdd> Action { get; set; }
            public System.Single? ApproximateDollarLimit { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String DisplayName { get; set; }
            public System.String FarmId { get; set; }
            public System.DateTime? Fixed_EndTime { get; set; }
            public System.DateTime? Fixed_StartTime { get; set; }
            public System.String UsageTrackingResource_QueueId { get; set; }
            public System.Func<Amazon.Deadline.Model.CreateBudgetResponse, NewADCBudgetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.BudgetId;
        }
        
    }
}
