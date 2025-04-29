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
    /// Create a machine learning algorithm that you can use in SageMaker and list in the
    /// Amazon Web Services Marketplace.
    /// </summary>
    [Cmdlet("New", "SMAlgorithm", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateAlgorithm API operation.", Operation = new[] {"CreateAlgorithm"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateAlgorithmResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateAlgorithmResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateAlgorithmResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSMAlgorithmCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AlgorithmDescription
        /// <summary>
        /// <para>
        /// <para>A description of the algorithm.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AlgorithmDescription { get; set; }
        #endregion
        
        #region Parameter AlgorithmName
        /// <summary>
        /// <para>
        /// <para>The name of the algorithm.</para>
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
        public System.String AlgorithmName { get; set; }
        #endregion
        
        #region Parameter CertifyForMarketplace
        /// <summary>
        /// <para>
        /// <para>Whether to certify the algorithm so that it can be listed in Amazon Web Services Marketplace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CertifyForMarketplace { get; set; }
        #endregion
        
        #region Parameter AdditionalS3DataSource_CompressionType
        /// <summary>
        /// <para>
        /// <para>The type of compression used for an additional data source used in inference or training.
        /// Specify <c>None</c> if your additional data source is not compressed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingSpecification_AdditionalS3DataSource_CompressionType")]
        [AWSConstantClassSource("Amazon.SageMaker.CompressionType")]
        public Amazon.SageMaker.CompressionType AdditionalS3DataSource_CompressionType { get; set; }
        #endregion
        
        #region Parameter InferenceSpecification_Container
        /// <summary>
        /// <para>
        /// <para>The Amazon ECR registry path of the Docker image that contains the inference code.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InferenceSpecification_Containers")]
        public Amazon.SageMaker.Model.ModelPackageContainerDefinition[] InferenceSpecification_Container { get; set; }
        #endregion
        
        #region Parameter AdditionalS3DataSource_ETag
        /// <summary>
        /// <para>
        /// <para>The ETag associated with S3 URI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingSpecification_AdditionalS3DataSource_ETag")]
        public System.String AdditionalS3DataSource_ETag { get; set; }
        #endregion
        
        #region Parameter TrainingSpecification_MetricDefinition
        /// <summary>
        /// <para>
        /// <para>A list of <c>MetricDefinition</c> objects, which are used for parsing metrics generated
        /// by the algorithm.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingSpecification_MetricDefinitions")]
        public Amazon.SageMaker.Model.MetricDefinition[] TrainingSpecification_MetricDefinition { get; set; }
        #endregion
        
        #region Parameter AdditionalS3DataSource_S3DataType
        /// <summary>
        /// <para>
        /// <para>The data type of the additional data source that you specify for use in inference
        /// or training. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingSpecification_AdditionalS3DataSource_S3DataType")]
        [AWSConstantClassSource("Amazon.SageMaker.AdditionalS3DataSourceDataType")]
        public Amazon.SageMaker.AdditionalS3DataSourceDataType AdditionalS3DataSource_S3DataType { get; set; }
        #endregion
        
        #region Parameter AdditionalS3DataSource_S3Uri
        /// <summary>
        /// <para>
        /// <para>The uniform resource identifier (URI) used to identify an additional data source used
        /// in inference or training.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingSpecification_AdditionalS3DataSource_S3Uri")]
        public System.String AdditionalS3DataSource_S3Uri { get; set; }
        #endregion
        
        #region Parameter InferenceSpecification_SupportedContentType
        /// <summary>
        /// <para>
        /// <para>The supported MIME types for the input data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InferenceSpecification_SupportedContentTypes")]
        public System.String[] InferenceSpecification_SupportedContentType { get; set; }
        #endregion
        
        #region Parameter TrainingSpecification_SupportedHyperParameter
        /// <summary>
        /// <para>
        /// <para>A list of the <c>HyperParameterSpecification</c> objects, that define the supported
        /// hyperparameters. This is required if the algorithm supports automatic model tuning.&gt;</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingSpecification_SupportedHyperParameters")]
        public Amazon.SageMaker.Model.HyperParameterSpecification[] TrainingSpecification_SupportedHyperParameter { get; set; }
        #endregion
        
        #region Parameter InferenceSpecification_SupportedRealtimeInferenceInstanceType
        /// <summary>
        /// <para>
        /// <para>A list of the instance types that are used to generate inferences in real-time.</para><para>This parameter is required for unversioned models, and optional for versioned models.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InferenceSpecification_SupportedRealtimeInferenceInstanceTypes")]
        public System.String[] InferenceSpecification_SupportedRealtimeInferenceInstanceType { get; set; }
        #endregion
        
        #region Parameter InferenceSpecification_SupportedResponseMIMEType
        /// <summary>
        /// <para>
        /// <para>The supported MIME types for the output data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InferenceSpecification_SupportedResponseMIMETypes")]
        public System.String[] InferenceSpecification_SupportedResponseMIMEType { get; set; }
        #endregion
        
        #region Parameter TrainingSpecification_SupportedTrainingInstanceType
        /// <summary>
        /// <para>
        /// <para>A list of the instance types that this algorithm can use for training.</para>
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
        [Alias("TrainingSpecification_SupportedTrainingInstanceTypes")]
        public System.String[] TrainingSpecification_SupportedTrainingInstanceType { get; set; }
        #endregion
        
        #region Parameter InferenceSpecification_SupportedTransformInstanceType
        /// <summary>
        /// <para>
        /// <para>A list of the instance types on which a transformation job can be run or on which
        /// an endpoint can be deployed.</para><para>This parameter is required for unversioned models, and optional for versioned models.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InferenceSpecification_SupportedTransformInstanceTypes")]
        public System.String[] InferenceSpecification_SupportedTransformInstanceType { get; set; }
        #endregion
        
        #region Parameter TrainingSpecification_SupportedTuningJobObjectiveMetric
        /// <summary>
        /// <para>
        /// <para>A list of the metrics that the algorithm emits that can be used as the objective metric
        /// in a hyperparameter tuning job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingSpecification_SupportedTuningJobObjectiveMetrics")]
        public Amazon.SageMaker.Model.HyperParameterTuningJobObjective[] TrainingSpecification_SupportedTuningJobObjectiveMetric { get; set; }
        #endregion
        
        #region Parameter TrainingSpecification_SupportsDistributedTraining
        /// <summary>
        /// <para>
        /// <para>Indicates whether the algorithm supports distributed training. If set to false, buyers
        /// can't request more than one instance during training.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? TrainingSpecification_SupportsDistributedTraining { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of key-value pairs. You can use tags to categorize your Amazon Web Services
        /// resources in different ways, for example, by purpose, owner, or environment. For more
        /// information, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">Tagging
        /// Amazon Web Services Resources</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TrainingSpecification_TrainingChannel
        /// <summary>
        /// <para>
        /// <para>A list of <c>ChannelSpecification</c> objects, which specify the input sources to
        /// be used by the algorithm.</para>
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
        [Alias("TrainingSpecification_TrainingChannels")]
        public Amazon.SageMaker.Model.ChannelSpecification[] TrainingSpecification_TrainingChannel { get; set; }
        #endregion
        
        #region Parameter TrainingSpecification_TrainingImage
        /// <summary>
        /// <para>
        /// <para>The Amazon ECR registry path of the Docker image that contains the training algorithm.</para>
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
        public System.String TrainingSpecification_TrainingImage { get; set; }
        #endregion
        
        #region Parameter TrainingSpecification_TrainingImageDigest
        /// <summary>
        /// <para>
        /// <para>An MD5 hash of the training algorithm that identifies the Docker image used for training.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TrainingSpecification_TrainingImageDigest { get; set; }
        #endregion
        
        #region Parameter ValidationSpecification_ValidationProfile
        /// <summary>
        /// <para>
        /// <para>An array of <c>AlgorithmValidationProfile</c> objects, each of which specifies a training
        /// job and batch transform job that SageMaker runs to validate your algorithm.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValidationSpecification_ValidationProfiles")]
        public Amazon.SageMaker.Model.AlgorithmValidationProfile[] ValidationSpecification_ValidationProfile { get; set; }
        #endregion
        
        #region Parameter ValidationSpecification_ValidationRole
        /// <summary>
        /// <para>
        /// <para>The IAM roles that SageMaker uses to run the training jobs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ValidationSpecification_ValidationRole { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AlgorithmArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateAlgorithmResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateAlgorithmResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AlgorithmArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AlgorithmName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMAlgorithm (CreateAlgorithm)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateAlgorithmResponse, NewSMAlgorithmCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AlgorithmDescription = this.AlgorithmDescription;
            context.AlgorithmName = this.AlgorithmName;
            #if MODULAR
            if (this.AlgorithmName == null && ParameterWasBound(nameof(this.AlgorithmName)))
            {
                WriteWarning("You are passing $null as a value for parameter AlgorithmName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CertifyForMarketplace = this.CertifyForMarketplace;
            if (this.InferenceSpecification_Container != null)
            {
                context.InferenceSpecification_Container = new List<Amazon.SageMaker.Model.ModelPackageContainerDefinition>(this.InferenceSpecification_Container);
            }
            if (this.InferenceSpecification_SupportedContentType != null)
            {
                context.InferenceSpecification_SupportedContentType = new List<System.String>(this.InferenceSpecification_SupportedContentType);
            }
            if (this.InferenceSpecification_SupportedRealtimeInferenceInstanceType != null)
            {
                context.InferenceSpecification_SupportedRealtimeInferenceInstanceType = new List<System.String>(this.InferenceSpecification_SupportedRealtimeInferenceInstanceType);
            }
            if (this.InferenceSpecification_SupportedResponseMIMEType != null)
            {
                context.InferenceSpecification_SupportedResponseMIMEType = new List<System.String>(this.InferenceSpecification_SupportedResponseMIMEType);
            }
            if (this.InferenceSpecification_SupportedTransformInstanceType != null)
            {
                context.InferenceSpecification_SupportedTransformInstanceType = new List<System.String>(this.InferenceSpecification_SupportedTransformInstanceType);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
            }
            context.AdditionalS3DataSource_CompressionType = this.AdditionalS3DataSource_CompressionType;
            context.AdditionalS3DataSource_ETag = this.AdditionalS3DataSource_ETag;
            context.AdditionalS3DataSource_S3DataType = this.AdditionalS3DataSource_S3DataType;
            context.AdditionalS3DataSource_S3Uri = this.AdditionalS3DataSource_S3Uri;
            if (this.TrainingSpecification_MetricDefinition != null)
            {
                context.TrainingSpecification_MetricDefinition = new List<Amazon.SageMaker.Model.MetricDefinition>(this.TrainingSpecification_MetricDefinition);
            }
            if (this.TrainingSpecification_SupportedHyperParameter != null)
            {
                context.TrainingSpecification_SupportedHyperParameter = new List<Amazon.SageMaker.Model.HyperParameterSpecification>(this.TrainingSpecification_SupportedHyperParameter);
            }
            if (this.TrainingSpecification_SupportedTrainingInstanceType != null)
            {
                context.TrainingSpecification_SupportedTrainingInstanceType = new List<System.String>(this.TrainingSpecification_SupportedTrainingInstanceType);
            }
            #if MODULAR
            if (this.TrainingSpecification_SupportedTrainingInstanceType == null && ParameterWasBound(nameof(this.TrainingSpecification_SupportedTrainingInstanceType)))
            {
                WriteWarning("You are passing $null as a value for parameter TrainingSpecification_SupportedTrainingInstanceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TrainingSpecification_SupportedTuningJobObjectiveMetric != null)
            {
                context.TrainingSpecification_SupportedTuningJobObjectiveMetric = new List<Amazon.SageMaker.Model.HyperParameterTuningJobObjective>(this.TrainingSpecification_SupportedTuningJobObjectiveMetric);
            }
            context.TrainingSpecification_SupportsDistributedTraining = this.TrainingSpecification_SupportsDistributedTraining;
            if (this.TrainingSpecification_TrainingChannel != null)
            {
                context.TrainingSpecification_TrainingChannel = new List<Amazon.SageMaker.Model.ChannelSpecification>(this.TrainingSpecification_TrainingChannel);
            }
            #if MODULAR
            if (this.TrainingSpecification_TrainingChannel == null && ParameterWasBound(nameof(this.TrainingSpecification_TrainingChannel)))
            {
                WriteWarning("You are passing $null as a value for parameter TrainingSpecification_TrainingChannel which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TrainingSpecification_TrainingImage = this.TrainingSpecification_TrainingImage;
            #if MODULAR
            if (this.TrainingSpecification_TrainingImage == null && ParameterWasBound(nameof(this.TrainingSpecification_TrainingImage)))
            {
                WriteWarning("You are passing $null as a value for parameter TrainingSpecification_TrainingImage which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TrainingSpecification_TrainingImageDigest = this.TrainingSpecification_TrainingImageDigest;
            if (this.ValidationSpecification_ValidationProfile != null)
            {
                context.ValidationSpecification_ValidationProfile = new List<Amazon.SageMaker.Model.AlgorithmValidationProfile>(this.ValidationSpecification_ValidationProfile);
            }
            context.ValidationSpecification_ValidationRole = this.ValidationSpecification_ValidationRole;
            
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
            var request = new Amazon.SageMaker.Model.CreateAlgorithmRequest();
            
            if (cmdletContext.AlgorithmDescription != null)
            {
                request.AlgorithmDescription = cmdletContext.AlgorithmDescription;
            }
            if (cmdletContext.AlgorithmName != null)
            {
                request.AlgorithmName = cmdletContext.AlgorithmName;
            }
            if (cmdletContext.CertifyForMarketplace != null)
            {
                request.CertifyForMarketplace = cmdletContext.CertifyForMarketplace.Value;
            }
            
             // populate InferenceSpecification
            var requestInferenceSpecificationIsNull = true;
            request.InferenceSpecification = new Amazon.SageMaker.Model.InferenceSpecification();
            List<Amazon.SageMaker.Model.ModelPackageContainerDefinition> requestInferenceSpecification_inferenceSpecification_Container = null;
            if (cmdletContext.InferenceSpecification_Container != null)
            {
                requestInferenceSpecification_inferenceSpecification_Container = cmdletContext.InferenceSpecification_Container;
            }
            if (requestInferenceSpecification_inferenceSpecification_Container != null)
            {
                request.InferenceSpecification.Containers = requestInferenceSpecification_inferenceSpecification_Container;
                requestInferenceSpecificationIsNull = false;
            }
            List<System.String> requestInferenceSpecification_inferenceSpecification_SupportedContentType = null;
            if (cmdletContext.InferenceSpecification_SupportedContentType != null)
            {
                requestInferenceSpecification_inferenceSpecification_SupportedContentType = cmdletContext.InferenceSpecification_SupportedContentType;
            }
            if (requestInferenceSpecification_inferenceSpecification_SupportedContentType != null)
            {
                request.InferenceSpecification.SupportedContentTypes = requestInferenceSpecification_inferenceSpecification_SupportedContentType;
                requestInferenceSpecificationIsNull = false;
            }
            List<System.String> requestInferenceSpecification_inferenceSpecification_SupportedRealtimeInferenceInstanceType = null;
            if (cmdletContext.InferenceSpecification_SupportedRealtimeInferenceInstanceType != null)
            {
                requestInferenceSpecification_inferenceSpecification_SupportedRealtimeInferenceInstanceType = cmdletContext.InferenceSpecification_SupportedRealtimeInferenceInstanceType;
            }
            if (requestInferenceSpecification_inferenceSpecification_SupportedRealtimeInferenceInstanceType != null)
            {
                request.InferenceSpecification.SupportedRealtimeInferenceInstanceTypes = requestInferenceSpecification_inferenceSpecification_SupportedRealtimeInferenceInstanceType;
                requestInferenceSpecificationIsNull = false;
            }
            List<System.String> requestInferenceSpecification_inferenceSpecification_SupportedResponseMIMEType = null;
            if (cmdletContext.InferenceSpecification_SupportedResponseMIMEType != null)
            {
                requestInferenceSpecification_inferenceSpecification_SupportedResponseMIMEType = cmdletContext.InferenceSpecification_SupportedResponseMIMEType;
            }
            if (requestInferenceSpecification_inferenceSpecification_SupportedResponseMIMEType != null)
            {
                request.InferenceSpecification.SupportedResponseMIMETypes = requestInferenceSpecification_inferenceSpecification_SupportedResponseMIMEType;
                requestInferenceSpecificationIsNull = false;
            }
            List<System.String> requestInferenceSpecification_inferenceSpecification_SupportedTransformInstanceType = null;
            if (cmdletContext.InferenceSpecification_SupportedTransformInstanceType != null)
            {
                requestInferenceSpecification_inferenceSpecification_SupportedTransformInstanceType = cmdletContext.InferenceSpecification_SupportedTransformInstanceType;
            }
            if (requestInferenceSpecification_inferenceSpecification_SupportedTransformInstanceType != null)
            {
                request.InferenceSpecification.SupportedTransformInstanceTypes = requestInferenceSpecification_inferenceSpecification_SupportedTransformInstanceType;
                requestInferenceSpecificationIsNull = false;
            }
             // determine if request.InferenceSpecification should be set to null
            if (requestInferenceSpecificationIsNull)
            {
                request.InferenceSpecification = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate TrainingSpecification
            var requestTrainingSpecificationIsNull = true;
            request.TrainingSpecification = new Amazon.SageMaker.Model.TrainingSpecification();
            List<Amazon.SageMaker.Model.MetricDefinition> requestTrainingSpecification_trainingSpecification_MetricDefinition = null;
            if (cmdletContext.TrainingSpecification_MetricDefinition != null)
            {
                requestTrainingSpecification_trainingSpecification_MetricDefinition = cmdletContext.TrainingSpecification_MetricDefinition;
            }
            if (requestTrainingSpecification_trainingSpecification_MetricDefinition != null)
            {
                request.TrainingSpecification.MetricDefinitions = requestTrainingSpecification_trainingSpecification_MetricDefinition;
                requestTrainingSpecificationIsNull = false;
            }
            List<Amazon.SageMaker.Model.HyperParameterSpecification> requestTrainingSpecification_trainingSpecification_SupportedHyperParameter = null;
            if (cmdletContext.TrainingSpecification_SupportedHyperParameter != null)
            {
                requestTrainingSpecification_trainingSpecification_SupportedHyperParameter = cmdletContext.TrainingSpecification_SupportedHyperParameter;
            }
            if (requestTrainingSpecification_trainingSpecification_SupportedHyperParameter != null)
            {
                request.TrainingSpecification.SupportedHyperParameters = requestTrainingSpecification_trainingSpecification_SupportedHyperParameter;
                requestTrainingSpecificationIsNull = false;
            }
            List<System.String> requestTrainingSpecification_trainingSpecification_SupportedTrainingInstanceType = null;
            if (cmdletContext.TrainingSpecification_SupportedTrainingInstanceType != null)
            {
                requestTrainingSpecification_trainingSpecification_SupportedTrainingInstanceType = cmdletContext.TrainingSpecification_SupportedTrainingInstanceType;
            }
            if (requestTrainingSpecification_trainingSpecification_SupportedTrainingInstanceType != null)
            {
                request.TrainingSpecification.SupportedTrainingInstanceTypes = requestTrainingSpecification_trainingSpecification_SupportedTrainingInstanceType;
                requestTrainingSpecificationIsNull = false;
            }
            List<Amazon.SageMaker.Model.HyperParameterTuningJobObjective> requestTrainingSpecification_trainingSpecification_SupportedTuningJobObjectiveMetric = null;
            if (cmdletContext.TrainingSpecification_SupportedTuningJobObjectiveMetric != null)
            {
                requestTrainingSpecification_trainingSpecification_SupportedTuningJobObjectiveMetric = cmdletContext.TrainingSpecification_SupportedTuningJobObjectiveMetric;
            }
            if (requestTrainingSpecification_trainingSpecification_SupportedTuningJobObjectiveMetric != null)
            {
                request.TrainingSpecification.SupportedTuningJobObjectiveMetrics = requestTrainingSpecification_trainingSpecification_SupportedTuningJobObjectiveMetric;
                requestTrainingSpecificationIsNull = false;
            }
            System.Boolean? requestTrainingSpecification_trainingSpecification_SupportsDistributedTraining = null;
            if (cmdletContext.TrainingSpecification_SupportsDistributedTraining != null)
            {
                requestTrainingSpecification_trainingSpecification_SupportsDistributedTraining = cmdletContext.TrainingSpecification_SupportsDistributedTraining.Value;
            }
            if (requestTrainingSpecification_trainingSpecification_SupportsDistributedTraining != null)
            {
                request.TrainingSpecification.SupportsDistributedTraining = requestTrainingSpecification_trainingSpecification_SupportsDistributedTraining.Value;
                requestTrainingSpecificationIsNull = false;
            }
            List<Amazon.SageMaker.Model.ChannelSpecification> requestTrainingSpecification_trainingSpecification_TrainingChannel = null;
            if (cmdletContext.TrainingSpecification_TrainingChannel != null)
            {
                requestTrainingSpecification_trainingSpecification_TrainingChannel = cmdletContext.TrainingSpecification_TrainingChannel;
            }
            if (requestTrainingSpecification_trainingSpecification_TrainingChannel != null)
            {
                request.TrainingSpecification.TrainingChannels = requestTrainingSpecification_trainingSpecification_TrainingChannel;
                requestTrainingSpecificationIsNull = false;
            }
            System.String requestTrainingSpecification_trainingSpecification_TrainingImage = null;
            if (cmdletContext.TrainingSpecification_TrainingImage != null)
            {
                requestTrainingSpecification_trainingSpecification_TrainingImage = cmdletContext.TrainingSpecification_TrainingImage;
            }
            if (requestTrainingSpecification_trainingSpecification_TrainingImage != null)
            {
                request.TrainingSpecification.TrainingImage = requestTrainingSpecification_trainingSpecification_TrainingImage;
                requestTrainingSpecificationIsNull = false;
            }
            System.String requestTrainingSpecification_trainingSpecification_TrainingImageDigest = null;
            if (cmdletContext.TrainingSpecification_TrainingImageDigest != null)
            {
                requestTrainingSpecification_trainingSpecification_TrainingImageDigest = cmdletContext.TrainingSpecification_TrainingImageDigest;
            }
            if (requestTrainingSpecification_trainingSpecification_TrainingImageDigest != null)
            {
                request.TrainingSpecification.TrainingImageDigest = requestTrainingSpecification_trainingSpecification_TrainingImageDigest;
                requestTrainingSpecificationIsNull = false;
            }
            Amazon.SageMaker.Model.AdditionalS3DataSource requestTrainingSpecification_trainingSpecification_AdditionalS3DataSource = null;
            
             // populate AdditionalS3DataSource
            var requestTrainingSpecification_trainingSpecification_AdditionalS3DataSourceIsNull = true;
            requestTrainingSpecification_trainingSpecification_AdditionalS3DataSource = new Amazon.SageMaker.Model.AdditionalS3DataSource();
            Amazon.SageMaker.CompressionType requestTrainingSpecification_trainingSpecification_AdditionalS3DataSource_additionalS3DataSource_CompressionType = null;
            if (cmdletContext.AdditionalS3DataSource_CompressionType != null)
            {
                requestTrainingSpecification_trainingSpecification_AdditionalS3DataSource_additionalS3DataSource_CompressionType = cmdletContext.AdditionalS3DataSource_CompressionType;
            }
            if (requestTrainingSpecification_trainingSpecification_AdditionalS3DataSource_additionalS3DataSource_CompressionType != null)
            {
                requestTrainingSpecification_trainingSpecification_AdditionalS3DataSource.CompressionType = requestTrainingSpecification_trainingSpecification_AdditionalS3DataSource_additionalS3DataSource_CompressionType;
                requestTrainingSpecification_trainingSpecification_AdditionalS3DataSourceIsNull = false;
            }
            System.String requestTrainingSpecification_trainingSpecification_AdditionalS3DataSource_additionalS3DataSource_ETag = null;
            if (cmdletContext.AdditionalS3DataSource_ETag != null)
            {
                requestTrainingSpecification_trainingSpecification_AdditionalS3DataSource_additionalS3DataSource_ETag = cmdletContext.AdditionalS3DataSource_ETag;
            }
            if (requestTrainingSpecification_trainingSpecification_AdditionalS3DataSource_additionalS3DataSource_ETag != null)
            {
                requestTrainingSpecification_trainingSpecification_AdditionalS3DataSource.ETag = requestTrainingSpecification_trainingSpecification_AdditionalS3DataSource_additionalS3DataSource_ETag;
                requestTrainingSpecification_trainingSpecification_AdditionalS3DataSourceIsNull = false;
            }
            Amazon.SageMaker.AdditionalS3DataSourceDataType requestTrainingSpecification_trainingSpecification_AdditionalS3DataSource_additionalS3DataSource_S3DataType = null;
            if (cmdletContext.AdditionalS3DataSource_S3DataType != null)
            {
                requestTrainingSpecification_trainingSpecification_AdditionalS3DataSource_additionalS3DataSource_S3DataType = cmdletContext.AdditionalS3DataSource_S3DataType;
            }
            if (requestTrainingSpecification_trainingSpecification_AdditionalS3DataSource_additionalS3DataSource_S3DataType != null)
            {
                requestTrainingSpecification_trainingSpecification_AdditionalS3DataSource.S3DataType = requestTrainingSpecification_trainingSpecification_AdditionalS3DataSource_additionalS3DataSource_S3DataType;
                requestTrainingSpecification_trainingSpecification_AdditionalS3DataSourceIsNull = false;
            }
            System.String requestTrainingSpecification_trainingSpecification_AdditionalS3DataSource_additionalS3DataSource_S3Uri = null;
            if (cmdletContext.AdditionalS3DataSource_S3Uri != null)
            {
                requestTrainingSpecification_trainingSpecification_AdditionalS3DataSource_additionalS3DataSource_S3Uri = cmdletContext.AdditionalS3DataSource_S3Uri;
            }
            if (requestTrainingSpecification_trainingSpecification_AdditionalS3DataSource_additionalS3DataSource_S3Uri != null)
            {
                requestTrainingSpecification_trainingSpecification_AdditionalS3DataSource.S3Uri = requestTrainingSpecification_trainingSpecification_AdditionalS3DataSource_additionalS3DataSource_S3Uri;
                requestTrainingSpecification_trainingSpecification_AdditionalS3DataSourceIsNull = false;
            }
             // determine if requestTrainingSpecification_trainingSpecification_AdditionalS3DataSource should be set to null
            if (requestTrainingSpecification_trainingSpecification_AdditionalS3DataSourceIsNull)
            {
                requestTrainingSpecification_trainingSpecification_AdditionalS3DataSource = null;
            }
            if (requestTrainingSpecification_trainingSpecification_AdditionalS3DataSource != null)
            {
                request.TrainingSpecification.AdditionalS3DataSource = requestTrainingSpecification_trainingSpecification_AdditionalS3DataSource;
                requestTrainingSpecificationIsNull = false;
            }
             // determine if request.TrainingSpecification should be set to null
            if (requestTrainingSpecificationIsNull)
            {
                request.TrainingSpecification = null;
            }
            
             // populate ValidationSpecification
            var requestValidationSpecificationIsNull = true;
            request.ValidationSpecification = new Amazon.SageMaker.Model.AlgorithmValidationSpecification();
            List<Amazon.SageMaker.Model.AlgorithmValidationProfile> requestValidationSpecification_validationSpecification_ValidationProfile = null;
            if (cmdletContext.ValidationSpecification_ValidationProfile != null)
            {
                requestValidationSpecification_validationSpecification_ValidationProfile = cmdletContext.ValidationSpecification_ValidationProfile;
            }
            if (requestValidationSpecification_validationSpecification_ValidationProfile != null)
            {
                request.ValidationSpecification.ValidationProfiles = requestValidationSpecification_validationSpecification_ValidationProfile;
                requestValidationSpecificationIsNull = false;
            }
            System.String requestValidationSpecification_validationSpecification_ValidationRole = null;
            if (cmdletContext.ValidationSpecification_ValidationRole != null)
            {
                requestValidationSpecification_validationSpecification_ValidationRole = cmdletContext.ValidationSpecification_ValidationRole;
            }
            if (requestValidationSpecification_validationSpecification_ValidationRole != null)
            {
                request.ValidationSpecification.ValidationRole = requestValidationSpecification_validationSpecification_ValidationRole;
                requestValidationSpecificationIsNull = false;
            }
             // determine if request.ValidationSpecification should be set to null
            if (requestValidationSpecificationIsNull)
            {
                request.ValidationSpecification = null;
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
        
        private Amazon.SageMaker.Model.CreateAlgorithmResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateAlgorithmRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateAlgorithm");
            try
            {
                return client.CreateAlgorithmAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AlgorithmDescription { get; set; }
            public System.String AlgorithmName { get; set; }
            public System.Boolean? CertifyForMarketplace { get; set; }
            public List<Amazon.SageMaker.Model.ModelPackageContainerDefinition> InferenceSpecification_Container { get; set; }
            public List<System.String> InferenceSpecification_SupportedContentType { get; set; }
            public List<System.String> InferenceSpecification_SupportedRealtimeInferenceInstanceType { get; set; }
            public List<System.String> InferenceSpecification_SupportedResponseMIMEType { get; set; }
            public List<System.String> InferenceSpecification_SupportedTransformInstanceType { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public Amazon.SageMaker.CompressionType AdditionalS3DataSource_CompressionType { get; set; }
            public System.String AdditionalS3DataSource_ETag { get; set; }
            public Amazon.SageMaker.AdditionalS3DataSourceDataType AdditionalS3DataSource_S3DataType { get; set; }
            public System.String AdditionalS3DataSource_S3Uri { get; set; }
            public List<Amazon.SageMaker.Model.MetricDefinition> TrainingSpecification_MetricDefinition { get; set; }
            public List<Amazon.SageMaker.Model.HyperParameterSpecification> TrainingSpecification_SupportedHyperParameter { get; set; }
            public List<System.String> TrainingSpecification_SupportedTrainingInstanceType { get; set; }
            public List<Amazon.SageMaker.Model.HyperParameterTuningJobObjective> TrainingSpecification_SupportedTuningJobObjectiveMetric { get; set; }
            public System.Boolean? TrainingSpecification_SupportsDistributedTraining { get; set; }
            public List<Amazon.SageMaker.Model.ChannelSpecification> TrainingSpecification_TrainingChannel { get; set; }
            public System.String TrainingSpecification_TrainingImage { get; set; }
            public System.String TrainingSpecification_TrainingImageDigest { get; set; }
            public List<Amazon.SageMaker.Model.AlgorithmValidationProfile> ValidationSpecification_ValidationProfile { get; set; }
            public System.String ValidationSpecification_ValidationRole { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateAlgorithmResponse, NewSMAlgorithmCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AlgorithmArn;
        }
        
    }
}
