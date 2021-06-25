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
    /// Starts an asynchronous analytics job that not only transcribes the audio recording
    /// of a caller and agent, but also returns additional insights. These insights include
    /// how quickly or loudly the caller or agent was speaking. To retrieve additional insights
    /// with your analytics jobs, create categories. A category is a way to classify analytics
    /// jobs based on attributes, such as a customer's sentiment or a particular phrase being
    /// used during the call. For more information, see the operation.
    /// </summary>
    [Cmdlet("Start", "TRSCallAnalyticsJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.TranscribeService.Model.CallAnalyticsJob")]
    [AWSCmdlet("Calls the Amazon Transcribe Service StartCallAnalyticsJob API operation.", Operation = new[] {"StartCallAnalyticsJob"}, SelectReturnType = typeof(Amazon.TranscribeService.Model.StartCallAnalyticsJobResponse))]
    [AWSCmdletOutput("Amazon.TranscribeService.Model.CallAnalyticsJob or Amazon.TranscribeService.Model.StartCallAnalyticsJobResponse",
        "This cmdlet returns an Amazon.TranscribeService.Model.CallAnalyticsJob object.",
        "The service call response (type Amazon.TranscribeService.Model.StartCallAnalyticsJobResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartTRSCallAnalyticsJobCmdlet : AmazonTranscribeServiceClientCmdlet, IExecutor
    {
        
        #region Parameter CallAnalyticsJobName
        /// <summary>
        /// <para>
        /// <para>The name of the call analytics job. You can't use the string "." or ".." by themselves
        /// as the job name. The name must also be unique within an Amazon Web Services account.
        /// If you try to create a call analytics job with the same name as a previous call analytics
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
        public System.String CallAnalyticsJobName { get; set; }
        #endregion
        
        #region Parameter ChannelDefinition
        /// <summary>
        /// <para>
        /// <para>When you start a call analytics job, you must pass an array that maps the agent and
        /// the customer to specific audio channels. The values you can assign to a channel are
        /// 0 and 1. The agent and the customer must each have their own channel. You can't assign
        /// more than one channel to an agent or customer. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChannelDefinitions")]
        public Amazon.TranscribeService.Model.ChannelDefinition[] ChannelDefinition { get; set; }
        #endregion
        
        #region Parameter DataAccessRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a role that has access to the S3 bucket that contains
        /// your input files. Amazon Transcribe assumes this role to read queued audio files.
        /// If you have specified an output S3 bucket for your transcription results, this role
        /// should have access to the output bucket as well.</para>
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
        
        #region Parameter Settings_LanguageModelName
        /// <summary>
        /// <para>
        /// <para>The structure used to describe a custom language model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Settings_LanguageModelName { get; set; }
        #endregion
        
        #region Parameter Settings_LanguageOption
        /// <summary>
        /// <para>
        /// <para>When you run a call analytics job, you can specify the language spoken in the audio,
        /// or you can have Amazon Transcribe identify the language for you.</para><para>To specify a language, specify an array with one language code. If you don't know
        /// the language, you can leave this field blank and Amazon Transcribe will use machine
        /// learning to identify the language for you. To improve the ability of Amazon Transcribe
        /// to correctly identify the language, you can provide an array of the languages that
        /// can be present in the audio. Refer to <a href="https://docs.aws.amazon.com/transcribe/latest/dg/how-it-works.html">Supported
        /// languages and language-specific features</a> for additional information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_LanguageOptions")]
        public System.String[] Settings_LanguageOption { get; set; }
        #endregion
        
        #region Parameter Media_MediaFileUri
        /// <summary>
        /// <para>
        /// <para>The S3 object location of the input media file. The URI must be in the same region
        /// as the API endpoint that you are calling. The general form is:</para><para>For example:</para><para>For more information about S3 object names, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/UsingMetadata.html#object-keys">Object
        /// Keys</a> in the <i>Amazon S3 Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Media_MediaFileUri { get; set; }
        #endregion
        
        #region Parameter OutputEncryptionKMSKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon Web Services Key Management Service key
        /// used to encrypt the output of the call analytics job. The user calling the operation
        /// must have permission to use the specified KMS key.</para><para>You use either of the following to identify an Amazon Web Services KMS key in the
        /// current account:</para><ul><li><para>KMS Key ID: "1234abcd-12ab-34cd-56ef-1234567890ab"</para></li><li><para>KMS Key Alias: "alias/ExampleAlias"</para></li></ul><para> You can use either of the following to identify a KMS key in the current account
        /// or another account:</para><ul><li><para>Amazon Resource Name (ARN) of a KMS key in the current account or another account:
        /// "arn:aws:kms:region:account ID:key/1234abcd-12ab-34cd-56ef1234567890ab"</para></li><li><para>ARN of a KMS Key Alias: "arn:aws:kms:region:account ID:alias/ExampleAlias"</para></li></ul><para>If you don't specify an encryption key, the output of the call analytics job is encrypted
        /// with the default Amazon S3 key (SSE-S3).</para><para>If you specify a KMS key to encrypt your output, you must also specify an output location
        /// in the <code>OutputLocation</code> parameter. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputEncryptionKMSKeyId { get; set; }
        #endregion
        
        #region Parameter OutputLocation
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 location where the output of the call analytics job is stored. You can
        /// provide the following location types to store the output of call analytics job:</para><ul><li><para>s3://DOC-EXAMPLE-BUCKET1</para><para> If you specify a bucket, Amazon Transcribe saves the output of the analytics job
        /// as a JSON file at the root level of the bucket.</para></li><li><para>s3://DOC-EXAMPLE-BUCKET1/folder/</para><para>f you specify a path, Amazon Transcribe saves the output of the analytics job as s3://DOC-EXAMPLE-BUCKET1/folder/your-transcription-job-name.json</para><para>If you specify a folder, you must provide a trailing slash.</para></li><li><para>s3://DOC-EXAMPLE-BUCKET1/folder/filename.json</para><para> If you provide a path that has the filename specified, Amazon Transcribe saves the
        /// output of the analytics job as s3://DOC-EXAMPLEBUCKET1/folder/filename.json</para></li></ul><para>You can specify an Amazon Web Services Key Management Service (KMS) key to encrypt
        /// the output of our analytics job using the <code>OutputEncryptionKMSKeyId</code> parameter.
        /// If you don't specify a KMS key, Amazon Transcribe uses the default Amazon S3 key for
        /// server-side encryption of the analytics job output that is placed in your S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputLocation { get; set; }
        #endregion
        
        #region Parameter Media_RedactedMediaFileUri
        /// <summary>
        /// <para>
        /// <para> The S3 object location for your redacted output media file. This is only supported
        /// for call analytics jobs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Media_RedactedMediaFileUri { get; set; }
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
        [Alias("Settings_ContentRedaction_RedactionOutput")]
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
        [Alias("Settings_ContentRedaction_RedactionType")]
        [AWSConstantClassSource("Amazon.TranscribeService.RedactionType")]
        public Amazon.TranscribeService.RedactionType ContentRedaction_RedactionType { get; set; }
        #endregion
        
        #region Parameter Settings_VocabularyFilterMethod
        /// <summary>
        /// <para>
        /// <para>Set to mask to remove filtered text from the transcript and replace it with three
        /// asterisks ("***") as placeholder text. Set to <code>remove</code> to remove filtered
        /// text from the transcript without using placeholder text. Set to <code>tag</code> to
        /// mark the word in the transcription output that matches the vocabulary filter. When
        /// you set the filter method to <code>tag</code>, the words matching your vocabulary
        /// filter are not masked or removed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.TranscribeService.VocabularyFilterMethod")]
        public Amazon.TranscribeService.VocabularyFilterMethod Settings_VocabularyFilterMethod { get; set; }
        #endregion
        
        #region Parameter Settings_VocabularyFilterName
        /// <summary>
        /// <para>
        /// <para>The name of the vocabulary filter to use when running a call analytics job. The filter
        /// that you specify must have the same language code as the analytics job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Settings_VocabularyFilterName { get; set; }
        #endregion
        
        #region Parameter Settings_VocabularyName
        /// <summary>
        /// <para>
        /// <para>The name of a vocabulary to use when processing the call analytics job.</para>
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
            #if MODULAR
            if (this.DataAccessRoleArn == null && ParameterWasBound(nameof(this.DataAccessRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DataAccessRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Media_MediaFileUri = this.Media_MediaFileUri;
            context.Media_RedactedMediaFileUri = this.Media_RedactedMediaFileUri;
            context.OutputEncryptionKMSKeyId = this.OutputEncryptionKMSKeyId;
            context.OutputLocation = this.OutputLocation;
            context.ContentRedaction_RedactionOutput = this.ContentRedaction_RedactionOutput;
            context.ContentRedaction_RedactionType = this.ContentRedaction_RedactionType;
            context.Settings_LanguageModelName = this.Settings_LanguageModelName;
            if (this.Settings_LanguageOption != null)
            {
                context.Settings_LanguageOption = new List<System.String>(this.Settings_LanguageOption);
            }
            context.Settings_VocabularyFilterMethod = this.Settings_VocabularyFilterMethod;
            context.Settings_VocabularyFilterName = this.Settings_VocabularyFilterName;
            context.Settings_VocabularyName = this.Settings_VocabularyName;
            
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
            Amazon.TranscribeService.Model.ContentRedaction requestSettings_settings_ContentRedaction = null;
            
             // populate ContentRedaction
            var requestSettings_settings_ContentRedactionIsNull = true;
            requestSettings_settings_ContentRedaction = new Amazon.TranscribeService.Model.ContentRedaction();
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
            public Amazon.TranscribeService.RedactionOutput ContentRedaction_RedactionOutput { get; set; }
            public Amazon.TranscribeService.RedactionType ContentRedaction_RedactionType { get; set; }
            public System.String Settings_LanguageModelName { get; set; }
            public List<System.String> Settings_LanguageOption { get; set; }
            public Amazon.TranscribeService.VocabularyFilterMethod Settings_VocabularyFilterMethod { get; set; }
            public System.String Settings_VocabularyFilterName { get; set; }
            public System.String Settings_VocabularyName { get; set; }
            public System.Func<Amazon.TranscribeService.Model.StartCallAnalyticsJobResponse, StartTRSCallAnalyticsJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CallAnalyticsJob;
        }
        
    }
}
