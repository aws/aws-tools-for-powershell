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
    /// Transcribes patient-clinician conversations and generates clinical notes. 
    /// 
    ///  
    /// <para>
    /// Amazon Web Services HealthScribe automatically provides rich conversation transcripts,
    /// identifies speaker roles, classifies dialogues, extracts medical terms, and generates
    /// preliminary clinical notes. To learn more about these features, refer to <a href="https://docs.aws.amazon.com/transcribe/latest/dg/health-scribe.html">Amazon
    /// Web Services HealthScribe</a>.
    /// </para><para>
    /// To make a <c>StartMedicalScribeJob</c> request, you must first upload your media file
    /// into an Amazon S3 bucket; you can then specify the Amazon S3 location of the file
    /// using the <c>Media</c> parameter.
    /// </para><para>
    /// You must include the following parameters in your <c>StartMedicalTranscriptionJob</c>
    /// request:
    /// </para><ul><li><para><c>DataAccessRoleArn</c>: The ARN of an IAM role with the these minimum permissions:
    /// read permission on input file Amazon S3 bucket specified in <c>Media</c>, write permission
    /// on the Amazon S3 bucket specified in <c>OutputBucketName</c>, and full permissions
    /// on the KMS key specified in <c>OutputEncryptionKMSKeyId</c> (if set). The role should
    /// also allow <c>transcribe.amazonaws.com</c> to assume it. 
    /// </para></li><li><para><c>Media</c> (<c>MediaFileUri</c>): The Amazon S3 location of your media file.
    /// </para></li><li><para><c>MedicalScribeJobName</c>: A custom name you create for your MedicalScribe job
    /// that is unique within your Amazon Web Services account.
    /// </para></li><li><para><c>OutputBucketName</c>: The Amazon S3 bucket where you want your output files stored.
    /// </para></li><li><para><c>Settings</c>: A <c>MedicalScribeSettings</c> obect that must set exactly one of
    /// <c>ShowSpeakerLabels</c> or <c>ChannelIdentification</c> to true. If <c>ShowSpeakerLabels</c>
    /// is true, <c>MaxSpeakerLabels</c> must also be set. 
    /// </para></li><li><para><c>ChannelDefinitions</c>: A <c>MedicalScribeChannelDefinitions</c> array should
    /// be set if and only if the <c>ChannelIdentification</c> value of <c>Settings</c> is
    /// set to true. 
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Start", "TRSMedicalScribeJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.TranscribeService.Model.MedicalScribeJob")]
    [AWSCmdlet("Calls the Amazon Transcribe Service StartMedicalScribeJob API operation.", Operation = new[] {"StartMedicalScribeJob"}, SelectReturnType = typeof(Amazon.TranscribeService.Model.StartMedicalScribeJobResponse))]
    [AWSCmdletOutput("Amazon.TranscribeService.Model.MedicalScribeJob or Amazon.TranscribeService.Model.StartMedicalScribeJobResponse",
        "This cmdlet returns an Amazon.TranscribeService.Model.MedicalScribeJob object.",
        "The service call response (type Amazon.TranscribeService.Model.StartMedicalScribeJobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartTRSMedicalScribeJobCmdlet : AmazonTranscribeServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ChannelDefinition
        /// <summary>
        /// <para>
        /// <para>Makes it possible to specify which speaker is on which channel. For example, if the
        /// clinician is the first participant to speak, you would set <c>ChannelId</c> of the
        /// first <c>ChannelDefinition</c> in the list to <c>0</c> (to indicate the first channel)
        /// and <c>ParticipantRole</c> to <c>CLINICIAN</c> (to indicate that it's the clinician
        /// speaking). Then you would set the <c>ChannelId</c> of the second <c>ChannelDefinition</c>
        /// in the list to <c>1</c> (to indicate the second channel) and <c>ParticipantRole</c>
        /// to <c>PATIENT</c> (to indicate that it's the patient speaking). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChannelDefinitions")]
        public Amazon.TranscribeService.Model.MedicalScribeChannelDefinition[] ChannelDefinition { get; set; }
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
        
        #region Parameter DataAccessRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an IAM role that has permissions to access the Amazon
        /// S3 bucket that contains your input files, write to the output bucket, and use your
        /// KMS key if supplied. If the role that you specify doesn’t have the appropriate permissions
        /// your request fails.</para><para>IAM role ARNs have the format <c>arn:partition:iam::account:role/role-name-with-path</c>.
        /// For example: <c>arn:aws:iam::111122223333:role/Admin</c>.</para><para>For more information, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_identifiers.html#identifiers-arns">IAM
        /// ARNs</a>.</para>
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
        public System.String DataAccessRoleArn { get; set; }
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
        
        #region Parameter MedicalScribeJobName
        /// <summary>
        /// <para>
        /// <para>A unique name, chosen by you, for your Medical Scribe job.</para><para>This name is case sensitive, cannot contain spaces, and must be unique within an Amazon
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
        public System.String MedicalScribeJobName { get; set; }
        #endregion
        
        #region Parameter ClinicalNoteGenerationSettings_NoteTemplate
        /// <summary>
        /// <para>
        /// <para>Specify one of the following templates to use for the clinical note summary. The default
        /// is <c>HISTORY_AND_PHYSICAL</c>.</para><ul><li><para>HISTORY_AND_PHYSICAL: Provides summaries for key sections of the clinical documentation.
        /// Examples of sections include Chief Complaint, History of Present Illness, Review of
        /// Systems, Past Medical History, Assessment, and Plan. </para></li><li><para>GIRPP: Provides summaries based on the patients progress toward goals. Examples of
        /// sections include Goal, Intervention, Response, Progress, and Plan.</para></li><li><para>BIRP: Focuses on the patient's behavioral patterns and responses. Examples of sections
        /// include Behavior, Intervention, Response, and Plan.</para></li><li><para>SIRP: Emphasizes the situational context of therapy. Examples of sections include
        /// Situation, Intervention, Response, and Plan.</para></li><li><para>DAP: Provides a simplified format for clinical documentation. Examples of sections
        /// include Data, Assessment, and Plan.</para></li><li><para>BEHAVIORAL_SOAP: Behavioral health focused documentation format. Examples of sections
        /// include Subjective, Objective, Assessment, and Plan.</para></li><li><para>PHYSICAL_SOAP: Physical health focused documentation format. Examples of sections
        /// include Subjective, Objective, Assessment, and Plan.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_ClinicalNoteGenerationSettings_NoteTemplate")]
        [AWSConstantClassSource("Amazon.TranscribeService.MedicalScribeNoteTemplate")]
        public Amazon.TranscribeService.MedicalScribeNoteTemplate ClinicalNoteGenerationSettings_NoteTemplate { get; set; }
        #endregion
        
        #region Parameter OutputBucketName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon S3 bucket where you want your Medical Scribe output stored.
        /// Do not include the <c>S3://</c> prefix of the specified bucket.</para><para>Note that the role specified in the <c>DataAccessRoleArn</c> request parameter must
        /// have permission to use the specified location. You can change Amazon S3 permissions
        /// using the <a href="https://console.aws.amazon.com/s3">Amazon Web Services Management
        /// Console</a>. See also <a href="https://docs.aws.amazon.com/transcribe/latest/dg/security_iam_id-based-policy-examples.html#auth-role-iam-user">Permissions
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
        /// <para>The KMS key you want to use to encrypt your Medical Scribe output.</para><para>If using a key located in the <b>current</b> Amazon Web Services account, you can
        /// specify your KMS key in one of four ways:</para><ol><li><para>Use the KMS key ID itself. For example, <c>1234abcd-12ab-34cd-56ef-1234567890ab</c>.</para></li><li><para>Use an alias for the KMS key ID. For example, <c>alias/ExampleAlias</c>.</para></li><li><para>Use the Amazon Resource Name (ARN) for the KMS key ID. For example, <c>arn:aws:kms:region:account-ID:key/1234abcd-12ab-34cd-56ef-1234567890ab</c>.</para></li><li><para>Use the ARN for the KMS key alias. For example, <c>arn:aws:kms:region:account-ID:alias/ExampleAlias</c>.</para></li></ol><para>If using a key located in a <b>different</b> Amazon Web Services account than the
        /// current Amazon Web Services account, you can specify your KMS key in one of two ways:</para><ol><li><para>Use the ARN for the KMS key ID. For example, <c>arn:aws:kms:region:account-ID:key/1234abcd-12ab-34cd-56ef-1234567890ab</c>.</para></li><li><para>Use the ARN for the KMS key alias. For example, <c>arn:aws:kms:region:account-ID:alias/ExampleAlias</c>.</para></li></ol><para>If you do not specify an encryption key, your output is encrypted with the default
        /// Amazon S3 key (SSE-S3).</para><para>Note that the role specified in the <c>DataAccessRoleArn</c> request parameter must
        /// have permission to use the specified KMS key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputEncryptionKMSKeyId { get; set; }
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
        
        #region Parameter Settings_ShowSpeakerLabel
        /// <summary>
        /// <para>
        /// <para>Enables speaker partitioning (diarization) in your Medical Scribe output. Speaker
        /// partitioning labels the speech from individual speakers in your media file.</para><para>If you enable <c>ShowSpeakerLabels</c> in your request, you must also include <c>MaxSpeakerLabels</c>.</para><para>For more information, see <a href="https://docs.aws.amazon.com/transcribe/latest/dg/diarization.html">Partitioning
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
        /// <para>Adds one or more custom tags, each in the form of a key:value pair, to the Medica
        /// Scribe job.</para><para>To learn more about using tags with Amazon Transcribe, refer to <a href="https://docs.aws.amazon.com/transcribe/latest/dg/tagging.html">Tagging
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
        /// <para>The name of the custom vocabulary filter you want to include in your Medical Scribe
        /// request. Custom vocabulary filter names are case sensitive.</para><para>Note that if you include <c>VocabularyFilterName</c> in your request, you must also
        /// include <c>VocabularyFilterMethod</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Settings_VocabularyFilterName { get; set; }
        #endregion
        
        #region Parameter Settings_VocabularyName
        /// <summary>
        /// <para>
        /// <para>The name of the custom vocabulary you want to include in your Medical Scribe request.
        /// Custom vocabulary names are case sensitive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Settings_VocabularyName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MedicalScribeJob'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TranscribeService.Model.StartMedicalScribeJobResponse).
        /// Specifying the name of a property of type Amazon.TranscribeService.Model.StartMedicalScribeJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MedicalScribeJob";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the MedicalScribeJobName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^MedicalScribeJobName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^MedicalScribeJobName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MedicalScribeJobName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-TRSMedicalScribeJob (StartMedicalScribeJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.TranscribeService.Model.StartMedicalScribeJobResponse, StartTRSMedicalScribeJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.MedicalScribeJobName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.ChannelDefinition != null)
            {
                context.ChannelDefinition = new List<Amazon.TranscribeService.Model.MedicalScribeChannelDefinition>(this.ChannelDefinition);
            }
            context.DataAccessRoleArn = this.DataAccessRoleArn;
            #if MODULAR
            if (this.DataAccessRoleArn == null && ParameterWasBound(nameof(this.DataAccessRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DataAccessRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.KMSEncryptionContext != null)
            {
                context.KMSEncryptionContext = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.KMSEncryptionContext.Keys)
                {
                    context.KMSEncryptionContext.Add((String)hashKey, (System.String)(this.KMSEncryptionContext[hashKey]));
                }
            }
            context.Media_MediaFileUri = this.Media_MediaFileUri;
            context.Media_RedactedMediaFileUri = this.Media_RedactedMediaFileUri;
            context.MedicalScribeJobName = this.MedicalScribeJobName;
            #if MODULAR
            if (this.MedicalScribeJobName == null && ParameterWasBound(nameof(this.MedicalScribeJobName)))
            {
                WriteWarning("You are passing $null as a value for parameter MedicalScribeJobName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            context.ClinicalNoteGenerationSettings_NoteTemplate = this.ClinicalNoteGenerationSettings_NoteTemplate;
            context.Settings_MaxSpeakerLabel = this.Settings_MaxSpeakerLabel;
            context.Settings_ShowSpeakerLabel = this.Settings_ShowSpeakerLabel;
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
            var request = new Amazon.TranscribeService.Model.StartMedicalScribeJobRequest();
            
            if (cmdletContext.ChannelDefinition != null)
            {
                request.ChannelDefinitions = cmdletContext.ChannelDefinition;
            }
            if (cmdletContext.DataAccessRoleArn != null)
            {
                request.DataAccessRoleArn = cmdletContext.DataAccessRoleArn;
            }
            if (cmdletContext.KMSEncryptionContext != null)
            {
                request.KMSEncryptionContext = cmdletContext.KMSEncryptionContext;
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
            if (cmdletContext.MedicalScribeJobName != null)
            {
                request.MedicalScribeJobName = cmdletContext.MedicalScribeJobName;
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
            request.Settings = new Amazon.TranscribeService.Model.MedicalScribeSettings();
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
            Amazon.TranscribeService.Model.ClinicalNoteGenerationSettings requestSettings_settings_ClinicalNoteGenerationSettings = null;
            
             // populate ClinicalNoteGenerationSettings
            var requestSettings_settings_ClinicalNoteGenerationSettingsIsNull = true;
            requestSettings_settings_ClinicalNoteGenerationSettings = new Amazon.TranscribeService.Model.ClinicalNoteGenerationSettings();
            Amazon.TranscribeService.MedicalScribeNoteTemplate requestSettings_settings_ClinicalNoteGenerationSettings_clinicalNoteGenerationSettings_NoteTemplate = null;
            if (cmdletContext.ClinicalNoteGenerationSettings_NoteTemplate != null)
            {
                requestSettings_settings_ClinicalNoteGenerationSettings_clinicalNoteGenerationSettings_NoteTemplate = cmdletContext.ClinicalNoteGenerationSettings_NoteTemplate;
            }
            if (requestSettings_settings_ClinicalNoteGenerationSettings_clinicalNoteGenerationSettings_NoteTemplate != null)
            {
                requestSettings_settings_ClinicalNoteGenerationSettings.NoteTemplate = requestSettings_settings_ClinicalNoteGenerationSettings_clinicalNoteGenerationSettings_NoteTemplate;
                requestSettings_settings_ClinicalNoteGenerationSettingsIsNull = false;
            }
             // determine if requestSettings_settings_ClinicalNoteGenerationSettings should be set to null
            if (requestSettings_settings_ClinicalNoteGenerationSettingsIsNull)
            {
                requestSettings_settings_ClinicalNoteGenerationSettings = null;
            }
            if (requestSettings_settings_ClinicalNoteGenerationSettings != null)
            {
                request.Settings.ClinicalNoteGenerationSettings = requestSettings_settings_ClinicalNoteGenerationSettings;
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
        
        private Amazon.TranscribeService.Model.StartMedicalScribeJobResponse CallAWSServiceOperation(IAmazonTranscribeService client, Amazon.TranscribeService.Model.StartMedicalScribeJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Transcribe Service", "StartMedicalScribeJob");
            try
            {
                #if DESKTOP
                return client.StartMedicalScribeJob(request);
                #elif CORECLR
                return client.StartMedicalScribeJobAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.TranscribeService.Model.MedicalScribeChannelDefinition> ChannelDefinition { get; set; }
            public System.String DataAccessRoleArn { get; set; }
            public Dictionary<System.String, System.String> KMSEncryptionContext { get; set; }
            public System.String Media_MediaFileUri { get; set; }
            public System.String Media_RedactedMediaFileUri { get; set; }
            public System.String MedicalScribeJobName { get; set; }
            public System.String OutputBucketName { get; set; }
            public System.String OutputEncryptionKMSKeyId { get; set; }
            public System.Boolean? Settings_ChannelIdentification { get; set; }
            public Amazon.TranscribeService.MedicalScribeNoteTemplate ClinicalNoteGenerationSettings_NoteTemplate { get; set; }
            public System.Int32? Settings_MaxSpeakerLabel { get; set; }
            public System.Boolean? Settings_ShowSpeakerLabel { get; set; }
            public Amazon.TranscribeService.VocabularyFilterMethod Settings_VocabularyFilterMethod { get; set; }
            public System.String Settings_VocabularyFilterName { get; set; }
            public System.String Settings_VocabularyName { get; set; }
            public List<Amazon.TranscribeService.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.TranscribeService.Model.StartMedicalScribeJobResponse, StartTRSMedicalScribeJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MedicalScribeJob;
        }
        
    }
}
