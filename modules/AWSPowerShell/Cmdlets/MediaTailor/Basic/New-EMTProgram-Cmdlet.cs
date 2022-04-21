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
using Amazon.MediaTailor;
using Amazon.MediaTailor.Model;

namespace Amazon.PowerShell.Cmdlets.EMT
{
    /// <summary>
    /// Creates a program.
    /// </summary>
    [Cmdlet("New", "EMTProgram", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaTailor.Model.CreateProgramResponse")]
    [AWSCmdlet("Calls the AWS Elemental MediaTailor CreateProgram API operation.", Operation = new[] {"CreateProgram"}, SelectReturnType = typeof(Amazon.MediaTailor.Model.CreateProgramResponse))]
    [AWSCmdletOutput("Amazon.MediaTailor.Model.CreateProgramResponse",
        "This cmdlet returns an Amazon.MediaTailor.Model.CreateProgramResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEMTProgramCmdlet : AmazonMediaTailorClientCmdlet, IExecutor
    {
        
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
        
        #region Parameter ChannelName
        /// <summary>
        /// <para>
        /// <para>The identifier for the channel you are working on.</para>
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
        
        #region Parameter LiveSourceName
        /// <summary>
        /// <para>
        /// <para>The name of the LiveSource for this Program.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LiveSourceName { get; set; }
        #endregion
        
        #region Parameter ProgramName
        /// <summary>
        /// <para>
        /// <para>The identifier for the program you are working on.</para>
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
        
        #region Parameter Transition_RelativePosition
        /// <summary>
        /// <para>
        /// <para>The position where this program will be inserted relative to the RelativePosition.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ScheduleConfiguration_Transition_RelativePosition")]
        [AWSConstantClassSource("Amazon.MediaTailor.RelativePosition")]
        public Amazon.MediaTailor.RelativePosition Transition_RelativePosition { get; set; }
        #endregion
        
        #region Parameter Transition_RelativeProgram
        /// <summary>
        /// <para>
        /// <para>The name of the program that this program will be inserted next to, as defined by
        /// RelativePosition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ScheduleConfiguration_Transition_RelativeProgram")]
        public System.String Transition_RelativeProgram { get; set; }
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
        
        #region Parameter SourceLocationName
        /// <summary>
        /// <para>
        /// <para>The name of the source location.</para>
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
        public System.String SourceLocationName { get; set; }
        #endregion
        
        #region Parameter Transition_Type
        /// <summary>
        /// <para>
        /// <para>Defines when the program plays in the schedule. You can set the value to ABSOLUTE
        /// or RELATIVE.</para><para>ABSOLUTE - The program plays at a specific wall clock time. This setting can only
        /// be used for channels using the LINEAR PlaybackMode.</para><para>Note the following considerations when using ABSOLUTE transitions:</para><para>If the preceding program in the schedule has a duration that extends past the wall
        /// clock time, MediaTailor truncates the preceding program on a common segment boundary.</para><para>If there are gaps in playback, MediaTailor plays the FillerSlate you configured for
        /// your linear channel.</para><para>RELATIVE - The program is inserted into the schedule either before or after a program
        /// that you specify via RelativePosition.</para>
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
        [Alias("ScheduleConfiguration_Transition_Type")]
        public System.String Transition_Type { get; set; }
        #endregion
        
        #region Parameter VodSourceName
        /// <summary>
        /// <para>
        /// <para>The name that's used to refer to a VOD source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VodSourceName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaTailor.Model.CreateProgramResponse).
        /// Specifying the name of a property of type Amazon.MediaTailor.Model.CreateProgramResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EMTProgram (CreateProgram)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaTailor.Model.CreateProgramResponse, NewEMTProgramCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AdBreak != null)
            {
                context.AdBreak = new List<Amazon.MediaTailor.Model.AdBreak>(this.AdBreak);
            }
            context.ChannelName = this.ChannelName;
            #if MODULAR
            if (this.ChannelName == null && ParameterWasBound(nameof(this.ChannelName)))
            {
                WriteWarning("You are passing $null as a value for parameter ChannelName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LiveSourceName = this.LiveSourceName;
            context.ProgramName = this.ProgramName;
            #if MODULAR
            if (this.ProgramName == null && ParameterWasBound(nameof(this.ProgramName)))
            {
                WriteWarning("You are passing $null as a value for parameter ProgramName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Transition_DurationMilli = this.Transition_DurationMilli;
            context.Transition_RelativePosition = this.Transition_RelativePosition;
            #if MODULAR
            if (this.Transition_RelativePosition == null && ParameterWasBound(nameof(this.Transition_RelativePosition)))
            {
                WriteWarning("You are passing $null as a value for parameter Transition_RelativePosition which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Transition_RelativeProgram = this.Transition_RelativeProgram;
            context.Transition_ScheduledStartTimeMilli = this.Transition_ScheduledStartTimeMilli;
            context.Transition_Type = this.Transition_Type;
            #if MODULAR
            if (this.Transition_Type == null && ParameterWasBound(nameof(this.Transition_Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Transition_Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceLocationName = this.SourceLocationName;
            #if MODULAR
            if (this.SourceLocationName == null && ParameterWasBound(nameof(this.SourceLocationName)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceLocationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VodSourceName = this.VodSourceName;
            
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
            var request = new Amazon.MediaTailor.Model.CreateProgramRequest();
            
            if (cmdletContext.AdBreak != null)
            {
                request.AdBreaks = cmdletContext.AdBreak;
            }
            if (cmdletContext.ChannelName != null)
            {
                request.ChannelName = cmdletContext.ChannelName;
            }
            if (cmdletContext.LiveSourceName != null)
            {
                request.LiveSourceName = cmdletContext.LiveSourceName;
            }
            if (cmdletContext.ProgramName != null)
            {
                request.ProgramName = cmdletContext.ProgramName;
            }
            
             // populate ScheduleConfiguration
            var requestScheduleConfigurationIsNull = true;
            request.ScheduleConfiguration = new Amazon.MediaTailor.Model.ScheduleConfiguration();
            Amazon.MediaTailor.Model.Transition requestScheduleConfiguration_scheduleConfiguration_Transition = null;
            
             // populate Transition
            var requestScheduleConfiguration_scheduleConfiguration_TransitionIsNull = true;
            requestScheduleConfiguration_scheduleConfiguration_Transition = new Amazon.MediaTailor.Model.Transition();
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
            Amazon.MediaTailor.RelativePosition requestScheduleConfiguration_scheduleConfiguration_Transition_transition_RelativePosition = null;
            if (cmdletContext.Transition_RelativePosition != null)
            {
                requestScheduleConfiguration_scheduleConfiguration_Transition_transition_RelativePosition = cmdletContext.Transition_RelativePosition;
            }
            if (requestScheduleConfiguration_scheduleConfiguration_Transition_transition_RelativePosition != null)
            {
                requestScheduleConfiguration_scheduleConfiguration_Transition.RelativePosition = requestScheduleConfiguration_scheduleConfiguration_Transition_transition_RelativePosition;
                requestScheduleConfiguration_scheduleConfiguration_TransitionIsNull = false;
            }
            System.String requestScheduleConfiguration_scheduleConfiguration_Transition_transition_RelativeProgram = null;
            if (cmdletContext.Transition_RelativeProgram != null)
            {
                requestScheduleConfiguration_scheduleConfiguration_Transition_transition_RelativeProgram = cmdletContext.Transition_RelativeProgram;
            }
            if (requestScheduleConfiguration_scheduleConfiguration_Transition_transition_RelativeProgram != null)
            {
                requestScheduleConfiguration_scheduleConfiguration_Transition.RelativeProgram = requestScheduleConfiguration_scheduleConfiguration_Transition_transition_RelativeProgram;
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
            System.String requestScheduleConfiguration_scheduleConfiguration_Transition_transition_Type = null;
            if (cmdletContext.Transition_Type != null)
            {
                requestScheduleConfiguration_scheduleConfiguration_Transition_transition_Type = cmdletContext.Transition_Type;
            }
            if (requestScheduleConfiguration_scheduleConfiguration_Transition_transition_Type != null)
            {
                requestScheduleConfiguration_scheduleConfiguration_Transition.Type = requestScheduleConfiguration_scheduleConfiguration_Transition_transition_Type;
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
            if (cmdletContext.SourceLocationName != null)
            {
                request.SourceLocationName = cmdletContext.SourceLocationName;
            }
            if (cmdletContext.VodSourceName != null)
            {
                request.VodSourceName = cmdletContext.VodSourceName;
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
        
        private Amazon.MediaTailor.Model.CreateProgramResponse CallAWSServiceOperation(IAmazonMediaTailor client, Amazon.MediaTailor.Model.CreateProgramRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaTailor", "CreateProgram");
            try
            {
                #if DESKTOP
                return client.CreateProgram(request);
                #elif CORECLR
                return client.CreateProgramAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.MediaTailor.Model.AdBreak> AdBreak { get; set; }
            public System.String ChannelName { get; set; }
            public System.String LiveSourceName { get; set; }
            public System.String ProgramName { get; set; }
            public System.Int64? Transition_DurationMilli { get; set; }
            public Amazon.MediaTailor.RelativePosition Transition_RelativePosition { get; set; }
            public System.String Transition_RelativeProgram { get; set; }
            public System.Int64? Transition_ScheduledStartTimeMilli { get; set; }
            public System.String Transition_Type { get; set; }
            public System.String SourceLocationName { get; set; }
            public System.String VodSourceName { get; set; }
            public System.Func<Amazon.MediaTailor.Model.CreateProgramResponse, NewEMTProgramCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
