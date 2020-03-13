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
    /// Start a batch job to transcribe medical speech to text.
    /// </summary>
    [Cmdlet("Start", "TRSMedicalTranscriptionJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.TranscribeService.Model.MedicalTranscriptionJob")]
    [AWSCmdlet("Calls the Amazon Transcribe Service StartMedicalTranscriptionJob API operation.", Operation = new[] {"StartMedicalTranscriptionJob"}, SelectReturnType = typeof(Amazon.TranscribeService.Model.StartMedicalTranscriptionJobResponse))]
    [AWSCmdletOutput("Amazon.TranscribeService.Model.MedicalTranscriptionJob or Amazon.TranscribeService.Model.StartMedicalTranscriptionJobResponse",
        "This cmdlet returns an Amazon.TranscribeService.Model.MedicalTranscriptionJob object.",
        "The service call response (type Amazon.TranscribeService.Model.StartMedicalTranscriptionJobResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartTRSMedicalTranscriptionJobCmdlet : AmazonTranscribeServiceClientCmdlet, IExecutor
    {
        
        #region Parameter Settings_ChannelIdentification
        /// <summary>
        /// <para>
        /// <para>Instructs Amazon Transcribe Medical to process each audio channel separately and then
        /// merge the transcription output of each channel into a single transcription.</para><para>Amazon Transcribe Medical also produces a transcription of each item detected on an
        /// audio channel, including the start time and end time of the item and alternative transcriptions
        /// of item. The alternative transcriptions also come with confidence scores provided
        /// by Amazon Transcribe Medical.</para><para>You can't set both <code>ShowSpeakerLabels</code> and <code>ChannelIdentification</code>
        /// in the same request. If you set both, your request returns a <code>BadRequestException</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Settings_ChannelIdentification { get; set; }
        #endregion
        
        #region Parameter LanguageCode
        /// <summary>
        /// <para>
        /// <para>The language code for the language spoken in the input media file. US English (en-US)
        /// is the valid value for medical transcription jobs. Any other value you enter for language
        /// code results in a <code>BadRequestException</code> error.</para>
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
        /// <para>The maximum number of alternatives that you tell the service to return. If you specify
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
        /// <para>The audio format of the input media file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.TranscribeService.MediaFormat")]
        public Amazon.TranscribeService.MediaFormat MediaFormat { get; set; }
        #endregion
        
        #region Parameter MediaSampleRateHertz
        /// <summary>
        /// <para>
        /// <para>The sample rate, in Hertz, of the audio track in the input media file.</para><para>If you do not specify the media sample rate, Amazon Transcribe Medical determines
        /// the sample rate. If you specify the sample rate, it must match the rate detected by
        /// Amazon Transcribe Medical. In most cases, you should leave the <code>MediaSampleRateHertz</code>
        /// field blank and let Amazon Transcribe Medical determine the sample rate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MediaSampleRateHertz { get; set; }
        #endregion
        
        #region Parameter MedicalTranscriptionJobName
        /// <summary>
        /// <para>
        /// <para>The name of the medical transcription job. You can't use the strings "." or ".." by
        /// themselves as the job name. The name must also be unique within an AWS account. If
        /// you try to create a medical transcription job with the same name as a previous medical
        /// transcription job you will receive a <code>ConflictException</code> error.</para>
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
        /// <para>The Amazon S3 location where the transcription is stored.</para><para>You must set <code>OutputBucketName</code> for Amazon Transcribe Medical to store
        /// the transcription results. Your transcript appears in the S3 location you specify.
        /// When you call the <a>GetMedicalTranscriptionJob</a>, the operation returns this location
        /// in the <code>TranscriptFileUri</code> field. The S3 bucket must have permissions that
        /// allow Amazon Transcribe Medical to put files in the bucket. For more information,
        /// see <a href="https://docs.aws.amazon.com/transcribe/latest/dg/security_iam_id-based-policy-examples.html#auth-role-iam-user">Permissions
        /// Required for IAM User Roles</a>.</para><para>You can specify an AWS Key Management Service (KMS) key to encrypt the output of your
        /// transcription using the <code>OutputEncryptionKMSKeyId</code> parameter. If you don't
        /// specify a KMS key, Amazon Transcribe Medical uses the default Amazon S3 key for server-side
        /// encryption of transcripts that are placed in your S3 bucket.</para>
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
        /// <para>The Amazon Resource Name (ARN) of the AWS Key Management Service (KMS) key used to
        /// encrypt the output of the transcription job. The user calling the <a>StartMedicalTranscriptionJob</a>
        /// operation must have permission to use the specified KMS key.</para><para>You use either of the following to identify a KMS key in the current account:</para><ul><li><para>KMS Key ID: "1234abcd-12ab-34cd-56ef-1234567890ab"</para></li><li><para>KMS Key Alias: "alias/ExampleAlias"</para></li></ul><para>You can use either of the following to identify a KMS key in the current account or
        /// another account:</para><ul><li><para>Amazon Resource Name (ARN) of a KMS key in the current account or another account:
        /// "arn:aws:kms:region:account ID:key/1234abcd-12ab-34cd-56ef-1234567890ab"</para></li><li><para>ARN of a KMS Key Alias: "arn:aws:kms:region:account ID:alias/ExampleAlias"</para></li></ul><para>If you don't specify an encryption key, the output of the medical transcription job
        /// is encrypted with the default Amazon S3 key (SSE-S3).</para><para>If you specify a KMS key to encrypt your output, you must also specify an output location
        /// in the <code>OutputBucketName</code> parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputEncryptionKMSKeyId { get; set; }
        #endregion
        
        #region Parameter Settings_ShowAlternative
        /// <summary>
        /// <para>
        /// <para>Determines whether alternative transcripts are generated along with the transcript
        /// that has the highest confidence. If you set <code>ShowAlternatives</code> field to
        /// true, you must also set the maximum number of alternatives to return in the <code>MaxAlternatives</code>
        /// field.</para>
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
        /// speakers in the input audio. Speaker recongition labels individual speakers in the
        /// audio file. If you set the <code>ShowSpeakerLabels</code> field to true, you must
        /// also set the maximum number of speaker labels in the <code>MaxSpeakerLabels</code>
        /// field.</para><para>You can't set both <code>ShowSpeakerLabels</code> and <code>ChannelIdentification</code>
        /// in the same request. If you set both, your request returns a <code>BadRequestException</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_ShowSpeakerLabels")]
        public System.Boolean? Settings_ShowSpeakerLabel { get; set; }
        #endregion
        
        #region Parameter Specialty
        /// <summary>
        /// <para>
        /// <para>The medical specialty of any clinician speaking in the input media.</para>
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
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of speech in the input audio. <code>CONVERSATION</code> refers to conversations
        /// between two or more speakers, e.g., a conversations between doctors and patients.
        /// <code>DICTATION</code> refers to single-speaker dictated speech, e.g., for clinical
        /// notes.</para>
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
        /// <para>The name of the vocabulary to use when processing a medical transcription job.</para>
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
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the MedicalTranscriptionJobName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^MedicalTranscriptionJobName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^MedicalTranscriptionJobName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-TRSMedicalTranscriptionJob (StartMedicalTranscriptionJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.TranscribeService.Model.StartMedicalTranscriptionJobResponse, StartTRSMedicalTranscriptionJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.MedicalTranscriptionJobName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
                #if DESKTOP
                return client.StartMedicalTranscriptionJob(request);
                #elif CORECLR
                return client.StartMedicalTranscriptionJobAsync(request).GetAwaiter().GetResult();
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
            public Amazon.TranscribeService.LanguageCode LanguageCode { get; set; }
            public System.String Media_MediaFileUri { get; set; }
            public Amazon.TranscribeService.MediaFormat MediaFormat { get; set; }
            public System.Int32? MediaSampleRateHertz { get; set; }
            public System.String MedicalTranscriptionJobName { get; set; }
            public System.String OutputBucketName { get; set; }
            public System.String OutputEncryptionKMSKeyId { get; set; }
            public System.Boolean? Settings_ChannelIdentification { get; set; }
            public System.Int32? Settings_MaxAlternative { get; set; }
            public System.Int32? Settings_MaxSpeakerLabel { get; set; }
            public System.Boolean? Settings_ShowAlternative { get; set; }
            public System.Boolean? Settings_ShowSpeakerLabel { get; set; }
            public System.String Settings_VocabularyName { get; set; }
            public Amazon.TranscribeService.Specialty Specialty { get; set; }
            public Amazon.TranscribeService.Type Type { get; set; }
            public System.Func<Amazon.TranscribeService.Model.StartMedicalTranscriptionJobResponse, StartTRSMedicalTranscriptionJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MedicalTranscriptionJob;
        }
        
    }
}
