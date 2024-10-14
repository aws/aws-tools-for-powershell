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
    /// Creates an alias for the specified version of a bot. Use an alias to enable you to
    /// change the version of a bot without updating applications that use the bot.
    /// 
    ///  
    /// <para>
    /// For example, you can create an alias called "PROD" that your applications use to call
    /// the Amazon Lex bot. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "LMBV2BotAlias", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LexModelsV2.Model.CreateBotAliasResponse")]
    [AWSCmdlet("Calls the Amazon Lex Model Building V2 CreateBotAlias API operation.", Operation = new[] {"CreateBotAlias"}, SelectReturnType = typeof(Amazon.LexModelsV2.Model.CreateBotAliasResponse))]
    [AWSCmdletOutput("Amazon.LexModelsV2.Model.CreateBotAliasResponse",
        "This cmdlet returns an Amazon.LexModelsV2.Model.CreateBotAliasResponse object containing multiple properties."
    )]
    public partial class NewLMBV2BotAliasCmdlet : AmazonLexModelsV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConversationLogSettings_AudioLogSetting
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 settings for logging audio to an S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConversationLogSettings_AudioLogSettings")]
        public Amazon.LexModelsV2.Model.AudioLogSetting[] ConversationLogSettings_AudioLogSetting { get; set; }
        #endregion
        
        #region Parameter BotAliasLocaleSetting
        /// <summary>
        /// <para>
        /// <para>Maps configuration information to a specific locale. You can use this parameter to
        /// specify a specific Lambda function to run different functions in different locales.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BotAliasLocaleSettings")]
        public System.Collections.Hashtable BotAliasLocaleSetting { get; set; }
        #endregion
        
        #region Parameter BotAliasName
        /// <summary>
        /// <para>
        /// <para>The alias to create. The name must be unique for the bot.</para>
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
        public System.String BotAliasName { get; set; }
        #endregion
        
        #region Parameter BotId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the bot that the alias applies to.</para>
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
        
        #region Parameter BotVersion
        /// <summary>
        /// <para>
        /// <para>The version of the bot that this alias points to. You can use the <a href="https://docs.aws.amazon.com/lexv2/latest/APIReference/API_UpdateBotAlias.html">UpdateBotAlias</a>
        /// operation to change the bot version associated with the alias.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BotVersion { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the alias. Use this description to help identify the alias.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter SentimentAnalysisSettings_DetectSentiment
        /// <summary>
        /// <para>
        /// <para>Sets whether Amazon Lex uses Amazon Comprehend to detect the sentiment of user utterances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SentimentAnalysisSettings_DetectSentiment { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags to add to the bot alias. You can only add tags when you create an alias,
        /// you can't use the <c>UpdateBotAlias</c> operation to update the tags on a bot alias.
        /// To update tags, use the <c>TagResource</c> operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ConversationLogSettings_TextLogSetting
        /// <summary>
        /// <para>
        /// <para>The Amazon CloudWatch Logs settings for logging text and metadata.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConversationLogSettings_TextLogSettings")]
        public Amazon.LexModelsV2.Model.TextLogSetting[] ConversationLogSettings_TextLogSetting { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LexModelsV2.Model.CreateBotAliasResponse).
        /// Specifying the name of a property of type Amazon.LexModelsV2.Model.CreateBotAliasResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the BotAliasName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^BotAliasName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^BotAliasName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BotAliasName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LMBV2BotAlias (CreateBotAlias)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LexModelsV2.Model.CreateBotAliasResponse, NewLMBV2BotAliasCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.BotAliasName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.BotAliasLocaleSetting != null)
            {
                context.BotAliasLocaleSetting = new Dictionary<System.String, Amazon.LexModelsV2.Model.BotAliasLocaleSettings>(StringComparer.Ordinal);
                foreach (var hashKey in this.BotAliasLocaleSetting.Keys)
                {
                    context.BotAliasLocaleSetting.Add((String)hashKey, (Amazon.LexModelsV2.Model.BotAliasLocaleSettings)(this.BotAliasLocaleSetting[hashKey]));
                }
            }
            context.BotAliasName = this.BotAliasName;
            #if MODULAR
            if (this.BotAliasName == null && ParameterWasBound(nameof(this.BotAliasName)))
            {
                WriteWarning("You are passing $null as a value for parameter BotAliasName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BotId = this.BotId;
            #if MODULAR
            if (this.BotId == null && ParameterWasBound(nameof(this.BotId)))
            {
                WriteWarning("You are passing $null as a value for parameter BotId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BotVersion = this.BotVersion;
            if (this.ConversationLogSettings_AudioLogSetting != null)
            {
                context.ConversationLogSettings_AudioLogSetting = new List<Amazon.LexModelsV2.Model.AudioLogSetting>(this.ConversationLogSettings_AudioLogSetting);
            }
            if (this.ConversationLogSettings_TextLogSetting != null)
            {
                context.ConversationLogSettings_TextLogSetting = new List<Amazon.LexModelsV2.Model.TextLogSetting>(this.ConversationLogSettings_TextLogSetting);
            }
            context.Description = this.Description;
            context.SentimentAnalysisSettings_DetectSentiment = this.SentimentAnalysisSettings_DetectSentiment;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.LexModelsV2.Model.CreateBotAliasRequest();
            
            if (cmdletContext.BotAliasLocaleSetting != null)
            {
                request.BotAliasLocaleSettings = cmdletContext.BotAliasLocaleSetting;
            }
            if (cmdletContext.BotAliasName != null)
            {
                request.BotAliasName = cmdletContext.BotAliasName;
            }
            if (cmdletContext.BotId != null)
            {
                request.BotId = cmdletContext.BotId;
            }
            if (cmdletContext.BotVersion != null)
            {
                request.BotVersion = cmdletContext.BotVersion;
            }
            
             // populate ConversationLogSettings
            var requestConversationLogSettingsIsNull = true;
            request.ConversationLogSettings = new Amazon.LexModelsV2.Model.ConversationLogSettings();
            List<Amazon.LexModelsV2.Model.AudioLogSetting> requestConversationLogSettings_conversationLogSettings_AudioLogSetting = null;
            if (cmdletContext.ConversationLogSettings_AudioLogSetting != null)
            {
                requestConversationLogSettings_conversationLogSettings_AudioLogSetting = cmdletContext.ConversationLogSettings_AudioLogSetting;
            }
            if (requestConversationLogSettings_conversationLogSettings_AudioLogSetting != null)
            {
                request.ConversationLogSettings.AudioLogSettings = requestConversationLogSettings_conversationLogSettings_AudioLogSetting;
                requestConversationLogSettingsIsNull = false;
            }
            List<Amazon.LexModelsV2.Model.TextLogSetting> requestConversationLogSettings_conversationLogSettings_TextLogSetting = null;
            if (cmdletContext.ConversationLogSettings_TextLogSetting != null)
            {
                requestConversationLogSettings_conversationLogSettings_TextLogSetting = cmdletContext.ConversationLogSettings_TextLogSetting;
            }
            if (requestConversationLogSettings_conversationLogSettings_TextLogSetting != null)
            {
                request.ConversationLogSettings.TextLogSettings = requestConversationLogSettings_conversationLogSettings_TextLogSetting;
                requestConversationLogSettingsIsNull = false;
            }
             // determine if request.ConversationLogSettings should be set to null
            if (requestConversationLogSettingsIsNull)
            {
                request.ConversationLogSettings = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate SentimentAnalysisSettings
            var requestSentimentAnalysisSettingsIsNull = true;
            request.SentimentAnalysisSettings = new Amazon.LexModelsV2.Model.SentimentAnalysisSettings();
            System.Boolean? requestSentimentAnalysisSettings_sentimentAnalysisSettings_DetectSentiment = null;
            if (cmdletContext.SentimentAnalysisSettings_DetectSentiment != null)
            {
                requestSentimentAnalysisSettings_sentimentAnalysisSettings_DetectSentiment = cmdletContext.SentimentAnalysisSettings_DetectSentiment.Value;
            }
            if (requestSentimentAnalysisSettings_sentimentAnalysisSettings_DetectSentiment != null)
            {
                request.SentimentAnalysisSettings.DetectSentiment = requestSentimentAnalysisSettings_sentimentAnalysisSettings_DetectSentiment.Value;
                requestSentimentAnalysisSettingsIsNull = false;
            }
             // determine if request.SentimentAnalysisSettings should be set to null
            if (requestSentimentAnalysisSettingsIsNull)
            {
                request.SentimentAnalysisSettings = null;
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
        
        private Amazon.LexModelsV2.Model.CreateBotAliasResponse CallAWSServiceOperation(IAmazonLexModelsV2 client, Amazon.LexModelsV2.Model.CreateBotAliasRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lex Model Building V2", "CreateBotAlias");
            try
            {
                #if DESKTOP
                return client.CreateBotAlias(request);
                #elif CORECLR
                return client.CreateBotAliasAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, Amazon.LexModelsV2.Model.BotAliasLocaleSettings> BotAliasLocaleSetting { get; set; }
            public System.String BotAliasName { get; set; }
            public System.String BotId { get; set; }
            public System.String BotVersion { get; set; }
            public List<Amazon.LexModelsV2.Model.AudioLogSetting> ConversationLogSettings_AudioLogSetting { get; set; }
            public List<Amazon.LexModelsV2.Model.TextLogSetting> ConversationLogSettings_TextLogSetting { get; set; }
            public System.String Description { get; set; }
            public System.Boolean? SentimentAnalysisSettings_DetectSentiment { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.LexModelsV2.Model.CreateBotAliasResponse, NewLMBV2BotAliasCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
