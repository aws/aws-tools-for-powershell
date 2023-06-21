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
    /// Creates an Autopilot job also referred to as Autopilot experiment or AutoML job V2.
    /// 
    ///  <note><para><a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_CreateAutoMLJobV2.html">CreateAutoMLJobV2</a>
    /// and <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_DescribeAutoMLJobV2.html">DescribeAutoMLJobV2</a>
    /// are new versions of <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_CreateAutoMLJob.html">CreateAutoMLJob</a>
    /// and <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_DescribeAutoMLJob.html">DescribeAutoMLJob</a>
    /// which offer backward compatibility.
    /// </para><para><code>CreateAutoMLJobV2</code> can manage tabular problem types identical to those
    /// of its previous version <code>CreateAutoMLJob</code>, as well as non-tabular problem
    /// types such as image or text classification.
    /// </para><para>
    /// Find guidelines about how to migrate a <code>CreateAutoMLJob</code> to <code>CreateAutoMLJobV2</code>
    /// in <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/autopilot-automate-model-development-create-experiment-api.html#autopilot-create-experiment-api-migrate-v1-v2">Migrate
    /// a CreateAutoMLJob to CreateAutoMLJobV2</a>.
    /// </para></note><para>
    /// For the list of available problem types supported by <code>CreateAutoMLJobV2</code>,
    /// see <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_AutoMLProblemTypeConfig.html">AutoMLProblemTypeConfig</a>.
    /// </para><para>
    /// You can find the best-performing model after you run an AutoML job V2 by calling <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_DescribeAutoMLJobV2.html">DescribeAutoMLJobV2</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SMAutoMLJobV2", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateAutoMLJobV2 API operation.", Operation = new[] {"CreateAutoMLJobV2"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateAutoMLJobV2Response))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateAutoMLJobV2Response",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateAutoMLJobV2Response) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSMAutoMLJobV2Cmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        #region Parameter CandidateGenerationConfig_AlgorithmsConfig
        /// <summary>
        /// <para>
        /// <para>Stores the configuration information for the selection of algorithms used to train
        /// model candidates on tabular data.</para><para>The list of available algorithms to choose from depends on the training mode set in
        /// <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_TabularJobConfig.html"><code>TabularJobConfig.Mode</code></a>.</para><ul><li><para><code>AlgorithmsConfig</code> should not be set in <code>AUTO</code> training mode.</para></li><li><para>When <code>AlgorithmsConfig</code> is provided, one <code>AutoMLAlgorithms</code>
        /// attribute must be set and one only.</para><para>If the list of algorithms provided as values for <code>AutoMLAlgorithms</code> is
        /// empty, <code>CandidateGenerationConfig</code> uses the full set of algorithms for
        /// the given training mode.</para></li><li><para>When <code>AlgorithmsConfig</code> is not provided, <code>CandidateGenerationConfig</code>
        /// uses the full set of algorithms for the given training mode.</para></li></ul><para>For the list of all algorithms per problem type and training mode, see <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_AutoMLAlgorithmConfig.html">
        /// AutoMLAlgorithmConfig</a>.</para><para>For more information on each algorithm, see the <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/autopilot-model-support-validation.html#autopilot-algorithm-support">Algorithm
        /// support</a> section in Autopilot developer guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLProblemTypeConfig_TabularJobConfig_CandidateGenerationConfig_AlgorithmsConfig")]
        public Amazon.SageMaker.Model.AutoMLAlgorithmConfig[] CandidateGenerationConfig_AlgorithmsConfig { get; set; }
        #endregion
        
        #region Parameter ModelDeployConfig_AutoGenerateEndpointName
        /// <summary>
        /// <para>
        /// <para>Set to <code>True</code> to automatically generate an endpoint name for a one-click
        /// Autopilot model deployment; set to <code>False</code> otherwise. The default value
        /// is <code>False</code>.</para><note><para>If you set <code>AutoGenerateEndpointName</code> to <code>True</code>, do not specify
        /// the <code>EndpointName</code>; otherwise a 400 error is thrown.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ModelDeployConfig_AutoGenerateEndpointName { get; set; }
        #endregion
        
        #region Parameter AutoMLJobInputDataConfig
        /// <summary>
        /// <para>
        /// <para>An array of channel objects describing the input data and their location. Each channel
        /// is a named input source. Similar to the <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_CreateAutoMLJob.html#sagemaker-CreateAutoMLJob-request-InputDataConfig">InputDataConfig</a>
        /// attribute in the <code>CreateAutoMLJob</code> input parameters. The supported formats
        /// depend on the problem type:</para><ul><li><para>For Tabular problem types: <code>S3Prefix</code>, <code>ManifestFile</code>.</para></li><li><para>For ImageClassification: <code>S3Prefix</code>, <code>ManifestFile</code>, <code>AugmentedManifestFile</code>.</para></li><li><para>For TextClassification: <code>S3Prefix</code>.</para></li></ul>
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
        public Amazon.SageMaker.Model.AutoMLJobChannel[] AutoMLJobInputDataConfig { get; set; }
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
        
        #region Parameter TextClassificationJobConfig_ContentColumn
        /// <summary>
        /// <para>
        /// <para>The name of the column used to provide the sentences to be classified. It should not
        /// be the same as the target column (Required).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLProblemTypeConfig_TextClassificationJobConfig_ContentColumn")]
        public System.String TextClassificationJobConfig_ContentColumn { get; set; }
        #endregion
        
        #region Parameter SecurityConfig_EnableInterContainerTrafficEncryption
        /// <summary>
        /// <para>
        /// <para>Whether to use traffic encryption between the container layers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SecurityConfig_EnableInterContainerTrafficEncryption { get; set; }
        #endregion
        
        #region Parameter ModelDeployConfig_EndpointName
        /// <summary>
        /// <para>
        /// <para>Specifies the endpoint name to use for a one-click Autopilot model deployment if the
        /// endpoint name is not generated automatically.</para><note><para>Specify the <code>EndpointName</code> if and only if you set <code>AutoGenerateEndpointName</code>
        /// to <code>False</code>; otherwise a 400 error is thrown.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ModelDeployConfig_EndpointName { get; set; }
        #endregion
        
        #region Parameter TabularJobConfig_FeatureSpecificationS3Uri
        /// <summary>
        /// <para>
        /// <para>A URL to the Amazon S3 data source containing selected features from the input data
        /// source to run an Autopilot job V2. You can input <code>FeatureAttributeNames</code>
        /// (optional) in JSON format as shown below: </para><para><code>{ "FeatureAttributeNames":["col1", "col2", ...] }</code>.</para><para>You can also specify the data type of the feature (optional) in the format shown below:</para><para><code>{ "FeatureDataTypes":{"col1":"numeric", "col2":"categorical" ... } }</code></para><note><para>These column keys may not include the target column.</para></note><para>In ensembling mode, Autopilot only supports the following data types: <code>numeric</code>,
        /// <code>categorical</code>, <code>text</code>, and <code>datetime</code>. In HPO mode,
        /// Autopilot can support <code>numeric</code>, <code>categorical</code>, <code>text</code>,
        /// <code>datetime</code>, and <code>sequence</code>.</para><para>If only <code>FeatureDataTypes</code> is provided, the column keys (<code>col1</code>,
        /// <code>col2</code>,..) should be a subset of the column names in the input data. </para><para>If both <code>FeatureDataTypes</code> and <code>FeatureAttributeNames</code> are provided,
        /// then the column keys should be a subset of the column names provided in <code>FeatureAttributeNames</code>.
        /// </para><para>The key name <code>FeatureAttributeNames</code> is fixed. The values listed in <code>["col1",
        /// "col2", ...]</code> are case sensitive and should be a list of strings containing
        /// unique values that are a subset of the column names in the input data. The list of
        /// columns provided must not include the target column.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLProblemTypeConfig_TabularJobConfig_FeatureSpecificationS3Uri")]
        public System.String TabularJobConfig_FeatureSpecificationS3Uri { get; set; }
        #endregion
        
        #region Parameter TabularJobConfig_GenerateCandidateDefinitionsOnly
        /// <summary>
        /// <para>
        /// <para>Generates possible candidates without training the models. A model candidate is a
        /// combination of data preprocessors, algorithms, and algorithm parameter settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLProblemTypeConfig_TabularJobConfig_GenerateCandidateDefinitionsOnly")]
        public System.Boolean? TabularJobConfig_GenerateCandidateDefinitionsOnly { get; set; }
        #endregion
        
        #region Parameter OutputDataConfig_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Key Management Service (KMS) encryption key ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputDataConfig_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSeconds
        /// <summary>
        /// <para>
        /// <para>The maximum runtime, in seconds, an AutoML job has to complete.</para><para>If an AutoML job exceeds the maximum runtime, the job is stopped automatically and
        /// its processing is ended gracefully. The AutoML job identifies the best model whose
        /// training was completed and marks it as the best-performing model. Any unfinished steps
        /// of the job, such as automatic one-click Autopilot model deployment, are not completed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSeconds { get; set; }
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
        [Alias("AutoMLProblemTypeConfig_TabularJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSeconds")]
        public System.Int32? CompletionCriteria_MaxAutoMLJobRuntimeInSecond { get; set; }
        #endregion
        
        #region Parameter AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSeconds
        /// <summary>
        /// <para>
        /// <para>The maximum runtime, in seconds, an AutoML job has to complete.</para><para>If an AutoML job exceeds the maximum runtime, the job is stopped automatically and
        /// its processing is ended gracefully. The AutoML job identifies the best model whose
        /// training was completed and marks it as the best-performing model. Any unfinished steps
        /// of the job, such as automatic one-click Autopilot model deployment, are not completed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSeconds { get; set; }
        #endregion
        
        #region Parameter AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxCandidates
        /// <summary>
        /// <para>
        /// <para>The maximum number of times a training job is allowed to run.</para><para>For job V2s (jobs created by calling <code>CreateAutoMLJobV2</code>), the supported
        /// value is 1.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxCandidates { get; set; }
        #endregion
        
        #region Parameter CompletionCriteria_MaxCandidate
        /// <summary>
        /// <para>
        /// <para>The maximum number of times a training job is allowed to run.</para><para>For job V2s (jobs created by calling <code>CreateAutoMLJobV2</code>), the supported
        /// value is 1.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLProblemTypeConfig_TabularJobConfig_CompletionCriteria_MaxCandidates")]
        public System.Int32? CompletionCriteria_MaxCandidate { get; set; }
        #endregion
        
        #region Parameter AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxCandidates
        /// <summary>
        /// <para>
        /// <para>The maximum number of times a training job is allowed to run.</para><para>For job V2s (jobs created by calling <code>CreateAutoMLJobV2</code>), the supported
        /// value is 1.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxCandidates { get; set; }
        #endregion
        
        #region Parameter AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSeconds
        /// <summary>
        /// <para>
        /// <para>The maximum time, in seconds, that each training job executed inside hyperparameter
        /// tuning is allowed to run as part of a hyperparameter tuning job. For more information,
        /// see the <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_StoppingCondition.html">StoppingCondition</a>
        /// used by the <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_CreateHyperParameterTuningJob.html">CreateHyperParameterTuningJob</a>
        /// action.</para><para>For job V2s (jobs created by calling <code>CreateAutoMLJobV2</code>), this field controls
        /// the runtime of the job candidate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSeconds { get; set; }
        #endregion
        
        #region Parameter CompletionCriteria_MaxRuntimePerTrainingJobInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum time, in seconds, that each training job executed inside hyperparameter
        /// tuning is allowed to run as part of a hyperparameter tuning job. For more information,
        /// see the <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_StoppingCondition.html">StoppingCondition</a>
        /// used by the <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_CreateHyperParameterTuningJob.html">CreateHyperParameterTuningJob</a>
        /// action.</para><para>For job V2s (jobs created by calling <code>CreateAutoMLJobV2</code>), this field controls
        /// the runtime of the job candidate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLProblemTypeConfig_TabularJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSeconds")]
        public System.Int32? CompletionCriteria_MaxRuntimePerTrainingJobInSecond { get; set; }
        #endregion
        
        #region Parameter AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSeconds
        /// <summary>
        /// <para>
        /// <para>The maximum time, in seconds, that each training job executed inside hyperparameter
        /// tuning is allowed to run as part of a hyperparameter tuning job. For more information,
        /// see the <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_StoppingCondition.html">StoppingCondition</a>
        /// used by the <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_CreateHyperParameterTuningJob.html">CreateHyperParameterTuningJob</a>
        /// action.</para><para>For job V2s (jobs created by calling <code>CreateAutoMLJobV2</code>), this field controls
        /// the runtime of the job candidate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSeconds { get; set; }
        #endregion
        
        #region Parameter AutoMLJobObjective_MetricName
        /// <summary>
        /// <para>
        /// <para>The name of the objective metric used to measure the predictive quality of a machine
        /// learning system. During training, the model's parameters are updated iteratively to
        /// optimize its performance based on the feedback provided by the objective metric when
        /// evaluating the model on the validation dataset.</para><para>For the list of all available metrics supported by Autopilot, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/autopilot-metrics-validation.html#autopilot-metrics">Autopilot
        /// metrics</a>.</para><para>If you do not specify a metric explicitly, the default behavior is to automatically
        /// use:</para><ul><li><para>For tabular problem types:</para><ul><li><para>Regression: <code>MSE</code>.</para></li><li><para>Binary classification: <code>F1</code>.</para></li><li><para>Multiclass classification: <code>Accuracy</code>.</para></li></ul></li><li><para>For image or text classification problem types: <code>Accuracy</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.AutoMLMetricEnum")]
        public Amazon.SageMaker.AutoMLMetricEnum AutoMLJobObjective_MetricName { get; set; }
        #endregion
        
        #region Parameter TabularJobConfig_Mode
        /// <summary>
        /// <para>
        /// <para>The method that Autopilot uses to train the data. You can either specify the mode
        /// manually or let Autopilot choose for you based on the dataset size by selecting <code>AUTO</code>.
        /// In <code>AUTO</code> mode, Autopilot chooses <code>ENSEMBLING</code> for datasets
        /// smaller than 100 MB, and <code>HYPERPARAMETER_TUNING</code> for larger ones.</para><para>The <code>ENSEMBLING</code> mode uses a multi-stack ensemble model to predict classification
        /// and regression tasks directly from your dataset. This machine learning mode combines
        /// several base models to produce an optimal predictive model. It then uses a stacking
        /// ensemble method to combine predictions from contributing members. A multi-stack ensemble
        /// model can provide better performance over a single model by combining the predictive
        /// capabilities of multiple models. See <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/autopilot-model-support-validation.html#autopilot-algorithm-support">Autopilot
        /// algorithm support</a> for a list of algorithms supported by <code>ENSEMBLING</code>
        /// mode.</para><para>The <code>HYPERPARAMETER_TUNING</code> (HPO) mode uses the best hyperparameters to
        /// train the best version of a model. HPO automatically selects an algorithm for the
        /// type of problem you want to solve. Then HPO finds the best hyperparameters according
        /// to your objective metric. See <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/autopilot-model-support-validation.html#autopilot-algorithm-support">Autopilot
        /// algorithm support</a> for a list of algorithms supported by <code>HYPERPARAMETER_TUNING</code>
        /// mode.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLProblemTypeConfig_TabularJobConfig_Mode")]
        [AWSConstantClassSource("Amazon.SageMaker.AutoMLMode")]
        public Amazon.SageMaker.AutoMLMode TabularJobConfig_Mode { get; set; }
        #endregion
        
        #region Parameter TabularJobConfig_ProblemType
        /// <summary>
        /// <para>
        /// <para>The type of supervised learning problem available for the model candidates of the
        /// AutoML job V2. For more information, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/autopilot-datasets-problem-types.html#autopilot-problem-types">
        /// Amazon SageMaker Autopilot problem types</a>.</para><note><para>You must either specify the type of supervised learning problem in <code>ProblemType</code>
        /// and provide the <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_CreateAutoMLJobV2.html#sagemaker-CreateAutoMLJobV2-request-AutoMLJobObjective">AutoMLJobObjective</a>
        /// metric, or none at all.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLProblemTypeConfig_TabularJobConfig_ProblemType")]
        [AWSConstantClassSource("Amazon.SageMaker.ProblemType")]
        public Amazon.SageMaker.ProblemType TabularJobConfig_ProblemType { get; set; }
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
        /// <para>The Amazon S3 output path. Must be 128 characters or less.</para>
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
        
        #region Parameter TabularJobConfig_SampleWeightAttributeName
        /// <summary>
        /// <para>
        /// <para>If specified, this column name indicates which column of the dataset should be treated
        /// as sample weights for use by the objective metric during the training, evaluation,
        /// and the selection of the best model. This column is not considered as a predictive
        /// feature. For more information on Autopilot metrics, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/autopilot-metrics-validation.html">Metrics
        /// and validation</a>.</para><para>Sample weights should be numeric, non-negative, with larger values indicating which
        /// rows are more important than others. Data points that have invalid or no weight value
        /// are excluded.</para><para>Support for sample weights is available in <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_AutoMLAlgorithmConfig.html">Ensembling</a>
        /// mode only.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLProblemTypeConfig_TabularJobConfig_SampleWeightAttributeName")]
        public System.String TabularJobConfig_SampleWeightAttributeName { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The VPC security group IDs, in the form sg-xxxxxxxx. Specify the security groups for
        /// the VPC that is specified in the <code>Subnets</code> field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityConfig_VpcConfig_SecurityGroupIds")]
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
        [Alias("SecurityConfig_VpcConfig_Subnets")]
        public System.String[] VpcConfig_Subnet { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of key-value pairs. You can use tags to categorize your Amazon Web Services
        /// resources in different ways, such as by purpose, owner, or environment. For more information,
        /// see <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">Tagging
        /// Amazon Web ServicesResources</a>. Tag keys must be unique per resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TabularJobConfig_TargetAttributeName
        /// <summary>
        /// <para>
        /// <para>The name of the target variable in supervised learning, usually represented by 'y'.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLProblemTypeConfig_TabularJobConfig_TargetAttributeName")]
        public System.String TabularJobConfig_TargetAttributeName { get; set; }
        #endregion
        
        #region Parameter TextClassificationJobConfig_TargetLabelColumn
        /// <summary>
        /// <para>
        /// <para>The name of the column used to provide the class labels. It should not be same as
        /// the content column (Required).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLProblemTypeConfig_TextClassificationJobConfig_TargetLabelColumn")]
        public System.String TextClassificationJobConfig_TargetLabelColumn { get; set; }
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
        public System.Single? DataSplitConfig_ValidationFraction { get; set; }
        #endregion
        
        #region Parameter SecurityConfig_VolumeKmsKeyId
        /// <summary>
        /// <para>
        /// <para>The key used to encrypt stored data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SecurityConfig_VolumeKmsKeyId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AutoMLJobArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateAutoMLJobV2Response).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateAutoMLJobV2Response will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AutoMLJobArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AutoMLJobName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AutoMLJobName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AutoMLJobName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AutoMLJobName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMAutoMLJobV2 (CreateAutoMLJobV2)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateAutoMLJobV2Response, NewSMAutoMLJobV2Cmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AutoMLJobName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AutoMLJobInputDataConfig != null)
            {
                context.AutoMLJobInputDataConfig = new List<Amazon.SageMaker.Model.AutoMLJobChannel>(this.AutoMLJobInputDataConfig);
            }
            #if MODULAR
            if (this.AutoMLJobInputDataConfig == null && ParameterWasBound(nameof(this.AutoMLJobInputDataConfig)))
            {
                WriteWarning("You are passing $null as a value for parameter AutoMLJobInputDataConfig which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AutoMLJobName = this.AutoMLJobName;
            #if MODULAR
            if (this.AutoMLJobName == null && ParameterWasBound(nameof(this.AutoMLJobName)))
            {
                WriteWarning("You are passing $null as a value for parameter AutoMLJobName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AutoMLJobObjective_MetricName = this.AutoMLJobObjective_MetricName;
            context.AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSeconds = this.AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSeconds;
            context.AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxCandidates = this.AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxCandidates;
            context.AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSeconds = this.AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSeconds;
            if (this.CandidateGenerationConfig_AlgorithmsConfig != null)
            {
                context.CandidateGenerationConfig_AlgorithmsConfig = new List<Amazon.SageMaker.Model.AutoMLAlgorithmConfig>(this.CandidateGenerationConfig_AlgorithmsConfig);
            }
            context.CompletionCriteria_MaxAutoMLJobRuntimeInSecond = this.CompletionCriteria_MaxAutoMLJobRuntimeInSecond;
            context.CompletionCriteria_MaxCandidate = this.CompletionCriteria_MaxCandidate;
            context.CompletionCriteria_MaxRuntimePerTrainingJobInSecond = this.CompletionCriteria_MaxRuntimePerTrainingJobInSecond;
            context.TabularJobConfig_FeatureSpecificationS3Uri = this.TabularJobConfig_FeatureSpecificationS3Uri;
            context.TabularJobConfig_GenerateCandidateDefinitionsOnly = this.TabularJobConfig_GenerateCandidateDefinitionsOnly;
            context.TabularJobConfig_Mode = this.TabularJobConfig_Mode;
            context.TabularJobConfig_ProblemType = this.TabularJobConfig_ProblemType;
            context.TabularJobConfig_SampleWeightAttributeName = this.TabularJobConfig_SampleWeightAttributeName;
            context.TabularJobConfig_TargetAttributeName = this.TabularJobConfig_TargetAttributeName;
            context.AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSeconds = this.AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSeconds;
            context.AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxCandidates = this.AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxCandidates;
            context.AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSeconds = this.AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSeconds;
            context.TextClassificationJobConfig_ContentColumn = this.TextClassificationJobConfig_ContentColumn;
            context.TextClassificationJobConfig_TargetLabelColumn = this.TextClassificationJobConfig_TargetLabelColumn;
            context.DataSplitConfig_ValidationFraction = this.DataSplitConfig_ValidationFraction;
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
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.SageMaker.Model.CreateAutoMLJobV2Request();
            
            if (cmdletContext.AutoMLJobInputDataConfig != null)
            {
                request.AutoMLJobInputDataConfig = cmdletContext.AutoMLJobInputDataConfig;
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
            
             // populate AutoMLProblemTypeConfig
            var requestAutoMLProblemTypeConfigIsNull = true;
            request.AutoMLProblemTypeConfig = new Amazon.SageMaker.Model.AutoMLProblemTypeConfig();
            Amazon.SageMaker.Model.ImageClassificationJobConfig requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig = null;
            
             // populate ImageClassificationJobConfig
            var requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfigIsNull = true;
            requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig = new Amazon.SageMaker.Model.ImageClassificationJobConfig();
            Amazon.SageMaker.Model.AutoMLJobCompletionCriteria requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria = null;
            
             // populate CompletionCriteria
            var requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteriaIsNull = true;
            requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria = new Amazon.SageMaker.Model.AutoMLJobCompletionCriteria();
            System.Int32? requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSeconds = null;
            if (cmdletContext.AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSeconds != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSeconds = cmdletContext.AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSeconds.Value;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSeconds != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria.MaxAutoMLJobRuntimeInSeconds = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSeconds.Value;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteriaIsNull = false;
            }
            System.Int32? requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxCandidates = null;
            if (cmdletContext.AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxCandidates != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxCandidates = cmdletContext.AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxCandidates.Value;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxCandidates != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria.MaxCandidates = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxCandidates.Value;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteriaIsNull = false;
            }
            System.Int32? requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSeconds = null;
            if (cmdletContext.AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSeconds != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSeconds = cmdletContext.AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSeconds.Value;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSeconds != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria.MaxRuntimePerTrainingJobInSeconds = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSeconds.Value;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteriaIsNull = false;
            }
             // determine if requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria should be set to null
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteriaIsNull)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria = null;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig.CompletionCriteria = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfigIsNull = false;
            }
             // determine if requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig should be set to null
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfigIsNull)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig = null;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig != null)
            {
                request.AutoMLProblemTypeConfig.ImageClassificationJobConfig = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig;
                requestAutoMLProblemTypeConfigIsNull = false;
            }
            Amazon.SageMaker.Model.TextClassificationJobConfig requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig = null;
            
             // populate TextClassificationJobConfig
            var requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfigIsNull = true;
            requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig = new Amazon.SageMaker.Model.TextClassificationJobConfig();
            System.String requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_textClassificationJobConfig_ContentColumn = null;
            if (cmdletContext.TextClassificationJobConfig_ContentColumn != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_textClassificationJobConfig_ContentColumn = cmdletContext.TextClassificationJobConfig_ContentColumn;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_textClassificationJobConfig_ContentColumn != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig.ContentColumn = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_textClassificationJobConfig_ContentColumn;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfigIsNull = false;
            }
            System.String requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_textClassificationJobConfig_TargetLabelColumn = null;
            if (cmdletContext.TextClassificationJobConfig_TargetLabelColumn != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_textClassificationJobConfig_TargetLabelColumn = cmdletContext.TextClassificationJobConfig_TargetLabelColumn;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_textClassificationJobConfig_TargetLabelColumn != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig.TargetLabelColumn = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_textClassificationJobConfig_TargetLabelColumn;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfigIsNull = false;
            }
            Amazon.SageMaker.Model.AutoMLJobCompletionCriteria requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria = null;
            
             // populate CompletionCriteria
            var requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteriaIsNull = true;
            requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria = new Amazon.SageMaker.Model.AutoMLJobCompletionCriteria();
            System.Int32? requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSeconds = null;
            if (cmdletContext.AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSeconds != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSeconds = cmdletContext.AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSeconds.Value;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSeconds != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria.MaxAutoMLJobRuntimeInSeconds = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSeconds.Value;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteriaIsNull = false;
            }
            System.Int32? requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxCandidates = null;
            if (cmdletContext.AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxCandidates != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxCandidates = cmdletContext.AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxCandidates.Value;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxCandidates != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria.MaxCandidates = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxCandidates.Value;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteriaIsNull = false;
            }
            System.Int32? requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSeconds = null;
            if (cmdletContext.AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSeconds != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSeconds = cmdletContext.AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSeconds.Value;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSeconds != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria.MaxRuntimePerTrainingJobInSeconds = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSeconds.Value;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteriaIsNull = false;
            }
             // determine if requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria should be set to null
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteriaIsNull)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria = null;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig.CompletionCriteria = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfigIsNull = false;
            }
             // determine if requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig should be set to null
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfigIsNull)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig = null;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig != null)
            {
                request.AutoMLProblemTypeConfig.TextClassificationJobConfig = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig;
                requestAutoMLProblemTypeConfigIsNull = false;
            }
            Amazon.SageMaker.Model.TabularJobConfig requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig = null;
            
             // populate TabularJobConfig
            var requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfigIsNull = true;
            requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig = new Amazon.SageMaker.Model.TabularJobConfig();
            System.String requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_tabularJobConfig_FeatureSpecificationS3Uri = null;
            if (cmdletContext.TabularJobConfig_FeatureSpecificationS3Uri != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_tabularJobConfig_FeatureSpecificationS3Uri = cmdletContext.TabularJobConfig_FeatureSpecificationS3Uri;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_tabularJobConfig_FeatureSpecificationS3Uri != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig.FeatureSpecificationS3Uri = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_tabularJobConfig_FeatureSpecificationS3Uri;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfigIsNull = false;
            }
            System.Boolean? requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_tabularJobConfig_GenerateCandidateDefinitionsOnly = null;
            if (cmdletContext.TabularJobConfig_GenerateCandidateDefinitionsOnly != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_tabularJobConfig_GenerateCandidateDefinitionsOnly = cmdletContext.TabularJobConfig_GenerateCandidateDefinitionsOnly.Value;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_tabularJobConfig_GenerateCandidateDefinitionsOnly != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig.GenerateCandidateDefinitionsOnly = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_tabularJobConfig_GenerateCandidateDefinitionsOnly.Value;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfigIsNull = false;
            }
            Amazon.SageMaker.AutoMLMode requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_tabularJobConfig_Mode = null;
            if (cmdletContext.TabularJobConfig_Mode != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_tabularJobConfig_Mode = cmdletContext.TabularJobConfig_Mode;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_tabularJobConfig_Mode != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig.Mode = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_tabularJobConfig_Mode;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfigIsNull = false;
            }
            Amazon.SageMaker.ProblemType requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_tabularJobConfig_ProblemType = null;
            if (cmdletContext.TabularJobConfig_ProblemType != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_tabularJobConfig_ProblemType = cmdletContext.TabularJobConfig_ProblemType;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_tabularJobConfig_ProblemType != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig.ProblemType = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_tabularJobConfig_ProblemType;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfigIsNull = false;
            }
            System.String requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_tabularJobConfig_SampleWeightAttributeName = null;
            if (cmdletContext.TabularJobConfig_SampleWeightAttributeName != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_tabularJobConfig_SampleWeightAttributeName = cmdletContext.TabularJobConfig_SampleWeightAttributeName;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_tabularJobConfig_SampleWeightAttributeName != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig.SampleWeightAttributeName = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_tabularJobConfig_SampleWeightAttributeName;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfigIsNull = false;
            }
            System.String requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_tabularJobConfig_TargetAttributeName = null;
            if (cmdletContext.TabularJobConfig_TargetAttributeName != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_tabularJobConfig_TargetAttributeName = cmdletContext.TabularJobConfig_TargetAttributeName;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_tabularJobConfig_TargetAttributeName != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig.TargetAttributeName = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_tabularJobConfig_TargetAttributeName;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfigIsNull = false;
            }
            Amazon.SageMaker.Model.CandidateGenerationConfig requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CandidateGenerationConfig = null;
            
             // populate CandidateGenerationConfig
            var requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CandidateGenerationConfigIsNull = true;
            requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CandidateGenerationConfig = new Amazon.SageMaker.Model.CandidateGenerationConfig();
            List<Amazon.SageMaker.Model.AutoMLAlgorithmConfig> requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CandidateGenerationConfig_candidateGenerationConfig_AlgorithmsConfig = null;
            if (cmdletContext.CandidateGenerationConfig_AlgorithmsConfig != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CandidateGenerationConfig_candidateGenerationConfig_AlgorithmsConfig = cmdletContext.CandidateGenerationConfig_AlgorithmsConfig;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CandidateGenerationConfig_candidateGenerationConfig_AlgorithmsConfig != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CandidateGenerationConfig.AlgorithmsConfig = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CandidateGenerationConfig_candidateGenerationConfig_AlgorithmsConfig;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CandidateGenerationConfigIsNull = false;
            }
             // determine if requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CandidateGenerationConfig should be set to null
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CandidateGenerationConfigIsNull)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CandidateGenerationConfig = null;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CandidateGenerationConfig != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig.CandidateGenerationConfig = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CandidateGenerationConfig;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfigIsNull = false;
            }
            Amazon.SageMaker.Model.AutoMLJobCompletionCriteria requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CompletionCriteria = null;
            
             // populate CompletionCriteria
            var requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CompletionCriteriaIsNull = true;
            requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CompletionCriteria = new Amazon.SageMaker.Model.AutoMLJobCompletionCriteria();
            System.Int32? requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CompletionCriteria_completionCriteria_MaxAutoMLJobRuntimeInSecond = null;
            if (cmdletContext.CompletionCriteria_MaxAutoMLJobRuntimeInSecond != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CompletionCriteria_completionCriteria_MaxAutoMLJobRuntimeInSecond = cmdletContext.CompletionCriteria_MaxAutoMLJobRuntimeInSecond.Value;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CompletionCriteria_completionCriteria_MaxAutoMLJobRuntimeInSecond != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CompletionCriteria.MaxAutoMLJobRuntimeInSeconds = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CompletionCriteria_completionCriteria_MaxAutoMLJobRuntimeInSecond.Value;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CompletionCriteriaIsNull = false;
            }
            System.Int32? requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CompletionCriteria_completionCriteria_MaxCandidate = null;
            if (cmdletContext.CompletionCriteria_MaxCandidate != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CompletionCriteria_completionCriteria_MaxCandidate = cmdletContext.CompletionCriteria_MaxCandidate.Value;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CompletionCriteria_completionCriteria_MaxCandidate != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CompletionCriteria.MaxCandidates = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CompletionCriteria_completionCriteria_MaxCandidate.Value;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CompletionCriteriaIsNull = false;
            }
            System.Int32? requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CompletionCriteria_completionCriteria_MaxRuntimePerTrainingJobInSecond = null;
            if (cmdletContext.CompletionCriteria_MaxRuntimePerTrainingJobInSecond != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CompletionCriteria_completionCriteria_MaxRuntimePerTrainingJobInSecond = cmdletContext.CompletionCriteria_MaxRuntimePerTrainingJobInSecond.Value;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CompletionCriteria_completionCriteria_MaxRuntimePerTrainingJobInSecond != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CompletionCriteria.MaxRuntimePerTrainingJobInSeconds = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CompletionCriteria_completionCriteria_MaxRuntimePerTrainingJobInSecond.Value;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CompletionCriteriaIsNull = false;
            }
             // determine if requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CompletionCriteria should be set to null
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CompletionCriteriaIsNull)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CompletionCriteria = null;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CompletionCriteria != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig.CompletionCriteria = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CompletionCriteria;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfigIsNull = false;
            }
             // determine if requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig should be set to null
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfigIsNull)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig = null;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig != null)
            {
                request.AutoMLProblemTypeConfig.TabularJobConfig = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig;
                requestAutoMLProblemTypeConfigIsNull = false;
            }
             // determine if request.AutoMLProblemTypeConfig should be set to null
            if (requestAutoMLProblemTypeConfigIsNull)
            {
                request.AutoMLProblemTypeConfig = null;
            }
            
             // populate DataSplitConfig
            var requestDataSplitConfigIsNull = true;
            request.DataSplitConfig = new Amazon.SageMaker.Model.AutoMLDataSplitConfig();
            System.Single? requestDataSplitConfig_dataSplitConfig_ValidationFraction = null;
            if (cmdletContext.DataSplitConfig_ValidationFraction != null)
            {
                requestDataSplitConfig_dataSplitConfig_ValidationFraction = cmdletContext.DataSplitConfig_ValidationFraction.Value;
            }
            if (requestDataSplitConfig_dataSplitConfig_ValidationFraction != null)
            {
                request.DataSplitConfig.ValidationFraction = requestDataSplitConfig_dataSplitConfig_ValidationFraction.Value;
                requestDataSplitConfigIsNull = false;
            }
             // determine if request.DataSplitConfig should be set to null
            if (requestDataSplitConfigIsNull)
            {
                request.DataSplitConfig = null;
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
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            
             // populate SecurityConfig
            var requestSecurityConfigIsNull = true;
            request.SecurityConfig = new Amazon.SageMaker.Model.AutoMLSecurityConfig();
            System.Boolean? requestSecurityConfig_securityConfig_EnableInterContainerTrafficEncryption = null;
            if (cmdletContext.SecurityConfig_EnableInterContainerTrafficEncryption != null)
            {
                requestSecurityConfig_securityConfig_EnableInterContainerTrafficEncryption = cmdletContext.SecurityConfig_EnableInterContainerTrafficEncryption.Value;
            }
            if (requestSecurityConfig_securityConfig_EnableInterContainerTrafficEncryption != null)
            {
                request.SecurityConfig.EnableInterContainerTrafficEncryption = requestSecurityConfig_securityConfig_EnableInterContainerTrafficEncryption.Value;
                requestSecurityConfigIsNull = false;
            }
            System.String requestSecurityConfig_securityConfig_VolumeKmsKeyId = null;
            if (cmdletContext.SecurityConfig_VolumeKmsKeyId != null)
            {
                requestSecurityConfig_securityConfig_VolumeKmsKeyId = cmdletContext.SecurityConfig_VolumeKmsKeyId;
            }
            if (requestSecurityConfig_securityConfig_VolumeKmsKeyId != null)
            {
                request.SecurityConfig.VolumeKmsKeyId = requestSecurityConfig_securityConfig_VolumeKmsKeyId;
                requestSecurityConfigIsNull = false;
            }
            Amazon.SageMaker.Model.VpcConfig requestSecurityConfig_securityConfig_VpcConfig = null;
            
             // populate VpcConfig
            var requestSecurityConfig_securityConfig_VpcConfigIsNull = true;
            requestSecurityConfig_securityConfig_VpcConfig = new Amazon.SageMaker.Model.VpcConfig();
            List<System.String> requestSecurityConfig_securityConfig_VpcConfig_vpcConfig_SecurityGroupId = null;
            if (cmdletContext.VpcConfig_SecurityGroupId != null)
            {
                requestSecurityConfig_securityConfig_VpcConfig_vpcConfig_SecurityGroupId = cmdletContext.VpcConfig_SecurityGroupId;
            }
            if (requestSecurityConfig_securityConfig_VpcConfig_vpcConfig_SecurityGroupId != null)
            {
                requestSecurityConfig_securityConfig_VpcConfig.SecurityGroupIds = requestSecurityConfig_securityConfig_VpcConfig_vpcConfig_SecurityGroupId;
                requestSecurityConfig_securityConfig_VpcConfigIsNull = false;
            }
            List<System.String> requestSecurityConfig_securityConfig_VpcConfig_vpcConfig_Subnet = null;
            if (cmdletContext.VpcConfig_Subnet != null)
            {
                requestSecurityConfig_securityConfig_VpcConfig_vpcConfig_Subnet = cmdletContext.VpcConfig_Subnet;
            }
            if (requestSecurityConfig_securityConfig_VpcConfig_vpcConfig_Subnet != null)
            {
                requestSecurityConfig_securityConfig_VpcConfig.Subnets = requestSecurityConfig_securityConfig_VpcConfig_vpcConfig_Subnet;
                requestSecurityConfig_securityConfig_VpcConfigIsNull = false;
            }
             // determine if requestSecurityConfig_securityConfig_VpcConfig should be set to null
            if (requestSecurityConfig_securityConfig_VpcConfigIsNull)
            {
                requestSecurityConfig_securityConfig_VpcConfig = null;
            }
            if (requestSecurityConfig_securityConfig_VpcConfig != null)
            {
                request.SecurityConfig.VpcConfig = requestSecurityConfig_securityConfig_VpcConfig;
                requestSecurityConfigIsNull = false;
            }
             // determine if request.SecurityConfig should be set to null
            if (requestSecurityConfigIsNull)
            {
                request.SecurityConfig = null;
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
        
        private Amazon.SageMaker.Model.CreateAutoMLJobV2Response CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateAutoMLJobV2Request request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateAutoMLJobV2");
            try
            {
                #if DESKTOP
                return client.CreateAutoMLJobV2(request);
                #elif CORECLR
                return client.CreateAutoMLJobV2Async(request).GetAwaiter().GetResult();
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
            public List<Amazon.SageMaker.Model.AutoMLJobChannel> AutoMLJobInputDataConfig { get; set; }
            public System.String AutoMLJobName { get; set; }
            public Amazon.SageMaker.AutoMLMetricEnum AutoMLJobObjective_MetricName { get; set; }
            public System.Int32? AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSeconds { get; set; }
            public System.Int32? AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxCandidates { get; set; }
            public System.Int32? AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSeconds { get; set; }
            public List<Amazon.SageMaker.Model.AutoMLAlgorithmConfig> CandidateGenerationConfig_AlgorithmsConfig { get; set; }
            public System.Int32? CompletionCriteria_MaxAutoMLJobRuntimeInSecond { get; set; }
            public System.Int32? CompletionCriteria_MaxCandidate { get; set; }
            public System.Int32? CompletionCriteria_MaxRuntimePerTrainingJobInSecond { get; set; }
            public System.String TabularJobConfig_FeatureSpecificationS3Uri { get; set; }
            public System.Boolean? TabularJobConfig_GenerateCandidateDefinitionsOnly { get; set; }
            public Amazon.SageMaker.AutoMLMode TabularJobConfig_Mode { get; set; }
            public Amazon.SageMaker.ProblemType TabularJobConfig_ProblemType { get; set; }
            public System.String TabularJobConfig_SampleWeightAttributeName { get; set; }
            public System.String TabularJobConfig_TargetAttributeName { get; set; }
            public System.Int32? AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSeconds { get; set; }
            public System.Int32? AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxCandidates { get; set; }
            public System.Int32? AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSeconds { get; set; }
            public System.String TextClassificationJobConfig_ContentColumn { get; set; }
            public System.String TextClassificationJobConfig_TargetLabelColumn { get; set; }
            public System.Single? DataSplitConfig_ValidationFraction { get; set; }
            public System.Boolean? ModelDeployConfig_AutoGenerateEndpointName { get; set; }
            public System.String ModelDeployConfig_EndpointName { get; set; }
            public System.String OutputDataConfig_KmsKeyId { get; set; }
            public System.String OutputDataConfig_S3OutputPath { get; set; }
            public System.String RoleArn { get; set; }
            public System.Boolean? SecurityConfig_EnableInterContainerTrafficEncryption { get; set; }
            public System.String SecurityConfig_VolumeKmsKeyId { get; set; }
            public List<System.String> VpcConfig_SecurityGroupId { get; set; }
            public List<System.String> VpcConfig_Subnet { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateAutoMLJobV2Response, NewSMAutoMLJobV2Cmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AutoMLJobArn;
        }
        
    }
}
