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
using Amazon.LexModelsV2;
using Amazon.LexModelsV2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LMBV2
{
    /// <summary>
    /// Updates the configuration of an existing bot alias.
    /// </summary>
    [Cmdlet("Update", "LMBV2BotAlias", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LexModelsV2.Model.UpdateBotAliasResponse")]
    [AWSCmdlet("Calls the Amazon Lex Model Building V2 UpdateBotAlias API operation.", Operation = new[] {"UpdateBotAlias"}, SelectReturnType = typeof(Amazon.LexModelsV2.Model.UpdateBotAliasResponse))]
    [AWSCmdletOutput("Amazon.LexModelsV2.Model.UpdateBotAliasResponse",
        "This cmdlet returns an Amazon.LexModelsV2.Model.UpdateBotAliasResponse object containing multiple properties."
    )]
    public partial class UpdateLMBV2BotAliasCmdlet : AmazonLexModelsV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConversationLogSettings_AudioLogSetting
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 settings for logging audio to an S3 bucket.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConversationLogSettings_AudioLogSettings")]
        public Amazon.LexModelsV2.Model.AudioLogSetting[] ConversationLogSettings_AudioLogSetting { get; set; }
        #endregion
        
        #region Parameter BotAliasId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the bot alias.</para>
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
        public System.String BotAliasId { get; set; }
        #endregion
        
        #region Parameter BotAliasLocaleSetting
        /// <summary>
        /// <para>
        /// <para>The new Lambda functions to use in each locale for the bot alias.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BotAliasLocaleSettings")]
        public System.Collections.Hashtable BotAliasLocaleSetting { get; set; }
        #endregion
        
        #region Parameter BotAliasName
        /// <summary>
        /// <para>
        /// <para>The new name to assign to the bot alias.</para>
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
        public System.String BotAliasName { get; set; }
        #endregion
        
        #region Parameter BotId
        /// <summary>
        /// <para>
        /// <para>The identifier of the bot with the updated alias.</para>
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
        /// <para>The new bot version to assign to the bot alias.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BotVersion { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The new description to assign to the bot alias.</para>
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
        
        #region Parameter ConversationLogSettings_TextLogSetting
        /// <summary>
        /// <para>
        /// <para>The Amazon CloudWatch Logs settings for logging text and metadata.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConversationLogSettings_TextLogSettings")]
        public Amazon.LexModelsV2.Model.TextLogSetting[] ConversationLogSettings_TextLogSetting { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LexModelsV2.Model.UpdateBotAliasResponse).
        /// Specifying the name of a property of type Amazon.LexModelsV2.Model.UpdateBotAliasResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BotAliasId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LMBV2BotAlias (UpdateBotAlias)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LexModelsV2.Model.UpdateBotAliasResponse, UpdateLMBV2BotAliasCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BotAliasId = this.BotAliasId;
            #if MODULAR
            if (this.BotAliasId == null && ParameterWasBound(nameof(this.BotAliasId)))
            {
                WriteWarning("You are passing $null as a value for parameter BotAliasId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.LexModelsV2.Model.UpdateBotAliasRequest();
            
            if (cmdletContext.BotAliasId != null)
            {
                request.BotAliasId = cmdletContext.BotAliasId;
            }
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
        
        private Amazon.LexModelsV2.Model.UpdateBotAliasResponse CallAWSServiceOperation(IAmazonLexModelsV2 client, Amazon.LexModelsV2.Model.UpdateBotAliasRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lex Model Building V2", "UpdateBotAlias");
            try
            {
                return client.UpdateBotAliasAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String BotAliasId { get; set; }
            public Dictionary<System.String, Amazon.LexModelsV2.Model.BotAliasLocaleSettings> BotAliasLocaleSetting { get; set; }
            public System.String BotAliasName { get; set; }
            public System.String BotId { get; set; }
            public System.String BotVersion { get; set; }
            public List<Amazon.LexModelsV2.Model.AudioLogSetting> ConversationLogSettings_AudioLogSetting { get; set; }
            public List<Amazon.LexModelsV2.Model.TextLogSetting> ConversationLogSettings_TextLogSetting { get; set; }
            public System.String Description { get; set; }
            public System.Boolean? SentimentAnalysisSettings_DetectSentiment { get; set; }
            public System.Func<Amazon.LexModelsV2.Model.UpdateBotAliasResponse, UpdateLMBV2BotAliasCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
