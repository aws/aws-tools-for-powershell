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
using Amazon.AlexaForBusiness;
using Amazon.AlexaForBusiness.Model;

namespace Amazon.PowerShell.Cmdlets.ALXB
{
    /// <summary>
    /// Creates a new room profile with the specified details.
    /// </summary>
    [Cmdlet("New", "ALXBProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Alexa For Business CreateProfile API operation.", Operation = new[] {"CreateProfile"}, SelectReturnType = typeof(Amazon.AlexaForBusiness.Model.CreateProfileResponse))]
    [AWSCmdletOutput("System.String or Amazon.AlexaForBusiness.Model.CreateProfileResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.AlexaForBusiness.Model.CreateProfileResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewALXBProfileCmdlet : AmazonAlexaForBusinessClientCmdlet, IExecutor
    {
        
        #region Parameter Address
        /// <summary>
        /// <para>
        /// <para>The valid address for the room.</para>
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
        public System.String Address { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>The user-specified token that is used during the creation of a profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter DataRetentionOptIn
        /// <summary>
        /// <para>
        /// <para>Whether data retention of the profile is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DataRetentionOptIn { get; set; }
        #endregion
        
        #region Parameter DistanceUnit
        /// <summary>
        /// <para>
        /// <para>The distance unit to be used by devices in the profile.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.AlexaForBusiness.DistanceUnit")]
        public Amazon.AlexaForBusiness.DistanceUnit DistanceUnit { get; set; }
        #endregion
        
        #region Parameter InstantBooking_DurationInMinute
        /// <summary>
        /// <para>
        /// <para>Duration between 15 and 240 minutes at increments of 15 that determines how long to
        /// book an available room when a meeting is started with Alexa.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MeetingRoomConfiguration_InstantBooking_DurationInMinutes")]
        public System.Int32? InstantBooking_DurationInMinute { get; set; }
        #endregion
        
        #region Parameter EndOfMeetingReminder_Enabled
        /// <summary>
        /// <para>
        /// <para>Whether an end of meeting reminder is enabled or not.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MeetingRoomConfiguration_EndOfMeetingReminder_Enabled")]
        public System.Boolean? EndOfMeetingReminder_Enabled { get; set; }
        #endregion
        
        #region Parameter InstantBooking_Enabled
        /// <summary>
        /// <para>
        /// <para>Whether instant booking is enabled or not.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MeetingRoomConfiguration_InstantBooking_Enabled")]
        public System.Boolean? InstantBooking_Enabled { get; set; }
        #endregion
        
        #region Parameter RequireCheckIn_Enabled
        /// <summary>
        /// <para>
        /// <para>Whether require check in is enabled or not.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MeetingRoomConfiguration_RequireCheckIn_Enabled")]
        public System.Boolean? RequireCheckIn_Enabled { get; set; }
        #endregion
        
        #region Parameter Locale
        /// <summary>
        /// <para>
        /// <para>The locale of the room profile. (This is currently only available to a limited preview
        /// audience.)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Locale { get; set; }
        #endregion
        
        #region Parameter MaxVolumeLimit
        /// <summary>
        /// <para>
        /// <para>The maximum volume limit for a room profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxVolumeLimit { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of a room profile.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter PSTNEnabled
        /// <summary>
        /// <para>
        /// <para>Whether PSTN calling is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PSTNEnabled { get; set; }
        #endregion
        
        #region Parameter RequireCheckIn_ReleaseAfterMinute
        /// <summary>
        /// <para>
        /// <para>Duration between 5 and 20 minutes to determine when to release the room if it's not
        /// checked into.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MeetingRoomConfiguration_RequireCheckIn_ReleaseAfterMinutes")]
        public System.Int32? RequireCheckIn_ReleaseAfterMinute { get; set; }
        #endregion
        
        #region Parameter EndOfMeetingReminder_ReminderAtMinute
        /// <summary>
        /// <para>
        /// <para> A range of 3 to 15 minutes that determines when the reminder begins.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MeetingRoomConfiguration_EndOfMeetingReminder_ReminderAtMinutes")]
        public System.Int32[] EndOfMeetingReminder_ReminderAtMinute { get; set; }
        #endregion
        
        #region Parameter EndOfMeetingReminder_ReminderType
        /// <summary>
        /// <para>
        /// <para>The type of sound that users hear during the end of meeting reminder. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MeetingRoomConfiguration_EndOfMeetingReminder_ReminderType")]
        [AWSConstantClassSource("Amazon.AlexaForBusiness.EndOfMeetingReminderType")]
        public Amazon.AlexaForBusiness.EndOfMeetingReminderType EndOfMeetingReminder_ReminderType { get; set; }
        #endregion
        
        #region Parameter MeetingRoomConfiguration_RoomUtilizationMetricsEnabled
        /// <summary>
        /// <para>
        /// <para>Whether room utilization metrics are enabled or not.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? MeetingRoomConfiguration_RoomUtilizationMetricsEnabled { get; set; }
        #endregion
        
        #region Parameter SetupModeDisabled
        /// <summary>
        /// <para>
        /// <para>Whether room profile setup is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SetupModeDisabled { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags for the profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.AlexaForBusiness.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TemperatureUnit
        /// <summary>
        /// <para>
        /// <para>The temperature unit to be used by devices in the profile.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.AlexaForBusiness.TemperatureUnit")]
        public Amazon.AlexaForBusiness.TemperatureUnit TemperatureUnit { get; set; }
        #endregion
        
        #region Parameter Timezone
        /// <summary>
        /// <para>
        /// <para>The time zone used by a room profile.</para>
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
        public System.String Timezone { get; set; }
        #endregion
        
        #region Parameter WakeWord
        /// <summary>
        /// <para>
        /// <para>A wake word for Alexa, Echo, Amazon, or a computer.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.AlexaForBusiness.WakeWord")]
        public Amazon.AlexaForBusiness.WakeWord WakeWord { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ProfileArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AlexaForBusiness.Model.CreateProfileResponse).
        /// Specifying the name of a property of type Amazon.AlexaForBusiness.Model.CreateProfileResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ProfileArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ALXBProfile (CreateProfile)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AlexaForBusiness.Model.CreateProfileResponse, NewALXBProfileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Address = this.Address;
            #if MODULAR
            if (this.Address == null && ParameterWasBound(nameof(this.Address)))
            {
                WriteWarning("You are passing $null as a value for parameter Address which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientRequestToken = this.ClientRequestToken;
            context.DataRetentionOptIn = this.DataRetentionOptIn;
            context.DistanceUnit = this.DistanceUnit;
            #if MODULAR
            if (this.DistanceUnit == null && ParameterWasBound(nameof(this.DistanceUnit)))
            {
                WriteWarning("You are passing $null as a value for parameter DistanceUnit which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Locale = this.Locale;
            context.MaxVolumeLimit = this.MaxVolumeLimit;
            context.EndOfMeetingReminder_Enabled = this.EndOfMeetingReminder_Enabled;
            if (this.EndOfMeetingReminder_ReminderAtMinute != null)
            {
                context.EndOfMeetingReminder_ReminderAtMinute = new List<System.Int32>(this.EndOfMeetingReminder_ReminderAtMinute);
            }
            context.EndOfMeetingReminder_ReminderType = this.EndOfMeetingReminder_ReminderType;
            context.InstantBooking_DurationInMinute = this.InstantBooking_DurationInMinute;
            context.InstantBooking_Enabled = this.InstantBooking_Enabled;
            context.RequireCheckIn_Enabled = this.RequireCheckIn_Enabled;
            context.RequireCheckIn_ReleaseAfterMinute = this.RequireCheckIn_ReleaseAfterMinute;
            context.MeetingRoomConfiguration_RoomUtilizationMetricsEnabled = this.MeetingRoomConfiguration_RoomUtilizationMetricsEnabled;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PSTNEnabled = this.PSTNEnabled;
            context.SetupModeDisabled = this.SetupModeDisabled;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.AlexaForBusiness.Model.Tag>(this.Tag);
            }
            context.TemperatureUnit = this.TemperatureUnit;
            #if MODULAR
            if (this.TemperatureUnit == null && ParameterWasBound(nameof(this.TemperatureUnit)))
            {
                WriteWarning("You are passing $null as a value for parameter TemperatureUnit which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Timezone = this.Timezone;
            #if MODULAR
            if (this.Timezone == null && ParameterWasBound(nameof(this.Timezone)))
            {
                WriteWarning("You are passing $null as a value for parameter Timezone which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WakeWord = this.WakeWord;
            #if MODULAR
            if (this.WakeWord == null && ParameterWasBound(nameof(this.WakeWord)))
            {
                WriteWarning("You are passing $null as a value for parameter WakeWord which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AlexaForBusiness.Model.CreateProfileRequest();
            
            if (cmdletContext.Address != null)
            {
                request.Address = cmdletContext.Address;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.DataRetentionOptIn != null)
            {
                request.DataRetentionOptIn = cmdletContext.DataRetentionOptIn.Value;
            }
            if (cmdletContext.DistanceUnit != null)
            {
                request.DistanceUnit = cmdletContext.DistanceUnit;
            }
            if (cmdletContext.Locale != null)
            {
                request.Locale = cmdletContext.Locale;
            }
            if (cmdletContext.MaxVolumeLimit != null)
            {
                request.MaxVolumeLimit = cmdletContext.MaxVolumeLimit.Value;
            }
            
             // populate MeetingRoomConfiguration
            var requestMeetingRoomConfigurationIsNull = true;
            request.MeetingRoomConfiguration = new Amazon.AlexaForBusiness.Model.CreateMeetingRoomConfiguration();
            System.Boolean? requestMeetingRoomConfiguration_meetingRoomConfiguration_RoomUtilizationMetricsEnabled = null;
            if (cmdletContext.MeetingRoomConfiguration_RoomUtilizationMetricsEnabled != null)
            {
                requestMeetingRoomConfiguration_meetingRoomConfiguration_RoomUtilizationMetricsEnabled = cmdletContext.MeetingRoomConfiguration_RoomUtilizationMetricsEnabled.Value;
            }
            if (requestMeetingRoomConfiguration_meetingRoomConfiguration_RoomUtilizationMetricsEnabled != null)
            {
                request.MeetingRoomConfiguration.RoomUtilizationMetricsEnabled = requestMeetingRoomConfiguration_meetingRoomConfiguration_RoomUtilizationMetricsEnabled.Value;
                requestMeetingRoomConfigurationIsNull = false;
            }
            Amazon.AlexaForBusiness.Model.CreateInstantBooking requestMeetingRoomConfiguration_meetingRoomConfiguration_InstantBooking = null;
            
             // populate InstantBooking
            var requestMeetingRoomConfiguration_meetingRoomConfiguration_InstantBookingIsNull = true;
            requestMeetingRoomConfiguration_meetingRoomConfiguration_InstantBooking = new Amazon.AlexaForBusiness.Model.CreateInstantBooking();
            System.Int32? requestMeetingRoomConfiguration_meetingRoomConfiguration_InstantBooking_instantBooking_DurationInMinute = null;
            if (cmdletContext.InstantBooking_DurationInMinute != null)
            {
                requestMeetingRoomConfiguration_meetingRoomConfiguration_InstantBooking_instantBooking_DurationInMinute = cmdletContext.InstantBooking_DurationInMinute.Value;
            }
            if (requestMeetingRoomConfiguration_meetingRoomConfiguration_InstantBooking_instantBooking_DurationInMinute != null)
            {
                requestMeetingRoomConfiguration_meetingRoomConfiguration_InstantBooking.DurationInMinutes = requestMeetingRoomConfiguration_meetingRoomConfiguration_InstantBooking_instantBooking_DurationInMinute.Value;
                requestMeetingRoomConfiguration_meetingRoomConfiguration_InstantBookingIsNull = false;
            }
            System.Boolean? requestMeetingRoomConfiguration_meetingRoomConfiguration_InstantBooking_instantBooking_Enabled = null;
            if (cmdletContext.InstantBooking_Enabled != null)
            {
                requestMeetingRoomConfiguration_meetingRoomConfiguration_InstantBooking_instantBooking_Enabled = cmdletContext.InstantBooking_Enabled.Value;
            }
            if (requestMeetingRoomConfiguration_meetingRoomConfiguration_InstantBooking_instantBooking_Enabled != null)
            {
                requestMeetingRoomConfiguration_meetingRoomConfiguration_InstantBooking.Enabled = requestMeetingRoomConfiguration_meetingRoomConfiguration_InstantBooking_instantBooking_Enabled.Value;
                requestMeetingRoomConfiguration_meetingRoomConfiguration_InstantBookingIsNull = false;
            }
             // determine if requestMeetingRoomConfiguration_meetingRoomConfiguration_InstantBooking should be set to null
            if (requestMeetingRoomConfiguration_meetingRoomConfiguration_InstantBookingIsNull)
            {
                requestMeetingRoomConfiguration_meetingRoomConfiguration_InstantBooking = null;
            }
            if (requestMeetingRoomConfiguration_meetingRoomConfiguration_InstantBooking != null)
            {
                request.MeetingRoomConfiguration.InstantBooking = requestMeetingRoomConfiguration_meetingRoomConfiguration_InstantBooking;
                requestMeetingRoomConfigurationIsNull = false;
            }
            Amazon.AlexaForBusiness.Model.CreateRequireCheckIn requestMeetingRoomConfiguration_meetingRoomConfiguration_RequireCheckIn = null;
            
             // populate RequireCheckIn
            var requestMeetingRoomConfiguration_meetingRoomConfiguration_RequireCheckInIsNull = true;
            requestMeetingRoomConfiguration_meetingRoomConfiguration_RequireCheckIn = new Amazon.AlexaForBusiness.Model.CreateRequireCheckIn();
            System.Boolean? requestMeetingRoomConfiguration_meetingRoomConfiguration_RequireCheckIn_requireCheckIn_Enabled = null;
            if (cmdletContext.RequireCheckIn_Enabled != null)
            {
                requestMeetingRoomConfiguration_meetingRoomConfiguration_RequireCheckIn_requireCheckIn_Enabled = cmdletContext.RequireCheckIn_Enabled.Value;
            }
            if (requestMeetingRoomConfiguration_meetingRoomConfiguration_RequireCheckIn_requireCheckIn_Enabled != null)
            {
                requestMeetingRoomConfiguration_meetingRoomConfiguration_RequireCheckIn.Enabled = requestMeetingRoomConfiguration_meetingRoomConfiguration_RequireCheckIn_requireCheckIn_Enabled.Value;
                requestMeetingRoomConfiguration_meetingRoomConfiguration_RequireCheckInIsNull = false;
            }
            System.Int32? requestMeetingRoomConfiguration_meetingRoomConfiguration_RequireCheckIn_requireCheckIn_ReleaseAfterMinute = null;
            if (cmdletContext.RequireCheckIn_ReleaseAfterMinute != null)
            {
                requestMeetingRoomConfiguration_meetingRoomConfiguration_RequireCheckIn_requireCheckIn_ReleaseAfterMinute = cmdletContext.RequireCheckIn_ReleaseAfterMinute.Value;
            }
            if (requestMeetingRoomConfiguration_meetingRoomConfiguration_RequireCheckIn_requireCheckIn_ReleaseAfterMinute != null)
            {
                requestMeetingRoomConfiguration_meetingRoomConfiguration_RequireCheckIn.ReleaseAfterMinutes = requestMeetingRoomConfiguration_meetingRoomConfiguration_RequireCheckIn_requireCheckIn_ReleaseAfterMinute.Value;
                requestMeetingRoomConfiguration_meetingRoomConfiguration_RequireCheckInIsNull = false;
            }
             // determine if requestMeetingRoomConfiguration_meetingRoomConfiguration_RequireCheckIn should be set to null
            if (requestMeetingRoomConfiguration_meetingRoomConfiguration_RequireCheckInIsNull)
            {
                requestMeetingRoomConfiguration_meetingRoomConfiguration_RequireCheckIn = null;
            }
            if (requestMeetingRoomConfiguration_meetingRoomConfiguration_RequireCheckIn != null)
            {
                request.MeetingRoomConfiguration.RequireCheckIn = requestMeetingRoomConfiguration_meetingRoomConfiguration_RequireCheckIn;
                requestMeetingRoomConfigurationIsNull = false;
            }
            Amazon.AlexaForBusiness.Model.CreateEndOfMeetingReminder requestMeetingRoomConfiguration_meetingRoomConfiguration_EndOfMeetingReminder = null;
            
             // populate EndOfMeetingReminder
            var requestMeetingRoomConfiguration_meetingRoomConfiguration_EndOfMeetingReminderIsNull = true;
            requestMeetingRoomConfiguration_meetingRoomConfiguration_EndOfMeetingReminder = new Amazon.AlexaForBusiness.Model.CreateEndOfMeetingReminder();
            System.Boolean? requestMeetingRoomConfiguration_meetingRoomConfiguration_EndOfMeetingReminder_endOfMeetingReminder_Enabled = null;
            if (cmdletContext.EndOfMeetingReminder_Enabled != null)
            {
                requestMeetingRoomConfiguration_meetingRoomConfiguration_EndOfMeetingReminder_endOfMeetingReminder_Enabled = cmdletContext.EndOfMeetingReminder_Enabled.Value;
            }
            if (requestMeetingRoomConfiguration_meetingRoomConfiguration_EndOfMeetingReminder_endOfMeetingReminder_Enabled != null)
            {
                requestMeetingRoomConfiguration_meetingRoomConfiguration_EndOfMeetingReminder.Enabled = requestMeetingRoomConfiguration_meetingRoomConfiguration_EndOfMeetingReminder_endOfMeetingReminder_Enabled.Value;
                requestMeetingRoomConfiguration_meetingRoomConfiguration_EndOfMeetingReminderIsNull = false;
            }
            List<System.Int32> requestMeetingRoomConfiguration_meetingRoomConfiguration_EndOfMeetingReminder_endOfMeetingReminder_ReminderAtMinute = null;
            if (cmdletContext.EndOfMeetingReminder_ReminderAtMinute != null)
            {
                requestMeetingRoomConfiguration_meetingRoomConfiguration_EndOfMeetingReminder_endOfMeetingReminder_ReminderAtMinute = cmdletContext.EndOfMeetingReminder_ReminderAtMinute;
            }
            if (requestMeetingRoomConfiguration_meetingRoomConfiguration_EndOfMeetingReminder_endOfMeetingReminder_ReminderAtMinute != null)
            {
                requestMeetingRoomConfiguration_meetingRoomConfiguration_EndOfMeetingReminder.ReminderAtMinutes = requestMeetingRoomConfiguration_meetingRoomConfiguration_EndOfMeetingReminder_endOfMeetingReminder_ReminderAtMinute;
                requestMeetingRoomConfiguration_meetingRoomConfiguration_EndOfMeetingReminderIsNull = false;
            }
            Amazon.AlexaForBusiness.EndOfMeetingReminderType requestMeetingRoomConfiguration_meetingRoomConfiguration_EndOfMeetingReminder_endOfMeetingReminder_ReminderType = null;
            if (cmdletContext.EndOfMeetingReminder_ReminderType != null)
            {
                requestMeetingRoomConfiguration_meetingRoomConfiguration_EndOfMeetingReminder_endOfMeetingReminder_ReminderType = cmdletContext.EndOfMeetingReminder_ReminderType;
            }
            if (requestMeetingRoomConfiguration_meetingRoomConfiguration_EndOfMeetingReminder_endOfMeetingReminder_ReminderType != null)
            {
                requestMeetingRoomConfiguration_meetingRoomConfiguration_EndOfMeetingReminder.ReminderType = requestMeetingRoomConfiguration_meetingRoomConfiguration_EndOfMeetingReminder_endOfMeetingReminder_ReminderType;
                requestMeetingRoomConfiguration_meetingRoomConfiguration_EndOfMeetingReminderIsNull = false;
            }
             // determine if requestMeetingRoomConfiguration_meetingRoomConfiguration_EndOfMeetingReminder should be set to null
            if (requestMeetingRoomConfiguration_meetingRoomConfiguration_EndOfMeetingReminderIsNull)
            {
                requestMeetingRoomConfiguration_meetingRoomConfiguration_EndOfMeetingReminder = null;
            }
            if (requestMeetingRoomConfiguration_meetingRoomConfiguration_EndOfMeetingReminder != null)
            {
                request.MeetingRoomConfiguration.EndOfMeetingReminder = requestMeetingRoomConfiguration_meetingRoomConfiguration_EndOfMeetingReminder;
                requestMeetingRoomConfigurationIsNull = false;
            }
             // determine if request.MeetingRoomConfiguration should be set to null
            if (requestMeetingRoomConfigurationIsNull)
            {
                request.MeetingRoomConfiguration = null;
            }
            if (cmdletContext.Name != null)
            {
                request.ProfileName = cmdletContext.Name;
            }
            if (cmdletContext.PSTNEnabled != null)
            {
                request.PSTNEnabled = cmdletContext.PSTNEnabled.Value;
            }
            if (cmdletContext.SetupModeDisabled != null)
            {
                request.SetupModeDisabled = cmdletContext.SetupModeDisabled.Value;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TemperatureUnit != null)
            {
                request.TemperatureUnit = cmdletContext.TemperatureUnit;
            }
            if (cmdletContext.Timezone != null)
            {
                request.Timezone = cmdletContext.Timezone;
            }
            if (cmdletContext.WakeWord != null)
            {
                request.WakeWord = cmdletContext.WakeWord;
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
        
        private Amazon.AlexaForBusiness.Model.CreateProfileResponse CallAWSServiceOperation(IAmazonAlexaForBusiness client, Amazon.AlexaForBusiness.Model.CreateProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Alexa For Business", "CreateProfile");
            try
            {
                #if DESKTOP
                return client.CreateProfile(request);
                #elif CORECLR
                return client.CreateProfileAsync(request).GetAwaiter().GetResult();
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
            public System.String Address { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.Boolean? DataRetentionOptIn { get; set; }
            public Amazon.AlexaForBusiness.DistanceUnit DistanceUnit { get; set; }
            public System.String Locale { get; set; }
            public System.Int32? MaxVolumeLimit { get; set; }
            public System.Boolean? EndOfMeetingReminder_Enabled { get; set; }
            public List<System.Int32> EndOfMeetingReminder_ReminderAtMinute { get; set; }
            public Amazon.AlexaForBusiness.EndOfMeetingReminderType EndOfMeetingReminder_ReminderType { get; set; }
            public System.Int32? InstantBooking_DurationInMinute { get; set; }
            public System.Boolean? InstantBooking_Enabled { get; set; }
            public System.Boolean? RequireCheckIn_Enabled { get; set; }
            public System.Int32? RequireCheckIn_ReleaseAfterMinute { get; set; }
            public System.Boolean? MeetingRoomConfiguration_RoomUtilizationMetricsEnabled { get; set; }
            public System.String Name { get; set; }
            public System.Boolean? PSTNEnabled { get; set; }
            public System.Boolean? SetupModeDisabled { get; set; }
            public List<Amazon.AlexaForBusiness.Model.Tag> Tag { get; set; }
            public Amazon.AlexaForBusiness.TemperatureUnit TemperatureUnit { get; set; }
            public System.String Timezone { get; set; }
            public Amazon.AlexaForBusiness.WakeWord WakeWord { get; set; }
            public System.Func<Amazon.AlexaForBusiness.Model.CreateProfileResponse, NewALXBProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ProfileArn;
        }
        
    }
}
