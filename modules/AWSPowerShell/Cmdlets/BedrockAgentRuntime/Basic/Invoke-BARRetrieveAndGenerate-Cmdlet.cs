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
using Amazon.BedrockAgentRuntime;
using Amazon.BedrockAgentRuntime.Model;

namespace Amazon.PowerShell.Cmdlets.BAR
{
    /// <summary>
    /// Queries a knowledge base and generates responses based on the retrieved results. The
    /// response cites up to five sources but only selects the ones that are relevant to the
    /// query.
    /// </summary>
    [Cmdlet("Invoke", "BARRetrieveAndGenerate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentRuntime.Model.RetrieveAndGenerateResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Runtime RetrieveAndGenerate API operation.", Operation = new[] {"RetrieveAndGenerate"}, SelectReturnType = typeof(Amazon.BedrockAgentRuntime.Model.RetrieveAndGenerateResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentRuntime.Model.RetrieveAndGenerateResponse",
        "This cmdlet returns an Amazon.BedrockAgentRuntime.Model.RetrieveAndGenerateResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class InvokeBARRetrieveAndGenerateCmdlet : AmazonBedrockAgentRuntimeClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SessionConfiguration_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the KMS key encrypting the session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SessionConfiguration_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter KnowledgeBaseConfiguration_KnowledgeBaseId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the knowledge base that is queried and the foundation model
        /// used for generation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_KnowledgeBaseId")]
        public System.String KnowledgeBaseConfiguration_KnowledgeBaseId { get; set; }
        #endregion
        
        #region Parameter KnowledgeBaseConfiguration_ModelArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the foundation model used to generate a response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_ModelArn")]
        public System.String KnowledgeBaseConfiguration_ModelArn { get; set; }
        #endregion
        
        #region Parameter VectorSearchConfiguration_NumberOfResult
        /// <summary>
        /// <para>
        /// <para>The number of source chunks to retrieve.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration_VectorSearchConfiguration_NumberOfResults")]
        public System.Int32? VectorSearchConfiguration_NumberOfResult { get; set; }
        #endregion
        
        #region Parameter VectorSearchConfiguration_OverrideSearchType
        /// <summary>
        /// <para>
        /// <para>By default, Amazon Bedrock decides a search strategy for you. If you're using an Amazon
        /// OpenSearch Serverless vector store that contains a filterable text field, you can
        /// specify whether to query the knowledge base with a <c>HYBRID</c> search using both
        /// vector embeddings and raw text, or <c>SEMANTIC</c> search using only vector embeddings.
        /// For other vector store configurations, only <c>SEMANTIC</c> search is available. For
        /// more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/knowledge-base-test.html">Test
        /// a knowledge base</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration_VectorSearchConfiguration_OverrideSearchType")]
        [AWSConstantClassSource("Amazon.BedrockAgentRuntime.SearchType")]
        public Amazon.BedrockAgentRuntime.SearchType VectorSearchConfiguration_OverrideSearchType { get; set; }
        #endregion
        
        #region Parameter SessionId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the session. Reuse the same value to continue the same session
        /// with the knowledge base.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SessionId { get; set; }
        #endregion
        
        #region Parameter Input_Text
        /// <summary>
        /// <para>
        /// <para>The query made to the knowledge base.</para>
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
        public System.String Input_Text { get; set; }
        #endregion
        
        #region Parameter PromptTemplate_TextPromptTemplate
        /// <summary>
        /// <para>
        /// <para>The template for the prompt that's sent to the model for response generation. You
        /// can include prompt placeholders, which become replaced before the prompt is sent to
        /// the model to provide instructions and context to the model. In addition, you can include
        /// XML tags to delineate meaningful sections of the prompt template.</para><para>For more information, see the following resources:</para><ul><li><para><a href="https://docs.aws.amazon.com/bedrock/latest/userguide/kb-test-config.html#kb-test-config-sysprompt">Knowledge
        /// base prompt templates</a></para></li><li><para><a href="https://docs.anthropic.com/claude/docs/use-xml-tags">Use XML tags with Anthropic
        /// Claude models</a></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_GenerationConfiguration_PromptTemplate_TextPromptTemplate")]
        public System.String PromptTemplate_TextPromptTemplate { get; set; }
        #endregion
        
        #region Parameter RetrieveAndGenerateConfiguration_Type
        /// <summary>
        /// <para>
        /// <para>The type of resource that is queried by the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentRuntime.RetrieveAndGenerateType")]
        public Amazon.BedrockAgentRuntime.RetrieveAndGenerateType RetrieveAndGenerateConfiguration_Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentRuntime.Model.RetrieveAndGenerateResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentRuntime.Model.RetrieveAndGenerateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Input_Text parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Input_Text' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Input_Text' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SessionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-BARRetrieveAndGenerate (RetrieveAndGenerate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentRuntime.Model.RetrieveAndGenerateResponse, InvokeBARRetrieveAndGenerateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Input_Text;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Input_Text = this.Input_Text;
            #if MODULAR
            if (this.Input_Text == null && ParameterWasBound(nameof(this.Input_Text)))
            {
                WriteWarning("You are passing $null as a value for parameter Input_Text which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PromptTemplate_TextPromptTemplate = this.PromptTemplate_TextPromptTemplate;
            context.KnowledgeBaseConfiguration_KnowledgeBaseId = this.KnowledgeBaseConfiguration_KnowledgeBaseId;
            context.KnowledgeBaseConfiguration_ModelArn = this.KnowledgeBaseConfiguration_ModelArn;
            context.VectorSearchConfiguration_NumberOfResult = this.VectorSearchConfiguration_NumberOfResult;
            context.VectorSearchConfiguration_OverrideSearchType = this.VectorSearchConfiguration_OverrideSearchType;
            context.RetrieveAndGenerateConfiguration_Type = this.RetrieveAndGenerateConfiguration_Type;
            context.SessionConfiguration_KmsKeyArn = this.SessionConfiguration_KmsKeyArn;
            context.SessionId = this.SessionId;
            
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
            var request = new Amazon.BedrockAgentRuntime.Model.RetrieveAndGenerateRequest();
            
            
             // populate Input
            var requestInputIsNull = true;
            request.Input = new Amazon.BedrockAgentRuntime.Model.RetrieveAndGenerateInput();
            System.String requestInput_input_Text = null;
            if (cmdletContext.Input_Text != null)
            {
                requestInput_input_Text = cmdletContext.Input_Text;
            }
            if (requestInput_input_Text != null)
            {
                request.Input.Text = requestInput_input_Text;
                requestInputIsNull = false;
            }
             // determine if request.Input should be set to null
            if (requestInputIsNull)
            {
                request.Input = null;
            }
            
             // populate RetrieveAndGenerateConfiguration
            var requestRetrieveAndGenerateConfigurationIsNull = true;
            request.RetrieveAndGenerateConfiguration = new Amazon.BedrockAgentRuntime.Model.RetrieveAndGenerateConfiguration();
            Amazon.BedrockAgentRuntime.RetrieveAndGenerateType requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_Type = null;
            if (cmdletContext.RetrieveAndGenerateConfiguration_Type != null)
            {
                requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_Type = cmdletContext.RetrieveAndGenerateConfiguration_Type;
            }
            if (requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_Type != null)
            {
                request.RetrieveAndGenerateConfiguration.Type = requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_Type;
                requestRetrieveAndGenerateConfigurationIsNull = false;
            }
            Amazon.BedrockAgentRuntime.Model.KnowledgeBaseRetrieveAndGenerateConfiguration requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration = null;
            
             // populate KnowledgeBaseConfiguration
            var requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfigurationIsNull = true;
            requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration = new Amazon.BedrockAgentRuntime.Model.KnowledgeBaseRetrieveAndGenerateConfiguration();
            System.String requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_knowledgeBaseConfiguration_KnowledgeBaseId = null;
            if (cmdletContext.KnowledgeBaseConfiguration_KnowledgeBaseId != null)
            {
                requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_knowledgeBaseConfiguration_KnowledgeBaseId = cmdletContext.KnowledgeBaseConfiguration_KnowledgeBaseId;
            }
            if (requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_knowledgeBaseConfiguration_KnowledgeBaseId != null)
            {
                requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration.KnowledgeBaseId = requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_knowledgeBaseConfiguration_KnowledgeBaseId;
                requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfigurationIsNull = false;
            }
            System.String requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_knowledgeBaseConfiguration_ModelArn = null;
            if (cmdletContext.KnowledgeBaseConfiguration_ModelArn != null)
            {
                requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_knowledgeBaseConfiguration_ModelArn = cmdletContext.KnowledgeBaseConfiguration_ModelArn;
            }
            if (requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_knowledgeBaseConfiguration_ModelArn != null)
            {
                requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration.ModelArn = requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_knowledgeBaseConfiguration_ModelArn;
                requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfigurationIsNull = false;
            }
            Amazon.BedrockAgentRuntime.Model.GenerationConfiguration requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_GenerationConfiguration = null;
            
             // populate GenerationConfiguration
            var requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_GenerationConfigurationIsNull = true;
            requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_GenerationConfiguration = new Amazon.BedrockAgentRuntime.Model.GenerationConfiguration();
            Amazon.BedrockAgentRuntime.Model.PromptTemplate requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_GenerationConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_GenerationConfiguration_PromptTemplate = null;
            
             // populate PromptTemplate
            var requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_GenerationConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_GenerationConfiguration_PromptTemplateIsNull = true;
            requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_GenerationConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_GenerationConfiguration_PromptTemplate = new Amazon.BedrockAgentRuntime.Model.PromptTemplate();
            System.String requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_GenerationConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_GenerationConfiguration_PromptTemplate_promptTemplate_TextPromptTemplate = null;
            if (cmdletContext.PromptTemplate_TextPromptTemplate != null)
            {
                requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_GenerationConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_GenerationConfiguration_PromptTemplate_promptTemplate_TextPromptTemplate = cmdletContext.PromptTemplate_TextPromptTemplate;
            }
            if (requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_GenerationConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_GenerationConfiguration_PromptTemplate_promptTemplate_TextPromptTemplate != null)
            {
                requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_GenerationConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_GenerationConfiguration_PromptTemplate.TextPromptTemplate = requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_GenerationConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_GenerationConfiguration_PromptTemplate_promptTemplate_TextPromptTemplate;
                requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_GenerationConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_GenerationConfiguration_PromptTemplateIsNull = false;
            }
             // determine if requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_GenerationConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_GenerationConfiguration_PromptTemplate should be set to null
            if (requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_GenerationConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_GenerationConfiguration_PromptTemplateIsNull)
            {
                requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_GenerationConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_GenerationConfiguration_PromptTemplate = null;
            }
            if (requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_GenerationConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_GenerationConfiguration_PromptTemplate != null)
            {
                requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_GenerationConfiguration.PromptTemplate = requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_GenerationConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_GenerationConfiguration_PromptTemplate;
                requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_GenerationConfigurationIsNull = false;
            }
             // determine if requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_GenerationConfiguration should be set to null
            if (requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_GenerationConfigurationIsNull)
            {
                requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_GenerationConfiguration = null;
            }
            if (requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_GenerationConfiguration != null)
            {
                requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration.GenerationConfiguration = requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_GenerationConfiguration;
                requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfigurationIsNull = false;
            }
            Amazon.BedrockAgentRuntime.Model.KnowledgeBaseRetrievalConfiguration requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration = null;
            
             // populate RetrievalConfiguration
            var requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfigurationIsNull = true;
            requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration = new Amazon.BedrockAgentRuntime.Model.KnowledgeBaseRetrievalConfiguration();
            Amazon.BedrockAgentRuntime.Model.KnowledgeBaseVectorSearchConfiguration requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration_VectorSearchConfiguration = null;
            
             // populate VectorSearchConfiguration
            var requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration_VectorSearchConfigurationIsNull = true;
            requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration_VectorSearchConfiguration = new Amazon.BedrockAgentRuntime.Model.KnowledgeBaseVectorSearchConfiguration();
            System.Int32? requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration_VectorSearchConfiguration_vectorSearchConfiguration_NumberOfResult = null;
            if (cmdletContext.VectorSearchConfiguration_NumberOfResult != null)
            {
                requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration_VectorSearchConfiguration_vectorSearchConfiguration_NumberOfResult = cmdletContext.VectorSearchConfiguration_NumberOfResult.Value;
            }
            if (requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration_VectorSearchConfiguration_vectorSearchConfiguration_NumberOfResult != null)
            {
                requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration_VectorSearchConfiguration.NumberOfResults = requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration_VectorSearchConfiguration_vectorSearchConfiguration_NumberOfResult.Value;
                requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration_VectorSearchConfigurationIsNull = false;
            }
            Amazon.BedrockAgentRuntime.SearchType requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration_VectorSearchConfiguration_vectorSearchConfiguration_OverrideSearchType = null;
            if (cmdletContext.VectorSearchConfiguration_OverrideSearchType != null)
            {
                requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration_VectorSearchConfiguration_vectorSearchConfiguration_OverrideSearchType = cmdletContext.VectorSearchConfiguration_OverrideSearchType;
            }
            if (requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration_VectorSearchConfiguration_vectorSearchConfiguration_OverrideSearchType != null)
            {
                requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration_VectorSearchConfiguration.OverrideSearchType = requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration_VectorSearchConfiguration_vectorSearchConfiguration_OverrideSearchType;
                requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration_VectorSearchConfigurationIsNull = false;
            }
             // determine if requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration_VectorSearchConfiguration should be set to null
            if (requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration_VectorSearchConfigurationIsNull)
            {
                requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration_VectorSearchConfiguration = null;
            }
            if (requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration_VectorSearchConfiguration != null)
            {
                requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration.VectorSearchConfiguration = requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration_VectorSearchConfiguration;
                requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfigurationIsNull = false;
            }
             // determine if requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration should be set to null
            if (requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfigurationIsNull)
            {
                requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration = null;
            }
            if (requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration != null)
            {
                requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration.RetrievalConfiguration = requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_RetrievalConfiguration;
                requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfigurationIsNull = false;
            }
             // determine if requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration should be set to null
            if (requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfigurationIsNull)
            {
                requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration = null;
            }
            if (requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration != null)
            {
                request.RetrieveAndGenerateConfiguration.KnowledgeBaseConfiguration = requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration;
                requestRetrieveAndGenerateConfigurationIsNull = false;
            }
             // determine if request.RetrieveAndGenerateConfiguration should be set to null
            if (requestRetrieveAndGenerateConfigurationIsNull)
            {
                request.RetrieveAndGenerateConfiguration = null;
            }
            
             // populate SessionConfiguration
            var requestSessionConfigurationIsNull = true;
            request.SessionConfiguration = new Amazon.BedrockAgentRuntime.Model.RetrieveAndGenerateSessionConfiguration();
            System.String requestSessionConfiguration_sessionConfiguration_KmsKeyArn = null;
            if (cmdletContext.SessionConfiguration_KmsKeyArn != null)
            {
                requestSessionConfiguration_sessionConfiguration_KmsKeyArn = cmdletContext.SessionConfiguration_KmsKeyArn;
            }
            if (requestSessionConfiguration_sessionConfiguration_KmsKeyArn != null)
            {
                request.SessionConfiguration.KmsKeyArn = requestSessionConfiguration_sessionConfiguration_KmsKeyArn;
                requestSessionConfigurationIsNull = false;
            }
             // determine if request.SessionConfiguration should be set to null
            if (requestSessionConfigurationIsNull)
            {
                request.SessionConfiguration = null;
            }
            if (cmdletContext.SessionId != null)
            {
                request.SessionId = cmdletContext.SessionId;
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
        
        private Amazon.BedrockAgentRuntime.Model.RetrieveAndGenerateResponse CallAWSServiceOperation(IAmazonBedrockAgentRuntime client, Amazon.BedrockAgentRuntime.Model.RetrieveAndGenerateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Runtime", "RetrieveAndGenerate");
            try
            {
                #if DESKTOP
                return client.RetrieveAndGenerate(request);
                #elif CORECLR
                return client.RetrieveAndGenerateAsync(request).GetAwaiter().GetResult();
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
            public System.String Input_Text { get; set; }
            public System.String PromptTemplate_TextPromptTemplate { get; set; }
            public System.String KnowledgeBaseConfiguration_KnowledgeBaseId { get; set; }
            public System.String KnowledgeBaseConfiguration_ModelArn { get; set; }
            public System.Int32? VectorSearchConfiguration_NumberOfResult { get; set; }
            public Amazon.BedrockAgentRuntime.SearchType VectorSearchConfiguration_OverrideSearchType { get; set; }
            public Amazon.BedrockAgentRuntime.RetrieveAndGenerateType RetrieveAndGenerateConfiguration_Type { get; set; }
            public System.String SessionConfiguration_KmsKeyArn { get; set; }
            public System.String SessionId { get; set; }
            public System.Func<Amazon.BedrockAgentRuntime.Model.RetrieveAndGenerateResponse, InvokeBARRetrieveAndGenerateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
