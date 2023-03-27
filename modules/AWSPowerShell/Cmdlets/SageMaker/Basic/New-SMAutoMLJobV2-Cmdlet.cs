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
    /// Creates an Amazon SageMaker AutoML job that uses non-tabular data such as images or
    /// text for Computer Vision or Natural Language Processing problems.
    /// 
    ///  
    /// <para>
    /// Find the resulting model after you run an AutoML job V2 by calling <code><a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_DescribeAutoMLJobV2.html">DescribeAutoMLJobV2</a></code>.
    /// </para><para>
    /// To create an <code>AutoMLJob</code> using tabular data, see <code><a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_CreateAutoMLJob.html">CreateAutoMLJob</a></code>.
    /// </para><note><para>
    /// This API action is callable through SageMaker Canvas only. Calling it directly from
    /// the CLI or an SDK results in an error.
    /// </para></note>
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
        /// is a named input source. Similar to <code><a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_CreateAutoMLJob.html#sagemaker-CreateAutoMLJob-request-InputDataConfig">InputDataConfig</a></code> supported by <code>CreateAutoMLJob</code>. The supported formats depend on
        /// the problem type:</para><ul><li><para>ImageClassification: S3Prefix, <code>ManifestFile</code>, <code>AugmentedManifestFile</code></para></li><li><para>TextClassification: S3Prefix</para></li></ul>
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
        /// endpoint name is not generated automatically.</para><note><para>Specify the <code>EndpointName</code> if and only if you set <code>AutoGenerateEndpointName</code>
        /// to <code>False</code>; otherwise a 400 error is thrown.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ModelDeployConfig_EndpointName { get; set; }
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
        /// <para>The maximum number of times a training job is allowed to run.</para><para>For V2 jobs (jobs created by calling <code>CreateAutoMLJobV2</code>), the supported
        /// value is 1.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxCandidates { get; set; }
        #endregion
        
        #region Parameter AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxCandidates
        /// <summary>
        /// <para>
        /// <para>The maximum number of times a training job is allowed to run.</para><para>For V2 jobs (jobs created by calling <code>CreateAutoMLJobV2</code>), the supported
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
        /// see the <code><a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_StoppingCondition.html">StoppingCondition</a></code> used by the <code><a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_CreateHyperParameterTuningJob.html">CreateHyperParameterTuningJob</a></code> action.</para><para>For V2 jobs (jobs created by calling <code>CreateAutoMLJobV2</code>), this field controls
        /// the runtime of the job candidate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AutoMLProblemTypeConfig_ImageClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSeconds { get; set; }
        #endregion
        
        #region Parameter AutoMLProblemTypeConfig_TextClassificationJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSeconds
        /// <summary>
        /// <para>
        /// <para>The maximum time, in seconds, that each training job executed inside hyperparameter
        /// tuning is allowed to run as part of a hyperparameter tuning job. For more information,
        /// see the <code><a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_StoppingCondition.html">StoppingCondition</a></code> used by the <code><a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_CreateHyperParameterTuningJob.html">CreateHyperParameterTuningJob</a></code> action.</para><para>For V2 jobs (jobs created by calling <code>CreateAutoMLJobV2</code>), this field controls
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
        /// learning system. This metric is optimized during training to provide the best estimate
        /// for model parameter values from data.</para><para>Here are the options:</para><dl><dt>Accuracy</dt><dd><para>The ratio of the number of correctly classified items to the total number of (correctly
        /// and incorrectly) classified items. It is used for both binary and multiclass classification.
        /// Accuracy measures how close the predicted class values are to the actual values. Values
        /// for accuracy metrics vary between zero (0) and one (1). A value of 1 indicates perfect
        /// accuracy, and 0 indicates perfect inaccuracy.</para></dd><dt>AUC</dt><dd><para>The area under the curve (AUC) metric is used to compare and evaluate binary classification
        /// by algorithms that return probabilities, such as logistic regression. To map the probabilities
        /// into classifications, these are compared against a threshold value. </para><para>The relevant curve is the receiver operating characteristic curve (ROC curve). The
        /// ROC curve plots the true positive rate (TPR) of predictions (or recall) against the
        /// false positive rate (FPR) as a function of the threshold value, above which a prediction
        /// is considered positive. Increasing the threshold results in fewer false positives,
        /// but more false negatives. </para><para>AUC is the area under this ROC curve. Therefore, AUC provides an aggregated measure
        /// of the model performance across all possible classification thresholds. AUC scores
        /// vary between 0 and 1. A score of 1 indicates perfect accuracy, and a score of one
        /// half (0.5) indicates that the prediction is not better than a random classifier. </para></dd><dt>BalancedAccuracy</dt><dd><para><code>BalancedAccuracy</code> is a metric that measures the ratio of accurate predictions
        /// to all predictions. This ratio is calculated after normalizing true positives (TP)
        /// and true negatives (TN) by the total number of positive (P) and negative (N) values.
        /// It is used in both binary and multiclass classification and is defined as follows:
        /// 0.5*((TP/P)+(TN/N)), with values ranging from 0 to 1. <code>BalancedAccuracy</code>
        /// gives a better measure of accuracy when the number of positives or negatives differ
        /// greatly from each other in an imbalanced dataset. For example, when only 1% of email
        /// is spam. </para></dd><dt>F1</dt><dd><para>The <code>F1</code> score is the harmonic mean of the precision and recall, defined
        /// as follows: F1 = 2 * (precision * recall) / (precision + recall). It is used for binary
        /// classification into classes traditionally referred to as positive and negative. Predictions
        /// are said to be true when they match their actual (correct) class, and false when they
        /// do not. </para><para>Precision is the ratio of the true positive predictions to all positive predictions,
        /// and it includes the false positives in a dataset. Precision measures the quality of
        /// the prediction when it predicts the positive class. </para><para>Recall (or sensitivity) is the ratio of the true positive predictions to all actual
        /// positive instances. Recall measures how completely a model predicts the actual class
        /// members in a dataset. </para><para>F1 scores vary between 0 and 1. A score of 1 indicates the best possible performance,
        /// and 0 indicates the worst.</para></dd><dt>F1macro</dt><dd><para>The <code>F1macro</code> score applies F1 scoring to multiclass classification problems.
        /// It does this by calculating the precision and recall, and then taking their harmonic
        /// mean to calculate the F1 score for each class. Lastly, the F1macro averages the individual
        /// scores to obtain the <code>F1macro</code> score. <code>F1macro</code> scores vary
        /// between 0 and 1. A score of 1 indicates the best possible performance, and 0 indicates
        /// the worst.</para></dd><dt>MAE</dt><dd><para>The mean absolute error (MAE) is a measure of how different the predicted and actual
        /// values are, when they're averaged over all values. MAE is commonly used in regression
        /// analysis to understand model prediction error. If there is linear regression, MAE
        /// represents the average distance from a predicted line to the actual value. MAE is
        /// defined as the sum of absolute errors divided by the number of observations. Values
        /// range from 0 to infinity, with smaller numbers indicating a better model fit to the
        /// data.</para></dd><dt>MSE</dt><dd><para>The mean squared error (MSE) is the average of the squared differences between the
        /// predicted and actual values. It is used for regression. MSE values are always positive.
        /// The better a model is at predicting the actual values, the smaller the MSE value is</para></dd><dt>Precision</dt><dd><para>Precision measures how well an algorithm predicts the true positives (TP) out of all
        /// of the positives that it identifies. It is defined as follows: Precision = TP/(TP+FP),
        /// with values ranging from zero (0) to one (1), and is used in binary classification.
        /// Precision is an important metric when the cost of a false positive is high. For example,
        /// the cost of a false positive is very high if an airplane safety system is falsely
        /// deemed safe to fly. A false positive (FP) reflects a positive prediction that is actually
        /// negative in the data.</para></dd><dt>PrecisionMacro</dt><dd><para>The precision macro computes precision for multiclass classification problems. It
        /// does this by calculating precision for each class and averaging scores to obtain precision
        /// for several classes. <code>PrecisionMacro</code> scores range from zero (0) to one
        /// (1). Higher scores reflect the model's ability to predict true positives (TP) out
        /// of all of the positives that it identifies, averaged across multiple classes.</para></dd><dt>R2</dt><dd><para>R2, also known as the coefficient of determination, is used in regression to quantify
        /// how much a model can explain the variance of a dependent variable. Values range from
        /// one (1) to negative one (-1). Higher numbers indicate a higher fraction of explained
        /// variability. <code>R2</code> values close to zero (0) indicate that very little of
        /// the dependent variable can be explained by the model. Negative values indicate a poor
        /// fit and that the model is outperformed by a constant function. For linear regression,
        /// this is a horizontal line.</para></dd><dt>Recall</dt><dd><para>Recall measures how well an algorithm correctly predicts all of the true positives
        /// (TP) in a dataset. A true positive is a positive prediction that is also an actual
        /// positive value in the data. Recall is defined as follows: Recall = TP/(TP+FN), with
        /// values ranging from 0 to 1. Higher scores reflect a better ability of the model to
        /// predict true positives (TP) in the data, and is used in binary classification. </para><para>Recall is important when testing for cancer because it's used to find all of the true
        /// positives. A false positive (FP) reflects a positive prediction that is actually negative
        /// in the data. It is often insufficient to measure only recall, because predicting every
        /// output as a true positive yield a perfect recall score.</para></dd><dt>RecallMacro</dt><dd><para>The RecallMacro computes recall for multiclass classification problems by calculating
        /// recall for each class and averaging scores to obtain recall for several classes. RecallMacro
        /// scores range from 0 to 1. Higher scores reflect the model's ability to predict true
        /// positives (TP) in a dataset. Whereas, a true positive reflects a positive prediction
        /// that is also an actual positive value in the data. It is often insufficient to measure
        /// only recall, because predicting every output as a true positive yields a perfect recall
        /// score.</para></dd><dt>RMSE</dt><dd><para>Root mean squared error (RMSE) measures the square root of the squared difference
        /// between predicted and actual values, and it's averaged over all values. It is used
        /// in regression analysis to understand model prediction error. It's an important metric
        /// to indicate the presence of large model errors and outliers. Values range from zero
        /// (0) to infinity, with smaller numbers indicating a better model fit to the data. RMSE
        /// is dependent on scale, and should not be used to compare datasets of different sizes.</para></dd></dl><para>If you do not specify a metric explicitly, the default behavior is to automatically
        /// use:</para><ul><li><para><code>MSE</code>: for regression.</para></li><li><para><code>F1</code>: for binary classification</para></li><li><para><code>Accuracy</code>: for multiclass classification.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.AutoMLMetricEnum")]
        public Amazon.SageMaker.AutoMLMetricEnum AutoMLJobObjective_MetricName { get; set; }
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
