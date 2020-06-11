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
    /// Starts an asynchronous job to transcribe speech to text.
    /// </summary>
    [Cmdlet("Start", "TRSTranscriptionJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.TranscribeService.Model.TranscriptionJob")]
    [AWSCmdlet("Calls the Amazon Transcribe Service StartTranscriptionJob API operation.", Operation = new[] {"StartTranscriptionJob"}, SelectReturnType = typeof(Amazon.TranscribeService.Model.StartTranscriptionJobResponse))]
    [AWSCmdletOutput("Amazon.TranscribeService.Model.TranscriptionJob or Amazon.TranscribeService.Model.StartTranscriptionJobResponse",
        "This cmdlet returns an Amazon.TranscribeService.Model.TranscriptionJob object.",
        "The service call response (type Amazon.TranscribeService.Model.StartTranscriptionJobResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartTRSTranscriptionJobCmdlet : AmazonTranscribeServiceClientCmdlet, IExecutor
    {
        
        #region Parameter JobExecutionSettings_AllowDeferredExecution
        /// <summary>
        /// <para>
        /// <para>Indicates whether a job should be queued by Amazon Transcribe when the concurrent
        /// execution limit is exceeded. When the <code>AllowDeferredExecution</code> field is
        /// true, jobs are queued and executed when the number of executing jobs falls below the
        /// concurrent execution limit. If the field is false, Amazon Transcribe returns a <code>LimitExceededException</code>
        /// exception.</para><para>If you specify the <code>AllowDeferredExecution</code> field, you must specify the
        /// <code>DataAccessRoleArn</code> field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? JobExecutionSettings_AllowDeferredExecution { get; set; }
        #endregion
        
        #region Parameter Settings_ChannelIdentification
        /// <summary>
        /// <para>
        /// <para>Instructs Amazon Transcribe to process each audio channel separately and then merge
        /// the transcription output of each channel into a single transcription. </para><para>Amazon Transcribe also produces a transcription of each item detected on an audio
        /// channel, including the start time and end time of the item and alternative transcriptions
        /// of the item including the confidence that Amazon Transcribe has in the transcription.</para><para>You can't set both <code>ShowSpeakerLabels</code> and <code>ChannelIdentification</code>
        /// in the same request. If you set both, your request returns a <code>BadRequestException</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Settings_ChannelIdentification { get; set; }
        #endregion
        
        #region Parameter JobExecutionSettings_DataAccessRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a role that has access to the S3 bucket that contains
        /// the input files. Amazon Transcribe assumes this role to read queued media files. If
        /// you have specified an output S3 bucket for the transcription results, this role should
        /// have access to the output bucket as well.</para><para>If you specify the <code>AllowDeferredExecution</code> field, you must specify the
        /// <code>DataAccessRoleArn</code> field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String JobExecutionSettings_DataAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter LanguageCode
        /// <summary>
        /// <para>
        /// <para>The language code for the language used in the input media file.</para>
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
        
        #region Parameter ModelSettings_LanguageModelName
        /// <summary>
        /// <para>
        /// <para>The name of your custom language model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ModelSettings_LanguageModelName { get; set; }
        #endregion
        
        #region Parameter Settings_MaxAlternative
        /// <summary>
        /// <para>
        /// <para>The number of alternative transcriptions that the service should return. If you specify
        /// the <code>MaxAlternatives</code> field, you must set the <code>ShowAlternatives</code>
        /// field to true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_MaxAlternatives")]
        public System.Int32? Settings_MaxAlternative { get; set; }
        #endregion
        
        #region Parameter Settings_MaxSpeakerLabel
        /// <summary>
        /// <para>
        /// <para>The maximum number of speakers to identify in the input audio. If there are more speakers
        /// in the audio than this number, multiple speakers are identified as a single speaker.
        /// If you specify the <code>MaxSpeakerLabels</code> field, you must set the <code>ShowSpeakerLabels</code>
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
        /// <para>The S3 object location of the input media file. The URI must be in the same region
        /// as the API endpoint that you are calling. The general form is:</para><para>For example:</para><para>For more information about S3 object names, see <a href="http://docs.aws.amazon.com/AmazonS3/latest/dev/UsingMetadata.html#object-keys">Object
        /// Keys</a> in the <i>Amazon S3 Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Media_MediaFileUri { get; set; }
        #endregion
        
        #region Parameter MediaFormat
        /// <summary>
        /// <para>
        /// <para>The format of the input media file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.TranscribeService.MediaFormat")]
        public Amazon.TranscribeService.MediaFormat MediaFormat { get; set; }
        #endregion
        
        #region Parameter MediaSampleRateHertz
        /// <summary>
        /// <para>
        /// <para>The sample rate, in Hertz, of the audio track in the input media file. </para><para>If you do not specify the media sample rate, Amazon Transcribe determines the sample
        /// rate. If you specify the sample rate, it must match the sample rate detected by Amazon
        /// Transcribe. In most cases, you should leave the <code>MediaSampleRateHertz</code>
        /// field blank and let Amazon Transcribe determine the sample rate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MediaSampleRateHertz { get; set; }
        #endregion
        
        #region Parameter OutputBucketName
        /// <summary>
        /// <para>
        /// <para>The location where the transcription is stored.</para><para>If you set the <code>OutputBucketName</code>, Amazon Transcribe puts the transcript
        /// in the specified S3 bucket. When you call the <a>GetTranscriptionJob</a> operation,
        /// the operation returns this location in the <code>TranscriptFileUri</code> field. If
        /// you enable content redaction, the redacted transcript appears in <code>RedactedTranscriptFileUri</code>.
        /// If you enable content redaction and choose to output an unredacted transcript, that
        /// transcript's location still appears in the <code>TranscriptFileUri</code>. The S3
        /// bucket must have permissions that allow Amazon Transcribe to put files in the bucket.
        /// For more information, see <a href="https://docs.aws.amazon.com/transcribe/latest/dg/security_iam_id-based-policy-examples.html#auth-role-iam-user">Permissions
        /// Required for IAM User Roles</a>.</para><para>You can specify an AWS Key Management Service (KMS) key to encrypt the output of your
        /// transcription using the <code>OutputEncryptionKMSKeyId</code> parameter. If you don't
        /// specify a KMS key, Amazon Transcribe uses the default Amazon S3 key for server-side
        /// encryption of transcripts that are placed in your S3 bucket.</para><para>If you don't set the <code>OutputBucketName</code>, Amazon Transcribe generates a
        /// pre-signed URL, a shareable URL that provides secure access to your transcription,
        /// and returns it in the <code>TranscriptFileUri</code> field. Use this URL to download
        /// the transcription.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputBucketName { get; set; }
        #endregion
        
        #region Parameter OutputEncryptionKMSKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the AWS Key Management Service (KMS) key used to
        /// encrypt the output of the transcription job. The user calling the <code>StartTranscriptionJob</code>
        /// operation must have permission to use the specified KMS key.</para><para>You can use either of the following to identify a KMS key in the current account:</para><ul><li><para>KMS Key ID: "1234abcd-12ab-34cd-56ef-1234567890ab"</para></li><li><para>KMS Key Alias: "alias/ExampleAlias"</para></li></ul><para>You can use either of the following to identify a KMS key in the current account or
        /// another account:</para><ul><li><para>Amazon Resource Name (ARN) of a KMS Key: "arn:aws:kms:region:account ID:key/1234abcd-12ab-34cd-56ef-1234567890ab"</para></li><li><para>ARN of a KMS Key Alias: "arn:aws:kms:region:account ID:alias/ExampleAlias"</para></li></ul><para>If you don't specify an encryption key, the output of the transcription job is encrypted
        /// with the default Amazon S3 key (SSE-S3). </para><para>If you specify a KMS key to encrypt your output, you must also specify an output location
        /// in the <code>OutputBucketName</code> parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputEncryptionKMSKeyId { get; set; }
        #endregion
        
        #region Parameter ContentRedaction_RedactionOutput
        /// <summary>
        /// <para>
        /// <para>The output transcript file stored in either the default S3 bucket or in a bucket you
        /// specify.</para><para>When you choose <code>redacted</code> Amazon Transcribe outputs only the redacted
        /// transcript.</para><para>When you choose <code>redacted_and_unredacted</code> Amazon Transcribe outputs both
        /// the redacted and unredacted transcripts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.TranscribeService.RedactionOutput")]
        public Amazon.TranscribeService.RedactionOutput ContentRedaction_RedactionOutput { get; set; }
        #endregion
        
        #region Parameter ContentRedaction_RedactionType
        /// <summary>
        /// <para>
        /// <para>Request parameter that defines the entities to be redacted. The only accepted value
        /// is <code>PII</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.TranscribeService.RedactionType")]
        public Amazon.TranscribeService.RedactionType ContentRedaction_RedactionType { get; set; }
        #endregion
        
        #region Parameter Settings_ShowAlternative
        /// <summary>
        /// <para>
        /// <para>Determines whether the transcription contains alternative transcriptions. If you set
        /// the <code>ShowAlternatives</code> field to true, you must also set the maximum number
        /// of alternatives to return in the <code>MaxAlternatives</code> field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_ShowAlternatives")]
        public System.Boolean? Settings_ShowAlternative { get; set; }
        #endregion
        
        #region Parameter Settings_ShowSpeakerLabel
        /// <summary>
        /// <para>
        /// <para>Determines whether the transcription job uses speaker recognition to identify different
        /// speakers in the input audio. Speaker recognition labels individual speakers in the
        /// audio file. If you set the <code>ShowSpeakerLabels</code> field to true, you must
        /// also set the maximum number of speaker labels <code>MaxSpeakerLabels</code> field.</para><para>You can't set both <code>ShowSpeakerLabels</code> and <code>ChannelIdentification</code>
        /// in the same request. If you set both, your request returns a <code>BadRequestException</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_ShowSpeakerLabels")]
        public System.Boolean? Settings_ShowSpeakerLabel { get; set; }
        #endregion
        
        #region Parameter TranscriptionJobName
        /// <summary>
        /// <para>
        /// <para>The name of the job. You can't use the strings "<code>.</code>" or "<code>..</code>"
        /// by themselves as the job name. The name must also be unique within an AWS account.
        /// If you try to create a transcription job with the same name as a previous transcription
        /// job, you get a <code>ConflictException</code> error.</para>
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
        /// <para>Set to <code>mask</code> to remove filtered text from the transcript and replace it
        /// with three asterisks ("***") as placeholder text. Set to <code>remove</code> to remove
        /// filtered text from the transcript without using placeholder text.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.TranscribeService.VocabularyFilterMethod")]
        public Amazon.TranscribeService.VocabularyFilterMethod Settings_VocabularyFilterMethod { get; set; }
        #endregion
        
        #region Parameter Settings_VocabularyFilterName
        /// <summary>
        /// <para>
        /// <para>The name of the vocabulary filter to use when transcribing the audio. The filter that
        /// you specify must have the same language code as the transcription job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Settings_VocabularyFilterName { get; set; }
        #endregion
        
        #region Parameter Settings_VocabularyName
        /// <summary>
        /// <para>
        /// <para>The name of a vocabulary to use when processing the transcription job.</para>
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
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TranscriptionJobName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TranscriptionJobName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TranscriptionJobName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TranscriptionJobName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-TRSTranscriptionJob (StartTranscriptionJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.TranscribeService.Model.StartTranscriptionJobResponse, StartTRSTranscriptionJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TranscriptionJobName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ContentRedaction_RedactionOutput = this.ContentRedaction_RedactionOutput;
            context.ContentRedaction_RedactionType = this.ContentRedaction_RedactionType;
            context.JobExecutionSettings_AllowDeferredExecution = this.JobExecutionSettings_AllowDeferredExecution;
            context.JobExecutionSettings_DataAccessRoleArn = this.JobExecutionSettings_DataAccessRoleArn;
            context.LanguageCode = this.LanguageCode;
            #if MODULAR
            if (this.LanguageCode == null && ParameterWasBound(nameof(this.LanguageCode)))
            {
                WriteWarning("You are passing $null as a value for parameter LanguageCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Media_MediaFileUri = this.Media_MediaFileUri;
            context.MediaFormat = this.MediaFormat;
            context.MediaSampleRateHertz = this.MediaSampleRateHertz;
            context.ModelSettings_LanguageModelName = this.ModelSettings_LanguageModelName;
            context.OutputBucketName = this.OutputBucketName;
            context.OutputEncryptionKMSKeyId = this.OutputEncryptionKMSKeyId;
            context.Settings_ChannelIdentification = this.Settings_ChannelIdentification;
            context.Settings_MaxAlternative = this.Settings_MaxAlternative;
            context.Settings_MaxSpeakerLabel = this.Settings_MaxSpeakerLabel;
            context.Settings_ShowAlternative = this.Settings_ShowAlternative;
            context.Settings_ShowSpeakerLabel = this.Settings_ShowSpeakerLabel;
            context.Settings_VocabularyFilterMethod = this.Settings_VocabularyFilterMethod;
            context.Settings_VocabularyFilterName = this.Settings_VocabularyFilterName;
            context.Settings_VocabularyName = this.Settings_VocabularyName;
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
            public Amazon.TranscribeService.RedactionOutput ContentRedaction_RedactionOutput { get; set; }
            public Amazon.TranscribeService.RedactionType ContentRedaction_RedactionType { get; set; }
            public System.Boolean? JobExecutionSettings_AllowDeferredExecution { get; set; }
            public System.String JobExecutionSettings_DataAccessRoleArn { get; set; }
            public Amazon.TranscribeService.LanguageCode LanguageCode { get; set; }
            public System.String Media_MediaFileUri { get; set; }
            public Amazon.TranscribeService.MediaFormat MediaFormat { get; set; }
            public System.Int32? MediaSampleRateHertz { get; set; }
            public System.String ModelSettings_LanguageModelName { get; set; }
            public System.String OutputBucketName { get; set; }
            public System.String OutputEncryptionKMSKeyId { get; set; }
            public System.Boolean? Settings_ChannelIdentification { get; set; }
            public System.Int32? Settings_MaxAlternative { get; set; }
            public System.Int32? Settings_MaxSpeakerLabel { get; set; }
            public System.Boolean? Settings_ShowAlternative { get; set; }
            public System.Boolean? Settings_ShowSpeakerLabel { get; set; }
            public Amazon.TranscribeService.VocabularyFilterMethod Settings_VocabularyFilterMethod { get; set; }
            public System.String Settings_VocabularyFilterName { get; set; }
            public System.String Settings_VocabularyName { get; set; }
            public System.String TranscriptionJobName { get; set; }
            public System.Func<Amazon.TranscribeService.Model.StartTranscriptionJobResponse, StartTRSTranscriptionJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TranscriptionJob;
        }
        
    }
}
