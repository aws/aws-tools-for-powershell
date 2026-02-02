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
using Amazon.BedrockAgentCoreControl;
using Amazon.BedrockAgentCoreControl.Model;

namespace Amazon.PowerShell.Cmdlets.BACC
{
    /// <summary>
    /// Creates a custom evaluator for agent quality assessment. Custom evaluators use LLM-as-a-Judge
    /// configurations with user-defined prompts, rating scales, and model settings to evaluate
    /// agent performance at tool call, trace, or session levels.
    /// </summary>
    [Cmdlet("New", "BACCEvaluator", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCoreControl.Model.CreateEvaluatorResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Core Control Plane Fronting Layer CreateEvaluator API operation.", Operation = new[] {"CreateEvaluator"}, SelectReturnType = typeof(Amazon.BedrockAgentCoreControl.Model.CreateEvaluatorResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCoreControl.Model.CreateEvaluatorResponse",
        "This cmdlet returns an Amazon.BedrockAgentCoreControl.Model.CreateEvaluatorResponse object containing multiple properties."
    )]
    public partial class NewBACCEvaluatorCmdlet : AmazonBedrockAgentCoreControlClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BedrockEvaluatorModelConfig_AdditionalModelRequestField
        /// <summary>
        /// <para>
        /// <para> Additional model-specific request fields to customize model behavior beyond the standard
        /// inference configuration. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EvaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_AdditionalModelRequestFields")]
        public System.Management.Automation.PSObject BedrockEvaluatorModelConfig_AdditionalModelRequestField { get; set; }
        #endregion
        
        #region Parameter RatingScale_Categorical
        /// <summary>
        /// <para>
        /// <para> The categorical rating scale with named categories and definitions for qualitative
        /// evaluation. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EvaluatorConfig_LlmAsAJudge_RatingScale_Categorical")]
        public Amazon.BedrockAgentCoreControl.Model.CategoricalScaleDefinition[] RatingScale_Categorical { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para> The description of the evaluator that explains its purpose and evaluation criteria.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EvaluatorName
        /// <summary>
        /// <para>
        /// <para> The name of the evaluator. Must be unique within your account. </para>
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
        public System.String EvaluatorName { get; set; }
        #endregion
        
        #region Parameter LlmAsAJudge_Instruction
        /// <summary>
        /// <para>
        /// <para> The evaluation instructions that guide the language model in assessing agent performance,
        /// including criteria and evaluation guidelines. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EvaluatorConfig_LlmAsAJudge_Instructions")]
        public System.String LlmAsAJudge_Instruction { get; set; }
        #endregion
        
        #region Parameter Level
        /// <summary>
        /// <para>
        /// <para> The evaluation level that determines the scope of evaluation. Valid values are <c>TOOL_CALL</c>
        /// for individual tool invocations, <c>TRACE</c> for single request-response interactions,
        /// or <c>SESSION</c> for entire conversation sessions. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.EvaluatorLevel")]
        public Amazon.BedrockAgentCoreControl.EvaluatorLevel Level { get; set; }
        #endregion
        
        #region Parameter InferenceConfig_MaxToken
        /// <summary>
        /// <para>
        /// <para> The maximum number of tokens to generate in the model response during evaluation.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EvaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_InferenceConfig_MaxTokens")]
        public System.Int32? InferenceConfig_MaxToken { get; set; }
        #endregion
        
        #region Parameter BedrockEvaluatorModelConfig_ModelId
        /// <summary>
        /// <para>
        /// <para> The identifier of the Amazon Bedrock model to use for evaluation. Must be a supported
        /// foundation model available in your region. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EvaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_ModelId")]
        public System.String BedrockEvaluatorModelConfig_ModelId { get; set; }
        #endregion
        
        #region Parameter RatingScale_Numerical
        /// <summary>
        /// <para>
        /// <para> The numerical rating scale with defined score values and descriptions for quantitative
        /// evaluation. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EvaluatorConfig_LlmAsAJudge_RatingScale_Numerical")]
        public Amazon.BedrockAgentCoreControl.Model.NumericalScaleDefinition[] RatingScale_Numerical { get; set; }
        #endregion
        
        #region Parameter InferenceConfig_StopSequence
        /// <summary>
        /// <para>
        /// <para> The list of sequences that will cause the model to stop generating tokens when encountered.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EvaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_InferenceConfig_StopSequences")]
        public System.String[] InferenceConfig_StopSequence { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A map of tag keys and values to assign to an AgentCore Evaluator. Tags enable you
        /// to categorize your resources in different ways, for example, by purpose, owner, or
        /// environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter InferenceConfig_Temperature
        /// <summary>
        /// <para>
        /// <para> The temperature value that controls randomness in the model's responses. Lower values
        /// produce more deterministic outputs. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EvaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_InferenceConfig_Temperature")]
        public System.Single? InferenceConfig_Temperature { get; set; }
        #endregion
        
        #region Parameter InferenceConfig_TopP
        /// <summary>
        /// <para>
        /// <para> The top-p sampling parameter that controls the diversity of the model's responses
        /// by limiting the cumulative probability of token choices. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EvaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_InferenceConfig_TopP")]
        public System.Single? InferenceConfig_TopP { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure that the API request completes no more
        /// than one time. If you don't specify this field, a value is randomly generated for
        /// you. If this token matches a previous request, the service ignores the request, but
        /// doesn't return an error. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCoreControl.Model.CreateEvaluatorResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCoreControl.Model.CreateEvaluatorResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EvaluatorName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BACCEvaluator (CreateEvaluator)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCoreControl.Model.CreateEvaluatorResponse, NewBACCEvaluatorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.LlmAsAJudge_Instruction = this.LlmAsAJudge_Instruction;
            context.BedrockEvaluatorModelConfig_AdditionalModelRequestField = this.BedrockEvaluatorModelConfig_AdditionalModelRequestField;
            context.InferenceConfig_MaxToken = this.InferenceConfig_MaxToken;
            if (this.InferenceConfig_StopSequence != null)
            {
                context.InferenceConfig_StopSequence = new List<System.String>(this.InferenceConfig_StopSequence);
            }
            context.InferenceConfig_Temperature = this.InferenceConfig_Temperature;
            context.InferenceConfig_TopP = this.InferenceConfig_TopP;
            context.BedrockEvaluatorModelConfig_ModelId = this.BedrockEvaluatorModelConfig_ModelId;
            if (this.RatingScale_Categorical != null)
            {
                context.RatingScale_Categorical = new List<Amazon.BedrockAgentCoreControl.Model.CategoricalScaleDefinition>(this.RatingScale_Categorical);
            }
            if (this.RatingScale_Numerical != null)
            {
                context.RatingScale_Numerical = new List<Amazon.BedrockAgentCoreControl.Model.NumericalScaleDefinition>(this.RatingScale_Numerical);
            }
            context.EvaluatorName = this.EvaluatorName;
            #if MODULAR
            if (this.EvaluatorName == null && ParameterWasBound(nameof(this.EvaluatorName)))
            {
                WriteWarning("You are passing $null as a value for parameter EvaluatorName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Level = this.Level;
            #if MODULAR
            if (this.Level == null && ParameterWasBound(nameof(this.Level)))
            {
                WriteWarning("You are passing $null as a value for parameter Level which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.BedrockAgentCoreControl.Model.CreateEvaluatorRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate EvaluatorConfig
            var requestEvaluatorConfigIsNull = true;
            request.EvaluatorConfig = new Amazon.BedrockAgentCoreControl.Model.EvaluatorConfig();
            Amazon.BedrockAgentCoreControl.Model.LlmAsAJudgeEvaluatorConfig requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge = null;
            
             // populate LlmAsAJudge
            var requestEvaluatorConfig_evaluatorConfig_LlmAsAJudgeIsNull = true;
            requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge = new Amazon.BedrockAgentCoreControl.Model.LlmAsAJudgeEvaluatorConfig();
            System.String requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_llmAsAJudge_Instruction = null;
            if (cmdletContext.LlmAsAJudge_Instruction != null)
            {
                requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_llmAsAJudge_Instruction = cmdletContext.LlmAsAJudge_Instruction;
            }
            if (requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_llmAsAJudge_Instruction != null)
            {
                requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge.Instructions = requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_llmAsAJudge_Instruction;
                requestEvaluatorConfig_evaluatorConfig_LlmAsAJudgeIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.EvaluatorModelConfig requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig = null;
            
             // populate ModelConfig
            var requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfigIsNull = true;
            requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig = new Amazon.BedrockAgentCoreControl.Model.EvaluatorModelConfig();
            Amazon.BedrockAgentCoreControl.Model.BedrockEvaluatorModelConfig requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig = null;
            
             // populate BedrockEvaluatorModelConfig
            var requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfigIsNull = true;
            requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig = new Amazon.BedrockAgentCoreControl.Model.BedrockEvaluatorModelConfig();
            Amazon.Runtime.Documents.Document? requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_bedrockEvaluatorModelConfig_AdditionalModelRequestField = null;
            if (cmdletContext.BedrockEvaluatorModelConfig_AdditionalModelRequestField != null)
            {
                requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_bedrockEvaluatorModelConfig_AdditionalModelRequestField = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.BedrockEvaluatorModelConfig_AdditionalModelRequestField);
            }
            if (requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_bedrockEvaluatorModelConfig_AdditionalModelRequestField != null)
            {
                requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig.AdditionalModelRequestFields = requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_bedrockEvaluatorModelConfig_AdditionalModelRequestField.Value;
                requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfigIsNull = false;
            }
            System.String requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_bedrockEvaluatorModelConfig_ModelId = null;
            if (cmdletContext.BedrockEvaluatorModelConfig_ModelId != null)
            {
                requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_bedrockEvaluatorModelConfig_ModelId = cmdletContext.BedrockEvaluatorModelConfig_ModelId;
            }
            if (requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_bedrockEvaluatorModelConfig_ModelId != null)
            {
                requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig.ModelId = requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_bedrockEvaluatorModelConfig_ModelId;
                requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfigIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.InferenceConfiguration requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_InferenceConfig = null;
            
             // populate InferenceConfig
            var requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_InferenceConfigIsNull = true;
            requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_InferenceConfig = new Amazon.BedrockAgentCoreControl.Model.InferenceConfiguration();
            System.Int32? requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_InferenceConfig_inferenceConfig_MaxToken = null;
            if (cmdletContext.InferenceConfig_MaxToken != null)
            {
                requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_InferenceConfig_inferenceConfig_MaxToken = cmdletContext.InferenceConfig_MaxToken.Value;
            }
            if (requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_InferenceConfig_inferenceConfig_MaxToken != null)
            {
                requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_InferenceConfig.MaxTokens = requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_InferenceConfig_inferenceConfig_MaxToken.Value;
                requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_InferenceConfigIsNull = false;
            }
            List<System.String> requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_InferenceConfig_inferenceConfig_StopSequence = null;
            if (cmdletContext.InferenceConfig_StopSequence != null)
            {
                requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_InferenceConfig_inferenceConfig_StopSequence = cmdletContext.InferenceConfig_StopSequence;
            }
            if (requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_InferenceConfig_inferenceConfig_StopSequence != null)
            {
                requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_InferenceConfig.StopSequences = requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_InferenceConfig_inferenceConfig_StopSequence;
                requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_InferenceConfigIsNull = false;
            }
            System.Single? requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_InferenceConfig_inferenceConfig_Temperature = null;
            if (cmdletContext.InferenceConfig_Temperature != null)
            {
                requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_InferenceConfig_inferenceConfig_Temperature = cmdletContext.InferenceConfig_Temperature.Value;
            }
            if (requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_InferenceConfig_inferenceConfig_Temperature != null)
            {
                requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_InferenceConfig.Temperature = requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_InferenceConfig_inferenceConfig_Temperature.Value;
                requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_InferenceConfigIsNull = false;
            }
            System.Single? requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_InferenceConfig_inferenceConfig_TopP = null;
            if (cmdletContext.InferenceConfig_TopP != null)
            {
                requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_InferenceConfig_inferenceConfig_TopP = cmdletContext.InferenceConfig_TopP.Value;
            }
            if (requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_InferenceConfig_inferenceConfig_TopP != null)
            {
                requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_InferenceConfig.TopP = requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_InferenceConfig_inferenceConfig_TopP.Value;
                requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_InferenceConfigIsNull = false;
            }
             // determine if requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_InferenceConfig should be set to null
            if (requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_InferenceConfigIsNull)
            {
                requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_InferenceConfig = null;
            }
            if (requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_InferenceConfig != null)
            {
                requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig.InferenceConfig = requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig_InferenceConfig;
                requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfigIsNull = false;
            }
             // determine if requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig should be set to null
            if (requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfigIsNull)
            {
                requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig = null;
            }
            if (requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig != null)
            {
                requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig.BedrockEvaluatorModelConfig = requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig_evaluatorConfig_LlmAsAJudge_ModelConfig_BedrockEvaluatorModelConfig;
                requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfigIsNull = false;
            }
             // determine if requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig should be set to null
            if (requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfigIsNull)
            {
                requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig = null;
            }
            if (requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig != null)
            {
                requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge.ModelConfig = requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_ModelConfig;
                requestEvaluatorConfig_evaluatorConfig_LlmAsAJudgeIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.RatingScale requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_RatingScale = null;
            
             // populate RatingScale
            var requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_RatingScaleIsNull = true;
            requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_RatingScale = new Amazon.BedrockAgentCoreControl.Model.RatingScale();
            List<Amazon.BedrockAgentCoreControl.Model.CategoricalScaleDefinition> requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_RatingScale_ratingScale_Categorical = null;
            if (cmdletContext.RatingScale_Categorical != null)
            {
                requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_RatingScale_ratingScale_Categorical = cmdletContext.RatingScale_Categorical;
            }
            if (requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_RatingScale_ratingScale_Categorical != null)
            {
                requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_RatingScale.Categorical = requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_RatingScale_ratingScale_Categorical;
                requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_RatingScaleIsNull = false;
            }
            List<Amazon.BedrockAgentCoreControl.Model.NumericalScaleDefinition> requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_RatingScale_ratingScale_Numerical = null;
            if (cmdletContext.RatingScale_Numerical != null)
            {
                requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_RatingScale_ratingScale_Numerical = cmdletContext.RatingScale_Numerical;
            }
            if (requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_RatingScale_ratingScale_Numerical != null)
            {
                requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_RatingScale.Numerical = requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_RatingScale_ratingScale_Numerical;
                requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_RatingScaleIsNull = false;
            }
             // determine if requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_RatingScale should be set to null
            if (requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_RatingScaleIsNull)
            {
                requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_RatingScale = null;
            }
            if (requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_RatingScale != null)
            {
                requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge.RatingScale = requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge_evaluatorConfig_LlmAsAJudge_RatingScale;
                requestEvaluatorConfig_evaluatorConfig_LlmAsAJudgeIsNull = false;
            }
             // determine if requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge should be set to null
            if (requestEvaluatorConfig_evaluatorConfig_LlmAsAJudgeIsNull)
            {
                requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge = null;
            }
            if (requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge != null)
            {
                request.EvaluatorConfig.LlmAsAJudge = requestEvaluatorConfig_evaluatorConfig_LlmAsAJudge;
                requestEvaluatorConfigIsNull = false;
            }
             // determine if request.EvaluatorConfig should be set to null
            if (requestEvaluatorConfigIsNull)
            {
                request.EvaluatorConfig = null;
            }
            if (cmdletContext.EvaluatorName != null)
            {
                request.EvaluatorName = cmdletContext.EvaluatorName;
            }
            if (cmdletContext.Level != null)
            {
                request.Level = cmdletContext.Level;
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
        
        private Amazon.BedrockAgentCoreControl.Model.CreateEvaluatorResponse CallAWSServiceOperation(IAmazonBedrockAgentCoreControl client, Amazon.BedrockAgentCoreControl.Model.CreateEvaluatorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Core Control Plane Fronting Layer", "CreateEvaluator");
            try
            {
                #if DESKTOP
                return client.CreateEvaluator(request);
                #elif CORECLR
                return client.CreateEvaluatorAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String LlmAsAJudge_Instruction { get; set; }
            public System.Management.Automation.PSObject BedrockEvaluatorModelConfig_AdditionalModelRequestField { get; set; }
            public System.Int32? InferenceConfig_MaxToken { get; set; }
            public List<System.String> InferenceConfig_StopSequence { get; set; }
            public System.Single? InferenceConfig_Temperature { get; set; }
            public System.Single? InferenceConfig_TopP { get; set; }
            public System.String BedrockEvaluatorModelConfig_ModelId { get; set; }
            public List<Amazon.BedrockAgentCoreControl.Model.CategoricalScaleDefinition> RatingScale_Categorical { get; set; }
            public List<Amazon.BedrockAgentCoreControl.Model.NumericalScaleDefinition> RatingScale_Numerical { get; set; }
            public System.String EvaluatorName { get; set; }
            public Amazon.BedrockAgentCoreControl.EvaluatorLevel Level { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.BedrockAgentCoreControl.Model.CreateEvaluatorResponse, NewBACCEvaluatorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
