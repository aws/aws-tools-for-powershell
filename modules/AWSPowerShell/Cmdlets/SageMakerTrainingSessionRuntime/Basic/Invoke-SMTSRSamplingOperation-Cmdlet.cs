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
using Amazon.SageMakerTrainingSessionRuntime;
using Amazon.SageMakerTrainingSessionRuntime.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SMTSR
{
    /// <summary>
    /// Submits an asynchronous sampling operation to generate text or compute log-probabilities
    /// from the model associated with the specified training session. The session must be
    /// in <c>Running</c> or <c>Blocked</c> state. Use <c>GetSamplingOperationResult</c> to
    /// poll for the result.
    /// </summary>
    [Cmdlet("Invoke", "SMTSRSamplingOperation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the SageMaker Training Session Runtime ExecuteSamplingOperation API operation.", Operation = new[] {"ExecuteSamplingOperation"}, SelectReturnType = typeof(Amazon.SageMakerTrainingSessionRuntime.Model.ExecuteSamplingOperationResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMakerTrainingSessionRuntime.Model.ExecuteSamplingOperationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMakerTrainingSessionRuntime.Model.ExecuteSamplingOperationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class InvokeSMTSRSamplingOperationCmdlet : AmazonSageMakerTrainingSessionRuntimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter OperationConfig_ComputeLogprobs_Prompt_Chunk
        /// <summary>
        /// <para>
        /// <para>The ordered list of encoded text chunks forming the input sequence.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OperationConfig_ComputeLogprobs_Prompt_Chunks")]
        public Amazon.SageMakerTrainingSessionRuntime.Model.EncodedTextChunk[] OperationConfig_ComputeLogprobs_Prompt_Chunk { get; set; }
        #endregion
        
        #region Parameter OperationConfig_Sample_Prompt_Chunk
        /// <summary>
        /// <para>
        /// <para>The ordered list of encoded text chunks forming the input sequence.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OperationConfig_Sample_Prompt_Chunks")]
        public Amazon.SageMakerTrainingSessionRuntime.Model.EncodedTextChunk[] OperationConfig_Sample_Prompt_Chunk { get; set; }
        #endregion
        
        #region Parameter OperationConfig_Sample_IncludePromptLogprob
        /// <summary>
        /// <para>
        /// <para>Specifies whether to include per-token log-probabilities for the input prompt in the
        /// response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OperationConfig_Sample_IncludePromptLogprobs")]
        public System.Boolean? OperationConfig_Sample_IncludePromptLogprob { get; set; }
        #endregion
        
        #region Parameter OperationConfig_Sample_SamplingParams_MaxToken
        /// <summary>
        /// <para>
        /// <para>The maximum number of tokens to generate per sample.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OperationConfig_Sample_SamplingParams_MaxTokens")]
        public System.Int32? OperationConfig_Sample_SamplingParams_MaxToken { get; set; }
        #endregion
        
        #region Parameter OperationConfig_ComputeLogprobs_ModelPackageArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the model package whose checkpoint this operation should run against. Must
        /// be a valid SageMaker model package ARN in the format <c>arn:aws:sagemaker:REGION:ACCOUNT:model-package/PACKAGE_NAME/VERSION</c>.
        /// When absent, the operation runs against the session's latest checkpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OperationConfig_ComputeLogprobs_ModelPackageArn { get; set; }
        #endregion
        
        #region Parameter OperationConfig_LoadWeightsForSampling_ModelPackageArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the model package containing the weights to load for sampling. Must be
        /// a valid SageMaker model package ARN in the format <c>arn:aws:sagemaker:REGION:ACCOUNT:model-package/PACKAGE_NAME/VERSION</c>.
        /// The model package must belong to the same AWS account as the training session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OperationConfig_LoadWeightsForSampling_ModelPackageArn { get; set; }
        #endregion
        
        #region Parameter OperationConfig_Sample_ModelPackageArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the model package whose checkpoint this sample should run against. Must
        /// be a valid SageMaker model package ARN in the format <c>arn:aws:sagemaker:REGION:ACCOUNT:model-package/PACKAGE_NAME/VERSION</c>.
        /// When absent, the sample runs against the session's latest checkpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OperationConfig_Sample_ModelPackageArn { get; set; }
        #endregion
        
        #region Parameter OperationConfig_Sample_NumSample
        /// <summary>
        /// <para>
        /// <para>The number of independent samples to generate for the prompt.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OperationConfig_Sample_NumSamples")]
        public System.Int32? OperationConfig_Sample_NumSample { get; set; }
        #endregion
        
        #region Parameter OperationConfig_Sample_SamplingParams_Seed
        /// <summary>
        /// <para>
        /// <para>The random seed for reproducible sampling. When set, the same seed with the same input
        /// produces deterministic outputs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? OperationConfig_Sample_SamplingParams_Seed { get; set; }
        #endregion
        
        #region Parameter OperationConfig_Sample_SamplingParams_Stop
        /// <summary>
        /// <para>
        /// <para>The list of stop sequences that terminate generation when encountered in the output.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] OperationConfig_Sample_SamplingParams_Stop { get; set; }
        #endregion
        
        #region Parameter OperationConfig_Sample_SamplingParams_Temperature
        /// <summary>
        /// <para>
        /// <para>The sampling temperature controlling randomness. Higher values produce more diverse
        /// outputs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? OperationConfig_Sample_SamplingParams_Temperature { get; set; }
        #endregion
        
        #region Parameter OperationConfig_Sample_SamplingParams_TopK
        /// <summary>
        /// <para>
        /// <para>The number of highest-probability vocabulary tokens to keep for top-k filtering. Set
        /// to -1 to disable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? OperationConfig_Sample_SamplingParams_TopK { get; set; }
        #endregion
        
        #region Parameter OperationConfig_Sample_TopkPromptLogprob
        /// <summary>
        /// <para>
        /// <para>The number of top-k log-probabilities to return per prompt token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OperationConfig_Sample_TopkPromptLogprobs")]
        public System.Int32? OperationConfig_Sample_TopkPromptLogprob { get; set; }
        #endregion
        
        #region Parameter OperationConfig_Sample_SamplingParams_TopP
        /// <summary>
        /// <para>
        /// <para>The cumulative probability threshold for nucleus (top-p) sampling. Only tokens with
        /// cumulative probability below this threshold are considered.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? OperationConfig_Sample_SamplingParams_TopP { get; set; }
        #endregion
        
        #region Parameter TrainingSessionName
        /// <summary>
        /// <para>
        /// <para>The name of the training session to sample from.</para>
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
        public System.String TrainingSessionName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'OperationId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMakerTrainingSessionRuntime.Model.ExecuteSamplingOperationResponse).
        /// Specifying the name of a property of type Amazon.SageMakerTrainingSessionRuntime.Model.ExecuteSamplingOperationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "OperationId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TrainingSessionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-SMTSRSamplingOperation (ExecuteSamplingOperation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMakerTrainingSessionRuntime.Model.ExecuteSamplingOperationResponse, InvokeSMTSRSamplingOperationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.OperationConfig_ComputeLogprobs_ModelPackageArn = this.OperationConfig_ComputeLogprobs_ModelPackageArn;
            if (this.OperationConfig_ComputeLogprobs_Prompt_Chunk != null)
            {
                context.OperationConfig_ComputeLogprobs_Prompt_Chunk = new List<Amazon.SageMakerTrainingSessionRuntime.Model.EncodedTextChunk>(this.OperationConfig_ComputeLogprobs_Prompt_Chunk);
            }
            context.OperationConfig_LoadWeightsForSampling_ModelPackageArn = this.OperationConfig_LoadWeightsForSampling_ModelPackageArn;
            context.OperationConfig_Sample_IncludePromptLogprob = this.OperationConfig_Sample_IncludePromptLogprob;
            context.OperationConfig_Sample_ModelPackageArn = this.OperationConfig_Sample_ModelPackageArn;
            context.OperationConfig_Sample_NumSample = this.OperationConfig_Sample_NumSample;
            if (this.OperationConfig_Sample_Prompt_Chunk != null)
            {
                context.OperationConfig_Sample_Prompt_Chunk = new List<Amazon.SageMakerTrainingSessionRuntime.Model.EncodedTextChunk>(this.OperationConfig_Sample_Prompt_Chunk);
            }
            context.OperationConfig_Sample_SamplingParams_MaxToken = this.OperationConfig_Sample_SamplingParams_MaxToken;
            context.OperationConfig_Sample_SamplingParams_Seed = this.OperationConfig_Sample_SamplingParams_Seed;
            if (this.OperationConfig_Sample_SamplingParams_Stop != null)
            {
                context.OperationConfig_Sample_SamplingParams_Stop = new List<System.String>(this.OperationConfig_Sample_SamplingParams_Stop);
            }
            context.OperationConfig_Sample_SamplingParams_Temperature = this.OperationConfig_Sample_SamplingParams_Temperature;
            context.OperationConfig_Sample_SamplingParams_TopK = this.OperationConfig_Sample_SamplingParams_TopK;
            context.OperationConfig_Sample_SamplingParams_TopP = this.OperationConfig_Sample_SamplingParams_TopP;
            context.OperationConfig_Sample_TopkPromptLogprob = this.OperationConfig_Sample_TopkPromptLogprob;
            context.TrainingSessionName = this.TrainingSessionName;
            #if MODULAR
            if (this.TrainingSessionName == null && ParameterWasBound(nameof(this.TrainingSessionName)))
            {
                WriteWarning("You are passing $null as a value for parameter TrainingSessionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SageMakerTrainingSessionRuntime.Model.ExecuteSamplingOperationRequest();
            
            
             // populate OperationConfig
            var requestOperationConfigIsNull = true;
            request.OperationConfig = new Amazon.SageMakerTrainingSessionRuntime.Model.SampleOperationConfig();
            Amazon.SageMakerTrainingSessionRuntime.Model.LoadWeightsForSamplingConfig requestOperationConfig_operationConfig_LoadWeightsForSampling = null;
            
             // populate LoadWeightsForSampling
            var requestOperationConfig_operationConfig_LoadWeightsForSamplingIsNull = true;
            requestOperationConfig_operationConfig_LoadWeightsForSampling = new Amazon.SageMakerTrainingSessionRuntime.Model.LoadWeightsForSamplingConfig();
            System.String requestOperationConfig_operationConfig_LoadWeightsForSampling_operationConfig_LoadWeightsForSampling_ModelPackageArn = null;
            if (cmdletContext.OperationConfig_LoadWeightsForSampling_ModelPackageArn != null)
            {
                requestOperationConfig_operationConfig_LoadWeightsForSampling_operationConfig_LoadWeightsForSampling_ModelPackageArn = cmdletContext.OperationConfig_LoadWeightsForSampling_ModelPackageArn;
            }
            if (requestOperationConfig_operationConfig_LoadWeightsForSampling_operationConfig_LoadWeightsForSampling_ModelPackageArn != null)
            {
                requestOperationConfig_operationConfig_LoadWeightsForSampling.ModelPackageArn = requestOperationConfig_operationConfig_LoadWeightsForSampling_operationConfig_LoadWeightsForSampling_ModelPackageArn;
                requestOperationConfig_operationConfig_LoadWeightsForSamplingIsNull = false;
            }
             // determine if requestOperationConfig_operationConfig_LoadWeightsForSampling should be set to null
            if (requestOperationConfig_operationConfig_LoadWeightsForSamplingIsNull)
            {
                requestOperationConfig_operationConfig_LoadWeightsForSampling = null;
            }
            if (requestOperationConfig_operationConfig_LoadWeightsForSampling != null)
            {
                request.OperationConfig.LoadWeightsForSampling = requestOperationConfig_operationConfig_LoadWeightsForSampling;
                requestOperationConfigIsNull = false;
            }
            Amazon.SageMakerTrainingSessionRuntime.Model.ComputeLogprobsConfig requestOperationConfig_operationConfig_ComputeLogprobs = null;
            
             // populate ComputeLogprobs
            var requestOperationConfig_operationConfig_ComputeLogprobsIsNull = true;
            requestOperationConfig_operationConfig_ComputeLogprobs = new Amazon.SageMakerTrainingSessionRuntime.Model.ComputeLogprobsConfig();
            System.String requestOperationConfig_operationConfig_ComputeLogprobs_operationConfig_ComputeLogprobs_ModelPackageArn = null;
            if (cmdletContext.OperationConfig_ComputeLogprobs_ModelPackageArn != null)
            {
                requestOperationConfig_operationConfig_ComputeLogprobs_operationConfig_ComputeLogprobs_ModelPackageArn = cmdletContext.OperationConfig_ComputeLogprobs_ModelPackageArn;
            }
            if (requestOperationConfig_operationConfig_ComputeLogprobs_operationConfig_ComputeLogprobs_ModelPackageArn != null)
            {
                requestOperationConfig_operationConfig_ComputeLogprobs.ModelPackageArn = requestOperationConfig_operationConfig_ComputeLogprobs_operationConfig_ComputeLogprobs_ModelPackageArn;
                requestOperationConfig_operationConfig_ComputeLogprobsIsNull = false;
            }
            Amazon.SageMakerTrainingSessionRuntime.Model.ModelInput requestOperationConfig_operationConfig_ComputeLogprobs_operationConfig_ComputeLogprobs_Prompt = null;
            
             // populate Prompt
            var requestOperationConfig_operationConfig_ComputeLogprobs_operationConfig_ComputeLogprobs_PromptIsNull = true;
            requestOperationConfig_operationConfig_ComputeLogprobs_operationConfig_ComputeLogprobs_Prompt = new Amazon.SageMakerTrainingSessionRuntime.Model.ModelInput();
            List<Amazon.SageMakerTrainingSessionRuntime.Model.EncodedTextChunk> requestOperationConfig_operationConfig_ComputeLogprobs_operationConfig_ComputeLogprobs_Prompt_operationConfig_ComputeLogprobs_Prompt_Chunk = null;
            if (cmdletContext.OperationConfig_ComputeLogprobs_Prompt_Chunk != null)
            {
                requestOperationConfig_operationConfig_ComputeLogprobs_operationConfig_ComputeLogprobs_Prompt_operationConfig_ComputeLogprobs_Prompt_Chunk = cmdletContext.OperationConfig_ComputeLogprobs_Prompt_Chunk;
            }
            if (requestOperationConfig_operationConfig_ComputeLogprobs_operationConfig_ComputeLogprobs_Prompt_operationConfig_ComputeLogprobs_Prompt_Chunk != null)
            {
                requestOperationConfig_operationConfig_ComputeLogprobs_operationConfig_ComputeLogprobs_Prompt.Chunks = requestOperationConfig_operationConfig_ComputeLogprobs_operationConfig_ComputeLogprobs_Prompt_operationConfig_ComputeLogprobs_Prompt_Chunk;
                requestOperationConfig_operationConfig_ComputeLogprobs_operationConfig_ComputeLogprobs_PromptIsNull = false;
            }
             // determine if requestOperationConfig_operationConfig_ComputeLogprobs_operationConfig_ComputeLogprobs_Prompt should be set to null
            if (requestOperationConfig_operationConfig_ComputeLogprobs_operationConfig_ComputeLogprobs_PromptIsNull)
            {
                requestOperationConfig_operationConfig_ComputeLogprobs_operationConfig_ComputeLogprobs_Prompt = null;
            }
            if (requestOperationConfig_operationConfig_ComputeLogprobs_operationConfig_ComputeLogprobs_Prompt != null)
            {
                requestOperationConfig_operationConfig_ComputeLogprobs.Prompt = requestOperationConfig_operationConfig_ComputeLogprobs_operationConfig_ComputeLogprobs_Prompt;
                requestOperationConfig_operationConfig_ComputeLogprobsIsNull = false;
            }
             // determine if requestOperationConfig_operationConfig_ComputeLogprobs should be set to null
            if (requestOperationConfig_operationConfig_ComputeLogprobsIsNull)
            {
                requestOperationConfig_operationConfig_ComputeLogprobs = null;
            }
            if (requestOperationConfig_operationConfig_ComputeLogprobs != null)
            {
                request.OperationConfig.ComputeLogprobs = requestOperationConfig_operationConfig_ComputeLogprobs;
                requestOperationConfigIsNull = false;
            }
            Amazon.SageMakerTrainingSessionRuntime.Model.SampleConfig requestOperationConfig_operationConfig_Sample = null;
            
             // populate Sample
            var requestOperationConfig_operationConfig_SampleIsNull = true;
            requestOperationConfig_operationConfig_Sample = new Amazon.SageMakerTrainingSessionRuntime.Model.SampleConfig();
            System.Boolean? requestOperationConfig_operationConfig_Sample_operationConfig_Sample_IncludePromptLogprob = null;
            if (cmdletContext.OperationConfig_Sample_IncludePromptLogprob != null)
            {
                requestOperationConfig_operationConfig_Sample_operationConfig_Sample_IncludePromptLogprob = cmdletContext.OperationConfig_Sample_IncludePromptLogprob.Value;
            }
            if (requestOperationConfig_operationConfig_Sample_operationConfig_Sample_IncludePromptLogprob != null)
            {
                requestOperationConfig_operationConfig_Sample.IncludePromptLogprobs = requestOperationConfig_operationConfig_Sample_operationConfig_Sample_IncludePromptLogprob.Value;
                requestOperationConfig_operationConfig_SampleIsNull = false;
            }
            System.String requestOperationConfig_operationConfig_Sample_operationConfig_Sample_ModelPackageArn = null;
            if (cmdletContext.OperationConfig_Sample_ModelPackageArn != null)
            {
                requestOperationConfig_operationConfig_Sample_operationConfig_Sample_ModelPackageArn = cmdletContext.OperationConfig_Sample_ModelPackageArn;
            }
            if (requestOperationConfig_operationConfig_Sample_operationConfig_Sample_ModelPackageArn != null)
            {
                requestOperationConfig_operationConfig_Sample.ModelPackageArn = requestOperationConfig_operationConfig_Sample_operationConfig_Sample_ModelPackageArn;
                requestOperationConfig_operationConfig_SampleIsNull = false;
            }
            System.Int32? requestOperationConfig_operationConfig_Sample_operationConfig_Sample_NumSample = null;
            if (cmdletContext.OperationConfig_Sample_NumSample != null)
            {
                requestOperationConfig_operationConfig_Sample_operationConfig_Sample_NumSample = cmdletContext.OperationConfig_Sample_NumSample.Value;
            }
            if (requestOperationConfig_operationConfig_Sample_operationConfig_Sample_NumSample != null)
            {
                requestOperationConfig_operationConfig_Sample.NumSamples = requestOperationConfig_operationConfig_Sample_operationConfig_Sample_NumSample.Value;
                requestOperationConfig_operationConfig_SampleIsNull = false;
            }
            System.Int32? requestOperationConfig_operationConfig_Sample_operationConfig_Sample_TopkPromptLogprob = null;
            if (cmdletContext.OperationConfig_Sample_TopkPromptLogprob != null)
            {
                requestOperationConfig_operationConfig_Sample_operationConfig_Sample_TopkPromptLogprob = cmdletContext.OperationConfig_Sample_TopkPromptLogprob.Value;
            }
            if (requestOperationConfig_operationConfig_Sample_operationConfig_Sample_TopkPromptLogprob != null)
            {
                requestOperationConfig_operationConfig_Sample.TopkPromptLogprobs = requestOperationConfig_operationConfig_Sample_operationConfig_Sample_TopkPromptLogprob.Value;
                requestOperationConfig_operationConfig_SampleIsNull = false;
            }
            Amazon.SageMakerTrainingSessionRuntime.Model.ModelInput requestOperationConfig_operationConfig_Sample_operationConfig_Sample_Prompt = null;
            
             // populate Prompt
            var requestOperationConfig_operationConfig_Sample_operationConfig_Sample_PromptIsNull = true;
            requestOperationConfig_operationConfig_Sample_operationConfig_Sample_Prompt = new Amazon.SageMakerTrainingSessionRuntime.Model.ModelInput();
            List<Amazon.SageMakerTrainingSessionRuntime.Model.EncodedTextChunk> requestOperationConfig_operationConfig_Sample_operationConfig_Sample_Prompt_operationConfig_Sample_Prompt_Chunk = null;
            if (cmdletContext.OperationConfig_Sample_Prompt_Chunk != null)
            {
                requestOperationConfig_operationConfig_Sample_operationConfig_Sample_Prompt_operationConfig_Sample_Prompt_Chunk = cmdletContext.OperationConfig_Sample_Prompt_Chunk;
            }
            if (requestOperationConfig_operationConfig_Sample_operationConfig_Sample_Prompt_operationConfig_Sample_Prompt_Chunk != null)
            {
                requestOperationConfig_operationConfig_Sample_operationConfig_Sample_Prompt.Chunks = requestOperationConfig_operationConfig_Sample_operationConfig_Sample_Prompt_operationConfig_Sample_Prompt_Chunk;
                requestOperationConfig_operationConfig_Sample_operationConfig_Sample_PromptIsNull = false;
            }
             // determine if requestOperationConfig_operationConfig_Sample_operationConfig_Sample_Prompt should be set to null
            if (requestOperationConfig_operationConfig_Sample_operationConfig_Sample_PromptIsNull)
            {
                requestOperationConfig_operationConfig_Sample_operationConfig_Sample_Prompt = null;
            }
            if (requestOperationConfig_operationConfig_Sample_operationConfig_Sample_Prompt != null)
            {
                requestOperationConfig_operationConfig_Sample.Prompt = requestOperationConfig_operationConfig_Sample_operationConfig_Sample_Prompt;
                requestOperationConfig_operationConfig_SampleIsNull = false;
            }
            Amazon.SageMakerTrainingSessionRuntime.Model.SamplingParams requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParams = null;
            
             // populate SamplingParams
            var requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParamsIsNull = true;
            requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParams = new Amazon.SageMakerTrainingSessionRuntime.Model.SamplingParams();
            System.Int32? requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParams_operationConfig_Sample_SamplingParams_MaxToken = null;
            if (cmdletContext.OperationConfig_Sample_SamplingParams_MaxToken != null)
            {
                requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParams_operationConfig_Sample_SamplingParams_MaxToken = cmdletContext.OperationConfig_Sample_SamplingParams_MaxToken.Value;
            }
            if (requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParams_operationConfig_Sample_SamplingParams_MaxToken != null)
            {
                requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParams.MaxTokens = requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParams_operationConfig_Sample_SamplingParams_MaxToken.Value;
                requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParamsIsNull = false;
            }
            System.Int32? requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParams_operationConfig_Sample_SamplingParams_Seed = null;
            if (cmdletContext.OperationConfig_Sample_SamplingParams_Seed != null)
            {
                requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParams_operationConfig_Sample_SamplingParams_Seed = cmdletContext.OperationConfig_Sample_SamplingParams_Seed.Value;
            }
            if (requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParams_operationConfig_Sample_SamplingParams_Seed != null)
            {
                requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParams.Seed = requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParams_operationConfig_Sample_SamplingParams_Seed.Value;
                requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParamsIsNull = false;
            }
            List<System.String> requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParams_operationConfig_Sample_SamplingParams_Stop = null;
            if (cmdletContext.OperationConfig_Sample_SamplingParams_Stop != null)
            {
                requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParams_operationConfig_Sample_SamplingParams_Stop = cmdletContext.OperationConfig_Sample_SamplingParams_Stop;
            }
            if (requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParams_operationConfig_Sample_SamplingParams_Stop != null)
            {
                requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParams.Stop = requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParams_operationConfig_Sample_SamplingParams_Stop;
                requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParamsIsNull = false;
            }
            System.Double? requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParams_operationConfig_Sample_SamplingParams_Temperature = null;
            if (cmdletContext.OperationConfig_Sample_SamplingParams_Temperature != null)
            {
                requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParams_operationConfig_Sample_SamplingParams_Temperature = cmdletContext.OperationConfig_Sample_SamplingParams_Temperature.Value;
            }
            if (requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParams_operationConfig_Sample_SamplingParams_Temperature != null)
            {
                requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParams.Temperature = requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParams_operationConfig_Sample_SamplingParams_Temperature.Value;
                requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParamsIsNull = false;
            }
            System.Int32? requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParams_operationConfig_Sample_SamplingParams_TopK = null;
            if (cmdletContext.OperationConfig_Sample_SamplingParams_TopK != null)
            {
                requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParams_operationConfig_Sample_SamplingParams_TopK = cmdletContext.OperationConfig_Sample_SamplingParams_TopK.Value;
            }
            if (requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParams_operationConfig_Sample_SamplingParams_TopK != null)
            {
                requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParams.TopK = requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParams_operationConfig_Sample_SamplingParams_TopK.Value;
                requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParamsIsNull = false;
            }
            System.Double? requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParams_operationConfig_Sample_SamplingParams_TopP = null;
            if (cmdletContext.OperationConfig_Sample_SamplingParams_TopP != null)
            {
                requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParams_operationConfig_Sample_SamplingParams_TopP = cmdletContext.OperationConfig_Sample_SamplingParams_TopP.Value;
            }
            if (requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParams_operationConfig_Sample_SamplingParams_TopP != null)
            {
                requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParams.TopP = requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParams_operationConfig_Sample_SamplingParams_TopP.Value;
                requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParamsIsNull = false;
            }
             // determine if requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParams should be set to null
            if (requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParamsIsNull)
            {
                requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParams = null;
            }
            if (requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParams != null)
            {
                requestOperationConfig_operationConfig_Sample.SamplingParams = requestOperationConfig_operationConfig_Sample_operationConfig_Sample_SamplingParams;
                requestOperationConfig_operationConfig_SampleIsNull = false;
            }
             // determine if requestOperationConfig_operationConfig_Sample should be set to null
            if (requestOperationConfig_operationConfig_SampleIsNull)
            {
                requestOperationConfig_operationConfig_Sample = null;
            }
            if (requestOperationConfig_operationConfig_Sample != null)
            {
                request.OperationConfig.Sample = requestOperationConfig_operationConfig_Sample;
                requestOperationConfigIsNull = false;
            }
             // determine if request.OperationConfig should be set to null
            if (requestOperationConfigIsNull)
            {
                request.OperationConfig = null;
            }
            if (cmdletContext.TrainingSessionName != null)
            {
                request.TrainingSessionName = cmdletContext.TrainingSessionName;
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
        
        private Amazon.SageMakerTrainingSessionRuntime.Model.ExecuteSamplingOperationResponse CallAWSServiceOperation(IAmazonSageMakerTrainingSessionRuntime client, Amazon.SageMakerTrainingSessionRuntime.Model.ExecuteSamplingOperationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "SageMaker Training Session Runtime", "ExecuteSamplingOperation");
            try
            {
                return client.ExecuteSamplingOperationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String OperationConfig_ComputeLogprobs_ModelPackageArn { get; set; }
            public List<Amazon.SageMakerTrainingSessionRuntime.Model.EncodedTextChunk> OperationConfig_ComputeLogprobs_Prompt_Chunk { get; set; }
            public System.String OperationConfig_LoadWeightsForSampling_ModelPackageArn { get; set; }
            public System.Boolean? OperationConfig_Sample_IncludePromptLogprob { get; set; }
            public System.String OperationConfig_Sample_ModelPackageArn { get; set; }
            public System.Int32? OperationConfig_Sample_NumSample { get; set; }
            public List<Amazon.SageMakerTrainingSessionRuntime.Model.EncodedTextChunk> OperationConfig_Sample_Prompt_Chunk { get; set; }
            public System.Int32? OperationConfig_Sample_SamplingParams_MaxToken { get; set; }
            public System.Int32? OperationConfig_Sample_SamplingParams_Seed { get; set; }
            public List<System.String> OperationConfig_Sample_SamplingParams_Stop { get; set; }
            public System.Double? OperationConfig_Sample_SamplingParams_Temperature { get; set; }
            public System.Int32? OperationConfig_Sample_SamplingParams_TopK { get; set; }
            public System.Double? OperationConfig_Sample_SamplingParams_TopP { get; set; }
            public System.Int32? OperationConfig_Sample_TopkPromptLogprob { get; set; }
            public System.String TrainingSessionName { get; set; }
            public System.Func<Amazon.SageMakerTrainingSessionRuntime.Model.ExecuteSamplingOperationResponse, InvokeSMTSRSamplingOperationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.OperationId;
        }
        
    }
}
