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
    /// Creates a new campaign for an application or updates the settings of an existing campaign
    /// for an application.
    /// </summary>
    [Cmdlet("New", "PINCampaign", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.CampaignResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint CreateCampaign API operation.", Operation = new[] {"CreateCampaign"}, SelectReturnType = typeof(Amazon.Pinpoint.Model.CreateCampaignResponse))]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.CampaignResponse or Amazon.Pinpoint.Model.CreateCampaignResponse",
        "This cmdlet returns an Amazon.Pinpoint.Model.CampaignResponse object.",
        "The service call response (type Amazon.Pinpoint.Model.CreateCampaignResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewPINCampaignCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ADMMessage_Action
        /// <summary>
        /// <para>
        /// <para>The action to occur if a recipient taps the push notification. Valid values are:</para><ul><li><para>OPEN_APP - Your app opens or it becomes the foreground app if it was sent to the background.
        /// This is the default action.</para></li><li><para>DEEP_LINK - Your app opens and displays a designated user interface in the app. This
        /// setting uses the deep-linking features of iOS and Android.</para></li><li><para>URL - The default mobile browser on the recipient's device opens and loads the web
        /// page at a URL that you specify.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_ADMMessage_Action")]
        [AWSConstantClassSource("Amazon.Pinpoint.Action")]
        public Amazon.Pinpoint.Action ADMMessage_Action { get; set; }
        #endregion
        
        #region Parameter APNSMessage_Action
        /// <summary>
        /// <para>
        /// <para>The action to occur if a recipient taps the push notification. Valid values are:</para><ul><li><para>OPEN_APP - Your app opens or it becomes the foreground app if it was sent to the background.
        /// This is the default action.</para></li><li><para>DEEP_LINK - Your app opens and displays a designated user interface in the app. This
        /// setting uses the deep-linking features of iOS and Android.</para></li><li><para>URL - The default mobile browser on the recipient's device opens and loads the web
        /// page at a URL that you specify.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_APNSMessage_Action")]
        [AWSConstantClassSource("Amazon.Pinpoint.Action")]
        public Amazon.Pinpoint.Action APNSMessage_Action { get; set; }
        #endregion
        
        #region Parameter BaiduMessage_Action
        /// <summary>
        /// <para>
        /// <para>The action to occur if a recipient taps the push notification. Valid values are:</para><ul><li><para>OPEN_APP - Your app opens or it becomes the foreground app if it was sent to the background.
        /// This is the default action.</para></li><li><para>DEEP_LINK - Your app opens and displays a designated user interface in the app. This
        /// setting uses the deep-linking features of iOS and Android.</para></li><li><para>URL - The default mobile browser on the recipient's device opens and loads the web
        /// page at a URL that you specify.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_BaiduMessage_Action")]
        [AWSConstantClassSource("Amazon.Pinpoint.Action")]
        public Amazon.Pinpoint.Action BaiduMessage_Action { get; set; }
        #endregion
        
        #region Parameter DefaultMessage_Action
        /// <summary>
        /// <para>
        /// <para>The action to occur if a recipient taps the push notification. Valid values are:</para><ul><li><para>OPEN_APP - Your app opens or it becomes the foreground app if it was sent to the background.
        /// This is the default action.</para></li><li><para>DEEP_LINK - Your app opens and displays a designated user interface in the app. This
        /// setting uses the deep-linking features of iOS and Android.</para></li><li><para>URL - The default mobile browser on the recipient's device opens and loads the web
        /// page at a URL that you specify.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_DefaultMessage_Action")]
        [AWSConstantClassSource("Amazon.Pinpoint.Action")]
        public Amazon.Pinpoint.Action DefaultMessage_Action { get; set; }
        #endregion
        
        #region Parameter GCMMessage_Action
        /// <summary>
        /// <para>
        /// <para>The action to occur if a recipient taps the push notification. Valid values are:</para><ul><li><para>OPEN_APP - Your app opens or it becomes the foreground app if it was sent to the background.
        /// This is the default action.</para></li><li><para>DEEP_LINK - Your app opens and displays a designated user interface in the app. This
        /// setting uses the deep-linking features of iOS and Android.</para></li><li><para>URL - The default mobile browser on the recipient's device opens and loads the web
        /// page at a URL that you specify.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_GCMMessage_Action")]
        [AWSConstantClassSource("Amazon.Pinpoint.Action")]
        public Amazon.Pinpoint.Action GCMMessage_Action { get; set; }
        #endregion
        
        #region Parameter WriteCampaignRequest_AdditionalTreatment
        /// <summary>
        /// <para>
        /// <para>An array of requests that defines additional treatments for the campaign, in addition
        /// to the default treatment for the campaign.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_AdditionalTreatments")]
        public Amazon.Pinpoint.Model.WriteTreatmentResource[] WriteCampaignRequest_AdditionalTreatment { get; set; }
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
        
        #region Parameter Dimensions_Attribute
        /// <summary>
        /// <para>
        /// <para>One or more custom attributes that your application reports to Amazon Pinpoint. You
        /// can use these attributes as selection criteria when you create an event filter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_Schedule_EventFilter_Dimensions_Attributes")]
        public System.Collections.Hashtable Dimensions_Attribute { get; set; }
        #endregion
        
        #region Parameter ADMMessage_Body
        /// <summary>
        /// <para>
        /// <para>The body of the notification message. The maximum number of characters is 200.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_ADMMessage_Body")]
        public System.String ADMMessage_Body { get; set; }
        #endregion
        
        #region Parameter APNSMessage_Body
        /// <summary>
        /// <para>
        /// <para>The body of the notification message. The maximum number of characters is 200.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_APNSMessage_Body")]
        public System.String APNSMessage_Body { get; set; }
        #endregion
        
        #region Parameter BaiduMessage_Body
        /// <summary>
        /// <para>
        /// <para>The body of the notification message. The maximum number of characters is 200.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_BaiduMessage_Body")]
        public System.String BaiduMessage_Body { get; set; }
        #endregion
        
        #region Parameter DefaultMessage_Body
        /// <summary>
        /// <para>
        /// <para>The body of the notification message. The maximum number of characters is 200.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_DefaultMessage_Body")]
        public System.String DefaultMessage_Body { get; set; }
        #endregion
        
        #region Parameter EmailMessage_Body
        /// <summary>
        /// <para>
        /// <para>The body of the email for recipients whose email clients don't render HTML content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_EmailMessage_Body")]
        public System.String EmailMessage_Body { get; set; }
        #endregion
        
        #region Parameter GCMMessage_Body
        /// <summary>
        /// <para>
        /// <para>The body of the notification message. The maximum number of characters is 200.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_GCMMessage_Body")]
        public System.String GCMMessage_Body { get; set; }
        #endregion
        
        #region Parameter InAppMessage_Body
        /// <summary>
        /// <para>
        /// <para>The message body of the notification, the email body or the text message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_InAppMessage_Body")]
        public System.String InAppMessage_Body { get; set; }
        #endregion
        
        #region Parameter SMSMessage_Body
        /// <summary>
        /// <para>
        /// <para>The body of the SMS message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_SMSMessage_Body")]
        public System.String SMSMessage_Body { get; set; }
        #endregion
        
        #region Parameter InAppMessage_Content
        /// <summary>
        /// <para>
        /// <para>In-app message content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_InAppMessage_Content")]
        public Amazon.Pinpoint.Model.InAppMessageContent[] InAppMessage_Content { get; set; }
        #endregion
        
        #region Parameter InAppMessage_CustomConfig
        /// <summary>
        /// <para>
        /// <para>Custom config to be sent to client.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_InAppMessage_CustomConfig")]
        public System.Collections.Hashtable InAppMessage_CustomConfig { get; set; }
        #endregion
        
        #region Parameter Limits_Daily
        /// <summary>
        /// <para>
        /// <para>The maximum number of messages that a campaign can send to a single endpoint during
        /// a 24-hour period. For an application, this value specifies the default limit for the
        /// number of messages that campaigns and journeys can send to a single endpoint during
        /// a 24-hour period. The maximum value is 100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_Limits_Daily")]
        public System.Int32? Limits_Daily { get; set; }
        #endregion
        
        #region Parameter CustomMessage_Data
        /// <summary>
        /// <para>
        /// <para>The raw, JSON-formatted string to use as the payload for the message. The maximum
        /// size is 5 KB.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_CustomMessage_Data")]
        public System.String CustomMessage_Data { get; set; }
        #endregion
        
        #region Parameter CustomDeliveryConfiguration_DeliveryUri
        /// <summary>
        /// <para>
        /// <para>The destination to send the campaign or treatment to. This value can be one of the
        /// following:</para><ul><li><para>The name or Amazon Resource Name (ARN) of an AWS Lambda function to invoke to handle
        /// delivery of the campaign or treatment.</para></li><li><para>The URL for a web application or service that supports HTTPS and can receive the message.
        /// The URL has to be a full URL, including the HTTPS protocol.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_CustomDeliveryConfiguration_DeliveryUri")]
        public System.String CustomDeliveryConfiguration_DeliveryUri { get; set; }
        #endregion
        
        #region Parameter WriteCampaignRequest_Description
        /// <summary>
        /// <para>
        /// <para>A custom description of the campaign.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WriteCampaignRequest_Description { get; set; }
        #endregion
        
        #region Parameter EventType_DimensionType
        /// <summary>
        /// <para>
        /// <para>The type of segment dimension to use. Valid values are: INCLUSIVE, endpoints that
        /// match the criteria are included in the segment; and, EXCLUSIVE, endpoints that match
        /// the criteria are excluded from the segment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_Schedule_EventFilter_Dimensions_EventType_DimensionType")]
        [AWSConstantClassSource("Amazon.Pinpoint.DimensionType")]
        public Amazon.Pinpoint.DimensionType EventType_DimensionType { get; set; }
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
        [Alias("WriteCampaignRequest_Schedule_QuietTime_End")]
        public System.String QuietTime_End { get; set; }
        #endregion
        
        #region Parameter CustomDeliveryConfiguration_EndpointType
        /// <summary>
        /// <para>
        /// <para>The types of endpoints to send the campaign or treatment to. Each valid value maps
        /// to a type of channel that you can associate with an endpoint by using the ChannelType
        /// property of an endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_CustomDeliveryConfiguration_EndpointTypes")]
        public System.String[] CustomDeliveryConfiguration_EndpointType { get; set; }
        #endregion
        
        #region Parameter Schedule_EndTime
        /// <summary>
        /// <para>
        /// <para>The scheduled time, in ISO 8601 format, when the campaign ended or will end.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_Schedule_EndTime")]
        public System.String Schedule_EndTime { get; set; }
        #endregion
        
        #region Parameter SMSMessage_EntityId
        /// <summary>
        /// <para>
        /// <para>The entity ID or Principal Entity (PE) id received from the regulatory body for sending
        /// SMS in your country.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_SMSMessage_EntityId")]
        public System.String SMSMessage_EntityId { get; set; }
        #endregion
        
        #region Parameter EventFilter_FilterType
        /// <summary>
        /// <para>
        /// <para>The type of event that causes the campaign to be sent. Valid values are: SYSTEM, sends
        /// the campaign when a system event occurs; and, ENDPOINT, sends the campaign when an
        /// endpoint event (<link linkend="apps-application-id-events">Events</link> resource)
        /// occurs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_Schedule_EventFilter_FilterType")]
        [AWSConstantClassSource("Amazon.Pinpoint.FilterType")]
        public Amazon.Pinpoint.FilterType EventFilter_FilterType { get; set; }
        #endregion
        
        #region Parameter Schedule_Frequency
        /// <summary>
        /// <para>
        /// <para>Specifies how often the campaign is sent or whether the campaign is sent in response
        /// to a specific event.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_Schedule_Frequency")]
        [AWSConstantClassSource("Amazon.Pinpoint.Frequency")]
        public Amazon.Pinpoint.Frequency Schedule_Frequency { get; set; }
        #endregion
        
        #region Parameter EmailMessage_FromAddress
        /// <summary>
        /// <para>
        /// <para>The verified email address to send the email from. The default address is the FromAddress
        /// specified for the email channel for the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_EmailMessage_FromAddress")]
        public System.String EmailMessage_FromAddress { get; set; }
        #endregion
        
        #region Parameter EmailMessage_Header
        /// <summary>
        /// <para>
        /// <para>The list of <a href="https://docs.aws.amazon.com/pinpoint/latest/apireference/apps-application-id-campaigns-campaign-id.html#apps-application-id-campaigns-campaign-id-model-messageheader">MessageHeaders</a>
        /// for the email. You can have up to 15 MessageHeaders for each email.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_EmailMessage_Headers")]
        public Amazon.Pinpoint.Model.MessageHeader[] EmailMessage_Header { get; set; }
        #endregion
        
        #region Parameter WriteCampaignRequest_HoldoutPercent
        /// <summary>
        /// <para>
        /// <para>The allocated percentage of users (segment members) who shouldn't receive messages
        /// from the campaign.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? WriteCampaignRequest_HoldoutPercent { get; set; }
        #endregion
        
        #region Parameter EmailMessage_HtmlBody
        /// <summary>
        /// <para>
        /// <para>The body of the email, in HTML format, for recipients whose email clients render HTML
        /// content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_EmailMessage_HtmlBody")]
        public System.String EmailMessage_HtmlBody { get; set; }
        #endregion
        
        #region Parameter ADMMessage_ImageIconUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the image to display as the push-notification icon, such as the icon for
        /// the app.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_ADMMessage_ImageIconUrl")]
        public System.String ADMMessage_ImageIconUrl { get; set; }
        #endregion
        
        #region Parameter APNSMessage_ImageIconUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the image to display as the push-notification icon, such as the icon for
        /// the app.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_APNSMessage_ImageIconUrl")]
        public System.String APNSMessage_ImageIconUrl { get; set; }
        #endregion
        
        #region Parameter BaiduMessage_ImageIconUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the image to display as the push-notification icon, such as the icon for
        /// the app.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_BaiduMessage_ImageIconUrl")]
        public System.String BaiduMessage_ImageIconUrl { get; set; }
        #endregion
        
        #region Parameter DefaultMessage_ImageIconUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the image to display as the push-notification icon, such as the icon for
        /// the app.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_DefaultMessage_ImageIconUrl")]
        public System.String DefaultMessage_ImageIconUrl { get; set; }
        #endregion
        
        #region Parameter GCMMessage_ImageIconUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the image to display as the push-notification icon, such as the icon for
        /// the app.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_GCMMessage_ImageIconUrl")]
        public System.String GCMMessage_ImageIconUrl { get; set; }
        #endregion
        
        #region Parameter ADMMessage_ImageSmallIconUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the image to display as the small, push-notification icon, such as a small
        /// version of the icon for the app.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_ADMMessage_ImageSmallIconUrl")]
        public System.String ADMMessage_ImageSmallIconUrl { get; set; }
        #endregion
        
        #region Parameter APNSMessage_ImageSmallIconUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the image to display as the small, push-notification icon, such as a small
        /// version of the icon for the app.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_APNSMessage_ImageSmallIconUrl")]
        public System.String APNSMessage_ImageSmallIconUrl { get; set; }
        #endregion
        
        #region Parameter BaiduMessage_ImageSmallIconUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the image to display as the small, push-notification icon, such as a small
        /// version of the icon for the app.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_BaiduMessage_ImageSmallIconUrl")]
        public System.String BaiduMessage_ImageSmallIconUrl { get; set; }
        #endregion
        
        #region Parameter DefaultMessage_ImageSmallIconUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the image to display as the small, push-notification icon, such as a small
        /// version of the icon for the app.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_DefaultMessage_ImageSmallIconUrl")]
        public System.String DefaultMessage_ImageSmallIconUrl { get; set; }
        #endregion
        
        #region Parameter GCMMessage_ImageSmallIconUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the image to display as the small, push-notification icon, such as a small
        /// version of the icon for the app.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_GCMMessage_ImageSmallIconUrl")]
        public System.String GCMMessage_ImageSmallIconUrl { get; set; }
        #endregion
        
        #region Parameter ADMMessage_ImageUrl
        /// <summary>
        /// <para>
        /// <para>The URL of an image to display in the push notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_ADMMessage_ImageUrl")]
        public System.String ADMMessage_ImageUrl { get; set; }
        #endregion
        
        #region Parameter APNSMessage_ImageUrl
        /// <summary>
        /// <para>
        /// <para>The URL of an image to display in the push notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_APNSMessage_ImageUrl")]
        public System.String APNSMessage_ImageUrl { get; set; }
        #endregion
        
        #region Parameter BaiduMessage_ImageUrl
        /// <summary>
        /// <para>
        /// <para>The URL of an image to display in the push notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_BaiduMessage_ImageUrl")]
        public System.String BaiduMessage_ImageUrl { get; set; }
        #endregion
        
        #region Parameter DefaultMessage_ImageUrl
        /// <summary>
        /// <para>
        /// <para>The URL of an image to display in the push notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_DefaultMessage_ImageUrl")]
        public System.String DefaultMessage_ImageUrl { get; set; }
        #endregion
        
        #region Parameter GCMMessage_ImageUrl
        /// <summary>
        /// <para>
        /// <para>The URL of an image to display in the push notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_GCMMessage_ImageUrl")]
        public System.String GCMMessage_ImageUrl { get; set; }
        #endregion
        
        #region Parameter Schedule_IsLocalTime
        /// <summary>
        /// <para>
        /// <para>Specifies whether the start and end times for the campaign schedule use each recipient's
        /// local time. To base the schedule on each recipient's local time, set this value to
        /// true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_Schedule_IsLocalTime")]
        public System.Boolean? Schedule_IsLocalTime { get; set; }
        #endregion
        
        #region Parameter WriteCampaignRequest_IsPaused
        /// <summary>
        /// <para>
        /// <para>Specifies whether to pause the campaign. A paused campaign doesn't run unless you
        /// resume it by changing this value to false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? WriteCampaignRequest_IsPaused { get; set; }
        #endregion
        
        #region Parameter ADMMessage_JsonBody
        /// <summary>
        /// <para>
        /// <para>The JSON payload to use for a silent push notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_ADMMessage_JsonBody")]
        public System.String ADMMessage_JsonBody { get; set; }
        #endregion
        
        #region Parameter APNSMessage_JsonBody
        /// <summary>
        /// <para>
        /// <para>The JSON payload to use for a silent push notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_APNSMessage_JsonBody")]
        public System.String APNSMessage_JsonBody { get; set; }
        #endregion
        
        #region Parameter BaiduMessage_JsonBody
        /// <summary>
        /// <para>
        /// <para>The JSON payload to use for a silent push notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_BaiduMessage_JsonBody")]
        public System.String BaiduMessage_JsonBody { get; set; }
        #endregion
        
        #region Parameter DefaultMessage_JsonBody
        /// <summary>
        /// <para>
        /// <para>The JSON payload to use for a silent push notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_DefaultMessage_JsonBody")]
        public System.String DefaultMessage_JsonBody { get; set; }
        #endregion
        
        #region Parameter GCMMessage_JsonBody
        /// <summary>
        /// <para>
        /// <para>The JSON payload to use for a silent push notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_GCMMessage_JsonBody")]
        public System.String GCMMessage_JsonBody { get; set; }
        #endregion
        
        #region Parameter Hook_LambdaFunctionName
        /// <summary>
        /// <para>
        /// <para>The name or Amazon Resource Name (ARN) of the AWS Lambda function that Amazon Pinpoint
        /// invokes to customize a segment for a campaign.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_Hook_LambdaFunctionName")]
        public System.String Hook_LambdaFunctionName { get; set; }
        #endregion
        
        #region Parameter InAppMessage_Layout
        /// <summary>
        /// <para>
        /// <para>In-app message layout.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_InAppMessage_Layout")]
        [AWSConstantClassSource("Amazon.Pinpoint.Layout")]
        public Amazon.Pinpoint.Layout InAppMessage_Layout { get; set; }
        #endregion
        
        #region Parameter Limits_MaximumDuration
        /// <summary>
        /// <para>
        /// <para>The maximum amount of time, in seconds, that a campaign can attempt to deliver a message
        /// after the scheduled start time for the campaign. The minimum value is 60 seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_Limits_MaximumDuration")]
        public System.Int32? Limits_MaximumDuration { get; set; }
        #endregion
        
        #region Parameter ADMMessage_MediaUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the image or video to display in the push notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_ADMMessage_MediaUrl")]
        public System.String ADMMessage_MediaUrl { get; set; }
        #endregion
        
        #region Parameter APNSMessage_MediaUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the image or video to display in the push notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_APNSMessage_MediaUrl")]
        public System.String APNSMessage_MediaUrl { get; set; }
        #endregion
        
        #region Parameter BaiduMessage_MediaUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the image or video to display in the push notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_BaiduMessage_MediaUrl")]
        public System.String BaiduMessage_MediaUrl { get; set; }
        #endregion
        
        #region Parameter DefaultMessage_MediaUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the image or video to display in the push notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_DefaultMessage_MediaUrl")]
        public System.String DefaultMessage_MediaUrl { get; set; }
        #endregion
        
        #region Parameter GCMMessage_MediaUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the image or video to display in the push notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_GCMMessage_MediaUrl")]
        public System.String GCMMessage_MediaUrl { get; set; }
        #endregion
        
        #region Parameter Limits_MessagesPerSecond
        /// <summary>
        /// <para>
        /// <para>The maximum number of messages that a campaign can send each second. For an application,
        /// this value specifies the default limit for the number of messages that campaigns can
        /// send each second. The minimum value is 1. The maximum value is 20,000.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_Limits_MessagesPerSecond")]
        public System.Int32? Limits_MessagesPerSecond { get; set; }
        #endregion
        
        #region Parameter SMSMessage_MessageType
        /// <summary>
        /// <para>
        /// <para>The SMS message type. Valid values are TRANSACTIONAL (for messages that are critical
        /// or time-sensitive, such as a one-time passwords) and PROMOTIONAL (for messsages that
        /// aren't critical or time-sensitive, such as marketing messages).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_SMSMessage_MessageType")]
        [AWSConstantClassSource("Amazon.Pinpoint.MessageType")]
        public Amazon.Pinpoint.MessageType SMSMessage_MessageType { get; set; }
        #endregion
        
        #region Parameter Dimensions_Metric
        /// <summary>
        /// <para>
        /// <para>One or more custom metrics that your application reports to Amazon Pinpoint. You can
        /// use these metrics as selection criteria when you create an event filter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_Schedule_EventFilter_Dimensions_Metrics")]
        public System.Collections.Hashtable Dimensions_Metric { get; set; }
        #endregion
        
        #region Parameter Hook_Mode
        /// <summary>
        /// <para>
        /// <para>The mode that Amazon Pinpoint uses to invoke the AWS Lambda function. Possible values
        /// are:</para><ul><li><para>FILTER - Invoke the function to customize the segment that's used by a campaign.</para></li><li><para>DELIVERY - (Deprecated) Previously, invoked the function to send a campaign through
        /// a custom channel. This functionality is not supported anymore. To send a campaign
        /// through a custom channel, use the CustomDeliveryConfiguration and CampaignCustomMessage
        /// objects of the campaign.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_Hook_Mode")]
        [AWSConstantClassSource("Amazon.Pinpoint.Mode")]
        public Amazon.Pinpoint.Mode Hook_Mode { get; set; }
        #endregion
        
        #region Parameter WriteCampaignRequest_Name
        /// <summary>
        /// <para>
        /// <para>A custom name for the campaign.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WriteCampaignRequest_Name { get; set; }
        #endregion
        
        #region Parameter EmailTemplate_Name
        /// <summary>
        /// <para>
        /// <para>The name of the message template to use for the message. If specified, this value
        /// must match the name of an existing message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_TemplateConfiguration_EmailTemplate_Name")]
        public System.String EmailTemplate_Name { get; set; }
        #endregion
        
        #region Parameter InAppTemplate_Name
        /// <summary>
        /// <para>
        /// <para>The name of the message template to use for the message. If specified, this value
        /// must match the name of an existing message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_TemplateConfiguration_InAppTemplate_Name")]
        public System.String InAppTemplate_Name { get; set; }
        #endregion
        
        #region Parameter PushTemplate_Name
        /// <summary>
        /// <para>
        /// <para>The name of the message template to use for the message. If specified, this value
        /// must match the name of an existing message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_TemplateConfiguration_PushTemplate_Name")]
        public System.String PushTemplate_Name { get; set; }
        #endregion
        
        #region Parameter SMSTemplate_Name
        /// <summary>
        /// <para>
        /// <para>The name of the message template to use for the message. If specified, this value
        /// must match the name of an existing message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_TemplateConfiguration_SMSTemplate_Name")]
        public System.String SMSTemplate_Name { get; set; }
        #endregion
        
        #region Parameter VoiceTemplate_Name
        /// <summary>
        /// <para>
        /// <para>The name of the message template to use for the message. If specified, this value
        /// must match the name of an existing message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_TemplateConfiguration_VoiceTemplate_Name")]
        public System.String VoiceTemplate_Name { get; set; }
        #endregion
        
        #region Parameter SMSMessage_OriginationNumber
        /// <summary>
        /// <para>
        /// <para>The long code to send the SMS message from. This value should be one of the dedicated
        /// long codes that's assigned to your AWS account. Although it isn't required, we recommend
        /// that you specify the long code using an E.164 format to ensure prompt and accurate
        /// delivery of the message. For example, +12065550100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_SMSMessage_OriginationNumber")]
        public System.String SMSMessage_OriginationNumber { get; set; }
        #endregion
        
        #region Parameter WriteCampaignRequest_Priority
        /// <summary>
        /// <para>
        /// <para>Defines the priority of the campaign, used to decide the order of messages displayed
        /// to user if there are multiple messages scheduled to be displayed at the same moment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? WriteCampaignRequest_Priority { get; set; }
        #endregion
        
        #region Parameter ADMMessage_RawContent
        /// <summary>
        /// <para>
        /// <para>The raw, JSON-formatted string to use as the payload for the notification message.
        /// If specified, this value overrides all other content for the message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_ADMMessage_RawContent")]
        public System.String ADMMessage_RawContent { get; set; }
        #endregion
        
        #region Parameter APNSMessage_RawContent
        /// <summary>
        /// <para>
        /// <para>The raw, JSON-formatted string to use as the payload for the notification message.
        /// If specified, this value overrides all other content for the message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_APNSMessage_RawContent")]
        public System.String APNSMessage_RawContent { get; set; }
        #endregion
        
        #region Parameter BaiduMessage_RawContent
        /// <summary>
        /// <para>
        /// <para>The raw, JSON-formatted string to use as the payload for the notification message.
        /// If specified, this value overrides all other content for the message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_BaiduMessage_RawContent")]
        public System.String BaiduMessage_RawContent { get; set; }
        #endregion
        
        #region Parameter DefaultMessage_RawContent
        /// <summary>
        /// <para>
        /// <para>The raw, JSON-formatted string to use as the payload for the notification message.
        /// If specified, this value overrides all other content for the message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_DefaultMessage_RawContent")]
        public System.String DefaultMessage_RawContent { get; set; }
        #endregion
        
        #region Parameter GCMMessage_RawContent
        /// <summary>
        /// <para>
        /// <para>The raw, JSON-formatted string to use as the payload for the notification message.
        /// If specified, this value overrides all other content for the message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_GCMMessage_RawContent")]
        public System.String GCMMessage_RawContent { get; set; }
        #endregion
        
        #region Parameter WriteCampaignRequest_SegmentId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the segment to associate with the campaign.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WriteCampaignRequest_SegmentId { get; set; }
        #endregion
        
        #region Parameter WriteCampaignRequest_SegmentVersion
        /// <summary>
        /// <para>
        /// <para>The version of the segment to associate with the campaign.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? WriteCampaignRequest_SegmentVersion { get; set; }
        #endregion
        
        #region Parameter SMSMessage_SenderId
        /// <summary>
        /// <para>
        /// <para>The sender ID to display on recipients' devices when they receive the SMS message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_SMSMessage_SenderId")]
        public System.String SMSMessage_SenderId { get; set; }
        #endregion
        
        #region Parameter Limits_Session
        /// <summary>
        /// <para>
        /// <para>The maximum total number of messages that the campaign can send per user session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_Limits_Session")]
        public System.Int32? Limits_Session { get; set; }
        #endregion
        
        #region Parameter ADMMessage_SilentPush
        /// <summary>
        /// <para>
        /// <para>Specifies whether the notification is a silent push notification, which is a push
        /// notification that doesn't display on a recipient's device. Silent push notifications
        /// can be used for cases such as updating an app's configuration, displaying messages
        /// in an in-app message center, or supporting phone home functionality.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_ADMMessage_SilentPush")]
        public System.Boolean? ADMMessage_SilentPush { get; set; }
        #endregion
        
        #region Parameter APNSMessage_SilentPush
        /// <summary>
        /// <para>
        /// <para>Specifies whether the notification is a silent push notification, which is a push
        /// notification that doesn't display on a recipient's device. Silent push notifications
        /// can be used for cases such as updating an app's configuration, displaying messages
        /// in an in-app message center, or supporting phone home functionality.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_APNSMessage_SilentPush")]
        public System.Boolean? APNSMessage_SilentPush { get; set; }
        #endregion
        
        #region Parameter BaiduMessage_SilentPush
        /// <summary>
        /// <para>
        /// <para>Specifies whether the notification is a silent push notification, which is a push
        /// notification that doesn't display on a recipient's device. Silent push notifications
        /// can be used for cases such as updating an app's configuration, displaying messages
        /// in an in-app message center, or supporting phone home functionality.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_BaiduMessage_SilentPush")]
        public System.Boolean? BaiduMessage_SilentPush { get; set; }
        #endregion
        
        #region Parameter DefaultMessage_SilentPush
        /// <summary>
        /// <para>
        /// <para>Specifies whether the notification is a silent push notification, which is a push
        /// notification that doesn't display on a recipient's device. Silent push notifications
        /// can be used for cases such as updating an app's configuration, displaying messages
        /// in an in-app message center, or supporting phone home functionality.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_DefaultMessage_SilentPush")]
        public System.Boolean? DefaultMessage_SilentPush { get; set; }
        #endregion
        
        #region Parameter GCMMessage_SilentPush
        /// <summary>
        /// <para>
        /// <para>Specifies whether the notification is a silent push notification, which is a push
        /// notification that doesn't display on a recipient's device. Silent push notifications
        /// can be used for cases such as updating an app's configuration, displaying messages
        /// in an in-app message center, or supporting phone home functionality.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_GCMMessage_SilentPush")]
        public System.Boolean? GCMMessage_SilentPush { get; set; }
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
        [Alias("WriteCampaignRequest_Schedule_QuietTime_Start")]
        public System.String QuietTime_Start { get; set; }
        #endregion
        
        #region Parameter Schedule_StartTime
        /// <summary>
        /// <para>
        /// <para>The scheduled time when the campaign began or will begin. Valid values are: IMMEDIATE,
        /// to start the campaign immediately; or, a specific time in ISO 8601 format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_Schedule_StartTime")]
        public System.String Schedule_StartTime { get; set; }
        #endregion
        
        #region Parameter WriteCampaignRequest_Tag
        /// <summary>
        /// <para>
        /// <note><para>As of <b>22-05-2023</b> tags has been deprecated for update operations. After this
        /// date any value in tags is not processed and an error code is not returned. To manage
        /// tags we recommend using either <a href="https://docs.aws.amazon.com/pinpoint/latest/apireference/tags-resource-arn.html">Tags</a>
        /// in the <i>API Reference for Amazon Pinpoint</i>, <a href="https://docs.aws.amazon.com/cli/latest/reference/resourcegroupstaggingapi/index.html">resourcegroupstaggingapi</a>
        /// commands in the <i>AWS Command Line Interface Documentation</i> or <a href="https://sdk.amazonaws.com/java/api/latest/software/amazon/awssdk/services/resourcegroupstaggingapi/package-summary.html">resourcegroupstaggingapi</a>
        /// in the <i>AWS SDK</i>.</para></note><para>(Deprecated) A string-to-string map of key-value pairs that defines the tags to associate
        /// with the campaign. Each tag consists of a required tag key and an associated tag value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_Tags")]
        public System.Collections.Hashtable WriteCampaignRequest_Tag { get; set; }
        #endregion
        
        #region Parameter SMSMessage_TemplateId
        /// <summary>
        /// <para>
        /// <para>The template ID received from the regulatory body for sending SMS in your country.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_SMSMessage_TemplateId")]
        public System.String SMSMessage_TemplateId { get; set; }
        #endregion
        
        #region Parameter ADMMessage_TimeToLive
        /// <summary>
        /// <para>
        /// <para>The number of seconds that the push-notification service should keep the message,
        /// if the service is unable to deliver the notification the first time. This value is
        /// converted to an expiration value when it's sent to a push-notification service. If
        /// this value is 0, the service treats the notification as if it expires immediately
        /// and the service doesn't store or try to deliver the notification again.</para><para>This value doesn't apply to messages that are sent through the Amazon Device Messaging
        /// (ADM) service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_ADMMessage_TimeToLive")]
        public System.Int32? ADMMessage_TimeToLive { get; set; }
        #endregion
        
        #region Parameter APNSMessage_TimeToLive
        /// <summary>
        /// <para>
        /// <para>The number of seconds that the push-notification service should keep the message,
        /// if the service is unable to deliver the notification the first time. This value is
        /// converted to an expiration value when it's sent to a push-notification service. If
        /// this value is 0, the service treats the notification as if it expires immediately
        /// and the service doesn't store or try to deliver the notification again.</para><para>This value doesn't apply to messages that are sent through the Amazon Device Messaging
        /// (ADM) service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_APNSMessage_TimeToLive")]
        public System.Int32? APNSMessage_TimeToLive { get; set; }
        #endregion
        
        #region Parameter BaiduMessage_TimeToLive
        /// <summary>
        /// <para>
        /// <para>The number of seconds that the push-notification service should keep the message,
        /// if the service is unable to deliver the notification the first time. This value is
        /// converted to an expiration value when it's sent to a push-notification service. If
        /// this value is 0, the service treats the notification as if it expires immediately
        /// and the service doesn't store or try to deliver the notification again.</para><para>This value doesn't apply to messages that are sent through the Amazon Device Messaging
        /// (ADM) service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_BaiduMessage_TimeToLive")]
        public System.Int32? BaiduMessage_TimeToLive { get; set; }
        #endregion
        
        #region Parameter DefaultMessage_TimeToLive
        /// <summary>
        /// <para>
        /// <para>The number of seconds that the push-notification service should keep the message,
        /// if the service is unable to deliver the notification the first time. This value is
        /// converted to an expiration value when it's sent to a push-notification service. If
        /// this value is 0, the service treats the notification as if it expires immediately
        /// and the service doesn't store or try to deliver the notification again.</para><para>This value doesn't apply to messages that are sent through the Amazon Device Messaging
        /// (ADM) service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_DefaultMessage_TimeToLive")]
        public System.Int32? DefaultMessage_TimeToLive { get; set; }
        #endregion
        
        #region Parameter GCMMessage_TimeToLive
        /// <summary>
        /// <para>
        /// <para>The number of seconds that the push-notification service should keep the message,
        /// if the service is unable to deliver the notification the first time. This value is
        /// converted to an expiration value when it's sent to a push-notification service. If
        /// this value is 0, the service treats the notification as if it expires immediately
        /// and the service doesn't store or try to deliver the notification again.</para><para>This value doesn't apply to messages that are sent through the Amazon Device Messaging
        /// (ADM) service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_GCMMessage_TimeToLive")]
        public System.Int32? GCMMessage_TimeToLive { get; set; }
        #endregion
        
        #region Parameter Schedule_Timezone
        /// <summary>
        /// <para>
        /// <para>The starting UTC offset for the campaign schedule, if the value of the IsLocalTime
        /// property is true. Valid values are: UTC, UTC+01, UTC+02, UTC+03, UTC+03:30, UTC+04,
        /// UTC+04:30, UTC+05,                  UTC+05:30, UTC+05:45, UTC+06, UTC+06:30, UTC+07,
        /// UTC+08, UTC+09, UTC+09:30,                  UTC+10, UTC+10:30, UTC+11, UTC+12, UTC+13,
        /// UTC-02, UTC-03, UTC-04, UTC-05, UTC-06,                  UTC-07, UTC-08, UTC-09, UTC-10,
        /// and UTC-11.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_Schedule_Timezone")]
        public System.String Schedule_Timezone { get; set; }
        #endregion
        
        #region Parameter ADMMessage_Title
        /// <summary>
        /// <para>
        /// <para>The title to display above the notification message on a recipient's device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_ADMMessage_Title")]
        public System.String ADMMessage_Title { get; set; }
        #endregion
        
        #region Parameter APNSMessage_Title
        /// <summary>
        /// <para>
        /// <para>The title to display above the notification message on a recipient's device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_APNSMessage_Title")]
        public System.String APNSMessage_Title { get; set; }
        #endregion
        
        #region Parameter BaiduMessage_Title
        /// <summary>
        /// <para>
        /// <para>The title to display above the notification message on a recipient's device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_BaiduMessage_Title")]
        public System.String BaiduMessage_Title { get; set; }
        #endregion
        
        #region Parameter DefaultMessage_Title
        /// <summary>
        /// <para>
        /// <para>The title to display above the notification message on a recipient's device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_DefaultMessage_Title")]
        public System.String DefaultMessage_Title { get; set; }
        #endregion
        
        #region Parameter EmailMessage_Title
        /// <summary>
        /// <para>
        /// <para>The subject line, or title, of the email.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_EmailMessage_Title")]
        public System.String EmailMessage_Title { get; set; }
        #endregion
        
        #region Parameter GCMMessage_Title
        /// <summary>
        /// <para>
        /// <para>The title to display above the notification message on a recipient's device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_GCMMessage_Title")]
        public System.String GCMMessage_Title { get; set; }
        #endregion
        
        #region Parameter Limits_Total
        /// <summary>
        /// <para>
        /// <para>The maximum number of messages that a campaign can send to a single endpoint during
        /// the course of the campaign. If a campaign recurs, this setting applies to all runs
        /// of the campaign. The maximum value is 100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_Limits_Total")]
        public System.Int32? Limits_Total { get; set; }
        #endregion
        
        #region Parameter WriteCampaignRequest_TreatmentDescription
        /// <summary>
        /// <para>
        /// <para>A custom description of the default treatment for the campaign.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WriteCampaignRequest_TreatmentDescription { get; set; }
        #endregion
        
        #region Parameter WriteCampaignRequest_TreatmentName
        /// <summary>
        /// <para>
        /// <para>A custom name of the default treatment for the campaign, if the campaign has multiple
        /// treatments. A <i>treatment</i> is a variation of a campaign that's used for A/B testing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WriteCampaignRequest_TreatmentName { get; set; }
        #endregion
        
        #region Parameter ADMMessage_Url
        /// <summary>
        /// <para>
        /// <para>The URL to open in a recipient's default mobile browser, if a recipient taps the push
        /// notification and the value of the Action property is URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_ADMMessage_Url")]
        public System.String ADMMessage_Url { get; set; }
        #endregion
        
        #region Parameter APNSMessage_Url
        /// <summary>
        /// <para>
        /// <para>The URL to open in a recipient's default mobile browser, if a recipient taps the push
        /// notification and the value of the Action property is URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_APNSMessage_Url")]
        public System.String APNSMessage_Url { get; set; }
        #endregion
        
        #region Parameter BaiduMessage_Url
        /// <summary>
        /// <para>
        /// <para>The URL to open in a recipient's default mobile browser, if a recipient taps the push
        /// notification and the value of the Action property is URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_BaiduMessage_Url")]
        public System.String BaiduMessage_Url { get; set; }
        #endregion
        
        #region Parameter DefaultMessage_Url
        /// <summary>
        /// <para>
        /// <para>The URL to open in a recipient's default mobile browser, if a recipient taps the push
        /// notification and the value of the Action property is URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_DefaultMessage_Url")]
        public System.String DefaultMessage_Url { get; set; }
        #endregion
        
        #region Parameter GCMMessage_Url
        /// <summary>
        /// <para>
        /// <para>The URL to open in a recipient's default mobile browser, if a recipient taps the push
        /// notification and the value of the Action property is URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_MessageConfiguration_GCMMessage_Url")]
        public System.String GCMMessage_Url { get; set; }
        #endregion
        
        #region Parameter EventType_Value
        /// <summary>
        /// <para>
        /// <para>The criteria values to use for the segment dimension. Depending on the value of the
        /// DimensionType property, endpoints are included or excluded from the segment if their
        /// values match the criteria values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_Schedule_EventFilter_Dimensions_EventType_Values")]
        public System.String[] EventType_Value { get; set; }
        #endregion
        
        #region Parameter EmailTemplate_Version
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the version of the message template to use for the message.
        /// If specified, this value must match the identifier for an existing template version.
        /// To retrieve a list of versions and version identifiers for a template, use the <link linkend="templates-template-name-template-type-versions">Template Versions</link>
        /// resource.</para><para>If you don't specify a value for this property, Amazon Pinpoint uses the <i>active
        /// version</i> of the template. The <i>active version</i> is typically the version of
        /// a template that's been most recently reviewed and approved for use, depending on your
        /// workflow. It isn't necessarily the latest version of a template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_TemplateConfiguration_EmailTemplate_Version")]
        public System.String EmailTemplate_Version { get; set; }
        #endregion
        
        #region Parameter InAppTemplate_Version
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the version of the message template to use for the message.
        /// If specified, this value must match the identifier for an existing template version.
        /// To retrieve a list of versions and version identifiers for a template, use the <link linkend="templates-template-name-template-type-versions">Template Versions</link>
        /// resource.</para><para>If you don't specify a value for this property, Amazon Pinpoint uses the <i>active
        /// version</i> of the template. The <i>active version</i> is typically the version of
        /// a template that's been most recently reviewed and approved for use, depending on your
        /// workflow. It isn't necessarily the latest version of a template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_TemplateConfiguration_InAppTemplate_Version")]
        public System.String InAppTemplate_Version { get; set; }
        #endregion
        
        #region Parameter PushTemplate_Version
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the version of the message template to use for the message.
        /// If specified, this value must match the identifier for an existing template version.
        /// To retrieve a list of versions and version identifiers for a template, use the <link linkend="templates-template-name-template-type-versions">Template Versions</link>
        /// resource.</para><para>If you don't specify a value for this property, Amazon Pinpoint uses the <i>active
        /// version</i> of the template. The <i>active version</i> is typically the version of
        /// a template that's been most recently reviewed and approved for use, depending on your
        /// workflow. It isn't necessarily the latest version of a template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_TemplateConfiguration_PushTemplate_Version")]
        public System.String PushTemplate_Version { get; set; }
        #endregion
        
        #region Parameter SMSTemplate_Version
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the version of the message template to use for the message.
        /// If specified, this value must match the identifier for an existing template version.
        /// To retrieve a list of versions and version identifiers for a template, use the <link linkend="templates-template-name-template-type-versions">Template Versions</link>
        /// resource.</para><para>If you don't specify a value for this property, Amazon Pinpoint uses the <i>active
        /// version</i> of the template. The <i>active version</i> is typically the version of
        /// a template that's been most recently reviewed and approved for use, depending on your
        /// workflow. It isn't necessarily the latest version of a template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_TemplateConfiguration_SMSTemplate_Version")]
        public System.String SMSTemplate_Version { get; set; }
        #endregion
        
        #region Parameter VoiceTemplate_Version
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the version of the message template to use for the message.
        /// If specified, this value must match the identifier for an existing template version.
        /// To retrieve a list of versions and version identifiers for a template, use the <link linkend="templates-template-name-template-type-versions">Template Versions</link>
        /// resource.</para><para>If you don't specify a value for this property, Amazon Pinpoint uses the <i>active
        /// version</i> of the template. The <i>active version</i> is typically the version of
        /// a template that's been most recently reviewed and approved for use, depending on your
        /// workflow. It isn't necessarily the latest version of a template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_TemplateConfiguration_VoiceTemplate_Version")]
        public System.String VoiceTemplate_Version { get; set; }
        #endregion
        
        #region Parameter Hook_WebUrl
        /// <summary>
        /// <para>
        /// <para>The web URL that Amazon Pinpoint calls to invoke the AWS Lambda function over HTTPS.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteCampaignRequest_Hook_WebUrl")]
        public System.String Hook_WebUrl { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CampaignResponse'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Pinpoint.Model.CreateCampaignResponse).
        /// Specifying the name of a property of type Amazon.Pinpoint.Model.CreateCampaignResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CampaignResponse";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PINCampaign (CreateCampaign)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Pinpoint.Model.CreateCampaignResponse, NewPINCampaignCmdlet>(Select) ??
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
            if (this.WriteCampaignRequest_AdditionalTreatment != null)
            {
                context.WriteCampaignRequest_AdditionalTreatment = new List<Amazon.Pinpoint.Model.WriteTreatmentResource>(this.WriteCampaignRequest_AdditionalTreatment);
            }
            context.CustomDeliveryConfiguration_DeliveryUri = this.CustomDeliveryConfiguration_DeliveryUri;
            if (this.CustomDeliveryConfiguration_EndpointType != null)
            {
                context.CustomDeliveryConfiguration_EndpointType = new List<System.String>(this.CustomDeliveryConfiguration_EndpointType);
            }
            context.WriteCampaignRequest_Description = this.WriteCampaignRequest_Description;
            context.WriteCampaignRequest_HoldoutPercent = this.WriteCampaignRequest_HoldoutPercent;
            context.Hook_LambdaFunctionName = this.Hook_LambdaFunctionName;
            context.Hook_Mode = this.Hook_Mode;
            context.Hook_WebUrl = this.Hook_WebUrl;
            context.WriteCampaignRequest_IsPaused = this.WriteCampaignRequest_IsPaused;
            context.Limits_Daily = this.Limits_Daily;
            context.Limits_MaximumDuration = this.Limits_MaximumDuration;
            context.Limits_MessagesPerSecond = this.Limits_MessagesPerSecond;
            context.Limits_Session = this.Limits_Session;
            context.Limits_Total = this.Limits_Total;
            context.ADMMessage_Action = this.ADMMessage_Action;
            context.ADMMessage_Body = this.ADMMessage_Body;
            context.ADMMessage_ImageIconUrl = this.ADMMessage_ImageIconUrl;
            context.ADMMessage_ImageSmallIconUrl = this.ADMMessage_ImageSmallIconUrl;
            context.ADMMessage_ImageUrl = this.ADMMessage_ImageUrl;
            context.ADMMessage_JsonBody = this.ADMMessage_JsonBody;
            context.ADMMessage_MediaUrl = this.ADMMessage_MediaUrl;
            context.ADMMessage_RawContent = this.ADMMessage_RawContent;
            context.ADMMessage_SilentPush = this.ADMMessage_SilentPush;
            context.ADMMessage_TimeToLive = this.ADMMessage_TimeToLive;
            context.ADMMessage_Title = this.ADMMessage_Title;
            context.ADMMessage_Url = this.ADMMessage_Url;
            context.APNSMessage_Action = this.APNSMessage_Action;
            context.APNSMessage_Body = this.APNSMessage_Body;
            context.APNSMessage_ImageIconUrl = this.APNSMessage_ImageIconUrl;
            context.APNSMessage_ImageSmallIconUrl = this.APNSMessage_ImageSmallIconUrl;
            context.APNSMessage_ImageUrl = this.APNSMessage_ImageUrl;
            context.APNSMessage_JsonBody = this.APNSMessage_JsonBody;
            context.APNSMessage_MediaUrl = this.APNSMessage_MediaUrl;
            context.APNSMessage_RawContent = this.APNSMessage_RawContent;
            context.APNSMessage_SilentPush = this.APNSMessage_SilentPush;
            context.APNSMessage_TimeToLive = this.APNSMessage_TimeToLive;
            context.APNSMessage_Title = this.APNSMessage_Title;
            context.APNSMessage_Url = this.APNSMessage_Url;
            context.BaiduMessage_Action = this.BaiduMessage_Action;
            context.BaiduMessage_Body = this.BaiduMessage_Body;
            context.BaiduMessage_ImageIconUrl = this.BaiduMessage_ImageIconUrl;
            context.BaiduMessage_ImageSmallIconUrl = this.BaiduMessage_ImageSmallIconUrl;
            context.BaiduMessage_ImageUrl = this.BaiduMessage_ImageUrl;
            context.BaiduMessage_JsonBody = this.BaiduMessage_JsonBody;
            context.BaiduMessage_MediaUrl = this.BaiduMessage_MediaUrl;
            context.BaiduMessage_RawContent = this.BaiduMessage_RawContent;
            context.BaiduMessage_SilentPush = this.BaiduMessage_SilentPush;
            context.BaiduMessage_TimeToLive = this.BaiduMessage_TimeToLive;
            context.BaiduMessage_Title = this.BaiduMessage_Title;
            context.BaiduMessage_Url = this.BaiduMessage_Url;
            context.CustomMessage_Data = this.CustomMessage_Data;
            context.DefaultMessage_Action = this.DefaultMessage_Action;
            context.DefaultMessage_Body = this.DefaultMessage_Body;
            context.DefaultMessage_ImageIconUrl = this.DefaultMessage_ImageIconUrl;
            context.DefaultMessage_ImageSmallIconUrl = this.DefaultMessage_ImageSmallIconUrl;
            context.DefaultMessage_ImageUrl = this.DefaultMessage_ImageUrl;
            context.DefaultMessage_JsonBody = this.DefaultMessage_JsonBody;
            context.DefaultMessage_MediaUrl = this.DefaultMessage_MediaUrl;
            context.DefaultMessage_RawContent = this.DefaultMessage_RawContent;
            context.DefaultMessage_SilentPush = this.DefaultMessage_SilentPush;
            context.DefaultMessage_TimeToLive = this.DefaultMessage_TimeToLive;
            context.DefaultMessage_Title = this.DefaultMessage_Title;
            context.DefaultMessage_Url = this.DefaultMessage_Url;
            context.EmailMessage_Body = this.EmailMessage_Body;
            context.EmailMessage_FromAddress = this.EmailMessage_FromAddress;
            if (this.EmailMessage_Header != null)
            {
                context.EmailMessage_Header = new List<Amazon.Pinpoint.Model.MessageHeader>(this.EmailMessage_Header);
            }
            context.EmailMessage_HtmlBody = this.EmailMessage_HtmlBody;
            context.EmailMessage_Title = this.EmailMessage_Title;
            context.GCMMessage_Action = this.GCMMessage_Action;
            context.GCMMessage_Body = this.GCMMessage_Body;
            context.GCMMessage_ImageIconUrl = this.GCMMessage_ImageIconUrl;
            context.GCMMessage_ImageSmallIconUrl = this.GCMMessage_ImageSmallIconUrl;
            context.GCMMessage_ImageUrl = this.GCMMessage_ImageUrl;
            context.GCMMessage_JsonBody = this.GCMMessage_JsonBody;
            context.GCMMessage_MediaUrl = this.GCMMessage_MediaUrl;
            context.GCMMessage_RawContent = this.GCMMessage_RawContent;
            context.GCMMessage_SilentPush = this.GCMMessage_SilentPush;
            context.GCMMessage_TimeToLive = this.GCMMessage_TimeToLive;
            context.GCMMessage_Title = this.GCMMessage_Title;
            context.GCMMessage_Url = this.GCMMessage_Url;
            context.InAppMessage_Body = this.InAppMessage_Body;
            if (this.InAppMessage_Content != null)
            {
                context.InAppMessage_Content = new List<Amazon.Pinpoint.Model.InAppMessageContent>(this.InAppMessage_Content);
            }
            if (this.InAppMessage_CustomConfig != null)
            {
                context.InAppMessage_CustomConfig = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.InAppMessage_CustomConfig.Keys)
                {
                    context.InAppMessage_CustomConfig.Add((String)hashKey, (System.String)(this.InAppMessage_CustomConfig[hashKey]));
                }
            }
            context.InAppMessage_Layout = this.InAppMessage_Layout;
            context.SMSMessage_Body = this.SMSMessage_Body;
            context.SMSMessage_EntityId = this.SMSMessage_EntityId;
            context.SMSMessage_MessageType = this.SMSMessage_MessageType;
            context.SMSMessage_OriginationNumber = this.SMSMessage_OriginationNumber;
            context.SMSMessage_SenderId = this.SMSMessage_SenderId;
            context.SMSMessage_TemplateId = this.SMSMessage_TemplateId;
            context.WriteCampaignRequest_Name = this.WriteCampaignRequest_Name;
            context.WriteCampaignRequest_Priority = this.WriteCampaignRequest_Priority;
            context.Schedule_EndTime = this.Schedule_EndTime;
            if (this.Dimensions_Attribute != null)
            {
                context.Dimensions_Attribute = new Dictionary<System.String, Amazon.Pinpoint.Model.AttributeDimension>(StringComparer.Ordinal);
                foreach (var hashKey in this.Dimensions_Attribute.Keys)
                {
                    context.Dimensions_Attribute.Add((String)hashKey, (Amazon.Pinpoint.Model.AttributeDimension)(this.Dimensions_Attribute[hashKey]));
                }
            }
            context.EventType_DimensionType = this.EventType_DimensionType;
            if (this.EventType_Value != null)
            {
                context.EventType_Value = new List<System.String>(this.EventType_Value);
            }
            if (this.Dimensions_Metric != null)
            {
                context.Dimensions_Metric = new Dictionary<System.String, Amazon.Pinpoint.Model.MetricDimension>(StringComparer.Ordinal);
                foreach (var hashKey in this.Dimensions_Metric.Keys)
                {
                    context.Dimensions_Metric.Add((String)hashKey, (Amazon.Pinpoint.Model.MetricDimension)(this.Dimensions_Metric[hashKey]));
                }
            }
            context.EventFilter_FilterType = this.EventFilter_FilterType;
            context.Schedule_Frequency = this.Schedule_Frequency;
            context.Schedule_IsLocalTime = this.Schedule_IsLocalTime;
            context.QuietTime_End = this.QuietTime_End;
            context.QuietTime_Start = this.QuietTime_Start;
            context.Schedule_StartTime = this.Schedule_StartTime;
            context.Schedule_Timezone = this.Schedule_Timezone;
            context.WriteCampaignRequest_SegmentId = this.WriteCampaignRequest_SegmentId;
            context.WriteCampaignRequest_SegmentVersion = this.WriteCampaignRequest_SegmentVersion;
            if (this.WriteCampaignRequest_Tag != null)
            {
                context.WriteCampaignRequest_Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.WriteCampaignRequest_Tag.Keys)
                {
                    context.WriteCampaignRequest_Tag.Add((String)hashKey, (System.String)(this.WriteCampaignRequest_Tag[hashKey]));
                }
            }
            context.EmailTemplate_Name = this.EmailTemplate_Name;
            context.EmailTemplate_Version = this.EmailTemplate_Version;
            context.InAppTemplate_Name = this.InAppTemplate_Name;
            context.InAppTemplate_Version = this.InAppTemplate_Version;
            context.PushTemplate_Name = this.PushTemplate_Name;
            context.PushTemplate_Version = this.PushTemplate_Version;
            context.SMSTemplate_Name = this.SMSTemplate_Name;
            context.SMSTemplate_Version = this.SMSTemplate_Version;
            context.VoiceTemplate_Name = this.VoiceTemplate_Name;
            context.VoiceTemplate_Version = this.VoiceTemplate_Version;
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
            var request = new Amazon.Pinpoint.Model.CreateCampaignRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            
             // populate WriteCampaignRequest
            var requestWriteCampaignRequestIsNull = true;
            request.WriteCampaignRequest = new Amazon.Pinpoint.Model.WriteCampaignRequest();
            List<Amazon.Pinpoint.Model.WriteTreatmentResource> requestWriteCampaignRequest_writeCampaignRequest_AdditionalTreatment = null;
            if (cmdletContext.WriteCampaignRequest_AdditionalTreatment != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_AdditionalTreatment = cmdletContext.WriteCampaignRequest_AdditionalTreatment;
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
            System.Int32? requestWriteCampaignRequest_writeCampaignRequest_Priority = null;
            if (cmdletContext.WriteCampaignRequest_Priority != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Priority = cmdletContext.WriteCampaignRequest_Priority.Value;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_Priority != null)
            {
                request.WriteCampaignRequest.Priority = requestWriteCampaignRequest_writeCampaignRequest_Priority.Value;
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
            Dictionary<System.String, System.String> requestWriteCampaignRequest_writeCampaignRequest_Tag = null;
            if (cmdletContext.WriteCampaignRequest_Tag != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Tag = cmdletContext.WriteCampaignRequest_Tag;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_Tag != null)
            {
                request.WriteCampaignRequest.Tags = requestWriteCampaignRequest_writeCampaignRequest_Tag;
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
            Amazon.Pinpoint.Model.CustomDeliveryConfiguration requestWriteCampaignRequest_writeCampaignRequest_CustomDeliveryConfiguration = null;
            
             // populate CustomDeliveryConfiguration
            var requestWriteCampaignRequest_writeCampaignRequest_CustomDeliveryConfigurationIsNull = true;
            requestWriteCampaignRequest_writeCampaignRequest_CustomDeliveryConfiguration = new Amazon.Pinpoint.Model.CustomDeliveryConfiguration();
            System.String requestWriteCampaignRequest_writeCampaignRequest_CustomDeliveryConfiguration_customDeliveryConfiguration_DeliveryUri = null;
            if (cmdletContext.CustomDeliveryConfiguration_DeliveryUri != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_CustomDeliveryConfiguration_customDeliveryConfiguration_DeliveryUri = cmdletContext.CustomDeliveryConfiguration_DeliveryUri;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_CustomDeliveryConfiguration_customDeliveryConfiguration_DeliveryUri != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_CustomDeliveryConfiguration.DeliveryUri = requestWriteCampaignRequest_writeCampaignRequest_CustomDeliveryConfiguration_customDeliveryConfiguration_DeliveryUri;
                requestWriteCampaignRequest_writeCampaignRequest_CustomDeliveryConfigurationIsNull = false;
            }
            List<System.String> requestWriteCampaignRequest_writeCampaignRequest_CustomDeliveryConfiguration_customDeliveryConfiguration_EndpointType = null;
            if (cmdletContext.CustomDeliveryConfiguration_EndpointType != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_CustomDeliveryConfiguration_customDeliveryConfiguration_EndpointType = cmdletContext.CustomDeliveryConfiguration_EndpointType;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_CustomDeliveryConfiguration_customDeliveryConfiguration_EndpointType != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_CustomDeliveryConfiguration.EndpointTypes = requestWriteCampaignRequest_writeCampaignRequest_CustomDeliveryConfiguration_customDeliveryConfiguration_EndpointType;
                requestWriteCampaignRequest_writeCampaignRequest_CustomDeliveryConfigurationIsNull = false;
            }
             // determine if requestWriteCampaignRequest_writeCampaignRequest_CustomDeliveryConfiguration should be set to null
            if (requestWriteCampaignRequest_writeCampaignRequest_CustomDeliveryConfigurationIsNull)
            {
                requestWriteCampaignRequest_writeCampaignRequest_CustomDeliveryConfiguration = null;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_CustomDeliveryConfiguration != null)
            {
                request.WriteCampaignRequest.CustomDeliveryConfiguration = requestWriteCampaignRequest_writeCampaignRequest_CustomDeliveryConfiguration;
                requestWriteCampaignRequestIsNull = false;
            }
            Amazon.Pinpoint.Model.CampaignHook requestWriteCampaignRequest_writeCampaignRequest_Hook = null;
            
             // populate Hook
            var requestWriteCampaignRequest_writeCampaignRequest_HookIsNull = true;
            requestWriteCampaignRequest_writeCampaignRequest_Hook = new Amazon.Pinpoint.Model.CampaignHook();
            System.String requestWriteCampaignRequest_writeCampaignRequest_Hook_hook_LambdaFunctionName = null;
            if (cmdletContext.Hook_LambdaFunctionName != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Hook_hook_LambdaFunctionName = cmdletContext.Hook_LambdaFunctionName;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_Hook_hook_LambdaFunctionName != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Hook.LambdaFunctionName = requestWriteCampaignRequest_writeCampaignRequest_Hook_hook_LambdaFunctionName;
                requestWriteCampaignRequest_writeCampaignRequest_HookIsNull = false;
            }
            Amazon.Pinpoint.Mode requestWriteCampaignRequest_writeCampaignRequest_Hook_hook_Mode = null;
            if (cmdletContext.Hook_Mode != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Hook_hook_Mode = cmdletContext.Hook_Mode;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_Hook_hook_Mode != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Hook.Mode = requestWriteCampaignRequest_writeCampaignRequest_Hook_hook_Mode;
                requestWriteCampaignRequest_writeCampaignRequest_HookIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_Hook_hook_WebUrl = null;
            if (cmdletContext.Hook_WebUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Hook_hook_WebUrl = cmdletContext.Hook_WebUrl;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_Hook_hook_WebUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Hook.WebUrl = requestWriteCampaignRequest_writeCampaignRequest_Hook_hook_WebUrl;
                requestWriteCampaignRequest_writeCampaignRequest_HookIsNull = false;
            }
             // determine if requestWriteCampaignRequest_writeCampaignRequest_Hook should be set to null
            if (requestWriteCampaignRequest_writeCampaignRequest_HookIsNull)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Hook = null;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_Hook != null)
            {
                request.WriteCampaignRequest.Hook = requestWriteCampaignRequest_writeCampaignRequest_Hook;
                requestWriteCampaignRequestIsNull = false;
            }
            Amazon.Pinpoint.Model.CampaignLimits requestWriteCampaignRequest_writeCampaignRequest_Limits = null;
            
             // populate Limits
            var requestWriteCampaignRequest_writeCampaignRequest_LimitsIsNull = true;
            requestWriteCampaignRequest_writeCampaignRequest_Limits = new Amazon.Pinpoint.Model.CampaignLimits();
            System.Int32? requestWriteCampaignRequest_writeCampaignRequest_Limits_limits_Daily = null;
            if (cmdletContext.Limits_Daily != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Limits_limits_Daily = cmdletContext.Limits_Daily.Value;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_Limits_limits_Daily != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Limits.Daily = requestWriteCampaignRequest_writeCampaignRequest_Limits_limits_Daily.Value;
                requestWriteCampaignRequest_writeCampaignRequest_LimitsIsNull = false;
            }
            System.Int32? requestWriteCampaignRequest_writeCampaignRequest_Limits_limits_MaximumDuration = null;
            if (cmdletContext.Limits_MaximumDuration != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Limits_limits_MaximumDuration = cmdletContext.Limits_MaximumDuration.Value;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_Limits_limits_MaximumDuration != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Limits.MaximumDuration = requestWriteCampaignRequest_writeCampaignRequest_Limits_limits_MaximumDuration.Value;
                requestWriteCampaignRequest_writeCampaignRequest_LimitsIsNull = false;
            }
            System.Int32? requestWriteCampaignRequest_writeCampaignRequest_Limits_limits_MessagesPerSecond = null;
            if (cmdletContext.Limits_MessagesPerSecond != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Limits_limits_MessagesPerSecond = cmdletContext.Limits_MessagesPerSecond.Value;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_Limits_limits_MessagesPerSecond != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Limits.MessagesPerSecond = requestWriteCampaignRequest_writeCampaignRequest_Limits_limits_MessagesPerSecond.Value;
                requestWriteCampaignRequest_writeCampaignRequest_LimitsIsNull = false;
            }
            System.Int32? requestWriteCampaignRequest_writeCampaignRequest_Limits_limits_Session = null;
            if (cmdletContext.Limits_Session != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Limits_limits_Session = cmdletContext.Limits_Session.Value;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_Limits_limits_Session != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Limits.Session = requestWriteCampaignRequest_writeCampaignRequest_Limits_limits_Session.Value;
                requestWriteCampaignRequest_writeCampaignRequest_LimitsIsNull = false;
            }
            System.Int32? requestWriteCampaignRequest_writeCampaignRequest_Limits_limits_Total = null;
            if (cmdletContext.Limits_Total != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Limits_limits_Total = cmdletContext.Limits_Total.Value;
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
            Amazon.Pinpoint.Model.TemplateConfiguration requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration = null;
            
             // populate TemplateConfiguration
            var requestWriteCampaignRequest_writeCampaignRequest_TemplateConfigurationIsNull = true;
            requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration = new Amazon.Pinpoint.Model.TemplateConfiguration();
            Amazon.Pinpoint.Model.Template requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_EmailTemplate = null;
            
             // populate EmailTemplate
            var requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_EmailTemplateIsNull = true;
            requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_EmailTemplate = new Amazon.Pinpoint.Model.Template();
            System.String requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_EmailTemplate_emailTemplate_Name = null;
            if (cmdletContext.EmailTemplate_Name != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_EmailTemplate_emailTemplate_Name = cmdletContext.EmailTemplate_Name;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_EmailTemplate_emailTemplate_Name != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_EmailTemplate.Name = requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_EmailTemplate_emailTemplate_Name;
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_EmailTemplateIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_EmailTemplate_emailTemplate_Version = null;
            if (cmdletContext.EmailTemplate_Version != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_EmailTemplate_emailTemplate_Version = cmdletContext.EmailTemplate_Version;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_EmailTemplate_emailTemplate_Version != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_EmailTemplate.Version = requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_EmailTemplate_emailTemplate_Version;
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_EmailTemplateIsNull = false;
            }
             // determine if requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_EmailTemplate should be set to null
            if (requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_EmailTemplateIsNull)
            {
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_EmailTemplate = null;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_EmailTemplate != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration.EmailTemplate = requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_EmailTemplate;
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfigurationIsNull = false;
            }
            Amazon.Pinpoint.Model.Template requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_InAppTemplate = null;
            
             // populate InAppTemplate
            var requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_InAppTemplateIsNull = true;
            requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_InAppTemplate = new Amazon.Pinpoint.Model.Template();
            System.String requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_InAppTemplate_inAppTemplate_Name = null;
            if (cmdletContext.InAppTemplate_Name != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_InAppTemplate_inAppTemplate_Name = cmdletContext.InAppTemplate_Name;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_InAppTemplate_inAppTemplate_Name != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_InAppTemplate.Name = requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_InAppTemplate_inAppTemplate_Name;
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_InAppTemplateIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_InAppTemplate_inAppTemplate_Version = null;
            if (cmdletContext.InAppTemplate_Version != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_InAppTemplate_inAppTemplate_Version = cmdletContext.InAppTemplate_Version;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_InAppTemplate_inAppTemplate_Version != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_InAppTemplate.Version = requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_InAppTemplate_inAppTemplate_Version;
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_InAppTemplateIsNull = false;
            }
             // determine if requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_InAppTemplate should be set to null
            if (requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_InAppTemplateIsNull)
            {
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_InAppTemplate = null;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_InAppTemplate != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration.InAppTemplate = requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_InAppTemplate;
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfigurationIsNull = false;
            }
            Amazon.Pinpoint.Model.Template requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_PushTemplate = null;
            
             // populate PushTemplate
            var requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_PushTemplateIsNull = true;
            requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_PushTemplate = new Amazon.Pinpoint.Model.Template();
            System.String requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_PushTemplate_pushTemplate_Name = null;
            if (cmdletContext.PushTemplate_Name != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_PushTemplate_pushTemplate_Name = cmdletContext.PushTemplate_Name;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_PushTemplate_pushTemplate_Name != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_PushTemplate.Name = requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_PushTemplate_pushTemplate_Name;
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_PushTemplateIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_PushTemplate_pushTemplate_Version = null;
            if (cmdletContext.PushTemplate_Version != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_PushTemplate_pushTemplate_Version = cmdletContext.PushTemplate_Version;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_PushTemplate_pushTemplate_Version != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_PushTemplate.Version = requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_PushTemplate_pushTemplate_Version;
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_PushTemplateIsNull = false;
            }
             // determine if requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_PushTemplate should be set to null
            if (requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_PushTemplateIsNull)
            {
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_PushTemplate = null;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_PushTemplate != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration.PushTemplate = requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_PushTemplate;
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfigurationIsNull = false;
            }
            Amazon.Pinpoint.Model.Template requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_SMSTemplate = null;
            
             // populate SMSTemplate
            var requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_SMSTemplateIsNull = true;
            requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_SMSTemplate = new Amazon.Pinpoint.Model.Template();
            System.String requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_SMSTemplate_sMSTemplate_Name = null;
            if (cmdletContext.SMSTemplate_Name != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_SMSTemplate_sMSTemplate_Name = cmdletContext.SMSTemplate_Name;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_SMSTemplate_sMSTemplate_Name != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_SMSTemplate.Name = requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_SMSTemplate_sMSTemplate_Name;
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_SMSTemplateIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_SMSTemplate_sMSTemplate_Version = null;
            if (cmdletContext.SMSTemplate_Version != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_SMSTemplate_sMSTemplate_Version = cmdletContext.SMSTemplate_Version;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_SMSTemplate_sMSTemplate_Version != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_SMSTemplate.Version = requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_SMSTemplate_sMSTemplate_Version;
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_SMSTemplateIsNull = false;
            }
             // determine if requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_SMSTemplate should be set to null
            if (requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_SMSTemplateIsNull)
            {
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_SMSTemplate = null;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_SMSTemplate != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration.SMSTemplate = requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_SMSTemplate;
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfigurationIsNull = false;
            }
            Amazon.Pinpoint.Model.Template requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_VoiceTemplate = null;
            
             // populate VoiceTemplate
            var requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_VoiceTemplateIsNull = true;
            requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_VoiceTemplate = new Amazon.Pinpoint.Model.Template();
            System.String requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_VoiceTemplate_voiceTemplate_Name = null;
            if (cmdletContext.VoiceTemplate_Name != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_VoiceTemplate_voiceTemplate_Name = cmdletContext.VoiceTemplate_Name;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_VoiceTemplate_voiceTemplate_Name != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_VoiceTemplate.Name = requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_VoiceTemplate_voiceTemplate_Name;
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_VoiceTemplateIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_VoiceTemplate_voiceTemplate_Version = null;
            if (cmdletContext.VoiceTemplate_Version != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_VoiceTemplate_voiceTemplate_Version = cmdletContext.VoiceTemplate_Version;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_VoiceTemplate_voiceTemplate_Version != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_VoiceTemplate.Version = requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_VoiceTemplate_voiceTemplate_Version;
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_VoiceTemplateIsNull = false;
            }
             // determine if requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_VoiceTemplate should be set to null
            if (requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_VoiceTemplateIsNull)
            {
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_VoiceTemplate = null;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_VoiceTemplate != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration.VoiceTemplate = requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration_writeCampaignRequest_TemplateConfiguration_VoiceTemplate;
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfigurationIsNull = false;
            }
             // determine if requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration should be set to null
            if (requestWriteCampaignRequest_writeCampaignRequest_TemplateConfigurationIsNull)
            {
                requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration = null;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration != null)
            {
                request.WriteCampaignRequest.TemplateConfiguration = requestWriteCampaignRequest_writeCampaignRequest_TemplateConfiguration;
                requestWriteCampaignRequestIsNull = false;
            }
            Amazon.Pinpoint.Model.Schedule requestWriteCampaignRequest_writeCampaignRequest_Schedule = null;
            
             // populate Schedule
            var requestWriteCampaignRequest_writeCampaignRequest_ScheduleIsNull = true;
            requestWriteCampaignRequest_writeCampaignRequest_Schedule = new Amazon.Pinpoint.Model.Schedule();
            System.String requestWriteCampaignRequest_writeCampaignRequest_Schedule_schedule_EndTime = null;
            if (cmdletContext.Schedule_EndTime != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule_schedule_EndTime = cmdletContext.Schedule_EndTime;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_Schedule_schedule_EndTime != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule.EndTime = requestWriteCampaignRequest_writeCampaignRequest_Schedule_schedule_EndTime;
                requestWriteCampaignRequest_writeCampaignRequest_ScheduleIsNull = false;
            }
            Amazon.Pinpoint.Frequency requestWriteCampaignRequest_writeCampaignRequest_Schedule_schedule_Frequency = null;
            if (cmdletContext.Schedule_Frequency != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule_schedule_Frequency = cmdletContext.Schedule_Frequency;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_Schedule_schedule_Frequency != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule.Frequency = requestWriteCampaignRequest_writeCampaignRequest_Schedule_schedule_Frequency;
                requestWriteCampaignRequest_writeCampaignRequest_ScheduleIsNull = false;
            }
            System.Boolean? requestWriteCampaignRequest_writeCampaignRequest_Schedule_schedule_IsLocalTime = null;
            if (cmdletContext.Schedule_IsLocalTime != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule_schedule_IsLocalTime = cmdletContext.Schedule_IsLocalTime.Value;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_Schedule_schedule_IsLocalTime != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule.IsLocalTime = requestWriteCampaignRequest_writeCampaignRequest_Schedule_schedule_IsLocalTime.Value;
                requestWriteCampaignRequest_writeCampaignRequest_ScheduleIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_Schedule_schedule_StartTime = null;
            if (cmdletContext.Schedule_StartTime != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule_schedule_StartTime = cmdletContext.Schedule_StartTime;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_Schedule_schedule_StartTime != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule.StartTime = requestWriteCampaignRequest_writeCampaignRequest_Schedule_schedule_StartTime;
                requestWriteCampaignRequest_writeCampaignRequest_ScheduleIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_Schedule_schedule_Timezone = null;
            if (cmdletContext.Schedule_Timezone != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule_schedule_Timezone = cmdletContext.Schedule_Timezone;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_Schedule_schedule_Timezone != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule.Timezone = requestWriteCampaignRequest_writeCampaignRequest_Schedule_schedule_Timezone;
                requestWriteCampaignRequest_writeCampaignRequest_ScheduleIsNull = false;
            }
            Amazon.Pinpoint.Model.CampaignEventFilter requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter = null;
            
             // populate EventFilter
            var requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilterIsNull = true;
            requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter = new Amazon.Pinpoint.Model.CampaignEventFilter();
            Amazon.Pinpoint.FilterType requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_eventFilter_FilterType = null;
            if (cmdletContext.EventFilter_FilterType != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_eventFilter_FilterType = cmdletContext.EventFilter_FilterType;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_eventFilter_FilterType != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter.FilterType = requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_eventFilter_FilterType;
                requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilterIsNull = false;
            }
            Amazon.Pinpoint.Model.EventDimensions requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_writeCampaignRequest_Schedule_EventFilter_Dimensions = null;
            
             // populate Dimensions
            var requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_writeCampaignRequest_Schedule_EventFilter_DimensionsIsNull = true;
            requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_writeCampaignRequest_Schedule_EventFilter_Dimensions = new Amazon.Pinpoint.Model.EventDimensions();
            Dictionary<System.String, Amazon.Pinpoint.Model.AttributeDimension> requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_writeCampaignRequest_Schedule_EventFilter_Dimensions_dimensions_Attribute = null;
            if (cmdletContext.Dimensions_Attribute != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_writeCampaignRequest_Schedule_EventFilter_Dimensions_dimensions_Attribute = cmdletContext.Dimensions_Attribute;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_writeCampaignRequest_Schedule_EventFilter_Dimensions_dimensions_Attribute != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_writeCampaignRequest_Schedule_EventFilter_Dimensions.Attributes = requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_writeCampaignRequest_Schedule_EventFilter_Dimensions_dimensions_Attribute;
                requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_writeCampaignRequest_Schedule_EventFilter_DimensionsIsNull = false;
            }
            Dictionary<System.String, Amazon.Pinpoint.Model.MetricDimension> requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_writeCampaignRequest_Schedule_EventFilter_Dimensions_dimensions_Metric = null;
            if (cmdletContext.Dimensions_Metric != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_writeCampaignRequest_Schedule_EventFilter_Dimensions_dimensions_Metric = cmdletContext.Dimensions_Metric;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_writeCampaignRequest_Schedule_EventFilter_Dimensions_dimensions_Metric != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_writeCampaignRequest_Schedule_EventFilter_Dimensions.Metrics = requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_writeCampaignRequest_Schedule_EventFilter_Dimensions_dimensions_Metric;
                requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_writeCampaignRequest_Schedule_EventFilter_DimensionsIsNull = false;
            }
            Amazon.Pinpoint.Model.SetDimension requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_writeCampaignRequest_Schedule_EventFilter_Dimensions_writeCampaignRequest_Schedule_EventFilter_Dimensions_EventType = null;
            
             // populate EventType
            var requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_writeCampaignRequest_Schedule_EventFilter_Dimensions_writeCampaignRequest_Schedule_EventFilter_Dimensions_EventTypeIsNull = true;
            requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_writeCampaignRequest_Schedule_EventFilter_Dimensions_writeCampaignRequest_Schedule_EventFilter_Dimensions_EventType = new Amazon.Pinpoint.Model.SetDimension();
            Amazon.Pinpoint.DimensionType requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_writeCampaignRequest_Schedule_EventFilter_Dimensions_writeCampaignRequest_Schedule_EventFilter_Dimensions_EventType_eventType_DimensionType = null;
            if (cmdletContext.EventType_DimensionType != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_writeCampaignRequest_Schedule_EventFilter_Dimensions_writeCampaignRequest_Schedule_EventFilter_Dimensions_EventType_eventType_DimensionType = cmdletContext.EventType_DimensionType;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_writeCampaignRequest_Schedule_EventFilter_Dimensions_writeCampaignRequest_Schedule_EventFilter_Dimensions_EventType_eventType_DimensionType != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_writeCampaignRequest_Schedule_EventFilter_Dimensions_writeCampaignRequest_Schedule_EventFilter_Dimensions_EventType.DimensionType = requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_writeCampaignRequest_Schedule_EventFilter_Dimensions_writeCampaignRequest_Schedule_EventFilter_Dimensions_EventType_eventType_DimensionType;
                requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_writeCampaignRequest_Schedule_EventFilter_Dimensions_writeCampaignRequest_Schedule_EventFilter_Dimensions_EventTypeIsNull = false;
            }
            List<System.String> requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_writeCampaignRequest_Schedule_EventFilter_Dimensions_writeCampaignRequest_Schedule_EventFilter_Dimensions_EventType_eventType_Value = null;
            if (cmdletContext.EventType_Value != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_writeCampaignRequest_Schedule_EventFilter_Dimensions_writeCampaignRequest_Schedule_EventFilter_Dimensions_EventType_eventType_Value = cmdletContext.EventType_Value;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_writeCampaignRequest_Schedule_EventFilter_Dimensions_writeCampaignRequest_Schedule_EventFilter_Dimensions_EventType_eventType_Value != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_writeCampaignRequest_Schedule_EventFilter_Dimensions_writeCampaignRequest_Schedule_EventFilter_Dimensions_EventType.Values = requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_writeCampaignRequest_Schedule_EventFilter_Dimensions_writeCampaignRequest_Schedule_EventFilter_Dimensions_EventType_eventType_Value;
                requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_writeCampaignRequest_Schedule_EventFilter_Dimensions_writeCampaignRequest_Schedule_EventFilter_Dimensions_EventTypeIsNull = false;
            }
             // determine if requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_writeCampaignRequest_Schedule_EventFilter_Dimensions_writeCampaignRequest_Schedule_EventFilter_Dimensions_EventType should be set to null
            if (requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_writeCampaignRequest_Schedule_EventFilter_Dimensions_writeCampaignRequest_Schedule_EventFilter_Dimensions_EventTypeIsNull)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_writeCampaignRequest_Schedule_EventFilter_Dimensions_writeCampaignRequest_Schedule_EventFilter_Dimensions_EventType = null;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_writeCampaignRequest_Schedule_EventFilter_Dimensions_writeCampaignRequest_Schedule_EventFilter_Dimensions_EventType != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_writeCampaignRequest_Schedule_EventFilter_Dimensions.EventType = requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_writeCampaignRequest_Schedule_EventFilter_Dimensions_writeCampaignRequest_Schedule_EventFilter_Dimensions_EventType;
                requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_writeCampaignRequest_Schedule_EventFilter_DimensionsIsNull = false;
            }
             // determine if requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_writeCampaignRequest_Schedule_EventFilter_Dimensions should be set to null
            if (requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_writeCampaignRequest_Schedule_EventFilter_DimensionsIsNull)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_writeCampaignRequest_Schedule_EventFilter_Dimensions = null;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_writeCampaignRequest_Schedule_EventFilter_Dimensions != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter.Dimensions = requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter_writeCampaignRequest_Schedule_EventFilter_Dimensions;
                requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilterIsNull = false;
            }
             // determine if requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter should be set to null
            if (requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilterIsNull)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter = null;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule.EventFilter = requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_EventFilter;
                requestWriteCampaignRequest_writeCampaignRequest_ScheduleIsNull = false;
            }
            Amazon.Pinpoint.Model.QuietTime requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_QuietTime = null;
            
             // populate QuietTime
            var requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_QuietTimeIsNull = true;
            requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_QuietTime = new Amazon.Pinpoint.Model.QuietTime();
            System.String requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_QuietTime_quietTime_End = null;
            if (cmdletContext.QuietTime_End != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_QuietTime_quietTime_End = cmdletContext.QuietTime_End;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_QuietTime_quietTime_End != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_QuietTime.End = requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_QuietTime_quietTime_End;
                requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_QuietTimeIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_QuietTime_quietTime_Start = null;
            if (cmdletContext.QuietTime_Start != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_Schedule_writeCampaignRequest_Schedule_QuietTime_quietTime_Start = cmdletContext.QuietTime_Start;
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
            Amazon.Pinpoint.Model.MessageConfiguration requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration = null;
            
             // populate MessageConfiguration
            var requestWriteCampaignRequest_writeCampaignRequest_MessageConfigurationIsNull = true;
            requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration = new Amazon.Pinpoint.Model.MessageConfiguration();
            Amazon.Pinpoint.Model.CampaignCustomMessage requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_CustomMessage = null;
            
             // populate CustomMessage
            var requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_CustomMessageIsNull = true;
            requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_CustomMessage = new Amazon.Pinpoint.Model.CampaignCustomMessage();
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_CustomMessage_customMessage_Data = null;
            if (cmdletContext.CustomMessage_Data != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_CustomMessage_customMessage_Data = cmdletContext.CustomMessage_Data;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_CustomMessage_customMessage_Data != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_CustomMessage.Data = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_CustomMessage_customMessage_Data;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_CustomMessageIsNull = false;
            }
             // determine if requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_CustomMessage should be set to null
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_CustomMessageIsNull)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_CustomMessage = null;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_CustomMessage != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration.CustomMessage = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_CustomMessage;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfigurationIsNull = false;
            }
            Amazon.Pinpoint.Model.CampaignInAppMessage requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_InAppMessage = null;
            
             // populate InAppMessage
            var requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_InAppMessageIsNull = true;
            requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_InAppMessage = new Amazon.Pinpoint.Model.CampaignInAppMessage();
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_InAppMessage_inAppMessage_Body = null;
            if (cmdletContext.InAppMessage_Body != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_InAppMessage_inAppMessage_Body = cmdletContext.InAppMessage_Body;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_InAppMessage_inAppMessage_Body != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_InAppMessage.Body = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_InAppMessage_inAppMessage_Body;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_InAppMessageIsNull = false;
            }
            List<Amazon.Pinpoint.Model.InAppMessageContent> requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_InAppMessage_inAppMessage_Content = null;
            if (cmdletContext.InAppMessage_Content != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_InAppMessage_inAppMessage_Content = cmdletContext.InAppMessage_Content;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_InAppMessage_inAppMessage_Content != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_InAppMessage.Content = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_InAppMessage_inAppMessage_Content;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_InAppMessageIsNull = false;
            }
            Dictionary<System.String, System.String> requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_InAppMessage_inAppMessage_CustomConfig = null;
            if (cmdletContext.InAppMessage_CustomConfig != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_InAppMessage_inAppMessage_CustomConfig = cmdletContext.InAppMessage_CustomConfig;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_InAppMessage_inAppMessage_CustomConfig != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_InAppMessage.CustomConfig = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_InAppMessage_inAppMessage_CustomConfig;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_InAppMessageIsNull = false;
            }
            Amazon.Pinpoint.Layout requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_InAppMessage_inAppMessage_Layout = null;
            if (cmdletContext.InAppMessage_Layout != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_InAppMessage_inAppMessage_Layout = cmdletContext.InAppMessage_Layout;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_InAppMessage_inAppMessage_Layout != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_InAppMessage.Layout = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_InAppMessage_inAppMessage_Layout;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_InAppMessageIsNull = false;
            }
             // determine if requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_InAppMessage should be set to null
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_InAppMessageIsNull)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_InAppMessage = null;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_InAppMessage != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration.InAppMessage = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_InAppMessage;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfigurationIsNull = false;
            }
            Amazon.Pinpoint.Model.CampaignEmailMessage requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage = null;
            
             // populate EmailMessage
            var requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessageIsNull = true;
            requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage = new Amazon.Pinpoint.Model.CampaignEmailMessage();
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage_emailMessage_Body = null;
            if (cmdletContext.EmailMessage_Body != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage_emailMessage_Body = cmdletContext.EmailMessage_Body;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage_emailMessage_Body != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage.Body = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage_emailMessage_Body;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage_emailMessage_FromAddress = null;
            if (cmdletContext.EmailMessage_FromAddress != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage_emailMessage_FromAddress = cmdletContext.EmailMessage_FromAddress;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage_emailMessage_FromAddress != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage.FromAddress = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage_emailMessage_FromAddress;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessageIsNull = false;
            }
            List<Amazon.Pinpoint.Model.MessageHeader> requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage_emailMessage_Header = null;
            if (cmdletContext.EmailMessage_Header != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage_emailMessage_Header = cmdletContext.EmailMessage_Header;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage_emailMessage_Header != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage.Headers = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage_emailMessage_Header;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage_emailMessage_HtmlBody = null;
            if (cmdletContext.EmailMessage_HtmlBody != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage_emailMessage_HtmlBody = cmdletContext.EmailMessage_HtmlBody;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage_emailMessage_HtmlBody != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage.HtmlBody = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage_emailMessage_HtmlBody;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage_emailMessage_Title = null;
            if (cmdletContext.EmailMessage_Title != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_EmailMessage_emailMessage_Title = cmdletContext.EmailMessage_Title;
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
            var requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessageIsNull = true;
            requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage = new Amazon.Pinpoint.Model.CampaignSmsMessage();
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage_sMSMessage_Body = null;
            if (cmdletContext.SMSMessage_Body != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage_sMSMessage_Body = cmdletContext.SMSMessage_Body;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage_sMSMessage_Body != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage.Body = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage_sMSMessage_Body;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage_sMSMessage_EntityId = null;
            if (cmdletContext.SMSMessage_EntityId != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage_sMSMessage_EntityId = cmdletContext.SMSMessage_EntityId;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage_sMSMessage_EntityId != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage.EntityId = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage_sMSMessage_EntityId;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessageIsNull = false;
            }
            Amazon.Pinpoint.MessageType requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage_sMSMessage_MessageType = null;
            if (cmdletContext.SMSMessage_MessageType != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage_sMSMessage_MessageType = cmdletContext.SMSMessage_MessageType;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage_sMSMessage_MessageType != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage.MessageType = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage_sMSMessage_MessageType;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage_sMSMessage_OriginationNumber = null;
            if (cmdletContext.SMSMessage_OriginationNumber != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage_sMSMessage_OriginationNumber = cmdletContext.SMSMessage_OriginationNumber;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage_sMSMessage_OriginationNumber != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage.OriginationNumber = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage_sMSMessage_OriginationNumber;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage_sMSMessage_SenderId = null;
            if (cmdletContext.SMSMessage_SenderId != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage_sMSMessage_SenderId = cmdletContext.SMSMessage_SenderId;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage_sMSMessage_SenderId != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage.SenderId = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage_sMSMessage_SenderId;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage_sMSMessage_TemplateId = null;
            if (cmdletContext.SMSMessage_TemplateId != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage_sMSMessage_TemplateId = cmdletContext.SMSMessage_TemplateId;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage_sMSMessage_TemplateId != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage.TemplateId = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_SMSMessage_sMSMessage_TemplateId;
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
            Amazon.Pinpoint.Model.Message requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage = null;
            
             // populate ADMMessage
            var requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessageIsNull = true;
            requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage = new Amazon.Pinpoint.Model.Message();
            Amazon.Pinpoint.Action requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_Action = null;
            if (cmdletContext.ADMMessage_Action != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_Action = cmdletContext.ADMMessage_Action;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_Action != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage.Action = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_Action;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_Body = null;
            if (cmdletContext.ADMMessage_Body != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_Body = cmdletContext.ADMMessage_Body;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_Body != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage.Body = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_Body;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_ImageIconUrl = null;
            if (cmdletContext.ADMMessage_ImageIconUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_ImageIconUrl = cmdletContext.ADMMessage_ImageIconUrl;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_ImageIconUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage.ImageIconUrl = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_ImageIconUrl;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_ImageSmallIconUrl = null;
            if (cmdletContext.ADMMessage_ImageSmallIconUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_ImageSmallIconUrl = cmdletContext.ADMMessage_ImageSmallIconUrl;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_ImageSmallIconUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage.ImageSmallIconUrl = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_ImageSmallIconUrl;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_ImageUrl = null;
            if (cmdletContext.ADMMessage_ImageUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_ImageUrl = cmdletContext.ADMMessage_ImageUrl;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_ImageUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage.ImageUrl = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_ImageUrl;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_JsonBody = null;
            if (cmdletContext.ADMMessage_JsonBody != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_JsonBody = cmdletContext.ADMMessage_JsonBody;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_JsonBody != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage.JsonBody = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_JsonBody;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_MediaUrl = null;
            if (cmdletContext.ADMMessage_MediaUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_MediaUrl = cmdletContext.ADMMessage_MediaUrl;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_MediaUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage.MediaUrl = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_MediaUrl;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_RawContent = null;
            if (cmdletContext.ADMMessage_RawContent != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_RawContent = cmdletContext.ADMMessage_RawContent;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_RawContent != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage.RawContent = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_RawContent;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessageIsNull = false;
            }
            System.Boolean? requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_SilentPush = null;
            if (cmdletContext.ADMMessage_SilentPush != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_SilentPush = cmdletContext.ADMMessage_SilentPush.Value;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_SilentPush != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage.SilentPush = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_SilentPush.Value;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessageIsNull = false;
            }
            System.Int32? requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_TimeToLive = null;
            if (cmdletContext.ADMMessage_TimeToLive != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_TimeToLive = cmdletContext.ADMMessage_TimeToLive.Value;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_TimeToLive != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage.TimeToLive = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_TimeToLive.Value;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_Title = null;
            if (cmdletContext.ADMMessage_Title != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_Title = cmdletContext.ADMMessage_Title;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_Title != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage.Title = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_Title;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_Url = null;
            if (cmdletContext.ADMMessage_Url != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_Url = cmdletContext.ADMMessage_Url;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_Url != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage.Url = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage_aDMMessage_Url;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessageIsNull = false;
            }
             // determine if requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage should be set to null
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessageIsNull)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage = null;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration.ADMMessage = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_ADMMessage;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfigurationIsNull = false;
            }
            Amazon.Pinpoint.Model.Message requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage = null;
            
             // populate APNSMessage
            var requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessageIsNull = true;
            requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage = new Amazon.Pinpoint.Model.Message();
            Amazon.Pinpoint.Action requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_Action = null;
            if (cmdletContext.APNSMessage_Action != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_Action = cmdletContext.APNSMessage_Action;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_Action != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage.Action = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_Action;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_Body = null;
            if (cmdletContext.APNSMessage_Body != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_Body = cmdletContext.APNSMessage_Body;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_Body != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage.Body = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_Body;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_ImageIconUrl = null;
            if (cmdletContext.APNSMessage_ImageIconUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_ImageIconUrl = cmdletContext.APNSMessage_ImageIconUrl;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_ImageIconUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage.ImageIconUrl = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_ImageIconUrl;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_ImageSmallIconUrl = null;
            if (cmdletContext.APNSMessage_ImageSmallIconUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_ImageSmallIconUrl = cmdletContext.APNSMessage_ImageSmallIconUrl;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_ImageSmallIconUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage.ImageSmallIconUrl = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_ImageSmallIconUrl;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_ImageUrl = null;
            if (cmdletContext.APNSMessage_ImageUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_ImageUrl = cmdletContext.APNSMessage_ImageUrl;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_ImageUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage.ImageUrl = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_ImageUrl;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_JsonBody = null;
            if (cmdletContext.APNSMessage_JsonBody != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_JsonBody = cmdletContext.APNSMessage_JsonBody;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_JsonBody != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage.JsonBody = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_JsonBody;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_MediaUrl = null;
            if (cmdletContext.APNSMessage_MediaUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_MediaUrl = cmdletContext.APNSMessage_MediaUrl;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_MediaUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage.MediaUrl = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_MediaUrl;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_RawContent = null;
            if (cmdletContext.APNSMessage_RawContent != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_RawContent = cmdletContext.APNSMessage_RawContent;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_RawContent != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage.RawContent = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_RawContent;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessageIsNull = false;
            }
            System.Boolean? requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_SilentPush = null;
            if (cmdletContext.APNSMessage_SilentPush != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_SilentPush = cmdletContext.APNSMessage_SilentPush.Value;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_SilentPush != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage.SilentPush = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_SilentPush.Value;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessageIsNull = false;
            }
            System.Int32? requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_TimeToLive = null;
            if (cmdletContext.APNSMessage_TimeToLive != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_TimeToLive = cmdletContext.APNSMessage_TimeToLive.Value;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_TimeToLive != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage.TimeToLive = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_TimeToLive.Value;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_Title = null;
            if (cmdletContext.APNSMessage_Title != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_Title = cmdletContext.APNSMessage_Title;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_Title != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage.Title = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_Title;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_Url = null;
            if (cmdletContext.APNSMessage_Url != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_APNSMessage_aPNSMessage_Url = cmdletContext.APNSMessage_Url;
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
            Amazon.Pinpoint.Model.Message requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage = null;
            
             // populate BaiduMessage
            var requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessageIsNull = true;
            requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage = new Amazon.Pinpoint.Model.Message();
            Amazon.Pinpoint.Action requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_Action = null;
            if (cmdletContext.BaiduMessage_Action != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_Action = cmdletContext.BaiduMessage_Action;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_Action != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage.Action = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_Action;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_Body = null;
            if (cmdletContext.BaiduMessage_Body != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_Body = cmdletContext.BaiduMessage_Body;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_Body != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage.Body = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_Body;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_ImageIconUrl = null;
            if (cmdletContext.BaiduMessage_ImageIconUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_ImageIconUrl = cmdletContext.BaiduMessage_ImageIconUrl;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_ImageIconUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage.ImageIconUrl = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_ImageIconUrl;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_ImageSmallIconUrl = null;
            if (cmdletContext.BaiduMessage_ImageSmallIconUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_ImageSmallIconUrl = cmdletContext.BaiduMessage_ImageSmallIconUrl;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_ImageSmallIconUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage.ImageSmallIconUrl = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_ImageSmallIconUrl;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_ImageUrl = null;
            if (cmdletContext.BaiduMessage_ImageUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_ImageUrl = cmdletContext.BaiduMessage_ImageUrl;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_ImageUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage.ImageUrl = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_ImageUrl;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_JsonBody = null;
            if (cmdletContext.BaiduMessage_JsonBody != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_JsonBody = cmdletContext.BaiduMessage_JsonBody;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_JsonBody != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage.JsonBody = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_JsonBody;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_MediaUrl = null;
            if (cmdletContext.BaiduMessage_MediaUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_MediaUrl = cmdletContext.BaiduMessage_MediaUrl;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_MediaUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage.MediaUrl = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_MediaUrl;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_RawContent = null;
            if (cmdletContext.BaiduMessage_RawContent != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_RawContent = cmdletContext.BaiduMessage_RawContent;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_RawContent != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage.RawContent = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_RawContent;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessageIsNull = false;
            }
            System.Boolean? requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_SilentPush = null;
            if (cmdletContext.BaiduMessage_SilentPush != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_SilentPush = cmdletContext.BaiduMessage_SilentPush.Value;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_SilentPush != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage.SilentPush = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_SilentPush.Value;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessageIsNull = false;
            }
            System.Int32? requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_TimeToLive = null;
            if (cmdletContext.BaiduMessage_TimeToLive != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_TimeToLive = cmdletContext.BaiduMessage_TimeToLive.Value;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_TimeToLive != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage.TimeToLive = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_TimeToLive.Value;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_Title = null;
            if (cmdletContext.BaiduMessage_Title != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_Title = cmdletContext.BaiduMessage_Title;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_Title != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage.Title = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_Title;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_Url = null;
            if (cmdletContext.BaiduMessage_Url != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_Url = cmdletContext.BaiduMessage_Url;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_Url != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage.Url = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage_baiduMessage_Url;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessageIsNull = false;
            }
             // determine if requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage should be set to null
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessageIsNull)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage = null;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration.BaiduMessage = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_BaiduMessage;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfigurationIsNull = false;
            }
            Amazon.Pinpoint.Model.Message requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage = null;
            
             // populate DefaultMessage
            var requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessageIsNull = true;
            requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage = new Amazon.Pinpoint.Model.Message();
            Amazon.Pinpoint.Action requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_Action = null;
            if (cmdletContext.DefaultMessage_Action != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_Action = cmdletContext.DefaultMessage_Action;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_Action != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage.Action = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_Action;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_Body = null;
            if (cmdletContext.DefaultMessage_Body != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_Body = cmdletContext.DefaultMessage_Body;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_Body != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage.Body = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_Body;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_ImageIconUrl = null;
            if (cmdletContext.DefaultMessage_ImageIconUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_ImageIconUrl = cmdletContext.DefaultMessage_ImageIconUrl;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_ImageIconUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage.ImageIconUrl = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_ImageIconUrl;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_ImageSmallIconUrl = null;
            if (cmdletContext.DefaultMessage_ImageSmallIconUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_ImageSmallIconUrl = cmdletContext.DefaultMessage_ImageSmallIconUrl;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_ImageSmallIconUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage.ImageSmallIconUrl = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_ImageSmallIconUrl;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_ImageUrl = null;
            if (cmdletContext.DefaultMessage_ImageUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_ImageUrl = cmdletContext.DefaultMessage_ImageUrl;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_ImageUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage.ImageUrl = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_ImageUrl;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_JsonBody = null;
            if (cmdletContext.DefaultMessage_JsonBody != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_JsonBody = cmdletContext.DefaultMessage_JsonBody;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_JsonBody != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage.JsonBody = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_JsonBody;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_MediaUrl = null;
            if (cmdletContext.DefaultMessage_MediaUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_MediaUrl = cmdletContext.DefaultMessage_MediaUrl;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_MediaUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage.MediaUrl = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_MediaUrl;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_RawContent = null;
            if (cmdletContext.DefaultMessage_RawContent != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_RawContent = cmdletContext.DefaultMessage_RawContent;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_RawContent != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage.RawContent = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_RawContent;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessageIsNull = false;
            }
            System.Boolean? requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_SilentPush = null;
            if (cmdletContext.DefaultMessage_SilentPush != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_SilentPush = cmdletContext.DefaultMessage_SilentPush.Value;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_SilentPush != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage.SilentPush = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_SilentPush.Value;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessageIsNull = false;
            }
            System.Int32? requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_TimeToLive = null;
            if (cmdletContext.DefaultMessage_TimeToLive != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_TimeToLive = cmdletContext.DefaultMessage_TimeToLive.Value;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_TimeToLive != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage.TimeToLive = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_TimeToLive.Value;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_Title = null;
            if (cmdletContext.DefaultMessage_Title != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_Title = cmdletContext.DefaultMessage_Title;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_Title != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage.Title = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_Title;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_Url = null;
            if (cmdletContext.DefaultMessage_Url != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_DefaultMessage_defaultMessage_Url = cmdletContext.DefaultMessage_Url;
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
            var requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessageIsNull = true;
            requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage = new Amazon.Pinpoint.Model.Message();
            Amazon.Pinpoint.Action requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_Action = null;
            if (cmdletContext.GCMMessage_Action != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_Action = cmdletContext.GCMMessage_Action;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_Action != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage.Action = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_Action;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_Body = null;
            if (cmdletContext.GCMMessage_Body != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_Body = cmdletContext.GCMMessage_Body;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_Body != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage.Body = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_Body;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageIconUrl = null;
            if (cmdletContext.GCMMessage_ImageIconUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageIconUrl = cmdletContext.GCMMessage_ImageIconUrl;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageIconUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage.ImageIconUrl = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageIconUrl;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageSmallIconUrl = null;
            if (cmdletContext.GCMMessage_ImageSmallIconUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageSmallIconUrl = cmdletContext.GCMMessage_ImageSmallIconUrl;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageSmallIconUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage.ImageSmallIconUrl = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageSmallIconUrl;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageUrl = null;
            if (cmdletContext.GCMMessage_ImageUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageUrl = cmdletContext.GCMMessage_ImageUrl;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage.ImageUrl = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageUrl;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_JsonBody = null;
            if (cmdletContext.GCMMessage_JsonBody != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_JsonBody = cmdletContext.GCMMessage_JsonBody;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_JsonBody != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage.JsonBody = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_JsonBody;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_MediaUrl = null;
            if (cmdletContext.GCMMessage_MediaUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_MediaUrl = cmdletContext.GCMMessage_MediaUrl;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_MediaUrl != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage.MediaUrl = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_MediaUrl;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_RawContent = null;
            if (cmdletContext.GCMMessage_RawContent != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_RawContent = cmdletContext.GCMMessage_RawContent;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_RawContent != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage.RawContent = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_RawContent;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessageIsNull = false;
            }
            System.Boolean? requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_SilentPush = null;
            if (cmdletContext.GCMMessage_SilentPush != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_SilentPush = cmdletContext.GCMMessage_SilentPush.Value;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_SilentPush != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage.SilentPush = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_SilentPush.Value;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessageIsNull = false;
            }
            System.Int32? requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_TimeToLive = null;
            if (cmdletContext.GCMMessage_TimeToLive != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_TimeToLive = cmdletContext.GCMMessage_TimeToLive.Value;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_TimeToLive != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage.TimeToLive = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_TimeToLive.Value;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_Title = null;
            if (cmdletContext.GCMMessage_Title != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_Title = cmdletContext.GCMMessage_Title;
            }
            if (requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_Title != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage.Title = requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_Title;
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessageIsNull = false;
            }
            System.String requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_Url = null;
            if (cmdletContext.GCMMessage_Url != null)
            {
                requestWriteCampaignRequest_writeCampaignRequest_MessageConfiguration_writeCampaignRequest_MessageConfiguration_GCMMessage_gCMMessage_Url = cmdletContext.GCMMessage_Url;
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
             // determine if request.WriteCampaignRequest should be set to null
            if (requestWriteCampaignRequestIsNull)
            {
                request.WriteCampaignRequest = null;
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
        
        private Amazon.Pinpoint.Model.CreateCampaignResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.CreateCampaignRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "CreateCampaign");
            try
            {
                #if DESKTOP
                return client.CreateCampaign(request);
                #elif CORECLR
                return client.CreateCampaignAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Pinpoint.Model.WriteTreatmentResource> WriteCampaignRequest_AdditionalTreatment { get; set; }
            public System.String CustomDeliveryConfiguration_DeliveryUri { get; set; }
            public List<System.String> CustomDeliveryConfiguration_EndpointType { get; set; }
            public System.String WriteCampaignRequest_Description { get; set; }
            public System.Int32? WriteCampaignRequest_HoldoutPercent { get; set; }
            public System.String Hook_LambdaFunctionName { get; set; }
            public Amazon.Pinpoint.Mode Hook_Mode { get; set; }
            public System.String Hook_WebUrl { get; set; }
            public System.Boolean? WriteCampaignRequest_IsPaused { get; set; }
            public System.Int32? Limits_Daily { get; set; }
            public System.Int32? Limits_MaximumDuration { get; set; }
            public System.Int32? Limits_MessagesPerSecond { get; set; }
            public System.Int32? Limits_Session { get; set; }
            public System.Int32? Limits_Total { get; set; }
            public Amazon.Pinpoint.Action ADMMessage_Action { get; set; }
            public System.String ADMMessage_Body { get; set; }
            public System.String ADMMessage_ImageIconUrl { get; set; }
            public System.String ADMMessage_ImageSmallIconUrl { get; set; }
            public System.String ADMMessage_ImageUrl { get; set; }
            public System.String ADMMessage_JsonBody { get; set; }
            public System.String ADMMessage_MediaUrl { get; set; }
            public System.String ADMMessage_RawContent { get; set; }
            public System.Boolean? ADMMessage_SilentPush { get; set; }
            public System.Int32? ADMMessage_TimeToLive { get; set; }
            public System.String ADMMessage_Title { get; set; }
            public System.String ADMMessage_Url { get; set; }
            public Amazon.Pinpoint.Action APNSMessage_Action { get; set; }
            public System.String APNSMessage_Body { get; set; }
            public System.String APNSMessage_ImageIconUrl { get; set; }
            public System.String APNSMessage_ImageSmallIconUrl { get; set; }
            public System.String APNSMessage_ImageUrl { get; set; }
            public System.String APNSMessage_JsonBody { get; set; }
            public System.String APNSMessage_MediaUrl { get; set; }
            public System.String APNSMessage_RawContent { get; set; }
            public System.Boolean? APNSMessage_SilentPush { get; set; }
            public System.Int32? APNSMessage_TimeToLive { get; set; }
            public System.String APNSMessage_Title { get; set; }
            public System.String APNSMessage_Url { get; set; }
            public Amazon.Pinpoint.Action BaiduMessage_Action { get; set; }
            public System.String BaiduMessage_Body { get; set; }
            public System.String BaiduMessage_ImageIconUrl { get; set; }
            public System.String BaiduMessage_ImageSmallIconUrl { get; set; }
            public System.String BaiduMessage_ImageUrl { get; set; }
            public System.String BaiduMessage_JsonBody { get; set; }
            public System.String BaiduMessage_MediaUrl { get; set; }
            public System.String BaiduMessage_RawContent { get; set; }
            public System.Boolean? BaiduMessage_SilentPush { get; set; }
            public System.Int32? BaiduMessage_TimeToLive { get; set; }
            public System.String BaiduMessage_Title { get; set; }
            public System.String BaiduMessage_Url { get; set; }
            public System.String CustomMessage_Data { get; set; }
            public Amazon.Pinpoint.Action DefaultMessage_Action { get; set; }
            public System.String DefaultMessage_Body { get; set; }
            public System.String DefaultMessage_ImageIconUrl { get; set; }
            public System.String DefaultMessage_ImageSmallIconUrl { get; set; }
            public System.String DefaultMessage_ImageUrl { get; set; }
            public System.String DefaultMessage_JsonBody { get; set; }
            public System.String DefaultMessage_MediaUrl { get; set; }
            public System.String DefaultMessage_RawContent { get; set; }
            public System.Boolean? DefaultMessage_SilentPush { get; set; }
            public System.Int32? DefaultMessage_TimeToLive { get; set; }
            public System.String DefaultMessage_Title { get; set; }
            public System.String DefaultMessage_Url { get; set; }
            public System.String EmailMessage_Body { get; set; }
            public System.String EmailMessage_FromAddress { get; set; }
            public List<Amazon.Pinpoint.Model.MessageHeader> EmailMessage_Header { get; set; }
            public System.String EmailMessage_HtmlBody { get; set; }
            public System.String EmailMessage_Title { get; set; }
            public Amazon.Pinpoint.Action GCMMessage_Action { get; set; }
            public System.String GCMMessage_Body { get; set; }
            public System.String GCMMessage_ImageIconUrl { get; set; }
            public System.String GCMMessage_ImageSmallIconUrl { get; set; }
            public System.String GCMMessage_ImageUrl { get; set; }
            public System.String GCMMessage_JsonBody { get; set; }
            public System.String GCMMessage_MediaUrl { get; set; }
            public System.String GCMMessage_RawContent { get; set; }
            public System.Boolean? GCMMessage_SilentPush { get; set; }
            public System.Int32? GCMMessage_TimeToLive { get; set; }
            public System.String GCMMessage_Title { get; set; }
            public System.String GCMMessage_Url { get; set; }
            public System.String InAppMessage_Body { get; set; }
            public List<Amazon.Pinpoint.Model.InAppMessageContent> InAppMessage_Content { get; set; }
            public Dictionary<System.String, System.String> InAppMessage_CustomConfig { get; set; }
            public Amazon.Pinpoint.Layout InAppMessage_Layout { get; set; }
            public System.String SMSMessage_Body { get; set; }
            public System.String SMSMessage_EntityId { get; set; }
            public Amazon.Pinpoint.MessageType SMSMessage_MessageType { get; set; }
            public System.String SMSMessage_OriginationNumber { get; set; }
            public System.String SMSMessage_SenderId { get; set; }
            public System.String SMSMessage_TemplateId { get; set; }
            public System.String WriteCampaignRequest_Name { get; set; }
            public System.Int32? WriteCampaignRequest_Priority { get; set; }
            public System.String Schedule_EndTime { get; set; }
            public Dictionary<System.String, Amazon.Pinpoint.Model.AttributeDimension> Dimensions_Attribute { get; set; }
            public Amazon.Pinpoint.DimensionType EventType_DimensionType { get; set; }
            public List<System.String> EventType_Value { get; set; }
            public Dictionary<System.String, Amazon.Pinpoint.Model.MetricDimension> Dimensions_Metric { get; set; }
            public Amazon.Pinpoint.FilterType EventFilter_FilterType { get; set; }
            public Amazon.Pinpoint.Frequency Schedule_Frequency { get; set; }
            public System.Boolean? Schedule_IsLocalTime { get; set; }
            public System.String QuietTime_End { get; set; }
            public System.String QuietTime_Start { get; set; }
            public System.String Schedule_StartTime { get; set; }
            public System.String Schedule_Timezone { get; set; }
            public System.String WriteCampaignRequest_SegmentId { get; set; }
            public System.Int32? WriteCampaignRequest_SegmentVersion { get; set; }
            public Dictionary<System.String, System.String> WriteCampaignRequest_Tag { get; set; }
            public System.String EmailTemplate_Name { get; set; }
            public System.String EmailTemplate_Version { get; set; }
            public System.String InAppTemplate_Name { get; set; }
            public System.String InAppTemplate_Version { get; set; }
            public System.String PushTemplate_Name { get; set; }
            public System.String PushTemplate_Version { get; set; }
            public System.String SMSTemplate_Name { get; set; }
            public System.String SMSTemplate_Version { get; set; }
            public System.String VoiceTemplate_Name { get; set; }
            public System.String VoiceTemplate_Version { get; set; }
            public System.String WriteCampaignRequest_TreatmentDescription { get; set; }
            public System.String WriteCampaignRequest_TreatmentName { get; set; }
            public System.Func<Amazon.Pinpoint.Model.CreateCampaignResponse, NewPINCampaignCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CampaignResponse;
        }
        
    }
}
