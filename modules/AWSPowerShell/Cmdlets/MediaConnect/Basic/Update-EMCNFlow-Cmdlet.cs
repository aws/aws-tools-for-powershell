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
using Amazon.MediaConnect;
using Amazon.MediaConnect.Model;

namespace Amazon.PowerShell.Cmdlets.EMCN
{
    /// <summary>
    /// Updates flow
    /// </summary>
    [Cmdlet("Update", "EMCNFlow", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaConnect.Model.Flow")]
    [AWSCmdlet("Calls the AWS Elemental MediaConnect UpdateFlow API operation.", Operation = new[] {"UpdateFlow"}, SelectReturnType = typeof(Amazon.MediaConnect.Model.UpdateFlowResponse))]
    [AWSCmdletOutput("Amazon.MediaConnect.Model.Flow or Amazon.MediaConnect.Model.UpdateFlowResponse",
        "This cmdlet returns an Amazon.MediaConnect.Model.Flow object.",
        "The service call response (type Amazon.MediaConnect.Model.UpdateFlowResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateEMCNFlowCmdlet : AmazonMediaConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SourceMonitoringConfig_AudioMonitoringSetting
        /// <summary>
        /// <para>
        /// Contains the settings for audio
        /// stream metrics monitoring.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceMonitoringConfig_AudioMonitoringSettings")]
        public Amazon.MediaConnect.Model.AudioMonitoringSetting[] SourceMonitoringConfig_AudioMonitoringSetting { get; set; }
        #endregion
        
        #region Parameter SourceMonitoringConfig_ContentQualityAnalysisState
        /// <summary>
        /// <para>
        /// Indicates whether content
        /// quality analysis is enabled or disabled.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaConnect.ContentQualityAnalysisState")]
        public Amazon.MediaConnect.ContentQualityAnalysisState SourceMonitoringConfig_ContentQualityAnalysisState { get; set; }
        #endregion
        
        #region Parameter SourceFailoverConfig_FailoverMode
        /// <summary>
        /// <para>
        /// The type of failover you choose for this
        /// flow. MERGE combines the source streams into a single stream, allowing graceful recovery
        /// from any single-source loss. FAILOVER allows switching between different streams.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaConnect.FailoverMode")]
        public Amazon.MediaConnect.FailoverMode SourceFailoverConfig_FailoverMode { get; set; }
        #endregion
        
        #region Parameter FlowArn
        /// <summary>
        /// <para>
        /// The flow that you want to update.
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
        public System.String FlowArn { get; set; }
        #endregion
        
        #region Parameter Maintenance_MaintenanceDay
        /// <summary>
        /// <para>
        /// A day of a week when the maintenance will
        /// happen. use Monday/Tuesday/Wednesday/Thursday/Friday/Saturday/Sunday.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaConnect.MaintenanceDay")]
        public Amazon.MediaConnect.MaintenanceDay Maintenance_MaintenanceDay { get; set; }
        #endregion
        
        #region Parameter Maintenance_MaintenanceScheduledDate
        /// <summary>
        /// <para>
        /// A scheduled date in ISO UTC format
        /// when the maintenance will happen. Use YYYY-MM-DD format. Example: 2021-01-30.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Maintenance_MaintenanceScheduledDate { get; set; }
        #endregion
        
        #region Parameter Maintenance_MaintenanceStartHour
        /// <summary>
        /// <para>
        /// UTC time when the maintenance will
        /// happen. Use 24-hour HH:MM format. Minutes must be 00. Example: 13:00. The default
        /// value is 02:00.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Maintenance_MaintenanceStartHour { get; set; }
        #endregion
        
        #region Parameter SourcePriority_PrimarySource
        /// <summary>
        /// <para>
        /// The name of the source you choose as the
        /// primary source for this flow.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceFailoverConfig_SourcePriority_PrimarySource")]
        public System.String SourcePriority_PrimarySource { get; set; }
        #endregion
        
        #region Parameter SourceFailoverConfig_RecoveryWindow
        /// <summary>
        /// <para>
        /// Recovery window time to look for dash-7
        /// packets
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SourceFailoverConfig_RecoveryWindow { get; set; }
        #endregion
        
        #region Parameter SourceFailoverConfig_State
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaConnect.State")]
        public Amazon.MediaConnect.State SourceFailoverConfig_State { get; set; }
        #endregion
        
        #region Parameter SourceMonitoringConfig_ThumbnailState
        /// <summary>
        /// <para>
        /// The state of thumbnail monitoring.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaConnect.ThumbnailState")]
        public Amazon.MediaConnect.ThumbnailState SourceMonitoringConfig_ThumbnailState { get; set; }
        #endregion
        
        #region Parameter SourceMonitoringConfig_VideoMonitoringSetting
        /// <summary>
        /// <para>
        /// Contains the settings for video
        /// stream metrics monitoring.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceMonitoringConfig_VideoMonitoringSettings")]
        public Amazon.MediaConnect.Model.VideoMonitoringSetting[] SourceMonitoringConfig_VideoMonitoringSetting { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Flow'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaConnect.Model.UpdateFlowResponse).
        /// Specifying the name of a property of type Amazon.MediaConnect.Model.UpdateFlowResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Flow";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FlowArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EMCNFlow (UpdateFlow)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaConnect.Model.UpdateFlowResponse, UpdateEMCNFlowCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FlowArn = this.FlowArn;
            #if MODULAR
            if (this.FlowArn == null && ParameterWasBound(nameof(this.FlowArn)))
            {
                WriteWarning("You are passing $null as a value for parameter FlowArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Maintenance_MaintenanceDay = this.Maintenance_MaintenanceDay;
            context.Maintenance_MaintenanceScheduledDate = this.Maintenance_MaintenanceScheduledDate;
            context.Maintenance_MaintenanceStartHour = this.Maintenance_MaintenanceStartHour;
            context.SourceFailoverConfig_FailoverMode = this.SourceFailoverConfig_FailoverMode;
            context.SourceFailoverConfig_RecoveryWindow = this.SourceFailoverConfig_RecoveryWindow;
            context.SourcePriority_PrimarySource = this.SourcePriority_PrimarySource;
            context.SourceFailoverConfig_State = this.SourceFailoverConfig_State;
            if (this.SourceMonitoringConfig_AudioMonitoringSetting != null)
            {
                context.SourceMonitoringConfig_AudioMonitoringSetting = new List<Amazon.MediaConnect.Model.AudioMonitoringSetting>(this.SourceMonitoringConfig_AudioMonitoringSetting);
            }
            context.SourceMonitoringConfig_ContentQualityAnalysisState = this.SourceMonitoringConfig_ContentQualityAnalysisState;
            context.SourceMonitoringConfig_ThumbnailState = this.SourceMonitoringConfig_ThumbnailState;
            if (this.SourceMonitoringConfig_VideoMonitoringSetting != null)
            {
                context.SourceMonitoringConfig_VideoMonitoringSetting = new List<Amazon.MediaConnect.Model.VideoMonitoringSetting>(this.SourceMonitoringConfig_VideoMonitoringSetting);
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
            var request = new Amazon.MediaConnect.Model.UpdateFlowRequest();
            
            if (cmdletContext.FlowArn != null)
            {
                request.FlowArn = cmdletContext.FlowArn;
            }
            
             // populate Maintenance
            var requestMaintenanceIsNull = true;
            request.Maintenance = new Amazon.MediaConnect.Model.UpdateMaintenance();
            Amazon.MediaConnect.MaintenanceDay requestMaintenance_maintenance_MaintenanceDay = null;
            if (cmdletContext.Maintenance_MaintenanceDay != null)
            {
                requestMaintenance_maintenance_MaintenanceDay = cmdletContext.Maintenance_MaintenanceDay;
            }
            if (requestMaintenance_maintenance_MaintenanceDay != null)
            {
                request.Maintenance.MaintenanceDay = requestMaintenance_maintenance_MaintenanceDay;
                requestMaintenanceIsNull = false;
            }
            System.String requestMaintenance_maintenance_MaintenanceScheduledDate = null;
            if (cmdletContext.Maintenance_MaintenanceScheduledDate != null)
            {
                requestMaintenance_maintenance_MaintenanceScheduledDate = cmdletContext.Maintenance_MaintenanceScheduledDate;
            }
            if (requestMaintenance_maintenance_MaintenanceScheduledDate != null)
            {
                request.Maintenance.MaintenanceScheduledDate = requestMaintenance_maintenance_MaintenanceScheduledDate;
                requestMaintenanceIsNull = false;
            }
            System.String requestMaintenance_maintenance_MaintenanceStartHour = null;
            if (cmdletContext.Maintenance_MaintenanceStartHour != null)
            {
                requestMaintenance_maintenance_MaintenanceStartHour = cmdletContext.Maintenance_MaintenanceStartHour;
            }
            if (requestMaintenance_maintenance_MaintenanceStartHour != null)
            {
                request.Maintenance.MaintenanceStartHour = requestMaintenance_maintenance_MaintenanceStartHour;
                requestMaintenanceIsNull = false;
            }
             // determine if request.Maintenance should be set to null
            if (requestMaintenanceIsNull)
            {
                request.Maintenance = null;
            }
            
             // populate SourceFailoverConfig
            var requestSourceFailoverConfigIsNull = true;
            request.SourceFailoverConfig = new Amazon.MediaConnect.Model.UpdateFailoverConfig();
            Amazon.MediaConnect.FailoverMode requestSourceFailoverConfig_sourceFailoverConfig_FailoverMode = null;
            if (cmdletContext.SourceFailoverConfig_FailoverMode != null)
            {
                requestSourceFailoverConfig_sourceFailoverConfig_FailoverMode = cmdletContext.SourceFailoverConfig_FailoverMode;
            }
            if (requestSourceFailoverConfig_sourceFailoverConfig_FailoverMode != null)
            {
                request.SourceFailoverConfig.FailoverMode = requestSourceFailoverConfig_sourceFailoverConfig_FailoverMode;
                requestSourceFailoverConfigIsNull = false;
            }
            System.Int32? requestSourceFailoverConfig_sourceFailoverConfig_RecoveryWindow = null;
            if (cmdletContext.SourceFailoverConfig_RecoveryWindow != null)
            {
                requestSourceFailoverConfig_sourceFailoverConfig_RecoveryWindow = cmdletContext.SourceFailoverConfig_RecoveryWindow.Value;
            }
            if (requestSourceFailoverConfig_sourceFailoverConfig_RecoveryWindow != null)
            {
                request.SourceFailoverConfig.RecoveryWindow = requestSourceFailoverConfig_sourceFailoverConfig_RecoveryWindow.Value;
                requestSourceFailoverConfigIsNull = false;
            }
            Amazon.MediaConnect.State requestSourceFailoverConfig_sourceFailoverConfig_State = null;
            if (cmdletContext.SourceFailoverConfig_State != null)
            {
                requestSourceFailoverConfig_sourceFailoverConfig_State = cmdletContext.SourceFailoverConfig_State;
            }
            if (requestSourceFailoverConfig_sourceFailoverConfig_State != null)
            {
                request.SourceFailoverConfig.State = requestSourceFailoverConfig_sourceFailoverConfig_State;
                requestSourceFailoverConfigIsNull = false;
            }
            Amazon.MediaConnect.Model.SourcePriority requestSourceFailoverConfig_sourceFailoverConfig_SourcePriority = null;
            
             // populate SourcePriority
            var requestSourceFailoverConfig_sourceFailoverConfig_SourcePriorityIsNull = true;
            requestSourceFailoverConfig_sourceFailoverConfig_SourcePriority = new Amazon.MediaConnect.Model.SourcePriority();
            System.String requestSourceFailoverConfig_sourceFailoverConfig_SourcePriority_sourcePriority_PrimarySource = null;
            if (cmdletContext.SourcePriority_PrimarySource != null)
            {
                requestSourceFailoverConfig_sourceFailoverConfig_SourcePriority_sourcePriority_PrimarySource = cmdletContext.SourcePriority_PrimarySource;
            }
            if (requestSourceFailoverConfig_sourceFailoverConfig_SourcePriority_sourcePriority_PrimarySource != null)
            {
                requestSourceFailoverConfig_sourceFailoverConfig_SourcePriority.PrimarySource = requestSourceFailoverConfig_sourceFailoverConfig_SourcePriority_sourcePriority_PrimarySource;
                requestSourceFailoverConfig_sourceFailoverConfig_SourcePriorityIsNull = false;
            }
             // determine if requestSourceFailoverConfig_sourceFailoverConfig_SourcePriority should be set to null
            if (requestSourceFailoverConfig_sourceFailoverConfig_SourcePriorityIsNull)
            {
                requestSourceFailoverConfig_sourceFailoverConfig_SourcePriority = null;
            }
            if (requestSourceFailoverConfig_sourceFailoverConfig_SourcePriority != null)
            {
                request.SourceFailoverConfig.SourcePriority = requestSourceFailoverConfig_sourceFailoverConfig_SourcePriority;
                requestSourceFailoverConfigIsNull = false;
            }
             // determine if request.SourceFailoverConfig should be set to null
            if (requestSourceFailoverConfigIsNull)
            {
                request.SourceFailoverConfig = null;
            }
            
             // populate SourceMonitoringConfig
            var requestSourceMonitoringConfigIsNull = true;
            request.SourceMonitoringConfig = new Amazon.MediaConnect.Model.MonitoringConfig();
            List<Amazon.MediaConnect.Model.AudioMonitoringSetting> requestSourceMonitoringConfig_sourceMonitoringConfig_AudioMonitoringSetting = null;
            if (cmdletContext.SourceMonitoringConfig_AudioMonitoringSetting != null)
            {
                requestSourceMonitoringConfig_sourceMonitoringConfig_AudioMonitoringSetting = cmdletContext.SourceMonitoringConfig_AudioMonitoringSetting;
            }
            if (requestSourceMonitoringConfig_sourceMonitoringConfig_AudioMonitoringSetting != null)
            {
                request.SourceMonitoringConfig.AudioMonitoringSettings = requestSourceMonitoringConfig_sourceMonitoringConfig_AudioMonitoringSetting;
                requestSourceMonitoringConfigIsNull = false;
            }
            Amazon.MediaConnect.ContentQualityAnalysisState requestSourceMonitoringConfig_sourceMonitoringConfig_ContentQualityAnalysisState = null;
            if (cmdletContext.SourceMonitoringConfig_ContentQualityAnalysisState != null)
            {
                requestSourceMonitoringConfig_sourceMonitoringConfig_ContentQualityAnalysisState = cmdletContext.SourceMonitoringConfig_ContentQualityAnalysisState;
            }
            if (requestSourceMonitoringConfig_sourceMonitoringConfig_ContentQualityAnalysisState != null)
            {
                request.SourceMonitoringConfig.ContentQualityAnalysisState = requestSourceMonitoringConfig_sourceMonitoringConfig_ContentQualityAnalysisState;
                requestSourceMonitoringConfigIsNull = false;
            }
            Amazon.MediaConnect.ThumbnailState requestSourceMonitoringConfig_sourceMonitoringConfig_ThumbnailState = null;
            if (cmdletContext.SourceMonitoringConfig_ThumbnailState != null)
            {
                requestSourceMonitoringConfig_sourceMonitoringConfig_ThumbnailState = cmdletContext.SourceMonitoringConfig_ThumbnailState;
            }
            if (requestSourceMonitoringConfig_sourceMonitoringConfig_ThumbnailState != null)
            {
                request.SourceMonitoringConfig.ThumbnailState = requestSourceMonitoringConfig_sourceMonitoringConfig_ThumbnailState;
                requestSourceMonitoringConfigIsNull = false;
            }
            List<Amazon.MediaConnect.Model.VideoMonitoringSetting> requestSourceMonitoringConfig_sourceMonitoringConfig_VideoMonitoringSetting = null;
            if (cmdletContext.SourceMonitoringConfig_VideoMonitoringSetting != null)
            {
                requestSourceMonitoringConfig_sourceMonitoringConfig_VideoMonitoringSetting = cmdletContext.SourceMonitoringConfig_VideoMonitoringSetting;
            }
            if (requestSourceMonitoringConfig_sourceMonitoringConfig_VideoMonitoringSetting != null)
            {
                request.SourceMonitoringConfig.VideoMonitoringSettings = requestSourceMonitoringConfig_sourceMonitoringConfig_VideoMonitoringSetting;
                requestSourceMonitoringConfigIsNull = false;
            }
             // determine if request.SourceMonitoringConfig should be set to null
            if (requestSourceMonitoringConfigIsNull)
            {
                request.SourceMonitoringConfig = null;
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
        
        private Amazon.MediaConnect.Model.UpdateFlowResponse CallAWSServiceOperation(IAmazonMediaConnect client, Amazon.MediaConnect.Model.UpdateFlowRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaConnect", "UpdateFlow");
            try
            {
                #if DESKTOP
                return client.UpdateFlow(request);
                #elif CORECLR
                return client.UpdateFlowAsync(request).GetAwaiter().GetResult();
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
            public System.String FlowArn { get; set; }
            public Amazon.MediaConnect.MaintenanceDay Maintenance_MaintenanceDay { get; set; }
            public System.String Maintenance_MaintenanceScheduledDate { get; set; }
            public System.String Maintenance_MaintenanceStartHour { get; set; }
            public Amazon.MediaConnect.FailoverMode SourceFailoverConfig_FailoverMode { get; set; }
            public System.Int32? SourceFailoverConfig_RecoveryWindow { get; set; }
            public System.String SourcePriority_PrimarySource { get; set; }
            public Amazon.MediaConnect.State SourceFailoverConfig_State { get; set; }
            public List<Amazon.MediaConnect.Model.AudioMonitoringSetting> SourceMonitoringConfig_AudioMonitoringSetting { get; set; }
            public Amazon.MediaConnect.ContentQualityAnalysisState SourceMonitoringConfig_ContentQualityAnalysisState { get; set; }
            public Amazon.MediaConnect.ThumbnailState SourceMonitoringConfig_ThumbnailState { get; set; }
            public List<Amazon.MediaConnect.Model.VideoMonitoringSetting> SourceMonitoringConfig_VideoMonitoringSetting { get; set; }
            public System.Func<Amazon.MediaConnect.Model.UpdateFlowResponse, UpdateEMCNFlowCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Flow;
        }
        
    }
}
