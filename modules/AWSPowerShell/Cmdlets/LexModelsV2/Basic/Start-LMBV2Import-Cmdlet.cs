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
    /// Starts importing a bot, bot locale, or custom vocabulary from a zip archive that you
    /// uploaded to an S3 bucket.
    /// </summary>
    [Cmdlet("Start", "LMBV2Import", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LexModelsV2.Model.StartImportResponse")]
    [AWSCmdlet("Calls the Amazon Lex Model Building V2 StartImport API operation.", Operation = new[] {"StartImport"}, SelectReturnType = typeof(Amazon.LexModelsV2.Model.StartImportResponse))]
    [AWSCmdletOutput("Amazon.LexModelsV2.Model.StartImportResponse",
        "This cmdlet returns an Amazon.LexModelsV2.Model.StartImportResponse object containing multiple properties."
    )]
    public partial class StartLMBV2ImportCmdlet : AmazonLexModelsV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BotLocaleImportSpecification_BotId
        /// <summary>
        /// <para>
        /// <para>The identifier of the bot to import the locale to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceSpecification_BotLocaleImportSpecification_BotId")]
        public System.String BotLocaleImportSpecification_BotId { get; set; }
        #endregion
        
        #region Parameter CustomVocabularyImportSpecification_BotId
        /// <summary>
        /// <para>
        /// <para>The identifier of the bot to import the custom vocabulary to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceSpecification_CustomVocabularyImportSpecification_BotId")]
        public System.String CustomVocabularyImportSpecification_BotId { get; set; }
        #endregion
        
        #region Parameter BotImportSpecification_BotName
        /// <summary>
        /// <para>
        /// <para>The name that Amazon Lex should use for the bot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceSpecification_BotImportSpecification_BotName")]
        public System.String BotImportSpecification_BotName { get; set; }
        #endregion
        
        #region Parameter BotImportSpecification_BotTag
        /// <summary>
        /// <para>
        /// <para>A list of tags to add to the bot. You can only add tags when you import a bot. You
        /// can't use the <c>UpdateBot</c> operation to update tags. To update tags, use the <c>TagResource</c>
        /// operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceSpecification_BotImportSpecification_BotTags")]
        public System.Collections.Hashtable BotImportSpecification_BotTag { get; set; }
        #endregion
        
        #region Parameter BotLocaleImportSpecification_BotVersion
        /// <summary>
        /// <para>
        /// <para>The version of the bot to import the locale to. This can only be the <c>DRAFT</c>
        /// version of the bot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceSpecification_BotLocaleImportSpecification_BotVersion")]
        public System.String BotLocaleImportSpecification_BotVersion { get; set; }
        #endregion
        
        #region Parameter CustomVocabularyImportSpecification_BotVersion
        /// <summary>
        /// <para>
        /// <para>The version of the bot to import the custom vocabulary to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceSpecification_CustomVocabularyImportSpecification_BotVersion")]
        public System.String CustomVocabularyImportSpecification_BotVersion { get; set; }
        #endregion
        
        #region Parameter DataPrivacy_ChildDirected
        /// <summary>
        /// <para>
        /// <para>For each Amazon Lex bot created with the Amazon Lex Model Building Service, you must
        /// specify whether your use of Amazon Lex is related to a website, program, or other
        /// application that is directed or targeted, in whole or in part, to children under age
        /// 13 and subject to the Children's Online Privacy Protection Act (COPPA) by specifying
        /// <c>true</c> or <c>false</c> in the <c>childDirected</c> field. By specifying <c>true</c>
        /// in the <c>childDirected</c> field, you confirm that your use of Amazon Lex <b>is</b>
        /// related to a website, program, or other application that is directed or targeted,
        /// in whole or in part, to children under age 13 and subject to COPPA. By specifying
        /// <c>false</c> in the <c>childDirected</c> field, you confirm that your use of Amazon
        /// Lex <b>is not</b> related to a website, program, or other application that is directed
        /// or targeted, in whole or in part, to children under age 13 and subject to COPPA. You
        /// may not specify a default value for the <c>childDirected</c> field that does not accurately
        /// reflect whether your use of Amazon Lex is related to a website, program, or other
        /// application that is directed or targeted, in whole or in part, to children under age
        /// 13 and subject to COPPA. If your use of Amazon Lex relates to a website, program,
        /// or other application that is directed in whole or in part, to children under age 13,
        /// you must obtain any required verifiable parental consent under COPPA. For information
        /// regarding the use of Amazon Lex in connection with websites, programs, or other applications
        /// that are directed or targeted, in whole or in part, to children under age 13, see
        /// the <a href="http://aws.amazon.com/lex/faqs#data-security">Amazon Lex FAQ</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceSpecification_BotImportSpecification_DataPrivacy_ChildDirected")]
        public System.Boolean? DataPrivacy_ChildDirected { get; set; }
        #endregion
        
        #region Parameter TestSetImportResourceSpecification_Description
        /// <summary>
        /// <para>
        /// <para>The description of the test set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceSpecification_TestSetImportResourceSpecification_Description")]
        public System.String TestSetImportResourceSpecification_Description { get; set; }
        #endregion
        
        #region Parameter ErrorLogSettings_Enabled
        /// <summary>
        /// <para>
        /// <para>Settings parameters for the error logs, when it is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceSpecification_BotImportSpecification_ErrorLogSettings_Enabled")]
        public System.Boolean? ErrorLogSettings_Enabled { get; set; }
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
        [Alias("ResourceSpecification_BotLocaleImportSpecification_VoiceSettings_Engine")]
        [AWSConstantClassSource("Amazon.LexModelsV2.VoiceEngine")]
        public Amazon.LexModelsV2.VoiceEngine VoiceSettings_Engine { get; set; }
        #endregion
        
        #region Parameter FilePassword
        /// <summary>
        /// <para>
        /// <para>The password used to encrypt the zip archive that contains the resource definition.
        /// You should always encrypt the zip archive to protect it during transit between your
        /// site and Amazon Lex.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FilePassword { get; set; }
        #endregion
        
        #region Parameter BotImportSpecification_IdleSessionTTLInSecond
        /// <summary>
        /// <para>
        /// <para>The time, in seconds, that Amazon Lex should keep information about a user's conversation
        /// with the bot. </para><para>A user interaction remains active for the amount of time specified. If no conversation
        /// occurs during this time, the session expires and Amazon Lex deletes any data provided
        /// before the timeout.</para><para>You can specify between 60 (1 minute) and 86,400 (24 hours) seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceSpecification_BotImportSpecification_IdleSessionTTLInSeconds")]
        public System.Int32? BotImportSpecification_IdleSessionTTLInSecond { get; set; }
        #endregion
        
        #region Parameter ImportId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the import. It is included in the response from the <a href="https://docs.aws.amazon.com/lexv2/latest/APIReference/API_CreateUploadUrl.html">CreateUploadUrl</a>
        /// operation.</para>
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
        public System.String ImportId { get; set; }
        #endregion
        
        #region Parameter StorageLocation_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an Amazon Web Services Key Management Service (KMS)
        /// key for encrypting the test set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceSpecification_TestSetImportResourceSpecification_StorageLocation_KmsKeyArn")]
        public System.String StorageLocation_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter BotLocaleImportSpecification_LocaleId
        /// <summary>
        /// <para>
        /// <para>The identifier of the language and locale that the bot will be used in. The string
        /// must match one of the supported locales. All of the intents, slot types, and slots
        /// used in the bot must have the same locale. For more information, see <a href="https://docs.aws.amazon.com/lexv2/latest/dg/how-languages.html">Supported
        /// languages</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceSpecification_BotLocaleImportSpecification_LocaleId")]
        public System.String BotLocaleImportSpecification_LocaleId { get; set; }
        #endregion
        
        #region Parameter CustomVocabularyImportSpecification_LocaleId
        /// <summary>
        /// <para>
        /// <para>The identifier of the local to import the custom vocabulary to. The value must be
        /// <c>en_GB</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceSpecification_CustomVocabularyImportSpecification_LocaleId")]
        public System.String CustomVocabularyImportSpecification_LocaleId { get; set; }
        #endregion
        
        #region Parameter MergeStrategy
        /// <summary>
        /// <para>
        /// <para>The strategy to use when there is a name conflict between the imported resource and
        /// an existing resource. When the merge strategy is <c>FailOnConflict</c> existing resources
        /// are not overwritten and the import fails.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.LexModelsV2.MergeStrategy")]
        public Amazon.LexModelsV2.MergeStrategy MergeStrategy { get; set; }
        #endregion
        
        #region Parameter TestSetImportResourceSpecification_Modality
        /// <summary>
        /// <para>
        /// <para>Specifies whether the test-set being imported contains written or spoken data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceSpecification_TestSetImportResourceSpecification_Modality")]
        [AWSConstantClassSource("Amazon.LexModelsV2.TestSetModality")]
        public Amazon.LexModelsV2.TestSetModality TestSetImportResourceSpecification_Modality { get; set; }
        #endregion
        
        #region Parameter BotLocaleImportSpecification_NluIntentConfidenceThreshold
        /// <summary>
        /// <para>
        /// <para>Determines the threshold where Amazon Lex will insert the <c>AMAZON.FallbackIntent</c>,
        /// <c>AMAZON.KendraSearchIntent</c>, or both when returning alternative intents. <c>AMAZON.FallbackIntent</c>
        /// and <c>AMAZON.KendraSearchIntent</c> are only inserted if they are configured for
        /// the bot. </para><para>For example, suppose a bot is configured with the confidence threshold of 0.80 and
        /// the <c>AMAZON.FallbackIntent</c>. Amazon Lex returns three alternative intents with
        /// the following confidence scores: IntentA (0.70), IntentB (0.60), IntentC (0.50). The
        /// response from the <c>PostText</c> operation would be:</para><ul><li><para><c>AMAZON.FallbackIntent</c></para></li><li><para><c>IntentA</c></para></li><li><para><c>IntentB</c></para></li><li><para><c>IntentC</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceSpecification_BotLocaleImportSpecification_NluIntentConfidenceThreshold")]
        public System.Double? BotLocaleImportSpecification_NluIntentConfidenceThreshold { get; set; }
        #endregion
        
        #region Parameter BotImportSpecification_RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role used to build and run the bot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceSpecification_BotImportSpecification_RoleArn")]
        public System.String BotImportSpecification_RoleArn { get; set; }
        #endregion
        
        #region Parameter TestSetImportResourceSpecification_RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an IAM role that has permission to access the test
        /// set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceSpecification_TestSetImportResourceSpecification_RoleArn")]
        public System.String TestSetImportResourceSpecification_RoleArn { get; set; }
        #endregion
        
        #region Parameter ImportInputLocation_S3BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceSpecification_TestSetImportResourceSpecification_ImportInputLocation_S3BucketName")]
        public System.String ImportInputLocation_S3BucketName { get; set; }
        #endregion
        
        #region Parameter StorageLocation_S3BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon S3 bucket in which the test set is stored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceSpecification_TestSetImportResourceSpecification_StorageLocation_S3BucketName")]
        public System.String StorageLocation_S3BucketName { get; set; }
        #endregion
        
        #region Parameter ImportInputLocation_S3Path
        /// <summary>
        /// <para>
        /// <para>The path inside the Amazon S3 bucket pointing to the test-set CSV file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceSpecification_TestSetImportResourceSpecification_ImportInputLocation_S3Path")]
        public System.String ImportInputLocation_S3Path { get; set; }
        #endregion
        
        #region Parameter StorageLocation_S3Path
        /// <summary>
        /// <para>
        /// <para>The path inside the Amazon S3 bucket where the test set is stored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceSpecification_TestSetImportResourceSpecification_StorageLocation_S3Path")]
        public System.String StorageLocation_S3Path { get; set; }
        #endregion
        
        #region Parameter BotLocaleImportSpecification_SpeechDetectionSensitivity
        /// <summary>
        /// <para>
        /// <para>The sensitivity level for voice activity detection (VAD) in the bot locale. This setting
        /// helps optimize speech recognition accuracy by adjusting how the system responds to
        /// background noise during voice interactions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceSpecification_BotLocaleImportSpecification_SpeechDetectionSensitivity")]
        [AWSConstantClassSource("Amazon.LexModelsV2.SpeechDetectionSensitivity")]
        public Amazon.LexModelsV2.SpeechDetectionSensitivity BotLocaleImportSpecification_SpeechDetectionSensitivity { get; set; }
        #endregion
        
        #region Parameter BotImportSpecification_TestBotAliasTag
        /// <summary>
        /// <para>
        /// <para>A list of tags to add to the test alias for a bot. You can only add tags when you
        /// import a bot. You can't use the <c>UpdateAlias</c> operation to update tags. To update
        /// tags on the test alias, use the <c>TagResource</c> operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceSpecification_BotImportSpecification_TestBotAliasTags")]
        public System.Collections.Hashtable BotImportSpecification_TestBotAliasTag { get; set; }
        #endregion
        
        #region Parameter TestSetImportResourceSpecification_TestSetName
        /// <summary>
        /// <para>
        /// <para>The name of the test set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceSpecification_TestSetImportResourceSpecification_TestSetName")]
        public System.String TestSetImportResourceSpecification_TestSetName { get; set; }
        #endregion
        
        #region Parameter TestSetImportResourceSpecification_TestSetTag
        /// <summary>
        /// <para>
        /// <para>A list of tags to add to the test set. You can only add tags when you import/generate
        /// a new test set. You can't use the <c>UpdateTestSet</c> operation to update tags. To
        /// update tags, use the <c>TagResource</c> operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceSpecification_TestSetImportResourceSpecification_TestSetTags")]
        public System.Collections.Hashtable TestSetImportResourceSpecification_TestSetTag { get; set; }
        #endregion
        
        #region Parameter VoiceSettings_VoiceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Polly voice to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceSpecification_BotLocaleImportSpecification_VoiceSettings_VoiceId")]
        public System.String VoiceSettings_VoiceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LexModelsV2.Model.StartImportResponse).
        /// Specifying the name of a property of type Amazon.LexModelsV2.Model.StartImportResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ImportId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ImportId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ImportId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ImportId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-LMBV2Import (StartImport)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LexModelsV2.Model.StartImportResponse, StartLMBV2ImportCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ImportId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.FilePassword = this.FilePassword;
            context.ImportId = this.ImportId;
            #if MODULAR
            if (this.ImportId == null && ParameterWasBound(nameof(this.ImportId)))
            {
                WriteWarning("You are passing $null as a value for parameter ImportId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MergeStrategy = this.MergeStrategy;
            #if MODULAR
            if (this.MergeStrategy == null && ParameterWasBound(nameof(this.MergeStrategy)))
            {
                WriteWarning("You are passing $null as a value for parameter MergeStrategy which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BotImportSpecification_BotName = this.BotImportSpecification_BotName;
            if (this.BotImportSpecification_BotTag != null)
            {
                context.BotImportSpecification_BotTag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.BotImportSpecification_BotTag.Keys)
                {
                    context.BotImportSpecification_BotTag.Add((String)hashKey, (System.String)(this.BotImportSpecification_BotTag[hashKey]));
                }
            }
            context.DataPrivacy_ChildDirected = this.DataPrivacy_ChildDirected;
            context.ErrorLogSettings_Enabled = this.ErrorLogSettings_Enabled;
            context.BotImportSpecification_IdleSessionTTLInSecond = this.BotImportSpecification_IdleSessionTTLInSecond;
            context.BotImportSpecification_RoleArn = this.BotImportSpecification_RoleArn;
            if (this.BotImportSpecification_TestBotAliasTag != null)
            {
                context.BotImportSpecification_TestBotAliasTag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.BotImportSpecification_TestBotAliasTag.Keys)
                {
                    context.BotImportSpecification_TestBotAliasTag.Add((String)hashKey, (System.String)(this.BotImportSpecification_TestBotAliasTag[hashKey]));
                }
            }
            context.BotLocaleImportSpecification_BotId = this.BotLocaleImportSpecification_BotId;
            context.BotLocaleImportSpecification_BotVersion = this.BotLocaleImportSpecification_BotVersion;
            context.BotLocaleImportSpecification_LocaleId = this.BotLocaleImportSpecification_LocaleId;
            context.BotLocaleImportSpecification_NluIntentConfidenceThreshold = this.BotLocaleImportSpecification_NluIntentConfidenceThreshold;
            context.BotLocaleImportSpecification_SpeechDetectionSensitivity = this.BotLocaleImportSpecification_SpeechDetectionSensitivity;
            context.VoiceSettings_Engine = this.VoiceSettings_Engine;
            context.VoiceSettings_VoiceId = this.VoiceSettings_VoiceId;
            context.CustomVocabularyImportSpecification_BotId = this.CustomVocabularyImportSpecification_BotId;
            context.CustomVocabularyImportSpecification_BotVersion = this.CustomVocabularyImportSpecification_BotVersion;
            context.CustomVocabularyImportSpecification_LocaleId = this.CustomVocabularyImportSpecification_LocaleId;
            context.TestSetImportResourceSpecification_Description = this.TestSetImportResourceSpecification_Description;
            context.ImportInputLocation_S3BucketName = this.ImportInputLocation_S3BucketName;
            context.ImportInputLocation_S3Path = this.ImportInputLocation_S3Path;
            context.TestSetImportResourceSpecification_Modality = this.TestSetImportResourceSpecification_Modality;
            context.TestSetImportResourceSpecification_RoleArn = this.TestSetImportResourceSpecification_RoleArn;
            context.StorageLocation_KmsKeyArn = this.StorageLocation_KmsKeyArn;
            context.StorageLocation_S3BucketName = this.StorageLocation_S3BucketName;
            context.StorageLocation_S3Path = this.StorageLocation_S3Path;
            context.TestSetImportResourceSpecification_TestSetName = this.TestSetImportResourceSpecification_TestSetName;
            if (this.TestSetImportResourceSpecification_TestSetTag != null)
            {
                context.TestSetImportResourceSpecification_TestSetTag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.TestSetImportResourceSpecification_TestSetTag.Keys)
                {
                    context.TestSetImportResourceSpecification_TestSetTag.Add((String)hashKey, (System.String)(this.TestSetImportResourceSpecification_TestSetTag[hashKey]));
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
            var request = new Amazon.LexModelsV2.Model.StartImportRequest();
            
            if (cmdletContext.FilePassword != null)
            {
                request.FilePassword = cmdletContext.FilePassword;
            }
            if (cmdletContext.ImportId != null)
            {
                request.ImportId = cmdletContext.ImportId;
            }
            if (cmdletContext.MergeStrategy != null)
            {
                request.MergeStrategy = cmdletContext.MergeStrategy;
            }
            
             // populate ResourceSpecification
            var requestResourceSpecificationIsNull = true;
            request.ResourceSpecification = new Amazon.LexModelsV2.Model.ImportResourceSpecification();
            Amazon.LexModelsV2.Model.CustomVocabularyImportSpecification requestResourceSpecification_resourceSpecification_CustomVocabularyImportSpecification = null;
            
             // populate CustomVocabularyImportSpecification
            var requestResourceSpecification_resourceSpecification_CustomVocabularyImportSpecificationIsNull = true;
            requestResourceSpecification_resourceSpecification_CustomVocabularyImportSpecification = new Amazon.LexModelsV2.Model.CustomVocabularyImportSpecification();
            System.String requestResourceSpecification_resourceSpecification_CustomVocabularyImportSpecification_customVocabularyImportSpecification_BotId = null;
            if (cmdletContext.CustomVocabularyImportSpecification_BotId != null)
            {
                requestResourceSpecification_resourceSpecification_CustomVocabularyImportSpecification_customVocabularyImportSpecification_BotId = cmdletContext.CustomVocabularyImportSpecification_BotId;
            }
            if (requestResourceSpecification_resourceSpecification_CustomVocabularyImportSpecification_customVocabularyImportSpecification_BotId != null)
            {
                requestResourceSpecification_resourceSpecification_CustomVocabularyImportSpecification.BotId = requestResourceSpecification_resourceSpecification_CustomVocabularyImportSpecification_customVocabularyImportSpecification_BotId;
                requestResourceSpecification_resourceSpecification_CustomVocabularyImportSpecificationIsNull = false;
            }
            System.String requestResourceSpecification_resourceSpecification_CustomVocabularyImportSpecification_customVocabularyImportSpecification_BotVersion = null;
            if (cmdletContext.CustomVocabularyImportSpecification_BotVersion != null)
            {
                requestResourceSpecification_resourceSpecification_CustomVocabularyImportSpecification_customVocabularyImportSpecification_BotVersion = cmdletContext.CustomVocabularyImportSpecification_BotVersion;
            }
            if (requestResourceSpecification_resourceSpecification_CustomVocabularyImportSpecification_customVocabularyImportSpecification_BotVersion != null)
            {
                requestResourceSpecification_resourceSpecification_CustomVocabularyImportSpecification.BotVersion = requestResourceSpecification_resourceSpecification_CustomVocabularyImportSpecification_customVocabularyImportSpecification_BotVersion;
                requestResourceSpecification_resourceSpecification_CustomVocabularyImportSpecificationIsNull = false;
            }
            System.String requestResourceSpecification_resourceSpecification_CustomVocabularyImportSpecification_customVocabularyImportSpecification_LocaleId = null;
            if (cmdletContext.CustomVocabularyImportSpecification_LocaleId != null)
            {
                requestResourceSpecification_resourceSpecification_CustomVocabularyImportSpecification_customVocabularyImportSpecification_LocaleId = cmdletContext.CustomVocabularyImportSpecification_LocaleId;
            }
            if (requestResourceSpecification_resourceSpecification_CustomVocabularyImportSpecification_customVocabularyImportSpecification_LocaleId != null)
            {
                requestResourceSpecification_resourceSpecification_CustomVocabularyImportSpecification.LocaleId = requestResourceSpecification_resourceSpecification_CustomVocabularyImportSpecification_customVocabularyImportSpecification_LocaleId;
                requestResourceSpecification_resourceSpecification_CustomVocabularyImportSpecificationIsNull = false;
            }
             // determine if requestResourceSpecification_resourceSpecification_CustomVocabularyImportSpecification should be set to null
            if (requestResourceSpecification_resourceSpecification_CustomVocabularyImportSpecificationIsNull)
            {
                requestResourceSpecification_resourceSpecification_CustomVocabularyImportSpecification = null;
            }
            if (requestResourceSpecification_resourceSpecification_CustomVocabularyImportSpecification != null)
            {
                request.ResourceSpecification.CustomVocabularyImportSpecification = requestResourceSpecification_resourceSpecification_CustomVocabularyImportSpecification;
                requestResourceSpecificationIsNull = false;
            }
            Amazon.LexModelsV2.Model.BotLocaleImportSpecification requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification = null;
            
             // populate BotLocaleImportSpecification
            var requestResourceSpecification_resourceSpecification_BotLocaleImportSpecificationIsNull = true;
            requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification = new Amazon.LexModelsV2.Model.BotLocaleImportSpecification();
            System.String requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification_botLocaleImportSpecification_BotId = null;
            if (cmdletContext.BotLocaleImportSpecification_BotId != null)
            {
                requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification_botLocaleImportSpecification_BotId = cmdletContext.BotLocaleImportSpecification_BotId;
            }
            if (requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification_botLocaleImportSpecification_BotId != null)
            {
                requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification.BotId = requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification_botLocaleImportSpecification_BotId;
                requestResourceSpecification_resourceSpecification_BotLocaleImportSpecificationIsNull = false;
            }
            System.String requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification_botLocaleImportSpecification_BotVersion = null;
            if (cmdletContext.BotLocaleImportSpecification_BotVersion != null)
            {
                requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification_botLocaleImportSpecification_BotVersion = cmdletContext.BotLocaleImportSpecification_BotVersion;
            }
            if (requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification_botLocaleImportSpecification_BotVersion != null)
            {
                requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification.BotVersion = requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification_botLocaleImportSpecification_BotVersion;
                requestResourceSpecification_resourceSpecification_BotLocaleImportSpecificationIsNull = false;
            }
            System.String requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification_botLocaleImportSpecification_LocaleId = null;
            if (cmdletContext.BotLocaleImportSpecification_LocaleId != null)
            {
                requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification_botLocaleImportSpecification_LocaleId = cmdletContext.BotLocaleImportSpecification_LocaleId;
            }
            if (requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification_botLocaleImportSpecification_LocaleId != null)
            {
                requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification.LocaleId = requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification_botLocaleImportSpecification_LocaleId;
                requestResourceSpecification_resourceSpecification_BotLocaleImportSpecificationIsNull = false;
            }
            System.Double? requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification_botLocaleImportSpecification_NluIntentConfidenceThreshold = null;
            if (cmdletContext.BotLocaleImportSpecification_NluIntentConfidenceThreshold != null)
            {
                requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification_botLocaleImportSpecification_NluIntentConfidenceThreshold = cmdletContext.BotLocaleImportSpecification_NluIntentConfidenceThreshold.Value;
            }
            if (requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification_botLocaleImportSpecification_NluIntentConfidenceThreshold != null)
            {
                requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification.NluIntentConfidenceThreshold = requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification_botLocaleImportSpecification_NluIntentConfidenceThreshold.Value;
                requestResourceSpecification_resourceSpecification_BotLocaleImportSpecificationIsNull = false;
            }
            Amazon.LexModelsV2.SpeechDetectionSensitivity requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification_botLocaleImportSpecification_SpeechDetectionSensitivity = null;
            if (cmdletContext.BotLocaleImportSpecification_SpeechDetectionSensitivity != null)
            {
                requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification_botLocaleImportSpecification_SpeechDetectionSensitivity = cmdletContext.BotLocaleImportSpecification_SpeechDetectionSensitivity;
            }
            if (requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification_botLocaleImportSpecification_SpeechDetectionSensitivity != null)
            {
                requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification.SpeechDetectionSensitivity = requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification_botLocaleImportSpecification_SpeechDetectionSensitivity;
                requestResourceSpecification_resourceSpecification_BotLocaleImportSpecificationIsNull = false;
            }
            Amazon.LexModelsV2.Model.VoiceSettings requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification_resourceSpecification_BotLocaleImportSpecification_VoiceSettings = null;
            
             // populate VoiceSettings
            var requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification_resourceSpecification_BotLocaleImportSpecification_VoiceSettingsIsNull = true;
            requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification_resourceSpecification_BotLocaleImportSpecification_VoiceSettings = new Amazon.LexModelsV2.Model.VoiceSettings();
            Amazon.LexModelsV2.VoiceEngine requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification_resourceSpecification_BotLocaleImportSpecification_VoiceSettings_voiceSettings_Engine = null;
            if (cmdletContext.VoiceSettings_Engine != null)
            {
                requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification_resourceSpecification_BotLocaleImportSpecification_VoiceSettings_voiceSettings_Engine = cmdletContext.VoiceSettings_Engine;
            }
            if (requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification_resourceSpecification_BotLocaleImportSpecification_VoiceSettings_voiceSettings_Engine != null)
            {
                requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification_resourceSpecification_BotLocaleImportSpecification_VoiceSettings.Engine = requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification_resourceSpecification_BotLocaleImportSpecification_VoiceSettings_voiceSettings_Engine;
                requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification_resourceSpecification_BotLocaleImportSpecification_VoiceSettingsIsNull = false;
            }
            System.String requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification_resourceSpecification_BotLocaleImportSpecification_VoiceSettings_voiceSettings_VoiceId = null;
            if (cmdletContext.VoiceSettings_VoiceId != null)
            {
                requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification_resourceSpecification_BotLocaleImportSpecification_VoiceSettings_voiceSettings_VoiceId = cmdletContext.VoiceSettings_VoiceId;
            }
            if (requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification_resourceSpecification_BotLocaleImportSpecification_VoiceSettings_voiceSettings_VoiceId != null)
            {
                requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification_resourceSpecification_BotLocaleImportSpecification_VoiceSettings.VoiceId = requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification_resourceSpecification_BotLocaleImportSpecification_VoiceSettings_voiceSettings_VoiceId;
                requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification_resourceSpecification_BotLocaleImportSpecification_VoiceSettingsIsNull = false;
            }
             // determine if requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification_resourceSpecification_BotLocaleImportSpecification_VoiceSettings should be set to null
            if (requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification_resourceSpecification_BotLocaleImportSpecification_VoiceSettingsIsNull)
            {
                requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification_resourceSpecification_BotLocaleImportSpecification_VoiceSettings = null;
            }
            if (requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification_resourceSpecification_BotLocaleImportSpecification_VoiceSettings != null)
            {
                requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification.VoiceSettings = requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification_resourceSpecification_BotLocaleImportSpecification_VoiceSettings;
                requestResourceSpecification_resourceSpecification_BotLocaleImportSpecificationIsNull = false;
            }
             // determine if requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification should be set to null
            if (requestResourceSpecification_resourceSpecification_BotLocaleImportSpecificationIsNull)
            {
                requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification = null;
            }
            if (requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification != null)
            {
                request.ResourceSpecification.BotLocaleImportSpecification = requestResourceSpecification_resourceSpecification_BotLocaleImportSpecification;
                requestResourceSpecificationIsNull = false;
            }
            Amazon.LexModelsV2.Model.BotImportSpecification requestResourceSpecification_resourceSpecification_BotImportSpecification = null;
            
             // populate BotImportSpecification
            var requestResourceSpecification_resourceSpecification_BotImportSpecificationIsNull = true;
            requestResourceSpecification_resourceSpecification_BotImportSpecification = new Amazon.LexModelsV2.Model.BotImportSpecification();
            System.String requestResourceSpecification_resourceSpecification_BotImportSpecification_botImportSpecification_BotName = null;
            if (cmdletContext.BotImportSpecification_BotName != null)
            {
                requestResourceSpecification_resourceSpecification_BotImportSpecification_botImportSpecification_BotName = cmdletContext.BotImportSpecification_BotName;
            }
            if (requestResourceSpecification_resourceSpecification_BotImportSpecification_botImportSpecification_BotName != null)
            {
                requestResourceSpecification_resourceSpecification_BotImportSpecification.BotName = requestResourceSpecification_resourceSpecification_BotImportSpecification_botImportSpecification_BotName;
                requestResourceSpecification_resourceSpecification_BotImportSpecificationIsNull = false;
            }
            Dictionary<System.String, System.String> requestResourceSpecification_resourceSpecification_BotImportSpecification_botImportSpecification_BotTag = null;
            if (cmdletContext.BotImportSpecification_BotTag != null)
            {
                requestResourceSpecification_resourceSpecification_BotImportSpecification_botImportSpecification_BotTag = cmdletContext.BotImportSpecification_BotTag;
            }
            if (requestResourceSpecification_resourceSpecification_BotImportSpecification_botImportSpecification_BotTag != null)
            {
                requestResourceSpecification_resourceSpecification_BotImportSpecification.BotTags = requestResourceSpecification_resourceSpecification_BotImportSpecification_botImportSpecification_BotTag;
                requestResourceSpecification_resourceSpecification_BotImportSpecificationIsNull = false;
            }
            System.Int32? requestResourceSpecification_resourceSpecification_BotImportSpecification_botImportSpecification_IdleSessionTTLInSecond = null;
            if (cmdletContext.BotImportSpecification_IdleSessionTTLInSecond != null)
            {
                requestResourceSpecification_resourceSpecification_BotImportSpecification_botImportSpecification_IdleSessionTTLInSecond = cmdletContext.BotImportSpecification_IdleSessionTTLInSecond.Value;
            }
            if (requestResourceSpecification_resourceSpecification_BotImportSpecification_botImportSpecification_IdleSessionTTLInSecond != null)
            {
                requestResourceSpecification_resourceSpecification_BotImportSpecification.IdleSessionTTLInSeconds = requestResourceSpecification_resourceSpecification_BotImportSpecification_botImportSpecification_IdleSessionTTLInSecond.Value;
                requestResourceSpecification_resourceSpecification_BotImportSpecificationIsNull = false;
            }
            System.String requestResourceSpecification_resourceSpecification_BotImportSpecification_botImportSpecification_RoleArn = null;
            if (cmdletContext.BotImportSpecification_RoleArn != null)
            {
                requestResourceSpecification_resourceSpecification_BotImportSpecification_botImportSpecification_RoleArn = cmdletContext.BotImportSpecification_RoleArn;
            }
            if (requestResourceSpecification_resourceSpecification_BotImportSpecification_botImportSpecification_RoleArn != null)
            {
                requestResourceSpecification_resourceSpecification_BotImportSpecification.RoleArn = requestResourceSpecification_resourceSpecification_BotImportSpecification_botImportSpecification_RoleArn;
                requestResourceSpecification_resourceSpecification_BotImportSpecificationIsNull = false;
            }
            Dictionary<System.String, System.String> requestResourceSpecification_resourceSpecification_BotImportSpecification_botImportSpecification_TestBotAliasTag = null;
            if (cmdletContext.BotImportSpecification_TestBotAliasTag != null)
            {
                requestResourceSpecification_resourceSpecification_BotImportSpecification_botImportSpecification_TestBotAliasTag = cmdletContext.BotImportSpecification_TestBotAliasTag;
            }
            if (requestResourceSpecification_resourceSpecification_BotImportSpecification_botImportSpecification_TestBotAliasTag != null)
            {
                requestResourceSpecification_resourceSpecification_BotImportSpecification.TestBotAliasTags = requestResourceSpecification_resourceSpecification_BotImportSpecification_botImportSpecification_TestBotAliasTag;
                requestResourceSpecification_resourceSpecification_BotImportSpecificationIsNull = false;
            }
            Amazon.LexModelsV2.Model.DataPrivacy requestResourceSpecification_resourceSpecification_BotImportSpecification_resourceSpecification_BotImportSpecification_DataPrivacy = null;
            
             // populate DataPrivacy
            var requestResourceSpecification_resourceSpecification_BotImportSpecification_resourceSpecification_BotImportSpecification_DataPrivacyIsNull = true;
            requestResourceSpecification_resourceSpecification_BotImportSpecification_resourceSpecification_BotImportSpecification_DataPrivacy = new Amazon.LexModelsV2.Model.DataPrivacy();
            System.Boolean? requestResourceSpecification_resourceSpecification_BotImportSpecification_resourceSpecification_BotImportSpecification_DataPrivacy_dataPrivacy_ChildDirected = null;
            if (cmdletContext.DataPrivacy_ChildDirected != null)
            {
                requestResourceSpecification_resourceSpecification_BotImportSpecification_resourceSpecification_BotImportSpecification_DataPrivacy_dataPrivacy_ChildDirected = cmdletContext.DataPrivacy_ChildDirected.Value;
            }
            if (requestResourceSpecification_resourceSpecification_BotImportSpecification_resourceSpecification_BotImportSpecification_DataPrivacy_dataPrivacy_ChildDirected != null)
            {
                requestResourceSpecification_resourceSpecification_BotImportSpecification_resourceSpecification_BotImportSpecification_DataPrivacy.ChildDirected = requestResourceSpecification_resourceSpecification_BotImportSpecification_resourceSpecification_BotImportSpecification_DataPrivacy_dataPrivacy_ChildDirected.Value;
                requestResourceSpecification_resourceSpecification_BotImportSpecification_resourceSpecification_BotImportSpecification_DataPrivacyIsNull = false;
            }
             // determine if requestResourceSpecification_resourceSpecification_BotImportSpecification_resourceSpecification_BotImportSpecification_DataPrivacy should be set to null
            if (requestResourceSpecification_resourceSpecification_BotImportSpecification_resourceSpecification_BotImportSpecification_DataPrivacyIsNull)
            {
                requestResourceSpecification_resourceSpecification_BotImportSpecification_resourceSpecification_BotImportSpecification_DataPrivacy = null;
            }
            if (requestResourceSpecification_resourceSpecification_BotImportSpecification_resourceSpecification_BotImportSpecification_DataPrivacy != null)
            {
                requestResourceSpecification_resourceSpecification_BotImportSpecification.DataPrivacy = requestResourceSpecification_resourceSpecification_BotImportSpecification_resourceSpecification_BotImportSpecification_DataPrivacy;
                requestResourceSpecification_resourceSpecification_BotImportSpecificationIsNull = false;
            }
            Amazon.LexModelsV2.Model.ErrorLogSettings requestResourceSpecification_resourceSpecification_BotImportSpecification_resourceSpecification_BotImportSpecification_ErrorLogSettings = null;
            
             // populate ErrorLogSettings
            var requestResourceSpecification_resourceSpecification_BotImportSpecification_resourceSpecification_BotImportSpecification_ErrorLogSettingsIsNull = true;
            requestResourceSpecification_resourceSpecification_BotImportSpecification_resourceSpecification_BotImportSpecification_ErrorLogSettings = new Amazon.LexModelsV2.Model.ErrorLogSettings();
            System.Boolean? requestResourceSpecification_resourceSpecification_BotImportSpecification_resourceSpecification_BotImportSpecification_ErrorLogSettings_errorLogSettings_Enabled = null;
            if (cmdletContext.ErrorLogSettings_Enabled != null)
            {
                requestResourceSpecification_resourceSpecification_BotImportSpecification_resourceSpecification_BotImportSpecification_ErrorLogSettings_errorLogSettings_Enabled = cmdletContext.ErrorLogSettings_Enabled.Value;
            }
            if (requestResourceSpecification_resourceSpecification_BotImportSpecification_resourceSpecification_BotImportSpecification_ErrorLogSettings_errorLogSettings_Enabled != null)
            {
                requestResourceSpecification_resourceSpecification_BotImportSpecification_resourceSpecification_BotImportSpecification_ErrorLogSettings.Enabled = requestResourceSpecification_resourceSpecification_BotImportSpecification_resourceSpecification_BotImportSpecification_ErrorLogSettings_errorLogSettings_Enabled.Value;
                requestResourceSpecification_resourceSpecification_BotImportSpecification_resourceSpecification_BotImportSpecification_ErrorLogSettingsIsNull = false;
            }
             // determine if requestResourceSpecification_resourceSpecification_BotImportSpecification_resourceSpecification_BotImportSpecification_ErrorLogSettings should be set to null
            if (requestResourceSpecification_resourceSpecification_BotImportSpecification_resourceSpecification_BotImportSpecification_ErrorLogSettingsIsNull)
            {
                requestResourceSpecification_resourceSpecification_BotImportSpecification_resourceSpecification_BotImportSpecification_ErrorLogSettings = null;
            }
            if (requestResourceSpecification_resourceSpecification_BotImportSpecification_resourceSpecification_BotImportSpecification_ErrorLogSettings != null)
            {
                requestResourceSpecification_resourceSpecification_BotImportSpecification.ErrorLogSettings = requestResourceSpecification_resourceSpecification_BotImportSpecification_resourceSpecification_BotImportSpecification_ErrorLogSettings;
                requestResourceSpecification_resourceSpecification_BotImportSpecificationIsNull = false;
            }
             // determine if requestResourceSpecification_resourceSpecification_BotImportSpecification should be set to null
            if (requestResourceSpecification_resourceSpecification_BotImportSpecificationIsNull)
            {
                requestResourceSpecification_resourceSpecification_BotImportSpecification = null;
            }
            if (requestResourceSpecification_resourceSpecification_BotImportSpecification != null)
            {
                request.ResourceSpecification.BotImportSpecification = requestResourceSpecification_resourceSpecification_BotImportSpecification;
                requestResourceSpecificationIsNull = false;
            }
            Amazon.LexModelsV2.Model.TestSetImportResourceSpecification requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification = null;
            
             // populate TestSetImportResourceSpecification
            var requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecificationIsNull = true;
            requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification = new Amazon.LexModelsV2.Model.TestSetImportResourceSpecification();
            System.String requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_testSetImportResourceSpecification_Description = null;
            if (cmdletContext.TestSetImportResourceSpecification_Description != null)
            {
                requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_testSetImportResourceSpecification_Description = cmdletContext.TestSetImportResourceSpecification_Description;
            }
            if (requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_testSetImportResourceSpecification_Description != null)
            {
                requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification.Description = requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_testSetImportResourceSpecification_Description;
                requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecificationIsNull = false;
            }
            Amazon.LexModelsV2.TestSetModality requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_testSetImportResourceSpecification_Modality = null;
            if (cmdletContext.TestSetImportResourceSpecification_Modality != null)
            {
                requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_testSetImportResourceSpecification_Modality = cmdletContext.TestSetImportResourceSpecification_Modality;
            }
            if (requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_testSetImportResourceSpecification_Modality != null)
            {
                requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification.Modality = requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_testSetImportResourceSpecification_Modality;
                requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecificationIsNull = false;
            }
            System.String requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_testSetImportResourceSpecification_RoleArn = null;
            if (cmdletContext.TestSetImportResourceSpecification_RoleArn != null)
            {
                requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_testSetImportResourceSpecification_RoleArn = cmdletContext.TestSetImportResourceSpecification_RoleArn;
            }
            if (requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_testSetImportResourceSpecification_RoleArn != null)
            {
                requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification.RoleArn = requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_testSetImportResourceSpecification_RoleArn;
                requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecificationIsNull = false;
            }
            System.String requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_testSetImportResourceSpecification_TestSetName = null;
            if (cmdletContext.TestSetImportResourceSpecification_TestSetName != null)
            {
                requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_testSetImportResourceSpecification_TestSetName = cmdletContext.TestSetImportResourceSpecification_TestSetName;
            }
            if (requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_testSetImportResourceSpecification_TestSetName != null)
            {
                requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification.TestSetName = requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_testSetImportResourceSpecification_TestSetName;
                requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecificationIsNull = false;
            }
            Dictionary<System.String, System.String> requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_testSetImportResourceSpecification_TestSetTag = null;
            if (cmdletContext.TestSetImportResourceSpecification_TestSetTag != null)
            {
                requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_testSetImportResourceSpecification_TestSetTag = cmdletContext.TestSetImportResourceSpecification_TestSetTag;
            }
            if (requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_testSetImportResourceSpecification_TestSetTag != null)
            {
                requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification.TestSetTags = requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_testSetImportResourceSpecification_TestSetTag;
                requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecificationIsNull = false;
            }
            Amazon.LexModelsV2.Model.TestSetImportInputLocation requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_ImportInputLocation = null;
            
             // populate ImportInputLocation
            var requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_ImportInputLocationIsNull = true;
            requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_ImportInputLocation = new Amazon.LexModelsV2.Model.TestSetImportInputLocation();
            System.String requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_ImportInputLocation_importInputLocation_S3BucketName = null;
            if (cmdletContext.ImportInputLocation_S3BucketName != null)
            {
                requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_ImportInputLocation_importInputLocation_S3BucketName = cmdletContext.ImportInputLocation_S3BucketName;
            }
            if (requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_ImportInputLocation_importInputLocation_S3BucketName != null)
            {
                requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_ImportInputLocation.S3BucketName = requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_ImportInputLocation_importInputLocation_S3BucketName;
                requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_ImportInputLocationIsNull = false;
            }
            System.String requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_ImportInputLocation_importInputLocation_S3Path = null;
            if (cmdletContext.ImportInputLocation_S3Path != null)
            {
                requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_ImportInputLocation_importInputLocation_S3Path = cmdletContext.ImportInputLocation_S3Path;
            }
            if (requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_ImportInputLocation_importInputLocation_S3Path != null)
            {
                requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_ImportInputLocation.S3Path = requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_ImportInputLocation_importInputLocation_S3Path;
                requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_ImportInputLocationIsNull = false;
            }
             // determine if requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_ImportInputLocation should be set to null
            if (requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_ImportInputLocationIsNull)
            {
                requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_ImportInputLocation = null;
            }
            if (requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_ImportInputLocation != null)
            {
                requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification.ImportInputLocation = requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_ImportInputLocation;
                requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecificationIsNull = false;
            }
            Amazon.LexModelsV2.Model.TestSetStorageLocation requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_StorageLocation = null;
            
             // populate StorageLocation
            var requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_StorageLocationIsNull = true;
            requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_StorageLocation = new Amazon.LexModelsV2.Model.TestSetStorageLocation();
            System.String requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_StorageLocation_storageLocation_KmsKeyArn = null;
            if (cmdletContext.StorageLocation_KmsKeyArn != null)
            {
                requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_StorageLocation_storageLocation_KmsKeyArn = cmdletContext.StorageLocation_KmsKeyArn;
            }
            if (requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_StorageLocation_storageLocation_KmsKeyArn != null)
            {
                requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_StorageLocation.KmsKeyArn = requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_StorageLocation_storageLocation_KmsKeyArn;
                requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_StorageLocationIsNull = false;
            }
            System.String requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_StorageLocation_storageLocation_S3BucketName = null;
            if (cmdletContext.StorageLocation_S3BucketName != null)
            {
                requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_StorageLocation_storageLocation_S3BucketName = cmdletContext.StorageLocation_S3BucketName;
            }
            if (requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_StorageLocation_storageLocation_S3BucketName != null)
            {
                requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_StorageLocation.S3BucketName = requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_StorageLocation_storageLocation_S3BucketName;
                requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_StorageLocationIsNull = false;
            }
            System.String requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_StorageLocation_storageLocation_S3Path = null;
            if (cmdletContext.StorageLocation_S3Path != null)
            {
                requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_StorageLocation_storageLocation_S3Path = cmdletContext.StorageLocation_S3Path;
            }
            if (requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_StorageLocation_storageLocation_S3Path != null)
            {
                requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_StorageLocation.S3Path = requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_StorageLocation_storageLocation_S3Path;
                requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_StorageLocationIsNull = false;
            }
             // determine if requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_StorageLocation should be set to null
            if (requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_StorageLocationIsNull)
            {
                requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_StorageLocation = null;
            }
            if (requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_StorageLocation != null)
            {
                requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification.StorageLocation = requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_resourceSpecification_TestSetImportResourceSpecification_StorageLocation;
                requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecificationIsNull = false;
            }
             // determine if requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification should be set to null
            if (requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecificationIsNull)
            {
                requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification = null;
            }
            if (requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification != null)
            {
                request.ResourceSpecification.TestSetImportResourceSpecification = requestResourceSpecification_resourceSpecification_TestSetImportResourceSpecification;
                requestResourceSpecificationIsNull = false;
            }
             // determine if request.ResourceSpecification should be set to null
            if (requestResourceSpecificationIsNull)
            {
                request.ResourceSpecification = null;
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
        
        private Amazon.LexModelsV2.Model.StartImportResponse CallAWSServiceOperation(IAmazonLexModelsV2 client, Amazon.LexModelsV2.Model.StartImportRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lex Model Building V2", "StartImport");
            try
            {
                #if DESKTOP
                return client.StartImport(request);
                #elif CORECLR
                return client.StartImportAsync(request).GetAwaiter().GetResult();
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
            public System.String FilePassword { get; set; }
            public System.String ImportId { get; set; }
            public Amazon.LexModelsV2.MergeStrategy MergeStrategy { get; set; }
            public System.String BotImportSpecification_BotName { get; set; }
            public Dictionary<System.String, System.String> BotImportSpecification_BotTag { get; set; }
            public System.Boolean? DataPrivacy_ChildDirected { get; set; }
            public System.Boolean? ErrorLogSettings_Enabled { get; set; }
            public System.Int32? BotImportSpecification_IdleSessionTTLInSecond { get; set; }
            public System.String BotImportSpecification_RoleArn { get; set; }
            public Dictionary<System.String, System.String> BotImportSpecification_TestBotAliasTag { get; set; }
            public System.String BotLocaleImportSpecification_BotId { get; set; }
            public System.String BotLocaleImportSpecification_BotVersion { get; set; }
            public System.String BotLocaleImportSpecification_LocaleId { get; set; }
            public System.Double? BotLocaleImportSpecification_NluIntentConfidenceThreshold { get; set; }
            public Amazon.LexModelsV2.SpeechDetectionSensitivity BotLocaleImportSpecification_SpeechDetectionSensitivity { get; set; }
            public Amazon.LexModelsV2.VoiceEngine VoiceSettings_Engine { get; set; }
            public System.String VoiceSettings_VoiceId { get; set; }
            public System.String CustomVocabularyImportSpecification_BotId { get; set; }
            public System.String CustomVocabularyImportSpecification_BotVersion { get; set; }
            public System.String CustomVocabularyImportSpecification_LocaleId { get; set; }
            public System.String TestSetImportResourceSpecification_Description { get; set; }
            public System.String ImportInputLocation_S3BucketName { get; set; }
            public System.String ImportInputLocation_S3Path { get; set; }
            public Amazon.LexModelsV2.TestSetModality TestSetImportResourceSpecification_Modality { get; set; }
            public System.String TestSetImportResourceSpecification_RoleArn { get; set; }
            public System.String StorageLocation_KmsKeyArn { get; set; }
            public System.String StorageLocation_S3BucketName { get; set; }
            public System.String StorageLocation_S3Path { get; set; }
            public System.String TestSetImportResourceSpecification_TestSetName { get; set; }
            public Dictionary<System.String, System.String> TestSetImportResourceSpecification_TestSetTag { get; set; }
            public System.Func<Amazon.LexModelsV2.Model.StartImportResponse, StartLMBV2ImportCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
