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
    /// Starts a recommendation job. You can create either an instance recommendation or load
    /// test job.
    /// </summary>
    [Cmdlet("New", "SMInferenceRecommendationsJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateInferenceRecommendationsJob API operation.", Operation = new[] {"CreateInferenceRecommendationsJob"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateInferenceRecommendationsJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateInferenceRecommendationsJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateInferenceRecommendationsJobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSMInferenceRecommendationsJobCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ContainerConfig_DataInputConfig
        /// <summary>
        /// <para>
        /// <para>Specifies the name and shape of the expected data inputs for your trained model with
        /// a JSON dictionary form. This field is used for optimizing your model using SageMaker
        /// Neo. For more information, see <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_InputConfig.html#sagemaker-Type-InputConfig-DataInputConfig">DataInputConfig</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfig_ContainerConfig_DataInputConfig")]
        public System.String ContainerConfig_DataInputConfig { get; set; }
        #endregion
        
        #region Parameter ContainerConfig_Domain
        /// <summary>
        /// <para>
        /// <para>The machine learning domain of the model and its components.</para><para>Valid Values: <c>COMPUTER_VISION | NATURAL_LANGUAGE_PROCESSING | MACHINE_LEARNING</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfig_ContainerConfig_Domain")]
        public System.String ContainerConfig_Domain { get; set; }
        #endregion
        
        #region Parameter Stairs_DurationInSecond
        /// <summary>
        /// <para>
        /// <para>Defines how long each traffic step should be.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfig_TrafficPattern_Stairs_DurationInSeconds")]
        public System.Int32? Stairs_DurationInSecond { get; set; }
        #endregion
        
        #region Parameter InputConfig_EndpointConfiguration
        /// <summary>
        /// <para>
        /// <para>Specifies the endpoint configuration to use for a job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfig_EndpointConfigurations")]
        public Amazon.SageMaker.Model.EndpointInputConfiguration[] InputConfig_EndpointConfiguration { get; set; }
        #endregion
        
        #region Parameter InputConfig_Endpoint
        /// <summary>
        /// <para>
        /// <para>Existing customer endpoints on which to run an Inference Recommender job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfig_Endpoints")]
        public Amazon.SageMaker.Model.EndpointInfo[] InputConfig_Endpoint { get; set; }
        #endregion
        
        #region Parameter StoppingConditions_FlatInvocation
        /// <summary>
        /// <para>
        /// <para>Stops a load test when the number of invocations (TPS) peaks and flattens, which means
        /// that the instance has reached capacity. The default value is <c>Stop</c>. If you want
        /// the load test to continue after invocations have flattened, set the value to <c>Continue</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StoppingConditions_FlatInvocations")]
        [AWSConstantClassSource("Amazon.SageMaker.FlatInvocations")]
        public Amazon.SageMaker.FlatInvocations StoppingConditions_FlatInvocation { get; set; }
        #endregion
        
        #region Parameter ContainerConfig_Framework
        /// <summary>
        /// <para>
        /// <para>The machine learning framework of the container image.</para><para>Valid Values: <c>TENSORFLOW | PYTORCH | XGBOOST | SAGEMAKER-SCIKIT-LEARN</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfig_ContainerConfig_Framework")]
        public System.String ContainerConfig_Framework { get; set; }
        #endregion
        
        #region Parameter ContainerConfig_FrameworkVersion
        /// <summary>
        /// <para>
        /// <para>The framework version of the container image.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfig_ContainerConfig_FrameworkVersion")]
        public System.String ContainerConfig_FrameworkVersion { get; set; }
        #endregion
        
        #region Parameter JobDescription
        /// <summary>
        /// <para>
        /// <para>Description of the recommendation job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String JobDescription { get; set; }
        #endregion
        
        #region Parameter InputConfig_JobDurationInSecond
        /// <summary>
        /// <para>
        /// <para>Specifies the maximum duration of the job, in seconds. The maximum value is 18,000
        /// seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfig_JobDurationInSeconds")]
        public System.Int32? InputConfig_JobDurationInSecond { get; set; }
        #endregion
        
        #region Parameter JobName
        /// <summary>
        /// <para>
        /// <para>A name for the recommendation job. The name must be unique within the Amazon Web Services
        /// Region and within your Amazon Web Services account. The job name is passed down to
        /// the resources created by the recommendation job. The names of resources (such as the
        /// model, endpoint configuration, endpoint, and compilation) that are prefixed with the
        /// job name are truncated at 40 characters.</para>
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
        public System.String JobName { get; set; }
        #endregion
        
        #region Parameter JobType
        /// <summary>
        /// <para>
        /// <para>Defines the type of recommendation job. Specify <c>Default</c> to initiate an instance
        /// recommendation and <c>Advanced</c> to initiate a load test. If left unspecified, Amazon
        /// SageMaker Inference Recommender will run an instance recommendation (<c>DEFAULT</c>)
        /// job.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SageMaker.RecommendationJobType")]
        public Amazon.SageMaker.RecommendationJobType JobType { get; set; }
        #endregion
        
        #region Parameter OutputConfig_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a Amazon Web Services Key Management Service (Amazon
        /// Web Services KMS) key that Amazon SageMaker uses to encrypt your output artifacts
        /// with Amazon S3 server-side encryption. The SageMaker execution role must have <c>kms:GenerateDataKey</c>
        /// permission.</para><para>The <c>KmsKeyId</c> can be any of the following formats:</para><ul><li><para>// KMS Key ID</para><para><c>"1234abcd-12ab-34cd-56ef-1234567890ab"</c></para></li><li><para>// Amazon Resource Name (ARN) of a KMS Key</para><para><c>"arn:aws:kms:&lt;region&gt;:&lt;account&gt;:key/&lt;key-id-12ab-34cd-56ef-1234567890ab&gt;"</c></para></li><li><para>// KMS Key Alias</para><para><c>"alias/ExampleAlias"</c></para></li><li><para>// Amazon Resource Name (ARN) of a KMS Key Alias</para><para><c>"arn:aws:kms:&lt;region&gt;:&lt;account&gt;:alias/&lt;ExampleAlias&gt;"</c></para></li></ul><para>For more information about key identifiers, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#key-id-key-id">Key
        /// identifiers (KeyID)</a> in the Amazon Web Services Key Management Service (Amazon
        /// Web Services KMS) documentation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputConfig_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter StoppingConditions_MaxInvocation
        /// <summary>
        /// <para>
        /// <para>The maximum number of requests per minute expected for the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StoppingConditions_MaxInvocations")]
        public System.Int32? StoppingConditions_MaxInvocation { get; set; }
        #endregion
        
        #region Parameter ResourceLimit_MaxNumberOfTest
        /// <summary>
        /// <para>
        /// <para>Defines the maximum number of load tests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfig_ResourceLimit_MaxNumberOfTests")]
        public System.Int32? ResourceLimit_MaxNumberOfTest { get; set; }
        #endregion
        
        #region Parameter ResourceLimit_MaxParallelOfTest
        /// <summary>
        /// <para>
        /// <para>Defines the maximum number of parallel load tests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfig_ResourceLimit_MaxParallelOfTests")]
        public System.Int32? ResourceLimit_MaxParallelOfTest { get; set; }
        #endregion
        
        #region Parameter StoppingConditions_ModelLatencyThreshold
        /// <summary>
        /// <para>
        /// <para>The interval of time taken by a model to respond as viewed from SageMaker. The interval
        /// includes the local communication time taken to send the request and to fetch the response
        /// from the container of a model and the time taken to complete the inference in the
        /// container.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StoppingConditions_ModelLatencyThresholds")]
        public Amazon.SageMaker.Model.ModelLatencyThreshold[] StoppingConditions_ModelLatencyThreshold { get; set; }
        #endregion
        
        #region Parameter InputConfig_ModelName
        /// <summary>
        /// <para>
        /// <para>The name of the created model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InputConfig_ModelName { get; set; }
        #endregion
        
        #region Parameter InputConfig_ModelPackageVersionArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a versioned model package.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InputConfig_ModelPackageVersionArn { get; set; }
        #endregion
        
        #region Parameter ContainerConfig_NearestModelName
        /// <summary>
        /// <para>
        /// <para>The name of a pre-trained machine learning model benchmarked by Amazon SageMaker Inference
        /// Recommender that matches your model.</para><para>Valid Values: <c>efficientnetb7 | unet | xgboost | faster-rcnn-resnet101 | nasnetlarge
        /// | vgg16 | inception-v3 | mask-rcnn | sagemaker-scikit-learn | densenet201-gluon |
        /// resnet18v2-gluon | xception | densenet201 | yolov4 | resnet152 | bert-base-cased |
        /// xceptionV1-keras | resnet50 | retinanet</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfig_ContainerConfig_NearestModelName")]
        public System.String ContainerConfig_NearestModelName { get; set; }
        #endregion
        
        #region Parameter Stairs_NumberOfStep
        /// <summary>
        /// <para>
        /// <para>Specifies how many steps to perform during traffic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfig_TrafficPattern_Stairs_NumberOfSteps")]
        public System.Int32? Stairs_NumberOfStep { get; set; }
        #endregion
        
        #region Parameter TrafficPattern_Phase
        /// <summary>
        /// <para>
        /// <para>Defines the phases traffic specification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfig_TrafficPattern_Phases")]
        public Amazon.SageMaker.Model.Phase[] TrafficPattern_Phase { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an IAM role that enables Amazon SageMaker to perform
        /// tasks on your behalf.</para>
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
        
        #region Parameter CompiledOutputConfig_S3OutputUri
        /// <summary>
        /// <para>
        /// <para>Identifies the Amazon S3 bucket where you want SageMaker to store the compiled model
        /// artifacts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputConfig_CompiledOutputConfig_S3OutputUri")]
        public System.String CompiledOutputConfig_S3OutputUri { get; set; }
        #endregion
        
        #region Parameter PayloadConfig_SamplePayloadUrl
        /// <summary>
        /// <para>
        /// <para>The Amazon Simple Storage Service (Amazon S3) path where the sample payload is stored.
        /// This path must point to a single gzip compressed tar archive (.tar.gz suffix).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfig_ContainerConfig_PayloadConfig_SamplePayloadUrl")]
        public System.String PayloadConfig_SamplePayloadUrl { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The VPC security group IDs. IDs have the form of <c>sg-xxxxxxxx</c>. Specify the security
        /// groups for the VPC that is specified in the <c>Subnets</c> field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfig_VpcConfig_SecurityGroupIds")]
        public System.String[] VpcConfig_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter VpcConfig_Subnet
        /// <summary>
        /// <para>
        /// <para>The ID of the subnets in the VPC to which you want to connect your model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfig_VpcConfig_Subnets")]
        public System.String[] VpcConfig_Subnet { get; set; }
        #endregion
        
        #region Parameter PayloadConfig_SupportedContentType
        /// <summary>
        /// <para>
        /// <para>The supported MIME types for the input data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfig_ContainerConfig_PayloadConfig_SupportedContentTypes")]
        public System.String[] PayloadConfig_SupportedContentType { get; set; }
        #endregion
        
        #region Parameter ContainerConfig_SupportedEndpointType
        /// <summary>
        /// <para>
        /// <para>The endpoint type to receive recommendations for. By default this is null, and the
        /// results of the inference recommendation job return a combined list of both real-time
        /// and serverless benchmarks. By specifying a value for this field, you can receive a
        /// longer list of benchmarks for the desired endpoint type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfig_ContainerConfig_SupportedEndpointType")]
        [AWSConstantClassSource("Amazon.SageMaker.RecommendationJobSupportedEndpointType")]
        public Amazon.SageMaker.RecommendationJobSupportedEndpointType ContainerConfig_SupportedEndpointType { get; set; }
        #endregion
        
        #region Parameter ContainerConfig_SupportedInstanceType
        /// <summary>
        /// <para>
        /// <para>A list of the instance types that are used to generate inferences in real-time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfig_ContainerConfig_SupportedInstanceTypes")]
        public System.String[] ContainerConfig_SupportedInstanceType { get; set; }
        #endregion
        
        #region Parameter ContainerConfig_SupportedResponseMIMEType
        /// <summary>
        /// <para>
        /// <para>The supported MIME types for the output data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfig_ContainerConfig_SupportedResponseMIMETypes")]
        public System.String[] ContainerConfig_SupportedResponseMIMEType { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The metadata that you apply to Amazon Web Services resources to help you categorize
        /// and organize them. Each tag consists of a key and a value, both of which you define.
        /// For more information, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">Tagging
        /// Amazon Web Services Resources</a> in the Amazon Web Services General Reference.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ContainerConfig_Task
        /// <summary>
        /// <para>
        /// <para>The machine learning task that the model accomplishes.</para><para>Valid Values: <c>IMAGE_CLASSIFICATION | OBJECT_DETECTION | TEXT_GENERATION | IMAGE_SEGMENTATION
        /// | FILL_MASK | CLASSIFICATION | REGRESSION | OTHER</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfig_ContainerConfig_Task")]
        public System.String ContainerConfig_Task { get; set; }
        #endregion
        
        #region Parameter TrafficPattern_TrafficType
        /// <summary>
        /// <para>
        /// <para>Defines the traffic patterns. Choose either <c>PHASES</c> or <c>STAIRS</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfig_TrafficPattern_TrafficType")]
        [AWSConstantClassSource("Amazon.SageMaker.TrafficType")]
        public Amazon.SageMaker.TrafficType TrafficPattern_TrafficType { get; set; }
        #endregion
        
        #region Parameter Stairs_UsersPerStep
        /// <summary>
        /// <para>
        /// <para>Specifies how many new users to spawn in each step.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfig_TrafficPattern_Stairs_UsersPerStep")]
        public System.Int32? Stairs_UsersPerStep { get; set; }
        #endregion
        
        #region Parameter InputConfig_VolumeKmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a Amazon Web Services Key Management Service (Amazon
        /// Web Services KMS) key that Amazon SageMaker uses to encrypt data on the storage volume
        /// attached to the ML compute instance that hosts the endpoint. This key will be passed
        /// to SageMaker Hosting for endpoint creation. </para><para>The SageMaker execution role must have <c>kms:CreateGrant</c> permission in order
        /// to encrypt data on the storage volume of the endpoints created for inference recommendation.
        /// The inference recommendation job will fail asynchronously during endpoint configuration
        /// creation if the role passed does not have <c>kms:CreateGrant</c> permission.</para><para>The <c>KmsKeyId</c> can be any of the following formats:</para><ul><li><para>// KMS Key ID</para><para><c>"1234abcd-12ab-34cd-56ef-1234567890ab"</c></para></li><li><para>// Amazon Resource Name (ARN) of a KMS Key</para><para><c>"arn:aws:kms:&lt;region&gt;:&lt;account&gt;:key/&lt;key-id-12ab-34cd-56ef-1234567890ab&gt;"</c></para></li><li><para>// KMS Key Alias</para><para><c>"alias/ExampleAlias"</c></para></li><li><para>// Amazon Resource Name (ARN) of a KMS Key Alias</para><para><c>"arn:aws:kms:&lt;region&gt;:&lt;account&gt;:alias/&lt;ExampleAlias&gt;"</c></para></li></ul><para>For more information about key identifiers, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#key-id-key-id">Key
        /// identifiers (KeyID)</a> in the Amazon Web Services Key Management Service (Amazon
        /// Web Services KMS) documentation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InputConfig_VolumeKmsKeyId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'JobArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateInferenceRecommendationsJobResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateInferenceRecommendationsJobResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMInferenceRecommendationsJob (CreateInferenceRecommendationsJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateInferenceRecommendationsJobResponse, NewSMInferenceRecommendationsJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ContainerConfig_DataInputConfig = this.ContainerConfig_DataInputConfig;
            context.ContainerConfig_Domain = this.ContainerConfig_Domain;
            context.ContainerConfig_Framework = this.ContainerConfig_Framework;
            context.ContainerConfig_FrameworkVersion = this.ContainerConfig_FrameworkVersion;
            context.ContainerConfig_NearestModelName = this.ContainerConfig_NearestModelName;
            context.PayloadConfig_SamplePayloadUrl = this.PayloadConfig_SamplePayloadUrl;
            if (this.PayloadConfig_SupportedContentType != null)
            {
                context.PayloadConfig_SupportedContentType = new List<System.String>(this.PayloadConfig_SupportedContentType);
            }
            context.ContainerConfig_SupportedEndpointType = this.ContainerConfig_SupportedEndpointType;
            if (this.ContainerConfig_SupportedInstanceType != null)
            {
                context.ContainerConfig_SupportedInstanceType = new List<System.String>(this.ContainerConfig_SupportedInstanceType);
            }
            if (this.ContainerConfig_SupportedResponseMIMEType != null)
            {
                context.ContainerConfig_SupportedResponseMIMEType = new List<System.String>(this.ContainerConfig_SupportedResponseMIMEType);
            }
            context.ContainerConfig_Task = this.ContainerConfig_Task;
            if (this.InputConfig_EndpointConfiguration != null)
            {
                context.InputConfig_EndpointConfiguration = new List<Amazon.SageMaker.Model.EndpointInputConfiguration>(this.InputConfig_EndpointConfiguration);
            }
            if (this.InputConfig_Endpoint != null)
            {
                context.InputConfig_Endpoint = new List<Amazon.SageMaker.Model.EndpointInfo>(this.InputConfig_Endpoint);
            }
            context.InputConfig_JobDurationInSecond = this.InputConfig_JobDurationInSecond;
            context.InputConfig_ModelName = this.InputConfig_ModelName;
            context.InputConfig_ModelPackageVersionArn = this.InputConfig_ModelPackageVersionArn;
            context.ResourceLimit_MaxNumberOfTest = this.ResourceLimit_MaxNumberOfTest;
            context.ResourceLimit_MaxParallelOfTest = this.ResourceLimit_MaxParallelOfTest;
            if (this.TrafficPattern_Phase != null)
            {
                context.TrafficPattern_Phase = new List<Amazon.SageMaker.Model.Phase>(this.TrafficPattern_Phase);
            }
            context.Stairs_DurationInSecond = this.Stairs_DurationInSecond;
            context.Stairs_NumberOfStep = this.Stairs_NumberOfStep;
            context.Stairs_UsersPerStep = this.Stairs_UsersPerStep;
            context.TrafficPattern_TrafficType = this.TrafficPattern_TrafficType;
            context.InputConfig_VolumeKmsKeyId = this.InputConfig_VolumeKmsKeyId;
            if (this.VpcConfig_SecurityGroupId != null)
            {
                context.VpcConfig_SecurityGroupId = new List<System.String>(this.VpcConfig_SecurityGroupId);
            }
            if (this.VpcConfig_Subnet != null)
            {
                context.VpcConfig_Subnet = new List<System.String>(this.VpcConfig_Subnet);
            }
            context.JobDescription = this.JobDescription;
            context.JobName = this.JobName;
            #if MODULAR
            if (this.JobName == null && ParameterWasBound(nameof(this.JobName)))
            {
                WriteWarning("You are passing $null as a value for parameter JobName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.JobType = this.JobType;
            #if MODULAR
            if (this.JobType == null && ParameterWasBound(nameof(this.JobType)))
            {
                WriteWarning("You are passing $null as a value for parameter JobType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CompiledOutputConfig_S3OutputUri = this.CompiledOutputConfig_S3OutputUri;
            context.OutputConfig_KmsKeyId = this.OutputConfig_KmsKeyId;
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StoppingConditions_FlatInvocation = this.StoppingConditions_FlatInvocation;
            context.StoppingConditions_MaxInvocation = this.StoppingConditions_MaxInvocation;
            if (this.StoppingConditions_ModelLatencyThreshold != null)
            {
                context.StoppingConditions_ModelLatencyThreshold = new List<Amazon.SageMaker.Model.ModelLatencyThreshold>(this.StoppingConditions_ModelLatencyThreshold);
            }
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
            var request = new Amazon.SageMaker.Model.CreateInferenceRecommendationsJobRequest();
            
            
             // populate InputConfig
            var requestInputConfigIsNull = true;
            request.InputConfig = new Amazon.SageMaker.Model.RecommendationJobInputConfig();
            List<Amazon.SageMaker.Model.EndpointInputConfiguration> requestInputConfig_inputConfig_EndpointConfiguration = null;
            if (cmdletContext.InputConfig_EndpointConfiguration != null)
            {
                requestInputConfig_inputConfig_EndpointConfiguration = cmdletContext.InputConfig_EndpointConfiguration;
            }
            if (requestInputConfig_inputConfig_EndpointConfiguration != null)
            {
                request.InputConfig.EndpointConfigurations = requestInputConfig_inputConfig_EndpointConfiguration;
                requestInputConfigIsNull = false;
            }
            List<Amazon.SageMaker.Model.EndpointInfo> requestInputConfig_inputConfig_Endpoint = null;
            if (cmdletContext.InputConfig_Endpoint != null)
            {
                requestInputConfig_inputConfig_Endpoint = cmdletContext.InputConfig_Endpoint;
            }
            if (requestInputConfig_inputConfig_Endpoint != null)
            {
                request.InputConfig.Endpoints = requestInputConfig_inputConfig_Endpoint;
                requestInputConfigIsNull = false;
            }
            System.Int32? requestInputConfig_inputConfig_JobDurationInSecond = null;
            if (cmdletContext.InputConfig_JobDurationInSecond != null)
            {
                requestInputConfig_inputConfig_JobDurationInSecond = cmdletContext.InputConfig_JobDurationInSecond.Value;
            }
            if (requestInputConfig_inputConfig_JobDurationInSecond != null)
            {
                request.InputConfig.JobDurationInSeconds = requestInputConfig_inputConfig_JobDurationInSecond.Value;
                requestInputConfigIsNull = false;
            }
            System.String requestInputConfig_inputConfig_ModelName = null;
            if (cmdletContext.InputConfig_ModelName != null)
            {
                requestInputConfig_inputConfig_ModelName = cmdletContext.InputConfig_ModelName;
            }
            if (requestInputConfig_inputConfig_ModelName != null)
            {
                request.InputConfig.ModelName = requestInputConfig_inputConfig_ModelName;
                requestInputConfigIsNull = false;
            }
            System.String requestInputConfig_inputConfig_ModelPackageVersionArn = null;
            if (cmdletContext.InputConfig_ModelPackageVersionArn != null)
            {
                requestInputConfig_inputConfig_ModelPackageVersionArn = cmdletContext.InputConfig_ModelPackageVersionArn;
            }
            if (requestInputConfig_inputConfig_ModelPackageVersionArn != null)
            {
                request.InputConfig.ModelPackageVersionArn = requestInputConfig_inputConfig_ModelPackageVersionArn;
                requestInputConfigIsNull = false;
            }
            System.String requestInputConfig_inputConfig_VolumeKmsKeyId = null;
            if (cmdletContext.InputConfig_VolumeKmsKeyId != null)
            {
                requestInputConfig_inputConfig_VolumeKmsKeyId = cmdletContext.InputConfig_VolumeKmsKeyId;
            }
            if (requestInputConfig_inputConfig_VolumeKmsKeyId != null)
            {
                request.InputConfig.VolumeKmsKeyId = requestInputConfig_inputConfig_VolumeKmsKeyId;
                requestInputConfigIsNull = false;
            }
            Amazon.SageMaker.Model.RecommendationJobResourceLimit requestInputConfig_inputConfig_ResourceLimit = null;
            
             // populate ResourceLimit
            var requestInputConfig_inputConfig_ResourceLimitIsNull = true;
            requestInputConfig_inputConfig_ResourceLimit = new Amazon.SageMaker.Model.RecommendationJobResourceLimit();
            System.Int32? requestInputConfig_inputConfig_ResourceLimit_resourceLimit_MaxNumberOfTest = null;
            if (cmdletContext.ResourceLimit_MaxNumberOfTest != null)
            {
                requestInputConfig_inputConfig_ResourceLimit_resourceLimit_MaxNumberOfTest = cmdletContext.ResourceLimit_MaxNumberOfTest.Value;
            }
            if (requestInputConfig_inputConfig_ResourceLimit_resourceLimit_MaxNumberOfTest != null)
            {
                requestInputConfig_inputConfig_ResourceLimit.MaxNumberOfTests = requestInputConfig_inputConfig_ResourceLimit_resourceLimit_MaxNumberOfTest.Value;
                requestInputConfig_inputConfig_ResourceLimitIsNull = false;
            }
            System.Int32? requestInputConfig_inputConfig_ResourceLimit_resourceLimit_MaxParallelOfTest = null;
            if (cmdletContext.ResourceLimit_MaxParallelOfTest != null)
            {
                requestInputConfig_inputConfig_ResourceLimit_resourceLimit_MaxParallelOfTest = cmdletContext.ResourceLimit_MaxParallelOfTest.Value;
            }
            if (requestInputConfig_inputConfig_ResourceLimit_resourceLimit_MaxParallelOfTest != null)
            {
                requestInputConfig_inputConfig_ResourceLimit.MaxParallelOfTests = requestInputConfig_inputConfig_ResourceLimit_resourceLimit_MaxParallelOfTest.Value;
                requestInputConfig_inputConfig_ResourceLimitIsNull = false;
            }
             // determine if requestInputConfig_inputConfig_ResourceLimit should be set to null
            if (requestInputConfig_inputConfig_ResourceLimitIsNull)
            {
                requestInputConfig_inputConfig_ResourceLimit = null;
            }
            if (requestInputConfig_inputConfig_ResourceLimit != null)
            {
                request.InputConfig.ResourceLimit = requestInputConfig_inputConfig_ResourceLimit;
                requestInputConfigIsNull = false;
            }
            Amazon.SageMaker.Model.RecommendationJobVpcConfig requestInputConfig_inputConfig_VpcConfig = null;
            
             // populate VpcConfig
            var requestInputConfig_inputConfig_VpcConfigIsNull = true;
            requestInputConfig_inputConfig_VpcConfig = new Amazon.SageMaker.Model.RecommendationJobVpcConfig();
            List<System.String> requestInputConfig_inputConfig_VpcConfig_vpcConfig_SecurityGroupId = null;
            if (cmdletContext.VpcConfig_SecurityGroupId != null)
            {
                requestInputConfig_inputConfig_VpcConfig_vpcConfig_SecurityGroupId = cmdletContext.VpcConfig_SecurityGroupId;
            }
            if (requestInputConfig_inputConfig_VpcConfig_vpcConfig_SecurityGroupId != null)
            {
                requestInputConfig_inputConfig_VpcConfig.SecurityGroupIds = requestInputConfig_inputConfig_VpcConfig_vpcConfig_SecurityGroupId;
                requestInputConfig_inputConfig_VpcConfigIsNull = false;
            }
            List<System.String> requestInputConfig_inputConfig_VpcConfig_vpcConfig_Subnet = null;
            if (cmdletContext.VpcConfig_Subnet != null)
            {
                requestInputConfig_inputConfig_VpcConfig_vpcConfig_Subnet = cmdletContext.VpcConfig_Subnet;
            }
            if (requestInputConfig_inputConfig_VpcConfig_vpcConfig_Subnet != null)
            {
                requestInputConfig_inputConfig_VpcConfig.Subnets = requestInputConfig_inputConfig_VpcConfig_vpcConfig_Subnet;
                requestInputConfig_inputConfig_VpcConfigIsNull = false;
            }
             // determine if requestInputConfig_inputConfig_VpcConfig should be set to null
            if (requestInputConfig_inputConfig_VpcConfigIsNull)
            {
                requestInputConfig_inputConfig_VpcConfig = null;
            }
            if (requestInputConfig_inputConfig_VpcConfig != null)
            {
                request.InputConfig.VpcConfig = requestInputConfig_inputConfig_VpcConfig;
                requestInputConfigIsNull = false;
            }
            Amazon.SageMaker.Model.TrafficPattern requestInputConfig_inputConfig_TrafficPattern = null;
            
             // populate TrafficPattern
            var requestInputConfig_inputConfig_TrafficPatternIsNull = true;
            requestInputConfig_inputConfig_TrafficPattern = new Amazon.SageMaker.Model.TrafficPattern();
            List<Amazon.SageMaker.Model.Phase> requestInputConfig_inputConfig_TrafficPattern_trafficPattern_Phase = null;
            if (cmdletContext.TrafficPattern_Phase != null)
            {
                requestInputConfig_inputConfig_TrafficPattern_trafficPattern_Phase = cmdletContext.TrafficPattern_Phase;
            }
            if (requestInputConfig_inputConfig_TrafficPattern_trafficPattern_Phase != null)
            {
                requestInputConfig_inputConfig_TrafficPattern.Phases = requestInputConfig_inputConfig_TrafficPattern_trafficPattern_Phase;
                requestInputConfig_inputConfig_TrafficPatternIsNull = false;
            }
            Amazon.SageMaker.TrafficType requestInputConfig_inputConfig_TrafficPattern_trafficPattern_TrafficType = null;
            if (cmdletContext.TrafficPattern_TrafficType != null)
            {
                requestInputConfig_inputConfig_TrafficPattern_trafficPattern_TrafficType = cmdletContext.TrafficPattern_TrafficType;
            }
            if (requestInputConfig_inputConfig_TrafficPattern_trafficPattern_TrafficType != null)
            {
                requestInputConfig_inputConfig_TrafficPattern.TrafficType = requestInputConfig_inputConfig_TrafficPattern_trafficPattern_TrafficType;
                requestInputConfig_inputConfig_TrafficPatternIsNull = false;
            }
            Amazon.SageMaker.Model.Stairs requestInputConfig_inputConfig_TrafficPattern_inputConfig_TrafficPattern_Stairs = null;
            
             // populate Stairs
            var requestInputConfig_inputConfig_TrafficPattern_inputConfig_TrafficPattern_StairsIsNull = true;
            requestInputConfig_inputConfig_TrafficPattern_inputConfig_TrafficPattern_Stairs = new Amazon.SageMaker.Model.Stairs();
            System.Int32? requestInputConfig_inputConfig_TrafficPattern_inputConfig_TrafficPattern_Stairs_stairs_DurationInSecond = null;
            if (cmdletContext.Stairs_DurationInSecond != null)
            {
                requestInputConfig_inputConfig_TrafficPattern_inputConfig_TrafficPattern_Stairs_stairs_DurationInSecond = cmdletContext.Stairs_DurationInSecond.Value;
            }
            if (requestInputConfig_inputConfig_TrafficPattern_inputConfig_TrafficPattern_Stairs_stairs_DurationInSecond != null)
            {
                requestInputConfig_inputConfig_TrafficPattern_inputConfig_TrafficPattern_Stairs.DurationInSeconds = requestInputConfig_inputConfig_TrafficPattern_inputConfig_TrafficPattern_Stairs_stairs_DurationInSecond.Value;
                requestInputConfig_inputConfig_TrafficPattern_inputConfig_TrafficPattern_StairsIsNull = false;
            }
            System.Int32? requestInputConfig_inputConfig_TrafficPattern_inputConfig_TrafficPattern_Stairs_stairs_NumberOfStep = null;
            if (cmdletContext.Stairs_NumberOfStep != null)
            {
                requestInputConfig_inputConfig_TrafficPattern_inputConfig_TrafficPattern_Stairs_stairs_NumberOfStep = cmdletContext.Stairs_NumberOfStep.Value;
            }
            if (requestInputConfig_inputConfig_TrafficPattern_inputConfig_TrafficPattern_Stairs_stairs_NumberOfStep != null)
            {
                requestInputConfig_inputConfig_TrafficPattern_inputConfig_TrafficPattern_Stairs.NumberOfSteps = requestInputConfig_inputConfig_TrafficPattern_inputConfig_TrafficPattern_Stairs_stairs_NumberOfStep.Value;
                requestInputConfig_inputConfig_TrafficPattern_inputConfig_TrafficPattern_StairsIsNull = false;
            }
            System.Int32? requestInputConfig_inputConfig_TrafficPattern_inputConfig_TrafficPattern_Stairs_stairs_UsersPerStep = null;
            if (cmdletContext.Stairs_UsersPerStep != null)
            {
                requestInputConfig_inputConfig_TrafficPattern_inputConfig_TrafficPattern_Stairs_stairs_UsersPerStep = cmdletContext.Stairs_UsersPerStep.Value;
            }
            if (requestInputConfig_inputConfig_TrafficPattern_inputConfig_TrafficPattern_Stairs_stairs_UsersPerStep != null)
            {
                requestInputConfig_inputConfig_TrafficPattern_inputConfig_TrafficPattern_Stairs.UsersPerStep = requestInputConfig_inputConfig_TrafficPattern_inputConfig_TrafficPattern_Stairs_stairs_UsersPerStep.Value;
                requestInputConfig_inputConfig_TrafficPattern_inputConfig_TrafficPattern_StairsIsNull = false;
            }
             // determine if requestInputConfig_inputConfig_TrafficPattern_inputConfig_TrafficPattern_Stairs should be set to null
            if (requestInputConfig_inputConfig_TrafficPattern_inputConfig_TrafficPattern_StairsIsNull)
            {
                requestInputConfig_inputConfig_TrafficPattern_inputConfig_TrafficPattern_Stairs = null;
            }
            if (requestInputConfig_inputConfig_TrafficPattern_inputConfig_TrafficPattern_Stairs != null)
            {
                requestInputConfig_inputConfig_TrafficPattern.Stairs = requestInputConfig_inputConfig_TrafficPattern_inputConfig_TrafficPattern_Stairs;
                requestInputConfig_inputConfig_TrafficPatternIsNull = false;
            }
             // determine if requestInputConfig_inputConfig_TrafficPattern should be set to null
            if (requestInputConfig_inputConfig_TrafficPatternIsNull)
            {
                requestInputConfig_inputConfig_TrafficPattern = null;
            }
            if (requestInputConfig_inputConfig_TrafficPattern != null)
            {
                request.InputConfig.TrafficPattern = requestInputConfig_inputConfig_TrafficPattern;
                requestInputConfigIsNull = false;
            }
            Amazon.SageMaker.Model.RecommendationJobContainerConfig requestInputConfig_inputConfig_ContainerConfig = null;
            
             // populate ContainerConfig
            var requestInputConfig_inputConfig_ContainerConfigIsNull = true;
            requestInputConfig_inputConfig_ContainerConfig = new Amazon.SageMaker.Model.RecommendationJobContainerConfig();
            System.String requestInputConfig_inputConfig_ContainerConfig_containerConfig_DataInputConfig = null;
            if (cmdletContext.ContainerConfig_DataInputConfig != null)
            {
                requestInputConfig_inputConfig_ContainerConfig_containerConfig_DataInputConfig = cmdletContext.ContainerConfig_DataInputConfig;
            }
            if (requestInputConfig_inputConfig_ContainerConfig_containerConfig_DataInputConfig != null)
            {
                requestInputConfig_inputConfig_ContainerConfig.DataInputConfig = requestInputConfig_inputConfig_ContainerConfig_containerConfig_DataInputConfig;
                requestInputConfig_inputConfig_ContainerConfigIsNull = false;
            }
            System.String requestInputConfig_inputConfig_ContainerConfig_containerConfig_Domain = null;
            if (cmdletContext.ContainerConfig_Domain != null)
            {
                requestInputConfig_inputConfig_ContainerConfig_containerConfig_Domain = cmdletContext.ContainerConfig_Domain;
            }
            if (requestInputConfig_inputConfig_ContainerConfig_containerConfig_Domain != null)
            {
                requestInputConfig_inputConfig_ContainerConfig.Domain = requestInputConfig_inputConfig_ContainerConfig_containerConfig_Domain;
                requestInputConfig_inputConfig_ContainerConfigIsNull = false;
            }
            System.String requestInputConfig_inputConfig_ContainerConfig_containerConfig_Framework = null;
            if (cmdletContext.ContainerConfig_Framework != null)
            {
                requestInputConfig_inputConfig_ContainerConfig_containerConfig_Framework = cmdletContext.ContainerConfig_Framework;
            }
            if (requestInputConfig_inputConfig_ContainerConfig_containerConfig_Framework != null)
            {
                requestInputConfig_inputConfig_ContainerConfig.Framework = requestInputConfig_inputConfig_ContainerConfig_containerConfig_Framework;
                requestInputConfig_inputConfig_ContainerConfigIsNull = false;
            }
            System.String requestInputConfig_inputConfig_ContainerConfig_containerConfig_FrameworkVersion = null;
            if (cmdletContext.ContainerConfig_FrameworkVersion != null)
            {
                requestInputConfig_inputConfig_ContainerConfig_containerConfig_FrameworkVersion = cmdletContext.ContainerConfig_FrameworkVersion;
            }
            if (requestInputConfig_inputConfig_ContainerConfig_containerConfig_FrameworkVersion != null)
            {
                requestInputConfig_inputConfig_ContainerConfig.FrameworkVersion = requestInputConfig_inputConfig_ContainerConfig_containerConfig_FrameworkVersion;
                requestInputConfig_inputConfig_ContainerConfigIsNull = false;
            }
            System.String requestInputConfig_inputConfig_ContainerConfig_containerConfig_NearestModelName = null;
            if (cmdletContext.ContainerConfig_NearestModelName != null)
            {
                requestInputConfig_inputConfig_ContainerConfig_containerConfig_NearestModelName = cmdletContext.ContainerConfig_NearestModelName;
            }
            if (requestInputConfig_inputConfig_ContainerConfig_containerConfig_NearestModelName != null)
            {
                requestInputConfig_inputConfig_ContainerConfig.NearestModelName = requestInputConfig_inputConfig_ContainerConfig_containerConfig_NearestModelName;
                requestInputConfig_inputConfig_ContainerConfigIsNull = false;
            }
            Amazon.SageMaker.RecommendationJobSupportedEndpointType requestInputConfig_inputConfig_ContainerConfig_containerConfig_SupportedEndpointType = null;
            if (cmdletContext.ContainerConfig_SupportedEndpointType != null)
            {
                requestInputConfig_inputConfig_ContainerConfig_containerConfig_SupportedEndpointType = cmdletContext.ContainerConfig_SupportedEndpointType;
            }
            if (requestInputConfig_inputConfig_ContainerConfig_containerConfig_SupportedEndpointType != null)
            {
                requestInputConfig_inputConfig_ContainerConfig.SupportedEndpointType = requestInputConfig_inputConfig_ContainerConfig_containerConfig_SupportedEndpointType;
                requestInputConfig_inputConfig_ContainerConfigIsNull = false;
            }
            List<System.String> requestInputConfig_inputConfig_ContainerConfig_containerConfig_SupportedInstanceType = null;
            if (cmdletContext.ContainerConfig_SupportedInstanceType != null)
            {
                requestInputConfig_inputConfig_ContainerConfig_containerConfig_SupportedInstanceType = cmdletContext.ContainerConfig_SupportedInstanceType;
            }
            if (requestInputConfig_inputConfig_ContainerConfig_containerConfig_SupportedInstanceType != null)
            {
                requestInputConfig_inputConfig_ContainerConfig.SupportedInstanceTypes = requestInputConfig_inputConfig_ContainerConfig_containerConfig_SupportedInstanceType;
                requestInputConfig_inputConfig_ContainerConfigIsNull = false;
            }
            List<System.String> requestInputConfig_inputConfig_ContainerConfig_containerConfig_SupportedResponseMIMEType = null;
            if (cmdletContext.ContainerConfig_SupportedResponseMIMEType != null)
            {
                requestInputConfig_inputConfig_ContainerConfig_containerConfig_SupportedResponseMIMEType = cmdletContext.ContainerConfig_SupportedResponseMIMEType;
            }
            if (requestInputConfig_inputConfig_ContainerConfig_containerConfig_SupportedResponseMIMEType != null)
            {
                requestInputConfig_inputConfig_ContainerConfig.SupportedResponseMIMETypes = requestInputConfig_inputConfig_ContainerConfig_containerConfig_SupportedResponseMIMEType;
                requestInputConfig_inputConfig_ContainerConfigIsNull = false;
            }
            System.String requestInputConfig_inputConfig_ContainerConfig_containerConfig_Task = null;
            if (cmdletContext.ContainerConfig_Task != null)
            {
                requestInputConfig_inputConfig_ContainerConfig_containerConfig_Task = cmdletContext.ContainerConfig_Task;
            }
            if (requestInputConfig_inputConfig_ContainerConfig_containerConfig_Task != null)
            {
                requestInputConfig_inputConfig_ContainerConfig.Task = requestInputConfig_inputConfig_ContainerConfig_containerConfig_Task;
                requestInputConfig_inputConfig_ContainerConfigIsNull = false;
            }
            Amazon.SageMaker.Model.RecommendationJobPayloadConfig requestInputConfig_inputConfig_ContainerConfig_inputConfig_ContainerConfig_PayloadConfig = null;
            
             // populate PayloadConfig
            var requestInputConfig_inputConfig_ContainerConfig_inputConfig_ContainerConfig_PayloadConfigIsNull = true;
            requestInputConfig_inputConfig_ContainerConfig_inputConfig_ContainerConfig_PayloadConfig = new Amazon.SageMaker.Model.RecommendationJobPayloadConfig();
            System.String requestInputConfig_inputConfig_ContainerConfig_inputConfig_ContainerConfig_PayloadConfig_payloadConfig_SamplePayloadUrl = null;
            if (cmdletContext.PayloadConfig_SamplePayloadUrl != null)
            {
                requestInputConfig_inputConfig_ContainerConfig_inputConfig_ContainerConfig_PayloadConfig_payloadConfig_SamplePayloadUrl = cmdletContext.PayloadConfig_SamplePayloadUrl;
            }
            if (requestInputConfig_inputConfig_ContainerConfig_inputConfig_ContainerConfig_PayloadConfig_payloadConfig_SamplePayloadUrl != null)
            {
                requestInputConfig_inputConfig_ContainerConfig_inputConfig_ContainerConfig_PayloadConfig.SamplePayloadUrl = requestInputConfig_inputConfig_ContainerConfig_inputConfig_ContainerConfig_PayloadConfig_payloadConfig_SamplePayloadUrl;
                requestInputConfig_inputConfig_ContainerConfig_inputConfig_ContainerConfig_PayloadConfigIsNull = false;
            }
            List<System.String> requestInputConfig_inputConfig_ContainerConfig_inputConfig_ContainerConfig_PayloadConfig_payloadConfig_SupportedContentType = null;
            if (cmdletContext.PayloadConfig_SupportedContentType != null)
            {
                requestInputConfig_inputConfig_ContainerConfig_inputConfig_ContainerConfig_PayloadConfig_payloadConfig_SupportedContentType = cmdletContext.PayloadConfig_SupportedContentType;
            }
            if (requestInputConfig_inputConfig_ContainerConfig_inputConfig_ContainerConfig_PayloadConfig_payloadConfig_SupportedContentType != null)
            {
                requestInputConfig_inputConfig_ContainerConfig_inputConfig_ContainerConfig_PayloadConfig.SupportedContentTypes = requestInputConfig_inputConfig_ContainerConfig_inputConfig_ContainerConfig_PayloadConfig_payloadConfig_SupportedContentType;
                requestInputConfig_inputConfig_ContainerConfig_inputConfig_ContainerConfig_PayloadConfigIsNull = false;
            }
             // determine if requestInputConfig_inputConfig_ContainerConfig_inputConfig_ContainerConfig_PayloadConfig should be set to null
            if (requestInputConfig_inputConfig_ContainerConfig_inputConfig_ContainerConfig_PayloadConfigIsNull)
            {
                requestInputConfig_inputConfig_ContainerConfig_inputConfig_ContainerConfig_PayloadConfig = null;
            }
            if (requestInputConfig_inputConfig_ContainerConfig_inputConfig_ContainerConfig_PayloadConfig != null)
            {
                requestInputConfig_inputConfig_ContainerConfig.PayloadConfig = requestInputConfig_inputConfig_ContainerConfig_inputConfig_ContainerConfig_PayloadConfig;
                requestInputConfig_inputConfig_ContainerConfigIsNull = false;
            }
             // determine if requestInputConfig_inputConfig_ContainerConfig should be set to null
            if (requestInputConfig_inputConfig_ContainerConfigIsNull)
            {
                requestInputConfig_inputConfig_ContainerConfig = null;
            }
            if (requestInputConfig_inputConfig_ContainerConfig != null)
            {
                request.InputConfig.ContainerConfig = requestInputConfig_inputConfig_ContainerConfig;
                requestInputConfigIsNull = false;
            }
             // determine if request.InputConfig should be set to null
            if (requestInputConfigIsNull)
            {
                request.InputConfig = null;
            }
            if (cmdletContext.JobDescription != null)
            {
                request.JobDescription = cmdletContext.JobDescription;
            }
            if (cmdletContext.JobName != null)
            {
                request.JobName = cmdletContext.JobName;
            }
            if (cmdletContext.JobType != null)
            {
                request.JobType = cmdletContext.JobType;
            }
            
             // populate OutputConfig
            var requestOutputConfigIsNull = true;
            request.OutputConfig = new Amazon.SageMaker.Model.RecommendationJobOutputConfig();
            System.String requestOutputConfig_outputConfig_KmsKeyId = null;
            if (cmdletContext.OutputConfig_KmsKeyId != null)
            {
                requestOutputConfig_outputConfig_KmsKeyId = cmdletContext.OutputConfig_KmsKeyId;
            }
            if (requestOutputConfig_outputConfig_KmsKeyId != null)
            {
                request.OutputConfig.KmsKeyId = requestOutputConfig_outputConfig_KmsKeyId;
                requestOutputConfigIsNull = false;
            }
            Amazon.SageMaker.Model.RecommendationJobCompiledOutputConfig requestOutputConfig_outputConfig_CompiledOutputConfig = null;
            
             // populate CompiledOutputConfig
            var requestOutputConfig_outputConfig_CompiledOutputConfigIsNull = true;
            requestOutputConfig_outputConfig_CompiledOutputConfig = new Amazon.SageMaker.Model.RecommendationJobCompiledOutputConfig();
            System.String requestOutputConfig_outputConfig_CompiledOutputConfig_compiledOutputConfig_S3OutputUri = null;
            if (cmdletContext.CompiledOutputConfig_S3OutputUri != null)
            {
                requestOutputConfig_outputConfig_CompiledOutputConfig_compiledOutputConfig_S3OutputUri = cmdletContext.CompiledOutputConfig_S3OutputUri;
            }
            if (requestOutputConfig_outputConfig_CompiledOutputConfig_compiledOutputConfig_S3OutputUri != null)
            {
                requestOutputConfig_outputConfig_CompiledOutputConfig.S3OutputUri = requestOutputConfig_outputConfig_CompiledOutputConfig_compiledOutputConfig_S3OutputUri;
                requestOutputConfig_outputConfig_CompiledOutputConfigIsNull = false;
            }
             // determine if requestOutputConfig_outputConfig_CompiledOutputConfig should be set to null
            if (requestOutputConfig_outputConfig_CompiledOutputConfigIsNull)
            {
                requestOutputConfig_outputConfig_CompiledOutputConfig = null;
            }
            if (requestOutputConfig_outputConfig_CompiledOutputConfig != null)
            {
                request.OutputConfig.CompiledOutputConfig = requestOutputConfig_outputConfig_CompiledOutputConfig;
                requestOutputConfigIsNull = false;
            }
             // determine if request.OutputConfig should be set to null
            if (requestOutputConfigIsNull)
            {
                request.OutputConfig = null;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            
             // populate StoppingConditions
            var requestStoppingConditionsIsNull = true;
            request.StoppingConditions = new Amazon.SageMaker.Model.RecommendationJobStoppingConditions();
            Amazon.SageMaker.FlatInvocations requestStoppingConditions_stoppingConditions_FlatInvocation = null;
            if (cmdletContext.StoppingConditions_FlatInvocation != null)
            {
                requestStoppingConditions_stoppingConditions_FlatInvocation = cmdletContext.StoppingConditions_FlatInvocation;
            }
            if (requestStoppingConditions_stoppingConditions_FlatInvocation != null)
            {
                request.StoppingConditions.FlatInvocations = requestStoppingConditions_stoppingConditions_FlatInvocation;
                requestStoppingConditionsIsNull = false;
            }
            System.Int32? requestStoppingConditions_stoppingConditions_MaxInvocation = null;
            if (cmdletContext.StoppingConditions_MaxInvocation != null)
            {
                requestStoppingConditions_stoppingConditions_MaxInvocation = cmdletContext.StoppingConditions_MaxInvocation.Value;
            }
            if (requestStoppingConditions_stoppingConditions_MaxInvocation != null)
            {
                request.StoppingConditions.MaxInvocations = requestStoppingConditions_stoppingConditions_MaxInvocation.Value;
                requestStoppingConditionsIsNull = false;
            }
            List<Amazon.SageMaker.Model.ModelLatencyThreshold> requestStoppingConditions_stoppingConditions_ModelLatencyThreshold = null;
            if (cmdletContext.StoppingConditions_ModelLatencyThreshold != null)
            {
                requestStoppingConditions_stoppingConditions_ModelLatencyThreshold = cmdletContext.StoppingConditions_ModelLatencyThreshold;
            }
            if (requestStoppingConditions_stoppingConditions_ModelLatencyThreshold != null)
            {
                request.StoppingConditions.ModelLatencyThresholds = requestStoppingConditions_stoppingConditions_ModelLatencyThreshold;
                requestStoppingConditionsIsNull = false;
            }
             // determine if request.StoppingConditions should be set to null
            if (requestStoppingConditionsIsNull)
            {
                request.StoppingConditions = null;
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
        
        private Amazon.SageMaker.Model.CreateInferenceRecommendationsJobResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateInferenceRecommendationsJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateInferenceRecommendationsJob");
            try
            {
                return client.CreateInferenceRecommendationsJobAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ContainerConfig_DataInputConfig { get; set; }
            public System.String ContainerConfig_Domain { get; set; }
            public System.String ContainerConfig_Framework { get; set; }
            public System.String ContainerConfig_FrameworkVersion { get; set; }
            public System.String ContainerConfig_NearestModelName { get; set; }
            public System.String PayloadConfig_SamplePayloadUrl { get; set; }
            public List<System.String> PayloadConfig_SupportedContentType { get; set; }
            public Amazon.SageMaker.RecommendationJobSupportedEndpointType ContainerConfig_SupportedEndpointType { get; set; }
            public List<System.String> ContainerConfig_SupportedInstanceType { get; set; }
            public List<System.String> ContainerConfig_SupportedResponseMIMEType { get; set; }
            public System.String ContainerConfig_Task { get; set; }
            public List<Amazon.SageMaker.Model.EndpointInputConfiguration> InputConfig_EndpointConfiguration { get; set; }
            public List<Amazon.SageMaker.Model.EndpointInfo> InputConfig_Endpoint { get; set; }
            public System.Int32? InputConfig_JobDurationInSecond { get; set; }
            public System.String InputConfig_ModelName { get; set; }
            public System.String InputConfig_ModelPackageVersionArn { get; set; }
            public System.Int32? ResourceLimit_MaxNumberOfTest { get; set; }
            public System.Int32? ResourceLimit_MaxParallelOfTest { get; set; }
            public List<Amazon.SageMaker.Model.Phase> TrafficPattern_Phase { get; set; }
            public System.Int32? Stairs_DurationInSecond { get; set; }
            public System.Int32? Stairs_NumberOfStep { get; set; }
            public System.Int32? Stairs_UsersPerStep { get; set; }
            public Amazon.SageMaker.TrafficType TrafficPattern_TrafficType { get; set; }
            public System.String InputConfig_VolumeKmsKeyId { get; set; }
            public List<System.String> VpcConfig_SecurityGroupId { get; set; }
            public List<System.String> VpcConfig_Subnet { get; set; }
            public System.String JobDescription { get; set; }
            public System.String JobName { get; set; }
            public Amazon.SageMaker.RecommendationJobType JobType { get; set; }
            public System.String CompiledOutputConfig_S3OutputUri { get; set; }
            public System.String OutputConfig_KmsKeyId { get; set; }
            public System.String RoleArn { get; set; }
            public Amazon.SageMaker.FlatInvocations StoppingConditions_FlatInvocation { get; set; }
            public System.Int32? StoppingConditions_MaxInvocation { get; set; }
            public List<Amazon.SageMaker.Model.ModelLatencyThreshold> StoppingConditions_ModelLatencyThreshold { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateInferenceRecommendationsJobResponse, NewSMInferenceRecommendationsJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobArn;
        }
        
    }
}
