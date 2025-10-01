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
using Amazon.ChimeSDKMeetings;
using Amazon.ChimeSDKMeetings.Model;

namespace Amazon.PowerShell.Cmdlets.CHMTG
{
    /// <summary>
    /// Creates a new Amazon Chime SDK meeting in the specified media Region, with attendees.
    /// For more information about specifying media Regions, see <a href="https://docs.aws.amazon.com/chime-sdk/latest/dg/sdk-available-regions">Available
    /// Regions</a> and <a href="https://docs.aws.amazon.com/chime-sdk/latest/dg/chime-sdk-meetings-regions.html">Using
    /// meeting Regions</a>, both in the <i>Amazon Chime SDK Developer Guide</i>. For more
    /// information about the Amazon Chime SDK, see <a href="https://docs.aws.amazon.com/chime-sdk/latest/dg/meetings-sdk.html">Using
    /// the Amazon Chime SDK</a> in the <i>Amazon Chime SDK Developer Guide</i>. 
    /// 
    ///  <note><para>
    /// If you use this API in conjuction with the and APIs, and you don't specify the <c>MeetingFeatures.Content.MaxResolution</c>
    /// or <c>MeetingFeatures.Video.MaxResolution</c> parameters, the following defaults are
    /// used:
    /// </para><ul><li><para>
    /// Content.MaxResolution: FHD
    /// </para></li><li><para>
    /// Video.MaxResolution: HD
    /// </para></li></ul></note>
    /// </summary>
    [Cmdlet("New", "CHMTGMeetingWithAttendee", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ChimeSDKMeetings.Model.CreateMeetingWithAttendeesResponse")]
    [AWSCmdlet("Calls the Amazon Chime SDK Meetings CreateMeetingWithAttendees API operation.", Operation = new[] {"CreateMeetingWithAttendees"}, SelectReturnType = typeof(Amazon.ChimeSDKMeetings.Model.CreateMeetingWithAttendeesResponse))]
    [AWSCmdletOutput("Amazon.ChimeSDKMeetings.Model.CreateMeetingWithAttendeesResponse",
        "This cmdlet returns an Amazon.ChimeSDKMeetings.Model.CreateMeetingWithAttendeesResponse object containing multiple properties."
    )]
    public partial class NewCHMTGMeetingWithAttendeeCmdlet : AmazonChimeSDKMeetingsClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Attendee
        /// <summary>
        /// <para>
        /// <para>The attendee information, including attendees' IDs and join tokens.</para>
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
        [Alias("Attendees")]
        public Amazon.ChimeSDKMeetings.Model.CreateAttendeeRequestItem[] Attendee { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the client request. Use a different token for different
        /// meetings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter Audio_EchoReduction
        /// <summary>
        /// <para>
        /// <para>Makes echo reduction available to clients who connect to the meeting.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MeetingFeatures_Audio_EchoReduction")]
        [AWSConstantClassSource("Amazon.ChimeSDKMeetings.MeetingFeatureStatus")]
        public Amazon.ChimeSDKMeetings.MeetingFeatureStatus Audio_EchoReduction { get; set; }
        #endregion
        
        #region Parameter ExternalMeetingId
        /// <summary>
        /// <para>
        /// <para>The external meeting ID.</para><para>Pattern: <c>[-_&amp;@+=,(){}\[\]\/«».:|'"#a-zA-Z0-9À-ÿ\s]*</c></para><para>Values that begin with <c>aws:</c> are reserved. You can't configure a value that
        /// uses this prefix. Case insensitive.</para>
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
        public System.String ExternalMeetingId { get; set; }
        #endregion
        
        #region Parameter NotificationsConfiguration_LambdaFunctionArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Amazon Web Services Lambda function in the notifications configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NotificationsConfiguration_LambdaFunctionArn { get; set; }
        #endregion
        
        #region Parameter Attendee_MaxCount
        /// <summary>
        /// <para>
        /// <para>The maximum number of attendees allowed into the meeting.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MeetingFeatures_Attendee_MaxCount")]
        public System.Int32? Attendee_MaxCount { get; set; }
        #endregion
        
        #region Parameter Content_MaxResolution
        /// <summary>
        /// <para>
        /// <para>The maximum resolution for the meeting content.</para><note><para>Defaults to <c>FHD</c>. To use <c>UHD</c>, you must also provide a <c>MeetingFeatures:Attendee:MaxCount</c>
        /// value and override the default size limit of 250 attendees.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MeetingFeatures_Content_MaxResolution")]
        [AWSConstantClassSource("Amazon.ChimeSDKMeetings.ContentResolution")]
        public Amazon.ChimeSDKMeetings.ContentResolution Content_MaxResolution { get; set; }
        #endregion
        
        #region Parameter Video_MaxResolution
        /// <summary>
        /// <para>
        /// <para>The maximum video resolution for the meeting. Applies to all attendees.</para><note><para>Defaults to <c>HD</c>. To use <c>FHD</c>, you must also provide a <c>MeetingFeatures:Attendee:MaxCount</c>
        /// value and override the default size limit of 250 attendees.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MeetingFeatures_Video_MaxResolution")]
        [AWSConstantClassSource("Amazon.ChimeSDKMeetings.VideoResolution")]
        public Amazon.ChimeSDKMeetings.VideoResolution Video_MaxResolution { get; set; }
        #endregion
        
        #region Parameter MediaPlacementNetworkType
        /// <summary>
        /// <para>
        /// <para>The type of network for the media placement. Either IPv4 only or dual-stack (IPv4
        /// and IPv6).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ChimeSDKMeetings.MediaPlacementNetworkType")]
        public Amazon.ChimeSDKMeetings.MediaPlacementNetworkType MediaPlacementNetworkType { get; set; }
        #endregion
        
        #region Parameter MediaRegion
        /// <summary>
        /// <para>
        /// <para>The Region in which to create the meeting.</para><para> Available values: <c>af-south-1</c>, <c>ap-northeast-1</c>, <c>ap-northeast-2</c>,
        /// <c>ap-south-1</c>, <c>ap-southeast-1</c>, <c>ap-southeast-2</c>, <c>ca-central-1</c>,
        /// <c>eu-central-1</c>, <c>eu-north-1</c>, <c>eu-south-1</c>, <c>eu-west-1</c>, <c>eu-west-2</c>,
        /// <c>eu-west-3</c>, <c>sa-east-1</c>, <c>us-east-1</c>, <c>us-east-2</c>, <c>us-west-1</c>,
        /// <c>us-west-2</c>. </para><para>Available values in Amazon Web Services GovCloud (US) Regions: <c>us-gov-east-1</c>,
        /// <c>us-gov-west-1</c>.</para>
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
        public System.String MediaRegion { get; set; }
        #endregion
        
        #region Parameter MeetingHostId
        /// <summary>
        /// <para>
        /// <para>Reserved.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MeetingHostId { get; set; }
        #endregion
        
        #region Parameter PrimaryMeetingId
        /// <summary>
        /// <para>
        /// <para>When specified, replicates the media from the primary meeting to the new meeting.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PrimaryMeetingId { get; set; }
        #endregion
        
        #region Parameter NotificationsConfiguration_SnsTopicArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the SNS topic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NotificationsConfiguration_SnsTopicArn { get; set; }
        #endregion
        
        #region Parameter NotificationsConfiguration_SqsQueueArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the SQS queue.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NotificationsConfiguration_SqsQueueArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags in the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ChimeSDKMeetings.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TenantId
        /// <summary>
        /// <para>
        /// <para>A consistent and opaque identifier, created and maintained by the builder to represent
        /// a segment of their users.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TenantIds")]
        public System.String[] TenantId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKMeetings.Model.CreateMeetingWithAttendeesResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKMeetings.Model.CreateMeetingWithAttendeesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ClientRequestToken parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ClientRequestToken' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ClientRequestToken' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ExternalMeetingId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CHMTGMeetingWithAttendee (CreateMeetingWithAttendees)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKMeetings.Model.CreateMeetingWithAttendeesResponse, NewCHMTGMeetingWithAttendeeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ClientRequestToken;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Attendee != null)
            {
                context.Attendee = new List<Amazon.ChimeSDKMeetings.Model.CreateAttendeeRequestItem>(this.Attendee);
            }
            #if MODULAR
            if (this.Attendee == null && ParameterWasBound(nameof(this.Attendee)))
            {
                WriteWarning("You are passing $null as a value for parameter Attendee which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientRequestToken = this.ClientRequestToken;
            context.ExternalMeetingId = this.ExternalMeetingId;
            #if MODULAR
            if (this.ExternalMeetingId == null && ParameterWasBound(nameof(this.ExternalMeetingId)))
            {
                WriteWarning("You are passing $null as a value for parameter ExternalMeetingId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MediaPlacementNetworkType = this.MediaPlacementNetworkType;
            context.MediaRegion = this.MediaRegion;
            #if MODULAR
            if (this.MediaRegion == null && ParameterWasBound(nameof(this.MediaRegion)))
            {
                WriteWarning("You are passing $null as a value for parameter MediaRegion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Attendee_MaxCount = this.Attendee_MaxCount;
            context.Audio_EchoReduction = this.Audio_EchoReduction;
            context.Content_MaxResolution = this.Content_MaxResolution;
            context.Video_MaxResolution = this.Video_MaxResolution;
            context.MeetingHostId = this.MeetingHostId;
            context.NotificationsConfiguration_LambdaFunctionArn = this.NotificationsConfiguration_LambdaFunctionArn;
            context.NotificationsConfiguration_SnsTopicArn = this.NotificationsConfiguration_SnsTopicArn;
            context.NotificationsConfiguration_SqsQueueArn = this.NotificationsConfiguration_SqsQueueArn;
            context.PrimaryMeetingId = this.PrimaryMeetingId;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ChimeSDKMeetings.Model.Tag>(this.Tag);
            }
            if (this.TenantId != null)
            {
                context.TenantId = new List<System.String>(this.TenantId);
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
            var request = new Amazon.ChimeSDKMeetings.Model.CreateMeetingWithAttendeesRequest();
            
            if (cmdletContext.Attendee != null)
            {
                request.Attendees = cmdletContext.Attendee;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.ExternalMeetingId != null)
            {
                request.ExternalMeetingId = cmdletContext.ExternalMeetingId;
            }
            if (cmdletContext.MediaPlacementNetworkType != null)
            {
                request.MediaPlacementNetworkType = cmdletContext.MediaPlacementNetworkType;
            }
            if (cmdletContext.MediaRegion != null)
            {
                request.MediaRegion = cmdletContext.MediaRegion;
            }
            
             // populate MeetingFeatures
            var requestMeetingFeaturesIsNull = true;
            request.MeetingFeatures = new Amazon.ChimeSDKMeetings.Model.MeetingFeaturesConfiguration();
            Amazon.ChimeSDKMeetings.Model.AttendeeFeatures requestMeetingFeatures_meetingFeatures_Attendee = null;
            
             // populate Attendee
            var requestMeetingFeatures_meetingFeatures_AttendeeIsNull = true;
            requestMeetingFeatures_meetingFeatures_Attendee = new Amazon.ChimeSDKMeetings.Model.AttendeeFeatures();
            System.Int32? requestMeetingFeatures_meetingFeatures_Attendee_attendee_MaxCount = null;
            if (cmdletContext.Attendee_MaxCount != null)
            {
                requestMeetingFeatures_meetingFeatures_Attendee_attendee_MaxCount = cmdletContext.Attendee_MaxCount.Value;
            }
            if (requestMeetingFeatures_meetingFeatures_Attendee_attendee_MaxCount != null)
            {
                requestMeetingFeatures_meetingFeatures_Attendee.MaxCount = requestMeetingFeatures_meetingFeatures_Attendee_attendee_MaxCount.Value;
                requestMeetingFeatures_meetingFeatures_AttendeeIsNull = false;
            }
             // determine if requestMeetingFeatures_meetingFeatures_Attendee should be set to null
            if (requestMeetingFeatures_meetingFeatures_AttendeeIsNull)
            {
                requestMeetingFeatures_meetingFeatures_Attendee = null;
            }
            if (requestMeetingFeatures_meetingFeatures_Attendee != null)
            {
                request.MeetingFeatures.Attendee = requestMeetingFeatures_meetingFeatures_Attendee;
                requestMeetingFeaturesIsNull = false;
            }
            Amazon.ChimeSDKMeetings.Model.AudioFeatures requestMeetingFeatures_meetingFeatures_Audio = null;
            
             // populate Audio
            var requestMeetingFeatures_meetingFeatures_AudioIsNull = true;
            requestMeetingFeatures_meetingFeatures_Audio = new Amazon.ChimeSDKMeetings.Model.AudioFeatures();
            Amazon.ChimeSDKMeetings.MeetingFeatureStatus requestMeetingFeatures_meetingFeatures_Audio_audio_EchoReduction = null;
            if (cmdletContext.Audio_EchoReduction != null)
            {
                requestMeetingFeatures_meetingFeatures_Audio_audio_EchoReduction = cmdletContext.Audio_EchoReduction;
            }
            if (requestMeetingFeatures_meetingFeatures_Audio_audio_EchoReduction != null)
            {
                requestMeetingFeatures_meetingFeatures_Audio.EchoReduction = requestMeetingFeatures_meetingFeatures_Audio_audio_EchoReduction;
                requestMeetingFeatures_meetingFeatures_AudioIsNull = false;
            }
             // determine if requestMeetingFeatures_meetingFeatures_Audio should be set to null
            if (requestMeetingFeatures_meetingFeatures_AudioIsNull)
            {
                requestMeetingFeatures_meetingFeatures_Audio = null;
            }
            if (requestMeetingFeatures_meetingFeatures_Audio != null)
            {
                request.MeetingFeatures.Audio = requestMeetingFeatures_meetingFeatures_Audio;
                requestMeetingFeaturesIsNull = false;
            }
            Amazon.ChimeSDKMeetings.Model.ContentFeatures requestMeetingFeatures_meetingFeatures_Content = null;
            
             // populate Content
            var requestMeetingFeatures_meetingFeatures_ContentIsNull = true;
            requestMeetingFeatures_meetingFeatures_Content = new Amazon.ChimeSDKMeetings.Model.ContentFeatures();
            Amazon.ChimeSDKMeetings.ContentResolution requestMeetingFeatures_meetingFeatures_Content_content_MaxResolution = null;
            if (cmdletContext.Content_MaxResolution != null)
            {
                requestMeetingFeatures_meetingFeatures_Content_content_MaxResolution = cmdletContext.Content_MaxResolution;
            }
            if (requestMeetingFeatures_meetingFeatures_Content_content_MaxResolution != null)
            {
                requestMeetingFeatures_meetingFeatures_Content.MaxResolution = requestMeetingFeatures_meetingFeatures_Content_content_MaxResolution;
                requestMeetingFeatures_meetingFeatures_ContentIsNull = false;
            }
             // determine if requestMeetingFeatures_meetingFeatures_Content should be set to null
            if (requestMeetingFeatures_meetingFeatures_ContentIsNull)
            {
                requestMeetingFeatures_meetingFeatures_Content = null;
            }
            if (requestMeetingFeatures_meetingFeatures_Content != null)
            {
                request.MeetingFeatures.Content = requestMeetingFeatures_meetingFeatures_Content;
                requestMeetingFeaturesIsNull = false;
            }
            Amazon.ChimeSDKMeetings.Model.VideoFeatures requestMeetingFeatures_meetingFeatures_Video = null;
            
             // populate Video
            var requestMeetingFeatures_meetingFeatures_VideoIsNull = true;
            requestMeetingFeatures_meetingFeatures_Video = new Amazon.ChimeSDKMeetings.Model.VideoFeatures();
            Amazon.ChimeSDKMeetings.VideoResolution requestMeetingFeatures_meetingFeatures_Video_video_MaxResolution = null;
            if (cmdletContext.Video_MaxResolution != null)
            {
                requestMeetingFeatures_meetingFeatures_Video_video_MaxResolution = cmdletContext.Video_MaxResolution;
            }
            if (requestMeetingFeatures_meetingFeatures_Video_video_MaxResolution != null)
            {
                requestMeetingFeatures_meetingFeatures_Video.MaxResolution = requestMeetingFeatures_meetingFeatures_Video_video_MaxResolution;
                requestMeetingFeatures_meetingFeatures_VideoIsNull = false;
            }
             // determine if requestMeetingFeatures_meetingFeatures_Video should be set to null
            if (requestMeetingFeatures_meetingFeatures_VideoIsNull)
            {
                requestMeetingFeatures_meetingFeatures_Video = null;
            }
            if (requestMeetingFeatures_meetingFeatures_Video != null)
            {
                request.MeetingFeatures.Video = requestMeetingFeatures_meetingFeatures_Video;
                requestMeetingFeaturesIsNull = false;
            }
             // determine if request.MeetingFeatures should be set to null
            if (requestMeetingFeaturesIsNull)
            {
                request.MeetingFeatures = null;
            }
            if (cmdletContext.MeetingHostId != null)
            {
                request.MeetingHostId = cmdletContext.MeetingHostId;
            }
            
             // populate NotificationsConfiguration
            var requestNotificationsConfigurationIsNull = true;
            request.NotificationsConfiguration = new Amazon.ChimeSDKMeetings.Model.NotificationsConfiguration();
            System.String requestNotificationsConfiguration_notificationsConfiguration_LambdaFunctionArn = null;
            if (cmdletContext.NotificationsConfiguration_LambdaFunctionArn != null)
            {
                requestNotificationsConfiguration_notificationsConfiguration_LambdaFunctionArn = cmdletContext.NotificationsConfiguration_LambdaFunctionArn;
            }
            if (requestNotificationsConfiguration_notificationsConfiguration_LambdaFunctionArn != null)
            {
                request.NotificationsConfiguration.LambdaFunctionArn = requestNotificationsConfiguration_notificationsConfiguration_LambdaFunctionArn;
                requestNotificationsConfigurationIsNull = false;
            }
            System.String requestNotificationsConfiguration_notificationsConfiguration_SnsTopicArn = null;
            if (cmdletContext.NotificationsConfiguration_SnsTopicArn != null)
            {
                requestNotificationsConfiguration_notificationsConfiguration_SnsTopicArn = cmdletContext.NotificationsConfiguration_SnsTopicArn;
            }
            if (requestNotificationsConfiguration_notificationsConfiguration_SnsTopicArn != null)
            {
                request.NotificationsConfiguration.SnsTopicArn = requestNotificationsConfiguration_notificationsConfiguration_SnsTopicArn;
                requestNotificationsConfigurationIsNull = false;
            }
            System.String requestNotificationsConfiguration_notificationsConfiguration_SqsQueueArn = null;
            if (cmdletContext.NotificationsConfiguration_SqsQueueArn != null)
            {
                requestNotificationsConfiguration_notificationsConfiguration_SqsQueueArn = cmdletContext.NotificationsConfiguration_SqsQueueArn;
            }
            if (requestNotificationsConfiguration_notificationsConfiguration_SqsQueueArn != null)
            {
                request.NotificationsConfiguration.SqsQueueArn = requestNotificationsConfiguration_notificationsConfiguration_SqsQueueArn;
                requestNotificationsConfigurationIsNull = false;
            }
             // determine if request.NotificationsConfiguration should be set to null
            if (requestNotificationsConfigurationIsNull)
            {
                request.NotificationsConfiguration = null;
            }
            if (cmdletContext.PrimaryMeetingId != null)
            {
                request.PrimaryMeetingId = cmdletContext.PrimaryMeetingId;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TenantId != null)
            {
                request.TenantIds = cmdletContext.TenantId;
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
        
        private Amazon.ChimeSDKMeetings.Model.CreateMeetingWithAttendeesResponse CallAWSServiceOperation(IAmazonChimeSDKMeetings client, Amazon.ChimeSDKMeetings.Model.CreateMeetingWithAttendeesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Meetings", "CreateMeetingWithAttendees");
            try
            {
                #if DESKTOP
                return client.CreateMeetingWithAttendees(request);
                #elif CORECLR
                return client.CreateMeetingWithAttendeesAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.ChimeSDKMeetings.Model.CreateAttendeeRequestItem> Attendee { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.String ExternalMeetingId { get; set; }
            public Amazon.ChimeSDKMeetings.MediaPlacementNetworkType MediaPlacementNetworkType { get; set; }
            public System.String MediaRegion { get; set; }
            public System.Int32? Attendee_MaxCount { get; set; }
            public Amazon.ChimeSDKMeetings.MeetingFeatureStatus Audio_EchoReduction { get; set; }
            public Amazon.ChimeSDKMeetings.ContentResolution Content_MaxResolution { get; set; }
            public Amazon.ChimeSDKMeetings.VideoResolution Video_MaxResolution { get; set; }
            public System.String MeetingHostId { get; set; }
            public System.String NotificationsConfiguration_LambdaFunctionArn { get; set; }
            public System.String NotificationsConfiguration_SnsTopicArn { get; set; }
            public System.String NotificationsConfiguration_SqsQueueArn { get; set; }
            public System.String PrimaryMeetingId { get; set; }
            public List<Amazon.ChimeSDKMeetings.Model.Tag> Tag { get; set; }
            public List<System.String> TenantId { get; set; }
            public System.Func<Amazon.ChimeSDKMeetings.Model.CreateMeetingWithAttendeesResponse, NewCHMTGMeetingWithAttendeeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
