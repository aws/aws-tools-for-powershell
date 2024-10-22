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
using Amazon.ForecastService;
using Amazon.ForecastService.Model;

namespace Amazon.PowerShell.Cmdlets.FRC
{
    /// <summary>
    /// <note><para>
    ///  This operation creates a legacy predictor that does not include all the predictor
    /// functionalities provided by Amazon Forecast. To create a predictor that is compatible
    /// with all aspects of Forecast, use <a>CreateAutoPredictor</a>.
    /// </para></note><para>
    /// Creates an Amazon Forecast predictor.
    /// </para><para>
    /// In the request, provide a dataset group and either specify an algorithm or let Amazon
    /// Forecast choose an algorithm for you using AutoML. If you specify an algorithm, you
    /// also can override algorithm-specific hyperparameters.
    /// </para><para>
    /// Amazon Forecast uses the algorithm to train a predictor using the latest version of
    /// the datasets in the specified dataset group. You can then generate a forecast using
    /// the <a>CreateForecast</a> operation.
    /// </para><para>
    ///  To see the evaluation metrics, use the <a>GetAccuracyMetrics</a> operation. 
    /// </para><para>
    /// You can specify a featurization configuration to fill and aggregate the data fields
    /// in the <c>TARGET_TIME_SERIES</c> dataset to improve model training. For more information,
    /// see <a>FeaturizationConfig</a>.
    /// </para><para>
    /// For RELATED_TIME_SERIES datasets, <c>CreatePredictor</c> verifies that the <c>DataFrequency</c>
    /// specified when the dataset was created matches the <c>ForecastFrequency</c>. TARGET_TIME_SERIES
    /// datasets don't have this restriction. Amazon Forecast also verifies the delimiter
    /// and timestamp format. For more information, see <a>howitworks-datasets-groups</a>.
    /// </para><para>
    /// By default, predictors are trained and evaluated at the 0.1 (P10), 0.5 (P50), and
    /// 0.9 (P90) quantiles. You can choose custom forecast types to train and evaluate your
    /// predictor by setting the <c>ForecastTypes</c>. 
    /// </para><para><b>AutoML</b></para><para>
    /// If you want Amazon Forecast to evaluate each algorithm and choose the one that minimizes
    /// the <c>objective function</c>, set <c>PerformAutoML</c> to <c>true</c>. The <c>objective
    /// function</c> is defined as the mean of the weighted losses over the forecast types.
    /// By default, these are the p10, p50, and p90 quantile losses. For more information,
    /// see <a>EvaluationResult</a>.
    /// </para><para>
    /// When AutoML is enabled, the following properties are disallowed:
    /// </para><ul><li><para><c>AlgorithmArn</c></para></li><li><para><c>HPOConfig</c></para></li><li><para><c>PerformHPO</c></para></li><li><para><c>TrainingParameters</c></para></li></ul><para>
    /// To get a list of all of your predictors, use the <a>ListPredictors</a> operation.
    /// </para><note><para>
    /// Before you can use the predictor to create a forecast, the <c>Status</c> of the predictor
    /// must be <c>ACTIVE</c>, signifying that training has completed. To get the status,
    /// use the <a>DescribePredictor</a> operation.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "FRCPredictor", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Forecast Service CreatePredictor API operation.", Operation = new[] {"CreatePredictor"}, SelectReturnType = typeof(Amazon.ForecastService.Model.CreatePredictorResponse))]
    [AWSCmdletOutput("System.String or Amazon.ForecastService.Model.CreatePredictorResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ForecastService.Model.CreatePredictorResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewFRCPredictorCmdlet : AmazonForecastServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AlgorithmArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the algorithm to use for model training. Required
        /// if <c>PerformAutoML</c> is not set to <c>true</c>.</para><para><b>Supported algorithms:</b></para><ul><li><para><c>arn:aws:forecast:::algorithm/ARIMA</c></para></li><li><para><c>arn:aws:forecast:::algorithm/CNN-QR</c></para></li><li><para><c>arn:aws:forecast:::algorithm/Deep_AR_Plus</c></para></li><li><para><c>arn:aws:forecast:::algorithm/ETS</c></para></li><li><para><c>arn:aws:forecast:::algorithm/NPTS</c></para></li><li><para><c>arn:aws:forecast:::algorithm/Prophet</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AlgorithmArn { get; set; }
        #endregion
        
        #region Parameter AutoMLOverrideStrategy
        /// <summary>
        /// <para>
        /// <note><para> The <c>LatencyOptimized</c> AutoML override strategy is only available in private
        /// beta. Contact Amazon Web Services Support or your account manager to learn more about
        /// access privileges. </para></note><para>Used to overide the default AutoML strategy, which is to optimize predictor accuracy.
        /// To apply an AutoML strategy that minimizes training time, use <c>LatencyOptimized</c>.</para><para>This parameter is only valid for predictors trained using AutoML.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ForecastService.AutoMLOverrideStrategy")]
        public Amazon.ForecastService.AutoMLOverrideStrategy AutoMLOverrideStrategy { get; set; }
        #endregion
        
        #region Parameter EvaluationParameters_BackTestWindowOffset
        /// <summary>
        /// <para>
        /// <para>The point from the end of the dataset where you want to split the data for model training
        /// and testing (evaluation). Specify the value as the number of data points. The default
        /// is the value of the forecast horizon. <c>BackTestWindowOffset</c> can be used to mimic
        /// a past virtual forecast start date. This value must be greater than or equal to the
        /// forecast horizon and less than half of the TARGET_TIME_SERIES dataset length.</para><para><c>ForecastHorizon</c> &lt;= <c>BackTestWindowOffset</c> &lt; 1/2 * TARGET_TIME_SERIES
        /// dataset length</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? EvaluationParameters_BackTestWindowOffset { get; set; }
        #endregion
        
        #region Parameter ParameterRanges_CategoricalParameterRange
        /// <summary>
        /// <para>
        /// <para>Specifies the tunable range for each categorical hyperparameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HPOConfig_ParameterRanges_CategoricalParameterRanges")]
        public Amazon.ForecastService.Model.CategoricalParameterRange[] ParameterRanges_CategoricalParameterRange { get; set; }
        #endregion
        
        #region Parameter ParameterRanges_ContinuousParameterRange
        /// <summary>
        /// <para>
        /// <para>Specifies the tunable range for each continuous hyperparameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HPOConfig_ParameterRanges_ContinuousParameterRanges")]
        public Amazon.ForecastService.Model.ContinuousParameterRange[] ParameterRanges_ContinuousParameterRange { get; set; }
        #endregion
        
        #region Parameter InputDataConfig_DatasetGroupArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the dataset group.</para>
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
        public System.String InputDataConfig_DatasetGroupArn { get; set; }
        #endregion
        
        #region Parameter FeaturizationConfig_Featurization
        /// <summary>
        /// <para>
        /// <para>An array of featurization (transformation) information for the fields of a dataset.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FeaturizationConfig_Featurizations")]
        public Amazon.ForecastService.Model.Featurization[] FeaturizationConfig_Featurization { get; set; }
        #endregion
        
        #region Parameter FeaturizationConfig_ForecastDimension
        /// <summary>
        /// <para>
        /// <para>An array of dimension (field) names that specify how to group the generated forecast.</para><para>For example, suppose that you are generating a forecast for item sales across all
        /// of your stores, and your dataset contains a <c>store_id</c> field. If you want the
        /// sales forecast for each item by store, you would specify <c>store_id</c> as the dimension.</para><para>All forecast dimensions specified in the <c>TARGET_TIME_SERIES</c> dataset don't need
        /// to be specified in the <c>CreatePredictor</c> request. All forecast dimensions specified
        /// in the <c>RELATED_TIME_SERIES</c> dataset must be specified in the <c>CreatePredictor</c>
        /// request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FeaturizationConfig_ForecastDimensions")]
        public System.String[] FeaturizationConfig_ForecastDimension { get; set; }
        #endregion
        
        #region Parameter FeaturizationConfig_ForecastFrequency
        /// <summary>
        /// <para>
        /// <para>The frequency of predictions in a forecast.</para><para>Valid intervals are an integer followed by Y (Year), M (Month), W (Week), D (Day),
        /// H (Hour), and min (Minute). For example, "1D" indicates every day and "15min" indicates
        /// every 15 minutes. You cannot specify a value that would overlap with the next larger
        /// frequency. That means, for example, you cannot specify a frequency of 60 minutes,
        /// because that is equivalent to 1 hour. The valid values for each frequency are the
        /// following:</para><ul><li><para>Minute - 1-59</para></li><li><para>Hour - 1-23</para></li><li><para>Day - 1-6</para></li><li><para>Week - 1-4</para></li><li><para>Month - 1-11</para></li><li><para>Year - 1</para></li></ul><para>Thus, if you want every other week forecasts, specify "2W". Or, if you want quarterly
        /// forecasts, you specify "3M".</para><para>The frequency must be greater than or equal to the TARGET_TIME_SERIES dataset frequency.</para><para>When a RELATED_TIME_SERIES dataset is provided, the frequency must be equal to the
        /// TARGET_TIME_SERIES dataset frequency.</para>
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
        public System.String FeaturizationConfig_ForecastFrequency { get; set; }
        #endregion
        
        #region Parameter ForecastHorizon
        /// <summary>
        /// <para>
        /// <para>Specifies the number of time-steps that the model is trained to predict. The forecast
        /// horizon is also called the prediction length.</para><para>For example, if you configure a dataset for daily data collection (using the <c>DataFrequency</c>
        /// parameter of the <a>CreateDataset</a> operation) and set the forecast horizon to 10,
        /// the model returns predictions for 10 days.</para><para>The maximum forecast horizon is the lesser of 500 time-steps or 1/3 of the TARGET_TIME_SERIES
        /// dataset length.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? ForecastHorizon { get; set; }
        #endregion
        
        #region Parameter ForecastType
        /// <summary>
        /// <para>
        /// <para>Specifies the forecast types used to train a predictor. You can specify up to five
        /// forecast types. Forecast types can be quantiles from 0.01 to 0.99, by increments of
        /// 0.01 or higher. You can also specify the mean forecast with <c>mean</c>. </para><para>The default value is <c>["0.10", "0.50", "0.9"]</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ForecastTypes")]
        public System.String[] ForecastType { get; set; }
        #endregion
        
        #region Parameter ParameterRanges_IntegerParameterRange
        /// <summary>
        /// <para>
        /// <para>Specifies the tunable range for each integer hyperparameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HPOConfig_ParameterRanges_IntegerParameterRanges")]
        public Amazon.ForecastService.Model.IntegerParameterRange[] ParameterRanges_IntegerParameterRange { get; set; }
        #endregion
        
        #region Parameter EncryptionConfig_KMSKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the KMS key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionConfig_KMSKeyArn { get; set; }
        #endregion
        
        #region Parameter EvaluationParameters_NumberOfBacktestWindow
        /// <summary>
        /// <para>
        /// <para>The number of times to split the input data. The default is 1. Valid values are 1
        /// through 5.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EvaluationParameters_NumberOfBacktestWindows")]
        public System.Int32? EvaluationParameters_NumberOfBacktestWindow { get; set; }
        #endregion
        
        #region Parameter OptimizationMetric
        /// <summary>
        /// <para>
        /// <para>The accuracy metric used to optimize the predictor.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ForecastService.OptimizationMetric")]
        public Amazon.ForecastService.OptimizationMetric OptimizationMetric { get; set; }
        #endregion
        
        #region Parameter PerformAutoML
        /// <summary>
        /// <para>
        /// <para>Whether to perform AutoML. When Amazon Forecast performs AutoML, it evaluates the
        /// algorithms it provides and chooses the best algorithm and configuration for your training
        /// dataset.</para><para>The default value is <c>false</c>. In this case, you are required to specify an algorithm.</para><para>Set <c>PerformAutoML</c> to <c>true</c> to have Amazon Forecast perform AutoML. This
        /// is a good option if you aren't sure which algorithm is suitable for your training
        /// data. In this case, <c>PerformHPO</c> must be false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PerformAutoML { get; set; }
        #endregion
        
        #region Parameter PerformHPO
        /// <summary>
        /// <para>
        /// <para>Whether to perform hyperparameter optimization (HPO). HPO finds optimal hyperparameter
        /// values for your training data. The process of performing HPO is known as running a
        /// hyperparameter tuning job.</para><para>The default value is <c>false</c>. In this case, Amazon Forecast uses default hyperparameter
        /// values from the chosen algorithm.</para><para>To override the default values, set <c>PerformHPO</c> to <c>true</c> and, optionally,
        /// supply the <a>HyperParameterTuningJobConfig</a> object. The tuning job specifies a
        /// metric to optimize, which hyperparameters participate in tuning, and the valid range
        /// for each tunable hyperparameter. In this case, you are required to specify an algorithm
        /// and <c>PerformAutoML</c> must be false.</para><para>The following algorithms support HPO:</para><ul><li><para>DeepAR+</para></li><li><para>CNN-QR</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PerformHPO { get; set; }
        #endregion
        
        #region Parameter PredictorName
        /// <summary>
        /// <para>
        /// <para>A name for the predictor.</para>
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
        public System.String PredictorName { get; set; }
        #endregion
        
        #region Parameter EncryptionConfig_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that Amazon Forecast can assume to access the KMS key.</para><para>Passing a role across Amazon Web Services accounts is not allowed. If you pass a role
        /// that isn't in your account, you get an <c>InvalidInputException</c> error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionConfig_RoleArn { get; set; }
        #endregion
        
        #region Parameter InputDataConfig_SupplementaryFeature
        /// <summary>
        /// <para>
        /// <para>An array of supplementary features. The only supported feature is a holiday calendar.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputDataConfig_SupplementaryFeatures")]
        public Amazon.ForecastService.Model.SupplementaryFeature[] InputDataConfig_SupplementaryFeature { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The optional metadata that you apply to the predictor to help you categorize and organize
        /// them. Each tag consists of a key and an optional value, both of which you define.</para><para>The following basic restrictions apply to tags:</para><ul><li><para>Maximum number of tags per resource - 50.</para></li><li><para>For each resource, each tag key must be unique, and each tag key can have only one
        /// value.</para></li><li><para>Maximum key length - 128 Unicode characters in UTF-8.</para></li><li><para>Maximum value length - 256 Unicode characters in UTF-8.</para></li><li><para>If your tagging schema is used across multiple services and resources, remember that
        /// other services may have restrictions on allowed characters. Generally allowed characters
        /// are: letters, numbers, and spaces representable in UTF-8, and the following characters:
        /// + - = . _ : / @.</para></li><li><para>Tag keys and values are case sensitive.</para></li><li><para>Do not use <c>aws:</c>, <c>AWS:</c>, or any upper or lowercase combination of such
        /// as a prefix for keys as it is reserved for Amazon Web Services use. You cannot edit
        /// or delete tag keys with this prefix. Values can have this prefix. If a tag value has
        /// <c>aws</c> as its prefix but the key does not, then Forecast considers it to be a
        /// user tag and will count against the limit of 50 tags. Tags with only the key prefix
        /// of <c>aws</c> do not count against your tags per resource limit.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ForecastService.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TrainingParameter
        /// <summary>
        /// <para>
        /// <para>The hyperparameters to override for model training. The hyperparameters that you can
        /// override are listed in the individual algorithms. For the list of supported algorithms,
        /// see <a>aws-forecast-choosing-recipes</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrainingParameters")]
        public System.Collections.Hashtable TrainingParameter { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PredictorArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ForecastService.Model.CreatePredictorResponse).
        /// Specifying the name of a property of type Amazon.ForecastService.Model.CreatePredictorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PredictorArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PredictorName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-FRCPredictor (CreatePredictor)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ForecastService.Model.CreatePredictorResponse, NewFRCPredictorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AlgorithmArn = this.AlgorithmArn;
            context.AutoMLOverrideStrategy = this.AutoMLOverrideStrategy;
            context.EncryptionConfig_KMSKeyArn = this.EncryptionConfig_KMSKeyArn;
            context.EncryptionConfig_RoleArn = this.EncryptionConfig_RoleArn;
            context.EvaluationParameters_BackTestWindowOffset = this.EvaluationParameters_BackTestWindowOffset;
            context.EvaluationParameters_NumberOfBacktestWindow = this.EvaluationParameters_NumberOfBacktestWindow;
            if (this.FeaturizationConfig_Featurization != null)
            {
                context.FeaturizationConfig_Featurization = new List<Amazon.ForecastService.Model.Featurization>(this.FeaturizationConfig_Featurization);
            }
            if (this.FeaturizationConfig_ForecastDimension != null)
            {
                context.FeaturizationConfig_ForecastDimension = new List<System.String>(this.FeaturizationConfig_ForecastDimension);
            }
            context.FeaturizationConfig_ForecastFrequency = this.FeaturizationConfig_ForecastFrequency;
            #if MODULAR
            if (this.FeaturizationConfig_ForecastFrequency == null && ParameterWasBound(nameof(this.FeaturizationConfig_ForecastFrequency)))
            {
                WriteWarning("You are passing $null as a value for parameter FeaturizationConfig_ForecastFrequency which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ForecastHorizon = this.ForecastHorizon;
            #if MODULAR
            if (this.ForecastHorizon == null && ParameterWasBound(nameof(this.ForecastHorizon)))
            {
                WriteWarning("You are passing $null as a value for parameter ForecastHorizon which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ForecastType != null)
            {
                context.ForecastType = new List<System.String>(this.ForecastType);
            }
            if (this.ParameterRanges_CategoricalParameterRange != null)
            {
                context.ParameterRanges_CategoricalParameterRange = new List<Amazon.ForecastService.Model.CategoricalParameterRange>(this.ParameterRanges_CategoricalParameterRange);
            }
            if (this.ParameterRanges_ContinuousParameterRange != null)
            {
                context.ParameterRanges_ContinuousParameterRange = new List<Amazon.ForecastService.Model.ContinuousParameterRange>(this.ParameterRanges_ContinuousParameterRange);
            }
            if (this.ParameterRanges_IntegerParameterRange != null)
            {
                context.ParameterRanges_IntegerParameterRange = new List<Amazon.ForecastService.Model.IntegerParameterRange>(this.ParameterRanges_IntegerParameterRange);
            }
            context.InputDataConfig_DatasetGroupArn = this.InputDataConfig_DatasetGroupArn;
            #if MODULAR
            if (this.InputDataConfig_DatasetGroupArn == null && ParameterWasBound(nameof(this.InputDataConfig_DatasetGroupArn)))
            {
                WriteWarning("You are passing $null as a value for parameter InputDataConfig_DatasetGroupArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.InputDataConfig_SupplementaryFeature != null)
            {
                context.InputDataConfig_SupplementaryFeature = new List<Amazon.ForecastService.Model.SupplementaryFeature>(this.InputDataConfig_SupplementaryFeature);
            }
            context.OptimizationMetric = this.OptimizationMetric;
            context.PerformAutoML = this.PerformAutoML;
            context.PerformHPO = this.PerformHPO;
            context.PredictorName = this.PredictorName;
            #if MODULAR
            if (this.PredictorName == null && ParameterWasBound(nameof(this.PredictorName)))
            {
                WriteWarning("You are passing $null as a value for parameter PredictorName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ForecastService.Model.Tag>(this.Tag);
            }
            if (this.TrainingParameter != null)
            {
                context.TrainingParameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.TrainingParameter.Keys)
                {
                    context.TrainingParameter.Add((String)hashKey, (System.String)(this.TrainingParameter[hashKey]));
                }
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
            var request = new Amazon.ForecastService.Model.CreatePredictorRequest();
            
            if (cmdletContext.AlgorithmArn != null)
            {
                request.AlgorithmArn = cmdletContext.AlgorithmArn;
            }
            if (cmdletContext.AutoMLOverrideStrategy != null)
            {
                request.AutoMLOverrideStrategy = cmdletContext.AutoMLOverrideStrategy;
            }
            
             // populate EncryptionConfig
            var requestEncryptionConfigIsNull = true;
            request.EncryptionConfig = new Amazon.ForecastService.Model.EncryptionConfig();
            System.String requestEncryptionConfig_encryptionConfig_KMSKeyArn = null;
            if (cmdletContext.EncryptionConfig_KMSKeyArn != null)
            {
                requestEncryptionConfig_encryptionConfig_KMSKeyArn = cmdletContext.EncryptionConfig_KMSKeyArn;
            }
            if (requestEncryptionConfig_encryptionConfig_KMSKeyArn != null)
            {
                request.EncryptionConfig.KMSKeyArn = requestEncryptionConfig_encryptionConfig_KMSKeyArn;
                requestEncryptionConfigIsNull = false;
            }
            System.String requestEncryptionConfig_encryptionConfig_RoleArn = null;
            if (cmdletContext.EncryptionConfig_RoleArn != null)
            {
                requestEncryptionConfig_encryptionConfig_RoleArn = cmdletContext.EncryptionConfig_RoleArn;
            }
            if (requestEncryptionConfig_encryptionConfig_RoleArn != null)
            {
                request.EncryptionConfig.RoleArn = requestEncryptionConfig_encryptionConfig_RoleArn;
                requestEncryptionConfigIsNull = false;
            }
             // determine if request.EncryptionConfig should be set to null
            if (requestEncryptionConfigIsNull)
            {
                request.EncryptionConfig = null;
            }
            
             // populate EvaluationParameters
            var requestEvaluationParametersIsNull = true;
            request.EvaluationParameters = new Amazon.ForecastService.Model.EvaluationParameters();
            System.Int32? requestEvaluationParameters_evaluationParameters_BackTestWindowOffset = null;
            if (cmdletContext.EvaluationParameters_BackTestWindowOffset != null)
            {
                requestEvaluationParameters_evaluationParameters_BackTestWindowOffset = cmdletContext.EvaluationParameters_BackTestWindowOffset.Value;
            }
            if (requestEvaluationParameters_evaluationParameters_BackTestWindowOffset != null)
            {
                request.EvaluationParameters.BackTestWindowOffset = requestEvaluationParameters_evaluationParameters_BackTestWindowOffset.Value;
                requestEvaluationParametersIsNull = false;
            }
            System.Int32? requestEvaluationParameters_evaluationParameters_NumberOfBacktestWindow = null;
            if (cmdletContext.EvaluationParameters_NumberOfBacktestWindow != null)
            {
                requestEvaluationParameters_evaluationParameters_NumberOfBacktestWindow = cmdletContext.EvaluationParameters_NumberOfBacktestWindow.Value;
            }
            if (requestEvaluationParameters_evaluationParameters_NumberOfBacktestWindow != null)
            {
                request.EvaluationParameters.NumberOfBacktestWindows = requestEvaluationParameters_evaluationParameters_NumberOfBacktestWindow.Value;
                requestEvaluationParametersIsNull = false;
            }
             // determine if request.EvaluationParameters should be set to null
            if (requestEvaluationParametersIsNull)
            {
                request.EvaluationParameters = null;
            }
            
             // populate FeaturizationConfig
            var requestFeaturizationConfigIsNull = true;
            request.FeaturizationConfig = new Amazon.ForecastService.Model.FeaturizationConfig();
            List<Amazon.ForecastService.Model.Featurization> requestFeaturizationConfig_featurizationConfig_Featurization = null;
            if (cmdletContext.FeaturizationConfig_Featurization != null)
            {
                requestFeaturizationConfig_featurizationConfig_Featurization = cmdletContext.FeaturizationConfig_Featurization;
            }
            if (requestFeaturizationConfig_featurizationConfig_Featurization != null)
            {
                request.FeaturizationConfig.Featurizations = requestFeaturizationConfig_featurizationConfig_Featurization;
                requestFeaturizationConfigIsNull = false;
            }
            List<System.String> requestFeaturizationConfig_featurizationConfig_ForecastDimension = null;
            if (cmdletContext.FeaturizationConfig_ForecastDimension != null)
            {
                requestFeaturizationConfig_featurizationConfig_ForecastDimension = cmdletContext.FeaturizationConfig_ForecastDimension;
            }
            if (requestFeaturizationConfig_featurizationConfig_ForecastDimension != null)
            {
                request.FeaturizationConfig.ForecastDimensions = requestFeaturizationConfig_featurizationConfig_ForecastDimension;
                requestFeaturizationConfigIsNull = false;
            }
            System.String requestFeaturizationConfig_featurizationConfig_ForecastFrequency = null;
            if (cmdletContext.FeaturizationConfig_ForecastFrequency != null)
            {
                requestFeaturizationConfig_featurizationConfig_ForecastFrequency = cmdletContext.FeaturizationConfig_ForecastFrequency;
            }
            if (requestFeaturizationConfig_featurizationConfig_ForecastFrequency != null)
            {
                request.FeaturizationConfig.ForecastFrequency = requestFeaturizationConfig_featurizationConfig_ForecastFrequency;
                requestFeaturizationConfigIsNull = false;
            }
             // determine if request.FeaturizationConfig should be set to null
            if (requestFeaturizationConfigIsNull)
            {
                request.FeaturizationConfig = null;
            }
            if (cmdletContext.ForecastHorizon != null)
            {
                request.ForecastHorizon = cmdletContext.ForecastHorizon.Value;
            }
            if (cmdletContext.ForecastType != null)
            {
                request.ForecastTypes = cmdletContext.ForecastType;
            }
            
             // populate HPOConfig
            var requestHPOConfigIsNull = true;
            request.HPOConfig = new Amazon.ForecastService.Model.HyperParameterTuningJobConfig();
            Amazon.ForecastService.Model.ParameterRanges requestHPOConfig_hPOConfig_ParameterRanges = null;
            
             // populate ParameterRanges
            var requestHPOConfig_hPOConfig_ParameterRangesIsNull = true;
            requestHPOConfig_hPOConfig_ParameterRanges = new Amazon.ForecastService.Model.ParameterRanges();
            List<Amazon.ForecastService.Model.CategoricalParameterRange> requestHPOConfig_hPOConfig_ParameterRanges_parameterRanges_CategoricalParameterRange = null;
            if (cmdletContext.ParameterRanges_CategoricalParameterRange != null)
            {
                requestHPOConfig_hPOConfig_ParameterRanges_parameterRanges_CategoricalParameterRange = cmdletContext.ParameterRanges_CategoricalParameterRange;
            }
            if (requestHPOConfig_hPOConfig_ParameterRanges_parameterRanges_CategoricalParameterRange != null)
            {
                requestHPOConfig_hPOConfig_ParameterRanges.CategoricalParameterRanges = requestHPOConfig_hPOConfig_ParameterRanges_parameterRanges_CategoricalParameterRange;
                requestHPOConfig_hPOConfig_ParameterRangesIsNull = false;
            }
            List<Amazon.ForecastService.Model.ContinuousParameterRange> requestHPOConfig_hPOConfig_ParameterRanges_parameterRanges_ContinuousParameterRange = null;
            if (cmdletContext.ParameterRanges_ContinuousParameterRange != null)
            {
                requestHPOConfig_hPOConfig_ParameterRanges_parameterRanges_ContinuousParameterRange = cmdletContext.ParameterRanges_ContinuousParameterRange;
            }
            if (requestHPOConfig_hPOConfig_ParameterRanges_parameterRanges_ContinuousParameterRange != null)
            {
                requestHPOConfig_hPOConfig_ParameterRanges.ContinuousParameterRanges = requestHPOConfig_hPOConfig_ParameterRanges_parameterRanges_ContinuousParameterRange;
                requestHPOConfig_hPOConfig_ParameterRangesIsNull = false;
            }
            List<Amazon.ForecastService.Model.IntegerParameterRange> requestHPOConfig_hPOConfig_ParameterRanges_parameterRanges_IntegerParameterRange = null;
            if (cmdletContext.ParameterRanges_IntegerParameterRange != null)
            {
                requestHPOConfig_hPOConfig_ParameterRanges_parameterRanges_IntegerParameterRange = cmdletContext.ParameterRanges_IntegerParameterRange;
            }
            if (requestHPOConfig_hPOConfig_ParameterRanges_parameterRanges_IntegerParameterRange != null)
            {
                requestHPOConfig_hPOConfig_ParameterRanges.IntegerParameterRanges = requestHPOConfig_hPOConfig_ParameterRanges_parameterRanges_IntegerParameterRange;
                requestHPOConfig_hPOConfig_ParameterRangesIsNull = false;
            }
             // determine if requestHPOConfig_hPOConfig_ParameterRanges should be set to null
            if (requestHPOConfig_hPOConfig_ParameterRangesIsNull)
            {
                requestHPOConfig_hPOConfig_ParameterRanges = null;
            }
            if (requestHPOConfig_hPOConfig_ParameterRanges != null)
            {
                request.HPOConfig.ParameterRanges = requestHPOConfig_hPOConfig_ParameterRanges;
                requestHPOConfigIsNull = false;
            }
             // determine if request.HPOConfig should be set to null
            if (requestHPOConfigIsNull)
            {
                request.HPOConfig = null;
            }
            
             // populate InputDataConfig
            var requestInputDataConfigIsNull = true;
            request.InputDataConfig = new Amazon.ForecastService.Model.InputDataConfig();
            System.String requestInputDataConfig_inputDataConfig_DatasetGroupArn = null;
            if (cmdletContext.InputDataConfig_DatasetGroupArn != null)
            {
                requestInputDataConfig_inputDataConfig_DatasetGroupArn = cmdletContext.InputDataConfig_DatasetGroupArn;
            }
            if (requestInputDataConfig_inputDataConfig_DatasetGroupArn != null)
            {
                request.InputDataConfig.DatasetGroupArn = requestInputDataConfig_inputDataConfig_DatasetGroupArn;
                requestInputDataConfigIsNull = false;
            }
            List<Amazon.ForecastService.Model.SupplementaryFeature> requestInputDataConfig_inputDataConfig_SupplementaryFeature = null;
            if (cmdletContext.InputDataConfig_SupplementaryFeature != null)
            {
                requestInputDataConfig_inputDataConfig_SupplementaryFeature = cmdletContext.InputDataConfig_SupplementaryFeature;
            }
            if (requestInputDataConfig_inputDataConfig_SupplementaryFeature != null)
            {
                request.InputDataConfig.SupplementaryFeatures = requestInputDataConfig_inputDataConfig_SupplementaryFeature;
                requestInputDataConfigIsNull = false;
            }
             // determine if request.InputDataConfig should be set to null
            if (requestInputDataConfigIsNull)
            {
                request.InputDataConfig = null;
            }
            if (cmdletContext.OptimizationMetric != null)
            {
                request.OptimizationMetric = cmdletContext.OptimizationMetric;
            }
            if (cmdletContext.PerformAutoML != null)
            {
                request.PerformAutoML = cmdletContext.PerformAutoML.Value;
            }
            if (cmdletContext.PerformHPO != null)
            {
                request.PerformHPO = cmdletContext.PerformHPO.Value;
            }
            if (cmdletContext.PredictorName != null)
            {
                request.PredictorName = cmdletContext.PredictorName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TrainingParameter != null)
            {
                request.TrainingParameters = cmdletContext.TrainingParameter;
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
        
        private Amazon.ForecastService.Model.CreatePredictorResponse CallAWSServiceOperation(IAmazonForecastService client, Amazon.ForecastService.Model.CreatePredictorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Forecast Service", "CreatePredictor");
            try
            {
                #if DESKTOP
                return client.CreatePredictor(request);
                #elif CORECLR
                return client.CreatePredictorAsync(request).GetAwaiter().GetResult();
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
            public System.String AlgorithmArn { get; set; }
            public Amazon.ForecastService.AutoMLOverrideStrategy AutoMLOverrideStrategy { get; set; }
            public System.String EncryptionConfig_KMSKeyArn { get; set; }
            public System.String EncryptionConfig_RoleArn { get; set; }
            public System.Int32? EvaluationParameters_BackTestWindowOffset { get; set; }
            public System.Int32? EvaluationParameters_NumberOfBacktestWindow { get; set; }
            public List<Amazon.ForecastService.Model.Featurization> FeaturizationConfig_Featurization { get; set; }
            public List<System.String> FeaturizationConfig_ForecastDimension { get; set; }
            public System.String FeaturizationConfig_ForecastFrequency { get; set; }
            public System.Int32? ForecastHorizon { get; set; }
            public List<System.String> ForecastType { get; set; }
            public List<Amazon.ForecastService.Model.CategoricalParameterRange> ParameterRanges_CategoricalParameterRange { get; set; }
            public List<Amazon.ForecastService.Model.ContinuousParameterRange> ParameterRanges_ContinuousParameterRange { get; set; }
            public List<Amazon.ForecastService.Model.IntegerParameterRange> ParameterRanges_IntegerParameterRange { get; set; }
            public System.String InputDataConfig_DatasetGroupArn { get; set; }
            public List<Amazon.ForecastService.Model.SupplementaryFeature> InputDataConfig_SupplementaryFeature { get; set; }
            public Amazon.ForecastService.OptimizationMetric OptimizationMetric { get; set; }
            public System.Boolean? PerformAutoML { get; set; }
            public System.Boolean? PerformHPO { get; set; }
            public System.String PredictorName { get; set; }
            public List<Amazon.ForecastService.Model.Tag> Tag { get; set; }
            public Dictionary<System.String, System.String> TrainingParameter { get; set; }
            public System.Func<Amazon.ForecastService.Model.CreatePredictorResponse, NewFRCPredictorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PredictorArn;
        }
        
    }
}
