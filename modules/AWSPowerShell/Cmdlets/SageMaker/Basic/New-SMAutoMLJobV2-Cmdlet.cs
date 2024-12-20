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
    ///  
    /// <para>
    /// An AutoML job in SageMaker AI is a fully automated process that allows you to build
    /// machine learning models with minimal effort and machine learning expertise. When initiating
    /// an AutoML job, you provide your data and optionally specify parameters tailored to
    /// your use case. SageMaker AI then automates the entire model development lifecycle,
    /// including data preprocessing, model training, tuning, and evaluation. AutoML jobs
    /// are designed to simplify and accelerate the model building process by automating various
    /// tasks and exploring different combinations of machine learning algorithms, data preprocessing
    /// techniques, and hyperparameter values. The output of an AutoML job comprises one or
    /// more trained models ready for deployment and inference. Additionally, SageMaker AI
    /// AutoML jobs generate a candidate model leaderboard, allowing you to select the best-performing
    /// model for deployment.
    /// </para><para>
    /// For more information about AutoML jobs, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/autopilot-automate-model-development.html">https://docs.aws.amazon.com/sagemaker/latest/dg/autopilot-automate-model-development.html</a>
    /// in the SageMaker AI developer guide.
    /// </para><para>
    /// AutoML jobs V2 support various problem types such as regression, binary, and multiclass
    /// classification with tabular data, text and image classification, time-series forecasting,
    /// and fine-tuning of large language models (LLMs) for text generation.
    /// </para><note><para><a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_CreateAutoMLJobV2.html">CreateAutoMLJobV2</a>
    /// and <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_DescribeAutoMLJobV2.html">DescribeAutoMLJobV2</a>
    /// are new versions of <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_CreateAutoMLJob.html">CreateAutoMLJob</a>
    /// and <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_DescribeAutoMLJob.html">DescribeAutoMLJob</a>
    /// which offer backward compatibility.
    /// </para><para><c>CreateAutoMLJobV2</c> can manage tabular problem types identical to those of its
    /// previous version <c>CreateAutoMLJob</c>, as well as time-series forecasting, non-tabular
    /// problem types such as image or text classification, and text generation (LLMs fine-tuning).
    /// </para><para>
    /// Find guidelines about how to migrate a <c>CreateAutoMLJob</c> to <c>CreateAutoMLJobV2</c>
    /// in <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/autopilot-automate-model-development-create-experiment.html#autopilot-create-experiment-api-migrate-v1-v2">Migrate
    /// a CreateAutoMLJob to CreateAutoMLJobV2</a>.
    /// </para></note><para>
    /// For the list of available problem types supported by <c>CreateAutoMLJobV2</c>, see
    /// <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_AutoMLProblemTypeConfig.html">AutoMLProblemTypeConfig</a>.
    /// </para><para>
    /// You can find the best-performing model after you run an AutoML job V2 by calling <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_DescribeAutoMLJobV2.html">DescribeAutoMLJobV2</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SMAutoMLJobV2", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateAutoMLJobV2 API operation.", Operation = new[] {"CreateAutoMLJobV2"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateAutoMLJobV2Response))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateAutoMLJobV2Response",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateAutoMLJobV2Response) can be returned by specifying '-Select *'."
    )]
    public partial class NewSMAutoMLJobV2Cmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ModelAccessConfig_AcceptEula
        /// <summary>
        /// <para>
        /// <para>Specifies agreement to the model end-user license agreement (EULA). The <c>AcceptEula</c>
        /// value must be explicitly defined as <c>True</c> in order to accept the EULA that this
        /// model requires. You are responsible for reviewing and complying with any applicable
        /// license terms and making sure they are acceptable for your use case before downloading
        /// or using a model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLProblemTypeConfig_TextGenerationJobConfig_ModelAccessConfig_AcceptEula")]
        public System.Boolean? ModelAccessConfig_AcceptEula { get; set; }
        #endregion
        
        #region Parameter Transformations_Aggregation
        /// <summary>
        /// <para>
        /// <para>A key value pair defining the aggregation method for a column, where the key is the
        /// column name and the value is the aggregation method.</para><para>The supported aggregation methods are <c>sum</c> (default), <c>avg</c>, <c>first</c>,
        /// <c>min</c>, <c>max</c>.</para><note><para>Aggregation is only supported for the target column.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_Transformations_Aggregation")]
        public System.Collections.Hashtable Transformations_Aggregation { get; set; }
        #endregion
        
        #region Parameter TabularJobConfig_CandidateGenerationConfig_AlgorithmsConfig
        /// <summary>
        /// <para>
        /// <para>Your Autopilot job trains a default set of algorithms on your dataset. For tabular
        /// and time-series data, you can customize the algorithm list by selecting a subset of
        /// algorithms for your problem type.</para><para><c>AlgorithmsConfig</c> stores the customized selection of algorithms to train on
        /// your data.</para><ul><li><para><b>For the tabular problem type <c>TabularJobConfig</c>,</b> the list of available
        /// algorithms to choose from depends on the training mode set in <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_AutoMLJobConfig.html"><c>AutoMLJobConfig.Mode</c></a>.</para><ul><li><para><c>AlgorithmsConfig</c> should not be set when the training mode <c>AutoMLJobConfig.Mode</c>
        /// is set to <c>AUTO</c>.</para></li><li><para>When <c>AlgorithmsConfig</c> is provided, one <c>AutoMLAlgorithms</c> attribute must
        /// be set and one only.</para><para>If the list of algorithms provided as values for <c>AutoMLAlgorithms</c> is empty,
        /// <c>CandidateGenerationConfig</c> uses the full set of algorithms for the given training
        /// mode.</para></li><li><para>When <c>AlgorithmsConfig</c> is not provided, <c>CandidateGenerationConfig</c> uses
        /// the full set of algorithms for the given training mode.</para></li></ul><para>For the list of all algorithms per training mode, see <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_AutoMLAlgorithmConfig.html">
        /// AlgorithmConfig</a>.</para><para>For more information on each algorithm, see the <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/autopilot-model-support-validation.html#autopilot-algorithm-support">Algorithm
        /// support</a> section in the Autopilot developer guide.</para></li><li><para><b>For the time-series forecasting problem type <c>TimeSeriesForecastingJobConfig</c>,</b>
        /// choose your algorithms from the list provided in <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_AutoMLAlgorithmConfig.html">
        /// AlgorithmConfig</a>.</para><para>For more information on each algorithm, see the <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/timeseries-forecasting-algorithms.html">Algorithms
        /// support for time-series forecasting</a> section in the Autopilot developer guide.</para><ul><li><para>When <c>AlgorithmsConfig</c> is provided, one <c>AutoMLAlgorithms</c> attribute must
        /// be set and one only.</para><para>If the list of algorithms provided as values for <c>AutoMLAlgorithms</c> is empty,
        /// <c>CandidateGenerationConfig</c> uses the full set of algorithms for time-series forecasting.</para></li><li><para>When <c>AlgorithmsConfig</c> is not provided, <c>CandidateGenerationConfig</c> uses
        /// the full set of algorithms for time-series forecasting.</para></li></ul></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLProblemTypeConfig_TabularJobConfig_CandidateGenerationConfig_AlgorithmsConfig","CandidateGenerationConfig_AlgorithmsConfig")]
        public Amazon.SageMaker.Model.AutoMLAlgorithmConfig[] TabularJobConfig_CandidateGenerationConfig_AlgorithmsConfig { get; set; }
        #endregion
        
        #region Parameter AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CandidateGenerationConfig_AlgorithmsConfig
        /// <summary>
        /// <para>
        /// <para>Your Autopilot job trains a default set of algorithms on your dataset. For tabular
        /// and time-series data, you can customize the algorithm list by selecting a subset of
        /// algorithms for your problem type.</para><para><c>AlgorithmsConfig</c> stores the customized selection of algorithms to train on
        /// your data.</para><ul><li><para><b>For the tabular problem type <c>TabularJobConfig</c>,</b> the list of available
        /// algorithms to choose from depends on the training mode set in <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_AutoMLJobConfig.html"><c>AutoMLJobConfig.Mode</c></a>.</para><ul><li><para><c>AlgorithmsConfig</c> should not be set when the training mode <c>AutoMLJobConfig.Mode</c>
        /// is set to <c>AUTO</c>.</para></li><li><para>When <c>AlgorithmsConfig</c> is provided, one <c>AutoMLAlgorithms</c> attribute must
        /// be set and one only.</para><para>If the list of algorithms provided as values for <c>AutoMLAlgorithms</c> is empty,
        /// <c>CandidateGenerationConfig</c> uses the full set of algorithms for the given training
        /// mode.</para></li><li><para>When <c>AlgorithmsConfig</c> is not provided, <c>CandidateGenerationConfig</c> uses
        /// the full set of algorithms for the given training mode.</para></li></ul><para>For the list of all algorithms per training mode, see <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_AutoMLAlgorithmConfig.html">
        /// AlgorithmConfig</a>.</para><para>For more information on each algorithm, see the <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/autopilot-model-support-validation.html#autopilot-algorithm-support">Algorithm
        /// support</a> section in the Autopilot developer guide.</para></li><li><para><b>For the time-series forecasting problem type <c>TimeSeriesForecastingJobConfig</c>,</b>
        /// choose your algorithms from the list provided in <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_AutoMLAlgorithmConfig.html">
        /// AlgorithmConfig</a>.</para><para>For more information on each algorithm, see the <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/timeseries-forecasting-algorithms.html">Algorithms
        /// support for time-series forecasting</a> section in the Autopilot developer guide.</para><ul><li><para>When <c>AlgorithmsConfig</c> is provided, one <c>AutoMLAlgorithms</c> attribute must
        /// be set and one only.</para><para>If the list of algorithms provided as values for <c>AutoMLAlgorithms</c> is empty,
        /// <c>CandidateGenerationConfig</c> uses the full set of algorithms for time-series forecasting.</para></li><li><para>When <c>AlgorithmsConfig</c> is not provided, <c>CandidateGenerationConfig</c> uses
        /// the full set of algorithms for time-series forecasting.</para></li></ul></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SageMaker.Model.AutoMLAlgorithmConfig[] AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CandidateGenerationConfig_AlgorithmsConfig { get; set; }
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
        
        #region Parameter AutoMLJobInputDataConfig
        /// <summary>
        /// <para>
        /// <para>An array of channel objects describing the input data and their location. Each channel
        /// is a named input source. Similar to the <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_CreateAutoMLJob.html#sagemaker-CreateAutoMLJob-request-InputDataConfig">InputDataConfig</a>
        /// attribute in the <c>CreateAutoMLJob</c> input parameters. The supported formats depend
        /// on the problem type:</para><ul><li><para>For tabular problem types: <c>S3Prefix</c>, <c>ManifestFile</c>.</para></li><li><para>For image classification: <c>S3Prefix</c>, <c>ManifestFile</c>, <c>AugmentedManifestFile</c>.</para></li><li><para>For text classification: <c>S3Prefix</c>.</para></li><li><para>For time-series forecasting: <c>S3Prefix</c>.</para></li><li><para>For text generation (LLMs fine-tuning): <c>S3Prefix</c>.</para></li></ul>
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
        
        #region Parameter TextGenerationJobConfig_BaseModelName
        /// <summary>
        /// <para>
        /// <para>The name of the base model to fine-tune. Autopilot supports fine-tuning a variety
        /// of large language models. For information on the list of supported models, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/autopilot-llms-finetuning-models.html#autopilot-llms-finetuning-supported-llms">Text
        /// generation models supporting fine-tuning in Autopilot</a>. If no <c>BaseModelName</c>
        /// is provided, the default model used is <b>Falcon7BInstruct</b>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLProblemTypeConfig_TextGenerationJobConfig_BaseModelName")]
        public System.String TextGenerationJobConfig_BaseModelName { get; set; }
        #endregion
        
        #region Parameter TextClassificationJobConfig_ContentColumn
        /// <summary>
        /// <para>
        /// <para>The name of the column used to provide the sentences to be classified. It should not
        /// be the same as the target column.</para>
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
        /// endpoint name is not generated automatically.</para><note><para>Specify the <c>EndpointName</c> if and only if you set <c>AutoGenerateEndpointName</c>
        /// to <c>False</c>; otherwise a 400 error is thrown.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ModelDeployConfig_EndpointName { get; set; }
        #endregion
        
        #region Parameter EmrServerlessComputeConfig_ExecutionRoleARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role granting the AutoML job V2 the necessary permissions access
        /// policies to list, connect to, or manage EMR Serverless jobs. For detailed information
        /// about the required permissions of this role, see "How to configure AutoML to initiate
        /// a remote job on EMR Serverless for large datasets" in <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/autopilot-automate-model-development-create-experiment.html">Create
        /// a regression or classification job for tabular data using the AutoML API</a> or <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/autopilot-create-experiment-timeseries-forecasting.html#timeseries-forecasting-api-optional-params">Create
        /// an AutoML job for time-series forecasting using the API</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLComputeConfig_EmrServerlessComputeConfig_ExecutionRoleARN")]
        public System.String EmrServerlessComputeConfig_ExecutionRoleARN { get; set; }
        #endregion
        
        #region Parameter TabularJobConfig_FeatureSpecificationS3Uri
        /// <summary>
        /// <para>
        /// <para>A URL to the Amazon S3 data source containing selected features from the input data
        /// source to run an Autopilot job V2. You can input <c>FeatureAttributeNames</c> (optional)
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
        [Alias("AutoMLProblemTypeConfig_TabularJobConfig_FeatureSpecificationS3Uri")]
        public System.String TabularJobConfig_FeatureSpecificationS3Uri { get; set; }
        #endregion
        
        #region Parameter TimeSeriesForecastingJobConfig_FeatureSpecificationS3Uri
        /// <summary>
        /// <para>
        /// <para>A URL to the Amazon S3 data source containing additional selected features that complement
        /// the target, itemID, timestamp, and grouped columns set in <c>TimeSeriesConfig</c>.
        /// When not provided, the AutoML job V2 includes all the columns from the original dataset
        /// that are not already declared in <c>TimeSeriesConfig</c>. If provided, the AutoML
        /// job V2 only considers these additional columns as a complement to the ones declared
        /// in <c>TimeSeriesConfig</c>.</para><para>You can input <c>FeatureAttributeNames</c> (optional) in JSON format as shown below:
        /// </para><para><c>{ "FeatureAttributeNames":["col1", "col2", ...] }</c>.</para><para>You can also specify the data type of the feature (optional) in the format shown below:</para><para><c>{ "FeatureDataTypes":{"col1":"numeric", "col2":"categorical" ... } }</c></para><para>Autopilot supports the following data types: <c>numeric</c>, <c>categorical</c>, <c>text</c>,
        /// and <c>datetime</c>.</para><note><para>These column keys must not include any column set in <c>TimeSeriesConfig</c>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_FeatureSpecificationS3Uri")]
        public System.String TimeSeriesForecastingJobConfig_FeatureSpecificationS3Uri { get; set; }
        #endregion
        
        #region Parameter Transformations_Filling
        /// <summary>
        /// <para>
        /// <para>A key value pair defining the filling method for a column, where the key is the column
        /// name and the value is an object which defines the filling logic. You can specify multiple
        /// filling methods for a single column.</para><para>The supported filling methods and their corresponding options are:</para><ul><li><para><c>frontfill</c>: <c>none</c> (Supported only for target column)</para></li><li><para><c>middlefill</c>: <c>zero</c>, <c>value</c>, <c>median</c>, <c>mean</c>, <c>min</c>,
        /// <c>max</c></para></li><li><para><c>backfill</c>: <c>zero</c>, <c>value</c>, <c>median</c>, <c>mean</c>, <c>min</c>,
        /// <c>max</c></para></li><li><para><c>futurefill</c>: <c>zero</c>, <c>value</c>, <c>median</c>, <c>mean</c>, <c>min</c>,
        /// <c>max</c></para></li></ul><para>To set a filling method to a specific value, set the fill parameter to the chosen
        /// filling method value (for example <c>"backfill" : "value"</c>), and define the filling
        /// value in an additional parameter prefixed with "_value". For example, to set <c>backfill</c>
        /// to a value of <c>2</c>, you must include two parameters: <c>"backfill": "value"</c>
        /// and <c>"backfill_value":"2"</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_Transformations_Filling")]
        public System.Collections.Hashtable Transformations_Filling { get; set; }
        #endregion
        
        #region Parameter TimeSeriesForecastingJobConfig_ForecastFrequency
        /// <summary>
        /// <para>
        /// <para>The frequency of predictions in a forecast.</para><para>Valid intervals are an integer followed by Y (Year), M (Month), W (Week), D (Day),
        /// H (Hour), and min (Minute). For example, <c>1D</c> indicates every day and <c>15min</c>
        /// indicates every 15 minutes. The value of a frequency must not overlap with the next
        /// larger frequency. For example, you must use a frequency of <c>1H</c> instead of <c>60min</c>.</para><para>The valid values for each frequency are the following:</para><ul><li><para>Minute - 1-59</para></li><li><para>Hour - 1-23</para></li><li><para>Day - 1-6</para></li><li><para>Week - 1-4</para></li><li><para>Month - 1-11</para></li><li><para>Year - 1</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_ForecastFrequency")]
        public System.String TimeSeriesForecastingJobConfig_ForecastFrequency { get; set; }
        #endregion
        
        #region Parameter TimeSeriesForecastingJobConfig_ForecastHorizon
        /// <summary>
        /// <para>
        /// <para>The number of time-steps that the model predicts. The forecast horizon is also called
        /// the prediction length. The maximum forecast horizon is the lesser of 500 time-steps
        /// or 1/4 of the time-steps in the dataset.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_ForecastHorizon")]
        public System.Int32? TimeSeriesForecastingJobConfig_ForecastHorizon { get; set; }
        #endregion
        
        #region Parameter TimeSeriesForecastingJobConfig_ForecastQuantile
        /// <summary>
        /// <para>
        /// <para>The quantiles used to train the model for forecasts at a specified quantile. You can
        /// specify quantiles from <c>0.01</c> (p1) to <c>0.99</c> (p99), by increments of 0.01
        /// or higher. Up to five forecast quantiles can be specified. When <c>ForecastQuantiles</c>
        /// is not provided, the AutoML job uses the quantiles p10, p50, and p90 as default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_ForecastQuantiles")]
        public System.String[] TimeSeriesForecastingJobConfig_ForecastQuantile { get; set; }
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
        
        #region Parameter TimeSeriesConfig_GroupingAttributeName
        /// <summary>
        /// <para>
        /// <para>A set of columns names that can be grouped with the item identifier column to create
        /// a composite key for which a target value is predicted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_TimeSeriesConfig_GroupingAttributeNames")]
        public System.String[] TimeSeriesConfig_GroupingAttributeName { get; set; }
        #endregion
        
        #region Parameter TimeSeriesForecastingJobConfig_HolidayConfig
        /// <summary>
        /// <para>
        /// <para>The collection of holiday featurization attributes used to incorporate national holiday
        /// information into your forecasting model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_HolidayConfig")]
        public Amazon.SageMaker.Model.HolidayConfigAttributes[] TimeSeriesForecastingJobConfig_HolidayConfig { get; set; }
        #endregion
        
        #region Parameter TimeSeriesConfig_ItemIdentifierAttributeName
        /// <summary>
        /// <para>
        /// <para>The name of the column that represents the set of item identifiers for which you want
        /// to predict the target value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_TimeSeriesConfig_ItemIdentifierAttributeName")]
        public System.String TimeSeriesConfig_ItemIdentifierAttributeName { get; set; }
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
        
        #region Parameter AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum runtime, in seconds, an AutoML job has to complete.</para><para>If an AutoML job exceeds the maximum runtime, the job is stopped automatically and
        /// its processing is ended gracefully. The AutoML job identifies the best model whose
        /// training was completed and marks it as the best-performing model. Any unfinished steps
        /// of the job, such as automatic one-click Autopilot model deployment, are not completed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSeconds","ImageClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSeconds")]
        public System.Int32? AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond { get; set; }
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
        
        #region Parameter AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum runtime, in seconds, an AutoML job has to complete.</para><para>If an AutoML job exceeds the maximum runtime, the job is stopped automatically and
        /// its processing is ended gracefully. The AutoML job identifies the best model whose
        /// training was completed and marks it as the best-performing model. Any unfinished steps
        /// of the job, such as automatic one-click Autopilot model deployment, are not completed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSeconds","TextClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSeconds")]
        public System.Int32? AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond { get; set; }
        #endregion
        
        #region Parameter AutoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum runtime, in seconds, an AutoML job has to complete.</para><para>If an AutoML job exceeds the maximum runtime, the job is stopped automatically and
        /// its processing is ended gracefully. The AutoML job identifies the best model whose
        /// training was completed and marks it as the best-performing model. Any unfinished steps
        /// of the job, such as automatic one-click Autopilot model deployment, are not completed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSeconds","TextGeneration_CompletionCriteria_MaxAutoMLJobRuntimeInSeconds")]
        public System.Int32? AutoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond { get; set; }
        #endregion
        
        #region Parameter AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum runtime, in seconds, an AutoML job has to complete.</para><para>If an AutoML job exceeds the maximum runtime, the job is stopped automatically and
        /// its processing is ended gracefully. The AutoML job identifies the best model whose
        /// training was completed and marks it as the best-performing model. Any unfinished steps
        /// of the job, such as automatic one-click Autopilot model deployment, are not completed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSeconds","TimeSeries_CompletionCriteria_MaxAutoMLJobRuntimeInSeconds")]
        public System.Int32? AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond { get; set; }
        #endregion
        
        #region Parameter AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxCandidate
        /// <summary>
        /// <para>
        /// <para>The maximum number of times a training job is allowed to run.</para><para>For text and image classification, time-series forecasting, as well as text generation
        /// (LLMs fine-tuning) problem types, the supported value is 1. For tabular problem types,
        /// the maximum value is 750.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxCandidates","ImageClassificationJobConfig_CompletionCriteria_MaxCandidates")]
        public System.Int32? AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxCandidate { get; set; }
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
        [Alias("AutoMLProblemTypeConfig_TabularJobConfig_CompletionCriteria_MaxCandidates")]
        public System.Int32? CompletionCriteria_MaxCandidate { get; set; }
        #endregion
        
        #region Parameter AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxCandidate
        /// <summary>
        /// <para>
        /// <para>The maximum number of times a training job is allowed to run.</para><para>For text and image classification, time-series forecasting, as well as text generation
        /// (LLMs fine-tuning) problem types, the supported value is 1. For tabular problem types,
        /// the maximum value is 750.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxCandidates","TextClassificationJobConfig_CompletionCriteria_MaxCandidates")]
        public System.Int32? AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxCandidate { get; set; }
        #endregion
        
        #region Parameter AutoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_MaxCandidate
        /// <summary>
        /// <para>
        /// <para>The maximum number of times a training job is allowed to run.</para><para>For text and image classification, time-series forecasting, as well as text generation
        /// (LLMs fine-tuning) problem types, the supported value is 1. For tabular problem types,
        /// the maximum value is 750.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_MaxCandidates","TextGeneration_CompletionCriteria_MaxCandidates")]
        public System.Int32? AutoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_MaxCandidate { get; set; }
        #endregion
        
        #region Parameter AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_MaxCandidate
        /// <summary>
        /// <para>
        /// <para>The maximum number of times a training job is allowed to run.</para><para>For text and image classification, time-series forecasting, as well as text generation
        /// (LLMs fine-tuning) problem types, the supported value is 1. For tabular problem types,
        /// the maximum value is 750.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_MaxCandidates","TimeSeries_CompletionCriteria_MaxCandidates")]
        public System.Int32? AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_MaxCandidate { get; set; }
        #endregion
        
        #region Parameter AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond
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
        [Alias("AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSeconds","ImageClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSeconds")]
        public System.Int32? AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond { get; set; }
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
        [Alias("AutoMLProblemTypeConfig_TabularJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSeconds")]
        public System.Int32? CompletionCriteria_MaxRuntimePerTrainingJobInSecond { get; set; }
        #endregion
        
        #region Parameter AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond
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
        [Alias("AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSeconds","TextClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSeconds")]
        public System.Int32? AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond { get; set; }
        #endregion
        
        #region Parameter AutoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond
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
        [Alias("AutoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSeconds","TextGeneration_CompletionCriteria_MaxRuntimePerTrainingJobInSeconds")]
        public System.Int32? AutoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond { get; set; }
        #endregion
        
        #region Parameter AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond
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
        [Alias("AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSeconds","TimeSeries_CompletionCriteria_MaxRuntimePerTrainingJobInSeconds")]
        public System.Int32? AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond { get; set; }
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
        
        #region Parameter TabularJobConfig_Mode
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
        [Alias("AutoMLProblemTypeConfig_TabularJobConfig_Mode")]
        [AWSConstantClassSource("Amazon.SageMaker.AutoMLMode")]
        public Amazon.SageMaker.AutoMLMode TabularJobConfig_Mode { get; set; }
        #endregion
        
        #region Parameter TabularJobConfig_ProblemType
        /// <summary>
        /// <para>
        /// <para>The type of supervised learning problem available for the model candidates of the
        /// AutoML job V2. For more information, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/autopilot-datasets-problem-types.html#autopilot-problem-types">
        /// SageMaker Autopilot problem types</a>.</para><note><para>You must either specify the type of supervised learning problem in <c>ProblemType</c>
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
        /// <para>The VPC security group IDs, in the form <c>sg-xxxxxxxx</c>. Specify the security groups
        /// for the VPC that is specified in the <c>Subnets</c> field.</para>
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
        
        #region Parameter TimeSeriesConfig_TargetAttributeName
        /// <summary>
        /// <para>
        /// <para>The name of the column representing the target variable that you want to predict for
        /// each item in your dataset. The data type of the target variable must be numerical.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_TimeSeriesConfig_TargetAttributeName")]
        public System.String TimeSeriesConfig_TargetAttributeName { get; set; }
        #endregion
        
        #region Parameter TextClassificationJobConfig_TargetLabelColumn
        /// <summary>
        /// <para>
        /// <para>The name of the column used to provide the class labels. It should not be same as
        /// the content column.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLProblemTypeConfig_TextClassificationJobConfig_TargetLabelColumn")]
        public System.String TextClassificationJobConfig_TargetLabelColumn { get; set; }
        #endregion
        
        #region Parameter TextGenerationJobConfig_TextGenerationHyperParameter
        /// <summary>
        /// <para>
        /// <para>The hyperparameters used to configure and optimize the learning process of the base
        /// model. You can set any combination of the following hyperparameters for all base models.
        /// For more information on each supported hyperparameter, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/autopilot-llms-finetuning-set-hyperparameters.html">Optimize
        /// the learning process of your text generation models with hyperparameters</a>.</para><ul><li><para><c>"epochCount"</c>: The number of times the model goes through the entire training
        /// dataset. Its value should be a string containing an integer value within the range
        /// of "1" to "10".</para></li><li><para><c>"batchSize"</c>: The number of data samples used in each iteration of training.
        /// Its value should be a string containing an integer value within the range of "1" to
        /// "64".</para></li><li><para><c>"learningRate"</c>: The step size at which a model's parameters are updated during
        /// training. Its value should be a string containing a floating-point value within the
        /// range of "0" to "1".</para></li><li><para><c>"learningRateWarmupSteps"</c>: The number of training steps during which the learning
        /// rate gradually increases before reaching its target or maximum value. Its value should
        /// be a string containing an integer value within the range of "0" to "250".</para></li></ul><para>Here is an example where all four hyperparameters are configured.</para><para><c>{ "epochCount":"5", "learningRate":"0.5", "batchSize": "32", "learningRateWarmupSteps":
        /// "10" }</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLProblemTypeConfig_TextGenerationJobConfig_TextGenerationHyperParameters")]
        public System.Collections.Hashtable TextGenerationJobConfig_TextGenerationHyperParameter { get; set; }
        #endregion
        
        #region Parameter TimeSeriesConfig_TimestampAttributeName
        /// <summary>
        /// <para>
        /// <para>The name of the column indicating a point in time at which the target value of a given
        /// item is recorded.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_TimeSeriesConfig_TimestampAttributeName")]
        public System.String TimeSeriesConfig_TimestampAttributeName { get; set; }
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
            context.EmrServerlessComputeConfig_ExecutionRoleARN = this.EmrServerlessComputeConfig_ExecutionRoleARN;
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
            context.AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond = this.AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond;
            context.AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxCandidate = this.AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxCandidate;
            context.AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond = this.AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond;
            if (this.TabularJobConfig_CandidateGenerationConfig_AlgorithmsConfig != null)
            {
                context.TabularJobConfig_CandidateGenerationConfig_AlgorithmsConfig = new List<Amazon.SageMaker.Model.AutoMLAlgorithmConfig>(this.TabularJobConfig_CandidateGenerationConfig_AlgorithmsConfig);
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
            context.AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond = this.AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond;
            context.AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxCandidate = this.AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxCandidate;
            context.AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond = this.AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond;
            context.TextClassificationJobConfig_ContentColumn = this.TextClassificationJobConfig_ContentColumn;
            context.TextClassificationJobConfig_TargetLabelColumn = this.TextClassificationJobConfig_TargetLabelColumn;
            context.TextGenerationJobConfig_BaseModelName = this.TextGenerationJobConfig_BaseModelName;
            context.AutoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond = this.AutoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond;
            context.AutoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_MaxCandidate = this.AutoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_MaxCandidate;
            context.AutoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond = this.AutoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond;
            context.ModelAccessConfig_AcceptEula = this.ModelAccessConfig_AcceptEula;
            if (this.TextGenerationJobConfig_TextGenerationHyperParameter != null)
            {
                context.TextGenerationJobConfig_TextGenerationHyperParameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.TextGenerationJobConfig_TextGenerationHyperParameter.Keys)
                {
                    context.TextGenerationJobConfig_TextGenerationHyperParameter.Add((String)hashKey, (System.String)(this.TextGenerationJobConfig_TextGenerationHyperParameter[hashKey]));
                }
            }
            if (this.AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CandidateGenerationConfig_AlgorithmsConfig != null)
            {
                context.AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CandidateGenerationConfig_AlgorithmsConfig = new List<Amazon.SageMaker.Model.AutoMLAlgorithmConfig>(this.AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CandidateGenerationConfig_AlgorithmsConfig);
            }
            context.AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond = this.AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond;
            context.AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_MaxCandidate = this.AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_MaxCandidate;
            context.AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond = this.AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond;
            context.TimeSeriesForecastingJobConfig_FeatureSpecificationS3Uri = this.TimeSeriesForecastingJobConfig_FeatureSpecificationS3Uri;
            context.TimeSeriesForecastingJobConfig_ForecastFrequency = this.TimeSeriesForecastingJobConfig_ForecastFrequency;
            context.TimeSeriesForecastingJobConfig_ForecastHorizon = this.TimeSeriesForecastingJobConfig_ForecastHorizon;
            if (this.TimeSeriesForecastingJobConfig_ForecastQuantile != null)
            {
                context.TimeSeriesForecastingJobConfig_ForecastQuantile = new List<System.String>(this.TimeSeriesForecastingJobConfig_ForecastQuantile);
            }
            if (this.TimeSeriesForecastingJobConfig_HolidayConfig != null)
            {
                context.TimeSeriesForecastingJobConfig_HolidayConfig = new List<Amazon.SageMaker.Model.HolidayConfigAttributes>(this.TimeSeriesForecastingJobConfig_HolidayConfig);
            }
            if (this.TimeSeriesConfig_GroupingAttributeName != null)
            {
                context.TimeSeriesConfig_GroupingAttributeName = new List<System.String>(this.TimeSeriesConfig_GroupingAttributeName);
            }
            context.TimeSeriesConfig_ItemIdentifierAttributeName = this.TimeSeriesConfig_ItemIdentifierAttributeName;
            context.TimeSeriesConfig_TargetAttributeName = this.TimeSeriesConfig_TargetAttributeName;
            context.TimeSeriesConfig_TimestampAttributeName = this.TimeSeriesConfig_TimestampAttributeName;
            if (this.Transformations_Aggregation != null)
            {
                context.Transformations_Aggregation = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Transformations_Aggregation.Keys)
                {
                    context.Transformations_Aggregation.Add((String)hashKey, (System.String)(this.Transformations_Aggregation[hashKey]));
                }
            }
            if (this.Transformations_Filling != null)
            {
                context.Transformations_Filling = new Dictionary<System.String, Dictionary<System.String, System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.Transformations_Filling.Keys)
                {
                    context.Transformations_Filling.Add((String)hashKey, (Dictionary<System.String,System.String>)(this.Transformations_Filling[hashKey]));
                }
            }
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
            
            
             // populate AutoMLComputeConfig
            var requestAutoMLComputeConfigIsNull = true;
            request.AutoMLComputeConfig = new Amazon.SageMaker.Model.AutoMLComputeConfig();
            Amazon.SageMaker.Model.EmrServerlessComputeConfig requestAutoMLComputeConfig_autoMLComputeConfig_EmrServerlessComputeConfig = null;
            
             // populate EmrServerlessComputeConfig
            var requestAutoMLComputeConfig_autoMLComputeConfig_EmrServerlessComputeConfigIsNull = true;
            requestAutoMLComputeConfig_autoMLComputeConfig_EmrServerlessComputeConfig = new Amazon.SageMaker.Model.EmrServerlessComputeConfig();
            System.String requestAutoMLComputeConfig_autoMLComputeConfig_EmrServerlessComputeConfig_emrServerlessComputeConfig_ExecutionRoleARN = null;
            if (cmdletContext.EmrServerlessComputeConfig_ExecutionRoleARN != null)
            {
                requestAutoMLComputeConfig_autoMLComputeConfig_EmrServerlessComputeConfig_emrServerlessComputeConfig_ExecutionRoleARN = cmdletContext.EmrServerlessComputeConfig_ExecutionRoleARN;
            }
            if (requestAutoMLComputeConfig_autoMLComputeConfig_EmrServerlessComputeConfig_emrServerlessComputeConfig_ExecutionRoleARN != null)
            {
                requestAutoMLComputeConfig_autoMLComputeConfig_EmrServerlessComputeConfig.ExecutionRoleARN = requestAutoMLComputeConfig_autoMLComputeConfig_EmrServerlessComputeConfig_emrServerlessComputeConfig_ExecutionRoleARN;
                requestAutoMLComputeConfig_autoMLComputeConfig_EmrServerlessComputeConfigIsNull = false;
            }
             // determine if requestAutoMLComputeConfig_autoMLComputeConfig_EmrServerlessComputeConfig should be set to null
            if (requestAutoMLComputeConfig_autoMLComputeConfig_EmrServerlessComputeConfigIsNull)
            {
                requestAutoMLComputeConfig_autoMLComputeConfig_EmrServerlessComputeConfig = null;
            }
            if (requestAutoMLComputeConfig_autoMLComputeConfig_EmrServerlessComputeConfig != null)
            {
                request.AutoMLComputeConfig.EmrServerlessComputeConfig = requestAutoMLComputeConfig_autoMLComputeConfig_EmrServerlessComputeConfig;
                requestAutoMLComputeConfigIsNull = false;
            }
             // determine if request.AutoMLComputeConfig should be set to null
            if (requestAutoMLComputeConfigIsNull)
            {
                request.AutoMLComputeConfig = null;
            }
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
            System.Int32? requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond = null;
            if (cmdletContext.AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond = cmdletContext.AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond.Value;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria.MaxAutoMLJobRuntimeInSeconds = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond.Value;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteriaIsNull = false;
            }
            System.Int32? requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxCandidate = null;
            if (cmdletContext.AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxCandidate != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxCandidate = cmdletContext.AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxCandidate.Value;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxCandidate != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria.MaxCandidates = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxCandidate.Value;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteriaIsNull = false;
            }
            System.Int32? requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond = null;
            if (cmdletContext.AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond = cmdletContext.AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond.Value;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria.MaxRuntimePerTrainingJobInSeconds = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond.Value;
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
            System.Int32? requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond = null;
            if (cmdletContext.AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond = cmdletContext.AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond.Value;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria.MaxAutoMLJobRuntimeInSeconds = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond.Value;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteriaIsNull = false;
            }
            System.Int32? requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxCandidate = null;
            if (cmdletContext.AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxCandidate != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxCandidate = cmdletContext.AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxCandidate.Value;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxCandidate != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria.MaxCandidates = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxCandidate.Value;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteriaIsNull = false;
            }
            System.Int32? requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond = null;
            if (cmdletContext.AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond = cmdletContext.AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond.Value;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria.MaxRuntimePerTrainingJobInSeconds = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond.Value;
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
            Amazon.SageMaker.Model.TextGenerationJobConfig requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig = null;
            
             // populate TextGenerationJobConfig
            var requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfigIsNull = true;
            requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig = new Amazon.SageMaker.Model.TextGenerationJobConfig();
            System.String requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_textGenerationJobConfig_BaseModelName = null;
            if (cmdletContext.TextGenerationJobConfig_BaseModelName != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_textGenerationJobConfig_BaseModelName = cmdletContext.TextGenerationJobConfig_BaseModelName;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_textGenerationJobConfig_BaseModelName != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig.BaseModelName = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_textGenerationJobConfig_BaseModelName;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfigIsNull = false;
            }
            Dictionary<System.String, System.String> requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_textGenerationJobConfig_TextGenerationHyperParameter = null;
            if (cmdletContext.TextGenerationJobConfig_TextGenerationHyperParameter != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_textGenerationJobConfig_TextGenerationHyperParameter = cmdletContext.TextGenerationJobConfig_TextGenerationHyperParameter;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_textGenerationJobConfig_TextGenerationHyperParameter != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig.TextGenerationHyperParameters = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_textGenerationJobConfig_TextGenerationHyperParameter;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfigIsNull = false;
            }
            Amazon.SageMaker.Model.ModelAccessConfig requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_ModelAccessConfig = null;
            
             // populate ModelAccessConfig
            var requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_ModelAccessConfigIsNull = true;
            requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_ModelAccessConfig = new Amazon.SageMaker.Model.ModelAccessConfig();
            System.Boolean? requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_ModelAccessConfig_modelAccessConfig_AcceptEula = null;
            if (cmdletContext.ModelAccessConfig_AcceptEula != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_ModelAccessConfig_modelAccessConfig_AcceptEula = cmdletContext.ModelAccessConfig_AcceptEula.Value;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_ModelAccessConfig_modelAccessConfig_AcceptEula != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_ModelAccessConfig.AcceptEula = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_ModelAccessConfig_modelAccessConfig_AcceptEula.Value;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_ModelAccessConfigIsNull = false;
            }
             // determine if requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_ModelAccessConfig should be set to null
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_ModelAccessConfigIsNull)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_ModelAccessConfig = null;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_ModelAccessConfig != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig.ModelAccessConfig = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_ModelAccessConfig;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfigIsNull = false;
            }
            Amazon.SageMaker.Model.AutoMLJobCompletionCriteria requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria = null;
            
             // populate CompletionCriteria
            var requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteriaIsNull = true;
            requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria = new Amazon.SageMaker.Model.AutoMLJobCompletionCriteria();
            System.Int32? requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond = null;
            if (cmdletContext.AutoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond = cmdletContext.AutoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond.Value;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria.MaxAutoMLJobRuntimeInSeconds = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond.Value;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteriaIsNull = false;
            }
            System.Int32? requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_MaxCandidate = null;
            if (cmdletContext.AutoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_MaxCandidate != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_MaxCandidate = cmdletContext.AutoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_MaxCandidate.Value;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_MaxCandidate != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria.MaxCandidates = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_MaxCandidate.Value;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteriaIsNull = false;
            }
            System.Int32? requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond = null;
            if (cmdletContext.AutoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond = cmdletContext.AutoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond.Value;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria.MaxRuntimePerTrainingJobInSeconds = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond.Value;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteriaIsNull = false;
            }
             // determine if requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria should be set to null
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteriaIsNull)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria = null;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig.CompletionCriteria = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_autoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfigIsNull = false;
            }
             // determine if requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig should be set to null
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfigIsNull)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig = null;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig != null)
            {
                request.AutoMLProblemTypeConfig.TextGenerationJobConfig = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TextGenerationJobConfig;
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
            List<Amazon.SageMaker.Model.AutoMLAlgorithmConfig> requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CandidateGenerationConfig_tabularJobConfig_CandidateGenerationConfig_AlgorithmsConfig = null;
            if (cmdletContext.TabularJobConfig_CandidateGenerationConfig_AlgorithmsConfig != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CandidateGenerationConfig_tabularJobConfig_CandidateGenerationConfig_AlgorithmsConfig = cmdletContext.TabularJobConfig_CandidateGenerationConfig_AlgorithmsConfig;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CandidateGenerationConfig_tabularJobConfig_CandidateGenerationConfig_AlgorithmsConfig != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CandidateGenerationConfig.AlgorithmsConfig = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TabularJobConfig_autoMLProblemTypeConfig_TabularJobConfig_CandidateGenerationConfig_tabularJobConfig_CandidateGenerationConfig_AlgorithmsConfig;
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
            Amazon.SageMaker.Model.TimeSeriesForecastingJobConfig requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig = null;
            
             // populate TimeSeriesForecastingJobConfig
            var requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfigIsNull = true;
            requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig = new Amazon.SageMaker.Model.TimeSeriesForecastingJobConfig();
            System.String requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_timeSeriesForecastingJobConfig_FeatureSpecificationS3Uri = null;
            if (cmdletContext.TimeSeriesForecastingJobConfig_FeatureSpecificationS3Uri != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_timeSeriesForecastingJobConfig_FeatureSpecificationS3Uri = cmdletContext.TimeSeriesForecastingJobConfig_FeatureSpecificationS3Uri;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_timeSeriesForecastingJobConfig_FeatureSpecificationS3Uri != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig.FeatureSpecificationS3Uri = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_timeSeriesForecastingJobConfig_FeatureSpecificationS3Uri;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfigIsNull = false;
            }
            System.String requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_timeSeriesForecastingJobConfig_ForecastFrequency = null;
            if (cmdletContext.TimeSeriesForecastingJobConfig_ForecastFrequency != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_timeSeriesForecastingJobConfig_ForecastFrequency = cmdletContext.TimeSeriesForecastingJobConfig_ForecastFrequency;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_timeSeriesForecastingJobConfig_ForecastFrequency != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig.ForecastFrequency = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_timeSeriesForecastingJobConfig_ForecastFrequency;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfigIsNull = false;
            }
            System.Int32? requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_timeSeriesForecastingJobConfig_ForecastHorizon = null;
            if (cmdletContext.TimeSeriesForecastingJobConfig_ForecastHorizon != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_timeSeriesForecastingJobConfig_ForecastHorizon = cmdletContext.TimeSeriesForecastingJobConfig_ForecastHorizon.Value;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_timeSeriesForecastingJobConfig_ForecastHorizon != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig.ForecastHorizon = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_timeSeriesForecastingJobConfig_ForecastHorizon.Value;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfigIsNull = false;
            }
            List<System.String> requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_timeSeriesForecastingJobConfig_ForecastQuantile = null;
            if (cmdletContext.TimeSeriesForecastingJobConfig_ForecastQuantile != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_timeSeriesForecastingJobConfig_ForecastQuantile = cmdletContext.TimeSeriesForecastingJobConfig_ForecastQuantile;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_timeSeriesForecastingJobConfig_ForecastQuantile != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig.ForecastQuantiles = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_timeSeriesForecastingJobConfig_ForecastQuantile;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfigIsNull = false;
            }
            List<Amazon.SageMaker.Model.HolidayConfigAttributes> requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_timeSeriesForecastingJobConfig_HolidayConfig = null;
            if (cmdletContext.TimeSeriesForecastingJobConfig_HolidayConfig != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_timeSeriesForecastingJobConfig_HolidayConfig = cmdletContext.TimeSeriesForecastingJobConfig_HolidayConfig;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_timeSeriesForecastingJobConfig_HolidayConfig != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig.HolidayConfig = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_timeSeriesForecastingJobConfig_HolidayConfig;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfigIsNull = false;
            }
            Amazon.SageMaker.Model.CandidateGenerationConfig requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CandidateGenerationConfig = null;
            
             // populate CandidateGenerationConfig
            var requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CandidateGenerationConfigIsNull = true;
            requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CandidateGenerationConfig = new Amazon.SageMaker.Model.CandidateGenerationConfig();
            List<Amazon.SageMaker.Model.AutoMLAlgorithmConfig> requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CandidateGenerationConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CandidateGenerationConfig_AlgorithmsConfig = null;
            if (cmdletContext.AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CandidateGenerationConfig_AlgorithmsConfig != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CandidateGenerationConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CandidateGenerationConfig_AlgorithmsConfig = cmdletContext.AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CandidateGenerationConfig_AlgorithmsConfig;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CandidateGenerationConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CandidateGenerationConfig_AlgorithmsConfig != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CandidateGenerationConfig.AlgorithmsConfig = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CandidateGenerationConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CandidateGenerationConfig_AlgorithmsConfig;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CandidateGenerationConfigIsNull = false;
            }
             // determine if requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CandidateGenerationConfig should be set to null
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CandidateGenerationConfigIsNull)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CandidateGenerationConfig = null;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CandidateGenerationConfig != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig.CandidateGenerationConfig = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CandidateGenerationConfig;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfigIsNull = false;
            }
            Amazon.SageMaker.Model.TimeSeriesTransformations requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_Transformations = null;
            
             // populate Transformations
            var requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_TransformationsIsNull = true;
            requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_Transformations = new Amazon.SageMaker.Model.TimeSeriesTransformations();
            Dictionary<System.String, System.String> requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_Transformations_transformations_Aggregation = null;
            if (cmdletContext.Transformations_Aggregation != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_Transformations_transformations_Aggregation = cmdletContext.Transformations_Aggregation;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_Transformations_transformations_Aggregation != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_Transformations.Aggregation = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_Transformations_transformations_Aggregation;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_TransformationsIsNull = false;
            }
            Dictionary<System.String, Dictionary<System.String, System.String>> requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_Transformations_transformations_Filling = null;
            if (cmdletContext.Transformations_Filling != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_Transformations_transformations_Filling = cmdletContext.Transformations_Filling;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_Transformations_transformations_Filling != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_Transformations.Filling = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_Transformations_transformations_Filling;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_TransformationsIsNull = false;
            }
             // determine if requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_Transformations should be set to null
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_TransformationsIsNull)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_Transformations = null;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_Transformations != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig.Transformations = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_Transformations;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfigIsNull = false;
            }
            Amazon.SageMaker.Model.AutoMLJobCompletionCriteria requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria = null;
            
             // populate CompletionCriteria
            var requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteriaIsNull = true;
            requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria = new Amazon.SageMaker.Model.AutoMLJobCompletionCriteria();
            System.Int32? requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond = null;
            if (cmdletContext.AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond = cmdletContext.AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond.Value;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria.MaxAutoMLJobRuntimeInSeconds = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond.Value;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteriaIsNull = false;
            }
            System.Int32? requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_MaxCandidate = null;
            if (cmdletContext.AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_MaxCandidate != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_MaxCandidate = cmdletContext.AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_MaxCandidate.Value;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_MaxCandidate != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria.MaxCandidates = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_MaxCandidate.Value;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteriaIsNull = false;
            }
            System.Int32? requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond = null;
            if (cmdletContext.AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond = cmdletContext.AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond.Value;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria.MaxRuntimePerTrainingJobInSeconds = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond.Value;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteriaIsNull = false;
            }
             // determine if requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria should be set to null
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteriaIsNull)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria = null;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig.CompletionCriteria = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfigIsNull = false;
            }
            Amazon.SageMaker.Model.TimeSeriesConfig requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_TimeSeriesConfig = null;
            
             // populate TimeSeriesConfig
            var requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_TimeSeriesConfigIsNull = true;
            requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_TimeSeriesConfig = new Amazon.SageMaker.Model.TimeSeriesConfig();
            List<System.String> requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_TimeSeriesConfig_timeSeriesConfig_GroupingAttributeName = null;
            if (cmdletContext.TimeSeriesConfig_GroupingAttributeName != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_TimeSeriesConfig_timeSeriesConfig_GroupingAttributeName = cmdletContext.TimeSeriesConfig_GroupingAttributeName;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_TimeSeriesConfig_timeSeriesConfig_GroupingAttributeName != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_TimeSeriesConfig.GroupingAttributeNames = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_TimeSeriesConfig_timeSeriesConfig_GroupingAttributeName;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_TimeSeriesConfigIsNull = false;
            }
            System.String requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_TimeSeriesConfig_timeSeriesConfig_ItemIdentifierAttributeName = null;
            if (cmdletContext.TimeSeriesConfig_ItemIdentifierAttributeName != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_TimeSeriesConfig_timeSeriesConfig_ItemIdentifierAttributeName = cmdletContext.TimeSeriesConfig_ItemIdentifierAttributeName;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_TimeSeriesConfig_timeSeriesConfig_ItemIdentifierAttributeName != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_TimeSeriesConfig.ItemIdentifierAttributeName = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_TimeSeriesConfig_timeSeriesConfig_ItemIdentifierAttributeName;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_TimeSeriesConfigIsNull = false;
            }
            System.String requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_TimeSeriesConfig_timeSeriesConfig_TargetAttributeName = null;
            if (cmdletContext.TimeSeriesConfig_TargetAttributeName != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_TimeSeriesConfig_timeSeriesConfig_TargetAttributeName = cmdletContext.TimeSeriesConfig_TargetAttributeName;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_TimeSeriesConfig_timeSeriesConfig_TargetAttributeName != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_TimeSeriesConfig.TargetAttributeName = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_TimeSeriesConfig_timeSeriesConfig_TargetAttributeName;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_TimeSeriesConfigIsNull = false;
            }
            System.String requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_TimeSeriesConfig_timeSeriesConfig_TimestampAttributeName = null;
            if (cmdletContext.TimeSeriesConfig_TimestampAttributeName != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_TimeSeriesConfig_timeSeriesConfig_TimestampAttributeName = cmdletContext.TimeSeriesConfig_TimestampAttributeName;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_TimeSeriesConfig_timeSeriesConfig_TimestampAttributeName != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_TimeSeriesConfig.TimestampAttributeName = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_TimeSeriesConfig_timeSeriesConfig_TimestampAttributeName;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_TimeSeriesConfigIsNull = false;
            }
             // determine if requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_TimeSeriesConfig should be set to null
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_TimeSeriesConfigIsNull)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_TimeSeriesConfig = null;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_TimeSeriesConfig != null)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig.TimeSeriesConfig = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_TimeSeriesConfig;
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfigIsNull = false;
            }
             // determine if requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig should be set to null
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfigIsNull)
            {
                requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig = null;
            }
            if (requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig != null)
            {
                request.AutoMLProblemTypeConfig.TimeSeriesForecastingJobConfig = requestAutoMLProblemTypeConfig_autoMLProblemTypeConfig_TimeSeriesForecastingJobConfig;
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
            public System.String EmrServerlessComputeConfig_ExecutionRoleARN { get; set; }
            public List<Amazon.SageMaker.Model.AutoMLJobChannel> AutoMLJobInputDataConfig { get; set; }
            public System.String AutoMLJobName { get; set; }
            public Amazon.SageMaker.AutoMLMetricEnum AutoMLJobObjective_MetricName { get; set; }
            public System.Int32? AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond { get; set; }
            public System.Int32? AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxCandidate { get; set; }
            public System.Int32? AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond { get; set; }
            public List<Amazon.SageMaker.Model.AutoMLAlgorithmConfig> TabularJobConfig_CandidateGenerationConfig_AlgorithmsConfig { get; set; }
            public System.Int32? CompletionCriteria_MaxAutoMLJobRuntimeInSecond { get; set; }
            public System.Int32? CompletionCriteria_MaxCandidate { get; set; }
            public System.Int32? CompletionCriteria_MaxRuntimePerTrainingJobInSecond { get; set; }
            public System.String TabularJobConfig_FeatureSpecificationS3Uri { get; set; }
            public System.Boolean? TabularJobConfig_GenerateCandidateDefinitionsOnly { get; set; }
            public Amazon.SageMaker.AutoMLMode TabularJobConfig_Mode { get; set; }
            public Amazon.SageMaker.ProblemType TabularJobConfig_ProblemType { get; set; }
            public System.String TabularJobConfig_SampleWeightAttributeName { get; set; }
            public System.String TabularJobConfig_TargetAttributeName { get; set; }
            public System.Int32? AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond { get; set; }
            public System.Int32? AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxCandidate { get; set; }
            public System.Int32? AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond { get; set; }
            public System.String TextClassificationJobConfig_ContentColumn { get; set; }
            public System.String TextClassificationJobConfig_TargetLabelColumn { get; set; }
            public System.String TextGenerationJobConfig_BaseModelName { get; set; }
            public System.Int32? AutoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond { get; set; }
            public System.Int32? AutoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_MaxCandidate { get; set; }
            public System.Int32? AutoMLProblemTypeConfig_TextGenerationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond { get; set; }
            public System.Boolean? ModelAccessConfig_AcceptEula { get; set; }
            public Dictionary<System.String, System.String> TextGenerationJobConfig_TextGenerationHyperParameter { get; set; }
            public List<Amazon.SageMaker.Model.AutoMLAlgorithmConfig> AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CandidateGenerationConfig_AlgorithmsConfig { get; set; }
            public System.Int32? AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond { get; set; }
            public System.Int32? AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_MaxCandidate { get; set; }
            public System.Int32? AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond { get; set; }
            public System.String TimeSeriesForecastingJobConfig_FeatureSpecificationS3Uri { get; set; }
            public System.String TimeSeriesForecastingJobConfig_ForecastFrequency { get; set; }
            public System.Int32? TimeSeriesForecastingJobConfig_ForecastHorizon { get; set; }
            public List<System.String> TimeSeriesForecastingJobConfig_ForecastQuantile { get; set; }
            public List<Amazon.SageMaker.Model.HolidayConfigAttributes> TimeSeriesForecastingJobConfig_HolidayConfig { get; set; }
            public List<System.String> TimeSeriesConfig_GroupingAttributeName { get; set; }
            public System.String TimeSeriesConfig_ItemIdentifierAttributeName { get; set; }
            public System.String TimeSeriesConfig_TargetAttributeName { get; set; }
            public System.String TimeSeriesConfig_TimestampAttributeName { get; set; }
            public Dictionary<System.String, System.String> Transformations_Aggregation { get; set; }
            public Dictionary<System.String, Dictionary<System.String, System.String>> Transformations_Filling { get; set; }
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
