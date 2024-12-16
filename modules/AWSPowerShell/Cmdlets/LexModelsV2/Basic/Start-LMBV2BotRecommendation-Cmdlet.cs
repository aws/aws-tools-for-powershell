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
using Amazon.LexModelsV2;
using Amazon.LexModelsV2.Model;

namespace Amazon.PowerShell.Cmdlets.LMBV2
{
    /// <summary>
    /// Use this to provide your transcript data, and to start the bot recommendation process.
    /// </summary>
    [Cmdlet("Start", "LMBV2BotRecommendation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LexModelsV2.Model.StartBotRecommendationResponse")]
    [AWSCmdlet("Calls the Amazon Lex Model Building V2 StartBotRecommendation API operation.", Operation = new[] {"StartBotRecommendation"}, SelectReturnType = typeof(Amazon.LexModelsV2.Model.StartBotRecommendationResponse))]
    [AWSCmdletOutput("Amazon.LexModelsV2.Model.StartBotRecommendationResponse",
        "This cmdlet returns an Amazon.LexModelsV2.Model.StartBotRecommendationResponse object containing multiple properties."
    )]
    public partial class StartLMBV2BotRecommendationCmdlet : AmazonLexModelsV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EncryptionSetting_AssociatedTranscriptsPassword
        /// <summary>
        /// <para>
        /// <para>The password used to encrypt the associated transcript file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionSetting_AssociatedTranscriptsPassword { get; set; }
        #endregion
        
        #region Parameter BotId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the bot containing the bot recommendation.</para>
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
        public System.String BotId { get; set; }
        #endregion
        
        #region Parameter EncryptionSetting_BotLocaleExportPassword
        /// <summary>
        /// <para>
        /// <para>The password used to encrypt the recommended bot recommendation file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionSetting_BotLocaleExportPassword { get; set; }
        #endregion
        
        #region Parameter BotVersion
        /// <summary>
        /// <para>
        /// <para>The version of the bot containing the bot recommendation.</para>
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
        public System.String BotVersion { get; set; }
        #endregion
        
        #region Parameter DateRangeFilter_EndDateTime
        /// <summary>
        /// <para>
        /// <para>A timestamp indicating the end date for the date range filter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TranscriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter_DateRangeFilter_EndDateTime")]
        public System.DateTime? DateRangeFilter_EndDateTime { get; set; }
        #endregion
        
        #region Parameter EncryptionSetting_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The KMS key ARN used to encrypt the metadata associated with the bot recommendation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionSetting_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter S3BucketTranscriptSource_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the KMS key that customer use to encrypt their Amazon S3 bucket. Only use
        /// this field if your bucket is encrypted using a customer managed KMS key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TranscriptSourceSetting_S3BucketTranscriptSource_KmsKeyArn")]
        public System.String S3BucketTranscriptSource_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter LocaleId
        /// <summary>
        /// <para>
        /// <para>The identifier of the language and locale of the bot recommendation to start. The
        /// string must match one of the supported locales. For more information, see <a href="https://docs.aws.amazon.com/lexv2/latest/dg/how-languages.html">Supported
        /// languages</a></para>
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
        public System.String LocaleId { get; set; }
        #endregion
        
        #region Parameter PathFormat_ObjectPrefix
        /// <summary>
        /// <para>
        /// <para>A list of Amazon S3 prefixes that points to sub-folders in the Amazon S3 bucket. Specify
        /// this list if you only want Lex to read the files under this set of sub-folders.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TranscriptSourceSetting_S3BucketTranscriptSource_PathFormat_ObjectPrefixes")]
        public System.String[] PathFormat_ObjectPrefix { get; set; }
        #endregion
        
        #region Parameter S3BucketTranscriptSource_S3BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the bucket containing the transcript and the associated metadata.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TranscriptSourceSetting_S3BucketTranscriptSource_S3BucketName")]
        public System.String S3BucketTranscriptSource_S3BucketName { get; set; }
        #endregion
        
        #region Parameter DateRangeFilter_StartDateTime
        /// <summary>
        /// <para>
        /// <para>A timestamp indicating the start date for the date range filter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TranscriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter_DateRangeFilter_StartDateTime")]
        public System.DateTime? DateRangeFilter_StartDateTime { get; set; }
        #endregion
        
        #region Parameter S3BucketTranscriptSource_TranscriptFormat
        /// <summary>
        /// <para>
        /// <para>The format of the transcript content. Currently, Genie only supports the Amazon Lex
        /// transcript format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TranscriptSourceSetting_S3BucketTranscriptSource_TranscriptFormat")]
        [AWSConstantClassSource("Amazon.LexModelsV2.TranscriptFormat")]
        public Amazon.LexModelsV2.TranscriptFormat S3BucketTranscriptSource_TranscriptFormat { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LexModelsV2.Model.StartBotRecommendationResponse).
        /// Specifying the name of a property of type Amazon.LexModelsV2.Model.StartBotRecommendationResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LocaleId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-LMBV2BotRecommendation (StartBotRecommendation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LexModelsV2.Model.StartBotRecommendationResponse, StartLMBV2BotRecommendationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BotId = this.BotId;
            #if MODULAR
            if (this.BotId == null && ParameterWasBound(nameof(this.BotId)))
            {
                WriteWarning("You are passing $null as a value for parameter BotId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BotVersion = this.BotVersion;
            #if MODULAR
            if (this.BotVersion == null && ParameterWasBound(nameof(this.BotVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter BotVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EncryptionSetting_AssociatedTranscriptsPassword = this.EncryptionSetting_AssociatedTranscriptsPassword;
            context.EncryptionSetting_BotLocaleExportPassword = this.EncryptionSetting_BotLocaleExportPassword;
            context.EncryptionSetting_KmsKeyArn = this.EncryptionSetting_KmsKeyArn;
            context.LocaleId = this.LocaleId;
            #if MODULAR
            if (this.LocaleId == null && ParameterWasBound(nameof(this.LocaleId)))
            {
                WriteWarning("You are passing $null as a value for parameter LocaleId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3BucketTranscriptSource_KmsKeyArn = this.S3BucketTranscriptSource_KmsKeyArn;
            if (this.PathFormat_ObjectPrefix != null)
            {
                context.PathFormat_ObjectPrefix = new List<System.String>(this.PathFormat_ObjectPrefix);
            }
            context.S3BucketTranscriptSource_S3BucketName = this.S3BucketTranscriptSource_S3BucketName;
            context.DateRangeFilter_EndDateTime = this.DateRangeFilter_EndDateTime;
            context.DateRangeFilter_StartDateTime = this.DateRangeFilter_StartDateTime;
            context.S3BucketTranscriptSource_TranscriptFormat = this.S3BucketTranscriptSource_TranscriptFormat;
            
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
            var request = new Amazon.LexModelsV2.Model.StartBotRecommendationRequest();
            
            if (cmdletContext.BotId != null)
            {
                request.BotId = cmdletContext.BotId;
            }
            if (cmdletContext.BotVersion != null)
            {
                request.BotVersion = cmdletContext.BotVersion;
            }
            
             // populate EncryptionSetting
            var requestEncryptionSettingIsNull = true;
            request.EncryptionSetting = new Amazon.LexModelsV2.Model.EncryptionSetting();
            System.String requestEncryptionSetting_encryptionSetting_AssociatedTranscriptsPassword = null;
            if (cmdletContext.EncryptionSetting_AssociatedTranscriptsPassword != null)
            {
                requestEncryptionSetting_encryptionSetting_AssociatedTranscriptsPassword = cmdletContext.EncryptionSetting_AssociatedTranscriptsPassword;
            }
            if (requestEncryptionSetting_encryptionSetting_AssociatedTranscriptsPassword != null)
            {
                request.EncryptionSetting.AssociatedTranscriptsPassword = requestEncryptionSetting_encryptionSetting_AssociatedTranscriptsPassword;
                requestEncryptionSettingIsNull = false;
            }
            System.String requestEncryptionSetting_encryptionSetting_BotLocaleExportPassword = null;
            if (cmdletContext.EncryptionSetting_BotLocaleExportPassword != null)
            {
                requestEncryptionSetting_encryptionSetting_BotLocaleExportPassword = cmdletContext.EncryptionSetting_BotLocaleExportPassword;
            }
            if (requestEncryptionSetting_encryptionSetting_BotLocaleExportPassword != null)
            {
                request.EncryptionSetting.BotLocaleExportPassword = requestEncryptionSetting_encryptionSetting_BotLocaleExportPassword;
                requestEncryptionSettingIsNull = false;
            }
            System.String requestEncryptionSetting_encryptionSetting_KmsKeyArn = null;
            if (cmdletContext.EncryptionSetting_KmsKeyArn != null)
            {
                requestEncryptionSetting_encryptionSetting_KmsKeyArn = cmdletContext.EncryptionSetting_KmsKeyArn;
            }
            if (requestEncryptionSetting_encryptionSetting_KmsKeyArn != null)
            {
                request.EncryptionSetting.KmsKeyArn = requestEncryptionSetting_encryptionSetting_KmsKeyArn;
                requestEncryptionSettingIsNull = false;
            }
             // determine if request.EncryptionSetting should be set to null
            if (requestEncryptionSettingIsNull)
            {
                request.EncryptionSetting = null;
            }
            if (cmdletContext.LocaleId != null)
            {
                request.LocaleId = cmdletContext.LocaleId;
            }
            
             // populate TranscriptSourceSetting
            var requestTranscriptSourceSettingIsNull = true;
            request.TranscriptSourceSetting = new Amazon.LexModelsV2.Model.TranscriptSourceSetting();
            Amazon.LexModelsV2.Model.S3BucketTranscriptSource requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource = null;
            
             // populate S3BucketTranscriptSource
            var requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSourceIsNull = true;
            requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource = new Amazon.LexModelsV2.Model.S3BucketTranscriptSource();
            System.String requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_s3BucketTranscriptSource_KmsKeyArn = null;
            if (cmdletContext.S3BucketTranscriptSource_KmsKeyArn != null)
            {
                requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_s3BucketTranscriptSource_KmsKeyArn = cmdletContext.S3BucketTranscriptSource_KmsKeyArn;
            }
            if (requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_s3BucketTranscriptSource_KmsKeyArn != null)
            {
                requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource.KmsKeyArn = requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_s3BucketTranscriptSource_KmsKeyArn;
                requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSourceIsNull = false;
            }
            System.String requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_s3BucketTranscriptSource_S3BucketName = null;
            if (cmdletContext.S3BucketTranscriptSource_S3BucketName != null)
            {
                requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_s3BucketTranscriptSource_S3BucketName = cmdletContext.S3BucketTranscriptSource_S3BucketName;
            }
            if (requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_s3BucketTranscriptSource_S3BucketName != null)
            {
                requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource.S3BucketName = requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_s3BucketTranscriptSource_S3BucketName;
                requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSourceIsNull = false;
            }
            Amazon.LexModelsV2.TranscriptFormat requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_s3BucketTranscriptSource_TranscriptFormat = null;
            if (cmdletContext.S3BucketTranscriptSource_TranscriptFormat != null)
            {
                requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_s3BucketTranscriptSource_TranscriptFormat = cmdletContext.S3BucketTranscriptSource_TranscriptFormat;
            }
            if (requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_s3BucketTranscriptSource_TranscriptFormat != null)
            {
                requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource.TranscriptFormat = requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_s3BucketTranscriptSource_TranscriptFormat;
                requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSourceIsNull = false;
            }
            Amazon.LexModelsV2.Model.PathFormat requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_PathFormat = null;
            
             // populate PathFormat
            var requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_PathFormatIsNull = true;
            requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_PathFormat = new Amazon.LexModelsV2.Model.PathFormat();
            List<System.String> requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_PathFormat_pathFormat_ObjectPrefix = null;
            if (cmdletContext.PathFormat_ObjectPrefix != null)
            {
                requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_PathFormat_pathFormat_ObjectPrefix = cmdletContext.PathFormat_ObjectPrefix;
            }
            if (requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_PathFormat_pathFormat_ObjectPrefix != null)
            {
                requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_PathFormat.ObjectPrefixes = requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_PathFormat_pathFormat_ObjectPrefix;
                requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_PathFormatIsNull = false;
            }
             // determine if requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_PathFormat should be set to null
            if (requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_PathFormatIsNull)
            {
                requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_PathFormat = null;
            }
            if (requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_PathFormat != null)
            {
                requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource.PathFormat = requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_PathFormat;
                requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSourceIsNull = false;
            }
            Amazon.LexModelsV2.Model.TranscriptFilter requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter = null;
            
             // populate TranscriptFilter
            var requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilterIsNull = true;
            requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter = new Amazon.LexModelsV2.Model.TranscriptFilter();
            Amazon.LexModelsV2.Model.LexTranscriptFilter requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter = null;
            
             // populate LexTranscriptFilter
            var requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilterIsNull = true;
            requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter = new Amazon.LexModelsV2.Model.LexTranscriptFilter();
            Amazon.LexModelsV2.Model.DateRangeFilter requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter_DateRangeFilter = null;
            
             // populate DateRangeFilter
            var requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter_DateRangeFilterIsNull = true;
            requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter_DateRangeFilter = new Amazon.LexModelsV2.Model.DateRangeFilter();
            System.DateTime? requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter_DateRangeFilter_dateRangeFilter_EndDateTime = null;
            if (cmdletContext.DateRangeFilter_EndDateTime != null)
            {
                requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter_DateRangeFilter_dateRangeFilter_EndDateTime = cmdletContext.DateRangeFilter_EndDateTime.Value;
            }
            if (requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter_DateRangeFilter_dateRangeFilter_EndDateTime != null)
            {
                requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter_DateRangeFilter.EndDateTime = requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter_DateRangeFilter_dateRangeFilter_EndDateTime.Value;
                requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter_DateRangeFilterIsNull = false;
            }
            System.DateTime? requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter_DateRangeFilter_dateRangeFilter_StartDateTime = null;
            if (cmdletContext.DateRangeFilter_StartDateTime != null)
            {
                requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter_DateRangeFilter_dateRangeFilter_StartDateTime = cmdletContext.DateRangeFilter_StartDateTime.Value;
            }
            if (requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter_DateRangeFilter_dateRangeFilter_StartDateTime != null)
            {
                requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter_DateRangeFilter.StartDateTime = requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter_DateRangeFilter_dateRangeFilter_StartDateTime.Value;
                requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter_DateRangeFilterIsNull = false;
            }
             // determine if requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter_DateRangeFilter should be set to null
            if (requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter_DateRangeFilterIsNull)
            {
                requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter_DateRangeFilter = null;
            }
            if (requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter_DateRangeFilter != null)
            {
                requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter.DateRangeFilter = requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter_DateRangeFilter;
                requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilterIsNull = false;
            }
             // determine if requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter should be set to null
            if (requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilterIsNull)
            {
                requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter = null;
            }
            if (requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter != null)
            {
                requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter.LexTranscriptFilter = requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter_LexTranscriptFilter;
                requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilterIsNull = false;
            }
             // determine if requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter should be set to null
            if (requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilterIsNull)
            {
                requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter = null;
            }
            if (requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter != null)
            {
                requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource.TranscriptFilter = requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource_transcriptSourceSetting_S3BucketTranscriptSource_TranscriptFilter;
                requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSourceIsNull = false;
            }
             // determine if requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource should be set to null
            if (requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSourceIsNull)
            {
                requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource = null;
            }
            if (requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource != null)
            {
                request.TranscriptSourceSetting.S3BucketTranscriptSource = requestTranscriptSourceSetting_transcriptSourceSetting_S3BucketTranscriptSource;
                requestTranscriptSourceSettingIsNull = false;
            }
             // determine if request.TranscriptSourceSetting should be set to null
            if (requestTranscriptSourceSettingIsNull)
            {
                request.TranscriptSourceSetting = null;
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
        
        private Amazon.LexModelsV2.Model.StartBotRecommendationResponse CallAWSServiceOperation(IAmazonLexModelsV2 client, Amazon.LexModelsV2.Model.StartBotRecommendationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lex Model Building V2", "StartBotRecommendation");
            try
            {
                #if DESKTOP
                return client.StartBotRecommendation(request);
                #elif CORECLR
                return client.StartBotRecommendationAsync(request).GetAwaiter().GetResult();
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
            public System.String BotId { get; set; }
            public System.String BotVersion { get; set; }
            public System.String EncryptionSetting_AssociatedTranscriptsPassword { get; set; }
            public System.String EncryptionSetting_BotLocaleExportPassword { get; set; }
            public System.String EncryptionSetting_KmsKeyArn { get; set; }
            public System.String LocaleId { get; set; }
            public System.String S3BucketTranscriptSource_KmsKeyArn { get; set; }
            public List<System.String> PathFormat_ObjectPrefix { get; set; }
            public System.String S3BucketTranscriptSource_S3BucketName { get; set; }
            public System.DateTime? DateRangeFilter_EndDateTime { get; set; }
            public System.DateTime? DateRangeFilter_StartDateTime { get; set; }
            public Amazon.LexModelsV2.TranscriptFormat S3BucketTranscriptSource_TranscriptFormat { get; set; }
            public System.Func<Amazon.LexModelsV2.Model.StartBotRecommendationResponse, StartLMBV2BotRecommendationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
