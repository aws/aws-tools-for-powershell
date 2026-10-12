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
    /// Submits an asynchronous training operation to the specified training session. The
    /// service executes operations in sequence number order. The session must be in <c>Running</c>
    /// or <c>Blocked</c> state. Use <c>GetTrainingOperationResult</c> to poll for the result.
    /// Supported operation types: <c>forward</c>, <c>forwardBackward</c>, <c>optimizerStep</c>,
    /// <c>saveWeights</c>, <c>saveState</c>, and <c>loadState</c>.
    /// </summary>
    [Cmdlet("Invoke", "SMTSRTrainingOperation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the SageMaker Training Session Runtime ExecuteTrainingOperation API operation.", Operation = new[] {"ExecuteTrainingOperation"}, SelectReturnType = typeof(Amazon.SageMakerTrainingSessionRuntime.Model.ExecuteTrainingOperationResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMakerTrainingSessionRuntime.Model.ExecuteTrainingOperationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMakerTrainingSessionRuntime.Model.ExecuteTrainingOperationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class InvokeSMTSRTrainingOperationCmdlet : AmazonSageMakerTrainingSessionRuntimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter OperationConfig_OptimizerStep_AdamParamsConfig_Beta1
        /// <summary>
        /// <para>
        /// <para>The exponential decay rate for the first moment estimates.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? OperationConfig_OptimizerStep_AdamParamsConfig_Beta1 { get; set; }
        #endregion
        
        #region Parameter OperationConfig_OptimizerStep_AdamParamsConfig_Beta2
        /// <summary>
        /// <para>
        /// <para>The exponential decay rate for the second moment estimates.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? OperationConfig_OptimizerStep_AdamParamsConfig_Beta2 { get; set; }
        #endregion
        
        #region Parameter OperationConfig_Forward_DatumList
        /// <summary>
        /// <para>
        /// <para>The list of input data to feed through the model. Must contain at least one datum,
        /// and each datum must have a non-empty modelInput with at least one chunk.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SageMakerTrainingSessionRuntime.Model.Datum[] OperationConfig_Forward_DatumList { get; set; }
        #endregion
        
        #region Parameter OperationConfig_ForwardBackward_DatumList
        /// <summary>
        /// <para>
        /// <para>The list of input data to feed through the model. Must contain at least one datum,
        /// and each datum must have a non-empty modelInput with at least one chunk.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SageMakerTrainingSessionRuntime.Model.Datum[] OperationConfig_ForwardBackward_DatumList { get; set; }
        #endregion
        
        #region Parameter OperationConfig_SaveState_Description
        /// <summary>
        /// <para>
        /// <para>A human-readable description for the saved state checkpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OperationConfig_SaveState_Description { get; set; }
        #endregion
        
        #region Parameter OperationConfig_SaveWeights_Description
        /// <summary>
        /// <para>
        /// <para>A human-readable description for the saved checkpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OperationConfig_SaveWeights_Description { get; set; }
        #endregion
        
        #region Parameter OperationConfig_OptimizerStep_AdamParamsConfig_Ep
        /// <summary>
        /// <para>
        /// <para>A small constant added to the denominator for numerical stability.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OperationConfig_OptimizerStep_AdamParamsConfig_Eps")]
        public System.Double? OperationConfig_OptimizerStep_AdamParamsConfig_Ep { get; set; }
        #endregion
        
        #region Parameter OperationConfig_OptimizerStep_AdamParamsConfig_GradClipNorm
        /// <summary>
        /// <para>
        /// <para>The maximum gradient norm for gradient clipping. Gradients are scaled down if their
        /// norm exceeds this value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? OperationConfig_OptimizerStep_AdamParamsConfig_GradClipNorm { get; set; }
        #endregion
        
        #region Parameter OperationConfig_OptimizerStep_AdamParamsConfig_LearningRate
        /// <summary>
        /// <para>
        /// <para>The learning rate for the optimizer. Must be greater than 0.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? OperationConfig_OptimizerStep_AdamParamsConfig_LearningRate { get; set; }
        #endregion
        
        #region Parameter OperationConfig_LoadState_LoadOptimizer
        /// <summary>
        /// <para>
        /// <para>Specifies whether to also restore the optimizer state alongside model weights. When
        /// true, optimizer state is restored to resume training from where it left off.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? OperationConfig_LoadState_LoadOptimizer { get; set; }
        #endregion
        
        #region Parameter OperationConfig_OptimizerStep_AdamParamsConfig_LoraPlusLrRatio
        /// <summary>
        /// <para>
        /// <para>The learning rate multiplier for LoRA+ B matrices relative to A matrices. When set,
        /// B matrices use <c>learningRate * loraPlusLrRatio</c> while A matrices use the base
        /// learning rate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? OperationConfig_OptimizerStep_AdamParamsConfig_LoraPlusLrRatio { get; set; }
        #endregion
        
        #region Parameter OperationConfig_Forward_LossFnConfig
        /// <summary>
        /// <para>
        /// <para>Additional loss function configuration passed to the engine. Supported keys are <c>clip_low_threshold</c>
        /// (valid range: 0 to 1) and <c>clip_high_threshold</c> (valid range: 1 to 10). Unsupported
        /// keys are rejected.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Management.Automation.PSObject OperationConfig_Forward_LossFnConfig { get; set; }
        #endregion
        
        #region Parameter OperationConfig_ForwardBackward_LossFnConfig
        /// <summary>
        /// <para>
        /// <para>Additional loss function configuration passed to the engine. Supported keys are <c>clip_low_threshold</c>
        /// (valid range: 0 to 1) and <c>clip_high_threshold</c> (valid range: 1 to 10). Unsupported
        /// keys are rejected.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Management.Automation.PSObject OperationConfig_ForwardBackward_LossFnConfig { get; set; }
        #endregion
        
        #region Parameter OperationConfig_Forward_LossFnName
        /// <summary>
        /// <para>
        /// <para>The name of the loss function to evaluate during the forward pass.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMakerTrainingSessionRuntime.LossFnName")]
        public Amazon.SageMakerTrainingSessionRuntime.LossFnName OperationConfig_Forward_LossFnName { get; set; }
        #endregion
        
        #region Parameter OperationConfig_ForwardBackward_LossFnName
        /// <summary>
        /// <para>
        /// <para>The name of the loss function to evaluate during the forward-backward pass.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMakerTrainingSessionRuntime.LossFnName")]
        public Amazon.SageMakerTrainingSessionRuntime.LossFnName OperationConfig_ForwardBackward_LossFnName { get; set; }
        #endregion
        
        #region Parameter OperationConfig_SaveWeights_MergeWeight
        /// <summary>
        /// <para>
        /// <para>Specifies whether to merge LoRA adapter weights into the base model before saving.
        /// When true, the saved checkpoint contains the full merged model weights.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OperationConfig_SaveWeights_MergeWeights")]
        public System.Boolean? OperationConfig_SaveWeights_MergeWeight { get; set; }
        #endregion
        
        #region Parameter OperationConfig_LoadState_ModelPackageArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the model package containing the checkpoint to load. Must be a valid SageMaker
        /// model package ARN in the format <c>arn:aws:sagemaker:REGION:ACCOUNT:model-package/PACKAGE_NAME/VERSION</c>.
        /// Model package group ARNs are not accepted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OperationConfig_LoadState_ModelPackageArn { get; set; }
        #endregion
        
        #region Parameter SequenceNumber
        /// <summary>
        /// <para>
        /// <para>The monotonically increasing sequence number that determines execution order. The
        /// training session processes operations strictly in sequence number order. If a gap
        /// exists, the session blocks until the missing operation arrives or times out. Must
        /// be at least 1.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? SequenceNumber { get; set; }
        #endregion
        
        #region Parameter TrainingSessionName
        /// <summary>
        /// <para>
        /// <para>The name of the training session to submit the operation to.</para>
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
        public System.String TrainingSessionName { get; set; }
        #endregion
        
        #region Parameter OperationConfig_OptimizerStep_AdamParamsConfig_WeightDecay
        /// <summary>
        /// <para>
        /// <para>The weight decay (L2 regularization) coefficient.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? OperationConfig_OptimizerStep_AdamParamsConfig_WeightDecay { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure that the operation
        /// completes no more than one time. If you retry a request with the same client token
        /// and the same parameters, the service ignores the request but does not return an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'OperationId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMakerTrainingSessionRuntime.Model.ExecuteTrainingOperationResponse).
        /// Specifying the name of a property of type Amazon.SageMakerTrainingSessionRuntime.Model.ExecuteTrainingOperationResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-SMTSRTrainingOperation (ExecuteTrainingOperation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMakerTrainingSessionRuntime.Model.ExecuteTrainingOperationResponse, InvokeSMTSRTrainingOperationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            if (this.OperationConfig_Forward_DatumList != null)
            {
                context.OperationConfig_Forward_DatumList = new List<Amazon.SageMakerTrainingSessionRuntime.Model.Datum>(this.OperationConfig_Forward_DatumList);
            }
            context.OperationConfig_Forward_LossFnConfig = this.OperationConfig_Forward_LossFnConfig;
            context.OperationConfig_Forward_LossFnName = this.OperationConfig_Forward_LossFnName;
            if (this.OperationConfig_ForwardBackward_DatumList != null)
            {
                context.OperationConfig_ForwardBackward_DatumList = new List<Amazon.SageMakerTrainingSessionRuntime.Model.Datum>(this.OperationConfig_ForwardBackward_DatumList);
            }
            context.OperationConfig_ForwardBackward_LossFnConfig = this.OperationConfig_ForwardBackward_LossFnConfig;
            context.OperationConfig_ForwardBackward_LossFnName = this.OperationConfig_ForwardBackward_LossFnName;
            context.OperationConfig_LoadState_LoadOptimizer = this.OperationConfig_LoadState_LoadOptimizer;
            context.OperationConfig_LoadState_ModelPackageArn = this.OperationConfig_LoadState_ModelPackageArn;
            context.OperationConfig_OptimizerStep_AdamParamsConfig_Beta1 = this.OperationConfig_OptimizerStep_AdamParamsConfig_Beta1;
            context.OperationConfig_OptimizerStep_AdamParamsConfig_Beta2 = this.OperationConfig_OptimizerStep_AdamParamsConfig_Beta2;
            context.OperationConfig_OptimizerStep_AdamParamsConfig_Ep = this.OperationConfig_OptimizerStep_AdamParamsConfig_Ep;
            context.OperationConfig_OptimizerStep_AdamParamsConfig_GradClipNorm = this.OperationConfig_OptimizerStep_AdamParamsConfig_GradClipNorm;
            context.OperationConfig_OptimizerStep_AdamParamsConfig_LearningRate = this.OperationConfig_OptimizerStep_AdamParamsConfig_LearningRate;
            context.OperationConfig_OptimizerStep_AdamParamsConfig_LoraPlusLrRatio = this.OperationConfig_OptimizerStep_AdamParamsConfig_LoraPlusLrRatio;
            context.OperationConfig_OptimizerStep_AdamParamsConfig_WeightDecay = this.OperationConfig_OptimizerStep_AdamParamsConfig_WeightDecay;
            context.OperationConfig_SaveState_Description = this.OperationConfig_SaveState_Description;
            context.OperationConfig_SaveWeights_Description = this.OperationConfig_SaveWeights_Description;
            context.OperationConfig_SaveWeights_MergeWeight = this.OperationConfig_SaveWeights_MergeWeight;
            context.SequenceNumber = this.SequenceNumber;
            #if MODULAR
            if (this.SequenceNumber == null && ParameterWasBound(nameof(this.SequenceNumber)))
            {
                WriteWarning("You are passing $null as a value for parameter SequenceNumber which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.SageMakerTrainingSessionRuntime.Model.ExecuteTrainingOperationRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate OperationConfig
            var requestOperationConfigIsNull = true;
            request.OperationConfig = new Amazon.SageMakerTrainingSessionRuntime.Model.OperationConfig();
            Amazon.SageMakerTrainingSessionRuntime.Model.OptimizerStepConfig requestOperationConfig_operationConfig_OptimizerStep = null;
            
             // populate OptimizerStep
            var requestOperationConfig_operationConfig_OptimizerStepIsNull = true;
            requestOperationConfig_operationConfig_OptimizerStep = new Amazon.SageMakerTrainingSessionRuntime.Model.OptimizerStepConfig();
            Amazon.SageMakerTrainingSessionRuntime.Model.AdamParamsConfig requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfig = null;
            
             // populate AdamParamsConfig
            var requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfigIsNull = true;
            requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfig = new Amazon.SageMakerTrainingSessionRuntime.Model.AdamParamsConfig();
            System.Double? requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfig_operationConfig_OptimizerStep_AdamParamsConfig_Beta1 = null;
            if (cmdletContext.OperationConfig_OptimizerStep_AdamParamsConfig_Beta1 != null)
            {
                requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfig_operationConfig_OptimizerStep_AdamParamsConfig_Beta1 = cmdletContext.OperationConfig_OptimizerStep_AdamParamsConfig_Beta1.Value;
            }
            if (requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfig_operationConfig_OptimizerStep_AdamParamsConfig_Beta1 != null)
            {
                requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfig.Beta1 = requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfig_operationConfig_OptimizerStep_AdamParamsConfig_Beta1.Value;
                requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfigIsNull = false;
            }
            System.Double? requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfig_operationConfig_OptimizerStep_AdamParamsConfig_Beta2 = null;
            if (cmdletContext.OperationConfig_OptimizerStep_AdamParamsConfig_Beta2 != null)
            {
                requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfig_operationConfig_OptimizerStep_AdamParamsConfig_Beta2 = cmdletContext.OperationConfig_OptimizerStep_AdamParamsConfig_Beta2.Value;
            }
            if (requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfig_operationConfig_OptimizerStep_AdamParamsConfig_Beta2 != null)
            {
                requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfig.Beta2 = requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfig_operationConfig_OptimizerStep_AdamParamsConfig_Beta2.Value;
                requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfigIsNull = false;
            }
            System.Double? requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfig_operationConfig_OptimizerStep_AdamParamsConfig_Ep = null;
            if (cmdletContext.OperationConfig_OptimizerStep_AdamParamsConfig_Ep != null)
            {
                requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfig_operationConfig_OptimizerStep_AdamParamsConfig_Ep = cmdletContext.OperationConfig_OptimizerStep_AdamParamsConfig_Ep.Value;
            }
            if (requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfig_operationConfig_OptimizerStep_AdamParamsConfig_Ep != null)
            {
                requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfig.Eps = requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfig_operationConfig_OptimizerStep_AdamParamsConfig_Ep.Value;
                requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfigIsNull = false;
            }
            System.Double? requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfig_operationConfig_OptimizerStep_AdamParamsConfig_GradClipNorm = null;
            if (cmdletContext.OperationConfig_OptimizerStep_AdamParamsConfig_GradClipNorm != null)
            {
                requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfig_operationConfig_OptimizerStep_AdamParamsConfig_GradClipNorm = cmdletContext.OperationConfig_OptimizerStep_AdamParamsConfig_GradClipNorm.Value;
            }
            if (requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfig_operationConfig_OptimizerStep_AdamParamsConfig_GradClipNorm != null)
            {
                requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfig.GradClipNorm = requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfig_operationConfig_OptimizerStep_AdamParamsConfig_GradClipNorm.Value;
                requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfigIsNull = false;
            }
            System.Double? requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfig_operationConfig_OptimizerStep_AdamParamsConfig_LearningRate = null;
            if (cmdletContext.OperationConfig_OptimizerStep_AdamParamsConfig_LearningRate != null)
            {
                requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfig_operationConfig_OptimizerStep_AdamParamsConfig_LearningRate = cmdletContext.OperationConfig_OptimizerStep_AdamParamsConfig_LearningRate.Value;
            }
            if (requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfig_operationConfig_OptimizerStep_AdamParamsConfig_LearningRate != null)
            {
                requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfig.LearningRate = requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfig_operationConfig_OptimizerStep_AdamParamsConfig_LearningRate.Value;
                requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfigIsNull = false;
            }
            System.Double? requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfig_operationConfig_OptimizerStep_AdamParamsConfig_LoraPlusLrRatio = null;
            if (cmdletContext.OperationConfig_OptimizerStep_AdamParamsConfig_LoraPlusLrRatio != null)
            {
                requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfig_operationConfig_OptimizerStep_AdamParamsConfig_LoraPlusLrRatio = cmdletContext.OperationConfig_OptimizerStep_AdamParamsConfig_LoraPlusLrRatio.Value;
            }
            if (requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfig_operationConfig_OptimizerStep_AdamParamsConfig_LoraPlusLrRatio != null)
            {
                requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfig.LoraPlusLrRatio = requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfig_operationConfig_OptimizerStep_AdamParamsConfig_LoraPlusLrRatio.Value;
                requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfigIsNull = false;
            }
            System.Double? requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfig_operationConfig_OptimizerStep_AdamParamsConfig_WeightDecay = null;
            if (cmdletContext.OperationConfig_OptimizerStep_AdamParamsConfig_WeightDecay != null)
            {
                requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfig_operationConfig_OptimizerStep_AdamParamsConfig_WeightDecay = cmdletContext.OperationConfig_OptimizerStep_AdamParamsConfig_WeightDecay.Value;
            }
            if (requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfig_operationConfig_OptimizerStep_AdamParamsConfig_WeightDecay != null)
            {
                requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfig.WeightDecay = requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfig_operationConfig_OptimizerStep_AdamParamsConfig_WeightDecay.Value;
                requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfigIsNull = false;
            }
             // determine if requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfig should be set to null
            if (requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfigIsNull)
            {
                requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfig = null;
            }
            if (requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfig != null)
            {
                requestOperationConfig_operationConfig_OptimizerStep.AdamParamsConfig = requestOperationConfig_operationConfig_OptimizerStep_operationConfig_OptimizerStep_AdamParamsConfig;
                requestOperationConfig_operationConfig_OptimizerStepIsNull = false;
            }
             // determine if requestOperationConfig_operationConfig_OptimizerStep should be set to null
            if (requestOperationConfig_operationConfig_OptimizerStepIsNull)
            {
                requestOperationConfig_operationConfig_OptimizerStep = null;
            }
            if (requestOperationConfig_operationConfig_OptimizerStep != null)
            {
                request.OperationConfig.OptimizerStep = requestOperationConfig_operationConfig_OptimizerStep;
                requestOperationConfigIsNull = false;
            }
            Amazon.SageMakerTrainingSessionRuntime.Model.SaveStateConfig requestOperationConfig_operationConfig_SaveState = null;
            
             // populate SaveState
            var requestOperationConfig_operationConfig_SaveStateIsNull = true;
            requestOperationConfig_operationConfig_SaveState = new Amazon.SageMakerTrainingSessionRuntime.Model.SaveStateConfig();
            System.String requestOperationConfig_operationConfig_SaveState_operationConfig_SaveState_Description = null;
            if (cmdletContext.OperationConfig_SaveState_Description != null)
            {
                requestOperationConfig_operationConfig_SaveState_operationConfig_SaveState_Description = cmdletContext.OperationConfig_SaveState_Description;
            }
            if (requestOperationConfig_operationConfig_SaveState_operationConfig_SaveState_Description != null)
            {
                requestOperationConfig_operationConfig_SaveState.Description = requestOperationConfig_operationConfig_SaveState_operationConfig_SaveState_Description;
                requestOperationConfig_operationConfig_SaveStateIsNull = false;
            }
             // determine if requestOperationConfig_operationConfig_SaveState should be set to null
            if (requestOperationConfig_operationConfig_SaveStateIsNull)
            {
                requestOperationConfig_operationConfig_SaveState = null;
            }
            if (requestOperationConfig_operationConfig_SaveState != null)
            {
                request.OperationConfig.SaveState = requestOperationConfig_operationConfig_SaveState;
                requestOperationConfigIsNull = false;
            }
            Amazon.SageMakerTrainingSessionRuntime.Model.LoadStateConfig requestOperationConfig_operationConfig_LoadState = null;
            
             // populate LoadState
            var requestOperationConfig_operationConfig_LoadStateIsNull = true;
            requestOperationConfig_operationConfig_LoadState = new Amazon.SageMakerTrainingSessionRuntime.Model.LoadStateConfig();
            System.Boolean? requestOperationConfig_operationConfig_LoadState_operationConfig_LoadState_LoadOptimizer = null;
            if (cmdletContext.OperationConfig_LoadState_LoadOptimizer != null)
            {
                requestOperationConfig_operationConfig_LoadState_operationConfig_LoadState_LoadOptimizer = cmdletContext.OperationConfig_LoadState_LoadOptimizer.Value;
            }
            if (requestOperationConfig_operationConfig_LoadState_operationConfig_LoadState_LoadOptimizer != null)
            {
                requestOperationConfig_operationConfig_LoadState.LoadOptimizer = requestOperationConfig_operationConfig_LoadState_operationConfig_LoadState_LoadOptimizer.Value;
                requestOperationConfig_operationConfig_LoadStateIsNull = false;
            }
            System.String requestOperationConfig_operationConfig_LoadState_operationConfig_LoadState_ModelPackageArn = null;
            if (cmdletContext.OperationConfig_LoadState_ModelPackageArn != null)
            {
                requestOperationConfig_operationConfig_LoadState_operationConfig_LoadState_ModelPackageArn = cmdletContext.OperationConfig_LoadState_ModelPackageArn;
            }
            if (requestOperationConfig_operationConfig_LoadState_operationConfig_LoadState_ModelPackageArn != null)
            {
                requestOperationConfig_operationConfig_LoadState.ModelPackageArn = requestOperationConfig_operationConfig_LoadState_operationConfig_LoadState_ModelPackageArn;
                requestOperationConfig_operationConfig_LoadStateIsNull = false;
            }
             // determine if requestOperationConfig_operationConfig_LoadState should be set to null
            if (requestOperationConfig_operationConfig_LoadStateIsNull)
            {
                requestOperationConfig_operationConfig_LoadState = null;
            }
            if (requestOperationConfig_operationConfig_LoadState != null)
            {
                request.OperationConfig.LoadState = requestOperationConfig_operationConfig_LoadState;
                requestOperationConfigIsNull = false;
            }
            Amazon.SageMakerTrainingSessionRuntime.Model.SaveWeightsConfig requestOperationConfig_operationConfig_SaveWeights = null;
            
             // populate SaveWeights
            var requestOperationConfig_operationConfig_SaveWeightsIsNull = true;
            requestOperationConfig_operationConfig_SaveWeights = new Amazon.SageMakerTrainingSessionRuntime.Model.SaveWeightsConfig();
            System.String requestOperationConfig_operationConfig_SaveWeights_operationConfig_SaveWeights_Description = null;
            if (cmdletContext.OperationConfig_SaveWeights_Description != null)
            {
                requestOperationConfig_operationConfig_SaveWeights_operationConfig_SaveWeights_Description = cmdletContext.OperationConfig_SaveWeights_Description;
            }
            if (requestOperationConfig_operationConfig_SaveWeights_operationConfig_SaveWeights_Description != null)
            {
                requestOperationConfig_operationConfig_SaveWeights.Description = requestOperationConfig_operationConfig_SaveWeights_operationConfig_SaveWeights_Description;
                requestOperationConfig_operationConfig_SaveWeightsIsNull = false;
            }
            System.Boolean? requestOperationConfig_operationConfig_SaveWeights_operationConfig_SaveWeights_MergeWeight = null;
            if (cmdletContext.OperationConfig_SaveWeights_MergeWeight != null)
            {
                requestOperationConfig_operationConfig_SaveWeights_operationConfig_SaveWeights_MergeWeight = cmdletContext.OperationConfig_SaveWeights_MergeWeight.Value;
            }
            if (requestOperationConfig_operationConfig_SaveWeights_operationConfig_SaveWeights_MergeWeight != null)
            {
                requestOperationConfig_operationConfig_SaveWeights.MergeWeights = requestOperationConfig_operationConfig_SaveWeights_operationConfig_SaveWeights_MergeWeight.Value;
                requestOperationConfig_operationConfig_SaveWeightsIsNull = false;
            }
             // determine if requestOperationConfig_operationConfig_SaveWeights should be set to null
            if (requestOperationConfig_operationConfig_SaveWeightsIsNull)
            {
                requestOperationConfig_operationConfig_SaveWeights = null;
            }
            if (requestOperationConfig_operationConfig_SaveWeights != null)
            {
                request.OperationConfig.SaveWeights = requestOperationConfig_operationConfig_SaveWeights;
                requestOperationConfigIsNull = false;
            }
            Amazon.SageMakerTrainingSessionRuntime.Model.ForwardConfig requestOperationConfig_operationConfig_Forward = null;
            
             // populate Forward
            var requestOperationConfig_operationConfig_ForwardIsNull = true;
            requestOperationConfig_operationConfig_Forward = new Amazon.SageMakerTrainingSessionRuntime.Model.ForwardConfig();
            List<Amazon.SageMakerTrainingSessionRuntime.Model.Datum> requestOperationConfig_operationConfig_Forward_operationConfig_Forward_DatumList = null;
            if (cmdletContext.OperationConfig_Forward_DatumList != null)
            {
                requestOperationConfig_operationConfig_Forward_operationConfig_Forward_DatumList = cmdletContext.OperationConfig_Forward_DatumList;
            }
            if (requestOperationConfig_operationConfig_Forward_operationConfig_Forward_DatumList != null)
            {
                requestOperationConfig_operationConfig_Forward.DatumList = requestOperationConfig_operationConfig_Forward_operationConfig_Forward_DatumList;
                requestOperationConfig_operationConfig_ForwardIsNull = false;
            }
            Amazon.Runtime.Documents.Document? requestOperationConfig_operationConfig_Forward_operationConfig_Forward_LossFnConfig = null;
            if (cmdletContext.OperationConfig_Forward_LossFnConfig != null)
            {
                requestOperationConfig_operationConfig_Forward_operationConfig_Forward_LossFnConfig = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.OperationConfig_Forward_LossFnConfig);
            }
            if (requestOperationConfig_operationConfig_Forward_operationConfig_Forward_LossFnConfig != null)
            {
                requestOperationConfig_operationConfig_Forward.LossFnConfig = requestOperationConfig_operationConfig_Forward_operationConfig_Forward_LossFnConfig.Value;
                requestOperationConfig_operationConfig_ForwardIsNull = false;
            }
            Amazon.SageMakerTrainingSessionRuntime.LossFnName requestOperationConfig_operationConfig_Forward_operationConfig_Forward_LossFnName = null;
            if (cmdletContext.OperationConfig_Forward_LossFnName != null)
            {
                requestOperationConfig_operationConfig_Forward_operationConfig_Forward_LossFnName = cmdletContext.OperationConfig_Forward_LossFnName;
            }
            if (requestOperationConfig_operationConfig_Forward_operationConfig_Forward_LossFnName != null)
            {
                requestOperationConfig_operationConfig_Forward.LossFnName = requestOperationConfig_operationConfig_Forward_operationConfig_Forward_LossFnName;
                requestOperationConfig_operationConfig_ForwardIsNull = false;
            }
             // determine if requestOperationConfig_operationConfig_Forward should be set to null
            if (requestOperationConfig_operationConfig_ForwardIsNull)
            {
                requestOperationConfig_operationConfig_Forward = null;
            }
            if (requestOperationConfig_operationConfig_Forward != null)
            {
                request.OperationConfig.Forward = requestOperationConfig_operationConfig_Forward;
                requestOperationConfigIsNull = false;
            }
            Amazon.SageMakerTrainingSessionRuntime.Model.ForwardBackwardConfig requestOperationConfig_operationConfig_ForwardBackward = null;
            
             // populate ForwardBackward
            var requestOperationConfig_operationConfig_ForwardBackwardIsNull = true;
            requestOperationConfig_operationConfig_ForwardBackward = new Amazon.SageMakerTrainingSessionRuntime.Model.ForwardBackwardConfig();
            List<Amazon.SageMakerTrainingSessionRuntime.Model.Datum> requestOperationConfig_operationConfig_ForwardBackward_operationConfig_ForwardBackward_DatumList = null;
            if (cmdletContext.OperationConfig_ForwardBackward_DatumList != null)
            {
                requestOperationConfig_operationConfig_ForwardBackward_operationConfig_ForwardBackward_DatumList = cmdletContext.OperationConfig_ForwardBackward_DatumList;
            }
            if (requestOperationConfig_operationConfig_ForwardBackward_operationConfig_ForwardBackward_DatumList != null)
            {
                requestOperationConfig_operationConfig_ForwardBackward.DatumList = requestOperationConfig_operationConfig_ForwardBackward_operationConfig_ForwardBackward_DatumList;
                requestOperationConfig_operationConfig_ForwardBackwardIsNull = false;
            }
            Amazon.Runtime.Documents.Document? requestOperationConfig_operationConfig_ForwardBackward_operationConfig_ForwardBackward_LossFnConfig = null;
            if (cmdletContext.OperationConfig_ForwardBackward_LossFnConfig != null)
            {
                requestOperationConfig_operationConfig_ForwardBackward_operationConfig_ForwardBackward_LossFnConfig = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.OperationConfig_ForwardBackward_LossFnConfig);
            }
            if (requestOperationConfig_operationConfig_ForwardBackward_operationConfig_ForwardBackward_LossFnConfig != null)
            {
                requestOperationConfig_operationConfig_ForwardBackward.LossFnConfig = requestOperationConfig_operationConfig_ForwardBackward_operationConfig_ForwardBackward_LossFnConfig.Value;
                requestOperationConfig_operationConfig_ForwardBackwardIsNull = false;
            }
            Amazon.SageMakerTrainingSessionRuntime.LossFnName requestOperationConfig_operationConfig_ForwardBackward_operationConfig_ForwardBackward_LossFnName = null;
            if (cmdletContext.OperationConfig_ForwardBackward_LossFnName != null)
            {
                requestOperationConfig_operationConfig_ForwardBackward_operationConfig_ForwardBackward_LossFnName = cmdletContext.OperationConfig_ForwardBackward_LossFnName;
            }
            if (requestOperationConfig_operationConfig_ForwardBackward_operationConfig_ForwardBackward_LossFnName != null)
            {
                requestOperationConfig_operationConfig_ForwardBackward.LossFnName = requestOperationConfig_operationConfig_ForwardBackward_operationConfig_ForwardBackward_LossFnName;
                requestOperationConfig_operationConfig_ForwardBackwardIsNull = false;
            }
             // determine if requestOperationConfig_operationConfig_ForwardBackward should be set to null
            if (requestOperationConfig_operationConfig_ForwardBackwardIsNull)
            {
                requestOperationConfig_operationConfig_ForwardBackward = null;
            }
            if (requestOperationConfig_operationConfig_ForwardBackward != null)
            {
                request.OperationConfig.ForwardBackward = requestOperationConfig_operationConfig_ForwardBackward;
                requestOperationConfigIsNull = false;
            }
             // determine if request.OperationConfig should be set to null
            if (requestOperationConfigIsNull)
            {
                request.OperationConfig = null;
            }
            if (cmdletContext.SequenceNumber != null)
            {
                request.SequenceNumber = cmdletContext.SequenceNumber.Value;
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
        
        private Amazon.SageMakerTrainingSessionRuntime.Model.ExecuteTrainingOperationResponse CallAWSServiceOperation(IAmazonSageMakerTrainingSessionRuntime client, Amazon.SageMakerTrainingSessionRuntime.Model.ExecuteTrainingOperationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "SageMaker Training Session Runtime", "ExecuteTrainingOperation");
            try
            {
                return client.ExecuteTrainingOperationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.SageMakerTrainingSessionRuntime.Model.Datum> OperationConfig_Forward_DatumList { get; set; }
            public System.Management.Automation.PSObject OperationConfig_Forward_LossFnConfig { get; set; }
            public Amazon.SageMakerTrainingSessionRuntime.LossFnName OperationConfig_Forward_LossFnName { get; set; }
            public List<Amazon.SageMakerTrainingSessionRuntime.Model.Datum> OperationConfig_ForwardBackward_DatumList { get; set; }
            public System.Management.Automation.PSObject OperationConfig_ForwardBackward_LossFnConfig { get; set; }
            public Amazon.SageMakerTrainingSessionRuntime.LossFnName OperationConfig_ForwardBackward_LossFnName { get; set; }
            public System.Boolean? OperationConfig_LoadState_LoadOptimizer { get; set; }
            public System.String OperationConfig_LoadState_ModelPackageArn { get; set; }
            public System.Double? OperationConfig_OptimizerStep_AdamParamsConfig_Beta1 { get; set; }
            public System.Double? OperationConfig_OptimizerStep_AdamParamsConfig_Beta2 { get; set; }
            public System.Double? OperationConfig_OptimizerStep_AdamParamsConfig_Ep { get; set; }
            public System.Double? OperationConfig_OptimizerStep_AdamParamsConfig_GradClipNorm { get; set; }
            public System.Double? OperationConfig_OptimizerStep_AdamParamsConfig_LearningRate { get; set; }
            public System.Double? OperationConfig_OptimizerStep_AdamParamsConfig_LoraPlusLrRatio { get; set; }
            public System.Double? OperationConfig_OptimizerStep_AdamParamsConfig_WeightDecay { get; set; }
            public System.String OperationConfig_SaveState_Description { get; set; }
            public System.String OperationConfig_SaveWeights_Description { get; set; }
            public System.Boolean? OperationConfig_SaveWeights_MergeWeight { get; set; }
            public System.Int32? SequenceNumber { get; set; }
            public System.String TrainingSessionName { get; set; }
            public System.Func<Amazon.SageMakerTrainingSessionRuntime.Model.ExecuteTrainingOperationResponse, InvokeSMTSRTrainingOperationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.OperationId;
        }
        
    }
}
