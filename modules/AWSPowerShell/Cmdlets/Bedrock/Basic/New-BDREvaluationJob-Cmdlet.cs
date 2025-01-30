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
using Amazon.Bedrock;
using Amazon.Bedrock.Model;

namespace Amazon.PowerShell.Cmdlets.BDR
{
    /// <summary>
    /// Creates an evaluation job.
    /// </summary>
    [Cmdlet("New", "BDREvaluationJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Bedrock CreateEvaluationJob API operation.", Operation = new[] {"CreateEvaluationJob"}, SelectReturnType = typeof(Amazon.Bedrock.Model.CreateEvaluationJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.Bedrock.Model.CreateEvaluationJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Bedrock.Model.CreateEvaluationJobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewBDREvaluationJobCmdlet : AmazonBedrockClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationType
        /// <summary>
        /// <para>
        /// <para>Specifies whether the evaluation job is for evaluating a model or evaluating a knowledge
        /// base (retrieval and response generation).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Bedrock.ApplicationType")]
        public Amazon.Bedrock.ApplicationType ApplicationType { get; set; }
        #endregion
        
        #region Parameter EvaluatorModelConfig_BedrockEvaluatorModel
        /// <summary>
        /// <para>
        /// <para>The evaluator model used in knowledge base evaluation job or in model evaluation job
        /// that use a model as judge. This model computes all evaluation related metrics.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EvaluationConfig_Automated_EvaluatorModelConfig_BedrockEvaluatorModels")]
        public Amazon.Bedrock.Model.BedrockEvaluatorModel[] EvaluatorModelConfig_BedrockEvaluatorModel { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure that the API request completes no more
        /// than one time. If this token matches a previous request, Amazon Bedrock ignores the
        /// request, but does not return an error. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter CustomerEncryptionKeyId
        /// <summary>
        /// <para>
        /// <para>Specify your customer managed encryption key Amazon Resource Name (ARN) that will
        /// be used to encrypt your evaluation job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomerEncryptionKeyId { get; set; }
        #endregion
        
        #region Parameter Human_CustomMetric
        /// <summary>
        /// <para>
        /// <para>A <c>HumanEvaluationCustomMetric</c> object. It contains the names the metrics, how
        /// the metrics are to be evaluated, an optional description.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EvaluationConfig_Human_CustomMetrics")]
        public Amazon.Bedrock.Model.HumanEvaluationCustomMetric[] Human_CustomMetric { get; set; }
        #endregion
        
        #region Parameter Automated_DatasetMetricConfig
        /// <summary>
        /// <para>
        /// <para>Configuration details of the prompt datasets and metrics you want to use for your
        /// evaluation job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EvaluationConfig_Automated_DatasetMetricConfigs")]
        public Amazon.Bedrock.Model.EvaluationDatasetMetricConfig[] Automated_DatasetMetricConfig { get; set; }
        #endregion
        
        #region Parameter Human_DatasetMetricConfig
        /// <summary>
        /// <para>
        /// <para>Use to specify the metrics, task, and prompt dataset to be used in your model evaluation
        /// job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EvaluationConfig_Human_DatasetMetricConfigs")]
        public Amazon.Bedrock.Model.EvaluationDatasetMetricConfig[] Human_DatasetMetricConfig { get; set; }
        #endregion
        
        #region Parameter HumanWorkflowConfig_FlowDefinitionArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Number (ARN) for the flow definition</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EvaluationConfig_Human_HumanWorkflowConfig_FlowDefinitionArn")]
        public System.String HumanWorkflowConfig_FlowDefinitionArn { get; set; }
        #endregion
        
        #region Parameter HumanWorkflowConfig_Instruction
        /// <summary>
        /// <para>
        /// <para>Instructions for the flow definition</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EvaluationConfig_Human_HumanWorkflowConfig_Instructions")]
        public System.String HumanWorkflowConfig_Instruction { get; set; }
        #endregion
        
        #region Parameter JobDescription
        /// <summary>
        /// <para>
        /// <para>A description of the evaluation job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String JobDescription { get; set; }
        #endregion
        
        #region Parameter JobName
        /// <summary>
        /// <para>
        /// <para>A name for the evaluation job. Names must unique with your Amazon Web Services account,
        /// and your account's Amazon Web Services region.</para>
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
        public System.String JobName { get; set; }
        #endregion
        
        #region Parameter JobTag
        /// <summary>
        /// <para>
        /// <para>Tags to attach to the model evaluation job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobTags")]
        public Amazon.Bedrock.Model.Tag[] JobTag { get; set; }
        #endregion
        
        #region Parameter InferenceConfig_Model
        /// <summary>
        /// <para>
        /// <para>Specifies the inference models.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InferenceConfig_Models")]
        public Amazon.Bedrock.Model.EvaluationModelConfig[] InferenceConfig_Model { get; set; }
        #endregion
        
        #region Parameter InferenceConfig_RagConfig
        /// <summary>
        /// <para>
        /// <para>Contains the configuration details of the inference for a knowledge base evaluation
        /// job, including either the retrieval only configuration or the retrieval with response
        /// generation configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InferenceConfig_RagConfigs")]
        public Amazon.Bedrock.Model.RAGConfig[] InferenceConfig_RagConfig { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an IAM service role that Amazon Bedrock can assume
        /// to perform tasks on your behalf. To learn more about the required permissions, see
        /// <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/model-evaluation-security.html">Required
        /// permissions for model evaluations</a>.</para>
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter OutputDataConfig_S3Uri
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 URI where the results of the evaluation job are saved.</para>
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
        public System.String OutputDataConfig_S3Uri { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'JobArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Bedrock.Model.CreateEvaluationJobResponse).
        /// Specifying the name of a property of type Amazon.Bedrock.Model.CreateEvaluationJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "JobArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.JobName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BDREvaluationJob (CreateEvaluationJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Bedrock.Model.CreateEvaluationJobResponse, NewBDREvaluationJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationType = this.ApplicationType;
            context.ClientRequestToken = this.ClientRequestToken;
            context.CustomerEncryptionKeyId = this.CustomerEncryptionKeyId;
            if (this.Automated_DatasetMetricConfig != null)
            {
                context.Automated_DatasetMetricConfig = new List<Amazon.Bedrock.Model.EvaluationDatasetMetricConfig>(this.Automated_DatasetMetricConfig);
            }
            if (this.EvaluatorModelConfig_BedrockEvaluatorModel != null)
            {
                context.EvaluatorModelConfig_BedrockEvaluatorModel = new List<Amazon.Bedrock.Model.BedrockEvaluatorModel>(this.EvaluatorModelConfig_BedrockEvaluatorModel);
            }
            if (this.Human_CustomMetric != null)
            {
                context.Human_CustomMetric = new List<Amazon.Bedrock.Model.HumanEvaluationCustomMetric>(this.Human_CustomMetric);
            }
            if (this.Human_DatasetMetricConfig != null)
            {
                context.Human_DatasetMetricConfig = new List<Amazon.Bedrock.Model.EvaluationDatasetMetricConfig>(this.Human_DatasetMetricConfig);
            }
            context.HumanWorkflowConfig_FlowDefinitionArn = this.HumanWorkflowConfig_FlowDefinitionArn;
            context.HumanWorkflowConfig_Instruction = this.HumanWorkflowConfig_Instruction;
            if (this.InferenceConfig_Model != null)
            {
                context.InferenceConfig_Model = new List<Amazon.Bedrock.Model.EvaluationModelConfig>(this.InferenceConfig_Model);
            }
            if (this.InferenceConfig_RagConfig != null)
            {
                context.InferenceConfig_RagConfig = new List<Amazon.Bedrock.Model.RAGConfig>(this.InferenceConfig_RagConfig);
            }
            context.JobDescription = this.JobDescription;
            context.JobName = this.JobName;
            #if MODULAR
            if (this.JobName == null && ParameterWasBound(nameof(this.JobName)))
            {
                WriteWarning("You are passing $null as a value for parameter JobName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.JobTag != null)
            {
                context.JobTag = new List<Amazon.Bedrock.Model.Tag>(this.JobTag);
            }
            context.OutputDataConfig_S3Uri = this.OutputDataConfig_S3Uri;
            #if MODULAR
            if (this.OutputDataConfig_S3Uri == null && ParameterWasBound(nameof(this.OutputDataConfig_S3Uri)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputDataConfig_S3Uri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Bedrock.Model.CreateEvaluationJobRequest();
            
            if (cmdletContext.ApplicationType != null)
            {
                request.ApplicationType = cmdletContext.ApplicationType;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.CustomerEncryptionKeyId != null)
            {
                request.CustomerEncryptionKeyId = cmdletContext.CustomerEncryptionKeyId;
            }
            
             // populate EvaluationConfig
            var requestEvaluationConfigIsNull = true;
            request.EvaluationConfig = new Amazon.Bedrock.Model.EvaluationConfig();
            Amazon.Bedrock.Model.AutomatedEvaluationConfig requestEvaluationConfig_evaluationConfig_Automated = null;
            
             // populate Automated
            var requestEvaluationConfig_evaluationConfig_AutomatedIsNull = true;
            requestEvaluationConfig_evaluationConfig_Automated = new Amazon.Bedrock.Model.AutomatedEvaluationConfig();
            List<Amazon.Bedrock.Model.EvaluationDatasetMetricConfig> requestEvaluationConfig_evaluationConfig_Automated_automated_DatasetMetricConfig = null;
            if (cmdletContext.Automated_DatasetMetricConfig != null)
            {
                requestEvaluationConfig_evaluationConfig_Automated_automated_DatasetMetricConfig = cmdletContext.Automated_DatasetMetricConfig;
            }
            if (requestEvaluationConfig_evaluationConfig_Automated_automated_DatasetMetricConfig != null)
            {
                requestEvaluationConfig_evaluationConfig_Automated.DatasetMetricConfigs = requestEvaluationConfig_evaluationConfig_Automated_automated_DatasetMetricConfig;
                requestEvaluationConfig_evaluationConfig_AutomatedIsNull = false;
            }
            Amazon.Bedrock.Model.EvaluatorModelConfig requestEvaluationConfig_evaluationConfig_Automated_evaluationConfig_Automated_EvaluatorModelConfig = null;
            
             // populate EvaluatorModelConfig
            var requestEvaluationConfig_evaluationConfig_Automated_evaluationConfig_Automated_EvaluatorModelConfigIsNull = true;
            requestEvaluationConfig_evaluationConfig_Automated_evaluationConfig_Automated_EvaluatorModelConfig = new Amazon.Bedrock.Model.EvaluatorModelConfig();
            List<Amazon.Bedrock.Model.BedrockEvaluatorModel> requestEvaluationConfig_evaluationConfig_Automated_evaluationConfig_Automated_EvaluatorModelConfig_evaluatorModelConfig_BedrockEvaluatorModel = null;
            if (cmdletContext.EvaluatorModelConfig_BedrockEvaluatorModel != null)
            {
                requestEvaluationConfig_evaluationConfig_Automated_evaluationConfig_Automated_EvaluatorModelConfig_evaluatorModelConfig_BedrockEvaluatorModel = cmdletContext.EvaluatorModelConfig_BedrockEvaluatorModel;
            }
            if (requestEvaluationConfig_evaluationConfig_Automated_evaluationConfig_Automated_EvaluatorModelConfig_evaluatorModelConfig_BedrockEvaluatorModel != null)
            {
                requestEvaluationConfig_evaluationConfig_Automated_evaluationConfig_Automated_EvaluatorModelConfig.BedrockEvaluatorModels = requestEvaluationConfig_evaluationConfig_Automated_evaluationConfig_Automated_EvaluatorModelConfig_evaluatorModelConfig_BedrockEvaluatorModel;
                requestEvaluationConfig_evaluationConfig_Automated_evaluationConfig_Automated_EvaluatorModelConfigIsNull = false;
            }
             // determine if requestEvaluationConfig_evaluationConfig_Automated_evaluationConfig_Automated_EvaluatorModelConfig should be set to null
            if (requestEvaluationConfig_evaluationConfig_Automated_evaluationConfig_Automated_EvaluatorModelConfigIsNull)
            {
                requestEvaluationConfig_evaluationConfig_Automated_evaluationConfig_Automated_EvaluatorModelConfig = null;
            }
            if (requestEvaluationConfig_evaluationConfig_Automated_evaluationConfig_Automated_EvaluatorModelConfig != null)
            {
                requestEvaluationConfig_evaluationConfig_Automated.EvaluatorModelConfig = requestEvaluationConfig_evaluationConfig_Automated_evaluationConfig_Automated_EvaluatorModelConfig;
                requestEvaluationConfig_evaluationConfig_AutomatedIsNull = false;
            }
             // determine if requestEvaluationConfig_evaluationConfig_Automated should be set to null
            if (requestEvaluationConfig_evaluationConfig_AutomatedIsNull)
            {
                requestEvaluationConfig_evaluationConfig_Automated = null;
            }
            if (requestEvaluationConfig_evaluationConfig_Automated != null)
            {
                request.EvaluationConfig.Automated = requestEvaluationConfig_evaluationConfig_Automated;
                requestEvaluationConfigIsNull = false;
            }
            Amazon.Bedrock.Model.HumanEvaluationConfig requestEvaluationConfig_evaluationConfig_Human = null;
            
             // populate Human
            var requestEvaluationConfig_evaluationConfig_HumanIsNull = true;
            requestEvaluationConfig_evaluationConfig_Human = new Amazon.Bedrock.Model.HumanEvaluationConfig();
            List<Amazon.Bedrock.Model.HumanEvaluationCustomMetric> requestEvaluationConfig_evaluationConfig_Human_human_CustomMetric = null;
            if (cmdletContext.Human_CustomMetric != null)
            {
                requestEvaluationConfig_evaluationConfig_Human_human_CustomMetric = cmdletContext.Human_CustomMetric;
            }
            if (requestEvaluationConfig_evaluationConfig_Human_human_CustomMetric != null)
            {
                requestEvaluationConfig_evaluationConfig_Human.CustomMetrics = requestEvaluationConfig_evaluationConfig_Human_human_CustomMetric;
                requestEvaluationConfig_evaluationConfig_HumanIsNull = false;
            }
            List<Amazon.Bedrock.Model.EvaluationDatasetMetricConfig> requestEvaluationConfig_evaluationConfig_Human_human_DatasetMetricConfig = null;
            if (cmdletContext.Human_DatasetMetricConfig != null)
            {
                requestEvaluationConfig_evaluationConfig_Human_human_DatasetMetricConfig = cmdletContext.Human_DatasetMetricConfig;
            }
            if (requestEvaluationConfig_evaluationConfig_Human_human_DatasetMetricConfig != null)
            {
                requestEvaluationConfig_evaluationConfig_Human.DatasetMetricConfigs = requestEvaluationConfig_evaluationConfig_Human_human_DatasetMetricConfig;
                requestEvaluationConfig_evaluationConfig_HumanIsNull = false;
            }
            Amazon.Bedrock.Model.HumanWorkflowConfig requestEvaluationConfig_evaluationConfig_Human_evaluationConfig_Human_HumanWorkflowConfig = null;
            
             // populate HumanWorkflowConfig
            var requestEvaluationConfig_evaluationConfig_Human_evaluationConfig_Human_HumanWorkflowConfigIsNull = true;
            requestEvaluationConfig_evaluationConfig_Human_evaluationConfig_Human_HumanWorkflowConfig = new Amazon.Bedrock.Model.HumanWorkflowConfig();
            System.String requestEvaluationConfig_evaluationConfig_Human_evaluationConfig_Human_HumanWorkflowConfig_humanWorkflowConfig_FlowDefinitionArn = null;
            if (cmdletContext.HumanWorkflowConfig_FlowDefinitionArn != null)
            {
                requestEvaluationConfig_evaluationConfig_Human_evaluationConfig_Human_HumanWorkflowConfig_humanWorkflowConfig_FlowDefinitionArn = cmdletContext.HumanWorkflowConfig_FlowDefinitionArn;
            }
            if (requestEvaluationConfig_evaluationConfig_Human_evaluationConfig_Human_HumanWorkflowConfig_humanWorkflowConfig_FlowDefinitionArn != null)
            {
                requestEvaluationConfig_evaluationConfig_Human_evaluationConfig_Human_HumanWorkflowConfig.FlowDefinitionArn = requestEvaluationConfig_evaluationConfig_Human_evaluationConfig_Human_HumanWorkflowConfig_humanWorkflowConfig_FlowDefinitionArn;
                requestEvaluationConfig_evaluationConfig_Human_evaluationConfig_Human_HumanWorkflowConfigIsNull = false;
            }
            System.String requestEvaluationConfig_evaluationConfig_Human_evaluationConfig_Human_HumanWorkflowConfig_humanWorkflowConfig_Instruction = null;
            if (cmdletContext.HumanWorkflowConfig_Instruction != null)
            {
                requestEvaluationConfig_evaluationConfig_Human_evaluationConfig_Human_HumanWorkflowConfig_humanWorkflowConfig_Instruction = cmdletContext.HumanWorkflowConfig_Instruction;
            }
            if (requestEvaluationConfig_evaluationConfig_Human_evaluationConfig_Human_HumanWorkflowConfig_humanWorkflowConfig_Instruction != null)
            {
                requestEvaluationConfig_evaluationConfig_Human_evaluationConfig_Human_HumanWorkflowConfig.Instructions = requestEvaluationConfig_evaluationConfig_Human_evaluationConfig_Human_HumanWorkflowConfig_humanWorkflowConfig_Instruction;
                requestEvaluationConfig_evaluationConfig_Human_evaluationConfig_Human_HumanWorkflowConfigIsNull = false;
            }
             // determine if requestEvaluationConfig_evaluationConfig_Human_evaluationConfig_Human_HumanWorkflowConfig should be set to null
            if (requestEvaluationConfig_evaluationConfig_Human_evaluationConfig_Human_HumanWorkflowConfigIsNull)
            {
                requestEvaluationConfig_evaluationConfig_Human_evaluationConfig_Human_HumanWorkflowConfig = null;
            }
            if (requestEvaluationConfig_evaluationConfig_Human_evaluationConfig_Human_HumanWorkflowConfig != null)
            {
                requestEvaluationConfig_evaluationConfig_Human.HumanWorkflowConfig = requestEvaluationConfig_evaluationConfig_Human_evaluationConfig_Human_HumanWorkflowConfig;
                requestEvaluationConfig_evaluationConfig_HumanIsNull = false;
            }
             // determine if requestEvaluationConfig_evaluationConfig_Human should be set to null
            if (requestEvaluationConfig_evaluationConfig_HumanIsNull)
            {
                requestEvaluationConfig_evaluationConfig_Human = null;
            }
            if (requestEvaluationConfig_evaluationConfig_Human != null)
            {
                request.EvaluationConfig.Human = requestEvaluationConfig_evaluationConfig_Human;
                requestEvaluationConfigIsNull = false;
            }
             // determine if request.EvaluationConfig should be set to null
            if (requestEvaluationConfigIsNull)
            {
                request.EvaluationConfig = null;
            }
            
             // populate InferenceConfig
            var requestInferenceConfigIsNull = true;
            request.InferenceConfig = new Amazon.Bedrock.Model.EvaluationInferenceConfig();
            List<Amazon.Bedrock.Model.EvaluationModelConfig> requestInferenceConfig_inferenceConfig_Model = null;
            if (cmdletContext.InferenceConfig_Model != null)
            {
                requestInferenceConfig_inferenceConfig_Model = cmdletContext.InferenceConfig_Model;
            }
            if (requestInferenceConfig_inferenceConfig_Model != null)
            {
                request.InferenceConfig.Models = requestInferenceConfig_inferenceConfig_Model;
                requestInferenceConfigIsNull = false;
            }
            List<Amazon.Bedrock.Model.RAGConfig> requestInferenceConfig_inferenceConfig_RagConfig = null;
            if (cmdletContext.InferenceConfig_RagConfig != null)
            {
                requestInferenceConfig_inferenceConfig_RagConfig = cmdletContext.InferenceConfig_RagConfig;
            }
            if (requestInferenceConfig_inferenceConfig_RagConfig != null)
            {
                request.InferenceConfig.RagConfigs = requestInferenceConfig_inferenceConfig_RagConfig;
                requestInferenceConfigIsNull = false;
            }
             // determine if request.InferenceConfig should be set to null
            if (requestInferenceConfigIsNull)
            {
                request.InferenceConfig = null;
            }
            if (cmdletContext.JobDescription != null)
            {
                request.JobDescription = cmdletContext.JobDescription;
            }
            if (cmdletContext.JobName != null)
            {
                request.JobName = cmdletContext.JobName;
            }
            if (cmdletContext.JobTag != null)
            {
                request.JobTags = cmdletContext.JobTag;
            }
            
             // populate OutputDataConfig
            var requestOutputDataConfigIsNull = true;
            request.OutputDataConfig = new Amazon.Bedrock.Model.EvaluationOutputDataConfig();
            System.String requestOutputDataConfig_outputDataConfig_S3Uri = null;
            if (cmdletContext.OutputDataConfig_S3Uri != null)
            {
                requestOutputDataConfig_outputDataConfig_S3Uri = cmdletContext.OutputDataConfig_S3Uri;
            }
            if (requestOutputDataConfig_outputDataConfig_S3Uri != null)
            {
                request.OutputDataConfig.S3Uri = requestOutputDataConfig_outputDataConfig_S3Uri;
                requestOutputDataConfigIsNull = false;
            }
             // determine if request.OutputDataConfig should be set to null
            if (requestOutputDataConfigIsNull)
            {
                request.OutputDataConfig = null;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
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
        
        private Amazon.Bedrock.Model.CreateEvaluationJobResponse CallAWSServiceOperation(IAmazonBedrock client, Amazon.Bedrock.Model.CreateEvaluationJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock", "CreateEvaluationJob");
            try
            {
                #if DESKTOP
                return client.CreateEvaluationJob(request);
                #elif CORECLR
                return client.CreateEvaluationJobAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Bedrock.ApplicationType ApplicationType { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.String CustomerEncryptionKeyId { get; set; }
            public List<Amazon.Bedrock.Model.EvaluationDatasetMetricConfig> Automated_DatasetMetricConfig { get; set; }
            public List<Amazon.Bedrock.Model.BedrockEvaluatorModel> EvaluatorModelConfig_BedrockEvaluatorModel { get; set; }
            public List<Amazon.Bedrock.Model.HumanEvaluationCustomMetric> Human_CustomMetric { get; set; }
            public List<Amazon.Bedrock.Model.EvaluationDatasetMetricConfig> Human_DatasetMetricConfig { get; set; }
            public System.String HumanWorkflowConfig_FlowDefinitionArn { get; set; }
            public System.String HumanWorkflowConfig_Instruction { get; set; }
            public List<Amazon.Bedrock.Model.EvaluationModelConfig> InferenceConfig_Model { get; set; }
            public List<Amazon.Bedrock.Model.RAGConfig> InferenceConfig_RagConfig { get; set; }
            public System.String JobDescription { get; set; }
            public System.String JobName { get; set; }
            public List<Amazon.Bedrock.Model.Tag> JobTag { get; set; }
            public System.String OutputDataConfig_S3Uri { get; set; }
            public System.String RoleArn { get; set; }
            public System.Func<Amazon.Bedrock.Model.CreateEvaluationJobResponse, NewBDREvaluationJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobArn;
        }
        
    }
}
