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
    /// Transcribes the audio from a medical dictation or conversation and applies any additional
    /// Request Parameters you choose to include in your request.
    /// 
    ///  
    /// <para>
    /// In addition to many standard transcription features, Amazon Transcribe Medical provides
    /// you with a robust medical vocabulary and, optionally, content identification, which
    /// adds flags to personal health information (PHI). To learn more about these features,
    /// refer to <a href="https://docs.aws.amazon.com/transcribe/latest/dg/how-it-works-med.html">How
    /// Amazon Transcribe Medical works</a>.
    /// </para><para>
    /// To make a <c>StartMedicalTranscriptionJob</c> request, you must first upload your
    /// media file into an Amazon S3 bucket; you can then specify the Amazon S3 location of
    /// the file using the <c>Media</c> parameter.
    /// </para><para>
    /// You must include the following parameters in your <c>StartMedicalTranscriptionJob</c>
    /// request:
    /// </para><ul><li><para><c>region</c>: The Amazon Web Services Region where you are making your request.
    /// For a list of Amazon Web Services Regions supported with Amazon Transcribe, refer
    /// to <a href="https://docs.aws.amazon.com/general/latest/gr/transcribe.html">Amazon
    /// Transcribe endpoints and quotas</a>.
    /// </para></li><li><para><c>MedicalTranscriptionJobName</c>: A custom name you create for your transcription
    /// job that is unique within your Amazon Web Services account.
    /// </para></li><li><para><c>Media</c> (<c>MediaFileUri</c>): The Amazon S3 location of your media file.
    /// </para></li><li><para><c>LanguageCode</c>: This must be <c>en-US</c>.
    /// </para></li><li><para><c>OutputBucketName</c>: The Amazon S3 bucket where you want your transcript stored.
    /// If you want your output stored in a sub-folder of this bucket, you must also include
    /// <c>OutputKey</c>.
    /// </para></li><li><para><c>Specialty</c>: This must be <c>PRIMARYCARE</c>.
    /// </para></li><li><para><c>Type</c>: Choose whether your audio is a conversation or a dictation.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Start", "TRSMedicalTranscriptionJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.TranscribeService.Model.MedicalTranscriptionJob")]
    [AWSCmdlet("Calls the Amazon Transcribe Service StartMedicalTranscriptionJob API operation.", Operation = new[] {"StartMedicalTranscriptionJob"}, SelectReturnType = typeof(Amazon.TranscribeService.Model.StartMedicalTranscriptionJobResponse))]
    [AWSCmdletOutput("Amazon.TranscribeService.Model.MedicalTranscriptionJob or Amazon.TranscribeService.Model.StartMedicalTranscriptionJobResponse",
        "This cmdlet returns an Amazon.TranscribeService.Model.MedicalTranscriptionJob object.",
        "The service call response (type Amazon.TranscribeService.Model.StartMedicalTranscriptionJobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartTRSMedicalTranscriptionJobCmdlet : AmazonTranscribeServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Settings_ChannelIdentification
        /// <summary>
        /// <para>
        /// <para>Enables channel identification in multi-channel audio.</para><para>Channel identification transcribes the audio on each channel independently, then appends
        /// the output for each channel into one transcript.</para><para>If you have multi-channel audio and do not enable channel identification, your audio
        /// is transcribed in a continuous manner and your transcript does not separate the speech
        /// by channel.</para><para>For more information, see <a href="https://docs.aws.amazon.com/transcribe/latest/dg/channel-id.html">Transcribing
        /// multi-channel audio</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Settings_ChannelIdentification { get; set; }
        #endregion
        
        #region Parameter ContentIdentificationType
        /// <summary>
        /// <para>
        /// <para>Labels all personal health information (PHI) identified in your transcript. For more
        /// information, see <a href="https://docs.aws.amazon.com/transcribe/latest/dg/phi-id.html">Identifying
        /// personal health information (PHI) in a transcription</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.TranscribeService.MedicalContentIdentificationType")]
        public Amazon.TranscribeService.MedicalContentIdentificationType ContentIdentificationType { get; set; }
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
        /// <para>The language code that represents the language spoken in the input media file. US
        /// English (<c>en-US</c>) is the only valid value for medical transcription jobs. Any
        /// other value you enter for language code results in a <c>BadRequestException</c> error.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.TranscribeService.LanguageCode")]
        public Amazon.TranscribeService.LanguageCode LanguageCode { get; set; }
        #endregion
        
        #region Parameter Settings_MaxAlternative
        /// <summary>
        /// <para>
        /// <para>Indicate the maximum number of alternative transcriptions you want Amazon Transcribe
        /// Medical to include in your transcript.</para><para>If you select a number greater than the number of alternative transcriptions generated
        /// by Amazon Transcribe Medical, only the actual number of alternative transcriptions
        /// are included.</para><para>If you include <c>MaxAlternatives</c> in your request, you must also include <c>ShowAlternatives</c>
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
        /// <para>The sample rate, in hertz, of the audio track in your input media file.</para><para>If you do not specify the media sample rate, Amazon Transcribe Medical determines
        /// it for you. If you specify the sample rate, it must match the rate detected by Amazon
        /// Transcribe Medical; if there's a mismatch between the value that you specify and the
        /// value detected, your job fails. Therefore, in most cases, it's advised to omit <c>MediaSampleRateHertz</c>
        /// and let Amazon Transcribe Medical determine the sample rate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MediaSampleRateHertz { get; set; }
        #endregion
        
        #region Parameter MedicalTranscriptionJobName
        /// <summary>
        /// <para>
        /// <para>A unique name, chosen by you, for your medical transcription job. The name that you
        /// specify is also used as the default name of your transcription output file. If you
        /// want to specify a different name for your transcription output, use the <c>OutputKey</c>
        /// parameter.</para><para>This name is case sensitive, cannot contain spaces, and must be unique within an Amazon
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
        public System.String MedicalTranscriptionJobName { get; set; }
        #endregion
        
        #region Parameter OutputBucketName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon S3 bucket where you want your medical transcription output
        /// stored. Do not include the <c>S3://</c> prefix of the specified bucket.</para><para>If you want your output to go to a sub-folder of this bucket, specify it using the
        /// <c>OutputKey</c> parameter; <c>OutputBucketName</c> only accepts the name of a bucket.</para><para>For example, if you want your output stored in <c>S3://DOC-EXAMPLE-BUCKET</c>, set
        /// <c>OutputBucketName</c> to <c>DOC-EXAMPLE-BUCKET</c>. However, if you want your output
        /// stored in <c>S3://DOC-EXAMPLE-BUCKET/test-files/</c>, set <c>OutputBucketName</c>
        /// to <c>DOC-EXAMPLE-BUCKET</c> and <c>OutputKey</c> to <c>test-files/</c>.</para><para>Note that Amazon Transcribe must have permission to use the specified location. You
        /// can change Amazon S3 permissions using the <a href="https://console.aws.amazon.com/s3">Amazon
        /// Web Services Management Console</a>. See also <a href="https://docs.aws.amazon.com/transcribe/latest/dg/security_iam_id-based-policy-examples.html#auth-role-iam-user">Permissions
        /// Required for IAM User Roles</a>.</para>
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
        public System.String OutputBucketName { get; set; }
        #endregion
        
        #region Parameter OutputEncryptionKMSKeyId
        /// <summary>
        /// <para>
        /// <para>The KMS key you want to use to encrypt your medical transcription output.</para><para>If using a key located in the <b>current</b> Amazon Web Services account, you can
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
        /// for your transcription output is the same as the name you specified for your medical
        /// transcription job (<c>MedicalTranscriptionJobName</c>).</para><para>Here are some examples of how you can use <c>OutputKey</c>:</para><ul><li><para>If you specify 'DOC-EXAMPLE-BUCKET' as the <c>OutputBucketName</c> and 'my-transcript.json'
        /// as the <c>OutputKey</c>, your transcription output path is <c>s3://DOC-EXAMPLE-BUCKET/my-transcript.json</c>.</para></li><li><para>If you specify 'my-first-transcription' as the <c>MedicalTranscriptionJobName</c>,
        /// 'DOC-EXAMPLE-BUCKET' as the <c>OutputBucketName</c>, and 'my-transcript' as the <c>OutputKey</c>,
        /// your transcription output path is <c>s3://DOC-EXAMPLE-BUCKET/my-transcript/my-first-transcription.json</c>.</para></li><li><para>If you specify 'DOC-EXAMPLE-BUCKET' as the <c>OutputBucketName</c> and 'test-files/my-transcript.json'
        /// as the <c>OutputKey</c>, your transcription output path is <c>s3://DOC-EXAMPLE-BUCKET/test-files/my-transcript.json</c>.</para></li><li><para>If you specify 'my-first-transcription' as the <c>MedicalTranscriptionJobName</c>,
        /// 'DOC-EXAMPLE-BUCKET' as the <c>OutputBucketName</c>, and 'test-files/my-transcript'
        /// as the <c>OutputKey</c>, your transcription output path is <c>s3://DOC-EXAMPLE-BUCKET/test-files/my-transcript/my-first-transcription.json</c>.</para></li></ul><para>If you specify the name of an Amazon S3 bucket sub-folder that doesn't exist, one
        /// is created for you.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputKey { get; set; }
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
        
        #region Parameter Settings_ShowAlternative
        /// <summary>
        /// <para>
        /// <para>To include alternative transcriptions within your transcription output, include <c>ShowAlternatives</c>
        /// in your transcription request.</para><para>If you include <c>ShowAlternatives</c>, you must also include <c>MaxAlternatives</c>,
        /// which is the maximum number of alternative transcriptions you want Amazon Transcribe
        /// Medical to generate.</para><para>For more information, see <a href="https://docs.aws.amazon.com/transcribe/latest/dg/how-alternatives.html">Alternative
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
        
        #region Parameter Specialty
        /// <summary>
        /// <para>
        /// <para>Specify the predominant medical specialty represented in your media. For batch transcriptions,
        /// <c>PRIMARYCARE</c> is the only valid value. If you require additional specialties,
        /// refer to .</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.TranscribeService.Specialty")]
        public Amazon.TranscribeService.Specialty Specialty { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Adds one or more custom tags, each in the form of a key:value pair, to a new medical
        /// transcription job at the time you start this new job.</para><para>To learn more about using tags with Amazon Transcribe, refer to <a href="https://docs.aws.amazon.com/transcribe/latest/dg/tagging.html">Tagging
        /// resources</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.TranscribeService.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>Specify whether your input media contains only one person (<c>DICTATION</c>) or contains
        /// a conversation between two people (<c>CONVERSATION</c>).</para><para>For example, <c>DICTATION</c> could be used for a medical professional wanting to
        /// transcribe voice memos; <c>CONVERSATION</c> could be used for transcribing the doctor-patient
        /// dialogue during the patient's office visit.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.TranscribeService.Type")]
        public Amazon.TranscribeService.Type Type { get; set; }
        #endregion
        
        #region Parameter Settings_VocabularyName
        /// <summary>
        /// <para>
        /// <para>The name of the custom vocabulary you want to use when processing your medical transcription
        /// job. Custom vocabulary names are case sensitive.</para><para>The language of the specified custom vocabulary must match the language code that
        /// you specify in your transcription request. If the languages do not match, the custom
        /// vocabulary isn't applied. There are no errors or warnings associated with a language
        /// mismatch. US English (<c>en-US</c>) is the only valid language for Amazon Transcribe
        /// Medical.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Settings_VocabularyName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MedicalTranscriptionJob'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TranscribeService.Model.StartMedicalTranscriptionJobResponse).
        /// Specifying the name of a property of type Amazon.TranscribeService.Model.StartMedicalTranscriptionJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MedicalTranscriptionJob";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-TRSMedicalTranscriptionJob (StartMedicalTranscriptionJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.TranscribeService.Model.StartMedicalTranscriptionJobResponse, StartTRSMedicalTranscriptionJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ContentIdentificationType = this.ContentIdentificationType;
            if (this.KMSEncryptionContext != null)
            {
                context.KMSEncryptionContext = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.KMSEncryptionContext.Keys)
                {
                    context.KMSEncryptionContext.Add((String)hashKey, (System.String)(this.KMSEncryptionContext[hashKey]));
                }
            }
            context.LanguageCode = this.LanguageCode;
            #if MODULAR
            if (this.LanguageCode == null && ParameterWasBound(nameof(this.LanguageCode)))
            {
                WriteWarning("You are passing $null as a value for parameter LanguageCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Media_MediaFileUri = this.Media_MediaFileUri;
            context.Media_RedactedMediaFileUri = this.Media_RedactedMediaFileUri;
            context.MediaFormat = this.MediaFormat;
            context.MediaSampleRateHertz = this.MediaSampleRateHertz;
            context.MedicalTranscriptionJobName = this.MedicalTranscriptionJobName;
            #if MODULAR
            if (this.MedicalTranscriptionJobName == null && ParameterWasBound(nameof(this.MedicalTranscriptionJobName)))
            {
                WriteWarning("You are passing $null as a value for parameter MedicalTranscriptionJobName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutputBucketName = this.OutputBucketName;
            #if MODULAR
            if (this.OutputBucketName == null && ParameterWasBound(nameof(this.OutputBucketName)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputBucketName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutputEncryptionKMSKeyId = this.OutputEncryptionKMSKeyId;
            context.OutputKey = this.OutputKey;
            context.Settings_ChannelIdentification = this.Settings_ChannelIdentification;
            context.Settings_MaxAlternative = this.Settings_MaxAlternative;
            context.Settings_MaxSpeakerLabel = this.Settings_MaxSpeakerLabel;
            context.Settings_ShowAlternative = this.Settings_ShowAlternative;
            context.Settings_ShowSpeakerLabel = this.Settings_ShowSpeakerLabel;
            context.Settings_VocabularyName = this.Settings_VocabularyName;
            context.Specialty = this.Specialty;
            #if MODULAR
            if (this.Specialty == null && ParameterWasBound(nameof(this.Specialty)))
            {
                WriteWarning("You are passing $null as a value for parameter Specialty which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.TranscribeService.Model.Tag>(this.Tag);
            }
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.TranscribeService.Model.StartMedicalTranscriptionJobRequest();
            
            if (cmdletContext.ContentIdentificationType != null)
            {
                request.ContentIdentificationType = cmdletContext.ContentIdentificationType;
            }
            if (cmdletContext.KMSEncryptionContext != null)
            {
                request.KMSEncryptionContext = cmdletContext.KMSEncryptionContext;
            }
            if (cmdletContext.LanguageCode != null)
            {
                request.LanguageCode = cmdletContext.LanguageCode;
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
            if (cmdletContext.MedicalTranscriptionJobName != null)
            {
                request.MedicalTranscriptionJobName = cmdletContext.MedicalTranscriptionJobName;
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
            request.Settings = new Amazon.TranscribeService.Model.MedicalTranscriptionSetting();
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
            if (cmdletContext.Specialty != null)
            {
                request.Specialty = cmdletContext.Specialty;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.TranscribeService.Model.StartMedicalTranscriptionJobResponse CallAWSServiceOperation(IAmazonTranscribeService client, Amazon.TranscribeService.Model.StartMedicalTranscriptionJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Transcribe Service", "StartMedicalTranscriptionJob");
            try
            {
                return client.StartMedicalTranscriptionJobAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.TranscribeService.MedicalContentIdentificationType ContentIdentificationType { get; set; }
            public Dictionary<System.String, System.String> KMSEncryptionContext { get; set; }
            public Amazon.TranscribeService.LanguageCode LanguageCode { get; set; }
            public System.String Media_MediaFileUri { get; set; }
            public System.String Media_RedactedMediaFileUri { get; set; }
            public Amazon.TranscribeService.MediaFormat MediaFormat { get; set; }
            public System.Int32? MediaSampleRateHertz { get; set; }
            public System.String MedicalTranscriptionJobName { get; set; }
            public System.String OutputBucketName { get; set; }
            public System.String OutputEncryptionKMSKeyId { get; set; }
            public System.String OutputKey { get; set; }
            public System.Boolean? Settings_ChannelIdentification { get; set; }
            public System.Int32? Settings_MaxAlternative { get; set; }
            public System.Int32? Settings_MaxSpeakerLabel { get; set; }
            public System.Boolean? Settings_ShowAlternative { get; set; }
            public System.Boolean? Settings_ShowSpeakerLabel { get; set; }
            public System.String Settings_VocabularyName { get; set; }
            public Amazon.TranscribeService.Specialty Specialty { get; set; }
            public List<Amazon.TranscribeService.Model.Tag> Tag { get; set; }
            public Amazon.TranscribeService.Type Type { get; set; }
            public System.Func<Amazon.TranscribeService.Model.StartMedicalTranscriptionJobResponse, StartTRSMedicalTranscriptionJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MedicalTranscriptionJob;
        }
        
    }
}
