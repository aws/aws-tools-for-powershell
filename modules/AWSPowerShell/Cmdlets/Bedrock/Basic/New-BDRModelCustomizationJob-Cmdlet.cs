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
    /// Creates a fine-tuning job to customize a base model.
    /// 
    ///  
    /// <para>
    /// You specify the base foundation model and the location of the training data. After
    /// the model-customization job completes successfully, your custom model resource will
    /// be ready to use. Amazon Bedrock returns validation loss metrics and output generations
    /// after the job completes. 
    /// </para><para>
    /// For information on the format of training and validation data, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/model-customization-prepare.html">Prepare
    /// the datasets</a>.
    /// </para><para>
    ///  Model-customization jobs are asynchronous and the completion time depends on the
    /// base model and the training/validation data size. To monitor a job, use the <c>GetModelCustomizationJob</c>
    /// operation to retrieve the job status.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/custom-models.html">Custom
    /// models</a> in the <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/what-is-service.html">Amazon
    /// Bedrock User Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "BDRModelCustomizationJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Bedrock CreateModelCustomizationJob API operation.", Operation = new[] {"CreateModelCustomizationJob"}, SelectReturnType = typeof(Amazon.Bedrock.Model.CreateModelCustomizationJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.Bedrock.Model.CreateModelCustomizationJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Bedrock.Model.CreateModelCustomizationJobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewBDRModelCustomizationJobCmdlet : AmazonBedrockClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter RequestMetadataFilters_AndAll
        /// <summary>
        /// <para>
        /// <para>Include results where all of the based filters match.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingDataConfig_InvocationLogsConfig_RequestMetadataFilters_AndAll")]
        public Amazon.Bedrock.Model.RequestMetadataBaseFilters[] RequestMetadataFilters_AndAll { get; set; }
        #endregion
        
        #region Parameter BaseModelIdentifier
        /// <summary>
        /// <para>
        /// <para>Name of the base model.</para>
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
        public System.String BaseModelIdentifier { get; set; }
        #endregion
        
        #region Parameter HyperParameters_BatchSize
        /// <summary>
        /// <para>
        /// <para> Number of training samples processed in each batch during reinforcement fine-tuning
        /// (RFT) training. Larger batches may improve training stability. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CustomizationConfig_RftConfig_HyperParameters_BatchSize")]
        public System.Int32? HyperParameters_BatchSize { get; set; }
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
        
        #region Parameter CustomizationType
        /// <summary>
        /// <para>
        /// <para>The customization type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Bedrock.CustomizationType")]
        public Amazon.Bedrock.CustomizationType CustomizationType { get; set; }
        #endregion
        
        #region Parameter CustomModelKmsKeyId
        /// <summary>
        /// <para>
        /// <para>The custom model is encrypted at rest using this key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomModelKmsKeyId { get; set; }
        #endregion
        
        #region Parameter CustomModelName
        /// <summary>
        /// <para>
        /// <para>A name for the resulting custom model.</para>
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
        public System.String CustomModelName { get; set; }
        #endregion
        
        #region Parameter CustomModelTag
        /// <summary>
        /// <para>
        /// <para>Tags to attach to the resulting custom model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CustomModelTags")]
        public Amazon.Bedrock.Model.Tag[] CustomModelTag { get; set; }
        #endregion
        
        #region Parameter HyperParameters_EpochCount
        /// <summary>
        /// <para>
        /// <para> Number of training epochs to run during reinforcement fine-tuning. Higher values
        /// may improve performance but increase training time. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CustomizationConfig_RftConfig_HyperParameters_EpochCount")]
        public System.Int32? HyperParameters_EpochCount { get; set; }
        #endregion
        
        #region Parameter RequestMetadataFilters_Equal
        /// <summary>
        /// <para>
        /// <para>Include results where the key equals the value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingDataConfig_InvocationLogsConfig_RequestMetadataFilters_Equals")]
        public System.Collections.Hashtable RequestMetadataFilters_Equal { get; set; }
        #endregion
        
        #region Parameter HyperParameters_EvalInterval
        /// <summary>
        /// <para>
        /// <para> Interval between evaluation runs during RFT training, measured in training steps.
        /// More frequent evaluation provides better monitoring. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CustomizationConfig_RftConfig_HyperParameters_EvalInterval")]
        public System.Int32? HyperParameters_EvalInterval { get; set; }
        #endregion
        
        #region Parameter HyperParameter
        /// <summary>
        /// <para>
        /// <para>Parameters related to tuning the model. For details on the format for different models,
        /// see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/custom-models-hp.html">Custom
        /// model hyperparameters</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HyperParameters")]
        public System.Collections.Hashtable HyperParameter { get; set; }
        #endregion
        
        #region Parameter HyperParameters_InferenceMaxToken
        /// <summary>
        /// <para>
        /// <para> Maximum number of tokens the model can generate in response to each prompt during
        /// RFT training. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CustomizationConfig_RftConfig_HyperParameters_InferenceMaxTokens")]
        public System.Int32? HyperParameters_InferenceMaxToken { get; set; }
        #endregion
        
        #region Parameter JobName
        /// <summary>
        /// <para>
        /// <para>A name for the fine-tuning job.</para>
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
        /// <para>Tags to attach to the job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobTags")]
        public Amazon.Bedrock.Model.Tag[] JobTag { get; set; }
        #endregion
        
        #region Parameter LambdaGrader_LambdaArn
        /// <summary>
        /// <para>
        /// <para> ARN of the AWS Lambda function that will evaluate model responses and return reward
        /// scores for RFT training. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CustomizationConfig_RftConfig_GraderConfig_LambdaGrader_LambdaArn")]
        public System.String LambdaGrader_LambdaArn { get; set; }
        #endregion
        
        #region Parameter HyperParameters_LearningRate
        /// <summary>
        /// <para>
        /// <para> Learning rate for the reinforcement fine-tuning. Controls how quickly the model adapts
        /// to reward signals. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CustomizationConfig_RftConfig_HyperParameters_LearningRate")]
        public System.Single? HyperParameters_LearningRate { get; set; }
        #endregion
        
        #region Parameter HyperParameters_MaxPromptLength
        /// <summary>
        /// <para>
        /// <para> Maximum length of input prompts during RFT training, measured in tokens. Longer prompts
        /// allow more context but increase memory usage and training-time. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CustomizationConfig_RftConfig_HyperParameters_MaxPromptLength")]
        public System.Int32? HyperParameters_MaxPromptLength { get; set; }
        #endregion
        
        #region Parameter TeacherModelConfig_MaxResponseLengthForInference
        /// <summary>
        /// <para>
        /// <para>The maximum number of tokens requested when the customization job invokes the teacher
        /// model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CustomizationConfig_DistillationConfig_TeacherModelConfig_MaxResponseLengthForInference")]
        public System.Int32? TeacherModelConfig_MaxResponseLengthForInference { get; set; }
        #endregion
        
        #region Parameter RequestMetadataFilters_NotEqual
        /// <summary>
        /// <para>
        /// <para>Include results where the key does not equal the value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingDataConfig_InvocationLogsConfig_RequestMetadataFilters_NotEquals")]
        public System.Collections.Hashtable RequestMetadataFilters_NotEqual { get; set; }
        #endregion
        
        #region Parameter RequestMetadataFilters_OrAll
        /// <summary>
        /// <para>
        /// <para>Include results where any of the base filters match.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingDataConfig_InvocationLogsConfig_RequestMetadataFilters_OrAll")]
        public Amazon.Bedrock.Model.RequestMetadataBaseFilters[] RequestMetadataFilters_OrAll { get; set; }
        #endregion
        
        #region Parameter HyperParameters_ReasoningEffort
        /// <summary>
        /// <para>
        /// <para> Level of reasoning effort applied during RFT training. Higher values may improve
        /// response quality but increase training time. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CustomizationConfig_RftConfig_HyperParameters_ReasoningEffort")]
        [AWSConstantClassSource("Amazon.Bedrock.ReasoningEffort")]
        public Amazon.Bedrock.ReasoningEffort HyperParameters_ReasoningEffort { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an IAM service role that Amazon Bedrock can assume
        /// to perform tasks on your behalf. For example, during model training, Amazon Bedrock
        /// needs your permission to read input data from an S3 bucket, write model artifacts
        /// to an S3 bucket. To pass this role to Amazon Bedrock, the caller of this API must
        /// have the <c>iam:PassRole</c> permission. </para>
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
        /// <para>The S3 URI where the output data is stored.</para>
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
        
        #region Parameter InvocationLogSource_S3Uri
        /// <summary>
        /// <para>
        /// <para>The URI of an invocation log in a bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingDataConfig_InvocationLogsConfig_InvocationLogSource_S3Uri")]
        public System.String InvocationLogSource_S3Uri { get; set; }
        #endregion
        
        #region Parameter TrainingDataConfig_S3Uri
        /// <summary>
        /// <para>
        /// <para>The S3 URI where the training data is stored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TrainingDataConfig_S3Uri { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>An array of IDs for each security group in the VPC to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfig_SecurityGroupIds")]
        public System.String[] VpcConfig_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SubnetId
        /// <summary>
        /// <para>
        /// <para>An array of IDs for each subnet in the VPC to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfig_SubnetIds")]
        public System.String[] VpcConfig_SubnetId { get; set; }
        #endregion
        
        #region Parameter TeacherModelConfig_TeacherModelIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the teacher model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CustomizationConfig_DistillationConfig_TeacherModelConfig_TeacherModelIdentifier")]
        public System.String TeacherModelConfig_TeacherModelIdentifier { get; set; }
        #endregion
        
        #region Parameter HyperParameters_TrainingSamplePerPrompt
        /// <summary>
        /// <para>
        /// <para> Number of response samples generated per prompt during RFT training. More samples
        /// provide better reward signal estimation. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CustomizationConfig_RftConfig_HyperParameters_TrainingSamplePerPrompt")]
        public System.Int32? HyperParameters_TrainingSamplePerPrompt { get; set; }
        #endregion
        
        #region Parameter InvocationLogsConfig_UsePromptResponse
        /// <summary>
        /// <para>
        /// <para>Whether to use the model's response for training, or just the prompt. The default
        /// value is <c>False</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingDataConfig_InvocationLogsConfig_UsePromptResponse")]
        public System.Boolean? InvocationLogsConfig_UsePromptResponse { get; set; }
        #endregion
        
        #region Parameter ValidationDataConfig_Validator
        /// <summary>
        /// <para>
        /// <para>Information about the validators.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValidationDataConfig_Validators")]
        public Amazon.Bedrock.Model.Validator[] ValidationDataConfig_Validator { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'JobArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Bedrock.Model.CreateModelCustomizationJobResponse).
        /// Specifying the name of a property of type Amazon.Bedrock.Model.CreateModelCustomizationJobResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BDRModelCustomizationJob (CreateModelCustomizationJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Bedrock.Model.CreateModelCustomizationJobResponse, NewBDRModelCustomizationJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BaseModelIdentifier = this.BaseModelIdentifier;
            #if MODULAR
            if (this.BaseModelIdentifier == null && ParameterWasBound(nameof(this.BaseModelIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter BaseModelIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientRequestToken = this.ClientRequestToken;
            context.TeacherModelConfig_MaxResponseLengthForInference = this.TeacherModelConfig_MaxResponseLengthForInference;
            context.TeacherModelConfig_TeacherModelIdentifier = this.TeacherModelConfig_TeacherModelIdentifier;
            context.LambdaGrader_LambdaArn = this.LambdaGrader_LambdaArn;
            context.HyperParameters_BatchSize = this.HyperParameters_BatchSize;
            context.HyperParameters_EpochCount = this.HyperParameters_EpochCount;
            context.HyperParameters_EvalInterval = this.HyperParameters_EvalInterval;
            context.HyperParameters_InferenceMaxToken = this.HyperParameters_InferenceMaxToken;
            context.HyperParameters_LearningRate = this.HyperParameters_LearningRate;
            context.HyperParameters_MaxPromptLength = this.HyperParameters_MaxPromptLength;
            context.HyperParameters_ReasoningEffort = this.HyperParameters_ReasoningEffort;
            context.HyperParameters_TrainingSamplePerPrompt = this.HyperParameters_TrainingSamplePerPrompt;
            context.CustomizationType = this.CustomizationType;
            context.CustomModelKmsKeyId = this.CustomModelKmsKeyId;
            context.CustomModelName = this.CustomModelName;
            #if MODULAR
            if (this.CustomModelName == null && ParameterWasBound(nameof(this.CustomModelName)))
            {
                WriteWarning("You are passing $null as a value for parameter CustomModelName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.CustomModelTag != null)
            {
                context.CustomModelTag = new List<Amazon.Bedrock.Model.Tag>(this.CustomModelTag);
            }
            if (this.HyperParameter != null)
            {
                context.HyperParameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.HyperParameter.Keys)
                {
                    context.HyperParameter.Add((String)hashKey, (System.String)(this.HyperParameter[hashKey]));
                }
            }
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
            context.InvocationLogSource_S3Uri = this.InvocationLogSource_S3Uri;
            if (this.RequestMetadataFilters_AndAll != null)
            {
                context.RequestMetadataFilters_AndAll = new List<Amazon.Bedrock.Model.RequestMetadataBaseFilters>(this.RequestMetadataFilters_AndAll);
            }
            if (this.RequestMetadataFilters_Equal != null)
            {
                context.RequestMetadataFilters_Equal = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.RequestMetadataFilters_Equal.Keys)
                {
                    context.RequestMetadataFilters_Equal.Add((String)hashKey, (System.String)(this.RequestMetadataFilters_Equal[hashKey]));
                }
            }
            if (this.RequestMetadataFilters_NotEqual != null)
            {
                context.RequestMetadataFilters_NotEqual = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.RequestMetadataFilters_NotEqual.Keys)
                {
                    context.RequestMetadataFilters_NotEqual.Add((String)hashKey, (System.String)(this.RequestMetadataFilters_NotEqual[hashKey]));
                }
            }
            if (this.RequestMetadataFilters_OrAll != null)
            {
                context.RequestMetadataFilters_OrAll = new List<Amazon.Bedrock.Model.RequestMetadataBaseFilters>(this.RequestMetadataFilters_OrAll);
            }
            context.InvocationLogsConfig_UsePromptResponse = this.InvocationLogsConfig_UsePromptResponse;
            context.TrainingDataConfig_S3Uri = this.TrainingDataConfig_S3Uri;
            if (this.ValidationDataConfig_Validator != null)
            {
                context.ValidationDataConfig_Validator = new List<Amazon.Bedrock.Model.Validator>(this.ValidationDataConfig_Validator);
            }
            if (this.VpcConfig_SecurityGroupId != null)
            {
                context.VpcConfig_SecurityGroupId = new List<System.String>(this.VpcConfig_SecurityGroupId);
            }
            if (this.VpcConfig_SubnetId != null)
            {
                context.VpcConfig_SubnetId = new List<System.String>(this.VpcConfig_SubnetId);
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
            var request = new Amazon.Bedrock.Model.CreateModelCustomizationJobRequest();
            
            if (cmdletContext.BaseModelIdentifier != null)
            {
                request.BaseModelIdentifier = cmdletContext.BaseModelIdentifier;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            
             // populate CustomizationConfig
            var requestCustomizationConfigIsNull = true;
            request.CustomizationConfig = new Amazon.Bedrock.Model.CustomizationConfig();
            Amazon.Bedrock.Model.DistillationConfig requestCustomizationConfig_customizationConfig_DistillationConfig = null;
            
             // populate DistillationConfig
            var requestCustomizationConfig_customizationConfig_DistillationConfigIsNull = true;
            requestCustomizationConfig_customizationConfig_DistillationConfig = new Amazon.Bedrock.Model.DistillationConfig();
            Amazon.Bedrock.Model.TeacherModelConfig requestCustomizationConfig_customizationConfig_DistillationConfig_customizationConfig_DistillationConfig_TeacherModelConfig = null;
            
             // populate TeacherModelConfig
            var requestCustomizationConfig_customizationConfig_DistillationConfig_customizationConfig_DistillationConfig_TeacherModelConfigIsNull = true;
            requestCustomizationConfig_customizationConfig_DistillationConfig_customizationConfig_DistillationConfig_TeacherModelConfig = new Amazon.Bedrock.Model.TeacherModelConfig();
            System.Int32? requestCustomizationConfig_customizationConfig_DistillationConfig_customizationConfig_DistillationConfig_TeacherModelConfig_teacherModelConfig_MaxResponseLengthForInference = null;
            if (cmdletContext.TeacherModelConfig_MaxResponseLengthForInference != null)
            {
                requestCustomizationConfig_customizationConfig_DistillationConfig_customizationConfig_DistillationConfig_TeacherModelConfig_teacherModelConfig_MaxResponseLengthForInference = cmdletContext.TeacherModelConfig_MaxResponseLengthForInference.Value;
            }
            if (requestCustomizationConfig_customizationConfig_DistillationConfig_customizationConfig_DistillationConfig_TeacherModelConfig_teacherModelConfig_MaxResponseLengthForInference != null)
            {
                requestCustomizationConfig_customizationConfig_DistillationConfig_customizationConfig_DistillationConfig_TeacherModelConfig.MaxResponseLengthForInference = requestCustomizationConfig_customizationConfig_DistillationConfig_customizationConfig_DistillationConfig_TeacherModelConfig_teacherModelConfig_MaxResponseLengthForInference.Value;
                requestCustomizationConfig_customizationConfig_DistillationConfig_customizationConfig_DistillationConfig_TeacherModelConfigIsNull = false;
            }
            System.String requestCustomizationConfig_customizationConfig_DistillationConfig_customizationConfig_DistillationConfig_TeacherModelConfig_teacherModelConfig_TeacherModelIdentifier = null;
            if (cmdletContext.TeacherModelConfig_TeacherModelIdentifier != null)
            {
                requestCustomizationConfig_customizationConfig_DistillationConfig_customizationConfig_DistillationConfig_TeacherModelConfig_teacherModelConfig_TeacherModelIdentifier = cmdletContext.TeacherModelConfig_TeacherModelIdentifier;
            }
            if (requestCustomizationConfig_customizationConfig_DistillationConfig_customizationConfig_DistillationConfig_TeacherModelConfig_teacherModelConfig_TeacherModelIdentifier != null)
            {
                requestCustomizationConfig_customizationConfig_DistillationConfig_customizationConfig_DistillationConfig_TeacherModelConfig.TeacherModelIdentifier = requestCustomizationConfig_customizationConfig_DistillationConfig_customizationConfig_DistillationConfig_TeacherModelConfig_teacherModelConfig_TeacherModelIdentifier;
                requestCustomizationConfig_customizationConfig_DistillationConfig_customizationConfig_DistillationConfig_TeacherModelConfigIsNull = false;
            }
             // determine if requestCustomizationConfig_customizationConfig_DistillationConfig_customizationConfig_DistillationConfig_TeacherModelConfig should be set to null
            if (requestCustomizationConfig_customizationConfig_DistillationConfig_customizationConfig_DistillationConfig_TeacherModelConfigIsNull)
            {
                requestCustomizationConfig_customizationConfig_DistillationConfig_customizationConfig_DistillationConfig_TeacherModelConfig = null;
            }
            if (requestCustomizationConfig_customizationConfig_DistillationConfig_customizationConfig_DistillationConfig_TeacherModelConfig != null)
            {
                requestCustomizationConfig_customizationConfig_DistillationConfig.TeacherModelConfig = requestCustomizationConfig_customizationConfig_DistillationConfig_customizationConfig_DistillationConfig_TeacherModelConfig;
                requestCustomizationConfig_customizationConfig_DistillationConfigIsNull = false;
            }
             // determine if requestCustomizationConfig_customizationConfig_DistillationConfig should be set to null
            if (requestCustomizationConfig_customizationConfig_DistillationConfigIsNull)
            {
                requestCustomizationConfig_customizationConfig_DistillationConfig = null;
            }
            if (requestCustomizationConfig_customizationConfig_DistillationConfig != null)
            {
                request.CustomizationConfig.DistillationConfig = requestCustomizationConfig_customizationConfig_DistillationConfig;
                requestCustomizationConfigIsNull = false;
            }
            Amazon.Bedrock.Model.RFTConfig requestCustomizationConfig_customizationConfig_RftConfig = null;
            
             // populate RftConfig
            var requestCustomizationConfig_customizationConfig_RftConfigIsNull = true;
            requestCustomizationConfig_customizationConfig_RftConfig = new Amazon.Bedrock.Model.RFTConfig();
            Amazon.Bedrock.Model.GraderConfig requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_GraderConfig = null;
            
             // populate GraderConfig
            var requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_GraderConfigIsNull = true;
            requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_GraderConfig = new Amazon.Bedrock.Model.GraderConfig();
            Amazon.Bedrock.Model.LambdaGraderConfig requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_GraderConfig_customizationConfig_RftConfig_GraderConfig_LambdaGrader = null;
            
             // populate LambdaGrader
            var requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_GraderConfig_customizationConfig_RftConfig_GraderConfig_LambdaGraderIsNull = true;
            requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_GraderConfig_customizationConfig_RftConfig_GraderConfig_LambdaGrader = new Amazon.Bedrock.Model.LambdaGraderConfig();
            System.String requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_GraderConfig_customizationConfig_RftConfig_GraderConfig_LambdaGrader_lambdaGrader_LambdaArn = null;
            if (cmdletContext.LambdaGrader_LambdaArn != null)
            {
                requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_GraderConfig_customizationConfig_RftConfig_GraderConfig_LambdaGrader_lambdaGrader_LambdaArn = cmdletContext.LambdaGrader_LambdaArn;
            }
            if (requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_GraderConfig_customizationConfig_RftConfig_GraderConfig_LambdaGrader_lambdaGrader_LambdaArn != null)
            {
                requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_GraderConfig_customizationConfig_RftConfig_GraderConfig_LambdaGrader.LambdaArn = requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_GraderConfig_customizationConfig_RftConfig_GraderConfig_LambdaGrader_lambdaGrader_LambdaArn;
                requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_GraderConfig_customizationConfig_RftConfig_GraderConfig_LambdaGraderIsNull = false;
            }
             // determine if requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_GraderConfig_customizationConfig_RftConfig_GraderConfig_LambdaGrader should be set to null
            if (requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_GraderConfig_customizationConfig_RftConfig_GraderConfig_LambdaGraderIsNull)
            {
                requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_GraderConfig_customizationConfig_RftConfig_GraderConfig_LambdaGrader = null;
            }
            if (requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_GraderConfig_customizationConfig_RftConfig_GraderConfig_LambdaGrader != null)
            {
                requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_GraderConfig.LambdaGrader = requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_GraderConfig_customizationConfig_RftConfig_GraderConfig_LambdaGrader;
                requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_GraderConfigIsNull = false;
            }
             // determine if requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_GraderConfig should be set to null
            if (requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_GraderConfigIsNull)
            {
                requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_GraderConfig = null;
            }
            if (requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_GraderConfig != null)
            {
                requestCustomizationConfig_customizationConfig_RftConfig.GraderConfig = requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_GraderConfig;
                requestCustomizationConfig_customizationConfig_RftConfigIsNull = false;
            }
            Amazon.Bedrock.Model.RFTHyperParameters requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters = null;
            
             // populate HyperParameters
            var requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParametersIsNull = true;
            requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters = new Amazon.Bedrock.Model.RFTHyperParameters();
            System.Int32? requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters_hyperParameters_BatchSize = null;
            if (cmdletContext.HyperParameters_BatchSize != null)
            {
                requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters_hyperParameters_BatchSize = cmdletContext.HyperParameters_BatchSize.Value;
            }
            if (requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters_hyperParameters_BatchSize != null)
            {
                requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters.BatchSize = requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters_hyperParameters_BatchSize.Value;
                requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParametersIsNull = false;
            }
            System.Int32? requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters_hyperParameters_EpochCount = null;
            if (cmdletContext.HyperParameters_EpochCount != null)
            {
                requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters_hyperParameters_EpochCount = cmdletContext.HyperParameters_EpochCount.Value;
            }
            if (requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters_hyperParameters_EpochCount != null)
            {
                requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters.EpochCount = requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters_hyperParameters_EpochCount.Value;
                requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParametersIsNull = false;
            }
            System.Int32? requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters_hyperParameters_EvalInterval = null;
            if (cmdletContext.HyperParameters_EvalInterval != null)
            {
                requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters_hyperParameters_EvalInterval = cmdletContext.HyperParameters_EvalInterval.Value;
            }
            if (requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters_hyperParameters_EvalInterval != null)
            {
                requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters.EvalInterval = requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters_hyperParameters_EvalInterval.Value;
                requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParametersIsNull = false;
            }
            System.Int32? requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters_hyperParameters_InferenceMaxToken = null;
            if (cmdletContext.HyperParameters_InferenceMaxToken != null)
            {
                requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters_hyperParameters_InferenceMaxToken = cmdletContext.HyperParameters_InferenceMaxToken.Value;
            }
            if (requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters_hyperParameters_InferenceMaxToken != null)
            {
                requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters.InferenceMaxTokens = requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters_hyperParameters_InferenceMaxToken.Value;
                requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParametersIsNull = false;
            }
            System.Single? requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters_hyperParameters_LearningRate = null;
            if (cmdletContext.HyperParameters_LearningRate != null)
            {
                requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters_hyperParameters_LearningRate = cmdletContext.HyperParameters_LearningRate.Value;
            }
            if (requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters_hyperParameters_LearningRate != null)
            {
                requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters.LearningRate = requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters_hyperParameters_LearningRate.Value;
                requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParametersIsNull = false;
            }
            System.Int32? requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters_hyperParameters_MaxPromptLength = null;
            if (cmdletContext.HyperParameters_MaxPromptLength != null)
            {
                requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters_hyperParameters_MaxPromptLength = cmdletContext.HyperParameters_MaxPromptLength.Value;
            }
            if (requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters_hyperParameters_MaxPromptLength != null)
            {
                requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters.MaxPromptLength = requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters_hyperParameters_MaxPromptLength.Value;
                requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParametersIsNull = false;
            }
            Amazon.Bedrock.ReasoningEffort requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters_hyperParameters_ReasoningEffort = null;
            if (cmdletContext.HyperParameters_ReasoningEffort != null)
            {
                requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters_hyperParameters_ReasoningEffort = cmdletContext.HyperParameters_ReasoningEffort;
            }
            if (requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters_hyperParameters_ReasoningEffort != null)
            {
                requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters.ReasoningEffort = requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters_hyperParameters_ReasoningEffort;
                requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParametersIsNull = false;
            }
            System.Int32? requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters_hyperParameters_TrainingSamplePerPrompt = null;
            if (cmdletContext.HyperParameters_TrainingSamplePerPrompt != null)
            {
                requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters_hyperParameters_TrainingSamplePerPrompt = cmdletContext.HyperParameters_TrainingSamplePerPrompt.Value;
            }
            if (requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters_hyperParameters_TrainingSamplePerPrompt != null)
            {
                requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters.TrainingSamplePerPrompt = requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters_hyperParameters_TrainingSamplePerPrompt.Value;
                requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParametersIsNull = false;
            }
             // determine if requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters should be set to null
            if (requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParametersIsNull)
            {
                requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters = null;
            }
            if (requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters != null)
            {
                requestCustomizationConfig_customizationConfig_RftConfig.HyperParameters = requestCustomizationConfig_customizationConfig_RftConfig_customizationConfig_RftConfig_HyperParameters;
                requestCustomizationConfig_customizationConfig_RftConfigIsNull = false;
            }
             // determine if requestCustomizationConfig_customizationConfig_RftConfig should be set to null
            if (requestCustomizationConfig_customizationConfig_RftConfigIsNull)
            {
                requestCustomizationConfig_customizationConfig_RftConfig = null;
            }
            if (requestCustomizationConfig_customizationConfig_RftConfig != null)
            {
                request.CustomizationConfig.RftConfig = requestCustomizationConfig_customizationConfig_RftConfig;
                requestCustomizationConfigIsNull = false;
            }
             // determine if request.CustomizationConfig should be set to null
            if (requestCustomizationConfigIsNull)
            {
                request.CustomizationConfig = null;
            }
            if (cmdletContext.CustomizationType != null)
            {
                request.CustomizationType = cmdletContext.CustomizationType;
            }
            if (cmdletContext.CustomModelKmsKeyId != null)
            {
                request.CustomModelKmsKeyId = cmdletContext.CustomModelKmsKeyId;
            }
            if (cmdletContext.CustomModelName != null)
            {
                request.CustomModelName = cmdletContext.CustomModelName;
            }
            if (cmdletContext.CustomModelTag != null)
            {
                request.CustomModelTags = cmdletContext.CustomModelTag;
            }
            if (cmdletContext.HyperParameter != null)
            {
                request.HyperParameters = cmdletContext.HyperParameter;
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
            request.OutputDataConfig = new Amazon.Bedrock.Model.OutputDataConfig();
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
            
             // populate TrainingDataConfig
            var requestTrainingDataConfigIsNull = true;
            request.TrainingDataConfig = new Amazon.Bedrock.Model.TrainingDataConfig();
            System.String requestTrainingDataConfig_trainingDataConfig_S3Uri = null;
            if (cmdletContext.TrainingDataConfig_S3Uri != null)
            {
                requestTrainingDataConfig_trainingDataConfig_S3Uri = cmdletContext.TrainingDataConfig_S3Uri;
            }
            if (requestTrainingDataConfig_trainingDataConfig_S3Uri != null)
            {
                request.TrainingDataConfig.S3Uri = requestTrainingDataConfig_trainingDataConfig_S3Uri;
                requestTrainingDataConfigIsNull = false;
            }
            Amazon.Bedrock.Model.InvocationLogsConfig requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig = null;
            
             // populate InvocationLogsConfig
            var requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfigIsNull = true;
            requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig = new Amazon.Bedrock.Model.InvocationLogsConfig();
            System.Boolean? requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_invocationLogsConfig_UsePromptResponse = null;
            if (cmdletContext.InvocationLogsConfig_UsePromptResponse != null)
            {
                requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_invocationLogsConfig_UsePromptResponse = cmdletContext.InvocationLogsConfig_UsePromptResponse.Value;
            }
            if (requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_invocationLogsConfig_UsePromptResponse != null)
            {
                requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig.UsePromptResponse = requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_invocationLogsConfig_UsePromptResponse.Value;
                requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfigIsNull = false;
            }
            Amazon.Bedrock.Model.InvocationLogSource requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_InvocationLogSource = null;
            
             // populate InvocationLogSource
            var requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_InvocationLogSourceIsNull = true;
            requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_InvocationLogSource = new Amazon.Bedrock.Model.InvocationLogSource();
            System.String requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_InvocationLogSource_invocationLogSource_S3Uri = null;
            if (cmdletContext.InvocationLogSource_S3Uri != null)
            {
                requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_InvocationLogSource_invocationLogSource_S3Uri = cmdletContext.InvocationLogSource_S3Uri;
            }
            if (requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_InvocationLogSource_invocationLogSource_S3Uri != null)
            {
                requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_InvocationLogSource.S3Uri = requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_InvocationLogSource_invocationLogSource_S3Uri;
                requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_InvocationLogSourceIsNull = false;
            }
             // determine if requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_InvocationLogSource should be set to null
            if (requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_InvocationLogSourceIsNull)
            {
                requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_InvocationLogSource = null;
            }
            if (requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_InvocationLogSource != null)
            {
                requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig.InvocationLogSource = requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_InvocationLogSource;
                requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfigIsNull = false;
            }
            Amazon.Bedrock.Model.RequestMetadataFilters requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_RequestMetadataFilters = null;
            
             // populate RequestMetadataFilters
            var requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_RequestMetadataFiltersIsNull = true;
            requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_RequestMetadataFilters = new Amazon.Bedrock.Model.RequestMetadataFilters();
            List<Amazon.Bedrock.Model.RequestMetadataBaseFilters> requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_RequestMetadataFilters_requestMetadataFilters_AndAll = null;
            if (cmdletContext.RequestMetadataFilters_AndAll != null)
            {
                requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_RequestMetadataFilters_requestMetadataFilters_AndAll = cmdletContext.RequestMetadataFilters_AndAll;
            }
            if (requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_RequestMetadataFilters_requestMetadataFilters_AndAll != null)
            {
                requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_RequestMetadataFilters.AndAll = requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_RequestMetadataFilters_requestMetadataFilters_AndAll;
                requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_RequestMetadataFiltersIsNull = false;
            }
            Dictionary<System.String, System.String> requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_RequestMetadataFilters_requestMetadataFilters_Equal = null;
            if (cmdletContext.RequestMetadataFilters_Equal != null)
            {
                requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_RequestMetadataFilters_requestMetadataFilters_Equal = cmdletContext.RequestMetadataFilters_Equal;
            }
            if (requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_RequestMetadataFilters_requestMetadataFilters_Equal != null)
            {
                requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_RequestMetadataFilters.Equals = requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_RequestMetadataFilters_requestMetadataFilters_Equal;
                requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_RequestMetadataFiltersIsNull = false;
            }
            Dictionary<System.String, System.String> requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_RequestMetadataFilters_requestMetadataFilters_NotEqual = null;
            if (cmdletContext.RequestMetadataFilters_NotEqual != null)
            {
                requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_RequestMetadataFilters_requestMetadataFilters_NotEqual = cmdletContext.RequestMetadataFilters_NotEqual;
            }
            if (requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_RequestMetadataFilters_requestMetadataFilters_NotEqual != null)
            {
                requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_RequestMetadataFilters.NotEquals = requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_RequestMetadataFilters_requestMetadataFilters_NotEqual;
                requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_RequestMetadataFiltersIsNull = false;
            }
            List<Amazon.Bedrock.Model.RequestMetadataBaseFilters> requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_RequestMetadataFilters_requestMetadataFilters_OrAll = null;
            if (cmdletContext.RequestMetadataFilters_OrAll != null)
            {
                requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_RequestMetadataFilters_requestMetadataFilters_OrAll = cmdletContext.RequestMetadataFilters_OrAll;
            }
            if (requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_RequestMetadataFilters_requestMetadataFilters_OrAll != null)
            {
                requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_RequestMetadataFilters.OrAll = requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_RequestMetadataFilters_requestMetadataFilters_OrAll;
                requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_RequestMetadataFiltersIsNull = false;
            }
             // determine if requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_RequestMetadataFilters should be set to null
            if (requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_RequestMetadataFiltersIsNull)
            {
                requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_RequestMetadataFilters = null;
            }
            if (requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_RequestMetadataFilters != null)
            {
                requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig.RequestMetadataFilters = requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig_trainingDataConfig_InvocationLogsConfig_RequestMetadataFilters;
                requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfigIsNull = false;
            }
             // determine if requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig should be set to null
            if (requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfigIsNull)
            {
                requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig = null;
            }
            if (requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig != null)
            {
                request.TrainingDataConfig.InvocationLogsConfig = requestTrainingDataConfig_trainingDataConfig_InvocationLogsConfig;
                requestTrainingDataConfigIsNull = false;
            }
             // determine if request.TrainingDataConfig should be set to null
            if (requestTrainingDataConfigIsNull)
            {
                request.TrainingDataConfig = null;
            }
            
             // populate ValidationDataConfig
            var requestValidationDataConfigIsNull = true;
            request.ValidationDataConfig = new Amazon.Bedrock.Model.ValidationDataConfig();
            List<Amazon.Bedrock.Model.Validator> requestValidationDataConfig_validationDataConfig_Validator = null;
            if (cmdletContext.ValidationDataConfig_Validator != null)
            {
                requestValidationDataConfig_validationDataConfig_Validator = cmdletContext.ValidationDataConfig_Validator;
            }
            if (requestValidationDataConfig_validationDataConfig_Validator != null)
            {
                request.ValidationDataConfig.Validators = requestValidationDataConfig_validationDataConfig_Validator;
                requestValidationDataConfigIsNull = false;
            }
             // determine if request.ValidationDataConfig should be set to null
            if (requestValidationDataConfigIsNull)
            {
                request.ValidationDataConfig = null;
            }
            
             // populate VpcConfig
            var requestVpcConfigIsNull = true;
            request.VpcConfig = new Amazon.Bedrock.Model.VpcConfig();
            List<System.String> requestVpcConfig_vpcConfig_SecurityGroupId = null;
            if (cmdletContext.VpcConfig_SecurityGroupId != null)
            {
                requestVpcConfig_vpcConfig_SecurityGroupId = cmdletContext.VpcConfig_SecurityGroupId;
            }
            if (requestVpcConfig_vpcConfig_SecurityGroupId != null)
            {
                request.VpcConfig.SecurityGroupIds = requestVpcConfig_vpcConfig_SecurityGroupId;
                requestVpcConfigIsNull = false;
            }
            List<System.String> requestVpcConfig_vpcConfig_SubnetId = null;
            if (cmdletContext.VpcConfig_SubnetId != null)
            {
                requestVpcConfig_vpcConfig_SubnetId = cmdletContext.VpcConfig_SubnetId;
            }
            if (requestVpcConfig_vpcConfig_SubnetId != null)
            {
                request.VpcConfig.SubnetIds = requestVpcConfig_vpcConfig_SubnetId;
                requestVpcConfigIsNull = false;
            }
             // determine if request.VpcConfig should be set to null
            if (requestVpcConfigIsNull)
            {
                request.VpcConfig = null;
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
        
        private Amazon.Bedrock.Model.CreateModelCustomizationJobResponse CallAWSServiceOperation(IAmazonBedrock client, Amazon.Bedrock.Model.CreateModelCustomizationJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock", "CreateModelCustomizationJob");
            try
            {
                #if DESKTOP
                return client.CreateModelCustomizationJob(request);
                #elif CORECLR
                return client.CreateModelCustomizationJobAsync(request).GetAwaiter().GetResult();
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
            public System.String BaseModelIdentifier { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.Int32? TeacherModelConfig_MaxResponseLengthForInference { get; set; }
            public System.String TeacherModelConfig_TeacherModelIdentifier { get; set; }
            public System.String LambdaGrader_LambdaArn { get; set; }
            public System.Int32? HyperParameters_BatchSize { get; set; }
            public System.Int32? HyperParameters_EpochCount { get; set; }
            public System.Int32? HyperParameters_EvalInterval { get; set; }
            public System.Int32? HyperParameters_InferenceMaxToken { get; set; }
            public System.Single? HyperParameters_LearningRate { get; set; }
            public System.Int32? HyperParameters_MaxPromptLength { get; set; }
            public Amazon.Bedrock.ReasoningEffort HyperParameters_ReasoningEffort { get; set; }
            public System.Int32? HyperParameters_TrainingSamplePerPrompt { get; set; }
            public Amazon.Bedrock.CustomizationType CustomizationType { get; set; }
            public System.String CustomModelKmsKeyId { get; set; }
            public System.String CustomModelName { get; set; }
            public List<Amazon.Bedrock.Model.Tag> CustomModelTag { get; set; }
            public Dictionary<System.String, System.String> HyperParameter { get; set; }
            public System.String JobName { get; set; }
            public List<Amazon.Bedrock.Model.Tag> JobTag { get; set; }
            public System.String OutputDataConfig_S3Uri { get; set; }
            public System.String RoleArn { get; set; }
            public System.String InvocationLogSource_S3Uri { get; set; }
            public List<Amazon.Bedrock.Model.RequestMetadataBaseFilters> RequestMetadataFilters_AndAll { get; set; }
            public Dictionary<System.String, System.String> RequestMetadataFilters_Equal { get; set; }
            public Dictionary<System.String, System.String> RequestMetadataFilters_NotEqual { get; set; }
            public List<Amazon.Bedrock.Model.RequestMetadataBaseFilters> RequestMetadataFilters_OrAll { get; set; }
            public System.Boolean? InvocationLogsConfig_UsePromptResponse { get; set; }
            public System.String TrainingDataConfig_S3Uri { get; set; }
            public List<Amazon.Bedrock.Model.Validator> ValidationDataConfig_Validator { get; set; }
            public List<System.String> VpcConfig_SecurityGroupId { get; set; }
            public List<System.String> VpcConfig_SubnetId { get; set; }
            public System.Func<Amazon.Bedrock.Model.CreateModelCustomizationJobResponse, NewBDRModelCustomizationJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobArn;
        }
        
    }
}
