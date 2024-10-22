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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Creates an Autopilot job also referred to as Autopilot experiment or AutoML job.
    /// 
    ///  
    /// <para>
    /// An AutoML job in SageMaker is a fully automated process that allows you to build machine
    /// learning models with minimal effort and machine learning expertise. When initiating
    /// an AutoML job, you provide your data and optionally specify parameters tailored to
    /// your use case. SageMaker then automates the entire model development lifecycle, including
    /// data preprocessing, model training, tuning, and evaluation. AutoML jobs are designed
    /// to simplify and accelerate the model building process by automating various tasks
    /// and exploring different combinations of machine learning algorithms, data preprocessing
    /// techniques, and hyperparameter values. The output of an AutoML job comprises one or
    /// more trained models ready for deployment and inference. Additionally, SageMaker AutoML
    /// jobs generate a candidate model leaderboard, allowing you to select the best-performing
    /// model for deployment.
    /// </para><para>
    /// For more information about AutoML jobs, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/autopilot-automate-model-development.html">https://docs.aws.amazon.com/sagemaker/latest/dg/autopilot-automate-model-development.html</a>
    /// in the SageMaker developer guide.
    /// </para><note><para>
    /// We recommend using the new versions <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_CreateAutoMLJobV2.html">CreateAutoMLJobV2</a>
    /// and <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_DescribeAutoMLJobV2.html">DescribeAutoMLJobV2</a>,
    /// which offer backward compatibility.
    /// </para><para><c>CreateAutoMLJobV2</c> can manage tabular problem types identical to those of its
    /// previous version <c>CreateAutoMLJob</c>, as well as time-series forecasting, non-tabular
    /// problem types such as image or text classification, and text generation (LLMs fine-tuning).
    /// </para><para>
    /// Find guidelines about how to migrate a <c>CreateAutoMLJob</c> to <c>CreateAutoMLJobV2</c>
    /// in <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/autopilot-automate-model-development-create-experiment.html#autopilot-create-experiment-api-migrate-v1-v2">Migrate
    /// a CreateAutoMLJob to CreateAutoMLJobV2</a>.
    /// </para></note><para>
    /// You can find the best-performing model after you run an AutoML job by calling <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_DescribeAutoMLJobV2.html">DescribeAutoMLJobV2</a>
    /// (recommended) or <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_DescribeAutoMLJob.html">DescribeAutoMLJob</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SMAutoMLJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateAutoMLJob API operation.", Operation = new[] {"CreateAutoMLJob"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateAutoMLJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateAutoMLJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateAutoMLJobResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSMAutoMLJobCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CandidateGenerationConfig_AlgorithmsConfig
        /// <summary>
        /// <para>
        /// <para>Stores the configuration information for the selection of algorithms trained on tabular
        /// data.</para><para>The list of available algorithms to choose from depends on the training mode set in
        /// <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_TabularJobConfig.html"><c>TabularJobConfig.Mode</c></a>.</para><ul><li><para><c>AlgorithmsConfig</c> should not be set if the training mode is set on <c>AUTO</c>.</para></li><li><para>When <c>AlgorithmsConfig</c> is provided, one <c>AutoMLAlgorithms</c> attribute must
        /// be set and one only.</para><para>If the list of algorithms provided as values for <c>AutoMLAlgorithms</c> is empty,
        /// <c>CandidateGenerationConfig</c> uses the full set of algorithms for the given training
        /// mode.</para></li><li><para>When <c>AlgorithmsConfig</c> is not provided, <c>CandidateGenerationConfig</c> uses
        /// the full set of algorithms for the given training mode.</para></li></ul><para>For the list of all algorithms per problem type and training mode, see <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_AutoMLAlgorithmConfig.html">
        /// AutoMLAlgorithmConfig</a>.</para><para>For more information on each algorithm, see the <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/autopilot-model-support-validation.html#autopilot-algorithm-support">Algorithm
        /// support</a> section in Autopilot developer guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLJobConfig_CandidateGenerationConfig_AlgorithmsConfig")]
        public Amazon.SageMaker.Model.AutoMLAlgorithmConfig[] CandidateGenerationConfig_AlgorithmsConfig { get; set; }
        #endregion
        
        #region Parameter ModelDeployConfig_AutoGenerateEndpointName
        /// <summary>
        /// <para>
        /// <para>Set to <c>True</c> to automatically generate an endpoint name for a one-click Autopilot
        /// model deployment; set to <c>False</c> otherwise. The default value is <c>False</c>.</para><note><para>If you set <c>AutoGenerateEndpointName</c> to <c>True</c>, do not specify the <c>EndpointName</c>;
        /// otherwise a 400 error is thrown.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ModelDeployConfig_AutoGenerateEndpointName { get; set; }
        #endregion
        
        #region Parameter AutoMLJobName
        /// <summary>
        /// <para>
        /// <para>Identifies an Autopilot job. The name must be unique to your account and is case insensitive.</para>
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
        public System.String AutoMLJobName { get; set; }
        #endregion
        
        #region Parameter SecurityConfig_EnableInterContainerTrafficEncryption
        /// <summary>
        /// <para>
        /// <para>Whether to use traffic encryption between the container layers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLJobConfig_SecurityConfig_EnableInterContainerTrafficEncryption")]
        public System.Boolean? SecurityConfig_EnableInterContainerTrafficEncryption { get; set; }
        #endregion
        
        #region Parameter ModelDeployConfig_EndpointName
        /// <summary>
        /// <para>
        /// <para>Specifies the endpoint name to use for a one-click Autopilot model deployment if the
        /// endpoint name is not generated automatically.</para><note><para>Specify the <c>EndpointName</c> if and only if you set <c>AutoGenerateEndpointName</c>
        /// to <c>False</c>; otherwise a 400 error is thrown.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ModelDeployConfig_EndpointName { get; set; }
        #endregion
        
        #region Parameter CandidateGenerationConfig_FeatureSpecificationS3Uri
        /// <summary>
        /// <para>
        /// <para>A URL to the Amazon S3 data source containing selected features from the input data
        /// source to run an Autopilot job. You can input <c>FeatureAttributeNames</c> (optional)
        /// in JSON format as shown below: </para><para><c>{ "FeatureAttributeNames":["col1", "col2", ...] }</c>.</para><para>You can also specify the data type of the feature (optional) in the format shown below:</para><para><c>{ "FeatureDataTypes":{"col1":"numeric", "col2":"categorical" ... } }</c></para><note><para>These column keys may not include the target column.</para></note><para>In ensembling mode, Autopilot only supports the following data types: <c>numeric</c>,
        /// <c>categorical</c>, <c>text</c>, and <c>datetime</c>. In HPO mode, Autopilot can support
        /// <c>numeric</c>, <c>categorical</c>, <c>text</c>, <c>datetime</c>, and <c>sequence</c>.</para><para>If only <c>FeatureDataTypes</c> is provided, the column keys (<c>col1</c>, <c>col2</c>,..)
        /// should be a subset of the column names in the input data. </para><para>If both <c>FeatureDataTypes</c> and <c>FeatureAttributeNames</c> are provided, then
        /// the column keys should be a subset of the column names provided in <c>FeatureAttributeNames</c>.
        /// </para><para>The key name <c>FeatureAttributeNames</c> is fixed. The values listed in <c>["col1",
        /// "col2", ...]</c> are case sensitive and should be a list of strings containing unique
        /// values that are a subset of the column names in the input data. The list of columns
        /// provided must not include the target column.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLJobConfig_CandidateGenerationConfig_FeatureSpecificationS3Uri")]
        public System.String CandidateGenerationConfig_FeatureSpecificationS3Uri { get; set; }
        #endregion
        
        #region Parameter GenerateCandidateDefinitionsOnly
        /// <summary>
        /// <para>
        /// <para>Generates possible candidates without training the models. A candidate is a combination
        /// of data preprocessors, algorithms, and algorithm parameter settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? GenerateCandidateDefinitionsOnly { get; set; }
        #endregion
        
        #region Parameter InputDataConfig
        /// <summary>
        /// <para>
        /// <para>An array of channel objects that describes the input data and its location. Each channel
        /// is a named input source. Similar to <c>InputDataConfig</c> supported by <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_HyperParameterTrainingJobDefinition.html">HyperParameterTrainingJobDefinition</a>.
        /// Format(s) supported: CSV, Parquet. A minimum of 500 rows is required for the training
        /// dataset. There is not a minimum number of rows required for the validation dataset.</para>
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
        public Amazon.SageMaker.Model.AutoMLChannel[] InputDataConfig { get; set; }
        #endregion
        
        #region Parameter OutputDataConfig_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Key Management Service encryption key ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputDataConfig_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter CompletionCriteria_MaxAutoMLJobRuntimeInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum runtime, in seconds, an AutoML job has to complete.</para><para>If an AutoML job exceeds the maximum runtime, the job is stopped automatically and
        /// its processing is ended gracefully. The AutoML job identifies the best model whose
        /// training was completed and marks it as the best-performing model. Any unfinished steps
        /// of the job, such as automatic one-click Autopilot model deployment, are not completed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSeconds")]
        public System.Int32? CompletionCriteria_MaxAutoMLJobRuntimeInSecond { get; set; }
        #endregion
        
        #region Parameter CompletionCriteria_MaxCandidate
        /// <summary>
        /// <para>
        /// <para>The maximum number of times a training job is allowed to run.</para><para>For text and image classification, time-series forecasting, as well as text generation
        /// (LLMs fine-tuning) problem types, the supported value is 1. For tabular problem types,
        /// the maximum value is 750.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLJobConfig_CompletionCriteria_MaxCandidates")]
        public System.Int32? CompletionCriteria_MaxCandidate { get; set; }
        #endregion
        
        #region Parameter CompletionCriteria_MaxRuntimePerTrainingJobInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum time, in seconds, that each training job executed inside hyperparameter
        /// tuning is allowed to run as part of a hyperparameter tuning job. For more information,
        /// see the <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_StoppingCondition.html">StoppingCondition</a>
        /// used by the <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_CreateHyperParameterTuningJob.html">CreateHyperParameterTuningJob</a>
        /// action.</para><para>For job V2s (jobs created by calling <c>CreateAutoMLJobV2</c>), this field controls
        /// the runtime of the job candidate.</para><para>For <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_TextClassificationJobConfig.html">TextGenerationJobConfig</a>
        /// problem types, the maximum time defaults to 72 hours (259200 seconds).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSeconds")]
        public System.Int32? CompletionCriteria_MaxRuntimePerTrainingJobInSecond { get; set; }
        #endregion
        
        #region Parameter AutoMLJobObjective_MetricName
        /// <summary>
        /// <para>
        /// <para>The name of the objective metric used to measure the predictive quality of a machine
        /// learning system. During training, the model's parameters are updated iteratively to
        /// optimize its performance based on the feedback provided by the objective metric when
        /// evaluating the model on the validation dataset.</para><para>The list of available metrics supported by Autopilot and the default metric applied
        /// when you do not specify a metric name explicitly depend on the problem type.</para><ul><li><para>For tabular problem types:</para><ul><li><para>List of available metrics: </para><ul><li><para> Regression: <c>MAE</c>, <c>MSE</c>, <c>R2</c>, <c>RMSE</c></para></li><li><para> Binary classification: <c>Accuracy</c>, <c>AUC</c>, <c>BalancedAccuracy</c>, <c>F1</c>,
        /// <c>Precision</c>, <c>Recall</c></para></li><li><para> Multiclass classification: <c>Accuracy</c>, <c>BalancedAccuracy</c>, <c>F1macro</c>,
        /// <c>PrecisionMacro</c>, <c>RecallMacro</c></para></li></ul><para>For a description of each metric, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/autopilot-metrics-validation.html#autopilot-metrics">Autopilot
        /// metrics for classification and regression</a>.</para></li><li><para>Default objective metrics:</para><ul><li><para>Regression: <c>MSE</c>.</para></li><li><para>Binary classification: <c>F1</c>.</para></li><li><para>Multiclass classification: <c>Accuracy</c>.</para></li></ul></li></ul></li><li><para>For image or text classification problem types:</para><ul><li><para>List of available metrics: <c>Accuracy</c></para><para>For a description of each metric, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/text-classification-data-format-and-metric.html">Autopilot
        /// metrics for text and image classification</a>.</para></li><li><para>Default objective metrics: <c>Accuracy</c></para></li></ul></li><li><para>For time-series forecasting problem types:</para><ul><li><para>List of available metrics: <c>RMSE</c>, <c>wQL</c>, <c>Average wQL</c>, <c>MASE</c>,
        /// <c>MAPE</c>, <c>WAPE</c></para><para>For a description of each metric, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/timeseries-objective-metric.html">Autopilot
        /// metrics for time-series forecasting</a>.</para></li><li><para>Default objective metrics: <c>AverageWeightedQuantileLoss</c></para></li></ul></li><li><para>For text generation problem types (LLMs fine-tuning): Fine-tuning language models
        /// in Autopilot does not require setting the <c>AutoMLJobObjective</c> field. Autopilot
        /// fine-tunes LLMs without requiring multiple candidates to be trained and evaluated.
        /// Instead, using your dataset, Autopilot directly fine-tunes your target model to enhance
        /// a default objective metric, the cross-entropy loss. After fine-tuning a language model,
        /// you can evaluate the quality of its generated text using different metrics. For a
        /// list of the available metrics, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/autopilot-llms-finetuning-metrics.html">Metrics
        /// for fine-tuning LLMs in Autopilot</a>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.AutoMLMetricEnum")]
        public Amazon.SageMaker.AutoMLMetricEnum AutoMLJobObjective_MetricName { get; set; }
        #endregion
        
        #region Parameter AutoMLJobConfig_Mode
        /// <summary>
        /// <para>
        /// <para>The method that Autopilot uses to train the data. You can either specify the mode
        /// manually or let Autopilot choose for you based on the dataset size by selecting <c>AUTO</c>.
        /// In <c>AUTO</c> mode, Autopilot chooses <c>ENSEMBLING</c> for datasets smaller than
        /// 100 MB, and <c>HYPERPARAMETER_TUNING</c> for larger ones.</para><para>The <c>ENSEMBLING</c> mode uses a multi-stack ensemble model to predict classification
        /// and regression tasks directly from your dataset. This machine learning mode combines
        /// several base models to produce an optimal predictive model. It then uses a stacking
        /// ensemble method to combine predictions from contributing members. A multi-stack ensemble
        /// model can provide better performance over a single model by combining the predictive
        /// capabilities of multiple models. See <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/autopilot-model-support-validation.html#autopilot-algorithm-support">Autopilot
        /// algorithm support</a> for a list of algorithms supported by <c>ENSEMBLING</c> mode.</para><para>The <c>HYPERPARAMETER_TUNING</c> (HPO) mode uses the best hyperparameters to train
        /// the best version of a model. HPO automatically selects an algorithm for the type of
        /// problem you want to solve. Then HPO finds the best hyperparameters according to your
        /// objective metric. See <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/autopilot-model-support-validation.html#autopilot-algorithm-support">Autopilot
        /// algorithm support</a> for a list of algorithms supported by <c>HYPERPARAMETER_TUNING</c>
        /// mode.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.AutoMLMode")]
        public Amazon.SageMaker.AutoMLMode AutoMLJobConfig_Mode { get; set; }
        #endregion
        
        #region Parameter ProblemType
        /// <summary>
        /// <para>
        /// <para>Defines the type of supervised learning problem available for the candidates. For
        /// more information, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/autopilot-datasets-problem-types.html#autopilot-problem-types">
        /// SageMaker Autopilot problem types</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.ProblemType")]
        public Amazon.SageMaker.ProblemType ProblemType { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the role that is used to access the data.</para>
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
        
        #region Parameter OutputDataConfig_S3OutputPath
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 output path. Must be 512 characters or less.</para>
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
        public System.String OutputDataConfig_S3OutputPath { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The VPC security group IDs, in the form <c>sg-xxxxxxxx</c>. Specify the security groups
        /// for the VPC that is specified in the <c>Subnets</c> field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLJobConfig_SecurityConfig_VpcConfig_SecurityGroupIds")]
        public System.String[] VpcConfig_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter VpcConfig_Subnet
        /// <summary>
        /// <para>
        /// <para>The ID of the subnets in the VPC to which you want to connect your training job or
        /// model. For information about the availability of specific instance types, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/instance-types-az.html">Supported
        /// Instance Types and Availability Zones</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLJobConfig_SecurityConfig_VpcConfig_Subnets")]
        public System.String[] VpcConfig_Subnet { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of key-value pairs. You can use tags to categorize your Amazon Web Services
        /// resources in different ways, for example, by purpose, owner, or environment. For more
        /// information, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">Tagging
        /// Amazon Web ServicesResources</a>. Tag keys must be unique per resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter DataSplitConfig_ValidationFraction
        /// <summary>
        /// <para>
        /// <para>The validation fraction (optional) is a float that specifies the portion of the training
        /// dataset to be used for validation. The default value is 0.2, and values must be greater
        /// than 0 and less than 1. We recommend setting this value to be less than 0.5.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLJobConfig_DataSplitConfig_ValidationFraction")]
        public System.Single? DataSplitConfig_ValidationFraction { get; set; }
        #endregion
        
        #region Parameter SecurityConfig_VolumeKmsKeyId
        /// <summary>
        /// <para>
        /// <para>The key used to encrypt stored data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLJobConfig_SecurityConfig_VolumeKmsKeyId")]
        public System.String SecurityConfig_VolumeKmsKeyId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AutoMLJobArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateAutoMLJobResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateAutoMLJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AutoMLJobArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AutoMLJobName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMAutoMLJob (CreateAutoMLJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateAutoMLJobResponse, NewSMAutoMLJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.CandidateGenerationConfig_AlgorithmsConfig != null)
            {
                context.CandidateGenerationConfig_AlgorithmsConfig = new List<Amazon.SageMaker.Model.AutoMLAlgorithmConfig>(this.CandidateGenerationConfig_AlgorithmsConfig);
            }
            context.CandidateGenerationConfig_FeatureSpecificationS3Uri = this.CandidateGenerationConfig_FeatureSpecificationS3Uri;
            context.CompletionCriteria_MaxAutoMLJobRuntimeInSecond = this.CompletionCriteria_MaxAutoMLJobRuntimeInSecond;
            context.CompletionCriteria_MaxCandidate = this.CompletionCriteria_MaxCandidate;
            context.CompletionCriteria_MaxRuntimePerTrainingJobInSecond = this.CompletionCriteria_MaxRuntimePerTrainingJobInSecond;
            context.DataSplitConfig_ValidationFraction = this.DataSplitConfig_ValidationFraction;
            context.AutoMLJobConfig_Mode = this.AutoMLJobConfig_Mode;
            context.SecurityConfig_EnableInterContainerTrafficEncryption = this.SecurityConfig_EnableInterContainerTrafficEncryption;
            context.SecurityConfig_VolumeKmsKeyId = this.SecurityConfig_VolumeKmsKeyId;
            if (this.VpcConfig_SecurityGroupId != null)
            {
                context.VpcConfig_SecurityGroupId = new List<System.String>(this.VpcConfig_SecurityGroupId);
            }
            if (this.VpcConfig_Subnet != null)
            {
                context.VpcConfig_Subnet = new List<System.String>(this.VpcConfig_Subnet);
            }
            context.AutoMLJobName = this.AutoMLJobName;
            #if MODULAR
            if (this.AutoMLJobName == null && ParameterWasBound(nameof(this.AutoMLJobName)))
            {
                WriteWarning("You are passing $null as a value for parameter AutoMLJobName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AutoMLJobObjective_MetricName = this.AutoMLJobObjective_MetricName;
            context.GenerateCandidateDefinitionsOnly = this.GenerateCandidateDefinitionsOnly;
            if (this.InputDataConfig != null)
            {
                context.InputDataConfig = new List<Amazon.SageMaker.Model.AutoMLChannel>(this.InputDataConfig);
            }
            #if MODULAR
            if (this.InputDataConfig == null && ParameterWasBound(nameof(this.InputDataConfig)))
            {
                WriteWarning("You are passing $null as a value for parameter InputDataConfig which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ModelDeployConfig_AutoGenerateEndpointName = this.ModelDeployConfig_AutoGenerateEndpointName;
            context.ModelDeployConfig_EndpointName = this.ModelDeployConfig_EndpointName;
            context.OutputDataConfig_KmsKeyId = this.OutputDataConfig_KmsKeyId;
            context.OutputDataConfig_S3OutputPath = this.OutputDataConfig_S3OutputPath;
            #if MODULAR
            if (this.OutputDataConfig_S3OutputPath == null && ParameterWasBound(nameof(this.OutputDataConfig_S3OutputPath)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputDataConfig_S3OutputPath which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProblemType = this.ProblemType;
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
            var request = new Amazon.SageMaker.Model.CreateAutoMLJobRequest();
            
            
             // populate AutoMLJobConfig
            var requestAutoMLJobConfigIsNull = true;
            request.AutoMLJobConfig = new Amazon.SageMaker.Model.AutoMLJobConfig();
            Amazon.SageMaker.AutoMLMode requestAutoMLJobConfig_autoMLJobConfig_Mode = null;
            if (cmdletContext.AutoMLJobConfig_Mode != null)
            {
                requestAutoMLJobConfig_autoMLJobConfig_Mode = cmdletContext.AutoMLJobConfig_Mode;
            }
            if (requestAutoMLJobConfig_autoMLJobConfig_Mode != null)
            {
                request.AutoMLJobConfig.Mode = requestAutoMLJobConfig_autoMLJobConfig_Mode;
                requestAutoMLJobConfigIsNull = false;
            }
            Amazon.SageMaker.Model.AutoMLDataSplitConfig requestAutoMLJobConfig_autoMLJobConfig_DataSplitConfig = null;
            
             // populate DataSplitConfig
            var requestAutoMLJobConfig_autoMLJobConfig_DataSplitConfigIsNull = true;
            requestAutoMLJobConfig_autoMLJobConfig_DataSplitConfig = new Amazon.SageMaker.Model.AutoMLDataSplitConfig();
            System.Single? requestAutoMLJobConfig_autoMLJobConfig_DataSplitConfig_dataSplitConfig_ValidationFraction = null;
            if (cmdletContext.DataSplitConfig_ValidationFraction != null)
            {
                requestAutoMLJobConfig_autoMLJobConfig_DataSplitConfig_dataSplitConfig_ValidationFraction = cmdletContext.DataSplitConfig_ValidationFraction.Value;
            }
            if (requestAutoMLJobConfig_autoMLJobConfig_DataSplitConfig_dataSplitConfig_ValidationFraction != null)
            {
                requestAutoMLJobConfig_autoMLJobConfig_DataSplitConfig.ValidationFraction = requestAutoMLJobConfig_autoMLJobConfig_DataSplitConfig_dataSplitConfig_ValidationFraction.Value;
                requestAutoMLJobConfig_autoMLJobConfig_DataSplitConfigIsNull = false;
            }
             // determine if requestAutoMLJobConfig_autoMLJobConfig_DataSplitConfig should be set to null
            if (requestAutoMLJobConfig_autoMLJobConfig_DataSplitConfigIsNull)
            {
                requestAutoMLJobConfig_autoMLJobConfig_DataSplitConfig = null;
            }
            if (requestAutoMLJobConfig_autoMLJobConfig_DataSplitConfig != null)
            {
                request.AutoMLJobConfig.DataSplitConfig = requestAutoMLJobConfig_autoMLJobConfig_DataSplitConfig;
                requestAutoMLJobConfigIsNull = false;
            }
            Amazon.SageMaker.Model.AutoMLCandidateGenerationConfig requestAutoMLJobConfig_autoMLJobConfig_CandidateGenerationConfig = null;
            
             // populate CandidateGenerationConfig
            var requestAutoMLJobConfig_autoMLJobConfig_CandidateGenerationConfigIsNull = true;
            requestAutoMLJobConfig_autoMLJobConfig_CandidateGenerationConfig = new Amazon.SageMaker.Model.AutoMLCandidateGenerationConfig();
            List<Amazon.SageMaker.Model.AutoMLAlgorithmConfig> requestAutoMLJobConfig_autoMLJobConfig_CandidateGenerationConfig_candidateGenerationConfig_AlgorithmsConfig = null;
            if (cmdletContext.CandidateGenerationConfig_AlgorithmsConfig != null)
            {
                requestAutoMLJobConfig_autoMLJobConfig_CandidateGenerationConfig_candidateGenerationConfig_AlgorithmsConfig = cmdletContext.CandidateGenerationConfig_AlgorithmsConfig;
            }
            if (requestAutoMLJobConfig_autoMLJobConfig_CandidateGenerationConfig_candidateGenerationConfig_AlgorithmsConfig != null)
            {
                requestAutoMLJobConfig_autoMLJobConfig_CandidateGenerationConfig.AlgorithmsConfig = requestAutoMLJobConfig_autoMLJobConfig_CandidateGenerationConfig_candidateGenerationConfig_AlgorithmsConfig;
                requestAutoMLJobConfig_autoMLJobConfig_CandidateGenerationConfigIsNull = false;
            }
            System.String requestAutoMLJobConfig_autoMLJobConfig_CandidateGenerationConfig_candidateGenerationConfig_FeatureSpecificationS3Uri = null;
            if (cmdletContext.CandidateGenerationConfig_FeatureSpecificationS3Uri != null)
            {
                requestAutoMLJobConfig_autoMLJobConfig_CandidateGenerationConfig_candidateGenerationConfig_FeatureSpecificationS3Uri = cmdletContext.CandidateGenerationConfig_FeatureSpecificationS3Uri;
            }
            if (requestAutoMLJobConfig_autoMLJobConfig_CandidateGenerationConfig_candidateGenerationConfig_FeatureSpecificationS3Uri != null)
            {
                requestAutoMLJobConfig_autoMLJobConfig_CandidateGenerationConfig.FeatureSpecificationS3Uri = requestAutoMLJobConfig_autoMLJobConfig_CandidateGenerationConfig_candidateGenerationConfig_FeatureSpecificationS3Uri;
                requestAutoMLJobConfig_autoMLJobConfig_CandidateGenerationConfigIsNull = false;
            }
             // determine if requestAutoMLJobConfig_autoMLJobConfig_CandidateGenerationConfig should be set to null
            if (requestAutoMLJobConfig_autoMLJobConfig_CandidateGenerationConfigIsNull)
            {
                requestAutoMLJobConfig_autoMLJobConfig_CandidateGenerationConfig = null;
            }
            if (requestAutoMLJobConfig_autoMLJobConfig_CandidateGenerationConfig != null)
            {
                request.AutoMLJobConfig.CandidateGenerationConfig = requestAutoMLJobConfig_autoMLJobConfig_CandidateGenerationConfig;
                requestAutoMLJobConfigIsNull = false;
            }
            Amazon.SageMaker.Model.AutoMLJobCompletionCriteria requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteria = null;
            
             // populate CompletionCriteria
            var requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteriaIsNull = true;
            requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteria = new Amazon.SageMaker.Model.AutoMLJobCompletionCriteria();
            System.Int32? requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteria_completionCriteria_MaxAutoMLJobRuntimeInSecond = null;
            if (cmdletContext.CompletionCriteria_MaxAutoMLJobRuntimeInSecond != null)
            {
                requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteria_completionCriteria_MaxAutoMLJobRuntimeInSecond = cmdletContext.CompletionCriteria_MaxAutoMLJobRuntimeInSecond.Value;
            }
            if (requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteria_completionCriteria_MaxAutoMLJobRuntimeInSecond != null)
            {
                requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteria.MaxAutoMLJobRuntimeInSeconds = requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteria_completionCriteria_MaxAutoMLJobRuntimeInSecond.Value;
                requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteriaIsNull = false;
            }
            System.Int32? requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteria_completionCriteria_MaxCandidate = null;
            if (cmdletContext.CompletionCriteria_MaxCandidate != null)
            {
                requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteria_completionCriteria_MaxCandidate = cmdletContext.CompletionCriteria_MaxCandidate.Value;
            }
            if (requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteria_completionCriteria_MaxCandidate != null)
            {
                requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteria.MaxCandidates = requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteria_completionCriteria_MaxCandidate.Value;
                requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteriaIsNull = false;
            }
            System.Int32? requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteria_completionCriteria_MaxRuntimePerTrainingJobInSecond = null;
            if (cmdletContext.CompletionCriteria_MaxRuntimePerTrainingJobInSecond != null)
            {
                requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteria_completionCriteria_MaxRuntimePerTrainingJobInSecond = cmdletContext.CompletionCriteria_MaxRuntimePerTrainingJobInSecond.Value;
            }
            if (requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteria_completionCriteria_MaxRuntimePerTrainingJobInSecond != null)
            {
                requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteria.MaxRuntimePerTrainingJobInSeconds = requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteria_completionCriteria_MaxRuntimePerTrainingJobInSecond.Value;
                requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteriaIsNull = false;
            }
             // determine if requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteria should be set to null
            if (requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteriaIsNull)
            {
                requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteria = null;
            }
            if (requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteria != null)
            {
                request.AutoMLJobConfig.CompletionCriteria = requestAutoMLJobConfig_autoMLJobConfig_CompletionCriteria;
                requestAutoMLJobConfigIsNull = false;
            }
            Amazon.SageMaker.Model.AutoMLSecurityConfig requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig = null;
            
             // populate SecurityConfig
            var requestAutoMLJobConfig_autoMLJobConfig_SecurityConfigIsNull = true;
            requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig = new Amazon.SageMaker.Model.AutoMLSecurityConfig();
            System.Boolean? requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_securityConfig_EnableInterContainerTrafficEncryption = null;
            if (cmdletContext.SecurityConfig_EnableInterContainerTrafficEncryption != null)
            {
                requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_securityConfig_EnableInterContainerTrafficEncryption = cmdletContext.SecurityConfig_EnableInterContainerTrafficEncryption.Value;
            }
            if (requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_securityConfig_EnableInterContainerTrafficEncryption != null)
            {
                requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig.EnableInterContainerTrafficEncryption = requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_securityConfig_EnableInterContainerTrafficEncryption.Value;
                requestAutoMLJobConfig_autoMLJobConfig_SecurityConfigIsNull = false;
            }
            System.String requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_securityConfig_VolumeKmsKeyId = null;
            if (cmdletContext.SecurityConfig_VolumeKmsKeyId != null)
            {
                requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_securityConfig_VolumeKmsKeyId = cmdletContext.SecurityConfig_VolumeKmsKeyId;
            }
            if (requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_securityConfig_VolumeKmsKeyId != null)
            {
                requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig.VolumeKmsKeyId = requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_securityConfig_VolumeKmsKeyId;
                requestAutoMLJobConfig_autoMLJobConfig_SecurityConfigIsNull = false;
            }
            Amazon.SageMaker.Model.VpcConfig requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_autoMLJobConfig_SecurityConfig_VpcConfig = null;
            
             // populate VpcConfig
            var requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_autoMLJobConfig_SecurityConfig_VpcConfigIsNull = true;
            requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_autoMLJobConfig_SecurityConfig_VpcConfig = new Amazon.SageMaker.Model.VpcConfig();
            List<System.String> requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_autoMLJobConfig_SecurityConfig_VpcConfig_vpcConfig_SecurityGroupId = null;
            if (cmdletContext.VpcConfig_SecurityGroupId != null)
            {
                requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_autoMLJobConfig_SecurityConfig_VpcConfig_vpcConfig_SecurityGroupId = cmdletContext.VpcConfig_SecurityGroupId;
            }
            if (requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_autoMLJobConfig_SecurityConfig_VpcConfig_vpcConfig_SecurityGroupId != null)
            {
                requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_autoMLJobConfig_SecurityConfig_VpcConfig.SecurityGroupIds = requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_autoMLJobConfig_SecurityConfig_VpcConfig_vpcConfig_SecurityGroupId;
                requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_autoMLJobConfig_SecurityConfig_VpcConfigIsNull = false;
            }
            List<System.String> requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_autoMLJobConfig_SecurityConfig_VpcConfig_vpcConfig_Subnet = null;
            if (cmdletContext.VpcConfig_Subnet != null)
            {
                requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_autoMLJobConfig_SecurityConfig_VpcConfig_vpcConfig_Subnet = cmdletContext.VpcConfig_Subnet;
            }
            if (requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_autoMLJobConfig_SecurityConfig_VpcConfig_vpcConfig_Subnet != null)
            {
                requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_autoMLJobConfig_SecurityConfig_VpcConfig.Subnets = requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_autoMLJobConfig_SecurityConfig_VpcConfig_vpcConfig_Subnet;
                requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_autoMLJobConfig_SecurityConfig_VpcConfigIsNull = false;
            }
             // determine if requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_autoMLJobConfig_SecurityConfig_VpcConfig should be set to null
            if (requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_autoMLJobConfig_SecurityConfig_VpcConfigIsNull)
            {
                requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_autoMLJobConfig_SecurityConfig_VpcConfig = null;
            }
            if (requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_autoMLJobConfig_SecurityConfig_VpcConfig != null)
            {
                requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig.VpcConfig = requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig_autoMLJobConfig_SecurityConfig_VpcConfig;
                requestAutoMLJobConfig_autoMLJobConfig_SecurityConfigIsNull = false;
            }
             // determine if requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig should be set to null
            if (requestAutoMLJobConfig_autoMLJobConfig_SecurityConfigIsNull)
            {
                requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig = null;
            }
            if (requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig != null)
            {
                request.AutoMLJobConfig.SecurityConfig = requestAutoMLJobConfig_autoMLJobConfig_SecurityConfig;
                requestAutoMLJobConfigIsNull = false;
            }
             // determine if request.AutoMLJobConfig should be set to null
            if (requestAutoMLJobConfigIsNull)
            {
                request.AutoMLJobConfig = null;
            }
            if (cmdletContext.AutoMLJobName != null)
            {
                request.AutoMLJobName = cmdletContext.AutoMLJobName;
            }
            
             // populate AutoMLJobObjective
            var requestAutoMLJobObjectiveIsNull = true;
            request.AutoMLJobObjective = new Amazon.SageMaker.Model.AutoMLJobObjective();
            Amazon.SageMaker.AutoMLMetricEnum requestAutoMLJobObjective_autoMLJobObjective_MetricName = null;
            if (cmdletContext.AutoMLJobObjective_MetricName != null)
            {
                requestAutoMLJobObjective_autoMLJobObjective_MetricName = cmdletContext.AutoMLJobObjective_MetricName;
            }
            if (requestAutoMLJobObjective_autoMLJobObjective_MetricName != null)
            {
                request.AutoMLJobObjective.MetricName = requestAutoMLJobObjective_autoMLJobObjective_MetricName;
                requestAutoMLJobObjectiveIsNull = false;
            }
             // determine if request.AutoMLJobObjective should be set to null
            if (requestAutoMLJobObjectiveIsNull)
            {
                request.AutoMLJobObjective = null;
            }
            if (cmdletContext.GenerateCandidateDefinitionsOnly != null)
            {
                request.GenerateCandidateDefinitionsOnly = cmdletContext.GenerateCandidateDefinitionsOnly.Value;
            }
            if (cmdletContext.InputDataConfig != null)
            {
                request.InputDataConfig = cmdletContext.InputDataConfig;
            }
            
             // populate ModelDeployConfig
            var requestModelDeployConfigIsNull = true;
            request.ModelDeployConfig = new Amazon.SageMaker.Model.ModelDeployConfig();
            System.Boolean? requestModelDeployConfig_modelDeployConfig_AutoGenerateEndpointName = null;
            if (cmdletContext.ModelDeployConfig_AutoGenerateEndpointName != null)
            {
                requestModelDeployConfig_modelDeployConfig_AutoGenerateEndpointName = cmdletContext.ModelDeployConfig_AutoGenerateEndpointName.Value;
            }
            if (requestModelDeployConfig_modelDeployConfig_AutoGenerateEndpointName != null)
            {
                request.ModelDeployConfig.AutoGenerateEndpointName = requestModelDeployConfig_modelDeployConfig_AutoGenerateEndpointName.Value;
                requestModelDeployConfigIsNull = false;
            }
            System.String requestModelDeployConfig_modelDeployConfig_EndpointName = null;
            if (cmdletContext.ModelDeployConfig_EndpointName != null)
            {
                requestModelDeployConfig_modelDeployConfig_EndpointName = cmdletContext.ModelDeployConfig_EndpointName;
            }
            if (requestModelDeployConfig_modelDeployConfig_EndpointName != null)
            {
                request.ModelDeployConfig.EndpointName = requestModelDeployConfig_modelDeployConfig_EndpointName;
                requestModelDeployConfigIsNull = false;
            }
             // determine if request.ModelDeployConfig should be set to null
            if (requestModelDeployConfigIsNull)
            {
                request.ModelDeployConfig = null;
            }
            
             // populate OutputDataConfig
            var requestOutputDataConfigIsNull = true;
            request.OutputDataConfig = new Amazon.SageMaker.Model.AutoMLOutputDataConfig();
            System.String requestOutputDataConfig_outputDataConfig_KmsKeyId = null;
            if (cmdletContext.OutputDataConfig_KmsKeyId != null)
            {
                requestOutputDataConfig_outputDataConfig_KmsKeyId = cmdletContext.OutputDataConfig_KmsKeyId;
            }
            if (requestOutputDataConfig_outputDataConfig_KmsKeyId != null)
            {
                request.OutputDataConfig.KmsKeyId = requestOutputDataConfig_outputDataConfig_KmsKeyId;
                requestOutputDataConfigIsNull = false;
            }
            System.String requestOutputDataConfig_outputDataConfig_S3OutputPath = null;
            if (cmdletContext.OutputDataConfig_S3OutputPath != null)
            {
                requestOutputDataConfig_outputDataConfig_S3OutputPath = cmdletContext.OutputDataConfig_S3OutputPath;
            }
            if (requestOutputDataConfig_outputDataConfig_S3OutputPath != null)
            {
                request.OutputDataConfig.S3OutputPath = requestOutputDataConfig_outputDataConfig_S3OutputPath;
                requestOutputDataConfigIsNull = false;
            }
             // determine if request.OutputDataConfig should be set to null
            if (requestOutputDataConfigIsNull)
            {
                request.OutputDataConfig = null;
            }
            if (cmdletContext.ProblemType != null)
            {
                request.ProblemType = cmdletContext.ProblemType;
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
        
        private Amazon.SageMaker.Model.CreateAutoMLJobResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateAutoMLJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateAutoMLJob");
            try
            {
                #if DESKTOP
                return client.CreateAutoMLJob(request);
                #elif CORECLR
                return client.CreateAutoMLJobAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.SageMaker.Model.AutoMLAlgorithmConfig> CandidateGenerationConfig_AlgorithmsConfig { get; set; }
            public System.String CandidateGenerationConfig_FeatureSpecificationS3Uri { get; set; }
            public System.Int32? CompletionCriteria_MaxAutoMLJobRuntimeInSecond { get; set; }
            public System.Int32? CompletionCriteria_MaxCandidate { get; set; }
            public System.Int32? CompletionCriteria_MaxRuntimePerTrainingJobInSecond { get; set; }
            public System.Single? DataSplitConfig_ValidationFraction { get; set; }
            public Amazon.SageMaker.AutoMLMode AutoMLJobConfig_Mode { get; set; }
            public System.Boolean? SecurityConfig_EnableInterContainerTrafficEncryption { get; set; }
            public System.String SecurityConfig_VolumeKmsKeyId { get; set; }
            public List<System.String> VpcConfig_SecurityGroupId { get; set; }
            public List<System.String> VpcConfig_Subnet { get; set; }
            public System.String AutoMLJobName { get; set; }
            public Amazon.SageMaker.AutoMLMetricEnum AutoMLJobObjective_MetricName { get; set; }
            public System.Boolean? GenerateCandidateDefinitionsOnly { get; set; }
            public List<Amazon.SageMaker.Model.AutoMLChannel> InputDataConfig { get; set; }
            public System.Boolean? ModelDeployConfig_AutoGenerateEndpointName { get; set; }
            public System.String ModelDeployConfig_EndpointName { get; set; }
            public System.String OutputDataConfig_KmsKeyId { get; set; }
            public System.String OutputDataConfig_S3OutputPath { get; set; }
            public Amazon.SageMaker.ProblemType ProblemType { get; set; }
            public System.String RoleArn { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateAutoMLJobResponse, NewSMAutoMLJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AutoMLJobArn;
        }
        
    }
}
