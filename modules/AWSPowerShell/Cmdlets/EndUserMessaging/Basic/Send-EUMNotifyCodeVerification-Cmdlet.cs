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
using System.Threading;
using Amazon.EndUserMessaging;
using Amazon.EndUserMessaging.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EUM
{
    /// <summary>
    /// Generates a one-time passcode and delivers it to a recipient over the requested channel.
    /// The passcode policy is captured from the referenced notify code configuration at the
    /// time of the request, so later updates to the configuration do not affect verifications
    /// that are already in progress.
    /// </summary>
    [Cmdlet("Send", "EUMNotifyCodeVerification", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EndUserMessaging.Model.SendNotifyCodeVerificationResponse")]
    [AWSCmdlet("Calls the AWS End User Messaging SendNotifyCodeVerification API operation.", Operation = new[] {"SendNotifyCodeVerification"}, SelectReturnType = typeof(Amazon.EndUserMessaging.Model.SendNotifyCodeVerificationResponse))]
    [AWSCmdletOutput("Amazon.EndUserMessaging.Model.SendNotifyCodeVerificationResponse",
        "This cmdlet returns an Amazon.EndUserMessaging.Model.SendNotifyCodeVerificationResponse object containing multiple properties."
    )]
    public partial class SendEUMNotifyCodeVerificationCmdlet : AmazonEndUserMessagingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Channel
        /// <summary>
        /// <para>
        /// <para>The channel used to deliver the one-time passcode to the recipient.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.EndUserMessaging.NotifyChannel")]
        public Amazon.EndUserMessaging.NotifyChannel Channel { get; set; }
        #endregion
        
        #region Parameter OverrideCodeConfigurationParameters_CodeLength
        /// <summary>
        /// <para>
        /// <para>The number of characters in the one-time passcode. Valid values range from 4 through
        /// 8. When you do not specify a value, the default is applied when a passcode is sent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? OverrideCodeConfigurationParameters_CodeLength { get; set; }
        #endregion
        
        #region Parameter OverrideCodeConfigurationParameters_CodeType
        /// <summary>
        /// <para>
        /// <para>The character set used to generate the one-time passcode. Valid values are NUMERIC
        /// (digits only), ALPHA (uppercase letters only), and ALPHANUMERIC (uppercase letters
        /// and digits). When you do not specify a value, the default is applied when a passcode
        /// is sent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EndUserMessaging.CodeType")]
        public Amazon.EndUserMessaging.CodeType OverrideCodeConfigurationParameters_CodeType { get; set; }
        #endregion
        
        #region Parameter ConfigurationSetName
        /// <summary>
        /// <para>
        /// <para>The name of the configuration set used to control how delivery events for the message
        /// are handled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConfigurationSetName { get; set; }
        #endregion
        
        #region Parameter Context
        /// <summary>
        /// <para>
        /// <para>A map of custom key and value pairs that are propagated to the delivery events for
        /// this verification.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable Context { get; set; }
        #endregion
        
        #region Parameter OverrideChannelParameters_Text_DestinationCountryParameter
        /// <summary>
        /// <para>
        /// <para>A map of country-specific parameters that control one-time passcode delivery.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OverrideChannelParameters_Text_DestinationCountryParameters")]
        public System.Collections.Hashtable OverrideChannelParameters_Text_DestinationCountryParameter { get; set; }
        #endregion
        
        #region Parameter DestinationIdentity
        /// <summary>
        /// <para>
        /// <para>The recipient identifier. For the TEXT and VOICE channels, specify an E.164 phone
        /// number. For the WhatsApp channel, specify a WhatsApp address.</para>
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
        public System.String DestinationIdentity { get; set; }
        #endregion
        
        #region Parameter OverrideChannelParameters_Text_InlineTemplateBody
        /// <summary>
        /// <para>
        /// <para>The freeform message template used to render the one-time passcode for the SMS or
        /// RCS channels. The template must contain the code placeholder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OverrideChannelParameters_Text_InlineTemplateBody { get; set; }
        #endregion
        
        #region Parameter OverrideChannelParameters_Voice_InlineTemplateBody
        /// <summary>
        /// <para>
        /// <para>The freeform message template used to render the one-time passcode for the voice channel.
        /// The template must contain the code placeholder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OverrideChannelParameters_Voice_InlineTemplateBody { get; set; }
        #endregion
        
        #region Parameter OverrideChannelParameters_Voice_LanguageCode
        /// <summary>
        /// <para>
        /// <para>The BCP 47 language code used to render the voice message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OverrideChannelParameters_Voice_LanguageCode { get; set; }
        #endregion
        
        #region Parameter OverrideChannelParameters_WhatsApp_LanguageCode
        /// <summary>
        /// <para>
        /// <para>The BCP 47 language code used to render the template. This value is required for the
        /// WhatsApp channel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OverrideChannelParameters_WhatsApp_LanguageCode { get; set; }
        #endregion
        
        #region Parameter OverrideCodeConfigurationParameters_MaxAttempt
        /// <summary>
        /// <para>
        /// <para>The maximum number of validation attempts that are allowed before the verification
        /// is locked. Valid values range from 1 through 5. When you do not specify a value, the
        /// default is applied when a passcode is sent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OverrideCodeConfigurationParameters_MaxAttempts")]
        public System.Int32? OverrideCodeConfigurationParameters_MaxAttempt { get; set; }
        #endregion
        
        #region Parameter NotifyCodeConfiguration
        /// <summary>
        /// <para>
        /// <para>The identifier or Amazon Resource Name (ARN) of the notify code configuration that
        /// supplies the passcode policy and template defaults. When you do not specify a configuration,
        /// you must supply the template in the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NotifyCodeConfiguration { get; set; }
        #endregion
        
        #region Parameter OverrideChannelParameters_Notify_NotifyTemplateId
        /// <summary>
        /// <para>
        /// <para>The identifier of a preapproved notify template for the SMS or voice channels.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OverrideChannelParameters_Notify_NotifyTemplateId { get; set; }
        #endregion
        
        #region Parameter OriginationIdentity
        /// <summary>
        /// <para>
        /// <para>The identity used to send the message, such as a phone number, sender ID, or pool
        /// that is owned by your account.</para>
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
        public System.String OriginationIdentity { get; set; }
        #endregion
        
        #region Parameter ReferenceId
        /// <summary>
        /// <para>
        /// <para>A caller-supplied reference identifier that binds a send request to a later validate
        /// request. Specify the same value in both requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReferenceId { get; set; }
        #endregion
        
        #region Parameter OverrideCodeConfigurationParameters_ValidityPeriodMinute
        /// <summary>
        /// <para>
        /// <para>The length of time, in minutes, that the one-time passcode remains valid. Valid values
        /// range from 1 through 60. When you do not specify a value, the default is applied when
        /// a passcode is sent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OverrideCodeConfigurationParameters_ValidityPeriodMinutes")]
        public System.Int32? OverrideCodeConfigurationParameters_ValidityPeriodMinute { get; set; }
        #endregion
        
        #region Parameter OverrideChannelParameters_Notify_VoiceId
        /// <summary>
        /// <para>
        /// <para>The Amazon Polly voice ID used when the notify template is delivered over the voice
        /// channel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OverrideChannelParameters_Notify_VoiceId { get; set; }
        #endregion
        
        #region Parameter OverrideChannelParameters_Voice_VoiceId
        /// <summary>
        /// <para>
        /// <para>The Amazon Polly voice ID used for the voice channel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OverrideChannelParameters_Voice_VoiceId { get; set; }
        #endregion
        
        #region Parameter OverrideChannelParameters_Voice_VoiceMessageBodyTextType
        /// <summary>
        /// <para>
        /// <para>The format of the voice message body. Valid values are TEXT and SSML.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EndUserMessaging.VoiceMessageBodyTextType")]
        public Amazon.EndUserMessaging.VoiceMessageBodyTextType OverrideChannelParameters_Voice_VoiceMessageBodyTextType { get; set; }
        #endregion
        
        #region Parameter OverrideChannelParameters_WhatsApp_WhatsAppTemplateName
        /// <summary>
        /// <para>
        /// <para>The name of the Meta-approved WhatsApp authentication template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OverrideChannelParameters_WhatsApp_WhatsAppTemplateName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EndUserMessaging.Model.SendNotifyCodeVerificationResponse).
        /// Specifying the name of a property of type Amazon.EndUserMessaging.Model.SendNotifyCodeVerificationResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-EUMNotifyCodeVerification (SendNotifyCodeVerification)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EndUserMessaging.Model.SendNotifyCodeVerificationResponse, SendEUMNotifyCodeVerificationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Channel = this.Channel;
            #if MODULAR
            if (this.Channel == null && ParameterWasBound(nameof(this.Channel)))
            {
                WriteWarning("You are passing $null as a value for parameter Channel which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ConfigurationSetName = this.ConfigurationSetName;
            if (this.Context != null)
            {
                context.Context = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Context.Keys)
                {
                    context.Context.Add((String)hashKey, (System.String)(this.Context[hashKey]));
                }
            }
            context.DestinationIdentity = this.DestinationIdentity;
            #if MODULAR
            if (this.DestinationIdentity == null && ParameterWasBound(nameof(this.DestinationIdentity)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationIdentity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NotifyCodeConfiguration = this.NotifyCodeConfiguration;
            context.OriginationIdentity = this.OriginationIdentity;
            #if MODULAR
            if (this.OriginationIdentity == null && ParameterWasBound(nameof(this.OriginationIdentity)))
            {
                WriteWarning("You are passing $null as a value for parameter OriginationIdentity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OverrideChannelParameters_Notify_NotifyTemplateId = this.OverrideChannelParameters_Notify_NotifyTemplateId;
            context.OverrideChannelParameters_Notify_VoiceId = this.OverrideChannelParameters_Notify_VoiceId;
            if (this.OverrideChannelParameters_Text_DestinationCountryParameter != null)
            {
                context.OverrideChannelParameters_Text_DestinationCountryParameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.OverrideChannelParameters_Text_DestinationCountryParameter.Keys)
                {
                    context.OverrideChannelParameters_Text_DestinationCountryParameter.Add((String)hashKey, (System.String)(this.OverrideChannelParameters_Text_DestinationCountryParameter[hashKey]));
                }
            }
            context.OverrideChannelParameters_Text_InlineTemplateBody = this.OverrideChannelParameters_Text_InlineTemplateBody;
            context.OverrideChannelParameters_Voice_InlineTemplateBody = this.OverrideChannelParameters_Voice_InlineTemplateBody;
            context.OverrideChannelParameters_Voice_LanguageCode = this.OverrideChannelParameters_Voice_LanguageCode;
            context.OverrideChannelParameters_Voice_VoiceId = this.OverrideChannelParameters_Voice_VoiceId;
            context.OverrideChannelParameters_Voice_VoiceMessageBodyTextType = this.OverrideChannelParameters_Voice_VoiceMessageBodyTextType;
            context.OverrideChannelParameters_WhatsApp_LanguageCode = this.OverrideChannelParameters_WhatsApp_LanguageCode;
            context.OverrideChannelParameters_WhatsApp_WhatsAppTemplateName = this.OverrideChannelParameters_WhatsApp_WhatsAppTemplateName;
            context.OverrideCodeConfigurationParameters_CodeLength = this.OverrideCodeConfigurationParameters_CodeLength;
            context.OverrideCodeConfigurationParameters_CodeType = this.OverrideCodeConfigurationParameters_CodeType;
            context.OverrideCodeConfigurationParameters_MaxAttempt = this.OverrideCodeConfigurationParameters_MaxAttempt;
            context.OverrideCodeConfigurationParameters_ValidityPeriodMinute = this.OverrideCodeConfigurationParameters_ValidityPeriodMinute;
            context.ReferenceId = this.ReferenceId;
            
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
            var request = new Amazon.EndUserMessaging.Model.SendNotifyCodeVerificationRequest();
            
            if (cmdletContext.Channel != null)
            {
                request.Channel = cmdletContext.Channel;
            }
            if (cmdletContext.ConfigurationSetName != null)
            {
                request.ConfigurationSetName = cmdletContext.ConfigurationSetName;
            }
            if (cmdletContext.Context != null)
            {
                request.Context = cmdletContext.Context;
            }
            if (cmdletContext.DestinationIdentity != null)
            {
                request.DestinationIdentity = cmdletContext.DestinationIdentity;
            }
            if (cmdletContext.NotifyCodeConfiguration != null)
            {
                request.NotifyCodeConfiguration = cmdletContext.NotifyCodeConfiguration;
            }
            if (cmdletContext.OriginationIdentity != null)
            {
                request.OriginationIdentity = cmdletContext.OriginationIdentity;
            }
            
             // populate OverrideChannelParameters
            var requestOverrideChannelParametersIsNull = true;
            request.OverrideChannelParameters = new Amazon.EndUserMessaging.Model.ChannelParameters();
            Amazon.EndUserMessaging.Model.NotifyParameters requestOverrideChannelParameters_overrideChannelParameters_Notify = null;
            
             // populate Notify
            var requestOverrideChannelParameters_overrideChannelParameters_NotifyIsNull = true;
            requestOverrideChannelParameters_overrideChannelParameters_Notify = new Amazon.EndUserMessaging.Model.NotifyParameters();
            System.String requestOverrideChannelParameters_overrideChannelParameters_Notify_overrideChannelParameters_Notify_NotifyTemplateId = null;
            if (cmdletContext.OverrideChannelParameters_Notify_NotifyTemplateId != null)
            {
                requestOverrideChannelParameters_overrideChannelParameters_Notify_overrideChannelParameters_Notify_NotifyTemplateId = cmdletContext.OverrideChannelParameters_Notify_NotifyTemplateId;
            }
            if (requestOverrideChannelParameters_overrideChannelParameters_Notify_overrideChannelParameters_Notify_NotifyTemplateId != null)
            {
                requestOverrideChannelParameters_overrideChannelParameters_Notify.NotifyTemplateId = requestOverrideChannelParameters_overrideChannelParameters_Notify_overrideChannelParameters_Notify_NotifyTemplateId;
                requestOverrideChannelParameters_overrideChannelParameters_NotifyIsNull = false;
            }
            System.String requestOverrideChannelParameters_overrideChannelParameters_Notify_overrideChannelParameters_Notify_VoiceId = null;
            if (cmdletContext.OverrideChannelParameters_Notify_VoiceId != null)
            {
                requestOverrideChannelParameters_overrideChannelParameters_Notify_overrideChannelParameters_Notify_VoiceId = cmdletContext.OverrideChannelParameters_Notify_VoiceId;
            }
            if (requestOverrideChannelParameters_overrideChannelParameters_Notify_overrideChannelParameters_Notify_VoiceId != null)
            {
                requestOverrideChannelParameters_overrideChannelParameters_Notify.VoiceId = requestOverrideChannelParameters_overrideChannelParameters_Notify_overrideChannelParameters_Notify_VoiceId;
                requestOverrideChannelParameters_overrideChannelParameters_NotifyIsNull = false;
            }
             // determine if requestOverrideChannelParameters_overrideChannelParameters_Notify should be set to null
            if (requestOverrideChannelParameters_overrideChannelParameters_NotifyIsNull)
            {
                requestOverrideChannelParameters_overrideChannelParameters_Notify = null;
            }
            if (requestOverrideChannelParameters_overrideChannelParameters_Notify != null)
            {
                request.OverrideChannelParameters.Notify = requestOverrideChannelParameters_overrideChannelParameters_Notify;
                requestOverrideChannelParametersIsNull = false;
            }
            Amazon.EndUserMessaging.Model.TextParameters requestOverrideChannelParameters_overrideChannelParameters_Text = null;
            
             // populate Text
            var requestOverrideChannelParameters_overrideChannelParameters_TextIsNull = true;
            requestOverrideChannelParameters_overrideChannelParameters_Text = new Amazon.EndUserMessaging.Model.TextParameters();
            Dictionary<System.String, System.String> requestOverrideChannelParameters_overrideChannelParameters_Text_overrideChannelParameters_Text_DestinationCountryParameter = null;
            if (cmdletContext.OverrideChannelParameters_Text_DestinationCountryParameter != null)
            {
                requestOverrideChannelParameters_overrideChannelParameters_Text_overrideChannelParameters_Text_DestinationCountryParameter = cmdletContext.OverrideChannelParameters_Text_DestinationCountryParameter;
            }
            if (requestOverrideChannelParameters_overrideChannelParameters_Text_overrideChannelParameters_Text_DestinationCountryParameter != null)
            {
                requestOverrideChannelParameters_overrideChannelParameters_Text.DestinationCountryParameters = requestOverrideChannelParameters_overrideChannelParameters_Text_overrideChannelParameters_Text_DestinationCountryParameter;
                requestOverrideChannelParameters_overrideChannelParameters_TextIsNull = false;
            }
            System.String requestOverrideChannelParameters_overrideChannelParameters_Text_overrideChannelParameters_Text_InlineTemplateBody = null;
            if (cmdletContext.OverrideChannelParameters_Text_InlineTemplateBody != null)
            {
                requestOverrideChannelParameters_overrideChannelParameters_Text_overrideChannelParameters_Text_InlineTemplateBody = cmdletContext.OverrideChannelParameters_Text_InlineTemplateBody;
            }
            if (requestOverrideChannelParameters_overrideChannelParameters_Text_overrideChannelParameters_Text_InlineTemplateBody != null)
            {
                requestOverrideChannelParameters_overrideChannelParameters_Text.InlineTemplateBody = requestOverrideChannelParameters_overrideChannelParameters_Text_overrideChannelParameters_Text_InlineTemplateBody;
                requestOverrideChannelParameters_overrideChannelParameters_TextIsNull = false;
            }
             // determine if requestOverrideChannelParameters_overrideChannelParameters_Text should be set to null
            if (requestOverrideChannelParameters_overrideChannelParameters_TextIsNull)
            {
                requestOverrideChannelParameters_overrideChannelParameters_Text = null;
            }
            if (requestOverrideChannelParameters_overrideChannelParameters_Text != null)
            {
                request.OverrideChannelParameters.Text = requestOverrideChannelParameters_overrideChannelParameters_Text;
                requestOverrideChannelParametersIsNull = false;
            }
            Amazon.EndUserMessaging.Model.WhatsAppParameters requestOverrideChannelParameters_overrideChannelParameters_WhatsApp = null;
            
             // populate WhatsApp
            var requestOverrideChannelParameters_overrideChannelParameters_WhatsAppIsNull = true;
            requestOverrideChannelParameters_overrideChannelParameters_WhatsApp = new Amazon.EndUserMessaging.Model.WhatsAppParameters();
            System.String requestOverrideChannelParameters_overrideChannelParameters_WhatsApp_overrideChannelParameters_WhatsApp_LanguageCode = null;
            if (cmdletContext.OverrideChannelParameters_WhatsApp_LanguageCode != null)
            {
                requestOverrideChannelParameters_overrideChannelParameters_WhatsApp_overrideChannelParameters_WhatsApp_LanguageCode = cmdletContext.OverrideChannelParameters_WhatsApp_LanguageCode;
            }
            if (requestOverrideChannelParameters_overrideChannelParameters_WhatsApp_overrideChannelParameters_WhatsApp_LanguageCode != null)
            {
                requestOverrideChannelParameters_overrideChannelParameters_WhatsApp.LanguageCode = requestOverrideChannelParameters_overrideChannelParameters_WhatsApp_overrideChannelParameters_WhatsApp_LanguageCode;
                requestOverrideChannelParameters_overrideChannelParameters_WhatsAppIsNull = false;
            }
            System.String requestOverrideChannelParameters_overrideChannelParameters_WhatsApp_overrideChannelParameters_WhatsApp_WhatsAppTemplateName = null;
            if (cmdletContext.OverrideChannelParameters_WhatsApp_WhatsAppTemplateName != null)
            {
                requestOverrideChannelParameters_overrideChannelParameters_WhatsApp_overrideChannelParameters_WhatsApp_WhatsAppTemplateName = cmdletContext.OverrideChannelParameters_WhatsApp_WhatsAppTemplateName;
            }
            if (requestOverrideChannelParameters_overrideChannelParameters_WhatsApp_overrideChannelParameters_WhatsApp_WhatsAppTemplateName != null)
            {
                requestOverrideChannelParameters_overrideChannelParameters_WhatsApp.WhatsAppTemplateName = requestOverrideChannelParameters_overrideChannelParameters_WhatsApp_overrideChannelParameters_WhatsApp_WhatsAppTemplateName;
                requestOverrideChannelParameters_overrideChannelParameters_WhatsAppIsNull = false;
            }
             // determine if requestOverrideChannelParameters_overrideChannelParameters_WhatsApp should be set to null
            if (requestOverrideChannelParameters_overrideChannelParameters_WhatsAppIsNull)
            {
                requestOverrideChannelParameters_overrideChannelParameters_WhatsApp = null;
            }
            if (requestOverrideChannelParameters_overrideChannelParameters_WhatsApp != null)
            {
                request.OverrideChannelParameters.WhatsApp = requestOverrideChannelParameters_overrideChannelParameters_WhatsApp;
                requestOverrideChannelParametersIsNull = false;
            }
            Amazon.EndUserMessaging.Model.VoiceParameters requestOverrideChannelParameters_overrideChannelParameters_Voice = null;
            
             // populate Voice
            var requestOverrideChannelParameters_overrideChannelParameters_VoiceIsNull = true;
            requestOverrideChannelParameters_overrideChannelParameters_Voice = new Amazon.EndUserMessaging.Model.VoiceParameters();
            System.String requestOverrideChannelParameters_overrideChannelParameters_Voice_overrideChannelParameters_Voice_InlineTemplateBody = null;
            if (cmdletContext.OverrideChannelParameters_Voice_InlineTemplateBody != null)
            {
                requestOverrideChannelParameters_overrideChannelParameters_Voice_overrideChannelParameters_Voice_InlineTemplateBody = cmdletContext.OverrideChannelParameters_Voice_InlineTemplateBody;
            }
            if (requestOverrideChannelParameters_overrideChannelParameters_Voice_overrideChannelParameters_Voice_InlineTemplateBody != null)
            {
                requestOverrideChannelParameters_overrideChannelParameters_Voice.InlineTemplateBody = requestOverrideChannelParameters_overrideChannelParameters_Voice_overrideChannelParameters_Voice_InlineTemplateBody;
                requestOverrideChannelParameters_overrideChannelParameters_VoiceIsNull = false;
            }
            System.String requestOverrideChannelParameters_overrideChannelParameters_Voice_overrideChannelParameters_Voice_LanguageCode = null;
            if (cmdletContext.OverrideChannelParameters_Voice_LanguageCode != null)
            {
                requestOverrideChannelParameters_overrideChannelParameters_Voice_overrideChannelParameters_Voice_LanguageCode = cmdletContext.OverrideChannelParameters_Voice_LanguageCode;
            }
            if (requestOverrideChannelParameters_overrideChannelParameters_Voice_overrideChannelParameters_Voice_LanguageCode != null)
            {
                requestOverrideChannelParameters_overrideChannelParameters_Voice.LanguageCode = requestOverrideChannelParameters_overrideChannelParameters_Voice_overrideChannelParameters_Voice_LanguageCode;
                requestOverrideChannelParameters_overrideChannelParameters_VoiceIsNull = false;
            }
            System.String requestOverrideChannelParameters_overrideChannelParameters_Voice_overrideChannelParameters_Voice_VoiceId = null;
            if (cmdletContext.OverrideChannelParameters_Voice_VoiceId != null)
            {
                requestOverrideChannelParameters_overrideChannelParameters_Voice_overrideChannelParameters_Voice_VoiceId = cmdletContext.OverrideChannelParameters_Voice_VoiceId;
            }
            if (requestOverrideChannelParameters_overrideChannelParameters_Voice_overrideChannelParameters_Voice_VoiceId != null)
            {
                requestOverrideChannelParameters_overrideChannelParameters_Voice.VoiceId = requestOverrideChannelParameters_overrideChannelParameters_Voice_overrideChannelParameters_Voice_VoiceId;
                requestOverrideChannelParameters_overrideChannelParameters_VoiceIsNull = false;
            }
            Amazon.EndUserMessaging.VoiceMessageBodyTextType requestOverrideChannelParameters_overrideChannelParameters_Voice_overrideChannelParameters_Voice_VoiceMessageBodyTextType = null;
            if (cmdletContext.OverrideChannelParameters_Voice_VoiceMessageBodyTextType != null)
            {
                requestOverrideChannelParameters_overrideChannelParameters_Voice_overrideChannelParameters_Voice_VoiceMessageBodyTextType = cmdletContext.OverrideChannelParameters_Voice_VoiceMessageBodyTextType;
            }
            if (requestOverrideChannelParameters_overrideChannelParameters_Voice_overrideChannelParameters_Voice_VoiceMessageBodyTextType != null)
            {
                requestOverrideChannelParameters_overrideChannelParameters_Voice.VoiceMessageBodyTextType = requestOverrideChannelParameters_overrideChannelParameters_Voice_overrideChannelParameters_Voice_VoiceMessageBodyTextType;
                requestOverrideChannelParameters_overrideChannelParameters_VoiceIsNull = false;
            }
             // determine if requestOverrideChannelParameters_overrideChannelParameters_Voice should be set to null
            if (requestOverrideChannelParameters_overrideChannelParameters_VoiceIsNull)
            {
                requestOverrideChannelParameters_overrideChannelParameters_Voice = null;
            }
            if (requestOverrideChannelParameters_overrideChannelParameters_Voice != null)
            {
                request.OverrideChannelParameters.Voice = requestOverrideChannelParameters_overrideChannelParameters_Voice;
                requestOverrideChannelParametersIsNull = false;
            }
             // determine if request.OverrideChannelParameters should be set to null
            if (requestOverrideChannelParametersIsNull)
            {
                request.OverrideChannelParameters = null;
            }
            
             // populate OverrideCodeConfigurationParameters
            var requestOverrideCodeConfigurationParametersIsNull = true;
            request.OverrideCodeConfigurationParameters = new Amazon.EndUserMessaging.Model.CodeConfigurationParameters();
            System.Int32? requestOverrideCodeConfigurationParameters_overrideCodeConfigurationParameters_CodeLength = null;
            if (cmdletContext.OverrideCodeConfigurationParameters_CodeLength != null)
            {
                requestOverrideCodeConfigurationParameters_overrideCodeConfigurationParameters_CodeLength = cmdletContext.OverrideCodeConfigurationParameters_CodeLength.Value;
            }
            if (requestOverrideCodeConfigurationParameters_overrideCodeConfigurationParameters_CodeLength != null)
            {
                request.OverrideCodeConfigurationParameters.CodeLength = requestOverrideCodeConfigurationParameters_overrideCodeConfigurationParameters_CodeLength.Value;
                requestOverrideCodeConfigurationParametersIsNull = false;
            }
            Amazon.EndUserMessaging.CodeType requestOverrideCodeConfigurationParameters_overrideCodeConfigurationParameters_CodeType = null;
            if (cmdletContext.OverrideCodeConfigurationParameters_CodeType != null)
            {
                requestOverrideCodeConfigurationParameters_overrideCodeConfigurationParameters_CodeType = cmdletContext.OverrideCodeConfigurationParameters_CodeType;
            }
            if (requestOverrideCodeConfigurationParameters_overrideCodeConfigurationParameters_CodeType != null)
            {
                request.OverrideCodeConfigurationParameters.CodeType = requestOverrideCodeConfigurationParameters_overrideCodeConfigurationParameters_CodeType;
                requestOverrideCodeConfigurationParametersIsNull = false;
            }
            System.Int32? requestOverrideCodeConfigurationParameters_overrideCodeConfigurationParameters_MaxAttempt = null;
            if (cmdletContext.OverrideCodeConfigurationParameters_MaxAttempt != null)
            {
                requestOverrideCodeConfigurationParameters_overrideCodeConfigurationParameters_MaxAttempt = cmdletContext.OverrideCodeConfigurationParameters_MaxAttempt.Value;
            }
            if (requestOverrideCodeConfigurationParameters_overrideCodeConfigurationParameters_MaxAttempt != null)
            {
                request.OverrideCodeConfigurationParameters.MaxAttempts = requestOverrideCodeConfigurationParameters_overrideCodeConfigurationParameters_MaxAttempt.Value;
                requestOverrideCodeConfigurationParametersIsNull = false;
            }
            System.Int32? requestOverrideCodeConfigurationParameters_overrideCodeConfigurationParameters_ValidityPeriodMinute = null;
            if (cmdletContext.OverrideCodeConfigurationParameters_ValidityPeriodMinute != null)
            {
                requestOverrideCodeConfigurationParameters_overrideCodeConfigurationParameters_ValidityPeriodMinute = cmdletContext.OverrideCodeConfigurationParameters_ValidityPeriodMinute.Value;
            }
            if (requestOverrideCodeConfigurationParameters_overrideCodeConfigurationParameters_ValidityPeriodMinute != null)
            {
                request.OverrideCodeConfigurationParameters.ValidityPeriodMinutes = requestOverrideCodeConfigurationParameters_overrideCodeConfigurationParameters_ValidityPeriodMinute.Value;
                requestOverrideCodeConfigurationParametersIsNull = false;
            }
             // determine if request.OverrideCodeConfigurationParameters should be set to null
            if (requestOverrideCodeConfigurationParametersIsNull)
            {
                request.OverrideCodeConfigurationParameters = null;
            }
            if (cmdletContext.ReferenceId != null)
            {
                request.ReferenceId = cmdletContext.ReferenceId;
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
        
        private Amazon.EndUserMessaging.Model.SendNotifyCodeVerificationResponse CallAWSServiceOperation(IAmazonEndUserMessaging client, Amazon.EndUserMessaging.Model.SendNotifyCodeVerificationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS End User Messaging", "SendNotifyCodeVerification");
            try
            {
                return client.SendNotifyCodeVerificationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.EndUserMessaging.NotifyChannel Channel { get; set; }
            public System.String ConfigurationSetName { get; set; }
            public Dictionary<System.String, System.String> Context { get; set; }
            public System.String DestinationIdentity { get; set; }
            public System.String NotifyCodeConfiguration { get; set; }
            public System.String OriginationIdentity { get; set; }
            public System.String OverrideChannelParameters_Notify_NotifyTemplateId { get; set; }
            public System.String OverrideChannelParameters_Notify_VoiceId { get; set; }
            public Dictionary<System.String, System.String> OverrideChannelParameters_Text_DestinationCountryParameter { get; set; }
            public System.String OverrideChannelParameters_Text_InlineTemplateBody { get; set; }
            public System.String OverrideChannelParameters_Voice_InlineTemplateBody { get; set; }
            public System.String OverrideChannelParameters_Voice_LanguageCode { get; set; }
            public System.String OverrideChannelParameters_Voice_VoiceId { get; set; }
            public Amazon.EndUserMessaging.VoiceMessageBodyTextType OverrideChannelParameters_Voice_VoiceMessageBodyTextType { get; set; }
            public System.String OverrideChannelParameters_WhatsApp_LanguageCode { get; set; }
            public System.String OverrideChannelParameters_WhatsApp_WhatsAppTemplateName { get; set; }
            public System.Int32? OverrideCodeConfigurationParameters_CodeLength { get; set; }
            public Amazon.EndUserMessaging.CodeType OverrideCodeConfigurationParameters_CodeType { get; set; }
            public System.Int32? OverrideCodeConfigurationParameters_MaxAttempt { get; set; }
            public System.Int32? OverrideCodeConfigurationParameters_ValidityPeriodMinute { get; set; }
            public System.String ReferenceId { get; set; }
            public System.Func<Amazon.EndUserMessaging.Model.SendNotifyCodeVerificationResponse, SendEUMNotifyCodeVerificationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
