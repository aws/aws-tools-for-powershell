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
using Amazon.PinpointSMSVoiceV2;
using Amazon.PinpointSMSVoiceV2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SMSV
{
    /// <summary>
    /// Creates a new RCS message and sends it to a recipient's phone number. RCS messages
    /// support rich content including text, files, rich cards, and carousels with interactive
    /// suggested actions.
    /// </summary>
    [Cmdlet("Send", "SMSVRcsMessage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Pinpoint SMS Voice V2 SendRcsMessage API operation.", Operation = new[] {"SendRcsMessage"}, SelectReturnType = typeof(Amazon.PinpointSMSVoiceV2.Model.SendRcsMessageResponse))]
    [AWSCmdletOutput("System.String or Amazon.PinpointSMSVoiceV2.Model.SendRcsMessageResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.PinpointSMSVoiceV2.Model.SendRcsMessageResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SendSMSVRcsMessageCmdlet : AmazonPinpointSMSVoiceV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter RcsMessageContent_Content_TextMessage_Body
        /// <summary>
        /// <para>
        /// <para>The text body of the RCS message. Maximum 3072 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RcsMessageContent_Content_TextMessage_Body { get; set; }
        #endregion
        
        #region Parameter RcsMessageContent_Content_Carousel_CardContent
        /// <summary>
        /// <para>
        /// <para>The list of cards in the carousel. Minimum 2, maximum 10 cards.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RcsMessageContent_Content_Carousel_CardContents")]
        public Amazon.PinpointSMSVoiceV2.Model.RcsCarouselCardContent[] RcsMessageContent_Content_Carousel_CardContent { get; set; }
        #endregion
        
        #region Parameter RcsMessageContent_Content_RichCard_CardOrientation
        /// <summary>
        /// <para>
        /// <para>The orientation of the rich card. Valid values are HORIZONTAL and VERTICAL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RcsMessageContent_Content_RichCard_CardOrientation { get; set; }
        #endregion
        
        #region Parameter RcsMessageContent_Content_Carousel_CardWidth
        /// <summary>
        /// <para>
        /// <para>The width of cards in the carousel. Valid values are SMALL and MEDIUM.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RcsMessageContent_Content_Carousel_CardWidth { get; set; }
        #endregion
        
        #region Parameter FallbackConfiguration_Channel
        /// <summary>
        /// <para>
        /// <para>The fallback channel to use when RCS delivery fails. Valid values are SMS and MMS.
        /// SMS and MMS are mutually exclusive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PinpointSMSVoiceV2.RcsFallbackChannel")]
        public Amazon.PinpointSMSVoiceV2.RcsFallbackChannel FallbackConfiguration_Channel { get; set; }
        #endregion
        
        #region Parameter ConfigurationSetName
        /// <summary>
        /// <para>
        /// <para>The name of the configuration set to use. This can be either the ConfigurationSetName
        /// or ConfigurationSetArn.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConfigurationSetName { get; set; }
        #endregion
        
        #region Parameter Context
        /// <summary>
        /// <para>
        /// <para>You can specify custom data in this field. If you do, that data is logged to the event
        /// destination.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable Context { get; set; }
        #endregion
        
        #region Parameter RcsMessageContent_Content_RichCard_CardContent_Description
        /// <summary>
        /// <para>
        /// <para>The description text of the card. Maximum 2000 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RcsMessageContent_Content_RichCard_CardContent_Description { get; set; }
        #endregion
        
        #region Parameter DestinationPhoneNumber
        /// <summary>
        /// <para>
        /// <para>The destination phone number in E.164 format.</para>
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
        public System.String DestinationPhoneNumber { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>When set to true, the message is checked and validated, but isn't sent to the end
        /// recipient.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter RcsMessageContent_Content_FileMessage_FileUrl
        /// <summary>
        /// <para>
        /// <para>The S3 URI of the media file to send, in the format <c>s3://bucket-name/key</c>. The
        /// service downloads the file from your S3 bucket, rehosts it, and generates a presigned
        /// URL for the aggregator. Maximum 2000 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RcsMessageContent_Content_FileMessage_FileUrl { get; set; }
        #endregion
        
        #region Parameter RcsMessageContent_Content_RichCard_CardContent_Media_FileUrl
        /// <summary>
        /// <para>
        /// <para>The S3 URI of the media file for the card, in the format <c>s3://bucket-name/key</c>.
        /// Maximum 2000 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RcsMessageContent_Content_RichCard_CardContent_Media_FileUrl { get; set; }
        #endregion
        
        #region Parameter RcsMessageContent_Content_RichCard_CardContent_Media_Height
        /// <summary>
        /// <para>
        /// <para>The display height of the media in the card. Valid values are SHORT, MEDIUM, and TALL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RcsMessageContent_Content_RichCard_CardContent_Media_Height { get; set; }
        #endregion
        
        #region Parameter MaxPrice
        /// <summary>
        /// <para>
        /// <para>The maximum amount that you want to spend, in US dollars, per each RCS message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MaxPrice { get; set; }
        #endregion
        
        #region Parameter FallbackConfiguration_MediaUrl
        /// <summary>
        /// <para>
        /// <para>An array of S3 URIs to media files for MMS fallback. Only valid when Channel is MMS.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FallbackConfiguration_MediaUrls")]
        public System.String[] FallbackConfiguration_MediaUrl { get; set; }
        #endregion
        
        #region Parameter FallbackConfiguration_MessageBody
        /// <summary>
        /// <para>
        /// <para>The text body of the fallback message. Required for SMS fallback. For MMS fallback,
        /// at least one of MessageBody or MediaUrls must be provided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FallbackConfiguration_MessageBody { get; set; }
        #endregion
        
        #region Parameter MessageFeedbackEnabled
        /// <summary>
        /// <para>
        /// <para>Set to true to enable message feedback for the message. When a user receives the message
        /// you need to update the message status using <a>PutMessageFeedback</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? MessageFeedbackEnabled { get; set; }
        #endregion
        
        #region Parameter MessageTrafficType
        /// <summary>
        /// <para>
        /// <para>The traffic type of the RCS message. Valid values are AUTHENTICATION, TRANSACTION,
        /// PROMOTION, SERVICE_REQUEST, and ACKNOWLEDGEMENT. This field is reserved for future
        /// use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MessageTrafficType { get; set; }
        #endregion
        
        #region Parameter FallbackConfiguration_OriginationIdentity
        /// <summary>
        /// <para>
        /// <para>The origination identity to use for the fallback message. This can be a PhoneNumber,
        /// PhoneNumberId, PhoneNumberArn, SenderId, or SenderIdArn. Pool IDs and pool ARNs are
        /// not accepted. If not specified and the original message was sent via a pool, the service
        /// selects a suitable number from the pool.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FallbackConfiguration_OriginationIdentity { get; set; }
        #endregion
        
        #region Parameter OriginationIdentity
        /// <summary>
        /// <para>
        /// <para>The origination identity of the message. This can be either the RcsAgentId, RcsAgentArn,
        /// PoolId, or PoolArn.</para>
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
        
        #region Parameter ProtectConfigurationId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the protect configuration to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProtectConfigurationId { get; set; }
        #endregion
        
        #region Parameter RcsMessageContent_Content_RichCard_CardContent_Suggestion
        /// <summary>
        /// <para>
        /// <para>Card-level suggested actions. Maximum 4 suggestions per card.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RcsMessageContent_Content_RichCard_CardContent_Suggestions")]
        public Amazon.PinpointSMSVoiceV2.Model.RcsSuggestedAction[] RcsMessageContent_Content_RichCard_CardContent_Suggestion { get; set; }
        #endregion
        
        #region Parameter RcsMessageContent_Suggestion
        /// <summary>
        /// <para>
        /// <para>Message-level suggested actions displayed to the recipient. Maximum 11 suggestions
        /// per message.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RcsMessageContent_Suggestions")]
        public Amazon.PinpointSMSVoiceV2.Model.RcsSuggestedAction[] RcsMessageContent_Suggestion { get; set; }
        #endregion
        
        #region Parameter RcsMessageContent_Content_RichCard_ThumbnailImageAlignment
        /// <summary>
        /// <para>
        /// <para>The alignment of the thumbnail image in a horizontal card. Valid values are LEFT and
        /// RIGHT. Only applicable when CardOrientation is HORIZONTAL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RcsMessageContent_Content_RichCard_ThumbnailImageAlignment { get; set; }
        #endregion
        
        #region Parameter RcsMessageContent_Content_FileMessage_ThumbnailUrl
        /// <summary>
        /// <para>
        /// <para>The S3 URI of an optional thumbnail image for the media file, in the format <c>s3://bucket-name/key</c>.
        /// Maximum 2000 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RcsMessageContent_Content_FileMessage_ThumbnailUrl { get; set; }
        #endregion
        
        #region Parameter RcsMessageContent_Content_RichCard_CardContent_Media_ThumbnailUrl
        /// <summary>
        /// <para>
        /// <para>The S3 URI of an optional thumbnail image for the card media. Maximum 2000 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RcsMessageContent_Content_RichCard_CardContent_Media_ThumbnailUrl { get; set; }
        #endregion
        
        #region Parameter TimeToLive
        /// <summary>
        /// <para>
        /// <para>The duration in seconds that the RCS message is valid for delivery. If the message
        /// cannot be delivered within this duration, it is considered expired. Valid values are
        /// 1 to 172800 (48 hours). If a FallbackConfiguration is provided, the fallback is triggered
        /// when the duration expires without delivery confirmation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? TimeToLive { get; set; }
        #endregion
        
        #region Parameter RcsMessageContent_Content_RichCard_CardContent_Title
        /// <summary>
        /// <para>
        /// <para>The title of the card. Maximum 200 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RcsMessageContent_Content_RichCard_CardContent_Title { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MessageId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PinpointSMSVoiceV2.Model.SendRcsMessageResponse).
        /// Specifying the name of a property of type Amazon.PinpointSMSVoiceV2.Model.SendRcsMessageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MessageId";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-SMSVRcsMessage (SendRcsMessage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PinpointSMSVoiceV2.Model.SendRcsMessageResponse, SendSMSVRcsMessageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConfigurationSetName = this.ConfigurationSetName;
            if (this.Context != null)
            {
                context.Context = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Context.Keys)
                {
                    context.Context.Add((String)hashKey, (System.String)(this.Context[hashKey]));
                }
            }
            context.DestinationPhoneNumber = this.DestinationPhoneNumber;
            #if MODULAR
            if (this.DestinationPhoneNumber == null && ParameterWasBound(nameof(this.DestinationPhoneNumber)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationPhoneNumber which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DryRun = this.DryRun;
            context.FallbackConfiguration_Channel = this.FallbackConfiguration_Channel;
            if (this.FallbackConfiguration_MediaUrl != null)
            {
                context.FallbackConfiguration_MediaUrl = new List<System.String>(this.FallbackConfiguration_MediaUrl);
            }
            context.FallbackConfiguration_MessageBody = this.FallbackConfiguration_MessageBody;
            context.FallbackConfiguration_OriginationIdentity = this.FallbackConfiguration_OriginationIdentity;
            context.MaxPrice = this.MaxPrice;
            context.MessageFeedbackEnabled = this.MessageFeedbackEnabled;
            context.MessageTrafficType = this.MessageTrafficType;
            context.OriginationIdentity = this.OriginationIdentity;
            #if MODULAR
            if (this.OriginationIdentity == null && ParameterWasBound(nameof(this.OriginationIdentity)))
            {
                WriteWarning("You are passing $null as a value for parameter OriginationIdentity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProtectConfigurationId = this.ProtectConfigurationId;
            if (this.RcsMessageContent_Content_Carousel_CardContent != null)
            {
                context.RcsMessageContent_Content_Carousel_CardContent = new List<Amazon.PinpointSMSVoiceV2.Model.RcsCarouselCardContent>(this.RcsMessageContent_Content_Carousel_CardContent);
            }
            context.RcsMessageContent_Content_Carousel_CardWidth = this.RcsMessageContent_Content_Carousel_CardWidth;
            context.RcsMessageContent_Content_FileMessage_FileUrl = this.RcsMessageContent_Content_FileMessage_FileUrl;
            context.RcsMessageContent_Content_FileMessage_ThumbnailUrl = this.RcsMessageContent_Content_FileMessage_ThumbnailUrl;
            context.RcsMessageContent_Content_RichCard_CardContent_Description = this.RcsMessageContent_Content_RichCard_CardContent_Description;
            context.RcsMessageContent_Content_RichCard_CardContent_Media_FileUrl = this.RcsMessageContent_Content_RichCard_CardContent_Media_FileUrl;
            context.RcsMessageContent_Content_RichCard_CardContent_Media_Height = this.RcsMessageContent_Content_RichCard_CardContent_Media_Height;
            context.RcsMessageContent_Content_RichCard_CardContent_Media_ThumbnailUrl = this.RcsMessageContent_Content_RichCard_CardContent_Media_ThumbnailUrl;
            if (this.RcsMessageContent_Content_RichCard_CardContent_Suggestion != null)
            {
                context.RcsMessageContent_Content_RichCard_CardContent_Suggestion = new List<Amazon.PinpointSMSVoiceV2.Model.RcsSuggestedAction>(this.RcsMessageContent_Content_RichCard_CardContent_Suggestion);
            }
            context.RcsMessageContent_Content_RichCard_CardContent_Title = this.RcsMessageContent_Content_RichCard_CardContent_Title;
            context.RcsMessageContent_Content_RichCard_CardOrientation = this.RcsMessageContent_Content_RichCard_CardOrientation;
            context.RcsMessageContent_Content_RichCard_ThumbnailImageAlignment = this.RcsMessageContent_Content_RichCard_ThumbnailImageAlignment;
            context.RcsMessageContent_Content_TextMessage_Body = this.RcsMessageContent_Content_TextMessage_Body;
            if (this.RcsMessageContent_Suggestion != null)
            {
                context.RcsMessageContent_Suggestion = new List<Amazon.PinpointSMSVoiceV2.Model.RcsSuggestedAction>(this.RcsMessageContent_Suggestion);
            }
            context.TimeToLive = this.TimeToLive;
            
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
            var request = new Amazon.PinpointSMSVoiceV2.Model.SendRcsMessageRequest();
            
            if (cmdletContext.ConfigurationSetName != null)
            {
                request.ConfigurationSetName = cmdletContext.ConfigurationSetName;
            }
            if (cmdletContext.Context != null)
            {
                request.Context = cmdletContext.Context;
            }
            if (cmdletContext.DestinationPhoneNumber != null)
            {
                request.DestinationPhoneNumber = cmdletContext.DestinationPhoneNumber;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            
             // populate FallbackConfiguration
            var requestFallbackConfigurationIsNull = true;
            request.FallbackConfiguration = new Amazon.PinpointSMSVoiceV2.Model.RcsFallbackConfiguration();
            Amazon.PinpointSMSVoiceV2.RcsFallbackChannel requestFallbackConfiguration_fallbackConfiguration_Channel = null;
            if (cmdletContext.FallbackConfiguration_Channel != null)
            {
                requestFallbackConfiguration_fallbackConfiguration_Channel = cmdletContext.FallbackConfiguration_Channel;
            }
            if (requestFallbackConfiguration_fallbackConfiguration_Channel != null)
            {
                request.FallbackConfiguration.Channel = requestFallbackConfiguration_fallbackConfiguration_Channel;
                requestFallbackConfigurationIsNull = false;
            }
            List<System.String> requestFallbackConfiguration_fallbackConfiguration_MediaUrl = null;
            if (cmdletContext.FallbackConfiguration_MediaUrl != null)
            {
                requestFallbackConfiguration_fallbackConfiguration_MediaUrl = cmdletContext.FallbackConfiguration_MediaUrl;
            }
            if (requestFallbackConfiguration_fallbackConfiguration_MediaUrl != null)
            {
                request.FallbackConfiguration.MediaUrls = requestFallbackConfiguration_fallbackConfiguration_MediaUrl;
                requestFallbackConfigurationIsNull = false;
            }
            System.String requestFallbackConfiguration_fallbackConfiguration_MessageBody = null;
            if (cmdletContext.FallbackConfiguration_MessageBody != null)
            {
                requestFallbackConfiguration_fallbackConfiguration_MessageBody = cmdletContext.FallbackConfiguration_MessageBody;
            }
            if (requestFallbackConfiguration_fallbackConfiguration_MessageBody != null)
            {
                request.FallbackConfiguration.MessageBody = requestFallbackConfiguration_fallbackConfiguration_MessageBody;
                requestFallbackConfigurationIsNull = false;
            }
            System.String requestFallbackConfiguration_fallbackConfiguration_OriginationIdentity = null;
            if (cmdletContext.FallbackConfiguration_OriginationIdentity != null)
            {
                requestFallbackConfiguration_fallbackConfiguration_OriginationIdentity = cmdletContext.FallbackConfiguration_OriginationIdentity;
            }
            if (requestFallbackConfiguration_fallbackConfiguration_OriginationIdentity != null)
            {
                request.FallbackConfiguration.OriginationIdentity = requestFallbackConfiguration_fallbackConfiguration_OriginationIdentity;
                requestFallbackConfigurationIsNull = false;
            }
             // determine if request.FallbackConfiguration should be set to null
            if (requestFallbackConfigurationIsNull)
            {
                request.FallbackConfiguration = null;
            }
            if (cmdletContext.MaxPrice != null)
            {
                request.MaxPrice = cmdletContext.MaxPrice;
            }
            if (cmdletContext.MessageFeedbackEnabled != null)
            {
                request.MessageFeedbackEnabled = cmdletContext.MessageFeedbackEnabled.Value;
            }
            if (cmdletContext.MessageTrafficType != null)
            {
                request.MessageTrafficType = cmdletContext.MessageTrafficType;
            }
            if (cmdletContext.OriginationIdentity != null)
            {
                request.OriginationIdentity = cmdletContext.OriginationIdentity;
            }
            if (cmdletContext.ProtectConfigurationId != null)
            {
                request.ProtectConfigurationId = cmdletContext.ProtectConfigurationId;
            }
            
             // populate RcsMessageContent
            var requestRcsMessageContentIsNull = true;
            request.RcsMessageContent = new Amazon.PinpointSMSVoiceV2.Model.RcsMessageContent();
            List<Amazon.PinpointSMSVoiceV2.Model.RcsSuggestedAction> requestRcsMessageContent_rcsMessageContent_Suggestion = null;
            if (cmdletContext.RcsMessageContent_Suggestion != null)
            {
                requestRcsMessageContent_rcsMessageContent_Suggestion = cmdletContext.RcsMessageContent_Suggestion;
            }
            if (requestRcsMessageContent_rcsMessageContent_Suggestion != null)
            {
                request.RcsMessageContent.Suggestions = requestRcsMessageContent_rcsMessageContent_Suggestion;
                requestRcsMessageContentIsNull = false;
            }
            Amazon.PinpointSMSVoiceV2.Model.RcsContent requestRcsMessageContent_rcsMessageContent_Content = null;
            
             // populate Content
            var requestRcsMessageContent_rcsMessageContent_ContentIsNull = true;
            requestRcsMessageContent_rcsMessageContent_Content = new Amazon.PinpointSMSVoiceV2.Model.RcsContent();
            Amazon.PinpointSMSVoiceV2.Model.RcsTextMessage requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_TextMessage = null;
            
             // populate TextMessage
            var requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_TextMessageIsNull = true;
            requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_TextMessage = new Amazon.PinpointSMSVoiceV2.Model.RcsTextMessage();
            System.String requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_TextMessage_rcsMessageContent_Content_TextMessage_Body = null;
            if (cmdletContext.RcsMessageContent_Content_TextMessage_Body != null)
            {
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_TextMessage_rcsMessageContent_Content_TextMessage_Body = cmdletContext.RcsMessageContent_Content_TextMessage_Body;
            }
            if (requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_TextMessage_rcsMessageContent_Content_TextMessage_Body != null)
            {
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_TextMessage.Body = requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_TextMessage_rcsMessageContent_Content_TextMessage_Body;
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_TextMessageIsNull = false;
            }
             // determine if requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_TextMessage should be set to null
            if (requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_TextMessageIsNull)
            {
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_TextMessage = null;
            }
            if (requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_TextMessage != null)
            {
                requestRcsMessageContent_rcsMessageContent_Content.TextMessage = requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_TextMessage;
                requestRcsMessageContent_rcsMessageContent_ContentIsNull = false;
            }
            Amazon.PinpointSMSVoiceV2.Model.RcsCarousel requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_Carousel = null;
            
             // populate Carousel
            var requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_CarouselIsNull = true;
            requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_Carousel = new Amazon.PinpointSMSVoiceV2.Model.RcsCarousel();
            List<Amazon.PinpointSMSVoiceV2.Model.RcsCarouselCardContent> requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_Carousel_rcsMessageContent_Content_Carousel_CardContent = null;
            if (cmdletContext.RcsMessageContent_Content_Carousel_CardContent != null)
            {
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_Carousel_rcsMessageContent_Content_Carousel_CardContent = cmdletContext.RcsMessageContent_Content_Carousel_CardContent;
            }
            if (requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_Carousel_rcsMessageContent_Content_Carousel_CardContent != null)
            {
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_Carousel.CardContents = requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_Carousel_rcsMessageContent_Content_Carousel_CardContent;
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_CarouselIsNull = false;
            }
            System.String requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_Carousel_rcsMessageContent_Content_Carousel_CardWidth = null;
            if (cmdletContext.RcsMessageContent_Content_Carousel_CardWidth != null)
            {
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_Carousel_rcsMessageContent_Content_Carousel_CardWidth = cmdletContext.RcsMessageContent_Content_Carousel_CardWidth;
            }
            if (requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_Carousel_rcsMessageContent_Content_Carousel_CardWidth != null)
            {
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_Carousel.CardWidth = requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_Carousel_rcsMessageContent_Content_Carousel_CardWidth;
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_CarouselIsNull = false;
            }
             // determine if requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_Carousel should be set to null
            if (requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_CarouselIsNull)
            {
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_Carousel = null;
            }
            if (requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_Carousel != null)
            {
                requestRcsMessageContent_rcsMessageContent_Content.Carousel = requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_Carousel;
                requestRcsMessageContent_rcsMessageContent_ContentIsNull = false;
            }
            Amazon.PinpointSMSVoiceV2.Model.RcsFileMessage requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_FileMessage = null;
            
             // populate FileMessage
            var requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_FileMessageIsNull = true;
            requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_FileMessage = new Amazon.PinpointSMSVoiceV2.Model.RcsFileMessage();
            System.String requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_FileMessage_rcsMessageContent_Content_FileMessage_FileUrl = null;
            if (cmdletContext.RcsMessageContent_Content_FileMessage_FileUrl != null)
            {
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_FileMessage_rcsMessageContent_Content_FileMessage_FileUrl = cmdletContext.RcsMessageContent_Content_FileMessage_FileUrl;
            }
            if (requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_FileMessage_rcsMessageContent_Content_FileMessage_FileUrl != null)
            {
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_FileMessage.FileUrl = requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_FileMessage_rcsMessageContent_Content_FileMessage_FileUrl;
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_FileMessageIsNull = false;
            }
            System.String requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_FileMessage_rcsMessageContent_Content_FileMessage_ThumbnailUrl = null;
            if (cmdletContext.RcsMessageContent_Content_FileMessage_ThumbnailUrl != null)
            {
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_FileMessage_rcsMessageContent_Content_FileMessage_ThumbnailUrl = cmdletContext.RcsMessageContent_Content_FileMessage_ThumbnailUrl;
            }
            if (requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_FileMessage_rcsMessageContent_Content_FileMessage_ThumbnailUrl != null)
            {
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_FileMessage.ThumbnailUrl = requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_FileMessage_rcsMessageContent_Content_FileMessage_ThumbnailUrl;
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_FileMessageIsNull = false;
            }
             // determine if requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_FileMessage should be set to null
            if (requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_FileMessageIsNull)
            {
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_FileMessage = null;
            }
            if (requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_FileMessage != null)
            {
                requestRcsMessageContent_rcsMessageContent_Content.FileMessage = requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_FileMessage;
                requestRcsMessageContent_rcsMessageContent_ContentIsNull = false;
            }
            Amazon.PinpointSMSVoiceV2.Model.RcsStandaloneCard requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard = null;
            
             // populate RichCard
            var requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCardIsNull = true;
            requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard = new Amazon.PinpointSMSVoiceV2.Model.RcsStandaloneCard();
            System.String requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardOrientation = null;
            if (cmdletContext.RcsMessageContent_Content_RichCard_CardOrientation != null)
            {
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardOrientation = cmdletContext.RcsMessageContent_Content_RichCard_CardOrientation;
            }
            if (requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardOrientation != null)
            {
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard.CardOrientation = requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardOrientation;
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCardIsNull = false;
            }
            System.String requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_ThumbnailImageAlignment = null;
            if (cmdletContext.RcsMessageContent_Content_RichCard_ThumbnailImageAlignment != null)
            {
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_ThumbnailImageAlignment = cmdletContext.RcsMessageContent_Content_RichCard_ThumbnailImageAlignment;
            }
            if (requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_ThumbnailImageAlignment != null)
            {
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard.ThumbnailImageAlignment = requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_ThumbnailImageAlignment;
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCardIsNull = false;
            }
            Amazon.PinpointSMSVoiceV2.Model.RcsCardContent requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent = null;
            
             // populate CardContent
            var requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContentIsNull = true;
            requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent = new Amazon.PinpointSMSVoiceV2.Model.RcsCardContent();
            System.String requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent_rcsMessageContent_Content_RichCard_CardContent_Description = null;
            if (cmdletContext.RcsMessageContent_Content_RichCard_CardContent_Description != null)
            {
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent_rcsMessageContent_Content_RichCard_CardContent_Description = cmdletContext.RcsMessageContent_Content_RichCard_CardContent_Description;
            }
            if (requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent_rcsMessageContent_Content_RichCard_CardContent_Description != null)
            {
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent.Description = requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent_rcsMessageContent_Content_RichCard_CardContent_Description;
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContentIsNull = false;
            }
            List<Amazon.PinpointSMSVoiceV2.Model.RcsSuggestedAction> requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent_rcsMessageContent_Content_RichCard_CardContent_Suggestion = null;
            if (cmdletContext.RcsMessageContent_Content_RichCard_CardContent_Suggestion != null)
            {
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent_rcsMessageContent_Content_RichCard_CardContent_Suggestion = cmdletContext.RcsMessageContent_Content_RichCard_CardContent_Suggestion;
            }
            if (requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent_rcsMessageContent_Content_RichCard_CardContent_Suggestion != null)
            {
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent.Suggestions = requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent_rcsMessageContent_Content_RichCard_CardContent_Suggestion;
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContentIsNull = false;
            }
            System.String requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent_rcsMessageContent_Content_RichCard_CardContent_Title = null;
            if (cmdletContext.RcsMessageContent_Content_RichCard_CardContent_Title != null)
            {
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent_rcsMessageContent_Content_RichCard_CardContent_Title = cmdletContext.RcsMessageContent_Content_RichCard_CardContent_Title;
            }
            if (requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent_rcsMessageContent_Content_RichCard_CardContent_Title != null)
            {
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent.Title = requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent_rcsMessageContent_Content_RichCard_CardContent_Title;
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContentIsNull = false;
            }
            Amazon.PinpointSMSVoiceV2.Model.RcsCardMedia requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent_rcsMessageContent_Content_RichCard_CardContent_Media = null;
            
             // populate Media
            var requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent_rcsMessageContent_Content_RichCard_CardContent_MediaIsNull = true;
            requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent_rcsMessageContent_Content_RichCard_CardContent_Media = new Amazon.PinpointSMSVoiceV2.Model.RcsCardMedia();
            System.String requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent_rcsMessageContent_Content_RichCard_CardContent_Media_rcsMessageContent_Content_RichCard_CardContent_Media_FileUrl = null;
            if (cmdletContext.RcsMessageContent_Content_RichCard_CardContent_Media_FileUrl != null)
            {
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent_rcsMessageContent_Content_RichCard_CardContent_Media_rcsMessageContent_Content_RichCard_CardContent_Media_FileUrl = cmdletContext.RcsMessageContent_Content_RichCard_CardContent_Media_FileUrl;
            }
            if (requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent_rcsMessageContent_Content_RichCard_CardContent_Media_rcsMessageContent_Content_RichCard_CardContent_Media_FileUrl != null)
            {
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent_rcsMessageContent_Content_RichCard_CardContent_Media.FileUrl = requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent_rcsMessageContent_Content_RichCard_CardContent_Media_rcsMessageContent_Content_RichCard_CardContent_Media_FileUrl;
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent_rcsMessageContent_Content_RichCard_CardContent_MediaIsNull = false;
            }
            System.String requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent_rcsMessageContent_Content_RichCard_CardContent_Media_rcsMessageContent_Content_RichCard_CardContent_Media_Height = null;
            if (cmdletContext.RcsMessageContent_Content_RichCard_CardContent_Media_Height != null)
            {
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent_rcsMessageContent_Content_RichCard_CardContent_Media_rcsMessageContent_Content_RichCard_CardContent_Media_Height = cmdletContext.RcsMessageContent_Content_RichCard_CardContent_Media_Height;
            }
            if (requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent_rcsMessageContent_Content_RichCard_CardContent_Media_rcsMessageContent_Content_RichCard_CardContent_Media_Height != null)
            {
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent_rcsMessageContent_Content_RichCard_CardContent_Media.Height = requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent_rcsMessageContent_Content_RichCard_CardContent_Media_rcsMessageContent_Content_RichCard_CardContent_Media_Height;
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent_rcsMessageContent_Content_RichCard_CardContent_MediaIsNull = false;
            }
            System.String requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent_rcsMessageContent_Content_RichCard_CardContent_Media_rcsMessageContent_Content_RichCard_CardContent_Media_ThumbnailUrl = null;
            if (cmdletContext.RcsMessageContent_Content_RichCard_CardContent_Media_ThumbnailUrl != null)
            {
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent_rcsMessageContent_Content_RichCard_CardContent_Media_rcsMessageContent_Content_RichCard_CardContent_Media_ThumbnailUrl = cmdletContext.RcsMessageContent_Content_RichCard_CardContent_Media_ThumbnailUrl;
            }
            if (requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent_rcsMessageContent_Content_RichCard_CardContent_Media_rcsMessageContent_Content_RichCard_CardContent_Media_ThumbnailUrl != null)
            {
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent_rcsMessageContent_Content_RichCard_CardContent_Media.ThumbnailUrl = requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent_rcsMessageContent_Content_RichCard_CardContent_Media_rcsMessageContent_Content_RichCard_CardContent_Media_ThumbnailUrl;
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent_rcsMessageContent_Content_RichCard_CardContent_MediaIsNull = false;
            }
             // determine if requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent_rcsMessageContent_Content_RichCard_CardContent_Media should be set to null
            if (requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent_rcsMessageContent_Content_RichCard_CardContent_MediaIsNull)
            {
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent_rcsMessageContent_Content_RichCard_CardContent_Media = null;
            }
            if (requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent_rcsMessageContent_Content_RichCard_CardContent_Media != null)
            {
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent.Media = requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent_rcsMessageContent_Content_RichCard_CardContent_Media;
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContentIsNull = false;
            }
             // determine if requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent should be set to null
            if (requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContentIsNull)
            {
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent = null;
            }
            if (requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent != null)
            {
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard.CardContent = requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard_rcsMessageContent_Content_RichCard_CardContent;
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCardIsNull = false;
            }
             // determine if requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard should be set to null
            if (requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCardIsNull)
            {
                requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard = null;
            }
            if (requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard != null)
            {
                requestRcsMessageContent_rcsMessageContent_Content.RichCard = requestRcsMessageContent_rcsMessageContent_Content_rcsMessageContent_Content_RichCard;
                requestRcsMessageContent_rcsMessageContent_ContentIsNull = false;
            }
             // determine if requestRcsMessageContent_rcsMessageContent_Content should be set to null
            if (requestRcsMessageContent_rcsMessageContent_ContentIsNull)
            {
                requestRcsMessageContent_rcsMessageContent_Content = null;
            }
            if (requestRcsMessageContent_rcsMessageContent_Content != null)
            {
                request.RcsMessageContent.Content = requestRcsMessageContent_rcsMessageContent_Content;
                requestRcsMessageContentIsNull = false;
            }
             // determine if request.RcsMessageContent should be set to null
            if (requestRcsMessageContentIsNull)
            {
                request.RcsMessageContent = null;
            }
            if (cmdletContext.TimeToLive != null)
            {
                request.TimeToLive = cmdletContext.TimeToLive.Value;
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
        
        private Amazon.PinpointSMSVoiceV2.Model.SendRcsMessageResponse CallAWSServiceOperation(IAmazonPinpointSMSVoiceV2 client, Amazon.PinpointSMSVoiceV2.Model.SendRcsMessageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint SMS Voice V2", "SendRcsMessage");
            try
            {
                return client.SendRcsMessageAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ConfigurationSetName { get; set; }
            public Dictionary<System.String, System.String> Context { get; set; }
            public System.String DestinationPhoneNumber { get; set; }
            public System.Boolean? DryRun { get; set; }
            public Amazon.PinpointSMSVoiceV2.RcsFallbackChannel FallbackConfiguration_Channel { get; set; }
            public List<System.String> FallbackConfiguration_MediaUrl { get; set; }
            public System.String FallbackConfiguration_MessageBody { get; set; }
            public System.String FallbackConfiguration_OriginationIdentity { get; set; }
            public System.String MaxPrice { get; set; }
            public System.Boolean? MessageFeedbackEnabled { get; set; }
            public System.String MessageTrafficType { get; set; }
            public System.String OriginationIdentity { get; set; }
            public System.String ProtectConfigurationId { get; set; }
            public List<Amazon.PinpointSMSVoiceV2.Model.RcsCarouselCardContent> RcsMessageContent_Content_Carousel_CardContent { get; set; }
            public System.String RcsMessageContent_Content_Carousel_CardWidth { get; set; }
            public System.String RcsMessageContent_Content_FileMessage_FileUrl { get; set; }
            public System.String RcsMessageContent_Content_FileMessage_ThumbnailUrl { get; set; }
            public System.String RcsMessageContent_Content_RichCard_CardContent_Description { get; set; }
            public System.String RcsMessageContent_Content_RichCard_CardContent_Media_FileUrl { get; set; }
            public System.String RcsMessageContent_Content_RichCard_CardContent_Media_Height { get; set; }
            public System.String RcsMessageContent_Content_RichCard_CardContent_Media_ThumbnailUrl { get; set; }
            public List<Amazon.PinpointSMSVoiceV2.Model.RcsSuggestedAction> RcsMessageContent_Content_RichCard_CardContent_Suggestion { get; set; }
            public System.String RcsMessageContent_Content_RichCard_CardContent_Title { get; set; }
            public System.String RcsMessageContent_Content_RichCard_CardOrientation { get; set; }
            public System.String RcsMessageContent_Content_RichCard_ThumbnailImageAlignment { get; set; }
            public System.String RcsMessageContent_Content_TextMessage_Body { get; set; }
            public List<Amazon.PinpointSMSVoiceV2.Model.RcsSuggestedAction> RcsMessageContent_Suggestion { get; set; }
            public System.Int32? TimeToLive { get; set; }
            public System.Func<Amazon.PinpointSMSVoiceV2.Model.SendRcsMessageResponse, SendSMSVRcsMessageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MessageId;
        }
        
    }
}
