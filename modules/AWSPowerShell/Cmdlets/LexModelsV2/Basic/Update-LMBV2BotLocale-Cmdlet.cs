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
using Amazon.LexModelsV2;
using Amazon.LexModelsV2.Model;

namespace Amazon.PowerShell.Cmdlets.LMBV2
{
    /// <summary>
    /// Updates the settings that a bot has for a specific locale.
    /// </summary>
    [Cmdlet("Update", "LMBV2BotLocale", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LexModelsV2.Model.UpdateBotLocaleResponse")]
    [AWSCmdlet("Calls the Amazon Lex Model Building V2 UpdateBotLocale API operation.", Operation = new[] {"UpdateBotLocale"}, SelectReturnType = typeof(Amazon.LexModelsV2.Model.UpdateBotLocaleResponse))]
    [AWSCmdletOutput("Amazon.LexModelsV2.Model.UpdateBotLocaleResponse",
        "This cmdlet returns an Amazon.LexModelsV2.Model.UpdateBotLocaleResponse object containing multiple properties."
    )]
    public partial class UpdateLMBV2BotLocaleCmdlet : AmazonLexModelsV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DeepgramConfig_ApiTokenSecretArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Secrets Manager secret that contains the Deepgram
        /// API token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SpeechRecognitionSettings_SpeechModelConfig_DeepgramConfig_ApiTokenSecretArn")]
        public System.String DeepgramConfig_ApiTokenSecretArn { get; set; }
        #endregion
        
        #region Parameter NluImprovement_AssistedNluMode
        /// <summary>
        /// <para>
        /// <para>Specifies the mode for Assisted NLU operation. Use <c>Primary</c> to make Assisted
        /// NLU the primary intent recognition method, or <c>Fallback</c> to use it only when
        /// standard NLU confidence is low.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GenerativeAISettings_RuntimeSettings_NluImprovement_AssistedNluMode")]
        [AWSConstantClassSource("Amazon.LexModelsV2.AssistedNluMode")]
        public Amazon.LexModelsV2.AssistedNluMode NluImprovement_AssistedNluMode { get; set; }
        #endregion
        
        #region Parameter BotId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the bot that contains the locale.</para>
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
        public System.String BotId { get; set; }
        #endregion
        
        #region Parameter BotVersion
        /// <summary>
        /// <para>
        /// <para>The version of the bot that contains the locale to be updated. The version can only
        /// be the <c>DRAFT</c> version.</para>
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
        public System.String BotVersion { get; set; }
        #endregion
        
        #region Parameter IntentDisambiguationSettings_CustomDisambiguationMessage
        /// <summary>
        /// <para>
        /// <para>Provides a custom message that will be displayed before presenting the disambiguation
        /// options to users. This message helps set the context for users and can be customized
        /// to match your bot's tone and brand. If not specified, a default message will be used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GenerativeAISettings_RuntimeSettings_NluImprovement_IntentDisambiguationSettings_CustomDisambiguationMessage")]
        public System.String IntentDisambiguationSettings_CustomDisambiguationMessage { get; set; }
        #endregion
        
        #region Parameter GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_CustomPrompt
        /// <summary>
        /// <para>
        /// <para>The custom prompt used in the Bedrock model specification details.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BedrockModelSpecification_CustomPrompt")]
        public System.String GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_CustomPrompt { get; set; }
        #endregion
        
        #region Parameter GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_CustomPrompt
        /// <summary>
        /// <para>
        /// <para>The custom prompt used in the Bedrock model specification details.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_CustomPrompt { get; set; }
        #endregion
        
        #region Parameter GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_CustomPrompt
        /// <summary>
        /// <para>
        /// <para>The custom prompt used in the Bedrock model specification details.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_CustomPrompt { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The new description of the locale.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DescriptiveBotBuilder_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether the descriptive bot building feature is activated or not.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_Enabled")]
        public System.Boolean? DescriptiveBotBuilder_Enabled { get; set; }
        #endregion
        
        #region Parameter SampleUtteranceGeneration_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable sample utterance generation or not.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_Enabled")]
        public System.Boolean? SampleUtteranceGeneration_Enabled { get; set; }
        #endregion
        
        #region Parameter NluImprovement_Enabled
        /// <summary>
        /// <para>
        /// <para>Determines whether the Assisted NLU feature is enabled for the bot. When set to <c>true</c>,
        /// Amazon Lex uses advanced models to improve intent recognition and slot resolution,
        /// with the default being <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GenerativeAISettings_RuntimeSettings_NluImprovement_Enabled")]
        public System.Boolean? NluImprovement_Enabled { get; set; }
        #endregion
        
        #region Parameter IntentDisambiguationSettings_Enabled
        /// <summary>
        /// <para>
        /// <para>Determines whether the Intent Disambiguation feature is enabled. When set to <c>true</c>,
        /// Amazon Lex will present disambiguation options to users when multiple intents could
        /// match their input, with the default being <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GenerativeAISettings_RuntimeSettings_NluImprovement_IntentDisambiguationSettings_Enabled")]
        public System.Boolean? IntentDisambiguationSettings_Enabled { get; set; }
        #endregion
        
        #region Parameter SlotResolutionImprovement_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether assisted slot resolution is turned on or off.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_Enabled")]
        public System.Boolean? SlotResolutionImprovement_Enabled { get; set; }
        #endregion
        
        #region Parameter VoiceSettings_Engine
        /// <summary>
        /// <para>
        /// <para>Indicates the type of Amazon Polly voice that Amazon Lex should use for voice interaction
        /// with the user. For more information, see the <a href="https://docs.aws.amazon.com/polly/latest/dg/API_SynthesizeSpeech.html#polly-SynthesizeSpeech-request-Engine"><c>engine</c> parameter of the <c>SynthesizeSpeech</c> operation</a> in the <i>Amazon
        /// Polly developer guide</i>.</para><para>If you do not specify a value, the default is <c>standard</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LexModelsV2.VoiceEngine")]
        public Amazon.LexModelsV2.VoiceEngine VoiceSettings_Engine { get; set; }
        #endregion
        
        #region Parameter GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_Guardrail_Identifier
        /// <summary>
        /// <para>
        /// <para>The unique guardrail id for the Bedrock guardrail configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BedrockModelSpecification_Guardrail_Identifier")]
        public System.String GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_Guardrail_Identifier { get; set; }
        #endregion
        
        #region Parameter GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_Guardrail_Identifier
        /// <summary>
        /// <para>
        /// <para>The unique guardrail id for the Bedrock guardrail configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_Guardrail_Identifier { get; set; }
        #endregion
        
        #region Parameter GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_Guardrail_Identifier
        /// <summary>
        /// <para>
        /// <para>The unique guardrail id for the Bedrock guardrail configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_Guardrail_Identifier { get; set; }
        #endregion
        
        #region Parameter LocaleId
        /// <summary>
        /// <para>
        /// <para>The identifier of the language and locale to update. The string must match one of
        /// the supported locales. For more information, see <a href="https://docs.aws.amazon.com/lexv2/latest/dg/how-languages.html">Supported
        /// languages</a>.</para>
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
        public System.String LocaleId { get; set; }
        #endregion
        
        #region Parameter IntentDisambiguationSettings_MaxDisambiguationIntent
        /// <summary>
        /// <para>
        /// <para>Specifies the maximum number of intent options (2-5) to present to users when disambiguation
        /// is needed. This setting determines how many intent options will be shown to users
        /// when the system detects ambiguous input. The default value is 3.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GenerativeAISettings_RuntimeSettings_NluImprovement_IntentDisambiguationSettings_MaxDisambiguationIntents")]
        public System.Int32? IntentDisambiguationSettings_MaxDisambiguationIntent { get; set; }
        #endregion
        
        #region Parameter GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_ModelArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the foundation model used in descriptive bot building.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BedrockModelSpecification_ModelArn")]
        public System.String GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_ModelArn { get; set; }
        #endregion
        
        #region Parameter GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_ModelArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the foundation model used in descriptive bot building.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_ModelArn { get; set; }
        #endregion
        
        #region Parameter GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_ModelArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the foundation model used in descriptive bot building.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_ModelArn { get; set; }
        #endregion
        
        #region Parameter SpeechFoundationModel_ModelArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the foundation model used for speech processing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UnifiedSpeechSettings_SpeechFoundationModel_ModelArn")]
        public System.String SpeechFoundationModel_ModelArn { get; set; }
        #endregion
        
        #region Parameter DeepgramConfig_ModelId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Deepgram speech-to-text model to use for processing speech input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SpeechRecognitionSettings_SpeechModelConfig_DeepgramConfig_ModelId")]
        public System.String DeepgramConfig_ModelId { get; set; }
        #endregion
        
        #region Parameter NluIntentConfidenceThreshold
        /// <summary>
        /// <para>
        /// <para>The new confidence threshold where Amazon Lex inserts the <c>AMAZON.FallbackIntent</c>
        /// and <c>AMAZON.KendraSearchIntent</c> intents in the list of possible intents for an
        /// utterance.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Double? NluIntentConfidenceThreshold { get; set; }
        #endregion
        
        #region Parameter SpeechDetectionSensitivity
        /// <summary>
        /// <para>
        /// <para>The new sensitivity level for voice activity detection (VAD) in the bot locale. This
        /// setting helps optimize speech recognition accuracy by adjusting how the system responds
        /// to background noise during voice interactions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LexModelsV2.SpeechDetectionSensitivity")]
        public Amazon.LexModelsV2.SpeechDetectionSensitivity SpeechDetectionSensitivity { get; set; }
        #endregion
        
        #region Parameter SpeechRecognitionSettings_SpeechModelPreference
        /// <summary>
        /// <para>
        /// <para>The speech-to-text model to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LexModelsV2.SpeechModelPreference")]
        public Amazon.LexModelsV2.SpeechModelPreference SpeechRecognitionSettings_SpeechModelPreference { get; set; }
        #endregion
        
        #region Parameter GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_TraceStatus
        /// <summary>
        /// <para>
        /// <para>The Bedrock trace status in the Bedrock model specification details.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BedrockModelSpecification_TraceStatus")]
        [AWSConstantClassSource("Amazon.LexModelsV2.BedrockTraceStatus")]
        public Amazon.LexModelsV2.BedrockTraceStatus GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_TraceStatus { get; set; }
        #endregion
        
        #region Parameter GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_TraceStatus
        /// <summary>
        /// <para>
        /// <para>The Bedrock trace status in the Bedrock model specification details.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LexModelsV2.BedrockTraceStatus")]
        public Amazon.LexModelsV2.BedrockTraceStatus GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_TraceStatus { get; set; }
        #endregion
        
        #region Parameter GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_TraceStatus
        /// <summary>
        /// <para>
        /// <para>The Bedrock trace status in the Bedrock model specification details.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LexModelsV2.BedrockTraceStatus")]
        public Amazon.LexModelsV2.BedrockTraceStatus GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_TraceStatus { get; set; }
        #endregion
        
        #region Parameter GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_Guardrail_Version
        /// <summary>
        /// <para>
        /// <para>The guardrail version for the Bedrock guardrail configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BedrockModelSpecification_Guardrail_Version")]
        public System.String GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_Guardrail_Version { get; set; }
        #endregion
        
        #region Parameter GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_Guardrail_Version
        /// <summary>
        /// <para>
        /// <para>The guardrail version for the Bedrock guardrail configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_Guardrail_Version { get; set; }
        #endregion
        
        #region Parameter GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_Guardrail_Version
        /// <summary>
        /// <para>
        /// <para>The guardrail version for the Bedrock guardrail configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_Guardrail_Version { get; set; }
        #endregion
        
        #region Parameter SpeechFoundationModel_VoiceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the voice to use for speech synthesis with the foundation model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UnifiedSpeechSettings_SpeechFoundationModel_VoiceId")]
        public System.String SpeechFoundationModel_VoiceId { get; set; }
        #endregion
        
        #region Parameter VoiceSettings_VoiceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Polly voice to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VoiceSettings_VoiceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LexModelsV2.Model.UpdateBotLocaleResponse).
        /// Specifying the name of a property of type Amazon.LexModelsV2.Model.UpdateBotLocaleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the LocaleId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^LocaleId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^LocaleId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LocaleId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LMBV2BotLocale (UpdateBotLocale)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LexModelsV2.Model.UpdateBotLocaleResponse, UpdateLMBV2BotLocaleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.LocaleId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BotId = this.BotId;
            #if MODULAR
            if (this.BotId == null && ParameterWasBound(nameof(this.BotId)))
            {
                WriteWarning("You are passing $null as a value for parameter BotId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BotVersion = this.BotVersion;
            #if MODULAR
            if (this.BotVersion == null && ParameterWasBound(nameof(this.BotVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter BotVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_CustomPrompt = this.GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_CustomPrompt;
            context.GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_Guardrail_Identifier = this.GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_Guardrail_Identifier;
            context.GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_Guardrail_Version = this.GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_Guardrail_Version;
            context.GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_ModelArn = this.GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_ModelArn;
            context.GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_TraceStatus = this.GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_TraceStatus;
            context.DescriptiveBotBuilder_Enabled = this.DescriptiveBotBuilder_Enabled;
            context.GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_CustomPrompt = this.GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_CustomPrompt;
            context.GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_Guardrail_Identifier = this.GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_Guardrail_Identifier;
            context.GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_Guardrail_Version = this.GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_Guardrail_Version;
            context.GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_ModelArn = this.GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_ModelArn;
            context.GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_TraceStatus = this.GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_TraceStatus;
            context.SampleUtteranceGeneration_Enabled = this.SampleUtteranceGeneration_Enabled;
            context.NluImprovement_AssistedNluMode = this.NluImprovement_AssistedNluMode;
            context.NluImprovement_Enabled = this.NluImprovement_Enabled;
            context.IntentDisambiguationSettings_CustomDisambiguationMessage = this.IntentDisambiguationSettings_CustomDisambiguationMessage;
            context.IntentDisambiguationSettings_Enabled = this.IntentDisambiguationSettings_Enabled;
            context.IntentDisambiguationSettings_MaxDisambiguationIntent = this.IntentDisambiguationSettings_MaxDisambiguationIntent;
            context.GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_CustomPrompt = this.GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_CustomPrompt;
            context.GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_Guardrail_Identifier = this.GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_Guardrail_Identifier;
            context.GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_Guardrail_Version = this.GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_Guardrail_Version;
            context.GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_ModelArn = this.GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_ModelArn;
            context.GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_TraceStatus = this.GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_TraceStatus;
            context.SlotResolutionImprovement_Enabled = this.SlotResolutionImprovement_Enabled;
            context.LocaleId = this.LocaleId;
            #if MODULAR
            if (this.LocaleId == null && ParameterWasBound(nameof(this.LocaleId)))
            {
                WriteWarning("You are passing $null as a value for parameter LocaleId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NluIntentConfidenceThreshold = this.NluIntentConfidenceThreshold;
            #if MODULAR
            if (this.NluIntentConfidenceThreshold == null && ParameterWasBound(nameof(this.NluIntentConfidenceThreshold)))
            {
                WriteWarning("You are passing $null as a value for parameter NluIntentConfidenceThreshold which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SpeechDetectionSensitivity = this.SpeechDetectionSensitivity;
            context.DeepgramConfig_ApiTokenSecretArn = this.DeepgramConfig_ApiTokenSecretArn;
            context.DeepgramConfig_ModelId = this.DeepgramConfig_ModelId;
            context.SpeechRecognitionSettings_SpeechModelPreference = this.SpeechRecognitionSettings_SpeechModelPreference;
            context.SpeechFoundationModel_ModelArn = this.SpeechFoundationModel_ModelArn;
            context.SpeechFoundationModel_VoiceId = this.SpeechFoundationModel_VoiceId;
            context.VoiceSettings_Engine = this.VoiceSettings_Engine;
            context.VoiceSettings_VoiceId = this.VoiceSettings_VoiceId;
            
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
            var request = new Amazon.LexModelsV2.Model.UpdateBotLocaleRequest();
            
            if (cmdletContext.BotId != null)
            {
                request.BotId = cmdletContext.BotId;
            }
            if (cmdletContext.BotVersion != null)
            {
                request.BotVersion = cmdletContext.BotVersion;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate GenerativeAISettings
            var requestGenerativeAISettingsIsNull = true;
            request.GenerativeAISettings = new Amazon.LexModelsV2.Model.GenerativeAISettings();
            Amazon.LexModelsV2.Model.BuildtimeSettings requestGenerativeAISettings_generativeAISettings_BuildtimeSettings = null;
            
             // populate BuildtimeSettings
            var requestGenerativeAISettings_generativeAISettings_BuildtimeSettingsIsNull = true;
            requestGenerativeAISettings_generativeAISettings_BuildtimeSettings = new Amazon.LexModelsV2.Model.BuildtimeSettings();
            Amazon.LexModelsV2.Model.DescriptiveBotBuilderSpecification requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder = null;
            
             // populate DescriptiveBotBuilder
            var requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilderIsNull = true;
            requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder = new Amazon.LexModelsV2.Model.DescriptiveBotBuilderSpecification();
            System.Boolean? requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_descriptiveBotBuilder_Enabled = null;
            if (cmdletContext.DescriptiveBotBuilder_Enabled != null)
            {
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_descriptiveBotBuilder_Enabled = cmdletContext.DescriptiveBotBuilder_Enabled.Value;
            }
            if (requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_descriptiveBotBuilder_Enabled != null)
            {
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder.Enabled = requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_descriptiveBotBuilder_Enabled.Value;
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilderIsNull = false;
            }
            Amazon.LexModelsV2.Model.BedrockModelSpecification requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification = null;
            
             // populate BedrockModelSpecification
            var requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecificationIsNull = true;
            requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification = new Amazon.LexModelsV2.Model.BedrockModelSpecification();
            System.String requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_CustomPrompt = null;
            if (cmdletContext.GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_CustomPrompt != null)
            {
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_CustomPrompt = cmdletContext.GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_CustomPrompt;
            }
            if (requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_CustomPrompt != null)
            {
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification.CustomPrompt = requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_CustomPrompt;
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecificationIsNull = false;
            }
            System.String requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_ModelArn = null;
            if (cmdletContext.GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_ModelArn != null)
            {
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_ModelArn = cmdletContext.GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_ModelArn;
            }
            if (requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_ModelArn != null)
            {
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification.ModelArn = requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_ModelArn;
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecificationIsNull = false;
            }
            Amazon.LexModelsV2.BedrockTraceStatus requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_TraceStatus = null;
            if (cmdletContext.GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_TraceStatus != null)
            {
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_TraceStatus = cmdletContext.GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_TraceStatus;
            }
            if (requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_TraceStatus != null)
            {
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification.TraceStatus = requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_TraceStatus;
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecificationIsNull = false;
            }
            Amazon.LexModelsV2.Model.BedrockGuardrailConfiguration requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_Guardrail = null;
            
             // populate Guardrail
            var requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_GuardrailIsNull = true;
            requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_Guardrail = new Amazon.LexModelsV2.Model.BedrockGuardrailConfiguration();
            System.String requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_Guardrail_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_Guardrail_Identifier = null;
            if (cmdletContext.GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_Guardrail_Identifier != null)
            {
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_Guardrail_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_Guardrail_Identifier = cmdletContext.GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_Guardrail_Identifier;
            }
            if (requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_Guardrail_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_Guardrail_Identifier != null)
            {
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_Guardrail.Identifier = requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_Guardrail_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_Guardrail_Identifier;
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_GuardrailIsNull = false;
            }
            System.String requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_Guardrail_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_Guardrail_Version = null;
            if (cmdletContext.GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_Guardrail_Version != null)
            {
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_Guardrail_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_Guardrail_Version = cmdletContext.GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_Guardrail_Version;
            }
            if (requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_Guardrail_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_Guardrail_Version != null)
            {
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_Guardrail.Version = requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_Guardrail_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_Guardrail_Version;
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_GuardrailIsNull = false;
            }
             // determine if requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_Guardrail should be set to null
            if (requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_GuardrailIsNull)
            {
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_Guardrail = null;
            }
            if (requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_Guardrail != null)
            {
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification.Guardrail = requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_Guardrail;
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecificationIsNull = false;
            }
             // determine if requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification should be set to null
            if (requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecificationIsNull)
            {
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification = null;
            }
            if (requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification != null)
            {
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder.BedrockModelSpecification = requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification;
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilderIsNull = false;
            }
             // determine if requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder should be set to null
            if (requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilderIsNull)
            {
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder = null;
            }
            if (requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder != null)
            {
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings.DescriptiveBotBuilder = requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_DescriptiveBotBuilder;
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettingsIsNull = false;
            }
            Amazon.LexModelsV2.Model.SampleUtteranceGenerationSpecification requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration = null;
            
             // populate SampleUtteranceGeneration
            var requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGenerationIsNull = true;
            requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration = new Amazon.LexModelsV2.Model.SampleUtteranceGenerationSpecification();
            System.Boolean? requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_sampleUtteranceGeneration_Enabled = null;
            if (cmdletContext.SampleUtteranceGeneration_Enabled != null)
            {
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_sampleUtteranceGeneration_Enabled = cmdletContext.SampleUtteranceGeneration_Enabled.Value;
            }
            if (requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_sampleUtteranceGeneration_Enabled != null)
            {
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration.Enabled = requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_sampleUtteranceGeneration_Enabled.Value;
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGenerationIsNull = false;
            }
            Amazon.LexModelsV2.Model.BedrockModelSpecification requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification = null;
            
             // populate BedrockModelSpecification
            var requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecificationIsNull = true;
            requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification = new Amazon.LexModelsV2.Model.BedrockModelSpecification();
            System.String requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_CustomPrompt = null;
            if (cmdletContext.GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_CustomPrompt != null)
            {
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_CustomPrompt = cmdletContext.GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_CustomPrompt;
            }
            if (requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_CustomPrompt != null)
            {
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification.CustomPrompt = requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_CustomPrompt;
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecificationIsNull = false;
            }
            System.String requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_ModelArn = null;
            if (cmdletContext.GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_ModelArn != null)
            {
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_ModelArn = cmdletContext.GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_ModelArn;
            }
            if (requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_ModelArn != null)
            {
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification.ModelArn = requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_ModelArn;
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecificationIsNull = false;
            }
            Amazon.LexModelsV2.BedrockTraceStatus requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_TraceStatus = null;
            if (cmdletContext.GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_TraceStatus != null)
            {
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_TraceStatus = cmdletContext.GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_TraceStatus;
            }
            if (requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_TraceStatus != null)
            {
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification.TraceStatus = requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_TraceStatus;
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecificationIsNull = false;
            }
            Amazon.LexModelsV2.Model.BedrockGuardrailConfiguration requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_Guardrail = null;
            
             // populate Guardrail
            var requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_GuardrailIsNull = true;
            requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_Guardrail = new Amazon.LexModelsV2.Model.BedrockGuardrailConfiguration();
            System.String requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_Guardrail_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_Guardrail_Identifier = null;
            if (cmdletContext.GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_Guardrail_Identifier != null)
            {
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_Guardrail_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_Guardrail_Identifier = cmdletContext.GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_Guardrail_Identifier;
            }
            if (requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_Guardrail_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_Guardrail_Identifier != null)
            {
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_Guardrail.Identifier = requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_Guardrail_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_Guardrail_Identifier;
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_GuardrailIsNull = false;
            }
            System.String requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_Guardrail_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_Guardrail_Version = null;
            if (cmdletContext.GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_Guardrail_Version != null)
            {
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_Guardrail_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_Guardrail_Version = cmdletContext.GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_Guardrail_Version;
            }
            if (requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_Guardrail_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_Guardrail_Version != null)
            {
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_Guardrail.Version = requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_Guardrail_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_Guardrail_Version;
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_GuardrailIsNull = false;
            }
             // determine if requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_Guardrail should be set to null
            if (requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_GuardrailIsNull)
            {
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_Guardrail = null;
            }
            if (requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_Guardrail != null)
            {
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification.Guardrail = requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_Guardrail;
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecificationIsNull = false;
            }
             // determine if requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification should be set to null
            if (requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecificationIsNull)
            {
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification = null;
            }
            if (requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification != null)
            {
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration.BedrockModelSpecification = requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification;
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGenerationIsNull = false;
            }
             // determine if requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration should be set to null
            if (requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGenerationIsNull)
            {
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration = null;
            }
            if (requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration != null)
            {
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings.SampleUtteranceGeneration = requestGenerativeAISettings_generativeAISettings_BuildtimeSettings_generativeAISettings_BuildtimeSettings_SampleUtteranceGeneration;
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettingsIsNull = false;
            }
             // determine if requestGenerativeAISettings_generativeAISettings_BuildtimeSettings should be set to null
            if (requestGenerativeAISettings_generativeAISettings_BuildtimeSettingsIsNull)
            {
                requestGenerativeAISettings_generativeAISettings_BuildtimeSettings = null;
            }
            if (requestGenerativeAISettings_generativeAISettings_BuildtimeSettings != null)
            {
                request.GenerativeAISettings.BuildtimeSettings = requestGenerativeAISettings_generativeAISettings_BuildtimeSettings;
                requestGenerativeAISettingsIsNull = false;
            }
            Amazon.LexModelsV2.Model.RuntimeSettings requestGenerativeAISettings_generativeAISettings_RuntimeSettings = null;
            
             // populate RuntimeSettings
            var requestGenerativeAISettings_generativeAISettings_RuntimeSettingsIsNull = true;
            requestGenerativeAISettings_generativeAISettings_RuntimeSettings = new Amazon.LexModelsV2.Model.RuntimeSettings();
            Amazon.LexModelsV2.Model.SlotResolutionImprovementSpecification requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement = null;
            
             // populate SlotResolutionImprovement
            var requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovementIsNull = true;
            requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement = new Amazon.LexModelsV2.Model.SlotResolutionImprovementSpecification();
            System.Boolean? requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_slotResolutionImprovement_Enabled = null;
            if (cmdletContext.SlotResolutionImprovement_Enabled != null)
            {
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_slotResolutionImprovement_Enabled = cmdletContext.SlotResolutionImprovement_Enabled.Value;
            }
            if (requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_slotResolutionImprovement_Enabled != null)
            {
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement.Enabled = requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_slotResolutionImprovement_Enabled.Value;
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovementIsNull = false;
            }
            Amazon.LexModelsV2.Model.BedrockModelSpecification requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification = null;
            
             // populate BedrockModelSpecification
            var requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecificationIsNull = true;
            requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification = new Amazon.LexModelsV2.Model.BedrockModelSpecification();
            System.String requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_CustomPrompt = null;
            if (cmdletContext.GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_CustomPrompt != null)
            {
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_CustomPrompt = cmdletContext.GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_CustomPrompt;
            }
            if (requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_CustomPrompt != null)
            {
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification.CustomPrompt = requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_CustomPrompt;
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecificationIsNull = false;
            }
            System.String requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_ModelArn = null;
            if (cmdletContext.GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_ModelArn != null)
            {
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_ModelArn = cmdletContext.GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_ModelArn;
            }
            if (requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_ModelArn != null)
            {
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification.ModelArn = requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_ModelArn;
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecificationIsNull = false;
            }
            Amazon.LexModelsV2.BedrockTraceStatus requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_TraceStatus = null;
            if (cmdletContext.GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_TraceStatus != null)
            {
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_TraceStatus = cmdletContext.GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_TraceStatus;
            }
            if (requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_TraceStatus != null)
            {
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification.TraceStatus = requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_TraceStatus;
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecificationIsNull = false;
            }
            Amazon.LexModelsV2.Model.BedrockGuardrailConfiguration requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_Guardrail = null;
            
             // populate Guardrail
            var requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_GuardrailIsNull = true;
            requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_Guardrail = new Amazon.LexModelsV2.Model.BedrockGuardrailConfiguration();
            System.String requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_Guardrail_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_Guardrail_Identifier = null;
            if (cmdletContext.GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_Guardrail_Identifier != null)
            {
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_Guardrail_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_Guardrail_Identifier = cmdletContext.GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_Guardrail_Identifier;
            }
            if (requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_Guardrail_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_Guardrail_Identifier != null)
            {
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_Guardrail.Identifier = requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_Guardrail_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_Guardrail_Identifier;
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_GuardrailIsNull = false;
            }
            System.String requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_Guardrail_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_Guardrail_Version = null;
            if (cmdletContext.GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_Guardrail_Version != null)
            {
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_Guardrail_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_Guardrail_Version = cmdletContext.GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_Guardrail_Version;
            }
            if (requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_Guardrail_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_Guardrail_Version != null)
            {
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_Guardrail.Version = requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_Guardrail_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_Guardrail_Version;
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_GuardrailIsNull = false;
            }
             // determine if requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_Guardrail should be set to null
            if (requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_GuardrailIsNull)
            {
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_Guardrail = null;
            }
            if (requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_Guardrail != null)
            {
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification.Guardrail = requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_Guardrail;
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecificationIsNull = false;
            }
             // determine if requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification should be set to null
            if (requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecificationIsNull)
            {
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification = null;
            }
            if (requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification != null)
            {
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement.BedrockModelSpecification = requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_generativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification;
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovementIsNull = false;
            }
             // determine if requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement should be set to null
            if (requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovementIsNull)
            {
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement = null;
            }
            if (requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement != null)
            {
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings.SlotResolutionImprovement = requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_SlotResolutionImprovement;
                requestGenerativeAISettings_generativeAISettings_RuntimeSettingsIsNull = false;
            }
            Amazon.LexModelsV2.Model.NluImprovementSpecification requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovement = null;
            
             // populate NluImprovement
            var requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovementIsNull = true;
            requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovement = new Amazon.LexModelsV2.Model.NluImprovementSpecification();
            Amazon.LexModelsV2.AssistedNluMode requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovement_nluImprovement_AssistedNluMode = null;
            if (cmdletContext.NluImprovement_AssistedNluMode != null)
            {
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovement_nluImprovement_AssistedNluMode = cmdletContext.NluImprovement_AssistedNluMode;
            }
            if (requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovement_nluImprovement_AssistedNluMode != null)
            {
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovement.AssistedNluMode = requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovement_nluImprovement_AssistedNluMode;
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovementIsNull = false;
            }
            System.Boolean? requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovement_nluImprovement_Enabled = null;
            if (cmdletContext.NluImprovement_Enabled != null)
            {
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovement_nluImprovement_Enabled = cmdletContext.NluImprovement_Enabled.Value;
            }
            if (requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovement_nluImprovement_Enabled != null)
            {
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovement.Enabled = requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovement_nluImprovement_Enabled.Value;
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovementIsNull = false;
            }
            Amazon.LexModelsV2.Model.IntentDisambiguationSettings requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovement_generativeAISettings_RuntimeSettings_NluImprovement_IntentDisambiguationSettings = null;
            
             // populate IntentDisambiguationSettings
            var requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovement_generativeAISettings_RuntimeSettings_NluImprovement_IntentDisambiguationSettingsIsNull = true;
            requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovement_generativeAISettings_RuntimeSettings_NluImprovement_IntentDisambiguationSettings = new Amazon.LexModelsV2.Model.IntentDisambiguationSettings();
            System.String requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovement_generativeAISettings_RuntimeSettings_NluImprovement_IntentDisambiguationSettings_intentDisambiguationSettings_CustomDisambiguationMessage = null;
            if (cmdletContext.IntentDisambiguationSettings_CustomDisambiguationMessage != null)
            {
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovement_generativeAISettings_RuntimeSettings_NluImprovement_IntentDisambiguationSettings_intentDisambiguationSettings_CustomDisambiguationMessage = cmdletContext.IntentDisambiguationSettings_CustomDisambiguationMessage;
            }
            if (requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovement_generativeAISettings_RuntimeSettings_NluImprovement_IntentDisambiguationSettings_intentDisambiguationSettings_CustomDisambiguationMessage != null)
            {
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovement_generativeAISettings_RuntimeSettings_NluImprovement_IntentDisambiguationSettings.CustomDisambiguationMessage = requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovement_generativeAISettings_RuntimeSettings_NluImprovement_IntentDisambiguationSettings_intentDisambiguationSettings_CustomDisambiguationMessage;
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovement_generativeAISettings_RuntimeSettings_NluImprovement_IntentDisambiguationSettingsIsNull = false;
            }
            System.Boolean? requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovement_generativeAISettings_RuntimeSettings_NluImprovement_IntentDisambiguationSettings_intentDisambiguationSettings_Enabled = null;
            if (cmdletContext.IntentDisambiguationSettings_Enabled != null)
            {
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovement_generativeAISettings_RuntimeSettings_NluImprovement_IntentDisambiguationSettings_intentDisambiguationSettings_Enabled = cmdletContext.IntentDisambiguationSettings_Enabled.Value;
            }
            if (requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovement_generativeAISettings_RuntimeSettings_NluImprovement_IntentDisambiguationSettings_intentDisambiguationSettings_Enabled != null)
            {
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovement_generativeAISettings_RuntimeSettings_NluImprovement_IntentDisambiguationSettings.Enabled = requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovement_generativeAISettings_RuntimeSettings_NluImprovement_IntentDisambiguationSettings_intentDisambiguationSettings_Enabled.Value;
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovement_generativeAISettings_RuntimeSettings_NluImprovement_IntentDisambiguationSettingsIsNull = false;
            }
            System.Int32? requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovement_generativeAISettings_RuntimeSettings_NluImprovement_IntentDisambiguationSettings_intentDisambiguationSettings_MaxDisambiguationIntent = null;
            if (cmdletContext.IntentDisambiguationSettings_MaxDisambiguationIntent != null)
            {
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovement_generativeAISettings_RuntimeSettings_NluImprovement_IntentDisambiguationSettings_intentDisambiguationSettings_MaxDisambiguationIntent = cmdletContext.IntentDisambiguationSettings_MaxDisambiguationIntent.Value;
            }
            if (requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovement_generativeAISettings_RuntimeSettings_NluImprovement_IntentDisambiguationSettings_intentDisambiguationSettings_MaxDisambiguationIntent != null)
            {
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovement_generativeAISettings_RuntimeSettings_NluImprovement_IntentDisambiguationSettings.MaxDisambiguationIntents = requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovement_generativeAISettings_RuntimeSettings_NluImprovement_IntentDisambiguationSettings_intentDisambiguationSettings_MaxDisambiguationIntent.Value;
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovement_generativeAISettings_RuntimeSettings_NluImprovement_IntentDisambiguationSettingsIsNull = false;
            }
             // determine if requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovement_generativeAISettings_RuntimeSettings_NluImprovement_IntentDisambiguationSettings should be set to null
            if (requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovement_generativeAISettings_RuntimeSettings_NluImprovement_IntentDisambiguationSettingsIsNull)
            {
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovement_generativeAISettings_RuntimeSettings_NluImprovement_IntentDisambiguationSettings = null;
            }
            if (requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovement_generativeAISettings_RuntimeSettings_NluImprovement_IntentDisambiguationSettings != null)
            {
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovement.IntentDisambiguationSettings = requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovement_generativeAISettings_RuntimeSettings_NluImprovement_IntentDisambiguationSettings;
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovementIsNull = false;
            }
             // determine if requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovement should be set to null
            if (requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovementIsNull)
            {
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovement = null;
            }
            if (requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovement != null)
            {
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings.NluImprovement = requestGenerativeAISettings_generativeAISettings_RuntimeSettings_generativeAISettings_RuntimeSettings_NluImprovement;
                requestGenerativeAISettings_generativeAISettings_RuntimeSettingsIsNull = false;
            }
             // determine if requestGenerativeAISettings_generativeAISettings_RuntimeSettings should be set to null
            if (requestGenerativeAISettings_generativeAISettings_RuntimeSettingsIsNull)
            {
                requestGenerativeAISettings_generativeAISettings_RuntimeSettings = null;
            }
            if (requestGenerativeAISettings_generativeAISettings_RuntimeSettings != null)
            {
                request.GenerativeAISettings.RuntimeSettings = requestGenerativeAISettings_generativeAISettings_RuntimeSettings;
                requestGenerativeAISettingsIsNull = false;
            }
             // determine if request.GenerativeAISettings should be set to null
            if (requestGenerativeAISettingsIsNull)
            {
                request.GenerativeAISettings = null;
            }
            if (cmdletContext.LocaleId != null)
            {
                request.LocaleId = cmdletContext.LocaleId;
            }
            if (cmdletContext.NluIntentConfidenceThreshold != null)
            {
                request.NluIntentConfidenceThreshold = cmdletContext.NluIntentConfidenceThreshold.Value;
            }
            if (cmdletContext.SpeechDetectionSensitivity != null)
            {
                request.SpeechDetectionSensitivity = cmdletContext.SpeechDetectionSensitivity;
            }
            
             // populate SpeechRecognitionSettings
            var requestSpeechRecognitionSettingsIsNull = true;
            request.SpeechRecognitionSettings = new Amazon.LexModelsV2.Model.SpeechRecognitionSettings();
            Amazon.LexModelsV2.SpeechModelPreference requestSpeechRecognitionSettings_speechRecognitionSettings_SpeechModelPreference = null;
            if (cmdletContext.SpeechRecognitionSettings_SpeechModelPreference != null)
            {
                requestSpeechRecognitionSettings_speechRecognitionSettings_SpeechModelPreference = cmdletContext.SpeechRecognitionSettings_SpeechModelPreference;
            }
            if (requestSpeechRecognitionSettings_speechRecognitionSettings_SpeechModelPreference != null)
            {
                request.SpeechRecognitionSettings.SpeechModelPreference = requestSpeechRecognitionSettings_speechRecognitionSettings_SpeechModelPreference;
                requestSpeechRecognitionSettingsIsNull = false;
            }
            Amazon.LexModelsV2.Model.SpeechModelConfig requestSpeechRecognitionSettings_speechRecognitionSettings_SpeechModelConfig = null;
            
             // populate SpeechModelConfig
            var requestSpeechRecognitionSettings_speechRecognitionSettings_SpeechModelConfigIsNull = true;
            requestSpeechRecognitionSettings_speechRecognitionSettings_SpeechModelConfig = new Amazon.LexModelsV2.Model.SpeechModelConfig();
            Amazon.LexModelsV2.Model.DeepgramSpeechModelConfig requestSpeechRecognitionSettings_speechRecognitionSettings_SpeechModelConfig_speechRecognitionSettings_SpeechModelConfig_DeepgramConfig = null;
            
             // populate DeepgramConfig
            var requestSpeechRecognitionSettings_speechRecognitionSettings_SpeechModelConfig_speechRecognitionSettings_SpeechModelConfig_DeepgramConfigIsNull = true;
            requestSpeechRecognitionSettings_speechRecognitionSettings_SpeechModelConfig_speechRecognitionSettings_SpeechModelConfig_DeepgramConfig = new Amazon.LexModelsV2.Model.DeepgramSpeechModelConfig();
            System.String requestSpeechRecognitionSettings_speechRecognitionSettings_SpeechModelConfig_speechRecognitionSettings_SpeechModelConfig_DeepgramConfig_deepgramConfig_ApiTokenSecretArn = null;
            if (cmdletContext.DeepgramConfig_ApiTokenSecretArn != null)
            {
                requestSpeechRecognitionSettings_speechRecognitionSettings_SpeechModelConfig_speechRecognitionSettings_SpeechModelConfig_DeepgramConfig_deepgramConfig_ApiTokenSecretArn = cmdletContext.DeepgramConfig_ApiTokenSecretArn;
            }
            if (requestSpeechRecognitionSettings_speechRecognitionSettings_SpeechModelConfig_speechRecognitionSettings_SpeechModelConfig_DeepgramConfig_deepgramConfig_ApiTokenSecretArn != null)
            {
                requestSpeechRecognitionSettings_speechRecognitionSettings_SpeechModelConfig_speechRecognitionSettings_SpeechModelConfig_DeepgramConfig.ApiTokenSecretArn = requestSpeechRecognitionSettings_speechRecognitionSettings_SpeechModelConfig_speechRecognitionSettings_SpeechModelConfig_DeepgramConfig_deepgramConfig_ApiTokenSecretArn;
                requestSpeechRecognitionSettings_speechRecognitionSettings_SpeechModelConfig_speechRecognitionSettings_SpeechModelConfig_DeepgramConfigIsNull = false;
            }
            System.String requestSpeechRecognitionSettings_speechRecognitionSettings_SpeechModelConfig_speechRecognitionSettings_SpeechModelConfig_DeepgramConfig_deepgramConfig_ModelId = null;
            if (cmdletContext.DeepgramConfig_ModelId != null)
            {
                requestSpeechRecognitionSettings_speechRecognitionSettings_SpeechModelConfig_speechRecognitionSettings_SpeechModelConfig_DeepgramConfig_deepgramConfig_ModelId = cmdletContext.DeepgramConfig_ModelId;
            }
            if (requestSpeechRecognitionSettings_speechRecognitionSettings_SpeechModelConfig_speechRecognitionSettings_SpeechModelConfig_DeepgramConfig_deepgramConfig_ModelId != null)
            {
                requestSpeechRecognitionSettings_speechRecognitionSettings_SpeechModelConfig_speechRecognitionSettings_SpeechModelConfig_DeepgramConfig.ModelId = requestSpeechRecognitionSettings_speechRecognitionSettings_SpeechModelConfig_speechRecognitionSettings_SpeechModelConfig_DeepgramConfig_deepgramConfig_ModelId;
                requestSpeechRecognitionSettings_speechRecognitionSettings_SpeechModelConfig_speechRecognitionSettings_SpeechModelConfig_DeepgramConfigIsNull = false;
            }
             // determine if requestSpeechRecognitionSettings_speechRecognitionSettings_SpeechModelConfig_speechRecognitionSettings_SpeechModelConfig_DeepgramConfig should be set to null
            if (requestSpeechRecognitionSettings_speechRecognitionSettings_SpeechModelConfig_speechRecognitionSettings_SpeechModelConfig_DeepgramConfigIsNull)
            {
                requestSpeechRecognitionSettings_speechRecognitionSettings_SpeechModelConfig_speechRecognitionSettings_SpeechModelConfig_DeepgramConfig = null;
            }
            if (requestSpeechRecognitionSettings_speechRecognitionSettings_SpeechModelConfig_speechRecognitionSettings_SpeechModelConfig_DeepgramConfig != null)
            {
                requestSpeechRecognitionSettings_speechRecognitionSettings_SpeechModelConfig.DeepgramConfig = requestSpeechRecognitionSettings_speechRecognitionSettings_SpeechModelConfig_speechRecognitionSettings_SpeechModelConfig_DeepgramConfig;
                requestSpeechRecognitionSettings_speechRecognitionSettings_SpeechModelConfigIsNull = false;
            }
             // determine if requestSpeechRecognitionSettings_speechRecognitionSettings_SpeechModelConfig should be set to null
            if (requestSpeechRecognitionSettings_speechRecognitionSettings_SpeechModelConfigIsNull)
            {
                requestSpeechRecognitionSettings_speechRecognitionSettings_SpeechModelConfig = null;
            }
            if (requestSpeechRecognitionSettings_speechRecognitionSettings_SpeechModelConfig != null)
            {
                request.SpeechRecognitionSettings.SpeechModelConfig = requestSpeechRecognitionSettings_speechRecognitionSettings_SpeechModelConfig;
                requestSpeechRecognitionSettingsIsNull = false;
            }
             // determine if request.SpeechRecognitionSettings should be set to null
            if (requestSpeechRecognitionSettingsIsNull)
            {
                request.SpeechRecognitionSettings = null;
            }
            
             // populate UnifiedSpeechSettings
            var requestUnifiedSpeechSettingsIsNull = true;
            request.UnifiedSpeechSettings = new Amazon.LexModelsV2.Model.UnifiedSpeechSettings();
            Amazon.LexModelsV2.Model.SpeechFoundationModel requestUnifiedSpeechSettings_unifiedSpeechSettings_SpeechFoundationModel = null;
            
             // populate SpeechFoundationModel
            var requestUnifiedSpeechSettings_unifiedSpeechSettings_SpeechFoundationModelIsNull = true;
            requestUnifiedSpeechSettings_unifiedSpeechSettings_SpeechFoundationModel = new Amazon.LexModelsV2.Model.SpeechFoundationModel();
            System.String requestUnifiedSpeechSettings_unifiedSpeechSettings_SpeechFoundationModel_speechFoundationModel_ModelArn = null;
            if (cmdletContext.SpeechFoundationModel_ModelArn != null)
            {
                requestUnifiedSpeechSettings_unifiedSpeechSettings_SpeechFoundationModel_speechFoundationModel_ModelArn = cmdletContext.SpeechFoundationModel_ModelArn;
            }
            if (requestUnifiedSpeechSettings_unifiedSpeechSettings_SpeechFoundationModel_speechFoundationModel_ModelArn != null)
            {
                requestUnifiedSpeechSettings_unifiedSpeechSettings_SpeechFoundationModel.ModelArn = requestUnifiedSpeechSettings_unifiedSpeechSettings_SpeechFoundationModel_speechFoundationModel_ModelArn;
                requestUnifiedSpeechSettings_unifiedSpeechSettings_SpeechFoundationModelIsNull = false;
            }
            System.String requestUnifiedSpeechSettings_unifiedSpeechSettings_SpeechFoundationModel_speechFoundationModel_VoiceId = null;
            if (cmdletContext.SpeechFoundationModel_VoiceId != null)
            {
                requestUnifiedSpeechSettings_unifiedSpeechSettings_SpeechFoundationModel_speechFoundationModel_VoiceId = cmdletContext.SpeechFoundationModel_VoiceId;
            }
            if (requestUnifiedSpeechSettings_unifiedSpeechSettings_SpeechFoundationModel_speechFoundationModel_VoiceId != null)
            {
                requestUnifiedSpeechSettings_unifiedSpeechSettings_SpeechFoundationModel.VoiceId = requestUnifiedSpeechSettings_unifiedSpeechSettings_SpeechFoundationModel_speechFoundationModel_VoiceId;
                requestUnifiedSpeechSettings_unifiedSpeechSettings_SpeechFoundationModelIsNull = false;
            }
             // determine if requestUnifiedSpeechSettings_unifiedSpeechSettings_SpeechFoundationModel should be set to null
            if (requestUnifiedSpeechSettings_unifiedSpeechSettings_SpeechFoundationModelIsNull)
            {
                requestUnifiedSpeechSettings_unifiedSpeechSettings_SpeechFoundationModel = null;
            }
            if (requestUnifiedSpeechSettings_unifiedSpeechSettings_SpeechFoundationModel != null)
            {
                request.UnifiedSpeechSettings.SpeechFoundationModel = requestUnifiedSpeechSettings_unifiedSpeechSettings_SpeechFoundationModel;
                requestUnifiedSpeechSettingsIsNull = false;
            }
             // determine if request.UnifiedSpeechSettings should be set to null
            if (requestUnifiedSpeechSettingsIsNull)
            {
                request.UnifiedSpeechSettings = null;
            }
            
             // populate VoiceSettings
            var requestVoiceSettingsIsNull = true;
            request.VoiceSettings = new Amazon.LexModelsV2.Model.VoiceSettings();
            Amazon.LexModelsV2.VoiceEngine requestVoiceSettings_voiceSettings_Engine = null;
            if (cmdletContext.VoiceSettings_Engine != null)
            {
                requestVoiceSettings_voiceSettings_Engine = cmdletContext.VoiceSettings_Engine;
            }
            if (requestVoiceSettings_voiceSettings_Engine != null)
            {
                request.VoiceSettings.Engine = requestVoiceSettings_voiceSettings_Engine;
                requestVoiceSettingsIsNull = false;
            }
            System.String requestVoiceSettings_voiceSettings_VoiceId = null;
            if (cmdletContext.VoiceSettings_VoiceId != null)
            {
                requestVoiceSettings_voiceSettings_VoiceId = cmdletContext.VoiceSettings_VoiceId;
            }
            if (requestVoiceSettings_voiceSettings_VoiceId != null)
            {
                request.VoiceSettings.VoiceId = requestVoiceSettings_voiceSettings_VoiceId;
                requestVoiceSettingsIsNull = false;
            }
             // determine if request.VoiceSettings should be set to null
            if (requestVoiceSettingsIsNull)
            {
                request.VoiceSettings = null;
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
        
        private Amazon.LexModelsV2.Model.UpdateBotLocaleResponse CallAWSServiceOperation(IAmazonLexModelsV2 client, Amazon.LexModelsV2.Model.UpdateBotLocaleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lex Model Building V2", "UpdateBotLocale");
            try
            {
                #if DESKTOP
                return client.UpdateBotLocale(request);
                #elif CORECLR
                return client.UpdateBotLocaleAsync(request).GetAwaiter().GetResult();
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
            public System.String BotId { get; set; }
            public System.String BotVersion { get; set; }
            public System.String Description { get; set; }
            public System.String GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_CustomPrompt { get; set; }
            public System.String GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_Guardrail_Identifier { get; set; }
            public System.String GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_Guardrail_Version { get; set; }
            public System.String GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_ModelArn { get; set; }
            public Amazon.LexModelsV2.BedrockTraceStatus GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_TraceStatus { get; set; }
            public System.Boolean? DescriptiveBotBuilder_Enabled { get; set; }
            public System.String GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_CustomPrompt { get; set; }
            public System.String GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_Guardrail_Identifier { get; set; }
            public System.String GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_Guardrail_Version { get; set; }
            public System.String GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_ModelArn { get; set; }
            public Amazon.LexModelsV2.BedrockTraceStatus GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_TraceStatus { get; set; }
            public System.Boolean? SampleUtteranceGeneration_Enabled { get; set; }
            public Amazon.LexModelsV2.AssistedNluMode NluImprovement_AssistedNluMode { get; set; }
            public System.Boolean? NluImprovement_Enabled { get; set; }
            public System.String IntentDisambiguationSettings_CustomDisambiguationMessage { get; set; }
            public System.Boolean? IntentDisambiguationSettings_Enabled { get; set; }
            public System.Int32? IntentDisambiguationSettings_MaxDisambiguationIntent { get; set; }
            public System.String GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_CustomPrompt { get; set; }
            public System.String GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_Guardrail_Identifier { get; set; }
            public System.String GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_Guardrail_Version { get; set; }
            public System.String GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_ModelArn { get; set; }
            public Amazon.LexModelsV2.BedrockTraceStatus GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_TraceStatus { get; set; }
            public System.Boolean? SlotResolutionImprovement_Enabled { get; set; }
            public System.String LocaleId { get; set; }
            public System.Double? NluIntentConfidenceThreshold { get; set; }
            public Amazon.LexModelsV2.SpeechDetectionSensitivity SpeechDetectionSensitivity { get; set; }
            public System.String DeepgramConfig_ApiTokenSecretArn { get; set; }
            public System.String DeepgramConfig_ModelId { get; set; }
            public Amazon.LexModelsV2.SpeechModelPreference SpeechRecognitionSettings_SpeechModelPreference { get; set; }
            public System.String SpeechFoundationModel_ModelArn { get; set; }
            public System.String SpeechFoundationModel_VoiceId { get; set; }
            public Amazon.LexModelsV2.VoiceEngine VoiceSettings_Engine { get; set; }
            public System.String VoiceSettings_VoiceId { get; set; }
            public System.Func<Amazon.LexModelsV2.Model.UpdateBotLocaleResponse, UpdateLMBV2BotLocaleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
