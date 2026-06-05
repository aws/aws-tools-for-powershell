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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Creates a recommendation job that generates intelligent optimization recommendations
    /// for generative AI inference deployments. The job analyzes your model, workload configuration,
    /// and performance targets to recommend optimal instance types, model optimization techniques
    /// (such as quantization and speculative decoding), and deployment configurations.
    /// </summary>
    [Cmdlet("New", "SMAIRecommendationJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateAIRecommendationJob API operation.", Operation = new[] {"CreateAIRecommendationJob"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateAIRecommendationJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateAIRecommendationJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateAIRecommendationJobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSMAIRecommendationJobCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AIRecommendationJobName
        /// <summary>
        /// <para>
        /// <para>The name of the AI recommendation job. The name must be unique within your Amazon
        /// Web Services account in the current Amazon Web Services Region.</para>
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
        public System.String AIRecommendationJobName { get; set; }
        #endregion
        
        #region Parameter AIWorkloadConfigIdentifier
        /// <summary>
        /// <para>
        /// <para>The name or Amazon Resource Name (ARN) of the AI workload configuration to use for
        /// this recommendation job.</para>
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
        public System.String AIWorkloadConfigIdentifier { get; set; }
        #endregion
        
        #region Parameter ComputeSpec_CapacityReservationConfig_CapacityReservationPreference
        /// <summary>
        /// <para>
        /// <para>The capacity reservation preference. The only valid value is <c>capacity-reservations-only</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.AICapacityReservationPreference")]
        public Amazon.SageMaker.AICapacityReservationPreference ComputeSpec_CapacityReservationConfig_CapacityReservationPreference { get; set; }
        #endregion
        
        #region Parameter PerformanceTarget_Constraint
        /// <summary>
        /// <para>
        /// <para>An array of performance constraints that define the optimization objectives.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("PerformanceTarget_Constraints")]
        public Amazon.SageMaker.Model.AIRecommendationConstraint[] PerformanceTarget_Constraint { get; set; }
        #endregion
        
        #region Parameter InferenceSpecification_Framework
        /// <summary>
        /// <para>
        /// <para>The inference framework. Valid values are <c>LMI</c> and <c>VLLM</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.AIRecommendationInferenceFramework")]
        public Amazon.SageMaker.AIRecommendationInferenceFramework InferenceSpecification_Framework { get; set; }
        #endregion
        
        #region Parameter ComputeSpec_InstanceType
        /// <summary>
        /// <para>
        /// <para>The list of instance types to consider for recommendations. You can specify up to
        /// 3 instance types.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeSpec_InstanceTypes")]
        public System.String[] ComputeSpec_InstanceType { get; set; }
        #endregion
        
        #region Parameter OutputConfig_MlflowConfig_MlflowExperimentName
        /// <summary>
        /// <para>
        /// <para>The MLflow experiment name used for tracking.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputConfig_MlflowConfig_MlflowExperimentName { get; set; }
        #endregion
        
        #region Parameter OutputConfig_MlflowConfig_MlflowResourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the SageMaker managed MLflow resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputConfig_MlflowConfig_MlflowResourceArn { get; set; }
        #endregion
        
        #region Parameter OutputConfig_MlflowConfig_MlflowRunName
        /// <summary>
        /// <para>
        /// <para>The MLflow run name used for tracking.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputConfig_MlflowConfig_MlflowRunName { get; set; }
        #endregion
        
        #region Parameter ComputeSpec_CapacityReservationConfig_MlReservationArn
        /// <summary>
        /// <para>
        /// <para>The list of ML reservation ARNs to use.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeSpec_CapacityReservationConfig_MlReservationArns")]
        public System.String[] ComputeSpec_CapacityReservationConfig_MlReservationArn { get; set; }
        #endregion
        
        #region Parameter OutputConfig_ModelPackageGroupIdentifier
        /// <summary>
        /// <para>
        /// <para>The name or Amazon Resource Name (ARN) of the model package group where the optimized
        /// model is registered as a new model package version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputConfig_ModelPackageGroupIdentifier { get; set; }
        #endregion
        
        #region Parameter OptimizeModel
        /// <summary>
        /// <para>
        /// <para>Whether to allow model optimization techniques such as quantization, speculative decoding,
        /// and kernel tuning. The default is <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? OptimizeModel { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an IAM role that enables Amazon SageMaker AI to
        /// perform tasks on your behalf.</para>
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
        
        #region Parameter OutputConfig_S3OutputLocation
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 URI where recommendation results are stored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputConfig_S3OutputLocation { get; set; }
        #endregion
        
        #region Parameter ModelSource_S3_S3Uri
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 URI of the model artifacts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ModelSource_S3_S3Uri { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The metadata that you apply to Amazon Web Services resources to help you categorize
        /// and organize them.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AIRecommendationJobArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateAIRecommendationJobResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateAIRecommendationJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AIRecommendationJobArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AIRecommendationJobName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMAIRecommendationJob (CreateAIRecommendationJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateAIRecommendationJobResponse, NewSMAIRecommendationJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AIRecommendationJobName = this.AIRecommendationJobName;
            #if MODULAR
            if (this.AIRecommendationJobName == null && ParameterWasBound(nameof(this.AIRecommendationJobName)))
            {
                WriteWarning("You are passing $null as a value for parameter AIRecommendationJobName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AIWorkloadConfigIdentifier = this.AIWorkloadConfigIdentifier;
            #if MODULAR
            if (this.AIWorkloadConfigIdentifier == null && ParameterWasBound(nameof(this.AIWorkloadConfigIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter AIWorkloadConfigIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ComputeSpec_CapacityReservationConfig_CapacityReservationPreference = this.ComputeSpec_CapacityReservationConfig_CapacityReservationPreference;
            if (this.ComputeSpec_CapacityReservationConfig_MlReservationArn != null)
            {
                context.ComputeSpec_CapacityReservationConfig_MlReservationArn = new List<System.String>(this.ComputeSpec_CapacityReservationConfig_MlReservationArn);
            }
            if (this.ComputeSpec_InstanceType != null)
            {
                context.ComputeSpec_InstanceType = new List<System.String>(this.ComputeSpec_InstanceType);
            }
            context.InferenceSpecification_Framework = this.InferenceSpecification_Framework;
            context.ModelSource_S3_S3Uri = this.ModelSource_S3_S3Uri;
            context.OptimizeModel = this.OptimizeModel;
            context.OutputConfig_MlflowConfig_MlflowExperimentName = this.OutputConfig_MlflowConfig_MlflowExperimentName;
            context.OutputConfig_MlflowConfig_MlflowResourceArn = this.OutputConfig_MlflowConfig_MlflowResourceArn;
            context.OutputConfig_MlflowConfig_MlflowRunName = this.OutputConfig_MlflowConfig_MlflowRunName;
            context.OutputConfig_ModelPackageGroupIdentifier = this.OutputConfig_ModelPackageGroupIdentifier;
            context.OutputConfig_S3OutputLocation = this.OutputConfig_S3OutputLocation;
            if (this.PerformanceTarget_Constraint != null)
            {
                context.PerformanceTarget_Constraint = new List<Amazon.SageMaker.Model.AIRecommendationConstraint>(this.PerformanceTarget_Constraint);
            }
            #if MODULAR
            if (this.PerformanceTarget_Constraint == null && ParameterWasBound(nameof(this.PerformanceTarget_Constraint)))
            {
                WriteWarning("You are passing $null as a value for parameter PerformanceTarget_Constraint which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
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
            var request = new Amazon.SageMaker.Model.CreateAIRecommendationJobRequest();
            
            if (cmdletContext.AIRecommendationJobName != null)
            {
                request.AIRecommendationJobName = cmdletContext.AIRecommendationJobName;
            }
            if (cmdletContext.AIWorkloadConfigIdentifier != null)
            {
                request.AIWorkloadConfigIdentifier = cmdletContext.AIWorkloadConfigIdentifier;
            }
            
             // populate ComputeSpec
            var requestComputeSpecIsNull = true;
            request.ComputeSpec = new Amazon.SageMaker.Model.AIRecommendationComputeSpec();
            List<System.String> requestComputeSpec_computeSpec_InstanceType = null;
            if (cmdletContext.ComputeSpec_InstanceType != null)
            {
                requestComputeSpec_computeSpec_InstanceType = cmdletContext.ComputeSpec_InstanceType;
            }
            if (requestComputeSpec_computeSpec_InstanceType != null)
            {
                request.ComputeSpec.InstanceTypes = requestComputeSpec_computeSpec_InstanceType;
                requestComputeSpecIsNull = false;
            }
            Amazon.SageMaker.Model.AICapacityReservationConfig requestComputeSpec_computeSpec_CapacityReservationConfig = null;
            
             // populate CapacityReservationConfig
            var requestComputeSpec_computeSpec_CapacityReservationConfigIsNull = true;
            requestComputeSpec_computeSpec_CapacityReservationConfig = new Amazon.SageMaker.Model.AICapacityReservationConfig();
            Amazon.SageMaker.AICapacityReservationPreference requestComputeSpec_computeSpec_CapacityReservationConfig_computeSpec_CapacityReservationConfig_CapacityReservationPreference = null;
            if (cmdletContext.ComputeSpec_CapacityReservationConfig_CapacityReservationPreference != null)
            {
                requestComputeSpec_computeSpec_CapacityReservationConfig_computeSpec_CapacityReservationConfig_CapacityReservationPreference = cmdletContext.ComputeSpec_CapacityReservationConfig_CapacityReservationPreference;
            }
            if (requestComputeSpec_computeSpec_CapacityReservationConfig_computeSpec_CapacityReservationConfig_CapacityReservationPreference != null)
            {
                requestComputeSpec_computeSpec_CapacityReservationConfig.CapacityReservationPreference = requestComputeSpec_computeSpec_CapacityReservationConfig_computeSpec_CapacityReservationConfig_CapacityReservationPreference;
                requestComputeSpec_computeSpec_CapacityReservationConfigIsNull = false;
            }
            List<System.String> requestComputeSpec_computeSpec_CapacityReservationConfig_computeSpec_CapacityReservationConfig_MlReservationArn = null;
            if (cmdletContext.ComputeSpec_CapacityReservationConfig_MlReservationArn != null)
            {
                requestComputeSpec_computeSpec_CapacityReservationConfig_computeSpec_CapacityReservationConfig_MlReservationArn = cmdletContext.ComputeSpec_CapacityReservationConfig_MlReservationArn;
            }
            if (requestComputeSpec_computeSpec_CapacityReservationConfig_computeSpec_CapacityReservationConfig_MlReservationArn != null)
            {
                requestComputeSpec_computeSpec_CapacityReservationConfig.MlReservationArns = requestComputeSpec_computeSpec_CapacityReservationConfig_computeSpec_CapacityReservationConfig_MlReservationArn;
                requestComputeSpec_computeSpec_CapacityReservationConfigIsNull = false;
            }
             // determine if requestComputeSpec_computeSpec_CapacityReservationConfig should be set to null
            if (requestComputeSpec_computeSpec_CapacityReservationConfigIsNull)
            {
                requestComputeSpec_computeSpec_CapacityReservationConfig = null;
            }
            if (requestComputeSpec_computeSpec_CapacityReservationConfig != null)
            {
                request.ComputeSpec.CapacityReservationConfig = requestComputeSpec_computeSpec_CapacityReservationConfig;
                requestComputeSpecIsNull = false;
            }
             // determine if request.ComputeSpec should be set to null
            if (requestComputeSpecIsNull)
            {
                request.ComputeSpec = null;
            }
            
             // populate InferenceSpecification
            var requestInferenceSpecificationIsNull = true;
            request.InferenceSpecification = new Amazon.SageMaker.Model.AIRecommendationInferenceSpecification();
            Amazon.SageMaker.AIRecommendationInferenceFramework requestInferenceSpecification_inferenceSpecification_Framework = null;
            if (cmdletContext.InferenceSpecification_Framework != null)
            {
                requestInferenceSpecification_inferenceSpecification_Framework = cmdletContext.InferenceSpecification_Framework;
            }
            if (requestInferenceSpecification_inferenceSpecification_Framework != null)
            {
                request.InferenceSpecification.Framework = requestInferenceSpecification_inferenceSpecification_Framework;
                requestInferenceSpecificationIsNull = false;
            }
             // determine if request.InferenceSpecification should be set to null
            if (requestInferenceSpecificationIsNull)
            {
                request.InferenceSpecification = null;
            }
            
             // populate ModelSource
            var requestModelSourceIsNull = true;
            request.ModelSource = new Amazon.SageMaker.Model.AIModelSource();
            Amazon.SageMaker.Model.AIModelSourceS3 requestModelSource_modelSource_S3 = null;
            
             // populate S3
            var requestModelSource_modelSource_S3IsNull = true;
            requestModelSource_modelSource_S3 = new Amazon.SageMaker.Model.AIModelSourceS3();
            System.String requestModelSource_modelSource_S3_modelSource_S3_S3Uri = null;
            if (cmdletContext.ModelSource_S3_S3Uri != null)
            {
                requestModelSource_modelSource_S3_modelSource_S3_S3Uri = cmdletContext.ModelSource_S3_S3Uri;
            }
            if (requestModelSource_modelSource_S3_modelSource_S3_S3Uri != null)
            {
                requestModelSource_modelSource_S3.S3Uri = requestModelSource_modelSource_S3_modelSource_S3_S3Uri;
                requestModelSource_modelSource_S3IsNull = false;
            }
             // determine if requestModelSource_modelSource_S3 should be set to null
            if (requestModelSource_modelSource_S3IsNull)
            {
                requestModelSource_modelSource_S3 = null;
            }
            if (requestModelSource_modelSource_S3 != null)
            {
                request.ModelSource.S3 = requestModelSource_modelSource_S3;
                requestModelSourceIsNull = false;
            }
             // determine if request.ModelSource should be set to null
            if (requestModelSourceIsNull)
            {
                request.ModelSource = null;
            }
            if (cmdletContext.OptimizeModel != null)
            {
                request.OptimizeModel = cmdletContext.OptimizeModel.Value;
            }
            
             // populate OutputConfig
            var requestOutputConfigIsNull = true;
            request.OutputConfig = new Amazon.SageMaker.Model.AIRecommendationOutputConfig();
            System.String requestOutputConfig_outputConfig_ModelPackageGroupIdentifier = null;
            if (cmdletContext.OutputConfig_ModelPackageGroupIdentifier != null)
            {
                requestOutputConfig_outputConfig_ModelPackageGroupIdentifier = cmdletContext.OutputConfig_ModelPackageGroupIdentifier;
            }
            if (requestOutputConfig_outputConfig_ModelPackageGroupIdentifier != null)
            {
                request.OutputConfig.ModelPackageGroupIdentifier = requestOutputConfig_outputConfig_ModelPackageGroupIdentifier;
                requestOutputConfigIsNull = false;
            }
            System.String requestOutputConfig_outputConfig_S3OutputLocation = null;
            if (cmdletContext.OutputConfig_S3OutputLocation != null)
            {
                requestOutputConfig_outputConfig_S3OutputLocation = cmdletContext.OutputConfig_S3OutputLocation;
            }
            if (requestOutputConfig_outputConfig_S3OutputLocation != null)
            {
                request.OutputConfig.S3OutputLocation = requestOutputConfig_outputConfig_S3OutputLocation;
                requestOutputConfigIsNull = false;
            }
            Amazon.SageMaker.Model.AIMlflowConfig requestOutputConfig_outputConfig_MlflowConfig = null;
            
             // populate MlflowConfig
            var requestOutputConfig_outputConfig_MlflowConfigIsNull = true;
            requestOutputConfig_outputConfig_MlflowConfig = new Amazon.SageMaker.Model.AIMlflowConfig();
            System.String requestOutputConfig_outputConfig_MlflowConfig_outputConfig_MlflowConfig_MlflowExperimentName = null;
            if (cmdletContext.OutputConfig_MlflowConfig_MlflowExperimentName != null)
            {
                requestOutputConfig_outputConfig_MlflowConfig_outputConfig_MlflowConfig_MlflowExperimentName = cmdletContext.OutputConfig_MlflowConfig_MlflowExperimentName;
            }
            if (requestOutputConfig_outputConfig_MlflowConfig_outputConfig_MlflowConfig_MlflowExperimentName != null)
            {
                requestOutputConfig_outputConfig_MlflowConfig.MlflowExperimentName = requestOutputConfig_outputConfig_MlflowConfig_outputConfig_MlflowConfig_MlflowExperimentName;
                requestOutputConfig_outputConfig_MlflowConfigIsNull = false;
            }
            System.String requestOutputConfig_outputConfig_MlflowConfig_outputConfig_MlflowConfig_MlflowResourceArn = null;
            if (cmdletContext.OutputConfig_MlflowConfig_MlflowResourceArn != null)
            {
                requestOutputConfig_outputConfig_MlflowConfig_outputConfig_MlflowConfig_MlflowResourceArn = cmdletContext.OutputConfig_MlflowConfig_MlflowResourceArn;
            }
            if (requestOutputConfig_outputConfig_MlflowConfig_outputConfig_MlflowConfig_MlflowResourceArn != null)
            {
                requestOutputConfig_outputConfig_MlflowConfig.MlflowResourceArn = requestOutputConfig_outputConfig_MlflowConfig_outputConfig_MlflowConfig_MlflowResourceArn;
                requestOutputConfig_outputConfig_MlflowConfigIsNull = false;
            }
            System.String requestOutputConfig_outputConfig_MlflowConfig_outputConfig_MlflowConfig_MlflowRunName = null;
            if (cmdletContext.OutputConfig_MlflowConfig_MlflowRunName != null)
            {
                requestOutputConfig_outputConfig_MlflowConfig_outputConfig_MlflowConfig_MlflowRunName = cmdletContext.OutputConfig_MlflowConfig_MlflowRunName;
            }
            if (requestOutputConfig_outputConfig_MlflowConfig_outputConfig_MlflowConfig_MlflowRunName != null)
            {
                requestOutputConfig_outputConfig_MlflowConfig.MlflowRunName = requestOutputConfig_outputConfig_MlflowConfig_outputConfig_MlflowConfig_MlflowRunName;
                requestOutputConfig_outputConfig_MlflowConfigIsNull = false;
            }
             // determine if requestOutputConfig_outputConfig_MlflowConfig should be set to null
            if (requestOutputConfig_outputConfig_MlflowConfigIsNull)
            {
                requestOutputConfig_outputConfig_MlflowConfig = null;
            }
            if (requestOutputConfig_outputConfig_MlflowConfig != null)
            {
                request.OutputConfig.MlflowConfig = requestOutputConfig_outputConfig_MlflowConfig;
                requestOutputConfigIsNull = false;
            }
             // determine if request.OutputConfig should be set to null
            if (requestOutputConfigIsNull)
            {
                request.OutputConfig = null;
            }
            
             // populate PerformanceTarget
            var requestPerformanceTargetIsNull = true;
            request.PerformanceTarget = new Amazon.SageMaker.Model.AIRecommendationPerformanceTarget();
            List<Amazon.SageMaker.Model.AIRecommendationConstraint> requestPerformanceTarget_performanceTarget_Constraint = null;
            if (cmdletContext.PerformanceTarget_Constraint != null)
            {
                requestPerformanceTarget_performanceTarget_Constraint = cmdletContext.PerformanceTarget_Constraint;
            }
            if (requestPerformanceTarget_performanceTarget_Constraint != null)
            {
                request.PerformanceTarget.Constraints = requestPerformanceTarget_performanceTarget_Constraint;
                requestPerformanceTargetIsNull = false;
            }
             // determine if request.PerformanceTarget should be set to null
            if (requestPerformanceTargetIsNull)
            {
                request.PerformanceTarget = null;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
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
        
        private Amazon.SageMaker.Model.CreateAIRecommendationJobResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateAIRecommendationJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateAIRecommendationJob");
            try
            {
                return client.CreateAIRecommendationJobAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AIRecommendationJobName { get; set; }
            public System.String AIWorkloadConfigIdentifier { get; set; }
            public Amazon.SageMaker.AICapacityReservationPreference ComputeSpec_CapacityReservationConfig_CapacityReservationPreference { get; set; }
            public List<System.String> ComputeSpec_CapacityReservationConfig_MlReservationArn { get; set; }
            public List<System.String> ComputeSpec_InstanceType { get; set; }
            public Amazon.SageMaker.AIRecommendationInferenceFramework InferenceSpecification_Framework { get; set; }
            public System.String ModelSource_S3_S3Uri { get; set; }
            public System.Boolean? OptimizeModel { get; set; }
            public System.String OutputConfig_MlflowConfig_MlflowExperimentName { get; set; }
            public System.String OutputConfig_MlflowConfig_MlflowResourceArn { get; set; }
            public System.String OutputConfig_MlflowConfig_MlflowRunName { get; set; }
            public System.String OutputConfig_ModelPackageGroupIdentifier { get; set; }
            public System.String OutputConfig_S3OutputLocation { get; set; }
            public List<Amazon.SageMaker.Model.AIRecommendationConstraint> PerformanceTarget_Constraint { get; set; }
            public System.String RoleArn { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateAIRecommendationJobResponse, NewSMAIRecommendationJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AIRecommendationJobArn;
        }
        
    }
}
