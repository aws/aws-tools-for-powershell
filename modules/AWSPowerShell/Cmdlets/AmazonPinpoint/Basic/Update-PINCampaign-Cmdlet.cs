/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Use to update a campaign.
    /// </summary>
    [Cmdlet("Update", "PINCampaign", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.CampaignResponse")]
    [AWSCmdlet("Invokes the UpdateCampaign operation against Amazon Pinpoint.", Operation = new[] {"UpdateCampaign"})]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.CampaignResponse",
        "This cmdlet returns a CampaignResponse object.",
        "The service call response (type Amazon.Pinpoint.Model.UpdateCampaignResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdatePINCampaignCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
        #region Parameter APNSMessage_Action
        /// <summary>
        /// <para>
        /// The action that occurs if the user taps a push
        /// notification delivered by the campaign:OPEN_APP - Your app launches, or it becomes
        /// the foreground app if it has been sent to the background. This is the default action.DEEP_LINK
        /// - Uses deep linking features in iOS and Android to open your app and display a designated
        /// user interface within the app.URL - The default mobile browser on the user's device
        /// launches and opens a web page at the URL you specify.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_MessageConfiguration_APNSMessage_Action")]
        [AWSConstantClassSource("Amazon.Pinpoint.Action")]
        public Amazon.Pinpoint.Action APNSMessage_Action { get; set; }
        #endregion
        
        #region Parameter DefaultMessage_Action
        /// <summary>
        /// <para>
        /// The action that occurs if the user taps a push
        /// notification delivered by the campaign:OPEN_APP - Your app launches, or it becomes
        /// the foreground app if it has been sent to the background. This is the default action.DEEP_LINK
        /// - Uses deep linking features in iOS and Android to open your app and display a designated
        /// user interface within the app.URL - The default mobile browser on the user's device
        /// launches and opens a web page at the URL you specify.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_MessageConfiguration_DefaultMessage_Action")]
        [AWSConstantClassSource("Amazon.Pinpoint.Action")]
        public Amazon.Pinpoint.Action DefaultMessage_Action { get; set; }
        #endregion
        
        #region Parameter GCMMessage_Action
        /// <summary>
        /// <para>
        /// The action that occurs if the user taps a push
        /// notification delivered by the campaign:OPEN_APP - Your app launches, or it becomes
        /// the foreground app if it has been sent to the background. This is the default action.DEEP_LINK
        /// - Uses deep linking features in iOS and Android to open your app and display a designated
        /// user interface within the app.URL - The default mobile browser on the user's device
        /// launches and opens a web page at the URL you specify.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_MessageConfiguration_GCMMessage_Action")]
        [AWSConstantClassSource("Amazon.Pinpoint.Action")]
        public Amazon.Pinpoint.Action GCMMessage_Action { get; set; }
        #endregion
        
        #region Parameter WriteCampaignRequest_AdditionalTreatment
        /// <summary>
        /// <para>
        /// Treatments that are defined in addition
        /// to the default treatment.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_AdditionalTreatments")]
        public Amazon.Pinpoint.Model.WriteTreatmentResource[] WriteCampaignRequest_AdditionalTreatment { get; set; }
        #endregion
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter APNSMessage_Body
        /// <summary>
        /// <para>
        /// The message body. Can include up to 140 characters.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_MessageConfiguration_APNSMessage_Body")]
        public System.String APNSMessage_Body { get; set; }
        #endregion
        
        #region Parameter DefaultMessage_Body
        /// <summary>
        /// <para>
        /// The message body. Can include up to 140 characters.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_MessageConfiguration_DefaultMessage_Body")]
        public System.String DefaultMessage_Body { get; set; }
        #endregion
        
        #region Parameter EmailMessage_Body
        /// <summary>
        /// <para>
        /// The email text body.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_MessageConfiguration_EmailMessage_Body")]
        public System.String EmailMessage_Body { get; set; }
        #endregion
        
        #region Parameter GCMMessage_Body
        /// <summary>
        /// <para>
        /// The message body. Can include up to 140 characters.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_MessageConfiguration_GCMMessage_Body")]
        public System.String GCMMessage_Body { get; set; }
        #endregion
        
        #region Parameter SMSMessage_Body
        /// <summary>
        /// <para>
        /// The SMS text body.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_MessageConfiguration_SMSMessage_Body")]
        public System.String SMSMessage_Body { get; set; }
        #endregion
        
        #region Parameter CampaignId
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CampaignId { get; set; }
        #endregion
        
        #region Parameter Limits_Daily
        /// <summary>
        /// <para>
        /// The maximum number of messages that the campaign
        /// can send daily.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_Limits_Daily")]
        public System.Int32 Limits_Daily { get; set; }
        #endregion
        
        #region Parameter WriteCampaignRequest_Description
        /// <summary>
        /// <para>
        /// A description of the campaign.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String WriteCampaignRequest_Description { get; set; }
        #endregion
        
        #region Parameter QuietTime_End
        /// <summary>
        /// <para>
        /// The default end time for quiet time in ISO 8601 format.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_Schedule_QuietTime_End")]
        public System.String QuietTime_End { get; set; }
        #endregion
        
        #region Parameter Schedule_EndTime
        /// <summary>
        /// <para>
        /// The scheduled time that the campaign ends in ISO
        /// 8601 format.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_Schedule_EndTime")]
        public System.String Schedule_EndTime { get; set; }
        #endregion
        
        #region Parameter Schedule_Frequency
        /// <summary>
        /// <para>
        /// How often the campaign delivers messages.Valid
        /// values: ONCE, HOURLY, DAILY, WEEKLY, MONTHLY
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_Schedule_Frequency")]
        [AWSConstantClassSource("Amazon.Pinpoint.Frequency")]
        public Amazon.Pinpoint.Frequency Schedule_Frequency { get; set; }
        #endregion
        
        #region Parameter WriteCampaignRequest_HoldoutPercent
        /// <summary>
        /// <para>
        /// The allocated percentage of end users who
        /// will not receive messages from this campaign.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 WriteCampaignRequest_HoldoutPercent { get; set; }
        #endregion
        
        #region Parameter EmailMessage_HtmlBody
        /// <summary>
        /// <para>
        /// The email html body.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_MessageConfiguration_EmailMessage_HtmlBody")]
        public System.String EmailMessage_HtmlBody { get; set; }
        #endregion
        
        #region Parameter APNSMessage_ImageIconUrl
        /// <summary>
        /// <para>
        /// The URL that points to the icon image for
        /// the push notification icon, for example, the app icon.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_MessageConfiguration_APNSMessage_ImageIconUrl")]
        public System.String APNSMessage_ImageIconUrl { get; set; }
        #endregion
        
        #region Parameter DefaultMessage_ImageIconUrl
        /// <summary>
        /// <para>
        /// The URL that points to the icon image for
        /// the push notification icon, for example, the app icon.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_MessageConfiguration_DefaultMessage_ImageIconUrl")]
        public System.String DefaultMessage_ImageIconUrl { get; set; }
        #endregion
        
        #region Parameter GCMMessage_ImageIconUrl
        /// <summary>
        /// <para>
        /// The URL that points to the icon image for
        /// the push notification icon, for example, the app icon.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_MessageConfiguration_GCMMessage_ImageIconUrl")]
        public System.String GCMMessage_ImageIconUrl { get; set; }
        #endregion
        
        #region Parameter APNSMessage_ImageSmallIconUrl
        /// <summary>
        /// <para>
        /// The URL that points to the small icon
        /// image for the push notification icon, for example, the app icon.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_MessageConfiguration_APNSMessage_ImageSmallIconUrl")]
        public System.String APNSMessage_ImageSmallIconUrl { get; set; }
        #endregion
        
        #region Parameter DefaultMessage_ImageSmallIconUrl
        /// <summary>
        /// <para>
        /// The URL that points to the small icon
        /// image for the push notification icon, for example, the app icon.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_MessageConfiguration_DefaultMessage_ImageSmallIconUrl")]
        public System.String DefaultMessage_ImageSmallIconUrl { get; set; }
        #endregion
        
        #region Parameter GCMMessage_ImageSmallIconUrl
        /// <summary>
        /// <para>
        /// The URL that points to the small icon
        /// image for the push notification icon, for example, the app icon.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_MessageConfiguration_GCMMessage_ImageSmallIconUrl")]
        public System.String GCMMessage_ImageSmallIconUrl { get; set; }
        #endregion
        
        #region Parameter APNSMessage_ImageUrl
        /// <summary>
        /// <para>
        /// The URL that points to an image used in the push
        /// notification.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_MessageConfiguration_APNSMessage_ImageUrl")]
        public System.String APNSMessage_ImageUrl { get; set; }
        #endregion
        
        #region Parameter DefaultMessage_ImageUrl
        /// <summary>
        /// <para>
        /// The URL that points to an image used in the push
        /// notification.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_MessageConfiguration_DefaultMessage_ImageUrl")]
        public System.String DefaultMessage_ImageUrl { get; set; }
        #endregion
        
        #region Parameter GCMMessage_ImageUrl
        /// <summary>
        /// <para>
        /// The URL that points to an image used in the push
        /// notification.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_MessageConfiguration_GCMMessage_ImageUrl")]
        public System.String GCMMessage_ImageUrl { get; set; }
        #endregion
        
        #region Parameter Schedule_IsLocalTime
        /// <summary>
        /// <para>
        /// Indicates whether the campaign schedule takes
        /// effect according to each user's local time.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_Schedule_IsLocalTime")]
        public System.Boolean Schedule_IsLocalTime { get; set; }
        #endregion
        
        #region Parameter WriteCampaignRequest_IsPaused
        /// <summary>
        /// <para>
        /// Indicates whether the campaign is paused. A paused
        /// campaign does not send messages unless you resume it by setting IsPaused to false.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean WriteCampaignRequest_IsPaused { get; set; }
        #endregion
        
        #region Parameter APNSMessage_JsonBody
        /// <summary>
        /// <para>
        /// The JSON payload used for a silent push.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_MessageConfiguration_APNSMessage_JsonBody")]
        public System.String APNSMessage_JsonBody { get; set; }
        #endregion
        
        #region Parameter DefaultMessage_JsonBody
        /// <summary>
        /// <para>
        /// The JSON payload used for a silent push.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_MessageConfiguration_DefaultMessage_JsonBody")]
        public System.String DefaultMessage_JsonBody { get; set; }
        #endregion
        
        #region Parameter GCMMessage_JsonBody
        /// <summary>
        /// <para>
        /// The JSON payload used for a silent push.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_MessageConfiguration_GCMMessage_JsonBody")]
        public System.String GCMMessage_JsonBody { get; set; }
        #endregion
        
        #region Parameter APNSMessage_MediaUrl
        /// <summary>
        /// <para>
        /// The URL that points to the media resource, for
        /// example a .mp4 or .gif file.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_MessageConfiguration_APNSMessage_MediaUrl")]
        public System.String APNSMessage_MediaUrl { get; set; }
        #endregion
        
        #region Parameter DefaultMessage_MediaUrl
        /// <summary>
        /// <para>
        /// The URL that points to the media resource, for
        /// example a .mp4 or .gif file.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_MessageConfiguration_DefaultMessage_MediaUrl")]
        public System.String DefaultMessage_MediaUrl { get; set; }
        #endregion
        
        #region Parameter GCMMessage_MediaUrl
        /// <summary>
        /// <para>
        /// The URL that points to the media resource, for
        /// example a .mp4 or .gif file.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_MessageConfiguration_GCMMessage_MediaUrl")]
        public System.String GCMMessage_MediaUrl { get; set; }
        #endregion
        
        #region Parameter SMSMessage_MessageType
        /// <summary>
        /// <para>
        /// Is this is a transactional SMS message, otherwise
        /// a promotional message.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_MessageConfiguration_SMSMessage_MessageType")]
        [AWSConstantClassSource("Amazon.Pinpoint.MessageType")]
        public Amazon.Pinpoint.MessageType SMSMessage_MessageType { get; set; }
        #endregion
        
        #region Parameter WriteCampaignRequest_Name
        /// <summary>
        /// <para>
        /// The custom name of the campaign.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String WriteCampaignRequest_Name { get; set; }
        #endregion
        
        #region Parameter WriteCampaignRequest_SegmentId
        /// <summary>
        /// <para>
        /// The ID of the segment to which the campaign
        /// sends messages.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String WriteCampaignRequest_SegmentId { get; set; }
        #endregion
        
        #region Parameter WriteCampaignRequest_SegmentVersion
        /// <summary>
        /// <para>
        /// The version of the segment to which the
        /// campaign sends messages.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 WriteCampaignRequest_SegmentVersion { get; set; }
        #endregion
        
        #region Parameter SMSMessage_SenderId
        /// <summary>
        /// <para>
        /// Sender ID of sent message.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_MessageConfiguration_SMSMessage_SenderId")]
        public System.String SMSMessage_SenderId { get; set; }
        #endregion
        
        #region Parameter APNSMessage_SilentPush
        /// <summary>
        /// <para>
        /// Indicates if the message should display on
        /// the users device.Silent pushes can be used for Remote Configuration and Phone Home
        /// use cases.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_MessageConfiguration_APNSMessage_SilentPush")]
        public System.Boolean APNSMessage_SilentPush { get; set; }
        #endregion
        
        #region Parameter DefaultMessage_SilentPush
        /// <summary>
        /// <para>
        /// Indicates if the message should display on
        /// the users device.Silent pushes can be used for Remote Configuration and Phone Home
        /// use cases.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_MessageConfiguration_DefaultMessage_SilentPush")]
        public System.Boolean DefaultMessage_SilentPush { get; set; }
        #endregion
        
        #region Parameter GCMMessage_SilentPush
        /// <summary>
        /// <para>
        /// Indicates if the message should display on
        /// the users device.Silent pushes can be used for Remote Configuration and Phone Home
        /// use cases.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_MessageConfiguration_GCMMessage_SilentPush")]
        public System.Boolean GCMMessage_SilentPush { get; set; }
        #endregion
        
        #region Parameter QuietTime_Start
        /// <summary>
        /// <para>
        /// The default start time for quiet time in ISO 8601
        /// format.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_Schedule_QuietTime_Start")]
        public System.String QuietTime_Start { get; set; }
        #endregion
        
        #region Parameter Schedule_StartTime
        /// <summary>
        /// <para>
        /// The scheduled time that the campaign begins
        /// in ISO 8601 format.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_Schedule_StartTime")]
        public System.String Schedule_StartTime { get; set; }
        #endregion
        
        #region Parameter Schedule_Timezone
        /// <summary>
        /// <para>
        /// The starting UTC offset for the schedule if the
        /// value for isLocalTime is trueValid values: UTCUTC+01UTC+02UTC+03UTC+03:30UTC+04UTC+04:30UTC+05UTC+05:30UTC+05:45UTC+06UTC+06:30UTC+07UTC+08UTC+09UTC+09:30UTC+10UTC+10:30UTC+11UTC+12UTC+13UTC-02UTC-03UTC-04UTC-05UTC-06UTC-07UTC-08UTC-09UTC-10UTC-11
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_Schedule_Timezone")]
        public System.String Schedule_Timezone { get; set; }
        #endregion
        
        #region Parameter APNSMessage_Title
        /// <summary>
        /// <para>
        /// The message title that displays above the message
        /// on the user's device.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_MessageConfiguration_APNSMessage_Title")]
        public System.String APNSMessage_Title { get; set; }
        #endregion
        
        #region Parameter DefaultMessage_Title
        /// <summary>
        /// <para>
        /// The message title that displays above the message
        /// on the user's device.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_MessageConfiguration_DefaultMessage_Title")]
        public System.String DefaultMessage_Title { get; set; }
        #endregion
        
        #region Parameter EmailMessage_Title
        /// <summary>
        /// <para>
        /// The email title (Or subject).
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_MessageConfiguration_EmailMessage_Title")]
        public System.String EmailMessage_Title { get; set; }
        #endregion
        
        #region Parameter GCMMessage_Title
        /// <summary>
        /// <para>
        /// The message title that displays above the message
        /// on the user's device.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_MessageConfiguration_GCMMessage_Title")]
        public System.String GCMMessage_Title { get; set; }
        #endregion
        
        #region Parameter Limits_Total
        /// <summary>
        /// <para>
        /// The maximum total number of messages that the campaign
        /// can send.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_Limits_Total")]
        public System.Int32 Limits_Total { get; set; }
        #endregion
        
        #region Parameter WriteCampaignRequest_TreatmentDescription
        /// <summary>
        /// <para>
        /// A custom description for the treatment.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String WriteCampaignRequest_TreatmentDescription { get; set; }
        #endregion
        
        #region Parameter WriteCampaignRequest_TreatmentName
        /// <summary>
        /// <para>
        /// The custom name of a variation of the campaign
        /// used for A/B testing.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String WriteCampaignRequest_TreatmentName { get; set; }
        #endregion
        
        #region Parameter APNSMessage_Url
        /// <summary>
        /// <para>
        /// The URL to open in the user's mobile browser. Used
        /// if the value for Action is URL.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_MessageConfiguration_APNSMessage_Url")]
        public System.String APNSMessage_Url { get; set; }
        #endregion
        
        #region Parameter DefaultMessage_Url
        /// <summary>
        /// <para>
        /// The URL to open in the user's mobile browser. Used
        /// if the value for Action is URL.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_MessageConfiguration_DefaultMessage_Url")]
        public System.String DefaultMessage_Url { get; set; }
        #endregion
        
        #region Parameter GCMMessage_Url
        /// <summary>
        /// <para>
        /// The URL to open in the user's mobile browser. Used
        /// if the value for Action is URL.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteCampaignRequest_MessageConfiguration_GCMMessage_Url")]
        public System.String GCMMessage_Url { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ApplicationId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PINCampaign (UpdateCampaign)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ApplicationId = this.ApplicationId;
            context.CampaignId = this.CampaignId;
            if (this.WriteCampaignRequest_AdditionalTreatment != null)
            {
                context.WriteCampaignRequest_AdditionalTreatments = new List<Amazon.Pinpoint.Model.WriteTreatmentResource>(this.WriteCampaignRequest_AdditionalTreatment);
            }
            context.WriteCampaignRequest_Description = this.WriteCampaignRequest_Description;
            if (ParameterWasBound("WriteCampaignRequest_HoldoutPercent"))
                context.WriteCampaignRequest_HoldoutPercent = this.WriteCampaignRequest_HoldoutPercent;
            if (ParameterWasBound("WriteCampaignRequest_IsPaused"))
                context.WriteCampaignRequest_IsPaused = this.WriteCampaignRequest_IsPaused;
            if (ParameterWasBound("Limits_Daily"))
                context.WriteCampaignRequest_Limits_Daily = this.Limits_Daily;
            if (ParameterWasBound("Limits_Total"))
                context.WriteCampaignRequest_Limits_Total = this.Limits_Total;
            context.WriteCampaignRequest_MessageConfiguration_APNSMessage_Action = this.APNSMessage_Action;
            context.WriteCampaignRequest_MessageConfiguration_APNSMessage_Body = this.APNSMessage_Body;
            context.WriteCampaignRequest_MessageConfiguration_APNSMessage_ImageIconUrl = this.APNSMessage_ImageIconUrl;
            context.WriteCampaignRequest_MessageConfiguration_APNSMessage_ImageSmallIconUrl = this.APNSMessage_ImageSmallIconUrl;
            context.WriteCampaignRequest_MessageConfiguration_APNSMessage_ImageUrl = this.APNSMessage_ImageUrl;
            context.WriteCampaignRequest_MessageConfiguration_APNSMessage_JsonBody = this.APNSMessage_JsonBody;
            context.WriteCampaignRequest_MessageConfiguration_APNSMessage_MediaUrl = this.APNSMessage_MediaUrl;
            if (ParameterWasBound("APNSMessage_SilentPush"))
                context.WriteCampaignRequest_MessageConfiguration_APNSMessage_SilentPush = this.APNSMessage_SilentPush;
            context.WriteCampaignRequest_MessageConfiguration_APNSMessage_Title = this.APNSMessage_Title;
            context.WriteCampaignRequest_MessageConfiguration_APNSMessage_Url = this.APNSMessage_Url;
            context.WriteCampaignRequest_MessageConfiguration_DefaultMessage_Action = this.DefaultMessage_Action;
            context.WriteCampaignRequest_MessageConfiguration_DefaultMessage_Body = this.DefaultMessage_Body;
            context.WriteCampaignRequest_MessageConfiguration_DefaultMessage_ImageIconUrl = this.DefaultMessage_ImageIconUrl;
            context.WriteCampaignRequest_MessageConfiguration_DefaultMessage_ImageSmallIconUrl = this.DefaultMessage_ImageSmallIconUrl;
            context.WriteCampaignRequest_MessageConfiguration_DefaultMessage_ImageUrl = this.DefaultMessage_ImageUrl;
            context.WriteCampaignRequest_MessageConfiguration_DefaultMessage_JsonBody = this.DefaultMessage_JsonBody;
            context.WriteCampaignRequest_MessageConfiguration_DefaultMessage_MediaUrl = this.DefaultMessage_MediaUrl;
            if (ParameterWasBound("DefaultMessage_SilentPush"))
                context.WriteCampaignRequest_MessageConfiguration_DefaultMessage_SilentPush = this.DefaultMessage_SilentPush;
            context.WriteCampaignRequest_MessageConfiguration_DefaultMessage_Title = this.DefaultMessage_Title;
            context.WriteCampaignRequest_MessageConfiguration_DefaultMessage_Url = this.DefaultMessage_Url;
            context.WriteCampaignRequest_MessageConfiguration_EmailMessage_Body = this.EmailMessage_Body;
            context.WriteCampaignRequest_MessageConfiguration_EmailMessage_HtmlBody = this.EmailMessage_HtmlBody;
            context.WriteCampaignRequest_MessageConfiguration_EmailMessage_Title = this.EmailMessage_Title;
            context.WriteCampaignRequest_MessageConfiguration_GCMMessage_Action = this.GCMMessage_Action;
            context.WriteCampaignRequest_MessageConfiguration_GCMMessage_Body = this.GCMMessage_Body;
            context.WriteCampaignRequest_MessageConfiguration_GCMMessage_ImageIconUrl = this.GCMMessage_ImageIconUrl;
            context.WriteCampaignRequest_MessageConfiguration_GCMMessage_ImageSmallIconUrl = this.GCMMessage_ImageSmallIconUrl;
            context.WriteCampaignRequest_MessageConfiguration_GCMMessage_ImageUrl = this.GCMMessage_ImageUrl;
            context.WriteCampaignRequest_MessageConfiguration_GCMMessage_JsonBody = this.GCMMessage_JsonBody;
            context.WriteCampaignRequest_MessageConfiguration_GCMMessage_MediaUrl = this.GCMMessage_MediaUrl;
            if (ParameterWasBound("GCMMessage_SilentPush"))
                context.WriteCampaignRequest_MessageConfiguration_GCMMessage_SilentPush = this.GCMMessage_SilentPush;
            context.WriteCampaignRequest_MessageConfiguration_GCMMessage_Title = this.GCMMessage_Title;
            context.WriteCampaignRequest_MessageConfiguration_GCMMessage_Url = this.GCMMessage_Url;
            context.WriteCampaignRequest_MessageConfiguration_SMSMessage_Body = this.SMSMessage_Body;
            context.WriteCampaignRequest_MessageConfiguration_SMSMessage_MessageType = this.SMSMessage_MessageType;
            context.WriteCampaignRequest_MessageConfiguration_SMSMessage_SenderId = this.SMSMessage_SenderId;
            context.WriteCampaignRequest_Name = this.WriteCampaignRequest_Name;
            context.WriteCampaignRequest_Schedule_EndTime = this.Schedule_EndTime;
            context.WriteCampaignRequest_Schedule_Frequency = this.Schedule_Frequency;
            if (ParameterWasBound("Schedule_IsLocalTime"))
                context.WriteCampaignRequest_Schedule_IsLocalTime = this.Schedule_IsLocalTime;
            context.WriteCampaignRequest_Schedule_QuietTime_End = this.QuietTime_End;
            context.WriteCampaignRequest_Schedule_QuietTime_Start = this.QuietTime_Start;
            context.WriteCampaignRequest_Schedule_StartTime = this.Schedule_StartTime;
            context.WriteCampaignRequest_Schedule_Timezone = this.Schedule_Timezone;
            context.WriteCampaignRequest_SegmentId = this.WriteCampaignRequest_SegmentId;
            if (ParameterWasBound("WriteCampaignRequest_SegmentVersion"))
                context.WriteCampaignRequest_SegmentVersion = this.WriteCampaignRequest_SegmentVersion;
            context.WriteCampaignRequest_TreatmentDescription = this.WriteCampaignRequest_TreatmentDescription;
            context.WriteCampaignRequest_TreatmentName = this.WriteCampaignRequest_TreatmentName;
            
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
            var request = new Amazon.Pinpoint.Model.UpdateCampaignRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            if (cmdletContext.CampaignId != null)
            {
                request.CampaignId = cmdletContext.CampaignId;
            }
            
             // populate WriteCampaignRequest
            bool requestWriteCampaignRequestIsNull = true;
            request.WriteCampaignRequest = new Amazon.Pinpoint.Model.WriteCampaignRequest();
            List<Amazon.Pinpoint.Model.WriteTreatmentResource> requestWriteCampaignRequest_writeCampaignRequest_AdditionalTreatment = null;
            if (cmdletContext.WriteCampaignRequest_AdditionalTreatments != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_AdditionalTreatment = cmdletContext.WriteCampaignRequest_AdditionalTreatments;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_AdditionalTreatment != null)
            {
                request.WriteCampaignRequest.AdditionalTreatments = requestWriteCampaignRequest_writeCampaignRequest_AdditionalTreatment;
                requestWriteCampaignRequestIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_Description = null;
            if (cmdletContext.WriteCampaignRequest_Description != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Description = cmdletContext.WriteCampaignRequest_Description;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_Description != null)
            {
                request.WriteCampaignRequest.Description = requestWriteCampaignRequest_writeCampaignRequest_Description;
                requestWriteCampaignRequestIsNull = false;
            }
            System.Int32? requestWriteCampaignRequest_writeCampaignRequest_HoldoutPercent = null;
            if (cmdletContext.WriteCampaignRequest_HoldoutPercent != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_HoldoutPercent = cmdletContext.WriteCampaignRequest_HoldoutPercent.Value;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_HoldoutPercent != null)
            {
                request.WriteCampaignRequest.HoldoutPercent = requestWriteCampaignRequest_writeCampaignRequest_HoldoutPercent.Value;
                requestWriteCampaignRequestIsNull = false;
            }
            System.Boolean? requestWriteCampaignRequest_writeCampaignRequest_IsPaused = null;
            if (cmdletContext.WriteCampaignRequest_IsPaused != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_IsPaused = cmdletContext.WriteCampaignRequest_IsPaused.Value;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_IsPaused != null)
            {
                request.WriteCampaignRequest.IsPaused = requestWriteCampaignRequest_writeCampaignRequest_IsPaused.Value;
                requestWriteCampaignRequestIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_Name = null;
            if (cmdletContext.WriteCampaignRequest_Name != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Name = cmdletContext.WriteCampaignRequest_Name;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_Name != null)
            {
                request.WriteCampaignRequest.Name = requestWriteCampaignRequest_writeCampaignRequest_Name;
                requestWriteCampaignRequestIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_SegmentId = null;
            if (cmdletContext.WriteCampaignRequest_SegmentId != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_SegmentId = cmdletContext.WriteCampaignRequest_SegmentId;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_SegmentId != null)
            {
                request.WriteCampaignRequest.SegmentId = requestWriteCampaignRequest_writeCampaignRequest_SegmentId;
                requestWriteCampaignRequestIsNull = false;
            }
            System.Int32? requestWriteCampaignRequest_writeCampaignRequest_SegmentVersion = null;
            if (cmdletContext.WriteCampaignRequest_SegmentVersion != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_SegmentVersion = cmdletContext.WriteCampaignRequest_SegmentVersion.Value;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_SegmentVersion != null)
            {
                request.WriteCampaignRequest.SegmentVersion = requestWriteCampaignRequest_writeCampaignRequest_SegmentVersion.Value;
                requestWriteCampaignRequestIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_TreatmentDescription = null;
            if (cmdletContext.WriteCampaignRequest_TreatmentDescription != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_TreatmentDescription = cmdletContext.WriteCampaignRequest_TreatmentDescription;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_TreatmentDescription != null)
            {
                request.WriteCampaignRequest.TreatmentDescription = requestWriteCampaignRequest_writeCampaignRequest_TreatmentDescription;
                requestWriteCampaignRequestIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_TreatmentName = null;
            if (cmdletContext.WriteCampaignRequest_TreatmentName != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_TreatmentName = cmdletContext.WriteCampaignRequest_TreatmentName;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_TreatmentName != null)
            {
                request.WriteCampaignRequest.TreatmentName = requestWriteCampaignRequest_writeCampaignRequest_TreatmentName;
                requestWriteCampaignRequestIsNull = false;
            }
            Amazon.Pinpoint.Model.CampaignLimits requestWriteCampaignRequest_writeCampaignRequest_Limits = null;
            
             // populate Limits
            bool requestWriteCampaignRequest_writeCampaignRequest_LimitsIsNull = true;
            requestWriteCampaignRequest_writeCampaignRequest_Limits = new Amazon.Pinpoint.Model.CampaignLimits();
            System.Int32? requestWriteCampaignRequest_writeCampaignRequest_Limits_limits_Daily = null;
            if (cmdletContext.WriteCampaignRequest_Limits_Daily != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Limits_limits_Daily = cmdletContext.WriteCampaignRequest_Limits_Daily.Value;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_Limits_limits_Daily != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Limits.Daily = requestWriteCampaignRequest_writeCampaignRequest_Limits_limits_Daily.Value;
                requestWriteCampaignRequest_writeCampaignRequest_LimitsIsNull = false;
            }
            System.Int32? requestWriteCampaignRequest_writeCampaignRequest_Limits_limits_Total = null;
            if (cmdletContext.WriteCampaignRequest_Limits_Total != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Limits_limits_Total = cmdletContext.WriteCampaignRequest_Limits_Total.Value;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_Limits_limits_Total != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Limits.Total = requestWriteCampaignRequest_writeCampaignRequest_Limits_limits_Total.Value;
                requestWriteCampaignRequest_writeCampaignRequest_LimitsIsNull = false;
            }
             // determine if requestWriteCampaignRequest_writeCampaignRequest_Limits should be set to null
            if (requestWriteCampaignRequest_writeCampaignRequest_LimitsIsNull)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Limits = null;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_Limits != null)
            {
                request.WriteCampaignRequest.Limits = requestWriteCampaignRequest_writeCampaignRequest_Limits;
                requestWriteCampaignRequestIsNull = false;
            }
            Amazon.Pinpoint.Model.MessageConfiguration requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration = null;
            
             // populate MessageConfiguration
            bool requestWriteCampaignRequest_writeCampaignRequest_MessageConfigurationIsNull = true;
            requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration = new Amazon.Pinpoint.Model.MessageConfiguration();
            Amazon.Pinpoint.Model.CampaignEmailMessage requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage = null;
            
             // populate EmailMessage
            bool requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessageIsNull = true;
            requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage = new Amazon.Pinpoint.Model.CampaignEmailMessage();
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage_emailMessage_Body = null;
            if (cmdletContext.WriteCampaignRequest_MessageConfiguration_EmailMessage_Body != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage_emailMessage_Body = cmdletContext.WriteCampaignRequest_MessageConfiguration_EmailMessage_Body;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage_emailMessage_Body != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage.Body = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage_emailMessage_Body;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage_emailMessage_HtmlBody = null;
            if (cmdletContext.WriteCampaignRequest_MessageConfiguration_EmailMessage_HtmlBody != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage_emailMessage_HtmlBody = cmdletContext.WriteCampaignRequest_MessageConfiguration_EmailMessage_HtmlBody;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage_emailMessage_HtmlBody != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage.HtmlBody = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage_emailMessage_HtmlBody;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage_emailMessage_Title = null;
            if (cmdletContext.WriteCampaignRequest_MessageConfiguration_EmailMessage_Title != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage_emailMessage_Title = cmdletContext.WriteCampaignRequest_MessageConfiguration_EmailMessage_Title;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage_emailMessage_Title != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage.Title = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage_emailMessage_Title;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessageIsNull = false;
            }
             // determine if requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage should be set to null
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessageIsNull)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage = null;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration.EmailMessage = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfigurationIsNull = false;
            }
            Amazon.Pinpoint.Model.CampaignSmsMessage requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage = null;
            
             // populate SMSMessage
            bool requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessageIsNull = true;
            requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage = new Amazon.Pinpoint.Model.CampaignSmsMessage();
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage_sMSMessage_Body = null;
            if (cmdletContext.WriteCampaignRequest_MessageConfiguration_SMSMessage_Body != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage_sMSMessage_Body = cmdletContext.WriteCampaignRequest_MessageConfiguration_SMSMessage_Body;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage_sMSMessage_Body != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage.Body = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage_sMSMessage_Body;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessageIsNull = false;
            }
            Amazon.Pinpoint.MessageType requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage_sMSMessage_MessageType = null;
            if (cmdletContext.WriteCampaignRequest_MessageConfiguration_SMSMessage_MessageType != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage_sMSMessage_MessageType = cmdletContext.WriteCampaignRequest_MessageConfiguration_SMSMessage_MessageType;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage_sMSMessage_MessageType != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage.MessageType = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage_sMSMessage_MessageType;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage_sMSMessage_SenderId = null;
            if (cmdletContext.WriteCampaignRequest_MessageConfiguration_SMSMessage_SenderId != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage_sMSMessage_SenderId = cmdletContext.WriteCampaignRequest_MessageConfiguration_SMSMessage_SenderId;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage_sMSMessage_SenderId != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage.SenderId = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage_sMSMessage_SenderId;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessageIsNull = false;
            }
             // determine if requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage should be set to null
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessageIsNull)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage = null;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration.SMSMessage = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfigurationIsNull = false;
            }
            Amazon.Pinpoint.Model.Message requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage = null;
            
             // populate APNSMessage
            bool requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessageIsNull = true;
            requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage = new Amazon.Pinpoint.Model.Message();
            Amazon.Pinpoint.Action requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_Action = null;
            if (cmdletContext.WriteCampaignRequest_MessageConfiguration_APNSMessage_Action != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_Action = cmdletContext.WriteCampaignRequest_MessageConfiguration_APNSMessage_Action;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_Action != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage.Action = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_Action;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_Body = null;
            if (cmdletContext.WriteCampaignRequest_MessageConfiguration_APNSMessage_Body != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_Body = cmdletContext.WriteCampaignRequest_MessageConfiguration_APNSMessage_Body;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_Body != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage.Body = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_Body;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_ImageIconUrl = null;
            if (cmdletContext.WriteCampaignRequest_MessageConfiguration_APNSMessage_ImageIconUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_ImageIconUrl = cmdletContext.WriteCampaignRequest_MessageConfiguration_APNSMessage_ImageIconUrl;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_ImageIconUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage.ImageIconUrl = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_ImageIconUrl;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_ImageSmallIconUrl = null;
            if (cmdletContext.WriteCampaignRequest_MessageConfiguration_APNSMessage_ImageSmallIconUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_ImageSmallIconUrl = cmdletContext.WriteCampaignRequest_MessageConfiguration_APNSMessage_ImageSmallIconUrl;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_ImageSmallIconUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage.ImageSmallIconUrl = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_ImageSmallIconUrl;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_ImageUrl = null;
            if (cmdletContext.WriteCampaignRequest_MessageConfiguration_APNSMessage_ImageUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_ImageUrl = cmdletContext.WriteCampaignRequest_MessageConfiguration_APNSMessage_ImageUrl;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_ImageUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage.ImageUrl = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_ImageUrl;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_JsonBody = null;
            if (cmdletContext.WriteCampaignRequest_MessageConfiguration_APNSMessage_JsonBody != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_JsonBody = cmdletContext.WriteCampaignRequest_MessageConfiguration_APNSMessage_JsonBody;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_JsonBody != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage.JsonBody = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_JsonBody;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_MediaUrl = null;
            if (cmdletContext.WriteCampaignRequest_MessageConfiguration_APNSMessage_MediaUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_MediaUrl = cmdletContext.WriteCampaignRequest_MessageConfiguration_APNSMessage_MediaUrl;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_MediaUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage.MediaUrl = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_MediaUrl;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessageIsNull = false;
            }
            System.Boolean? requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_SilentPush = null;
            if (cmdletContext.WriteCampaignRequest_MessageConfiguration_APNSMessage_SilentPush != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_SilentPush = cmdletContext.WriteCampaignRequest_MessageConfiguration_APNSMessage_SilentPush.Value;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_SilentPush != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage.SilentPush = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_SilentPush.Value;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_Title = null;
            if (cmdletContext.WriteCampaignRequest_MessageConfiguration_APNSMessage_Title != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_Title = cmdletContext.WriteCampaignRequest_MessageConfiguration_APNSMessage_Title;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_Title != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage.Title = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_Title;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_Url = null;
            if (cmdletContext.WriteCampaignRequest_MessageConfiguration_APNSMessage_Url != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_Url = cmdletContext.WriteCampaignRequest_MessageConfiguration_APNSMessage_Url;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_Url != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage.Url = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_Url;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessageIsNull = false;
            }
             // determine if requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage should be set to null
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessageIsNull)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage = null;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration.APNSMessage = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfigurationIsNull = false;
            }
            Amazon.Pinpoint.Model.Message requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage = null;
            
             // populate DefaultMessage
            bool requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessageIsNull = true;
            requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage = new Amazon.Pinpoint.Model.Message();
            Amazon.Pinpoint.Action requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_Action = null;
            if (cmdletContext.WriteCampaignRequest_MessageConfiguration_DefaultMessage_Action != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_Action = cmdletContext.WriteCampaignRequest_MessageConfiguration_DefaultMessage_Action;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_Action != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage.Action = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_Action;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_Body = null;
            if (cmdletContext.WriteCampaignRequest_MessageConfiguration_DefaultMessage_Body != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_Body = cmdletContext.WriteCampaignRequest_MessageConfiguration_DefaultMessage_Body;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_Body != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage.Body = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_Body;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_ImageIconUrl = null;
            if (cmdletContext.WriteCampaignRequest_MessageConfiguration_DefaultMessage_ImageIconUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_ImageIconUrl = cmdletContext.WriteCampaignRequest_MessageConfiguration_DefaultMessage_ImageIconUrl;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_ImageIconUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage.ImageIconUrl = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_ImageIconUrl;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_ImageSmallIconUrl = null;
            if (cmdletContext.WriteCampaignRequest_MessageConfiguration_DefaultMessage_ImageSmallIconUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_ImageSmallIconUrl = cmdletContext.WriteCampaignRequest_MessageConfiguration_DefaultMessage_ImageSmallIconUrl;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_ImageSmallIconUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage.ImageSmallIconUrl = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_ImageSmallIconUrl;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_ImageUrl = null;
            if (cmdletContext.WriteCampaignRequest_MessageConfiguration_DefaultMessage_ImageUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_ImageUrl = cmdletContext.WriteCampaignRequest_MessageConfiguration_DefaultMessage_ImageUrl;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_ImageUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage.ImageUrl = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_ImageUrl;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_JsonBody = null;
            if (cmdletContext.WriteCampaignRequest_MessageConfiguration_DefaultMessage_JsonBody != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_JsonBody = cmdletContext.WriteCampaignRequest_MessageConfiguration_DefaultMessage_JsonBody;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_JsonBody != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage.JsonBody = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_JsonBody;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_MediaUrl = null;
            if (cmdletContext.WriteCampaignRequest_MessageConfiguration_DefaultMessage_MediaUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_MediaUrl = cmdletContext.WriteCampaignRequest_MessageConfiguration_DefaultMessage_MediaUrl;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_MediaUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage.MediaUrl = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_MediaUrl;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessageIsNull = false;
            }
            System.Boolean? requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_SilentPush = null;
            if (cmdletContext.WriteCampaignRequest_MessageConfiguration_DefaultMessage_SilentPush != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_SilentPush = cmdletContext.WriteCampaignRequest_MessageConfiguration_DefaultMessage_SilentPush.Value;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_SilentPush != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage.SilentPush = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_SilentPush.Value;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_Title = null;
            if (cmdletContext.WriteCampaignRequest_MessageConfiguration_DefaultMessage_Title != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_Title = cmdletContext.WriteCampaignRequest_MessageConfiguration_DefaultMessage_Title;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_Title != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage.Title = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_Title;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_Url = null;
            if (cmdletContext.WriteCampaignRequest_MessageConfiguration_DefaultMessage_Url != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_Url = cmdletContext.WriteCampaignRequest_MessageConfiguration_DefaultMessage_Url;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_Url != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage.Url = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_Url;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessageIsNull = false;
            }
             // determine if requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage should be set to null
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessageIsNull)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage = null;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration.DefaultMessage = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfigurationIsNull = false;
            }
            Amazon.Pinpoint.Model.Message requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage = null;
            
             // populate GCMMessage
            bool requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessageIsNull = true;
            requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage = new Amazon.Pinpoint.Model.Message();
            Amazon.Pinpoint.Action requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_Action = null;
            if (cmdletContext.WriteCampaignRequest_MessageConfiguration_GCMMessage_Action != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_Action = cmdletContext.WriteCampaignRequest_MessageConfiguration_GCMMessage_Action;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_Action != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage.Action = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_Action;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_Body = null;
            if (cmdletContext.WriteCampaignRequest_MessageConfiguration_GCMMessage_Body != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_Body = cmdletContext.WriteCampaignRequest_MessageConfiguration_GCMMessage_Body;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_Body != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage.Body = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_Body;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageIconUrl = null;
            if (cmdletContext.WriteCampaignRequest_MessageConfiguration_GCMMessage_ImageIconUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageIconUrl = cmdletContext.WriteCampaignRequest_MessageConfiguration_GCMMessage_ImageIconUrl;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageIconUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage.ImageIconUrl = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageIconUrl;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageSmallIconUrl = null;
            if (cmdletContext.WriteCampaignRequest_MessageConfiguration_GCMMessage_ImageSmallIconUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageSmallIconUrl = cmdletContext.WriteCampaignRequest_MessageConfiguration_GCMMessage_ImageSmallIconUrl;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageSmallIconUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage.ImageSmallIconUrl = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageSmallIconUrl;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageUrl = null;
            if (cmdletContext.WriteCampaignRequest_MessageConfiguration_GCMMessage_ImageUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageUrl = cmdletContext.WriteCampaignRequest_MessageConfiguration_GCMMessage_ImageUrl;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage.ImageUrl = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageUrl;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_JsonBody = null;
            if (cmdletContext.WriteCampaignRequest_MessageConfiguration_GCMMessage_JsonBody != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_JsonBody = cmdletContext.WriteCampaignRequest_MessageConfiguration_GCMMessage_JsonBody;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_JsonBody != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage.JsonBody = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_JsonBody;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_MediaUrl = null;
            if (cmdletContext.WriteCampaignRequest_MessageConfiguration_GCMMessage_MediaUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_MediaUrl = cmdletContext.WriteCampaignRequest_MessageConfiguration_GCMMessage_MediaUrl;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_MediaUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage.MediaUrl = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_MediaUrl;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessageIsNull = false;
            }
            System.Boolean? requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_SilentPush = null;
            if (cmdletContext.WriteCampaignRequest_MessageConfiguration_GCMMessage_SilentPush != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_SilentPush = cmdletContext.WriteCampaignRequest_MessageConfiguration_GCMMessage_SilentPush.Value;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_SilentPush != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage.SilentPush = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_SilentPush.Value;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_Title = null;
            if (cmdletContext.WriteCampaignRequest_MessageConfiguration_GCMMessage_Title != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_Title = cmdletContext.WriteCampaignRequest_MessageConfiguration_GCMMessage_Title;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_Title != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage.Title = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_Title;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_Url = null;
            if (cmdletContext.WriteCampaignRequest_MessageConfiguration_GCMMessage_Url != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_Url = cmdletContext.WriteCampaignRequest_MessageConfiguration_GCMMessage_Url;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_Url != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage.Url = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_Url;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessageIsNull = false;
            }
             // determine if requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage should be set to null
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessageIsNull)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage = null;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration.GCMMessage = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfigurationIsNull = false;
            }
             // determine if requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration should be set to null
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfigurationIsNull)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration = null;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration != null)
            {
                request.WriteCampaignRequest.MessageConfiguration = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration;
                requestWriteCampaignRequestIsNull = false;
            }
            Amazon.Pinpoint.Model.Schedule requestWriteCampaignRequest_writeCampaignRequest_Schedule = null;
            
             // populate Schedule
            bool requestWriteCampaignRequest_writeCampaignRequest_ScheduleIsNull = true;
            requestWriteCampaignRequest_writeCampaignRequest_Schedule = new Amazon.Pinpoint.Model.Schedule();
            System.String requestWriteCampaignRequest_writeCampaignRequest_Schedule_schedule_EndTime = null;
            if (cmdletContext.WriteCampaignRequest_Schedule_EndTime != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule_schedule_EndTime = cmdletContext.WriteCampaignRequest_Schedule_EndTime;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_Schedule_schedule_EndTime != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule.EndTime = requestWriteCampaignRequest_writeCampaignRequest_Schedule_schedule_EndTime;
                requestWriteCampaignRequest_writeCampaignRequest_ScheduleIsNull = false;
            }
            Amazon.Pinpoint.Frequency requestWriteCampaignRequest_writeCampaignRequest_Schedule_schedule_Frequency = null;
            if (cmdletContext.WriteCampaignRequest_Schedule_Frequency != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule_schedule_Frequency = cmdletContext.WriteCampaignRequest_Schedule_Frequency;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_Schedule_schedule_Frequency != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule.Frequency = requestWriteCampaignRequest_writeCampaignRequest_Schedule_schedule_Frequency;
                requestWriteCampaignRequest_writeCampaignRequest_ScheduleIsNull = false;
            }
            System.Boolean? requestWriteCampaignRequest_writeCampaignRequest_Schedule_schedule_IsLocalTime = null;
            if (cmdletContext.WriteCampaignRequest_Schedule_IsLocalTime != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule_schedule_IsLocalTime = cmdletContext.WriteCampaignRequest_Schedule_IsLocalTime.Value;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_Schedule_schedule_IsLocalTime != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule.IsLocalTime = requestWriteCampaignRequest_writeCampaignRequest_Schedule_schedule_IsLocalTime.Value;
                requestWriteCampaignRequest_writeCampaignRequest_ScheduleIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_Schedule_schedule_StartTime = null;
            if (cmdletContext.WriteCampaignRequest_Schedule_StartTime != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule_schedule_StartTime = cmdletContext.WriteCampaignRequest_Schedule_StartTime;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_Schedule_schedule_StartTime != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule.StartTime = requestWriteCampaignRequest_writeCampaignRequest_Schedule_schedule_StartTime;
                requestWriteCampaignRequest_writeCampaignRequest_ScheduleIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_Schedule_schedule_Timezone = null;
            if (cmdletContext.WriteCampaignRequest_Schedule_Timezone != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule_schedule_Timezone = cmdletContext.WriteCampaignRequest_Schedule_Timezone;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_Schedule_schedule_Timezone != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule.Timezone = requestWriteCampaignRequest_writeCampaignRequest_Schedule_schedule_Timezone;
                requestWriteCampaignRequest_writeCampaignRequest_ScheduleIsNull = false;
            }
            Amazon.Pinpoint.Model.QuietTime requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_QuietTime = null;
            
             // populate QuietTime
            bool requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_QuietTimeIsNull = true;
            requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_QuietTime = new Amazon.Pinpoint.Model.QuietTime();
            System.String requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_QuietTime_quietTime_End = null;
            if (cmdletContext.WriteCampaignRequest_Schedule_QuietTime_End != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_QuietTime_quietTime_End = cmdletContext.WriteCampaignRequest_Schedule_QuietTime_End;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_QuietTime_quietTime_End != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_QuietTime.End = requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_QuietTime_quietTime_End;
                requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_QuietTimeIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_QuietTime_quietTime_Start = null;
            if (cmdletContext.WriteCampaignRequest_Schedule_QuietTime_Start != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_QuietTime_quietTime_Start = cmdletContext.WriteCampaignRequest_Schedule_QuietTime_Start;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_QuietTime_quietTime_Start != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_QuietTime.Start = requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_QuietTime_quietTime_Start;
                requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_QuietTimeIsNull = false;
            }
             // determine if requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_QuietTime should be set to null
            if (requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_QuietTimeIsNull)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_QuietTime = null;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_QuietTime != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule.QuietTime = requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_QuietTime;
                requestWriteCampaignRequest_writeCampaignRequest_ScheduleIsNull = false;
            }
             // determine if requestWriteCampaignRequest_writeCampaignRequest_Schedule should be set to null
            if (requestWriteCampaignRequest_writeCampaignRequest_ScheduleIsNull)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule = null;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_Schedule != null)
            {
                request.WriteCampaignRequest.Schedule = requestWriteCampaignRequest_writeCampaignRequest_Schedule;
                requestWriteCampaignRequestIsNull = false;
            }
             // determine if request.WriteCampaignRequest should be set to null
            if (requestWriteCampaignRequestIsNull)
            {
                request.WriteCampaignRequest = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.CampaignResponse;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.Pinpoint.Model.UpdateCampaignResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.UpdateCampaignRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "UpdateCampaign");
            #if DESKTOP
            return client.UpdateCampaign(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.UpdateCampaignAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ApplicationId { get; set; }
            public System.String CampaignId { get; set; }
            public List<Amazon.Pinpoint.Model.WriteTreatmentResource> WriteCampaignRequest_AdditionalTreatments { get; set; }
            public System.String WriteCampaignRequest_Description { get; set; }
            public System.Int32? WriteCampaignRequest_HoldoutPercent { get; set; }
            public System.Boolean? WriteCampaignRequest_IsPaused { get; set; }
            public System.Int32? WriteCampaignRequest_Limits_Daily { get; set; }
            public System.Int32? WriteCampaignRequest_Limits_Total { get; set; }
            public Amazon.Pinpoint.Action WriteCampaignRequest_MessageConfiguration_APNSMessage_Action { get; set; }
            public System.String WriteCampaignRequest_MessageConfiguration_APNSMessage_Body { get; set; }
            public System.String WriteCampaignRequest_MessageConfiguration_APNSMessage_ImageIconUrl { get; set; }
            public System.String WriteCampaignRequest_MessageConfiguration_APNSMessage_ImageSmallIconUrl { get; set; }
            public System.String WriteCampaignRequest_MessageConfiguration_APNSMessage_ImageUrl { get; set; }
            public System.String WriteCampaignRequest_MessageConfiguration_APNSMessage_JsonBody { get; set; }
            public System.String WriteCampaignRequest_MessageConfiguration_APNSMessage_MediaUrl { get; set; }
            public System.Boolean? WriteCampaignRequest_MessageConfiguration_APNSMessage_SilentPush { get; set; }
            public System.String WriteCampaignRequest_MessageConfiguration_APNSMessage_Title { get; set; }
            public System.String WriteCampaignRequest_MessageConfiguration_APNSMessage_Url { get; set; }
            public Amazon.Pinpoint.Action WriteCampaignRequest_MessageConfiguration_DefaultMessage_Action { get; set; }
            public System.String WriteCampaignRequest_MessageConfiguration_DefaultMessage_Body { get; set; }
            public System.String WriteCampaignRequest_MessageConfiguration_DefaultMessage_ImageIconUrl { get; set; }
            public System.String WriteCampaignRequest_MessageConfiguration_DefaultMessage_ImageSmallIconUrl { get; set; }
            public System.String WriteCampaignRequest_MessageConfiguration_DefaultMessage_ImageUrl { get; set; }
            public System.String WriteCampaignRequest_MessageConfiguration_DefaultMessage_JsonBody { get; set; }
            public System.String WriteCampaignRequest_MessageConfiguration_DefaultMessage_MediaUrl { get; set; }
            public System.Boolean? WriteCampaignRequest_MessageConfiguration_DefaultMessage_SilentPush { get; set; }
            public System.String WriteCampaignRequest_MessageConfiguration_DefaultMessage_Title { get; set; }
            public System.String WriteCampaignRequest_MessageConfiguration_DefaultMessage_Url { get; set; }
            public System.String WriteCampaignRequest_MessageConfiguration_EmailMessage_Body { get; set; }
            public System.String WriteCampaignRequest_MessageConfiguration_EmailMessage_HtmlBody { get; set; }
            public System.String WriteCampaignRequest_MessageConfiguration_EmailMessage_Title { get; set; }
            public Amazon.Pinpoint.Action WriteCampaignRequest_MessageConfiguration_GCMMessage_Action { get; set; }
            public System.String WriteCampaignRequest_MessageConfiguration_GCMMessage_Body { get; set; }
            public System.String WriteCampaignRequest_MessageConfiguration_GCMMessage_ImageIconUrl { get; set; }
            public System.String WriteCampaignRequest_MessageConfiguration_GCMMessage_ImageSmallIconUrl { get; set; }
            public System.String WriteCampaignRequest_MessageConfiguration_GCMMessage_ImageUrl { get; set; }
            public System.String WriteCampaignRequest_MessageConfiguration_GCMMessage_JsonBody { get; set; }
            public System.String WriteCampaignRequest_MessageConfiguration_GCMMessage_MediaUrl { get; set; }
            public System.Boolean? WriteCampaignRequest_MessageConfiguration_GCMMessage_SilentPush { get; set; }
            public System.String WriteCampaignRequest_MessageConfiguration_GCMMessage_Title { get; set; }
            public System.String WriteCampaignRequest_MessageConfiguration_GCMMessage_Url { get; set; }
            public System.String WriteCampaignRequest_MessageConfiguration_SMSMessage_Body { get; set; }
            public Amazon.Pinpoint.MessageType WriteCampaignRequest_MessageConfiguration_SMSMessage_MessageType { get; set; }
            public System.String WriteCampaignRequest_MessageConfiguration_SMSMessage_SenderId { get; set; }
            public System.String WriteCampaignRequest_Name { get; set; }
            public System.String WriteCampaignRequest_Schedule_EndTime { get; set; }
            public Amazon.Pinpoint.Frequency WriteCampaignRequest_Schedule_Frequency { get; set; }
            public System.Boolean? WriteCampaignRequest_Schedule_IsLocalTime { get; set; }
            public System.String WriteCampaignRequest_Schedule_QuietTime_End { get; set; }
            public System.String WriteCampaignRequest_Schedule_QuietTime_Start { get; set; }
            public System.String WriteCampaignRequest_Schedule_StartTime { get; set; }
            public System.String WriteCampaignRequest_Schedule_Timezone { get; set; }
            public System.String WriteCampaignRequest_SegmentId { get; set; }
            public System.Int32? WriteCampaignRequest_SegmentVersion { get; set; }
            public System.String WriteCampaignRequest_TreatmentDescription { get; set; }
            public System.String WriteCampaignRequest_TreatmentName { get; set; }
        }
        
    }
}
