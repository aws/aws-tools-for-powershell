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
using Amazon.QuickSight;
using Amazon.QuickSight.Model;

namespace Amazon.PowerShell.Cmdlets.QS
{
    /// <summary>
    /// Updates a topic refresh schedule.
    /// </summary>
    [Cmdlet("Update", "QSTopicRefreshSchedule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QuickSight.Model.UpdateTopicRefreshScheduleResponse")]
    [AWSCmdlet("Calls the Amazon QuickSight UpdateTopicRefreshSchedule API operation.", Operation = new[] {"UpdateTopicRefreshSchedule"}, SelectReturnType = typeof(Amazon.QuickSight.Model.UpdateTopicRefreshScheduleResponse))]
    [AWSCmdletOutput("Amazon.QuickSight.Model.UpdateTopicRefreshScheduleResponse",
        "This cmdlet returns an Amazon.QuickSight.Model.UpdateTopicRefreshScheduleResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateQSTopicRefreshScheduleCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services account that contains the topic whose refresh schedule
        /// you want to update.</para>
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
        
        #region Parameter RefreshSchedule_BasedOnSpiceSchedule
        /// <summary>
        /// <para>
        /// <para>A Boolean value that controls whether to schedule runs at the same schedule that is
        /// specified in SPICE dataset.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? RefreshSchedule_BasedOnSpiceSchedule { get; set; }
        #endregion
        
        #region Parameter DatasetId
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
        public System.String DatasetId { get; set; }
        #endregion
        
        #region Parameter RefreshSchedule_IsEnabled
        /// <summary>
        /// <para>
        /// <para>A Boolean value that controls whether to schedule is enabled.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? RefreshSchedule_IsEnabled { get; set; }
        #endregion
        
        #region Parameter RefreshSchedule_RepeatAt
        /// <summary>
        /// <para>
        /// <para>The time of day when the refresh should run, for example, Monday-Sunday.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RefreshSchedule_RepeatAt { get; set; }
        #endregion
        
        #region Parameter RefreshSchedule_StartingAt
        /// <summary>
        /// <para>
        /// <para>The starting date and time for the refresh schedule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? RefreshSchedule_StartingAt { get; set; }
        #endregion
        
        #region Parameter RefreshSchedule_Timezone
        /// <summary>
        /// <para>
        /// <para>The timezone that you want the refresh schedule to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RefreshSchedule_Timezone { get; set; }
        #endregion
        
        #region Parameter TopicId
        /// <summary>
        /// <para>
        /// <para>The ID of the topic that you want to modify. This ID is unique per Amazon Web Services
        /// Region for each Amazon Web Services account.</para>
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
        public System.String TopicId { get; set; }
        #endregion
        
        #region Parameter RefreshSchedule_TopicScheduleType
        /// <summary>
        /// <para>
        /// <para>The type of refresh schedule. Valid values for this structure are <c>HOURLY</c>, <c>DAILY</c>,
        /// <c>WEEKLY</c>, and <c>MONTHLY</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.TopicScheduleType")]
        public Amazon.QuickSight.TopicScheduleType RefreshSchedule_TopicScheduleType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.UpdateTopicRefreshScheduleResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.UpdateTopicRefreshScheduleResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TopicId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-QSTopicRefreshSchedule (UpdateTopicRefreshSchedule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.UpdateTopicRefreshScheduleResponse, UpdateQSTopicRefreshScheduleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DatasetId = this.DatasetId;
            #if MODULAR
            if (this.DatasetId == null && ParameterWasBound(nameof(this.DatasetId)))
            {
                WriteWarning("You are passing $null as a value for parameter DatasetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RefreshSchedule_BasedOnSpiceSchedule = this.RefreshSchedule_BasedOnSpiceSchedule;
            #if MODULAR
            if (this.RefreshSchedule_BasedOnSpiceSchedule == null && ParameterWasBound(nameof(this.RefreshSchedule_BasedOnSpiceSchedule)))
            {
                WriteWarning("You are passing $null as a value for parameter RefreshSchedule_BasedOnSpiceSchedule which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RefreshSchedule_IsEnabled = this.RefreshSchedule_IsEnabled;
            #if MODULAR
            if (this.RefreshSchedule_IsEnabled == null && ParameterWasBound(nameof(this.RefreshSchedule_IsEnabled)))
            {
                WriteWarning("You are passing $null as a value for parameter RefreshSchedule_IsEnabled which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RefreshSchedule_RepeatAt = this.RefreshSchedule_RepeatAt;
            context.RefreshSchedule_StartingAt = this.RefreshSchedule_StartingAt;
            context.RefreshSchedule_Timezone = this.RefreshSchedule_Timezone;
            context.RefreshSchedule_TopicScheduleType = this.RefreshSchedule_TopicScheduleType;
            context.TopicId = this.TopicId;
            #if MODULAR
            if (this.TopicId == null && ParameterWasBound(nameof(this.TopicId)))
            {
                WriteWarning("You are passing $null as a value for parameter TopicId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.QuickSight.Model.UpdateTopicRefreshScheduleRequest();
            
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            if (cmdletContext.DatasetId != null)
            {
                request.DatasetId = cmdletContext.DatasetId;
            }
            
             // populate RefreshSchedule
            var requestRefreshScheduleIsNull = true;
            request.RefreshSchedule = new Amazon.QuickSight.Model.TopicRefreshSchedule();
            System.Boolean? requestRefreshSchedule_refreshSchedule_BasedOnSpiceSchedule = null;
            if (cmdletContext.RefreshSchedule_BasedOnSpiceSchedule != null)
            {
                requestRefreshSchedule_refreshSchedule_BasedOnSpiceSchedule = cmdletContext.RefreshSchedule_BasedOnSpiceSchedule.Value;
            }
            if (requestRefreshSchedule_refreshSchedule_BasedOnSpiceSchedule != null)
            {
                request.RefreshSchedule.BasedOnSpiceSchedule = requestRefreshSchedule_refreshSchedule_BasedOnSpiceSchedule.Value;
                requestRefreshScheduleIsNull = false;
            }
            System.Boolean? requestRefreshSchedule_refreshSchedule_IsEnabled = null;
            if (cmdletContext.RefreshSchedule_IsEnabled != null)
            {
                requestRefreshSchedule_refreshSchedule_IsEnabled = cmdletContext.RefreshSchedule_IsEnabled.Value;
            }
            if (requestRefreshSchedule_refreshSchedule_IsEnabled != null)
            {
                request.RefreshSchedule.IsEnabled = requestRefreshSchedule_refreshSchedule_IsEnabled.Value;
                requestRefreshScheduleIsNull = false;
            }
            System.String requestRefreshSchedule_refreshSchedule_RepeatAt = null;
            if (cmdletContext.RefreshSchedule_RepeatAt != null)
            {
                requestRefreshSchedule_refreshSchedule_RepeatAt = cmdletContext.RefreshSchedule_RepeatAt;
            }
            if (requestRefreshSchedule_refreshSchedule_RepeatAt != null)
            {
                request.RefreshSchedule.RepeatAt = requestRefreshSchedule_refreshSchedule_RepeatAt;
                requestRefreshScheduleIsNull = false;
            }
            System.DateTime? requestRefreshSchedule_refreshSchedule_StartingAt = null;
            if (cmdletContext.RefreshSchedule_StartingAt != null)
            {
                requestRefreshSchedule_refreshSchedule_StartingAt = cmdletContext.RefreshSchedule_StartingAt.Value;
            }
            if (requestRefreshSchedule_refreshSchedule_StartingAt != null)
            {
                request.RefreshSchedule.StartingAt = requestRefreshSchedule_refreshSchedule_StartingAt.Value;
                requestRefreshScheduleIsNull = false;
            }
            System.String requestRefreshSchedule_refreshSchedule_Timezone = null;
            if (cmdletContext.RefreshSchedule_Timezone != null)
            {
                requestRefreshSchedule_refreshSchedule_Timezone = cmdletContext.RefreshSchedule_Timezone;
            }
            if (requestRefreshSchedule_refreshSchedule_Timezone != null)
            {
                request.RefreshSchedule.Timezone = requestRefreshSchedule_refreshSchedule_Timezone;
                requestRefreshScheduleIsNull = false;
            }
            Amazon.QuickSight.TopicScheduleType requestRefreshSchedule_refreshSchedule_TopicScheduleType = null;
            if (cmdletContext.RefreshSchedule_TopicScheduleType != null)
            {
                requestRefreshSchedule_refreshSchedule_TopicScheduleType = cmdletContext.RefreshSchedule_TopicScheduleType;
            }
            if (requestRefreshSchedule_refreshSchedule_TopicScheduleType != null)
            {
                request.RefreshSchedule.TopicScheduleType = requestRefreshSchedule_refreshSchedule_TopicScheduleType;
                requestRefreshScheduleIsNull = false;
            }
             // determine if request.RefreshSchedule should be set to null
            if (requestRefreshScheduleIsNull)
            {
                request.RefreshSchedule = null;
            }
            if (cmdletContext.TopicId != null)
            {
                request.TopicId = cmdletContext.TopicId;
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
        
        private Amazon.QuickSight.Model.UpdateTopicRefreshScheduleResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.UpdateTopicRefreshScheduleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "UpdateTopicRefreshSchedule");
            try
            {
                #if DESKTOP
                return client.UpdateTopicRefreshSchedule(request);
                #elif CORECLR
                return client.UpdateTopicRefreshScheduleAsync(request).GetAwaiter().GetResult();
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
            public System.String AwsAccountId { get; set; }
            public System.String DatasetId { get; set; }
            public System.Boolean? RefreshSchedule_BasedOnSpiceSchedule { get; set; }
            public System.Boolean? RefreshSchedule_IsEnabled { get; set; }
            public System.String RefreshSchedule_RepeatAt { get; set; }
            public System.DateTime? RefreshSchedule_StartingAt { get; set; }
            public System.String RefreshSchedule_Timezone { get; set; }
            public Amazon.QuickSight.TopicScheduleType RefreshSchedule_TopicScheduleType { get; set; }
            public System.String TopicId { get; set; }
            public System.Func<Amazon.QuickSight.Model.UpdateTopicRefreshScheduleResponse, UpdateQSTopicRefreshScheduleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
