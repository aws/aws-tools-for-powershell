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
using Amazon.TranscribeService;
using Amazon.TranscribeService.Model;

namespace Amazon.PowerShell.Cmdlets.TRS
{
    /// <summary>
    /// Transcribes the audio from a media file and applies any additional Request Parameters
    /// you choose to include in your request.
    /// 
    ///  
    /// <para>
    /// To make a <c>StartTranscriptionJob</c> request, you must first upload your media file
    /// into an Amazon S3 bucket; you can then specify the Amazon S3 location of the file
    /// using the <c>Media</c> parameter.
    /// </para><para>
    /// You must include the following parameters in your <c>StartTranscriptionJob</c> request:
    /// </para><ul><li><para><c>region</c>: The Amazon Web Services Region where you are making your request.
    /// For a list of Amazon Web Services Regions supported with Amazon Transcribe, refer
    /// to <a href="https://docs.aws.amazon.com/general/latest/gr/transcribe.html">Amazon
    /// Transcribe endpoints and quotas</a>.
    /// </para></li><li><para><c>TranscriptionJobName</c>: A custom name you create for your transcription job
    /// that is unique within your Amazon Web Services account.
    /// </para></li><li><para><c>Media</c> (<c>MediaFileUri</c>): The Amazon S3 location of your media file.
    /// </para></li><li><para>
    /// One of <c>LanguageCode</c>, <c>IdentifyLanguage</c>, or <c>IdentifyMultipleLanguages</c>:
    /// If you know the language of your media file, specify it using the <c>LanguageCode</c>
    /// parameter; you can find all valid language codes in the <a href="https://docs.aws.amazon.com/transcribe/latest/dg/supported-languages.html">Supported
    /// languages</a> table. If you do not know the languages spoken in your media, use either
    /// <c>IdentifyLanguage</c> or <c>IdentifyMultipleLanguages</c> and let Amazon Transcribe
    /// identify the languages for you.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Start", "TRSTranscriptionJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.TranscribeService.Model.TranscriptionJob")]
    [AWSCmdlet("Calls the Amazon Transcribe Service StartTranscriptionJob API operation.", Operation = new[] {"StartTranscriptionJob"}, SelectReturnType = typeof(Amazon.TranscribeService.Model.StartTranscriptionJobResponse))]
    [AWSCmdletOutput("Amazon.TranscribeService.Model.TranscriptionJob or Amazon.TranscribeService.Model.StartTranscriptionJobResponse",
        "This cmdlet returns an Amazon.TranscribeService.Model.TranscriptionJob object.",
        "The service call response (type Amazon.TranscribeService.Model.StartTranscriptionJobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartTRSTranscriptionJobCmdlet : AmazonTranscribeServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter JobExecutionSettings_AllowDeferredExecution
        /// <summary>
        /// <para>
        /// <para>Makes it possible to enable job queuing when your concurrent request limit is exceeded.
        /// When <c>AllowDeferredExecution</c> is set to <c>true</c>, transcription job requests
        /// are placed in a queue until the number of jobs falls below the concurrent request
        /// limit. If <c>AllowDeferredExecution</c> is set to <c>false</c> and the number of transcription
        /// job requests exceed the concurrent request limit, you get a <c>LimitExceededException</c>
        /// error.</para><para>If you include <c>AllowDeferredExecution</c> in your request, you must also include
        /// <c>DataAccessRoleArn</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? JobExecutionSettings_AllowDeferredExecution { get; set; }
        #endregion
        
        #region Parameter Settings_ChannelIdentification
        /// <summary>
        /// <para>
        /// <para>Enables channel identification in multi-channel audio.</para><para>Channel identification transcribes the audio on each channel independently, then appends
        /// the output for each channel into one transcript.</para><para>For more information, see <a href="https://docs.aws.amazon.com/transcribe/latest/dg/channel-id.html">Transcribing
        /// multi-channel audio</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Settings_ChannelIdentification { get; set; }
        #endregion
        
        #region Parameter JobExecutionSettings_DataAccessRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an IAM role that has permissions to access the Amazon
        /// S3 bucket that contains your input files. If the role that you specify doesn’t have
        /// the appropriate permissions to access the specified Amazon S3 location, your request
        /// fails.</para><para>IAM role ARNs have the format <c>arn:partition:iam::account:role/role-name-with-path</c>.
        /// For example: <c>arn:aws:iam::111122223333:role/Admin</c>. For more information, see
        /// <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_identifiers.html#identifiers-arns">IAM
        /// ARNs</a>.</para><para>Note that if you include <c>DataAccessRoleArn</c> in your request, you must also include
        /// <c>AllowDeferredExecution</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String JobExecutionSettings_DataAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter Subtitles_Format
        /// <summary>
        /// <para>
        /// <para>Specify the output format for your subtitle file; if you select both WebVTT (<c>vtt</c>)
        /// and SubRip (<c>srt</c>) formats, two output files are generated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Subtitles_Formats")]
        public System.String[] Subtitles_Format { get; set; }
        #endregion
        
        #region Parameter IdentifyLanguage
        /// <summary>
        /// <para>
        /// <para>Enables automatic language identification in your transcription job request. Use this
        /// parameter if your media file contains only one language. If your media contains multiple
        /// languages, use <c>IdentifyMultipleLanguages</c> instead.</para><para>If you include <c>IdentifyLanguage</c>, you can optionally include a list of language
        /// codes, using <c>LanguageOptions</c>, that you think may be present in your media file.
        /// Including <c>LanguageOptions</c> restricts <c>IdentifyLanguage</c> to only the language
        /// options that you specify, which can improve transcription accuracy.</para><para>If you want to apply a custom language model, a custom vocabulary, or a custom vocabulary
        /// filter to your automatic language identification request, include <c>LanguageIdSettings</c>
        /// with the relevant sub-parameters (<c>VocabularyName</c>, <c>LanguageModelName</c>,
        /// and <c>VocabularyFilterName</c>). If you include <c>LanguageIdSettings</c>, also include
        /// <c>LanguageOptions</c>.</para><para>Note that you must include one of <c>LanguageCode</c>, <c>IdentifyLanguage</c>, or
        /// <c>IdentifyMultipleLanguages</c> in your request. If you include more than one of
        /// these parameters, your transcription job fails.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IdentifyLanguage { get; set; }
        #endregion
        
        #region Parameter IdentifyMultipleLanguage
        /// <summary>
        /// <para>
        /// <para>Enables automatic multi-language identification in your transcription job request.
        /// Use this parameter if your media file contains more than one language. If your media
        /// contains only one language, use <c>IdentifyLanguage</c> instead.</para><para>If you include <c>IdentifyMultipleLanguages</c>, you can optionally include a list
        /// of language codes, using <c>LanguageOptions</c>, that you think may be present in
        /// your media file. Including <c>LanguageOptions</c> restricts <c>IdentifyLanguage</c>
        /// to only the language options that you specify, which can improve transcription accuracy.</para><para>If you want to apply a custom vocabulary or a custom vocabulary filter to your automatic
        /// language identification request, include <c>LanguageIdSettings</c> with the relevant
        /// sub-parameters (<c>VocabularyName</c> and <c>VocabularyFilterName</c>). If you include
        /// <c>LanguageIdSettings</c>, also include <c>LanguageOptions</c>.</para><para>Note that you must include one of <c>LanguageCode</c>, <c>IdentifyLanguage</c>, or
        /// <c>IdentifyMultipleLanguages</c> in your request. If you include more than one of
        /// these parameters, your transcription job fails.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IdentifyMultipleLanguages")]
        public System.Boolean? IdentifyMultipleLanguage { get; set; }
        #endregion
        
        #region Parameter KMSEncryptionContext
        /// <summary>
        /// <para>
        /// <para>A map of plain text, non-secret key:value pairs, known as encryption context pairs,
        /// that provide an added layer of security for your data. For more information, see <a href="https://docs.aws.amazon.com/transcribe/latest/dg/key-management.html#kms-context">KMS
        /// encryption context</a> and <a href="https://docs.aws.amazon.com/transcribe/latest/dg/symmetric-asymmetric.html">Asymmetric
        /// keys in KMS</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable KMSEncryptionContext { get; set; }
        #endregion
        
        #region Parameter LanguageCode
        /// <summary>
        /// <para>
        /// <para>The language code that represents the language spoken in the input media file.</para><para>If you're unsure of the language spoken in your media file, consider using <c>IdentifyLanguage</c>
        /// or <c>IdentifyMultipleLanguages</c> to enable automatic language identification.</para><para>Note that you must include one of <c>LanguageCode</c>, <c>IdentifyLanguage</c>, or
        /// <c>IdentifyMultipleLanguages</c> in your request. If you include more than one of
        /// these parameters, your transcription job fails.</para><para>For a list of supported languages and their associated language codes, refer to the
        /// <a href="https://docs.aws.amazon.com/transcribe/latest/dg/supported-languages.html">Supported
        /// languages</a> table.</para><note><para>To transcribe speech in Modern Standard Arabic (<c>ar-SA</c>), your media file must
        /// be encoded at a sample rate of 16,000 Hz or higher.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.TranscribeService.LanguageCode")]
        public Amazon.TranscribeService.LanguageCode LanguageCode { get; set; }
        #endregion
        
        #region Parameter LanguageIdSetting
        /// <summary>
        /// <para>
        /// <para>If using automatic language identification in your request and you want to apply a
        /// custom language model, a custom vocabulary, or a custom vocabulary filter, include
        /// <c>LanguageIdSettings</c> with the relevant sub-parameters (<c>VocabularyName</c>,
        /// <c>LanguageModelName</c>, and <c>VocabularyFilterName</c>). Note that multi-language
        /// identification (<c>IdentifyMultipleLanguages</c>) doesn't support custom language
        /// models.</para><para><c>LanguageIdSettings</c> supports two to five language codes. Each language code
        /// you include can have an associated custom language model, custom vocabulary, and custom
        /// vocabulary filter. The language codes that you specify must match the languages of
        /// the associated custom language models, custom vocabularies, and custom vocabulary
        /// filters.</para><para>It's recommended that you include <c>LanguageOptions</c> when using <c>LanguageIdSettings</c>
        /// to ensure that the correct language dialect is identified. For example, if you specify
        /// a custom vocabulary that is in <c>en-US</c> but Amazon Transcribe determines that
        /// the language spoken in your media is <c>en-AU</c>, your custom vocabulary <i>is not</i>
        /// applied to your transcription. If you include <c>LanguageOptions</c> and include <c>en-US</c>
        /// as the only English language dialect, your custom vocabulary <i>is</i> applied to
        /// your transcription.</para><para>If you want to include a custom language model with your request but <b>do not</b>
        /// want to use automatic language identification, use instead the <code /> parameter with
        /// the <c>LanguageModelName</c> sub-parameter. If you want to include a custom vocabulary
        /// or a custom vocabulary filter (or both) with your request but <b>do not</b> want to
        /// use automatic language identification, use instead the <code /> parameter with the
        /// <c>VocabularyName</c> or <c>VocabularyFilterName</c> (or both) sub-parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LanguageIdSettings")]
        public System.Collections.Hashtable LanguageIdSetting { get; set; }
        #endregion
        
        #region Parameter ModelSettings_LanguageModelName
        /// <summary>
        /// <para>
        /// <para>The name of the custom language model you want to use when processing your transcription
        /// job. Note that custom language model names are case sensitive.</para><para>The language of the specified custom language model must match the language code that
        /// you specify in your transcription request. If the languages do not match, the custom
        /// language model isn't applied. There are no errors or warnings associated with a language
        /// mismatch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ModelSettings_LanguageModelName { get; set; }
        #endregion
        
        #region Parameter LanguageOption
        /// <summary>
        /// <para>
        /// <para>You can specify two or more language codes that represent the languages you think
        /// may be present in your media. Including more than five is not recommended. If you're
        /// unsure what languages are present, do not include this parameter.</para><para>If you include <c>LanguageOptions</c> in your request, you must also include <c>IdentifyLanguage</c>.</para><para>For more information, refer to <a href="https://docs.aws.amazon.com/transcribe/latest/dg/supported-languages.html">Supported
        /// languages</a>.</para><para>To transcribe speech in Modern Standard Arabic (<c>ar-SA</c>), your media file must
        /// be encoded at a sample rate of 16,000 Hz or higher.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LanguageOptions")]
        public System.String[] LanguageOption { get; set; }
        #endregion
        
        #region Parameter Settings_MaxAlternative
        /// <summary>
        /// <para>
        /// <para>Indicate the maximum number of alternative transcriptions you want Amazon Transcribe
        /// to include in your transcript.</para><para>If you select a number greater than the number of alternative transcriptions generated
        /// by Amazon Transcribe, only the actual number of alternative transcriptions are included.</para><para>If you include <c>MaxAlternatives</c> in your request, you must also include <c>ShowAlternatives</c>
        /// with a value of <c>true</c>.</para><para>For more information, see <a href="https://docs.aws.amazon.com/transcribe/latest/dg/how-alternatives.html">Alternative
        /// transcriptions</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_MaxAlternatives")]
        public System.Int32? Settings_MaxAlternative { get; set; }
        #endregion
        
        #region Parameter Settings_MaxSpeakerLabel
        /// <summary>
        /// <para>
        /// <para>Specify the maximum number of speakers you want to partition in your media.</para><para>Note that if your media contains more speakers than the specified number, multiple
        /// speakers are treated as a single speaker.</para><para>If you specify the <c>MaxSpeakerLabels</c> field, you must set the <c>ShowSpeakerLabels</c>
        /// field to true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_MaxSpeakerLabels")]
        public System.Int32? Settings_MaxSpeakerLabel { get; set; }
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
        
        #region Parameter MediaFormat
        /// <summary>
        /// <para>
        /// <para>Specify the format of your input media file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.TranscribeService.MediaFormat")]
        public Amazon.TranscribeService.MediaFormat MediaFormat { get; set; }
        #endregion
        
        #region Parameter MediaSampleRateHertz
        /// <summary>
        /// <para>
        /// <para>The sample rate, in hertz, of the audio track in your input media file.</para><para>If you do not specify the media sample rate, Amazon Transcribe determines it for you.
        /// If you specify the sample rate, it must match the rate detected by Amazon Transcribe.
        /// If there's a mismatch between the value that you specify and the value detected, your
        /// job fails. In most cases, you can omit <c>MediaSampleRateHertz</c> and let Amazon
        /// Transcribe determine the sample rate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MediaSampleRateHertz { get; set; }
        #endregion
        
        #region Parameter OutputBucketName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon S3 bucket where you want your transcription output stored.
        /// Do not include the <c>S3://</c> prefix of the specified bucket.</para><para>If you want your output to go to a sub-folder of this bucket, specify it using the
        /// <c>OutputKey</c> parameter; <c>OutputBucketName</c> only accepts the name of a bucket.</para><para>For example, if you want your output stored in <c>S3://DOC-EXAMPLE-BUCKET</c>, set
        /// <c>OutputBucketName</c> to <c>DOC-EXAMPLE-BUCKET</c>. However, if you want your output
        /// stored in <c>S3://DOC-EXAMPLE-BUCKET/test-files/</c>, set <c>OutputBucketName</c>
        /// to <c>DOC-EXAMPLE-BUCKET</c> and <c>OutputKey</c> to <c>test-files/</c>.</para><para>Note that Amazon Transcribe must have permission to use the specified location. You
        /// can change Amazon S3 permissions using the <a href="https://console.aws.amazon.com/s3">Amazon
        /// Web Services Management Console</a>. See also <a href="https://docs.aws.amazon.com/transcribe/latest/dg/security_iam_id-based-policy-examples.html#auth-role-iam-user">Permissions
        /// Required for IAM User Roles</a>.</para><para>If you do not specify <c>OutputBucketName</c>, your transcript is placed in a service-managed
        /// Amazon S3 bucket and you are provided with a URI to access your transcript.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputBucketName { get; set; }
        #endregion
        
        #region Parameter OutputEncryptionKMSKeyId
        /// <summary>
        /// <para>
        /// <para>The KMS key you want to use to encrypt your transcription output.</para><para>If using a key located in the <b>current</b> Amazon Web Services account, you can
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
        
        #region Parameter OutputKey
        /// <summary>
        /// <para>
        /// <para>Use in combination with <c>OutputBucketName</c> to specify the output location of
        /// your transcript and, optionally, a unique name for your output file. The default name
        /// for your transcription output is the same as the name you specified for your transcription
        /// job (<c>TranscriptionJobName</c>).</para><para>Here are some examples of how you can use <c>OutputKey</c>:</para><ul><li><para>If you specify 'DOC-EXAMPLE-BUCKET' as the <c>OutputBucketName</c> and 'my-transcript.json'
        /// as the <c>OutputKey</c>, your transcription output path is <c>s3://DOC-EXAMPLE-BUCKET/my-transcript.json</c>.</para></li><li><para>If you specify 'my-first-transcription' as the <c>TranscriptionJobName</c>, 'DOC-EXAMPLE-BUCKET'
        /// as the <c>OutputBucketName</c>, and 'my-transcript' as the <c>OutputKey</c>, your
        /// transcription output path is <c>s3://DOC-EXAMPLE-BUCKET/my-transcript/my-first-transcription.json</c>.</para></li><li><para>If you specify 'DOC-EXAMPLE-BUCKET' as the <c>OutputBucketName</c> and 'test-files/my-transcript.json'
        /// as the <c>OutputKey</c>, your transcription output path is <c>s3://DOC-EXAMPLE-BUCKET/test-files/my-transcript.json</c>.</para></li><li><para>If you specify 'my-first-transcription' as the <c>TranscriptionJobName</c>, 'DOC-EXAMPLE-BUCKET'
        /// as the <c>OutputBucketName</c>, and 'test-files/my-transcript' as the <c>OutputKey</c>,
        /// your transcription output path is <c>s3://DOC-EXAMPLE-BUCKET/test-files/my-transcript/my-first-transcription.json</c>.</para></li></ul><para>If you specify the name of an Amazon S3 bucket sub-folder that doesn't exist, one
        /// is created for you.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputKey { get; set; }
        #endregion
        
        #region Parameter Subtitles_OutputStartIndex
        /// <summary>
        /// <para>
        /// <para>Specify the starting value that is assigned to the first subtitle segment.</para><para>The default start index for Amazon Transcribe is <c>0</c>, which differs from the
        /// more widely used standard of <c>1</c>. If you're uncertain which value to use, we
        /// recommend choosing <c>1</c>, as this may improve compatibility with other services.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Subtitles_OutputStartIndex { get; set; }
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
        [Alias("ContentRedaction_PiiEntityTypes")]
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
        
        #region Parameter Settings_ShowAlternative
        /// <summary>
        /// <para>
        /// <para>To include alternative transcriptions within your transcription output, include <c>ShowAlternatives</c>
        /// in your transcription request.</para><para>If you have multi-channel audio and do not enable channel identification, your audio
        /// is transcribed in a continuous manner and your transcript does not separate the speech
        /// by channel.</para><para>If you include <c>ShowAlternatives</c>, you must also include <c>MaxAlternatives</c>,
        /// which is the maximum number of alternative transcriptions you want Amazon Transcribe
        /// to generate.</para><para>For more information, see <a href="https://docs.aws.amazon.com/transcribe/latest/dg/how-alternatives.html">Alternative
        /// transcriptions</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_ShowAlternatives")]
        public System.Boolean? Settings_ShowAlternative { get; set; }
        #endregion
        
        #region Parameter Settings_ShowSpeakerLabel
        /// <summary>
        /// <para>
        /// <para>Enables speaker partitioning (diarization) in your transcription output. Speaker partitioning
        /// labels the speech from individual speakers in your media file.</para><para>If you enable <c>ShowSpeakerLabels</c> in your request, you must also include <c>MaxSpeakerLabels</c>.</para><para>For more information, see <a href="https://docs.aws.amazon.com/transcribe/latest/dg/diarization.html">Partitioning
        /// speakers (diarization)</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_ShowSpeakerLabels")]
        public System.Boolean? Settings_ShowSpeakerLabel { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Adds one or more custom tags, each in the form of a key:value pair, to a new transcription
        /// job at the time you start this new job.</para><para>To learn more about using tags with Amazon Transcribe, refer to <a href="https://docs.aws.amazon.com/transcribe/latest/dg/tagging.html">Tagging
        /// resources</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.TranscribeService.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ToxicityDetection
        /// <summary>
        /// <para>
        /// <para>Enables toxic speech detection in your transcript. If you include <c>ToxicityDetection</c>
        /// in your request, you must also include <c>ToxicityCategories</c>.</para><para>For information on the types of toxic speech Amazon Transcribe can detect, see <a href="https://docs.aws.amazon.com/transcribe/latest/dg/toxic-language.html">Detecting
        /// toxic speech</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.TranscribeService.Model.ToxicityDetectionSettings[] ToxicityDetection { get; set; }
        #endregion
        
        #region Parameter TranscriptionJobName
        /// <summary>
        /// <para>
        /// <para>A unique name, chosen by you, for your transcription job. The name that you specify
        /// is also used as the default name of your transcription output file. If you want to
        /// specify a different name for your transcription output, use the <c>OutputKey</c> parameter.</para><para>This name is case sensitive, cannot contain spaces, and must be unique within an Amazon
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
        public System.String TranscriptionJobName { get; set; }
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
        /// <para>The name of the custom vocabulary filter you want to use in your transcription job
        /// request. This name is case sensitive, cannot contain spaces, and must be unique within
        /// an Amazon Web Services account.</para><para>Note that if you include <c>VocabularyFilterName</c> in your request, you must also
        /// include <c>VocabularyFilterMethod</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Settings_VocabularyFilterName { get; set; }
        #endregion
        
        #region Parameter Settings_VocabularyName
        /// <summary>
        /// <para>
        /// <para>The name of the custom vocabulary you want to use in your transcription job request.
        /// This name is case sensitive, cannot contain spaces, and must be unique within an Amazon
        /// Web Services account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Settings_VocabularyName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TranscriptionJob'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TranscribeService.Model.StartTranscriptionJobResponse).
        /// Specifying the name of a property of type Amazon.TranscribeService.Model.StartTranscriptionJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TranscriptionJob";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TranscriptionJobName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-TRSTranscriptionJob (StartTranscriptionJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.TranscribeService.Model.StartTranscriptionJobResponse, StartTRSTranscriptionJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ContentRedaction_PiiEntityType != null)
            {
                context.ContentRedaction_PiiEntityType = new List<System.String>(this.ContentRedaction_PiiEntityType);
            }
            context.ContentRedaction_RedactionOutput = this.ContentRedaction_RedactionOutput;
            context.ContentRedaction_RedactionType = this.ContentRedaction_RedactionType;
            context.IdentifyLanguage = this.IdentifyLanguage;
            context.IdentifyMultipleLanguage = this.IdentifyMultipleLanguage;
            context.JobExecutionSettings_AllowDeferredExecution = this.JobExecutionSettings_AllowDeferredExecution;
            context.JobExecutionSettings_DataAccessRoleArn = this.JobExecutionSettings_DataAccessRoleArn;
            if (this.KMSEncryptionContext != null)
            {
                context.KMSEncryptionContext = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.KMSEncryptionContext.Keys)
                {
                    context.KMSEncryptionContext.Add((String)hashKey, (System.String)(this.KMSEncryptionContext[hashKey]));
                }
            }
            context.LanguageCode = this.LanguageCode;
            if (this.LanguageIdSetting != null)
            {
                context.LanguageIdSetting = new Dictionary<System.String, Amazon.TranscribeService.Model.LanguageIdSettings>(StringComparer.Ordinal);
                foreach (var hashKey in this.LanguageIdSetting.Keys)
                {
                    context.LanguageIdSetting.Add((String)hashKey, (Amazon.TranscribeService.Model.LanguageIdSettings)(this.LanguageIdSetting[hashKey]));
                }
            }
            if (this.LanguageOption != null)
            {
                context.LanguageOption = new List<System.String>(this.LanguageOption);
            }
            context.Media_MediaFileUri = this.Media_MediaFileUri;
            context.Media_RedactedMediaFileUri = this.Media_RedactedMediaFileUri;
            context.MediaFormat = this.MediaFormat;
            context.MediaSampleRateHertz = this.MediaSampleRateHertz;
            context.ModelSettings_LanguageModelName = this.ModelSettings_LanguageModelName;
            context.OutputBucketName = this.OutputBucketName;
            context.OutputEncryptionKMSKeyId = this.OutputEncryptionKMSKeyId;
            context.OutputKey = this.OutputKey;
            context.Settings_ChannelIdentification = this.Settings_ChannelIdentification;
            context.Settings_MaxAlternative = this.Settings_MaxAlternative;
            context.Settings_MaxSpeakerLabel = this.Settings_MaxSpeakerLabel;
            context.Settings_ShowAlternative = this.Settings_ShowAlternative;
            context.Settings_ShowSpeakerLabel = this.Settings_ShowSpeakerLabel;
            context.Settings_VocabularyFilterMethod = this.Settings_VocabularyFilterMethod;
            context.Settings_VocabularyFilterName = this.Settings_VocabularyFilterName;
            context.Settings_VocabularyName = this.Settings_VocabularyName;
            if (this.Subtitles_Format != null)
            {
                context.Subtitles_Format = new List<System.String>(this.Subtitles_Format);
            }
            context.Subtitles_OutputStartIndex = this.Subtitles_OutputStartIndex;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.TranscribeService.Model.Tag>(this.Tag);
            }
            if (this.ToxicityDetection != null)
            {
                context.ToxicityDetection = new List<Amazon.TranscribeService.Model.ToxicityDetectionSettings>(this.ToxicityDetection);
            }
            context.TranscriptionJobName = this.TranscriptionJobName;
            #if MODULAR
            if (this.TranscriptionJobName == null && ParameterWasBound(nameof(this.TranscriptionJobName)))
            {
                WriteWarning("You are passing $null as a value for parameter TranscriptionJobName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.TranscribeService.Model.StartTranscriptionJobRequest();
            
            
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
            if (cmdletContext.IdentifyLanguage != null)
            {
                request.IdentifyLanguage = cmdletContext.IdentifyLanguage.Value;
            }
            if (cmdletContext.IdentifyMultipleLanguage != null)
            {
                request.IdentifyMultipleLanguages = cmdletContext.IdentifyMultipleLanguage.Value;
            }
            
             // populate JobExecutionSettings
            var requestJobExecutionSettingsIsNull = true;
            request.JobExecutionSettings = new Amazon.TranscribeService.Model.JobExecutionSettings();
            System.Boolean? requestJobExecutionSettings_jobExecutionSettings_AllowDeferredExecution = null;
            if (cmdletContext.JobExecutionSettings_AllowDeferredExecution != null)
            {
                requestJobExecutionSettings_jobExecutionSettings_AllowDeferredExecution = cmdletContext.JobExecutionSettings_AllowDeferredExecution.Value;
            }
            if (requestJobExecutionSettings_jobExecutionSettings_AllowDeferredExecution != null)
            {
                request.JobExecutionSettings.AllowDeferredExecution = requestJobExecutionSettings_jobExecutionSettings_AllowDeferredExecution.Value;
                requestJobExecutionSettingsIsNull = false;
            }
            System.String requestJobExecutionSettings_jobExecutionSettings_DataAccessRoleArn = null;
            if (cmdletContext.JobExecutionSettings_DataAccessRoleArn != null)
            {
                requestJobExecutionSettings_jobExecutionSettings_DataAccessRoleArn = cmdletContext.JobExecutionSettings_DataAccessRoleArn;
            }
            if (requestJobExecutionSettings_jobExecutionSettings_DataAccessRoleArn != null)
            {
                request.JobExecutionSettings.DataAccessRoleArn = requestJobExecutionSettings_jobExecutionSettings_DataAccessRoleArn;
                requestJobExecutionSettingsIsNull = false;
            }
             // determine if request.JobExecutionSettings should be set to null
            if (requestJobExecutionSettingsIsNull)
            {
                request.JobExecutionSettings = null;
            }
            if (cmdletContext.KMSEncryptionContext != null)
            {
                request.KMSEncryptionContext = cmdletContext.KMSEncryptionContext;
            }
            if (cmdletContext.LanguageCode != null)
            {
                request.LanguageCode = cmdletContext.LanguageCode;
            }
            if (cmdletContext.LanguageIdSetting != null)
            {
                request.LanguageIdSettings = cmdletContext.LanguageIdSetting;
            }
            if (cmdletContext.LanguageOption != null)
            {
                request.LanguageOptions = cmdletContext.LanguageOption;
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
            if (cmdletContext.MediaFormat != null)
            {
                request.MediaFormat = cmdletContext.MediaFormat;
            }
            if (cmdletContext.MediaSampleRateHertz != null)
            {
                request.MediaSampleRateHertz = cmdletContext.MediaSampleRateHertz.Value;
            }
            
             // populate ModelSettings
            var requestModelSettingsIsNull = true;
            request.ModelSettings = new Amazon.TranscribeService.Model.ModelSettings();
            System.String requestModelSettings_modelSettings_LanguageModelName = null;
            if (cmdletContext.ModelSettings_LanguageModelName != null)
            {
                requestModelSettings_modelSettings_LanguageModelName = cmdletContext.ModelSettings_LanguageModelName;
            }
            if (requestModelSettings_modelSettings_LanguageModelName != null)
            {
                request.ModelSettings.LanguageModelName = requestModelSettings_modelSettings_LanguageModelName;
                requestModelSettingsIsNull = false;
            }
             // determine if request.ModelSettings should be set to null
            if (requestModelSettingsIsNull)
            {
                request.ModelSettings = null;
            }
            if (cmdletContext.OutputBucketName != null)
            {
                request.OutputBucketName = cmdletContext.OutputBucketName;
            }
            if (cmdletContext.OutputEncryptionKMSKeyId != null)
            {
                request.OutputEncryptionKMSKeyId = cmdletContext.OutputEncryptionKMSKeyId;
            }
            if (cmdletContext.OutputKey != null)
            {
                request.OutputKey = cmdletContext.OutputKey;
            }
            
             // populate Settings
            var requestSettingsIsNull = true;
            request.Settings = new Amazon.TranscribeService.Model.Settings();
            System.Boolean? requestSettings_settings_ChannelIdentification = null;
            if (cmdletContext.Settings_ChannelIdentification != null)
            {
                requestSettings_settings_ChannelIdentification = cmdletContext.Settings_ChannelIdentification.Value;
            }
            if (requestSettings_settings_ChannelIdentification != null)
            {
                request.Settings.ChannelIdentification = requestSettings_settings_ChannelIdentification.Value;
                requestSettingsIsNull = false;
            }
            System.Int32? requestSettings_settings_MaxAlternative = null;
            if (cmdletContext.Settings_MaxAlternative != null)
            {
                requestSettings_settings_MaxAlternative = cmdletContext.Settings_MaxAlternative.Value;
            }
            if (requestSettings_settings_MaxAlternative != null)
            {
                request.Settings.MaxAlternatives = requestSettings_settings_MaxAlternative.Value;
                requestSettingsIsNull = false;
            }
            System.Int32? requestSettings_settings_MaxSpeakerLabel = null;
            if (cmdletContext.Settings_MaxSpeakerLabel != null)
            {
                requestSettings_settings_MaxSpeakerLabel = cmdletContext.Settings_MaxSpeakerLabel.Value;
            }
            if (requestSettings_settings_MaxSpeakerLabel != null)
            {
                request.Settings.MaxSpeakerLabels = requestSettings_settings_MaxSpeakerLabel.Value;
                requestSettingsIsNull = false;
            }
            System.Boolean? requestSettings_settings_ShowAlternative = null;
            if (cmdletContext.Settings_ShowAlternative != null)
            {
                requestSettings_settings_ShowAlternative = cmdletContext.Settings_ShowAlternative.Value;
            }
            if (requestSettings_settings_ShowAlternative != null)
            {
                request.Settings.ShowAlternatives = requestSettings_settings_ShowAlternative.Value;
                requestSettingsIsNull = false;
            }
            System.Boolean? requestSettings_settings_ShowSpeakerLabel = null;
            if (cmdletContext.Settings_ShowSpeakerLabel != null)
            {
                requestSettings_settings_ShowSpeakerLabel = cmdletContext.Settings_ShowSpeakerLabel.Value;
            }
            if (requestSettings_settings_ShowSpeakerLabel != null)
            {
                request.Settings.ShowSpeakerLabels = requestSettings_settings_ShowSpeakerLabel.Value;
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
             // determine if request.Settings should be set to null
            if (requestSettingsIsNull)
            {
                request.Settings = null;
            }
            
             // populate Subtitles
            var requestSubtitlesIsNull = true;
            request.Subtitles = new Amazon.TranscribeService.Model.Subtitles();
            List<System.String> requestSubtitles_subtitles_Format = null;
            if (cmdletContext.Subtitles_Format != null)
            {
                requestSubtitles_subtitles_Format = cmdletContext.Subtitles_Format;
            }
            if (requestSubtitles_subtitles_Format != null)
            {
                request.Subtitles.Formats = requestSubtitles_subtitles_Format;
                requestSubtitlesIsNull = false;
            }
            System.Int32? requestSubtitles_subtitles_OutputStartIndex = null;
            if (cmdletContext.Subtitles_OutputStartIndex != null)
            {
                requestSubtitles_subtitles_OutputStartIndex = cmdletContext.Subtitles_OutputStartIndex.Value;
            }
            if (requestSubtitles_subtitles_OutputStartIndex != null)
            {
                request.Subtitles.OutputStartIndex = requestSubtitles_subtitles_OutputStartIndex.Value;
                requestSubtitlesIsNull = false;
            }
             // determine if request.Subtitles should be set to null
            if (requestSubtitlesIsNull)
            {
                request.Subtitles = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.ToxicityDetection != null)
            {
                request.ToxicityDetection = cmdletContext.ToxicityDetection;
            }
            if (cmdletContext.TranscriptionJobName != null)
            {
                request.TranscriptionJobName = cmdletContext.TranscriptionJobName;
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
        
        private Amazon.TranscribeService.Model.StartTranscriptionJobResponse CallAWSServiceOperation(IAmazonTranscribeService client, Amazon.TranscribeService.Model.StartTranscriptionJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Transcribe Service", "StartTranscriptionJob");
            try
            {
                #if DESKTOP
                return client.StartTranscriptionJob(request);
                #elif CORECLR
                return client.StartTranscriptionJobAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ContentRedaction_PiiEntityType { get; set; }
            public Amazon.TranscribeService.RedactionOutput ContentRedaction_RedactionOutput { get; set; }
            public Amazon.TranscribeService.RedactionType ContentRedaction_RedactionType { get; set; }
            public System.Boolean? IdentifyLanguage { get; set; }
            public System.Boolean? IdentifyMultipleLanguage { get; set; }
            public System.Boolean? JobExecutionSettings_AllowDeferredExecution { get; set; }
            public System.String JobExecutionSettings_DataAccessRoleArn { get; set; }
            public Dictionary<System.String, System.String> KMSEncryptionContext { get; set; }
            public Amazon.TranscribeService.LanguageCode LanguageCode { get; set; }
            public Dictionary<System.String, Amazon.TranscribeService.Model.LanguageIdSettings> LanguageIdSetting { get; set; }
            public List<System.String> LanguageOption { get; set; }
            public System.String Media_MediaFileUri { get; set; }
            public System.String Media_RedactedMediaFileUri { get; set; }
            public Amazon.TranscribeService.MediaFormat MediaFormat { get; set; }
            public System.Int32? MediaSampleRateHertz { get; set; }
            public System.String ModelSettings_LanguageModelName { get; set; }
            public System.String OutputBucketName { get; set; }
            public System.String OutputEncryptionKMSKeyId { get; set; }
            public System.String OutputKey { get; set; }
            public System.Boolean? Settings_ChannelIdentification { get; set; }
            public System.Int32? Settings_MaxAlternative { get; set; }
            public System.Int32? Settings_MaxSpeakerLabel { get; set; }
            public System.Boolean? Settings_ShowAlternative { get; set; }
            public System.Boolean? Settings_ShowSpeakerLabel { get; set; }
            public Amazon.TranscribeService.VocabularyFilterMethod Settings_VocabularyFilterMethod { get; set; }
            public System.String Settings_VocabularyFilterName { get; set; }
            public System.String Settings_VocabularyName { get; set; }
            public List<System.String> Subtitles_Format { get; set; }
            public System.Int32? Subtitles_OutputStartIndex { get; set; }
            public List<Amazon.TranscribeService.Model.Tag> Tag { get; set; }
            public List<Amazon.TranscribeService.Model.ToxicityDetectionSettings> ToxicityDetection { get; set; }
            public System.String TranscriptionJobName { get; set; }
            public System.Func<Amazon.TranscribeService.Model.StartTranscriptionJobResponse, StartTRSTranscriptionJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TranscriptionJob;
        }
        
    }
}
