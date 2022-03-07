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
using Amazon.ChimeSDKMeetings;
using Amazon.ChimeSDKMeetings.Model;

namespace Amazon.PowerShell.Cmdlets.CHMTG
{
    /// <summary>
    /// Starts transcription for the specified <code>meetingId</code>.
    /// </summary>
    [Cmdlet("Start", "CHMTGMeetingTranscription", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Chime SDK Meetings StartMeetingTranscription API operation.", Operation = new[] {"StartMeetingTranscription"}, SelectReturnType = typeof(Amazon.ChimeSDKMeetings.Model.StartMeetingTranscriptionResponse))]
    [AWSCmdletOutput("None or Amazon.ChimeSDKMeetings.Model.StartMeetingTranscriptionResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ChimeSDKMeetings.Model.StartMeetingTranscriptionResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartCHMTGMeetingTranscriptionCmdlet : AmazonChimeSDKMeetingsClientCmdlet, IExecutor
    {
        
        #region Parameter EngineTranscribeMedicalSettings_ContentIdentificationType
        /// <summary>
        /// <para>
        /// <para>Set this field to <code>PHI</code> to identify personal health information in the
        /// transcription output.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TranscriptionConfiguration_EngineTranscribeMedicalSettings_ContentIdentificationType")]
        [AWSConstantClassSource("Amazon.ChimeSDKMeetings.TranscribeMedicalContentIdentificationType")]
        public Amazon.ChimeSDKMeetings.TranscribeMedicalContentIdentificationType EngineTranscribeMedicalSettings_ContentIdentificationType { get; set; }
        #endregion
        
        #region Parameter EngineTranscribeSettings_ContentIdentificationType
        /// <summary>
        /// <para>
        /// <para>Set this field to <code>PII</code> to identify personally identifiable information
        /// in the transcription output.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TranscriptionConfiguration_EngineTranscribeSettings_ContentIdentificationType")]
        [AWSConstantClassSource("Amazon.ChimeSDKMeetings.TranscribeContentIdentificationType")]
        public Amazon.ChimeSDKMeetings.TranscribeContentIdentificationType EngineTranscribeSettings_ContentIdentificationType { get; set; }
        #endregion
        
        #region Parameter EngineTranscribeSettings_ContentRedactionType
        /// <summary>
        /// <para>
        /// <para>Set this field to <code>PII</code> to redact personally identifiable information in
        /// the transcription output. Content redaction is performed only upon complete transcription
        /// of the audio segments.</para><para>You can’t set <code>ContentRedactionType</code> and <code>ContentIdentificationType</code>
        /// in the same request. If you set both, your request returns a <code>BadRequestException</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TranscriptionConfiguration_EngineTranscribeSettings_ContentRedactionType")]
        [AWSConstantClassSource("Amazon.ChimeSDKMeetings.TranscribeContentRedactionType")]
        public Amazon.ChimeSDKMeetings.TranscribeContentRedactionType EngineTranscribeSettings_ContentRedactionType { get; set; }
        #endregion
        
        #region Parameter EngineTranscribeSettings_EnablePartialResultsStabilization
        /// <summary>
        /// <para>
        /// <para>Generates partial transcription results that are less likely to change as meeting
        /// attendees speak. It does so by only allowing the last few words from the partial results
        /// to change.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TranscriptionConfiguration_EngineTranscribeSettings_EnablePartialResultsStabilization")]
        public System.Boolean? EngineTranscribeSettings_EnablePartialResultsStabilization { get; set; }
        #endregion
        
        #region Parameter EngineTranscribeSettings_IdentifyLanguage
        /// <summary>
        /// <para>
        /// <para>Automatically identifies the language spoken in media files.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TranscriptionConfiguration_EngineTranscribeSettings_IdentifyLanguage")]
        public System.Boolean? EngineTranscribeSettings_IdentifyLanguage { get; set; }
        #endregion
        
        #region Parameter EngineTranscribeMedicalSettings_LanguageCode
        /// <summary>
        /// <para>
        /// <para>The language code specified for the Amazon Transcribe Medical engine.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TranscriptionConfiguration_EngineTranscribeMedicalSettings_LanguageCode")]
        [AWSConstantClassSource("Amazon.ChimeSDKMeetings.TranscribeMedicalLanguageCode")]
        public Amazon.ChimeSDKMeetings.TranscribeMedicalLanguageCode EngineTranscribeMedicalSettings_LanguageCode { get; set; }
        #endregion
        
        #region Parameter EngineTranscribeSettings_LanguageCode
        /// <summary>
        /// <para>
        /// <para>The language code specified for the Amazon Transcribe engine.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TranscriptionConfiguration_EngineTranscribeSettings_LanguageCode")]
        [AWSConstantClassSource("Amazon.ChimeSDKMeetings.TranscribeLanguageCode")]
        public Amazon.ChimeSDKMeetings.TranscribeLanguageCode EngineTranscribeSettings_LanguageCode { get; set; }
        #endregion
        
        #region Parameter EngineTranscribeSettings_LanguageModelName
        /// <summary>
        /// <para>
        /// <para>The name of the language model used during transcription.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TranscriptionConfiguration_EngineTranscribeSettings_LanguageModelName")]
        public System.String EngineTranscribeSettings_LanguageModelName { get; set; }
        #endregion
        
        #region Parameter EngineTranscribeSettings_LanguageOption
        /// <summary>
        /// <para>
        /// <para>Language codes for the languages that you want to identify. You must provide at least
        /// 2 codes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TranscriptionConfiguration_EngineTranscribeSettings_LanguageOptions")]
        public System.String EngineTranscribeSettings_LanguageOption { get; set; }
        #endregion
        
        #region Parameter MeetingId
        /// <summary>
        /// <para>
        /// <para>The unique ID of the meeting being transcribed.</para>
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
        public System.String MeetingId { get; set; }
        #endregion
        
        #region Parameter EngineTranscribeSettings_PartialResultsStability
        /// <summary>
        /// <para>
        /// <para>The stabity level of a partial results transcription. Determines how stable you want
        /// the transcription results to be. A higher level means the transcription results are
        /// less likely to change.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TranscriptionConfiguration_EngineTranscribeSettings_PartialResultsStability")]
        [AWSConstantClassSource("Amazon.ChimeSDKMeetings.TranscribePartialResultsStability")]
        public Amazon.ChimeSDKMeetings.TranscribePartialResultsStability EngineTranscribeSettings_PartialResultsStability { get; set; }
        #endregion
        
        #region Parameter EngineTranscribeSettings_PiiEntityType
        /// <summary>
        /// <para>
        /// <para>Lists the PII entity types you want to identify or redact. To specify entity types,
        /// you must enable <code>ContentIdentificationType</code> or <code>ContentRedactionType</code>.</para><para><code>PIIEntityTypes</code> must be comma-separated. The available values are: <code>BANK_ACCOUNT_NUMBER</code>,
        /// <code>BANK_ROUTING, CREDIT_DEBIT_NUMBER</code>, <code>CREDIT_DEBIT_CVV</code>, <code>CREDIT_DEBIT_EXPIRY</code>,
        /// <code>PIN</code>, <code>EMAIL</code>, <code>ADDRESS</code>, <code>NAME</code>, <code>PHONE</code>,
        /// <code>SSN</code>, and <code>ALL</code>.</para><para><code>PiiEntityTypes</code> is an optional parameter with a default value of <code>ALL</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TranscriptionConfiguration_EngineTranscribeSettings_PiiEntityTypes")]
        public System.String EngineTranscribeSettings_PiiEntityType { get; set; }
        #endregion
        
        #region Parameter EngineTranscribeSettings_PreferredLanguage
        /// <summary>
        /// <para>
        /// <para>Language code for the preferred language.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TranscriptionConfiguration_EngineTranscribeSettings_PreferredLanguage")]
        [AWSConstantClassSource("Amazon.ChimeSDKMeetings.TranscribeLanguageCode")]
        public Amazon.ChimeSDKMeetings.TranscribeLanguageCode EngineTranscribeSettings_PreferredLanguage { get; set; }
        #endregion
        
        #region Parameter EngineTranscribeMedicalSettings_Region
        /// <summary>
        /// <para>
        /// <para>The AWS Region passed to Amazon Transcribe Medical. If you don't specify a Region,
        /// Amazon Chime uses the meeting's Region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TranscriptionConfiguration_EngineTranscribeMedicalSettings_Region")]
        [AWSConstantClassSource("Amazon.ChimeSDKMeetings.TranscribeMedicalRegion")]
        public Amazon.ChimeSDKMeetings.TranscribeMedicalRegion EngineTranscribeMedicalSettings_Region { get; set; }
        #endregion
        
        #region Parameter EngineTranscribeSettings_Region
        /// <summary>
        /// <para>
        /// <para>The AWS Region passed to Amazon Transcribe. If you don't specify a Region, Amazon
        /// Chime uses the meeting's Region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TranscriptionConfiguration_EngineTranscribeSettings_Region")]
        [AWSConstantClassSource("Amazon.ChimeSDKMeetings.TranscribeRegion")]
        public Amazon.ChimeSDKMeetings.TranscribeRegion EngineTranscribeSettings_Region { get; set; }
        #endregion
        
        #region Parameter EngineTranscribeMedicalSettings_Specialty
        /// <summary>
        /// <para>
        /// <para>The specialty specified for the Amazon Transcribe Medical engine.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TranscriptionConfiguration_EngineTranscribeMedicalSettings_Specialty")]
        [AWSConstantClassSource("Amazon.ChimeSDKMeetings.TranscribeMedicalSpecialty")]
        public Amazon.ChimeSDKMeetings.TranscribeMedicalSpecialty EngineTranscribeMedicalSettings_Specialty { get; set; }
        #endregion
        
        #region Parameter EngineTranscribeMedicalSettings_Type
        /// <summary>
        /// <para>
        /// <para>The type of transcription.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TranscriptionConfiguration_EngineTranscribeMedicalSettings_Type")]
        [AWSConstantClassSource("Amazon.ChimeSDKMeetings.TranscribeMedicalType")]
        public Amazon.ChimeSDKMeetings.TranscribeMedicalType EngineTranscribeMedicalSettings_Type { get; set; }
        #endregion
        
        #region Parameter EngineTranscribeSettings_VocabularyFilterMethod
        /// <summary>
        /// <para>
        /// <para>The filtering method passed to Amazon Transcribe.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TranscriptionConfiguration_EngineTranscribeSettings_VocabularyFilterMethod")]
        [AWSConstantClassSource("Amazon.ChimeSDKMeetings.TranscribeVocabularyFilterMethod")]
        public Amazon.ChimeSDKMeetings.TranscribeVocabularyFilterMethod EngineTranscribeSettings_VocabularyFilterMethod { get; set; }
        #endregion
        
        #region Parameter EngineTranscribeSettings_VocabularyFilterName
        /// <summary>
        /// <para>
        /// <para>The name of the vocabulary filter passed to Amazon Transcribe.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TranscriptionConfiguration_EngineTranscribeSettings_VocabularyFilterName")]
        public System.String EngineTranscribeSettings_VocabularyFilterName { get; set; }
        #endregion
        
        #region Parameter EngineTranscribeMedicalSettings_VocabularyName
        /// <summary>
        /// <para>
        /// <para>The name of the vocabulary passed to Amazon Transcribe Medical.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TranscriptionConfiguration_EngineTranscribeMedicalSettings_VocabularyName")]
        public System.String EngineTranscribeMedicalSettings_VocabularyName { get; set; }
        #endregion
        
        #region Parameter EngineTranscribeSettings_VocabularyName
        /// <summary>
        /// <para>
        /// <para>The name of the vocabulary passed to Amazon Transcribe.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TranscriptionConfiguration_EngineTranscribeSettings_VocabularyName")]
        public System.String EngineTranscribeSettings_VocabularyName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKMeetings.Model.StartMeetingTranscriptionResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the MeetingId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^MeetingId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^MeetingId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MeetingId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CHMTGMeetingTranscription (StartMeetingTranscription)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKMeetings.Model.StartMeetingTranscriptionResponse, StartCHMTGMeetingTranscriptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.MeetingId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.MeetingId = this.MeetingId;
            #if MODULAR
            if (this.MeetingId == null && ParameterWasBound(nameof(this.MeetingId)))
            {
                WriteWarning("You are passing $null as a value for parameter MeetingId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EngineTranscribeMedicalSettings_ContentIdentificationType = this.EngineTranscribeMedicalSettings_ContentIdentificationType;
            context.EngineTranscribeMedicalSettings_LanguageCode = this.EngineTranscribeMedicalSettings_LanguageCode;
            context.EngineTranscribeMedicalSettings_Region = this.EngineTranscribeMedicalSettings_Region;
            context.EngineTranscribeMedicalSettings_Specialty = this.EngineTranscribeMedicalSettings_Specialty;
            context.EngineTranscribeMedicalSettings_Type = this.EngineTranscribeMedicalSettings_Type;
            context.EngineTranscribeMedicalSettings_VocabularyName = this.EngineTranscribeMedicalSettings_VocabularyName;
            context.EngineTranscribeSettings_ContentIdentificationType = this.EngineTranscribeSettings_ContentIdentificationType;
            context.EngineTranscribeSettings_ContentRedactionType = this.EngineTranscribeSettings_ContentRedactionType;
            context.EngineTranscribeSettings_EnablePartialResultsStabilization = this.EngineTranscribeSettings_EnablePartialResultsStabilization;
            context.EngineTranscribeSettings_IdentifyLanguage = this.EngineTranscribeSettings_IdentifyLanguage;
            context.EngineTranscribeSettings_LanguageCode = this.EngineTranscribeSettings_LanguageCode;
            context.EngineTranscribeSettings_LanguageModelName = this.EngineTranscribeSettings_LanguageModelName;
            context.EngineTranscribeSettings_LanguageOption = this.EngineTranscribeSettings_LanguageOption;
            context.EngineTranscribeSettings_PartialResultsStability = this.EngineTranscribeSettings_PartialResultsStability;
            context.EngineTranscribeSettings_PiiEntityType = this.EngineTranscribeSettings_PiiEntityType;
            context.EngineTranscribeSettings_PreferredLanguage = this.EngineTranscribeSettings_PreferredLanguage;
            context.EngineTranscribeSettings_Region = this.EngineTranscribeSettings_Region;
            context.EngineTranscribeSettings_VocabularyFilterMethod = this.EngineTranscribeSettings_VocabularyFilterMethod;
            context.EngineTranscribeSettings_VocabularyFilterName = this.EngineTranscribeSettings_VocabularyFilterName;
            context.EngineTranscribeSettings_VocabularyName = this.EngineTranscribeSettings_VocabularyName;
            
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
            var request = new Amazon.ChimeSDKMeetings.Model.StartMeetingTranscriptionRequest();
            
            if (cmdletContext.MeetingId != null)
            {
                request.MeetingId = cmdletContext.MeetingId;
            }
            
             // populate TranscriptionConfiguration
            var requestTranscriptionConfigurationIsNull = true;
            request.TranscriptionConfiguration = new Amazon.ChimeSDKMeetings.Model.TranscriptionConfiguration();
            Amazon.ChimeSDKMeetings.Model.EngineTranscribeMedicalSettings requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettings = null;
            
             // populate EngineTranscribeMedicalSettings
            var requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettingsIsNull = true;
            requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettings = new Amazon.ChimeSDKMeetings.Model.EngineTranscribeMedicalSettings();
            Amazon.ChimeSDKMeetings.TranscribeMedicalContentIdentificationType requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettings_engineTranscribeMedicalSettings_ContentIdentificationType = null;
            if (cmdletContext.EngineTranscribeMedicalSettings_ContentIdentificationType != null)
            {
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettings_engineTranscribeMedicalSettings_ContentIdentificationType = cmdletContext.EngineTranscribeMedicalSettings_ContentIdentificationType;
            }
            if (requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettings_engineTranscribeMedicalSettings_ContentIdentificationType != null)
            {
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettings.ContentIdentificationType = requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettings_engineTranscribeMedicalSettings_ContentIdentificationType;
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettingsIsNull = false;
            }
            Amazon.ChimeSDKMeetings.TranscribeMedicalLanguageCode requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettings_engineTranscribeMedicalSettings_LanguageCode = null;
            if (cmdletContext.EngineTranscribeMedicalSettings_LanguageCode != null)
            {
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettings_engineTranscribeMedicalSettings_LanguageCode = cmdletContext.EngineTranscribeMedicalSettings_LanguageCode;
            }
            if (requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettings_engineTranscribeMedicalSettings_LanguageCode != null)
            {
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettings.LanguageCode = requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettings_engineTranscribeMedicalSettings_LanguageCode;
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettingsIsNull = false;
            }
            Amazon.ChimeSDKMeetings.TranscribeMedicalRegion requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettings_engineTranscribeMedicalSettings_Region = null;
            if (cmdletContext.EngineTranscribeMedicalSettings_Region != null)
            {
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettings_engineTranscribeMedicalSettings_Region = cmdletContext.EngineTranscribeMedicalSettings_Region;
            }
            if (requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettings_engineTranscribeMedicalSettings_Region != null)
            {
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettings.Region = requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettings_engineTranscribeMedicalSettings_Region;
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettingsIsNull = false;
            }
            Amazon.ChimeSDKMeetings.TranscribeMedicalSpecialty requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettings_engineTranscribeMedicalSettings_Specialty = null;
            if (cmdletContext.EngineTranscribeMedicalSettings_Specialty != null)
            {
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettings_engineTranscribeMedicalSettings_Specialty = cmdletContext.EngineTranscribeMedicalSettings_Specialty;
            }
            if (requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettings_engineTranscribeMedicalSettings_Specialty != null)
            {
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettings.Specialty = requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettings_engineTranscribeMedicalSettings_Specialty;
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettingsIsNull = false;
            }
            Amazon.ChimeSDKMeetings.TranscribeMedicalType requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettings_engineTranscribeMedicalSettings_Type = null;
            if (cmdletContext.EngineTranscribeMedicalSettings_Type != null)
            {
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettings_engineTranscribeMedicalSettings_Type = cmdletContext.EngineTranscribeMedicalSettings_Type;
            }
            if (requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettings_engineTranscribeMedicalSettings_Type != null)
            {
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettings.Type = requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettings_engineTranscribeMedicalSettings_Type;
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettingsIsNull = false;
            }
            System.String requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettings_engineTranscribeMedicalSettings_VocabularyName = null;
            if (cmdletContext.EngineTranscribeMedicalSettings_VocabularyName != null)
            {
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettings_engineTranscribeMedicalSettings_VocabularyName = cmdletContext.EngineTranscribeMedicalSettings_VocabularyName;
            }
            if (requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettings_engineTranscribeMedicalSettings_VocabularyName != null)
            {
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettings.VocabularyName = requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettings_engineTranscribeMedicalSettings_VocabularyName;
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettingsIsNull = false;
            }
             // determine if requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettings should be set to null
            if (requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettingsIsNull)
            {
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettings = null;
            }
            if (requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettings != null)
            {
                request.TranscriptionConfiguration.EngineTranscribeMedicalSettings = requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeMedicalSettings;
                requestTranscriptionConfigurationIsNull = false;
            }
            Amazon.ChimeSDKMeetings.Model.EngineTranscribeSettings requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings = null;
            
             // populate EngineTranscribeSettings
            var requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettingsIsNull = true;
            requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings = new Amazon.ChimeSDKMeetings.Model.EngineTranscribeSettings();
            Amazon.ChimeSDKMeetings.TranscribeContentIdentificationType requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_ContentIdentificationType = null;
            if (cmdletContext.EngineTranscribeSettings_ContentIdentificationType != null)
            {
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_ContentIdentificationType = cmdletContext.EngineTranscribeSettings_ContentIdentificationType;
            }
            if (requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_ContentIdentificationType != null)
            {
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings.ContentIdentificationType = requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_ContentIdentificationType;
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettingsIsNull = false;
            }
            Amazon.ChimeSDKMeetings.TranscribeContentRedactionType requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_ContentRedactionType = null;
            if (cmdletContext.EngineTranscribeSettings_ContentRedactionType != null)
            {
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_ContentRedactionType = cmdletContext.EngineTranscribeSettings_ContentRedactionType;
            }
            if (requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_ContentRedactionType != null)
            {
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings.ContentRedactionType = requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_ContentRedactionType;
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettingsIsNull = false;
            }
            System.Boolean? requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_EnablePartialResultsStabilization = null;
            if (cmdletContext.EngineTranscribeSettings_EnablePartialResultsStabilization != null)
            {
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_EnablePartialResultsStabilization = cmdletContext.EngineTranscribeSettings_EnablePartialResultsStabilization.Value;
            }
            if (requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_EnablePartialResultsStabilization != null)
            {
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings.EnablePartialResultsStabilization = requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_EnablePartialResultsStabilization.Value;
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettingsIsNull = false;
            }
            System.Boolean? requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_IdentifyLanguage = null;
            if (cmdletContext.EngineTranscribeSettings_IdentifyLanguage != null)
            {
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_IdentifyLanguage = cmdletContext.EngineTranscribeSettings_IdentifyLanguage.Value;
            }
            if (requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_IdentifyLanguage != null)
            {
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings.IdentifyLanguage = requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_IdentifyLanguage.Value;
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettingsIsNull = false;
            }
            Amazon.ChimeSDKMeetings.TranscribeLanguageCode requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_LanguageCode = null;
            if (cmdletContext.EngineTranscribeSettings_LanguageCode != null)
            {
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_LanguageCode = cmdletContext.EngineTranscribeSettings_LanguageCode;
            }
            if (requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_LanguageCode != null)
            {
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings.LanguageCode = requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_LanguageCode;
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettingsIsNull = false;
            }
            System.String requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_LanguageModelName = null;
            if (cmdletContext.EngineTranscribeSettings_LanguageModelName != null)
            {
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_LanguageModelName = cmdletContext.EngineTranscribeSettings_LanguageModelName;
            }
            if (requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_LanguageModelName != null)
            {
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings.LanguageModelName = requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_LanguageModelName;
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettingsIsNull = false;
            }
            System.String requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_LanguageOption = null;
            if (cmdletContext.EngineTranscribeSettings_LanguageOption != null)
            {
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_LanguageOption = cmdletContext.EngineTranscribeSettings_LanguageOption;
            }
            if (requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_LanguageOption != null)
            {
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings.LanguageOptions = requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_LanguageOption;
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettingsIsNull = false;
            }
            Amazon.ChimeSDKMeetings.TranscribePartialResultsStability requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_PartialResultsStability = null;
            if (cmdletContext.EngineTranscribeSettings_PartialResultsStability != null)
            {
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_PartialResultsStability = cmdletContext.EngineTranscribeSettings_PartialResultsStability;
            }
            if (requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_PartialResultsStability != null)
            {
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings.PartialResultsStability = requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_PartialResultsStability;
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettingsIsNull = false;
            }
            System.String requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_PiiEntityType = null;
            if (cmdletContext.EngineTranscribeSettings_PiiEntityType != null)
            {
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_PiiEntityType = cmdletContext.EngineTranscribeSettings_PiiEntityType;
            }
            if (requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_PiiEntityType != null)
            {
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings.PiiEntityTypes = requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_PiiEntityType;
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettingsIsNull = false;
            }
            Amazon.ChimeSDKMeetings.TranscribeLanguageCode requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_PreferredLanguage = null;
            if (cmdletContext.EngineTranscribeSettings_PreferredLanguage != null)
            {
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_PreferredLanguage = cmdletContext.EngineTranscribeSettings_PreferredLanguage;
            }
            if (requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_PreferredLanguage != null)
            {
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings.PreferredLanguage = requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_PreferredLanguage;
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettingsIsNull = false;
            }
            Amazon.ChimeSDKMeetings.TranscribeRegion requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_Region = null;
            if (cmdletContext.EngineTranscribeSettings_Region != null)
            {
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_Region = cmdletContext.EngineTranscribeSettings_Region;
            }
            if (requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_Region != null)
            {
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings.Region = requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_Region;
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettingsIsNull = false;
            }
            Amazon.ChimeSDKMeetings.TranscribeVocabularyFilterMethod requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_VocabularyFilterMethod = null;
            if (cmdletContext.EngineTranscribeSettings_VocabularyFilterMethod != null)
            {
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_VocabularyFilterMethod = cmdletContext.EngineTranscribeSettings_VocabularyFilterMethod;
            }
            if (requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_VocabularyFilterMethod != null)
            {
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings.VocabularyFilterMethod = requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_VocabularyFilterMethod;
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettingsIsNull = false;
            }
            System.String requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_VocabularyFilterName = null;
            if (cmdletContext.EngineTranscribeSettings_VocabularyFilterName != null)
            {
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_VocabularyFilterName = cmdletContext.EngineTranscribeSettings_VocabularyFilterName;
            }
            if (requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_VocabularyFilterName != null)
            {
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings.VocabularyFilterName = requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_VocabularyFilterName;
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettingsIsNull = false;
            }
            System.String requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_VocabularyName = null;
            if (cmdletContext.EngineTranscribeSettings_VocabularyName != null)
            {
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_VocabularyName = cmdletContext.EngineTranscribeSettings_VocabularyName;
            }
            if (requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_VocabularyName != null)
            {
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings.VocabularyName = requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings_engineTranscribeSettings_VocabularyName;
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettingsIsNull = false;
            }
             // determine if requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings should be set to null
            if (requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettingsIsNull)
            {
                requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings = null;
            }
            if (requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings != null)
            {
                request.TranscriptionConfiguration.EngineTranscribeSettings = requestTranscriptionConfiguration_transcriptionConfiguration_EngineTranscribeSettings;
                requestTranscriptionConfigurationIsNull = false;
            }
             // determine if request.TranscriptionConfiguration should be set to null
            if (requestTranscriptionConfigurationIsNull)
            {
                request.TranscriptionConfiguration = null;
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
        
        private Amazon.ChimeSDKMeetings.Model.StartMeetingTranscriptionResponse CallAWSServiceOperation(IAmazonChimeSDKMeetings client, Amazon.ChimeSDKMeetings.Model.StartMeetingTranscriptionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Meetings", "StartMeetingTranscription");
            try
            {
                #if DESKTOP
                return client.StartMeetingTranscription(request);
                #elif CORECLR
                return client.StartMeetingTranscriptionAsync(request).GetAwaiter().GetResult();
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
            public System.String MeetingId { get; set; }
            public Amazon.ChimeSDKMeetings.TranscribeMedicalContentIdentificationType EngineTranscribeMedicalSettings_ContentIdentificationType { get; set; }
            public Amazon.ChimeSDKMeetings.TranscribeMedicalLanguageCode EngineTranscribeMedicalSettings_LanguageCode { get; set; }
            public Amazon.ChimeSDKMeetings.TranscribeMedicalRegion EngineTranscribeMedicalSettings_Region { get; set; }
            public Amazon.ChimeSDKMeetings.TranscribeMedicalSpecialty EngineTranscribeMedicalSettings_Specialty { get; set; }
            public Amazon.ChimeSDKMeetings.TranscribeMedicalType EngineTranscribeMedicalSettings_Type { get; set; }
            public System.String EngineTranscribeMedicalSettings_VocabularyName { get; set; }
            public Amazon.ChimeSDKMeetings.TranscribeContentIdentificationType EngineTranscribeSettings_ContentIdentificationType { get; set; }
            public Amazon.ChimeSDKMeetings.TranscribeContentRedactionType EngineTranscribeSettings_ContentRedactionType { get; set; }
            public System.Boolean? EngineTranscribeSettings_EnablePartialResultsStabilization { get; set; }
            public System.Boolean? EngineTranscribeSettings_IdentifyLanguage { get; set; }
            public Amazon.ChimeSDKMeetings.TranscribeLanguageCode EngineTranscribeSettings_LanguageCode { get; set; }
            public System.String EngineTranscribeSettings_LanguageModelName { get; set; }
            public System.String EngineTranscribeSettings_LanguageOption { get; set; }
            public Amazon.ChimeSDKMeetings.TranscribePartialResultsStability EngineTranscribeSettings_PartialResultsStability { get; set; }
            public System.String EngineTranscribeSettings_PiiEntityType { get; set; }
            public Amazon.ChimeSDKMeetings.TranscribeLanguageCode EngineTranscribeSettings_PreferredLanguage { get; set; }
            public Amazon.ChimeSDKMeetings.TranscribeRegion EngineTranscribeSettings_Region { get; set; }
            public Amazon.ChimeSDKMeetings.TranscribeVocabularyFilterMethod EngineTranscribeSettings_VocabularyFilterMethod { get; set; }
            public System.String EngineTranscribeSettings_VocabularyFilterName { get; set; }
            public System.String EngineTranscribeSettings_VocabularyName { get; set; }
            public System.Func<Amazon.ChimeSDKMeetings.Model.StartMeetingTranscriptionResponse, StartCHMTGMeetingTranscriptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
