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
using Amazon.QConnect;
using Amazon.QConnect.Model;

namespace Amazon.PowerShell.Cmdlets.QC
{
    /// <summary>
    /// Updates an AI Agent.
    /// </summary>
    [Cmdlet("Update", "QCAIAgent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QConnect.Model.AIAgentData")]
    [AWSCmdlet("Calls the Amazon Q Connect UpdateAIAgent API operation.", Operation = new[] {"UpdateAIAgent"}, SelectReturnType = typeof(Amazon.QConnect.Model.UpdateAIAgentResponse))]
    [AWSCmdletOutput("Amazon.QConnect.Model.AIAgentData or Amazon.QConnect.Model.UpdateAIAgentResponse",
        "This cmdlet returns an Amazon.QConnect.Model.AIAgentData object.",
        "The service call response (type Amazon.QConnect.Model.UpdateAIAgentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateQCAIAgentCmdlet : AmazonQConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AiAgentId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Q in Connect AI Agent.</para>
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
        public System.String AiAgentId { get; set; }
        #endregion
        
        #region Parameter AnswerRecommendationAIAgentConfiguration_AnswerGenerationAIGuardrailId
        /// <summary>
        /// <para>
        /// <para>The AI Guardrail identifier for the Answer Generation Guardrail used by the <c>ANSWER_RECOMMENDATION</c>
        /// AI Agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_AnswerRecommendationAIAgentConfiguration_AnswerGenerationAIGuardrailId")]
        public System.String AnswerRecommendationAIAgentConfiguration_AnswerGenerationAIGuardrailId { get; set; }
        #endregion
        
        #region Parameter ManualSearchAIAgentConfiguration_AnswerGenerationAIGuardrailId
        /// <summary>
        /// <para>
        /// <para>The AI Guardrail identifier for the Answer Generation guardrail used by the MANUAL_SEARCH
        /// AI Agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ManualSearchAIAgentConfiguration_AnswerGenerationAIGuardrailId")]
        public System.String ManualSearchAIAgentConfiguration_AnswerGenerationAIGuardrailId { get; set; }
        #endregion
        
        #region Parameter AnswerRecommendationAIAgentConfiguration_AnswerGenerationAIPromptId
        /// <summary>
        /// <para>
        /// <para>The AI Prompt identifier for the Answer Generation prompt used by the <c>ANSWER_RECOMMENDATION</c>
        /// AI Agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_AnswerRecommendationAIAgentConfiguration_AnswerGenerationAIPromptId")]
        public System.String AnswerRecommendationAIAgentConfiguration_AnswerGenerationAIPromptId { get; set; }
        #endregion
        
        #region Parameter ManualSearchAIAgentConfiguration_AnswerGenerationAIPromptId
        /// <summary>
        /// <para>
        /// <para>The AI Prompt identifier for the Answer Generation prompt used by the MANUAL_SEARCH
        /// AI Agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ManualSearchAIAgentConfiguration_AnswerGenerationAIPromptId")]
        public System.String ManualSearchAIAgentConfiguration_AnswerGenerationAIPromptId { get; set; }
        #endregion
        
        #region Parameter AssistantId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Q in Connect assistant. Can be either the ID or the ARN.
        /// URLs cannot contain the ARN.</para>
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
        public System.String AssistantId { get; set; }
        #endregion
        
        #region Parameter AnswerRecommendationAIAgentConfiguration_AssociationConfiguration
        /// <summary>
        /// <para>
        /// <para>The association configurations for overriding behavior on this AI Agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_AnswerRecommendationAIAgentConfiguration_AssociationConfigurations")]
        public Amazon.QConnect.Model.AssociationConfiguration[] AnswerRecommendationAIAgentConfiguration_AssociationConfiguration { get; set; }
        #endregion
        
        #region Parameter EmailGenerativeAnswerAIAgentConfiguration_AssociationConfiguration
        /// <summary>
        /// <para>
        /// <para>Configuration settings for knowledge base associations used by the email generative
        /// answer agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_EmailGenerativeAnswerAIAgentConfiguration_AssociationConfigurations")]
        public Amazon.QConnect.Model.AssociationConfiguration[] EmailGenerativeAnswerAIAgentConfiguration_AssociationConfiguration { get; set; }
        #endregion
        
        #region Parameter EmailResponseAIAgentConfiguration_AssociationConfiguration
        /// <summary>
        /// <para>
        /// <para>Configuration settings for knowledge base associations used by the email response
        /// agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_EmailResponseAIAgentConfiguration_AssociationConfigurations")]
        public Amazon.QConnect.Model.AssociationConfiguration[] EmailResponseAIAgentConfiguration_AssociationConfiguration { get; set; }
        #endregion
        
        #region Parameter ManualSearchAIAgentConfiguration_AssociationConfiguration
        /// <summary>
        /// <para>
        /// <para>The association configurations for overriding behavior on this AI Agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ManualSearchAIAgentConfiguration_AssociationConfigurations")]
        public Amazon.QConnect.Model.AssociationConfiguration[] ManualSearchAIAgentConfiguration_AssociationConfiguration { get; set; }
        #endregion
        
        #region Parameter SelfServiceAIAgentConfiguration_AssociationConfiguration
        /// <summary>
        /// <para>
        /// <para>The association configurations for overriding behavior on this AI Agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_SelfServiceAIAgentConfiguration_AssociationConfigurations")]
        public Amazon.QConnect.Model.AssociationConfiguration[] SelfServiceAIAgentConfiguration_AssociationConfiguration { get; set; }
        #endregion
        
        #region Parameter CaseSummarizationAIAgentConfiguration_CaseSummarizationAIGuardrailId
        /// <summary>
        /// <para>
        /// <para>The AI Guardrail identifier used by the Case Summarization AI Agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_CaseSummarizationAIAgentConfiguration_CaseSummarizationAIGuardrailId")]
        public System.String CaseSummarizationAIAgentConfiguration_CaseSummarizationAIGuardrailId { get; set; }
        #endregion
        
        #region Parameter CaseSummarizationAIAgentConfiguration_CaseSummarizationAIPromptId
        /// <summary>
        /// <para>
        /// <para>The AI Prompt identifier used by the Case Summarization AI Agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_CaseSummarizationAIAgentConfiguration_CaseSummarizationAIPromptId")]
        public System.String CaseSummarizationAIAgentConfiguration_CaseSummarizationAIPromptId { get; set; }
        #endregion
        
        #region Parameter OrchestrationAIAgentConfiguration_ConnectInstanceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon Connect instance used by the Orchestration
        /// AI Agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_OrchestrationAIAgentConfiguration_ConnectInstanceArn")]
        public System.String OrchestrationAIAgentConfiguration_ConnectInstanceArn { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the Amazon Q in Connect AI Agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EmailGenerativeAnswerAIAgentConfiguration_EmailGenerativeAnswerAIPromptId
        /// <summary>
        /// <para>
        /// <para>The ID of the System AI prompt used for generating comprehensive knowledge-based answers
        /// from email queries.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_EmailGenerativeAnswerAIAgentConfiguration_EmailGenerativeAnswerAIPromptId")]
        public System.String EmailGenerativeAnswerAIAgentConfiguration_EmailGenerativeAnswerAIPromptId { get; set; }
        #endregion
        
        #region Parameter EmailOverviewAIAgentConfiguration_EmailOverviewAIPromptId
        /// <summary>
        /// <para>
        /// <para>The ID of the System AI prompt used for generating structured email conversation summaries.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_EmailOverviewAIAgentConfiguration_EmailOverviewAIPromptId")]
        public System.String EmailOverviewAIAgentConfiguration_EmailOverviewAIPromptId { get; set; }
        #endregion
        
        #region Parameter EmailGenerativeAnswerAIAgentConfiguration_EmailQueryReformulationAIPromptId
        /// <summary>
        /// <para>
        /// <para>The ID of the System AI prompt used for reformulating email queries to optimize knowledge
        /// base search results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_EmailGenerativeAnswerAIAgentConfiguration_EmailQueryReformulationAIPromptId")]
        public System.String EmailGenerativeAnswerAIAgentConfiguration_EmailQueryReformulationAIPromptId { get; set; }
        #endregion
        
        #region Parameter EmailResponseAIAgentConfiguration_EmailQueryReformulationAIPromptId
        /// <summary>
        /// <para>
        /// <para>The ID of the System AI prompt used for reformulating email queries to optimize knowledge
        /// base search for response generation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_EmailResponseAIAgentConfiguration_EmailQueryReformulationAIPromptId")]
        public System.String EmailResponseAIAgentConfiguration_EmailQueryReformulationAIPromptId { get; set; }
        #endregion
        
        #region Parameter EmailResponseAIAgentConfiguration_EmailResponseAIPromptId
        /// <summary>
        /// <para>
        /// <para>The ID of the System AI prompt used for generating professional email responses based
        /// on knowledge base content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_EmailResponseAIAgentConfiguration_EmailResponseAIPromptId")]
        public System.String EmailResponseAIAgentConfiguration_EmailResponseAIPromptId { get; set; }
        #endregion
        
        #region Parameter AnswerRecommendationAIAgentConfiguration_IntentLabelingGenerationAIPromptId
        /// <summary>
        /// <para>
        /// <para>The AI Prompt identifier for the Intent Labeling prompt used by the <c>ANSWER_RECOMMENDATION</c>
        /// AI Agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_AnswerRecommendationAIAgentConfiguration_IntentLabelingGenerationAIPromptId")]
        public System.String AnswerRecommendationAIAgentConfiguration_IntentLabelingGenerationAIPromptId { get; set; }
        #endregion
        
        #region Parameter AnswerRecommendationAIAgentConfiguration_Locale
        /// <summary>
        /// <para>
        /// <para>The locale to which specifies the language and region settings that determine the
        /// response language for <a href="https://docs.aws.amazon.com/connect/latest/APIReference/API_amazon-q-connect_QueryAssistant.html">QueryAssistant</a>.</para><note><para>For more information on supported locales, see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/supported-languages.html#qic-notes-languages">Language
        /// support for Amazon Q in Connect</a>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_AnswerRecommendationAIAgentConfiguration_Locale")]
        public System.String AnswerRecommendationAIAgentConfiguration_Locale { get; set; }
        #endregion
        
        #region Parameter CaseSummarizationAIAgentConfiguration_Locale
        /// <summary>
        /// <para>
        /// <para>The locale setting for the Case Summarization AI Agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_CaseSummarizationAIAgentConfiguration_Locale")]
        public System.String CaseSummarizationAIAgentConfiguration_Locale { get; set; }
        #endregion
        
        #region Parameter EmailGenerativeAnswerAIAgentConfiguration_Locale
        /// <summary>
        /// <para>
        /// <para>The locale setting for language-specific email processing and response generation
        /// (for example, en_US, es_ES).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_EmailGenerativeAnswerAIAgentConfiguration_Locale")]
        public System.String EmailGenerativeAnswerAIAgentConfiguration_Locale { get; set; }
        #endregion
        
        #region Parameter EmailOverviewAIAgentConfiguration_Locale
        /// <summary>
        /// <para>
        /// <para>The locale setting for language-specific email overview processing (for example, en_US,
        /// es_ES).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_EmailOverviewAIAgentConfiguration_Locale")]
        public System.String EmailOverviewAIAgentConfiguration_Locale { get; set; }
        #endregion
        
        #region Parameter EmailResponseAIAgentConfiguration_Locale
        /// <summary>
        /// <para>
        /// <para>The locale setting for language-specific email response generation (for example, en_US,
        /// es_ES).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_EmailResponseAIAgentConfiguration_Locale")]
        public System.String EmailResponseAIAgentConfiguration_Locale { get; set; }
        #endregion
        
        #region Parameter ManualSearchAIAgentConfiguration_Locale
        /// <summary>
        /// <para>
        /// <para>The locale to which specifies the language and region settings that determine the
        /// response language for <a href="https://docs.aws.amazon.com/connect/latest/APIReference/API_amazon-q-connect_QueryAssistant.html">QueryAssistant</a>.</para><note><para>For more information on supported locales, see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/supported-languages.html#qic-notes-languages">Language
        /// support for Amazon Q in Connect</a>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ManualSearchAIAgentConfiguration_Locale")]
        public System.String ManualSearchAIAgentConfiguration_Locale { get; set; }
        #endregion
        
        #region Parameter NoteTakingAIAgentConfiguration_Locale
        /// <summary>
        /// <para>
        /// <para>The locale setting for language-specific case summarization generation (for example,
        /// en_US, es_ES).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_NoteTakingAIAgentConfiguration_Locale")]
        public System.String NoteTakingAIAgentConfiguration_Locale { get; set; }
        #endregion
        
        #region Parameter OrchestrationAIAgentConfiguration_Locale
        /// <summary>
        /// <para>
        /// <para>The locale setting for the Orchestration AI Agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_OrchestrationAIAgentConfiguration_Locale")]
        public System.String OrchestrationAIAgentConfiguration_Locale { get; set; }
        #endregion
        
        #region Parameter NoteTakingAIAgentConfiguration_NoteTakingAIGuardrailId
        /// <summary>
        /// <para>
        /// <para>The AI Guardrail identifier used by the Note Taking AI Agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_NoteTakingAIAgentConfiguration_NoteTakingAIGuardrailId")]
        public System.String NoteTakingAIAgentConfiguration_NoteTakingAIGuardrailId { get; set; }
        #endregion
        
        #region Parameter NoteTakingAIAgentConfiguration_NoteTakingAIPromptId
        /// <summary>
        /// <para>
        /// <para>The AI Prompt identifier used by the Note Taking AI Agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_NoteTakingAIAgentConfiguration_NoteTakingAIPromptId")]
        public System.String NoteTakingAIAgentConfiguration_NoteTakingAIPromptId { get; set; }
        #endregion
        
        #region Parameter OrchestrationAIAgentConfiguration_OrchestrationAIGuardrailId
        /// <summary>
        /// <para>
        /// <para>The AI Guardrail identifier used by the Orchestration AI Agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_OrchestrationAIAgentConfiguration_OrchestrationAIGuardrailId")]
        public System.String OrchestrationAIAgentConfiguration_OrchestrationAIGuardrailId { get; set; }
        #endregion
        
        #region Parameter OrchestrationAIAgentConfiguration_OrchestrationAIPromptId
        /// <summary>
        /// <para>
        /// <para>The AI Prompt identifier used by the Orchestration AI Agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_OrchestrationAIAgentConfiguration_OrchestrationAIPromptId")]
        public System.String OrchestrationAIAgentConfiguration_OrchestrationAIPromptId { get; set; }
        #endregion
        
        #region Parameter AnswerRecommendationAIAgentConfiguration_QueryReformulationAIPromptId
        /// <summary>
        /// <para>
        /// <para>The AI Prompt identifier for the Query Reformulation prompt used by the <c>ANSWER_RECOMMENDATION</c>
        /// AI Agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_AnswerRecommendationAIAgentConfiguration_QueryReformulationAIPromptId")]
        public System.String AnswerRecommendationAIAgentConfiguration_QueryReformulationAIPromptId { get; set; }
        #endregion
        
        #region Parameter SelfServiceAIAgentConfiguration_SelfServiceAIGuardrailId
        /// <summary>
        /// <para>
        /// <para>The AI Guardrail identifier used by the SELF_SERVICE AI Agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_SelfServiceAIAgentConfiguration_SelfServiceAIGuardrailId")]
        public System.String SelfServiceAIAgentConfiguration_SelfServiceAIGuardrailId { get; set; }
        #endregion
        
        #region Parameter SelfServiceAIAgentConfiguration_SelfServiceAnswerGenerationAIPromptId
        /// <summary>
        /// <para>
        /// <para>The AI Prompt identifier for the Self Service Answer Generation prompt used by the
        /// SELF_SERVICE AI Agent</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_SelfServiceAIAgentConfiguration_SelfServiceAnswerGenerationAIPromptId")]
        public System.String SelfServiceAIAgentConfiguration_SelfServiceAnswerGenerationAIPromptId { get; set; }
        #endregion
        
        #region Parameter SelfServiceAIAgentConfiguration_SelfServicePreProcessingAIPromptId
        /// <summary>
        /// <para>
        /// <para>The AI Prompt identifier for the Self Service Pre-Processing prompt used by the SELF_SERVICE
        /// AI Agent</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_SelfServiceAIAgentConfiguration_SelfServicePreProcessingAIPromptId")]
        public System.String SelfServiceAIAgentConfiguration_SelfServicePreProcessingAIPromptId { get; set; }
        #endregion
        
        #region Parameter AnswerRecommendationAIAgentConfiguration_SuggestedMessage
        /// <summary>
        /// <para>
        /// <para>The suggested messages configuration for the Answer Recommendation AI Agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_AnswerRecommendationAIAgentConfiguration_SuggestedMessages")]
        public System.String[] AnswerRecommendationAIAgentConfiguration_SuggestedMessage { get; set; }
        #endregion
        
        #region Parameter OrchestrationAIAgentConfiguration_ToolConfiguration
        /// <summary>
        /// <para>
        /// <para>The tool configurations used by the Orchestration AI Agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_OrchestrationAIAgentConfiguration_ToolConfigurations")]
        public Amazon.QConnect.Model.ToolConfiguration[] OrchestrationAIAgentConfiguration_ToolConfiguration { get; set; }
        #endregion
        
        #region Parameter VisibilityStatus
        /// <summary>
        /// <para>
        /// <para>The visbility status of the Amazon Q in Connect AI Agent.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.QConnect.VisibilityStatus")]
        public Amazon.QConnect.VisibilityStatus VisibilityStatus { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If not provided, the Amazon Web Services SDK populates this field. For
        /// more information about idempotency, see <a href="http://aws.amazon.com/builders-library/making-retries-safe-with-idempotent-APIs/">Making
        /// retries safe with idempotent APIs</a>..</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AiAgent'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QConnect.Model.UpdateAIAgentResponse).
        /// Specifying the name of a property of type Amazon.QConnect.Model.UpdateAIAgentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AiAgent";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AiAgentId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AiAgentId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AiAgentId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AiAgentId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-QCAIAgent (UpdateAIAgent)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QConnect.Model.UpdateAIAgentResponse, UpdateQCAIAgentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AiAgentId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AiAgentId = this.AiAgentId;
            #if MODULAR
            if (this.AiAgentId == null && ParameterWasBound(nameof(this.AiAgentId)))
            {
                WriteWarning("You are passing $null as a value for parameter AiAgentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AssistantId = this.AssistantId;
            #if MODULAR
            if (this.AssistantId == null && ParameterWasBound(nameof(this.AssistantId)))
            {
                WriteWarning("You are passing $null as a value for parameter AssistantId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.AnswerRecommendationAIAgentConfiguration_AnswerGenerationAIGuardrailId = this.AnswerRecommendationAIAgentConfiguration_AnswerGenerationAIGuardrailId;
            context.AnswerRecommendationAIAgentConfiguration_AnswerGenerationAIPromptId = this.AnswerRecommendationAIAgentConfiguration_AnswerGenerationAIPromptId;
            if (this.AnswerRecommendationAIAgentConfiguration_AssociationConfiguration != null)
            {
                context.AnswerRecommendationAIAgentConfiguration_AssociationConfiguration = new List<Amazon.QConnect.Model.AssociationConfiguration>(this.AnswerRecommendationAIAgentConfiguration_AssociationConfiguration);
            }
            context.AnswerRecommendationAIAgentConfiguration_IntentLabelingGenerationAIPromptId = this.AnswerRecommendationAIAgentConfiguration_IntentLabelingGenerationAIPromptId;
            context.AnswerRecommendationAIAgentConfiguration_Locale = this.AnswerRecommendationAIAgentConfiguration_Locale;
            context.AnswerRecommendationAIAgentConfiguration_QueryReformulationAIPromptId = this.AnswerRecommendationAIAgentConfiguration_QueryReformulationAIPromptId;
            if (this.AnswerRecommendationAIAgentConfiguration_SuggestedMessage != null)
            {
                context.AnswerRecommendationAIAgentConfiguration_SuggestedMessage = new List<System.String>(this.AnswerRecommendationAIAgentConfiguration_SuggestedMessage);
            }
            context.CaseSummarizationAIAgentConfiguration_CaseSummarizationAIGuardrailId = this.CaseSummarizationAIAgentConfiguration_CaseSummarizationAIGuardrailId;
            context.CaseSummarizationAIAgentConfiguration_CaseSummarizationAIPromptId = this.CaseSummarizationAIAgentConfiguration_CaseSummarizationAIPromptId;
            context.CaseSummarizationAIAgentConfiguration_Locale = this.CaseSummarizationAIAgentConfiguration_Locale;
            if (this.EmailGenerativeAnswerAIAgentConfiguration_AssociationConfiguration != null)
            {
                context.EmailGenerativeAnswerAIAgentConfiguration_AssociationConfiguration = new List<Amazon.QConnect.Model.AssociationConfiguration>(this.EmailGenerativeAnswerAIAgentConfiguration_AssociationConfiguration);
            }
            context.EmailGenerativeAnswerAIAgentConfiguration_EmailGenerativeAnswerAIPromptId = this.EmailGenerativeAnswerAIAgentConfiguration_EmailGenerativeAnswerAIPromptId;
            context.EmailGenerativeAnswerAIAgentConfiguration_EmailQueryReformulationAIPromptId = this.EmailGenerativeAnswerAIAgentConfiguration_EmailQueryReformulationAIPromptId;
            context.EmailGenerativeAnswerAIAgentConfiguration_Locale = this.EmailGenerativeAnswerAIAgentConfiguration_Locale;
            context.EmailOverviewAIAgentConfiguration_EmailOverviewAIPromptId = this.EmailOverviewAIAgentConfiguration_EmailOverviewAIPromptId;
            context.EmailOverviewAIAgentConfiguration_Locale = this.EmailOverviewAIAgentConfiguration_Locale;
            if (this.EmailResponseAIAgentConfiguration_AssociationConfiguration != null)
            {
                context.EmailResponseAIAgentConfiguration_AssociationConfiguration = new List<Amazon.QConnect.Model.AssociationConfiguration>(this.EmailResponseAIAgentConfiguration_AssociationConfiguration);
            }
            context.EmailResponseAIAgentConfiguration_EmailQueryReformulationAIPromptId = this.EmailResponseAIAgentConfiguration_EmailQueryReformulationAIPromptId;
            context.EmailResponseAIAgentConfiguration_EmailResponseAIPromptId = this.EmailResponseAIAgentConfiguration_EmailResponseAIPromptId;
            context.EmailResponseAIAgentConfiguration_Locale = this.EmailResponseAIAgentConfiguration_Locale;
            context.ManualSearchAIAgentConfiguration_AnswerGenerationAIGuardrailId = this.ManualSearchAIAgentConfiguration_AnswerGenerationAIGuardrailId;
            context.ManualSearchAIAgentConfiguration_AnswerGenerationAIPromptId = this.ManualSearchAIAgentConfiguration_AnswerGenerationAIPromptId;
            if (this.ManualSearchAIAgentConfiguration_AssociationConfiguration != null)
            {
                context.ManualSearchAIAgentConfiguration_AssociationConfiguration = new List<Amazon.QConnect.Model.AssociationConfiguration>(this.ManualSearchAIAgentConfiguration_AssociationConfiguration);
            }
            context.ManualSearchAIAgentConfiguration_Locale = this.ManualSearchAIAgentConfiguration_Locale;
            context.NoteTakingAIAgentConfiguration_Locale = this.NoteTakingAIAgentConfiguration_Locale;
            context.NoteTakingAIAgentConfiguration_NoteTakingAIGuardrailId = this.NoteTakingAIAgentConfiguration_NoteTakingAIGuardrailId;
            context.NoteTakingAIAgentConfiguration_NoteTakingAIPromptId = this.NoteTakingAIAgentConfiguration_NoteTakingAIPromptId;
            context.OrchestrationAIAgentConfiguration_ConnectInstanceArn = this.OrchestrationAIAgentConfiguration_ConnectInstanceArn;
            context.OrchestrationAIAgentConfiguration_Locale = this.OrchestrationAIAgentConfiguration_Locale;
            context.OrchestrationAIAgentConfiguration_OrchestrationAIGuardrailId = this.OrchestrationAIAgentConfiguration_OrchestrationAIGuardrailId;
            context.OrchestrationAIAgentConfiguration_OrchestrationAIPromptId = this.OrchestrationAIAgentConfiguration_OrchestrationAIPromptId;
            if (this.OrchestrationAIAgentConfiguration_ToolConfiguration != null)
            {
                context.OrchestrationAIAgentConfiguration_ToolConfiguration = new List<Amazon.QConnect.Model.ToolConfiguration>(this.OrchestrationAIAgentConfiguration_ToolConfiguration);
            }
            if (this.SelfServiceAIAgentConfiguration_AssociationConfiguration != null)
            {
                context.SelfServiceAIAgentConfiguration_AssociationConfiguration = new List<Amazon.QConnect.Model.AssociationConfiguration>(this.SelfServiceAIAgentConfiguration_AssociationConfiguration);
            }
            context.SelfServiceAIAgentConfiguration_SelfServiceAIGuardrailId = this.SelfServiceAIAgentConfiguration_SelfServiceAIGuardrailId;
            context.SelfServiceAIAgentConfiguration_SelfServiceAnswerGenerationAIPromptId = this.SelfServiceAIAgentConfiguration_SelfServiceAnswerGenerationAIPromptId;
            context.SelfServiceAIAgentConfiguration_SelfServicePreProcessingAIPromptId = this.SelfServiceAIAgentConfiguration_SelfServicePreProcessingAIPromptId;
            context.Description = this.Description;
            context.VisibilityStatus = this.VisibilityStatus;
            #if MODULAR
            if (this.VisibilityStatus == null && ParameterWasBound(nameof(this.VisibilityStatus)))
            {
                WriteWarning("You are passing $null as a value for parameter VisibilityStatus which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.QConnect.Model.UpdateAIAgentRequest();
            
            if (cmdletContext.AiAgentId != null)
            {
                request.AiAgentId = cmdletContext.AiAgentId;
            }
            if (cmdletContext.AssistantId != null)
            {
                request.AssistantId = cmdletContext.AssistantId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.QConnect.Model.AIAgentConfiguration();
            Amazon.QConnect.Model.EmailOverviewAIAgentConfiguration requestConfiguration_configuration_EmailOverviewAIAgentConfiguration = null;
            
             // populate EmailOverviewAIAgentConfiguration
            var requestConfiguration_configuration_EmailOverviewAIAgentConfigurationIsNull = true;
            requestConfiguration_configuration_EmailOverviewAIAgentConfiguration = new Amazon.QConnect.Model.EmailOverviewAIAgentConfiguration();
            System.String requestConfiguration_configuration_EmailOverviewAIAgentConfiguration_emailOverviewAIAgentConfiguration_EmailOverviewAIPromptId = null;
            if (cmdletContext.EmailOverviewAIAgentConfiguration_EmailOverviewAIPromptId != null)
            {
                requestConfiguration_configuration_EmailOverviewAIAgentConfiguration_emailOverviewAIAgentConfiguration_EmailOverviewAIPromptId = cmdletContext.EmailOverviewAIAgentConfiguration_EmailOverviewAIPromptId;
            }
            if (requestConfiguration_configuration_EmailOverviewAIAgentConfiguration_emailOverviewAIAgentConfiguration_EmailOverviewAIPromptId != null)
            {
                requestConfiguration_configuration_EmailOverviewAIAgentConfiguration.EmailOverviewAIPromptId = requestConfiguration_configuration_EmailOverviewAIAgentConfiguration_emailOverviewAIAgentConfiguration_EmailOverviewAIPromptId;
                requestConfiguration_configuration_EmailOverviewAIAgentConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_EmailOverviewAIAgentConfiguration_emailOverviewAIAgentConfiguration_Locale = null;
            if (cmdletContext.EmailOverviewAIAgentConfiguration_Locale != null)
            {
                requestConfiguration_configuration_EmailOverviewAIAgentConfiguration_emailOverviewAIAgentConfiguration_Locale = cmdletContext.EmailOverviewAIAgentConfiguration_Locale;
            }
            if (requestConfiguration_configuration_EmailOverviewAIAgentConfiguration_emailOverviewAIAgentConfiguration_Locale != null)
            {
                requestConfiguration_configuration_EmailOverviewAIAgentConfiguration.Locale = requestConfiguration_configuration_EmailOverviewAIAgentConfiguration_emailOverviewAIAgentConfiguration_Locale;
                requestConfiguration_configuration_EmailOverviewAIAgentConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_EmailOverviewAIAgentConfiguration should be set to null
            if (requestConfiguration_configuration_EmailOverviewAIAgentConfigurationIsNull)
            {
                requestConfiguration_configuration_EmailOverviewAIAgentConfiguration = null;
            }
            if (requestConfiguration_configuration_EmailOverviewAIAgentConfiguration != null)
            {
                request.Configuration.EmailOverviewAIAgentConfiguration = requestConfiguration_configuration_EmailOverviewAIAgentConfiguration;
                requestConfigurationIsNull = false;
            }
            Amazon.QConnect.Model.CaseSummarizationAIAgentConfiguration requestConfiguration_configuration_CaseSummarizationAIAgentConfiguration = null;
            
             // populate CaseSummarizationAIAgentConfiguration
            var requestConfiguration_configuration_CaseSummarizationAIAgentConfigurationIsNull = true;
            requestConfiguration_configuration_CaseSummarizationAIAgentConfiguration = new Amazon.QConnect.Model.CaseSummarizationAIAgentConfiguration();
            System.String requestConfiguration_configuration_CaseSummarizationAIAgentConfiguration_caseSummarizationAIAgentConfiguration_CaseSummarizationAIGuardrailId = null;
            if (cmdletContext.CaseSummarizationAIAgentConfiguration_CaseSummarizationAIGuardrailId != null)
            {
                requestConfiguration_configuration_CaseSummarizationAIAgentConfiguration_caseSummarizationAIAgentConfiguration_CaseSummarizationAIGuardrailId = cmdletContext.CaseSummarizationAIAgentConfiguration_CaseSummarizationAIGuardrailId;
            }
            if (requestConfiguration_configuration_CaseSummarizationAIAgentConfiguration_caseSummarizationAIAgentConfiguration_CaseSummarizationAIGuardrailId != null)
            {
                requestConfiguration_configuration_CaseSummarizationAIAgentConfiguration.CaseSummarizationAIGuardrailId = requestConfiguration_configuration_CaseSummarizationAIAgentConfiguration_caseSummarizationAIAgentConfiguration_CaseSummarizationAIGuardrailId;
                requestConfiguration_configuration_CaseSummarizationAIAgentConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_CaseSummarizationAIAgentConfiguration_caseSummarizationAIAgentConfiguration_CaseSummarizationAIPromptId = null;
            if (cmdletContext.CaseSummarizationAIAgentConfiguration_CaseSummarizationAIPromptId != null)
            {
                requestConfiguration_configuration_CaseSummarizationAIAgentConfiguration_caseSummarizationAIAgentConfiguration_CaseSummarizationAIPromptId = cmdletContext.CaseSummarizationAIAgentConfiguration_CaseSummarizationAIPromptId;
            }
            if (requestConfiguration_configuration_CaseSummarizationAIAgentConfiguration_caseSummarizationAIAgentConfiguration_CaseSummarizationAIPromptId != null)
            {
                requestConfiguration_configuration_CaseSummarizationAIAgentConfiguration.CaseSummarizationAIPromptId = requestConfiguration_configuration_CaseSummarizationAIAgentConfiguration_caseSummarizationAIAgentConfiguration_CaseSummarizationAIPromptId;
                requestConfiguration_configuration_CaseSummarizationAIAgentConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_CaseSummarizationAIAgentConfiguration_caseSummarizationAIAgentConfiguration_Locale = null;
            if (cmdletContext.CaseSummarizationAIAgentConfiguration_Locale != null)
            {
                requestConfiguration_configuration_CaseSummarizationAIAgentConfiguration_caseSummarizationAIAgentConfiguration_Locale = cmdletContext.CaseSummarizationAIAgentConfiguration_Locale;
            }
            if (requestConfiguration_configuration_CaseSummarizationAIAgentConfiguration_caseSummarizationAIAgentConfiguration_Locale != null)
            {
                requestConfiguration_configuration_CaseSummarizationAIAgentConfiguration.Locale = requestConfiguration_configuration_CaseSummarizationAIAgentConfiguration_caseSummarizationAIAgentConfiguration_Locale;
                requestConfiguration_configuration_CaseSummarizationAIAgentConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_CaseSummarizationAIAgentConfiguration should be set to null
            if (requestConfiguration_configuration_CaseSummarizationAIAgentConfigurationIsNull)
            {
                requestConfiguration_configuration_CaseSummarizationAIAgentConfiguration = null;
            }
            if (requestConfiguration_configuration_CaseSummarizationAIAgentConfiguration != null)
            {
                request.Configuration.CaseSummarizationAIAgentConfiguration = requestConfiguration_configuration_CaseSummarizationAIAgentConfiguration;
                requestConfigurationIsNull = false;
            }
            Amazon.QConnect.Model.NoteTakingAIAgentConfiguration requestConfiguration_configuration_NoteTakingAIAgentConfiguration = null;
            
             // populate NoteTakingAIAgentConfiguration
            var requestConfiguration_configuration_NoteTakingAIAgentConfigurationIsNull = true;
            requestConfiguration_configuration_NoteTakingAIAgentConfiguration = new Amazon.QConnect.Model.NoteTakingAIAgentConfiguration();
            System.String requestConfiguration_configuration_NoteTakingAIAgentConfiguration_noteTakingAIAgentConfiguration_Locale = null;
            if (cmdletContext.NoteTakingAIAgentConfiguration_Locale != null)
            {
                requestConfiguration_configuration_NoteTakingAIAgentConfiguration_noteTakingAIAgentConfiguration_Locale = cmdletContext.NoteTakingAIAgentConfiguration_Locale;
            }
            if (requestConfiguration_configuration_NoteTakingAIAgentConfiguration_noteTakingAIAgentConfiguration_Locale != null)
            {
                requestConfiguration_configuration_NoteTakingAIAgentConfiguration.Locale = requestConfiguration_configuration_NoteTakingAIAgentConfiguration_noteTakingAIAgentConfiguration_Locale;
                requestConfiguration_configuration_NoteTakingAIAgentConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_NoteTakingAIAgentConfiguration_noteTakingAIAgentConfiguration_NoteTakingAIGuardrailId = null;
            if (cmdletContext.NoteTakingAIAgentConfiguration_NoteTakingAIGuardrailId != null)
            {
                requestConfiguration_configuration_NoteTakingAIAgentConfiguration_noteTakingAIAgentConfiguration_NoteTakingAIGuardrailId = cmdletContext.NoteTakingAIAgentConfiguration_NoteTakingAIGuardrailId;
            }
            if (requestConfiguration_configuration_NoteTakingAIAgentConfiguration_noteTakingAIAgentConfiguration_NoteTakingAIGuardrailId != null)
            {
                requestConfiguration_configuration_NoteTakingAIAgentConfiguration.NoteTakingAIGuardrailId = requestConfiguration_configuration_NoteTakingAIAgentConfiguration_noteTakingAIAgentConfiguration_NoteTakingAIGuardrailId;
                requestConfiguration_configuration_NoteTakingAIAgentConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_NoteTakingAIAgentConfiguration_noteTakingAIAgentConfiguration_NoteTakingAIPromptId = null;
            if (cmdletContext.NoteTakingAIAgentConfiguration_NoteTakingAIPromptId != null)
            {
                requestConfiguration_configuration_NoteTakingAIAgentConfiguration_noteTakingAIAgentConfiguration_NoteTakingAIPromptId = cmdletContext.NoteTakingAIAgentConfiguration_NoteTakingAIPromptId;
            }
            if (requestConfiguration_configuration_NoteTakingAIAgentConfiguration_noteTakingAIAgentConfiguration_NoteTakingAIPromptId != null)
            {
                requestConfiguration_configuration_NoteTakingAIAgentConfiguration.NoteTakingAIPromptId = requestConfiguration_configuration_NoteTakingAIAgentConfiguration_noteTakingAIAgentConfiguration_NoteTakingAIPromptId;
                requestConfiguration_configuration_NoteTakingAIAgentConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_NoteTakingAIAgentConfiguration should be set to null
            if (requestConfiguration_configuration_NoteTakingAIAgentConfigurationIsNull)
            {
                requestConfiguration_configuration_NoteTakingAIAgentConfiguration = null;
            }
            if (requestConfiguration_configuration_NoteTakingAIAgentConfiguration != null)
            {
                request.Configuration.NoteTakingAIAgentConfiguration = requestConfiguration_configuration_NoteTakingAIAgentConfiguration;
                requestConfigurationIsNull = false;
            }
            Amazon.QConnect.Model.EmailGenerativeAnswerAIAgentConfiguration requestConfiguration_configuration_EmailGenerativeAnswerAIAgentConfiguration = null;
            
             // populate EmailGenerativeAnswerAIAgentConfiguration
            var requestConfiguration_configuration_EmailGenerativeAnswerAIAgentConfigurationIsNull = true;
            requestConfiguration_configuration_EmailGenerativeAnswerAIAgentConfiguration = new Amazon.QConnect.Model.EmailGenerativeAnswerAIAgentConfiguration();
            List<Amazon.QConnect.Model.AssociationConfiguration> requestConfiguration_configuration_EmailGenerativeAnswerAIAgentConfiguration_emailGenerativeAnswerAIAgentConfiguration_AssociationConfiguration = null;
            if (cmdletContext.EmailGenerativeAnswerAIAgentConfiguration_AssociationConfiguration != null)
            {
                requestConfiguration_configuration_EmailGenerativeAnswerAIAgentConfiguration_emailGenerativeAnswerAIAgentConfiguration_AssociationConfiguration = cmdletContext.EmailGenerativeAnswerAIAgentConfiguration_AssociationConfiguration;
            }
            if (requestConfiguration_configuration_EmailGenerativeAnswerAIAgentConfiguration_emailGenerativeAnswerAIAgentConfiguration_AssociationConfiguration != null)
            {
                requestConfiguration_configuration_EmailGenerativeAnswerAIAgentConfiguration.AssociationConfigurations = requestConfiguration_configuration_EmailGenerativeAnswerAIAgentConfiguration_emailGenerativeAnswerAIAgentConfiguration_AssociationConfiguration;
                requestConfiguration_configuration_EmailGenerativeAnswerAIAgentConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_EmailGenerativeAnswerAIAgentConfiguration_emailGenerativeAnswerAIAgentConfiguration_EmailGenerativeAnswerAIPromptId = null;
            if (cmdletContext.EmailGenerativeAnswerAIAgentConfiguration_EmailGenerativeAnswerAIPromptId != null)
            {
                requestConfiguration_configuration_EmailGenerativeAnswerAIAgentConfiguration_emailGenerativeAnswerAIAgentConfiguration_EmailGenerativeAnswerAIPromptId = cmdletContext.EmailGenerativeAnswerAIAgentConfiguration_EmailGenerativeAnswerAIPromptId;
            }
            if (requestConfiguration_configuration_EmailGenerativeAnswerAIAgentConfiguration_emailGenerativeAnswerAIAgentConfiguration_EmailGenerativeAnswerAIPromptId != null)
            {
                requestConfiguration_configuration_EmailGenerativeAnswerAIAgentConfiguration.EmailGenerativeAnswerAIPromptId = requestConfiguration_configuration_EmailGenerativeAnswerAIAgentConfiguration_emailGenerativeAnswerAIAgentConfiguration_EmailGenerativeAnswerAIPromptId;
                requestConfiguration_configuration_EmailGenerativeAnswerAIAgentConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_EmailGenerativeAnswerAIAgentConfiguration_emailGenerativeAnswerAIAgentConfiguration_EmailQueryReformulationAIPromptId = null;
            if (cmdletContext.EmailGenerativeAnswerAIAgentConfiguration_EmailQueryReformulationAIPromptId != null)
            {
                requestConfiguration_configuration_EmailGenerativeAnswerAIAgentConfiguration_emailGenerativeAnswerAIAgentConfiguration_EmailQueryReformulationAIPromptId = cmdletContext.EmailGenerativeAnswerAIAgentConfiguration_EmailQueryReformulationAIPromptId;
            }
            if (requestConfiguration_configuration_EmailGenerativeAnswerAIAgentConfiguration_emailGenerativeAnswerAIAgentConfiguration_EmailQueryReformulationAIPromptId != null)
            {
                requestConfiguration_configuration_EmailGenerativeAnswerAIAgentConfiguration.EmailQueryReformulationAIPromptId = requestConfiguration_configuration_EmailGenerativeAnswerAIAgentConfiguration_emailGenerativeAnswerAIAgentConfiguration_EmailQueryReformulationAIPromptId;
                requestConfiguration_configuration_EmailGenerativeAnswerAIAgentConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_EmailGenerativeAnswerAIAgentConfiguration_emailGenerativeAnswerAIAgentConfiguration_Locale = null;
            if (cmdletContext.EmailGenerativeAnswerAIAgentConfiguration_Locale != null)
            {
                requestConfiguration_configuration_EmailGenerativeAnswerAIAgentConfiguration_emailGenerativeAnswerAIAgentConfiguration_Locale = cmdletContext.EmailGenerativeAnswerAIAgentConfiguration_Locale;
            }
            if (requestConfiguration_configuration_EmailGenerativeAnswerAIAgentConfiguration_emailGenerativeAnswerAIAgentConfiguration_Locale != null)
            {
                requestConfiguration_configuration_EmailGenerativeAnswerAIAgentConfiguration.Locale = requestConfiguration_configuration_EmailGenerativeAnswerAIAgentConfiguration_emailGenerativeAnswerAIAgentConfiguration_Locale;
                requestConfiguration_configuration_EmailGenerativeAnswerAIAgentConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_EmailGenerativeAnswerAIAgentConfiguration should be set to null
            if (requestConfiguration_configuration_EmailGenerativeAnswerAIAgentConfigurationIsNull)
            {
                requestConfiguration_configuration_EmailGenerativeAnswerAIAgentConfiguration = null;
            }
            if (requestConfiguration_configuration_EmailGenerativeAnswerAIAgentConfiguration != null)
            {
                request.Configuration.EmailGenerativeAnswerAIAgentConfiguration = requestConfiguration_configuration_EmailGenerativeAnswerAIAgentConfiguration;
                requestConfigurationIsNull = false;
            }
            Amazon.QConnect.Model.EmailResponseAIAgentConfiguration requestConfiguration_configuration_EmailResponseAIAgentConfiguration = null;
            
             // populate EmailResponseAIAgentConfiguration
            var requestConfiguration_configuration_EmailResponseAIAgentConfigurationIsNull = true;
            requestConfiguration_configuration_EmailResponseAIAgentConfiguration = new Amazon.QConnect.Model.EmailResponseAIAgentConfiguration();
            List<Amazon.QConnect.Model.AssociationConfiguration> requestConfiguration_configuration_EmailResponseAIAgentConfiguration_emailResponseAIAgentConfiguration_AssociationConfiguration = null;
            if (cmdletContext.EmailResponseAIAgentConfiguration_AssociationConfiguration != null)
            {
                requestConfiguration_configuration_EmailResponseAIAgentConfiguration_emailResponseAIAgentConfiguration_AssociationConfiguration = cmdletContext.EmailResponseAIAgentConfiguration_AssociationConfiguration;
            }
            if (requestConfiguration_configuration_EmailResponseAIAgentConfiguration_emailResponseAIAgentConfiguration_AssociationConfiguration != null)
            {
                requestConfiguration_configuration_EmailResponseAIAgentConfiguration.AssociationConfigurations = requestConfiguration_configuration_EmailResponseAIAgentConfiguration_emailResponseAIAgentConfiguration_AssociationConfiguration;
                requestConfiguration_configuration_EmailResponseAIAgentConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_EmailResponseAIAgentConfiguration_emailResponseAIAgentConfiguration_EmailQueryReformulationAIPromptId = null;
            if (cmdletContext.EmailResponseAIAgentConfiguration_EmailQueryReformulationAIPromptId != null)
            {
                requestConfiguration_configuration_EmailResponseAIAgentConfiguration_emailResponseAIAgentConfiguration_EmailQueryReformulationAIPromptId = cmdletContext.EmailResponseAIAgentConfiguration_EmailQueryReformulationAIPromptId;
            }
            if (requestConfiguration_configuration_EmailResponseAIAgentConfiguration_emailResponseAIAgentConfiguration_EmailQueryReformulationAIPromptId != null)
            {
                requestConfiguration_configuration_EmailResponseAIAgentConfiguration.EmailQueryReformulationAIPromptId = requestConfiguration_configuration_EmailResponseAIAgentConfiguration_emailResponseAIAgentConfiguration_EmailQueryReformulationAIPromptId;
                requestConfiguration_configuration_EmailResponseAIAgentConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_EmailResponseAIAgentConfiguration_emailResponseAIAgentConfiguration_EmailResponseAIPromptId = null;
            if (cmdletContext.EmailResponseAIAgentConfiguration_EmailResponseAIPromptId != null)
            {
                requestConfiguration_configuration_EmailResponseAIAgentConfiguration_emailResponseAIAgentConfiguration_EmailResponseAIPromptId = cmdletContext.EmailResponseAIAgentConfiguration_EmailResponseAIPromptId;
            }
            if (requestConfiguration_configuration_EmailResponseAIAgentConfiguration_emailResponseAIAgentConfiguration_EmailResponseAIPromptId != null)
            {
                requestConfiguration_configuration_EmailResponseAIAgentConfiguration.EmailResponseAIPromptId = requestConfiguration_configuration_EmailResponseAIAgentConfiguration_emailResponseAIAgentConfiguration_EmailResponseAIPromptId;
                requestConfiguration_configuration_EmailResponseAIAgentConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_EmailResponseAIAgentConfiguration_emailResponseAIAgentConfiguration_Locale = null;
            if (cmdletContext.EmailResponseAIAgentConfiguration_Locale != null)
            {
                requestConfiguration_configuration_EmailResponseAIAgentConfiguration_emailResponseAIAgentConfiguration_Locale = cmdletContext.EmailResponseAIAgentConfiguration_Locale;
            }
            if (requestConfiguration_configuration_EmailResponseAIAgentConfiguration_emailResponseAIAgentConfiguration_Locale != null)
            {
                requestConfiguration_configuration_EmailResponseAIAgentConfiguration.Locale = requestConfiguration_configuration_EmailResponseAIAgentConfiguration_emailResponseAIAgentConfiguration_Locale;
                requestConfiguration_configuration_EmailResponseAIAgentConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_EmailResponseAIAgentConfiguration should be set to null
            if (requestConfiguration_configuration_EmailResponseAIAgentConfigurationIsNull)
            {
                requestConfiguration_configuration_EmailResponseAIAgentConfiguration = null;
            }
            if (requestConfiguration_configuration_EmailResponseAIAgentConfiguration != null)
            {
                request.Configuration.EmailResponseAIAgentConfiguration = requestConfiguration_configuration_EmailResponseAIAgentConfiguration;
                requestConfigurationIsNull = false;
            }
            Amazon.QConnect.Model.ManualSearchAIAgentConfiguration requestConfiguration_configuration_ManualSearchAIAgentConfiguration = null;
            
             // populate ManualSearchAIAgentConfiguration
            var requestConfiguration_configuration_ManualSearchAIAgentConfigurationIsNull = true;
            requestConfiguration_configuration_ManualSearchAIAgentConfiguration = new Amazon.QConnect.Model.ManualSearchAIAgentConfiguration();
            System.String requestConfiguration_configuration_ManualSearchAIAgentConfiguration_manualSearchAIAgentConfiguration_AnswerGenerationAIGuardrailId = null;
            if (cmdletContext.ManualSearchAIAgentConfiguration_AnswerGenerationAIGuardrailId != null)
            {
                requestConfiguration_configuration_ManualSearchAIAgentConfiguration_manualSearchAIAgentConfiguration_AnswerGenerationAIGuardrailId = cmdletContext.ManualSearchAIAgentConfiguration_AnswerGenerationAIGuardrailId;
            }
            if (requestConfiguration_configuration_ManualSearchAIAgentConfiguration_manualSearchAIAgentConfiguration_AnswerGenerationAIGuardrailId != null)
            {
                requestConfiguration_configuration_ManualSearchAIAgentConfiguration.AnswerGenerationAIGuardrailId = requestConfiguration_configuration_ManualSearchAIAgentConfiguration_manualSearchAIAgentConfiguration_AnswerGenerationAIGuardrailId;
                requestConfiguration_configuration_ManualSearchAIAgentConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_ManualSearchAIAgentConfiguration_manualSearchAIAgentConfiguration_AnswerGenerationAIPromptId = null;
            if (cmdletContext.ManualSearchAIAgentConfiguration_AnswerGenerationAIPromptId != null)
            {
                requestConfiguration_configuration_ManualSearchAIAgentConfiguration_manualSearchAIAgentConfiguration_AnswerGenerationAIPromptId = cmdletContext.ManualSearchAIAgentConfiguration_AnswerGenerationAIPromptId;
            }
            if (requestConfiguration_configuration_ManualSearchAIAgentConfiguration_manualSearchAIAgentConfiguration_AnswerGenerationAIPromptId != null)
            {
                requestConfiguration_configuration_ManualSearchAIAgentConfiguration.AnswerGenerationAIPromptId = requestConfiguration_configuration_ManualSearchAIAgentConfiguration_manualSearchAIAgentConfiguration_AnswerGenerationAIPromptId;
                requestConfiguration_configuration_ManualSearchAIAgentConfigurationIsNull = false;
            }
            List<Amazon.QConnect.Model.AssociationConfiguration> requestConfiguration_configuration_ManualSearchAIAgentConfiguration_manualSearchAIAgentConfiguration_AssociationConfiguration = null;
            if (cmdletContext.ManualSearchAIAgentConfiguration_AssociationConfiguration != null)
            {
                requestConfiguration_configuration_ManualSearchAIAgentConfiguration_manualSearchAIAgentConfiguration_AssociationConfiguration = cmdletContext.ManualSearchAIAgentConfiguration_AssociationConfiguration;
            }
            if (requestConfiguration_configuration_ManualSearchAIAgentConfiguration_manualSearchAIAgentConfiguration_AssociationConfiguration != null)
            {
                requestConfiguration_configuration_ManualSearchAIAgentConfiguration.AssociationConfigurations = requestConfiguration_configuration_ManualSearchAIAgentConfiguration_manualSearchAIAgentConfiguration_AssociationConfiguration;
                requestConfiguration_configuration_ManualSearchAIAgentConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_ManualSearchAIAgentConfiguration_manualSearchAIAgentConfiguration_Locale = null;
            if (cmdletContext.ManualSearchAIAgentConfiguration_Locale != null)
            {
                requestConfiguration_configuration_ManualSearchAIAgentConfiguration_manualSearchAIAgentConfiguration_Locale = cmdletContext.ManualSearchAIAgentConfiguration_Locale;
            }
            if (requestConfiguration_configuration_ManualSearchAIAgentConfiguration_manualSearchAIAgentConfiguration_Locale != null)
            {
                requestConfiguration_configuration_ManualSearchAIAgentConfiguration.Locale = requestConfiguration_configuration_ManualSearchAIAgentConfiguration_manualSearchAIAgentConfiguration_Locale;
                requestConfiguration_configuration_ManualSearchAIAgentConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_ManualSearchAIAgentConfiguration should be set to null
            if (requestConfiguration_configuration_ManualSearchAIAgentConfigurationIsNull)
            {
                requestConfiguration_configuration_ManualSearchAIAgentConfiguration = null;
            }
            if (requestConfiguration_configuration_ManualSearchAIAgentConfiguration != null)
            {
                request.Configuration.ManualSearchAIAgentConfiguration = requestConfiguration_configuration_ManualSearchAIAgentConfiguration;
                requestConfigurationIsNull = false;
            }
            Amazon.QConnect.Model.SelfServiceAIAgentConfiguration requestConfiguration_configuration_SelfServiceAIAgentConfiguration = null;
            
             // populate SelfServiceAIAgentConfiguration
            var requestConfiguration_configuration_SelfServiceAIAgentConfigurationIsNull = true;
            requestConfiguration_configuration_SelfServiceAIAgentConfiguration = new Amazon.QConnect.Model.SelfServiceAIAgentConfiguration();
            List<Amazon.QConnect.Model.AssociationConfiguration> requestConfiguration_configuration_SelfServiceAIAgentConfiguration_selfServiceAIAgentConfiguration_AssociationConfiguration = null;
            if (cmdletContext.SelfServiceAIAgentConfiguration_AssociationConfiguration != null)
            {
                requestConfiguration_configuration_SelfServiceAIAgentConfiguration_selfServiceAIAgentConfiguration_AssociationConfiguration = cmdletContext.SelfServiceAIAgentConfiguration_AssociationConfiguration;
            }
            if (requestConfiguration_configuration_SelfServiceAIAgentConfiguration_selfServiceAIAgentConfiguration_AssociationConfiguration != null)
            {
                requestConfiguration_configuration_SelfServiceAIAgentConfiguration.AssociationConfigurations = requestConfiguration_configuration_SelfServiceAIAgentConfiguration_selfServiceAIAgentConfiguration_AssociationConfiguration;
                requestConfiguration_configuration_SelfServiceAIAgentConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_SelfServiceAIAgentConfiguration_selfServiceAIAgentConfiguration_SelfServiceAIGuardrailId = null;
            if (cmdletContext.SelfServiceAIAgentConfiguration_SelfServiceAIGuardrailId != null)
            {
                requestConfiguration_configuration_SelfServiceAIAgentConfiguration_selfServiceAIAgentConfiguration_SelfServiceAIGuardrailId = cmdletContext.SelfServiceAIAgentConfiguration_SelfServiceAIGuardrailId;
            }
            if (requestConfiguration_configuration_SelfServiceAIAgentConfiguration_selfServiceAIAgentConfiguration_SelfServiceAIGuardrailId != null)
            {
                requestConfiguration_configuration_SelfServiceAIAgentConfiguration.SelfServiceAIGuardrailId = requestConfiguration_configuration_SelfServiceAIAgentConfiguration_selfServiceAIAgentConfiguration_SelfServiceAIGuardrailId;
                requestConfiguration_configuration_SelfServiceAIAgentConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_SelfServiceAIAgentConfiguration_selfServiceAIAgentConfiguration_SelfServiceAnswerGenerationAIPromptId = null;
            if (cmdletContext.SelfServiceAIAgentConfiguration_SelfServiceAnswerGenerationAIPromptId != null)
            {
                requestConfiguration_configuration_SelfServiceAIAgentConfiguration_selfServiceAIAgentConfiguration_SelfServiceAnswerGenerationAIPromptId = cmdletContext.SelfServiceAIAgentConfiguration_SelfServiceAnswerGenerationAIPromptId;
            }
            if (requestConfiguration_configuration_SelfServiceAIAgentConfiguration_selfServiceAIAgentConfiguration_SelfServiceAnswerGenerationAIPromptId != null)
            {
                requestConfiguration_configuration_SelfServiceAIAgentConfiguration.SelfServiceAnswerGenerationAIPromptId = requestConfiguration_configuration_SelfServiceAIAgentConfiguration_selfServiceAIAgentConfiguration_SelfServiceAnswerGenerationAIPromptId;
                requestConfiguration_configuration_SelfServiceAIAgentConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_SelfServiceAIAgentConfiguration_selfServiceAIAgentConfiguration_SelfServicePreProcessingAIPromptId = null;
            if (cmdletContext.SelfServiceAIAgentConfiguration_SelfServicePreProcessingAIPromptId != null)
            {
                requestConfiguration_configuration_SelfServiceAIAgentConfiguration_selfServiceAIAgentConfiguration_SelfServicePreProcessingAIPromptId = cmdletContext.SelfServiceAIAgentConfiguration_SelfServicePreProcessingAIPromptId;
            }
            if (requestConfiguration_configuration_SelfServiceAIAgentConfiguration_selfServiceAIAgentConfiguration_SelfServicePreProcessingAIPromptId != null)
            {
                requestConfiguration_configuration_SelfServiceAIAgentConfiguration.SelfServicePreProcessingAIPromptId = requestConfiguration_configuration_SelfServiceAIAgentConfiguration_selfServiceAIAgentConfiguration_SelfServicePreProcessingAIPromptId;
                requestConfiguration_configuration_SelfServiceAIAgentConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_SelfServiceAIAgentConfiguration should be set to null
            if (requestConfiguration_configuration_SelfServiceAIAgentConfigurationIsNull)
            {
                requestConfiguration_configuration_SelfServiceAIAgentConfiguration = null;
            }
            if (requestConfiguration_configuration_SelfServiceAIAgentConfiguration != null)
            {
                request.Configuration.SelfServiceAIAgentConfiguration = requestConfiguration_configuration_SelfServiceAIAgentConfiguration;
                requestConfigurationIsNull = false;
            }
            Amazon.QConnect.Model.OrchestrationAIAgentConfiguration requestConfiguration_configuration_OrchestrationAIAgentConfiguration = null;
            
             // populate OrchestrationAIAgentConfiguration
            var requestConfiguration_configuration_OrchestrationAIAgentConfigurationIsNull = true;
            requestConfiguration_configuration_OrchestrationAIAgentConfiguration = new Amazon.QConnect.Model.OrchestrationAIAgentConfiguration();
            System.String requestConfiguration_configuration_OrchestrationAIAgentConfiguration_orchestrationAIAgentConfiguration_ConnectInstanceArn = null;
            if (cmdletContext.OrchestrationAIAgentConfiguration_ConnectInstanceArn != null)
            {
                requestConfiguration_configuration_OrchestrationAIAgentConfiguration_orchestrationAIAgentConfiguration_ConnectInstanceArn = cmdletContext.OrchestrationAIAgentConfiguration_ConnectInstanceArn;
            }
            if (requestConfiguration_configuration_OrchestrationAIAgentConfiguration_orchestrationAIAgentConfiguration_ConnectInstanceArn != null)
            {
                requestConfiguration_configuration_OrchestrationAIAgentConfiguration.ConnectInstanceArn = requestConfiguration_configuration_OrchestrationAIAgentConfiguration_orchestrationAIAgentConfiguration_ConnectInstanceArn;
                requestConfiguration_configuration_OrchestrationAIAgentConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_OrchestrationAIAgentConfiguration_orchestrationAIAgentConfiguration_Locale = null;
            if (cmdletContext.OrchestrationAIAgentConfiguration_Locale != null)
            {
                requestConfiguration_configuration_OrchestrationAIAgentConfiguration_orchestrationAIAgentConfiguration_Locale = cmdletContext.OrchestrationAIAgentConfiguration_Locale;
            }
            if (requestConfiguration_configuration_OrchestrationAIAgentConfiguration_orchestrationAIAgentConfiguration_Locale != null)
            {
                requestConfiguration_configuration_OrchestrationAIAgentConfiguration.Locale = requestConfiguration_configuration_OrchestrationAIAgentConfiguration_orchestrationAIAgentConfiguration_Locale;
                requestConfiguration_configuration_OrchestrationAIAgentConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_OrchestrationAIAgentConfiguration_orchestrationAIAgentConfiguration_OrchestrationAIGuardrailId = null;
            if (cmdletContext.OrchestrationAIAgentConfiguration_OrchestrationAIGuardrailId != null)
            {
                requestConfiguration_configuration_OrchestrationAIAgentConfiguration_orchestrationAIAgentConfiguration_OrchestrationAIGuardrailId = cmdletContext.OrchestrationAIAgentConfiguration_OrchestrationAIGuardrailId;
            }
            if (requestConfiguration_configuration_OrchestrationAIAgentConfiguration_orchestrationAIAgentConfiguration_OrchestrationAIGuardrailId != null)
            {
                requestConfiguration_configuration_OrchestrationAIAgentConfiguration.OrchestrationAIGuardrailId = requestConfiguration_configuration_OrchestrationAIAgentConfiguration_orchestrationAIAgentConfiguration_OrchestrationAIGuardrailId;
                requestConfiguration_configuration_OrchestrationAIAgentConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_OrchestrationAIAgentConfiguration_orchestrationAIAgentConfiguration_OrchestrationAIPromptId = null;
            if (cmdletContext.OrchestrationAIAgentConfiguration_OrchestrationAIPromptId != null)
            {
                requestConfiguration_configuration_OrchestrationAIAgentConfiguration_orchestrationAIAgentConfiguration_OrchestrationAIPromptId = cmdletContext.OrchestrationAIAgentConfiguration_OrchestrationAIPromptId;
            }
            if (requestConfiguration_configuration_OrchestrationAIAgentConfiguration_orchestrationAIAgentConfiguration_OrchestrationAIPromptId != null)
            {
                requestConfiguration_configuration_OrchestrationAIAgentConfiguration.OrchestrationAIPromptId = requestConfiguration_configuration_OrchestrationAIAgentConfiguration_orchestrationAIAgentConfiguration_OrchestrationAIPromptId;
                requestConfiguration_configuration_OrchestrationAIAgentConfigurationIsNull = false;
            }
            List<Amazon.QConnect.Model.ToolConfiguration> requestConfiguration_configuration_OrchestrationAIAgentConfiguration_orchestrationAIAgentConfiguration_ToolConfiguration = null;
            if (cmdletContext.OrchestrationAIAgentConfiguration_ToolConfiguration != null)
            {
                requestConfiguration_configuration_OrchestrationAIAgentConfiguration_orchestrationAIAgentConfiguration_ToolConfiguration = cmdletContext.OrchestrationAIAgentConfiguration_ToolConfiguration;
            }
            if (requestConfiguration_configuration_OrchestrationAIAgentConfiguration_orchestrationAIAgentConfiguration_ToolConfiguration != null)
            {
                requestConfiguration_configuration_OrchestrationAIAgentConfiguration.ToolConfigurations = requestConfiguration_configuration_OrchestrationAIAgentConfiguration_orchestrationAIAgentConfiguration_ToolConfiguration;
                requestConfiguration_configuration_OrchestrationAIAgentConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_OrchestrationAIAgentConfiguration should be set to null
            if (requestConfiguration_configuration_OrchestrationAIAgentConfigurationIsNull)
            {
                requestConfiguration_configuration_OrchestrationAIAgentConfiguration = null;
            }
            if (requestConfiguration_configuration_OrchestrationAIAgentConfiguration != null)
            {
                request.Configuration.OrchestrationAIAgentConfiguration = requestConfiguration_configuration_OrchestrationAIAgentConfiguration;
                requestConfigurationIsNull = false;
            }
            Amazon.QConnect.Model.AnswerRecommendationAIAgentConfiguration requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration = null;
            
             // populate AnswerRecommendationAIAgentConfiguration
            var requestConfiguration_configuration_AnswerRecommendationAIAgentConfigurationIsNull = true;
            requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration = new Amazon.QConnect.Model.AnswerRecommendationAIAgentConfiguration();
            System.String requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_AnswerGenerationAIGuardrailId = null;
            if (cmdletContext.AnswerRecommendationAIAgentConfiguration_AnswerGenerationAIGuardrailId != null)
            {
                requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_AnswerGenerationAIGuardrailId = cmdletContext.AnswerRecommendationAIAgentConfiguration_AnswerGenerationAIGuardrailId;
            }
            if (requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_AnswerGenerationAIGuardrailId != null)
            {
                requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration.AnswerGenerationAIGuardrailId = requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_AnswerGenerationAIGuardrailId;
                requestConfiguration_configuration_AnswerRecommendationAIAgentConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_AnswerGenerationAIPromptId = null;
            if (cmdletContext.AnswerRecommendationAIAgentConfiguration_AnswerGenerationAIPromptId != null)
            {
                requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_AnswerGenerationAIPromptId = cmdletContext.AnswerRecommendationAIAgentConfiguration_AnswerGenerationAIPromptId;
            }
            if (requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_AnswerGenerationAIPromptId != null)
            {
                requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration.AnswerGenerationAIPromptId = requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_AnswerGenerationAIPromptId;
                requestConfiguration_configuration_AnswerRecommendationAIAgentConfigurationIsNull = false;
            }
            List<Amazon.QConnect.Model.AssociationConfiguration> requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_AssociationConfiguration = null;
            if (cmdletContext.AnswerRecommendationAIAgentConfiguration_AssociationConfiguration != null)
            {
                requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_AssociationConfiguration = cmdletContext.AnswerRecommendationAIAgentConfiguration_AssociationConfiguration;
            }
            if (requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_AssociationConfiguration != null)
            {
                requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration.AssociationConfigurations = requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_AssociationConfiguration;
                requestConfiguration_configuration_AnswerRecommendationAIAgentConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_IntentLabelingGenerationAIPromptId = null;
            if (cmdletContext.AnswerRecommendationAIAgentConfiguration_IntentLabelingGenerationAIPromptId != null)
            {
                requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_IntentLabelingGenerationAIPromptId = cmdletContext.AnswerRecommendationAIAgentConfiguration_IntentLabelingGenerationAIPromptId;
            }
            if (requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_IntentLabelingGenerationAIPromptId != null)
            {
                requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration.IntentLabelingGenerationAIPromptId = requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_IntentLabelingGenerationAIPromptId;
                requestConfiguration_configuration_AnswerRecommendationAIAgentConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_Locale = null;
            if (cmdletContext.AnswerRecommendationAIAgentConfiguration_Locale != null)
            {
                requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_Locale = cmdletContext.AnswerRecommendationAIAgentConfiguration_Locale;
            }
            if (requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_Locale != null)
            {
                requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration.Locale = requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_Locale;
                requestConfiguration_configuration_AnswerRecommendationAIAgentConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_QueryReformulationAIPromptId = null;
            if (cmdletContext.AnswerRecommendationAIAgentConfiguration_QueryReformulationAIPromptId != null)
            {
                requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_QueryReformulationAIPromptId = cmdletContext.AnswerRecommendationAIAgentConfiguration_QueryReformulationAIPromptId;
            }
            if (requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_QueryReformulationAIPromptId != null)
            {
                requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration.QueryReformulationAIPromptId = requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_QueryReformulationAIPromptId;
                requestConfiguration_configuration_AnswerRecommendationAIAgentConfigurationIsNull = false;
            }
            List<System.String> requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_SuggestedMessage = null;
            if (cmdletContext.AnswerRecommendationAIAgentConfiguration_SuggestedMessage != null)
            {
                requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_SuggestedMessage = cmdletContext.AnswerRecommendationAIAgentConfiguration_SuggestedMessage;
            }
            if (requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_SuggestedMessage != null)
            {
                requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration.SuggestedMessages = requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_SuggestedMessage;
                requestConfiguration_configuration_AnswerRecommendationAIAgentConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration should be set to null
            if (requestConfiguration_configuration_AnswerRecommendationAIAgentConfigurationIsNull)
            {
                requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration = null;
            }
            if (requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration != null)
            {
                request.Configuration.AnswerRecommendationAIAgentConfiguration = requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.VisibilityStatus != null)
            {
                request.VisibilityStatus = cmdletContext.VisibilityStatus;
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
        
        private Amazon.QConnect.Model.UpdateAIAgentResponse CallAWSServiceOperation(IAmazonQConnect client, Amazon.QConnect.Model.UpdateAIAgentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Q Connect", "UpdateAIAgent");
            try
            {
                #if DESKTOP
                return client.UpdateAIAgent(request);
                #elif CORECLR
                return client.UpdateAIAgentAsync(request).GetAwaiter().GetResult();
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
            public System.String AiAgentId { get; set; }
            public System.String AssistantId { get; set; }
            public System.String ClientToken { get; set; }
            public System.String AnswerRecommendationAIAgentConfiguration_AnswerGenerationAIGuardrailId { get; set; }
            public System.String AnswerRecommendationAIAgentConfiguration_AnswerGenerationAIPromptId { get; set; }
            public List<Amazon.QConnect.Model.AssociationConfiguration> AnswerRecommendationAIAgentConfiguration_AssociationConfiguration { get; set; }
            public System.String AnswerRecommendationAIAgentConfiguration_IntentLabelingGenerationAIPromptId { get; set; }
            public System.String AnswerRecommendationAIAgentConfiguration_Locale { get; set; }
            public System.String AnswerRecommendationAIAgentConfiguration_QueryReformulationAIPromptId { get; set; }
            public List<System.String> AnswerRecommendationAIAgentConfiguration_SuggestedMessage { get; set; }
            public System.String CaseSummarizationAIAgentConfiguration_CaseSummarizationAIGuardrailId { get; set; }
            public System.String CaseSummarizationAIAgentConfiguration_CaseSummarizationAIPromptId { get; set; }
            public System.String CaseSummarizationAIAgentConfiguration_Locale { get; set; }
            public List<Amazon.QConnect.Model.AssociationConfiguration> EmailGenerativeAnswerAIAgentConfiguration_AssociationConfiguration { get; set; }
            public System.String EmailGenerativeAnswerAIAgentConfiguration_EmailGenerativeAnswerAIPromptId { get; set; }
            public System.String EmailGenerativeAnswerAIAgentConfiguration_EmailQueryReformulationAIPromptId { get; set; }
            public System.String EmailGenerativeAnswerAIAgentConfiguration_Locale { get; set; }
            public System.String EmailOverviewAIAgentConfiguration_EmailOverviewAIPromptId { get; set; }
            public System.String EmailOverviewAIAgentConfiguration_Locale { get; set; }
            public List<Amazon.QConnect.Model.AssociationConfiguration> EmailResponseAIAgentConfiguration_AssociationConfiguration { get; set; }
            public System.String EmailResponseAIAgentConfiguration_EmailQueryReformulationAIPromptId { get; set; }
            public System.String EmailResponseAIAgentConfiguration_EmailResponseAIPromptId { get; set; }
            public System.String EmailResponseAIAgentConfiguration_Locale { get; set; }
            public System.String ManualSearchAIAgentConfiguration_AnswerGenerationAIGuardrailId { get; set; }
            public System.String ManualSearchAIAgentConfiguration_AnswerGenerationAIPromptId { get; set; }
            public List<Amazon.QConnect.Model.AssociationConfiguration> ManualSearchAIAgentConfiguration_AssociationConfiguration { get; set; }
            public System.String ManualSearchAIAgentConfiguration_Locale { get; set; }
            public System.String NoteTakingAIAgentConfiguration_Locale { get; set; }
            public System.String NoteTakingAIAgentConfiguration_NoteTakingAIGuardrailId { get; set; }
            public System.String NoteTakingAIAgentConfiguration_NoteTakingAIPromptId { get; set; }
            public System.String OrchestrationAIAgentConfiguration_ConnectInstanceArn { get; set; }
            public System.String OrchestrationAIAgentConfiguration_Locale { get; set; }
            public System.String OrchestrationAIAgentConfiguration_OrchestrationAIGuardrailId { get; set; }
            public System.String OrchestrationAIAgentConfiguration_OrchestrationAIPromptId { get; set; }
            public List<Amazon.QConnect.Model.ToolConfiguration> OrchestrationAIAgentConfiguration_ToolConfiguration { get; set; }
            public List<Amazon.QConnect.Model.AssociationConfiguration> SelfServiceAIAgentConfiguration_AssociationConfiguration { get; set; }
            public System.String SelfServiceAIAgentConfiguration_SelfServiceAIGuardrailId { get; set; }
            public System.String SelfServiceAIAgentConfiguration_SelfServiceAnswerGenerationAIPromptId { get; set; }
            public System.String SelfServiceAIAgentConfiguration_SelfServicePreProcessingAIPromptId { get; set; }
            public System.String Description { get; set; }
            public Amazon.QConnect.VisibilityStatus VisibilityStatus { get; set; }
            public System.Func<Amazon.QConnect.Model.UpdateAIAgentResponse, UpdateQCAIAgentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AiAgent;
        }
        
    }
}
