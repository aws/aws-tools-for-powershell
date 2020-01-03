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
    /// Creates and sends a direct message.
    /// </summary>
    [Cmdlet("Send", "PINMessage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.MessageResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint SendMessages API operation.", Operation = new[] {"SendMessages"}, SelectReturnType = typeof(Amazon.Pinpoint.Model.SendMessagesResponse))]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.MessageResponse or Amazon.Pinpoint.Model.SendMessagesResponse",
        "This cmdlet returns an Amazon.Pinpoint.Model.MessageResponse object.",
        "The service call response (type Amazon.Pinpoint.Model.SendMessagesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SendPINMessageCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
        #region Parameter ADMMessage_Action
        /// <summary>
        /// <para>
        /// <para>The action to occur if the recipient taps the push notification. Valid values are:</para><ul><li><para>OPEN_APP - Your app opens or it becomes the foreground app if it was sent to the background.
        /// This is the default action.</para></li><li><para>DEEP_LINK - Your app opens and displays a designated user interface in the app. This
        /// action uses the deep-linking features of the Android platform.</para></li><li><para>URL - The default mobile browser on the recipient's device opens and loads the web
        /// page at a URL that you specify.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_ADMMessage_Action")]
        [AWSConstantClassSource("Amazon.Pinpoint.Action")]
        public Amazon.Pinpoint.Action ADMMessage_Action { get; set; }
        #endregion
        
        #region Parameter APNSMessage_Action
        /// <summary>
        /// <para>
        /// <para>The action to occur if the recipient taps the push notification. Valid values are:</para><ul><li><para>OPEN_APP - Your app opens or it becomes the foreground app if it was sent to the background.
        /// This is the default action.</para></li><li><para>DEEP_LINK - Your app opens and displays a designated user interface in the app. This
        /// setting uses the deep-linking features of the iOS platform.</para></li><li><para>URL - The default mobile browser on the recipient's device opens and loads the web
        /// page at a URL that you specify.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_APNSMessage_Action")]
        [AWSConstantClassSource("Amazon.Pinpoint.Action")]
        public Amazon.Pinpoint.Action APNSMessage_Action { get; set; }
        #endregion
        
        #region Parameter BaiduMessage_Action
        /// <summary>
        /// <para>
        /// <para>The action to occur if the recipient taps the push notification. Valid values are:</para><ul><li><para>OPEN_APP - Your app opens or it becomes the foreground app if it was sent to the background.
        /// This is the default action.</para></li><li><para>DEEP_LINK - Your app opens and displays a designated user interface in the app. This
        /// action uses the deep-linking features of the Android platform.</para></li><li><para>URL - The default mobile browser on the recipient's device opens and loads the web
        /// page at a URL that you specify.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_BaiduMessage_Action")]
        [AWSConstantClassSource("Amazon.Pinpoint.Action")]
        public Amazon.Pinpoint.Action BaiduMessage_Action { get; set; }
        #endregion
        
        #region Parameter DefaultPushNotificationMessage_Action
        /// <summary>
        /// <para>
        /// <para>The default action to occur if a recipient taps the push notification. Valid values
        /// are:</para><ul><li><para>OPEN_APP - Your app opens or it becomes the foreground app if it was sent to the background.
        /// This is the default action.</para></li><li><para>DEEP_LINK - Your app opens and displays a designated user interface in the app. This
        /// setting uses the deep-linking features of the iOS and Android platforms.</para></li><li><para>URL - The default mobile browser on the recipient's device opens and loads the web
        /// page at a URL that you specify.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Action")]
        [AWSConstantClassSource("Amazon.Pinpoint.Action")]
        public Amazon.Pinpoint.Action DefaultPushNotificationMessage_Action { get; set; }
        #endregion
        
        #region Parameter GCMMessage_Action
        /// <summary>
        /// <para>
        /// <para>The action to occur if the recipient taps the push notification. Valid values are:</para><ul><li><para>OPEN_APP - Your app opens or it becomes the foreground app if it was sent to the background.
        /// This is the default action.</para></li><li><para>DEEP_LINK - Your app opens and displays a designated user interface in the app. This
        /// action uses the deep-linking features of the Android platform.</para></li><li><para>URL - The default mobile browser on the recipient's device opens and loads the web
        /// page at a URL that you specify.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_GCMMessage_Action")]
        [AWSConstantClassSource("Amazon.Pinpoint.Action")]
        public Amazon.Pinpoint.Action GCMMessage_Action { get; set; }
        #endregion
        
        #region Parameter MessageRequest_Address
        /// <summary>
        /// <para>
        /// <para>A map of key-value pairs, where each key is an address and each value is an AddressConfiguration
        /// object. An address can be a push notification token, a phone number, or an email address.
        /// You can use an AddressConfiguration object to tailor the message for an address by
        /// specifying settings such as content overrides and message variables.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_Addresses")]
        public System.Collections.Hashtable MessageRequest_Address { get; set; }
        #endregion
        
        #region Parameter APNSMessage_APNSPushType
        /// <summary>
        /// <para>
        /// <para>The type of push notification to send. Valid values are:</para><ul><li><para>alert - For a standard notification that's displayed on recipients' devices and prompts
        /// a recipient to interact with the notification.</para></li><li><para>background - For a silent notification that delivers content in the background and
        /// isn't displayed on recipients' devices.</para></li><li><para>complication - For a notification that contains update information for an app’s complication
        /// timeline.</para></li><li><para>fileprovider - For a notification that signals changes to a File Provider extension.</para></li><li><para>mdm - For a notification that tells managed devices to contact the MDM server.</para></li><li><para>voip - For a notification that provides information about an incoming VoIP call.</para></li></ul><para>Amazon Pinpoint specifies this value in the apns-push-type request header when it
        /// sends the notification message to APNs. If you don't specify a value for this property,
        /// Amazon Pinpoint sets the value to alert or background automatically, based on the
        /// value that you specify for the SilentPush or RawContent property of the message.</para><para>For more information about the apns-push-type request header, see <a href="https://developer.apple.com/documentation/usernotifications/setting_up_a_remote_notification_server/sending_notification_requests_to_apns">Sending
        /// Notification Requests to APNs</a> on the Apple Developer website.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_APNSMessage_APNSPushType")]
        public System.String APNSMessage_APNSPushType { get; set; }
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
        
        #region Parameter APNSMessage_Badge
        /// <summary>
        /// <para>
        /// <para>The key that indicates whether and how to modify the badge of your app's icon when
        /// the recipient receives the push notification. If this key isn't included in the dictionary,
        /// the badge doesn't change. To remove the badge, set this value to 0.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_APNSMessage_Badge")]
        public System.Int32? APNSMessage_Badge { get; set; }
        #endregion
        
        #region Parameter ADMMessage_Body
        /// <summary>
        /// <para>
        /// <para>The body of the notification message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_ADMMessage_Body")]
        public System.String ADMMessage_Body { get; set; }
        #endregion
        
        #region Parameter APNSMessage_Body
        /// <summary>
        /// <para>
        /// <para>The body of the notification message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_APNSMessage_Body")]
        public System.String APNSMessage_Body { get; set; }
        #endregion
        
        #region Parameter BaiduMessage_Body
        /// <summary>
        /// <para>
        /// <para>The body of the notification message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_BaiduMessage_Body")]
        public System.String BaiduMessage_Body { get; set; }
        #endregion
        
        #region Parameter DefaultMessage_Body
        /// <summary>
        /// <para>
        /// <para>The default body of the message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_DefaultMessage_Body")]
        public System.String DefaultMessage_Body { get; set; }
        #endregion
        
        #region Parameter DefaultPushNotificationMessage_Body
        /// <summary>
        /// <para>
        /// <para>The default body of the notification message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Body")]
        public System.String DefaultPushNotificationMessage_Body { get; set; }
        #endregion
        
        #region Parameter EmailMessage_Body
        /// <summary>
        /// <para>
        /// <para>The body of the email message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_EmailMessage_Body")]
        public System.String EmailMessage_Body { get; set; }
        #endregion
        
        #region Parameter GCMMessage_Body
        /// <summary>
        /// <para>
        /// <para>The body of the notification message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_GCMMessage_Body")]
        public System.String GCMMessage_Body { get; set; }
        #endregion
        
        #region Parameter SMSMessage_Body
        /// <summary>
        /// <para>
        /// <para>The body of the SMS message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_SMSMessage_Body")]
        public System.String SMSMessage_Body { get; set; }
        #endregion
        
        #region Parameter VoiceMessage_Body
        /// <summary>
        /// <para>
        /// <para>The text of the script to use for the voice message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_VoiceMessage_Body")]
        public System.String VoiceMessage_Body { get; set; }
        #endregion
        
        #region Parameter APNSMessage_Category
        /// <summary>
        /// <para>
        /// <para>The key that indicates the notification type for the push notification. This key is
        /// a value that's defined by the identifier property of one of your app's registered
        /// categories.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_APNSMessage_Category")]
        public System.String APNSMessage_Category { get; set; }
        #endregion
        
        #region Parameter HtmlPart_Charset
        /// <summary>
        /// <para>
        /// <para>The applicable character set for the message content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_EmailMessage_SimpleEmail_HtmlPart_Charset")]
        public System.String HtmlPart_Charset { get; set; }
        #endregion
        
        #region Parameter Subject_Charset
        /// <summary>
        /// <para>
        /// <para>The applicable character set for the message content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_EmailMessage_SimpleEmail_Subject_Charset")]
        public System.String Subject_Charset { get; set; }
        #endregion
        
        #region Parameter TextPart_Charset
        /// <summary>
        /// <para>
        /// <para>The applicable character set for the message content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_EmailMessage_SimpleEmail_TextPart_Charset")]
        public System.String TextPart_Charset { get; set; }
        #endregion
        
        #region Parameter APNSMessage_CollapseId
        /// <summary>
        /// <para>
        /// <para>An arbitrary identifier that, if assigned to multiple messages, APNs uses to coalesce
        /// the messages into a single push notification instead of delivering each message individually.
        /// This value can't exceed 64 bytes.</para><para>Amazon Pinpoint specifies this value in the apns-collapse-id request header when it
        /// sends the notification message to APNs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_APNSMessage_CollapseId")]
        public System.String APNSMessage_CollapseId { get; set; }
        #endregion
        
        #region Parameter GCMMessage_CollapseKey
        /// <summary>
        /// <para>
        /// <para>An arbitrary string that identifies a group of messages that can be collapsed to ensure
        /// that only the last message is sent when delivery can resume. This helps avoid sending
        /// too many instances of the same messages when the recipient's device comes online again
        /// or becomes active.</para><para>Amazon Pinpoint specifies this value in the Firebase Cloud Messaging (FCM) collapse_key
        /// parameter when it sends the notification message to FCM.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_GCMMessage_CollapseKey")]
        public System.String GCMMessage_CollapseKey { get; set; }
        #endregion
        
        #region Parameter ADMMessage_ConsolidationKey
        /// <summary>
        /// <para>
        /// <para>An arbitrary string that indicates that multiple messages are logically the same and
        /// that Amazon Device Messaging (ADM) can drop previously enqueued messages in favor
        /// of this message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_ADMMessage_ConsolidationKey")]
        public System.String ADMMessage_ConsolidationKey { get; set; }
        #endregion
        
        #region Parameter MessageRequest_Context
        /// <summary>
        /// <para>
        /// <para>A map of custom attributes to attach to the message. For a push notification, this
        /// payload is added to the data.pinpoint object. For an email or text message, this payload
        /// is added to email/SMS delivery receipt event attributes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable MessageRequest_Context { get; set; }
        #endregion
        
        #region Parameter ADMMessage_Data
        /// <summary>
        /// <para>
        /// <para>The JSON data payload to use for the push notification, if the notification is a silent
        /// push notification. This payload is added to the data.pinpoint.jsonBody object of the
        /// notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_ADMMessage_Data")]
        public System.Collections.Hashtable ADMMessage_Data { get; set; }
        #endregion
        
        #region Parameter APNSMessage_Data
        /// <summary>
        /// <para>
        /// <para>The JSON payload to use for a silent push notification. This payload is added to the
        /// data.pinpoint.jsonBody object of the notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_APNSMessage_Data")]
        public System.Collections.Hashtable APNSMessage_Data { get; set; }
        #endregion
        
        #region Parameter BaiduMessage_Data
        /// <summary>
        /// <para>
        /// <para>The JSON data payload to use for the push notification, if the notification is a silent
        /// push notification. This payload is added to the data.pinpoint.jsonBody object of the
        /// notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_BaiduMessage_Data")]
        public System.Collections.Hashtable BaiduMessage_Data { get; set; }
        #endregion
        
        #region Parameter DefaultPushNotificationMessage_Data
        /// <summary>
        /// <para>
        /// <para>The JSON data payload to use for the default push notification, if the notification
        /// is a silent push notification. This payload is added to the data.pinpoint.jsonBody
        /// object of the notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Data")]
        public System.Collections.Hashtable DefaultPushNotificationMessage_Data { get; set; }
        #endregion
        
        #region Parameter RawEmail_Data
        /// <summary>
        /// <para>
        /// <para>The email message, represented as a raw MIME message. The entire message must be base64
        /// encoded.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_EmailMessage_RawEmail_Data")]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] RawEmail_Data { get; set; }
        #endregion
        
        #region Parameter HtmlPart_Data
        /// <summary>
        /// <para>
        /// <para>The textual data of the message content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_EmailMessage_SimpleEmail_HtmlPart_Data")]
        public System.String HtmlPart_Data { get; set; }
        #endregion
        
        #region Parameter Subject_Data
        /// <summary>
        /// <para>
        /// <para>The textual data of the message content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_EmailMessage_SimpleEmail_Subject_Data")]
        public System.String Subject_Data { get; set; }
        #endregion
        
        #region Parameter TextPart_Data
        /// <summary>
        /// <para>
        /// <para>The textual data of the message content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_EmailMessage_SimpleEmail_TextPart_Data")]
        public System.String TextPart_Data { get; set; }
        #endregion
        
        #region Parameter GCMMessage_Data
        /// <summary>
        /// <para>
        /// <para>The JSON data payload to use for the push notification, if the notification is a silent
        /// push notification. This payload is added to the data.pinpoint.jsonBody object of the
        /// notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_GCMMessage_Data")]
        public System.Collections.Hashtable GCMMessage_Data { get; set; }
        #endregion
        
        #region Parameter MessageRequest_Endpoint
        /// <summary>
        /// <para>
        /// <para>A map of key-value pairs, where each key is an endpoint ID and each value is an EndpointSendConfiguration
        /// object. You can use an EndpointSendConfiguration object to tailor the message for
        /// an endpoint by specifying settings such as content overrides and message variables.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_Endpoints")]
        public System.Collections.Hashtable MessageRequest_Endpoint { get; set; }
        #endregion
        
        #region Parameter ADMMessage_ExpiresAfter
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, that ADM should store the message if the recipient's
        /// device is offline. Amazon Pinpoint specifies this value in the expiresAfter parameter
        /// when it sends the notification message to ADM.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_ADMMessage_ExpiresAfter")]
        public System.String ADMMessage_ExpiresAfter { get; set; }
        #endregion
        
        #region Parameter EmailMessage_FeedbackForwardingAddress
        /// <summary>
        /// <para>
        /// <para>The email address to forward bounces and complaints to, if feedback forwarding is
        /// enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_EmailMessage_FeedbackForwardingAddress")]
        public System.String EmailMessage_FeedbackForwardingAddress { get; set; }
        #endregion
        
        #region Parameter EmailMessage_FromAddress
        /// <summary>
        /// <para>
        /// <para>The verified email address to send the email message from. The default value is the
        /// FromAddress specified for the email channel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_EmailMessage_FromAddress")]
        public System.String EmailMessage_FromAddress { get; set; }
        #endregion
        
        #region Parameter ADMMessage_IconReference
        /// <summary>
        /// <para>
        /// <para>The icon image name of the asset saved in your app.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_ADMMessage_IconReference")]
        public System.String ADMMessage_IconReference { get; set; }
        #endregion
        
        #region Parameter BaiduMessage_IconReference
        /// <summary>
        /// <para>
        /// <para>The icon image name of the asset saved in your app.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_BaiduMessage_IconReference")]
        public System.String BaiduMessage_IconReference { get; set; }
        #endregion
        
        #region Parameter GCMMessage_IconReference
        /// <summary>
        /// <para>
        /// <para>The icon image name of the asset saved in your app.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_GCMMessage_IconReference")]
        public System.String GCMMessage_IconReference { get; set; }
        #endregion
        
        #region Parameter ADMMessage_ImageIconUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the large icon image to display in the content view of the push notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_ADMMessage_ImageIconUrl")]
        public System.String ADMMessage_ImageIconUrl { get; set; }
        #endregion
        
        #region Parameter BaiduMessage_ImageIconUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the large icon image to display in the content view of the push notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_BaiduMessage_ImageIconUrl")]
        public System.String BaiduMessage_ImageIconUrl { get; set; }
        #endregion
        
        #region Parameter GCMMessage_ImageIconUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the large icon image to display in the content view of the push notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_GCMMessage_ImageIconUrl")]
        public System.String GCMMessage_ImageIconUrl { get; set; }
        #endregion
        
        #region Parameter ADMMessage_ImageUrl
        /// <summary>
        /// <para>
        /// <para>The URL of an image to display in the push notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_ADMMessage_ImageUrl")]
        public System.String ADMMessage_ImageUrl { get; set; }
        #endregion
        
        #region Parameter BaiduMessage_ImageUrl
        /// <summary>
        /// <para>
        /// <para>The URL of an image to display in the push notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_BaiduMessage_ImageUrl")]
        public System.String BaiduMessage_ImageUrl { get; set; }
        #endregion
        
        #region Parameter GCMMessage_ImageUrl
        /// <summary>
        /// <para>
        /// <para>The URL of an image to display in the push notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_GCMMessage_ImageUrl")]
        public System.String GCMMessage_ImageUrl { get; set; }
        #endregion
        
        #region Parameter SMSMessage_Keyword
        /// <summary>
        /// <para>
        /// <para>The SMS program name that you provided to AWS Support when you requested your dedicated
        /// number.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_SMSMessage_Keyword")]
        public System.String SMSMessage_Keyword { get; set; }
        #endregion
        
        #region Parameter VoiceMessage_LanguageCode
        /// <summary>
        /// <para>
        /// <para>The code for the language to use when synthesizing the text of the message script.
        /// For a list of supported languages and the code for each one, see the <a href="https://docs.aws.amazon.com/polly/latest/dg/what-is.html">Amazon
        /// Polly Developer Guide</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_VoiceMessage_LanguageCode")]
        public System.String VoiceMessage_LanguageCode { get; set; }
        #endregion
        
        #region Parameter ADMMessage_MD5
        /// <summary>
        /// <para>
        /// <para>The base64-encoded, MD5 checksum of the value specified by the Data property. ADM
        /// uses the MD5 value to verify the integrity of the data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_ADMMessage_MD5")]
        public System.String ADMMessage_MD5 { get; set; }
        #endregion
        
        #region Parameter APNSMessage_MediaUrl
        /// <summary>
        /// <para>
        /// <para>The URL of an image or video to display in the push notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_APNSMessage_MediaUrl")]
        public System.String APNSMessage_MediaUrl { get; set; }
        #endregion
        
        #region Parameter SMSMessage_MessageType
        /// <summary>
        /// <para>
        /// <para>The SMS message type. Valid values are: TRANSACTIONAL, the message is critical or
        /// time-sensitive, such as a one-time password that supports a customer transaction;
        /// and, PROMOTIONAL, the message is not critical or time-sensitive, such as a marketing
        /// message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_SMSMessage_MessageType")]
        [AWSConstantClassSource("Amazon.Pinpoint.MessageType")]
        public Amazon.Pinpoint.MessageType SMSMessage_MessageType { get; set; }
        #endregion
        
        #region Parameter EmailTemplate_Name
        /// <summary>
        /// <para>
        /// <para>The name of the message template to use for the message. If specified, this value
        /// must match the name of an existing message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_TemplateConfiguration_EmailTemplate_Name")]
        public System.String EmailTemplate_Name { get; set; }
        #endregion
        
        #region Parameter PushTemplate_Name
        /// <summary>
        /// <para>
        /// <para>The name of the message template to use for the message. If specified, this value
        /// must match the name of an existing message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_TemplateConfiguration_PushTemplate_Name")]
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
        [Alias("MessageRequest_TemplateConfiguration_SMSTemplate_Name")]
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
        [Alias("MessageRequest_TemplateConfiguration_VoiceTemplate_Name")]
        public System.String VoiceTemplate_Name { get; set; }
        #endregion
        
        #region Parameter SMSMessage_OriginationNumber
        /// <summary>
        /// <para>
        /// <para>The number to send the SMS message from. This value should be one of the dedicated
        /// long or short codes that's assigned to your AWS account. If you don't specify a long
        /// or short code, Amazon Pinpoint assigns a random long code to the SMS message and sends
        /// the message from that code.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_SMSMessage_OriginationNumber")]
        public System.String SMSMessage_OriginationNumber { get; set; }
        #endregion
        
        #region Parameter VoiceMessage_OriginationNumber
        /// <summary>
        /// <para>
        /// <para>The long code to send the voice message from. This value should be one of the dedicated
        /// long codes that's assigned to your AWS account. Although it isn't required, we recommend
        /// that you specify the long code in E.164 format, for example +12065550100, to ensure
        /// prompt and accurate delivery of the message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_VoiceMessage_OriginationNumber")]
        public System.String VoiceMessage_OriginationNumber { get; set; }
        #endregion
        
        #region Parameter APNSMessage_PreferredAuthenticationMethod
        /// <summary>
        /// <para>
        /// <para>The authentication method that you want Amazon Pinpoint to use when authenticating
        /// with APNs, CERTIFICATE or TOKEN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_APNSMessage_PreferredAuthenticationMethod")]
        public System.String APNSMessage_PreferredAuthenticationMethod { get; set; }
        #endregion
        
        #region Parameter APNSMessage_Priority
        /// <summary>
        /// <para>
        /// <para>para&gt;5 - Low priority, the notification might be delayed, delivered as part of a group,
        /// or throttled.</para>
        /// /listitem&gt; <li><para>10 - High priority, the notification is sent immediately. This is the default value.
        /// A high priority notification should trigger an alert, play a sound, or badge your
        /// app's icon on the recipient's device.</para></li>/para&gt; 
        /// <para>Amazon Pinpoint specifies this value in the apns-priority request header when it sends
        /// the notification message to APNs.</para><para>The equivalent values for Firebase Cloud Messaging (FCM), formerly Google Cloud Messaging
        /// (GCM), are normal, for 5, and high, for 10. If you specify an FCM value for this property,
        /// Amazon Pinpoint accepts and converts the value to the corresponding APNs value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_APNSMessage_Priority")]
        public System.String APNSMessage_Priority { get; set; }
        #endregion
        
        #region Parameter GCMMessage_Priority
        /// <summary>
        /// <para>
        /// <para>para&gt;normal - The notification might be delayed. Delivery is optimized for battery
        /// usage on the recipient's device. Use this value unless immediate delivery is required.</para>
        /// /listitem&gt; <li><para>high - The notification is sent immediately and might wake a sleeping device.</para></li>/para&gt; 
        /// <para>Amazon Pinpoint specifies this value in the FCM priority parameter when it sends the
        /// notification message to FCM.</para><para>The equivalent values for Apple Push Notification service (APNs) are 5, for normal,
        /// and 10, for high. If you specify an APNs value for this property, Amazon Pinpoint
        /// accepts and converts the value to the corresponding FCM value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_GCMMessage_Priority")]
        public System.String GCMMessage_Priority { get; set; }
        #endregion
        
        #region Parameter ADMMessage_RawContent
        /// <summary>
        /// <para>
        /// <para>The raw, JSON-formatted string to use as the payload for the notification message.
        /// If specified, this value overrides all other content for the message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_ADMMessage_RawContent")]
        public System.String ADMMessage_RawContent { get; set; }
        #endregion
        
        #region Parameter APNSMessage_RawContent
        /// <summary>
        /// <para>
        /// <para>The raw, JSON-formatted string to use as the payload for the notification message.
        /// If specified, this value overrides all other content for the message.</para><note><para>If you specify the raw content of an APNs push notification, the message payload has
        /// to include the content-available key. The value of the content-available key has to
        /// be an integer, and can only be 0 or 1. If you're sending a standard notification,
        /// set the value of content-available to 0. If you're sending a silent (background) notification,
        /// set the value of content-available to 1. Additionally, silent notification payloads
        /// can't include the alert, badge, or sound keys. For more information, see <a href="https://developer.apple.com/documentation/usernotifications/setting_up_a_remote_notification_server/generating_a_remote_notification">Generating
        /// a Remote Notification</a> and <a href="https://developer.apple.com/documentation/usernotifications/setting_up_a_remote_notification_server/pushing_background_updates_to_your_app">Pushing
        /// Background Updates to Your App</a> on the Apple Developer website.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_APNSMessage_RawContent")]
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
        [Alias("MessageRequest_MessageConfiguration_BaiduMessage_RawContent")]
        public System.String BaiduMessage_RawContent { get; set; }
        #endregion
        
        #region Parameter GCMMessage_RawContent
        /// <summary>
        /// <para>
        /// <para>The raw, JSON-formatted string to use as the payload for the notification message.
        /// If specified, this value overrides all other content for the message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_GCMMessage_RawContent")]
        public System.String GCMMessage_RawContent { get; set; }
        #endregion
        
        #region Parameter EmailMessage_ReplyToAddress
        /// <summary>
        /// <para>
        /// <para>The reply-to email address(es) for the email message. If a recipient replies to the
        /// email, each reply-to address receives the reply.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_EmailMessage_ReplyToAddresses")]
        public System.String[] EmailMessage_ReplyToAddress { get; set; }
        #endregion
        
        #region Parameter GCMMessage_RestrictedPackageName
        /// <summary>
        /// <para>
        /// <para>The package name of the application where registration tokens must match in order
        /// for the recipient to receive the message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_GCMMessage_RestrictedPackageName")]
        public System.String GCMMessage_RestrictedPackageName { get; set; }
        #endregion
        
        #region Parameter SMSMessage_SenderId
        /// <summary>
        /// <para>
        /// <para>The sender ID to display as the sender of the message on a recipient's device. Support
        /// for sender IDs varies by country or region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_SMSMessage_SenderId")]
        public System.String SMSMessage_SenderId { get; set; }
        #endregion
        
        #region Parameter ADMMessage_SilentPush
        /// <summary>
        /// <para>
        /// <para>Specifies whether the notification is a silent push notification, which is a push
        /// notification that doesn't display on a recipient's device. Silent push notifications
        /// can be used for cases such as updating an app's configuration or supporting phone
        /// home functionality.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_ADMMessage_SilentPush")]
        public System.Boolean? ADMMessage_SilentPush { get; set; }
        #endregion
        
        #region Parameter APNSMessage_SilentPush
        /// <summary>
        /// <para>
        /// <para>Specifies whether the notification is a silent push notification. A silent (or background)
        /// push notification isn't displayed on recipients' devices. You can use silent push
        /// notifications to make small updates to your app, or to display messages in an in-app
        /// message center.</para><para>Amazon Pinpoint uses this property to determine the correct value for the apns-push-type
        /// request header when it sends the notification message to APNs. If you specify a value
        /// of true for this property, Amazon Pinpoint sets the value for the apns-push-type header
        /// field to background.</para><note><para>If you specify the raw content of an APNs push notification, the message payload has
        /// to include the content-available key. For silent (background) notifications, set the
        /// value of content-available to 1. Additionally, the message payload for a silent notification
        /// can't include the alert, badge, or sound keys. For more information, see <a href="https://developer.apple.com/documentation/usernotifications/setting_up_a_remote_notification_server/generating_a_remote_notification">Generating
        /// a Remote Notification</a> and <a href="https://developer.apple.com/documentation/usernotifications/setting_up_a_remote_notification_server/pushing_background_updates_to_your_app">Pushing
        /// Background Updates to Your App</a> on the Apple Developer website.</para><para>Apple has indicated that they will throttle "excessive" background notifications based
        /// on current traffic volumes. To prevent your notifications being throttled, Apple recommends
        /// that you send no more than 3 silent push notifications to each recipient per hour.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_APNSMessage_SilentPush")]
        public System.Boolean? APNSMessage_SilentPush { get; set; }
        #endregion
        
        #region Parameter BaiduMessage_SilentPush
        /// <summary>
        /// <para>
        /// <para>Specifies whether the notification is a silent push notification, which is a push
        /// notification that doesn't display on a recipient's device. Silent push notifications
        /// can be used for cases such as updating an app's configuration or supporting phone
        /// home functionality.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_BaiduMessage_SilentPush")]
        public System.Boolean? BaiduMessage_SilentPush { get; set; }
        #endregion
        
        #region Parameter DefaultPushNotificationMessage_SilentPush
        /// <summary>
        /// <para>
        /// <para>Specifies whether the default notification is a silent push notification, which is
        /// a push notification that doesn't display on a recipient's device. Silent push notifications
        /// can be used for cases such as updating an app's configuration or delivering messages
        /// to an in-app notification center.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_SilentPush")]
        public System.Boolean? DefaultPushNotificationMessage_SilentPush { get; set; }
        #endregion
        
        #region Parameter GCMMessage_SilentPush
        /// <summary>
        /// <para>
        /// <para>Specifies whether the notification is a silent push notification, which is a push
        /// notification that doesn't display on a recipient's device. Silent push notifications
        /// can be used for cases such as updating an app's configuration or supporting phone
        /// home functionality.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_GCMMessage_SilentPush")]
        public System.Boolean? GCMMessage_SilentPush { get; set; }
        #endregion
        
        #region Parameter ADMMessage_SmallImageIconUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the small icon image to display in the status bar and the content view
        /// of the push notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_ADMMessage_SmallImageIconUrl")]
        public System.String ADMMessage_SmallImageIconUrl { get; set; }
        #endregion
        
        #region Parameter BaiduMessage_SmallImageIconUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the small icon image to display in the status bar and the content view
        /// of the push notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_BaiduMessage_SmallImageIconUrl")]
        public System.String BaiduMessage_SmallImageIconUrl { get; set; }
        #endregion
        
        #region Parameter GCMMessage_SmallImageIconUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the small icon image to display in the status bar and the content view
        /// of the push notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_GCMMessage_SmallImageIconUrl")]
        public System.String GCMMessage_SmallImageIconUrl { get; set; }
        #endregion
        
        #region Parameter ADMMessage_Sound
        /// <summary>
        /// <para>
        /// <para>The sound to play when the recipient receives the push notification. You can use the
        /// default stream or specify the file name of a sound resource that's bundled in your
        /// app. On an Android platform, the sound file must reside in /res/raw/.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_ADMMessage_Sound")]
        public System.String ADMMessage_Sound { get; set; }
        #endregion
        
        #region Parameter APNSMessage_Sound
        /// <summary>
        /// <para>
        /// <para>The key for the sound to play when the recipient receives the push notification. The
        /// value for this key is the name of a sound file in your app's main bundle or the Library/Sounds
        /// folder in your app's data container. If the sound file can't be found or you specify
        /// default for the value, the system plays the default alert sound.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_APNSMessage_Sound")]
        public System.String APNSMessage_Sound { get; set; }
        #endregion
        
        #region Parameter BaiduMessage_Sound
        /// <summary>
        /// <para>
        /// <para>The sound to play when the recipient receives the push notification. You can use the
        /// default stream or specify the file name of a sound resource that's bundled in your
        /// app. On an Android platform, the sound file must reside in /res/raw/.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_BaiduMessage_Sound")]
        public System.String BaiduMessage_Sound { get; set; }
        #endregion
        
        #region Parameter GCMMessage_Sound
        /// <summary>
        /// <para>
        /// <para>The sound to play when the recipient receives the push notification. You can use the
        /// default stream or specify the file name of a sound resource that's bundled in your
        /// app. On an Android platform, the sound file must reside in /res/raw/.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_GCMMessage_Sound")]
        public System.String GCMMessage_Sound { get; set; }
        #endregion
        
        #region Parameter ADMMessage_Substitution
        /// <summary>
        /// <para>
        /// <para>The default message variables to use in the notification message. You can override
        /// the default variables with individual address variables.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_ADMMessage_Substitutions")]
        public System.Collections.Hashtable ADMMessage_Substitution { get; set; }
        #endregion
        
        #region Parameter APNSMessage_Substitution
        /// <summary>
        /// <para>
        /// <para>The default message variables to use in the notification message. You can override
        /// these default variables with individual address variables.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_APNSMessage_Substitutions")]
        public System.Collections.Hashtable APNSMessage_Substitution { get; set; }
        #endregion
        
        #region Parameter BaiduMessage_Substitution
        /// <summary>
        /// <para>
        /// <para>The default message variables to use in the notification message. You can override
        /// the default variables with individual address variables.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_BaiduMessage_Substitutions")]
        public System.Collections.Hashtable BaiduMessage_Substitution { get; set; }
        #endregion
        
        #region Parameter DefaultMessage_Substitution
        /// <summary>
        /// <para>
        /// <para>The default message variables to use in the message. You can override these default
        /// variables with individual address variables.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_DefaultMessage_Substitutions")]
        public System.Collections.Hashtable DefaultMessage_Substitution { get; set; }
        #endregion
        
        #region Parameter DefaultPushNotificationMessage_Substitution
        /// <summary>
        /// <para>
        /// <para>The default message variables to use in the notification message. You can override
        /// the default variables with individual address variables.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Substitutions")]
        public System.Collections.Hashtable DefaultPushNotificationMessage_Substitution { get; set; }
        #endregion
        
        #region Parameter EmailMessage_Substitution
        /// <summary>
        /// <para>
        /// <para>The default message variables to use in the email message. You can override the default
        /// variables with individual address variables.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_EmailMessage_Substitutions")]
        public System.Collections.Hashtable EmailMessage_Substitution { get; set; }
        #endregion
        
        #region Parameter GCMMessage_Substitution
        /// <summary>
        /// <para>
        /// <para>The default message variables to use in the notification message. You can override
        /// the default variables with individual address variables.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_GCMMessage_Substitutions")]
        public System.Collections.Hashtable GCMMessage_Substitution { get; set; }
        #endregion
        
        #region Parameter SMSMessage_Substitution
        /// <summary>
        /// <para>
        /// <para>The message variables to use in the SMS message. You can override the default variables
        /// with individual address variables.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_SMSMessage_Substitutions")]
        public System.Collections.Hashtable SMSMessage_Substitution { get; set; }
        #endregion
        
        #region Parameter VoiceMessage_Substitution
        /// <summary>
        /// <para>
        /// <para>The default message variables to use in the voice message. You can override the default
        /// variables with individual address variables.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_VoiceMessage_Substitutions")]
        public System.Collections.Hashtable VoiceMessage_Substitution { get; set; }
        #endregion
        
        #region Parameter APNSMessage_ThreadId
        /// <summary>
        /// <para>
        /// <para>The key that represents your app-specific identifier for grouping notifications. If
        /// you provide a Notification Content app extension, you can use this value to group
        /// your notifications together.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_APNSMessage_ThreadId")]
        public System.String APNSMessage_ThreadId { get; set; }
        #endregion
        
        #region Parameter APNSMessage_TimeToLive
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, that APNs should store and attempt to deliver the
        /// push notification, if the service is unable to deliver the notification the first
        /// time. If this value is 0, APNs treats the notification as if it expires immediately
        /// and the service doesn't store or try to deliver the notification again.</para><para>Amazon Pinpoint specifies this value in the apns-expiration request header when it
        /// sends the notification message to APNs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_APNSMessage_TimeToLive")]
        public System.Int32? APNSMessage_TimeToLive { get; set; }
        #endregion
        
        #region Parameter BaiduMessage_TimeToLive
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, that the Baidu Cloud Push service should store the
        /// message if the recipient's device is offline. The default value and maximum supported
        /// time is 604,800 seconds (7 days).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_BaiduMessage_TimeToLive")]
        public System.Int32? BaiduMessage_TimeToLive { get; set; }
        #endregion
        
        #region Parameter GCMMessage_TimeToLive
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, that FCM should store and attempt to deliver the push
        /// notification, if the service is unable to deliver the notification the first time.
        /// If you don't specify this value, FCM defaults to the maximum value, which is 2,419,200
        /// seconds (28 days).</para><para>Amazon Pinpoint specifies this value in the FCM time_to_live parameter when it sends
        /// the notification message to FCM.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_GCMMessage_TimeToLive")]
        public System.Int32? GCMMessage_TimeToLive { get; set; }
        #endregion
        
        #region Parameter ADMMessage_Title
        /// <summary>
        /// <para>
        /// <para>The title to display above the notification message on the recipient's device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_ADMMessage_Title")]
        public System.String ADMMessage_Title { get; set; }
        #endregion
        
        #region Parameter APNSMessage_Title
        /// <summary>
        /// <para>
        /// <para>The title to display above the notification message on the recipient's device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_APNSMessage_Title")]
        public System.String APNSMessage_Title { get; set; }
        #endregion
        
        #region Parameter BaiduMessage_Title
        /// <summary>
        /// <para>
        /// <para>The title to display above the notification message on the recipient's device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_BaiduMessage_Title")]
        public System.String BaiduMessage_Title { get; set; }
        #endregion
        
        #region Parameter DefaultPushNotificationMessage_Title
        /// <summary>
        /// <para>
        /// <para>The default title to display above the notification message on a recipient's device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Title")]
        public System.String DefaultPushNotificationMessage_Title { get; set; }
        #endregion
        
        #region Parameter GCMMessage_Title
        /// <summary>
        /// <para>
        /// <para>The title to display above the notification message on the recipient's device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_GCMMessage_Title")]
        public System.String GCMMessage_Title { get; set; }
        #endregion
        
        #region Parameter MessageRequest_TraceId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for tracing the message. This identifier is visible to message
        /// recipients.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MessageRequest_TraceId { get; set; }
        #endregion
        
        #region Parameter ADMMessage_Url
        /// <summary>
        /// <para>
        /// <para>The URL to open in the recipient's default mobile browser, if a recipient taps the
        /// push notification and the value of the Action property is URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_ADMMessage_Url")]
        public System.String ADMMessage_Url { get; set; }
        #endregion
        
        #region Parameter APNSMessage_Url
        /// <summary>
        /// <para>
        /// <para>The URL to open in the recipient's default mobile browser, if a recipient taps the
        /// push notification and the value of the Action property is URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_APNSMessage_Url")]
        public System.String APNSMessage_Url { get; set; }
        #endregion
        
        #region Parameter BaiduMessage_Url
        /// <summary>
        /// <para>
        /// <para>The URL to open in the recipient's default mobile browser, if a recipient taps the
        /// push notification and the value of the Action property is URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_BaiduMessage_Url")]
        public System.String BaiduMessage_Url { get; set; }
        #endregion
        
        #region Parameter DefaultPushNotificationMessage_Url
        /// <summary>
        /// <para>
        /// <para>The default URL to open in a recipient's default mobile browser, if a recipient taps
        /// the push notification and the value of the Action property is URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Url")]
        public System.String DefaultPushNotificationMessage_Url { get; set; }
        #endregion
        
        #region Parameter GCMMessage_Url
        /// <summary>
        /// <para>
        /// <para>The URL to open in the recipient's default mobile browser, if a recipient taps the
        /// push notification and the value of the Action property is URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_GCMMessage_Url")]
        public System.String GCMMessage_Url { get; set; }
        #endregion
        
        #region Parameter EmailTemplate_Version
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the version of the message template to use for the message.
        /// If specified, this value must match the identifier for an existing template version.
        /// To retrieve a list of versions and version identifiers for a template, use the <link linkend="templates-template-name-template-type-versions">Template Versions</link>
        /// resource.</para><para>If you don't specify a value for this property, Amazon Pinpoint uses the <i>active</i>
        /// version of the template. The <i>active</i> version is typically the version of a template
        /// that's been most recently reviewed and approved for use, depending on your workflow.
        /// It isn't necessarily the latest version of a template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_TemplateConfiguration_EmailTemplate_Version")]
        public System.String EmailTemplate_Version { get; set; }
        #endregion
        
        #region Parameter PushTemplate_Version
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the version of the message template to use for the message.
        /// If specified, this value must match the identifier for an existing template version.
        /// To retrieve a list of versions and version identifiers for a template, use the <link linkend="templates-template-name-template-type-versions">Template Versions</link>
        /// resource.</para><para>If you don't specify a value for this property, Amazon Pinpoint uses the <i>active</i>
        /// version of the template. The <i>active</i> version is typically the version of a template
        /// that's been most recently reviewed and approved for use, depending on your workflow.
        /// It isn't necessarily the latest version of a template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_TemplateConfiguration_PushTemplate_Version")]
        public System.String PushTemplate_Version { get; set; }
        #endregion
        
        #region Parameter SMSTemplate_Version
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the version of the message template to use for the message.
        /// If specified, this value must match the identifier for an existing template version.
        /// To retrieve a list of versions and version identifiers for a template, use the <link linkend="templates-template-name-template-type-versions">Template Versions</link>
        /// resource.</para><para>If you don't specify a value for this property, Amazon Pinpoint uses the <i>active</i>
        /// version of the template. The <i>active</i> version is typically the version of a template
        /// that's been most recently reviewed and approved for use, depending on your workflow.
        /// It isn't necessarily the latest version of a template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_TemplateConfiguration_SMSTemplate_Version")]
        public System.String SMSTemplate_Version { get; set; }
        #endregion
        
        #region Parameter VoiceTemplate_Version
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the version of the message template to use for the message.
        /// If specified, this value must match the identifier for an existing template version.
        /// To retrieve a list of versions and version identifiers for a template, use the <link linkend="templates-template-name-template-type-versions">Template Versions</link>
        /// resource.</para><para>If you don't specify a value for this property, Amazon Pinpoint uses the <i>active</i>
        /// version of the template. The <i>active</i> version is typically the version of a template
        /// that's been most recently reviewed and approved for use, depending on your workflow.
        /// It isn't necessarily the latest version of a template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_TemplateConfiguration_VoiceTemplate_Version")]
        public System.String VoiceTemplate_Version { get; set; }
        #endregion
        
        #region Parameter VoiceMessage_VoiceId
        /// <summary>
        /// <para>
        /// <para>The name of the voice to use when delivering the message. For a list of supported
        /// voices, see the <a href="https://docs.aws.amazon.com/polly/latest/dg/what-is.html">Amazon
        /// Polly Developer Guide</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageRequest_MessageConfiguration_VoiceMessage_VoiceId")]
        public System.String VoiceMessage_VoiceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MessageResponse'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Pinpoint.Model.SendMessagesResponse).
        /// Specifying the name of a property of type Amazon.Pinpoint.Model.SendMessagesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MessageResponse";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-PINMessage (SendMessages)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Pinpoint.Model.SendMessagesResponse, SendPINMessageCmdlet>(Select) ??
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
            if (this.MessageRequest_Address != null)
            {
                context.MessageRequest_Address = new Dictionary<System.String, Amazon.Pinpoint.Model.AddressConfiguration>(StringComparer.Ordinal);
                foreach (var hashKey in this.MessageRequest_Address.Keys)
                {
                    context.MessageRequest_Address.Add((String)hashKey, (AddressConfiguration)(this.MessageRequest_Address[hashKey]));
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
                context.MessageRequest_Endpoint = new Dictionary<System.String, Amazon.Pinpoint.Model.EndpointSendConfiguration>(StringComparer.Ordinal);
                foreach (var hashKey in this.MessageRequest_Endpoint.Keys)
                {
                    context.MessageRequest_Endpoint.Add((String)hashKey, (EndpointSendConfiguration)(this.MessageRequest_Endpoint[hashKey]));
                }
            }
            context.ADMMessage_Action = this.ADMMessage_Action;
            context.ADMMessage_Body = this.ADMMessage_Body;
            context.ADMMessage_ConsolidationKey = this.ADMMessage_ConsolidationKey;
            if (this.ADMMessage_Data != null)
            {
                context.ADMMessage_Data = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ADMMessage_Data.Keys)
                {
                    context.ADMMessage_Data.Add((String)hashKey, (String)(this.ADMMessage_Data[hashKey]));
                }
            }
            context.ADMMessage_ExpiresAfter = this.ADMMessage_ExpiresAfter;
            context.ADMMessage_IconReference = this.ADMMessage_IconReference;
            context.ADMMessage_ImageIconUrl = this.ADMMessage_ImageIconUrl;
            context.ADMMessage_ImageUrl = this.ADMMessage_ImageUrl;
            context.ADMMessage_MD5 = this.ADMMessage_MD5;
            context.ADMMessage_RawContent = this.ADMMessage_RawContent;
            context.ADMMessage_SilentPush = this.ADMMessage_SilentPush;
            context.ADMMessage_SmallImageIconUrl = this.ADMMessage_SmallImageIconUrl;
            context.ADMMessage_Sound = this.ADMMessage_Sound;
            if (this.ADMMessage_Substitution != null)
            {
                context.ADMMessage_Substitution = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.ADMMessage_Substitution.Keys)
                {
                    object hashValue = this.ADMMessage_Substitution[hashKey];
                    if (hashValue == null)
                    {
                        context.ADMMessage_Substitution.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((String)s);
                    }
                    context.ADMMessage_Substitution.Add((String)hashKey, valueSet);
                }
            }
            context.ADMMessage_Title = this.ADMMessage_Title;
            context.ADMMessage_Url = this.ADMMessage_Url;
            context.APNSMessage_Action = this.APNSMessage_Action;
            context.APNSMessage_APNSPushType = this.APNSMessage_APNSPushType;
            context.APNSMessage_Badge = this.APNSMessage_Badge;
            context.APNSMessage_Body = this.APNSMessage_Body;
            context.APNSMessage_Category = this.APNSMessage_Category;
            context.APNSMessage_CollapseId = this.APNSMessage_CollapseId;
            if (this.APNSMessage_Data != null)
            {
                context.APNSMessage_Data = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.APNSMessage_Data.Keys)
                {
                    context.APNSMessage_Data.Add((String)hashKey, (String)(this.APNSMessage_Data[hashKey]));
                }
            }
            context.APNSMessage_MediaUrl = this.APNSMessage_MediaUrl;
            context.APNSMessage_PreferredAuthenticationMethod = this.APNSMessage_PreferredAuthenticationMethod;
            context.APNSMessage_Priority = this.APNSMessage_Priority;
            context.APNSMessage_RawContent = this.APNSMessage_RawContent;
            context.APNSMessage_SilentPush = this.APNSMessage_SilentPush;
            context.APNSMessage_Sound = this.APNSMessage_Sound;
            if (this.APNSMessage_Substitution != null)
            {
                context.APNSMessage_Substitution = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.APNSMessage_Substitution.Keys)
                {
                    object hashValue = this.APNSMessage_Substitution[hashKey];
                    if (hashValue == null)
                    {
                        context.APNSMessage_Substitution.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((String)s);
                    }
                    context.APNSMessage_Substitution.Add((String)hashKey, valueSet);
                }
            }
            context.APNSMessage_ThreadId = this.APNSMessage_ThreadId;
            context.APNSMessage_TimeToLive = this.APNSMessage_TimeToLive;
            context.APNSMessage_Title = this.APNSMessage_Title;
            context.APNSMessage_Url = this.APNSMessage_Url;
            context.BaiduMessage_Action = this.BaiduMessage_Action;
            context.BaiduMessage_Body = this.BaiduMessage_Body;
            if (this.BaiduMessage_Data != null)
            {
                context.BaiduMessage_Data = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.BaiduMessage_Data.Keys)
                {
                    context.BaiduMessage_Data.Add((String)hashKey, (String)(this.BaiduMessage_Data[hashKey]));
                }
            }
            context.BaiduMessage_IconReference = this.BaiduMessage_IconReference;
            context.BaiduMessage_ImageIconUrl = this.BaiduMessage_ImageIconUrl;
            context.BaiduMessage_ImageUrl = this.BaiduMessage_ImageUrl;
            context.BaiduMessage_RawContent = this.BaiduMessage_RawContent;
            context.BaiduMessage_SilentPush = this.BaiduMessage_SilentPush;
            context.BaiduMessage_SmallImageIconUrl = this.BaiduMessage_SmallImageIconUrl;
            context.BaiduMessage_Sound = this.BaiduMessage_Sound;
            if (this.BaiduMessage_Substitution != null)
            {
                context.BaiduMessage_Substitution = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.BaiduMessage_Substitution.Keys)
                {
                    object hashValue = this.BaiduMessage_Substitution[hashKey];
                    if (hashValue == null)
                    {
                        context.BaiduMessage_Substitution.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((String)s);
                    }
                    context.BaiduMessage_Substitution.Add((String)hashKey, valueSet);
                }
            }
            context.BaiduMessage_TimeToLive = this.BaiduMessage_TimeToLive;
            context.BaiduMessage_Title = this.BaiduMessage_Title;
            context.BaiduMessage_Url = this.BaiduMessage_Url;
            context.DefaultMessage_Body = this.DefaultMessage_Body;
            if (this.DefaultMessage_Substitution != null)
            {
                context.DefaultMessage_Substitution = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.DefaultMessage_Substitution.Keys)
                {
                    object hashValue = this.DefaultMessage_Substitution[hashKey];
                    if (hashValue == null)
                    {
                        context.DefaultMessage_Substitution.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((String)s);
                    }
                    context.DefaultMessage_Substitution.Add((String)hashKey, valueSet);
                }
            }
            context.DefaultPushNotificationMessage_Action = this.DefaultPushNotificationMessage_Action;
            context.DefaultPushNotificationMessage_Body = this.DefaultPushNotificationMessage_Body;
            if (this.DefaultPushNotificationMessage_Data != null)
            {
                context.DefaultPushNotificationMessage_Data = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.DefaultPushNotificationMessage_Data.Keys)
                {
                    context.DefaultPushNotificationMessage_Data.Add((String)hashKey, (String)(this.DefaultPushNotificationMessage_Data[hashKey]));
                }
            }
            context.DefaultPushNotificationMessage_SilentPush = this.DefaultPushNotificationMessage_SilentPush;
            if (this.DefaultPushNotificationMessage_Substitution != null)
            {
                context.DefaultPushNotificationMessage_Substitution = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.DefaultPushNotificationMessage_Substitution.Keys)
                {
                    object hashValue = this.DefaultPushNotificationMessage_Substitution[hashKey];
                    if (hashValue == null)
                    {
                        context.DefaultPushNotificationMessage_Substitution.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((String)s);
                    }
                    context.DefaultPushNotificationMessage_Substitution.Add((String)hashKey, valueSet);
                }
            }
            context.DefaultPushNotificationMessage_Title = this.DefaultPushNotificationMessage_Title;
            context.DefaultPushNotificationMessage_Url = this.DefaultPushNotificationMessage_Url;
            context.EmailMessage_Body = this.EmailMessage_Body;
            context.EmailMessage_FeedbackForwardingAddress = this.EmailMessage_FeedbackForwardingAddress;
            context.EmailMessage_FromAddress = this.EmailMessage_FromAddress;
            context.RawEmail_Data = this.RawEmail_Data;
            if (this.EmailMessage_ReplyToAddress != null)
            {
                context.EmailMessage_ReplyToAddress = new List<System.String>(this.EmailMessage_ReplyToAddress);
            }
            context.HtmlPart_Charset = this.HtmlPart_Charset;
            context.HtmlPart_Data = this.HtmlPart_Data;
            context.Subject_Charset = this.Subject_Charset;
            context.Subject_Data = this.Subject_Data;
            context.TextPart_Charset = this.TextPart_Charset;
            context.TextPart_Data = this.TextPart_Data;
            if (this.EmailMessage_Substitution != null)
            {
                context.EmailMessage_Substitution = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.EmailMessage_Substitution.Keys)
                {
                    object hashValue = this.EmailMessage_Substitution[hashKey];
                    if (hashValue == null)
                    {
                        context.EmailMessage_Substitution.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((String)s);
                    }
                    context.EmailMessage_Substitution.Add((String)hashKey, valueSet);
                }
            }
            context.GCMMessage_Action = this.GCMMessage_Action;
            context.GCMMessage_Body = this.GCMMessage_Body;
            context.GCMMessage_CollapseKey = this.GCMMessage_CollapseKey;
            if (this.GCMMessage_Data != null)
            {
                context.GCMMessage_Data = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.GCMMessage_Data.Keys)
                {
                    context.GCMMessage_Data.Add((String)hashKey, (String)(this.GCMMessage_Data[hashKey]));
                }
            }
            context.GCMMessage_IconReference = this.GCMMessage_IconReference;
            context.GCMMessage_ImageIconUrl = this.GCMMessage_ImageIconUrl;
            context.GCMMessage_ImageUrl = this.GCMMessage_ImageUrl;
            context.GCMMessage_Priority = this.GCMMessage_Priority;
            context.GCMMessage_RawContent = this.GCMMessage_RawContent;
            context.GCMMessage_RestrictedPackageName = this.GCMMessage_RestrictedPackageName;
            context.GCMMessage_SilentPush = this.GCMMessage_SilentPush;
            context.GCMMessage_SmallImageIconUrl = this.GCMMessage_SmallImageIconUrl;
            context.GCMMessage_Sound = this.GCMMessage_Sound;
            if (this.GCMMessage_Substitution != null)
            {
                context.GCMMessage_Substitution = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.GCMMessage_Substitution.Keys)
                {
                    object hashValue = this.GCMMessage_Substitution[hashKey];
                    if (hashValue == null)
                    {
                        context.GCMMessage_Substitution.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((String)s);
                    }
                    context.GCMMessage_Substitution.Add((String)hashKey, valueSet);
                }
            }
            context.GCMMessage_TimeToLive = this.GCMMessage_TimeToLive;
            context.GCMMessage_Title = this.GCMMessage_Title;
            context.GCMMessage_Url = this.GCMMessage_Url;
            context.SMSMessage_Body = this.SMSMessage_Body;
            context.SMSMessage_Keyword = this.SMSMessage_Keyword;
            context.SMSMessage_MessageType = this.SMSMessage_MessageType;
            context.SMSMessage_OriginationNumber = this.SMSMessage_OriginationNumber;
            context.SMSMessage_SenderId = this.SMSMessage_SenderId;
            if (this.SMSMessage_Substitution != null)
            {
                context.SMSMessage_Substitution = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.SMSMessage_Substitution.Keys)
                {
                    object hashValue = this.SMSMessage_Substitution[hashKey];
                    if (hashValue == null)
                    {
                        context.SMSMessage_Substitution.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((String)s);
                    }
                    context.SMSMessage_Substitution.Add((String)hashKey, valueSet);
                }
            }
            context.VoiceMessage_Body = this.VoiceMessage_Body;
            context.VoiceMessage_LanguageCode = this.VoiceMessage_LanguageCode;
            context.VoiceMessage_OriginationNumber = this.VoiceMessage_OriginationNumber;
            if (this.VoiceMessage_Substitution != null)
            {
                context.VoiceMessage_Substitution = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.VoiceMessage_Substitution.Keys)
                {
                    object hashValue = this.VoiceMessage_Substitution[hashKey];
                    if (hashValue == null)
                    {
                        context.VoiceMessage_Substitution.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((String)s);
                    }
                    context.VoiceMessage_Substitution.Add((String)hashKey, valueSet);
                }
            }
            context.VoiceMessage_VoiceId = this.VoiceMessage_VoiceId;
            context.EmailTemplate_Name = this.EmailTemplate_Name;
            context.EmailTemplate_Version = this.EmailTemplate_Version;
            context.PushTemplate_Name = this.PushTemplate_Name;
            context.PushTemplate_Version = this.PushTemplate_Version;
            context.SMSTemplate_Name = this.SMSTemplate_Name;
            context.SMSTemplate_Version = this.SMSTemplate_Version;
            context.VoiceTemplate_Name = this.VoiceTemplate_Name;
            context.VoiceTemplate_Version = this.VoiceTemplate_Version;
            context.MessageRequest_TraceId = this.MessageRequest_TraceId;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _RawEmail_DataStream = null;
            
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
                var requestMessageRequestIsNull = true;
                request.MessageRequest = new Amazon.Pinpoint.Model.MessageRequest();
                Dictionary<System.String, Amazon.Pinpoint.Model.AddressConfiguration> requestMessageRequest_messageRequest_Address = null;
                if (cmdletContext.MessageRequest_Address != null)
                {
                    requestMessageRequest_messageRequest_Address = cmdletContext.MessageRequest_Address;
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
                if (cmdletContext.MessageRequest_Endpoint != null)
                {
                    requestMessageRequest_messageRequest_Endpoint = cmdletContext.MessageRequest_Endpoint;
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
                Amazon.Pinpoint.Model.TemplateConfiguration requestMessageRequest_messageRequest_TemplateConfiguration = null;
                
                 // populate TemplateConfiguration
                var requestMessageRequest_messageRequest_TemplateConfigurationIsNull = true;
                requestMessageRequest_messageRequest_TemplateConfiguration = new Amazon.Pinpoint.Model.TemplateConfiguration();
                Amazon.Pinpoint.Model.Template requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_EmailTemplate = null;
                
                 // populate EmailTemplate
                var requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_EmailTemplateIsNull = true;
                requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_EmailTemplate = new Amazon.Pinpoint.Model.Template();
                System.String requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_EmailTemplate_emailTemplate_Name = null;
                if (cmdletContext.EmailTemplate_Name != null)
                {
                    requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_EmailTemplate_emailTemplate_Name = cmdletContext.EmailTemplate_Name;
                }
                if (requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_EmailTemplate_emailTemplate_Name != null)
                {
                    requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_EmailTemplate.Name = requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_EmailTemplate_emailTemplate_Name;
                    requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_EmailTemplateIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_EmailTemplate_emailTemplate_Version = null;
                if (cmdletContext.EmailTemplate_Version != null)
                {
                    requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_EmailTemplate_emailTemplate_Version = cmdletContext.EmailTemplate_Version;
                }
                if (requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_EmailTemplate_emailTemplate_Version != null)
                {
                    requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_EmailTemplate.Version = requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_EmailTemplate_emailTemplate_Version;
                    requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_EmailTemplateIsNull = false;
                }
                 // determine if requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_EmailTemplate should be set to null
                if (requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_EmailTemplateIsNull)
                {
                    requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_EmailTemplate = null;
                }
                if (requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_EmailTemplate != null)
                {
                    requestMessageRequest_messageRequest_TemplateConfiguration.EmailTemplate = requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_EmailTemplate;
                    requestMessageRequest_messageRequest_TemplateConfigurationIsNull = false;
                }
                Amazon.Pinpoint.Model.Template requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_PushTemplate = null;
                
                 // populate PushTemplate
                var requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_PushTemplateIsNull = true;
                requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_PushTemplate = new Amazon.Pinpoint.Model.Template();
                System.String requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_PushTemplate_pushTemplate_Name = null;
                if (cmdletContext.PushTemplate_Name != null)
                {
                    requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_PushTemplate_pushTemplate_Name = cmdletContext.PushTemplate_Name;
                }
                if (requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_PushTemplate_pushTemplate_Name != null)
                {
                    requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_PushTemplate.Name = requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_PushTemplate_pushTemplate_Name;
                    requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_PushTemplateIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_PushTemplate_pushTemplate_Version = null;
                if (cmdletContext.PushTemplate_Version != null)
                {
                    requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_PushTemplate_pushTemplate_Version = cmdletContext.PushTemplate_Version;
                }
                if (requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_PushTemplate_pushTemplate_Version != null)
                {
                    requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_PushTemplate.Version = requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_PushTemplate_pushTemplate_Version;
                    requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_PushTemplateIsNull = false;
                }
                 // determine if requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_PushTemplate should be set to null
                if (requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_PushTemplateIsNull)
                {
                    requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_PushTemplate = null;
                }
                if (requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_PushTemplate != null)
                {
                    requestMessageRequest_messageRequest_TemplateConfiguration.PushTemplate = requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_PushTemplate;
                    requestMessageRequest_messageRequest_TemplateConfigurationIsNull = false;
                }
                Amazon.Pinpoint.Model.Template requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_SMSTemplate = null;
                
                 // populate SMSTemplate
                var requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_SMSTemplateIsNull = true;
                requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_SMSTemplate = new Amazon.Pinpoint.Model.Template();
                System.String requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_SMSTemplate_sMSTemplate_Name = null;
                if (cmdletContext.SMSTemplate_Name != null)
                {
                    requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_SMSTemplate_sMSTemplate_Name = cmdletContext.SMSTemplate_Name;
                }
                if (requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_SMSTemplate_sMSTemplate_Name != null)
                {
                    requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_SMSTemplate.Name = requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_SMSTemplate_sMSTemplate_Name;
                    requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_SMSTemplateIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_SMSTemplate_sMSTemplate_Version = null;
                if (cmdletContext.SMSTemplate_Version != null)
                {
                    requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_SMSTemplate_sMSTemplate_Version = cmdletContext.SMSTemplate_Version;
                }
                if (requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_SMSTemplate_sMSTemplate_Version != null)
                {
                    requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_SMSTemplate.Version = requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_SMSTemplate_sMSTemplate_Version;
                    requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_SMSTemplateIsNull = false;
                }
                 // determine if requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_SMSTemplate should be set to null
                if (requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_SMSTemplateIsNull)
                {
                    requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_SMSTemplate = null;
                }
                if (requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_SMSTemplate != null)
                {
                    requestMessageRequest_messageRequest_TemplateConfiguration.SMSTemplate = requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_SMSTemplate;
                    requestMessageRequest_messageRequest_TemplateConfigurationIsNull = false;
                }
                Amazon.Pinpoint.Model.Template requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_VoiceTemplate = null;
                
                 // populate VoiceTemplate
                var requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_VoiceTemplateIsNull = true;
                requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_VoiceTemplate = new Amazon.Pinpoint.Model.Template();
                System.String requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_VoiceTemplate_voiceTemplate_Name = null;
                if (cmdletContext.VoiceTemplate_Name != null)
                {
                    requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_VoiceTemplate_voiceTemplate_Name = cmdletContext.VoiceTemplate_Name;
                }
                if (requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_VoiceTemplate_voiceTemplate_Name != null)
                {
                    requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_VoiceTemplate.Name = requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_VoiceTemplate_voiceTemplate_Name;
                    requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_VoiceTemplateIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_VoiceTemplate_voiceTemplate_Version = null;
                if (cmdletContext.VoiceTemplate_Version != null)
                {
                    requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_VoiceTemplate_voiceTemplate_Version = cmdletContext.VoiceTemplate_Version;
                }
                if (requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_VoiceTemplate_voiceTemplate_Version != null)
                {
                    requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_VoiceTemplate.Version = requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_VoiceTemplate_voiceTemplate_Version;
                    requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_VoiceTemplateIsNull = false;
                }
                 // determine if requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_VoiceTemplate should be set to null
                if (requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_VoiceTemplateIsNull)
                {
                    requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_VoiceTemplate = null;
                }
                if (requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_VoiceTemplate != null)
                {
                    requestMessageRequest_messageRequest_TemplateConfiguration.VoiceTemplate = requestMessageRequest_messageRequest_TemplateConfiguration_messageRequest_TemplateConfiguration_VoiceTemplate;
                    requestMessageRequest_messageRequest_TemplateConfigurationIsNull = false;
                }
                 // determine if requestMessageRequest_messageRequest_TemplateConfiguration should be set to null
                if (requestMessageRequest_messageRequest_TemplateConfigurationIsNull)
                {
                    requestMessageRequest_messageRequest_TemplateConfiguration = null;
                }
                if (requestMessageRequest_messageRequest_TemplateConfiguration != null)
                {
                    request.MessageRequest.TemplateConfiguration = requestMessageRequest_messageRequest_TemplateConfiguration;
                    requestMessageRequestIsNull = false;
                }
                Amazon.Pinpoint.Model.DirectMessageConfiguration requestMessageRequest_messageRequest_MessageConfiguration = null;
                
                 // populate MessageConfiguration
                var requestMessageRequest_messageRequest_MessageConfigurationIsNull = true;
                requestMessageRequest_messageRequest_MessageConfiguration = new Amazon.Pinpoint.Model.DirectMessageConfiguration();
                Amazon.Pinpoint.Model.DefaultMessage requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultMessage = null;
                
                 // populate DefaultMessage
                var requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultMessageIsNull = true;
                requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultMessage = new Amazon.Pinpoint.Model.DefaultMessage();
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultMessage_defaultMessage_Body = null;
                if (cmdletContext.DefaultMessage_Body != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultMessage_defaultMessage_Body = cmdletContext.DefaultMessage_Body;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultMessage_defaultMessage_Body != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultMessage.Body = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultMessage_defaultMessage_Body;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultMessageIsNull = false;
                }
                Dictionary<System.String, List<System.String>> requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultMessage_defaultMessage_Substitution = null;
                if (cmdletContext.DefaultMessage_Substitution != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultMessage_defaultMessage_Substitution = cmdletContext.DefaultMessage_Substitution;
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
                var requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessageIsNull = true;
                requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage = new Amazon.Pinpoint.Model.VoiceMessage();
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage_voiceMessage_Body = null;
                if (cmdletContext.VoiceMessage_Body != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage_voiceMessage_Body = cmdletContext.VoiceMessage_Body;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage_voiceMessage_Body != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage.Body = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage_voiceMessage_Body;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage_voiceMessage_LanguageCode = null;
                if (cmdletContext.VoiceMessage_LanguageCode != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage_voiceMessage_LanguageCode = cmdletContext.VoiceMessage_LanguageCode;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage_voiceMessage_LanguageCode != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage.LanguageCode = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage_voiceMessage_LanguageCode;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage_voiceMessage_OriginationNumber = null;
                if (cmdletContext.VoiceMessage_OriginationNumber != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage_voiceMessage_OriginationNumber = cmdletContext.VoiceMessage_OriginationNumber;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage_voiceMessage_OriginationNumber != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage.OriginationNumber = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage_voiceMessage_OriginationNumber;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessageIsNull = false;
                }
                Dictionary<System.String, List<System.String>> requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage_voiceMessage_Substitution = null;
                if (cmdletContext.VoiceMessage_Substitution != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage_voiceMessage_Substitution = cmdletContext.VoiceMessage_Substitution;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage_voiceMessage_Substitution != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage.Substitutions = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage_voiceMessage_Substitution;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage_voiceMessage_VoiceId = null;
                if (cmdletContext.VoiceMessage_VoiceId != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_VoiceMessage_voiceMessage_VoiceId = cmdletContext.VoiceMessage_VoiceId;
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
                var requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessageIsNull = true;
                requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage = new Amazon.Pinpoint.Model.SMSMessage();
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_Body = null;
                if (cmdletContext.SMSMessage_Body != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_Body = cmdletContext.SMSMessage_Body;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_Body != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage.Body = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_Body;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_Keyword = null;
                if (cmdletContext.SMSMessage_Keyword != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_Keyword = cmdletContext.SMSMessage_Keyword;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_Keyword != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage.Keyword = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_Keyword;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessageIsNull = false;
                }
                Amazon.Pinpoint.MessageType requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_MessageType = null;
                if (cmdletContext.SMSMessage_MessageType != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_MessageType = cmdletContext.SMSMessage_MessageType;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_MessageType != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage.MessageType = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_MessageType;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_OriginationNumber = null;
                if (cmdletContext.SMSMessage_OriginationNumber != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_OriginationNumber = cmdletContext.SMSMessage_OriginationNumber;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_OriginationNumber != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage.OriginationNumber = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_OriginationNumber;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_SenderId = null;
                if (cmdletContext.SMSMessage_SenderId != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_SenderId = cmdletContext.SMSMessage_SenderId;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_SenderId != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage.SenderId = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_SenderId;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessageIsNull = false;
                }
                Dictionary<System.String, List<System.String>> requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_Substitution = null;
                if (cmdletContext.SMSMessage_Substitution != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_SMSMessage_sMSMessage_Substitution = cmdletContext.SMSMessage_Substitution;
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
                var requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessageIsNull = true;
                requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage = new Amazon.Pinpoint.Model.DefaultPushNotificationMessage();
                Amazon.Pinpoint.Action requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Action = null;
                if (cmdletContext.DefaultPushNotificationMessage_Action != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Action = cmdletContext.DefaultPushNotificationMessage_Action;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Action != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage.Action = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Action;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Body = null;
                if (cmdletContext.DefaultPushNotificationMessage_Body != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Body = cmdletContext.DefaultPushNotificationMessage_Body;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Body != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage.Body = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Body;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessageIsNull = false;
                }
                Dictionary<System.String, System.String> requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Data = null;
                if (cmdletContext.DefaultPushNotificationMessage_Data != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Data = cmdletContext.DefaultPushNotificationMessage_Data;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Data != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage.Data = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Data;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessageIsNull = false;
                }
                System.Boolean? requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_SilentPush = null;
                if (cmdletContext.DefaultPushNotificationMessage_SilentPush != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_SilentPush = cmdletContext.DefaultPushNotificationMessage_SilentPush.Value;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_SilentPush != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage.SilentPush = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_SilentPush.Value;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessageIsNull = false;
                }
                Dictionary<System.String, List<System.String>> requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Substitution = null;
                if (cmdletContext.DefaultPushNotificationMessage_Substitution != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Substitution = cmdletContext.DefaultPushNotificationMessage_Substitution;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Substitution != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage.Substitutions = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Substitution;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Title = null;
                if (cmdletContext.DefaultPushNotificationMessage_Title != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Title = cmdletContext.DefaultPushNotificationMessage_Title;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Title != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage.Title = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Title;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Url = null;
                if (cmdletContext.DefaultPushNotificationMessage_Url != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Url = cmdletContext.DefaultPushNotificationMessage_Url;
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
                var requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessageIsNull = true;
                requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage = new Amazon.Pinpoint.Model.EmailMessage();
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_emailMessage_Body = null;
                if (cmdletContext.EmailMessage_Body != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_emailMessage_Body = cmdletContext.EmailMessage_Body;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_emailMessage_Body != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage.Body = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_emailMessage_Body;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_emailMessage_FeedbackForwardingAddress = null;
                if (cmdletContext.EmailMessage_FeedbackForwardingAddress != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_emailMessage_FeedbackForwardingAddress = cmdletContext.EmailMessage_FeedbackForwardingAddress;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_emailMessage_FeedbackForwardingAddress != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage.FeedbackForwardingAddress = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_emailMessage_FeedbackForwardingAddress;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_emailMessage_FromAddress = null;
                if (cmdletContext.EmailMessage_FromAddress != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_emailMessage_FromAddress = cmdletContext.EmailMessage_FromAddress;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_emailMessage_FromAddress != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage.FromAddress = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_emailMessage_FromAddress;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessageIsNull = false;
                }
                List<System.String> requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_emailMessage_ReplyToAddress = null;
                if (cmdletContext.EmailMessage_ReplyToAddress != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_emailMessage_ReplyToAddress = cmdletContext.EmailMessage_ReplyToAddress;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_emailMessage_ReplyToAddress != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage.ReplyToAddresses = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_emailMessage_ReplyToAddress;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessageIsNull = false;
                }
                Dictionary<System.String, List<System.String>> requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_emailMessage_Substitution = null;
                if (cmdletContext.EmailMessage_Substitution != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_emailMessage_Substitution = cmdletContext.EmailMessage_Substitution;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_emailMessage_Substitution != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage.Substitutions = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_emailMessage_Substitution;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessageIsNull = false;
                }
                Amazon.Pinpoint.Model.RawEmail requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_RawEmail = null;
                
                 // populate RawEmail
                var requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_RawEmailIsNull = true;
                requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_RawEmail = new Amazon.Pinpoint.Model.RawEmail();
                System.IO.MemoryStream requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_RawEmail_rawEmail_Data = null;
                if (cmdletContext.RawEmail_Data != null)
                {
                    _RawEmail_DataStream = new System.IO.MemoryStream(cmdletContext.RawEmail_Data);
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_RawEmail_rawEmail_Data = _RawEmail_DataStream;
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
                var requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmailIsNull = true;
                requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail = new Amazon.Pinpoint.Model.SimpleEmail();
                Amazon.Pinpoint.Model.SimpleEmailPart requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_HtmlPart = null;
                
                 // populate HtmlPart
                var requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_HtmlPartIsNull = true;
                requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_HtmlPart = new Amazon.Pinpoint.Model.SimpleEmailPart();
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_HtmlPart_htmlPart_Charset = null;
                if (cmdletContext.HtmlPart_Charset != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_HtmlPart_htmlPart_Charset = cmdletContext.HtmlPart_Charset;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_HtmlPart_htmlPart_Charset != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_HtmlPart.Charset = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_HtmlPart_htmlPart_Charset;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_HtmlPartIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_HtmlPart_htmlPart_Data = null;
                if (cmdletContext.HtmlPart_Data != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_HtmlPart_htmlPart_Data = cmdletContext.HtmlPart_Data;
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
                var requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_SubjectIsNull = true;
                requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_Subject = new Amazon.Pinpoint.Model.SimpleEmailPart();
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_Subject_subject_Charset = null;
                if (cmdletContext.Subject_Charset != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_Subject_subject_Charset = cmdletContext.Subject_Charset;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_Subject_subject_Charset != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_Subject.Charset = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_Subject_subject_Charset;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_SubjectIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_Subject_subject_Data = null;
                if (cmdletContext.Subject_Data != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_Subject_subject_Data = cmdletContext.Subject_Data;
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
                var requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_TextPartIsNull = true;
                requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_TextPart = new Amazon.Pinpoint.Model.SimpleEmailPart();
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_TextPart_textPart_Charset = null;
                if (cmdletContext.TextPart_Charset != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_TextPart_textPart_Charset = cmdletContext.TextPart_Charset;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_TextPart_textPart_Charset != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_TextPart.Charset = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_TextPart_textPart_Charset;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_TextPartIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_TextPart_textPart_Data = null;
                if (cmdletContext.TextPart_Data != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_EmailMessage_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_messageRequest_MessageConfiguration_EmailMessage_SimpleEmail_TextPart_textPart_Data = cmdletContext.TextPart_Data;
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
                var requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessageIsNull = true;
                requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage = new Amazon.Pinpoint.Model.BaiduMessage();
                Amazon.Pinpoint.Action requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Action = null;
                if (cmdletContext.BaiduMessage_Action != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Action = cmdletContext.BaiduMessage_Action;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Action != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage.Action = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Action;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Body = null;
                if (cmdletContext.BaiduMessage_Body != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Body = cmdletContext.BaiduMessage_Body;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Body != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage.Body = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Body;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessageIsNull = false;
                }
                Dictionary<System.String, System.String> requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Data = null;
                if (cmdletContext.BaiduMessage_Data != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Data = cmdletContext.BaiduMessage_Data;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Data != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage.Data = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Data;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_IconReference = null;
                if (cmdletContext.BaiduMessage_IconReference != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_IconReference = cmdletContext.BaiduMessage_IconReference;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_IconReference != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage.IconReference = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_IconReference;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_ImageIconUrl = null;
                if (cmdletContext.BaiduMessage_ImageIconUrl != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_ImageIconUrl = cmdletContext.BaiduMessage_ImageIconUrl;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_ImageIconUrl != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage.ImageIconUrl = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_ImageIconUrl;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_ImageUrl = null;
                if (cmdletContext.BaiduMessage_ImageUrl != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_ImageUrl = cmdletContext.BaiduMessage_ImageUrl;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_ImageUrl != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage.ImageUrl = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_ImageUrl;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_RawContent = null;
                if (cmdletContext.BaiduMessage_RawContent != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_RawContent = cmdletContext.BaiduMessage_RawContent;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_RawContent != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage.RawContent = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_RawContent;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessageIsNull = false;
                }
                System.Boolean? requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_SilentPush = null;
                if (cmdletContext.BaiduMessage_SilentPush != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_SilentPush = cmdletContext.BaiduMessage_SilentPush.Value;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_SilentPush != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage.SilentPush = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_SilentPush.Value;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_SmallImageIconUrl = null;
                if (cmdletContext.BaiduMessage_SmallImageIconUrl != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_SmallImageIconUrl = cmdletContext.BaiduMessage_SmallImageIconUrl;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_SmallImageIconUrl != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage.SmallImageIconUrl = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_SmallImageIconUrl;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Sound = null;
                if (cmdletContext.BaiduMessage_Sound != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Sound = cmdletContext.BaiduMessage_Sound;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Sound != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage.Sound = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Sound;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessageIsNull = false;
                }
                Dictionary<System.String, List<System.String>> requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Substitution = null;
                if (cmdletContext.BaiduMessage_Substitution != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Substitution = cmdletContext.BaiduMessage_Substitution;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Substitution != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage.Substitutions = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Substitution;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessageIsNull = false;
                }
                System.Int32? requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_TimeToLive = null;
                if (cmdletContext.BaiduMessage_TimeToLive != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_TimeToLive = cmdletContext.BaiduMessage_TimeToLive.Value;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_TimeToLive != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage.TimeToLive = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_TimeToLive.Value;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Title = null;
                if (cmdletContext.BaiduMessage_Title != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Title = cmdletContext.BaiduMessage_Title;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Title != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage.Title = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Title;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Url = null;
                if (cmdletContext.BaiduMessage_Url != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Url = cmdletContext.BaiduMessage_Url;
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
                var requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessageIsNull = true;
                requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage = new Amazon.Pinpoint.Model.ADMMessage();
                Amazon.Pinpoint.Action requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Action = null;
                if (cmdletContext.ADMMessage_Action != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Action = cmdletContext.ADMMessage_Action;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Action != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage.Action = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Action;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Body = null;
                if (cmdletContext.ADMMessage_Body != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Body = cmdletContext.ADMMessage_Body;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Body != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage.Body = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Body;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_ConsolidationKey = null;
                if (cmdletContext.ADMMessage_ConsolidationKey != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_ConsolidationKey = cmdletContext.ADMMessage_ConsolidationKey;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_ConsolidationKey != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage.ConsolidationKey = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_ConsolidationKey;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessageIsNull = false;
                }
                Dictionary<System.String, System.String> requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Data = null;
                if (cmdletContext.ADMMessage_Data != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Data = cmdletContext.ADMMessage_Data;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Data != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage.Data = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Data;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_ExpiresAfter = null;
                if (cmdletContext.ADMMessage_ExpiresAfter != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_ExpiresAfter = cmdletContext.ADMMessage_ExpiresAfter;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_ExpiresAfter != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage.ExpiresAfter = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_ExpiresAfter;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_IconReference = null;
                if (cmdletContext.ADMMessage_IconReference != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_IconReference = cmdletContext.ADMMessage_IconReference;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_IconReference != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage.IconReference = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_IconReference;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_ImageIconUrl = null;
                if (cmdletContext.ADMMessage_ImageIconUrl != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_ImageIconUrl = cmdletContext.ADMMessage_ImageIconUrl;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_ImageIconUrl != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage.ImageIconUrl = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_ImageIconUrl;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_ImageUrl = null;
                if (cmdletContext.ADMMessage_ImageUrl != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_ImageUrl = cmdletContext.ADMMessage_ImageUrl;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_ImageUrl != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage.ImageUrl = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_ImageUrl;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_MD5 = null;
                if (cmdletContext.ADMMessage_MD5 != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_MD5 = cmdletContext.ADMMessage_MD5;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_MD5 != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage.MD5 = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_MD5;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_RawContent = null;
                if (cmdletContext.ADMMessage_RawContent != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_RawContent = cmdletContext.ADMMessage_RawContent;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_RawContent != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage.RawContent = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_RawContent;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessageIsNull = false;
                }
                System.Boolean? requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_SilentPush = null;
                if (cmdletContext.ADMMessage_SilentPush != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_SilentPush = cmdletContext.ADMMessage_SilentPush.Value;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_SilentPush != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage.SilentPush = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_SilentPush.Value;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_SmallImageIconUrl = null;
                if (cmdletContext.ADMMessage_SmallImageIconUrl != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_SmallImageIconUrl = cmdletContext.ADMMessage_SmallImageIconUrl;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_SmallImageIconUrl != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage.SmallImageIconUrl = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_SmallImageIconUrl;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Sound = null;
                if (cmdletContext.ADMMessage_Sound != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Sound = cmdletContext.ADMMessage_Sound;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Sound != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage.Sound = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Sound;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessageIsNull = false;
                }
                Dictionary<System.String, List<System.String>> requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Substitution = null;
                if (cmdletContext.ADMMessage_Substitution != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Substitution = cmdletContext.ADMMessage_Substitution;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Substitution != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage.Substitutions = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Substitution;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Title = null;
                if (cmdletContext.ADMMessage_Title != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Title = cmdletContext.ADMMessage_Title;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Title != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage.Title = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Title;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Url = null;
                if (cmdletContext.ADMMessage_Url != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_ADMMessage_aDMMessage_Url = cmdletContext.ADMMessage_Url;
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
                Amazon.Pinpoint.Model.GCMMessage requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage = null;
                
                 // populate GCMMessage
                var requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessageIsNull = true;
                requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage = new Amazon.Pinpoint.Model.GCMMessage();
                Amazon.Pinpoint.Action requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Action = null;
                if (cmdletContext.GCMMessage_Action != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Action = cmdletContext.GCMMessage_Action;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Action != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage.Action = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Action;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Body = null;
                if (cmdletContext.GCMMessage_Body != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Body = cmdletContext.GCMMessage_Body;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Body != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage.Body = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Body;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_CollapseKey = null;
                if (cmdletContext.GCMMessage_CollapseKey != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_CollapseKey = cmdletContext.GCMMessage_CollapseKey;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_CollapseKey != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage.CollapseKey = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_CollapseKey;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessageIsNull = false;
                }
                Dictionary<System.String, System.String> requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Data = null;
                if (cmdletContext.GCMMessage_Data != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Data = cmdletContext.GCMMessage_Data;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Data != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage.Data = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Data;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_IconReference = null;
                if (cmdletContext.GCMMessage_IconReference != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_IconReference = cmdletContext.GCMMessage_IconReference;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_IconReference != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage.IconReference = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_IconReference;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageIconUrl = null;
                if (cmdletContext.GCMMessage_ImageIconUrl != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageIconUrl = cmdletContext.GCMMessage_ImageIconUrl;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageIconUrl != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage.ImageIconUrl = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageIconUrl;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageUrl = null;
                if (cmdletContext.GCMMessage_ImageUrl != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageUrl = cmdletContext.GCMMessage_ImageUrl;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageUrl != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage.ImageUrl = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageUrl;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Priority = null;
                if (cmdletContext.GCMMessage_Priority != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Priority = cmdletContext.GCMMessage_Priority;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Priority != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage.Priority = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Priority;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_RawContent = null;
                if (cmdletContext.GCMMessage_RawContent != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_RawContent = cmdletContext.GCMMessage_RawContent;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_RawContent != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage.RawContent = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_RawContent;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_RestrictedPackageName = null;
                if (cmdletContext.GCMMessage_RestrictedPackageName != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_RestrictedPackageName = cmdletContext.GCMMessage_RestrictedPackageName;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_RestrictedPackageName != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage.RestrictedPackageName = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_RestrictedPackageName;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessageIsNull = false;
                }
                System.Boolean? requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_SilentPush = null;
                if (cmdletContext.GCMMessage_SilentPush != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_SilentPush = cmdletContext.GCMMessage_SilentPush.Value;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_SilentPush != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage.SilentPush = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_SilentPush.Value;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_SmallImageIconUrl = null;
                if (cmdletContext.GCMMessage_SmallImageIconUrl != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_SmallImageIconUrl = cmdletContext.GCMMessage_SmallImageIconUrl;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_SmallImageIconUrl != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage.SmallImageIconUrl = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_SmallImageIconUrl;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Sound = null;
                if (cmdletContext.GCMMessage_Sound != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Sound = cmdletContext.GCMMessage_Sound;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Sound != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage.Sound = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Sound;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessageIsNull = false;
                }
                Dictionary<System.String, List<System.String>> requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Substitution = null;
                if (cmdletContext.GCMMessage_Substitution != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Substitution = cmdletContext.GCMMessage_Substitution;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Substitution != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage.Substitutions = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Substitution;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessageIsNull = false;
                }
                System.Int32? requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_TimeToLive = null;
                if (cmdletContext.GCMMessage_TimeToLive != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_TimeToLive = cmdletContext.GCMMessage_TimeToLive.Value;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_TimeToLive != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage.TimeToLive = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_TimeToLive.Value;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Title = null;
                if (cmdletContext.GCMMessage_Title != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Title = cmdletContext.GCMMessage_Title;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Title != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage.Title = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Title;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Url = null;
                if (cmdletContext.GCMMessage_Url != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_GCMMessage_gCMMessage_Url = cmdletContext.GCMMessage_Url;
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
                Amazon.Pinpoint.Model.APNSMessage requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage = null;
                
                 // populate APNSMessage
                var requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessageIsNull = true;
                requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage = new Amazon.Pinpoint.Model.APNSMessage();
                Amazon.Pinpoint.Action requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Action = null;
                if (cmdletContext.APNSMessage_Action != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Action = cmdletContext.APNSMessage_Action;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Action != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage.Action = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Action;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_APNSPushType = null;
                if (cmdletContext.APNSMessage_APNSPushType != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_APNSPushType = cmdletContext.APNSMessage_APNSPushType;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_APNSPushType != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage.APNSPushType = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_APNSPushType;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessageIsNull = false;
                }
                System.Int32? requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Badge = null;
                if (cmdletContext.APNSMessage_Badge != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Badge = cmdletContext.APNSMessage_Badge.Value;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Badge != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage.Badge = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Badge.Value;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Body = null;
                if (cmdletContext.APNSMessage_Body != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Body = cmdletContext.APNSMessage_Body;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Body != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage.Body = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Body;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Category = null;
                if (cmdletContext.APNSMessage_Category != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Category = cmdletContext.APNSMessage_Category;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Category != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage.Category = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Category;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_CollapseId = null;
                if (cmdletContext.APNSMessage_CollapseId != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_CollapseId = cmdletContext.APNSMessage_CollapseId;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_CollapseId != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage.CollapseId = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_CollapseId;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessageIsNull = false;
                }
                Dictionary<System.String, System.String> requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Data = null;
                if (cmdletContext.APNSMessage_Data != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Data = cmdletContext.APNSMessage_Data;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Data != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage.Data = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Data;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_MediaUrl = null;
                if (cmdletContext.APNSMessage_MediaUrl != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_MediaUrl = cmdletContext.APNSMessage_MediaUrl;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_MediaUrl != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage.MediaUrl = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_MediaUrl;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_PreferredAuthenticationMethod = null;
                if (cmdletContext.APNSMessage_PreferredAuthenticationMethod != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_PreferredAuthenticationMethod = cmdletContext.APNSMessage_PreferredAuthenticationMethod;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_PreferredAuthenticationMethod != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage.PreferredAuthenticationMethod = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_PreferredAuthenticationMethod;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Priority = null;
                if (cmdletContext.APNSMessage_Priority != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Priority = cmdletContext.APNSMessage_Priority;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Priority != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage.Priority = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Priority;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_RawContent = null;
                if (cmdletContext.APNSMessage_RawContent != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_RawContent = cmdletContext.APNSMessage_RawContent;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_RawContent != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage.RawContent = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_RawContent;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessageIsNull = false;
                }
                System.Boolean? requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_SilentPush = null;
                if (cmdletContext.APNSMessage_SilentPush != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_SilentPush = cmdletContext.APNSMessage_SilentPush.Value;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_SilentPush != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage.SilentPush = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_SilentPush.Value;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Sound = null;
                if (cmdletContext.APNSMessage_Sound != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Sound = cmdletContext.APNSMessage_Sound;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Sound != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage.Sound = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Sound;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessageIsNull = false;
                }
                Dictionary<System.String, List<System.String>> requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Substitution = null;
                if (cmdletContext.APNSMessage_Substitution != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Substitution = cmdletContext.APNSMessage_Substitution;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Substitution != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage.Substitutions = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Substitution;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_ThreadId = null;
                if (cmdletContext.APNSMessage_ThreadId != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_ThreadId = cmdletContext.APNSMessage_ThreadId;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_ThreadId != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage.ThreadId = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_ThreadId;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessageIsNull = false;
                }
                System.Int32? requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_TimeToLive = null;
                if (cmdletContext.APNSMessage_TimeToLive != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_TimeToLive = cmdletContext.APNSMessage_TimeToLive.Value;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_TimeToLive != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage.TimeToLive = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_TimeToLive.Value;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Title = null;
                if (cmdletContext.APNSMessage_Title != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Title = cmdletContext.APNSMessage_Title;
                }
                if (requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Title != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage.Title = requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Title;
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessageIsNull = false;
                }
                System.String requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Url = null;
                if (cmdletContext.APNSMessage_Url != null)
                {
                    requestMessageRequest_messageRequest_MessageConfiguration_messageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Url = cmdletContext.APNSMessage_Url;
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
            finally
            {
                if( _RawEmail_DataStream != null)
                {
                    _RawEmail_DataStream.Dispose();
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
                return client.SendMessagesAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, Amazon.Pinpoint.Model.AddressConfiguration> MessageRequest_Address { get; set; }
            public Dictionary<System.String, System.String> MessageRequest_Context { get; set; }
            public Dictionary<System.String, Amazon.Pinpoint.Model.EndpointSendConfiguration> MessageRequest_Endpoint { get; set; }
            public Amazon.Pinpoint.Action ADMMessage_Action { get; set; }
            public System.String ADMMessage_Body { get; set; }
            public System.String ADMMessage_ConsolidationKey { get; set; }
            public Dictionary<System.String, System.String> ADMMessage_Data { get; set; }
            public System.String ADMMessage_ExpiresAfter { get; set; }
            public System.String ADMMessage_IconReference { get; set; }
            public System.String ADMMessage_ImageIconUrl { get; set; }
            public System.String ADMMessage_ImageUrl { get; set; }
            public System.String ADMMessage_MD5 { get; set; }
            public System.String ADMMessage_RawContent { get; set; }
            public System.Boolean? ADMMessage_SilentPush { get; set; }
            public System.String ADMMessage_SmallImageIconUrl { get; set; }
            public System.String ADMMessage_Sound { get; set; }
            public Dictionary<System.String, List<System.String>> ADMMessage_Substitution { get; set; }
            public System.String ADMMessage_Title { get; set; }
            public System.String ADMMessage_Url { get; set; }
            public Amazon.Pinpoint.Action APNSMessage_Action { get; set; }
            public System.String APNSMessage_APNSPushType { get; set; }
            public System.Int32? APNSMessage_Badge { get; set; }
            public System.String APNSMessage_Body { get; set; }
            public System.String APNSMessage_Category { get; set; }
            public System.String APNSMessage_CollapseId { get; set; }
            public Dictionary<System.String, System.String> APNSMessage_Data { get; set; }
            public System.String APNSMessage_MediaUrl { get; set; }
            public System.String APNSMessage_PreferredAuthenticationMethod { get; set; }
            public System.String APNSMessage_Priority { get; set; }
            public System.String APNSMessage_RawContent { get; set; }
            public System.Boolean? APNSMessage_SilentPush { get; set; }
            public System.String APNSMessage_Sound { get; set; }
            public Dictionary<System.String, List<System.String>> APNSMessage_Substitution { get; set; }
            public System.String APNSMessage_ThreadId { get; set; }
            public System.Int32? APNSMessage_TimeToLive { get; set; }
            public System.String APNSMessage_Title { get; set; }
            public System.String APNSMessage_Url { get; set; }
            public Amazon.Pinpoint.Action BaiduMessage_Action { get; set; }
            public System.String BaiduMessage_Body { get; set; }
            public Dictionary<System.String, System.String> BaiduMessage_Data { get; set; }
            public System.String BaiduMessage_IconReference { get; set; }
            public System.String BaiduMessage_ImageIconUrl { get; set; }
            public System.String BaiduMessage_ImageUrl { get; set; }
            public System.String BaiduMessage_RawContent { get; set; }
            public System.Boolean? BaiduMessage_SilentPush { get; set; }
            public System.String BaiduMessage_SmallImageIconUrl { get; set; }
            public System.String BaiduMessage_Sound { get; set; }
            public Dictionary<System.String, List<System.String>> BaiduMessage_Substitution { get; set; }
            public System.Int32? BaiduMessage_TimeToLive { get; set; }
            public System.String BaiduMessage_Title { get; set; }
            public System.String BaiduMessage_Url { get; set; }
            public System.String DefaultMessage_Body { get; set; }
            public Dictionary<System.String, List<System.String>> DefaultMessage_Substitution { get; set; }
            public Amazon.Pinpoint.Action DefaultPushNotificationMessage_Action { get; set; }
            public System.String DefaultPushNotificationMessage_Body { get; set; }
            public Dictionary<System.String, System.String> DefaultPushNotificationMessage_Data { get; set; }
            public System.Boolean? DefaultPushNotificationMessage_SilentPush { get; set; }
            public Dictionary<System.String, List<System.String>> DefaultPushNotificationMessage_Substitution { get; set; }
            public System.String DefaultPushNotificationMessage_Title { get; set; }
            public System.String DefaultPushNotificationMessage_Url { get; set; }
            public System.String EmailMessage_Body { get; set; }
            public System.String EmailMessage_FeedbackForwardingAddress { get; set; }
            public System.String EmailMessage_FromAddress { get; set; }
            public byte[] RawEmail_Data { get; set; }
            public List<System.String> EmailMessage_ReplyToAddress { get; set; }
            public System.String HtmlPart_Charset { get; set; }
            public System.String HtmlPart_Data { get; set; }
            public System.String Subject_Charset { get; set; }
            public System.String Subject_Data { get; set; }
            public System.String TextPart_Charset { get; set; }
            public System.String TextPart_Data { get; set; }
            public Dictionary<System.String, List<System.String>> EmailMessage_Substitution { get; set; }
            public Amazon.Pinpoint.Action GCMMessage_Action { get; set; }
            public System.String GCMMessage_Body { get; set; }
            public System.String GCMMessage_CollapseKey { get; set; }
            public Dictionary<System.String, System.String> GCMMessage_Data { get; set; }
            public System.String GCMMessage_IconReference { get; set; }
            public System.String GCMMessage_ImageIconUrl { get; set; }
            public System.String GCMMessage_ImageUrl { get; set; }
            public System.String GCMMessage_Priority { get; set; }
            public System.String GCMMessage_RawContent { get; set; }
            public System.String GCMMessage_RestrictedPackageName { get; set; }
            public System.Boolean? GCMMessage_SilentPush { get; set; }
            public System.String GCMMessage_SmallImageIconUrl { get; set; }
            public System.String GCMMessage_Sound { get; set; }
            public Dictionary<System.String, List<System.String>> GCMMessage_Substitution { get; set; }
            public System.Int32? GCMMessage_TimeToLive { get; set; }
            public System.String GCMMessage_Title { get; set; }
            public System.String GCMMessage_Url { get; set; }
            public System.String SMSMessage_Body { get; set; }
            public System.String SMSMessage_Keyword { get; set; }
            public Amazon.Pinpoint.MessageType SMSMessage_MessageType { get; set; }
            public System.String SMSMessage_OriginationNumber { get; set; }
            public System.String SMSMessage_SenderId { get; set; }
            public Dictionary<System.String, List<System.String>> SMSMessage_Substitution { get; set; }
            public System.String VoiceMessage_Body { get; set; }
            public System.String VoiceMessage_LanguageCode { get; set; }
            public System.String VoiceMessage_OriginationNumber { get; set; }
            public Dictionary<System.String, List<System.String>> VoiceMessage_Substitution { get; set; }
            public System.String VoiceMessage_VoiceId { get; set; }
            public System.String EmailTemplate_Name { get; set; }
            public System.String EmailTemplate_Version { get; set; }
            public System.String PushTemplate_Name { get; set; }
            public System.String PushTemplate_Version { get; set; }
            public System.String SMSTemplate_Name { get; set; }
            public System.String SMSTemplate_Version { get; set; }
            public System.String VoiceTemplate_Name { get; set; }
            public System.String VoiceTemplate_Version { get; set; }
            public System.String MessageRequest_TraceId { get; set; }
            public System.Func<Amazon.Pinpoint.Model.SendMessagesResponse, SendPINMessageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MessageResponse;
        }
        
    }
}
