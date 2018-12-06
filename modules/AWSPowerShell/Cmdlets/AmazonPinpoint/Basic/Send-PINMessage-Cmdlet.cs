/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Used to send a direct message.
    /// </summary>
    [Cmdlet("Send", "PINMessage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.MessageResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint SendMessages API operation.", Operation = new[] {"SendMessages"})]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.MessageResponse",
        "This cmdlet returns a MessageResponse object.",
        "The service call response (type Amazon.Pinpoint.Model.SendMessagesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SendPINMessageCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
        #region Parameter ADMMessage_Action
        /// <summary>
        /// <para>
        /// The action that occurs if the user taps a push
        /// notification delivered by the campaign: OPEN_APP - Your app launches, or it becomes
        /// the foreground app if it has been sent to the background. This is the default action.
        /// DEEP_LINK - Uses deep linking features in iOS and Android to open your app and display
        /// a designated user interface within the app. URL - The default mobile browser on the
        /// user's device launches and opens a web page at the URL you specify. Possible values
        /// include: OPEN_APP | DEEP_LINK | URL
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_ADMMessage_Action")]
        [AWSConstantClassSource("Amazon.Pinpoint.Action")]
        public Amazon.Pinpoint.Action ADMMessage_Action { get; set; }
        #endregion
        
        #region Parameter APNSMessage_Action
        /// <summary>
        /// <para>
        /// The action that occurs if the user taps a push
        /// notification delivered by the campaign: OPEN_APP - Your app launches, or it becomes
        /// the foreground app if it has been sent to the background. This is the default action.
        /// DEEP_LINK - Uses deep linking features in iOS and Android to open your app and display
        /// a designated user interface within the app. URL - The default mobile browser on the
        /// user's device launches and opens a web page at the URL you specify. Possible values
        /// include: OPEN_APP | DEEP_LINK | URL
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_APNSMessage_Action")]
        [AWSConstantClassSource("Amazon.Pinpoint.Action")]
        public Amazon.Pinpoint.Action APNSMessage_Action { get; set; }
        #endregion
        
        #region Parameter BaiduMessage_Action
        /// <summary>
        /// <para>
        /// The action that occurs if the user taps a push
        /// notification delivered by the campaign: OPEN_APP - Your app launches, or it becomes
        /// the foreground app if it has been sent to the background. This is the default action.
        /// DEEP_LINK - Uses deep linking features in iOS and Android to open your app and display
        /// a designated user interface within the app. URL - The default mobile browser on the
        /// user's device launches and opens a web page at the URL you specify. Possible values
        /// include: OPEN_APP | DEEP_LINK | URL
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_BaiduMessage_Action")]
        [AWSConstantClassSource("Amazon.Pinpoint.Action")]
        public Amazon.Pinpoint.Action BaiduMessage_Action { get; set; }
        #endregion
        
        #region Parameter DefaultPushNotificationMessage_Action
        /// <summary>
        /// <para>
        /// The action that occurs if the user taps a push
        /// notification delivered by the campaign: OPEN_APP - Your app launches, or it becomes
        /// the foreground app if it has been sent to the background. This is the default action.
        /// DEEP_LINK - Uses deep linking features in iOS and Android to open your app and display
        /// a designated user interface within the app. URL - The default mobile browser on the
        /// user's device launches and opens a web page at the URL you specify. Possible values
        /// include: OPEN_APP | DEEP_LINK | URL
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Action")]
        [AWSConstantClassSource("Amazon.Pinpoint.Action")]
        public Amazon.Pinpoint.Action DefaultPushNotificationMessage_Action { get; set; }
        #endregion
        
        #region Parameter GCMMessage_Action
        /// <summary>
        /// <para>
        /// The action that occurs if the user taps a push
        /// notification delivered by the campaign: OPEN_APP - Your app launches, or it becomes
        /// the foreground app if it has been sent to the background. This is the default action.
        /// DEEP_LINK - Uses deep linking features in iOS and Android to open your app and display
        /// a designated user interface within the app. URL - The default mobile browser on the
        /// user's device launches and opens a web page at the URL you specify. Possible values
        /// include: OPEN_APP | DEEP_LINK | URL
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_GCMMessage_Action")]
        [AWSConstantClassSource("Amazon.Pinpoint.Action")]
        public Amazon.Pinpoint.Action GCMMessage_Action { get; set; }
        #endregion
        
        #region Parameter MessageRequest_Address
        /// <summary>
        /// <para>
        /// A map of key-value pairs, where each key is
        /// an address and each value is an AddressConfiguration object. An address can be a push
        /// notification token, a phone number, or an email address.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_Addresses")]
        public System.Collections.Hashtable MessageRequest_Address { get; set; }
        #endregion
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// The unique ID of your Amazon Pinpoint application.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter APNSMessage_Badge
        /// <summary>
        /// <para>
        /// Include this key when you want the system to modify
        /// the badge of your app icon. If this key is not included in the dictionary, the badge
        /// is not changed. To remove the badge, set the value of this key to 0.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_APNSMessage_Badge")]
        public System.Int32 APNSMessage_Badge { get; set; }
        #endregion
        
        #region Parameter ADMMessage_Body
        /// <summary>
        /// <para>
        /// The message body of the notification.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_ADMMessage_Body")]
        public System.String ADMMessage_Body { get; set; }
        #endregion
        
        #region Parameter APNSMessage_Body
        /// <summary>
        /// <para>
        /// The message body of the notification.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_APNSMessage_Body")]
        public System.String APNSMessage_Body { get; set; }
        #endregion
        
        #region Parameter BaiduMessage_Body
        /// <summary>
        /// <para>
        /// The message body of the notification.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_BaiduMessage_Body")]
        public System.String BaiduMessage_Body { get; set; }
        #endregion
        
        #region Parameter DefaultMessage_Body
        /// <summary>
        /// <para>
        /// The message body of the notification, the email body
        /// or the text message.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_DefaultMessage_Body")]
        public System.String DefaultMessage_Body { get; set; }
        #endregion
        
        #region Parameter DefaultPushNotificationMessage_Body
        /// <summary>
        /// <para>
        /// The message body of the notification.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Body")]
        public System.String DefaultPushNotificationMessage_Body { get; set; }
        #endregion
        
        #region Parameter EmailMessage_Body
        /// <summary>
        /// <para>
        /// The body of the email message.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_EmailMessage_Body")]
        public System.String EmailMessage_Body { get; set; }
        #endregion
        
        #region Parameter GCMMessage_Body
        /// <summary>
        /// <para>
        /// The message body of the notification.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_GCMMessage_Body")]
        public System.String GCMMessage_Body { get; set; }
        #endregion
        
        #region Parameter SMSMessage_Body
        /// <summary>
        /// <para>
        /// The body of the SMS message.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_SMSMessage_Body")]
        public System.String SMSMessage_Body { get; set; }
        #endregion
        
        #region Parameter VoiceMessage_Body
        /// <summary>
        /// <para>
        /// The message body of the notification, the email body
        /// or the text message.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_VoiceMessage_Body")]
        public System.String VoiceMessage_Body { get; set; }
        #endregion
        
        #region Parameter APNSMessage_Category
        /// <summary>
        /// <para>
        /// Provide this key with a string value that represents
        /// the notification's type. This value corresponds to the value in the identifier property
        /// of one of your app's registered categories.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_APNSMessage_Category")]
        public System.String APNSMessage_Category { get; set; }
        #endregion
        
        #region Parameter HtmlPart_Charset
        /// <summary>
        /// <para>
        /// The character set of the content.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_EmailMessage_SimpleEmail_HtmlPart_Charset")]
        public System.String HtmlPart_Charset { get; set; }
        #endregion
        
        #region Parameter Subject_Charset
        /// <summary>
        /// <para>
        /// The character set of the content.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_EmailMessage_SimpleEmail_Subject_Charset")]
        public System.String Subject_Charset { get; set; }
        #endregion
        
        #region Parameter TextPart_Charset
        /// <summary>
        /// <para>
        /// The character set of the content.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_EmailMessage_SimpleEmail_TextPart_Charset")]
        public System.String TextPart_Charset { get; set; }
        #endregion
        
        #region Parameter APNSMessage_CollapseId
        /// <summary>
        /// <para>
        /// An ID that, if assigned to multiple messages,
        /// causes APNs to coalesce the messages into a single push notification instead of delivering
        /// each message individually. The value must not exceed 64 bytes. Amazon Pinpoint uses
        /// this value to set the apns-collapse-id request header when it sends the message to
        /// APNs.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_APNSMessage_CollapseId")]
        public System.String APNSMessage_CollapseId { get; set; }
        #endregion
        
        #region Parameter GCMMessage_CollapseKey
        /// <summary>
        /// <para>
        /// This parameter identifies a group of messages
        /// (e.g., with collapse_key: "Updates Available") that can be collapsed, so that only
        /// the last message gets sent when delivery can be resumed. This is intended to avoid
        /// sending too many of the same messages when the device comes back online or becomes
        /// active.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_GCMMessage_CollapseKey")]
        public System.String GCMMessage_CollapseKey { get; set; }
        #endregion
        
        #region Parameter ADMMessage_ConsolidationKey
        /// <summary>
        /// <para>
        /// Optional. Arbitrary string used to indicate
        /// multiple messages are logically the same and that ADM is allowed to drop previously
        /// enqueued messages in favor of this one.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_ADMMessage_ConsolidationKey")]
        public System.String ADMMessage_ConsolidationKey { get; set; }
        #endregion
        
        #region Parameter MessageRequest_Context
        /// <summary>
        /// <para>
        /// A map of custom attributes to attributes to be
        /// attached to the message. This payload is added to the push notification's 'data.pinpoint'
        /// object or added to the email/sms delivery receipt event attributes.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Collections.Hashtable MessageRequest_Context { get; set; }
        #endregion
        
        #region Parameter ADMMessage_Data
        /// <summary>
        /// <para>
        /// The data payload used for a silent push. This payload
        /// is added to the notifications' data.pinpoint.jsonBody' object
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_ADMMessage_Data")]
        public System.Collections.Hashtable ADMMessage_Data { get; set; }
        #endregion
        
        #region Parameter APNSMessage_Data
        /// <summary>
        /// <para>
        /// The data payload used for a silent push. This payload
        /// is added to the notifications' data.pinpoint.jsonBody' object
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_APNSMessage_Data")]
        public System.Collections.Hashtable APNSMessage_Data { get; set; }
        #endregion
        
        #region Parameter BaiduMessage_Data
        /// <summary>
        /// <para>
        /// The data payload used for a silent push. This payload
        /// is added to the notifications' data.pinpoint.jsonBody' object
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_BaiduMessage_Data")]
        public System.Collections.Hashtable BaiduMessage_Data { get; set; }
        #endregion
        
        #region Parameter DefaultPushNotificationMessage_Data
        /// <summary>
        /// <para>
        /// The data payload used for a silent push. This payload
        /// is added to the notifications' data.pinpoint.jsonBody' object
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Data")]
        public System.Collections.Hashtable DefaultPushNotificationMessage_Data { get; set; }
        #endregion
        
        #region Parameter RawEmail_Data
        /// <summary>
        /// <para>
        /// The raw email message itself. Then entire message
        /// must be base64-encoded.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_EmailMessage_RawEmail_Data")]
        public byte[] RawEmail_Data { get; set; }
        #endregion
        
        #region Parameter HtmlPart_Data
        /// <summary>
        /// <para>
        /// The textual data of the content.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_EmailMessage_SimpleEmail_HtmlPart_Data")]
        public System.String HtmlPart_Data { get; set; }
        #endregion
        
        #region Parameter Subject_Data
        /// <summary>
        /// <para>
        /// The textual data of the content.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_EmailMessage_SimpleEmail_Subject_Data")]
        public System.String Subject_Data { get; set; }
        #endregion
        
        #region Parameter TextPart_Data
        /// <summary>
        /// <para>
        /// The textual data of the content.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_EmailMessage_SimpleEmail_TextPart_Data")]
        public System.String TextPart_Data { get; set; }
        #endregion
        
        #region Parameter GCMMessage_Data
        /// <summary>
        /// <para>
        /// The data payload used for a silent push. This payload
        /// is added to the notifications' data.pinpoint.jsonBody' object
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_GCMMessage_Data")]
        public System.Collections.Hashtable GCMMessage_Data { get; set; }
        #endregion
        
        #region Parameter MessageRequest_Endpoint
        /// <summary>
        /// <para>
        /// A map of key-value pairs, where each key is
        /// an endpoint ID and each value is an EndpointSendConfiguration object. Within an EndpointSendConfiguration
        /// object, you can tailor the message for an endpoint by specifying message overrides
        /// or substitutions.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_Endpoints")]
        public System.Collections.Hashtable MessageRequest_Endpoint { get; set; }
        #endregion
        
        #region Parameter ADMMessage_ExpiresAfter
        /// <summary>
        /// <para>
        /// Optional. Number of seconds ADM should retain
        /// the message if the device is offline
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_ADMMessage_ExpiresAfter")]
        public System.String ADMMessage_ExpiresAfter { get; set; }
        #endregion
        
        #region Parameter EmailMessage_FeedbackForwardingAddress
        /// <summary>
        /// <para>
        /// The email address that bounces
        /// and complaints will be forwarded to when feedback forwarding is enabled.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_EmailMessage_FeedbackForwardingAddress")]
        public System.String EmailMessage_FeedbackForwardingAddress { get; set; }
        #endregion
        
        #region Parameter EmailMessage_FromAddress
        /// <summary>
        /// <para>
        /// The email address used to send the email from.
        /// Defaults to use FromAddress specified in the Email Channel.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_EmailMessage_FromAddress")]
        public System.String EmailMessage_FromAddress { get; set; }
        #endregion
        
        #region Parameter ADMMessage_IconReference
        /// <summary>
        /// <para>
        /// The icon image name of the asset saved in
        /// your application.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_ADMMessage_IconReference")]
        public System.String ADMMessage_IconReference { get; set; }
        #endregion
        
        #region Parameter BaiduMessage_IconReference
        /// <summary>
        /// <para>
        /// The icon image name of the asset saved in
        /// your application.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_BaiduMessage_IconReference")]
        public System.String BaiduMessage_IconReference { get; set; }
        #endregion
        
        #region Parameter GCMMessage_IconReference
        /// <summary>
        /// <para>
        /// The icon image name of the asset saved in
        /// your application.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_GCMMessage_IconReference")]
        public System.String GCMMessage_IconReference { get; set; }
        #endregion
        
        #region Parameter ADMMessage_ImageIconUrl
        /// <summary>
        /// <para>
        /// The URL that points to an image used as the
        /// large icon to the notification content view.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_ADMMessage_ImageIconUrl")]
        public System.String ADMMessage_ImageIconUrl { get; set; }
        #endregion
        
        #region Parameter BaiduMessage_ImageIconUrl
        /// <summary>
        /// <para>
        /// The URL that points to an image used as the
        /// large icon to the notification content view.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_BaiduMessage_ImageIconUrl")]
        public System.String BaiduMessage_ImageIconUrl { get; set; }
        #endregion
        
        #region Parameter GCMMessage_ImageIconUrl
        /// <summary>
        /// <para>
        /// The URL that points to an image used as the
        /// large icon to the notification content view.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_GCMMessage_ImageIconUrl")]
        public System.String GCMMessage_ImageIconUrl { get; set; }
        #endregion
        
        #region Parameter ADMMessage_ImageUrl
        /// <summary>
        /// <para>
        /// The URL that points to an image used in the push
        /// notification.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_ADMMessage_ImageUrl")]
        public System.String ADMMessage_ImageUrl { get; set; }
        #endregion
        
        #region Parameter BaiduMessage_ImageUrl
        /// <summary>
        /// <para>
        /// The URL that points to an image used in the push
        /// notification.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_BaiduMessage_ImageUrl")]
        public System.String BaiduMessage_ImageUrl { get; set; }
        #endregion
        
        #region Parameter GCMMessage_ImageUrl
        /// <summary>
        /// <para>
        /// The URL that points to an image used in the push
        /// notification.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_GCMMessage_ImageUrl")]
        public System.String GCMMessage_ImageUrl { get; set; }
        #endregion
        
        #region Parameter SMSMessage_Keyword
        /// <summary>
        /// <para>
        /// The SMS program name that you provided to AWS
        /// Support when you requested your dedicated number.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_SMSMessage_Keyword")]
        public System.String SMSMessage_Keyword { get; set; }
        #endregion
        
        #region Parameter VoiceMessage_LanguageCode
        /// <summary>
        /// <para>
        /// Language of sent message
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_VoiceMessage_LanguageCode")]
        public System.String VoiceMessage_LanguageCode { get; set; }
        #endregion
        
        #region Parameter ADMMessage_MD5
        /// <summary>
        /// <para>
        /// Optional. Base-64-encoded MD5 checksum of the data
        /// parameter. Used to verify data integrity
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_ADMMessage_MD5")]
        public System.String ADMMessage_MD5 { get; set; }
        #endregion
        
        #region Parameter APNSMessage_MediaUrl
        /// <summary>
        /// <para>
        /// A URL that refers to the location of an image
        /// or video that you want to display in the push notification.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_APNSMessage_MediaUrl")]
        public System.String APNSMessage_MediaUrl { get; set; }
        #endregion
        
        #region Parameter SMSMessage_MessageType
        /// <summary>
        /// <para>
        /// Is this a transaction priority message or
        /// lower priority.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_SMSMessage_MessageType")]
        [AWSConstantClassSource("Amazon.Pinpoint.MessageType")]
        public Amazon.Pinpoint.MessageType SMSMessage_MessageType { get; set; }
        #endregion
        
        #region Parameter SMSMessage_OriginationNumber
        /// <summary>
        /// <para>
        /// The phone number that the SMS message
        /// originates from. Specify one of the dedicated long codes or short codes that you requested
        /// from AWS Support and that is assigned to your account. If this attribute is not specified,
        /// Amazon Pinpoint randomly assigns a long code.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_SMSMessage_OriginationNumber")]
        public System.String SMSMessage_OriginationNumber { get; set; }
        #endregion
        
        #region Parameter VoiceMessage_OriginationNumber
        /// <summary>
        /// <para>
        /// Is the number from the pool or messaging
        /// service to send from.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_VoiceMessage_OriginationNumber")]
        public System.String VoiceMessage_OriginationNumber { get; set; }
        #endregion
        
        #region Parameter APNSMessage_PreferredAuthenticationMethod
        /// <summary>
        /// <para>
        /// The preferred authentication
        /// method, either "CERTIFICATE" or "TOKEN"
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_APNSMessage_PreferredAuthenticationMethod")]
        public System.String APNSMessage_PreferredAuthenticationMethod { get; set; }
        #endregion
        
        #region Parameter APNSMessage_Priority
        /// <summary>
        /// <para>
        /// The message priority. Amazon Pinpoint uses this
        /// value to set the apns-priority request header when it sends the message to APNs. Accepts
        /// the following values:"5" - Low priority. Messages might be delayed, delivered in groups,
        /// and throttled."10" - High priority. Messages are sent immediately. High priority messages
        /// must cause an alert, sound, or badge on the receiving device.The default value is
        /// "10".The equivalent values for FCM or GCM messages are "normal" and "high". Amazon
        /// Pinpoint accepts these values for APNs messages and converts them.For more information
        /// about the apns-priority parameter, see Communicating with APNs in the APNs Local and
        /// Remote Notification Programming Guide.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_APNSMessage_Priority")]
        public System.String APNSMessage_Priority { get; set; }
        #endregion
        
        #region Parameter GCMMessage_Priority
        /// <summary>
        /// <para>
        /// The message priority. Amazon Pinpoint uses this
        /// value to set the FCM or GCM priority parameter when it sends the message. Accepts
        /// the following values:"Normal" - Messages might be delayed. Delivery is optimized for
        /// battery usage on the receiving device. Use normal priority unless immediate delivery
        /// is required."High" - Messages are sent immediately and might wake a sleeping device.The
        /// equivalent values for APNs messages are "5" and "10". Amazon Pinpoint accepts these
        /// values here and converts them.For more information, see About FCM Messages in the
        /// Firebase documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_GCMMessage_Priority")]
        public System.String GCMMessage_Priority { get; set; }
        #endregion
        
        #region Parameter ADMMessage_RawContent
        /// <summary>
        /// <para>
        /// The Raw JSON formatted string to be used as
        /// the payload. This value overrides the message.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_ADMMessage_RawContent")]
        public System.String ADMMessage_RawContent { get; set; }
        #endregion
        
        #region Parameter APNSMessage_RawContent
        /// <summary>
        /// <para>
        /// The Raw JSON formatted string to be used as
        /// the payload. This value overrides the message.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_APNSMessage_RawContent")]
        public System.String APNSMessage_RawContent { get; set; }
        #endregion
        
        #region Parameter BaiduMessage_RawContent
        /// <summary>
        /// <para>
        /// The Raw JSON formatted string to be used as
        /// the payload. This value overrides the message.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_BaiduMessage_RawContent")]
        public System.String BaiduMessage_RawContent { get; set; }
        #endregion
        
        #region Parameter GCMMessage_RawContent
        /// <summary>
        /// <para>
        /// The Raw JSON formatted string to be used as
        /// the payload. This value overrides the message.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_GCMMessage_RawContent")]
        public System.String GCMMessage_RawContent { get; set; }
        #endregion
        
        #region Parameter EmailMessage_ReplyToAddress
        /// <summary>
        /// <para>
        /// The reply-to email address(es) for the
        /// email. If the recipient replies to the email, each reply-to address will receive the
        /// reply.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_EmailMessage_ReplyToAddresses")]
        public System.String[] EmailMessage_ReplyToAddress { get; set; }
        #endregion
        
        #region Parameter GCMMessage_RestrictedPackageName
        /// <summary>
        /// <para>
        /// This parameter specifies the package
        /// name of the application where the registration tokens must match in order to receive
        /// the message.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_GCMMessage_RestrictedPackageName")]
        public System.String GCMMessage_RestrictedPackageName { get; set; }
        #endregion
        
        #region Parameter SMSMessage_SenderId
        /// <summary>
        /// <para>
        /// The sender ID that is shown as the message sender
        /// on the recipient's device. Support for sender IDs varies by country or region.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_SMSMessage_SenderId")]
        public System.String SMSMessage_SenderId { get; set; }
        #endregion
        
        #region Parameter ADMMessage_SilentPush
        /// <summary>
        /// <para>
        /// Indicates if the message should display on
        /// the users device. Silent pushes can be used for Remote Configuration and Phone Home
        /// use cases.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_ADMMessage_SilentPush")]
        public System.Boolean ADMMessage_SilentPush { get; set; }
        #endregion
        
        #region Parameter APNSMessage_SilentPush
        /// <summary>
        /// <para>
        /// Indicates if the message should display on
        /// the users device. Silent pushes can be used for Remote Configuration and Phone Home
        /// use cases.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_APNSMessage_SilentPush")]
        public System.Boolean APNSMessage_SilentPush { get; set; }
        #endregion
        
        #region Parameter BaiduMessage_SilentPush
        /// <summary>
        /// <para>
        /// Indicates if the message should display on
        /// the users device. Silent pushes can be used for Remote Configuration and Phone Home
        /// use cases.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_BaiduMessage_SilentPush")]
        public System.Boolean BaiduMessage_SilentPush { get; set; }
        #endregion
        
        #region Parameter DefaultPushNotificationMessage_SilentPush
        /// <summary>
        /// <para>
        /// Indicates if the message should display on
        /// the recipient's device. You can use silent pushes for remote configuration or to deliver
        /// messages to in-app notification centers.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_SilentPush")]
        public System.Boolean DefaultPushNotificationMessage_SilentPush { get; set; }
        #endregion
        
        #region Parameter GCMMessage_SilentPush
        /// <summary>
        /// <para>
        /// Indicates if the message should display on
        /// the users device. Silent pushes can be used for Remote Configuration and Phone Home
        /// use cases.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_GCMMessage_SilentPush")]
        public System.Boolean GCMMessage_SilentPush { get; set; }
        #endregion
        
        #region Parameter ADMMessage_SmallImageIconUrl
        /// <summary>
        /// <para>
        /// The URL that points to an image used
        /// as the small icon for the notification which will be used to represent the notification
        /// in the status bar and content view
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_ADMMessage_SmallImageIconUrl")]
        public System.String ADMMessage_SmallImageIconUrl { get; set; }
        #endregion
        
        #region Parameter BaiduMessage_SmallImageIconUrl
        /// <summary>
        /// <para>
        /// The URL that points to an image used
        /// as the small icon for the notification which will be used to represent the notification
        /// in the status bar and content view
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_BaiduMessage_SmallImageIconUrl")]
        public System.String BaiduMessage_SmallImageIconUrl { get; set; }
        #endregion
        
        #region Parameter GCMMessage_SmallImageIconUrl
        /// <summary>
        /// <para>
        /// The URL that points to an image used
        /// as the small icon for the notification which will be used to represent the notification
        /// in the status bar and content view
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_GCMMessage_SmallImageIconUrl")]
        public System.String GCMMessage_SmallImageIconUrl { get; set; }
        #endregion
        
        #region Parameter ADMMessage_Sound
        /// <summary>
        /// <para>
        /// Indicates a sound to play when the device receives
        /// the notification. Supports default, or the filename of a sound resource bundled in
        /// the app. Android sound files must reside in /res/raw/
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_ADMMessage_Sound")]
        public System.String ADMMessage_Sound { get; set; }
        #endregion
        
        #region Parameter APNSMessage_Sound
        /// <summary>
        /// <para>
        /// Include this key when you want the system to play
        /// a sound. The value of this key is the name of a sound file in your app's main bundle
        /// or in the Library/Sounds folder of your app's data container. If the sound file cannot
        /// be found, or if you specify defaultfor the value, the system plays the default alert
        /// sound.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_APNSMessage_Sound")]
        public System.String APNSMessage_Sound { get; set; }
        #endregion
        
        #region Parameter BaiduMessage_Sound
        /// <summary>
        /// <para>
        /// Indicates a sound to play when the device receives
        /// the notification. Supports default, or the filename of a sound resource bundled in
        /// the app. Android sound files must reside in /res/raw/
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_BaiduMessage_Sound")]
        public System.String BaiduMessage_Sound { get; set; }
        #endregion
        
        #region Parameter GCMMessage_Sound
        /// <summary>
        /// <para>
        /// Indicates a sound to play when the device receives
        /// the notification. Supports default, or the filename of a sound resource bundled in
        /// the app. Android sound files must reside in /res/raw/
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_GCMMessage_Sound")]
        public System.String GCMMessage_Sound { get; set; }
        #endregion
        
        #region Parameter ADMMessage_Substitution
        /// <summary>
        /// <para>
        /// Default message substitutions. Can be overridden
        /// by individual address substitutions.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_ADMMessage_Substitutions")]
        public System.Collections.Hashtable ADMMessage_Substitution { get; set; }
        #endregion
        
        #region Parameter APNSMessage_Substitution
        /// <summary>
        /// <para>
        /// Default message substitutions. Can be overridden
        /// by individual address substitutions.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_APNSMessage_Substitutions")]
        public System.Collections.Hashtable APNSMessage_Substitution { get; set; }
        #endregion
        
        #region Parameter BaiduMessage_Substitution
        /// <summary>
        /// <para>
        /// Default message substitutions. Can be overridden
        /// by individual address substitutions.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_BaiduMessage_Substitutions")]
        public System.Collections.Hashtable BaiduMessage_Substitution { get; set; }
        #endregion
        
        #region Parameter DefaultMessage_Substitution
        /// <summary>
        /// <para>
        /// Default message substitutions. Can be overridden
        /// by individual address substitutions.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_DefaultMessage_Substitutions")]
        public System.Collections.Hashtable DefaultMessage_Substitution { get; set; }
        #endregion
        
        #region Parameter DefaultPushNotificationMessage_Substitution
        /// <summary>
        /// <para>
        /// Default message substitutions. Can be overridden
        /// by individual address substitutions.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Substitutions")]
        public System.Collections.Hashtable DefaultPushNotificationMessage_Substitution { get; set; }
        #endregion
        
        #region Parameter EmailMessage_Substitution
        /// <summary>
        /// <para>
        /// Default message substitutions. Can be overridden
        /// by individual address substitutions.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_EmailMessage_Substitutions")]
        public System.Collections.Hashtable EmailMessage_Substitution { get; set; }
        #endregion
        
        #region Parameter GCMMessage_Substitution
        /// <summary>
        /// <para>
        /// Default message substitutions. Can be overridden
        /// by individual address substitutions.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_GCMMessage_Substitutions")]
        public System.Collections.Hashtable GCMMessage_Substitution { get; set; }
        #endregion
        
        #region Parameter SMSMessage_Substitution
        /// <summary>
        /// <para>
        /// Default message substitutions. Can be overridden
        /// by individual address substitutions.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_SMSMessage_Substitutions")]
        public System.Collections.Hashtable SMSMessage_Substitution { get; set; }
        #endregion
        
        #region Parameter VoiceMessage_Substitution
        /// <summary>
        /// <para>
        /// Default message substitutions. Can be overridden
        /// by individual address substitutions.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_VoiceMessage_Substitutions")]
        public System.Collections.Hashtable VoiceMessage_Substitution { get; set; }
        #endregion
        
        #region Parameter APNSMessage_ThreadId
        /// <summary>
        /// <para>
        /// Provide this key with a string value that represents
        /// the app-specific identifier for grouping notifications. If you provide a Notification
        /// Content app extension, you can use this value to group your notifications together.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_APNSMessage_ThreadId")]
        public System.String APNSMessage_ThreadId { get; set; }
        #endregion
        
        #region Parameter APNSMessage_TimeToLive
        /// <summary>
        /// <para>
        /// The length of time (in seconds) that APNs stores
        /// and attempts to deliver the message. If the value is 0, APNs does not store the message
        /// or attempt to deliver it more than once. Amazon Pinpoint uses this value to set the
        /// apns-expiration request header when it sends the message to APNs.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_APNSMessage_TimeToLive")]
        public System.Int32 APNSMessage_TimeToLive { get; set; }
        #endregion
        
        #region Parameter BaiduMessage_TimeToLive
        /// <summary>
        /// <para>
        /// This parameter specifies how long (in seconds)
        /// the message should be kept in Baidu storage if the device is offline. The and the
        /// default value and the maximum time to live supported is 7 days (604800 seconds)
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_BaiduMessage_TimeToLive")]
        public System.Int32 BaiduMessage_TimeToLive { get; set; }
        #endregion
        
        #region Parameter GCMMessage_TimeToLive
        /// <summary>
        /// <para>
        /// The length of time (in seconds) that FCM or
        /// GCM stores and attempts to deliver the message. If unspecified, the value defaults
        /// to the maximum, which is 2,419,200 seconds (28 days). Amazon Pinpoint uses this value
        /// to set the FCM or GCM time_to_live parameter.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_GCMMessage_TimeToLive")]
        public System.Int32 GCMMessage_TimeToLive { get; set; }
        #endregion
        
        #region Parameter ADMMessage_Title
        /// <summary>
        /// <para>
        /// The message title that displays above the message
        /// on the user's device.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_ADMMessage_Title")]
        public System.String ADMMessage_Title { get; set; }
        #endregion
        
        #region Parameter APNSMessage_Title
        /// <summary>
        /// <para>
        /// The message title that displays above the message
        /// on the user's device.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_APNSMessage_Title")]
        public System.String APNSMessage_Title { get; set; }
        #endregion
        
        #region Parameter BaiduMessage_Title
        /// <summary>
        /// <para>
        /// The message title that displays above the message
        /// on the user's device.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_BaiduMessage_Title")]
        public System.String BaiduMessage_Title { get; set; }
        #endregion
        
        #region Parameter DefaultPushNotificationMessage_Title
        /// <summary>
        /// <para>
        /// The message title that displays above the message
        /// on the user's device.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Title")]
        public System.String DefaultPushNotificationMessage_Title { get; set; }
        #endregion
        
        #region Parameter GCMMessage_Title
        /// <summary>
        /// <para>
        /// The message title that displays above the message
        /// on the user's device.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_GCMMessage_Title")]
        public System.String GCMMessage_Title { get; set; }
        #endregion
        
        #region Parameter MessageRequest_TraceId
        /// <summary>
        /// <para>
        /// A unique ID that you can use to trace a message.
        /// This ID is visible to recipients.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MessageRequest_TraceId { get; set; }
        #endregion
        
        #region Parameter ADMMessage_Url
        /// <summary>
        /// <para>
        /// The URL to open in the user's mobile browser. Used
        /// if the value for Action is URL.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_ADMMessage_Url")]
        public System.String ADMMessage_Url { get; set; }
        #endregion
        
        #region Parameter APNSMessage_Url
        /// <summary>
        /// <para>
        /// The URL to open in the user's mobile browser. Used
        /// if the value for Action is URL.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_APNSMessage_Url")]
        public System.String APNSMessage_Url { get; set; }
        #endregion
        
        #region Parameter BaiduMessage_Url
        /// <summary>
        /// <para>
        /// The URL to open in the user's mobile browser. Used
        /// if the value for Action is URL.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_BaiduMessage_Url")]
        public System.String BaiduMessage_Url { get; set; }
        #endregion
        
        #region Parameter DefaultPushNotificationMessage_Url
        /// <summary>
        /// <para>
        /// The URL to open in the user's mobile browser. Used
        /// if the value for Action is URL.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Url")]
        public System.String DefaultPushNotificationMessage_Url { get; set; }
        #endregion
        
        #region Parameter GCMMessage_Url
        /// <summary>
        /// <para>
        /// The URL to open in the user's mobile browser. Used
        /// if the value for Action is URL.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_GCMMessage_Url")]
        public System.String GCMMessage_Url { get; set; }
        #endregion
        
        #region Parameter VoiceMessage_VoiceId
        /// <summary>
        /// <para>
        /// Voice ID of sent message.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageRequest_MessageConfiguration_VoiceMessage_VoiceId")]
        public System.String VoiceMessage_VoiceId { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-PINMessage (SendMessages)"))
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
            if (this.MessageRequest_Address != null)
            {
                context.MessageRequest_Addresses = new Dictionary<System.String, Amazon.Pinpoint.Model.AddressConfiguration>(StringComparer.Ordinal);
                foreach (var hashKey in this.MessageRequest_Address.Keys)
                {
                    context.MessageRequest_Addresses.Add((String)hashKey, (AddressConfiguration)(this.MessageRequest_Address[hashKey]));
                }
            }
            if (this.MessageRequest_Context != null)
            {
                context.MessageRequest_Context = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.MessageRequest_Context.Keys)
                {
                    context.MessageRequest_Context.Add((String)hashKey, (String)(this.MessageRequest_Context[hashKey]));
                }
            }
            if (this.MessageRequest_Endpoint != null)
            {
                context.MessageRequest_Endpoints = new Dictionary<System.String, Amazon.Pinpoint.Model.EndpointSendConfiguration>(StringComparer.Ordinal);
                foreach (var hashKey in this.MessageRequest_Endpoint.Keys)
                {
                    context.MessageRequest_Endpoints.Add((String)hashKey, (EndpointSendConfiguration)(this.MessageRequest_Endpoint[hashKey]));
                }
            }
            context.MessageRequest_MessageConfiguration_ADMMessage_Action = this.ADMMessage_Action;
            context.MessageRequest_MessageConfiguration_ADMMessage_Body = this.ADMMessage_Body;
            context.MessageRequest_MessageConfiguration_ADMMessage_ConsolidationKey = this.ADMMessage_ConsolidationKey;
            if (this.ADMMessage_Data != null)
            {
                context.MessageRequest_MessageConfiguration_ADMMessage_Data = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ADMMessage_Data.Keys)
                {
                    context.MessageRequest_MessageConfiguration_ADMMessage_Data.Add((String)hashKey, (String)(this.ADMMessage_Data[hashKey]));
                }
            }
            context.MessageRequest_MessageConfiguration_ADMMessage_ExpiresAfter = this.ADMMessage_ExpiresAfter;
            context.MessageRequest_MessageConfiguration_ADMMessage_IconReference = this.ADMMessage_IconReference;
            context.MessageRequest_MessageConfiguration_ADMMessage_ImageIconUrl = this.ADMMessage_ImageIconUrl;
            context.MessageRequest_MessageConfiguration_ADMMessage_ImageUrl = this.ADMMessage_ImageUrl;
            context.MessageRequest_MessageConfiguration_ADMMessage_MD5 = this.ADMMessage_MD5;
            context.MessageRequest_MessageConfiguration_ADMMessage_RawContent = this.ADMMessage_RawContent;
            if (ParameterWasBound("ADMMessage_SilentPush"))
                context.MessageRequest_MessageConfiguration_ADMMessage_SilentPush = this.ADMMessage_SilentPush;
            context.MessageRequest_MessageConfiguration_ADMMessage_SmallImageIconUrl = this.ADMMessage_SmallImageIconUrl;
            context.MessageRequest_MessageConfiguration_ADMMessage_Sound = this.ADMMessage_Sound;
            if (this.ADMMessage_Substitution != null)
            {
                context.MessageRequest_MessageConfiguration_ADMMessage_Substitutions = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.ADMMessage_Substitution.Keys)
                {
                    object hashValue = this.ADMMessage_Substitution[hashKey];
                    if (hashValue == null)
                    {
                        context.MessageRequest_MessageConfiguration_ADMMessage_Substitutions.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((String)s);
                    }
                    context.MessageRequest_MessageConfiguration_ADMMessage_Substitutions.Add((String)hashKey, valueSet);
                }
            }
            context.MessageRequest_MessageConfiguration_ADMMessage_Title = this.ADMMessage_Title;
            context.MessageRequest_MessageConfiguration_ADMMessage_Url = this.ADMMessage_Url;
            context.MessageRequest_MessageConfiguration_APNSMessage_Action = this.APNSMessage_Action;
            if (ParameterWasBound("APNSMessage_Badge"))
                context.MessageRequest_MessageConfiguration_APNSMessage_Badge = this.APNSMessage_Badge;
            context.MessageRequest_MessageConfiguration_APNSMessage_Body = this.APNSMessage_Body;
            context.MessageRequest_MessageConfiguration_APNSMessage_Category = this.APNSMessage_Category;
            context.MessageRequest_MessageConfiguration_APNSMessage_CollapseId = this.APNSMessage_CollapseId;
            if (this.APNSMessage_Data != null)
            {
                context.MessageRequest_MessageConfiguration_APNSMessage_Data = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.APNSMessage_Data.Keys)
                {
                    context.MessageRequest_MessageConfiguration_APNSMessage_Data.Add((String)hashKey, (String)(this.APNSMessage_Data[hashKey]));
                }
            }
            context.MessageRequest_MessageConfiguration_APNSMessage_MediaUrl = this.APNSMessage_MediaUrl;
            context.MessageRequest_MessageConfiguration_APNSMessage_PreferredAuthenticationMethod = this.APNSMessage_PreferredAuthenticationMethod;
            context.MessageRequest_MessageConfiguration_APNSMessage_Priority = this.APNSMessage_Priority;
            context.MessageRequest_MessageConfiguration_APNSMessage_RawContent = this.APNSMessage_RawContent;
            if (ParameterWasBound("APNSMessage_SilentPush"))
                context.MessageRequest_MessageConfiguration_APNSMessage_SilentPush = this.APNSMessage_SilentPush;
            context.MessageRequest_MessageConfiguration_APNSMessage_Sound = this.APNSMessage_Sound;
            if (this.APNSMessage_Substitution != null)
            {
                context.MessageRequest_MessageConfiguration_APNSMessage_Substitutions = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.APNSMessage_Substitution.Keys)
                {
                    object hashValue = this.APNSMessage_Substitution[hashKey];
                    if (hashValue == null)
                    {
                        context.MessageRequest_MessageConfiguration_APNSMessage_Substitutions.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((String)s);
                    }
                    context.MessageRequest_MessageConfiguration_APNSMessage_Substitutions.Add((String)hashKey, valueSet);
                }
            }
            context.MessageRequest_MessageConfiguration_APNSMessage_ThreadId = this.APNSMessage_ThreadId;
            if (ParameterWasBound("APNSMessage_TimeToLive"))
                context.MessageRequest_MessageConfiguration_APNSMessage_TimeToLive = this.APNSMessage_TimeToLive;
            context.MessageRequest_MessageConfiguration_APNSMessage_Title = this.APNSMessage_Title;
            context.MessageRequest_MessageConfiguration_APNSMessage_Url = this.APNSMessage_Url;
            context.MessageRequest_MessageConfiguration_BaiduMessage_Action = this.BaiduMessage_Action;
            context.MessageRequest_MessageConfiguration_BaiduMessage_Body = this.BaiduMessage_Body;
            if (this.BaiduMessage_Data != null)
            {
                context.MessageRequest_MessageConfiguration_BaiduMessage_Data = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.BaiduMessage_Data.Keys)
                {
                    context.MessageRequest_MessageConfiguration_BaiduMessage_Data.Add((String)hashKey, (String)(this.BaiduMessage_Data[hashKey]));
                }
            }
            context.MessageRequest_MessageConfiguration_BaiduMessage_IconReference = this.BaiduMessage_IconReference;
            context.MessageRequest_MessageConfiguration_BaiduMessage_ImageIconUrl = this.BaiduMessage_ImageIconUrl;
            context.MessageRequest_MessageConfiguration_BaiduMessage_ImageUrl = this.BaiduMessage_ImageUrl;
            context.MessageRequest_MessageConfiguration_BaiduMessage_RawContent = this.BaiduMessage_RawContent;
            if (ParameterWasBound("BaiduMessage_SilentPush"))
                context.MessageRequest_MessageConfiguration_BaiduMessage_SilentPush = this.BaiduMessage_SilentPush;
            context.MessageRequest_MessageConfiguration_BaiduMessage_SmallImageIconUrl = this.BaiduMessage_SmallImageIconUrl;
            context.MessageRequest_MessageConfiguration_BaiduMessage_Sound = this.BaiduMessage_Sound;
            if (this.BaiduMessage_Substitution != null)
            {
                context.MessageRequest_MessageConfiguration_BaiduMessage_Substitutions = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.BaiduMessage_Substitution.Keys)
                {
                    object hashValue = this.BaiduMessage_Substitution[hashKey];
                    if (hashValue == null)
                    {
                        context.MessageRequest_MessageConfiguration_BaiduMessage_Substitutions.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((String)s);
                    }
                    context.MessageRequest_MessageConfiguration_BaiduMessage_Substitutions.Add((String)hashKey, valueSet);
                }
            }
            if (ParameterWasBound("BaiduMessage_TimeToLive"))
                context.MessageRequest_MessageConfiguration_BaiduMessage_TimeToLive = this.BaiduMessage_TimeToLive;
            context.MessageRequest_MessageConfiguration_BaiduMessage_Title = this.BaiduMessage_Title;
            context.MessageRequest_MessageConfiguration_BaiduMessage_Url = this.BaiduMessage_Url;
            context.MessageRequest_MessageConfiguration_DefaultMessage_Body = this.DefaultMessage_Body;
            if (this.DefaultMessage_Substitution != null)
            {
                context.MessageRequest_MessageConfiguration_DefaultMessage_Substitutions = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.DefaultMessage_Substitution.Keys)
                {
                    object hashValue = this.DefaultMessage_Substitution[hashKey];
                    if (hashValue == null)
                    {
                        context.MessageRequest_MessageConfiguration_DefaultMessage_Substitutions.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((String)s);
                    }
                    context.MessageRequest_MessageConfiguration_DefaultMessage_Substitutions.Add((String)hashKey, valueSet);
                }
            }
            context.MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Action = this.DefaultPushNotificationMessage_Action;
            context.MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Body = this.DefaultPushNotificationMessage_Body;
            if (this.DefaultPushNotificationMessage_Data != null)
            {
                context.MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Data = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.DefaultPushNotificationMessage_Data.Keys)
                {
                    context.MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Data.Add((String)hashKey, (String)(this.DefaultPushNotificationMessage_Data[hashKey]));
                }
            }
            if (ParameterWasBound("DefaultPushNotificationMessage_SilentPush"))
                context.MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_SilentPush = this.DefaultPushNotificationMessage_SilentPush;
            if (this.DefaultPushNotificationMessage_Substitution != null)
            {
                context.MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Substitutions = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.DefaultPushNotificationMessage_Substitution.Keys)
                {
                    object hashValue = this.DefaultPushNotificationMessage_Substitution[hashKey];
                    if (hashValue == null)
                    {
                        context.MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Substitutions.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((String)s);
                    }
                    context.MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Substitutions.Add((String)hashKey, valueSet);
                }
            }
            context.MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Title = this.DefaultPushNotificationMessage_Title;
            context.MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Url = this.DefaultPushNotificationMessage_Url;
            context.MessageRequest_MessageConfiguration_EmailMessage_Body = this.EmailMessage_Body;
            context.MessageRequest_MessageConfiguration_EmailMessage_FeedbackForwardingAddress = this.EmailMessage_FeedbackForwardingAddress;
            context.MessageRequest_MessageConfiguration_EmailMessage_FromAddress = this.EmailMessage_FromAddress;
            context.MessageRequest_MessageConfiguration_EmailMessage_RawEmail_Data = this.RawEmail_Data;
            if (this.EmailMessage_ReplyToAddress != null)
            {
                context.MessageRequest_MessageConfiguration_EmailMessage_ReplyToAddresses = new List<System.String>(this.EmailMessage_ReplyToAddress);
            }
            context.MessageRequest_MessageConfiguration_EmailMessage_SimpleEmail_HtmlPart_Charset = this.HtmlPart_Charset;
            context.MessageRequest_MessageConfiguration_EmailMessage_SimpleEmail_HtmlPart_Data = this.HtmlPart_Data;
            context.MessageRequest_MessageConfiguration_EmailMessage_SimpleEmail_Subject_Charset = this.Subject_Charset;
            context.MessageRequest_MessageConfiguration_EmailMessage_SimpleEmail_Subject_Data = this.Subject_Data;
            context.MessageRequest_MessageConfiguration_EmailMessage_SimpleEmail_TextPart_Charset = this.TextPart_Charset;
            context.MessageRequest_MessageConfiguration_EmailMessage_SimpleEmail_TextPart_Data = this.TextPart_Data;
            if (this.EmailMessage_Substitution != null)
            {
                context.MessageRequest_MessageConfiguration_EmailMessage_Substitutions = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.EmailMessage_Substitution.Keys)
                {
                    object hashValue = this.EmailMessage_Substitution[hashKey];
                    if (hashValue == null)
                    {
                        context.MessageRequest_MessageConfiguration_EmailMessage_Substitutions.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((String)s);
                    }
                    context.MessageRequest_MessageConfiguration_EmailMessage_Substitutions.Add((String)hashKey, valueSet);
                }
            }
            context.MessageRequest_MessageConfiguration_GCMMessage_Action = this.GCMMessage_Action;
            context.MessageRequest_MessageConfiguration_GCMMessage_Body = this.GCMMessage_Body;
            context.MessageRequest_MessageConfiguration_GCMMessage_CollapseKey = this.GCMMessage_CollapseKey;
            if (this.GCMMessage_Data != null)
            {
                context.MessageRequest_MessageConfiguration_GCMMessage_Data = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.GCMMessage_Data.Keys)
                {
                    context.MessageRequest_MessageConfiguration_GCMMessage_Data.Add((String)hashKey, (String)(this.GCMMessage_Data[hashKey]));
                }
            }
            context.MessageRequest_MessageConfiguration_GCMMessage_IconReference = this.GCMMessage_IconReference;
            context.MessageRequest_MessageConfiguration_GCMMessage_ImageIconUrl = this.GCMMessage_ImageIconUrl;
            context.MessageRequest_MessageConfiguration_GCMMessage_ImageUrl = this.GCMMessage_ImageUrl;
            context.MessageRequest_MessageConfiguration_GCMMessage_Priority = this.GCMMessage_Priority;
            context.MessageRequest_MessageConfiguration_GCMMessage_RawContent = this.GCMMessage_RawContent;
            context.MessageRequest_MessageConfiguration_GCMMessage_RestrictedPackageName = this.GCMMessage_RestrictedPackageName;
            if (ParameterWasBound("GCMMessage_SilentPush"))
                context.MessageRequest_MessageConfiguration_GCMMessage_SilentPush = this.GCMMessage_SilentPush;
            context.MessageRequest_MessageConfiguration_GCMMessage_SmallImageIconUrl = this.GCMMessage_SmallImageIconUrl;
            context.MessageRequest_MessageConfiguration_GCMMessage_Sound = this.GCMMessage_Sound;
            if (this.GCMMessage_Substitution != null)
            {
                context.MessageRequest_MessageConfiguration_GCMMessage_Substitutions = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.GCMMessage_Substitution.Keys)
                {
                    object hashValue = this.GCMMessage_Substitution[hashKey];
                    if (hashValue == null)
                    {
                        context.MessageRequest_MessageConfiguration_GCMMessage_Substitutions.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((String)s);
                    }
                    context.MessageRequest_MessageConfiguration_GCMMessage_Substitutions.Add((String)hashKey, valueSet);
                }
            }
            if (ParameterWasBound("GCMMessage_TimeToLive"))
                context.MessageRequest_MessageConfiguration_GCMMessage_TimeToLive = this.GCMMessage_TimeToLive;
            context.MessageRequest_MessageConfiguration_GCMMessage_Title = this.GCMMessage_Title;
            context.MessageRequest_MessageConfiguration_GCMMessage_Url = this.GCMMessage_Url;
            context.MessageRequest_MessageConfiguration_SMSMessage_Body = this.SMSMessage_Body;
            context.MessageRequest_MessageConfiguration_SMSMessage_Keyword = this.SMSMessage_Keyword;
            context.MessageRequest_MessageConfiguration_SMSMessage_MessageType = this.SMSMessage_MessageType;
            context.MessageRequest_MessageConfiguration_SMSMessage_OriginationNumber = this.SMSMessage_OriginationNumber;
            context.MessageRequest_MessageConfiguration_SMSMessage_SenderId = this.SMSMessage_SenderId;
            if (this.SMSMessage_Substitution != null)
            {
                context.MessageRequest_MessageConfiguration_SMSMessage_Substitutions = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.SMSMessage_Substitution.Keys)
                {
                    object hashValue = this.SMSMessage_Substitution[hashKey];
                    if (hashValue == null)
                    {
                        context.MessageRequest_MessageConfiguration_SMSMessage_Substitutions.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((String)s);
                    }
                    context.MessageRequest_MessageConfiguration_SMSMessage_Substitutions.Add((String)hashKey, valueSet);
                }
            }
            context.MessageRequest_MessageConfiguration_VoiceMessage_Body = this.VoiceMessage_Body;
            context.MessageRequest_MessageConfiguration_VoiceMessage_LanguageCode = this.VoiceMessage_LanguageCode;
            context.MessageRequest_MessageConfiguration_VoiceMessage_OriginationNumber = this.VoiceMessage_OriginationNumber;
            if (this.VoiceMessage_Substitution != null)
            {
                context.MessageRequest_MessageConfiguration_VoiceMessage_Substitutions = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.VoiceMessage_Substitution.Keys)
                {
                    object hashValue = this.VoiceMessage_Substitution[hashKey];
                    if (hashValue == null)
                    {
                        context.MessageRequest_MessageConfiguration_VoiceMessage_Substitutions.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((String)s);
                    }
                    context.MessageRequest_MessageConfiguration_VoiceMessage_Substitutions.Add((String)hashKey, valueSet);
                }
            }
            context.MessageRequest_MessageConfiguration_VoiceMessage_VoiceId = this.VoiceMessage_VoiceId;
            context.MessageRequest_TraceId = this.MessageRequest_TraceId;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _MessageRequest_MessageConfiguration_EmailMessage_RawEmail_DataStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.Pinpoint.Model.SendMessagesRequest();
                
                if (cmdletContext.ApplicationId != null)
                {
                    request.ApplicationId = cmdletContext.ApplicationId;
                }
                
                 // populate MessageRequest
                bool requestMessageRequestIsNull = true;
                request.MessageRequest = new Amazon.Pinpoint.Model.MessageRequest();
                Dictionary<System.String, Amazon.Pinpoint.Model.AddressConfiguration> requestMessageRequest_messageRequest_Address = null;
                if (cmdletContext.MessageRequest_Addresses != null)
                {
                    requestMessageRequest_messageRequest_Address = cmdletContext.MessageRequest_Addresses;
                }
                if (requestMessageRequest_messageRequest_Address != null)
                {
                    request.MessageRequest.Addresses = requestMessageRequest_messageRequest_Address;
                    requestMessageRequestIsNull = false;
                }
                Dictionary<System.String, System.String> requestMessageRequest_messageRequest_Context = null;
                if (cmdletContext.MessageRequest_Context != null)
                {
                    requestMessageRequest_messageRequest_Context = cmdletContext.MessageRequest_Context;
                }
                if (requestMessageRequest_messageRequest_Context != null)
                {
                    request.MessageRequest.Context = requestMessageRequest_messageRequest_Context;
                    requestMessageRequestIsNull = false;
                }
                Dictionary<System.String, Amazon.Pinpoint.Model.EndpointSendConfiguration> requestMessageRequest_messageRequest_Endpoint = null;
                if (cmdletContext.MessageRequest_Endpoints != null)
                {
                    requestMessageRequest_messageRequest_Endpoint = cmdletContext.MessageRequest_Endpoints;
                }
                if (requestMessageRequest_messageRequest_Endpoint != null)
                {
                    request.MessageRequest.Endpoints = requestMessageRequest_messageRequest_Endpoint;
                    requestMessageRequestIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_TraceId = null;
                if (cmdletContext.MessageRequest_TraceId != null)
                {
                    requestMessageRequest_messageRequest_TraceId = cmdletContext.MessageRequest_TraceId;
                }
                if (requestMessageRequest_messageRequest_TraceId != null)
                {
                    request.MessageRequest.TraceId = requestMessageRequest_messageRequest_TraceId;
                    requestMessageRequestIsNull = false;
                }
                Amazon.Pinpoint.Model.DirectMessageConfiguration requestMessageRequest_messageRequest_MessageConfiguration = null;
                
                 // populate MessageConfiguration
                bool requestMessageRequest_messageRequest_MessageConfigurationIsNull = true;
                requestMessageRequest_messageRequest_MessageConfiguration = new Amazon.Pinpoint.Model.DirectMessageConfiguration();
                Amazon.Pinpoint.Model.DefaultMessage requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultMessage = null;
                
                 // populate DefaultMessage
                bool requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultMessageIsNull = true;
                requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultMessage = new Amazon.Pinpoint.Model.DefaultMessage();
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultMessage_defaultMessage_Body = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_DefaultMessage_Body != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultMessage_defaultMessage_Body = cmdletContext.MessageRequest_MessageConfiguration_DefaultMessage_Body;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultMessage_defaultMessage_Body != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultMessage.Body = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultMessage_defaultMessage_Body;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultMessageIsNull = false;
                }
                Dictionary<System.String, List<System.String>> requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultMessage_defaultMessage_Substitution = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_DefaultMessage_Substitutions != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultMessage_defaultMessage_Substitution = cmdletContext.MessageRequest_MessageConfiguration_DefaultMessage_Substitutions;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultMessage_defaultMessage_Substitution != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultMessage.Substitutions = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultMessage_defaultMessage_Substitution;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultMessageIsNull = false;
                }
                 // determine if requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultMessage should be set to null
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultMessageIsNull)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultMessage = null;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultMessage != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration.DefaultMessage = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultMessage;
                    requestMessageRequest_messageRequest_MessageConfigurationIsNull = false;
                }
                Amazon.Pinpoint.Model.VoiceMessage requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage = null;
                
                 // populate VoiceMessage
                bool requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessageIsNull = true;
                requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage = new Amazon.Pinpoint.Model.VoiceMessage();
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage_voiceMessage_Body = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_VoiceMessage_Body != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage_voiceMessage_Body = cmdletContext.MessageRequest_MessageConfiguration_VoiceMessage_Body;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage_voiceMessage_Body != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage.Body = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage_voiceMessage_Body;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage_voiceMessage_LanguageCode = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_VoiceMessage_LanguageCode != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage_voiceMessage_LanguageCode = cmdletContext.MessageRequest_MessageConfiguration_VoiceMessage_LanguageCode;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage_voiceMessage_LanguageCode != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage.LanguageCode = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage_voiceMessage_LanguageCode;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage_voiceMessage_OriginationNumber = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_VoiceMessage_OriginationNumber != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage_voiceMessage_OriginationNumber = cmdletContext.MessageRequest_MessageConfiguration_VoiceMessage_OriginationNumber;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage_voiceMessage_OriginationNumber != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage.OriginationNumber = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage_voiceMessage_OriginationNumber;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessageIsNull = false;
                }
                Dictionary<System.String, List<System.String>> requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage_voiceMessage_Substitution = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_VoiceMessage_Substitutions != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage_voiceMessage_Substitution = cmdletContext.MessageRequest_MessageConfiguration_VoiceMessage_Substitutions;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage_voiceMessage_Substitution != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage.Substitutions = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage_voiceMessage_Substitution;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage_voiceMessage_VoiceId = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_VoiceMessage_VoiceId != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage_voiceMessage_VoiceId = cmdletContext.MessageRequest_MessageConfiguration_VoiceMessage_VoiceId;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage_voiceMessage_VoiceId != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage.VoiceId = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage_voiceMessage_VoiceId;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessageIsNull = false;
                }
                 // determine if requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage should be set to null
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessageIsNull)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage = null;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration.VoiceMessage = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage;
                    requestMessageRequest_messageRequest_MessageConfigurationIsNull = false;
                }
                Amazon.Pinpoint.Model.SMSMessage requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage = null;
                
                 // populate SMSMessage
                bool requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessageIsNull = true;
                requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage = new Amazon.Pinpoint.Model.SMSMessage();
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_Body = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_SMSMessage_Body != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_Body = cmdletContext.MessageRequest_MessageConfiguration_SMSMessage_Body;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_Body != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage.Body = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_Body;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_Keyword = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_SMSMessage_Keyword != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_Keyword = cmdletContext.MessageRequest_MessageConfiguration_SMSMessage_Keyword;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_Keyword != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage.Keyword = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_Keyword;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessageIsNull = false;
                }
                Amazon.Pinpoint.MessageType requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_MessageType = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_SMSMessage_MessageType != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_MessageType = cmdletContext.MessageRequest_MessageConfiguration_SMSMessage_MessageType;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_MessageType != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage.MessageType = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_MessageType;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_OriginationNumber = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_SMSMessage_OriginationNumber != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_OriginationNumber = cmdletContext.MessageRequest_MessageConfiguration_SMSMessage_OriginationNumber;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_OriginationNumber != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage.OriginationNumber = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_OriginationNumber;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_SenderId = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_SMSMessage_SenderId != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_SenderId = cmdletContext.MessageRequest_MessageConfiguration_SMSMessage_SenderId;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_SenderId != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage.SenderId = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_SenderId;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessageIsNull = false;
                }
                Dictionary<System.String, List<System.String>> requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_Substitution = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_SMSMessage_Substitutions != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_Substitution = cmdletContext.MessageRequest_MessageConfiguration_SMSMessage_Substitutions;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_Substitution != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage.Substitutions = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_Substitution;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessageIsNull = false;
                }
                 // determine if requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage should be set to null
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessageIsNull)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage = null;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration.SMSMessage = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage;
                    requestMessageRequest_messageRequest_MessageConfigurationIsNull = false;
                }
                Amazon.Pinpoint.Model.DefaultPushNotificationMessage requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage = null;
                
                 // populate DefaultPushNotificationMessage
                bool requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessageIsNull = true;
                requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage = new Amazon.Pinpoint.Model.DefaultPushNotificationMessage();
                Amazon.Pinpoint.Action requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Action = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Action != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Action = cmdletContext.MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Action;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Action != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage.Action = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Action;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Body = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Body != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Body = cmdletContext.MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Body;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Body != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage.Body = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Body;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessageIsNull = false;
                }
                Dictionary<System.String, System.String> requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Data = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Data != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Data = cmdletContext.MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Data;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Data != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage.Data = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Data;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessageIsNull = false;
                }
                System.Boolean? requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_SilentPush = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_SilentPush != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_SilentPush = cmdletContext.MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_SilentPush.Value;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_SilentPush != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage.SilentPush = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_SilentPush.Value;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessageIsNull = false;
                }
                Dictionary<System.String, List<System.String>> requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Substitution = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Substitutions != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Substitution = cmdletContext.MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Substitutions;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Substitution != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage.Substitutions = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Substitution;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Title = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Title != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Title = cmdletContext.MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Title;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Title != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage.Title = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Title;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Url = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Url != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Url = cmdletContext.MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Url;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Url != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage.Url = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Url;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessageIsNull = false;
                }
                 // determine if requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage should be set to null
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessageIsNull)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage = null;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration.DefaultPushNotificationMessage = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage;
                    requestMessageRequest_messageRequest_MessageConfigurationIsNull = false;
                }
                Amazon.Pinpoint.Model.EmailMessage requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage = null;
                
                 // populate EmailMessage
                bool requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessageIsNull = true;
                requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage = new Amazon.Pinpoint.Model.EmailMessage();
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_emailMessage_Body = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_EmailMessage_Body != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_emailMessage_Body = cmdletContext.MessageRequest_MessageConfiguration_EmailMessage_Body;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_emailMessage_Body != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage.Body = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_emailMessage_Body;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_emailMessage_FeedbackForwardingAddress = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_EmailMessage_FeedbackForwardingAddress != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_emailMessage_FeedbackForwardingAddress = cmdletContext.MessageRequest_MessageConfiguration_EmailMessage_FeedbackForwardingAddress;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_emailMessage_FeedbackForwardingAddress != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage.FeedbackForwardingAddress = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_emailMessage_FeedbackForwardingAddress;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_emailMessage_FromAddress = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_EmailMessage_FromAddress != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_emailMessage_FromAddress = cmdletContext.MessageRequest_MessageConfiguration_EmailMessage_FromAddress;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_emailMessage_FromAddress != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage.FromAddress = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_emailMessage_FromAddress;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessageIsNull = false;
                }
                List<System.String> requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_emailMessage_ReplyToAddress = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_EmailMessage_ReplyToAddresses != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_emailMessage_ReplyToAddress = cmdletContext.MessageRequest_MessageConfiguration_EmailMessage_ReplyToAddresses;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_emailMessage_ReplyToAddress != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage.ReplyToAddresses = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_emailMessage_ReplyToAddress;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessageIsNull = false;
                }
                Dictionary<System.String, List<System.String>> requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_emailMessage_Substitution = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_EmailMessage_Substitutions != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_emailMessage_Substitution = cmdletContext.MessageRequest_MessageConfiguration_EmailMessage_Substitutions;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_emailMessage_Substitution != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage.Substitutions = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_emailMessage_Substitution;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessageIsNull = false;
                }
                Amazon.Pinpoint.Model.RawEmail requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_RawEmail = null;
                
                 // populate RawEmail
                bool requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_RawEmailIsNull = true;
                requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_RawEmail = new Amazon.Pinpoint.Model.RawEmail();
                System.IO.MemoryStream requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_RawEmail_rawEmail_Data = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_EmailMessage_RawEmail_Data != null)
                {
                    _MessageRequest_MessageConfiguration_EmailMessage_RawEmail_DataStream = new System.IO.MemoryStream(cmdletContext.MessageRequest_MessageConfiguration_EmailMessage_RawEmail_Data);
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_RawEmail_rawEmail_Data = _MessageRequest_MessageConfiguration_EmailMessage_RawEmail_DataStream;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_RawEmail_rawEmail_Data != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_RawEmail.Data = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_RawEmail_rawEmail_Data;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_RawEmailIsNull = false;
                }
                 // determine if requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_RawEmail should be set to null
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_RawEmailIsNull)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_RawEmail = null;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_RawEmail != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage.RawEmail = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_RawEmail;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessageIsNull = false;
                }
                Amazon.Pinpoint.Model.SimpleEmail requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail = null;
                
                 // populate SimpleEmail
                bool requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmailIsNull = true;
                requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail = new Amazon.Pinpoint.Model.SimpleEmail();
                Amazon.Pinpoint.Model.SimpleEmailPart requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_HtmlPart = null;
                
                 // populate HtmlPart
                bool requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_HtmlPartIsNull = true;
                requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_HtmlPart = new Amazon.Pinpoint.Model.SimpleEmailPart();
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_HtmlPart_htmlPart_Charset = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_EmailMessage_SimpleEmail_HtmlPart_Charset != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_HtmlPart_htmlPart_Charset = cmdletContext.MessageRequest_MessageConfiguration_EmailMessage_SimpleEmail_HtmlPart_Charset;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_HtmlPart_htmlPart_Charset != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_HtmlPart.Charset = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_HtmlPart_htmlPart_Charset;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_HtmlPartIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_HtmlPart_htmlPart_Data = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_EmailMessage_SimpleEmail_HtmlPart_Data != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_HtmlPart_htmlPart_Data = cmdletContext.MessageRequest_MessageConfiguration_EmailMessage_SimpleEmail_HtmlPart_Data;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_HtmlPart_htmlPart_Data != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_HtmlPart.Data = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_HtmlPart_htmlPart_Data;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_HtmlPartIsNull = false;
                }
                 // determine if requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_HtmlPart should be set to null
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_HtmlPartIsNull)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_HtmlPart = null;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_HtmlPart != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail.HtmlPart = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_HtmlPart;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmailIsNull = false;
                }
                Amazon.Pinpoint.Model.SimpleEmailPart requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_Subject = null;
                
                 // populate Subject
                bool requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_SubjectIsNull = true;
                requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_Subject = new Amazon.Pinpoint.Model.SimpleEmailPart();
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_Subject_subject_Charset = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_EmailMessage_SimpleEmail_Subject_Charset != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_Subject_subject_Charset = cmdletContext.MessageRequest_MessageConfiguration_EmailMessage_SimpleEmail_Subject_Charset;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_Subject_subject_Charset != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_Subject.Charset = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_Subject_subject_Charset;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_SubjectIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_Subject_subject_Data = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_EmailMessage_SimpleEmail_Subject_Data != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_Subject_subject_Data = cmdletContext.MessageRequest_MessageConfiguration_EmailMessage_SimpleEmail_Subject_Data;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_Subject_subject_Data != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_Subject.Data = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_Subject_subject_Data;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_SubjectIsNull = false;
                }
                 // determine if requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_Subject should be set to null
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_SubjectIsNull)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_Subject = null;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_Subject != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail.Subject = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_Subject;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmailIsNull = false;
                }
                Amazon.Pinpoint.Model.SimpleEmailPart requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_TextPart = null;
                
                 // populate TextPart
                bool requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_TextPartIsNull = true;
                requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_TextPart = new Amazon.Pinpoint.Model.SimpleEmailPart();
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_TextPart_textPart_Charset = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_EmailMessage_SimpleEmail_TextPart_Charset != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_TextPart_textPart_Charset = cmdletContext.MessageRequest_MessageConfiguration_EmailMessage_SimpleEmail_TextPart_Charset;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_TextPart_textPart_Charset != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_TextPart.Charset = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_TextPart_textPart_Charset;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_TextPartIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_TextPart_textPart_Data = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_EmailMessage_SimpleEmail_TextPart_Data != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_TextPart_textPart_Data = cmdletContext.MessageRequest_MessageConfiguration_EmailMessage_SimpleEmail_TextPart_Data;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_TextPart_textPart_Data != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_TextPart.Data = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_TextPart_textPart_Data;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_TextPartIsNull = false;
                }
                 // determine if requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_TextPart should be set to null
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_TextPartIsNull)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_TextPart = null;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_TextPart != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail.TextPart = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_TextPart;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmailIsNull = false;
                }
                 // determine if requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail should be set to null
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmailIsNull)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail = null;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage.SimpleEmail = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessageIsNull = false;
                }
                 // determine if requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage should be set to null
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessageIsNull)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage = null;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration.EmailMessage = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage;
                    requestMessageRequest_messageRequest_MessageConfigurationIsNull = false;
                }
                Amazon.Pinpoint.Model.BaiduMessage requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage = null;
                
                 // populate BaiduMessage
                bool requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessageIsNull = true;
                requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage = new Amazon.Pinpoint.Model.BaiduMessage();
                Amazon.Pinpoint.Action requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Action = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_BaiduMessage_Action != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Action = cmdletContext.MessageRequest_MessageConfiguration_BaiduMessage_Action;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Action != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage.Action = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Action;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Body = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_BaiduMessage_Body != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Body = cmdletContext.MessageRequest_MessageConfiguration_BaiduMessage_Body;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Body != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage.Body = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Body;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessageIsNull = false;
                }
                Dictionary<System.String, System.String> requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Data = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_BaiduMessage_Data != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Data = cmdletContext.MessageRequest_MessageConfiguration_BaiduMessage_Data;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Data != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage.Data = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Data;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_IconReference = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_BaiduMessage_IconReference != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_IconReference = cmdletContext.MessageRequest_MessageConfiguration_BaiduMessage_IconReference;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_IconReference != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage.IconReference = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_IconReference;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_ImageIconUrl = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_BaiduMessage_ImageIconUrl != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_ImageIconUrl = cmdletContext.MessageRequest_MessageConfiguration_BaiduMessage_ImageIconUrl;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_ImageIconUrl != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage.ImageIconUrl = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_ImageIconUrl;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_ImageUrl = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_BaiduMessage_ImageUrl != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_ImageUrl = cmdletContext.MessageRequest_MessageConfiguration_BaiduMessage_ImageUrl;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_ImageUrl != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage.ImageUrl = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_ImageUrl;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_RawContent = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_BaiduMessage_RawContent != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_RawContent = cmdletContext.MessageRequest_MessageConfiguration_BaiduMessage_RawContent;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_RawContent != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage.RawContent = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_RawContent;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessageIsNull = false;
                }
                System.Boolean? requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_SilentPush = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_BaiduMessage_SilentPush != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_SilentPush = cmdletContext.MessageRequest_MessageConfiguration_BaiduMessage_SilentPush.Value;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_SilentPush != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage.SilentPush = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_SilentPush.Value;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_SmallImageIconUrl = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_BaiduMessage_SmallImageIconUrl != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_SmallImageIconUrl = cmdletContext.MessageRequest_MessageConfiguration_BaiduMessage_SmallImageIconUrl;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_SmallImageIconUrl != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage.SmallImageIconUrl = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_SmallImageIconUrl;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Sound = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_BaiduMessage_Sound != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Sound = cmdletContext.MessageRequest_MessageConfiguration_BaiduMessage_Sound;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Sound != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage.Sound = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Sound;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessageIsNull = false;
                }
                Dictionary<System.String, List<System.String>> requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Substitution = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_BaiduMessage_Substitutions != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Substitution = cmdletContext.MessageRequest_MessageConfiguration_BaiduMessage_Substitutions;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Substitution != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage.Substitutions = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Substitution;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessageIsNull = false;
                }
                System.Int32? requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_TimeToLive = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_BaiduMessage_TimeToLive != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_TimeToLive = cmdletContext.MessageRequest_MessageConfiguration_BaiduMessage_TimeToLive.Value;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_TimeToLive != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage.TimeToLive = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_TimeToLive.Value;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Title = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_BaiduMessage_Title != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Title = cmdletContext.MessageRequest_MessageConfiguration_BaiduMessage_Title;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Title != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage.Title = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Title;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Url = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_BaiduMessage_Url != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Url = cmdletContext.MessageRequest_MessageConfiguration_BaiduMessage_Url;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Url != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage.Url = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Url;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessageIsNull = false;
                }
                 // determine if requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage should be set to null
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessageIsNull)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage = null;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration.BaiduMessage = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage;
                    requestMessageRequest_messageRequest_MessageConfigurationIsNull = false;
                }
                Amazon.Pinpoint.Model.ADMMessage requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage = null;
                
                 // populate ADMMessage
                bool requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessageIsNull = true;
                requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage = new Amazon.Pinpoint.Model.ADMMessage();
                Amazon.Pinpoint.Action requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Action = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_ADMMessage_Action != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Action = cmdletContext.MessageRequest_MessageConfiguration_ADMMessage_Action;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Action != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage.Action = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Action;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Body = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_ADMMessage_Body != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Body = cmdletContext.MessageRequest_MessageConfiguration_ADMMessage_Body;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Body != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage.Body = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Body;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_ConsolidationKey = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_ADMMessage_ConsolidationKey != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_ConsolidationKey = cmdletContext.MessageRequest_MessageConfiguration_ADMMessage_ConsolidationKey;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_ConsolidationKey != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage.ConsolidationKey = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_ConsolidationKey;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessageIsNull = false;
                }
                Dictionary<System.String, System.String> requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Data = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_ADMMessage_Data != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Data = cmdletContext.MessageRequest_MessageConfiguration_ADMMessage_Data;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Data != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage.Data = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Data;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_ExpiresAfter = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_ADMMessage_ExpiresAfter != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_ExpiresAfter = cmdletContext.MessageRequest_MessageConfiguration_ADMMessage_ExpiresAfter;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_ExpiresAfter != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage.ExpiresAfter = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_ExpiresAfter;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_IconReference = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_ADMMessage_IconReference != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_IconReference = cmdletContext.MessageRequest_MessageConfiguration_ADMMessage_IconReference;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_IconReference != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage.IconReference = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_IconReference;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_ImageIconUrl = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_ADMMessage_ImageIconUrl != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_ImageIconUrl = cmdletContext.MessageRequest_MessageConfiguration_ADMMessage_ImageIconUrl;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_ImageIconUrl != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage.ImageIconUrl = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_ImageIconUrl;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_ImageUrl = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_ADMMessage_ImageUrl != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_ImageUrl = cmdletContext.MessageRequest_MessageConfiguration_ADMMessage_ImageUrl;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_ImageUrl != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage.ImageUrl = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_ImageUrl;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_MD5 = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_ADMMessage_MD5 != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_MD5 = cmdletContext.MessageRequest_MessageConfiguration_ADMMessage_MD5;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_MD5 != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage.MD5 = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_MD5;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_RawContent = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_ADMMessage_RawContent != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_RawContent = cmdletContext.MessageRequest_MessageConfiguration_ADMMessage_RawContent;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_RawContent != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage.RawContent = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_RawContent;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessageIsNull = false;
                }
                System.Boolean? requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_SilentPush = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_ADMMessage_SilentPush != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_SilentPush = cmdletContext.MessageRequest_MessageConfiguration_ADMMessage_SilentPush.Value;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_SilentPush != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage.SilentPush = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_SilentPush.Value;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_SmallImageIconUrl = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_ADMMessage_SmallImageIconUrl != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_SmallImageIconUrl = cmdletContext.MessageRequest_MessageConfiguration_ADMMessage_SmallImageIconUrl;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_SmallImageIconUrl != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage.SmallImageIconUrl = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_SmallImageIconUrl;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Sound = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_ADMMessage_Sound != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Sound = cmdletContext.MessageRequest_MessageConfiguration_ADMMessage_Sound;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Sound != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage.Sound = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Sound;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessageIsNull = false;
                }
                Dictionary<System.String, List<System.String>> requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Substitution = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_ADMMessage_Substitutions != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Substitution = cmdletContext.MessageRequest_MessageConfiguration_ADMMessage_Substitutions;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Substitution != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage.Substitutions = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Substitution;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Title = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_ADMMessage_Title != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Title = cmdletContext.MessageRequest_MessageConfiguration_ADMMessage_Title;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Title != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage.Title = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Title;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Url = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_ADMMessage_Url != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Url = cmdletContext.MessageRequest_MessageConfiguration_ADMMessage_Url;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Url != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage.Url = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Url;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessageIsNull = false;
                }
                 // determine if requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage should be set to null
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessageIsNull)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage = null;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration.ADMMessage = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage;
                    requestMessageRequest_messageRequest_MessageConfigurationIsNull = false;
                }
                Amazon.Pinpoint.Model.APNSMessage requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage = null;
                
                 // populate APNSMessage
                bool requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessageIsNull = true;
                requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage = new Amazon.Pinpoint.Model.APNSMessage();
                Amazon.Pinpoint.Action requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Action = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_APNSMessage_Action != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Action = cmdletContext.MessageRequest_MessageConfiguration_APNSMessage_Action;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Action != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage.Action = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Action;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessageIsNull = false;
                }
                System.Int32? requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Badge = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_APNSMessage_Badge != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Badge = cmdletContext.MessageRequest_MessageConfiguration_APNSMessage_Badge.Value;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Badge != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage.Badge = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Badge.Value;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Body = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_APNSMessage_Body != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Body = cmdletContext.MessageRequest_MessageConfiguration_APNSMessage_Body;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Body != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage.Body = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Body;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Category = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_APNSMessage_Category != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Category = cmdletContext.MessageRequest_MessageConfiguration_APNSMessage_Category;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Category != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage.Category = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Category;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_CollapseId = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_APNSMessage_CollapseId != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_CollapseId = cmdletContext.MessageRequest_MessageConfiguration_APNSMessage_CollapseId;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_CollapseId != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage.CollapseId = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_CollapseId;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessageIsNull = false;
                }
                Dictionary<System.String, System.String> requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Data = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_APNSMessage_Data != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Data = cmdletContext.MessageRequest_MessageConfiguration_APNSMessage_Data;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Data != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage.Data = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Data;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_MediaUrl = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_APNSMessage_MediaUrl != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_MediaUrl = cmdletContext.MessageRequest_MessageConfiguration_APNSMessage_MediaUrl;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_MediaUrl != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage.MediaUrl = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_MediaUrl;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_PreferredAuthenticationMethod = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_APNSMessage_PreferredAuthenticationMethod != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_PreferredAuthenticationMethod = cmdletContext.MessageRequest_MessageConfiguration_APNSMessage_PreferredAuthenticationMethod;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_PreferredAuthenticationMethod != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage.PreferredAuthenticationMethod = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_PreferredAuthenticationMethod;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Priority = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_APNSMessage_Priority != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Priority = cmdletContext.MessageRequest_MessageConfiguration_APNSMessage_Priority;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Priority != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage.Priority = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Priority;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_RawContent = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_APNSMessage_RawContent != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_RawContent = cmdletContext.MessageRequest_MessageConfiguration_APNSMessage_RawContent;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_RawContent != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage.RawContent = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_RawContent;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessageIsNull = false;
                }
                System.Boolean? requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_SilentPush = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_APNSMessage_SilentPush != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_SilentPush = cmdletContext.MessageRequest_MessageConfiguration_APNSMessage_SilentPush.Value;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_SilentPush != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage.SilentPush = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_SilentPush.Value;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Sound = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_APNSMessage_Sound != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Sound = cmdletContext.MessageRequest_MessageConfiguration_APNSMessage_Sound;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Sound != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage.Sound = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Sound;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessageIsNull = false;
                }
                Dictionary<System.String, List<System.String>> requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Substitution = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_APNSMessage_Substitutions != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Substitution = cmdletContext.MessageRequest_MessageConfiguration_APNSMessage_Substitutions;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Substitution != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage.Substitutions = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Substitution;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_ThreadId = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_APNSMessage_ThreadId != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_ThreadId = cmdletContext.MessageRequest_MessageConfiguration_APNSMessage_ThreadId;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_ThreadId != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage.ThreadId = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_ThreadId;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessageIsNull = false;
                }
                System.Int32? requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_TimeToLive = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_APNSMessage_TimeToLive != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_TimeToLive = cmdletContext.MessageRequest_MessageConfiguration_APNSMessage_TimeToLive.Value;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_TimeToLive != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage.TimeToLive = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_TimeToLive.Value;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Title = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_APNSMessage_Title != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Title = cmdletContext.MessageRequest_MessageConfiguration_APNSMessage_Title;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Title != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage.Title = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Title;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Url = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_APNSMessage_Url != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Url = cmdletContext.MessageRequest_MessageConfiguration_APNSMessage_Url;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Url != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage.Url = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Url;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessageIsNull = false;
                }
                 // determine if requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage should be set to null
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessageIsNull)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage = null;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration.APNSMessage = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage;
                    requestMessageRequest_messageRequest_MessageConfigurationIsNull = false;
                }
                Amazon.Pinpoint.Model.GCMMessage requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage = null;
                
                 // populate GCMMessage
                bool requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessageIsNull = true;
                requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage = new Amazon.Pinpoint.Model.GCMMessage();
                Amazon.Pinpoint.Action requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Action = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_GCMMessage_Action != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Action = cmdletContext.MessageRequest_MessageConfiguration_GCMMessage_Action;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Action != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage.Action = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Action;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Body = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_GCMMessage_Body != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Body = cmdletContext.MessageRequest_MessageConfiguration_GCMMessage_Body;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Body != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage.Body = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Body;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_CollapseKey = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_GCMMessage_CollapseKey != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_CollapseKey = cmdletContext.MessageRequest_MessageConfiguration_GCMMessage_CollapseKey;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_CollapseKey != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage.CollapseKey = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_CollapseKey;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessageIsNull = false;
                }
                Dictionary<System.String, System.String> requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Data = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_GCMMessage_Data != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Data = cmdletContext.MessageRequest_MessageConfiguration_GCMMessage_Data;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Data != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage.Data = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Data;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_IconReference = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_GCMMessage_IconReference != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_IconReference = cmdletContext.MessageRequest_MessageConfiguration_GCMMessage_IconReference;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_IconReference != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage.IconReference = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_IconReference;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageIconUrl = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_GCMMessage_ImageIconUrl != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageIconUrl = cmdletContext.MessageRequest_MessageConfiguration_GCMMessage_ImageIconUrl;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageIconUrl != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage.ImageIconUrl = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageIconUrl;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageUrl = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_GCMMessage_ImageUrl != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageUrl = cmdletContext.MessageRequest_MessageConfiguration_GCMMessage_ImageUrl;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageUrl != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage.ImageUrl = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageUrl;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Priority = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_GCMMessage_Priority != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Priority = cmdletContext.MessageRequest_MessageConfiguration_GCMMessage_Priority;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Priority != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage.Priority = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Priority;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_RawContent = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_GCMMessage_RawContent != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_RawContent = cmdletContext.MessageRequest_MessageConfiguration_GCMMessage_RawContent;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_RawContent != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage.RawContent = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_RawContent;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_RestrictedPackageName = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_GCMMessage_RestrictedPackageName != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_RestrictedPackageName = cmdletContext.MessageRequest_MessageConfiguration_GCMMessage_RestrictedPackageName;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_RestrictedPackageName != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage.RestrictedPackageName = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_RestrictedPackageName;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessageIsNull = false;
                }
                System.Boolean? requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_SilentPush = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_GCMMessage_SilentPush != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_SilentPush = cmdletContext.MessageRequest_MessageConfiguration_GCMMessage_SilentPush.Value;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_SilentPush != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage.SilentPush = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_SilentPush.Value;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_SmallImageIconUrl = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_GCMMessage_SmallImageIconUrl != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_SmallImageIconUrl = cmdletContext.MessageRequest_MessageConfiguration_GCMMessage_SmallImageIconUrl;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_SmallImageIconUrl != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage.SmallImageIconUrl = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_SmallImageIconUrl;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Sound = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_GCMMessage_Sound != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Sound = cmdletContext.MessageRequest_MessageConfiguration_GCMMessage_Sound;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Sound != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage.Sound = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Sound;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessageIsNull = false;
                }
                Dictionary<System.String, List<System.String>> requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Substitution = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_GCMMessage_Substitutions != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Substitution = cmdletContext.MessageRequest_MessageConfiguration_GCMMessage_Substitutions;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Substitution != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage.Substitutions = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Substitution;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessageIsNull = false;
                }
                System.Int32? requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_TimeToLive = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_GCMMessage_TimeToLive != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_TimeToLive = cmdletContext.MessageRequest_MessageConfiguration_GCMMessage_TimeToLive.Value;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_TimeToLive != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage.TimeToLive = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_TimeToLive.Value;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Title = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_GCMMessage_Title != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Title = cmdletContext.MessageRequest_MessageConfiguration_GCMMessage_Title;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Title != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage.Title = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Title;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Url = null;
                if (cmdletContext.MessageRequest_MessageConfiguration_GCMMessage_Url != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Url = cmdletContext.MessageRequest_MessageConfiguration_GCMMessage_Url;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Url != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage.Url = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Url;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessageIsNull = false;
                }
                 // determine if requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage should be set to null
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessageIsNull)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage = null;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration.GCMMessage = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage;
                    requestMessageRequest_messageRequest_MessageConfigurationIsNull = false;
                }
                 // determine if requestMessageRequest_messageRequest_MessageConfiguration should be set to null
                if (requestMessageRequest_messageRequest_MessageConfigurationIsNull)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration = null;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration != null)
                {
                    request.MessageRequest.MessageConfiguration = requestMessageRequest_messageRequest_MessageConfiguration;
                    requestMessageRequestIsNull = false;
                }
                 // determine if request.MessageRequest should be set to null
                if (requestMessageRequestIsNull)
                {
                    request.MessageRequest = null;
                }
                
                CmdletOutput output;
                
                // issue call
                var client = Client ?? CreateClient(context.Credentials, context.Region);
                try
                {
                    var response = CallAWSServiceOperation(client, request);
                    Dictionary<string, object> notes = null;
                    object pipelineOutput = response.MessageResponse;
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
            finally
            {
                if( _MessageRequest_MessageConfiguration_EmailMessage_RawEmail_DataStream != null)
                {
                    _MessageRequest_MessageConfiguration_EmailMessage_RawEmail_DataStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Pinpoint.Model.SendMessagesResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.SendMessagesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "SendMessages");
            try
            {
                #if DESKTOP
                return client.SendMessages(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.SendMessagesAsync(request);
                return task.Result;
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
            public Dictionary<System.String, Amazon.Pinpoint.Model.AddressConfiguration> MessageRequest_Addresses { get; set; }
            public Dictionary<System.String, System.String> MessageRequest_Context { get; set; }
            public Dictionary<System.String, Amazon.Pinpoint.Model.EndpointSendConfiguration> MessageRequest_Endpoints { get; set; }
            public Amazon.Pinpoint.Action MessageRequest_MessageConfiguration_ADMMessage_Action { get; set; }
            public System.String MessageRequest_MessageConfiguration_ADMMessage_Body { get; set; }
            public System.String MessageRequest_MessageConfiguration_ADMMessage_ConsolidationKey { get; set; }
            public Dictionary<System.String, System.String> MessageRequest_MessageConfiguration_ADMMessage_Data { get; set; }
            public System.String MessageRequest_MessageConfiguration_ADMMessage_ExpiresAfter { get; set; }
            public System.String MessageRequest_MessageConfiguration_ADMMessage_IconReference { get; set; }
            public System.String MessageRequest_MessageConfiguration_ADMMessage_ImageIconUrl { get; set; }
            public System.String MessageRequest_MessageConfiguration_ADMMessage_ImageUrl { get; set; }
            public System.String MessageRequest_MessageConfiguration_ADMMessage_MD5 { get; set; }
            public System.String MessageRequest_MessageConfiguration_ADMMessage_RawContent { get; set; }
            public System.Boolean? MessageRequest_MessageConfiguration_ADMMessage_SilentPush { get; set; }
            public System.String MessageRequest_MessageConfiguration_ADMMessage_SmallImageIconUrl { get; set; }
            public System.String MessageRequest_MessageConfiguration_ADMMessage_Sound { get; set; }
            public Dictionary<System.String, List<System.String>> MessageRequest_MessageConfiguration_ADMMessage_Substitutions { get; set; }
            public System.String MessageRequest_MessageConfiguration_ADMMessage_Title { get; set; }
            public System.String MessageRequest_MessageConfiguration_ADMMessage_Url { get; set; }
            public Amazon.Pinpoint.Action MessageRequest_MessageConfiguration_APNSMessage_Action { get; set; }
            public System.Int32? MessageRequest_MessageConfiguration_APNSMessage_Badge { get; set; }
            public System.String MessageRequest_MessageConfiguration_APNSMessage_Body { get; set; }
            public System.String MessageRequest_MessageConfiguration_APNSMessage_Category { get; set; }
            public System.String MessageRequest_MessageConfiguration_APNSMessage_CollapseId { get; set; }
            public Dictionary<System.String, System.String> MessageRequest_MessageConfiguration_APNSMessage_Data { get; set; }
            public System.String MessageRequest_MessageConfiguration_APNSMessage_MediaUrl { get; set; }
            public System.String MessageRequest_MessageConfiguration_APNSMessage_PreferredAuthenticationMethod { get; set; }
            public System.String MessageRequest_MessageConfiguration_APNSMessage_Priority { get; set; }
            public System.String MessageRequest_MessageConfiguration_APNSMessage_RawContent { get; set; }
            public System.Boolean? MessageRequest_MessageConfiguration_APNSMessage_SilentPush { get; set; }
            public System.String MessageRequest_MessageConfiguration_APNSMessage_Sound { get; set; }
            public Dictionary<System.String, List<System.String>> MessageRequest_MessageConfiguration_APNSMessage_Substitutions { get; set; }
            public System.String MessageRequest_MessageConfiguration_APNSMessage_ThreadId { get; set; }
            public System.Int32? MessageRequest_MessageConfiguration_APNSMessage_TimeToLive { get; set; }
            public System.String MessageRequest_MessageConfiguration_APNSMessage_Title { get; set; }
            public System.String MessageRequest_MessageConfiguration_APNSMessage_Url { get; set; }
            public Amazon.Pinpoint.Action MessageRequest_MessageConfiguration_BaiduMessage_Action { get; set; }
            public System.String MessageRequest_MessageConfiguration_BaiduMessage_Body { get; set; }
            public Dictionary<System.String, System.String> MessageRequest_MessageConfiguration_BaiduMessage_Data { get; set; }
            public System.String MessageRequest_MessageConfiguration_BaiduMessage_IconReference { get; set; }
            public System.String MessageRequest_MessageConfiguration_BaiduMessage_ImageIconUrl { get; set; }
            public System.String MessageRequest_MessageConfiguration_BaiduMessage_ImageUrl { get; set; }
            public System.String MessageRequest_MessageConfiguration_BaiduMessage_RawContent { get; set; }
            public System.Boolean? MessageRequest_MessageConfiguration_BaiduMessage_SilentPush { get; set; }
            public System.String MessageRequest_MessageConfiguration_BaiduMessage_SmallImageIconUrl { get; set; }
            public System.String MessageRequest_MessageConfiguration_BaiduMessage_Sound { get; set; }
            public Dictionary<System.String, List<System.String>> MessageRequest_MessageConfiguration_BaiduMessage_Substitutions { get; set; }
            public System.Int32? MessageRequest_MessageConfiguration_BaiduMessage_TimeToLive { get; set; }
            public System.String MessageRequest_MessageConfiguration_BaiduMessage_Title { get; set; }
            public System.String MessageRequest_MessageConfiguration_BaiduMessage_Url { get; set; }
            public System.String MessageRequest_MessageConfiguration_DefaultMessage_Body { get; set; }
            public Dictionary<System.String, List<System.String>> MessageRequest_MessageConfiguration_DefaultMessage_Substitutions { get; set; }
            public Amazon.Pinpoint.Action MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Action { get; set; }
            public System.String MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Body { get; set; }
            public Dictionary<System.String, System.String> MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Data { get; set; }
            public System.Boolean? MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_SilentPush { get; set; }
            public Dictionary<System.String, List<System.String>> MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Substitutions { get; set; }
            public System.String MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Title { get; set; }
            public System.String MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Url { get; set; }
            public System.String MessageRequest_MessageConfiguration_EmailMessage_Body { get; set; }
            public System.String MessageRequest_MessageConfiguration_EmailMessage_FeedbackForwardingAddress { get; set; }
            public System.String MessageRequest_MessageConfiguration_EmailMessage_FromAddress { get; set; }
            public byte[] MessageRequest_MessageConfiguration_EmailMessage_RawEmail_Data { get; set; }
            public List<System.String> MessageRequest_MessageConfiguration_EmailMessage_ReplyToAddresses { get; set; }
            public System.String MessageRequest_MessageConfiguration_EmailMessage_SimpleEmail_HtmlPart_Charset { get; set; }
            public System.String MessageRequest_MessageConfiguration_EmailMessage_SimpleEmail_HtmlPart_Data { get; set; }
            public System.String MessageRequest_MessageConfiguration_EmailMessage_SimpleEmail_Subject_Charset { get; set; }
            public System.String MessageRequest_MessageConfiguration_EmailMessage_SimpleEmail_Subject_Data { get; set; }
            public System.String MessageRequest_MessageConfiguration_EmailMessage_SimpleEmail_TextPart_Charset { get; set; }
            public System.String MessageRequest_MessageConfiguration_EmailMessage_SimpleEmail_TextPart_Data { get; set; }
            public Dictionary<System.String, List<System.String>> MessageRequest_MessageConfiguration_EmailMessage_Substitutions { get; set; }
            public Amazon.Pinpoint.Action MessageRequest_MessageConfiguration_GCMMessage_Action { get; set; }
            public System.String MessageRequest_MessageConfiguration_GCMMessage_Body { get; set; }
            public System.String MessageRequest_MessageConfiguration_GCMMessage_CollapseKey { get; set; }
            public Dictionary<System.String, System.String> MessageRequest_MessageConfiguration_GCMMessage_Data { get; set; }
            public System.String MessageRequest_MessageConfiguration_GCMMessage_IconReference { get; set; }
            public System.String MessageRequest_MessageConfiguration_GCMMessage_ImageIconUrl { get; set; }
            public System.String MessageRequest_MessageConfiguration_GCMMessage_ImageUrl { get; set; }
            public System.String MessageRequest_MessageConfiguration_GCMMessage_Priority { get; set; }
            public System.String MessageRequest_MessageConfiguration_GCMMessage_RawContent { get; set; }
            public System.String MessageRequest_MessageConfiguration_GCMMessage_RestrictedPackageName { get; set; }
            public System.Boolean? MessageRequest_MessageConfiguration_GCMMessage_SilentPush { get; set; }
            public System.String MessageRequest_MessageConfiguration_GCMMessage_SmallImageIconUrl { get; set; }
            public System.String MessageRequest_MessageConfiguration_GCMMessage_Sound { get; set; }
            public Dictionary<System.String, List<System.String>> MessageRequest_MessageConfiguration_GCMMessage_Substitutions { get; set; }
            public System.Int32? MessageRequest_MessageConfiguration_GCMMessage_TimeToLive { get; set; }
            public System.String MessageRequest_MessageConfiguration_GCMMessage_Title { get; set; }
            public System.String MessageRequest_MessageConfiguration_GCMMessage_Url { get; set; }
            public System.String MessageRequest_MessageConfiguration_SMSMessage_Body { get; set; }
            public System.String MessageRequest_MessageConfiguration_SMSMessage_Keyword { get; set; }
            public Amazon.Pinpoint.MessageType MessageRequest_MessageConfiguration_SMSMessage_MessageType { get; set; }
            public System.String MessageRequest_MessageConfiguration_SMSMessage_OriginationNumber { get; set; }
            public System.String MessageRequest_MessageConfiguration_SMSMessage_SenderId { get; set; }
            public Dictionary<System.String, List<System.String>> MessageRequest_MessageConfiguration_SMSMessage_Substitutions { get; set; }
            public System.String MessageRequest_MessageConfiguration_VoiceMessage_Body { get; set; }
            public System.String MessageRequest_MessageConfiguration_VoiceMessage_LanguageCode { get; set; }
            public System.String MessageRequest_MessageConfiguration_VoiceMessage_OriginationNumber { get; set; }
            public Dictionary<System.String, List<System.String>> MessageRequest_MessageConfiguration_VoiceMessage_Substitutions { get; set; }
            public System.String MessageRequest_MessageConfiguration_VoiceMessage_VoiceId { get; set; }
            public System.String MessageRequest_TraceId { get; set; }
        }
        
    }
}
