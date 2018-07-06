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
    /// Use this resource to message a list of users. Amazon Pinpoint sends the message to
    /// all of the endpoints that are associated with each user.A user represents an individual
    /// who is assigned a unique user ID, and this ID is assigned to one or more endpoints.
    /// For example, if an individual uses your app on multiple devices, your app could assign
    /// that person's user ID to the endpoint for each device.With the users-messages resource,
    /// you specify the message recipients as user IDs. For each user ID, Amazon Pinpoint
    /// delivers the message to all of the user's endpoints. Within the body of your request,
    /// you can specify a default message, and you can tailor your message for different channels,
    /// including those for mobile push and SMS.With this resource, you send a direct message,
    /// which is a one time message that you send to a limited audience without creating a
    /// campaign. You can send the message to up to 100 users per request. You cannot use
    /// the message to engage a segment. When you send the message, Amazon Pinpoint delivers
    /// it immediately, and you cannot schedule the delivery. To engage a user segment, and
    /// to schedule the message delivery, create a campaign instead of using the users-messages
    /// resource.
    /// </summary>
    [Cmdlet("Send", "PINUserMessageBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.SendUsersMessageResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint SendUsersMessages API operation.", Operation = new[] {"SendUsersMessages"})]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.SendUsersMessageResponse",
        "This cmdlet returns a SendUsersMessageResponse object.",
        "The service call response (type Amazon.Pinpoint.Model.SendUsersMessagesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SendPINUserMessageBatchCmdlet : AmazonPinpointClientCmdlet, IExecutor
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_ADMMessage_Action")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_APNSMessage_Action")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_BaiduMessage_Action")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Action")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_GCMMessage_Action")]
        [AWSConstantClassSource("Amazon.Pinpoint.Action")]
        public Amazon.Pinpoint.Action GCMMessage_Action { get; set; }
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_APNSMessage_Badge")]
        public System.Int32 APNSMessage_Badge { get; set; }
        #endregion
        
        #region Parameter ADMMessage_Body
        /// <summary>
        /// <para>
        /// The message body of the notification, the email body
        /// or the text message.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SendUsersMessageRequest_MessageConfiguration_ADMMessage_Body")]
        public System.String ADMMessage_Body { get; set; }
        #endregion
        
        #region Parameter APNSMessage_Body
        /// <summary>
        /// <para>
        /// The message body of the notification, the email body
        /// or the text message.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SendUsersMessageRequest_MessageConfiguration_APNSMessage_Body")]
        public System.String APNSMessage_Body { get; set; }
        #endregion
        
        #region Parameter BaiduMessage_Body
        /// <summary>
        /// <para>
        /// The message body of the notification, the email body
        /// or the text message.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SendUsersMessageRequest_MessageConfiguration_BaiduMessage_Body")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_DefaultMessage_Body")]
        public System.String DefaultMessage_Body { get; set; }
        #endregion
        
        #region Parameter DefaultPushNotificationMessage_Body
        /// <summary>
        /// <para>
        /// The message body of the notification, the email body
        /// or the text message.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Body")]
        public System.String DefaultPushNotificationMessage_Body { get; set; }
        #endregion
        
        #region Parameter GCMMessage_Body
        /// <summary>
        /// <para>
        /// The message body of the notification, the email body
        /// or the text message.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SendUsersMessageRequest_MessageConfiguration_GCMMessage_Body")]
        public System.String GCMMessage_Body { get; set; }
        #endregion
        
        #region Parameter SMSMessage_Body
        /// <summary>
        /// <para>
        /// The body of the SMS message.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SendUsersMessageRequest_MessageConfiguration_SMSMessage_Body")]
        public System.String SMSMessage_Body { get; set; }
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_APNSMessage_Category")]
        public System.String APNSMessage_Category { get; set; }
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_APNSMessage_CollapseId")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_GCMMessage_CollapseKey")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_ADMMessage_ConsolidationKey")]
        public System.String ADMMessage_ConsolidationKey { get; set; }
        #endregion
        
        #region Parameter SendUsersMessageRequest_Context
        /// <summary>
        /// <para>
        /// A map of custom attribute-value pairs. Amazon
        /// Pinpoint adds these attributes to the data.pinpoint object in the body of the push
        /// notification payload. Amazon Pinpoint also provides these attributes in the events
        /// that it generates for users-messages deliveries.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Collections.Hashtable SendUsersMessageRequest_Context { get; set; }
        #endregion
        
        #region Parameter ADMMessage_Data
        /// <summary>
        /// <para>
        /// The data payload used for a silent push. This payload
        /// is added to the notifications' data.pinpoint.jsonBody' object
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SendUsersMessageRequest_MessageConfiguration_ADMMessage_Data")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_APNSMessage_Data")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_BaiduMessage_Data")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Data")]
        public System.Collections.Hashtable DefaultPushNotificationMessage_Data { get; set; }
        #endregion
        
        #region Parameter GCMMessage_Data
        /// <summary>
        /// <para>
        /// The data payload used for a silent push. This payload
        /// is added to the notifications' data.pinpoint.jsonBody' object
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SendUsersMessageRequest_MessageConfiguration_GCMMessage_Data")]
        public System.Collections.Hashtable GCMMessage_Data { get; set; }
        #endregion
        
        #region Parameter ADMMessage_ExpiresAfter
        /// <summary>
        /// <para>
        /// Optional. Number of seconds ADM should retain
        /// the message if the device is offline
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SendUsersMessageRequest_MessageConfiguration_ADMMessage_ExpiresAfter")]
        public System.String ADMMessage_ExpiresAfter { get; set; }
        #endregion
        
        #region Parameter ADMMessage_IconReference
        /// <summary>
        /// <para>
        /// The icon image name of the asset saved in
        /// your application.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SendUsersMessageRequest_MessageConfiguration_ADMMessage_IconReference")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_BaiduMessage_IconReference")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_GCMMessage_IconReference")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_ADMMessage_ImageIconUrl")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_BaiduMessage_ImageIconUrl")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_GCMMessage_ImageIconUrl")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_ADMMessage_ImageUrl")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_BaiduMessage_ImageUrl")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_GCMMessage_ImageUrl")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_SMSMessage_Keyword")]
        public System.String SMSMessage_Keyword { get; set; }
        #endregion
        
        #region Parameter ADMMessage_MD5
        /// <summary>
        /// <para>
        /// Optional. Base-64-encoded MD5 checksum of the data
        /// parameter. Used to verify data integrity
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SendUsersMessageRequest_MessageConfiguration_ADMMessage_MD5")]
        public System.String ADMMessage_MD5 { get; set; }
        #endregion
        
        #region Parameter APNSMessage_MediaUrl
        /// <summary>
        /// <para>
        /// The URL that points to a video used in the push
        /// notification.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SendUsersMessageRequest_MessageConfiguration_APNSMessage_MediaUrl")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_SMSMessage_MessageType")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_SMSMessage_OriginationNumber")]
        public System.String SMSMessage_OriginationNumber { get; set; }
        #endregion
        
        #region Parameter APNSMessage_PreferredAuthenticationMethod
        /// <summary>
        /// <para>
        /// The preferred authentication
        /// method, either "CERTIFICATE" or "TOKEN"
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SendUsersMessageRequest_MessageConfiguration_APNSMessage_PreferredAuthenticationMethod")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_APNSMessage_Priority")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_GCMMessage_Priority")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_ADMMessage_RawContent")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_APNSMessage_RawContent")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_BaiduMessage_RawContent")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_GCMMessage_RawContent")]
        public System.String GCMMessage_RawContent { get; set; }
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_GCMMessage_RestrictedPackageName")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_SMSMessage_SenderId")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_ADMMessage_SilentPush")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_APNSMessage_SilentPush")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_BaiduMessage_SilentPush")]
        public System.Boolean BaiduMessage_SilentPush { get; set; }
        #endregion
        
        #region Parameter DefaultPushNotificationMessage_SilentPush
        /// <summary>
        /// <para>
        /// Indicates if the message should display on
        /// the users device. Silent pushes can be used for Remote Configuration and Phone Home
        /// use cases.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_SilentPush")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_GCMMessage_SilentPush")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_ADMMessage_SmallImageIconUrl")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_BaiduMessage_SmallImageIconUrl")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_GCMMessage_SmallImageIconUrl")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_ADMMessage_Sound")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_APNSMessage_Sound")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_BaiduMessage_Sound")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_GCMMessage_Sound")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_ADMMessage_Substitutions")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_APNSMessage_Substitutions")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_BaiduMessage_Substitutions")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_DefaultMessage_Substitutions")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Substitutions")]
        public System.Collections.Hashtable DefaultPushNotificationMessage_Substitution { get; set; }
        #endregion
        
        #region Parameter GCMMessage_Substitution
        /// <summary>
        /// <para>
        /// Default message substitutions. Can be overridden
        /// by individual address substitutions.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SendUsersMessageRequest_MessageConfiguration_GCMMessage_Substitutions")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_SMSMessage_Substitutions")]
        public System.Collections.Hashtable SMSMessage_Substitution { get; set; }
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_APNSMessage_ThreadId")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_APNSMessage_TimeToLive")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_BaiduMessage_TimeToLive")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_GCMMessage_TimeToLive")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_ADMMessage_Title")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_APNSMessage_Title")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_BaiduMessage_Title")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Title")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_GCMMessage_Title")]
        public System.String GCMMessage_Title { get; set; }
        #endregion
        
        #region Parameter ADMMessage_Url
        /// <summary>
        /// <para>
        /// The URL to open in the user's mobile browser. Used
        /// if the value for Action is URL.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SendUsersMessageRequest_MessageConfiguration_ADMMessage_Url")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_APNSMessage_Url")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_BaiduMessage_Url")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Url")]
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
        [Alias("SendUsersMessageRequest_MessageConfiguration_GCMMessage_Url")]
        public System.String GCMMessage_Url { get; set; }
        #endregion
        
        #region Parameter SendUsersMessageRequest_User
        /// <summary>
        /// <para>
        /// A map that associates user IDs with EndpointSendConfiguration
        /// objects. Within an EndpointSendConfiguration object, you can tailor the message for
        /// a user by specifying message overrides or substitutions.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SendUsersMessageRequest_Users")]
        public System.Collections.Hashtable SendUsersMessageRequest_User { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-PINUserMessageBatch (SendUsersMessages)"))
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
            if (this.SendUsersMessageRequest_Context != null)
            {
                context.SendUsersMessageRequest_Context = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.SendUsersMessageRequest_Context.Keys)
                {
                    context.SendUsersMessageRequest_Context.Add((String)hashKey, (String)(this.SendUsersMessageRequest_Context[hashKey]));
                }
            }
            context.SendUsersMessageRequest_MessageConfiguration_ADMMessage_Action = this.ADMMessage_Action;
            context.SendUsersMessageRequest_MessageConfiguration_ADMMessage_Body = this.ADMMessage_Body;
            context.SendUsersMessageRequest_MessageConfiguration_ADMMessage_ConsolidationKey = this.ADMMessage_ConsolidationKey;
            if (this.ADMMessage_Data != null)
            {
                context.SendUsersMessageRequest_MessageConfiguration_ADMMessage_Data = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ADMMessage_Data.Keys)
                {
                    context.SendUsersMessageRequest_MessageConfiguration_ADMMessage_Data.Add((String)hashKey, (String)(this.ADMMessage_Data[hashKey]));
                }
            }
            context.SendUsersMessageRequest_MessageConfiguration_ADMMessage_ExpiresAfter = this.ADMMessage_ExpiresAfter;
            context.SendUsersMessageRequest_MessageConfiguration_ADMMessage_IconReference = this.ADMMessage_IconReference;
            context.SendUsersMessageRequest_MessageConfiguration_ADMMessage_ImageIconUrl = this.ADMMessage_ImageIconUrl;
            context.SendUsersMessageRequest_MessageConfiguration_ADMMessage_ImageUrl = this.ADMMessage_ImageUrl;
            context.SendUsersMessageRequest_MessageConfiguration_ADMMessage_MD5 = this.ADMMessage_MD5;
            context.SendUsersMessageRequest_MessageConfiguration_ADMMessage_RawContent = this.ADMMessage_RawContent;
            if (ParameterWasBound("ADMMessage_SilentPush"))
                context.SendUsersMessageRequest_MessageConfiguration_ADMMessage_SilentPush = this.ADMMessage_SilentPush;
            context.SendUsersMessageRequest_MessageConfiguration_ADMMessage_SmallImageIconUrl = this.ADMMessage_SmallImageIconUrl;
            context.SendUsersMessageRequest_MessageConfiguration_ADMMessage_Sound = this.ADMMessage_Sound;
            if (this.ADMMessage_Substitution != null)
            {
                context.SendUsersMessageRequest_MessageConfiguration_ADMMessage_Substitutions = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.ADMMessage_Substitution.Keys)
                {
                    object hashValue = this.ADMMessage_Substitution[hashKey];
                    if (hashValue == null)
                    {
                        context.SendUsersMessageRequest_MessageConfiguration_ADMMessage_Substitutions.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((String)s);
                    }
                    context.SendUsersMessageRequest_MessageConfiguration_ADMMessage_Substitutions.Add((String)hashKey, valueSet);
                }
            }
            context.SendUsersMessageRequest_MessageConfiguration_ADMMessage_Title = this.ADMMessage_Title;
            context.SendUsersMessageRequest_MessageConfiguration_ADMMessage_Url = this.ADMMessage_Url;
            context.SendUsersMessageRequest_MessageConfiguration_APNSMessage_Action = this.APNSMessage_Action;
            if (ParameterWasBound("APNSMessage_Badge"))
                context.SendUsersMessageRequest_MessageConfiguration_APNSMessage_Badge = this.APNSMessage_Badge;
            context.SendUsersMessageRequest_MessageConfiguration_APNSMessage_Body = this.APNSMessage_Body;
            context.SendUsersMessageRequest_MessageConfiguration_APNSMessage_Category = this.APNSMessage_Category;
            context.SendUsersMessageRequest_MessageConfiguration_APNSMessage_CollapseId = this.APNSMessage_CollapseId;
            if (this.APNSMessage_Data != null)
            {
                context.SendUsersMessageRequest_MessageConfiguration_APNSMessage_Data = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.APNSMessage_Data.Keys)
                {
                    context.SendUsersMessageRequest_MessageConfiguration_APNSMessage_Data.Add((String)hashKey, (String)(this.APNSMessage_Data[hashKey]));
                }
            }
            context.SendUsersMessageRequest_MessageConfiguration_APNSMessage_MediaUrl = this.APNSMessage_MediaUrl;
            context.SendUsersMessageRequest_MessageConfiguration_APNSMessage_PreferredAuthenticationMethod = this.APNSMessage_PreferredAuthenticationMethod;
            context.SendUsersMessageRequest_MessageConfiguration_APNSMessage_Priority = this.APNSMessage_Priority;
            context.SendUsersMessageRequest_MessageConfiguration_APNSMessage_RawContent = this.APNSMessage_RawContent;
            if (ParameterWasBound("APNSMessage_SilentPush"))
                context.SendUsersMessageRequest_MessageConfiguration_APNSMessage_SilentPush = this.APNSMessage_SilentPush;
            context.SendUsersMessageRequest_MessageConfiguration_APNSMessage_Sound = this.APNSMessage_Sound;
            if (this.APNSMessage_Substitution != null)
            {
                context.SendUsersMessageRequest_MessageConfiguration_APNSMessage_Substitutions = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.APNSMessage_Substitution.Keys)
                {
                    object hashValue = this.APNSMessage_Substitution[hashKey];
                    if (hashValue == null)
                    {
                        context.SendUsersMessageRequest_MessageConfiguration_APNSMessage_Substitutions.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((String)s);
                    }
                    context.SendUsersMessageRequest_MessageConfiguration_APNSMessage_Substitutions.Add((String)hashKey, valueSet);
                }
            }
            context.SendUsersMessageRequest_MessageConfiguration_APNSMessage_ThreadId = this.APNSMessage_ThreadId;
            if (ParameterWasBound("APNSMessage_TimeToLive"))
                context.SendUsersMessageRequest_MessageConfiguration_APNSMessage_TimeToLive = this.APNSMessage_TimeToLive;
            context.SendUsersMessageRequest_MessageConfiguration_APNSMessage_Title = this.APNSMessage_Title;
            context.SendUsersMessageRequest_MessageConfiguration_APNSMessage_Url = this.APNSMessage_Url;
            context.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_Action = this.BaiduMessage_Action;
            context.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_Body = this.BaiduMessage_Body;
            if (this.BaiduMessage_Data != null)
            {
                context.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_Data = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.BaiduMessage_Data.Keys)
                {
                    context.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_Data.Add((String)hashKey, (String)(this.BaiduMessage_Data[hashKey]));
                }
            }
            context.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_IconReference = this.BaiduMessage_IconReference;
            context.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_ImageIconUrl = this.BaiduMessage_ImageIconUrl;
            context.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_ImageUrl = this.BaiduMessage_ImageUrl;
            context.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_RawContent = this.BaiduMessage_RawContent;
            if (ParameterWasBound("BaiduMessage_SilentPush"))
                context.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_SilentPush = this.BaiduMessage_SilentPush;
            context.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_SmallImageIconUrl = this.BaiduMessage_SmallImageIconUrl;
            context.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_Sound = this.BaiduMessage_Sound;
            if (this.BaiduMessage_Substitution != null)
            {
                context.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_Substitutions = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.BaiduMessage_Substitution.Keys)
                {
                    object hashValue = this.BaiduMessage_Substitution[hashKey];
                    if (hashValue == null)
                    {
                        context.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_Substitutions.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((String)s);
                    }
                    context.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_Substitutions.Add((String)hashKey, valueSet);
                }
            }
            if (ParameterWasBound("BaiduMessage_TimeToLive"))
                context.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_TimeToLive = this.BaiduMessage_TimeToLive;
            context.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_Title = this.BaiduMessage_Title;
            context.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_Url = this.BaiduMessage_Url;
            context.SendUsersMessageRequest_MessageConfiguration_DefaultMessage_Body = this.DefaultMessage_Body;
            if (this.DefaultMessage_Substitution != null)
            {
                context.SendUsersMessageRequest_MessageConfiguration_DefaultMessage_Substitutions = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.DefaultMessage_Substitution.Keys)
                {
                    object hashValue = this.DefaultMessage_Substitution[hashKey];
                    if (hashValue == null)
                    {
                        context.SendUsersMessageRequest_MessageConfiguration_DefaultMessage_Substitutions.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((String)s);
                    }
                    context.SendUsersMessageRequest_MessageConfiguration_DefaultMessage_Substitutions.Add((String)hashKey, valueSet);
                }
            }
            context.SendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Action = this.DefaultPushNotificationMessage_Action;
            context.SendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Body = this.DefaultPushNotificationMessage_Body;
            if (this.DefaultPushNotificationMessage_Data != null)
            {
                context.SendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Data = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.DefaultPushNotificationMessage_Data.Keys)
                {
                    context.SendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Data.Add((String)hashKey, (String)(this.DefaultPushNotificationMessage_Data[hashKey]));
                }
            }
            if (ParameterWasBound("DefaultPushNotificationMessage_SilentPush"))
                context.SendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_SilentPush = this.DefaultPushNotificationMessage_SilentPush;
            if (this.DefaultPushNotificationMessage_Substitution != null)
            {
                context.SendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Substitutions = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.DefaultPushNotificationMessage_Substitution.Keys)
                {
                    object hashValue = this.DefaultPushNotificationMessage_Substitution[hashKey];
                    if (hashValue == null)
                    {
                        context.SendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Substitutions.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((String)s);
                    }
                    context.SendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Substitutions.Add((String)hashKey, valueSet);
                }
            }
            context.SendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Title = this.DefaultPushNotificationMessage_Title;
            context.SendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Url = this.DefaultPushNotificationMessage_Url;
            context.SendUsersMessageRequest_MessageConfiguration_GCMMessage_Action = this.GCMMessage_Action;
            context.SendUsersMessageRequest_MessageConfiguration_GCMMessage_Body = this.GCMMessage_Body;
            context.SendUsersMessageRequest_MessageConfiguration_GCMMessage_CollapseKey = this.GCMMessage_CollapseKey;
            if (this.GCMMessage_Data != null)
            {
                context.SendUsersMessageRequest_MessageConfiguration_GCMMessage_Data = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.GCMMessage_Data.Keys)
                {
                    context.SendUsersMessageRequest_MessageConfiguration_GCMMessage_Data.Add((String)hashKey, (String)(this.GCMMessage_Data[hashKey]));
                }
            }
            context.SendUsersMessageRequest_MessageConfiguration_GCMMessage_IconReference = this.GCMMessage_IconReference;
            context.SendUsersMessageRequest_MessageConfiguration_GCMMessage_ImageIconUrl = this.GCMMessage_ImageIconUrl;
            context.SendUsersMessageRequest_MessageConfiguration_GCMMessage_ImageUrl = this.GCMMessage_ImageUrl;
            context.SendUsersMessageRequest_MessageConfiguration_GCMMessage_Priority = this.GCMMessage_Priority;
            context.SendUsersMessageRequest_MessageConfiguration_GCMMessage_RawContent = this.GCMMessage_RawContent;
            context.SendUsersMessageRequest_MessageConfiguration_GCMMessage_RestrictedPackageName = this.GCMMessage_RestrictedPackageName;
            if (ParameterWasBound("GCMMessage_SilentPush"))
                context.SendUsersMessageRequest_MessageConfiguration_GCMMessage_SilentPush = this.GCMMessage_SilentPush;
            context.SendUsersMessageRequest_MessageConfiguration_GCMMessage_SmallImageIconUrl = this.GCMMessage_SmallImageIconUrl;
            context.SendUsersMessageRequest_MessageConfiguration_GCMMessage_Sound = this.GCMMessage_Sound;
            if (this.GCMMessage_Substitution != null)
            {
                context.SendUsersMessageRequest_MessageConfiguration_GCMMessage_Substitutions = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.GCMMessage_Substitution.Keys)
                {
                    object hashValue = this.GCMMessage_Substitution[hashKey];
                    if (hashValue == null)
                    {
                        context.SendUsersMessageRequest_MessageConfiguration_GCMMessage_Substitutions.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((String)s);
                    }
                    context.SendUsersMessageRequest_MessageConfiguration_GCMMessage_Substitutions.Add((String)hashKey, valueSet);
                }
            }
            if (ParameterWasBound("GCMMessage_TimeToLive"))
                context.SendUsersMessageRequest_MessageConfiguration_GCMMessage_TimeToLive = this.GCMMessage_TimeToLive;
            context.SendUsersMessageRequest_MessageConfiguration_GCMMessage_Title = this.GCMMessage_Title;
            context.SendUsersMessageRequest_MessageConfiguration_GCMMessage_Url = this.GCMMessage_Url;
            context.SendUsersMessageRequest_MessageConfiguration_SMSMessage_Body = this.SMSMessage_Body;
            context.SendUsersMessageRequest_MessageConfiguration_SMSMessage_Keyword = this.SMSMessage_Keyword;
            context.SendUsersMessageRequest_MessageConfiguration_SMSMessage_MessageType = this.SMSMessage_MessageType;
            context.SendUsersMessageRequest_MessageConfiguration_SMSMessage_OriginationNumber = this.SMSMessage_OriginationNumber;
            context.SendUsersMessageRequest_MessageConfiguration_SMSMessage_SenderId = this.SMSMessage_SenderId;
            if (this.SMSMessage_Substitution != null)
            {
                context.SendUsersMessageRequest_MessageConfiguration_SMSMessage_Substitutions = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.SMSMessage_Substitution.Keys)
                {
                    object hashValue = this.SMSMessage_Substitution[hashKey];
                    if (hashValue == null)
                    {
                        context.SendUsersMessageRequest_MessageConfiguration_SMSMessage_Substitutions.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((String)s);
                    }
                    context.SendUsersMessageRequest_MessageConfiguration_SMSMessage_Substitutions.Add((String)hashKey, valueSet);
                }
            }
            if (this.SendUsersMessageRequest_User != null)
            {
                context.SendUsersMessageRequest_Users = new Dictionary<System.String, Amazon.Pinpoint.Model.EndpointSendConfiguration>(StringComparer.Ordinal);
                foreach (var hashKey in this.SendUsersMessageRequest_User.Keys)
                {
                    context.SendUsersMessageRequest_Users.Add((String)hashKey, (EndpointSendConfiguration)(this.SendUsersMessageRequest_User[hashKey]));
                }
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
            var request = new Amazon.Pinpoint.Model.SendUsersMessagesRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            
             // populate SendUsersMessageRequest
            bool requestSendUsersMessageRequestIsNull = true;
            request.SendUsersMessageRequest = new Amazon.Pinpoint.Model.SendUsersMessageRequest();
            Dictionary<System.String, System.String> requestSendUsersMessageRequest_sendUsersMessageRequest_Context = null;
            if (cmdletContext.SendUsersMessageRequest_Context != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_Context = cmdletContext.SendUsersMessageRequest_Context;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_Context != null)
            {
                request.SendUsersMessageRequest.Context = requestSendUsersMessageRequest_sendUsersMessageRequest_Context;
                requestSendUsersMessageRequestIsNull = false;
            }
            Dictionary<System.String, Amazon.Pinpoint.Model.EndpointSendConfiguration> requestSendUsersMessageRequest_sendUsersMessageRequest_User = null;
            if (cmdletContext.SendUsersMessageRequest_Users != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_User = cmdletContext.SendUsersMessageRequest_Users;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_User != null)
            {
                request.SendUsersMessageRequest.Users = requestSendUsersMessageRequest_sendUsersMessageRequest_User;
                requestSendUsersMessageRequestIsNull = false;
            }
            Amazon.Pinpoint.Model.DirectMessageConfiguration requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration = null;
            
             // populate MessageConfiguration
            bool requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfigurationIsNull = true;
            requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration = new Amazon.Pinpoint.Model.DirectMessageConfiguration();
            Amazon.Pinpoint.Model.DefaultMessage requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultMessage = null;
            
             // populate DefaultMessage
            bool requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultMessageIsNull = true;
            requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultMessage = new Amazon.Pinpoint.Model.DefaultMessage();
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultMessage_defaultMessage_Body = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_DefaultMessage_Body != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultMessage_defaultMessage_Body = cmdletContext.SendUsersMessageRequest_MessageConfiguration_DefaultMessage_Body;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultMessage_defaultMessage_Body != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultMessage.Body = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultMessage_defaultMessage_Body;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultMessageIsNull = false;
            }
            Dictionary<System.String, List<System.String>> requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultMessage_defaultMessage_Substitution = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_DefaultMessage_Substitutions != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultMessage_defaultMessage_Substitution = cmdletContext.SendUsersMessageRequest_MessageConfiguration_DefaultMessage_Substitutions;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultMessage_defaultMessage_Substitution != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultMessage.Substitutions = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultMessage_defaultMessage_Substitution;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultMessageIsNull = false;
            }
             // determine if requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultMessage should be set to null
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultMessageIsNull)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultMessage = null;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultMessage != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration.DefaultMessage = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultMessage;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfigurationIsNull = false;
            }
            Amazon.Pinpoint.Model.SMSMessage requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessage = null;
            
             // populate SMSMessage
            bool requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessageIsNull = true;
            requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessage = new Amazon.Pinpoint.Model.SMSMessage();
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessage_sMSMessage_Body = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_SMSMessage_Body != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessage_sMSMessage_Body = cmdletContext.SendUsersMessageRequest_MessageConfiguration_SMSMessage_Body;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessage_sMSMessage_Body != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessage.Body = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessage_sMSMessage_Body;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessage_sMSMessage_Keyword = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_SMSMessage_Keyword != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessage_sMSMessage_Keyword = cmdletContext.SendUsersMessageRequest_MessageConfiguration_SMSMessage_Keyword;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessage_sMSMessage_Keyword != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessage.Keyword = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessage_sMSMessage_Keyword;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessageIsNull = false;
            }
            Amazon.Pinpoint.MessageType requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessage_sMSMessage_MessageType = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_SMSMessage_MessageType != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessage_sMSMessage_MessageType = cmdletContext.SendUsersMessageRequest_MessageConfiguration_SMSMessage_MessageType;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessage_sMSMessage_MessageType != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessage.MessageType = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessage_sMSMessage_MessageType;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessage_sMSMessage_OriginationNumber = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_SMSMessage_OriginationNumber != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessage_sMSMessage_OriginationNumber = cmdletContext.SendUsersMessageRequest_MessageConfiguration_SMSMessage_OriginationNumber;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessage_sMSMessage_OriginationNumber != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessage.OriginationNumber = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessage_sMSMessage_OriginationNumber;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessage_sMSMessage_SenderId = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_SMSMessage_SenderId != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessage_sMSMessage_SenderId = cmdletContext.SendUsersMessageRequest_MessageConfiguration_SMSMessage_SenderId;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessage_sMSMessage_SenderId != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessage.SenderId = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessage_sMSMessage_SenderId;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessageIsNull = false;
            }
            Dictionary<System.String, List<System.String>> requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessage_sMSMessage_Substitution = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_SMSMessage_Substitutions != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessage_sMSMessage_Substitution = cmdletContext.SendUsersMessageRequest_MessageConfiguration_SMSMessage_Substitutions;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessage_sMSMessage_Substitution != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessage.Substitutions = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessage_sMSMessage_Substitution;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessageIsNull = false;
            }
             // determine if requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessage should be set to null
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessageIsNull)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessage = null;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessage != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration.SMSMessage = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_SMSMessage;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfigurationIsNull = false;
            }
            Amazon.Pinpoint.Model.DefaultPushNotificationMessage requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage = null;
            
             // populate DefaultPushNotificationMessage
            bool requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessageIsNull = true;
            requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage = new Amazon.Pinpoint.Model.DefaultPushNotificationMessage();
            Amazon.Pinpoint.Action requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Action = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Action != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Action = cmdletContext.SendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Action;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Action != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage.Action = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Action;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Body = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Body != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Body = cmdletContext.SendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Body;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Body != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage.Body = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Body;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessageIsNull = false;
            }
            Dictionary<System.String, System.String> requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Data = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Data != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Data = cmdletContext.SendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Data;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Data != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage.Data = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Data;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessageIsNull = false;
            }
            System.Boolean? requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_SilentPush = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_SilentPush != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_SilentPush = cmdletContext.SendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_SilentPush.Value;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_SilentPush != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage.SilentPush = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_SilentPush.Value;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessageIsNull = false;
            }
            Dictionary<System.String, List<System.String>> requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Substitution = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Substitutions != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Substitution = cmdletContext.SendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Substitutions;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Substitution != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage.Substitutions = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Substitution;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Title = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Title != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Title = cmdletContext.SendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Title;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Title != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage.Title = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Title;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Url = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Url != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Url = cmdletContext.SendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Url;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Url != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage.Url = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_defaultPushNotificationMessage_Url;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessageIsNull = false;
            }
             // determine if requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage should be set to null
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessageIsNull)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage = null;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration.DefaultPushNotificationMessage = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfigurationIsNull = false;
            }
            Amazon.Pinpoint.Model.BaiduMessage requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage = null;
            
             // populate BaiduMessage
            bool requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessageIsNull = true;
            requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage = new Amazon.Pinpoint.Model.BaiduMessage();
            Amazon.Pinpoint.Action requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Action = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_Action != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Action = cmdletContext.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_Action;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Action != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage.Action = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Action;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Body = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_Body != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Body = cmdletContext.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_Body;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Body != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage.Body = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Body;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessageIsNull = false;
            }
            Dictionary<System.String, System.String> requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Data = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_Data != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Data = cmdletContext.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_Data;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Data != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage.Data = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Data;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_IconReference = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_IconReference != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_IconReference = cmdletContext.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_IconReference;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_IconReference != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage.IconReference = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_IconReference;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_ImageIconUrl = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_ImageIconUrl != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_ImageIconUrl = cmdletContext.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_ImageIconUrl;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_ImageIconUrl != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage.ImageIconUrl = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_ImageIconUrl;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_ImageUrl = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_ImageUrl != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_ImageUrl = cmdletContext.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_ImageUrl;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_ImageUrl != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage.ImageUrl = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_ImageUrl;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_RawContent = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_RawContent != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_RawContent = cmdletContext.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_RawContent;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_RawContent != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage.RawContent = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_RawContent;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessageIsNull = false;
            }
            System.Boolean? requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_SilentPush = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_SilentPush != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_SilentPush = cmdletContext.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_SilentPush.Value;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_SilentPush != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage.SilentPush = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_SilentPush.Value;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_SmallImageIconUrl = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_SmallImageIconUrl != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_SmallImageIconUrl = cmdletContext.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_SmallImageIconUrl;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_SmallImageIconUrl != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage.SmallImageIconUrl = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_SmallImageIconUrl;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Sound = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_Sound != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Sound = cmdletContext.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_Sound;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Sound != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage.Sound = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Sound;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessageIsNull = false;
            }
            Dictionary<System.String, List<System.String>> requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Substitution = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_Substitutions != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Substitution = cmdletContext.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_Substitutions;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Substitution != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage.Substitutions = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Substitution;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessageIsNull = false;
            }
            System.Int32? requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_TimeToLive = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_TimeToLive != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_TimeToLive = cmdletContext.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_TimeToLive.Value;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_TimeToLive != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage.TimeToLive = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_TimeToLive.Value;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Title = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_Title != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Title = cmdletContext.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_Title;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Title != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage.Title = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Title;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Url = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_Url != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Url = cmdletContext.SendUsersMessageRequest_MessageConfiguration_BaiduMessage_Url;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Url != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage.Url = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage_baiduMessage_Url;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessageIsNull = false;
            }
             // determine if requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage should be set to null
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessageIsNull)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage = null;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration.BaiduMessage = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_BaiduMessage;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfigurationIsNull = false;
            }
            Amazon.Pinpoint.Model.ADMMessage requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage = null;
            
             // populate ADMMessage
            bool requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessageIsNull = true;
            requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage = new Amazon.Pinpoint.Model.ADMMessage();
            Amazon.Pinpoint.Action requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_Action = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_ADMMessage_Action != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_Action = cmdletContext.SendUsersMessageRequest_MessageConfiguration_ADMMessage_Action;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_Action != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage.Action = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_Action;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_Body = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_ADMMessage_Body != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_Body = cmdletContext.SendUsersMessageRequest_MessageConfiguration_ADMMessage_Body;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_Body != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage.Body = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_Body;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_ConsolidationKey = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_ADMMessage_ConsolidationKey != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_ConsolidationKey = cmdletContext.SendUsersMessageRequest_MessageConfiguration_ADMMessage_ConsolidationKey;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_ConsolidationKey != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage.ConsolidationKey = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_ConsolidationKey;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessageIsNull = false;
            }
            Dictionary<System.String, System.String> requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_Data = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_ADMMessage_Data != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_Data = cmdletContext.SendUsersMessageRequest_MessageConfiguration_ADMMessage_Data;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_Data != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage.Data = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_Data;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_ExpiresAfter = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_ADMMessage_ExpiresAfter != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_ExpiresAfter = cmdletContext.SendUsersMessageRequest_MessageConfiguration_ADMMessage_ExpiresAfter;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_ExpiresAfter != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage.ExpiresAfter = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_ExpiresAfter;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_IconReference = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_ADMMessage_IconReference != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_IconReference = cmdletContext.SendUsersMessageRequest_MessageConfiguration_ADMMessage_IconReference;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_IconReference != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage.IconReference = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_IconReference;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_ImageIconUrl = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_ADMMessage_ImageIconUrl != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_ImageIconUrl = cmdletContext.SendUsersMessageRequest_MessageConfiguration_ADMMessage_ImageIconUrl;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_ImageIconUrl != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage.ImageIconUrl = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_ImageIconUrl;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_ImageUrl = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_ADMMessage_ImageUrl != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_ImageUrl = cmdletContext.SendUsersMessageRequest_MessageConfiguration_ADMMessage_ImageUrl;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_ImageUrl != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage.ImageUrl = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_ImageUrl;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_MD5 = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_ADMMessage_MD5 != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_MD5 = cmdletContext.SendUsersMessageRequest_MessageConfiguration_ADMMessage_MD5;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_MD5 != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage.MD5 = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_MD5;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_RawContent = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_ADMMessage_RawContent != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_RawContent = cmdletContext.SendUsersMessageRequest_MessageConfiguration_ADMMessage_RawContent;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_RawContent != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage.RawContent = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_RawContent;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessageIsNull = false;
            }
            System.Boolean? requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_SilentPush = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_ADMMessage_SilentPush != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_SilentPush = cmdletContext.SendUsersMessageRequest_MessageConfiguration_ADMMessage_SilentPush.Value;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_SilentPush != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage.SilentPush = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_SilentPush.Value;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_SmallImageIconUrl = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_ADMMessage_SmallImageIconUrl != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_SmallImageIconUrl = cmdletContext.SendUsersMessageRequest_MessageConfiguration_ADMMessage_SmallImageIconUrl;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_SmallImageIconUrl != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage.SmallImageIconUrl = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_SmallImageIconUrl;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_Sound = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_ADMMessage_Sound != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_Sound = cmdletContext.SendUsersMessageRequest_MessageConfiguration_ADMMessage_Sound;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_Sound != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage.Sound = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_Sound;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessageIsNull = false;
            }
            Dictionary<System.String, List<System.String>> requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_Substitution = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_ADMMessage_Substitutions != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_Substitution = cmdletContext.SendUsersMessageRequest_MessageConfiguration_ADMMessage_Substitutions;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_Substitution != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage.Substitutions = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_Substitution;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_Title = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_ADMMessage_Title != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_Title = cmdletContext.SendUsersMessageRequest_MessageConfiguration_ADMMessage_Title;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_Title != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage.Title = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_Title;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_Url = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_ADMMessage_Url != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_Url = cmdletContext.SendUsersMessageRequest_MessageConfiguration_ADMMessage_Url;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_Url != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage.Url = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage_aDMMessage_Url;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessageIsNull = false;
            }
             // determine if requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage should be set to null
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessageIsNull)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage = null;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration.ADMMessage = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_ADMMessage;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfigurationIsNull = false;
            }
            Amazon.Pinpoint.Model.APNSMessage requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage = null;
            
             // populate APNSMessage
            bool requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessageIsNull = true;
            requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage = new Amazon.Pinpoint.Model.APNSMessage();
            Amazon.Pinpoint.Action requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Action = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_APNSMessage_Action != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Action = cmdletContext.SendUsersMessageRequest_MessageConfiguration_APNSMessage_Action;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Action != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage.Action = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Action;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessageIsNull = false;
            }
            System.Int32? requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Badge = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_APNSMessage_Badge != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Badge = cmdletContext.SendUsersMessageRequest_MessageConfiguration_APNSMessage_Badge.Value;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Badge != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage.Badge = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Badge.Value;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Body = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_APNSMessage_Body != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Body = cmdletContext.SendUsersMessageRequest_MessageConfiguration_APNSMessage_Body;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Body != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage.Body = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Body;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Category = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_APNSMessage_Category != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Category = cmdletContext.SendUsersMessageRequest_MessageConfiguration_APNSMessage_Category;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Category != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage.Category = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Category;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_CollapseId = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_APNSMessage_CollapseId != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_CollapseId = cmdletContext.SendUsersMessageRequest_MessageConfiguration_APNSMessage_CollapseId;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_CollapseId != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage.CollapseId = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_CollapseId;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessageIsNull = false;
            }
            Dictionary<System.String, System.String> requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Data = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_APNSMessage_Data != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Data = cmdletContext.SendUsersMessageRequest_MessageConfiguration_APNSMessage_Data;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Data != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage.Data = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Data;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_MediaUrl = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_APNSMessage_MediaUrl != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_MediaUrl = cmdletContext.SendUsersMessageRequest_MessageConfiguration_APNSMessage_MediaUrl;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_MediaUrl != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage.MediaUrl = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_MediaUrl;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_PreferredAuthenticationMethod = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_APNSMessage_PreferredAuthenticationMethod != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_PreferredAuthenticationMethod = cmdletContext.SendUsersMessageRequest_MessageConfiguration_APNSMessage_PreferredAuthenticationMethod;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_PreferredAuthenticationMethod != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage.PreferredAuthenticationMethod = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_PreferredAuthenticationMethod;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Priority = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_APNSMessage_Priority != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Priority = cmdletContext.SendUsersMessageRequest_MessageConfiguration_APNSMessage_Priority;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Priority != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage.Priority = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Priority;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_RawContent = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_APNSMessage_RawContent != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_RawContent = cmdletContext.SendUsersMessageRequest_MessageConfiguration_APNSMessage_RawContent;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_RawContent != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage.RawContent = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_RawContent;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessageIsNull = false;
            }
            System.Boolean? requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_SilentPush = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_APNSMessage_SilentPush != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_SilentPush = cmdletContext.SendUsersMessageRequest_MessageConfiguration_APNSMessage_SilentPush.Value;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_SilentPush != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage.SilentPush = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_SilentPush.Value;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Sound = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_APNSMessage_Sound != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Sound = cmdletContext.SendUsersMessageRequest_MessageConfiguration_APNSMessage_Sound;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Sound != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage.Sound = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Sound;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessageIsNull = false;
            }
            Dictionary<System.String, List<System.String>> requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Substitution = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_APNSMessage_Substitutions != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Substitution = cmdletContext.SendUsersMessageRequest_MessageConfiguration_APNSMessage_Substitutions;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Substitution != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage.Substitutions = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Substitution;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_ThreadId = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_APNSMessage_ThreadId != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_ThreadId = cmdletContext.SendUsersMessageRequest_MessageConfiguration_APNSMessage_ThreadId;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_ThreadId != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage.ThreadId = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_ThreadId;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessageIsNull = false;
            }
            System.Int32? requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_TimeToLive = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_APNSMessage_TimeToLive != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_TimeToLive = cmdletContext.SendUsersMessageRequest_MessageConfiguration_APNSMessage_TimeToLive.Value;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_TimeToLive != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage.TimeToLive = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_TimeToLive.Value;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Title = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_APNSMessage_Title != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Title = cmdletContext.SendUsersMessageRequest_MessageConfiguration_APNSMessage_Title;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Title != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage.Title = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Title;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Url = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_APNSMessage_Url != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Url = cmdletContext.SendUsersMessageRequest_MessageConfiguration_APNSMessage_Url;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Url != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage.Url = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage_aPNSMessage_Url;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessageIsNull = false;
            }
             // determine if requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage should be set to null
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessageIsNull)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage = null;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration.APNSMessage = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_APNSMessage;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfigurationIsNull = false;
            }
            Amazon.Pinpoint.Model.GCMMessage requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage = null;
            
             // populate GCMMessage
            bool requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessageIsNull = true;
            requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage = new Amazon.Pinpoint.Model.GCMMessage();
            Amazon.Pinpoint.Action requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_Action = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_GCMMessage_Action != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_Action = cmdletContext.SendUsersMessageRequest_MessageConfiguration_GCMMessage_Action;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_Action != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage.Action = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_Action;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_Body = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_GCMMessage_Body != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_Body = cmdletContext.SendUsersMessageRequest_MessageConfiguration_GCMMessage_Body;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_Body != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage.Body = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_Body;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_CollapseKey = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_GCMMessage_CollapseKey != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_CollapseKey = cmdletContext.SendUsersMessageRequest_MessageConfiguration_GCMMessage_CollapseKey;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_CollapseKey != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage.CollapseKey = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_CollapseKey;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessageIsNull = false;
            }
            Dictionary<System.String, System.String> requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_Data = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_GCMMessage_Data != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_Data = cmdletContext.SendUsersMessageRequest_MessageConfiguration_GCMMessage_Data;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_Data != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage.Data = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_Data;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_IconReference = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_GCMMessage_IconReference != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_IconReference = cmdletContext.SendUsersMessageRequest_MessageConfiguration_GCMMessage_IconReference;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_IconReference != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage.IconReference = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_IconReference;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageIconUrl = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_GCMMessage_ImageIconUrl != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageIconUrl = cmdletContext.SendUsersMessageRequest_MessageConfiguration_GCMMessage_ImageIconUrl;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageIconUrl != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage.ImageIconUrl = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageIconUrl;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageUrl = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_GCMMessage_ImageUrl != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageUrl = cmdletContext.SendUsersMessageRequest_MessageConfiguration_GCMMessage_ImageUrl;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageUrl != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage.ImageUrl = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_ImageUrl;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_Priority = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_GCMMessage_Priority != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_Priority = cmdletContext.SendUsersMessageRequest_MessageConfiguration_GCMMessage_Priority;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_Priority != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage.Priority = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_Priority;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_RawContent = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_GCMMessage_RawContent != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_RawContent = cmdletContext.SendUsersMessageRequest_MessageConfiguration_GCMMessage_RawContent;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_RawContent != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage.RawContent = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_RawContent;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_RestrictedPackageName = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_GCMMessage_RestrictedPackageName != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_RestrictedPackageName = cmdletContext.SendUsersMessageRequest_MessageConfiguration_GCMMessage_RestrictedPackageName;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_RestrictedPackageName != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage.RestrictedPackageName = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_RestrictedPackageName;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessageIsNull = false;
            }
            System.Boolean? requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_SilentPush = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_GCMMessage_SilentPush != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_SilentPush = cmdletContext.SendUsersMessageRequest_MessageConfiguration_GCMMessage_SilentPush.Value;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_SilentPush != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage.SilentPush = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_SilentPush.Value;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_SmallImageIconUrl = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_GCMMessage_SmallImageIconUrl != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_SmallImageIconUrl = cmdletContext.SendUsersMessageRequest_MessageConfiguration_GCMMessage_SmallImageIconUrl;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_SmallImageIconUrl != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage.SmallImageIconUrl = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_SmallImageIconUrl;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_Sound = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_GCMMessage_Sound != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_Sound = cmdletContext.SendUsersMessageRequest_MessageConfiguration_GCMMessage_Sound;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_Sound != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage.Sound = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_Sound;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessageIsNull = false;
            }
            Dictionary<System.String, List<System.String>> requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_Substitution = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_GCMMessage_Substitutions != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_Substitution = cmdletContext.SendUsersMessageRequest_MessageConfiguration_GCMMessage_Substitutions;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_Substitution != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage.Substitutions = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_Substitution;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessageIsNull = false;
            }
            System.Int32? requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_TimeToLive = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_GCMMessage_TimeToLive != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_TimeToLive = cmdletContext.SendUsersMessageRequest_MessageConfiguration_GCMMessage_TimeToLive.Value;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_TimeToLive != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage.TimeToLive = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_TimeToLive.Value;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_Title = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_GCMMessage_Title != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_Title = cmdletContext.SendUsersMessageRequest_MessageConfiguration_GCMMessage_Title;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_Title != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage.Title = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_Title;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessageIsNull = false;
            }
            System.String requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_Url = null;
            if (cmdletContext.SendUsersMessageRequest_MessageConfiguration_GCMMessage_Url != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_Url = cmdletContext.SendUsersMessageRequest_MessageConfiguration_GCMMessage_Url;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_Url != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage.Url = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage_gCMMessage_Url;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessageIsNull = false;
            }
             // determine if requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage should be set to null
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessageIsNull)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage = null;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage != null)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration.GCMMessage = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration_sendUsersMessageRequest_MessageConfiguration_GCMMessage;
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfigurationIsNull = false;
            }
             // determine if requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration should be set to null
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfigurationIsNull)
            {
                requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration = null;
            }
            if (requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration != null)
            {
                request.SendUsersMessageRequest.MessageConfiguration = requestSendUsersMessageRequest_sendUsersMessageRequest_MessageConfiguration;
                requestSendUsersMessageRequestIsNull = false;
            }
             // determine if request.SendUsersMessageRequest should be set to null
            if (requestSendUsersMessageRequestIsNull)
            {
                request.SendUsersMessageRequest = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.SendUsersMessageResponse;
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
        
        private Amazon.Pinpoint.Model.SendUsersMessagesResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.SendUsersMessagesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "SendUsersMessages");
            try
            {
                #if DESKTOP
                return client.SendUsersMessages(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.SendUsersMessagesAsync(request);
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
            public Dictionary<System.String, System.String> SendUsersMessageRequest_Context { get; set; }
            public Amazon.Pinpoint.Action SendUsersMessageRequest_MessageConfiguration_ADMMessage_Action { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_ADMMessage_Body { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_ADMMessage_ConsolidationKey { get; set; }
            public Dictionary<System.String, System.String> SendUsersMessageRequest_MessageConfiguration_ADMMessage_Data { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_ADMMessage_ExpiresAfter { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_ADMMessage_IconReference { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_ADMMessage_ImageIconUrl { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_ADMMessage_ImageUrl { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_ADMMessage_MD5 { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_ADMMessage_RawContent { get; set; }
            public System.Boolean? SendUsersMessageRequest_MessageConfiguration_ADMMessage_SilentPush { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_ADMMessage_SmallImageIconUrl { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_ADMMessage_Sound { get; set; }
            public Dictionary<System.String, List<System.String>> SendUsersMessageRequest_MessageConfiguration_ADMMessage_Substitutions { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_ADMMessage_Title { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_ADMMessage_Url { get; set; }
            public Amazon.Pinpoint.Action SendUsersMessageRequest_MessageConfiguration_APNSMessage_Action { get; set; }
            public System.Int32? SendUsersMessageRequest_MessageConfiguration_APNSMessage_Badge { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_APNSMessage_Body { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_APNSMessage_Category { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_APNSMessage_CollapseId { get; set; }
            public Dictionary<System.String, System.String> SendUsersMessageRequest_MessageConfiguration_APNSMessage_Data { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_APNSMessage_MediaUrl { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_APNSMessage_PreferredAuthenticationMethod { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_APNSMessage_Priority { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_APNSMessage_RawContent { get; set; }
            public System.Boolean? SendUsersMessageRequest_MessageConfiguration_APNSMessage_SilentPush { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_APNSMessage_Sound { get; set; }
            public Dictionary<System.String, List<System.String>> SendUsersMessageRequest_MessageConfiguration_APNSMessage_Substitutions { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_APNSMessage_ThreadId { get; set; }
            public System.Int32? SendUsersMessageRequest_MessageConfiguration_APNSMessage_TimeToLive { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_APNSMessage_Title { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_APNSMessage_Url { get; set; }
            public Amazon.Pinpoint.Action SendUsersMessageRequest_MessageConfiguration_BaiduMessage_Action { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_BaiduMessage_Body { get; set; }
            public Dictionary<System.String, System.String> SendUsersMessageRequest_MessageConfiguration_BaiduMessage_Data { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_BaiduMessage_IconReference { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_BaiduMessage_ImageIconUrl { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_BaiduMessage_ImageUrl { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_BaiduMessage_RawContent { get; set; }
            public System.Boolean? SendUsersMessageRequest_MessageConfiguration_BaiduMessage_SilentPush { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_BaiduMessage_SmallImageIconUrl { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_BaiduMessage_Sound { get; set; }
            public Dictionary<System.String, List<System.String>> SendUsersMessageRequest_MessageConfiguration_BaiduMessage_Substitutions { get; set; }
            public System.Int32? SendUsersMessageRequest_MessageConfiguration_BaiduMessage_TimeToLive { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_BaiduMessage_Title { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_BaiduMessage_Url { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_DefaultMessage_Body { get; set; }
            public Dictionary<System.String, List<System.String>> SendUsersMessageRequest_MessageConfiguration_DefaultMessage_Substitutions { get; set; }
            public Amazon.Pinpoint.Action SendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Action { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Body { get; set; }
            public Dictionary<System.String, System.String> SendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Data { get; set; }
            public System.Boolean? SendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_SilentPush { get; set; }
            public Dictionary<System.String, List<System.String>> SendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Substitutions { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Title { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Url { get; set; }
            public Amazon.Pinpoint.Action SendUsersMessageRequest_MessageConfiguration_GCMMessage_Action { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_GCMMessage_Body { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_GCMMessage_CollapseKey { get; set; }
            public Dictionary<System.String, System.String> SendUsersMessageRequest_MessageConfiguration_GCMMessage_Data { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_GCMMessage_IconReference { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_GCMMessage_ImageIconUrl { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_GCMMessage_ImageUrl { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_GCMMessage_Priority { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_GCMMessage_RawContent { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_GCMMessage_RestrictedPackageName { get; set; }
            public System.Boolean? SendUsersMessageRequest_MessageConfiguration_GCMMessage_SilentPush { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_GCMMessage_SmallImageIconUrl { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_GCMMessage_Sound { get; set; }
            public Dictionary<System.String, List<System.String>> SendUsersMessageRequest_MessageConfiguration_GCMMessage_Substitutions { get; set; }
            public System.Int32? SendUsersMessageRequest_MessageConfiguration_GCMMessage_TimeToLive { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_GCMMessage_Title { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_GCMMessage_Url { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_SMSMessage_Body { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_SMSMessage_Keyword { get; set; }
            public Amazon.Pinpoint.MessageType SendUsersMessageRequest_MessageConfiguration_SMSMessage_MessageType { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_SMSMessage_OriginationNumber { get; set; }
            public System.String SendUsersMessageRequest_MessageConfiguration_SMSMessage_SenderId { get; set; }
            public Dictionary<System.String, List<System.String>> SendUsersMessageRequest_MessageConfiguration_SMSMessage_Substitutions { get; set; }
            public Dictionary<System.String, Amazon.Pinpoint.Model.EndpointSendConfiguration> SendUsersMessageRequest_Users { get; set; }
        }
        
    }
}
