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
using Amazon.TranscribeService;
using Amazon.TranscribeService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.TRS
{
    /// <summary>
    /// Transcribes a media file and returns the transcript in the same response. There is
    /// no job to start and no status to poll.
    /// 
    ///  
    /// <para>
    /// Use <c>TranscribeAudio</c> when you already have a complete media file and want the
    /// transcript right away. For large files, long audio, or bulk processing, use .
    /// </para><para>
    /// You must include the following parameters in your <c>TranscribeAudio</c> request:
    /// </para><ul><li><para><c>Media</c>: Your audio, either as inline bytes (<c>MediaBytes</c>) or as the Amazon
    /// S3 location of a media file (<c>MediaFileUri</c>).
    /// </para></li><li><para>
    /// One of <c>Language</c> or <c>LanguageDetectionMode</c>: Specify the language of your
    /// audio, or have Amazon Transcribe identify it.
    /// </para></li></ul><para>
    /// Your audio must be between 0.5 seconds and 1 hour long. Supported formats are WAV,
    /// MP3, FLAC, M4A, MP4, Ogg, WebM, and AMR.
    /// </para><para>
    /// If you send your audio in the request (<c>MediaBytes</c>), the file can be up to 25
    /// MB. If you provide an Amazon S3 location (<c>MediaFileUri</c>), the file can be up
    /// to 500 MB.
    /// </para><para>
    /// Amazon Transcribe always turns on smart formatting, also known as inverse text normalization
    /// (ITN). It writes numbers, dates, currency, and similar items in their usual written
    /// form. For example, "one hundred" becomes "100". You can't turn smart formatting off.
    /// </para><para>
    /// By default, Amazon Transcribe returns the transcript in <c>TranscriptResponse</c>.
    /// If you include <c>OutputConfiguration</c>, Amazon Transcribe writes the transcript
    /// to the Amazon S3 location you specify instead, and the response contains only that
    /// location.
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "TRSTranscribeAudio", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.TranscribeService.Model.TranscribeAudioResponse")]
    [AWSCmdlet("Calls the Amazon Transcribe Service TranscribeAudio API operation.", Operation = new[] {"TranscribeAudio"}, SelectReturnType = typeof(Amazon.TranscribeService.Model.TranscribeAudioResponse))]
    [AWSCmdletOutput("Amazon.TranscribeService.Model.TranscribeAudioResponse",
        "This cmdlet returns an Amazon.TranscribeService.Model.TranscribeAudioResponse object containing multiple properties."
    )]
    public partial class InvokeTRSTranscribeAudioCmdlet : AmazonTranscribeServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ChannelIdentification
        /// <summary>
        /// <para>
        /// <para>Enables channel identification in multi-channel audio. Each channel is transcribed
        /// independently, and each item in the transcript is labeled with its channel.</para><para>Channel identification supports up to two channels.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ChannelIdentification { get; set; }
        #endregion
        
        #region Parameter VocabularyFilterSettings_Filter
        /// <summary>
        /// <para>
        /// <para>Custom vocabulary filters, with one entry per language. In each entry, you can reference
        /// a custom vocabulary filter you created or provide words inline. All entries must use
        /// the same type, either all by name or all inline.</para><para>If you specify <c>Language</c>, include exactly one entry, and its <c>Language</c>
        /// must match. If you use <c>LanguageDetectionMode</c>, you can include one entry for
        /// each language in <c>LanguageOptions</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VocabularyFilterSettings_Filters")]
        public Amazon.TranscribeService.Model.VocabularyFilterEntry[] VocabularyFilterSettings_Filter { get; set; }
        #endregion
        
        #region Parameter Language
        /// <summary>
        /// <para>
        /// <para>The language spoken in your audio, as a base language code (for example, <c>en</c>
        /// or <c>es</c>).</para><para>Include either <c>Language</c> or <c>LanguageDetectionMode</c> in your request, but
        /// not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.TranscribeService.SyncLanguage")]
        public Amazon.TranscribeService.SyncLanguage Language { get; set; }
        #endregion
        
        #region Parameter LanguageDetectionMode
        /// <summary>
        /// <para>
        /// <para>Enables automatic language identification. Use <c>IDENTIFY_LANGUAGE</c> if your audio
        /// contains a single language that you don't know in advance.</para><para>You can optionally include <c>LanguageOptions</c> to limit identification to languages
        /// you think may be present, which can improve accuracy.</para><para>Amazon Transcribe returns the identified language, as a locale (for example, <c>en-US</c>),
        /// in the response metadata.</para><para>Include either <c>Language</c> or <c>LanguageDetectionMode</c> in your request, but
        /// not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.TranscribeService.LanguageDetectionMode")]
        public Amazon.TranscribeService.LanguageDetectionMode LanguageDetectionMode { get; set; }
        #endregion
        
        #region Parameter LanguageOption
        /// <summary>
        /// <para>
        /// <para>A list of two or more languages that you think may be present in your audio, as base
        /// language codes (for example, <c>en</c> and <c>es</c>). Each language can appear only
        /// once. A list with only one language returns a <c>BadRequestException</c>.</para><para>You can use <c>LanguageOptions</c> only with <c>LanguageDetectionMode</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LanguageOptions")]
        public System.String[] LanguageOption { get; set; }
        #endregion
        
        #region Parameter MaxSpeakerLabel
        /// <summary>
        /// <para>
        /// <para>Specify the maximum number of speakers you want to partition in your media.</para><para>Note that if your media contains more speakers than the specified number, Amazon Transcribe
        /// treats multiple speakers as a single speaker.</para><para>You can set <c>MaxSpeakerLabels</c> only if <c>ShowSpeakerLabels</c> is <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxSpeakerLabels")]
        public System.Int32? MaxSpeakerLabel { get; set; }
        #endregion
        
        #region Parameter Media_MediaByte
        /// <summary>
        /// <para>
        /// <para>Your audio file, provided inline in the request. The maximum size is 25 MB (26,214,400
        /// bytes) of audio, measured before base64 encoding.</para><para>If you use an Amazon Web Services SDK, the SDK base64-encodes the bytes for you. If
        /// you call the API directly, base64-encode the bytes yourself.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Media_MediaBytes")]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Media_MediaByte { get; set; }
        #endregion
        
        #region Parameter Media_MediaFileUri
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 location of the media file you want to transcribe. For example:</para><ul><li><para><c>s3://amzn-s3-demo-bucket/my-media-file.flac</c></para></li><li><para><c>s3://amzn-s3-demo-bucket/media-files/my-media-file.flac</c></para></li></ul><para>The maximum file size is 500 MB. You must have read permission for the file.</para><para>The Amazon S3 bucket that contains your input media must be located in the same Amazon
        /// Web Services Region where you're making your transcription request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Media_MediaFileUri { get; set; }
        #endregion
        
        #region Parameter OutputConfiguration_OutputMediaFileUri
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 location where you want your transcript written. For example:</para><ul><li><para><c>s3://amzn-s3-demo-bucket/my-transcript.json</c></para></li><li><para><c>s3://amzn-s3-demo-bucket/transcripts/</c></para></li></ul><para>If the location ends with an object key, Amazon Transcribe writes the transcript to
        /// that key. If it is a bucket or ends with a forward slash (<c>/</c>), it's treated
        /// as a prefix, and Amazon Transcribe writes the transcript under it to a file named
        /// with the request ID of your call and a <c>.json</c> extension.</para><para>If you use <c>ContentRedaction</c>, Amazon Transcribe writes the redacted transcript
        /// to the same location and adds <c>redacted-</c> before the file name (for example,
        /// <c>redacted-my-transcript.json</c>). With <c>redacted_and_unredacted</c>, Amazon Transcribe
        /// writes both files.</para><para>If an object already exists at that key, Amazon Transcribe overwrites it.</para><para>In a response, this is the location where Amazon Transcribe wrote your transcript.
        /// If you requested <c>redacted_and_unredacted</c> output, this is the location of the
        /// unredacted transcript.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputConfiguration_OutputMediaFileUri { get; set; }
        #endregion
        
        #region Parameter ContentRedaction_PiiEntityType
        /// <summary>
        /// <para>
        /// <para>Specify which types of personally identifiable information (PII) you want to redact
        /// in your transcript. You can include as many types as you'd like, or you can select
        /// <c>ALL</c>. If you do not include <c>PiiEntityTypes</c> in your request, all PII is
        /// redacted.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContentRedaction_PiiEntityTypes")]
        public System.String[] ContentRedaction_PiiEntityType { get; set; }
        #endregion
        
        #region Parameter ContentRedaction_RedactionOutput
        /// <summary>
        /// <para>
        /// <para>Specify if you want only a redacted transcript, or if you want a redacted and an unredacted
        /// transcript.</para><para>When you choose <c>redacted</c> Amazon Transcribe creates only a redacted transcript.</para><para>When you choose <c>redacted_and_unredacted</c> Amazon Transcribe creates a redacted
        /// and an unredacted transcript. For batch jobs, Amazon Transcribe creates two separate
        /// files. For <c>TranscribeAudio</c>, Amazon Transcribe returns them in <c>RedactedResults</c>
        /// and <c>Results</c>, or writes them as two separate files if you use <c>OutputConfiguration</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [AWSConstantClassSource("Amazon.TranscribeService.RedactionType")]
        public Amazon.TranscribeService.RedactionType ContentRedaction_RedactionType { get; set; }
        #endregion
        
        #region Parameter ShowSpeakerLabel
        /// <summary>
        /// <para>
        /// <para>Enables speaker partitioning (diarization) in your transcript. Speaker partitioning
        /// labels the speech from individual speakers in your media file.</para><para>If you set <c>ShowSpeakerLabels</c> to <c>true</c>, you must also include <c>MaxSpeakerLabels</c>.</para><para>For more information, see <a href="https://docs.aws.amazon.com/transcribe/latest/dg/diarization.html">Partitioning
        /// speakers (diarization)</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ShowSpeakerLabels")]
        public System.Boolean? ShowSpeakerLabel { get; set; }
        #endregion
        
        #region Parameter VocabularyFilterSettings_VocabularyFilterMethod
        /// <summary>
        /// <para>
        /// <para>Specify how you want your custom vocabulary filter applied to your transcript.</para><para>To replace words with <c>***</c>, choose <c>mask</c>.</para><para>To delete words, choose <c>remove</c>.</para><para>To flag words without changing them, choose <c>tag</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.TranscribeService.VocabularyFilterMethod")]
        public Amazon.TranscribeService.VocabularyFilterMethod VocabularyFilterSettings_VocabularyFilterMethod { get; set; }
        #endregion
        
        #region Parameter VocabularySetting
        /// <summary>
        /// <para>
        /// <para>Custom vocabularies to apply to your transcript, with one entry per language. In each
        /// entry, you can reference a custom vocabulary you created or provide phrases inline.
        /// All entries must use the same type, either all by name or all inline.</para><para>If you specify <c>Language</c>, include exactly one entry, and its <c>Language</c>
        /// must match. If you use <c>LanguageDetectionMode</c>, you can include one entry for
        /// each language in <c>LanguageOptions</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VocabularySettings")]
        public Amazon.TranscribeService.Model.VocabularySettingsEntry[] VocabularySetting { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TranscribeService.Model.TranscribeAudioResponse).
        /// Specifying the name of a property of type Amazon.TranscribeService.Model.TranscribeAudioResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-TRSTranscribeAudio (TranscribeAudio)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.TranscribeService.Model.TranscribeAudioResponse, InvokeTRSTranscribeAudioCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ChannelIdentification = this.ChannelIdentification;
            if (this.ContentRedaction_PiiEntityType != null)
            {
                context.ContentRedaction_PiiEntityType = new List<System.String>(this.ContentRedaction_PiiEntityType);
            }
            context.ContentRedaction_RedactionOutput = this.ContentRedaction_RedactionOutput;
            context.ContentRedaction_RedactionType = this.ContentRedaction_RedactionType;
            context.Language = this.Language;
            context.LanguageDetectionMode = this.LanguageDetectionMode;
            if (this.LanguageOption != null)
            {
                context.LanguageOption = new List<System.String>(this.LanguageOption);
            }
            context.MaxSpeakerLabel = this.MaxSpeakerLabel;
            context.Media_MediaByte = this.Media_MediaByte;
            context.Media_MediaFileUri = this.Media_MediaFileUri;
            context.OutputConfiguration_OutputMediaFileUri = this.OutputConfiguration_OutputMediaFileUri;
            context.ShowSpeakerLabel = this.ShowSpeakerLabel;
            if (this.VocabularyFilterSettings_Filter != null)
            {
                context.VocabularyFilterSettings_Filter = new List<Amazon.TranscribeService.Model.VocabularyFilterEntry>(this.VocabularyFilterSettings_Filter);
            }
            context.VocabularyFilterSettings_VocabularyFilterMethod = this.VocabularyFilterSettings_VocabularyFilterMethod;
            if (this.VocabularySetting != null)
            {
                context.VocabularySetting = new List<Amazon.TranscribeService.Model.VocabularySettingsEntry>(this.VocabularySetting);
            }
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _Media_MediaByteStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.TranscribeService.Model.TranscribeAudioRequest();
                
                if (cmdletContext.ChannelIdentification != null)
                {
                    request.ChannelIdentification = cmdletContext.ChannelIdentification.Value;
                }
                
                 // populate ContentRedaction
                var requestContentRedactionIsNull = true;
                request.ContentRedaction = new Amazon.TranscribeService.Model.ContentRedaction();
                List<System.String> requestContentRedaction_contentRedaction_PiiEntityType = null;
                if (cmdletContext.ContentRedaction_PiiEntityType != null)
                {
                    requestContentRedaction_contentRedaction_PiiEntityType = cmdletContext.ContentRedaction_PiiEntityType;
                }
                if (requestContentRedaction_contentRedaction_PiiEntityType != null)
                {
                    request.ContentRedaction.PiiEntityTypes = requestContentRedaction_contentRedaction_PiiEntityType;
                    requestContentRedactionIsNull = false;
                }
                Amazon.TranscribeService.RedactionOutput requestContentRedaction_contentRedaction_RedactionOutput = null;
                if (cmdletContext.ContentRedaction_RedactionOutput != null)
                {
                    requestContentRedaction_contentRedaction_RedactionOutput = cmdletContext.ContentRedaction_RedactionOutput;
                }
                if (requestContentRedaction_contentRedaction_RedactionOutput != null)
                {
                    request.ContentRedaction.RedactionOutput = requestContentRedaction_contentRedaction_RedactionOutput;
                    requestContentRedactionIsNull = false;
                }
                Amazon.TranscribeService.RedactionType requestContentRedaction_contentRedaction_RedactionType = null;
                if (cmdletContext.ContentRedaction_RedactionType != null)
                {
                    requestContentRedaction_contentRedaction_RedactionType = cmdletContext.ContentRedaction_RedactionType;
                }
                if (requestContentRedaction_contentRedaction_RedactionType != null)
                {
                    request.ContentRedaction.RedactionType = requestContentRedaction_contentRedaction_RedactionType;
                    requestContentRedactionIsNull = false;
                }
                 // determine if request.ContentRedaction should be set to null
                if (requestContentRedactionIsNull)
                {
                    request.ContentRedaction = null;
                }
                if (cmdletContext.Language != null)
                {
                    request.Language = cmdletContext.Language;
                }
                if (cmdletContext.LanguageDetectionMode != null)
                {
                    request.LanguageDetectionMode = cmdletContext.LanguageDetectionMode;
                }
                if (cmdletContext.LanguageOption != null)
                {
                    request.LanguageOptions = cmdletContext.LanguageOption;
                }
                if (cmdletContext.MaxSpeakerLabel != null)
                {
                    request.MaxSpeakerLabels = cmdletContext.MaxSpeakerLabel.Value;
                }
                
                 // populate Media
                var requestMediaIsNull = true;
                request.Media = new Amazon.TranscribeService.Model.SyncMedia();
                System.IO.MemoryStream requestMedia_media_MediaByte = null;
                if (cmdletContext.Media_MediaByte != null)
                {
                    _Media_MediaByteStream = new System.IO.MemoryStream(cmdletContext.Media_MediaByte);
                    requestMedia_media_MediaByte = _Media_MediaByteStream;
                }
                if (requestMedia_media_MediaByte != null)
                {
                    request.Media.MediaBytes = requestMedia_media_MediaByte;
                    requestMediaIsNull = false;
                }
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
                 // determine if request.Media should be set to null
                if (requestMediaIsNull)
                {
                    request.Media = null;
                }
                
                 // populate OutputConfiguration
                var requestOutputConfigurationIsNull = true;
                request.OutputConfiguration = new Amazon.TranscribeService.Model.SyncOutputConfiguration();
                System.String requestOutputConfiguration_outputConfiguration_OutputMediaFileUri = null;
                if (cmdletContext.OutputConfiguration_OutputMediaFileUri != null)
                {
                    requestOutputConfiguration_outputConfiguration_OutputMediaFileUri = cmdletContext.OutputConfiguration_OutputMediaFileUri;
                }
                if (requestOutputConfiguration_outputConfiguration_OutputMediaFileUri != null)
                {
                    request.OutputConfiguration.OutputMediaFileUri = requestOutputConfiguration_outputConfiguration_OutputMediaFileUri;
                    requestOutputConfigurationIsNull = false;
                }
                 // determine if request.OutputConfiguration should be set to null
                if (requestOutputConfigurationIsNull)
                {
                    request.OutputConfiguration = null;
                }
                if (cmdletContext.ShowSpeakerLabel != null)
                {
                    request.ShowSpeakerLabels = cmdletContext.ShowSpeakerLabel.Value;
                }
                
                 // populate VocabularyFilterSettings
                var requestVocabularyFilterSettingsIsNull = true;
                request.VocabularyFilterSettings = new Amazon.TranscribeService.Model.VocabularyFilterSettings();
                List<Amazon.TranscribeService.Model.VocabularyFilterEntry> requestVocabularyFilterSettings_vocabularyFilterSettings_Filter = null;
                if (cmdletContext.VocabularyFilterSettings_Filter != null)
                {
                    requestVocabularyFilterSettings_vocabularyFilterSettings_Filter = cmdletContext.VocabularyFilterSettings_Filter;
                }
                if (requestVocabularyFilterSettings_vocabularyFilterSettings_Filter != null)
                {
                    request.VocabularyFilterSettings.Filters = requestVocabularyFilterSettings_vocabularyFilterSettings_Filter;
                    requestVocabularyFilterSettingsIsNull = false;
                }
                Amazon.TranscribeService.VocabularyFilterMethod requestVocabularyFilterSettings_vocabularyFilterSettings_VocabularyFilterMethod = null;
                if (cmdletContext.VocabularyFilterSettings_VocabularyFilterMethod != null)
                {
                    requestVocabularyFilterSettings_vocabularyFilterSettings_VocabularyFilterMethod = cmdletContext.VocabularyFilterSettings_VocabularyFilterMethod;
                }
                if (requestVocabularyFilterSettings_vocabularyFilterSettings_VocabularyFilterMethod != null)
                {
                    request.VocabularyFilterSettings.VocabularyFilterMethod = requestVocabularyFilterSettings_vocabularyFilterSettings_VocabularyFilterMethod;
                    requestVocabularyFilterSettingsIsNull = false;
                }
                 // determine if request.VocabularyFilterSettings should be set to null
                if (requestVocabularyFilterSettingsIsNull)
                {
                    request.VocabularyFilterSettings = null;
                }
                if (cmdletContext.VocabularySetting != null)
                {
                    request.VocabularySettings = cmdletContext.VocabularySetting;
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
                if( _Media_MediaByteStream != null)
                {
                    _Media_MediaByteStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.TranscribeService.Model.TranscribeAudioResponse CallAWSServiceOperation(IAmazonTranscribeService client, Amazon.TranscribeService.Model.TranscribeAudioRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Transcribe Service", "TranscribeAudio");
            try
            {
                return client.TranscribeAudioAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? ChannelIdentification { get; set; }
            public List<System.String> ContentRedaction_PiiEntityType { get; set; }
            public Amazon.TranscribeService.RedactionOutput ContentRedaction_RedactionOutput { get; set; }
            public Amazon.TranscribeService.RedactionType ContentRedaction_RedactionType { get; set; }
            public Amazon.TranscribeService.SyncLanguage Language { get; set; }
            public Amazon.TranscribeService.LanguageDetectionMode LanguageDetectionMode { get; set; }
            public List<System.String> LanguageOption { get; set; }
            public System.Int32? MaxSpeakerLabel { get; set; }
            public byte[] Media_MediaByte { get; set; }
            public System.String Media_MediaFileUri { get; set; }
            public System.String OutputConfiguration_OutputMediaFileUri { get; set; }
            public System.Boolean? ShowSpeakerLabel { get; set; }
            public List<Amazon.TranscribeService.Model.VocabularyFilterEntry> VocabularyFilterSettings_Filter { get; set; }
            public Amazon.TranscribeService.VocabularyFilterMethod VocabularyFilterSettings_VocabularyFilterMethod { get; set; }
            public List<Amazon.TranscribeService.Model.VocabularySettingsEntry> VocabularySetting { get; set; }
            public System.Func<Amazon.TranscribeService.Model.TranscribeAudioResponse, InvokeTRSTranscribeAudioCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
