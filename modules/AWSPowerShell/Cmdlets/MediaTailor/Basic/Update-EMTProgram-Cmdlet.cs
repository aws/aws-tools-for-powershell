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
using Amazon.MediaTailor;
using Amazon.MediaTailor.Model;

namespace Amazon.PowerShell.Cmdlets.EMT
{
    /// <summary>
    /// Updates a program within a channel.
    /// </summary>
    [Cmdlet("Update", "EMTProgram", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaTailor.Model.UpdateProgramResponse")]
    [AWSCmdlet("Calls the AWS Elemental MediaTailor UpdateProgram API operation.", Operation = new[] {"UpdateProgram"}, SelectReturnType = typeof(Amazon.MediaTailor.Model.UpdateProgramResponse))]
    [AWSCmdletOutput("Amazon.MediaTailor.Model.UpdateProgramResponse",
        "This cmdlet returns an Amazon.MediaTailor.Model.UpdateProgramResponse object containing multiple properties."
    )]
    public partial class UpdateEMTProgramCmdlet : AmazonMediaTailorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AdBreak
        /// <summary>
        /// <para>
        /// <para>The ad break configuration settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdBreaks")]
        public Amazon.MediaTailor.Model.AdBreak[] AdBreak { get; set; }
        #endregion
        
        #region Parameter AudienceMedia
        /// <summary>
        /// <para>
        /// <para>The list of AudienceMedia defined in program.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.MediaTailor.Model.AudienceMedia[] AudienceMedia { get; set; }
        #endregion
        
        #region Parameter ChannelName
        /// <summary>
        /// <para>
        /// <para>The name of the channel for this Program.</para>
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
        public System.String ChannelName { get; set; }
        #endregion
        
        #region Parameter Transition_DurationMilli
        /// <summary>
        /// <para>
        /// <para>The duration of the live program in seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ScheduleConfiguration_Transition_DurationMillis")]
        public System.Int64? Transition_DurationMilli { get; set; }
        #endregion
        
        #region Parameter ClipRange_EndOffsetMilli
        /// <summary>
        /// <para>
        /// <para>The end offset of the clip range, in milliseconds, starting from the beginning of
        /// the VOD source associated with the program.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ScheduleConfiguration_ClipRange_EndOffsetMillis")]
        public System.Int64? ClipRange_EndOffsetMilli { get; set; }
        #endregion
        
        #region Parameter ProgramName
        /// <summary>
        /// <para>
        /// <para>The name of the Program.</para>
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
        public System.String ProgramName { get; set; }
        #endregion
        
        #region Parameter Transition_ScheduledStartTimeMilli
        /// <summary>
        /// <para>
        /// <para>The date and time that the program is scheduled to start, in epoch milliseconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ScheduleConfiguration_Transition_ScheduledStartTimeMillis")]
        public System.Int64? Transition_ScheduledStartTimeMilli { get; set; }
        #endregion
        
        #region Parameter ClipRange_StartOffsetMilli
        /// <summary>
        /// <para>
        /// <para>The start offset of the clip range, in milliseconds. This offset truncates the start
        /// at the number of milliseconds into the duration of the VOD source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ScheduleConfiguration_ClipRange_StartOffsetMillis")]
        public System.Int64? ClipRange_StartOffsetMilli { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaTailor.Model.UpdateProgramResponse).
        /// Specifying the name of a property of type Amazon.MediaTailor.Model.UpdateProgramResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EMTProgram (UpdateProgram)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaTailor.Model.UpdateProgramResponse, UpdateEMTProgramCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AdBreak != null)
            {
                context.AdBreak = new List<Amazon.MediaTailor.Model.AdBreak>(this.AdBreak);
            }
            if (this.AudienceMedia != null)
            {
                context.AudienceMedia = new List<Amazon.MediaTailor.Model.AudienceMedia>(this.AudienceMedia);
            }
            context.ChannelName = this.ChannelName;
            #if MODULAR
            if (this.ChannelName == null && ParameterWasBound(nameof(this.ChannelName)))
            {
                WriteWarning("You are passing $null as a value for parameter ChannelName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProgramName = this.ProgramName;
            #if MODULAR
            if (this.ProgramName == null && ParameterWasBound(nameof(this.ProgramName)))
            {
                WriteWarning("You are passing $null as a value for parameter ProgramName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClipRange_EndOffsetMilli = this.ClipRange_EndOffsetMilli;
            context.ClipRange_StartOffsetMilli = this.ClipRange_StartOffsetMilli;
            context.Transition_DurationMilli = this.Transition_DurationMilli;
            context.Transition_ScheduledStartTimeMilli = this.Transition_ScheduledStartTimeMilli;
            
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
            var request = new Amazon.MediaTailor.Model.UpdateProgramRequest();
            
            if (cmdletContext.AdBreak != null)
            {
                request.AdBreaks = cmdletContext.AdBreak;
            }
            if (cmdletContext.AudienceMedia != null)
            {
                request.AudienceMedia = cmdletContext.AudienceMedia;
            }
            if (cmdletContext.ChannelName != null)
            {
                request.ChannelName = cmdletContext.ChannelName;
            }
            if (cmdletContext.ProgramName != null)
            {
                request.ProgramName = cmdletContext.ProgramName;
            }
            
             // populate ScheduleConfiguration
            var requestScheduleConfigurationIsNull = true;
            request.ScheduleConfiguration = new Amazon.MediaTailor.Model.UpdateProgramScheduleConfiguration();
            Amazon.MediaTailor.Model.ClipRange requestScheduleConfiguration_scheduleConfiguration_ClipRange = null;
            
             // populate ClipRange
            var requestScheduleConfiguration_scheduleConfiguration_ClipRangeIsNull = true;
            requestScheduleConfiguration_scheduleConfiguration_ClipRange = new Amazon.MediaTailor.Model.ClipRange();
            System.Int64? requestScheduleConfiguration_scheduleConfiguration_ClipRange_clipRange_EndOffsetMilli = null;
            if (cmdletContext.ClipRange_EndOffsetMilli != null)
            {
                requestScheduleConfiguration_scheduleConfiguration_ClipRange_clipRange_EndOffsetMilli = cmdletContext.ClipRange_EndOffsetMilli.Value;
            }
            if (requestScheduleConfiguration_scheduleConfiguration_ClipRange_clipRange_EndOffsetMilli != null)
            {
                requestScheduleConfiguration_scheduleConfiguration_ClipRange.EndOffsetMillis = requestScheduleConfiguration_scheduleConfiguration_ClipRange_clipRange_EndOffsetMilli.Value;
                requestScheduleConfiguration_scheduleConfiguration_ClipRangeIsNull = false;
            }
            System.Int64? requestScheduleConfiguration_scheduleConfiguration_ClipRange_clipRange_StartOffsetMilli = null;
            if (cmdletContext.ClipRange_StartOffsetMilli != null)
            {
                requestScheduleConfiguration_scheduleConfiguration_ClipRange_clipRange_StartOffsetMilli = cmdletContext.ClipRange_StartOffsetMilli.Value;
            }
            if (requestScheduleConfiguration_scheduleConfiguration_ClipRange_clipRange_StartOffsetMilli != null)
            {
                requestScheduleConfiguration_scheduleConfiguration_ClipRange.StartOffsetMillis = requestScheduleConfiguration_scheduleConfiguration_ClipRange_clipRange_StartOffsetMilli.Value;
                requestScheduleConfiguration_scheduleConfiguration_ClipRangeIsNull = false;
            }
             // determine if requestScheduleConfiguration_scheduleConfiguration_ClipRange should be set to null
            if (requestScheduleConfiguration_scheduleConfiguration_ClipRangeIsNull)
            {
                requestScheduleConfiguration_scheduleConfiguration_ClipRange = null;
            }
            if (requestScheduleConfiguration_scheduleConfiguration_ClipRange != null)
            {
                request.ScheduleConfiguration.ClipRange = requestScheduleConfiguration_scheduleConfiguration_ClipRange;
                requestScheduleConfigurationIsNull = false;
            }
            Amazon.MediaTailor.Model.UpdateProgramTransition requestScheduleConfiguration_scheduleConfiguration_Transition = null;
            
             // populate Transition
            var requestScheduleConfiguration_scheduleConfiguration_TransitionIsNull = true;
            requestScheduleConfiguration_scheduleConfiguration_Transition = new Amazon.MediaTailor.Model.UpdateProgramTransition();
            System.Int64? requestScheduleConfiguration_scheduleConfiguration_Transition_transition_DurationMilli = null;
            if (cmdletContext.Transition_DurationMilli != null)
            {
                requestScheduleConfiguration_scheduleConfiguration_Transition_transition_DurationMilli = cmdletContext.Transition_DurationMilli.Value;
            }
            if (requestScheduleConfiguration_scheduleConfiguration_Transition_transition_DurationMilli != null)
            {
                requestScheduleConfiguration_scheduleConfiguration_Transition.DurationMillis = requestScheduleConfiguration_scheduleConfiguration_Transition_transition_DurationMilli.Value;
                requestScheduleConfiguration_scheduleConfiguration_TransitionIsNull = false;
            }
            System.Int64? requestScheduleConfiguration_scheduleConfiguration_Transition_transition_ScheduledStartTimeMilli = null;
            if (cmdletContext.Transition_ScheduledStartTimeMilli != null)
            {
                requestScheduleConfiguration_scheduleConfiguration_Transition_transition_ScheduledStartTimeMilli = cmdletContext.Transition_ScheduledStartTimeMilli.Value;
            }
            if (requestScheduleConfiguration_scheduleConfiguration_Transition_transition_ScheduledStartTimeMilli != null)
            {
                requestScheduleConfiguration_scheduleConfiguration_Transition.ScheduledStartTimeMillis = requestScheduleConfiguration_scheduleConfiguration_Transition_transition_ScheduledStartTimeMilli.Value;
                requestScheduleConfiguration_scheduleConfiguration_TransitionIsNull = false;
            }
             // determine if requestScheduleConfiguration_scheduleConfiguration_Transition should be set to null
            if (requestScheduleConfiguration_scheduleConfiguration_TransitionIsNull)
            {
                requestScheduleConfiguration_scheduleConfiguration_Transition = null;
            }
            if (requestScheduleConfiguration_scheduleConfiguration_Transition != null)
            {
                request.ScheduleConfiguration.Transition = requestScheduleConfiguration_scheduleConfiguration_Transition;
                requestScheduleConfigurationIsNull = false;
            }
             // determine if request.ScheduleConfiguration should be set to null
            if (requestScheduleConfigurationIsNull)
            {
                request.ScheduleConfiguration = null;
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
        
        private Amazon.MediaTailor.Model.UpdateProgramResponse CallAWSServiceOperation(IAmazonMediaTailor client, Amazon.MediaTailor.Model.UpdateProgramRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaTailor", "UpdateProgram");
            try
            {
                return client.UpdateProgramAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.MediaTailor.Model.AdBreak> AdBreak { get; set; }
            public List<Amazon.MediaTailor.Model.AudienceMedia> AudienceMedia { get; set; }
            public System.String ChannelName { get; set; }
            public System.String ProgramName { get; set; }
            public System.Int64? ClipRange_EndOffsetMilli { get; set; }
            public System.Int64? ClipRange_StartOffsetMilli { get; set; }
            public System.Int64? Transition_DurationMilli { get; set; }
            public System.Int64? Transition_ScheduledStartTimeMilli { get; set; }
            public System.Func<Amazon.MediaTailor.Model.UpdateProgramResponse, UpdateEMTProgramCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
