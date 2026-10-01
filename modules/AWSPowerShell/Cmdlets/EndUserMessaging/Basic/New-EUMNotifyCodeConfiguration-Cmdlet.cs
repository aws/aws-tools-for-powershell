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
    /// Creates a notify code configuration. A notify code configuration is a reusable policy
    /// that defines how one-time passcodes are generated and rendered, including the code
    /// type, length, validity period, maximum number of attempts, and channel templates.
    /// </summary>
    [Cmdlet("New", "EUMNotifyCodeConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EndUserMessaging.Model.NotifyCodeConfiguration")]
    [AWSCmdlet("Calls the AWS End User Messaging CreateNotifyCodeConfiguration API operation.", Operation = new[] {"CreateNotifyCodeConfiguration"}, SelectReturnType = typeof(Amazon.EndUserMessaging.Model.CreateNotifyCodeConfigurationResponse))]
    [AWSCmdletOutput("Amazon.EndUserMessaging.Model.NotifyCodeConfiguration or Amazon.EndUserMessaging.Model.CreateNotifyCodeConfigurationResponse",
        "This cmdlet returns an Amazon.EndUserMessaging.Model.NotifyCodeConfiguration object.",
        "The service call response (type Amazon.EndUserMessaging.Model.CreateNotifyCodeConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEUMNotifyCodeConfigurationCmdlet : AmazonEndUserMessagingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CodeConfigurationParameters_CodeLength
        /// <summary>
        /// <para>
        /// <para>The number of characters in the one-time passcode. Valid values range from 4 through
        /// 8. When you do not specify a value, the default is applied when a passcode is sent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? CodeConfigurationParameters_CodeLength { get; set; }
        #endregion
        
        #region Parameter CodeConfigurationParameters_CodeType
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
        public Amazon.EndUserMessaging.CodeType CodeConfigurationParameters_CodeType { get; set; }
        #endregion
        
        #region Parameter DeletionProtectionEnabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether deletion protection is enabled. When enabled, the resource cannot
        /// be deleted until deletion protection is turned off.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeletionProtectionEnabled { get; set; }
        #endregion
        
        #region Parameter ChannelParameters_Text_DestinationCountryParameter
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
        [Alias("ChannelParameters_Text_DestinationCountryParameters")]
        public System.Collections.Hashtable ChannelParameters_Text_DestinationCountryParameter { get; set; }
        #endregion
        
        #region Parameter ChannelParameters_Text_InlineTemplateBody
        /// <summary>
        /// <para>
        /// <para>The freeform message template used to render the one-time passcode for the SMS or
        /// RCS channels. The template must contain the code placeholder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChannelParameters_Text_InlineTemplateBody { get; set; }
        #endregion
        
        #region Parameter ChannelParameters_Voice_InlineTemplateBody
        /// <summary>
        /// <para>
        /// <para>The freeform message template used to render the one-time passcode for the voice channel.
        /// The template must contain the code placeholder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChannelParameters_Voice_InlineTemplateBody { get; set; }
        #endregion
        
        #region Parameter ChannelParameters_Voice_LanguageCode
        /// <summary>
        /// <para>
        /// <para>The BCP 47 language code used to render the voice message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChannelParameters_Voice_LanguageCode { get; set; }
        #endregion
        
        #region Parameter ChannelParameters_WhatsApp_LanguageCode
        /// <summary>
        /// <para>
        /// <para>The BCP 47 language code used to render the template. This value is required for the
        /// WhatsApp channel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChannelParameters_WhatsApp_LanguageCode { get; set; }
        #endregion
        
        #region Parameter CodeConfigurationParameters_MaxAttempt
        /// <summary>
        /// <para>
        /// <para>The maximum number of validation attempts that are allowed before the verification
        /// is locked. Valid values range from 1 through 5. When you do not specify a value, the
        /// default is applied when a passcode is sent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CodeConfigurationParameters_MaxAttempts")]
        public System.Int32? CodeConfigurationParameters_MaxAttempt { get; set; }
        #endregion
        
        #region Parameter NotifyCodeConfigurationName
        /// <summary>
        /// <para>
        /// <para>The name of the notify code configuration.</para>
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
        public System.String NotifyCodeConfigurationName { get; set; }
        #endregion
        
        #region Parameter ChannelParameters_Notify_NotifyTemplateId
        /// <summary>
        /// <para>
        /// <para>The identifier of a preapproved notify template for the SMS or voice channels.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChannelParameters_Notify_NotifyTemplateId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of key and value pair tags that are associated with the resource.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.EndUserMessaging.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter CodeConfigurationParameters_ValidityPeriodMinute
        /// <summary>
        /// <para>
        /// <para>The length of time, in minutes, that the one-time passcode remains valid. Valid values
        /// range from 1 through 60. When you do not specify a value, the default is applied when
        /// a passcode is sent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CodeConfigurationParameters_ValidityPeriodMinutes")]
        public System.Int32? CodeConfigurationParameters_ValidityPeriodMinute { get; set; }
        #endregion
        
        #region Parameter ChannelParameters_Notify_VoiceId
        /// <summary>
        /// <para>
        /// <para>The Amazon Polly voice ID used when the notify template is delivered over the voice
        /// channel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChannelParameters_Notify_VoiceId { get; set; }
        #endregion
        
        #region Parameter ChannelParameters_Voice_VoiceId
        /// <summary>
        /// <para>
        /// <para>The Amazon Polly voice ID used for the voice channel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChannelParameters_Voice_VoiceId { get; set; }
        #endregion
        
        #region Parameter ChannelParameters_Voice_VoiceMessageBodyTextType
        /// <summary>
        /// <para>
        /// <para>The format of the voice message body. Valid values are TEXT and SSML.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EndUserMessaging.VoiceMessageBodyTextType")]
        public Amazon.EndUserMessaging.VoiceMessageBodyTextType ChannelParameters_Voice_VoiceMessageBodyTextType { get; set; }
        #endregion
        
        #region Parameter ChannelParameters_WhatsApp_WhatsAppTemplateName
        /// <summary>
        /// <para>
        /// <para>The name of the Meta-approved WhatsApp authentication template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChannelParameters_WhatsApp_WhatsAppTemplateName { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If you do not specify a client token, the AWS SDK automatically generates
        /// one.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'NotifyCodeConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EndUserMessaging.Model.CreateNotifyCodeConfigurationResponse).
        /// Specifying the name of a property of type Amazon.EndUserMessaging.Model.CreateNotifyCodeConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "NotifyCodeConfiguration";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.NotifyCodeConfigurationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EUMNotifyCodeConfiguration (CreateNotifyCodeConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EndUserMessaging.Model.CreateNotifyCodeConfigurationResponse, NewEUMNotifyCodeConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ChannelParameters_Notify_NotifyTemplateId = this.ChannelParameters_Notify_NotifyTemplateId;
            context.ChannelParameters_Notify_VoiceId = this.ChannelParameters_Notify_VoiceId;
            if (this.ChannelParameters_Text_DestinationCountryParameter != null)
            {
                context.ChannelParameters_Text_DestinationCountryParameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ChannelParameters_Text_DestinationCountryParameter.Keys)
                {
                    context.ChannelParameters_Text_DestinationCountryParameter.Add((String)hashKey, (System.String)(this.ChannelParameters_Text_DestinationCountryParameter[hashKey]));
                }
            }
            context.ChannelParameters_Text_InlineTemplateBody = this.ChannelParameters_Text_InlineTemplateBody;
            context.ChannelParameters_Voice_InlineTemplateBody = this.ChannelParameters_Voice_InlineTemplateBody;
            context.ChannelParameters_Voice_LanguageCode = this.ChannelParameters_Voice_LanguageCode;
            context.ChannelParameters_Voice_VoiceId = this.ChannelParameters_Voice_VoiceId;
            context.ChannelParameters_Voice_VoiceMessageBodyTextType = this.ChannelParameters_Voice_VoiceMessageBodyTextType;
            context.ChannelParameters_WhatsApp_LanguageCode = this.ChannelParameters_WhatsApp_LanguageCode;
            context.ChannelParameters_WhatsApp_WhatsAppTemplateName = this.ChannelParameters_WhatsApp_WhatsAppTemplateName;
            context.ClientToken = this.ClientToken;
            context.CodeConfigurationParameters_CodeLength = this.CodeConfigurationParameters_CodeLength;
            context.CodeConfigurationParameters_CodeType = this.CodeConfigurationParameters_CodeType;
            context.CodeConfigurationParameters_MaxAttempt = this.CodeConfigurationParameters_MaxAttempt;
            context.CodeConfigurationParameters_ValidityPeriodMinute = this.CodeConfigurationParameters_ValidityPeriodMinute;
            context.DeletionProtectionEnabled = this.DeletionProtectionEnabled;
            context.NotifyCodeConfigurationName = this.NotifyCodeConfigurationName;
            #if MODULAR
            if (this.NotifyCodeConfigurationName == null && ParameterWasBound(nameof(this.NotifyCodeConfigurationName)))
            {
                WriteWarning("You are passing $null as a value for parameter NotifyCodeConfigurationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.EndUserMessaging.Model.Tag>(this.Tag);
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
            var request = new Amazon.EndUserMessaging.Model.CreateNotifyCodeConfigurationRequest();
            
            
             // populate ChannelParameters
            var requestChannelParametersIsNull = true;
            request.ChannelParameters = new Amazon.EndUserMessaging.Model.ChannelParameters();
            Amazon.EndUserMessaging.Model.NotifyParameters requestChannelParameters_channelParameters_Notify = null;
            
             // populate Notify
            var requestChannelParameters_channelParameters_NotifyIsNull = true;
            requestChannelParameters_channelParameters_Notify = new Amazon.EndUserMessaging.Model.NotifyParameters();
            System.String requestChannelParameters_channelParameters_Notify_channelParameters_Notify_NotifyTemplateId = null;
            if (cmdletContext.ChannelParameters_Notify_NotifyTemplateId != null)
            {
                requestChannelParameters_channelParameters_Notify_channelParameters_Notify_NotifyTemplateId = cmdletContext.ChannelParameters_Notify_NotifyTemplateId;
            }
            if (requestChannelParameters_channelParameters_Notify_channelParameters_Notify_NotifyTemplateId != null)
            {
                requestChannelParameters_channelParameters_Notify.NotifyTemplateId = requestChannelParameters_channelParameters_Notify_channelParameters_Notify_NotifyTemplateId;
                requestChannelParameters_channelParameters_NotifyIsNull = false;
            }
            System.String requestChannelParameters_channelParameters_Notify_channelParameters_Notify_VoiceId = null;
            if (cmdletContext.ChannelParameters_Notify_VoiceId != null)
            {
                requestChannelParameters_channelParameters_Notify_channelParameters_Notify_VoiceId = cmdletContext.ChannelParameters_Notify_VoiceId;
            }
            if (requestChannelParameters_channelParameters_Notify_channelParameters_Notify_VoiceId != null)
            {
                requestChannelParameters_channelParameters_Notify.VoiceId = requestChannelParameters_channelParameters_Notify_channelParameters_Notify_VoiceId;
                requestChannelParameters_channelParameters_NotifyIsNull = false;
            }
             // determine if requestChannelParameters_channelParameters_Notify should be set to null
            if (requestChannelParameters_channelParameters_NotifyIsNull)
            {
                requestChannelParameters_channelParameters_Notify = null;
            }
            if (requestChannelParameters_channelParameters_Notify != null)
            {
                request.ChannelParameters.Notify = requestChannelParameters_channelParameters_Notify;
                requestChannelParametersIsNull = false;
            }
            Amazon.EndUserMessaging.Model.TextParameters requestChannelParameters_channelParameters_Text = null;
            
             // populate Text
            var requestChannelParameters_channelParameters_TextIsNull = true;
            requestChannelParameters_channelParameters_Text = new Amazon.EndUserMessaging.Model.TextParameters();
            Dictionary<System.String, System.String> requestChannelParameters_channelParameters_Text_channelParameters_Text_DestinationCountryParameter = null;
            if (cmdletContext.ChannelParameters_Text_DestinationCountryParameter != null)
            {
                requestChannelParameters_channelParameters_Text_channelParameters_Text_DestinationCountryParameter = cmdletContext.ChannelParameters_Text_DestinationCountryParameter;
            }
            if (requestChannelParameters_channelParameters_Text_channelParameters_Text_DestinationCountryParameter != null)
            {
                requestChannelParameters_channelParameters_Text.DestinationCountryParameters = requestChannelParameters_channelParameters_Text_channelParameters_Text_DestinationCountryParameter;
                requestChannelParameters_channelParameters_TextIsNull = false;
            }
            System.String requestChannelParameters_channelParameters_Text_channelParameters_Text_InlineTemplateBody = null;
            if (cmdletContext.ChannelParameters_Text_InlineTemplateBody != null)
            {
                requestChannelParameters_channelParameters_Text_channelParameters_Text_InlineTemplateBody = cmdletContext.ChannelParameters_Text_InlineTemplateBody;
            }
            if (requestChannelParameters_channelParameters_Text_channelParameters_Text_InlineTemplateBody != null)
            {
                requestChannelParameters_channelParameters_Text.InlineTemplateBody = requestChannelParameters_channelParameters_Text_channelParameters_Text_InlineTemplateBody;
                requestChannelParameters_channelParameters_TextIsNull = false;
            }
             // determine if requestChannelParameters_channelParameters_Text should be set to null
            if (requestChannelParameters_channelParameters_TextIsNull)
            {
                requestChannelParameters_channelParameters_Text = null;
            }
            if (requestChannelParameters_channelParameters_Text != null)
            {
                request.ChannelParameters.Text = requestChannelParameters_channelParameters_Text;
                requestChannelParametersIsNull = false;
            }
            Amazon.EndUserMessaging.Model.WhatsAppParameters requestChannelParameters_channelParameters_WhatsApp = null;
            
             // populate WhatsApp
            var requestChannelParameters_channelParameters_WhatsAppIsNull = true;
            requestChannelParameters_channelParameters_WhatsApp = new Amazon.EndUserMessaging.Model.WhatsAppParameters();
            System.String requestChannelParameters_channelParameters_WhatsApp_channelParameters_WhatsApp_LanguageCode = null;
            if (cmdletContext.ChannelParameters_WhatsApp_LanguageCode != null)
            {
                requestChannelParameters_channelParameters_WhatsApp_channelParameters_WhatsApp_LanguageCode = cmdletContext.ChannelParameters_WhatsApp_LanguageCode;
            }
            if (requestChannelParameters_channelParameters_WhatsApp_channelParameters_WhatsApp_LanguageCode != null)
            {
                requestChannelParameters_channelParameters_WhatsApp.LanguageCode = requestChannelParameters_channelParameters_WhatsApp_channelParameters_WhatsApp_LanguageCode;
                requestChannelParameters_channelParameters_WhatsAppIsNull = false;
            }
            System.String requestChannelParameters_channelParameters_WhatsApp_channelParameters_WhatsApp_WhatsAppTemplateName = null;
            if (cmdletContext.ChannelParameters_WhatsApp_WhatsAppTemplateName != null)
            {
                requestChannelParameters_channelParameters_WhatsApp_channelParameters_WhatsApp_WhatsAppTemplateName = cmdletContext.ChannelParameters_WhatsApp_WhatsAppTemplateName;
            }
            if (requestChannelParameters_channelParameters_WhatsApp_channelParameters_WhatsApp_WhatsAppTemplateName != null)
            {
                requestChannelParameters_channelParameters_WhatsApp.WhatsAppTemplateName = requestChannelParameters_channelParameters_WhatsApp_channelParameters_WhatsApp_WhatsAppTemplateName;
                requestChannelParameters_channelParameters_WhatsAppIsNull = false;
            }
             // determine if requestChannelParameters_channelParameters_WhatsApp should be set to null
            if (requestChannelParameters_channelParameters_WhatsAppIsNull)
            {
                requestChannelParameters_channelParameters_WhatsApp = null;
            }
            if (requestChannelParameters_channelParameters_WhatsApp != null)
            {
                request.ChannelParameters.WhatsApp = requestChannelParameters_channelParameters_WhatsApp;
                requestChannelParametersIsNull = false;
            }
            Amazon.EndUserMessaging.Model.VoiceParameters requestChannelParameters_channelParameters_Voice = null;
            
             // populate Voice
            var requestChannelParameters_channelParameters_VoiceIsNull = true;
            requestChannelParameters_channelParameters_Voice = new Amazon.EndUserMessaging.Model.VoiceParameters();
            System.String requestChannelParameters_channelParameters_Voice_channelParameters_Voice_InlineTemplateBody = null;
            if (cmdletContext.ChannelParameters_Voice_InlineTemplateBody != null)
            {
                requestChannelParameters_channelParameters_Voice_channelParameters_Voice_InlineTemplateBody = cmdletContext.ChannelParameters_Voice_InlineTemplateBody;
            }
            if (requestChannelParameters_channelParameters_Voice_channelParameters_Voice_InlineTemplateBody != null)
            {
                requestChannelParameters_channelParameters_Voice.InlineTemplateBody = requestChannelParameters_channelParameters_Voice_channelParameters_Voice_InlineTemplateBody;
                requestChannelParameters_channelParameters_VoiceIsNull = false;
            }
            System.String requestChannelParameters_channelParameters_Voice_channelParameters_Voice_LanguageCode = null;
            if (cmdletContext.ChannelParameters_Voice_LanguageCode != null)
            {
                requestChannelParameters_channelParameters_Voice_channelParameters_Voice_LanguageCode = cmdletContext.ChannelParameters_Voice_LanguageCode;
            }
            if (requestChannelParameters_channelParameters_Voice_channelParameters_Voice_LanguageCode != null)
            {
                requestChannelParameters_channelParameters_Voice.LanguageCode = requestChannelParameters_channelParameters_Voice_channelParameters_Voice_LanguageCode;
                requestChannelParameters_channelParameters_VoiceIsNull = false;
            }
            System.String requestChannelParameters_channelParameters_Voice_channelParameters_Voice_VoiceId = null;
            if (cmdletContext.ChannelParameters_Voice_VoiceId != null)
            {
                requestChannelParameters_channelParameters_Voice_channelParameters_Voice_VoiceId = cmdletContext.ChannelParameters_Voice_VoiceId;
            }
            if (requestChannelParameters_channelParameters_Voice_channelParameters_Voice_VoiceId != null)
            {
                requestChannelParameters_channelParameters_Voice.VoiceId = requestChannelParameters_channelParameters_Voice_channelParameters_Voice_VoiceId;
                requestChannelParameters_channelParameters_VoiceIsNull = false;
            }
            Amazon.EndUserMessaging.VoiceMessageBodyTextType requestChannelParameters_channelParameters_Voice_channelParameters_Voice_VoiceMessageBodyTextType = null;
            if (cmdletContext.ChannelParameters_Voice_VoiceMessageBodyTextType != null)
            {
                requestChannelParameters_channelParameters_Voice_channelParameters_Voice_VoiceMessageBodyTextType = cmdletContext.ChannelParameters_Voice_VoiceMessageBodyTextType;
            }
            if (requestChannelParameters_channelParameters_Voice_channelParameters_Voice_VoiceMessageBodyTextType != null)
            {
                requestChannelParameters_channelParameters_Voice.VoiceMessageBodyTextType = requestChannelParameters_channelParameters_Voice_channelParameters_Voice_VoiceMessageBodyTextType;
                requestChannelParameters_channelParameters_VoiceIsNull = false;
            }
             // determine if requestChannelParameters_channelParameters_Voice should be set to null
            if (requestChannelParameters_channelParameters_VoiceIsNull)
            {
                requestChannelParameters_channelParameters_Voice = null;
            }
            if (requestChannelParameters_channelParameters_Voice != null)
            {
                request.ChannelParameters.Voice = requestChannelParameters_channelParameters_Voice;
                requestChannelParametersIsNull = false;
            }
             // determine if request.ChannelParameters should be set to null
            if (requestChannelParametersIsNull)
            {
                request.ChannelParameters = null;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate CodeConfigurationParameters
            var requestCodeConfigurationParametersIsNull = true;
            request.CodeConfigurationParameters = new Amazon.EndUserMessaging.Model.CodeConfigurationParameters();
            System.Int32? requestCodeConfigurationParameters_codeConfigurationParameters_CodeLength = null;
            if (cmdletContext.CodeConfigurationParameters_CodeLength != null)
            {
                requestCodeConfigurationParameters_codeConfigurationParameters_CodeLength = cmdletContext.CodeConfigurationParameters_CodeLength.Value;
            }
            if (requestCodeConfigurationParameters_codeConfigurationParameters_CodeLength != null)
            {
                request.CodeConfigurationParameters.CodeLength = requestCodeConfigurationParameters_codeConfigurationParameters_CodeLength.Value;
                requestCodeConfigurationParametersIsNull = false;
            }
            Amazon.EndUserMessaging.CodeType requestCodeConfigurationParameters_codeConfigurationParameters_CodeType = null;
            if (cmdletContext.CodeConfigurationParameters_CodeType != null)
            {
                requestCodeConfigurationParameters_codeConfigurationParameters_CodeType = cmdletContext.CodeConfigurationParameters_CodeType;
            }
            if (requestCodeConfigurationParameters_codeConfigurationParameters_CodeType != null)
            {
                request.CodeConfigurationParameters.CodeType = requestCodeConfigurationParameters_codeConfigurationParameters_CodeType;
                requestCodeConfigurationParametersIsNull = false;
            }
            System.Int32? requestCodeConfigurationParameters_codeConfigurationParameters_MaxAttempt = null;
            if (cmdletContext.CodeConfigurationParameters_MaxAttempt != null)
            {
                requestCodeConfigurationParameters_codeConfigurationParameters_MaxAttempt = cmdletContext.CodeConfigurationParameters_MaxAttempt.Value;
            }
            if (requestCodeConfigurationParameters_codeConfigurationParameters_MaxAttempt != null)
            {
                request.CodeConfigurationParameters.MaxAttempts = requestCodeConfigurationParameters_codeConfigurationParameters_MaxAttempt.Value;
                requestCodeConfigurationParametersIsNull = false;
            }
            System.Int32? requestCodeConfigurationParameters_codeConfigurationParameters_ValidityPeriodMinute = null;
            if (cmdletContext.CodeConfigurationParameters_ValidityPeriodMinute != null)
            {
                requestCodeConfigurationParameters_codeConfigurationParameters_ValidityPeriodMinute = cmdletContext.CodeConfigurationParameters_ValidityPeriodMinute.Value;
            }
            if (requestCodeConfigurationParameters_codeConfigurationParameters_ValidityPeriodMinute != null)
            {
                request.CodeConfigurationParameters.ValidityPeriodMinutes = requestCodeConfigurationParameters_codeConfigurationParameters_ValidityPeriodMinute.Value;
                requestCodeConfigurationParametersIsNull = false;
            }
             // determine if request.CodeConfigurationParameters should be set to null
            if (requestCodeConfigurationParametersIsNull)
            {
                request.CodeConfigurationParameters = null;
            }
            if (cmdletContext.DeletionProtectionEnabled != null)
            {
                request.DeletionProtectionEnabled = cmdletContext.DeletionProtectionEnabled.Value;
            }
            if (cmdletContext.NotifyCodeConfigurationName != null)
            {
                request.NotifyCodeConfigurationName = cmdletContext.NotifyCodeConfigurationName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.EndUserMessaging.Model.CreateNotifyCodeConfigurationResponse CallAWSServiceOperation(IAmazonEndUserMessaging client, Amazon.EndUserMessaging.Model.CreateNotifyCodeConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS End User Messaging", "CreateNotifyCodeConfiguration");
            try
            {
                return client.CreateNotifyCodeConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ChannelParameters_Notify_NotifyTemplateId { get; set; }
            public System.String ChannelParameters_Notify_VoiceId { get; set; }
            public Dictionary<System.String, System.String> ChannelParameters_Text_DestinationCountryParameter { get; set; }
            public System.String ChannelParameters_Text_InlineTemplateBody { get; set; }
            public System.String ChannelParameters_Voice_InlineTemplateBody { get; set; }
            public System.String ChannelParameters_Voice_LanguageCode { get; set; }
            public System.String ChannelParameters_Voice_VoiceId { get; set; }
            public Amazon.EndUserMessaging.VoiceMessageBodyTextType ChannelParameters_Voice_VoiceMessageBodyTextType { get; set; }
            public System.String ChannelParameters_WhatsApp_LanguageCode { get; set; }
            public System.String ChannelParameters_WhatsApp_WhatsAppTemplateName { get; set; }
            public System.String ClientToken { get; set; }
            public System.Int32? CodeConfigurationParameters_CodeLength { get; set; }
            public Amazon.EndUserMessaging.CodeType CodeConfigurationParameters_CodeType { get; set; }
            public System.Int32? CodeConfigurationParameters_MaxAttempt { get; set; }
            public System.Int32? CodeConfigurationParameters_ValidityPeriodMinute { get; set; }
            public System.Boolean? DeletionProtectionEnabled { get; set; }
            public System.String NotifyCodeConfigurationName { get; set; }
            public List<Amazon.EndUserMessaging.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.EndUserMessaging.Model.CreateNotifyCodeConfigurationResponse, NewEUMNotifyCodeConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.NotifyCodeConfiguration;
        }
        
    }
}
