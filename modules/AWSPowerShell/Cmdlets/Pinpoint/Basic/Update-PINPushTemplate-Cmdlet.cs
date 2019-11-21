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
    /// Updates an existing message template that you can use in messages that are sent through
    /// a push notification channel.
    /// </summary>
    [Cmdlet("Update", "PINPushTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.MessageBody")]
    [AWSCmdlet("Calls the Amazon Pinpoint UpdatePushTemplate API operation.", Operation = new[] {"UpdatePushTemplate"}, SelectReturnType = typeof(Amazon.Pinpoint.Model.UpdatePushTemplateResponse))]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.MessageBody or Amazon.Pinpoint.Model.UpdatePushTemplateResponse",
        "This cmdlet returns an Amazon.Pinpoint.Model.MessageBody object.",
        "The service call response (type Amazon.Pinpoint.Model.UpdatePushTemplateResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdatePINPushTemplateCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
        #region Parameter ADM_Action
        /// <summary>
        /// <para>
        /// <para>The action to occur if a recipient taps a push notification that's based on the message
        /// template. Valid values are:</para><ul><li><para>OPEN_APP - Your app opens or it becomes the foreground app if it was sent to the background.
        /// This is the default action.</para></li><li><para>DEEP_LINK - Your app opens and displays a designated user interface in the app. This
        /// action uses the deep-linking features of the Android platform.</para></li><li><para>URL - The default mobile browser on the recipient's device opens and loads the web
        /// page at a URL that you specify.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PushNotificationTemplateRequest_ADM_Action")]
        [AWSConstantClassSource("Amazon.Pinpoint.Action")]
        public Amazon.Pinpoint.Action ADM_Action { get; set; }
        #endregion
        
        #region Parameter APNS_Action
        /// <summary>
        /// <para>
        /// <para>The action to occur if a recipient taps a push notification that's based on the message
        /// template. Valid values are:</para><ul><li><para>OPEN_APP - Your app opens or it becomes the foreground app if it was sent to the background.
        /// This is the default action.</para></li><li><para>DEEP_LINK - Your app opens and displays a designated user interface in the app. This
        /// setting uses the deep-linking features of the iOS platform.</para></li><li><para>URL - The default mobile browser on the recipient's device opens and loads the web
        /// page at a URL that you specify.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PushNotificationTemplateRequest_APNS_Action")]
        [AWSConstantClassSource("Amazon.Pinpoint.Action")]
        public Amazon.Pinpoint.Action APNS_Action { get; set; }
        #endregion
        
        #region Parameter Baidu_Action
        /// <summary>
        /// <para>
        /// <para>The action to occur if a recipient taps a push notification that's based on the message
        /// template. Valid values are:</para><ul><li><para>OPEN_APP - Your app opens or it becomes the foreground app if it was sent to the background.
        /// This is the default action.</para></li><li><para>DEEP_LINK - Your app opens and displays a designated user interface in the app. This
        /// action uses the deep-linking features of the Android platform.</para></li><li><para>URL - The default mobile browser on the recipient's device opens and loads the web
        /// page at a URL that you specify.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PushNotificationTemplateRequest_Baidu_Action")]
        [AWSConstantClassSource("Amazon.Pinpoint.Action")]
        public Amazon.Pinpoint.Action Baidu_Action { get; set; }
        #endregion
        
        #region Parameter Default_Action
        /// <summary>
        /// <para>
        /// <para>The action to occur if a recipient taps a push notification that's based on the message
        /// template. Valid values are:</para><ul><li><para>OPEN_APP - Your app opens or it becomes the foreground app if it was sent to the background.
        /// This is the default action.</para></li><li><para>DEEP_LINK - Your app opens and displays a designated user interface in the app. This
        /// setting uses the deep-linking features of the iOS and Android platforms.</para></li><li><para>URL - The default mobile browser on the recipient's device opens and loads the web
        /// page at a URL that you specify.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PushNotificationTemplateRequest_Default_Action")]
        [AWSConstantClassSource("Amazon.Pinpoint.Action")]
        public Amazon.Pinpoint.Action Default_Action { get; set; }
        #endregion
        
        #region Parameter GCM_Action
        /// <summary>
        /// <para>
        /// <para>The action to occur if a recipient taps a push notification that's based on the message
        /// template. Valid values are:</para><ul><li><para>OPEN_APP - Your app opens or it becomes the foreground app if it was sent to the background.
        /// This is the default action.</para></li><li><para>DEEP_LINK - Your app opens and displays a designated user interface in the app. This
        /// action uses the deep-linking features of the Android platform.</para></li><li><para>URL - The default mobile browser on the recipient's device opens and loads the web
        /// page at a URL that you specify.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PushNotificationTemplateRequest_GCM_Action")]
        [AWSConstantClassSource("Amazon.Pinpoint.Action")]
        public Amazon.Pinpoint.Action GCM_Action { get; set; }
        #endregion
        
        #region Parameter ADM_Body
        /// <summary>
        /// <para>
        /// <para>The message body to use in a push notification that's based on the message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PushNotificationTemplateRequest_ADM_Body")]
        public System.String ADM_Body { get; set; }
        #endregion
        
        #region Parameter APNS_Body
        /// <summary>
        /// <para>
        /// <para>The message body to use in push notifications that are based on the message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PushNotificationTemplateRequest_APNS_Body")]
        public System.String APNS_Body { get; set; }
        #endregion
        
        #region Parameter Baidu_Body
        /// <summary>
        /// <para>
        /// <para>The message body to use in a push notification that's based on the message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PushNotificationTemplateRequest_Baidu_Body")]
        public System.String Baidu_Body { get; set; }
        #endregion
        
        #region Parameter Default_Body
        /// <summary>
        /// <para>
        /// <para>The message body to use in push notifications that are based on the message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PushNotificationTemplateRequest_Default_Body")]
        public System.String Default_Body { get; set; }
        #endregion
        
        #region Parameter GCM_Body
        /// <summary>
        /// <para>
        /// <para>The message body to use in a push notification that's based on the message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PushNotificationTemplateRequest_GCM_Body")]
        public System.String GCM_Body { get; set; }
        #endregion
        
        #region Parameter ADM_ImageIconUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the large icon image to display in the content view of a push notification
        /// that's based on the message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PushNotificationTemplateRequest_ADM_ImageIconUrl")]
        public System.String ADM_ImageIconUrl { get; set; }
        #endregion
        
        #region Parameter Baidu_ImageIconUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the large icon image to display in the content view of a push notification
        /// that's based on the message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PushNotificationTemplateRequest_Baidu_ImageIconUrl")]
        public System.String Baidu_ImageIconUrl { get; set; }
        #endregion
        
        #region Parameter GCM_ImageIconUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the large icon image to display in the content view of a push notification
        /// that's based on the message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PushNotificationTemplateRequest_GCM_ImageIconUrl")]
        public System.String GCM_ImageIconUrl { get; set; }
        #endregion
        
        #region Parameter ADM_ImageUrl
        /// <summary>
        /// <para>
        /// <para>The URL of an image to display in a push notification that's based on the message
        /// template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PushNotificationTemplateRequest_ADM_ImageUrl")]
        public System.String ADM_ImageUrl { get; set; }
        #endregion
        
        #region Parameter Baidu_ImageUrl
        /// <summary>
        /// <para>
        /// <para>The URL of an image to display in a push notification that's based on the message
        /// template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PushNotificationTemplateRequest_Baidu_ImageUrl")]
        public System.String Baidu_ImageUrl { get; set; }
        #endregion
        
        #region Parameter GCM_ImageUrl
        /// <summary>
        /// <para>
        /// <para>The URL of an image to display in a push notification that's based on the message
        /// template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PushNotificationTemplateRequest_GCM_ImageUrl")]
        public System.String GCM_ImageUrl { get; set; }
        #endregion
        
        #region Parameter APNS_MediaUrl
        /// <summary>
        /// <para>
        /// <para>The URL of an image or video to display in push notifications that are based on the
        /// message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PushNotificationTemplateRequest_APNS_MediaUrl")]
        public System.String APNS_MediaUrl { get; set; }
        #endregion
        
        #region Parameter ADM_SmallImageIconUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the small icon image to display in the status bar and the content view
        /// of a push notification that's based on the message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PushNotificationTemplateRequest_ADM_SmallImageIconUrl")]
        public System.String ADM_SmallImageIconUrl { get; set; }
        #endregion
        
        #region Parameter Baidu_SmallImageIconUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the small icon image to display in the status bar and the content view
        /// of a push notification that's based on the message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PushNotificationTemplateRequest_Baidu_SmallImageIconUrl")]
        public System.String Baidu_SmallImageIconUrl { get; set; }
        #endregion
        
        #region Parameter GCM_SmallImageIconUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the small icon image to display in the status bar and the content view
        /// of a push notification that's based on the message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PushNotificationTemplateRequest_GCM_SmallImageIconUrl")]
        public System.String GCM_SmallImageIconUrl { get; set; }
        #endregion
        
        #region Parameter ADM_Sound
        /// <summary>
        /// <para>
        /// <para>The sound to play when a recipient receives a push notification that's based on the
        /// message template. You can use the default stream or specify the file name of a sound
        /// resource that's bundled in your app. On an Android platform, the sound file must reside
        /// in /res/raw/.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PushNotificationTemplateRequest_ADM_Sound")]
        public System.String ADM_Sound { get; set; }
        #endregion
        
        #region Parameter APNS_Sound
        /// <summary>
        /// <para>
        /// <para>The key for the sound to play when the recipient receives a push notification that's
        /// based on the message template. The value for this key is the name of a sound file
        /// in your app's main bundle or the Library/Sounds folder in your app's data container.
        /// If the sound file can't be found or you specify default for the value, the system
        /// plays the default alert sound.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PushNotificationTemplateRequest_APNS_Sound")]
        public System.String APNS_Sound { get; set; }
        #endregion
        
        #region Parameter Baidu_Sound
        /// <summary>
        /// <para>
        /// <para>The sound to play when a recipient receives a push notification that's based on the
        /// message template. You can use the default stream or specify the file name of a sound
        /// resource that's bundled in your app. On an Android platform, the sound file must reside
        /// in /res/raw/.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PushNotificationTemplateRequest_Baidu_Sound")]
        public System.String Baidu_Sound { get; set; }
        #endregion
        
        #region Parameter Default_Sound
        /// <summary>
        /// <para>
        /// <para>The sound to play when a recipient receives a push notification that's based on the
        /// message template. You can use the default stream or specify the file name of a sound
        /// resource that's bundled in your app. On an Android platform, the sound file must reside
        /// in /res/raw/.</para><para>For an iOS platform, this value is the key for the name of a sound file in your app's
        /// main bundle or the Library/Sounds folder in your app's data container. If the sound
        /// file can't be found or you specify default for the value, the system plays the default
        /// alert sound.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PushNotificationTemplateRequest_Default_Sound")]
        public System.String Default_Sound { get; set; }
        #endregion
        
        #region Parameter GCM_Sound
        /// <summary>
        /// <para>
        /// <para>The sound to play when a recipient receives a push notification that's based on the
        /// message template. You can use the default stream or specify the file name of a sound
        /// resource that's bundled in your app. On an Android platform, the sound file must reside
        /// in /res/raw/.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PushNotificationTemplateRequest_GCM_Sound")]
        public System.String GCM_Sound { get; set; }
        #endregion
        
        #region Parameter PushNotificationTemplateRequest_Tag
        /// <summary>
        /// <para>
        /// <para>A string-to-string map of key-value pairs that defines the tags to associate with
        /// the message template. Each tag consists of a required tag key and an associated tag
        /// value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PushNotificationTemplateRequest_Tags")]
        public System.Collections.Hashtable PushNotificationTemplateRequest_Tag { get; set; }
        #endregion
        
        #region Parameter TemplateName
        /// <summary>
        /// <para>
        /// <para>The name of the message template. A template name must start with an alphanumeric
        /// character and can contain a maximum of 128 characters. The characters can be alphanumeric
        /// characters, underscores (_), or hyphens (-). Template names are case sensitive.</para>
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
        public System.String TemplateName { get; set; }
        #endregion
        
        #region Parameter ADM_Title
        /// <summary>
        /// <para>
        /// <para>The title to use in a push notification that's based on the message template. This
        /// title appears above the notification message on a recipient's device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PushNotificationTemplateRequest_ADM_Title")]
        public System.String ADM_Title { get; set; }
        #endregion
        
        #region Parameter APNS_Title
        /// <summary>
        /// <para>
        /// <para>The title to use in push notifications that are based on the message template. This
        /// title appears above the notification message on a recipient's device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PushNotificationTemplateRequest_APNS_Title")]
        public System.String APNS_Title { get; set; }
        #endregion
        
        #region Parameter Baidu_Title
        /// <summary>
        /// <para>
        /// <para>The title to use in a push notification that's based on the message template. This
        /// title appears above the notification message on a recipient's device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PushNotificationTemplateRequest_Baidu_Title")]
        public System.String Baidu_Title { get; set; }
        #endregion
        
        #region Parameter Default_Title
        /// <summary>
        /// <para>
        /// <para>The title to use in push notifications that are based on the message template. This
        /// title appears above the notification message on a recipient's device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PushNotificationTemplateRequest_Default_Title")]
        public System.String Default_Title { get; set; }
        #endregion
        
        #region Parameter GCM_Title
        /// <summary>
        /// <para>
        /// <para>The title to use in a push notification that's based on the message template. This
        /// title appears above the notification message on a recipient's device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PushNotificationTemplateRequest_GCM_Title")]
        public System.String GCM_Title { get; set; }
        #endregion
        
        #region Parameter ADM_Url
        /// <summary>
        /// <para>
        /// <para>The URL to open in a recipient's default mobile browser, if a recipient taps a a push
        /// notification that's based on the message template and the value of the Action property
        /// is URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PushNotificationTemplateRequest_ADM_Url")]
        public System.String ADM_Url { get; set; }
        #endregion
        
        #region Parameter APNS_Url
        /// <summary>
        /// <para>
        /// <para>The URL to open in the recipient's default mobile browser, if a recipient taps a push
        /// notification that's based on the message template and the value of the Action property
        /// is URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PushNotificationTemplateRequest_APNS_Url")]
        public System.String APNS_Url { get; set; }
        #endregion
        
        #region Parameter Baidu_Url
        /// <summary>
        /// <para>
        /// <para>The URL to open in a recipient's default mobile browser, if a recipient taps a a push
        /// notification that's based on the message template and the value of the Action property
        /// is URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PushNotificationTemplateRequest_Baidu_Url")]
        public System.String Baidu_Url { get; set; }
        #endregion
        
        #region Parameter Default_Url
        /// <summary>
        /// <para>
        /// <para>The URL to open in a recipient's default mobile browser, if a recipient taps a push
        /// notification that's based on the message template and the value of the Action property
        /// is URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PushNotificationTemplateRequest_Default_Url")]
        public System.String Default_Url { get; set; }
        #endregion
        
        #region Parameter GCM_Url
        /// <summary>
        /// <para>
        /// <para>The URL to open in a recipient's default mobile browser, if a recipient taps a a push
        /// notification that's based on the message template and the value of the Action property
        /// is URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PushNotificationTemplateRequest_GCM_Url")]
        public System.String GCM_Url { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MessageBody'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Pinpoint.Model.UpdatePushTemplateResponse).
        /// Specifying the name of a property of type Amazon.Pinpoint.Model.UpdatePushTemplateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MessageBody";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TemplateName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TemplateName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TemplateName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TemplateName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PINPushTemplate (UpdatePushTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Pinpoint.Model.UpdatePushTemplateResponse, UpdatePINPushTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TemplateName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ADM_Action = this.ADM_Action;
            context.ADM_Body = this.ADM_Body;
            context.ADM_ImageIconUrl = this.ADM_ImageIconUrl;
            context.ADM_ImageUrl = this.ADM_ImageUrl;
            context.ADM_SmallImageIconUrl = this.ADM_SmallImageIconUrl;
            context.ADM_Sound = this.ADM_Sound;
            context.ADM_Title = this.ADM_Title;
            context.ADM_Url = this.ADM_Url;
            context.APNS_Action = this.APNS_Action;
            context.APNS_Body = this.APNS_Body;
            context.APNS_MediaUrl = this.APNS_MediaUrl;
            context.APNS_Sound = this.APNS_Sound;
            context.APNS_Title = this.APNS_Title;
            context.APNS_Url = this.APNS_Url;
            context.Baidu_Action = this.Baidu_Action;
            context.Baidu_Body = this.Baidu_Body;
            context.Baidu_ImageIconUrl = this.Baidu_ImageIconUrl;
            context.Baidu_ImageUrl = this.Baidu_ImageUrl;
            context.Baidu_SmallImageIconUrl = this.Baidu_SmallImageIconUrl;
            context.Baidu_Sound = this.Baidu_Sound;
            context.Baidu_Title = this.Baidu_Title;
            context.Baidu_Url = this.Baidu_Url;
            context.Default_Action = this.Default_Action;
            context.Default_Body = this.Default_Body;
            context.Default_Sound = this.Default_Sound;
            context.Default_Title = this.Default_Title;
            context.Default_Url = this.Default_Url;
            context.GCM_Action = this.GCM_Action;
            context.GCM_Body = this.GCM_Body;
            context.GCM_ImageIconUrl = this.GCM_ImageIconUrl;
            context.GCM_ImageUrl = this.GCM_ImageUrl;
            context.GCM_SmallImageIconUrl = this.GCM_SmallImageIconUrl;
            context.GCM_Sound = this.GCM_Sound;
            context.GCM_Title = this.GCM_Title;
            context.GCM_Url = this.GCM_Url;
            if (this.PushNotificationTemplateRequest_Tag != null)
            {
                context.PushNotificationTemplateRequest_Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.PushNotificationTemplateRequest_Tag.Keys)
                {
                    context.PushNotificationTemplateRequest_Tag.Add((String)hashKey, (String)(this.PushNotificationTemplateRequest_Tag[hashKey]));
                }
            }
            context.TemplateName = this.TemplateName;
            #if MODULAR
            if (this.TemplateName == null && ParameterWasBound(nameof(this.TemplateName)))
            {
                WriteWarning("You are passing $null as a value for parameter TemplateName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Pinpoint.Model.UpdatePushTemplateRequest();
            
            
             // populate PushNotificationTemplateRequest
            var requestPushNotificationTemplateRequestIsNull = true;
            request.PushNotificationTemplateRequest = new Amazon.Pinpoint.Model.PushNotificationTemplateRequest();
            Dictionary<System.String, System.String> requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Tag = null;
            if (cmdletContext.PushNotificationTemplateRequest_Tag != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Tag = cmdletContext.PushNotificationTemplateRequest_Tag;
            }
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Tag != null)
            {
                request.PushNotificationTemplateRequest.Tags = requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Tag;
                requestPushNotificationTemplateRequestIsNull = false;
            }
            Amazon.Pinpoint.Model.DefaultPushNotificationTemplate requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Default = null;
            
             // populate Default
            var requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_DefaultIsNull = true;
            requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Default = new Amazon.Pinpoint.Model.DefaultPushNotificationTemplate();
            Amazon.Pinpoint.Action requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Default_default_Action = null;
            if (cmdletContext.Default_Action != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Default_default_Action = cmdletContext.Default_Action;
            }
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Default_default_Action != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Default.Action = requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Default_default_Action;
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_DefaultIsNull = false;
            }
            System.String requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Default_default_Body = null;
            if (cmdletContext.Default_Body != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Default_default_Body = cmdletContext.Default_Body;
            }
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Default_default_Body != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Default.Body = requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Default_default_Body;
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_DefaultIsNull = false;
            }
            System.String requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Default_default_Sound = null;
            if (cmdletContext.Default_Sound != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Default_default_Sound = cmdletContext.Default_Sound;
            }
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Default_default_Sound != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Default.Sound = requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Default_default_Sound;
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_DefaultIsNull = false;
            }
            System.String requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Default_default_Title = null;
            if (cmdletContext.Default_Title != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Default_default_Title = cmdletContext.Default_Title;
            }
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Default_default_Title != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Default.Title = requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Default_default_Title;
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_DefaultIsNull = false;
            }
            System.String requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Default_default_Url = null;
            if (cmdletContext.Default_Url != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Default_default_Url = cmdletContext.Default_Url;
            }
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Default_default_Url != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Default.Url = requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Default_default_Url;
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_DefaultIsNull = false;
            }
             // determine if requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Default should be set to null
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_DefaultIsNull)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Default = null;
            }
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Default != null)
            {
                request.PushNotificationTemplateRequest.Default = requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Default;
                requestPushNotificationTemplateRequestIsNull = false;
            }
            Amazon.Pinpoint.Model.APNSPushNotificationTemplate requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNS = null;
            
             // populate APNS
            var requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNSIsNull = true;
            requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNS = new Amazon.Pinpoint.Model.APNSPushNotificationTemplate();
            Amazon.Pinpoint.Action requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNS_aPNS_Action = null;
            if (cmdletContext.APNS_Action != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNS_aPNS_Action = cmdletContext.APNS_Action;
            }
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNS_aPNS_Action != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNS.Action = requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNS_aPNS_Action;
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNSIsNull = false;
            }
            System.String requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNS_aPNS_Body = null;
            if (cmdletContext.APNS_Body != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNS_aPNS_Body = cmdletContext.APNS_Body;
            }
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNS_aPNS_Body != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNS.Body = requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNS_aPNS_Body;
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNSIsNull = false;
            }
            System.String requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNS_aPNS_MediaUrl = null;
            if (cmdletContext.APNS_MediaUrl != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNS_aPNS_MediaUrl = cmdletContext.APNS_MediaUrl;
            }
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNS_aPNS_MediaUrl != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNS.MediaUrl = requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNS_aPNS_MediaUrl;
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNSIsNull = false;
            }
            System.String requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNS_aPNS_Sound = null;
            if (cmdletContext.APNS_Sound != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNS_aPNS_Sound = cmdletContext.APNS_Sound;
            }
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNS_aPNS_Sound != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNS.Sound = requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNS_aPNS_Sound;
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNSIsNull = false;
            }
            System.String requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNS_aPNS_Title = null;
            if (cmdletContext.APNS_Title != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNS_aPNS_Title = cmdletContext.APNS_Title;
            }
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNS_aPNS_Title != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNS.Title = requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNS_aPNS_Title;
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNSIsNull = false;
            }
            System.String requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNS_aPNS_Url = null;
            if (cmdletContext.APNS_Url != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNS_aPNS_Url = cmdletContext.APNS_Url;
            }
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNS_aPNS_Url != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNS.Url = requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNS_aPNS_Url;
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNSIsNull = false;
            }
             // determine if requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNS should be set to null
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNSIsNull)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNS = null;
            }
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNS != null)
            {
                request.PushNotificationTemplateRequest.APNS = requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_APNS;
                requestPushNotificationTemplateRequestIsNull = false;
            }
            Amazon.Pinpoint.Model.AndroidPushNotificationTemplate requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM = null;
            
             // populate ADM
            var requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADMIsNull = true;
            requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM = new Amazon.Pinpoint.Model.AndroidPushNotificationTemplate();
            Amazon.Pinpoint.Action requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM_aDM_Action = null;
            if (cmdletContext.ADM_Action != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM_aDM_Action = cmdletContext.ADM_Action;
            }
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM_aDM_Action != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM.Action = requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM_aDM_Action;
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADMIsNull = false;
            }
            System.String requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM_aDM_Body = null;
            if (cmdletContext.ADM_Body != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM_aDM_Body = cmdletContext.ADM_Body;
            }
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM_aDM_Body != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM.Body = requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM_aDM_Body;
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADMIsNull = false;
            }
            System.String requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM_aDM_ImageIconUrl = null;
            if (cmdletContext.ADM_ImageIconUrl != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM_aDM_ImageIconUrl = cmdletContext.ADM_ImageIconUrl;
            }
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM_aDM_ImageIconUrl != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM.ImageIconUrl = requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM_aDM_ImageIconUrl;
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADMIsNull = false;
            }
            System.String requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM_aDM_ImageUrl = null;
            if (cmdletContext.ADM_ImageUrl != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM_aDM_ImageUrl = cmdletContext.ADM_ImageUrl;
            }
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM_aDM_ImageUrl != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM.ImageUrl = requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM_aDM_ImageUrl;
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADMIsNull = false;
            }
            System.String requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM_aDM_SmallImageIconUrl = null;
            if (cmdletContext.ADM_SmallImageIconUrl != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM_aDM_SmallImageIconUrl = cmdletContext.ADM_SmallImageIconUrl;
            }
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM_aDM_SmallImageIconUrl != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM.SmallImageIconUrl = requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM_aDM_SmallImageIconUrl;
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADMIsNull = false;
            }
            System.String requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM_aDM_Sound = null;
            if (cmdletContext.ADM_Sound != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM_aDM_Sound = cmdletContext.ADM_Sound;
            }
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM_aDM_Sound != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM.Sound = requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM_aDM_Sound;
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADMIsNull = false;
            }
            System.String requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM_aDM_Title = null;
            if (cmdletContext.ADM_Title != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM_aDM_Title = cmdletContext.ADM_Title;
            }
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM_aDM_Title != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM.Title = requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM_aDM_Title;
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADMIsNull = false;
            }
            System.String requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM_aDM_Url = null;
            if (cmdletContext.ADM_Url != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM_aDM_Url = cmdletContext.ADM_Url;
            }
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM_aDM_Url != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM.Url = requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM_aDM_Url;
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADMIsNull = false;
            }
             // determine if requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM should be set to null
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADMIsNull)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM = null;
            }
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM != null)
            {
                request.PushNotificationTemplateRequest.ADM = requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_ADM;
                requestPushNotificationTemplateRequestIsNull = false;
            }
            Amazon.Pinpoint.Model.AndroidPushNotificationTemplate requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu = null;
            
             // populate Baidu
            var requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_BaiduIsNull = true;
            requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu = new Amazon.Pinpoint.Model.AndroidPushNotificationTemplate();
            Amazon.Pinpoint.Action requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu_baidu_Action = null;
            if (cmdletContext.Baidu_Action != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu_baidu_Action = cmdletContext.Baidu_Action;
            }
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu_baidu_Action != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu.Action = requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu_baidu_Action;
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_BaiduIsNull = false;
            }
            System.String requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu_baidu_Body = null;
            if (cmdletContext.Baidu_Body != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu_baidu_Body = cmdletContext.Baidu_Body;
            }
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu_baidu_Body != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu.Body = requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu_baidu_Body;
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_BaiduIsNull = false;
            }
            System.String requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu_baidu_ImageIconUrl = null;
            if (cmdletContext.Baidu_ImageIconUrl != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu_baidu_ImageIconUrl = cmdletContext.Baidu_ImageIconUrl;
            }
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu_baidu_ImageIconUrl != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu.ImageIconUrl = requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu_baidu_ImageIconUrl;
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_BaiduIsNull = false;
            }
            System.String requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu_baidu_ImageUrl = null;
            if (cmdletContext.Baidu_ImageUrl != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu_baidu_ImageUrl = cmdletContext.Baidu_ImageUrl;
            }
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu_baidu_ImageUrl != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu.ImageUrl = requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu_baidu_ImageUrl;
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_BaiduIsNull = false;
            }
            System.String requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu_baidu_SmallImageIconUrl = null;
            if (cmdletContext.Baidu_SmallImageIconUrl != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu_baidu_SmallImageIconUrl = cmdletContext.Baidu_SmallImageIconUrl;
            }
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu_baidu_SmallImageIconUrl != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu.SmallImageIconUrl = requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu_baidu_SmallImageIconUrl;
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_BaiduIsNull = false;
            }
            System.String requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu_baidu_Sound = null;
            if (cmdletContext.Baidu_Sound != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu_baidu_Sound = cmdletContext.Baidu_Sound;
            }
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu_baidu_Sound != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu.Sound = requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu_baidu_Sound;
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_BaiduIsNull = false;
            }
            System.String requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu_baidu_Title = null;
            if (cmdletContext.Baidu_Title != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu_baidu_Title = cmdletContext.Baidu_Title;
            }
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu_baidu_Title != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu.Title = requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu_baidu_Title;
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_BaiduIsNull = false;
            }
            System.String requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu_baidu_Url = null;
            if (cmdletContext.Baidu_Url != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu_baidu_Url = cmdletContext.Baidu_Url;
            }
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu_baidu_Url != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu.Url = requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu_baidu_Url;
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_BaiduIsNull = false;
            }
             // determine if requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu should be set to null
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_BaiduIsNull)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu = null;
            }
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu != null)
            {
                request.PushNotificationTemplateRequest.Baidu = requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_Baidu;
                requestPushNotificationTemplateRequestIsNull = false;
            }
            Amazon.Pinpoint.Model.AndroidPushNotificationTemplate requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM = null;
            
             // populate GCM
            var requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCMIsNull = true;
            requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM = new Amazon.Pinpoint.Model.AndroidPushNotificationTemplate();
            Amazon.Pinpoint.Action requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM_gCM_Action = null;
            if (cmdletContext.GCM_Action != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM_gCM_Action = cmdletContext.GCM_Action;
            }
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM_gCM_Action != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM.Action = requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM_gCM_Action;
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCMIsNull = false;
            }
            System.String requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM_gCM_Body = null;
            if (cmdletContext.GCM_Body != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM_gCM_Body = cmdletContext.GCM_Body;
            }
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM_gCM_Body != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM.Body = requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM_gCM_Body;
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCMIsNull = false;
            }
            System.String requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM_gCM_ImageIconUrl = null;
            if (cmdletContext.GCM_ImageIconUrl != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM_gCM_ImageIconUrl = cmdletContext.GCM_ImageIconUrl;
            }
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM_gCM_ImageIconUrl != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM.ImageIconUrl = requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM_gCM_ImageIconUrl;
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCMIsNull = false;
            }
            System.String requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM_gCM_ImageUrl = null;
            if (cmdletContext.GCM_ImageUrl != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM_gCM_ImageUrl = cmdletContext.GCM_ImageUrl;
            }
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM_gCM_ImageUrl != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM.ImageUrl = requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM_gCM_ImageUrl;
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCMIsNull = false;
            }
            System.String requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM_gCM_SmallImageIconUrl = null;
            if (cmdletContext.GCM_SmallImageIconUrl != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM_gCM_SmallImageIconUrl = cmdletContext.GCM_SmallImageIconUrl;
            }
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM_gCM_SmallImageIconUrl != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM.SmallImageIconUrl = requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM_gCM_SmallImageIconUrl;
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCMIsNull = false;
            }
            System.String requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM_gCM_Sound = null;
            if (cmdletContext.GCM_Sound != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM_gCM_Sound = cmdletContext.GCM_Sound;
            }
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM_gCM_Sound != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM.Sound = requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM_gCM_Sound;
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCMIsNull = false;
            }
            System.String requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM_gCM_Title = null;
            if (cmdletContext.GCM_Title != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM_gCM_Title = cmdletContext.GCM_Title;
            }
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM_gCM_Title != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM.Title = requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM_gCM_Title;
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCMIsNull = false;
            }
            System.String requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM_gCM_Url = null;
            if (cmdletContext.GCM_Url != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM_gCM_Url = cmdletContext.GCM_Url;
            }
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM_gCM_Url != null)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM.Url = requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM_gCM_Url;
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCMIsNull = false;
            }
             // determine if requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM should be set to null
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCMIsNull)
            {
                requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM = null;
            }
            if (requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM != null)
            {
                request.PushNotificationTemplateRequest.GCM = requestPushNotificationTemplateRequest_pushNotificationTemplateRequest_GCM;
                requestPushNotificationTemplateRequestIsNull = false;
            }
             // determine if request.PushNotificationTemplateRequest should be set to null
            if (requestPushNotificationTemplateRequestIsNull)
            {
                request.PushNotificationTemplateRequest = null;
            }
            if (cmdletContext.TemplateName != null)
            {
                request.TemplateName = cmdletContext.TemplateName;
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
        
        private Amazon.Pinpoint.Model.UpdatePushTemplateResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.UpdatePushTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "UpdatePushTemplate");
            try
            {
                #if DESKTOP
                return client.UpdatePushTemplate(request);
                #elif CORECLR
                return client.UpdatePushTemplateAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Pinpoint.Action ADM_Action { get; set; }
            public System.String ADM_Body { get; set; }
            public System.String ADM_ImageIconUrl { get; set; }
            public System.String ADM_ImageUrl { get; set; }
            public System.String ADM_SmallImageIconUrl { get; set; }
            public System.String ADM_Sound { get; set; }
            public System.String ADM_Title { get; set; }
            public System.String ADM_Url { get; set; }
            public Amazon.Pinpoint.Action APNS_Action { get; set; }
            public System.String APNS_Body { get; set; }
            public System.String APNS_MediaUrl { get; set; }
            public System.String APNS_Sound { get; set; }
            public System.String APNS_Title { get; set; }
            public System.String APNS_Url { get; set; }
            public Amazon.Pinpoint.Action Baidu_Action { get; set; }
            public System.String Baidu_Body { get; set; }
            public System.String Baidu_ImageIconUrl { get; set; }
            public System.String Baidu_ImageUrl { get; set; }
            public System.String Baidu_SmallImageIconUrl { get; set; }
            public System.String Baidu_Sound { get; set; }
            public System.String Baidu_Title { get; set; }
            public System.String Baidu_Url { get; set; }
            public Amazon.Pinpoint.Action Default_Action { get; set; }
            public System.String Default_Body { get; set; }
            public System.String Default_Sound { get; set; }
            public System.String Default_Title { get; set; }
            public System.String Default_Url { get; set; }
            public Amazon.Pinpoint.Action GCM_Action { get; set; }
            public System.String GCM_Body { get; set; }
            public System.String GCM_ImageIconUrl { get; set; }
            public System.String GCM_ImageUrl { get; set; }
            public System.String GCM_SmallImageIconUrl { get; set; }
            public System.String GCM_Sound { get; set; }
            public System.String GCM_Title { get; set; }
            public System.String GCM_Url { get; set; }
            public Dictionary<System.String, System.String> PushNotificationTemplateRequest_Tag { get; set; }
            public System.String TemplateName { get; set; }
            public System.Func<Amazon.Pinpoint.Model.UpdatePushTemplateResponse, UpdatePINPushTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MessageBody;
        }
        
    }
}
