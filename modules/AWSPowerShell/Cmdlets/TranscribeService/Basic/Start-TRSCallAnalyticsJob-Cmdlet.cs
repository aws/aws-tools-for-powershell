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
using Amazon.TranscribeService;
using Amazon.TranscribeService.Model;

namespace Amazon.PowerShell.Cmdlets.TRS
{
    /// <summary>
    /// Transcribes the audio from a customer service call and applies any additional Request
    /// Parameters you choose to include in your request.
    /// 
    ///  
    /// <para>
    /// In addition to many standard transcription features, Call Analytics provides you with
    /// call characteristics, call summarization, speaker sentiment, and optional redaction
    /// of your text transcript and your audio file. You can also apply custom categories
    /// to flag specified conditions. To learn more about these features and insights, refer
    /// to <a href="https://docs.aws.amazon.com/transcribe/latest/dg/call-analytics.html">Analyzing
    /// call center audio with Call Analytics</a>.
    /// </para><para>
    /// If you want to apply categories to your Call Analytics job, you must create them before
    /// submitting your job request. Categories cannot be retroactively applied to a job.
    /// To create a new category, use the operation. To learn more about Call Analytics categories,
    /// see <a href="https://docs.aws.amazon.com/transcribe/latest/dg/tca-categories-batch.html">Creating
    /// categories for post-call transcriptions</a> and <a href="https://docs.aws.amazon.com/transcribe/latest/dg/tca-categories-stream.html">Creating
    /// categories for real-time transcriptions</a>.
    /// </para><para>
    /// To make a <c>StartCallAnalyticsJob</c> request, you must first upload your media file
    /// into an Amazon S3 bucket; you can then specify the Amazon S3 location of the file
    /// using the <c>Media</c> parameter.
    /// </para><para>
    /// Job queuing is available for Call Analytics jobs. If you pass a <c>DataAccessRoleArn</c>
    /// in your request and you exceed your Concurrent Job Limit, your job will automatically
    /// be added to a queue to be processed once your concurrent job count is below the limit.
    /// </para><para>
    /// You must include the following parameters in your <c>StartCallAnalyticsJob</c> request:
    /// </para><ul><li><para><c>region</c>: The Amazon Web Services Region where you are making your request.
    /// For a list of Amazon Web Services Regions supported with Amazon Transcribe, refer
    /// to <a href="https://docs.aws.amazon.com/general/latest/gr/transcribe.html">Amazon
    /// Transcribe endpoints and quotas</a>.
    /// </para></li><li><para><c>CallAnalyticsJobName</c>: A custom name that you create for your transcription
    /// job that's unique within your Amazon Web Services account.
    /// </para></li><li><para><c>Media</c> (<c>MediaFileUri</c> or <c>RedactedMediaFileUri</c>): The Amazon S3
    /// location of your media file.
    /// </para></li></ul><note><para>
    /// With Call Analytics, you can redact the audio contained in your media file by including
    /// <c>RedactedMediaFileUri</c>, instead of <c>MediaFileUri</c>, to specify the location
    /// of your input audio. If you choose to redact your audio, you can find your redacted
    /// media at the location specified in the <c>RedactedMediaFileUri</c> field of your response.
    /// </para></note>
    /// </summary>
    [Cmdlet("Start", "TRSCallAnalyticsJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.TranscribeService.Model.CallAnalyticsJob")]
    [AWSCmdlet("Calls the Amazon Transcribe Service StartCallAnalyticsJob API operation.", Operation = new[] {"StartCallAnalyticsJob"}, SelectReturnType = typeof(Amazon.TranscribeService.Model.StartCallAnalyticsJobResponse))]
    [AWSCmdletOutput("Amazon.TranscribeService.Model.CallAnalyticsJob or Amazon.TranscribeService.Model.StartCallAnalyticsJobResponse",
        "This cmdlet returns an Amazon.TranscribeService.Model.CallAnalyticsJob object.",
        "The service call response (type Amazon.TranscribeService.Model.StartCallAnalyticsJobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartTRSCallAnalyticsJobCmdlet : AmazonTranscribeServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CallAnalyticsJobName
        /// <summary>
        /// <para>
        /// <para>A unique name, chosen by you, for your Call Analytics job.</para><para>This name is case sensitive, cannot contain spaces, and must be unique within an Amazon
        /// Web Services account. If you try to create a new job with the same name as an existing
        /// job, you get a <c>ConflictException</c> error.</para>
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
        public System.String CallAnalyticsJobName { get; set; }
        #endregion
        
        #region Parameter ChannelDefinition
        /// <summary>
        /// <para>
        /// <para>Makes it possible to specify which speaker is on which channel. For example, if your
        /// agent is the first participant to speak, you would set <c>ChannelId</c> to <c>0</c>
        /// (to indicate the first channel) and <c>ParticipantRole</c> to <c>AGENT</c> (to indicate
        /// that it's the agent speaking).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChannelDefinitions")]
        public Amazon.TranscribeService.Model.ChannelDefinition[] ChannelDefinition { get; set; }
        #endregion
        
        #region Parameter DataAccessRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an IAM role that has permissions to access the Amazon
        /// S3 bucket that contains your input files. If the role that you specify doesn’t have
        /// the appropriate permissions to access the specified Amazon S3 location, your request
        /// fails.</para><para>IAM role ARNs have the format <c>arn:partition:iam::account:role/role-name-with-path</c>.
        /// For example: <c>arn:aws:iam::111122223333:role/Admin</c>.</para><para>For more information, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_identifiers.html#identifiers-arns">IAM
        /// ARNs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter Summarization_GenerateAbstractiveSummary
        /// <summary>
        /// <para>
        /// <para>Enables Generative call summarization in your Call Analytics request</para><para>Generative call summarization provides a summary of the transcript including important
        /// components discussed in the conversation.</para><para>For more information, see <a href="https://docs.aws.amazon.com/transcribe/latest/dg/tca-enable-summarization.html">Enabling
        /// generative call summarization</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_Summarization_GenerateAbstractiveSummary")]
        public System.Boolean? Summarization_GenerateAbstractiveSummary { get; set; }
        #endregion
        
        #region Parameter Settings_LanguageIdSetting
        /// <summary>
        /// <para>
        /// <para>If using automatic language identification in your request and you want to apply a
        /// custom language model, a custom vocabulary, or a custom vocabulary filter, include
        /// <c>LanguageIdSettings</c> with the relevant sub-parameters (<c>VocabularyName</c>,
        /// <c>LanguageModelName</c>, and <c>VocabularyFilterName</c>).</para><para><c>LanguageIdSettings</c> supports two to five language codes. Each language code
        /// you include can have an associated custom language model, custom vocabulary, and custom
        /// vocabulary filter. The language codes that you specify must match the languages of
        /// the associated custom language models, custom vocabularies, and custom vocabulary
        /// filters.</para><para>It's recommended that you include <c>LanguageOptions</c> when using <c>LanguageIdSettings</c>
        /// to ensure that the correct language dialect is identified. For example, if you specify
        /// a custom vocabulary that is in <c>en-US</c> but Amazon Transcribe determines that
        /// the language spoken in your media is <c>en-AU</c>, your custom vocabulary <i>is not</i>
        /// applied to your transcription. If you include <c>LanguageOptions</c> and include <c>en-US</c>
        /// as the only English language dialect, your custom vocabulary <i>is</i> applied to
        /// your transcription.</para><para>If you want to include a custom language model, custom vocabulary, or custom vocabulary
        /// filter with your request but <b>do not</b> want to use automatic language identification,
        /// use instead the <code /> parameter with the <c>LanguageModelName</c>, <c>VocabularyName</c>,
        /// or <c>VocabularyFilterName</c> sub-parameters.</para><para>For a list of languages supported with Call Analytics, refer to <a href="https://docs.aws.amazon.com/transcribe/latest/dg/supported-languages.html">Supported
        /// languages and language-specific features</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_LanguageIdSettings")]
        public System.Collections.Hashtable Settings_LanguageIdSetting { get; set; }
        #endregion
        
        #region Parameter Settings_LanguageModelName
        /// <summary>
        /// <para>
        /// <para>The name of the custom language model you want to use when processing your Call Analytics
        /// job. Note that custom language model names are case sensitive.</para><para>The language of the specified custom language model must match the language code that
        /// you specify in your transcription request. If the languages do not match, the custom
        /// language model isn't applied. There are no errors or warnings associated with a language
        /// mismatch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Settings_LanguageModelName { get; set; }
        #endregion
        
        #region Parameter Settings_LanguageOption
        /// <summary>
        /// <para>
        /// <para>You can specify two or more language codes that represent the languages you think
        /// may be present in your media. Including more than five is not recommended. If you're
        /// unsure what languages are present, do not include this parameter.</para><para>Including language options can improve the accuracy of language identification.</para><para>For a list of languages supported with Call Analytics, refer to the <a href="https://docs.aws.amazon.com/transcribe/latest/dg/supported-languages.html">Supported
        /// languages</a> table.</para><para>To transcribe speech in Modern Standard Arabic (<c>ar-SA</c>) in Amazon Web Services
        /// GovCloud (US) (US-West, us-gov-west-1), Amazon Web Services GovCloud (US) (US-East,
        /// us-gov-east-1), Canada (Calgary) ca-west-1 and Africa (Cape Town) af-south-1, your
        /// media file must be encoded at a sample rate of 16,000 Hz or higher.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_LanguageOptions")]
        public System.String[] Settings_LanguageOption { get; set; }
        #endregion
        
        #region Parameter Media_MediaFileUri
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 location of the media file you want to transcribe. For example:</para><ul><li><para><c>s3://DOC-EXAMPLE-BUCKET/my-media-file.flac</c></para></li><li><para><c>s3://DOC-EXAMPLE-BUCKET/media-files/my-media-file.flac</c></para></li></ul><para>Note that the Amazon S3 bucket that contains your input media must be located in the
        /// same Amazon Web Services Region where you're making your transcription request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Media_MediaFileUri { get; set; }
        #endregion
        
        #region Parameter OutputEncryptionKMSKeyId
        /// <summary>
        /// <para>
        /// <para>The KMS key you want to use to encrypt your Call Analytics output.</para><para>If using a key located in the <b>current</b> Amazon Web Services account, you can
        /// specify your KMS key in one of four ways:</para><ol><li><para>Use the KMS key ID itself. For example, <c>1234abcd-12ab-34cd-56ef-1234567890ab</c>.</para></li><li><para>Use an alias for the KMS key ID. For example, <c>alias/ExampleAlias</c>.</para></li><li><para>Use the Amazon Resource Name (ARN) for the KMS key ID. For example, <c>arn:aws:kms:region:account-ID:key/1234abcd-12ab-34cd-56ef-1234567890ab</c>.</para></li><li><para>Use the ARN for the KMS key alias. For example, <c>arn:aws:kms:region:account-ID:alias/ExampleAlias</c>.</para></li></ol><para>If using a key located in a <b>different</b> Amazon Web Services account than the
        /// current Amazon Web Services account, you can specify your KMS key in one of two ways:</para><ol><li><para>Use the ARN for the KMS key ID. For example, <c>arn:aws:kms:region:account-ID:key/1234abcd-12ab-34cd-56ef-1234567890ab</c>.</para></li><li><para>Use the ARN for the KMS key alias. For example, <c>arn:aws:kms:region:account-ID:alias/ExampleAlias</c>.</para></li></ol><para>If you do not specify an encryption key, your output is encrypted with the default
        /// Amazon S3 key (SSE-S3).</para><para>If you specify a KMS key to encrypt your output, you must also specify an output location
        /// using the <c>OutputLocation</c> parameter.</para><para>Note that the role making the request must have permission to use the specified KMS
        /// key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputEncryptionKMSKeyId { get; set; }
        #endregion
        
        #region Parameter OutputLocation
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 location where you want your Call Analytics transcription output stored.
        /// You can use any of the following formats to specify the output location:</para><ol><li><para>s3://DOC-EXAMPLE-BUCKET</para></li><li><para>s3://DOC-EXAMPLE-BUCKET/my-output-folder/</para></li><li><para>s3://DOC-EXAMPLE-BUCKET/my-output-folder/my-call-analytics-job.json</para></li></ol><para>Unless you specify a file name (option 3), the name of your output file has a default
        /// value that matches the name you specified for your transcription job using the <c>CallAnalyticsJobName</c>
        /// parameter.</para><para>You can specify a KMS key to encrypt your output using the <c>OutputEncryptionKMSKeyId</c>
        /// parameter. If you do not specify a KMS key, Amazon Transcribe uses the default Amazon
        /// S3 key for server-side encryption.</para><para>If you do not specify <c>OutputLocation</c>, your transcript is placed in a service-managed
        /// Amazon S3 bucket and you are provided with a URI to access your transcript.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputLocation { get; set; }
        #endregion
        
        #region Parameter ContentRedaction_PiiEntityType
        /// <summary>
        /// <para>
        /// <para>Specify which types of personally identifiable information (PII) you want to redact
        /// in your transcript. You can include as many types as you'd like, or you can select
        /// <c>ALL</c>. If you do not include <c>PiiEntityTypes</c> in your request, all PII is
        /// redacted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_ContentRedaction_PiiEntityTypes")]
        public System.String[] ContentRedaction_PiiEntityType { get; set; }
        #endregion
        
        #region Parameter Media_RedactedMediaFileUri
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 location of the media file you want to redact. For example:</para><ul><li><para><c>s3://DOC-EXAMPLE-BUCKET/my-media-file.flac</c></para></li><li><para><c>s3://DOC-EXAMPLE-BUCKET/media-files/my-media-file.flac</c></para></li></ul><para>Note that the Amazon S3 bucket that contains your input media must be located in the
        /// same Amazon Web Services Region where you're making your transcription request.</para><important><para><c>RedactedMediaFileUri</c> produces a redacted audio file in addition to a redacted
        /// transcript. It is only supported for Call Analytics (<c>StartCallAnalyticsJob</c>)
        /// transcription requests.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Media_RedactedMediaFileUri { get; set; }
        #endregion
        
        #region Parameter ContentRedaction_RedactionOutput
        /// <summary>
        /// <para>
        /// <para>Specify if you want only a redacted transcript, or if you want a redacted and an unredacted
        /// transcript.</para><para>When you choose <c>redacted</c> Amazon Transcribe creates only a redacted transcript.</para><para>When you choose <c>redacted_and_unredacted</c> Amazon Transcribe creates a redacted
        /// and an unredacted transcript (as two separate files).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_ContentRedaction_RedactionOutput")]
        [AWSConstantClassSource("Amazon.TranscribeService.RedactionOutput")]
        public Amazon.TranscribeService.RedactionOutput ContentRedaction_RedactionOutput { get; set; }
        #endregion
        
        #region Parameter ContentRedaction_RedactionType
        /// <summary>
        /// <para>
        /// <para>Specify the category of information you want to redact; <c>PII</c> (personally identifiable
        /// information) is the only valid value. You can use <c>PiiEntityTypes</c> to choose
        /// which types of PII you want to redact. If you do not include <c>PiiEntityTypes</c>
        /// in your request, all PII is redacted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_ContentRedaction_RedactionType")]
        [AWSConstantClassSource("Amazon.TranscribeService.RedactionType")]
        public Amazon.TranscribeService.RedactionType ContentRedaction_RedactionType { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Adds one or more custom tags, each in the form of a key:value pair, to a new call
        /// analytics job at the time you start this new job.</para><para>To learn more about using tags with Amazon Transcribe, refer to <a href="https://docs.aws.amazon.com/transcribe/latest/dg/tagging.html">Tagging
        /// resources</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.TranscribeService.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Settings_VocabularyFilterMethod
        /// <summary>
        /// <para>
        /// <para>Specify how you want your custom vocabulary filter applied to your transcript.</para><para>To replace words with <c>***</c>, choose <c>mask</c>.</para><para>To delete words, choose <c>remove</c>.</para><para>To flag words without changing them, choose <c>tag</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.TranscribeService.VocabularyFilterMethod")]
        public Amazon.TranscribeService.VocabularyFilterMethod Settings_VocabularyFilterMethod { get; set; }
        #endregion
        
        #region Parameter Settings_VocabularyFilterName
        /// <summary>
        /// <para>
        /// <para>The name of the custom vocabulary filter you want to include in your Call Analytics
        /// transcription request. Custom vocabulary filter names are case sensitive.</para><para>Note that if you include <c>VocabularyFilterName</c> in your request, you must also
        /// include <c>VocabularyFilterMethod</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Settings_VocabularyFilterName { get; set; }
        #endregion
        
        #region Parameter Settings_VocabularyName
        /// <summary>
        /// <para>
        /// <para>The name of the custom vocabulary you want to include in your Call Analytics transcription
        /// request. Custom vocabulary names are case sensitive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Settings_VocabularyName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CallAnalyticsJob'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TranscribeService.Model.StartCallAnalyticsJobResponse).
        /// Specifying the name of a property of type Amazon.TranscribeService.Model.StartCallAnalyticsJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CallAnalyticsJob";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CallAnalyticsJobName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CallAnalyticsJobName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CallAnalyticsJobName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CallAnalyticsJobName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-TRSCallAnalyticsJob (StartCallAnalyticsJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.TranscribeService.Model.StartCallAnalyticsJobResponse, StartTRSCallAnalyticsJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CallAnalyticsJobName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CallAnalyticsJobName = this.CallAnalyticsJobName;
            #if MODULAR
            if (this.CallAnalyticsJobName == null && ParameterWasBound(nameof(this.CallAnalyticsJobName)))
            {
                WriteWarning("You are passing $null as a value for parameter CallAnalyticsJobName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ChannelDefinition != null)
            {
                context.ChannelDefinition = new List<Amazon.TranscribeService.Model.ChannelDefinition>(this.ChannelDefinition);
            }
            context.DataAccessRoleArn = this.DataAccessRoleArn;
            context.Media_MediaFileUri = this.Media_MediaFileUri;
            context.Media_RedactedMediaFileUri = this.Media_RedactedMediaFileUri;
            context.OutputEncryptionKMSKeyId = this.OutputEncryptionKMSKeyId;
            context.OutputLocation = this.OutputLocation;
            if (this.ContentRedaction_PiiEntityType != null)
            {
                context.ContentRedaction_PiiEntityType = new List<System.String>(this.ContentRedaction_PiiEntityType);
            }
            context.ContentRedaction_RedactionOutput = this.ContentRedaction_RedactionOutput;
            context.ContentRedaction_RedactionType = this.ContentRedaction_RedactionType;
            if (this.Settings_LanguageIdSetting != null)
            {
                context.Settings_LanguageIdSetting = new Dictionary<System.String, Amazon.TranscribeService.Model.LanguageIdSettings>(StringComparer.Ordinal);
                foreach (var hashKey in this.Settings_LanguageIdSetting.Keys)
                {
                    context.Settings_LanguageIdSetting.Add((String)hashKey, (Amazon.TranscribeService.Model.LanguageIdSettings)(this.Settings_LanguageIdSetting[hashKey]));
                }
            }
            context.Settings_LanguageModelName = this.Settings_LanguageModelName;
            if (this.Settings_LanguageOption != null)
            {
                context.Settings_LanguageOption = new List<System.String>(this.Settings_LanguageOption);
            }
            context.Summarization_GenerateAbstractiveSummary = this.Summarization_GenerateAbstractiveSummary;
            context.Settings_VocabularyFilterMethod = this.Settings_VocabularyFilterMethod;
            context.Settings_VocabularyFilterName = this.Settings_VocabularyFilterName;
            context.Settings_VocabularyName = this.Settings_VocabularyName;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.TranscribeService.Model.Tag>(this.Tag);
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
            var request = new Amazon.TranscribeService.Model.StartCallAnalyticsJobRequest();
            
            if (cmdletContext.CallAnalyticsJobName != null)
            {
                request.CallAnalyticsJobName = cmdletContext.CallAnalyticsJobName;
            }
            if (cmdletContext.ChannelDefinition != null)
            {
                request.ChannelDefinitions = cmdletContext.ChannelDefinition;
            }
            if (cmdletContext.DataAccessRoleArn != null)
            {
                request.DataAccessRoleArn = cmdletContext.DataAccessRoleArn;
            }
            
             // populate Media
            var requestMediaIsNull = true;
            request.Media = new Amazon.TranscribeService.Model.Media();
            System.String requestMedia_media_MediaFileUri = null;
            if (cmdletContext.Media_MediaFileUri != null)
            {
                requestMedia_media_MediaFileUri = cmdletContext.Media_MediaFileUri;
            }
            if (requestMedia_media_MediaFileUri != null)
            {
                request.Media.MediaFileUri = requestMedia_media_MediaFileUri;
                requestMediaIsNull = false;
            }
            System.String requestMedia_media_RedactedMediaFileUri = null;
            if (cmdletContext.Media_RedactedMediaFileUri != null)
            {
                requestMedia_media_RedactedMediaFileUri = cmdletContext.Media_RedactedMediaFileUri;
            }
            if (requestMedia_media_RedactedMediaFileUri != null)
            {
                request.Media.RedactedMediaFileUri = requestMedia_media_RedactedMediaFileUri;
                requestMediaIsNull = false;
            }
             // determine if request.Media should be set to null
            if (requestMediaIsNull)
            {
                request.Media = null;
            }
            if (cmdletContext.OutputEncryptionKMSKeyId != null)
            {
                request.OutputEncryptionKMSKeyId = cmdletContext.OutputEncryptionKMSKeyId;
            }
            if (cmdletContext.OutputLocation != null)
            {
                request.OutputLocation = cmdletContext.OutputLocation;
            }
            
             // populate Settings
            var requestSettingsIsNull = true;
            request.Settings = new Amazon.TranscribeService.Model.CallAnalyticsJobSettings();
            Dictionary<System.String, Amazon.TranscribeService.Model.LanguageIdSettings> requestSettings_settings_LanguageIdSetting = null;
            if (cmdletContext.Settings_LanguageIdSetting != null)
            {
                requestSettings_settings_LanguageIdSetting = cmdletContext.Settings_LanguageIdSetting;
            }
            if (requestSettings_settings_LanguageIdSetting != null)
            {
                request.Settings.LanguageIdSettings = requestSettings_settings_LanguageIdSetting;
                requestSettingsIsNull = false;
            }
            System.String requestSettings_settings_LanguageModelName = null;
            if (cmdletContext.Settings_LanguageModelName != null)
            {
                requestSettings_settings_LanguageModelName = cmdletContext.Settings_LanguageModelName;
            }
            if (requestSettings_settings_LanguageModelName != null)
            {
                request.Settings.LanguageModelName = requestSettings_settings_LanguageModelName;
                requestSettingsIsNull = false;
            }
            List<System.String> requestSettings_settings_LanguageOption = null;
            if (cmdletContext.Settings_LanguageOption != null)
            {
                requestSettings_settings_LanguageOption = cmdletContext.Settings_LanguageOption;
            }
            if (requestSettings_settings_LanguageOption != null)
            {
                request.Settings.LanguageOptions = requestSettings_settings_LanguageOption;
                requestSettingsIsNull = false;
            }
            Amazon.TranscribeService.VocabularyFilterMethod requestSettings_settings_VocabularyFilterMethod = null;
            if (cmdletContext.Settings_VocabularyFilterMethod != null)
            {
                requestSettings_settings_VocabularyFilterMethod = cmdletContext.Settings_VocabularyFilterMethod;
            }
            if (requestSettings_settings_VocabularyFilterMethod != null)
            {
                request.Settings.VocabularyFilterMethod = requestSettings_settings_VocabularyFilterMethod;
                requestSettingsIsNull = false;
            }
            System.String requestSettings_settings_VocabularyFilterName = null;
            if (cmdletContext.Settings_VocabularyFilterName != null)
            {
                requestSettings_settings_VocabularyFilterName = cmdletContext.Settings_VocabularyFilterName;
            }
            if (requestSettings_settings_VocabularyFilterName != null)
            {
                request.Settings.VocabularyFilterName = requestSettings_settings_VocabularyFilterName;
                requestSettingsIsNull = false;
            }
            System.String requestSettings_settings_VocabularyName = null;
            if (cmdletContext.Settings_VocabularyName != null)
            {
                requestSettings_settings_VocabularyName = cmdletContext.Settings_VocabularyName;
            }
            if (requestSettings_settings_VocabularyName != null)
            {
                request.Settings.VocabularyName = requestSettings_settings_VocabularyName;
                requestSettingsIsNull = false;
            }
            Amazon.TranscribeService.Model.Summarization requestSettings_settings_Summarization = null;
            
             // populate Summarization
            var requestSettings_settings_SummarizationIsNull = true;
            requestSettings_settings_Summarization = new Amazon.TranscribeService.Model.Summarization();
            System.Boolean? requestSettings_settings_Summarization_summarization_GenerateAbstractiveSummary = null;
            if (cmdletContext.Summarization_GenerateAbstractiveSummary != null)
            {
                requestSettings_settings_Summarization_summarization_GenerateAbstractiveSummary = cmdletContext.Summarization_GenerateAbstractiveSummary.Value;
            }
            if (requestSettings_settings_Summarization_summarization_GenerateAbstractiveSummary != null)
            {
                requestSettings_settings_Summarization.GenerateAbstractiveSummary = requestSettings_settings_Summarization_summarization_GenerateAbstractiveSummary.Value;
                requestSettings_settings_SummarizationIsNull = false;
            }
             // determine if requestSettings_settings_Summarization should be set to null
            if (requestSettings_settings_SummarizationIsNull)
            {
                requestSettings_settings_Summarization = null;
            }
            if (requestSettings_settings_Summarization != null)
            {
                request.Settings.Summarization = requestSettings_settings_Summarization;
                requestSettingsIsNull = false;
            }
            Amazon.TranscribeService.Model.ContentRedaction requestSettings_settings_ContentRedaction = null;
            
             // populate ContentRedaction
            var requestSettings_settings_ContentRedactionIsNull = true;
            requestSettings_settings_ContentRedaction = new Amazon.TranscribeService.Model.ContentRedaction();
            List<System.String> requestSettings_settings_ContentRedaction_contentRedaction_PiiEntityType = null;
            if (cmdletContext.ContentRedaction_PiiEntityType != null)
            {
                requestSettings_settings_ContentRedaction_contentRedaction_PiiEntityType = cmdletContext.ContentRedaction_PiiEntityType;
            }
            if (requestSettings_settings_ContentRedaction_contentRedaction_PiiEntityType != null)
            {
                requestSettings_settings_ContentRedaction.PiiEntityTypes = requestSettings_settings_ContentRedaction_contentRedaction_PiiEntityType;
                requestSettings_settings_ContentRedactionIsNull = false;
            }
            Amazon.TranscribeService.RedactionOutput requestSettings_settings_ContentRedaction_contentRedaction_RedactionOutput = null;
            if (cmdletContext.ContentRedaction_RedactionOutput != null)
            {
                requestSettings_settings_ContentRedaction_contentRedaction_RedactionOutput = cmdletContext.ContentRedaction_RedactionOutput;
            }
            if (requestSettings_settings_ContentRedaction_contentRedaction_RedactionOutput != null)
            {
                requestSettings_settings_ContentRedaction.RedactionOutput = requestSettings_settings_ContentRedaction_contentRedaction_RedactionOutput;
                requestSettings_settings_ContentRedactionIsNull = false;
            }
            Amazon.TranscribeService.RedactionType requestSettings_settings_ContentRedaction_contentRedaction_RedactionType = null;
            if (cmdletContext.ContentRedaction_RedactionType != null)
            {
                requestSettings_settings_ContentRedaction_contentRedaction_RedactionType = cmdletContext.ContentRedaction_RedactionType;
            }
            if (requestSettings_settings_ContentRedaction_contentRedaction_RedactionType != null)
            {
                requestSettings_settings_ContentRedaction.RedactionType = requestSettings_settings_ContentRedaction_contentRedaction_RedactionType;
                requestSettings_settings_ContentRedactionIsNull = false;
            }
             // determine if requestSettings_settings_ContentRedaction should be set to null
            if (requestSettings_settings_ContentRedactionIsNull)
            {
                requestSettings_settings_ContentRedaction = null;
            }
            if (requestSettings_settings_ContentRedaction != null)
            {
                request.Settings.ContentRedaction = requestSettings_settings_ContentRedaction;
                requestSettingsIsNull = false;
            }
             // determine if request.Settings should be set to null
            if (requestSettingsIsNull)
            {
                request.Settings = null;
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
        
        private Amazon.TranscribeService.Model.StartCallAnalyticsJobResponse CallAWSServiceOperation(IAmazonTranscribeService client, Amazon.TranscribeService.Model.StartCallAnalyticsJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Transcribe Service", "StartCallAnalyticsJob");
            try
            {
                #if DESKTOP
                return client.StartCallAnalyticsJob(request);
                #elif CORECLR
                return client.StartCallAnalyticsJobAsync(request).GetAwaiter().GetResult();
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
            public System.String CallAnalyticsJobName { get; set; }
            public List<Amazon.TranscribeService.Model.ChannelDefinition> ChannelDefinition { get; set; }
            public System.String DataAccessRoleArn { get; set; }
            public System.String Media_MediaFileUri { get; set; }
            public System.String Media_RedactedMediaFileUri { get; set; }
            public System.String OutputEncryptionKMSKeyId { get; set; }
            public System.String OutputLocation { get; set; }
            public List<System.String> ContentRedaction_PiiEntityType { get; set; }
            public Amazon.TranscribeService.RedactionOutput ContentRedaction_RedactionOutput { get; set; }
            public Amazon.TranscribeService.RedactionType ContentRedaction_RedactionType { get; set; }
            public Dictionary<System.String, Amazon.TranscribeService.Model.LanguageIdSettings> Settings_LanguageIdSetting { get; set; }
            public System.String Settings_LanguageModelName { get; set; }
            public List<System.String> Settings_LanguageOption { get; set; }
            public System.Boolean? Summarization_GenerateAbstractiveSummary { get; set; }
            public Amazon.TranscribeService.VocabularyFilterMethod Settings_VocabularyFilterMethod { get; set; }
            public System.String Settings_VocabularyFilterName { get; set; }
            public System.String Settings_VocabularyName { get; set; }
            public List<Amazon.TranscribeService.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.TranscribeService.Model.StartCallAnalyticsJobResponse, StartTRSCallAnalyticsJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CallAnalyticsJob;
        }
        
    }
}
