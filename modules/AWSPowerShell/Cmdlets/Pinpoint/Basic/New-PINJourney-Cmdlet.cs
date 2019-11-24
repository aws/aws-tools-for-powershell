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
using Amazon.Pinpoint;
using Amazon.Pinpoint.Model;

namespace Amazon.PowerShell.Cmdlets.PIN
{
    /// <summary>
    /// Creates a journey for an application.
    /// </summary>
    [Cmdlet("New", "PINJourney", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.JourneyResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint CreateJourney API operation.", Operation = new[] {"CreateJourney"}, SelectReturnType = typeof(Amazon.Pinpoint.Model.CreateJourneyResponse))]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.JourneyResponse or Amazon.Pinpoint.Model.CreateJourneyResponse",
        "This cmdlet returns an Amazon.Pinpoint.Model.JourneyResponse object.",
        "The service call response (type Amazon.Pinpoint.Model.CreateJourneyResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewPINJourneyCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
        #region Parameter WriteJourneyRequest_Activity
        /// <summary>
        /// <para>
        /// <para>The configuration and other settings for the activities that comprise the journey.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteJourneyRequest_Activities")]
        public System.Collections.Hashtable WriteJourneyRequest_Activity { get; set; }
        #endregion
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the application. This identifier is displayed as the <b>Project
        /// ID</b> on the Amazon Pinpoint console.</para>
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
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter WriteJourneyRequest_CreationDate
        /// <summary>
        /// <para>
        /// <para>The date, in ISO 8601 format, when the journey was created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WriteJourneyRequest_CreationDate { get; set; }
        #endregion
        
        #region Parameter Limits_DailyCap
        /// <summary>
        /// <para>
        /// <para>The maximum number of messages that the journey can send to a single participant during
        /// a 24-hour period. The maximum value is 100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteJourneyRequest_Limits_DailyCap")]
        public System.Int32? Limits_DailyCap { get; set; }
        #endregion
        
        #region Parameter StartCondition_Description
        /// <summary>
        /// <para>
        /// <para>The custom description of the condition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteJourneyRequest_StartCondition_Description")]
        public System.String StartCondition_Description { get; set; }
        #endregion
        
        #region Parameter QuietTime_End
        /// <summary>
        /// <para>
        /// <para>The specific time when quiet time ends. This value has to use 24-hour notation and
        /// be in HH:MM format, where HH is the hour (with a leading zero, if applicable) and
        /// MM is the minutes. For example, use 02:30 to represent 2:30 AM, or 14:30 to represent
        /// 2:30 PM.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteJourneyRequest_QuietTime_End")]
        public System.String QuietTime_End { get; set; }
        #endregion
        
        #region Parameter Limits_EndpointReentryCap
        /// <summary>
        /// <para>
        /// <para>The maximum number of times that a participant can enter the journey. The maximum
        /// value is 100. To allow participants to enter the journey an unlimited number of times,
        /// set this value to 0.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteJourneyRequest_Limits_EndpointReentryCap")]
        public System.Int32? Limits_EndpointReentryCap { get; set; }
        #endregion
        
        #region Parameter Schedule_EndTime
        /// <summary>
        /// <para>
        /// <para>The scheduled time, in ISO 8601 format, when the journey ended or will end.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteJourneyRequest_Schedule_EndTime")]
        public System.DateTime? Schedule_EndTime { get; set; }
        #endregion
        
        #region Parameter WriteJourneyRequest_LastModifiedDate
        /// <summary>
        /// <para>
        /// <para>The date, in ISO 8601 format, when the journey was last modified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WriteJourneyRequest_LastModifiedDate { get; set; }
        #endregion
        
        #region Parameter WriteJourneyRequest_LocalTime
        /// <summary>
        /// <para>
        /// <para>Specifies whether the journey's scheduled start and end times use each participant's
        /// local time. To base the schedule on each participant's local time, set this value
        /// to true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? WriteJourneyRequest_LocalTime { get; set; }
        #endregion
        
        #region Parameter Limits_MessagesPerSecond
        /// <summary>
        /// <para>
        /// <para>The maximum number of messages that the journey can send each second.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteJourneyRequest_Limits_MessagesPerSecond")]
        public System.Int32? Limits_MessagesPerSecond { get; set; }
        #endregion
        
        #region Parameter WriteJourneyRequest_Name
        /// <summary>
        /// <para>
        /// <para>The name of the journey. A journey name can contain a maximum of 150 characters. The
        /// characters can be alphanumeric characters or symbols, such as underscores (_) or hyphens
        /// (-). A journey name can't contain any spaces.</para>
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
        public System.String WriteJourneyRequest_Name { get; set; }
        #endregion
        
        #region Parameter WriteJourneyRequest_RefreshFrequency
        /// <summary>
        /// <para>
        /// <para>The frequency with which Amazon Pinpoint evaluates segment and event data for the
        /// journey, as a duration in ISO 8601 format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WriteJourneyRequest_RefreshFrequency { get; set; }
        #endregion
        
        #region Parameter SegmentStartCondition_SegmentId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the segment to associate with the activity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteJourneyRequest_StartCondition_SegmentStartCondition_SegmentId")]
        public System.String SegmentStartCondition_SegmentId { get; set; }
        #endregion
        
        #region Parameter QuietTime_Start
        /// <summary>
        /// <para>
        /// <para>The specific time when quiet time begins. This value has to use 24-hour notation and
        /// be in HH:MM format, where HH is the hour (with a leading zero, if applicable) and
        /// MM is the minutes. For example, use 02:30 to represent 2:30 AM, or 14:30 to represent
        /// 2:30 PM.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteJourneyRequest_QuietTime_Start")]
        public System.String QuietTime_Start { get; set; }
        #endregion
        
        #region Parameter WriteJourneyRequest_StartActivity
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the first activity in the journey.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WriteJourneyRequest_StartActivity { get; set; }
        #endregion
        
        #region Parameter Schedule_StartTime
        /// <summary>
        /// <para>
        /// <para>The scheduled time, in ISO 8601 format, when the journey began or will begin.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteJourneyRequest_Schedule_StartTime")]
        public System.DateTime? Schedule_StartTime { get; set; }
        #endregion
        
        #region Parameter WriteJourneyRequest_State
        /// <summary>
        /// <para>
        /// <para>The status of the journey. Valid values are:</para><ul><li><para>DRAFT - Saves the journey and doesn't publish it.</para></li><li><para>ACTIVE - Saves and publishes the journey. Depending on the journey's schedule, the
        /// journey starts running immediately or at the scheduled start time. If a journey's
        /// status is ACTIVE, you can't add, change, or remove activities from it.</para></li></ul><para>The CANCELLED, COMPLETED, and CLOSED values are not supported in requests to create
        /// or update a journey. To cancel a journey, use the <link linkend="apps-application-id-journeys-journey-id-state">Journey
        /// State</link> resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Pinpoint.State")]
        public Amazon.Pinpoint.State WriteJourneyRequest_State { get; set; }
        #endregion
        
        #region Parameter Schedule_Timezone
        /// <summary>
        /// <para>
        /// <para>The starting UTC offset for the journey schedule, if the value of the journey's LocalTime
        /// property is true. Valid values are: UTC,                  UTC+01, UTC+02, UTC+03,
        /// UTC+03:30, UTC+04, UTC+04:30, UTC+05, UTC+05:30,                  UTC+05:45, UTC+06,
        /// UTC+06:30, UTC+07, UTC+08, UTC+08:45, UTC+09, UTC+09:30,                  UTC+10,
        /// UTC+10:30, UTC+11, UTC+12, UTC+12:45, UTC+13, UTC+13:45, UTC-02,                 
        /// UTC-02:30, UTC-03, UTC-03:30, UTC-04, UTC-05, UTC-06, UTC-07, UTC-08, UTC-09,    
        ///              UTC-09:30, UTC-10, and UTC-11.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteJourneyRequest_Schedule_Timezone")]
        public System.String Schedule_Timezone { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'JourneyResponse'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Pinpoint.Model.CreateJourneyResponse).
        /// Specifying the name of a property of type Amazon.Pinpoint.Model.CreateJourneyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "JourneyResponse";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ApplicationId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ApplicationId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ApplicationId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PINJourney (CreateJourney)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Pinpoint.Model.CreateJourneyResponse, NewPINJourneyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ApplicationId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.WriteJourneyRequest_Activity != null)
            {
                context.WriteJourneyRequest_Activity = new Dictionary<System.String, Amazon.Pinpoint.Model.Activity>(StringComparer.Ordinal);
                foreach (var hashKey in this.WriteJourneyRequest_Activity.Keys)
                {
                    context.WriteJourneyRequest_Activity.Add((String)hashKey, (Activity)(this.WriteJourneyRequest_Activity[hashKey]));
                }
            }
            context.WriteJourneyRequest_CreationDate = this.WriteJourneyRequest_CreationDate;
            context.WriteJourneyRequest_LastModifiedDate = this.WriteJourneyRequest_LastModifiedDate;
            context.Limits_DailyCap = this.Limits_DailyCap;
            context.Limits_EndpointReentryCap = this.Limits_EndpointReentryCap;
            context.Limits_MessagesPerSecond = this.Limits_MessagesPerSecond;
            context.WriteJourneyRequest_LocalTime = this.WriteJourneyRequest_LocalTime;
            context.WriteJourneyRequest_Name = this.WriteJourneyRequest_Name;
            #if MODULAR
            if (this.WriteJourneyRequest_Name == null && ParameterWasBound(nameof(this.WriteJourneyRequest_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter WriteJourneyRequest_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.QuietTime_End = this.QuietTime_End;
            context.QuietTime_Start = this.QuietTime_Start;
            context.WriteJourneyRequest_RefreshFrequency = this.WriteJourneyRequest_RefreshFrequency;
            context.Schedule_EndTime = this.Schedule_EndTime;
            context.Schedule_StartTime = this.Schedule_StartTime;
            context.Schedule_Timezone = this.Schedule_Timezone;
            context.WriteJourneyRequest_StartActivity = this.WriteJourneyRequest_StartActivity;
            context.StartCondition_Description = this.StartCondition_Description;
            context.SegmentStartCondition_SegmentId = this.SegmentStartCondition_SegmentId;
            context.WriteJourneyRequest_State = this.WriteJourneyRequest_State;
            
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
            var request = new Amazon.Pinpoint.Model.CreateJourneyRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            
             // populate WriteJourneyRequest
            var requestWriteJourneyRequestIsNull = true;
            request.WriteJourneyRequest = new Amazon.Pinpoint.Model.WriteJourneyRequest();
            Dictionary<System.String, Amazon.Pinpoint.Model.Activity> requestWriteJourneyRequest_writeJourneyRequest_Activity = null;
            if (cmdletContext.WriteJourneyRequest_Activity != null)
            {
                requestWriteJourneyRequest_writeJourneyRequest_Activity = cmdletContext.WriteJourneyRequest_Activity;
            }
            if (requestWriteJourneyRequest_writeJourneyRequest_Activity != null)
            {
                request.WriteJourneyRequest.Activities = requestWriteJourneyRequest_writeJourneyRequest_Activity;
                requestWriteJourneyRequestIsNull = false;
            }
            System.String requestWriteJourneyRequest_writeJourneyRequest_CreationDate = null;
            if (cmdletContext.WriteJourneyRequest_CreationDate != null)
            {
                requestWriteJourneyRequest_writeJourneyRequest_CreationDate = cmdletContext.WriteJourneyRequest_CreationDate;
            }
            if (requestWriteJourneyRequest_writeJourneyRequest_CreationDate != null)
            {
                request.WriteJourneyRequest.CreationDate = requestWriteJourneyRequest_writeJourneyRequest_CreationDate;
                requestWriteJourneyRequestIsNull = false;
            }
            System.String requestWriteJourneyRequest_writeJourneyRequest_LastModifiedDate = null;
            if (cmdletContext.WriteJourneyRequest_LastModifiedDate != null)
            {
                requestWriteJourneyRequest_writeJourneyRequest_LastModifiedDate = cmdletContext.WriteJourneyRequest_LastModifiedDate;
            }
            if (requestWriteJourneyRequest_writeJourneyRequest_LastModifiedDate != null)
            {
                request.WriteJourneyRequest.LastModifiedDate = requestWriteJourneyRequest_writeJourneyRequest_LastModifiedDate;
                requestWriteJourneyRequestIsNull = false;
            }
            System.Boolean? requestWriteJourneyRequest_writeJourneyRequest_LocalTime = null;
            if (cmdletContext.WriteJourneyRequest_LocalTime != null)
            {
                requestWriteJourneyRequest_writeJourneyRequest_LocalTime = cmdletContext.WriteJourneyRequest_LocalTime.Value;
            }
            if (requestWriteJourneyRequest_writeJourneyRequest_LocalTime != null)
            {
                request.WriteJourneyRequest.LocalTime = requestWriteJourneyRequest_writeJourneyRequest_LocalTime.Value;
                requestWriteJourneyRequestIsNull = false;
            }
            System.String requestWriteJourneyRequest_writeJourneyRequest_Name = null;
            if (cmdletContext.WriteJourneyRequest_Name != null)
            {
                requestWriteJourneyRequest_writeJourneyRequest_Name = cmdletContext.WriteJourneyRequest_Name;
            }
            if (requestWriteJourneyRequest_writeJourneyRequest_Name != null)
            {
                request.WriteJourneyRequest.Name = requestWriteJourneyRequest_writeJourneyRequest_Name;
                requestWriteJourneyRequestIsNull = false;
            }
            System.String requestWriteJourneyRequest_writeJourneyRequest_RefreshFrequency = null;
            if (cmdletContext.WriteJourneyRequest_RefreshFrequency != null)
            {
                requestWriteJourneyRequest_writeJourneyRequest_RefreshFrequency = cmdletContext.WriteJourneyRequest_RefreshFrequency;
            }
            if (requestWriteJourneyRequest_writeJourneyRequest_RefreshFrequency != null)
            {
                request.WriteJourneyRequest.RefreshFrequency = requestWriteJourneyRequest_writeJourneyRequest_RefreshFrequency;
                requestWriteJourneyRequestIsNull = false;
            }
            System.String requestWriteJourneyRequest_writeJourneyRequest_StartActivity = null;
            if (cmdletContext.WriteJourneyRequest_StartActivity != null)
            {
                requestWriteJourneyRequest_writeJourneyRequest_StartActivity = cmdletContext.WriteJourneyRequest_StartActivity;
            }
            if (requestWriteJourneyRequest_writeJourneyRequest_StartActivity != null)
            {
                request.WriteJourneyRequest.StartActivity = requestWriteJourneyRequest_writeJourneyRequest_StartActivity;
                requestWriteJourneyRequestIsNull = false;
            }
            Amazon.Pinpoint.State requestWriteJourneyRequest_writeJourneyRequest_State = null;
            if (cmdletContext.WriteJourneyRequest_State != null)
            {
                requestWriteJourneyRequest_writeJourneyRequest_State = cmdletContext.WriteJourneyRequest_State;
            }
            if (requestWriteJourneyRequest_writeJourneyRequest_State != null)
            {
                request.WriteJourneyRequest.State = requestWriteJourneyRequest_writeJourneyRequest_State;
                requestWriteJourneyRequestIsNull = false;
            }
            Amazon.Pinpoint.Model.QuietTime requestWriteJourneyRequest_writeJourneyRequest_QuietTime = null;
            
             // populate QuietTime
            var requestWriteJourneyRequest_writeJourneyRequest_QuietTimeIsNull = true;
            requestWriteJourneyRequest_writeJourneyRequest_QuietTime = new Amazon.Pinpoint.Model.QuietTime();
            System.String requestWriteJourneyRequest_writeJourneyRequest_QuietTime_quietTime_End = null;
            if (cmdletContext.QuietTime_End != null)
            {
                requestWriteJourneyRequest_writeJourneyRequest_QuietTime_quietTime_End = cmdletContext.QuietTime_End;
            }
            if (requestWriteJourneyRequest_writeJourneyRequest_QuietTime_quietTime_End != null)
            {
                requestWriteJourneyRequest_writeJourneyRequest_QuietTime.End = requestWriteJourneyRequest_writeJourneyRequest_QuietTime_quietTime_End;
                requestWriteJourneyRequest_writeJourneyRequest_QuietTimeIsNull = false;
            }
            System.String requestWriteJourneyRequest_writeJourneyRequest_QuietTime_quietTime_Start = null;
            if (cmdletContext.QuietTime_Start != null)
            {
                requestWriteJourneyRequest_writeJourneyRequest_QuietTime_quietTime_Start = cmdletContext.QuietTime_Start;
            }
            if (requestWriteJourneyRequest_writeJourneyRequest_QuietTime_quietTime_Start != null)
            {
                requestWriteJourneyRequest_writeJourneyRequest_QuietTime.Start = requestWriteJourneyRequest_writeJourneyRequest_QuietTime_quietTime_Start;
                requestWriteJourneyRequest_writeJourneyRequest_QuietTimeIsNull = false;
            }
             // determine if requestWriteJourneyRequest_writeJourneyRequest_QuietTime should be set to null
            if (requestWriteJourneyRequest_writeJourneyRequest_QuietTimeIsNull)
            {
                requestWriteJourneyRequest_writeJourneyRequest_QuietTime = null;
            }
            if (requestWriteJourneyRequest_writeJourneyRequest_QuietTime != null)
            {
                request.WriteJourneyRequest.QuietTime = requestWriteJourneyRequest_writeJourneyRequest_QuietTime;
                requestWriteJourneyRequestIsNull = false;
            }
            Amazon.Pinpoint.Model.StartCondition requestWriteJourneyRequest_writeJourneyRequest_StartCondition = null;
            
             // populate StartCondition
            var requestWriteJourneyRequest_writeJourneyRequest_StartConditionIsNull = true;
            requestWriteJourneyRequest_writeJourneyRequest_StartCondition = new Amazon.Pinpoint.Model.StartCondition();
            System.String requestWriteJourneyRequest_writeJourneyRequest_StartCondition_startCondition_Description = null;
            if (cmdletContext.StartCondition_Description != null)
            {
                requestWriteJourneyRequest_writeJourneyRequest_StartCondition_startCondition_Description = cmdletContext.StartCondition_Description;
            }
            if (requestWriteJourneyRequest_writeJourneyRequest_StartCondition_startCondition_Description != null)
            {
                requestWriteJourneyRequest_writeJourneyRequest_StartCondition.Description = requestWriteJourneyRequest_writeJourneyRequest_StartCondition_startCondition_Description;
                requestWriteJourneyRequest_writeJourneyRequest_StartConditionIsNull = false;
            }
            Amazon.Pinpoint.Model.SegmentCondition requestWriteJourneyRequest_writeJourneyRequest_StartCondition_writeJourneyRequest_StartCondition_SegmentStartCondition = null;
            
             // populate SegmentStartCondition
            var requestWriteJourneyRequest_writeJourneyRequest_StartCondition_writeJourneyRequest_StartCondition_SegmentStartConditionIsNull = true;
            requestWriteJourneyRequest_writeJourneyRequest_StartCondition_writeJourneyRequest_StartCondition_SegmentStartCondition = new Amazon.Pinpoint.Model.SegmentCondition();
            System.String requestWriteJourneyRequest_writeJourneyRequest_StartCondition_writeJourneyRequest_StartCondition_SegmentStartCondition_segmentStartCondition_SegmentId = null;
            if (cmdletContext.SegmentStartCondition_SegmentId != null)
            {
                requestWriteJourneyRequest_writeJourneyRequest_StartCondition_writeJourneyRequest_StartCondition_SegmentStartCondition_segmentStartCondition_SegmentId = cmdletContext.SegmentStartCondition_SegmentId;
            }
            if (requestWriteJourneyRequest_writeJourneyRequest_StartCondition_writeJourneyRequest_StartCondition_SegmentStartCondition_segmentStartCondition_SegmentId != null)
            {
                requestWriteJourneyRequest_writeJourneyRequest_StartCondition_writeJourneyRequest_StartCondition_SegmentStartCondition.SegmentId = requestWriteJourneyRequest_writeJourneyRequest_StartCondition_writeJourneyRequest_StartCondition_SegmentStartCondition_segmentStartCondition_SegmentId;
                requestWriteJourneyRequest_writeJourneyRequest_StartCondition_writeJourneyRequest_StartCondition_SegmentStartConditionIsNull = false;
            }
             // determine if requestWriteJourneyRequest_writeJourneyRequest_StartCondition_writeJourneyRequest_StartCondition_SegmentStartCondition should be set to null
            if (requestWriteJourneyRequest_writeJourneyRequest_StartCondition_writeJourneyRequest_StartCondition_SegmentStartConditionIsNull)
            {
                requestWriteJourneyRequest_writeJourneyRequest_StartCondition_writeJourneyRequest_StartCondition_SegmentStartCondition = null;
            }
            if (requestWriteJourneyRequest_writeJourneyRequest_StartCondition_writeJourneyRequest_StartCondition_SegmentStartCondition != null)
            {
                requestWriteJourneyRequest_writeJourneyRequest_StartCondition.SegmentStartCondition = requestWriteJourneyRequest_writeJourneyRequest_StartCondition_writeJourneyRequest_StartCondition_SegmentStartCondition;
                requestWriteJourneyRequest_writeJourneyRequest_StartConditionIsNull = false;
            }
             // determine if requestWriteJourneyRequest_writeJourneyRequest_StartCondition should be set to null
            if (requestWriteJourneyRequest_writeJourneyRequest_StartConditionIsNull)
            {
                requestWriteJourneyRequest_writeJourneyRequest_StartCondition = null;
            }
            if (requestWriteJourneyRequest_writeJourneyRequest_StartCondition != null)
            {
                request.WriteJourneyRequest.StartCondition = requestWriteJourneyRequest_writeJourneyRequest_StartCondition;
                requestWriteJourneyRequestIsNull = false;
            }
            Amazon.Pinpoint.Model.JourneyLimits requestWriteJourneyRequest_writeJourneyRequest_Limits = null;
            
             // populate Limits
            var requestWriteJourneyRequest_writeJourneyRequest_LimitsIsNull = true;
            requestWriteJourneyRequest_writeJourneyRequest_Limits = new Amazon.Pinpoint.Model.JourneyLimits();
            System.Int32? requestWriteJourneyRequest_writeJourneyRequest_Limits_limits_DailyCap = null;
            if (cmdletContext.Limits_DailyCap != null)
            {
                requestWriteJourneyRequest_writeJourneyRequest_Limits_limits_DailyCap = cmdletContext.Limits_DailyCap.Value;
            }
            if (requestWriteJourneyRequest_writeJourneyRequest_Limits_limits_DailyCap != null)
            {
                requestWriteJourneyRequest_writeJourneyRequest_Limits.DailyCap = requestWriteJourneyRequest_writeJourneyRequest_Limits_limits_DailyCap.Value;
                requestWriteJourneyRequest_writeJourneyRequest_LimitsIsNull = false;
            }
            System.Int32? requestWriteJourneyRequest_writeJourneyRequest_Limits_limits_EndpointReentryCap = null;
            if (cmdletContext.Limits_EndpointReentryCap != null)
            {
                requestWriteJourneyRequest_writeJourneyRequest_Limits_limits_EndpointReentryCap = cmdletContext.Limits_EndpointReentryCap.Value;
            }
            if (requestWriteJourneyRequest_writeJourneyRequest_Limits_limits_EndpointReentryCap != null)
            {
                requestWriteJourneyRequest_writeJourneyRequest_Limits.EndpointReentryCap = requestWriteJourneyRequest_writeJourneyRequest_Limits_limits_EndpointReentryCap.Value;
                requestWriteJourneyRequest_writeJourneyRequest_LimitsIsNull = false;
            }
            System.Int32? requestWriteJourneyRequest_writeJourneyRequest_Limits_limits_MessagesPerSecond = null;
            if (cmdletContext.Limits_MessagesPerSecond != null)
            {
                requestWriteJourneyRequest_writeJourneyRequest_Limits_limits_MessagesPerSecond = cmdletContext.Limits_MessagesPerSecond.Value;
            }
            if (requestWriteJourneyRequest_writeJourneyRequest_Limits_limits_MessagesPerSecond != null)
            {
                requestWriteJourneyRequest_writeJourneyRequest_Limits.MessagesPerSecond = requestWriteJourneyRequest_writeJourneyRequest_Limits_limits_MessagesPerSecond.Value;
                requestWriteJourneyRequest_writeJourneyRequest_LimitsIsNull = false;
            }
             // determine if requestWriteJourneyRequest_writeJourneyRequest_Limits should be set to null
            if (requestWriteJourneyRequest_writeJourneyRequest_LimitsIsNull)
            {
                requestWriteJourneyRequest_writeJourneyRequest_Limits = null;
            }
            if (requestWriteJourneyRequest_writeJourneyRequest_Limits != null)
            {
                request.WriteJourneyRequest.Limits = requestWriteJourneyRequest_writeJourneyRequest_Limits;
                requestWriteJourneyRequestIsNull = false;
            }
            Amazon.Pinpoint.Model.JourneySchedule requestWriteJourneyRequest_writeJourneyRequest_Schedule = null;
            
             // populate Schedule
            var requestWriteJourneyRequest_writeJourneyRequest_ScheduleIsNull = true;
            requestWriteJourneyRequest_writeJourneyRequest_Schedule = new Amazon.Pinpoint.Model.JourneySchedule();
            System.DateTime? requestWriteJourneyRequest_writeJourneyRequest_Schedule_schedule_EndTime = null;
            if (cmdletContext.Schedule_EndTime != null)
            {
                requestWriteJourneyRequest_writeJourneyRequest_Schedule_schedule_EndTime = cmdletContext.Schedule_EndTime.Value;
            }
            if (requestWriteJourneyRequest_writeJourneyRequest_Schedule_schedule_EndTime != null)
            {
                requestWriteJourneyRequest_writeJourneyRequest_Schedule.EndTime = requestWriteJourneyRequest_writeJourneyRequest_Schedule_schedule_EndTime.Value;
                requestWriteJourneyRequest_writeJourneyRequest_ScheduleIsNull = false;
            }
            System.DateTime? requestWriteJourneyRequest_writeJourneyRequest_Schedule_schedule_StartTime = null;
            if (cmdletContext.Schedule_StartTime != null)
            {
                requestWriteJourneyRequest_writeJourneyRequest_Schedule_schedule_StartTime = cmdletContext.Schedule_StartTime.Value;
            }
            if (requestWriteJourneyRequest_writeJourneyRequest_Schedule_schedule_StartTime != null)
            {
                requestWriteJourneyRequest_writeJourneyRequest_Schedule.StartTime = requestWriteJourneyRequest_writeJourneyRequest_Schedule_schedule_StartTime.Value;
                requestWriteJourneyRequest_writeJourneyRequest_ScheduleIsNull = false;
            }
            System.String requestWriteJourneyRequest_writeJourneyRequest_Schedule_schedule_Timezone = null;
            if (cmdletContext.Schedule_Timezone != null)
            {
                requestWriteJourneyRequest_writeJourneyRequest_Schedule_schedule_Timezone = cmdletContext.Schedule_Timezone;
            }
            if (requestWriteJourneyRequest_writeJourneyRequest_Schedule_schedule_Timezone != null)
            {
                requestWriteJourneyRequest_writeJourneyRequest_Schedule.Timezone = requestWriteJourneyRequest_writeJourneyRequest_Schedule_schedule_Timezone;
                requestWriteJourneyRequest_writeJourneyRequest_ScheduleIsNull = false;
            }
             // determine if requestWriteJourneyRequest_writeJourneyRequest_Schedule should be set to null
            if (requestWriteJourneyRequest_writeJourneyRequest_ScheduleIsNull)
            {
                requestWriteJourneyRequest_writeJourneyRequest_Schedule = null;
            }
            if (requestWriteJourneyRequest_writeJourneyRequest_Schedule != null)
            {
                request.WriteJourneyRequest.Schedule = requestWriteJourneyRequest_writeJourneyRequest_Schedule;
                requestWriteJourneyRequestIsNull = false;
            }
             // determine if request.WriteJourneyRequest should be set to null
            if (requestWriteJourneyRequestIsNull)
            {
                request.WriteJourneyRequest = null;
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
        
        private Amazon.Pinpoint.Model.CreateJourneyResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.CreateJourneyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "CreateJourney");
            try
            {
                #if DESKTOP
                return client.CreateJourney(request);
                #elif CORECLR
                return client.CreateJourneyAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationId { get; set; }
            public Dictionary<System.String, Amazon.Pinpoint.Model.Activity> WriteJourneyRequest_Activity { get; set; }
            public System.String WriteJourneyRequest_CreationDate { get; set; }
            public System.String WriteJourneyRequest_LastModifiedDate { get; set; }
            public System.Int32? Limits_DailyCap { get; set; }
            public System.Int32? Limits_EndpointReentryCap { get; set; }
            public System.Int32? Limits_MessagesPerSecond { get; set; }
            public System.Boolean? WriteJourneyRequest_LocalTime { get; set; }
            public System.String WriteJourneyRequest_Name { get; set; }
            public System.String QuietTime_End { get; set; }
            public System.String QuietTime_Start { get; set; }
            public System.String WriteJourneyRequest_RefreshFrequency { get; set; }
            public System.DateTime? Schedule_EndTime { get; set; }
            public System.DateTime? Schedule_StartTime { get; set; }
            public System.String Schedule_Timezone { get; set; }
            public System.String WriteJourneyRequest_StartActivity { get; set; }
            public System.String StartCondition_Description { get; set; }
            public System.String SegmentStartCondition_SegmentId { get; set; }
            public Amazon.Pinpoint.State WriteJourneyRequest_State { get; set; }
            public System.Func<Amazon.Pinpoint.Model.CreateJourneyResponse, NewPINJourneyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JourneyResponse;
        }
        
    }
}
